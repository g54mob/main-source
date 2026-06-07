using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TradeModeRegion : MonoBehaviour
{
	public MenuButton tradeTypeButton;

	public Image tradeTypeImage;

	public AssignableState displayedSettings;

	public UnityAction onChangedDelegate;

	[NonSerialized]
	public bool allowInheritedSetting;

	private Vector3[] worldCorners = new Vector3[4];

	public void Initialize()
	{
		tradeTypeButton.InitializeButton();
		tradeTypeButton.buttonState = CustomButtonState.Background;
		tradeTypeButton.AddPointerClickTrigger(OnModeButtonPressed);
		tradeTypeButton.AddRightClickTrigger(OnModeRightClicked);
		tradeTypeButton.highlightTextDelegate = HighlightTextTradeMode;
		tradeTypeButton.isTooltipUpdatedEverySimulationStep = true;
	}

	private string HighlightTextTradeMode()
	{
		if (displayedSettings == null)
		{
			return null;
		}
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append("TradeMode".Localized());
		pooledStringBuilder.Append(':');
		pooledStringBuilder.Append(' ');
		TradeMode m = displayedSettings.DerivedTradeMode();
		pooledStringBuilder.Append(TextDisplay.TooltipForTradeMode(m));
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}

	public void SetModeImage(TradeMode m, bool isInherited = false)
	{
		tradeTypeImage.sprite = IconManager.SpriteForTradeMode(m);
		tradeTypeImage.color = (isInherited ? ColorManager.inheritedStateColor : Color.white);
		tradeTypeButton.isSelected = !isInherited;
	}

	private void AddPopup(TradeMode m, PopupIconGrid target)
	{
		target.AddIcon(IconManager.SpriteForTradeMode(m), m, OnTradeModeSelected).isSelected = displayedSettings.tradingConfig.value == m;
		Camera mainCamera = StartupManager.Instance.mainCamera;
		int childCount = target.childCount;
		int num = Screen.width - 10;
		float num2 = (float)childCount * target.layoutGroup.cellSize.x;
		if (childCount > 1)
		{
			num2 += (float)(childCount - 1) * target.layoutGroup.spacing.x;
		}
		float scaleFactor = MenuManager.Instance.canvas.scaleFactor;
		num2 *= scaleFactor;
		Vector3 vector = mainCamera.WorldToScreenPoint(target.viewTransform.position);
		float num3 = vector.x + num2 * 0.5f - (float)num;
		if (num3 > 0f)
		{
			Vector3 position = vector + new Vector3(0f - num3, 0f, 0f);
			target.viewTransform.position = mainCamera.ScreenToWorldPoint(position);
		}
	}

	private void OnModeRightClicked()
	{
		displayedSettings.tradingConfig.ChangeValue(TradeMode.None);
		onChangedDelegate?.Invoke();
	}

	private void OnModeButtonPressed()
	{
		PopupIconGrid target = MenuManager.Instance.ShowPopupIconGrid((RectTransform)base.transform);
		AddPopup(TradeMode.None, target);
		AddPopup(TradeMode.Off, target);
		AddPopup(TradeMode.Import, target);
		AddPopup(TradeMode.Export, target);
		AddPopup(TradeMode.AutoTradeLocalBalance, target);
		AddPopup(TradeMode.AutoTradeLocalFill, target);
	}

	public void OnTradeModeSelected(NavigationIcon sender)
	{
		if (sender.loadedObject is TradeMode nextValue)
		{
			displayedSettings.tradingConfig.ChangeValue(nextValue);
			onChangedDelegate?.Invoke();
		}
		MenuManager.Instance.popupIconGrid.Hide();
	}
}
