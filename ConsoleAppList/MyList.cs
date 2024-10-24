using System.Dynamic;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using System.Data.Common;

public class MyList()
{
    int[] arr = new int[4];
    int _counter;
    public int Count { get { return _counter; }}

    public void Add(int add)
    {
        _counter++;
        if (_counter > arr.Length)
        {
            Resize();
        }
        arr[_counter - 1] = add;
    }
    public void Insert(int add, int index)
    {
        _counter++;
        if (_counter > arr.Length)
        {
            Resize();
        }
        int[] temp1 = new int[_counter - index];
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
    public void Remove(int rem)
    {
        if (_counter == 0)
        {
            throw new ArgumentOutOfRangeException("Список не содержет элементов");
        }
        // обработка случая, когда список пуст
        int ind = -1;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] == rem)
            {
                ind = i;
                break;
            }
        }
        // метод находит индект элемента и удаляет его методом RemoveAt
        RemoveAt(ind);
    }
    public void RemoveAt(int index)
    {
        if (_counter == 0)
        {
            throw new ArgumentOutOfRangeException("Список не содержет элементов");
        }
        // обработка случая, когда список пуст
        _counter--;
        if (_counter == 0)
        {
            Clear();
        }
        else
        {
            int[] temp1 = new int[_counter - index];
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
        arr = new int[4];
        _counter = 0;
        // присваиваем массиву новый пустой массив
    }
    public void Resize()
    {
        int[] arrTemp = new int[arr.Length * 2];
        for (int i = 0; i < arr.Length; i++)
        {
            arrTemp[i] = arr[i];
        }
        arr = arrTemp;
        // выделение нового места для элементов списка
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
        // вывод элементов списка в виде строки
        return s;
    }
}