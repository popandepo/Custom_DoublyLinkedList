using CustomDoublyLinkedList;

namespace DLLTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var dll = new DoublyLinkedList<string>();

			dll.Selected = dll.Head;
			for (int i = 1; i <= 10; i++)
			{
				dll.Add(new Node<string>($"Node {i}"));
			}

			Console.WriteLine(dll.ToString());
			
			var list = dll.ToList();
			var dllFromList = new DoublyLinkedList<string>(list);
			Console.WriteLine(dll);
			
		}
	}
}

namespace CustomDoublyLinkedList
{
	public class DoublyLinkedList<T>
	{
		/// <summary>
		/// The first entry in the list
		/// </summary>
		public Node<T>? Head { get; set; }

		/// <summary>
		/// The last entry in the list
		/// </summary>
		public Node<T>? Tail { get; set; }

		/// <summary>
		/// The currently selected entry in the list
		/// </summary>
		public Node<T>? Selected { get; set; }

		public DoublyLinkedList()
		{
		}

		public DoublyLinkedList(List<T> list)
		{
			FromList(list);
		}

		/// <summary>
		/// Converts the DoublyLinkedList into a List
		/// </summary>
		public List<T> ToList()
		{
			List<T> list = new List<T>();

			Selected = Head;

			while (Selected is not null)
			{
				list.Add(Selected.Content);
				Selected = Selected.Next;
			}

			return list;
		}

		/// <summary>
		/// Populates the DoublyLinkedList with data from a normal List
		/// </summary>
		/// <param name="list"></param>
		public void FromList(List<T> list)
		{
			foreach (var content in list)
			{
				Add(new Node<T>(content));
			}
		}

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

		public override string ToString()
		{
			string output = "";

			Selected = Head;

			while (Selected is not null)
			{
				output += Selected.ToString() + Environment.NewLine;
				Selected = Selected.Next;
			}

			return output.TrimEnd();
		}
	}

	public class Node<T>
	{
		public T? Content { get; set; }
		public Node<T>? Next { get; set; }
		public Node<T>? Previous { get; set; }

		public Node(T content)
		{
			Content = content;
		}

		public void Remove()
		{
			Previous.Next = Next;
			Next.Previous = Previous;
		}

		public void InsertAhead(Node<T> node)
		{
			node.Next = Next;
			Next.Previous = node;
			
			node.Previous = this;
			Next = node;
		}

		public void InsertBehind(Node<T> node)
		{
			node.Previous = Previous;
			Previous.Next = node;

			node.Next = this;
			Previous = node;
		}
		
		public override string ToString()
		{
			return Content.ToString();
		}
	}
}

