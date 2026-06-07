using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class DebugDrawLine : ActionTask
	{
		public BBParameter<Vector3> from;

		public BBParameter<Vector3> to;

		public Color color;

		public float timeToShow;

		protected override void OnExecute()
		{
		}
	}
}
