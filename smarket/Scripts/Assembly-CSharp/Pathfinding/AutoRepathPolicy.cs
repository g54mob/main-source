using System;
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

		public Mode mode;

		public float interval;

		public float sensitivity;

		public float maximumInterval;

		public bool visualizeSensitivity;

		private Vector3 lastDestination;

		private float lastRepathTime;

		public virtual bool ShouldRecalculatePath(IAstarAI ai)
		{
			return false;
		}

		public virtual void Reset()
		{
		}

		public virtual void DidRecalculatePath(Vector3 destination)
		{
		}

		public void DrawGizmos(IAstarAI ai)
		{
		}
	}
}
