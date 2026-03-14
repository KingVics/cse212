using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue 3 items with different priorities and dequeue them all.
    // Expected Result: Items returned in priority order: "B"(3), "C"(2), "A"(1).
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same highest priority.
    // Expected Result: "A" is returned first (FIFO tie-breaking — first added, first removed).
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: The item with the highest priority is the last one added (back of queue).
    // Expected Result: "C"(10) is returned even though it was added last.
    // Defect(s) Found: Bug - loop used Count-1, so the last item was never checked and was never returned.
    public void TestPriorityQueue_LastItemHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 10);

        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException thrown with message "The queue is empty."
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_Empty()
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
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
        }
    }

    [TestMethod]
    // Scenario: Dequeue multiple times to verify items are actually removed after each call.
    // Expected Result: First dequeue returns "A"(3), second returns "B"(1), third throws exception (queue empty).
    // Defect(s) Found: Bug - Dequeue did not call RemoveAt, so the same highest-priority item was returned every time and the queue never shrank.
    public void TestPriorityQueue_ItemRemovedAfterDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
