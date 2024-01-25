using LINQTut06.Shared;

namespace PaginationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var emps = Repository.LoadEmployees();

            var page = 1; 
            var size = 10;

            Console.WriteLine("Result per page:");
            if(int.TryParse(Console.ReadLine(), out int resultPerPage))
            {
                size = resultPerPage;
            }

            Console.WriteLine("Page No.: ");
            if(int.TryParse(Console.ReadLine(), out int pageNo))
            {
                page = pageNo;
            }

            var result = emps.Paginate<Employee>(page, size);
            var startRecord = ((page - 1) * size) + 1;

            var endRecord = result.Count() < size
                            ? startRecord + result.Count() - 1
                            : size * (page - 1) + size;

            result.Print($"Showing emps from {startRecord} - {endRecord}");

        }
    }
}