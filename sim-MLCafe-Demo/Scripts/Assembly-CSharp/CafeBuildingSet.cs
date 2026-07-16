using System;
using System.Collections.Generic;

[Serializable]
public class CafeBuildingSet
{
	public string name;

	public List<CafeWallPieceVariant> variants = new List<CafeWallPieceVariant>();

	public CafeWallPieceVariant GetVariantByName(string name)
	{
		return variants.Find((CafeWallPieceVariant x) => x.name.ToLower().Contains(name.ToLower()));
	}

	public CafeWallPieceVariant GetVariantByIndex(int index)
	{
		return variants[index];
	}
}
