using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Serializable]
	public struct WargameSkillCondition
	{
		[SerializeField]
		private int[] m_dices;

		public WargameSkillCondition(IEnumerable<int> dices)
		{
			List<int> list = new List<int>();
			foreach (int dix in dices)
			{
				if (dix == 0)
				{
					break;
				}
				list.Add(dix);
			}
			while (list.Count < 3)
			{
				list.Add(0);
			}
			m_dices = list.ToArray();
		}

		public List<int> GetCombination()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < m_dices.Length; i++)
			{
				if (m_dices[i] != 0)
				{
					list.Add(m_dices[i]);
				}
			}
			return list;
		}

		public int TriggerCount(int[] dices, int combinationModification)
		{
			List<int> combination = GetCombination();
			while (combinationModification < 0 && combination.Count > 1)
			{
				combination.RemoveAt(combination.Count - 1);
				combinationModification++;
			}
			int num = 0;
			for (int i = 0; i < dices.Length - (combination.Count - 1); i++)
			{
				for (int j = 0; j < combination.Count && dices[j + i] == combination[j]; j++)
				{
					if (j == combination.Count - 1)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int TriggerCount(int[] dices, List<int> usedDices, int combinationModification)
		{
			usedDices.Clear();
			List<int> list = new List<int>();
			List<int> combination = GetCombination();
			while (combinationModification < 0 && combination.Count > 1)
			{
				combination.RemoveAt(combination.Count - 1);
				combinationModification++;
			}
			int num = 0;
			for (int i = 0; i < dices.Length - (combination.Count - 1); i++)
			{
				list.Clear();
				for (int j = 0; j < combination.Count && dices[j + i] == combination[j]; j++)
				{
					list.Add(j + i);
					if (j != combination.Count - 1)
					{
						continue;
					}
					num++;
					foreach (int item in list)
					{
						if (!usedDices.Contains(item))
						{
							usedDices.Add(item);
						}
					}
				}
			}
			return num;
		}
	}
}
