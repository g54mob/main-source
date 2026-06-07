using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/localspacegraph.html")]
	public class LocalSpaceGraph : VersionedMonoBehaviour
	{
		private Matrix4x4 originalMatrix;

		private MutableGraphTransform graphTransform = new MutableGraphTransform(Matrix4x4.identity);

		public GraphTransform transformation => graphTransform;

		private void Start()
		{
			originalMatrix = base.transform.worldToLocalMatrix;
			base.transform.hasChanged = true;
			Refresh();
		}

		public void Refresh()
		{
			if (base.transform.hasChanged)
			{
				graphTransform.SetMatrix(base.transform.localToWorldMatrix * originalMatrix);
				base.transform.hasChanged = false;
			}
		}
	}
}
