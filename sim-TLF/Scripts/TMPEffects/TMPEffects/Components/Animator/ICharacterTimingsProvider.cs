using TMPEffects.CharacterData;

namespace TMPEffects.Components.Animator
{
	public interface ICharacterTimingsProvider
	{
		float StateTime(CharData cData);

		float VisibleTime(CharData cData);

		float StateTime(int index);

		float VisibleTime(int index);
	}
}
