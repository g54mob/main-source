using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameSpeedControl : AUISituational
{
	private enum eGameSpeedType
	{
		_1x = 0,
		_1p5x = 1,
		_2x = 2,
		_half = 3
	}

	[SerializeField]
	private Button button_GameSpeed;

	[SerializeField]
	private List<GameObject> list_Node_SpeedIcons;

	[SerializeField]
	private eGameSpeedType currentGameSpeedType;

	[SerializeField]
	private eGameSpeedType previousGameSpeedType;

	[SerializeField]
	private Button button_GameSpeed_Half;

	[SerializeField]
	private Button button_GameSpeed_1x;

	[SerializeField]
	private Button button_GameSpeed_1p5x;

	[SerializeField]
	private Button button_GameSpeed_2x;

	[SerializeField]
	private Image image_SpeedIcon_Half;

	[SerializeField]
	private Image image_SpeedIcon_1x;

	[SerializeField]
	private Image image_SpeedIcon_1p5x;

	[SerializeField]
	private Image image_SpeedIcon_2x;

	[SerializeField]
	private Image image_BlockSlowSpeed;

	[SerializeField]
	private Image image_BlockNormalSpeed;

	[SerializeField]
	private Color color_SelectedSpeed;

	[SerializeField]
	private Color color_NotSelectedSpeed;

	[SerializeField]
	private GameObject node_KeyboardInputHint;

	[SerializeField]
	private GameObject node_JoystickInputHint;

	private bool isInBattle;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void UpdateInputHint()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnBattleStart()
	{
	}

	private void OnBattleEnd()
	{
	}

	private void OnHideCommonIngameUI()
	{
	}

	private void OnClickButton_GameSpeed()
	{
	}

	private void OnClickButton_GameSpeed(eGameSpeedType speedType)
	{
	}

	private void SetGameSpeedBySpeedType()
	{
	}

	private void SwitchToSlowerSpeed()
	{
	}

	private void SwitchToFasterSpeed()
	{
	}

	private void SwitchToNextSpeed(bool doLoop = true)
	{
	}

	private void UpdateButton()
	{
	}
}
