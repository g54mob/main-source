using System.Collections.Generic;
using NSMedieval.Manager;
using NSMedieval.Manager.RaidEndConditions;
using NSMedieval.State;
using NSMedieval.Village;
using UnityEngine;

public static class RaidUtil
{
	public static List<RaidPointsFactor> CreateFactors(ActiveRaidInfo raidInfo, IEnumerable<HumanoidInstance> units, bool isSecondMap, bool buildingsOwnedByThisSide = false)
	{
		if (buildingsOwnedByThisSide)
		{
			return new List<RaidPointsFactor>
			{
				new CombatUnitRaidPointsFactor(raidInfo, units),
				new BuildingsRaidPointsFactor(raidInfo, FactionOwnership.Player)
			};
		}
		if (!isSecondMap)
		{
			return new List<RaidPointsFactor>
			{
				new CombatUnitRaidPointsFactor(raidInfo, units)
			};
		}
		return new List<RaidPointsFactor>
		{
			new CombatUnitRaidPointsFactor(raidInfo, units),
			new BuildingsRaidPointsFactor(raidInfo, FactionOwnership.Enemy)
		};
	}

	public static List<RaidEndCondition> CreateEndConditions(ActiveRaidInfo raid, IEnumerable<HumanoidInstance> units)
	{
		return new List<RaidEndCondition>
		{
			new ManyUnitsDeadEndCondition(raid, units),
			new NoDamageTimeoutEndCondition(raid)
		};
	}

	public static (float normalizedPoints, float maxPointsRaw) CalculateNormalizedPoints(List<RaidPointsFactor> factors)
	{
		float num = 0f;
		float num2 = 0f;
		foreach (RaidPointsFactor factor in factors)
		{
			num += factor.MaxPoints;
			num2 += factor.CurrentPoints;
		}
		return (normalizedPoints: Mathf.Clamp01(num2 / num), maxPointsRaw: num);
	}

	public static void FillTooltipLines(List<RaidPointsFactor> factors, float allFactorsMaxPoints, List<string> outputLines, bool isPlayer)
	{
		foreach (RaidPointsFactor factor in factors)
		{
			if (!Mathf.Approximately(factor.CurrentPoints, factor.MaxPoints))
			{
				int num = Mathf.RoundToInt(Mathf.Abs(factor.MaxPoints - factor.CurrentPoints) / allFactorsMaxPoints * 100f);
				string text = (isPlayer ? "DefaultRed" : "DefaultGreen");
				string text2 = (isPlayer ? "-" : "+");
				string text3 = (isPlayer ? factor.LocalizedNamePlayer : factor.LocalizedNameEnemy);
				outputLines.Add($"<style={text}>{text2}{num}</style> {text3}");
			}
		}
	}
}
