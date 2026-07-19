using System;
using System.Collections.Generic;
using System.Linq;

namespace UniJSON
{
	public static class ListTreeNodeJsonPointerExtensions
	{
		public static void SetValue<T>(this ListTreeNode<T> self, Utf8String jsonPointer, ArraySegment<byte> bytes) where T : IListTreeItem, IValue<T>
		{
			foreach (ListTreeNode<T> node in self.GetNodes(jsonPointer))
			{
				node.SetValue(default(T).New(bytes, ValueNodeType.Boolean, node.Value.ParentIndex));
			}
		}

		public static void RemoveValue<T>(this ListTreeNode<T> self, Utf8String jsonPointer) where T : IListTreeItem, IValue<T>
		{
			foreach (ListTreeNode<T> node in self.GetNodes(new JsonPointer(jsonPointer)))
			{
				if (node.Parent.IsMap())
				{
					node.Prev.SetValue(default(T));
				}
				node.SetValue(default(T));
			}
		}

		public static JsonPointer Pointer<T>(this ListTreeNode<T> self) where T : IListTreeItem, IValue<T>
		{
			return JsonPointer.Create(self);
		}

		public static IEnumerable<ListTreeNode<T>> Path<T>(this ListTreeNode<T> self) where T : IListTreeItem, IValue<T>
		{
			if (self.HasParent)
			{
				foreach (ListTreeNode<T> item in self.Parent.Path())
				{
					yield return item;
				}
			}
			yield return self;
		}

		public static IEnumerable<ListTreeNode<T>> GetNodes<T>(this ListTreeNode<T> self, JsonPointer jsonPointer) where T : IListTreeItem, IValue<T>
		{
			if (jsonPointer.Path.Count == 0)
			{
				yield return self;
				yield break;
			}
			if (self.IsArray())
			{
				if (jsonPointer[0][0] == 42)
				{
					foreach (ListTreeNode<T> item in self.ArrayItems())
					{
						foreach (ListTreeNode<T> node in item.GetNodes(jsonPointer.Unshift()))
						{
							yield return node;
						}
					}
					yield break;
				}
				int count = jsonPointer[0].ToInt32();
				ListTreeNode<T> self2 = self.ArrayItems().Skip(count).First();
				foreach (ListTreeNode<T> node2 in self2.GetNodes(jsonPointer.Unshift()))
				{
					yield return node2;
				}
				yield break;
			}
			if (self.IsMap())
			{
				if (jsonPointer[0][0] == 42)
				{
					foreach (KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> item2 in self.ObjectItems())
					{
						foreach (ListTreeNode<T> node3 in item2.Value.GetNodes(jsonPointer.Unshift()))
						{
							yield return node3;
						}
					}
					yield break;
				}
				ListTreeNode<T> value;
				try
				{
					value = self.ObjectItems().First((KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> x) => x.Key.GetUtf8String() == jsonPointer[0]).Value;
				}
				catch (Exception)
				{
					self.AddKey(jsonPointer[0]);
					self.AddValue(default(ArraySegment<byte>), ValueNodeType.Object);
					value = self.ObjectItems().First((KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> x) => x.Key.GetUtf8String() == jsonPointer[0]).Value;
				}
				foreach (ListTreeNode<T> node4 in value.GetNodes(jsonPointer.Unshift()))
				{
					yield return node4;
				}
				yield break;
			}
			throw new NotImplementedException();
		}

		public static IEnumerable<ListTreeNode<T>> GetNodes<T>(this ListTreeNode<T> self, Utf8String jsonPointer) where T : IListTreeItem, IValue<T>
		{
			return self.GetNodes(new JsonPointer(jsonPointer));
		}
	}
}
