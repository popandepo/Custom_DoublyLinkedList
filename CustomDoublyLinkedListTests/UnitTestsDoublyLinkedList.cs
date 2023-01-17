using CustomDoublyLinkedList;

namespace CustomDoublyLinkedListTests;

public class DoublyLinkedListTests
{
	[Test]
	public void Add()
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
		//Assert.AreEqual(true,false);
	}

	[Test]
	public void Remove()
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
	public void RemoveHead()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node1 = new Node<int>(1);
		var node2 = new Node<int>(2);
		list.Add(node1);
		list.Add(node2);

		// Act
		list.Selected = list.Head;
		list.Remove();

		// Assert
		Assert.AreEqual(1, list.Count);
		Assert.AreEqual(node2, list.Head);
		Assert.AreEqual(node2, list.Tail);
	}

	[Test]
	public void RemoveTail()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node1 = new Node<int>(1);
		var node2 = new Node<int>(2);
		list.Add(node1);
		list.Add(node2);

		// Act
		list.Selected = list.Tail;
		list.Remove();

		// Assert
		Assert.AreEqual(1, list.Count);
		Assert.AreEqual(node1, list.Head);
		Assert.AreEqual(node1, list.Tail);
	}

	[Test]
	public void InsertAheadSelected()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node1 = new Node<int>(1);
		var node2 = new Node<int>(2);
		list.Add(node1);
		list.Add(node2);

		// Act
		var node3 = new Node<int>(3);
		list.Selected = node2;
		list.InsertAhead(node3);

		// Assert
		Assert.AreEqual(3, list.Count);
		Assert.AreEqual(node1, list.Head);
		Assert.AreEqual(node2, list.Head.Next);
		Assert.AreEqual(node2, list.Tail.Previous);
		Assert.AreEqual(node3, list.Tail);
	}

	[Test]
	public void InsertAheadHead()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node1 = new Node<int>(1);
		var node2 = new Node<int>(2);
		list.Add(node1);
		list.Add(node2);

		// Act
		var node3 = new Node<int>(3);
		list.InsertAhead(node3, list.Head);

		// Assert
		Assert.AreEqual(3, list.Count);
		Assert.AreEqual(node1, list.Head);
		Assert.AreEqual(node3, list.Head.Next);
		Assert.AreEqual(node3, list.Tail.Previous);
		Assert.AreEqual(node2, list.Tail);
	}

	[Test]
	public void InsertAheadTail()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node1 = new Node<int>(1);
		var node2 = new Node<int>(2);
		list.Add(node1);
		list.Add(node2);

		// Act
		var node3 = new Node<int>(3);
		list.InsertAhead(node3, list.Tail);

		// Assert
		Assert.AreEqual(3, list.Count);
		Assert.AreEqual(node1, list.Head);
		Assert.AreEqual(node2, list.Head.Next);
		Assert.AreEqual(node2, list.Tail.Previous);
		Assert.AreEqual(node3, list.Tail);
	}

	[Test]
	public void InsertBehindSelected()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node2 = new Node<int>(2);
		var node3 = new Node<int>(3);
		list.Add(node2);
		list.Add(node3);

		// Act
		var node1 = new Node<int>(1);
		list.Selected = node2;
		list.InsertBehind(node1);

		// Assert
		Assert.AreEqual(3, list.Count);
		Assert.AreEqual(node1, list.Head);
		Assert.AreEqual(node2, list.Head.Next);
		Assert.AreEqual(node2, list.Tail.Previous);
		Assert.AreEqual(node3, list.Tail);
	}

	[Test]
	public void InsertBehindHead()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node2 = new Node<int>(2);
		var node3 = new Node<int>(3);
		list.Add(node2);
		list.Add(node3);

		// Act
		var node1 = new Node<int>(1);
		list.InsertBehind(node1, list.Head);

		// Assert
		Assert.AreEqual(3, list.Count);
		Assert.AreEqual(node1, list.Head);
		Assert.AreEqual(node2, list.Head.Next);
		Assert.AreEqual(node2, list.Tail.Previous);
		Assert.AreEqual(node3, list.Tail);
	}

	[Test]
	public void InsertBehindTail()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var node2 = new Node<int>(2);
		var node3 = new Node<int>(3);
		list.Add(node2);
		list.Add(node3);

		// Act
		var node1 = new Node<int>(1);
		list.InsertBehind(node1, list.Tail);

		// Assert
		Assert.AreEqual(3, list.Count);
		Assert.AreEqual(node2, list.Head);
		Assert.AreEqual(node1, list.Head.Next);
		Assert.AreEqual(node1, list.Tail.Previous);
		Assert.AreEqual(node3, list.Tail);
	}

	[Test]
	public void FromList()
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
	public void ToList()
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

	[Test]
	public void FromListConstructor()
	{
		// Arrange
		var sourceList = new List<int> { 1, 2, 3 };

		// Act
		var list = new DoublyLinkedList<int>(sourceList);

		// Assert
		Assert.AreEqual(3, list.Count);
		Assert.AreEqual("1\r\n2\r\n3", list.ToString());
	}

	[Test]
	public void Clear()
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
		list.Clear();

		// Assert
		Assert.AreEqual(0, list.Count);
		Assert.AreEqual(null, list.Head);
		Assert.AreEqual(null, list.Tail);
		Assert.AreEqual(null, list.Selected);
	}

	[Test]
	public void FindExistingNode()
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
		var result = list.Find(2);

		// Assert
		Assert.AreEqual(node2, result);
	}

	[Test]
	public void FindNonExistingNode()
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
		var result = list.Find(4);

		// Assert
		Assert.AreEqual(null, result);
	}
}