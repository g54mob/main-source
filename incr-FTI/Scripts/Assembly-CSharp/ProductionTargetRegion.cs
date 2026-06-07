using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProductionTargetRegion : MonoBehaviour
{
	public Image priorityImage;

	public MenuButton productionTargetButton;

	public AssignableState displayedSettings;

	[NonSerialized]
	public UnityAction onLimitChangedDelegate;

	[NonSerialized]
	public UnityAction onPauseChangedDelegate;

	[NonSerialized]
	public bool hideWhenInactive;

	[NonSerialized]
	public bool debug;

	public void InitializeAsEmbeddedButton()
	{
		productionTargetButton.buttonState = CustomButtonState.Background;
	}

	public void InitializeAsStandaloneButton()
	{
		if (null != productionTargetButton)
		{
			productionTargetButton.InitializeButton();
			productionTargetButton.AddPointerClickTrigger(OnRegionClicked);
			productionTargetButton.AddRightClickTrigger(OnRegionRightClicked);
			productionTargetButton.buttonState = CustomButtonState.Background;
			productionTargetButton.highlightTextDelegate = HighlightTextButton;
		}
	}

	public void AppendStatusString(StringBuilder sb, ProductionConfig applied)
	{
		if (applied.type == ProductionLimitType.DefaultNone || applied.type == ProductionLimitType.OverrideNone)
		{
			sb.Append("NoLimit".Localized());
		}
		else if (applied.type == ProductionLimitType.MeetDemand)
		{
			sb.Append("Demand".Localized());
			sb.Append(" (");
			sb.Append(TextDisplay.Percent(applied.targetDemandPercent));
			sb.Append(")");
		}
		else if (applied.type == ProductionLimitType.TargetRate)
		{
			sb.Append("Rate".Localized());
			sb.Append(" (");
			sb.Append(TextDisplay.LocalizedNumber(applied.targetRate));
			sb.Append(" / " + "TimeSecondsAbbreviation".Localized());
			sb.Append(")");
		}
		else if (applied.type == ProductionLimitType.PassiveSurplus)
		{
			sb.Append("Surplus".Localized());
		}
	}

	private string HighlightTextButton()
	{
		if (displayedSettings.DerivedPause() == OverrideState.On)
		{
			return "Paused".Localized();
		}
		ProductionConfig productionConfig = displayedSettings.DerivedProductionConfig();
		if (productionConfig == null)
		{
			return null;
		}
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append("ProductionTarget".Localized());
		pooledStringBuilder.Append(": ");
		AppendStatusString(pooledStringBuilder, productionConfig);
		if (displayedSettings.productionLimit != productionConfig && productionConfig.type != ProductionLimitType.DefaultNone)
		{
			pooledStringBuilder.Append(TextDisplay.NewLine);
			pooledStringBuilder.Append("TooltipInheritedSetting".Localized());
		}
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}

	public void SetTargetImage(ProductionLimitType mode)
	{
		if (null != priorityImage)
		{
			bool flag = mode == ProductionLimitType.DefaultNone;
			priorityImage.sprite = IconManager.SpriteForTargetMode(mode);
			priorityImage.color = (flag ? ColorManager.inheritedStateColor : Color.white);
			productionTargetButton.isSelected = !flag;
		}
	}

	public void SetTargetImage()
	{
		_ = debug;
		if (displayedSettings == null)
		{
			Debug.LogError("Null displayed settings in " + this);
			return;
		}
		ProductionConfig productionLimit = displayedSettings.productionLimit;
		ProductionConfig productionConfig = displayedSettings.DerivedProductionConfig();
		if (null == priorityImage)
		{
			return;
		}
		OverrideState overrideState = displayedSettings.DerivedPause();
		_ = debug;
		if (overrideState == OverrideState.On)
		{
			bool flag = displayedSettings.pause.value == OverrideState.On;
			priorityImage.enabled = true;
			priorityImage.sprite = IconManager.SpriteForPausedState(isPaused: true);
			priorityImage.color = (flag ? Color.white : ColorManager.inheritedStateColor);
			productionTargetButton.isSelected = flag;
		}
		else if (productionConfig.type != ProductionLimitType.DefaultNone)
		{
			bool flag2 = productionLimit.type != ProductionLimitType.DefaultNone;
			priorityImage.sprite = IconManager.SpriteForTargetMode(productionConfig.type);
			priorityImage.color = (flag2 ? Color.white : ColorManager.inheritedStateColor);
			productionTargetButton.isSelected = flag2;
			if (hideWhenInactive)
			{
				priorityImage.enabled = flag2 || productionConfig.type != ProductionLimitType.DefaultNone;
				productionTargetButton.stateImage.enabled = priorityImage.enabled;
			}
		}
		else if (overrideState == OverrideState.Off)
		{
			priorityImage.enabled = true;
			priorityImage.sprite = IconManager.SpriteForPausedState(OverrideState.Off);
			bool flag3 = displayedSettings.pause.value == OverrideState.Off;
			priorityImage.color = (flag3 ? Color.white : ColorManager.inheritedStateColor);
			productionTargetButton.isSelected = flag3;
		}
		else if (hideWhenInactive)
		{
			priorityImage.enabled = false;
		}
		else
		{
			priorityImage.enabled = true;
			priorityImage.sprite = IconManager.SpriteForTargetMode(ProductionLimitType.DefaultNone);
			priorityImage.color = ColorManager.inheritedStateColor;
			productionTargetButton.isSelected = false;
		}
		debug = false;
	}

	public void OnRegionRightClicked()
	{
		SoundManager.PlayButtonClickSmall();
		if (displayedSettings.pause.value != OverrideState.None)
		{
			displayedSettings.pause.ChangeValue(OverrideState.None);
			onPauseChangedDelegate?.Invoke();
		}
		else if (displayedSettings.productionLimit.type != ProductionLimitType.DefaultNone)
		{
			displayedSettings.productionLimit.type = ProductionLimitType.DefaultNone;
			displayedSettings.productionLimit.OnChanged();
			onLimitChangedDelegate?.Invoke();
		}
	}

	public void OnRegionClicked()
	{
		if (displayedSettings != null)
		{
			MenuManager.Instance.productionLimitPanel.DisplayForState(this);
		}
	}

	public void OnPauseChanged()
	{
		onPauseChangedDelegate?.Invoke();
	}

	public void OnProductionTargetChanged()
	{
		onLimitChangedDelegate?.Invoke();
	}
}
