using System.Dynamic;

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

    }
    public void RemoveAt(int rem, int index)
    {

    }
    public void Clear()
    {

    }
    public string ListToString()
    {
        string s = string.Join(", ", arr);
        return s;
    }
}