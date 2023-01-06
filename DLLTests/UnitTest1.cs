using CustomDoublyLinkedList;

namespace DLLTests;

public class DoublyLinkedListTests
{
	[Fact]
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
		Assert.Equal(2, list.Count);
		Assert.Equal(node1, list.Head);
		Assert.Equal(node2, list.Tail);
	}

	[Fact]
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
		Assert.Equal(1, list.Count);
		Assert.Equal(node2, list.Head);
		Assert.Equal(node2, list.Tail);
	}

	[Fact]
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
		Assert.Equal(3, list.Count);
		Assert.Equal(node1, list.Head);
		Assert.Equal(node2, list.Head.Next);
		Assert.Equal(node2, list.Tail.Previous);
		Assert.Equal(node3, list.Tail);
	}

	[Fact]
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
		Assert.Equal(3, list.Count);
		Assert.Equal(node1, list.Head);
		Assert.Equal(node2, list.Head.Next);
		Assert.Equal(node2, list.Tail.Previous);
		Assert.Equal(node3, list.Tail);
	}

	[Fact]
	public void TestFromList()
	{
		// Arrange
		var list = new DoublyLinkedList<int>();
		var sourceList = new List<int> { 1, 2, 3 };

		// Act
		list.FromList(sourceList);

		// Assert
		Assert.Equal(3, list.Count);
		Assert.Equal("1\r\n2\r\n3", list.ToString());
	}

	[Fact]
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
		Assert.Equal(3, result.Count);
		Assert.Equal(1, result[0]);
		Assert.Equal(2, result[1]);
		Assert.Equal(3, result[2]);
	}
}