using System;

namespace TheKiwiCoder
{
	[Serializable]
	public class Failure : DecoratorNode
	{
		protected override void OnStart()
		{
		}

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
			if (child == null)
			{
				return State.Failure;
			}
			State state = child.Update();
			if (state == State.Success)
			{
				return State.Failure;
			}
			return state;
		}
	}
}
