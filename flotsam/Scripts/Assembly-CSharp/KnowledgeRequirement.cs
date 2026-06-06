using UnityEngine;

[CreateAssetMenu(fileName = "Knowledge Requirement", menuName = "Flotsam/Tech Tree/Knowledge Requirement")]
public class KnowledgeRequirement : TechTreeRequirement
{
	[SerializeField]
	private int _amount;

	public int Amount => _amount;

	public override bool IsMet()
	{
		return true;
	}

	public override bool TryGetAmount(out int amount)
	{
		amount = _amount;
		return true;
	}

	public override string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return $"{_amount} {base.Description}";
	}
}
