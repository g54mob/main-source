using System;
using System.Collections.Generic;

namespace NGenerics.DataStructures.Trees
{
	[Serializable]
	internal class RedBlackTreeList<TKey, TValue> : RedBlackTree<TKey, LinkedList<TValue>>
	{
		private delegate bool NodeAction(TKey key, LinkedList<TValue> values);

		public RedBlackTreeList()
		{
		}

		public RedBlackTreeList(IComparer<TKey> comparer)
			: base(comparer)
		{
		}

		public RedBlackTreeList(Comparison<TKey> comparison)
			: base(comparison)
		{
		}

		public bool ContainsValue(TValue value)
		{
			return TraverseItems((TKey key, LinkedList<TValue> list) => list.Contains(value));
		}

		public IEnumerator<TValue> GetValueEnumerator()
		{
			Stack<BinaryTree<KeyValuePair<TKey, LinkedList<TValue>>>> stack = new Stack<BinaryTree<KeyValuePair<TKey, LinkedList<TValue>>>>();
			if (base.Tree != null)
			{
				stack.Push(base.Tree);
			}
			while (stack.Count > 0)
			{
				BinaryTree<KeyValuePair<TKey, LinkedList<TValue>>> currentNode = stack.Pop();
				LinkedList<TValue> value = currentNode.Data.Value;
				foreach (TValue item in value)
				{
					yield return item;
				}
				if (currentNode.Left != null)
				{
					stack.Push(currentNode.Left);
				}
				if (currentNode.Right != null)
				{
					stack.Push(currentNode.Right);
				}
			}
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetKeyEnumerator()
		{
			Stack<BinaryTree<KeyValuePair<TKey, LinkedList<TValue>>>> stack = new Stack<BinaryTree<KeyValuePair<TKey, LinkedList<TValue>>>>();
			if (base.Tree != null)
			{
				stack.Push(base.Tree);
			}
			while (stack.Count > 0)
			{
				BinaryTree<KeyValuePair<TKey, LinkedList<TValue>>> currentNode = stack.Pop();
				LinkedList<TValue> value = currentNode.Data.Value;
				foreach (TValue item in value)
				{
					yield return new KeyValuePair<TKey, TValue>(currentNode.Data.Key, item);
				}
				if (currentNode.Left != null)
				{
					stack.Push(currentNode.Left);
				}
				if (currentNode.Right != null)
				{
					stack.Push(currentNode.Right);
				}
			}
		}

		public bool Remove(TValue value, out TKey key)
		{
			TKey foundKey = default(TKey);
			bool result = TraverseItems(delegate(TKey itemKey, LinkedList<TValue> list)
			{
				if (list.Remove(value))
				{
					if (list.Count == 0)
					{
						Remove(itemKey);
					}
					foundKey = itemKey;
					return true;
				}
				return false;
			});
			key = foundKey;
			return result;
		}

		private bool TraverseItems(NodeAction shouldStop)
		{
			Stack<BinaryTree<KeyValuePair<TKey, LinkedList<TValue>>>> stack = new Stack<BinaryTree<KeyValuePair<TKey, LinkedList<TValue>>>>();
			if (base.Tree != null)
			{
				stack.Push(base.Tree);
			}
			while (stack.Count > 0)
			{
				BinaryTree<KeyValuePair<TKey, LinkedList<TValue>>> binaryTree = stack.Pop();
				if (shouldStop(binaryTree.Data.Key, binaryTree.Data.Value))
				{
					return true;
				}
				if (binaryTree.Left != null)
				{
					stack.Push(binaryTree.Left);
				}
				if (binaryTree.Right != null)
				{
					stack.Push(binaryTree.Right);
				}
			}
			return false;
		}
	}
}
