using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterSO : ScriptableObject
{
	public List<Emotion> emotions;

	public string characterName;

	public string localizationKey;
}
