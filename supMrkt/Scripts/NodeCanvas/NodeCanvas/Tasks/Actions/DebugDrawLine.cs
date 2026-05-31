using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility")]
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
