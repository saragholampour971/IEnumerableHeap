namespace IEnumerableHeap;

public class TaskComparer<T> : IComparer<T>
{
    private readonly Func<T, T, int> _comparisonFunction;

    public TaskComparer(Func<T, T, int> comparisonFunction)
    {
        _comparisonFunction = comparisonFunction ?? throw new ArgumentNullException(nameof(comparisonFunction));
    }

    public int Compare(T x, T y)
    {
        return _comparisonFunction(x, y);
    }
}
