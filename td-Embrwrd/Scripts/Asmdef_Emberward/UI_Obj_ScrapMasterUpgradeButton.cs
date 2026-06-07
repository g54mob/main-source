using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_ScrapMasterUpgradeButton : MonoBehaviour
{
	public enum eButtonState
	{
		DISABLED = 0,
		CAN_SELECT = 1,
		UPGRADED = 2
	}

	[SerializeField]
	private Button button;

	[SerializeField]
	private TMP_Text text_Level;

	[SerializeField]
	private GameObject node_SelectOutline;

	[SerializeField]
	private eButtonState buttonState;

	public Action<UI_Obj_ScrapMasterUpgradeButton> OnButtonClicked;

	private UI_ScrapMasterUpgrade_Popup parentWindow;

	private ScrapMasterCardData cardData;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(UI_ScrapMasterUpgrade_Popup parentWindow, ScrapMasterCardData data, Action<UI_Obj_ScrapMasterUpgradeButton> callback)
	{
	}

	private void OnClickButton()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}
}
