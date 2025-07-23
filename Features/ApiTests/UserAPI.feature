Feature: User API Tests
    Тестирование REST API для работы с пользователями

Scenario: Получение информации о пользователе
    Given Я создаю запрос для эндпоинта "https://jsonplaceholder.typicode.com/users/1"
    When Я отправляю GET запрос
    Then Статус код ответа должен быть 200
    And В ответе должно быть поле "name" со значением "Leanne Graham"

Scenario Outline: Создание нового пользователя
    Given Я создаю запрос для эндпоинта "https://jsonplaceholder.typicode.com/users"
    When Я отправляю POST запрос с телом:
        """
        {
            "name": "<name>",
            "username": "<username>",
            "email": "<email>"
        }
        """
    Then Статус код ответа должен быть 201
    And В ответе есть поле "id"
    
    Examples:
        | name        | username   | email               |
        | John Doe    | johndoe    | john@example.com    |
        | Alice Smith | alices     | alice@example.org   |