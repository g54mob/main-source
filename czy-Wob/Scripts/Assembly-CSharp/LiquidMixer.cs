using UnityEngine;

public static class LiquidMixer
{
	public static LiquidInfo CombineLiquids(LiquidInfo a, LiquidInfo b, float combineRate)
	{
		LiquidInfo liquidInfo = new LiquidInfo();
		liquidInfo.liquidColor = CombineColors(a.liquidColor, b.liquidColor, combineRate, 0.5f);
		liquidInfo.puddleColor = CombineColors(a.puddleColor, b.puddleColor, combineRate);
		liquidInfo.emissionColor = CombineColors(a.emissionColor, b.emissionColor, combineRate);
		liquidInfo.liquidMaterial = CombinePhysicsMaterials(a.liquidMaterial, b.liquidMaterial, combineRate);
		liquidInfo.puddleMat = a.puddleMat;
		if (a.liquidType != LiquidType.COMBINED && a.liquidType == b.liquidType)
		{
			liquidInfo.liquidType = a.liquidType;
			liquidInfo.liquidMaterial.name = a.liquidMaterial.name;
		}
		else
		{
			liquidInfo.liquidType = LiquidType.COMBINED;
			liquidInfo.liquidMaterial.name = "CombinedLiquid";
		}
		return liquidInfo;
	}

	private static PhysicMaterial CombinePhysicsMaterials(PhysicMaterial a, PhysicMaterial b, float combineRate)
	{
		float num = 1f / combineRate;
		if (a.frictionCombine == PhysicMaterialCombine.Average && b.frictionCombine == PhysicMaterialCombine.Average)
		{
			a.staticFriction = (a.staticFriction * num + b.staticFriction) / (num + 1f);
			a.dynamicFriction = (a.dynamicFriction * num + b.dynamicFriction) / (num + 1f);
			a.frictionCombine = PhysicMaterialCombine.Average;
		}
		else if ((a.frictionCombine == PhysicMaterialCombine.Maximum && b.frictionCombine == PhysicMaterialCombine.Minimum) || (a.frictionCombine == PhysicMaterialCombine.Minimum && b.frictionCombine == PhysicMaterialCombine.Maximum))
		{
			a.staticFriction = (a.staticFriction * num + b.staticFriction) / (num + 1f);
			a.dynamicFriction = (a.dynamicFriction * num + b.dynamicFriction) / (num + 1f);
			a.frictionCombine = PhysicMaterialCombine.Average;
		}
		else if (a.frictionCombine == PhysicMaterialCombine.Minimum || b.frictionCombine == PhysicMaterialCombine.Minimum)
		{
			a.staticFriction = ((a.staticFriction <= b.staticFriction) ? a.staticFriction : b.staticFriction);
			a.dynamicFriction = ((a.dynamicFriction <= b.dynamicFriction) ? a.dynamicFriction : b.dynamicFriction);
			a.frictionCombine = PhysicMaterialCombine.Minimum;
		}
		else if (a.frictionCombine == PhysicMaterialCombine.Maximum || b.frictionCombine == PhysicMaterialCombine.Maximum)
		{
			a.staticFriction = ((a.staticFriction >= b.staticFriction) ? a.staticFriction : b.staticFriction);
			a.dynamicFriction = ((a.dynamicFriction >= b.dynamicFriction) ? a.dynamicFriction : b.dynamicFriction);
			a.frictionCombine = PhysicMaterialCombine.Maximum;
		}
		if (a.frictionCombine == PhysicMaterialCombine.Multiply || b.frictionCombine == PhysicMaterialCombine.Multiply)
		{
			Debug.LogError("Multiply is not currently supported for liquid mixing. Either implement this or change your strategy.");
		}
		return a;
	}

	private static Color CombineColors(Color a, Color b, float combineRate, float overrideAlpha = -1f)
	{
		Color color = default(Color);
		color = Color.Lerp(a, b, combineRate);
		if (overrideAlpha != -1f)
		{
			color.a = overrideAlpha;
		}
		return color;
	}
}
