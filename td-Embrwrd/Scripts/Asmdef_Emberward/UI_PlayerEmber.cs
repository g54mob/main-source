using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_PlayerEmber : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Serializable]
	public class EmberTypeToGameobjectDic : SerializableDictionary<eEmberType, GameObject>
	{
	}

	[SerializeField]
	[Header("火焰種類對應的GameObject")]
	private EmberTypeToGameobjectDic dic_EmberTypeToGameobject;

	private bool isSetEmberType;

	private GameObject curEmberFire;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEmberTypeChanged(eEmberType type)
	{
	}

	public void SwitchEmber(eEmberType type)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
