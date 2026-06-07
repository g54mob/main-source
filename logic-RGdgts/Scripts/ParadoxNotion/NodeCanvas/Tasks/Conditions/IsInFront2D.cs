using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class IsInFront2D : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> checkTarget;

		public BBParameter<float> viewAngle;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}

		public override void OnDrawGizmosSelected()
		{
		}
	}
}
