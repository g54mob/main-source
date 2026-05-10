using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Seek (Vector3)", 0)]
	[Category("Movement/Pathfinding")]
	public class MoveToPosition : ActionTask<NavMeshAgent>
	{
		public BBParameter<Vector3> targetPosition;

		public BBParameter<float> speed;

		public BBParameter<float> keepDistance;

		private Vector3? lastRequest;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnPause()
		{
		}

		protected override void OnStop()
		{
		}
	}
}
