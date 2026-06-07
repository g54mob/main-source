using System;
using UnityEngine;

[Serializable]
public struct BuildableRequirement
{
	[SerializeField]
	private BuildableProperties[] _buildables;

	public bool ReturnCommunityHasBuildable(Community community)
	{
		if (_buildables == null || _buildables.Length == 0)
		{
			return true;
		}
		BuildableProperties[] buildables = _buildables;
		foreach (BuildableProperties buildableProperties in buildables)
		{
			if (community.ReturnHasBuildable(buildableProperties))
			{
				return true;
			}
		}
		return false;
	}
}
