using System.Text.Json;
using TodoManager.Models;

namespace TodoManager.Services;

public class TodoRepository
{
    private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "todo.json");
    private List<TodoItem> _items = new();

    public List<TodoItem> GetAll() => _items;

    public void Add(TodoItem item)
    {
        _items.Add(item);
    }

    public void Remove(Guid id)
    {
        _items.RemoveAll(i => i.Id == id);
    }

    public TodoItem? FindById(Guid id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    public async Task SaveAsync()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(_items, options);
        await File.WriteAllTextAsync(_filePath, json);
    }

    public async Task LoadAsync()
    {
        if (!File.Exists(_filePath)) return;

        var json = await File.ReadAllTextAsync(_filePath);
        var items = JsonSerializer.Deserialize<List<TodoItem>>(json);
        if (items != null)
            _items = items;
    }
}
