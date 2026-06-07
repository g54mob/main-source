using CTS.BBT.AI;

namespace CTS
{
	internal sealed class ContextualStateNormal : ContextualState
	{
		private ContextualStateNormal()
			: base(0f)
		{
		}

		public ContextualStateNormal(float p_speed)
			: base(p_speed)
		{
		}

		public override void OnStateExit()
		{
		}
	}
}
