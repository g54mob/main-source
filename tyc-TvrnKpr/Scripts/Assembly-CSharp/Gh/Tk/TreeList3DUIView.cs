using UnityEngine;

namespace Gh.Tk
{
	public class TreeList3DUIView : MonoBehaviour
	{
		[SerializeField]
		protected Transform _nodeContainer;

		[SerializeField]
		protected GameObject _nodePrefab;

		public PrefabObjectPool NodePool { get; set; }

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		public TreeNodeUIView CreateTreeNode(ITreeNode iTreeNode, TreeNodeUIView parentNodeView, TreeList3DUIView listParent)
		{
			return null;
		}
	}
}
