using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Stocks/Amount Data")]
	public class StockAmountData : ScriptableObject
	{
		[Serializable]
		public struct StepData
		{
			[Min(0f)]
			public int MinCount;

			[Min(0f)]
			public int MaxCount;
		}

		[field: SerializeField]
		public PercentageList<StepData> Steps { get; private set; }

		public int GetRandomAmount()
		{
			StepData weightedRandom = Steps.GetWeightedRandom();
			return UnityEngine.Random.Range(weightedRandom.MinCount, weightedRandom.MaxCount + 1);
		}
	}
}
