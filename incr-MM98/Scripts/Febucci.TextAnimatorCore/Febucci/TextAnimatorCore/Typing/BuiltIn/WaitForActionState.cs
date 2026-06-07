namespace Febucci.TextAnimatorCore.Typing.BuiltIn
{
	public class WaitForActionState : IActionState
	{
		private readonly float waitDuration;

		private float elapsed;

		public WaitForActionState(float waitDuration)
		{
			this.waitDuration = waitDuration;
			elapsed = 0f;
		}

		public ActionStatus Progress(float deltaTime, ref TypingInfo typingInfo)
		{
			elapsed += deltaTime;
			if (elapsed >= waitDuration)
			{
				return ActionStatus.Finished;
			}
			return ActionStatus.Running;
		}

		public void Cancel()
		{
		}
	}
}
