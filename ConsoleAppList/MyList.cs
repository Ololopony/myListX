using System.Dynamic;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;

public class MyList()
{
    int[] arr = new int[0];
    int _counter;
    public int Count { get { return _counter; } set { _counter = value; } }

    public void Add(int add)
    {
        _counter++;
        int[] temp = new int[_counter];
        // создание нового массива с размером на один элемент больше
        for (int i = 0; i < arr.Length; i++)
        {
            temp[i] = arr[i];
            // перенос элементов во временный массив
        }
        temp[_counter - 1] = add;
        arr = (int[])temp.Clone();
        // добавление нового элемента и клонирование временного масива
    }
    public void Insert(int add, int index)
    {

    }
    public void Remove(int rem)
    {
        if (_counter == 0)
        {
            throw new ArgumentOutOfRangeException($"{_counter} - _counter, список не содержет элементов");
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
            throw new ArgumentOutOfRangeException($"{index} - index, список не содержет элементов");
        }
        // обработка случая, когда список пуст
        _counter--;
        if (_counter == 0)
        {
            Clear();
        }
        else
        {
            int[] temp1 = new int[index];
            int[] temp2 = new int[arr.Length - (index + 1)];
            for (int i = 0; i < index; i++)
            {
                temp1[i] = arr[i];
            }
            for (int i = index + 1; i < arr.Length; i++)
            {
                temp2[i - (index + 1)] = arr[i];
            }
            // элементы основного массива делятся на 2 временных за исключением искомого
            int[] temp3 = new int[temp1.Length + temp2.Length];
            for (int i = 0; i < temp1.Length; i++)
            {
                temp3[i] = temp1[i];
            }
            for (int i = temp1.Length; i < temp3.Length; i++)
            {
                temp3[i] = temp2[i - temp1.Length];
            }
            // временные массивы склеиваются в один и клонируются в основной
            arr = (int[])temp3.Clone();
        }
    }
    public void Clear()
    {
        int[] temp = new int[0];
        arr = (int[])temp.Clone();
        _counter = 0;
        // присваивание массиву новый пустой массив
    }
    public string ListToString()
    {
        string s = string.Join(", ", arr);
        return s;
    }
}