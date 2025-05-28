using TodoManager.Services;
using TodoManager.UI;

namespace TodoManager;

class Program
{
    static TodoRepository? _repo;

    static async Task Main()
    {
        _repo = new TodoRepository();

        AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

        var menu = new Menu(_repo);
        await menu.ShowAsync();
    }

    private static void OnProcessExit(object? sender, EventArgs e)
    {
        if (_repo != null)
        {
            Console.WriteLine("⏳ Сохраняю данные перед выходом...");
            _repo.SaveAsync().GetAwaiter().GetResult();
            Console.WriteLine("✅ Задачи сохранены.");
        }
    }
}
