namespace TodoManager.Models;

public class TodoItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; } = false;

    public override string ToString()
    {
        return $"{(IsCompleted ? "[X]" : "[ ]")} {Title} (до {DueDate:dd.MM.yyyy})";
    }
}
