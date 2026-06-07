using System;
using System.Text;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameModifierListItem : SelectableButton
{
	public TextMeshProUGUI keyLabel;

	public Image checkboxImage;

	[NonSerialized]
	public GameModifier displayedModifier;

	public UnityAction<GameModifierListItem> clickDelegate;

	private bool isLocked;

	public void Initialize()
	{
		AddPointerClickTrigger(OnSelected);
	}

	public void ReloadLabels()
	{
		keyLabel.text = TextDisplay.LabelForGameModifier(displayedModifier);
	}

	public void UpdateDynamicDisplay()
	{
		if (isLocked)
		{
			checkboxImage.sprite = IconManager.Instance.locked;
		}
		else
		{
			checkboxImage.sprite = IconManager.SpriteForToggleState(isSelected);
		}
	}

	public void LoadModifier(GameModifier modifier)
	{
		displayedModifier = modifier;
		UpdateLockedState();
	}

	public void UpdateLockedState()
	{
		isLocked = !GameManager.Instance.IsModifierAvailable(displayedModifier);
		base.buttonState = ((!isLocked) ? CustomButtonState.Default : CustomButtonState.Disabled);
	}

	private void OnSelected()
	{
		if (base.allowsAction)
		{
			clickDelegate(this);
		}
		else
		{
			MenuManager.Instance.ShowMessage("RequiresFullGame".Localized());
		}
	}

	public string DerivedRequirementLabel()
	{
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		int value = GameManager.RequiredTownLevelForGameModifier(displayedModifier);
		pooledStringBuilder.Append("Requires".Localized());
		pooledStringBuilder.Append(':');
		pooledStringBuilder.Append(' ');
		pooledStringBuilder.AppendFormat("ReachTownLevelFormat".Localized(), TextDisplay.LocalizedNumber(value));
		pooledStringBuilder.Append(' ');
		pooledStringBuilder.Append('(');
		pooledStringBuilder.Append(TextDisplay.LocalizedNumber(Platform.Instance.GetStatInt(StatType.MaxTownLevel)));
		pooledStringBuilder.Append('/');
		pooledStringBuilder.Append(TextDisplay.LocalizedNumber(value));
		pooledStringBuilder.Append(')');
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}

	public string GetTooltip()
	{
		int num = GameManager.RequiredTownLevelForGameModifier(displayedModifier);
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append(TextDisplay.DescriptionForGameModifier(displayedModifier));
		if (num > 0)
		{
			bool num2 = Platform.Instance.GetStatInt(StatType.MaxTownLevel) >= num;
			pooledStringBuilder.Append(TextDisplay.NewLine);
			string value = DerivedRequirementLabel();
			if (!num2)
			{
				pooledStringBuilder.Append("<color=#FF0000>");
			}
			pooledStringBuilder.Append(value);
			if (!num2)
			{
				pooledStringBuilder.Append("</color>");
			}
		}
		pooledStringBuilder.Append(TextDisplay.NewLine);
		pooledStringBuilder.Append("<color=#FF0000>");
		pooledStringBuilder.Append("RequiresFullGame".Localized());
		pooledStringBuilder.Append("</color>");
		return GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
	}
}
