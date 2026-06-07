using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Drifter Attribute Level Requirement", menuName = "Flotsam/Research/Drifter Attribute Level Requirement")]
public class DrifterAttributeLevelRequirement : RequirementBase
{
	[Serializable]
	private struct AttributeIcon
	{
		public DrifterAttributes.AttributeType Attribute;

		public Sprite Icon;
	}

	[SerializeField]
	private DrifterAttributes.AttributeType _attribute;

	[SerializeField]
	private int _level;

	[SerializeField]
	private AttributeIcon[] _icons;

	public override Sprite GetIcon()
	{
		AttributeIcon[] icons = _icons;
		for (int i = 0; i < icons.Length; i++)
		{
			AttributeIcon attributeIcon = icons[i];
			if (attributeIcon.Attribute == _attribute)
			{
				return attributeIcon.Icon;
			}
		}
		Debug.LogErrorFormat("No icon found for drifter attribute '{0}'", _attribute);
		return null;
	}

	public override bool TryGetAmount(out int amount)
	{
		amount = _level;
		return true;
	}

	public override bool IsMet()
	{
		Community playerCommunity = Community.PlayerCommunity;
		if (playerCommunity == null)
		{
			return false;
		}
		foreach (Agent agent in playerCommunity.Agents)
		{
			if (_level <= agent.Attributes.ReturnTotalAttributePoints(_attribute))
			{
				return true;
			}
		}
		return false;
	}
}
