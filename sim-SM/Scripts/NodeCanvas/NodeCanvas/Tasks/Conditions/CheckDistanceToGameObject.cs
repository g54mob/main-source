using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Name("Target Within Distance", 0)]
	[Category("GameObject")]
	public class CheckDistanceToGameObject : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> checkTarget;

		public CompareMethod checkType;

		public BBParameter<float> distance;

		[SliderField(0f, 0.1f)]
		public float floatingPoint;

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
