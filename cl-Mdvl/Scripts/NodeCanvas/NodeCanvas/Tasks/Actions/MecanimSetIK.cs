using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Set IK", 0)]
	[Category("Animator")]
	public class MecanimSetIK : ActionTask<Animator>
	{
		public AvatarIKGoal IKGoal;

		[RequiredField]
		public BBParameter<GameObject> goal;

		public BBParameter<float> weight;

		protected override string info => "Set '" + IKGoal.ToString() + "' " + goal;

		protected override void OnExecute()
		{
			base.router.onAnimatorIK += OnAnimatorIK;
		}

		protected override void OnStop()
		{
			base.router.onAnimatorIK -= OnAnimatorIK;
		}

		private void OnAnimatorIK(EventData<int> msg)
		{
			base.agent.SetIKPositionWeight(IKGoal, weight.value);
			base.agent.SetIKPosition(IKGoal, goal.value.transform.position);
			EndAction();
		}
	}
}
