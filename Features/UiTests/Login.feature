Feature: Login Page Tests
    Проверка функционала авторизации через UI

@ui
Scenario: Успешная авторизация
    Given Я открываю страницу логина "https://practicetestautomation.com/practice-test-login/"
    When Я ввожу логин "student" и пароль "Password123"
    And Я нажимаю кнопку входа
    Then Я должен быть перенаправлен на главную страницу

@ui
Scenario: Неудачная авторизация с неверными данными
    Given Я открываю страницу логина "https://practicetestautomation.com/practice-test-login/"
    When Я ввожу логин "wronguser" и пароль "wrongpass"
    And Я нажимаю кнопку входа
    Then Должно отображаться сообщение об ошибке "Your username is invalid!"