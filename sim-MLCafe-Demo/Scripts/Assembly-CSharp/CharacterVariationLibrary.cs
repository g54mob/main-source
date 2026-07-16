using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterVariationLibrary", menuName = "CharacterVariationLibrary")]
public class CharacterVariationLibrary : ScriptableObject
{
	public List<CharacterVariant> characterVariant = new List<CharacterVariant>();

	public CharacterVariant GetRandomVariant()
	{
		return characterVariant[Random.Range(0, characterVariant.Count)];
	}
}
