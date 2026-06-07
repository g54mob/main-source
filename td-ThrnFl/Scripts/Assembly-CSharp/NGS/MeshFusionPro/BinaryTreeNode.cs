using UnityEngine;

namespace NGS.MeshFusionPro
{
	public abstract class BinaryTreeNode<TData> : IBinaryTreeNode
	{
		public BinaryTreeNode<TData> Left { get; private set; }

		public BinaryTreeNode<TData> Right { get; private set; }

		public bool IsLeaf { get; private set; }

		public bool HasChilds => Left != null;

		public Vector3 Center { get; private set; }

		public Vector3 Size { get; private set; }

		public Bounds Bounds { get; private set; }

		public BinaryTreeNode(Vector3 center, Vector3 size, bool isLeaf)
		{
			Center = center;
			Size = size;
			Bounds = new Bounds(center, size);
			IsLeaf = isLeaf;
		}

		public IBinaryTreeNode GetLeft()
		{
			return Left;
		}

		public IBinaryTreeNode GetRight()
		{
			return Right;
		}

		public void SetChilds(BinaryTreeNode<TData> left, BinaryTreeNode<TData> right)
		{
			Left = left;
			Right = right;
		}

		public abstract void Add(TData data);

		public abstract void Remove(TData data);
	}
}
