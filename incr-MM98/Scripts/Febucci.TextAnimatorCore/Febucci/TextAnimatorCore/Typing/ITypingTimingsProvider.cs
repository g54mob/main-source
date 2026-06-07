using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore.Typing
{
	public interface ITypingTimingsProvider
	{
		float GetWaitAppearanceTimeOf(CharacterData character, TextAnimator animator);

		float GetWaitDisappearanceTimeOf(CharacterData character, TextAnimator animator);
	}
}
