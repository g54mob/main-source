using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class CheckSpeed : ConditionTask<Rigidbody>
	{
		public CompareMethod checkType;

		public BBParameter<float> value;

		public float differenceThreshold;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
