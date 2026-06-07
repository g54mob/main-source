using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
	public class MoveToGameObject : ActionTask<NavMeshAgent>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

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

		public override void OnDrawGizmosSelected()
		{
		}
	}
}
