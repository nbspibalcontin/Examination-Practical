using System;

namespace Examination_Practical
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calculate Circle

            Circle circle = new Circle { Radius = 5 };

            // Calculate the area of the circle
            double circleArea = circle.CalculateArea();

            // Calculate the perimeter of the circle
            double circlePerimeter = circle.CalculatePerimeter();

            Console.WriteLine($"Area of the circle: {circleArea}");
            Console.WriteLine($"Perimeter of the circle: {circlePerimeter}");

            // Calculate Square
            Square square = new Square();

            // Set the side length of the square
            square.Side = 5.0;

            // Calculate the area of the square
            double squareArea = square.CalculateArea();

            // Calculate the perimeter of the square
            double squarePerimeter = square.CalculatePerimeter();

            // Output the results
            Console.WriteLine("\nSquare with side length of " + square.Side);
            Console.WriteLine("Area: " + squareArea);
            Console.WriteLine("Perimeter: " + squarePerimeter);

            // Test passwords
            string[] passwords = {
            "Password123",   // Valid
            "short",         // Invalid: Too short
            "alllowercase1", // Invalid: No uppercase letter
            "ALLUPPERCASE1", // Invalid: No lowercase letter
            "NoNumbersHere", // Invalid: No digit
            "ValidPass1"     // Valid
        };

            Console.WriteLine();
            // Validate each password
            foreach (string password in passwords)
            {
                bool isValid = ValidatePassword(password);
                Console.WriteLine($"Password: {password}, Valid: {isValid}");
            }

            // Create an instance of CustomList
            CustomList list = new CustomList();

            // Add various types of elements to the list
            list.Add(1); // Adding an integer
            list.Add("Hello"); // Adding a string
            list.Add(3.14); // Adding a double
            list.Add(null); // Adding a null (should be skipped)
            list.Add("World"); // Adding another string


            // Print out the elements to verify correct addition
            Console.WriteLine("\nElements in the CustomList:");

            // Since we don't have a method to retrieve elements, we'll simulate it here
            // by iterating through the internal array up to the count
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list.Get(i)); // Assuming a Get method exists to retrieve elements
            }

            // Example order prices
            double[] orderPrices = { 50.0, 120.0, 99.99, 150.0, 101.0 };

            Console.WriteLine();
            // Calculate and display the final price for each order
            foreach (double price in orderPrices)
            {
                double finalPrice = CalculateOrderTotal(price);
                Console.WriteLine($"Original Price: ${price:F2}, Final Price after Discount: ${finalPrice:F2}");
            }
        }


        // Exam 1
        // Calculate Square and Cicle Area
        public class Circle
        {
            public double Radius { get; set; }

            public double CalculateArea()
            {
                // Calculate the area of the circle (π * radius^2)
                return Math.PI * Radius * Radius;
            }

            public double CalculatePerimeter()
            {
                // Calculate the perimeter (circumference) of the circle (2 * π * radius)
                return 2 * Math.PI * Radius;
            }
        }

        public class Square
        {
            public double Side { get; set; }

            public double CalculateArea()
            {
                // Calculate the area of the square (side * side)
                return Side * Side;
            }

            public double CalculatePerimeter()
            {
                // Calculate the perimeter of the square (4 * side)
                return 4 * Side;
            }
        }


        //Exam2
        // Add Object to array with limited capacity
        public class CustomList
        {
            private object[] elements;
            private int capacity;
            private int count;

            public CustomList()
            {
                capacity = 4;
                elements = new object[capacity];
                count = 0;
            }

            public void Add(object item)
            {
                // Skip adding if the item is null
                if (item == null)
                {
                    return;
                }

                // Check if the list is full
                if (count >= capacity)
                {
                    // The list is full, cannot add more elements
                    throw new InvalidOperationException("The list has reached its maximum capacity.");
                }

                // Add the item to the array at the current index (count)
                elements[count] = item;
                // Increment the count to reflect the added item
                count++;
            }

            // Method to get an element at a specific index
            public object Get(int index)
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return elements[index];
            }

            // Property to expose the current count of elements
            public int Count
            {
                get { return count; }
            }
        }


        // Exam 3
        // Password Validation
        public static bool ValidatePassword(string password)
        {
            // Check if the password length is at least 8 characters
            if (password.Length < 8) {
                return false;
            }

            // Check for the presence of at least one uppercase letter (A-Z)
            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            // Check for the presence of at least one uppercase letter (a-z)
            if (!password.Any(char.IsLower))
            {
                return false;
            }

            // Check for the presence of at least one digit (0-9)
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }


        // Exam 4
        // Calculate 10% and 5% Discont
        public static double CalculateOrderTotal(double originalPrice)
        {
            double finalPrice;

            // Check if the original price is greater than $100
            if (originalPrice > 100)
            {
                // Calculate 10% discount
                double discount = originalPrice * 0.10;
                // Apply discount
                finalPrice = originalPrice - discount;
            }
            else
            {
                // Calculate 5% discount
                double discount = originalPrice * 0.05;
                // Apply discount
                finalPrice = originalPrice - discount;
            }

            return finalPrice; // Return the final price
        }
    }
}