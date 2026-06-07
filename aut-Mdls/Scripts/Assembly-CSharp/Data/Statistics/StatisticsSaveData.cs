using System;
using System.Collections.Generic;
using Data.SaveData;
using Data.Shapes;
using Newtonsoft.Json;

namespace Data.Statistics
{
	[Serializable]
	public class StatisticsSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public readonly Dictionary<int, ulong> ProducedStats = new Dictionary<int, ulong>();

		public readonly Dictionary<string, uint> ProducedShapesStats = new Dictionary<string, uint>();

		public readonly Dictionary<int, uint> DeliveredStats = new Dictionary<int, uint>();

		public readonly Dictionary<string, uint> DeliveredShapesStats = new Dictionary<string, uint>();

		public readonly Dictionary<int, uint> WithdrawnStats = new Dictionary<int, uint>();

		public readonly Dictionary<int, uint> PlacedStats = new Dictionary<int, uint>();

		public readonly Dictionary<BehaviourStatisticType, uint> BehaviourStats = new Dictionary<BehaviourStatisticType, uint>();

		public readonly Dictionary<XPEarnedSource, int> XPEarned = new Dictionary<XPEarnedSource, int>();

		public StatisticsSaveData(Dictionary<int, ulong> producedStats, Dictionary<RotationIndependentHash, uint> producedShapesStats, Dictionary<int, uint> deliveredStats, Dictionary<RotationIndependentHash, uint> deliveredShapesStats, Dictionary<int, uint> withdrawnStats, Dictionary<int, uint> placedStats, Dictionary<BehaviourStatisticType, uint> behaviourStats, Dictionary<XPEarnedSource, int> xpEarned)
			: base(0)
		{
			ProducedStats = producedStats;
			ProducedShapesStats = new Dictionary<string, uint>(producedShapesStats.Count);
			foreach (KeyValuePair<RotationIndependentHash, uint> producedShapesStat in producedShapesStats)
			{
				ProducedShapesStats.Add(producedShapesStat.Key.ToString(), producedShapesStat.Value);
			}
			DeliveredStats = deliveredStats;
			DeliveredShapesStats = new Dictionary<string, uint>(deliveredShapesStats.Count);
			foreach (KeyValuePair<RotationIndependentHash, uint> deliveredShapesStat in deliveredShapesStats)
			{
				DeliveredShapesStats.Add(deliveredShapesStat.Key.ToString(), deliveredShapesStat.Value);
			}
			WithdrawnStats = withdrawnStats;
			PlacedStats = placedStats;
			BehaviourStats = behaviourStats;
			XPEarned = xpEarned;
		}

		[JsonConstructor]
		public StatisticsSaveData(Dictionary<int, ulong> producedStats, Dictionary<string, uint> producedShapesStats, Dictionary<int, uint> deliveredStats, Dictionary<string, uint> deliveredShapesStats, Dictionary<int, uint> withdrawnStats, Dictionary<int, uint> placedStats, Dictionary<BehaviourStatisticType, uint> behaviourStats, Dictionary<XPEarnedSource, int> xpEarned)
			: base(0)
		{
			ProducedStats = producedStats;
			ProducedShapesStats = producedShapesStats;
			DeliveredStats = deliveredStats;
			DeliveredShapesStats = deliveredShapesStats;
			WithdrawnStats = withdrawnStats;
			PlacedStats = placedStats;
			BehaviourStats = behaviourStats;
			XPEarned = xpEarned;
		}
	}
}
