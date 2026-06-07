using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Repeat", 0)]
	[Category("Decorators")]
	[Description("Repeats the child either x times or until it returns the specified status, or forever.")]
	[Icon("Repeat", false, null)]
	public class Repeater : BTDecorator
	{
		public enum RepeaterMode
		{
			RepeatTimes = 0,
			RepeatUntil = 1,
			RepeatForever = 2
		}

		public enum RepeatUntilStatus
		{
			Failure = 0,
			Success = 1
		}

		public RepeaterMode repeaterMode;

		[ShowIf("repeaterMode", 0)]
		public BBParameter<int> repeatTimes;

		[ShowIf("repeaterMode", 1)]
		public RepeatUntilStatus repeatUntilStatus;

		private int currentIteration;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected override void OnReset()
		{
		}
	}
}
