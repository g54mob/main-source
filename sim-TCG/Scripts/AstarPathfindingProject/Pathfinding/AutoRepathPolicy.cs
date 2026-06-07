using System;
using Pathfinding.Drawing;
using Pathfinding.Util;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[Serializable]
	public class AutoRepathPolicy
	{
		public enum Mode
		{
			Never = 0,
			EveryNSeconds = 1,
			Dynamic = 2
		}

		public Mode mode = Mode.Dynamic;

		[FormerlySerializedAs("interval")]
		public float period = 0.5f;

		public float sensitivity = 10f;

		[FormerlySerializedAs("maximumInterval")]
		public float maximumPeriod = 2f;

		public bool visualizeSensitivity;

		private Vector3 lastDestination = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

		private float lastRepathTime = float.NegativeInfinity;

		public virtual bool ShouldRecalculatePath(Vector3 position, float radius, Vector3 destination, float time)
		{
			if (mode == Mode.Never || float.IsPositiveInfinity(destination.x))
			{
				return false;
			}
			float num = time - lastRepathTime;
			if (mode == Mode.EveryNSeconds)
			{
				return num >= period;
			}
			float f = (destination - lastDestination).sqrMagnitude / Mathf.Max((position - lastDestination).sqrMagnitude, radius * radius) * (sensitivity * sensitivity);
			if (float.IsNaN(f))
			{
				f = 0f;
			}
			return num >= maximumPeriod * (1f - Mathf.Sqrt(f));
		}

		public virtual void Reset()
		{
			lastRepathTime = float.NegativeInfinity;
		}

		public virtual void DidRecalculatePath(Vector3 destination, float time)
		{
			lastRepathTime = time;
			lastDestination = destination;
			lastRepathTime -= (UnityEngine.Random.value - 0.5f) * 0.3f * ((mode == Mode.Dynamic) ? maximumPeriod : period);
		}

		public void DrawGizmos(CommandBuilder draw, Vector3 position, float radius, NativeMovementPlane movementPlane)
		{
			if (visualizeSensitivity && !float.IsPositiveInfinity(lastDestination.x))
			{
				float radius2 = Mathf.Sqrt(Mathf.Max((position - lastDestination).sqrMagnitude, radius * radius) / (sensitivity * sensitivity));
				draw.Circle(lastDestination, movementPlane.ToWorld(float2.zero, 1f), radius2, Color.magenta);
			}
		}

		public AutoRepathPolicy Clone()
		{
			return MemberwiseClone() as AutoRepathPolicy;
		}
	}
}
