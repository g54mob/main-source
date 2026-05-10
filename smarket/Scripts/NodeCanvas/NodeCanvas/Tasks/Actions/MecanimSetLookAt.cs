using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Set Look At", 0)]
	[Category("Animator")]
	public class MecanimSetLookAt : ActionTask<Animator>
	{
		public BBParameter<GameObject> targetPosition;

		public BBParameter<float> targetWeight;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnStop()
		{
		}

		private void OnAnimatorIK(EventData<int> msg)
		{
		}
	}
}
