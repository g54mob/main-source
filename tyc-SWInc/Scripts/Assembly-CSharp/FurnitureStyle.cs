using System;
using System.Collections.Generic;

[Serializable]
public class FurnitureStyle : IStyle
{
	public SVector3 Color1;

	public SVector3 Color2;

	public SVector3 Color3;

	public string Replacement1;

	public string Replacement2;

	public int AtlasIndex = -1;

	public SVector3 this[int idx]
	{
		get
		{
			switch (idx)
			{
			case 0:
				return Color1;
			case 1:
				return Color2;
			case 2:
				return Color3;
			default:
				return SVector3.One;
			}
		}
		set
		{
			switch (idx)
			{
			case 0:
				Color1 = value;
				break;
			case 1:
				Color2 = value;
				break;
			case 2:
				Color3 = value;
				break;
			}
		}
	}

	public string Name
	{
		get
		{
			return "";
		}
	}

	public FurnitureStyle()
	{
	}

	public FurnitureStyle(SVector3 c1, SVector3 c2, SVector3 c3, string replacement1, string replacement2, int atlasIndex)
	{
		Color1 = c1;
		Color2 = c2;
		Color3 = c3;
		Replacement1 = replacement1;
		Replacement2 = replacement2;
		AtlasIndex = atlasIndex;
	}

	public FurnitureStyle(SVector3 c1, SVector3 c2, SVector3 c3, string replacement1, string replacement2)
	{
		Color1 = c1;
		Color2 = c2;
		Color3 = c3;
		Replacement1 = replacement1;
		Replacement2 = replacement2;
		AtlasIndex = -1;
	}

	public FurnitureStyle(WallSnap f, bool prefab)
	{
		if (prefab)
		{
			Color1 = (f.ColorPrimaryEnabled ? ((SVector3)f.ColorPrimaryDefault) : null);
			Color2 = (f.ColorSecondaryEnabled ? ((SVector3)f.ColorSecondaryDefault) : null);
			Color3 = (f.ColorTertiaryEnabled ? ((SVector3)f.ColorTertiaryDefault) : null);
		}
		else
		{
			Color1 = (f.ColorPrimaryEnabled ? ((SVector3)f.ActualColorPrimary) : null);
			Color2 = (f.ColorSecondaryEnabled ? ((SVector3)f.ActualColorSecondary) : null);
			Color3 = (f.ColorTertiaryEnabled ? ((SVector3)f.ActualColorTertiary) : null);
		}
		Replacement1 = f.GetReplacement(0);
		Replacement2 = f.GetReplacement(1);
	}

	public FurnitureStyle Clone()
	{
		return new FurnitureStyle(Color1, Color2, Color3, Replacement1, Replacement2, AtlasIndex);
	}

	public void Apply(Selectable s, List<UndoObject.UndoAction> undos)
	{
		WallSnap wallSnap = s as WallSnap;
		if (wallSnap != null)
		{
			bool flag = true;
			bool flag2 = true;
			UserImageFrame component;
			if (wallSnap.TryGetComponent<UserImageFrame>(out component))
			{
				component.SetImage(Replacement2);
				flag2 = false;
			}
			HardwareDesignFurn component2;
			if (wallSnap.TryGetComponent<HardwareDesignFurn>(out component2))
			{
				component2.ProductID = Replacement1.ConvertToUIntDef(0u);
				component2.AddonID = Replacement2.ConvertToUIntDef(0u);
				flag = false;
				flag2 = false;
			}
			if (wallSnap.ColorPrimaryEnabled && !wallSnap.ForceColorPrimary)
			{
				wallSnap.ColorPrimary = Color1 ?? ((SVector3)wallSnap.ColorPrimaryDefault);
			}
			if (wallSnap.ColorSecondaryEnabled && !wallSnap.ForceColorSecondary)
			{
				wallSnap.ColorSecondary = Color2 ?? ((SVector3)wallSnap.ColorSecondaryDefault);
			}
			if (wallSnap.ColorTertiaryEnabled && !wallSnap.ForceColorTertiary)
			{
				wallSnap.ColorTertiary = Color3 ?? ((SVector3)wallSnap.ColorTertiaryDefault);
			}
			if (flag && Replacement1 != null && wallSnap.ReplacementGroups.Length != 0)
			{
				wallSnap.SetReplacement(wallSnap.ReplacementGroups[0], Replacement1);
			}
			if (flag2 && Replacement2 != null && wallSnap.ReplacementGroups.Length > 1)
			{
				wallSnap.SetReplacement(wallSnap.ReplacementGroups[1], Replacement2);
			}
			if (AtlasIndex >= 0)
			{
				wallSnap.AtlasIndex = AtlasIndex;
			}
		}
	}

	public bool Match(MaterialPreviewer.Mode m)
	{
		return m == MaterialPreviewer.Mode.Furniture;
	}

	public bool Match(IStyle ss)
	{
		FurnitureStyle furnitureStyle = ss as FurnitureStyle;
		if (furnitureStyle == null)
		{
			return false;
		}
		if (SVector3.MatchColor(Color1, furnitureStyle.Color1) && SVector3.MatchColor(Color2, furnitureStyle.Color2) && SVector3.MatchColor(Color3, furnitureStyle.Color3) && Replacement1.EqualsEmpty(furnitureStyle.Replacement1))
		{
			return Replacement2.EqualsEmpty(furnitureStyle.Replacement2);
		}
		return false;
	}

	public bool Match(Selectable s)
	{
		WallSnap wallSnap = s as WallSnap;
		if (wallSnap == null)
		{
			return false;
		}
		if (SVector3.MatchColor(Color1, wallSnap.ActualColorPrimary) && SVector3.MatchColor(Color2, wallSnap.ActualColorSecondary) && SVector3.MatchColor(Color3, wallSnap.ActualColorTertiary) && Replacement1.EqualsEmpty(wallSnap.GetReplacement(0)))
		{
			return Replacement2.EqualsEmpty(wallSnap.GetReplacement(1));
		}
		return false;
	}
}
