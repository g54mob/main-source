using System;
using Refic.Emberward.Minigame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_UI_OverchargeButton : MonoBehaviour
{
	public enum eButtonAnimState
	{
		IDLE = 0,
		CORRECT = 1,
		WRONG = 2,
		CLICK = 3,
		COMPLETED = 4
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private TMP_Text text_Number;

	[SerializeField]
	private Button button;

	private int index;

	private OverchargeItemData data;

	public Action<int, OverchargeItemData> ClickButtonCallback;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnClickButton()
	{
	}

	public void SetContent(int index, OverchargeItemData data, Color textColor)
	{
	}

	public void SetButtonState(eButtonAnimState state)
	{
	}
}
