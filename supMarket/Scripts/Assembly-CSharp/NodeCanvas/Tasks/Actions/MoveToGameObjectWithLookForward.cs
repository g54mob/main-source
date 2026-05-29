using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
	public class MoveToGameObjectWithLookForward : ActionTask<NavMeshAgent>
	{
		public BBParameter<GameObject> target;

		public BBParameter<float> speed;

		public BBParameter<float> turningSpeed;

		public BBParameter<float> keepDistance;

		public BBParameter<bool> secondLogic;

		private Vector3 lastRequest;

		private bool isFirst;

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
