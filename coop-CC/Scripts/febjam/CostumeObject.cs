using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "costume-", menuName = "CostumeObject", order = 1)]
public class CostumeObject : ScriptableObject
{
	public bool startsUnlocked;

	public string costumeName;

	public List<Sprite> costumeTextures = new List<Sprite>();
}
