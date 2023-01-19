namespace CustomDoublyLinkedList;

public class DoublyLinkedList<T>
{
	public DoublyLinkedList()
	{
	}

	public DoublyLinkedList(List<T> list)
	{
		FromList(list);
	}

	/// <summary>
	///  The first entry in the list
	/// </summary>
	public Node<T>? Head { get; set; }

	/// <summary>
	///  The last entry in the list
	/// </summary>
	public Node<T>? Tail { get; set; }

	/// <summary>
	///  The currently selected entry in the list
	/// </summary>
	public Node<T>? Selected { get; set; }

	/// <summary>
	///  The number of nodes in the list
	/// </summary>
	public int Count
	{
		get
		{
			var count = 0;
			var current = Head;
			while (current != null)
			{
				count++;
				current = current.Next;
			}

			return count;
		}
	}

	/// <summary>
	///  Converts the DoublyLinkedList into a List
	/// </summary>
	public List<T> ToList()
	{
		var list = new List<T>();

		Selected = Head;

		while (Selected is not null)
		{
			list.Add(Selected.Content);
			Selected = Selected.Next;
		}

		return list;
	}

	/// <summary>
	///  Populates the DoublyLinkedList with data from a normal List
	/// </summary>
	/// <param name="list"></param>
	public void FromList(List<T> list)
	{
		foreach (var content in list) Add(new Node<T>(content));
	}

	/// <summary>
	/// Adds a new node to the end of the list or makes it the first and last node if the list is empty
	/// </summary>
	/// <param name="node"></param>
	public void Add(Node<T> node)
	{
		if (Head is null || Tail is null)
		{
			Head ??= node;
			Tail ??= node;
		}
		else
		{
			Tail.Next = node;
			node.Previous = Tail;
			Tail = node;
		}
	}

	/// <summary>
	///  Removes a node from the linked list.
	/// </summary>
	/// <param name="node">The node to remove. If no node is provided, the currently selected node is removed.</param>
	public void Remove(Node<T>? node = null)
	{
		Selected = node ?? Selected;

		if (Selected.Previous is not null)
			Selected.Previous.Next = Selected.Next;
		else
			Head = Selected.Next;

		if (Selected.Next is not null)
			Selected.Next.Previous = Selected.Previous;
		else
			Tail = Selected.Previous;

		Selected = Head;
	}

	/// <summary>
	///  Adds a new node ahead of an existing node in the linked list.
	/// </summary>
	/// <param name="newNode">The new node to add.</param>
	/// <param name="node">
	///  The existing node ahead of which to add the new node. If no node is provided, the currently selected
	///  node is used.
	/// </param>
	public void InsertAhead(Node<T> newNode, Node<T>? node = null)
	{
		Selected = node ?? Selected;

		if (Selected == Tail)
		{
			newNode.Previous = Selected;
			Selected!.Next = newNode;
			Tail = newNode;
		}
		else
		{
			newNode.Previous = Selected;
			newNode.Next = Selected!.Next;
			Selected.Next!.Previous = newNode;
			Selected.Next = newNode;
		}

		Selected = newNode;
	}

	/// <summary>
	///  Adds a new node behind an existing node in the linked list.
	/// </summary>
	/// <param name="newNode">The new node to add.</param>
	/// <param name="node">
	///  The existing node behind which to add the new node. If no node is provided, the currently selected
	///  node is used.
	/// </param>
	public void InsertBehind(Node<T> newNode, Node<T>? node = null)
	{
		Selected = node ?? Selected;

		if (Selected == Head)
		{
			newNode.Next = Selected;
			Selected!.Previous = newNode;
			Head = newNode;
		}
		else
		{
			newNode.Next = Selected;
			newNode.Previous = Selected!.Previous;
			Selected.Previous!.Next = newNode;
			Selected.Previous = newNode;
		}

		Selected = newNode;
	}

	/// <summary>
	///  Clears the entire list
	/// </summary>
	public void Clear()
	{
		Head = null;
		Tail = null;
	}

	/// <summary>
	///  Finds a node in the list based on its Content value
	/// </summary>
	/// <param name="content">The Content value to search for</param>
	/// <returns>The node with the specified Content value, or null if not found</returns>
	public Node<T>? Find(T content)
	{
		Selected = Head;
		while (Selected != null)
		{
			if (Selected.Content.Equals(content)) return Selected;
			Selected = Selected.Next;
		}

		return null;
	}

	public override string ToString()
	{
		var output = "";

		var selected = Head;

		while (selected is not null)
		{
			output += selected + Environment.NewLine;
			selected = selected.Next;
		}

		return output.TrimEnd();
	}
}