using CustomDoublyLinkedList;
namespace CustomDoublyLinkedListTests;

public class NodeTests
{
	[Test]
	public void TestNodeContent()
	{
		// Arrange
		var node = new Node<int>(5);

		// Act
		var content = node.Content;

		// Assert
		Assert.AreEqual(5, content);
	}

	[Test]
	public void TestNodeNext()
	{
		// Arrange
		var node1 = new Node<int>(5);
		var node2 = new Node<int>(10);
		node1.Next = node2;

		// Act
		var nextNode = node1.Next;

		// Assert
		Assert.AreEqual(node2, nextNode);
	}

	[Test]
	public void TestNodePrevious()
	{
		// Arrange
		var node1 = new Node<int>(5);
		var node2 = new Node<int>(10);
		node1.Previous = node2;

		// Act
		var previousNode = node1.Previous;

		// Assert
		Assert.AreEqual(node2, previousNode);
	}

	[Test]
	public void TestNodeToString()
	{
		// Arrange
		var node = new Node<int>(5);

		// Act
		var str = node.ToString();

		// Assert
		Assert.AreEqual("5", str);
	}
}