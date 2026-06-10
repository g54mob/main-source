using System;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class CombineTree : BinaryTree<CombineTreeNode, ICombineSource>
	{
		private ICombinedMeshFactory _factory;

		private float _leafSize;

		private int _vertexLimit;

		private int _bonesLimit;

		public float LeafSize => _leafSize;

		public int VertexLimit => _vertexLimit;

		public int BonesLimit => _bonesLimit;

		public ICombinedMeshFactory CombinedMeshFactory => _factory;

		public event Action<CombinedObject> onStaticCombinedObjectCreated;

		public event Action<DynamicCombinedObject> onDynamicCombinedObjectCreated;

		public event Action<CombinedLODGroup> onCombinedLODGroupCreated;

		public event Action<SkinnedCombinedObject> onSkinnedCombinedObjectCreated;

		public CombineTree(ICombinedMeshFactory factory, float leafSize, int vertexLimit, int bonesLimit)
		{
			_factory = factory;
			_leafSize = leafSize;
			_vertexLimit = vertexLimit;
			_bonesLimit = bonesLimit;
		}

		public void Combine()
		{
			TreeTraversal(delegate(CombineTreeNode node, int depth)
			{
				node.Combine();
				return true;
			});
		}

		protected override CombineTreeNode CreateRoot(ICombineSource source)
		{
			return CreateNode(source.Position, Vector3.one * _leafSize, isLeaf: true);
		}

		protected override CombineTreeNode CreateNode(Vector3 center, Vector3 size, bool isLeaf)
		{
			CombineTreeNode combineTreeNode = new CombineTreeNode(this, center, size, isLeaf);
			combineTreeNode.onStaticCombinedObjectCreated += this.onStaticCombinedObjectCreated;
			combineTreeNode.onDynamicCombinedObjectCreated += this.onDynamicCombinedObjectCreated;
			combineTreeNode.onCombinedLODGroupCreated += this.onCombinedLODGroupCreated;
			combineTreeNode.onSkinnedCombinedObjectCreated += this.onSkinnedCombinedObjectCreated;
			return combineTreeNode;
		}

		protected override CombineTreeNode ExpandRoot(CombineTreeNode root, ICombineSource target)
		{
			Bounds bounds = root.Bounds;
			Bounds bounds2 = target.Bounds;
			Vector3 center = Vector3.zero;
			Vector3 size = Vector3.zero;
			Vector3 center2 = Vector3.zero;
			bool flag = false;
			for (int i = 0; i < 3; i++)
			{
				if (bounds2.min[i] < bounds.min[i])
				{
					size = bounds.size;
					size[i] *= 2f;
					center = bounds.center;
					center[i] -= bounds.size[i] / 2f;
					center2 = bounds.center;
					center2[i] -= bounds.size[i];
					break;
				}
				if (bounds2.max[i] > bounds.max[i])
				{
					size = bounds.size;
					size[i] *= 2f;
					center = bounds.center;
					center[i] += bounds.size[i] / 2f;
					center2 = bounds.center;
					center2[i] += bounds.size[i];
					flag = true;
					break;
				}
			}
			CombineTreeNode combineTreeNode = CreateNode(center, size, isLeaf: false);
			CombineTreeNode combineTreeNode2 = CreateNode(center2, bounds.size, root.IsLeaf);
			if (flag)
			{
				combineTreeNode.SetChilds(base.RootInternal, combineTreeNode2);
			}
			else
			{
				combineTreeNode.SetChilds(combineTreeNode2, base.RootInternal);
			}
			return combineTreeNode;
		}

		protected override bool Includes(CombineTreeNode node, ICombineSource source)
		{
			Bounds bounds = node.Bounds;
			Bounds bounds2 = source.Bounds;
			return bounds.Contains(bounds2);
		}

		protected override bool Intersects(CombineTreeNode node, ICombineSource source)
		{
			return node.Bounds.Contains(source.Position);
		}
	}
}
