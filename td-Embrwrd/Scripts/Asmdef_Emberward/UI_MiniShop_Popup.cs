using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MiniShop_Popup : APopupWindow
{
	[SerializeField]
	private Button button_OK;

	[SerializeField]
	private UI_RelicList ui_RelicList;

	[SerializeField]
	private UI_Obj_ShopCard card_SpecialItem;

	[SerializeField]
	private TMP_Text text_Dialog;

	[SerializeField]
	private List<Transform> list_ShopCardNodes;

	[SerializeField]
	private ParticleSystem particle_Confetti;

	private List<UI_Obj_ShopCard> list_ShopCards;

	private int cost_HP;

	private int cost_Reroll;

	private eCardType specialItemType;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnButtonOKClicked()
	{
	}

	private void Update()
	{
	}

	public void SetupContent()
	{
	}

	private void OnSpecialCardClickedCallback(UI_Obj_ShopCard card)
	{
	}

	private void OnCardClickedCallback(UI_Obj_ShopCard card)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnWindowRegainFocus()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void RebuildNavigationAndSelect(Selectable prioritizedSelectable = null)
	{
	}
}
