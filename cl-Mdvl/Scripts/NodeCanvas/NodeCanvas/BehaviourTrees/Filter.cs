using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Filter", 0)]
	[Category("Decorators")]
	[Description("Filters the access of its child either a specific number of times, or every specific amount of time.")]
	[ParadoxNotion.Design.Icon("Filter", false, "")]
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

		[Tooltip("The mode to use.")]
		public FilterMode filterMode = FilterMode.CoolDown;

		[ShowIf("filterMode", 0)]
		[Name("Max Times", 0)]
		[Tooltip("The max ammount of times to allow the child to execute until the tree is completely restarted.")]
		public BBParameter<int> maxCount = 1;

		[ShowIf("filterMode", 0)]
		[Name("Increase Count When", 0)]
		[Tooltip("Only increase count if the selected status is returned from the child.")]
		public Policy policy;

		[ShowIf("filterMode", 1)]
		[Tooltip("The time to disallow execution for.")]
		public BBParameter<float> coolDownTime = 5f;

		[Name("Optional When Filtered", 0)]
		[Tooltip("If enabled, the Filter Decorator will return an Optional status when it is filtered. Otherwise it will return Failure.")]
		public bool inactiveWhenLimited = true;

		private int executedCount;

		private float currentTime;

		public override void OnGraphStoped()
		{
			executedCount = 0;
			currentTime = 0f;
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.decoratedConnection == null)
			{
				return Status.Optional;
			}
			switch (filterMode)
			{
			case FilterMode.CoolDown:
				if (currentTime > 0f)
				{
					if (!inactiveWhenLimited)
					{
						return Status.Failure;
					}
					return Status.Optional;
				}
				base.status = base.decoratedConnection.Execute(agent, blackboard);
				if (base.status == Status.Success || base.status == Status.Failure)
				{
					StartCoroutine(Cooldown());
				}
				break;
			case FilterMode.LimitNumberOfTimes:
				if (executedCount >= maxCount.value)
				{
					if (!inactiveWhenLimited)
					{
						return Status.Failure;
					}
					return Status.Optional;
				}
				base.status = base.decoratedConnection.Execute(agent, blackboard);
				if ((base.status == Status.Success && policy == Policy.SuccessOnly) || (base.status == Status.Failure && policy == Policy.FailureOnly) || ((base.status == Status.Success || base.status == Status.Failure) && policy == Policy.SuccessOrFailure))
				{
					executedCount++;
				}
				break;
			}
			return base.status;
		}

		private IEnumerator Cooldown()
		{
			for (currentTime = coolDownTime.value; currentTime > 0f; currentTime -= Time.deltaTime)
			{
				yield return null;
			}
		}
	}
}
