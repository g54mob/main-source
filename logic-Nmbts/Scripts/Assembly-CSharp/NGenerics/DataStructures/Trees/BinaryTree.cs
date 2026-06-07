using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NGenerics.Util;

namespace NGenerics.DataStructures.Trees
{
	[Serializable]
	public class BinaryTree<T> : ICollection<T>, IEnumerable<T>, IEnumerable, ITree<T>
	{
		private BinaryTree<T> leftSubtree;

		private BinaryTree<T> rightSubtree;

		private T data;

		public bool IsEmpty
		{
			get
			{
				return Count == 0;
			}
		}

		public bool IsFull
		{
			get
			{
				if (leftSubtree != null)
				{
					return rightSubtree != null;
				}
				return false;
			}
		}

		public int Count
		{
			get
			{
				int num = 0;
				if (leftSubtree != null)
				{
					num++;
				}
				if (rightSubtree != null)
				{
					num++;
				}
				return num;
			}
		}

		ITree<T> ITree<T>.Parent
		{
			get
			{
				return Parent;
			}
		}

		public BinaryTree<T> Parent { get; private set; }

		public virtual BinaryTree<T> Left
		{
			get
			{
				return leftSubtree;
			}
			set
			{
				if (leftSubtree != null)
				{
					RemoveLeft();
				}
				if (value != null)
				{
					if (value.Parent != null)
					{
						value.Parent.Remove(value);
					}
					value.Parent = this;
				}
				leftSubtree = value;
			}
		}

		public virtual BinaryTree<T> Right
		{
			get
			{
				return rightSubtree;
			}
			set
			{
				if (rightSubtree != null)
				{
					RemoveRight();
				}
				if (value != null)
				{
					if (value.Parent != null)
					{
						value.Parent.Remove(value);
					}
					value.Parent = this;
				}
				rightSubtree = value;
			}
		}

		public virtual T Data
		{
			get
			{
				return data;
			}
			set
			{
				Guard.ArgumentNotNull(value, "data");
				data = value;
			}
		}

		public int Degree
		{
			get
			{
				return Count;
			}
		}

		public virtual int Height
		{
			get
			{
				if (Degree == 0)
				{
					return 0;
				}
				return 1 + FindMaximumChildHeight();
			}
		}

		public virtual bool IsLeafNode
		{
			get
			{
				return Degree == 0;
			}
		}

		public BinaryTree<T> this[int index]
		{
			get
			{
				return GetChild(index);
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public BinaryTree(T data)
			: this(data, (BinaryTree<T>)null, (BinaryTree<T>)null)
		{
		}

		public BinaryTree(T data, T left, T right)
			: this(data, new BinaryTree<T>(left), new BinaryTree<T>(right))
		{
		}

		public BinaryTree(T data, BinaryTree<T> left, BinaryTree<T> right)
			: this(data, left, right, true)
		{
		}

		internal BinaryTree(T data, BinaryTree<T> left, BinaryTree<T> right, bool validateData)
		{
			if (validateData)
			{
				Guard.ArgumentNotNull(data, "data");
			}
			leftSubtree = left;
			if (left != null)
			{
				left.Parent = this;
			}
			rightSubtree = right;
			if (right != null)
			{
				right.Parent = this;
			}
			this.data = data;
		}

		public bool Contains(T item)
		{
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					if (item.Equals(current))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					if (arrayIndex >= array.Length)
					{
						throw new ArgumentException("Not enough space in the target array.", "array");
					}
					array[arrayIndex++] = current;
				}
			}
		}

		public void Add(T item)
		{
			AddItem(new BinaryTree<T>(item));
		}

		public bool Remove(T item)
		{
			if (leftSubtree != null && leftSubtree.data.Equals(item))
			{
				RemoveLeft();
				return true;
			}
			if (rightSubtree != null && rightSubtree.data.Equals(item))
			{
				RemoveRight();
				return true;
			}
			return false;
		}

		public bool Remove(BinaryTree<T> child)
		{
			if (leftSubtree != null && leftSubtree == child)
			{
				RemoveLeft();
				return true;
			}
			if (rightSubtree != null && rightSubtree == child)
			{
				RemoveRight();
				return true;
			}
			return false;
		}

		public IEnumerator<T> GetEnumerator()
		{
			Stack<BinaryTree<T>> stack = new Stack<BinaryTree<T>>();
			stack.Push(this);
			while (stack.Count > 0)
			{
				BinaryTree<T> tree = stack.Pop();
				yield return tree.Data;
				if (tree.leftSubtree != null)
				{
					stack.Push(tree.leftSubtree);
				}
				if (tree.rightSubtree != null)
				{
					stack.Push(tree.rightSubtree);
				}
			}
		}

