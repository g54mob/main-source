using System;

namespace TheKiwiCoder
{
	[Serializable]
	public abstract class ConditionNode : ActionNode
	{
		public bool invert;

		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			bool flag = CheckCondition();
			if (invert)
			{
				flag = !flag;
			}
			if (flag)
			{
				return State.Success;
			}
			return State.Failure;
		}

		protected abstract bool CheckCondition();
	}
}
