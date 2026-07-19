using System;
using System.Collections.Generic;
using System.Linq;

namespace UniJSON
{
	public static class ListTreeNodeArrayExtensions
	{
		public static IEnumerable<ListTreeNode<T>> ArrayItems<T>(this ListTreeNode<T> self) where T : IListTreeItem, IValue<T>
		{
			if (!self.IsArray())
			{
				throw new DeserializationException("is not array");
			}
			return self.Children;
		}

		[Obsolete("Use GetArrayItem(index)")]
		public static ListTreeNode<T> GetArrrayItem<T>(this ListTreeNode<T> self, int index) where T : IListTreeItem, IValue<T>
		{
			return self.GetArrayItem(index);
		}

		public static ListTreeNode<T> GetArrayItem<T>(this ListTreeNode<T> self, int index) where T : IListTreeItem, IValue<T>
		{
			int num = 0;
			foreach (ListTreeNode<T> item in self.ArrayItems())
			{
				if (num++ == index)
				{
					return item;
				}
			}
			throw new KeyNotFoundException();
		}

		public static int GetArrayCount<T>(this ListTreeNode<T> self) where T : IListTreeItem, IValue<T>
		{
			if (!self.IsArray())
			{
				throw new DeserializationException("is not array");
			}
			return self.Children.Count();
		}

		public static int IndexOf<T>(this ListTreeNode<T> self, ListTreeNode<T> child) where T : IListTreeItem, IValue<T>
		{
			int num = 0;
			foreach (ListTreeNode<T> item in self.ArrayItems())
			{
				if (item.ValueIndex == child.ValueIndex)
				{
					return num;
				}
				num++;
			}
			throw new KeyNotFoundException();
		}
	}
}
