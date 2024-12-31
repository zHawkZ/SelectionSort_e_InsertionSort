class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Erro: Nome do arquivo não fornecido.");
            Console.WriteLine("Uso: dotnet run -- <nome-do-arquivo>");
            return 1;
        }

        string fileName = args[0];
        string projectPath = Directory.GetCurrentDirectory();
        string instanciasPath = Path.Combine(projectPath, "Instancias");
        string filePath = Path.Combine(instanciasPath, fileName);

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Erro: Arquivo {fileName} não encontrado na pasta Instancias.");
            return 1;
        }

        int[] array = LoadInstance(filePath);
        int[] arrayCopy = (int[])array.Clone();
        
        Console.WriteLine($"Quantidade de números: {array.Length}");
        
        // SelectionSort
        Console.WriteLine("\nUtilizando SelectionSort:");
        var stopwatch1 = System.Diagnostics.Stopwatch.StartNew();
        SelectionSort(array);
        stopwatch1.Stop();
        Console.WriteLine($"O Selection Sort ordenou o array em {stopwatch1.Elapsed.TotalMilliseconds * 1000:F2} μs");
        Console.WriteLine("Array ordenado:");
        Console.WriteLine(string.Join(" ", array));

        // InsertionSort
        Console.WriteLine("\nUtilizando InsertionSort:");
        var stopwatch2 = System.Diagnostics.Stopwatch.StartNew();
        InsertionSort(arrayCopy);
        stopwatch2.Stop();
        Console.WriteLine($"O Insertion Sort ordenou o array em {stopwatch2.Elapsed.TotalMilliseconds * 1000:F2} μs");
        Console.WriteLine("Array ordenado:");
        Console.WriteLine(string.Join(" ", arrayCopy));

        return 0;
    }

    static void SelectionSort(int[] A)
    {
        int n = A.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int i_min = i;
            for (int j = i + 1; j < n; j++)
            {
                if (A[j] < A[i_min])
                {
                    i_min = j;
                }
            }
            if (A[i] != A[i_min])
            {
                int temp = A[i];
                A[i] = A[i_min];
                A[i_min] = temp;
            }
        }
    }

    static void InsertionSort(int[] A)
    {
        int n = A.Length;
        for (int i = 1; i < n; i++)
        {
            int pivo = A[i];
            int j = i - 1;

            while (j >= 0 && A[j] > pivo)
            {
                A[j + 1] = A[j];
                j--;
            }
            A[j + 1] = pivo;
        }
    }

    static int[] LoadInstance(string filePath)
    {
        string content = File.ReadAllText(filePath);
        return content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}