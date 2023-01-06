using CustomDoublyLinkedList;

namespace CustomDoublyLinkedListTests;

public class DoublyLinkedListTests
{
	[Test]
	public void TestAdd()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node1 = new Node<int>(1);
		var node2 = new Node<int>(2);

		// Act
		list.Add(node1);
		list.Add(node2);

		// Assert
		Assert.AreEqual(2, list.Count);
		Assert.AreEqual(node1, list.Head);
		Assert.AreEqual(node2, list.Tail);
	}

	[Test]
	public void TestRemove()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node1 = new Node<int>(1);
		var node2 = new Node<int>(2);
		list.Add(node1);
		list.Add(node2);

		// Act
		list.Remove(node1);

		// Assert
		Assert.AreEqual(1, list.Count);
		Assert.AreEqual(node2, list.Head);
		Assert.AreEqual(node2, list.Tail);
	}

	[Test]
	public void TestInsertAhead()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node1 = new Node<int>(1);
		var node2 = new Node<int>(2);
		list.Add(node1);
		list.Add(node2);

		// Act
		var node3 = new Node<int>(3);
		list.InsertAhead(node3);

		// Assert
		Assert.AreEqual(3, list.Count);
		Assert.AreEqual(node1, list.Head);
		Assert.AreEqual(node2, list.Head.Next);
		Assert.AreEqual(node2, list.Tail.Previous);
		Assert.AreEqual(node3, list.Tail);
	}

	[Test]
	public void TestInsertBehind()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node2 = new Node<int>(2);
		var node3 = new Node<int>(3);
		list.Add(node2);
		list.Add(node3);

		// Act
		var node1 = new Node<int>(1);
		list.InsertBehind(node1);

		// Assert
		Assert.AreEqual(3, list.Count);
		Assert.AreEqual(node1, list.Head);
		Assert.AreEqual(node2, list.Head.Next);
		Assert.AreEqual(node2, list.Tail.Previous);
		Assert.AreEqual(node3, list.Tail);
	}

	[Test]
	public void TestFromList()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var sourceList = new List<int> { 1, 2, 3 };

		// Act
		list.FromList(sourceList);

		// Assert
		Assert.AreEqual(3, list.Count);
		Assert.AreEqual("1\r\n2\r\n3", list.ToString());
	}

	[Test]
	public void TestToList()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node1 = new Node<int>(1);
		var node2 = new Node<int>(2);
		var node3 = new Node<int>(3);
		list.Add(node1);
		list.Add(node2);
		list.Add(node3);

		// Act
		var result = list.ToList();

		// Assert
		Assert.AreEqual(3, result.Count);
		Assert.AreEqual(1, result[0]);
		Assert.AreEqual(2, result[1]);
		Assert.AreEqual(3, result[2]);
	}
}