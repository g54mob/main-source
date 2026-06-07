using UnityEngine;

namespace NGS.MeshFusionPro
{
	public interface IBinaryTreeNode
	{
		Vector3 Center { get; }

		Vector3 Size { get; }

		Bounds Bounds { get; }

		bool HasChilds { get; }

		bool IsLeaf { get; }

		IBinaryTreeNode GetLeft();

		IBinaryTreeNode GetRight();
	}
}
