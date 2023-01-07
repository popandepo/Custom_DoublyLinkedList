namespace CustomDoublyLinkedList;

public class Node<T>
{
	public Node(T content)
	{
		Content = content;
	}

	public T? Content { get; set; }
	public Node<T>? Next { get; set; }
	public Node<T>? Previous { get; set; }

	public override string ToString()
	{
		return Content.ToString();
	}
}