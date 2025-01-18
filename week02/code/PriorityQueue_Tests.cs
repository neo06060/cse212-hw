using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue them.
    // Expected Result: Items are dequeued in the order of their priority (highest priority first, FIFO for ties).
    public void TestPriorityQueue_BasicEnqueueDequeue()
    {
        var priorityQueue = new PriorityQueue();

        // Enqueue items with different priorities
        priorityQueue.Enqueue("Item1", 1);  // Priority 1
        priorityQueue.Enqueue("Item2", 3);  // Priority 3
        priorityQueue.Enqueue("Item3", 2);  // Priority 2

        // Expected dequeue order: Item2 (priority 3), Item3 (priority 2), Item1 (priority 1)
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority.
    // Expected Result: Items with the same priority are dequeued in the order they were enqueued (FIFO).
    public void TestPriorityQueue_TieBreakerFIFO()
    {
        var priorityQueue = new PriorityQueue();

        // Enqueue items with the same priority
        priorityQueue.Enqueue("Item1", 5);  // Priority 5
        priorityQueue.Enqueue("Item2", 5);  // Priority 5
        priorityQueue.Enqueue("Item3", 5);  // Priority 5

        // Expected dequeue order: Item1, Item2, Item3 (FIFO)
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Exception is thrown with the correct error message.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception type caught: {e.GetType()} - {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Add items with mixed priorities, and ensure priority ordering is maintained when dequeueing.
    // Expected Result: Items with higher priorities are always dequeued first, followed by lower priorities.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();

        // Enqueue items with mixed priorities
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("MediumPriority", 2);
        priorityQueue.Enqueue("HighPriority", 10);
        priorityQueue.Enqueue("MediumPriorityAgain", 2);

        // Expected dequeue order: HighPriority (10), MediumPriority (2), MediumPriorityAgain (2), LowPriority (1)
        Assert.AreEqual("HighPriority", priorityQueue.Dequeue());
        Assert.AreEqual("MediumPriority", priorityQueue.Dequeue());
        Assert.AreEqual("MediumPriorityAgain", priorityQueue.Dequeue());
        Assert.AreEqual("LowPriority", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items, dequeue some, and add more to ensure new additions are handled correctly.
    // Expected Result: Queue should handle additions and deletions dynamically and maintain priority ordering.
    public void TestPriorityQueue_DynamicAdditions()
    {
        var priorityQueue = new PriorityQueue();

        // Initial enqueue
        priorityQueue.Enqueue("Item1", 3);
        priorityQueue.Enqueue("Item2", 1);

        // Dequeue one item
        Assert.AreEqual("Item1", priorityQueue.Dequeue());

        // Add new items
        priorityQueue.Enqueue("Item3", 5);
        priorityQueue.Enqueue("Item4", 2);

        // Expected dequeue order: Item3 (priority 5), Item4 (priority 2), Item2 (priority 1)
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item4", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
    }
}
