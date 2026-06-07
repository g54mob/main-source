namespace Febucci.TextAnimatorCore.Typing
{
	public interface IActionState
	{
		ActionStatus Progress(float deltaTime, ref TypingInfo typingInfo);

		void Cancel();
	}
}
