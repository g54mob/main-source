using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AutoAssignRegion : MonoBehaviour
{
	public Image autoAssignImage;

	public MenuButton autoAssignButton;

	private bool displayedState;

	public AssignableState displayedSettings;

	public UnityAction onChangedDelegate;

	public void Initialize(UnityAction clickDelegate, UnityAction changeDelegate)
	{
		autoAssignButton.AddPointerClickTrigger(clickDelegate);
		onChangedDelegate = changeDelegate;
		autoAssignButton.AddRightClickTrigger(OnRightClicked);
		autoAssignButton.buttonState = CustomButtonState.Background;
		autoAssignButton.highlightTextDelegate = HighlightTextAutoAssign;
	}

	private void OnRightClicked()
	{
		SoundManager.PlayButtonClickSmall();
		displayedSettings.autoAssign.ChangeValue(OverrideState.None);
		onChangedDelegate?.Invoke();
	}

	private string HighlightTextAutoAssign()
	{
		if (displayedSettings == null)
		{
			return null;
		}
		string localizedValue = ((displayedSettings.autoAssign.value == OverrideState.On) ? "On".Localized() : "Off".Localized());
		return TextDisplay.FormattedKeyValue("AutomaticAssignment", localizedValue);
	}

	public void SetDisplayedState(OverrideState localState, OverrideState appliedState)
	{
		autoAssignImage.sprite = IconManager.SpriteForAutoAssignState(appliedState);
		bool flag = localState == OverrideState.None;
		autoAssignImage.color = (flag ? ColorManager.inheritedStateColor : Color.white);
		autoAssignButton.isSelected = !flag;
	}

	public void SetDisplayedState(bool state)
	{
		bool flag = !state;
		autoAssignButton.isSelected = state;
		autoAssignImage.sprite = (state ? IconManager.Instance.automaticAssignmentOn : IconManager.Instance.automaticAssignmentOff);
		autoAssignImage.color = (flag ? ColorManager.inheritedStateColor : Color.white);
		displayedState = state;
	}
}
