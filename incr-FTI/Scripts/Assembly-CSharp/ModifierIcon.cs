using TMPro;
using UnityEngine.UI;

public class ModifierIcon : MenuButton
{
	public Image backgroundImage;

	public Image iconImage;

	public Image modifierImage;

	private BiomeModifier loadedModifier;

	public TextMeshProUGUI label;

	public bool isHidden;

	public void InitializeModifier()
	{
		InitializeButton();
		AddPointerClickTrigger(OnClickedModifier);
	}

	private void OnClickedModifier()
	{
		if (!isHidden)
		{
			MenuManager.Instance.tooltipPanel.SetPosition(this);
			MenuManager.Instance.tooltipPanel.ToggleEntityPinState(loadedModifier.target);
		}
	}

	public string ModifierHighlightText()
	{
		if (isHidden || loadedModifier == null)
		{
			return null;
		}
		return loadedModifier.HighlightText();
	}

	public void SetHidden(bool nextState)
	{
		isHidden = nextState;
		if (isHidden)
		{
			iconImage.sprite = IconManager.Instance.menuQuestionMark;
		}
		else
		{
			LoadModifier(loadedModifier);
		}
		modifierImage.gameObject.SetActive(!isHidden);
	}

	public void LoadModifier(BiomeModifier modifier)
	{
		loadedModifier = modifier;
		iconImage.sprite = IconManager.SpriteForEntity(modifier.target);
		if (modifier.effect == BiomeModifierType.MarketDemand)
		{
			modifierImage.sprite = IconManager.Instance.happinessGeneral;
			if (modifier.target.TryAsBuilding(out var b))
			{
				iconImage.sprite = IconManager.SpriteForBuilding(b);
			}
		}
		else if (modifier.effect == BiomeModifierType.Excluded)
		{
			modifierImage.sprite = IconManager.Instance.activeStateOff;
		}
		else if (modifier.effect != BiomeModifierType.UniqueBuilding && modifier.effect != BiomeModifierType.UniqueResource && modifier.effect != BiomeModifierType.UniqueRecipe && GameUtility.IsNotZero(modifier.multiplier))
		{
			if (modifier.multiplier >= 1f)
			{
				modifierImage.sprite = IconManager.Instance.upgrade;
			}
			else
			{
				modifierImage.sprite = IconManager.Instance.downgrade;
			}
		}
		else
		{
			modifierImage.enabled = false;
		}
		label.text = string.Empty;
	}
}
