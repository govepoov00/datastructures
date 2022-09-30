using System;

    class datastructure
    {
        //generate array with random value which are unique
        public static int[] RandomArray(int n, bool sort)
        {
            int[] array = new int[n];
            var rand = new Random(); //random number 
            int randnum;
            //Create random array
            for (int i = 0; i < n; i++)
            {
                randnum=1+rand.Next(99);
                //Check if random number is unique before inserting otherwise regenerate
                do {
                if(!array.Contains(randnum))
                  {
                    array[i] = randnum;
                    break;
                  }
                  else
                  randnum=1+rand.Next(99);
                }while(true);
            }
            if(sort)  //Need array sorted for binary search
            Array.Sort(array); 
            displayArray(array);
            return array;
        }

        //Display an array with position and values
        public static void displayArray(int[] array)
        {
                //Display Array Positions
            int n = array.Length;
            Console.Write("Pos[");
            for (int i = 0; i < n; i++)
             {
                Console.Write(i+1);
                if(i < n-1)
                {
                    if(i < 9)
                    Console.Write(" ][");
                    else
                    Console.Write("][");
                }
                else
                {
                    if(i < 9)
                    Console.WriteLine(" ]");
                    else
                    Console.WriteLine("]");
                }
             }

             //Display Array Vals
             Console.Write("Val[");
            for (int i = 0; i < n; i++)
             {
                Console.Write(array[i]);
                if(i < n-1)
                {
                    if(array[i] <= 9)
                    Console.Write(" ][");
                    else
                    Console.Write("][");
                }
                else
                {
                    if(array[i] <= 9)
                    Console.WriteLine(" ]");
                    else
                    Console.WriteLine("]");
                }
             }
        }


        static void linearsearch(int n)
        {
            // Going through array sequencially
            Console.WriteLine("1. Linear Search");
            int[] array = RandomArray(n,false);
            Console.Write("Enter Value to search for: ");
            int item = Convert.ToInt32(Console.ReadLine());

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                if (array[i] == item)
                {
                    Console.WriteLine(item+" is in position "+(i+1));
                    watch.Stop();
                    Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
                    return;
                }
            }        
             Console.WriteLine(item+" is not found in array");  
             watch.Stop();
             Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        static void binarySearch(int n)
        {
            Console.WriteLine();
            Console.WriteLine("2. Binary Search");
            int[] array = RandomArray(n,true);
            
            Console.Write("Enter Value to search for: ");
            int item = Convert.ToInt32(Console.ReadLine());
            // Repeat until the pointers low and high meet each other
            int low = 0; 
            int high = n-1;
            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (array[mid] == item)
                {
                   Console.WriteLine(item+" is in position "+(mid+1));
                   return;
                }
                if (array[mid] < item)
                    low = mid + 1;

                else
                    high = mid - 1;
            }
            
            Console.WriteLine(item+" is not found in array");
        }


        static void bubblesort(int n)
        {
            Console.WriteLine();
            Console.WriteLine("3. Bubble Sort");
            Console.WriteLine("Original array");
            int[] array = RandomArray(n,false);
            int temp;

            Console.Write("Do you want to sort (a)scending or (d)escending: ");
            char sorttype = Console.ReadKey().KeyChar;  //Testing execution time 
          
            for (int j = 0; j <= n-2; j++)
            {
                for (int i = 0; i <= n-2; i++)
                {
                    if(sorttype=='a')
                    {
                        if (array[i] > array[i + 1])
                        {
                            temp = array[i + 1];
                            array[i + 1] = array[i];
                            array[i] = temp;
                        }
                    }
                    if(sorttype=='d')
                    {
                        if (array[i] < array[i + 1])
                        {
                            temp = array[i + 1];
                            array[i + 1] = array[i];
                            array[i] = temp;
                        }
                    }

                }            
            }
          

            Console.WriteLine();
        
            if(sorttype=='a')
            Console.WriteLine("Array sorted in ascending order");
            if(sorttype=='d')
            Console.WriteLine("Array sorted in descending order");
            displayArray(array);
            
        }

        static void insertionsort(int n)
        {
            Console.WriteLine();
            Console.WriteLine("4. Insertion Sort");
            Console.WriteLine("Original array");
            int[] array = RandomArray(n,false);
            int j,temp;

            Console.Write("Do you want to sort (a)scending or (d)escending: ");
            char sorttype = Console.ReadKey().KeyChar;

            for (int i = 1; i < n; i++)
            {
                temp = array[i];
                j = i - 1;
                if(sorttype=='a')
                while (j >= 0 && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                if(sorttype=='d')
                while (j >= 0 && array[j] < temp)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = temp;
            }

            Console.WriteLine();
            if(sorttype=='a')
            Console.WriteLine("Array sorted in ascending order");
            if(sorttype=='d')
            Console.WriteLine("Array sorted in descending order");
            displayArray(array);
            
        }

        static void selectionsort(int n)
        {
            Console.WriteLine();
            Console.WriteLine("5. Selection Sort");
            Console.WriteLine("Original array");
            int[] array = RandomArray(n,false);
            int temp,selection;

            Console.Write("Do you want to sort (a)scending or (d)escending: ");
            char sorttype = Console.ReadKey().KeyChar;

            for (int i = 0; i < n - 1; i++) 
            {
                selection = i;
                for (int j = i + 1; j < n; j++) {
                    if(sorttype=='a')
                        if (array[j] < array[selection]) 
                        {
                            selection = j;
                        }
                    if(sorttype=='d')
                        if (array[j] > array[selection]) 
                        {
                            selection = j;
                        }    
                
                }
                temp = array[selection];
                array[selection] = array[i];
                array[i] = temp;
            }

            Console.WriteLine();
            if(sorttype=='a')
            Console.WriteLine("Array sorted in ascending order");
            if(sorttype=='d')
            Console.WriteLine("Array sorted in descending order");
            displayArray(array);
            
        }

        static void quicksort(int[] array, int i, int j, int pivot)
        {
             //Quick Sort
            displayArray(array);
            
            int temp;
            Console.WriteLine("i:"+i+";j:"+j+";pivot:"+pivot);
          if(i <= j)
          { 
           for(int ct=i;array[ct]<=pivot;ct++)
            {
              i++; 
            }
            for(int ct=j;array[ct]>=pivot;ct--)
            {
              j--;
            }
            if(i < j) 
            {
                temp = array[i];
                array[i]= array[j];
                array[j] = temp; 
            }   
            
            quicksort(array,i,j,pivot);
            
          } 
          
            temp = pivot;
            pivot= array[j];
            array[j] = temp; 
    
        }

        public static void Main()   // while runing the program, change the funtion name to "main"
        {
           
           /*
            linearsearch(20);
            Console.WriteLine("Press any key to continue to Binary Search");
            Console.ReadKey();
            binarySearch(20);
            Console.WriteLine("Press any key to continue to Bubble Sort");
            Console.ReadKey();
            bubblesort(30);
            Console.WriteLine("Press any key to Continue to Insertion Sort");
            Console.ReadKey();
            insertionsort(20);
            Console.WriteLine("Press any key to Continue to Selection Sort");
            Console.ReadKey();
            selectionsort(20);
            */
 Console.WriteLine("Original Array");  
 int[] array = RandomArray(20,false);
          quicksort(array,0,(array.Length-1),array[0]);
          Console.WriteLine("QuickSort Array");  
           displayArray(array);

        }
    }
