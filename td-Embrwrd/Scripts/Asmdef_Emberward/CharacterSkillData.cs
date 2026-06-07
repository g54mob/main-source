using System;
using UnityEngine;

[Serializable]
public class CharacterSkillData
{
	public Sprite icon;

	public Color color;

	public eItemType showItemType;

	[TextArea(3, 10)]
	public string note;
}
