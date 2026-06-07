namespace Febucci.TextAnimatorCore.Typing.BuiltIn
{
	public class SpeedActionState : IActionState
	{
		private readonly float speedMultiplier;

		private bool applied;

		public SpeedActionState(float speedMultiplier)
		{
			this.speedMultiplier = speedMultiplier;
			applied = false;
		}

		public ActionStatus Progress(float deltaTime, ref TypingInfo typingInfo)
		{
			if (!applied)
			{
				typingInfo.speed *= speedMultiplier;
				applied = true;
			}
			return ActionStatus.Finished;
		}

		public void Cancel()
		{
		}
	}
}
