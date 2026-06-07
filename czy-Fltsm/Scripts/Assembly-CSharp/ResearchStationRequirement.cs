using UnityEngine;

[CreateAssetMenu(fileName = "Research Station Requirement", menuName = "Flotsam/Research/Research Station Requirement")]
public class ResearchStationRequirement : RequirementBase
{
	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private BuildableProperties[] _levels;

	[SerializeField]
	private int _level;

	public override Sprite GetIcon()
	{
		return _icon;
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
		if (_levels.Length <= _level)
		{
			Debug.LogError("There seems to be a mismatch between the required level and the available levels!");
			return false;
		}
		BuildableProperties buildableProperties = _levels[_level];
		foreach (Buildable buildable in playerCommunity.Buildables)
		{
			if (buildable.Properties == buildableProperties)
			{
				return true;
			}
		}
		return false;
	}
}
