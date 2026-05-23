using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Objectives/XP Reward Formula")]
public class ObjectiveXpRewardFormulaSO : ScriptableObject
{
	public enum XpRewardFormulaType
	{
		Flat = 0,
		TierBased = 1,
		Expression = 2
	}

	public XpRewardFormulaType FormulaType = XpRewardFormulaType.TierBased;

	[ShowIf("IsExpressionType")]
	[Label("The existing variables are: \"tier\" and \"xpMultiplier\" | Only supports operators: + - / *")]
	[TextArea(2, 3)]
	public string Expression = "tier * xpMultiplier + 50";

	[Header("Rounding to Nearest Multiple")]
	[Tooltip("XP rewards will be rounded to the nearest multiple of this value.")]
	public uint RoundToNearestMultiple = 50u;

	public uint Evaluate(uint tier, uint xpMultiplier)
	{
		float value = 0f;
		switch (FormulaType)
		{
		case XpRewardFormulaType.Flat:
			value = xpMultiplier;
			break;
		case XpRewardFormulaType.TierBased:
			value = tier * xpMultiplier;
			break;
		}
		return ApplyRounding(value);
	}

	private uint ApplyRounding(float value)
	{
		if (RoundToNearestMultiple == 0)
		{
			return (uint)value;
		}
		float num = RoundToNearestMultiple;
		return (uint)(Mathf.Round(value / num) * num);
	}

	private bool IsExpressionType()
	{
		return FormulaType == XpRewardFormulaType.Expression;
	}
}
