using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
	public class Patrol : ActionTask<NavMeshAgent>
	{
		public enum PatrolMode
		{
			Progressive = 0,
			Random = 1
		}

		[RequiredField]
		public BBParameter<List<GameObject>> targetList;

		public BBParameter<PatrolMode> patrolMode;

		public BBParameter<float> speed;

		public BBParameter<float> keepDistance;

		private int index;

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

		public override void OnDrawGizmosSelected()
		{
		}
	}
}
