using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_ModifyBlockSlot : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private Image image_Slot;

	[SerializeField]
	private UI_Obj_ShopCard card;

	[SerializeField]
	private Image image_DashLine_Activated;

	[SerializeField]
	private Image image_DashLine_Deactivated;

	private bool isActivated;

	private int index;

	private int cost;

	private CardData curData;

	private Action<int, int, CardData> OnSlotSelectedCallback;

	public Button Button => null;

	public bool IsActivated => false;

	private void OnEnable()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClickButton()
	{
	}

	public void SetActivated(bool isOn)
	{
	}

	public void SetupCardData(int index, CardData cardData, int cost, Action<int, int, CardData> callback)
	{
	}
}
