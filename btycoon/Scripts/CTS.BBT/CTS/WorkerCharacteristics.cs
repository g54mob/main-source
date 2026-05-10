using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.Pool;

namespace CTS
{
	[RequireComponent(typeof(Worker))]
	public class WorkerCharacteristics : CTSBehaviour
	{
		private static WorkerCharacteristicsData _statsParameter;

		private static WorkerLevelsData _workerLevelsData;

		[SerializeField]
		[Inject(false)]
		private AgentStatistics _agentStatistics;

		public static WorkerCharacteristicsData Data
		{
			get
			{
				if (_statsParameter == null)
				{
					_statsParameter = Resources.LoadAll<WorkerCharacteristicsData>("Scriptables\\WorkerConfigs")[0];
				}
				return _statsParameter;
			}
		}

		public static WorkerLevelsData WorkerLevelsData
		{
			get
			{
				if (_workerLevelsData == null)
				{
					_workerLevelsData = Resources.LoadAll<WorkerLevelsData>("Scriptables\\WorkerConfigs")[0];
				}
				return _workerLevelsData;
			}
		}

		public NumericStatistic Speed => _agentStatistics.GetNumericStatistic(EAgentStatistics.Speed);

		public NumericStatistic Intellect => _agentStatistics.GetNumericStatistic(EAgentStatistics.Intellect);

		public NumericStatistic Charisma => _agentStatistics.GetNumericStatistic(EAgentStatistics.Charisma);

		public int SpeedValue => _agentStatistics.GetStatisticIntValue(EAgentStatistics.Speed);

		public int IntelligenceValue => _agentStatistics.GetStatisticIntValue(EAgentStatistics.Intellect);

		public int CharismaValue => _agentStatistics.GetStatisticIntValue(EAgentStatistics.Charisma);

		public EWorkerType WorkerType { get; private set; }

		public bool IsGeneralist => WorkerType == EWorkerType.Generalist;

		public bool IsSpecialized => WorkerType == EWorkerType.Specialist;

		public EAgentStatistics SpecializedStat { get; private set; }

		public int StatisticValue(EAgentStatistics statistic)
		{
			return _agentStatistics.GetStatisticIntValue(statistic);
		}

		public void DrawWorkerType()
		{
			WorkerType = Data.WorkerTypesWeights.DrawWeightedRandom();
			if (WorkerType == EWorkerType.Specialist)
			{
				SpecializedStat = Data.SpecializedStatWeights.DrawWeightedRandom();
			}
		}

		public void Initialization()
		{
			DrawWorkerType();
			List<EAgentStatistics> list = new List<EAgentStatistics>();
			list.AddRange(Data.CharacteristicsStatistics);
			if (!WorkerLevelsData.GetLevelCharacteristicsMaximum(1, out var characteristicMaximum))
			{
				return;
			}
			foreach (EAgentStatistics item in list)
			{
				_agentStatistics.SetStatisticValue(item, Mathf.Min(Data.BaseCharacteristicsValue, characteristicMaximum));
			}
			switch (WorkerType)
			{
			case EWorkerType.Generalist:
				CharacteristicsGains(list, Data.GeneralistLevel1PointsToDistribute.RandomInRangeInclusive(), Data.GeneralistLevelUpGainRange, characteristicMaximum);
				break;
			case EWorkerType.Specialist:
				_agentStatistics.SetStatisticValue(SpecializedStat, characteristicMaximum);
				list.Remove(SpecializedStat);
				CharacteristicsGains(list, Data.SpecialistLevel1PointsToDistribute.RandomInRangeInclusive(), Data.SpecialistLevelUpGainRange, characteristicMaximum);
				break;
			}
		}

		public void CharacteristicsLevelUp()
		{
			List<EAgentStatistics> list = new List<EAgentStatistics>();
			list.AddRange(Data.CharacteristicsStatistics);
			if (WorkerLevelsData.GetLevelCharacteristicsMaximum(StatisticValue(EAgentStatistics.Level), out var characteristicMaximum))
			{
				switch (WorkerType)
				{
				case EWorkerType.Generalist:
					CharacteristicsGains(list, Data.GeneralistLevelUpPointsToDistribute.RandomInRangeInclusive(), Data.GeneralistLevelUpGainRange, characteristicMaximum);
					break;
				case EWorkerType.Specialist:
					_agentStatistics.SetStatisticValue(SpecializedStat, characteristicMaximum);
					list.Remove(SpecializedStat);
					CharacteristicsGains(list, Data.SpecialistLevelUpPointsToDistribute.RandomInRangeInclusive(), Data.GeneralistLevelUpGainRange, characteristicMaximum);
					break;
				}
			}
		}

		private void CharacteristicsGains(List<EAgentStatistics> characteristics, int pointsToDistribute, Vector2Int minMaxGain, int maxCharacteristicValue)
		{
			CharacteristicsGains(characteristics, pointsToDistribute, minMaxGain.x, minMaxGain.y, maxCharacteristicValue);
		}

		private void CharacteristicsGains(List<EAgentStatistics> characteristics, int pointsToDistribute, int minGain, int maxGain, int maxCharacteristicValue)
		{
			for (int num = characteristics.Count - 1; num >= 0; num--)
			{
				if (StatisticValue(characteristics[num]) >= maxCharacteristicValue)
				{
					characteristics.RemoveAt(num);
				}
			}
			Dictionary<EAgentStatistics, int> gains = new Dictionary<EAgentStatistics, int>();
			foreach (EAgentStatistics characteristic in characteristics)
			{
				gains.Add(characteristic, 0);
			}
			List<EAgentStatistics> list = CollectionPool<List<EAgentStatistics>, EAgentStatistics>.Get();
			list.AddRange(characteristics);
			foreach (EAgentStatistics item in list)
			{
				AddCharacteristicGain(item, minGain);
			}
			CollectionPool<List<EAgentStatistics>, EAgentStatistics>.Release(list);
			while (pointsToDistribute > 0 && characteristics.Count != 0)
			{
				AddCharacteristicGain(characteristics.GetRandom(), 1);
			}
			foreach (KeyValuePair<EAgentStatistics, int> item2 in gains)
			{
				_agentStatistics.AddToStatistic(item2.Key, item2.Value);
			}
			void AddCharacteristicGain(EAgentStatistics statistic, int gain)
			{
				if (gains.ContainsKey(statistic))
				{
					gains[statistic] += gain;
					pointsToDistribute -= gain;
					if (gains[statistic] >= maxGain || gains[statistic] + StatisticValue(statistic) >= maxCharacteristicValue)
					{
						characteristics.Remove(statistic);
					}
				}
			}
		}
	}
}
