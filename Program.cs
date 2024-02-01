namespace IEnumerableHeap;



class Program
{
    public static void Main(string[] args)
    {


        Func<MyTask, MyTask, int> comparisonFunction = (task1, task2) =>
        {
            return task1.DueDate.CompareTo(task2.DueDate);
        };

        var comparer = new TaskComparer<MyTask>(comparisonFunction);

        var tasks = new List<MyTask>
        {
            new MyTask { Title = "MyTask 1", CreatedDate = DateTime.Now, DueDate = DateTime.Now.AddDays(3) },
            new MyTask { Title = "MyTask 2", CreatedDate = DateTime.Now, DueDate = DateTime.Now.AddDays(1) },
            new MyTask { Title = "MyTask 3", CreatedDate = DateTime.Now, DueDate = DateTime.Now.AddDays(2) }
        };

        var taskHeap = new TaskHeap<MyTask>(tasks, comparer);

        MyTask mostPriorityTask = taskHeap.PeekLeastPriorityTask(0);
        MyTask leastPriorityTask = taskHeap.PeekMostPriorityTask();
        Console.WriteLine($"most Priority MyTask: {mostPriorityTask.Title}");
        Console.WriteLine($"least Priority MyTask: {leastPriorityTask.Title}");

    }
}
