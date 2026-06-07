using System;
using System.Collections.Generic;
using Febucci.UI;
using TMPro;
using UnityEngine;

public class UI_ControlTip : AUISituational
{
	public enum eControlTipType
	{
		NONE = 0,
		PLACE_TOWER = 1,
		PLACE_BLOCK = 2,
		BUFF_CARD = 3,
		DISCARD_STEP_1 = 4,
		DISCARD_STEP_2 = 5
	}

	[Serializable]
	public class TipTypeToNodePair
	{
		public eControlTipType type;

		public GameObject node;
	}

	[SerializeField]
	private Vector3 cursorOffset;

	[SerializeField]
	private List<TipTypeToNodePair> list_TipTypeToNodePair;

	[SerializeField]
	private Transform node_Error_PathBlocked;

	[SerializeField]
	private TMP_Text text_Error;

	[SerializeField]
	private TextAnimator_TMP textAnimator_Error;

	[SerializeField]
	private CanvasGroup canvasGroup_HideUsingJoystick;

	private bool isPathBlocked;

	private bool isNotEnoughCoin;

	private bool isInEnemyTerritory;

	private eControlTipType curType;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void UI_ClearAllControlTipError()
	{
	}

	private void UpdateErrorText()
	{
	}

	private void UI_ToggleControlTipError_NotEnoughCoin(bool isOn)
	{
	}

	private void UI_ToggleControlTipError_PathBlocked(bool isOn)
	{
	}

	private void UI_ToggleControlTipError_InEnemyTerritory(bool isOn)
	{
	}

	private void OnTurnOffControlTipIfType(eControlTipType type)
	{
	}

	private void OnToggleControlTip(bool isOn, eControlTipType type)
	{
	}

	private void Update()
	{
	}

	private void UpdatePosition()
	{
	}
}
