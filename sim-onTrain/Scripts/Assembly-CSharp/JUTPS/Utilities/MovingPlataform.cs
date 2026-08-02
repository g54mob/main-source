using JUTPS.AI;
using UnityEngine;

namespace JUTPS.Utilities
{
	public class MovingPlataform : MonoBehaviour
	{
		public WaypointPath WaypointPath;

		public WaypointPath.OnEndPathAction OnEndPath;

		public float Speed;

		public bool ParentCollidedObjects = true;

		private int waypointId;

		private void FixedUpdate()
		{
			if (!(WaypointPath == null))
			{
				WaypointPath.FollowPathTowards(base.gameObject, ref WaypointPath.WaypointPathPositions, ref waypointId, Speed, OnEndPath);
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (ParentCollidedObjects)
			{
				collision.transform.parent = base.transform;
			}
		}

		private void OnCollisionExit(Collision collision)
		{
			if (ParentCollidedObjects)
			{
				collision.transform.parent = null;
			}
		}
	}
}
