using CTS.BBT.AI;

namespace CTS
{
	internal sealed class ContextualStateDying : ContextualStateUnconscious
	{
		public ContextualStateDying(float p_duration)
			: base(p_duration, shouldPanic: true)
		{
		}

		public override void OnUpdate()
		{
			if (IsTimerOver())
			{
				base.parent.ContextualFSM.SetStateDead();
			}
		}
	}
}
