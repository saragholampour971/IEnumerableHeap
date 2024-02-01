namespace IEnumerableHeap;
using System;
using System.Collections.Generic;

public class TaskHeap<T>
{
    private readonly List<T> _heap;
    private readonly IComparer<T> _comparer;

    public TaskHeap(IEnumerable<T> tasks, IComparer<T> comparer)
    {
        _heap = new List<T>(tasks ?? throw new ArgumentNullException(nameof(tasks)));
        _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));

        for (int i = _heap.Count / 2 - 1; i >= 0; i--)
        {
            HeapifyDown(i);
        }
    }


// i have min heap , earlier task (most priority task ) is at root , 
// least priority task will be maximum of leaf node 
    public T PeekMostPriorityTask()
    {
        if (_heap.Count == 0)
            throw new InvalidOperationException("Heap is empty");

        return _heap[0];
    }


    public T PeekLeastPriorityTask(int index) 
    {
        int left = 2 * index + 1;
        int right = 2 * index + 2;

        if (left >= _heap.Count() && right >= _heap.Count())
        {
            return _heap[index];
        }

        T currentNode = _heap.ElementAt(index);
        T leftChild = left < _heap.Count() ? _heap.ElementAt(left) : default(T);
        T rightChild = right < _heap.Count() ? _heap.ElementAt(right) : default(T);

        T maxPriorityTask = currentNode;

        if (leftChild != null &&_comparer.Compare(leftChild,maxPriorityTask)  > 0)
        {
            maxPriorityTask = leftChild;
        }

        if (rightChild != null && _comparer.Compare(rightChild,maxPriorityTask)  > 0)
        {
            maxPriorityTask = rightChild;
        }

        T leftMaxPriority = PeekLeastPriorityTask(left);
        T rightMaxPriority = PeekLeastPriorityTask(right);

        if (leftMaxPriority != null && _comparer.Compare(leftMaxPriority,maxPriorityTask) > 0)
        {
            maxPriorityTask = leftMaxPriority;
        }

        if (rightMaxPriority != null && _comparer.Compare(rightMaxPriority,maxPriorityTask) > 0)
        {
            maxPriorityTask = rightMaxPriority;
        }

        return maxPriorityTask;
    }

    private void HeapifyDown(int index)
    {
        int left = 2 * index + 1;
        int right = 2 * index + 2;
        int smallest = index;

        if (left < _heap.Count && _comparer.Compare(_heap[left], _heap[smallest]) < 0)
        {
            smallest = left;
        }

        if (right < _heap.Count && _comparer.Compare(_heap[right], _heap[smallest]) < 0)
        {
            smallest = right;
        }

        if (smallest != index)
        {
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }

    private void Swap(int i, int j)
    {
        T temp = _heap[i];
        _heap[i] = _heap[j];
        _heap[j] = temp;
    }
}

