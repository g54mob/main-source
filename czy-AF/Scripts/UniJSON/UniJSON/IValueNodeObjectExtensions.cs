using System.Collections.Generic;
using System.Linq;

namespace UniJSON
{
	public static class IValueNodeObjectExtensions
	{
		public static IEnumerable<KeyValuePair<ListTreeNode<T>, ListTreeNode<T>>> ObjectItems<T>(this ListTreeNode<T> self) where T : IListTreeItem, IValue<T>
		{
			if (!self.IsMap())
			{
				throw new DeserializationException("is not object");
			}
			IEnumerator<ListTreeNode<T>> it = self.Children.GetEnumerator();
			while (it.MoveNext())
			{
				ListTreeNode<T> current = it.Current;
				it.MoveNext();
				yield return new KeyValuePair<ListTreeNode<T>, ListTreeNode<T>>(current, it.Current);
			}
		}

		public static int GetObjectCount<T>(this ListTreeNode<T> self) where T : IListTreeItem, IValue<T>
		{
			if (!self.IsMap())
			{
				throw new DeserializationException("is not object");
			}
			return self.Children.Count() / 2;
		}

		public static ListTreeNode<T> GetObjectItem<T>(this ListTreeNode<T> self, string key) where T : IListTreeItem, IValue<T>
		{
			return self.GetObjectItem(Utf8String.From(key));
		}

		public static ListTreeNode<T> GetObjectItem<T>(this ListTreeNode<T> self, Utf8String key) where T : IListTreeItem, IValue<T>
		{
			foreach (KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> item in self.ObjectItems())
			{
				if (item.Key.GetUtf8String() == key)
				{
					return item.Value;
				}
			}
			throw new KeyNotFoundException();
		}

		public static bool ContainsKey<T>(this ListTreeNode<T> self, Utf8String key) where T : IListTreeItem, IValue<T>
		{
			return self.ObjectItems().Any((KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> x) => x.Key.GetUtf8String() == key);
		}

		public static bool ContainsKey<T>(this ListTreeNode<T> self, string key) where T : IListTreeItem, IValue<T>
		{
			Utf8String key2 = Utf8String.From(key);
			return self.ContainsKey(key2);
		}

		public static Utf8String KeyOf<T>(this ListTreeNode<T> self, ListTreeNode<T> node) where T : IListTreeItem, IValue<T>
		{
			foreach (KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> item in self.ObjectItems())
			{
				if (node.ValueIndex == item.Value.ValueIndex)
				{
					return item.Key.GetUtf8String();
				}
			}
			throw new KeyNotFoundException();
		}
	}
}
