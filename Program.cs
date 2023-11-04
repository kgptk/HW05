using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW05
{
    internal class Program
    {
         //Напишите алгоритм, определяющий наличие выхода из лабиринта и выводящий на экран
         //координаты точки выхода, если таковые имеются.
         static void Main(string[] args)
         {
             int[,] labirint = new int[,]
         {
             {1, 1, 1, 1, 1, 1, 1 },
             {1, 0, 0, 0, 0, 0, 1 },
             {1, 0, 1, 1, 1, 0, 1 },
             {0, 0, 0, 0, 1, 0, 0 },
             {1, 1, 0, 0, 1, 1, 1 },
             {1, 1, 1, 0, 1, 1, 1 },
             {1, 1, 1, 0, 1, 1, 1 }
         };
        
             Console.WriteLine($"Количество выходов равно {HasExix(labirint)}");
             Console.ReadKey();
         }
        
         static int HasExix(int[,] l)
         {
             var stack = new Stack<Tuple<int, int>>();
             Tuple<int, int> point = new Tuple<int, int>(1, 1);
             stack.Push(point);
             int count = 0;
             while (stack.Count > 0)
             {
                 var temp = stack.Pop();
                 int i = temp.Item1;
                 int j = temp.Item2;
        
                 //Если элемент стека равен 0 и стоит на краю, то он является выходом
                 if (l[i, j] == 0 && (i == 0 || j == 0) || i == l.GetLength(0)-1 || j == l.GetLength(1)-1)
                 {
                     count++;
                 }
        
                 l[i, j] = 1;
        
                 if (j - 1 >= 0 && l[i, j - 1] != 1)
                 //если номер столбца элемента расположенного слева от текущего неотрицателен
                 //и этот элемент не равен 1
                 {
                     Tuple<int, int> p = new Tuple<int, int>(i, j - 1);
                     stack.Push(p);
                 }
                 //добавляем в стек координаты элемента слева от текущего
        
                 if (j + 1 < l.GetLength(1) && l[i, j + 1] != 1)
                 //если номер столбца элемента справа отностительно текущего элемента меньше количества
                 // столбцов в лабиринте  и  он не единица
                 {
                     Tuple<int, int> p = new Tuple<int, int>(i, j + 1);
                     stack.Push(p);
                 }
                 //добавляем в стек координаты элемента справа от текущего
        
                 if (i - 1 >= 0 && l[i - 1, j] != 1)
                 //если номер строки элемента, расположенного сверху от текущего элемента неотрицательный
                 //и этот элемент не единица
                 {
                     Tuple<int, int> p = new Tuple<int, int>(i - 1, j);
                     stack.Push(p);
                 }
                 //добавляем в стек координаты элемента, расположенного сверху от текущего
        
                 if (i + 1 < l.GetLength(0) && l[i + 1, j] != 1)
                 //если номер строки  элемента снизу от текущего меньше количества строк в массиве и этот 
                 // элемент не равен единице то добавляем его координаты в стек
                 {
                     Tuple<int, int> p = new Tuple<int, int>(i + 1, j);
                     stack.Push(p);
                 }
        
             }
             return count;
         }

    }
}
