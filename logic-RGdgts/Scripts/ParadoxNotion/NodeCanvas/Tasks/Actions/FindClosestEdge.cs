using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
	public class FindClosestEdge : ActionTask
	{
		public BBParameter<Vector3> targetPosition;

		[BlackboardOnly]
		public BBParameter<Vector3> saveFoundPosition;

		private NavMeshHit hit;

		protected override void OnExecute()
		{
		}
	}
}
