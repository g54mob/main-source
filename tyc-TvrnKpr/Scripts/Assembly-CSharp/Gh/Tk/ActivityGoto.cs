using UnityEngine;

namespace Gh.Tk
{
	public class ActivityGoto : Activity
	{
		public Vector3 Target;

		public float TargetRotation;

		public bool TeleportAtEnd;

		public float StoppingDistance;

		public bool SlowDownAtTheEnd;

		public static float IGNORE_ROTATION;

		public bool IsRotationValid => false;

		public Vector3 FacingDirection => default(Vector3);

		public void OnReachedTarget()
		{
		}

		public override string GetLogInfo()
		{
			return null;
		}
	}
}
