using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemTutorialPopup : APopupWindow
{
	[SerializeField]
	private Button button_Close;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	private Image image_TutorialContent;

	[SerializeField]
	private TutorialSettingData tutorialSettingData;

	private eTutorialType currentTutorialType;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnLanguageChanged()
	{
	}

	private void OnClickButton_Close()
	{
	}

	public void SetTutorialType(eTutorialType type)
	{
	}

	private void UpdateText(eTutorialType type)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
