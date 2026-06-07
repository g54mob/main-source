using System;

namespace NGenerics.DataStructures.Trees
{
	[Serializable]
	internal class RedBlackTreeNode<T> : BinaryTree<T>
	{
		internal NodeColor Color { get; set; }

		internal RedBlackTreeNode<T> this[bool direction]
		{
			get
			{
				if (!direction)
				{
					return Left;
				}
				return Right;
			}
			set
			{
				if (direction)
				{
					Right = value;
				}
				else
				{
					Left = value;
				}
			}
		}

		internal new RedBlackTreeNode<T> Left
		{
			get
			{
				return (RedBlackTreeNode<T>)base.Left;
			}
			set
			{
				base.Left = value;
			}
		}

		internal new RedBlackTreeNode<T> Right
		{
			get
			{
				return (RedBlackTreeNode<T>)base.Right;
			}
			set
			{
				base.Right = value;
			}
		}

		internal RedBlackTreeNode(T data)
			: base(data)
		{
			Color = NodeColor.Red;
		}
	}
}
