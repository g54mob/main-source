using System.Collections.Generic;
using DV.ThingTypes;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/HazmatCurveInfos asset")]
public class HazmatCurveInfos : ScriptableObject
{
	public HazmatCurveInfo[] curveInfos;

	private Dictionary<CargoType, HazmatCurveInfo> leakAndReactionCurves = new Dictionary<CargoType, HazmatCurveInfo>();

	public (AnimationCurveAsset leakCurve, AnimationCurveAsset reactionCurve) GetLeakAndReactionCurves(CargoType cargoType)
	{
		if (leakAndReactionCurves.Count <= 0)
		{
			GenerateDictionaryEntries();
		}
		if (leakAndReactionCurves.TryGetValue(cargoType, out var value))
		{
			return (leakCurve: value.leakCurve, reactionCurve: value.reactionCurve);
		}
		return (leakCurve: null, reactionCurve: null);
	}

	private void GenerateDictionaryEntries()
	{
		leakAndReactionCurves = new Dictionary<CargoType, HazmatCurveInfo>
		{
			{
				CargoType.Milk,
				curveInfos[1]
			},
			{
				CargoType.Ammonia,
				curveInfos[1]
			},
			{
				CargoType.Argon,
				curveInfos[0]
			},
			{
				CargoType.Biohazard,
				curveInfos[1]
			},
			{
				CargoType.CryoOxygen,
				curveInfos[0]
			},
			{
				CargoType.Nitrogen,
				curveInfos[0]
			},
			{
				CargoType.SodiumHydroxide,
				curveInfos[1]
			},
			{
				CargoType.SpentNuclearFuel,
				curveInfos[9]
			},
			{
				CargoType.Acetylene,
				curveInfos[2]
			},
			{
				CargoType.Alcohol,
				curveInfos[3]
			},
			{
				CargoType.CrudeOil,
				curveInfos[4]
			},
			{
				CargoType.Diesel,
				curveInfos[5]
			},
			{
				CargoType.CryoHydrogen,
				curveInfos[6]
			},
			{
				CargoType.Methane,
				curveInfos[7]
			},
			{
				CargoType.Gasoline,
				curveInfos[8]
			}
		};
	}
}
