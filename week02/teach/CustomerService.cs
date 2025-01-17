using System;
using System.Collections.Generic;

/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test Cases

        // Test 1: Add and Serve Customers
        Console.WriteLine("Test 1");
        var cs = new CustomerService(3);
        cs.AddNewCustomer("Alice", "A001", "Forgot password");
        cs.AddNewCustomer("Bob", "B002", "Payment issue");
        cs.AddNewCustomer("Charlie", "C003", "Account locked");
        cs.ServeCustomer(); // Should serve Alice
        cs.ServeCustomer(); // Should serve Bob
        cs.ServeCustomer(); // Should serve Charlie
        cs.ServeCustomer(); // Should display empty queue message
        Console.WriteLine("=================");

        // Test 2: Queue Overflow
        Console.WriteLine("Test 2");
        cs = new CustomerService(2);
        cs.AddNewCustomer("Alice", "A001", "Forgot password");
        cs.AddNewCustomer("Bob", "B002", "Payment issue");
        cs.AddNewCustomer("Charlie", "C003", "Account locked"); // Should display overflow message
        Console.WriteLine("=================");

        // Test 3: Default Queue Size
        Console.WriteLine("Test 3");
        cs = new CustomerService(0); // Should default to size 10
        for (int i = 1; i <= 11; i++) {
            cs.AddNewCustomer($"Customer{i}", $"ID{i}", $"Problem{i}");
        } // Should allow only 10 customers
        cs.ServeCustomer(); // Should serve Customer1
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        _maxSize = maxSize > 0 ? maxSize : 10;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Add a new customer into the queue.
    /// </summary>
    public void AddNewCustomer(string name, string accountId, string problem) {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
        Console.WriteLine($"Added: {customer}");
    }

    /// <summary>
    /// Serve the next customer in the queue.
    /// </summary>
    public void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers to serve.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine($"Serving: {customer}");
    }

    /// <summary>
    /// Provide a string representation of the customer service queue.
    /// </summary>
    public override string ToString() {
        return $"[size={_queue.Count}, max_size={_maxSize}] => " +
               string.Join(", ", _queue);
    }
}
