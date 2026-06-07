using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipIconLabelListItem : MenuButton
{
	public Image iconImage;

	public TextMeshProUGUI primaryLabel;

	private bool hasInitialized;

	private EntityId navigationTarget;

	private EntityId rightHandEntityId;

	public CostIcon rightHandCostIcon;

	public void ResetDisplay()
	{
		tooltipEntity = EntityId.None;
		rightHandEntityId = EntityId.None;
		FormatImpossibleState(isImpossible: false);
		if (null != rightHandCostIcon)
		{
			rightHandCostIcon.gameObject.SetActive(value: false);
			rightHandCostIcon.label.enabled = false;
		}
		if (!hasInitialized)
		{
			PerformLocalInitialization();
		}
	}

	private void PerformLocalInitialization()
	{
		if (null != rightHandCostIcon)
		{
			rightHandCostIcon.highlightTextDelegate = RightHandTooltip;
		}
		AddPointerClickTrigger(OnClickedEntity);
		hasInitialized = true;
	}

	public void LoadRightHandEntity(EntityId id)
	{
		rightHandCostIcon.gameObject.SetActive(value: true);
		rightHandEntityId = id.GetCopy();
		rightHandCostIcon.iconImage.sprite = IconManager.SpriteForEntity(id);
	}

	private string RightHandTooltip()
	{
		if (rightHandEntityId.TryAsBiome(out var t))
		{
			return string.Format("TooltipBiomeUnique".Localized(), TextDisplay.LabelForBiome(t));
		}
		return null;
	}

	public void LoadEntity(EntityId id, bool prependEntityCategory, BiomeType invalidBiomeWarning = BiomeType.None)
	{
		iconImage.sprite = IconManager.SpriteForEntity(id);
		if (prependEntityCategory)
		{
			primaryLabel.text = TextDisplay.FormattedRewardEntityWithType(id);
		}
		else
		{
			primaryLabel.text = TextDisplay.LabelForEntity(id);
		}
		navigationTarget = id;
		if (!hasInitialized)
		{
			PerformLocalInitialization();
		}
	}

	private void OnClickedEntity()
	{
		MenuManager.Instance.OnClickedTooltipNavigation(navigationTarget);
	}

	public void LoadBiomeModifier(BiomeModifier modifier, StringBuilder sb)
	{
		navigationTarget = EntityId.None;
		iconImage.sprite = IconManager.SpriteForEntity(modifier.target);
		tooltipEntity = modifier.target;
		sb.Clear();
		sb.Append(TextDisplay.LabelForBiomeModifier(modifier));
		if (modifier.effect != BiomeModifierType.UniqueResource && modifier.effect != BiomeModifierType.UniqueBuilding && modifier.effect != BiomeModifierType.UniqueRecipe && GameUtility.IsNotZero(modifier.multiplier))
		{
			sb.Append(' ');
			if (modifier.multiplier >= 1f)
			{
				sb.Append("<color=#00FF00>");
				sb.Append('+');
			}
			else
			{
				sb.Append("<color=#FF0000>");
			}
			sb.Append(TextDisplay.Percent(modifier.multiplier - 1f));
			sb.Append("</color>");
		}
		primaryLabel.SetText(sb);
		if (!hasInitialized)
		{
			AddPointerClickTrigger(OnClickedEntity);
			hasInitialized = true;
		}
	}

	public void FormatImpossibleState(bool isImpossible)
	{
		primaryLabel.color = (isImpossible ? Color.gray : Color.white);
	}
}
