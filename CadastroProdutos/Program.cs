using CadastroProdutos;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"C:\Dados\";
        string file = "products.txt";
        Console.WriteLine("Cadastro de produto");

        List<Product> products = new();
        List<Product> productsnew = new();

        products.Add(registerProduct());
        products.Add(registerProduct());

        showAll(products);
        saveFile(products, path, file);
        productsnew = loadFile(path, file);
        showAll(productsnew);
    }
    static Product registerProduct()
    {
        Console.WriteLine("Informe um Id:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Informe o nome do produto:");
        string description = Console.ReadLine();
        Console.WriteLine("Informe o preço do produto:");
        double price = double.Parse(Console.ReadLine());
        Console.WriteLine("Informe a quantidade do produto:");
        int quantity = int.Parse(Console.ReadLine());

        return new Product(id, description, price, quantity);
    }
    static void showAll(List<Product> receivedList)
    {
        //foreach(var item in list)
        foreach (Product product in receivedList)
        {
            Console.WriteLine(product.ToString());
        }
    }
    static void saveFile(List<Product> receivedList, string path, string file)
    {
        // verifica se diretorio existe
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        StreamWriter f = new(path + file); // inicia objeto de escrita
        foreach (Product product in receivedList)
        {
            f.WriteLine(product.ToString()); // realiza escrita no arquivo
        }
        f.Close(); // fecha o arquivo
    }
    static List<Product> loadFile(string path, string file)
    {
        List<Product> newlist = new();
        foreach (string item in File.ReadLines(path + file))
        {
            string[] products = item.Split(';');
            newlist.Add(new Product(int.Parse(products[0]), products[1], double.Parse(products[2]), int.Parse(products[3])));
        }
        return newlist;
    }
}