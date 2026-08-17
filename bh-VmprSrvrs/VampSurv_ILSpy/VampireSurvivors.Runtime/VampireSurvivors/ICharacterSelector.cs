using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public interface ICharacterSelector
{
	void ShowCharacterInfo(CharacterData charData, CharacterType cType, CharacterItemUI character);
}
