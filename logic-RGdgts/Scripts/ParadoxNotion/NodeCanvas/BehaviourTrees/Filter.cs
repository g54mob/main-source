using System.Collections;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class Filter : BTDecorator
	{
		public enum FilterMode
		{
			LimitNumberOfTimes = 0,
			CoolDown = 1
		}

		public enum Policy
		{
			SuccessOrFailure = 0,
			SuccessOnly = 1,
			FailureOnly = 2
		}

		public FilterMode filterMode;

		public BBParameter<int> maxCount;

		public Policy policy;

		public BBParameter<float> coolDownTime;

		public bool inactiveWhenLimited;

		private int executedCount;

		private float currentTime;

		public override void OnGraphStoped()
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		private IEnumerator Cooldown()
		{
			return null;
		}
	}
}
