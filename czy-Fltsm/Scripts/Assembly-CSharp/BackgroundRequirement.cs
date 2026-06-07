using UnityEngine;

[CreateAssetMenu(fileName = "Background Requirement", menuName = "Flotsam/Tech Tree/Background Requirement")]
public class BackgroundRequirement : TechTreeRequirement
{
	[SerializeField]
	private DrifterAttributesEffect _background;

	public DrifterAttributesEffect Background => _background;

	public override string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		if (!Background)
		{
			return "NULL";
		}
		return Background.Name;
	}

	public override bool IsMet()
	{
		if ((bool)_background)
		{
			foreach (Agent agent in Community.PlayerCommunity.Agents)
			{
				if (agent.Descriptor.PastBackground == _background || agent.Descriptor.PresentBackground == _background)
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	public override bool TryGetAmount(out int amount)
	{
		amount = 0;
		return false;
	}
}
