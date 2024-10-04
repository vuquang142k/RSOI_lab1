# Лабораторная работа #1

![GitHub Classroom Workflow](../../workflows/GitHub%20Classroom%20Workflow/badge.svg?branch=master)

## Continuous Integration & Continuous Delivery

### Формулировка

В рамках первой лабораторной работы требуется написать простейшее веб приложение, предоставляющее пользователю набор
операций над сущностью Person. Для этого приложения автоматизировать процесс сборки, тестирования и релиза на Heroku.

Приложение должно реализовать API:

* `GET /persons/{personId}` – информация о человеке;
* `GET /persons` – информация по всем людям;
* `POST /persons` – создание новой записи о человеке;
* `PATCH /persons/{personId}` – обновление существующей записи о человеке;
* `DELETE /persons/{personId}` – удаление записи о человеке.

[Описание API](person-service.yaml) в формате OpenAPI.

### Требования

* Исходный проект хранится на Github. Для сборки использовать
  _только_ [Github Actions](https://docs.github.com/en/actions).
* Запросы / ответы должны быть в формате JSON.
* Если запись по id не найдена, то возвращать HTTP статус 404 Not Found.
* При создании новой записи о человека (метод POST /person) возвращать HTTP статус 201 Created с пустым телом и
  Header `Location: /api/v1/persons/{personId}`, где `personId` – id созданной записи.
* Приложение должно содержать 4-5 unit-тестов на реализованные операции.
* Приложение должно быть завернуто в Docker.
* Деплой на Heroku реализовать средствами GitHub Actions, для деплоя использовать docker. Для деплоя _нельзя_
  использовать Heroku CLI или webhooks.
* В [build.yml](.github/workflows/classroom.yml) дописать шаги на сборку, прогон unit-тестов и деплой на Heroku.
* Приложение должно использовать БД для хранения записей.
* В [[inst][heroku] Lab1.postman_environment.json](postman/%5Binst%5D%5Bheroku%5D%20Lab1.postman_environment.json)
  заменить значение `baseUrl` на адрес развернутого сервиса на Heroku.

### Пояснения

* [Пример](https://github.com/Romanow/person-service) приложения на Kotlin / Spring.
* Для локальной разработки можно использовать Postgres в docker, для этого нужно запустить `docker compose up -d`,
  поднимется контейнер с Postgres 13, будет создана БД `persons` и пользователь `program:test`.
* После успешного деплоя на Heroku, через newman запускаются интеграционные тесты. Интеграционные тесты можно проверить
  локально, для этого нужно импортировать в Postman
  коллекцию [lab1.postman_collection.json](postman/%5Binst%5D%20Lab1.postman_collection.json)]) и
  environment [[local] lab1.postman_environment.json](postman/%5Binst%5D%5Blocal%5D%20Lab1.postman_environment.json).
