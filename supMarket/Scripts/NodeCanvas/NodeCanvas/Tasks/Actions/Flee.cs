using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement/Pathfinding")]
	[Description("Flees away from the target")]
	public class Flee : ActionTask<NavMeshAgent>
	{
		[RequiredField]
		[Tooltip("The target to flee from.")]
		public BBParameter<GameObject> target;

		[Tooltip("The speed to flee.")]
		public BBParameter<float> speed;

		[Tooltip("The distance to flee at.")]
		public BBParameter<float> fledDistance;

		[Tooltip("A distance to look away from the target for valid flee destination.")]
		public BBParameter<float> lookAhead;

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
