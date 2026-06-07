using System;
using Pathfinding.Util;
using UnityEngine;

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

		public float interval = 0.5f;

		public float sensitivity = 10f;

		public float maximumInterval = 2f;

		public bool visualizeSensitivity;

		private Vector3 lastDestination = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

		private float lastRepathTime = float.NegativeInfinity;

		public virtual bool ShouldRecalculatePath(IAstarAI ai)
		{
			if (mode == Mode.Never || float.IsPositiveInfinity(ai.destination.x))
			{
				return false;
			}
			float num = Time.time - lastRepathTime;
			if (mode == Mode.EveryNSeconds)
			{
				return num >= interval;
			}
			float num2 = (ai.destination - lastDestination).sqrMagnitude / Mathf.Max((ai.position - lastDestination).sqrMagnitude, ai.radius * ai.radius) * (sensitivity * sensitivity);
			if (num2 > 1f || float.IsNaN(num2))
			{
				return true;
			}
			if (num >= maximumInterval * (1f - Mathf.Sqrt(num2)))
			{
				return true;
			}
			return false;
		}

		public virtual void Reset()
		{
			lastRepathTime = float.NegativeInfinity;
		}

		public virtual void DidRecalculatePath(Vector3 destination)
		{
			lastRepathTime = Time.time;
			lastDestination = destination;
		}

		public void DrawGizmos(IAstarAI ai)
		{
			if (visualizeSensitivity && !float.IsPositiveInfinity(lastDestination.x))
			{
				float radius = Mathf.Sqrt(Mathf.Max((ai.position - lastDestination).sqrMagnitude, ai.radius * ai.radius) / (sensitivity * sensitivity));
				Draw.Gizmos.CircleXZ(lastDestination, radius, Color.magenta);
			}
		}
	}
}
