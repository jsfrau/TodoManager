using TodoManager.Models;
using TodoManager.Services;

namespace TodoManager.UI;

public class Menu
{
    private readonly TodoRepository _repo;

    public Menu(TodoRepository repo)
    {
        _repo = repo;
    }

    public async Task ShowAsync()
    {
        await _repo.LoadAsync();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("== TODO MANAGER ==");
            Console.WriteLine("1. Показать задачи");
            Console.WriteLine("2. Добавить задачу");
            Console.WriteLine("3. Отметить задачу выполненной");
            Console.WriteLine("4. Сохранить и выйти");
            Console.Write("Выбор: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowTasks();
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    MarkCompleted();
                    break;
                case "4":
                    await _repo.SaveAsync();
                    return;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }

            Console.WriteLine("\nНажми любую клавишу...");
            Console.ReadKey();
        }
    }

    private void ShowTasks()
    {
        var tasks = _repo.GetAll();
        if (tasks.Count == 0)
        {
            Console.WriteLine("Нет задач.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id} | {task}");
        }
    }

    private void AddTask()
    {
        Console.Write("Заголовок: ");
        var title = Console.ReadLine() ?? "";

        Console.Write("Описание (опц.): ");
        var desc = Console.ReadLine();

        Console.Write("Дата дедлайна (дд.мм.гггг): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var date))
        {
            Console.WriteLine("Неверная дата.");
            return;
        }

        var item = new TodoItem
        {
            Title = title,
            Description = desc,
            DueDate = date
        };

        _repo.Add(item);
        Console.WriteLine("Задача добавлена.");
    }

    private void MarkCompleted()
    {
        Console.Write("Введи ID задачи: ");
        if (!Guid.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Неверный ID.");
            return;
        }

        var task = _repo.FindById(id);
        if (task == null)
        {
            Console.WriteLine("Задача не найдена.");
            return;
        }

        task.IsCompleted = true;
        Console.WriteLine("Задача отмечена как выполненная.");
    }
}
