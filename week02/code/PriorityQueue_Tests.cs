using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with priorities 1, 5, 3 (in that order) and dequeue once.
    // Expected Result: The item with priority 5 ("high") should be dequeued, since it has the highest priority.
    // Defect(s) Found: None. This test passed on the first run.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("medium", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("high", result);
    }

    [TestMethod]
    // Scenario: Enqueue four items where two share the highest priority: a(3), b(5), c(5), d(1).
    // Expected Result: Dequeuing twice should return "b" first (added before "c", same priority 5),
    // then "c" second proving ties are broken by FIFO order.
    // Defect(s) Found: The tie-breaking comparison used ">=" instead of ">", which let a later
    // item with an equal priority overwrite an earlier one, breaking the FIFO tie-break rule
    // (expected "b" first, got "c").
    public void TestPriorityQueue_2()

    {

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 3);
        priorityQueue.Enqueue("b", 5);
        priorityQueue.Enqueue("c", 5);
        priorityQueue.Enqueue("d", 1);

        var first = priorityQueue.Dequeue();
        Assert.AreEqual("b", first);

        var second = priorityQueue.Dequeue();
        Assert.AreEqual("c", second);
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Call Dequeue() on a PriorityQueue that has no items in it.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: None. This test passed on the first run. The empty queue exception handeling was already implemented correctly.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: Enqueue three items with priorities not in sorted order: x(9), y(1), z(5).
    // Expected Result: The queue's internal order should match insertion order (not priority order),
    // since Enqueue always adds to the back regardless of priority.
    // Defect(s) Found: None. This test passed on the first run. Enqueue already appends to the
    //  back of the list regardless of priority.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("x", 9);
        priorityQueue.Enqueue("y", 1);
        priorityQueue.Enqueue("z", 5);

        Assert.AreEqual("[x (Pri:9), y (Pri:1), z (Pri:5)]", priorityQueue.ToString());
    }
}