using System;
using System.Text;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Serializable]
	public class MiniatureRarityModifier
	{
		[SerializeField]
		private float[] m_percentages;

		public bool IsPossible(int rarity)
		{
			return m_percentages[rarity - 1] > 0f;
		}

		public int GetWeight(int rarity)
		{
			if (m_percentages[rarity - 1] == 0f)
			{
				return 0;
			}
			return Mathf.FloorToInt(m_percentages[rarity - 1] * 100f);
		}

		public void SetPercentage(int index, float percentage)
		{
			if (m_percentages.IsIndexValid(index))
			{
				m_percentages[index] = percentage;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < m_percentages.Length; i++)
			{
				stringBuilder.Append(i);
				stringBuilder.Append(":");
				stringBuilder.Append(m_percentages[i]);
				stringBuilder.Append(" ; ");
			}
			return stringBuilder.ToString();
		}
	}
}
