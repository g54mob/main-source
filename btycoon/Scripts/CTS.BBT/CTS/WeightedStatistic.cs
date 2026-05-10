using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using UnityEngine;

namespace CTS
{
	public class WeightedStatistic<T> : StatisticBehaviour<T> where T : Enum
	{
		private Dictionary<NumericStatistic, float> _statisticsToUse = new Dictionary<NumericStatistic, float>();

		public WeightedStatistic(NumericStatistic statisticToAssign, StatisticsContainer<T> statisticsContainer, SerializableDictionary<T, float> statisticsToUse)
			: base(statisticToAssign, statisticsContainer)
		{
			foreach (KeyValuePair<T, float> item in statisticsToUse)
			{
				if (statisticsContainer.TryGetNumericStatistic(item.Key, out var numericStatistic))
				{
					_statisticsToUse.Add(numericStatistic, item.Value);
					numericStatistic.ValueChanged += UpdateStat;
				}
			}
			UpdateStat();
		}

		~WeightedStatistic()
		{
			foreach (KeyValuePair<NumericStatistic, float> item in _statisticsToUse)
			{
				item.Key.ValueChanged -= UpdateStat;
			}
		}

		protected override void AdditionLogic(float toAdd)
		{
			Debug.LogError("Happiness should not be changed directly.");
		}

		private void UpdateStat(float unused = 0f)
		{
			float num = 0f;
			foreach (KeyValuePair<NumericStatistic, float> item in _statisticsToUse)
			{
				num += item.Key.UnitInterval * item.Value;
			}
			num /= (float)_statisticsToUse.Count;
			base.AssignedStatistic.SetValueFromUnitInterval(num);
		}
	}
}
