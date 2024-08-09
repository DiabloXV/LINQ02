using ASSLINQ;
using static ASSLINQ.ListGenerators;
namespace LINQ02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Element Operators
            //Q1
            //var FirstOutOfstock = ProductList.First(p => p.UnitsInStock == 0);
            //Console.WriteLine(FirstOutOfstock);

            ////Q2
            //FirstOutOfstock = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            //Console.WriteLine(FirstOutOfstock);

            ////Q3
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var filtered = Arr.Where(x => x > 5);
            //int secondElement = filtered.ElementAt(1);

            //Console.WriteLine("The second element greater than 5 is: " + secondElement);
            #endregion

            #region Aggregate Operators
            ////Q1
            //var OddElemnts = Arr.Count(x => x % 2 != 0);
            //Console.WriteLine(OddElemnts);

            ////Q2
            //var CustomerOrders = CustomerList.Select(c => new { c, count = c.Orders.Count() });
            //foreach (var item in CustomerOrders)
            //{
            //    // Accessing the customer and their order count
            //    Console.WriteLine($"Customer: {item.c}, Number of Orders: {item.count}");
            //}

            ////Q3


            ////Q4
            //var total = Arr.Sum();
            //Console.WriteLine(total);

            ////Q5
            string[] words = File.ReadAllLines("dictionary_english.txt");

            //var totalCharacterCount = words
            //    .Select(word => word.Length)
            //    .Aggregate((total, length) => total + length);
            //Console.WriteLine($"Total number of characters: {totalCharacterCount}");

            ////Q6
            //var shortestWordLength = words.Select(word => word.Length).Min();
            //Console.WriteLine($"Length of the shortest word: {shortestWordLength}");

            ////Q7

            //var longestWordLength = words.Select(word => word.Length).Max();
            //Console.WriteLine(longestWordLength);

            ////Q8
            //var AverageWordLength = words.Select(word => word.Length).Average();
            //Console.WriteLine(AverageWordLength);

            ////Q9
            //var UnitsInStock = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, totualunits = g.Sum(p => p.UnitsInStock) });
            //foreach (var item in UnitsInStock)
            //{
            //    Console.WriteLine($"{item.Key}: Total Units in Stock: {item.totualunits}");
            //}

            ////Q10
            //var cheapestItem = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, b = g.MinBy(p => p.UnitPrice) });
            //foreach (var item in cheapestItem)
            //{
            //    Console.WriteLine($"{item.Key}:cheapest unit: {item.b}");
            //}

            ////Q11
            //var cheapestProductsPerCategory = from p in ProductList
            //                                  group p by p.Category into g
            //                                  let cheapestPrice = g.Min(p => p.UnitPrice)
            //                                  select new
            //                                  {
            //                                      CategoryId = g.Key,
            //                                      Products = g.Where(p => p.UnitPrice == cheapestPrice)
            //                                  };
            //foreach (var category in cheapestProductsPerCategory)
            //{
            //    Console.WriteLine($"Category ID: {category.CategoryId}");
            //    foreach (var product in category.Products)
            //    {
            //        Console.WriteLine($"  Product: {product.ProductName}, Price: {product.UnitPrice}");
            //    }
            //}

            ////Q12
            //var MostExpensivetItem = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, b = g.MaxBy(p => p.UnitPrice) });
            //foreach (var item in MostExpensivetItem)
            //{
            //    Console.WriteLine($"{item.Key}:most expensive unit: {item.b}");
            //}
            ////Q13
            //var mostExpensiveProducts = from p in ProductList
            //                            group p by p.Category into g
            //                            let mostExpensivePrice = g.Max(p => p.UnitPrice)
            //                            select new
            //                            {
            //                                CategoryId = g.Key,
            //                                Products = g.Where(p => p.UnitPrice == mostExpensivePrice)
            //                            };
            //foreach (var category in mostExpensiveProducts)
            //{
            //    Console.WriteLine($"Category ID: {category.CategoryId}");
            //    foreach (var product in category.Products)
            //    {
            //        Console.WriteLine($"  Product: {product.ProductName}, Price: {product.UnitPrice}");
            //    }


            //}

            //var averagePricePerCategory = ProductList.GroupBy(p => p.Category)
            //.Select(g => new
            //{
            //    CategoryId = g.Key,
            //    AveragePrice = g.Average(p => p.UnitPrice)
            //});

            //foreach (var item in averagePricePerCategory)
            //{
            //    Console.WriteLine($"Category ID: {item.CategoryId}, Average Price: {item.AveragePrice}");
            //}
            #endregion

            #region  Set Operators
            //Q1
            //var uniqueCategoryNames = ProductList.Select(p => p.Category).Distinct();

            //foreach (var categoryName in uniqueCategoryNames)
            //{
            //    Console.WriteLine(categoryName);
            //}

            //Q2
            var uniqueFirstLetters = ProductList
           .Select(p => p.ProductName[0])
           .Union(CustomerList.Select(c => c.CustomerName[0]))
           .Distinct();

            foreach (var letter in uniqueFirstLetters)
            {
                Console.WriteLine(letter);
            }

            //Q3
            var commonFirstLetters = ProductList
           .Select(p => p.ProductName[0])
           .Intersect(CustomerList.Select(c => c.CustomerName[0]));

            foreach (var letter in commonFirstLetters)
            {
                Console.WriteLine(letter);
            }

            //Q4
            var productExclusiveFirstLetters = ProductList
           .Select(p => p.ProductName[0])
           .Except(CustomerList.Select(c => c.CustomerName[0]));

            foreach (var letter in productExclusiveFirstLetters)
            {
                Console.WriteLine(letter);
            }

            //Q5
            var lastThreeCharacters = ProductList
            .Select(p => new string(p.ProductName.Reverse().Take(3).Reverse().ToArray()))
            .Concat(CustomerList.Select(c => new string(c.CustomerName.Reverse().Take(3).Reverse().ToArray())));

            foreach (var characters in lastThreeCharacters)
            {
                Console.WriteLine(characters);
            }


            #endregion

            #region Partioning Operators
            //Q1
            var firstThreeOrdersInWashington = CustomerList
           .Where(c => c.City == "Washington")
           .SelectMany(c => c.Orders)
           .Take(3);

            foreach (var order in firstThreeOrdersInWashington)
            {
                Console.WriteLine($"Order ID: {order.OrderID}");
            }

            //Q2
            var allButFirstTwoOrdersInWashington = CustomerList
            .Where(c => c.City == "Washington")
            .SelectMany(c => c.Orders)
            .Skip(2);

            foreach (var order in allButFirstTwoOrdersInWashington)
            {
                Console.WriteLine($"Order ID: {order.OrderID}");




            }

            //Q3
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var result = numbers
                .TakeWhile((num, index) => num >= index);

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }

            //Q4
            result = numbers.SkipWhile(num => num % 3 != 0);

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }

            //Q5
            result = numbers.SkipWhile((num, index) => num >= index);

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
            #endregion

            #region Quantifier Operators
            //Q1
            bool containsEi = words.Any(word => word.Contains("ei"));

            Console.WriteLine(containsEi ? "At least one word contains 'ei'." : "No word contains 'ei'.");

            //Q2
            var groupedProductsOutOfStock = ProductList.GroupBy(p => p.Category)
           .Where(g => g.Any(p => p.UnitsInStock == 0));

            foreach (var group in groupedProductsOutOfStock)
            {
                Console.WriteLine($"Category ID: {group.Key}");
                foreach (var product in group)
                {
                    Console.WriteLine($" - {product.ProductName}, Units in Stock: {product.UnitsInStock}");
                }


            }

            //Q3
            var groupedProductsAllInStock = ProductList.GroupBy(p => p.Category)
           .Where(g => g.All(p => p.UnitsInStock > 0));

            foreach (var group in groupedProductsAllInStock)
            {
                Console.WriteLine($"Category ID: {group.Key}");
                foreach (var product in group)
                {
                    Console.WriteLine($" - {product.ProductName}, Units in Stock: {product.UnitsInStock}");
                }
            }

            #endregion

            #region Grouping Operators
            ////Q1
            //List<int> numbers02 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            //var groupedNumbers = numbers02.GroupBy(n => n % 5).OrderBy(g => g.Key);

            //foreach (var group in groupedNumbers)
            //{
            //    Console.WriteLine($"Numbers with a remainder of {group.Key} when divided by 5:");
            //    foreach (var number in group)
            //    {
            //        Console.WriteLine(number);
            //    }
            //    Console.WriteLine();
            //}

            ////Q2
            //var groupedWords = words.Where(word => !string.IsNullOrWhiteSpace(word)).GroupBy(word => word[0].ToString().ToUpper()).OrderBy(g => g.Key);

            //foreach (var group in groupedWords)
            //{
            //    Console.WriteLine($"Words starting with '{group.Key}':");
            //    foreach (var word in group)
            //    {
            //        Console.WriteLine(word);
            //    }
            //    Console.WriteLine();

            //}

            ////Q3
            //string[] Random = { "from", "salt", "earn", "last", "near", "form" };

            //var groupedWords01 = Random.GroupBy(word => String.Concat(word.OrderBy(c => c))) .OrderBy(g => g.Key); 

            //foreach (var group in groupedWords)
            //{
            //    foreach (var word in group)
            //    {
            //        Console.WriteLine(word);
            //    }
            //    Console.WriteLine(". . . ."); 
            //}
            #endregion
            //Greatings!
        }

    }
}