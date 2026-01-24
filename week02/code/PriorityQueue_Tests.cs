using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
     [TestMethod]
    // Scenario: Enqueue multiple items and ensure Dequeue returns the one with the highest priority.
    // Expected Result: Returns item with highest priority
    // Defect(s) Found: None after correction of for loop and missing RemoveAt.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue(); // B has highest priority

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority, ensure Dequeue returns the first with that priority
    // Expected Result: Oldest item with max priority is dequeued
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 2);
        pq.Enqueue("Y", 5);
        pq.Enqueue("Z", 5);

        var result = pq.Dequeue(); // Y has highest priority and was enqueued before Z

        Assert.AreEqual("Y", result);
    }


    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Enqueue a single item and immediately dequeue
    // Expected Result: Returns the only item in the queue
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("OnlyOne", 42);

        var result = pq.Dequeue();

        Assert.AreEqual("OnlyOne", result);
    }
    
    [TestMethod]
    // Scenario: Enqueue several items with different priorities and dequeue them all
    // Expected Result: Items should be returned from highest to lowest priority
    // Defect(s) Found: None
    public void TestPriorityQueue_4()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 3);
        pq.Enqueue("High", 5);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }
}