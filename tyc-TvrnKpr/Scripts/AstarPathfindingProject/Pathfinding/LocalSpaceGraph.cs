using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/localspacegraph.html")]
	public class LocalSpaceGraph : VersionedMonoBehaviour
	{
		private Matrix4x4 originalMatrix;

		private MutableGraphTransform graphTransform;

		public GraphTransform transformation => null;

		private void Start()
		{
		}

		public void Refresh()
		{
		}
	}
}
