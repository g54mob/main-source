using System;
using UnityEngine;

public class ChronatBuildGhost : UnitBuildGhost
{
	[NonSerialized]
	public int chronatNumber;

	public override void Init(GameObject prefab, int width, int height, bool secondary, int placementRange)
	{
	}

	protected override UnitManager CreateUnit(UnitBuildGhost ubg)
	{
		return null;
	}
}