		public virtual void Clear()
		{
			if (leftSubtree != null)
			{
				leftSubtree.Parent = null;
				leftSubtree = null;
			}
			if (rightSubtree != null)
			{
				rightSubtree.Parent = null;
				rightSubtree = null;
			}
		}

		void ITree<T>.Add(ITree<T> child)
		{
			AddItem((BinaryTree<T>)child);
		}

		ITree<T> ITree<T>.GetChild(int index)
		{
			return GetChild(index);
		}

		bool ITree<T>.Remove(ITree<T> child)
		{
			return Remove((BinaryTree<T>)child);
		}

		ITree<T> ITree<T>.FindNode(Predicate<T> condition)
		{
			return FindNode(condition);
		}

		public BinaryTree<T> FindNode(Predicate<T> condition)
		{
			Guard.ArgumentNotNull(condition, "condition");
			if (condition(Data))
			{
				return this;
			}
			if (leftSubtree != null)
			{
				BinaryTree<T> binaryTree = leftSubtree.FindNode(condition);
				if (binaryTree != null)
				{
					return binaryTree;
				}
			}
			if (rightSubtree != null)
			{
				BinaryTree<T> binaryTree2 = rightSubtree.FindNode(condition);
				if (binaryTree2 != null)
				{
					return binaryTree2;
				}
			}
			return null;
		}

		public BinaryTree<T> GetChild(int index)
		{
			switch (index)
			{
			case 0:
				return leftSubtree;
			case 1:
				return rightSubtree;
			default:
				throw new ArgumentOutOfRangeException("index");
			}
		}

		public virtual void DepthFirstTraversal(OrderedVisitor<T> orderedVisitor)
		{
			Guard.ArgumentNotNull(orderedVisitor, "orderedVisitor");
			if (!orderedVisitor.HasCompleted)
			{
				orderedVisitor.VisitPreOrder(Data);
				if (leftSubtree != null)
				{
					leftSubtree.DepthFirstTraversal(orderedVisitor);
				}
				orderedVisitor.VisitInOrder(data);
				if (rightSubtree != null)
				{
					rightSubtree.DepthFirstTraversal(orderedVisitor);
				}
				orderedVisitor.VisitPostOrder(Data);
			}
		}

		public virtual void BreadthFirstTraversal(IVisitor<T> visitor)
		{
			Guard.ArgumentNotNull(visitor, "visitor");
			Queue<BinaryTree<T>> queue = new Queue<BinaryTree<T>>();
			queue.Enqueue(this);
			while (queue.Count > 0 && !visitor.HasCompleted)
			{
				BinaryTree<T> binaryTree = queue.Dequeue();
				visitor.Visit(binaryTree.Data);
				for (int i = 0; i < binaryTree.Degree; i++)
				{
					BinaryTree<T> child = binaryTree.GetChild(i);
					if (child != null)
					{
						queue.Enqueue(child);
					}
				}
			}
		}

		public virtual void RemoveLeft()
		{
			if (leftSubtree != null)
			{
				leftSubtree.Parent = null;
				leftSubtree = null;
			}
		}

		public virtual void RemoveRight()
		{
			if (rightSubtree != null)
			{
				rightSubtree.Parent = null;
				rightSubtree = null;
			}
		}

		public void Add(BinaryTree<T> subtree)
		{
			Guard.ArgumentNotNull(subtree, "subtree");
			AddItem(subtree);
		}

		protected virtual void AddItem(BinaryTree<T> subtree)
		{
			if (leftSubtree == null)
			{
				if (subtree.Parent != null)
				{
					subtree.Parent.Remove(subtree);
				}
				leftSubtree = subtree;
				subtree.Parent = this;
				return;
			}
			if (rightSubtree == null)
			{
				if (subtree.Parent != null)
				{
					subtree.Parent.Remove(subtree);
				}
				rightSubtree = subtree;
				subtree.Parent = this;
				return;
			}
			throw new InvalidOperationException("This binary tree is full.");
		}

		protected virtual int FindMaximumChildHeight()
		{
			int num = 0;
			int num2 = 0;
			if (leftSubtree != null)
			{
				num = leftSubtree.Height;
			}
			if (rightSubtree != null)
			{
				num2 = rightSubtree.Height;
			}
			if (num <= num2)
			{
				return num2;
			}
			return num;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override string ToString()
		{
			return data.ToString();
		}
	}
}
