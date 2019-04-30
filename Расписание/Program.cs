using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Расписание
{
    class Data_classes
    {
        public Dictionary<int, string> names_of_subjects = new Dictionary<int, string>();
        public Dictionary<int, int> hours_of_subjects = new Dictionary<int, int>();
        public Data_classes(Dictionary<int, string> a, Dictionary<int, int> b)
        {
            names_of_subjects = a;
            hours_of_subjects = b;
        }
    }

    public class Matrix
    {
        bool[,] a;
        int index1;
        int index2;

        public Matrix(bool[,] mat)
        {
            a = mat;
            index1 = mat.GetLength(0);
            index2 = mat.GetLength(1);
        }

        void Change(bool f,int i,int j)
        {

        }

        void Clear()
        {
            for (int i = 0; i < index1; i++)
                for (int j = 0; j < index2; j++)
                    a[i, j] = false;
        }

        bool Res(int i, int j)
        {
            return a[i, j];
        }
    }

    public class Matrix_Limit : Matrix
    {
        bool[,] Mat;
        List<string> Day = new List<string>() { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
        List<string> Time = new List<string>() { "8:00", "9:40", "11:30", "13:10", "15:00", "16:40", "18:20" };
        public Matrix_Limit(bool[,] a):base(a)
        {
            Mat = a;
        }
        public bool[,] ReturnMatrix()
        {
            return Mat;
        }
    }

    class Limit_List
    {
        List<Matrix_Limit> list1;

        public Limit_List(List<Matrix_Limit> a)
        {
            list1 = a;
        }

        public bool[,] ReturnMatrix (int i)
        {
            return list1[i].ReturnMatrix();
        }
    }

    class List_of_all_Limits
    {
        List<Limit_List> list2;
        public List_of_all_Limits(List<Limit_List> a)
        {
            list2 = a;
        }
    }

    class List_limit
    {
        List<string> result;
    }

    class List_limits:List<List_limit>
    {

    }

    class Program
    {

        static bool[,] Limit_of_4_classes(int i1, int i2, int i3, int i4, int i5, int i6)
        {
            bool[,] a = new bool[7, 6];

            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 6; j++)
                    a[i, j] = true;

            for (int i = i1; i < i1+4; i++)
                a[i, 0] = false;
            for (int i = i2; i < i2+4; i++)
                a[i, 1] = false;
            for (int i = i3; i < i3+4; i++)
                a[i, 2] = false;
            for (int i = i4; i < i4+4; i++)
                a[i, 3] = false;
            for (int i = i5; i < i5+4; i++)
                a[i, 4] = false;
            for (int i = i6; i < i6+4; i++)
                a[i, 5] = false;

            return a;
        }

        static bool[,] Limit_of_2_after_2(int k)
        {
            bool[,] a = new bool[7, 6];

            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 6; j++)
                    a[i, j] = true;

            for (int i = 0; i < 7; i++)
                for (int j = k; j < 6; j+=4)
                    if (j == 5)
                    a[i, j] = false;
                    else
                    {
                        a[i,j] = false;
                        a[i,j+1] = false;
                    }
            return a;
        }

        static void Main(string[] args)
        {
            string name;
            int hours,
                key=0;

            Dictionary<int, string> names_of_subjects = new Dictionary<int, string>();
            Dictionary<int, int> hours_of_subjects = new Dictionary<int, int>();
            Console.WriteLine("Введите название предмета и количество часов: ");
            do
            {
                Console.Write("Предмет: ");
                name = Console.ReadLine();
                if (name == "")
                    break;
                Console.Write("Кол-во часов:");
                hours = Convert.ToInt32(Console.ReadLine());
                key += 1;
                names_of_subjects.Add(key, name);
                hours_of_subjects.Add(key, hours);
            } while (true);
            Data_classes Subject = new Data_classes(names_of_subjects, hours_of_subjects);

            List<Matrix_Limit> List_of_limit = new List<Matrix_Limit>();
            bool[,] mat = new bool[7, 6];
            

//Ограничение на 4 пары в день

            for (int i1 = 0; i1 < 4; i1++)
                for (int i2 = 0; i2 < 4; i2++)
                    for (int i3 = 0; i3 < 4; i3++)
                        for (int i4 = 0; i4 < 4; i4++)
                            for (int i5 = 0; i5 < 4; i5++)
                                for (int i6 = 0; i6 < 4; i6++)
                                {
                                    mat = Limit_of_4_classes(i1,i2,i3,i4,i5,i6);
                                    Matrix_Limit Mat_of_limit = new Matrix_Limit(mat);
                                    List_of_limit.Add(Mat_of_limit);
                                }
            Limit_List List_Limit_of_4_classes = new Limit_List(List_of_limit);
            List_of_limit.Clear();

            for (int i = 0; i < 3; i+=2) 
            {
                mat = Limit_of_2_after_2(i);
                for (int l = 0; l < 7; l++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.Write(Convert.ToInt32(mat[l, j]));
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                    Matrix_Limit Mat_of_Limit = new Matrix_Limit(mat);
                List_of_limit.Add(Mat_of_Limit);
            }
            Limit_List List_Limit_of_2_after_2 = new Limit_List(List_of_limit);

            for(int i=0;i<)

            Console.ReadKey();
        }
    }
}
