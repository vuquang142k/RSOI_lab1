using Moq;
using Xunit;
using Person.Controllers;
using Person.InterfaceDB;
using Person.Model;
using Person.Service;

namespace PersonTests
{
    public class UnitTest1
    {
        [Fact]
        public void FindAll_NotNull()
        {
            // Arrange
            var expPerson = new PersonBuilder().Build();
            var expPeople = new List<People>() { expPerson };

            var mock = new Mock<IPersonRepository>();
            mock.Setup(x => x.getAllPerson())
                .Returns(expPeople);
            var personServices = new PersonService(mock.Object);

            // Act
            var actPeople = personServices.getAllPerson();

            // Assert
            Assert.NotNull(expPeople);
            Assert.Equal(expPeople, actPeople);
        }

        [Fact]
        public void FindById_FirstElement_NotNull()
        {
            const int personId = 1;

            // Arrange
            var expPerson = new PersonBuilder()
                .WherePersonId(personId)
                .Build();

            var mock = new Mock<IPersonRepository>();
            mock.Setup(x => x.FindById(personId))
                .Returns(expPerson);
            var personServices = new PersonService(mock.Object);

            // Act
            var actPerson = personServices.FindById(personId);

            // Assert
            Assert.NotNull(expPerson);
            Assert.Equal(expPerson, actPerson);
        }

        [Fact]
        public void AddPerson_Ok()
        {
            // Arrange
            var accessObject = new PersonAccessObject();
            var personToAdd = CreatePerson();
            AddEntity(accessObject, personToAdd);

            // Act
            accessObject.personRepository.Add(personToAdd);

            // Assert
            var addedPerson = accessObject.personRepository.FindById(personToAdd.id);

            Assert.NotNull(addedPerson);
            Assert.Equal(personToAdd, addedPerson);

            Cleanup(accessObject);
        }

        [Fact]
        public void UpdatePerson_Ok()
        {
            // Arrange
            var accessObject = new PersonAccessObject();
            var personToUpdate = CreatePerson();
            AddEntity(accessObject, personToUpdate);

            // Act
            personToUpdate.age += 5;
            accessObject.personRepository.updatePerson(personToUpdate.id, personToUpdate);

            // Assert
            var updatedPerson = accessObject.personRepository.FindById(personToUpdate.id);
            Assert.NotNull(updatedPerson);
            Assert.Equal(personToUpdate, updatedPerson);

            Cleanup(accessObject);
        }

        [Fact]
        public void DeletePersonById_Ok()
        {
            // Arrange
            var accessObject = new PersonAccessObject();
            var personToDelete = CreatePerson();
            AddEntity(accessObject, personToDelete);

            // Act
            var id = personToDelete.id;
            accessObject.personRepository.deletePerson(id);

            // Assert
            var removedPerson = accessObject.personRepository.FindById(id);
            Assert.Null(removedPerson);

            Cleanup(accessObject);
        }

        People CreatePerson()
        {
            var person = new People()
            {
                id = 11,
                name = "Test",
                age = 1,
                address = "Address",
                work = "Pass"
            };
            return person;
        }

        void AddEntity(PersonAccessObject accessObject, People person)
        {
            accessObject.peopleContext.ChangeTracker.Clear();
            accessObject.peopleContext.people.Add(person);
            accessObject.peopleContext.SaveChanges();
        }

        void Cleanup(PersonAccessObject accessObject)
        {
            accessObject.peopleContext.ChangeTracker.Clear();
            accessObject.peopleContext.people.RemoveRange(accessObject.peopleContext.people);
            accessObject.peopleContext.SaveChanges();
        }
    }
}