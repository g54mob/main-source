using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmingToolButton : SelectableButton
{
	public delegate void ToolClickDelegate(FarmingToolButton button);

	public EntityId entity;

	public Image toolImage;

	public GameObject costSection;

	public TextMeshProUGUI costLabel;

	public ToolClickDelegate toolClickDelegate;

	public void Init()
	{
		AddPointerClickTrigger(OnClickedTool);
	}

	public void OnClickedTool()
	{
		PerformSelection();
	}

	public void LoadCost(float cost)
	{
		if (cost > 0f)
		{
			costSection.SetActive(value: true);
			TextDisplay.SetNumber(costLabel, cost);
		}
		else
		{
			costSection.SetActive(value: false);
		}
	}

	public override string HighlightText()
	{
		if (entity.TryAsItem(out var i))
		{
			return string.Format(TextDisplay.KeyValueFormatSpaced, "PlantSeed".Localized(), TextDisplay.LabelForItem(i));
		}
		if (entity.TryAsFarmingTool(out var i2))
		{
			return string.Format(TextDisplay.KeyValueFormatSpaced, TextDisplay.LabelForFarmingTool(i2), TextDisplay.DescriptionForFarmingTool(i2));
		}
		return base.HighlightText();
	}
}
