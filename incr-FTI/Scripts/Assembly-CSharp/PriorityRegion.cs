using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PriorityRegion : MonoBehaviour
{
	public Image priorityImage;

	public MenuButton priorityButton;

	private StatePriority displayedPriority;

	public UnityAction onChangedDelegate;

	public AssignableState displayedSettings;

	private bool isDisplayingInherited;

	[NonSerialized]
	public bool hideWhenInactive;

	public void Initialize(UnityAction del)
	{
		if (null != priorityButton)
		{
			priorityButton.InitializeButton();
			priorityButton.AddPointerClickTrigger(OnPriorityButtonClicked);
			priorityButton.AddRightClickTrigger(OnPriorityButtonRightClicked);
			priorityButton.buttonState = CustomButtonState.Background;
			priorityButton.highlightTextDelegate = HighlightTextDelegatePanel;
			priorityButton.AnimateInstant();
		}
		onChangedDelegate = del;
	}

	private void OnPriorityButtonRightClicked()
	{
		SoundManager.PlayButtonClickSmall();
		displayedSettings.priority.ChangeValue(StatePriority.None);
		onChangedDelegate?.Invoke();
	}

	private void OnPriorityButtonClicked()
	{
		PopupIconGrid target = MenuManager.Instance.ShowPopupIconGrid((RectTransform)base.transform);
		AddPopup(StatePriority.None, target);
		AddPopup(StatePriority.Lowest, target);
		AddPopup(StatePriority.Low, target);
		AddPopup(StatePriority.Regular, target);
		AddPopup(StatePriority.High, target);
		AddPopup(StatePriority.Highest, target);
	}

	private void AddPopup(StatePriority priority, PopupIconGrid target)
	{
		target.AddIcon(IconManager.SpriteForPriority(priority), priority, OnPrioritySelected).isSelected = displayedSettings.priority.value == priority;
	}

	public void OnPrioritySelected(NavigationIcon sender)
	{
		if (sender.loadedObject is StatePriority nextValue)
		{
			displayedSettings.priority.ChangeValue(nextValue);
			onChangedDelegate?.Invoke();
		}
		MenuManager.Instance.popupIconGrid.Hide();
	}

	public void SetPriorityImage(StatePriority p)
	{
		bool flag = p == StatePriority.None;
		priorityImage.sprite = IconManager.SpriteForPriority(p);
		displayedPriority = p;
		priorityImage.color = (flag ? ColorManager.inheritedStateColor : Color.white);
		priorityButton.isSelected = !flag;
		isDisplayingInherited = false;
	}

	public void SetPriorityImage(StatePriority localPriority, StatePriority appliedPriority)
	{
		priorityImage.sprite = IconManager.SpriteForPriority(appliedPriority);
		isDisplayingInherited = localPriority == StatePriority.None && appliedPriority != StatePriority.None;
		displayedPriority = appliedPriority;
		priorityImage.color = ((localPriority == StatePriority.None) ? ColorManager.inheritedStateColor : Color.white);
		if (null != priorityButton)
		{
			priorityButton.isSelected = localPriority != StatePriority.None;
		}
		if (hideWhenInactive)
		{
			priorityImage.enabled = localPriority != StatePriority.None || appliedPriority != StatePriority.None;
			priorityButton.stateImage.enabled = priorityImage.enabled;
		}
	}

	public string HighlightTextDelegatePanel()
	{
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.AppendFormat(TextDisplay.LocalizedKeyValueFormat(), "Priority".Localized(), TextDisplay.LabelForPriority(displayedPriority));
		pooledStringBuilder.Append(TextDisplay.NewLine);
		pooledStringBuilder.Append(TextDisplay.DescriptionForPriority(displayedPriority));
		if (isDisplayingInherited)
		{
			pooledStringBuilder.Append(TextDisplay.NewLine);
			pooledStringBuilder.Append("TooltipInheritedSetting".Localized());
		}
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}
}
