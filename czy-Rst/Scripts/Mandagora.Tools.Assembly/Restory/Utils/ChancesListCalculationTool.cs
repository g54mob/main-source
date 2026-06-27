using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Restory.Utils
{
	public static class ChancesListCalculationTool
	{
		public struct Chance
		{
			public float Percent;

			public bool Frozen;
		}

		public static void UpdateChances(List<Chance> previousChances, List<Chance> chances)
		{
			if (previousChances.Count != chances.Count)
			{
				ResolveError(CalculateError(previousChances, chances), previousChances, chances, ignoreFrozen: false);
				return;
			}
			if (chances.Count == 1)
			{
				SetSpawnChance(0, 1f, previousChances, chances);
				return;
			}
			for (int i = 0; i < chances.Count; i++)
			{
				if (chances[i].Frozen)
				{
					SetSpawnChance(i, previousChances[i].Percent, previousChances, chances);
					continue;
				}
				float num = CalculateDelta(i, previousChances, chances);
				if (Math.Abs(num) > 0.001f)
				{
					if (!CanRecalculate(previousChances, chances))
					{
						SetSpawnChance(i, previousChances[i].Percent, previousChances, chances);
						break;
					}
					RecalculateChances(i, num, previousChances, chances);
					ResolveError(CalculateError(previousChances, chances), previousChances, chances);
					break;
				}
			}
		}

		private static int GetFrozenCount(List<Chance> previousChances, List<Chance> chances)
		{
			return chances.Count((Chance x) => x.Frozen);
		}

		private static float GetFrozenChancesSum(List<Chance> previousChances, List<Chance> chances)
		{
			float num = 0f;
			foreach (Chance chance in chances)
			{
				if (chance.Frozen)
				{
					num += chance.Percent;
				}
			}
			return num;
		}

		private static float CalculateDelta(int i, List<Chance> previousChances, List<Chance> chances)
		{
			float result = previousChances[i].Percent - chances[i].Percent;
			float frozenChancesSum = GetFrozenChancesSum(previousChances, chances);
			if (chances[i].Percent + frozenChancesSum > 1f)
			{
				float num = frozenChancesSum + previousChances[i].Percent - 1f;
				SetSpawnChance(i, previousChances[i].Percent - num, previousChances, chances);
				return num;
			}
			return result;
		}

		private static void RecalculateChances(int changedElement, float delta, List<Chance> previousChances, List<Chance> chances)
		{
			delta /= (float)(chances.Count - 1 - GetFrozenCount(previousChances, chances));
			float num = 0f;
			for (int i = 0; i < chances.Count; i++)
			{
				if (i != changedElement && !chances[i].Frozen)
				{
					float num2 = chances[i].Percent + delta;
					if (num2 < 0f)
					{
						num += num2;
					}
					SetSpawnChance(i, num2, previousChances, chances);
				}
			}
			if (num == 0f)
			{
				return;
			}
			float num3 = chances.Count - GetFrozenCount(previousChances, chances) - 1;
			for (int j = 0; j < chances.Count; j++)
			{
				if (Math.Abs(chances[j].Percent) < 0.001f)
				{
					num3 -= 1f;
				}
			}
			num /= num3;
			for (int k = 0; k < chances.Count; k++)
			{
				if (k != changedElement && !(Math.Abs(chances[k].Percent) < 0.001f) && !chances[k].Frozen)
				{
					float chance = chances[k].Percent + num;
					SetSpawnChance(k, chance, previousChances, chances);
				}
			}
		}

		private static float CalculateError(List<Chance> previousChances, List<Chance> chances)
		{
			float num = 0f;
			foreach (Chance chance in chances)
			{
				num += chance.Percent;
			}
			return 1f - num;
		}

		private static void ResolveError(float error, List<Chance> previousChances, List<Chance> chances, bool ignoreFrozen = true)
		{
			error /= (float)(ignoreFrozen ? (chances.Count - GetFrozenCount(previousChances, chances)) : chances.Count);
			for (int i = 0; i < chances.Count; i++)
			{
				if (!(chances[i].Frozen && ignoreFrozen))
				{
					float chance = chances[i].Percent + error;
					SetSpawnChance(i, chance, previousChances, chances);
				}
			}
		}

		private static void SetSpawnChance(int i, float chance, List<Chance> previousChances, List<Chance> chances)
		{
			Chance value = chances[i];
			value.Percent = Mathf.Clamp01(chance);
			chances[i] = value;
		}

		private static bool CanRecalculate(List<Chance> previousChances, List<Chance> chances)
		{
			bool num = chances.Count - GetFrozenCount(previousChances, chances) <= 1;
			bool flag = Math.Abs(GetFrozenChancesSum(previousChances, chances) - 1f) < float.Epsilon;
			if (!num)
			{
				return !flag;
			}
			return false;
		}
	}
}
