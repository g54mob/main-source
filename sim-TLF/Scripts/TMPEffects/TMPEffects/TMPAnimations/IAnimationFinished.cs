using TMPEffects.CharacterData;

namespace TMPEffects.TMPAnimations
{
	public interface IAnimationFinished
	{
		bool Finished(int index);

		bool Finished(CharData cData);
	}
}
