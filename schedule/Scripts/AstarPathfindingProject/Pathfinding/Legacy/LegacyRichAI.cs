using UnityEngine;

namespace Pathfinding.Legacy
{
	[RequireComponent(typeof(Seeker))]
	[AddComponentMenu("Pathfinding/Legacy/AI/Legacy RichAI (3D, for navmesh)")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_legacy_1_1_legacy_rich_a_i.php")]
	public class LegacyRichAI : RichAI
	{
		public bool preciseSlowdown;

		public bool raycastingForGroundPlacement;

		private new Vector3 velocity;

		private Vector3 lastTargetPoint;

		private Vector3 currentTargetDirection;

		private static float deltaTime;

		protected override void Awake()
		{
		}

		protected override void Update()
		{
		}

		private new Vector3 RaycastPosition(Vector3 position, float lasty)
		{
			return default(Vector3);
		}

		private bool RotateTowards(Vector3 trotdir)
		{
			return false;
		}
	}
}
