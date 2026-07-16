using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentModulLibrary", menuName = "AgentModulLibrary")]
public class AgentModulLibrary : ScriptableObject
{
	public List<CharacterModulType> characterType = new List<CharacterModulType>();

	public CharacterModulSaveData GetNewCharacter(int preferedType = -1, bool useBaseCharacter = false)
	{
		if (preferedType > -1)
		{
			return characterType[preferedType].GenerateCharacter(useBaseCharacter);
		}
		return characterType[Random.Range(0, characterType.Count - 1)].GenerateCharacter(useBaseCharacter);
	}

	public string GetName(byte charTypeIndex, byte firstNameIndex, byte lastNameIndex)
	{
		return characterType[charTypeIndex].firstNameVariations[firstNameIndex] + " " + characterType[charTypeIndex].secondNameVariations[lastNameIndex];
	}

	public GameObject GetCharacterBase(byte charTypeIndex)
	{
		return characterType[charTypeIndex].baseCharacter;
	}

	public GameObject GetHeadVariant(byte charTypeIndex, byte index)
	{
		return characterType[charTypeIndex].headVariations[index];
	}

	public GameObject GetBodyVariant(byte charTypeIndex, byte index)
	{
		return characterType[charTypeIndex].bodyVariations[index];
	}

	public GameObject GetHairVariant(byte charTypeIndex, byte index)
	{
		return characterType[charTypeIndex].hairVariations[index];
	}

	public Color GetHairColorVariant(byte charTypeIndex, byte index)
	{
		return characterType[charTypeIndex].hairColorVariations[index];
	}
}
