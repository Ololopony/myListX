using System.Dynamic;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using System.Data.Common;

public class MyList<T>()
{
    T[] arr = new T[4];
    int _counter;
    public int Count { get { return _counter; }}

    public void Add(T add)
    {
        _counter++;
        if (_counter > arr.Length)
        {
            Resize();
        }
        arr[_counter - 1] = add;
    }
    public void Insert(T add, int index)
    {
        _counter++;
        if (_counter > arr.Length)
        {
            Resize();
        }
        T[] temp1 = new T[_counter - index];
        for (int i = index; i < _counter; i++)
        {
            temp1[i - index] = arr[i];
        }
        arr[index] = add;
        for (int i = index + 1; i < _counter; i++)
        {
            arr[i] = temp1[i - (index + 1)];
        }
    }
    public void Remove(T rem)
    {
        RemoveAt(IndexOfItem(rem));
    }
    public void RemoveAt(int index)
    {
        if (_counter == 0)
        {
            throw new ArgumentOutOfRangeException("List is empty");
        }
        _counter--;
        if (_counter == 0)
        {
            Clear();
        }
        else
        {
            T[] temp1 = new T[_counter - index];
            for (int i = index + 1; i < _counter + 1; i++)
            {
                temp1[i - (index + 1)] = arr[i];
            }
            for (int i = index; i < _counter; i++)
            {
                arr[i] = temp1[i - index];
            }
        }
    }
    public void Clear()
    {
        arr = new T[4];
        _counter = 0;
    }
    public void Resize()
    {
        T[] arrTemp = new T[arr.Length * 2];
        for (int i = 0; i < arr.Length; i++)
        {
            arrTemp[i] = arr[i];
        }
        arr = arrTemp;
    }
    public string ListToString()
    {
        string s = "";
        for (int i = 0; i < _counter; i++)
        {
            s += arr[i];
            if (i + 1 != _counter)
            {
                s += ", ";
            }
        }
        return s;
    }
    public int IndexOfItem(T item)
    {
        if (item is not null)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (item.Equals(arr[i]))
                {
                    return i;
                }
            }
            throw new Exception("Item was not found");
        }
        else
        {
            throw new Exception("Collection's item is null");
        }
    }
    public void ForeEachItem(System.Action<T> action)
    {
        for (int i = 0; i < _counter; i++)
        {
            action(arr[i]);
        }
    }
    public T? Find(System.Func<T, bool> predicate)
    {
        for (int i = 0; i < _counter; i++)
        {
            if (predicate(arr[i]))
            {
                return arr[i];
            }
        }
        return default(T);
    }
    /*public T? Find(System.Predicate<T> match)
    {
        for (int i = 0; i < _counter; i++)
        {
            if (match(arr[i]))
            {
                return arr[i];
            }
        }
        return default(T);
    }*/
    public void Sort(System.Func<T, T, int> sort)
    {
        for (int i = 0; i < _counter; i++)
        {
            for (int j = 0; j < _counter - i - 1; j++)
            {
                if (sort(arr[j], arr[j + 1]) == 1)
                {
                    Swap(ref arr[j], ref arr[j + 1]);
                }
            }
        }
    }
    static private void Swap(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }
}