using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_NewUnlockPopup : APopupWindow
{
	[Serializable]
	public class EmberUnlockData
	{
		public eEmberType emberType;

		public Sprite image;
	}

	[Serializable]
	public class ExtraRewardUnlockData
	{
		public eExtraRewardType rewardType;

		public Sprite image;
	}

	public enum eUnlockType
	{
		FLAME = 0,
		CHARACTER = 1,
		EXTRA_REWARD = 2
	}

	[SerializeField]
	private Button button_OK;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_Content;

	[SerializeField]
	private TMP_Text text_Hint;

	[SerializeField]
	private List<EmberUnlockData> list_EmberUnlockData;

	[SerializeField]
	private List<ExtraRewardUnlockData> list_ExtraRewardUnlockData;

	[SerializeField]
	private UI_PlayerCharacter ui_PlayerCharacter;

	[SerializeField]
	private ParticleSystem particle_Spark;

	private bool isOkButtonClicked;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	public void Setup(eUnlockType unlockType, eEmberType emberType, eCharacterType characterType, eExtraRewardType extraRewardType)
	{
	}

	private void Setup_Flame(eEmberType emberType)
	{
	}

	private void Setup_Character(eCharacterType characterType)
	{
	}

	private void Setup_ExtraReward(eExtraRewardType extraRewardType)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void OnClickButton_OK()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
