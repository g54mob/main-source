using System;
using Pathfinding.Drawing;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[Serializable]
	public class AutoRepathPolicy
	{
		public enum Mode : byte
		{
			Never = 0,
			EveryNSeconds = 1,
			Dynamic = 2
		}

		public Mode mode;

		[FormerlySerializedAs("interval")]
		public float period;

		public float sensitivity;

		[FormerlySerializedAs("maximumInterval")]
		public float maximumPeriod;

		public bool visualizeSensitivity;

		private Vector3 lastDestination;

		private float lastRepathTime;

		public virtual bool ShouldRecalculatePath(Vector3 position, float radius, Vector3 destination, float time)
		{
			return false;
		}

		public virtual void Reset()
		{
		}

		public virtual void DidRecalculatePath(Vector3 destination, float time)
		{
		}

		public void DrawGizmos(CommandBuilder draw, Vector3 position, float radius, NativeMovementPlane movementPlane)
		{
		}

		public AutoRepathPolicy Clone()
		{
			return null;
		}
	}
}
