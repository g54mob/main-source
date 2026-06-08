using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct SPerformTableUpdate : IComponentData
	{
		public static Vector3 DefaultPathingSource = new Vector3(-15f, 0f, 0f);

		public Vector3 PathingSource;

		public bool EnforcePaths;

		public bool ReplaceWithDisabledGhosts;
	}
}
