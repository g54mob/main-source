using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement/Pathfinding")]
	[Description("Move Randomly or Progressively between various game object positions taken from the list provided")]
	public class Patrol : ActionTask<NavMeshAgent>
	{
		public enum PatrolMode
		{
			Progressive = 0,
			Random = 1
		}

		[RequiredField]
		[Tooltip("A list of gameobjects patrol points.")]
		public BBParameter<List<GameObject>> targetList;

		[Tooltip("The mode to use for patrol (progressive or random)")]
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
