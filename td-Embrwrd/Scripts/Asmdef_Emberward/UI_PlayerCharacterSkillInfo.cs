using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerCharacterSkillInfo : MonoBehaviour
{
	[SerializeField]
	private List<UI_Obj_CharacterSkillEntry> list_CharacterSkillEntries;

	[SerializeField]
	private GameObject node_CharacterSkillEntry;

	private void Awake()
	{
	}

	public void Toggle(eCharacterType characterType, bool isOn)
	{
	}
}
