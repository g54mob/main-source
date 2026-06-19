using System;

namespace TheKiwiCoder
{
	[Serializable]
	public class CompareProperty : ActionNode
	{
		public BlackboardKeyValuePair pair;

		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			BlackboardKey value = pair.value;
			BlackboardKey key = pair.key;
			if (value != null && key != null && key.Equals(value))
			{
				return State.Success;
			}
			return State.Failure;
		}
	}
}
