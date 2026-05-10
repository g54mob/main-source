using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement/Pathfinding")]
	[Description("Makes the agent wander randomly within the navigation map")]
	public class Wander : ActionTask<NavMeshAgent>
	{
		[Tooltip("The speed to wander with.")]
		public BBParameter<float> speed;

		[Tooltip("The distance to keep from each wander point.")]
		public BBParameter<float> keepDistance;

		[Tooltip("A wander point can't be closer than this distance")]
		public BBParameter<float> minWanderDistance;

		[Tooltip("A wander point can't be further than this distance")]
		public BBParameter<float> maxWanderDistance;

		[Tooltip("If enabled, will keep wandering forever. If not, only one wander point will be performed.")]
		public bool repeat;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void DoWander()
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
