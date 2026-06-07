using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Buildable Requirement", menuName = "Flotsam/Actions/Requirements/Any Buildable Requirement")]
public class AnyBuildableRequirement : RequirementBase
{
	[SerializeField]
	private BuildableProperties[] _buildables;

	public override Sprite GetIcon()
	{
		throw new NotImplementedException();
	}

	public override bool IsMet()
	{
		foreach (Buildable buildable in Community.PlayerCommunity.Buildables)
		{
			if (IsMatch(buildable))
			{
				return true;
			}
		}
		return false;
	}

	public override bool TryGetAmount(out int amount)
	{
		throw new NotImplementedException();
	}

	private bool IsMatch(Buildable buildable)
	{
		BuildableProperties[] buildables = _buildables;
		foreach (BuildableProperties buildableProperties in buildables)
		{
			if (buildable.Properties == buildableProperties)
			{
				return true;
			}
		}
		return false;
	}
}
