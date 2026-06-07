using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.MechInvasion
{
	[ExecuteAlways]
	public class MechPathWaypointScript : MonoBehaviour
	{
		[SerializeField]
		private bool _snapToGround = true;

		public MechPathScript Path { get; private set; }

		public Vector3 Position => base.transform.position;

		public Quaternion Rotation { get; private set; }

		public void Initialize(MechPathScript path)
		{
			Path = path;
			int num = path.Waypoints.IndexOf(this);
			if (num < 0)
			{
				Debug.LogError("The waypoint is not part of the specified path.");
			}
			Transform transform = path.Objective;
			if (num + 1 < path.Waypoints.Count)
			{
				transform = path.Waypoints[num + 1]?.transform;
			}
			if (transform != null)
			{
				Vector3 v = transform.position - base.transform.position;
				float? y = 0f;
				Vector3 normalized = v.Copy(null, y).normalized;
				Rotation = Quaternion.LookRotation(normalized, Vector3.up);
				base.transform.rotation = base.transform.rotation;
			}
		}
	}
}
