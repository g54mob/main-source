using System;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class CombineTreeNode : BinaryTreeNode<ICombineSource>
	{
		private CombineTree _tree;

		private UniversalObjectsCombiner _combiner;

		public event Action<CombinedObject> onStaticCombinedObjectCreated;

		public event Action<DynamicCombinedObject> onDynamicCombinedObjectCreated;

		public event Action<CombinedLODGroup> onCombinedLODGroupCreated;

		public CombineTreeNode(CombineTree tree, Vector3 center, Vector3 size, bool isLeaf)
			: base(center, size, isLeaf)
		{
			_tree = tree;
		}

		public override void Add(ICombineSource source)
		{
			if (_combiner == null)
			{
				_combiner = new UniversalObjectsCombiner(_tree.CombinedMeshFactory, _tree.VertexLimit);
				_combiner.onStaticCombinedObjectCreated += this.onStaticCombinedObjectCreated;
				_combiner.onDynamicCombinedObjectCreated += this.onDynamicCombinedObjectCreated;
				_combiner.onCombinedLODGroupCreated += this.onCombinedLODGroupCreated;
			}
			_combiner.AddSource(source);
		}

		public override void Remove(ICombineSource source)
		{
			_combiner.RemoveSource(source);
		}

		public void Combine()
		{
			_combiner?.Combine();
		}
	}
}
