using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterModulType
{
	public enum GenderType
	{
		Male = 0,
		Female = 1,
		Other = 2
	}

	public GenderType gender;

	public List<string> firstNameVariations;

	public List<string> secondNameVariations;

	public GameObject baseCharacter;

	public List<GameObject> headVariations;

	public List<GameObject> bodyVariations;

	public List<GameObject> hairVariations;

	public List<Color> hairColorVariations;

	public CharacterModulSaveData GenerateCharacter(bool baseChar)
	{
		byte firstNameIndex = (byte)UnityEngine.Random.Range(0, firstNameVariations.Count);
		byte secondNameIndex = (byte)UnityEngine.Random.Range(0, secondNameVariations.Count);
		byte headIndex = (byte)UnityEngine.Random.Range(0, headVariations.Count);
		byte bodyIndex = (byte)UnityEngine.Random.Range(0, bodyVariations.Count);
		byte hairIndex = (byte)UnityEngine.Random.Range(0, hairVariations.Count);
		byte hairColorIndex = (byte)UnityEngine.Random.Range(0, hairColorVariations.Count);
		return new CharacterModulSaveData((byte)gender, firstNameIndex, secondNameIndex, baseChar, headIndex, bodyIndex, hairIndex, hairColorIndex);
	}
}
