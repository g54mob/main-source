using UnityEngine;
using UnityEngine.UI;

public class AutoClaimRegion : MonoBehaviour
{
	public Image settingImage;

	public MenuButton settingButton;

	private bool displayedState;

	public void SetDisplayedState(OverrideState localState, OverrideState appliedState)
	{
		if (localState == OverrideState.None)
		{
			settingImage.sprite = ((appliedState == OverrideState.On) ? IconManager.Instance.automaticClaimOn : IconManager.Instance.automaticClaimNeutral);
		}
		else
		{
			settingImage.sprite = ((appliedState == OverrideState.On) ? IconManager.Instance.automaticClaimOn : IconManager.Instance.automaticClaimOff);
		}
		bool flag = localState == OverrideState.None;
		settingImage.color = (flag ? ColorManager.inheritedStateColor : Color.white);
		settingButton.isSelected = !flag;
	}

	public void SetDisplayedState(bool state)
	{
		bool flag = !state;
		settingButton.isSelected = state;
		settingImage.sprite = (state ? IconManager.Instance.automaticClaimOn : IconManager.Instance.automaticClaimNeutral);
		settingImage.color = (flag ? ColorManager.inheritedStateColor : Color.white);
		displayedState = state;
	}
}
