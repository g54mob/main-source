using UnityEngine;

public class SVInformationUI : MonoBehaviour
{
	public UITextLabel IconLabel;

	public UITextLabel IconOffLabel;

	public UITextLabel CtrlHintLabel;

	private void Awake()
	{
		IconOffLabel.gameObject.SetActive(false);
		CtrlHintLabel.gameObject.SetActive(false);
	}

	public void ShowIconOff()
	{
		IconOffLabel.gameObject.SetActive(true);
	}

	public void HideIconOff()
	{
		IconOffLabel.gameObject.SetActive(false);
	}

	public void ShowCtrlHint()
	{
		CtrlHintLabel.gameObject.SetActive(true);
	}

	public void HideCtrlHint()
	{
		CtrlHintLabel.gameObject.SetActive(false);
	}
}
