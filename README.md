# TodoManager

Консольное приложение на языке C# для управления списком задач. Поддерживает добавление, просмотр, поиск, удаление и отметку задач как выполненных. Все данные сохраняются в файл `todo.json` и автоматически загружаются при запуске приложения.

## Возможности

- Добавление задач с названием, описанием и сроком выполнения
- Просмотр всех текущих задач
- Удаление задачи по ID
- Отметка задачи как выполненной
- Поиск задач по части названия
- Проверка корректности введённых данных
- Автоматическое сохранение при выходе из программы
- Сохранение и загрузка задач в формате JSON

## Структура проекта

```
TodoManager/
├── Models/           # Модель задачи (TodoItem)
├── Services/         # Репозиторий задач и работа с JSON
├── UI/               # Меню и взаимодействие с пользователем
├── Program.cs        # Точка входа в приложение
├── todo.json         # Файл с сохранёнными задачами (создаётся автоматически)
└── README.md         # Информация о проекте
```

## Запуск

Для запуска проекта требуется .NET 6.0 или новее.

### Через Visual Studio:
1. Открой файл решения `.sln`
2. Нажми `Ctrl + F5` для запуска без отладки

### Через терминал:

```bash
dotnet run
```

## Использование

При запуске отображается текстовое меню. Пользователь может выбрать одно из доступных действий, следуя инструкциям в консоли.

Файл `todo.json` автоматически создаётся в каталоге сборки (`bin/Debug/net6.0/`) и используется для хранения списка задач между сессиями.

## Зависимости

- .NET 6.0 или новее
- System.Text.Json (входит в стандартную библиотеку .NET)
