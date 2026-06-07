using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class UI_PlayerCharacter : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Serializable]
	public class CharTypeToGameobjectDic : SerializableDictionary<eCharacterType, GameObject>
	{
	}

	[SerializeField]
	private bool doAutoInitialize;

	[SerializeField]
	private bool doShowTooltip;

	[SerializeField]
	private UI_PlayerCharacterSkillInfo ui_PlayerCharacterSkillInfo;

	[SerializeField]
	private Transform node_Character;

	[FormerlySerializedAs("dic_EventToTutorial")]
	[SerializeField]
	private CharTypeToGameobjectDic dic_CharTypeToGameobject;

	private eCharacterType characterType;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnCharacterChanged(eCharacterType type)
	{
	}

	public void ShowCharacter(eCharacterType type)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
