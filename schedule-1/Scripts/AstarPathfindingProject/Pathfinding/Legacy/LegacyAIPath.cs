using UnityEngine;

namespace Pathfinding.Legacy
{
	[RequireComponent(typeof(Seeker))]
	[AddComponentMenu("Pathfinding/Legacy/AI/Legacy AIPath (3D)")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_legacy_1_1_legacy_a_i_path.php")]
	public class LegacyAIPath : AIPath
	{
		public float forwardLook;

		public bool closestOnPathCheck;

		protected float minMoveScale;

		protected int currentWaypointIndex;

		protected Vector3 lastFoundWaypointPosition;

		protected float lastFoundWaypointTime;

		protected new Vector3 targetDirection;

		protected override void Awake()
		{
		}

		protected override void OnPathComplete(Path _p)
		{
		}

		protected override void Update()
		{
		}

		protected float XZSqrMagnitude(Vector3 a, Vector3 b)
		{
			return 0f;
		}

		protected new Vector3 CalculateVelocity(Vector3 currentPosition)
		{
			return default(Vector3);
		}

		protected void RotateTowards(Vector3 dir)
		{
		}

		protected Vector3 CalculateTargetPoint(Vector3 p, Vector3 a, Vector3 b)
		{
			return default(Vector3);
		}
	}
}
