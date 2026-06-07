using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public class ScoreConsequence
	{
		[SerializeField]
		private int m_scoreDifference = 10;

		[SerializeField]
		private Calculation m_calculation;

		public float GetComputedValue(float initValue)
		{
			float addedValue = (float)Mathf.RoundToInt((World.ScoreManager.CurrentScore - ScoreSettings.BaseScore) / m_scoreDifference) * m_calculation.Value;
			return m_calculation.ComputeValue(initValue, addedValue);
		}
	}
}
