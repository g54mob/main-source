using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseRegion : MonoBehaviour
{
	public MenuButton pauseButton;

	public Image pauseImage;

	public UnityAction onChangedDelegate;

	public AssignableState displayedSettings;

	public OverrideState displayedPauseState;

	private bool isDisplayingInherited;

	[NonSerialized]
	public bool hideWhenInactive;

	public void Initialize(UnityAction del)
	{
		pauseButton.InitializeButton();
		pauseButton.AddPointerClickTrigger(OnPauseButtonClicked);
		pauseButton.buttonState = CustomButtonState.Background;
		pauseButton.highlightTextDelegate = HighlightTextDelegatePanel;
		pauseButton.AddRightClickTrigger(OnPauseButtonRightClicked);
		onChangedDelegate = del;
	}

	private void OnPauseButtonRightClicked()
	{
		SoundManager.PlayButtonClickSmall();
		displayedSettings.pause.ChangeValue(OverrideState.None);
		onChangedDelegate?.Invoke();
	}

	private void OnPauseButtonClicked()
	{
		PopupIconGrid target = MenuManager.Instance.ShowPopupIconGrid((RectTransform)base.transform);
		AddPopup(PauseState.DefaultNone, target);
		AddPopup(PauseState.Paused, target);
		AddPopup(PauseState.Play, target);
	}

	private void AddPopup(PauseState pauseState, PopupIconGrid target)
	{
		OverrideState overrideState = GameUtility.OverrideStateForPauseState(pauseState);
		target.AddIcon(IconManager.SpriteForPausedState(overrideState), pauseState, OnPauseSelected).isSelected = displayedSettings.pause.value == overrideState;
	}

	public void OnPauseSelected(NavigationIcon sender)
	{
		if (sender.loadedObject is PauseState pauseState)
		{
			OverrideState nextValue = GameUtility.OverrideStateForPauseState(pauseState);
			displayedSettings.pause.ChangeValue(nextValue);
			onChangedDelegate?.Invoke();
		}
		MenuManager.Instance.popupIconGrid.Hide();
	}

	public void SetPauseDisplay(bool showAsPaused)
	{
		pauseImage.sprite = IconManager.SpriteForPausedState(showAsPaused);
		pauseImage.color = (showAsPaused ? Color.white : ColorManager.inheritedStateColor);
		pauseButton.isSelected = showAsPaused;
		displayedPauseState = (showAsPaused ? OverrideState.On : OverrideState.Off);
	}

	public void SetLocalPauseDisplay(OverrideState localState)
	{
		pauseImage.sprite = IconManager.SpriteForPausedState(localState);
		bool flag = localState != OverrideState.None;
		pauseImage.color = (flag ? Color.white : ColorManager.inheritedStateColor);
		pauseButton.isSelected = flag;
		displayedPauseState = localState;
	}

	public void SetPauseDisplay(OverrideState localState, OverrideState appliedState)
	{
		pauseImage.sprite = IconManager.SpriteForPausedState(appliedState);
		bool flag = localState != OverrideState.None;
		pauseImage.color = (flag ? Color.white : ColorManager.inheritedStateColor);
		pauseButton.isSelected = flag;
		isDisplayingInherited = localState == OverrideState.None && appliedState != OverrideState.None;
		displayedPauseState = appliedState;
		if (hideWhenInactive)
		{
			pauseImage.enabled = localState != OverrideState.None || appliedState != OverrideState.None;
			if (!(null == pauseButton.stateImage))
			{
				pauseButton.stateImage.enabled = pauseImage.enabled;
			}
		}
	}

	public string HighlightTextDelegatePanel()
	{
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		if (displayedPauseState == OverrideState.None)
		{
			pooledStringBuilder.AppendFormat(TextDisplay.LocalizedKeyValueFormat(), "Pause".Localized(), TextDisplay.LabelforPauseState(displayedPauseState));
		}
		else
		{
			pooledStringBuilder.Append(TextDisplay.LabelforPauseState(displayedPauseState));
		}
		if (isDisplayingInherited)
		{
			pooledStringBuilder.Append(TextDisplay.NewLine);
			pooledStringBuilder.Append("TooltipInheritedSetting".Localized());
		}
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}

	private void OnDisable()
	{
	}
}