* Для поиска нужного инструмента для сборки используется [Github Marketplace](https://github.com/marketplace).
* Пояснение как работает [Heroku](https://devcenter.heroku.com/articles/how-heroku-works).
* Для подключения БД на Heroku заходите через Dashboard в раздел Resources и в блоке `Add-ons` ищете Heroku Postgres.
  Для получения адреса, пользователя и пароля переходите в саму БД и выбираете раздел `Settings`
  -> `Database Credentials`.
* ❗Heroku не позволяет регистрировать новых пользователей, поэтому для регистрации используйте VPN.

### Прием задания

1. При получении задания у вас создается fork этого репозитория для вашего пользователя.
2. После того как все тесты успешно завершатся, в Github Classroom на Dashboard будет отмечен успешный прогон тестов.
3. ❗️С конца
   ноября [Heroku убирает Free Plan](https://help.heroku.com/RSBRUH58/removal-of-heroku-free-product-plans-faq),
   останутся только платные подписки. В связи с этим, дедлайн по сдаче ЛР #1 10 ноября. 
   
### Деплой на Railway

Сдача лабораторной работы происходила после дедлайна, в связи с чем был выбран другой хостинг с бесплатным тарифом.

Railway - облачная PaaS-платформа, на которой можно создавать инфраструктуру, разрабатывать ее локально, а затем развертывать в облаке.

Преимущества сервиса:
* деплой из ветки на Github;
* легкость масштабирования;
* возможность подключения базы данных (в том числе PostgreSQL) как сервиса;
* создание образа по Dockerfile;
* простая и интуитивно понятная конфигурация инструментов.

Недостатки:
* не поддерживает docker compose;
* поддерживает только следующие языки программирования и фреймворки (NodeJS, Deno, Python, Go, Ruby, PHP, Java, Rust, .NET, Haskell, Crystal, Swift, Zig, Dart, Staticfile, Elixir);
* нет импорта данных из дампа.

Инструкция:
1. Регистрация на Railway (под учеткой GitHub или через электронную почту).
![Страница входа Railway](https://user-images.githubusercontent.com/70375413/213858320-8e496acc-f18a-49e9-aa57-3dc88253ba4a.png)

После регистрации через почту дается 200 часов бесплатной работы. Чтобы их увеличить, необходимо пройти процедуру верификации. Верифицировать можно двумя способами: добавлением карты или подключением аккаунта GitHub. После чего количество бесплатных часов работы увеличивается до 500.

2. Создание базы данных (PosgtreSQL).
На основном дашборде нажать New Project. 
![Создание проекта Railway](https://user-images.githubusercontent.com/70375413/213858950-0397433c-a38d-485e-a5a1-7bdde56d51de.png)
Выбрать подходящую базу данных.
![Выбор сервиса для проекта.](https://user-images.githubusercontent.com/70375413/213859005-d9b6d8e8-8b19-435d-bf2f-1e406a5dd8ad.png)
Переход в настройки окружения.
![Дашборд после создания сервиса](https://user-images.githubusercontent.com/70375413/213859052-c3cb4acd-9656-467b-a45a-6d39778df666.png)
Переход на вкладку параметров окружения и их задание/просмотр.
![Задание параметров окружения](https://user-images.githubusercontent.com/70375413/213859079-d8a54f89-1eb1-4aa3-8184-7c67acd02eba.png)
Переход на вкладку подключения и копирование строки подключения. Подключение с локальной машины к базе данных и создание необходимых таблиц.
![Вкладка Connect сервиса PostgreSQL](https://user-images.githubusercontent.com/70375413/213859257-9617c619-0006-42d3-9e65-7f8aeefb0b28.png)

3. Соединение с GitHub и деплой.
Соединение с репозиторием
![Соединение с репозиторием](https://user-images.githubusercontent.com/70375413/213859365-bc2c883b-9003-41a0-8a76-663c9dc23888.png)

Настройка нового репозитория
![Настройка нового репозитория](https://user-images.githubusercontent.com/70375413/213859410-6e822914-7047-455e-b319-042a0f67ae7f.png)

Выбор проекта публичного проекта
![Выбор проекта публичного проекта](https://user-images.githubusercontent.com/70375413/213859466-71968f76-f1f3-4ded-a3b0-0a59c65ba412.png)

Наcтройка видимости для репозитория
![Наcтройка видимости для репозитория](https://user-images.githubusercontent.com/70375413/213859536-41f6d1c9-6656-4976-9c68-040887045059.png)

Добавление необходимых переменных окружения
![Добавление необходимых переменных окружения](https://user-images.githubusercontent.com/70375413/213859586-b07b8f91-1978-4439-afcc-af0df062b07b.png)

Добавление переменных для подключения к базе данных
![Добавление переменных для подключения к базе данных](https://user-images.githubusercontent.com/70375413/213859754-b9c6f1ca-c9a1-4b1a-aac4-52af7982d2ad.png)

Автоматический деплой из мастера
![Автоматический деплой из мастера](https://user-images.githubusercontent.com/70375413/213859810-6bdd4b00-49ca-4757-9a5a-5670f6e3b6d5.png)

Просмотр логов сборки
![Просмотр логов сборки](https://user-images.githubusercontent.com/70375413/213859945-57ab080a-9549-4c34-8a55-d41de1626a25.png)

Генерация доменного имени
![Генерация доменного имени](https://user-images.githubusercontent.com/70375413/213859983-f6074c75-d157-440c-a4d8-bb6f717c178e.png)

Редактирование доменного имени
![Редактирование доменного имени](https://user-images.githubusercontent.com/70375413/213860007-3ccea66b-caf0-4bd3-9420-064c11bf31f2.png)

!!! ДЛЯ КОРРЕКТНОЙ ТРЕБУЕТСЯ РАЗВЕРТКА ПРИЛОЖЕНИЯ НА 3000 ПОРТЕ !!!
Развертка на 3000 порту
![Развертка на 3000 порту](https://user-images.githubusercontent.com/70375413/213860129-21883175-421d-4da6-936b-61f511e19f69.png)

Пример работы приложения
![Пример работы приложения](https://user-images.githubusercontent.com/70375413/213860169-d1d480c3-2e3a-4307-8107-2f0b89eec534.png)



