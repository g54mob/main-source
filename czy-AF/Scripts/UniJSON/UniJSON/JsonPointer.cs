using System;
using System.Linq;
using System.Text;

namespace UniJSON
{
	public struct JsonPointer
	{
		public ArraySegment<Utf8String> Path { get; private set; }

		public int Count => Path.Count;

		public Utf8String this[int index] => Path.Array[Path.Offset + index];

		public JsonPointer Unshift()
		{
			return new JsonPointer
			{
				Path = new ArraySegment<Utf8String>(Path.Array, Path.Offset + 1, Path.Count - 1)
			};
		}

		public static JsonPointer Create<T>(ListTreeNode<T> node) where T : IListTreeItem, IValue<T>
		{
			return new JsonPointer
			{
				Path = new ArraySegment<Utf8String>((from x in node.Path().Skip(1)
					select GetKeyFromParent(x)).ToArray())
			};
		}

		public JsonPointer(Utf8String pointer)
		{
			this = default(JsonPointer);
			if (!pointer.TrySearchAscii(47, 0, out var pos))
			{
				throw new ArgumentException();
			}
			if (pos != 0)
			{
				throw new ArgumentException();
			}
			Utf8String[] array = pointer.Split(47).ToArray();
			Path = new ArraySegment<Utf8String>(array, 1, array.Length - 1);
		}

		public override string ToString()
		{
			if (Path.Count == 0)
			{
				return "/";
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = Path.Offset + Path.Count;
			for (int i = Path.Offset; i < num; i++)
			{
				stringBuilder.Append('/');
				stringBuilder.Append(Path.Array[i]);
			}
			return stringBuilder.ToString();
		}

		private static Utf8String GetKeyFromParent<T>(ListTreeNode<T> json) where T : IListTreeItem, IValue<T>
		{
			ListTreeNode<T> parent = json.Parent;
			if (parent.IsArray())
			{
				return Utf8String.From(parent.IndexOf(json));
			}
			if (parent.IsMap())
			{
				return parent.KeyOf(json);
			}
			throw new NotImplementedException();
		}
	}
}
