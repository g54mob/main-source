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
