using System;

[Serializable]
public class InventoryItem
{
	public readonly string Type;

	public readonly uint DID;

	public readonly int AtlasIndex;

	public readonly SVector3 Color1;

	public readonly SVector3 Color2;

	public readonly SVector3 Color3;

	public readonly float Quality;

	public readonly bool Offshore;

	public readonly bool Insured = true;

	public static InventoryItem FromPrefab(Furniture f, float quality, bool offshore)
	{
		return new InventoryItem(f.name, 0u, 0, f.ColorPrimaryDefault, f.ColorSecondaryDefault, f.ColorTertiaryDefault, quality, offshore, true);
	}

	public InventoryItem Clone(uint did)
	{
		return new InventoryItem(Type, did, AtlasIndex, Color1, Color2, Color3, Quality, Offshore, Insured);
	}

	public InventoryItem()
	{
	}

	public InventoryItem(string type, uint dID, int atlasIndex, SVector3 color1, SVector3 color2, SVector3 color3, float quality, bool offshore, bool insured)
	{
		Type = type;
		DID = dID;
		AtlasIndex = atlasIndex;
		Color1 = color1;
		Color2 = color2;
		Color3 = color3;
		Quality = quality;
		Offshore = offshore;
		Insured = insured;
	}

	public InventoryItem(Furniture furn)
	{
		Type = furn.name;
		DID = furn.DID;
		if (furn.AtlasObject != null)
		{
			AtlasIndex = furn.AtlasIndex;
		}
		else
		{
			AtlasIndex = 0;
		}
		Color1 = furn.ColorPrimary;
		Color2 = furn.ColorSecondary;
		Color3 = furn.ColorTertiary;
		Quality = (furn.HasUpg ? furn.upg.Quality : 1f);
		Offshore = furn.Offshore;
		Insured = furn.Insured;
	}

	public Furniture GetFurn()
	{
		return ObjectDatabase.Instance.GetFurnitureComponent(Type);
	}

	public float SellPrice()
	{
		Furniture furn = GetFurn();
		if (furn == null)
		{
			return 0f;
		}
		return Furniture.GetSellPrice(furn.name, furn.ComputerPower, furn.UnlockYear, furn.Cost, Quality, furn.ForcePCPricing);
	}

	public float SellPrice(Furniture prefab)
	{
		return Furniture.GetSellPrice(prefab.Type, prefab.ComputerPower, prefab.UnlockYear, prefab.Cost, Quality, prefab.ForcePCPricing);
	}

	public void ReverseInsurance()
	{
		InsuranceAccount insurance = GameSettings.Instance.Insurance;
		if (!Offshore && GameSettings.Instance.PassedFireInspection && insurance.ActualContentInsurance > 0)
		{
			GameSettings.Instance.ContentsInsured -= insurance.GetContentCoverage(true) * GetCost(GetFurn());
		}
	}

	public float GetCost(Furniture prefab)
	{
		return Furniture.GetCost(prefab.name, prefab.ComputerPower, prefab.UnlockYear, prefab.Cost, prefab.ForcePCPricing);
	}

	public string GetPrettyName()
	{
		Furniture furn = GetFurn();
		return (((object)furn != null) ? furn.GetActualString() : null) ?? Type;
	}

	public void Deserialize(Furniture furn)
	{
		if (furn.AtlasObject != null)
		{
			furn.AtlasIndex = AtlasIndex;
		}
		if (furn.ColorPrimaryEnabled && !furn.ForceColorPrimary)
		{
			furn.ColorPrimary = Color1;
		}
		if (furn.ColorSecondaryEnabled && !furn.ForceColorSecondary)
		{
			furn.ColorSecondary = Color2;
		}
		if (furn.ColorTertiaryEnabled && !furn.ForceColorTertiary)
		{
			furn.ColorTertiary = Color3;
		}
		if (furn.HasUpg)
		{
			furn.upg.Quality = Quality;
			furn.upg.FromInventory = true;
			furn.upg.FixLastRepair();
		}
		furn.DID = DID;
		furn.DisableInitColor = true;
		furn.Offshore = Offshore;
		furn.Insured = Insured;
	}
}
