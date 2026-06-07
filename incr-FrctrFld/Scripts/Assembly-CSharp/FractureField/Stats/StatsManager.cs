using System.Collections.Generic;
using FractureField.Rocks;
using FractureField.Tools;
using Reactivity;

namespace FractureField.Stats
{
	public class StatsManager : StatsManagerSaveData, ISaveData<StatsManager, StatsManagerSaveData>
	{
		private long _lastTimePlayedCheck;

		private long _lastSingleBombFrameCount;

		private long _lastBombsUsedFrameCount;

		private readonly Queue<long> _bombsUsedIn5Seconds;

		public int TimePlayedSeconds => 0;

		public RInt HitsWithoutMissing { get; }

		public RInt ConsecutiveCriticalHits { get; }

		public RInt RocksDestroyedBySingleBomb { get; }

		public RInt BombsUsedInLast5Seconds { get; }

		public RTrigger TransitionedThroughAllRockLayers { get; }

		public StatsManager Load()
		{
			return null;
		}

		public StatsManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		private void UpdateTimePlayed()
		{
		}

		private void OnAnyRockHit()
		{
		}

		private void OnRockMiss()
		{
		}

		private void OnBombUsed()
		{
		}

		private void OnUpgradePurchased()
		{
		}

		private void TrackRockLayerStat(Dictionary<RockLayerType, RFloat> dict, RockLayerType layerType, float value)
		{
		}

		private void TrackRockLayerStat(Dictionary<RockLayerType, RLong> dict, RockLayerType layerType, long value)
		{
		}

		public RFloat TryGetRockLayerStat(Dictionary<RockLayerType, RFloat> dict, RockLayerType layerType, float defaultValue = 0f)
		{
			return null;
		}

		public RLong TryGetRockLayerStat(Dictionary<RockLayerType, RLong> dict, RockLayerType layerType, long defaultValue = 0L)
		{
			return null;
		}

		private void TrackToolStat(Dictionary<ToolType, RLong> dict, ToolType toolType, long value)
		{
		}

		public RLong TryGetToolStat(Dictionary<ToolType, RLong> dict, ToolType toolType, long defaultValue = 0L)
		{
			return null;
		}

		public void RecordRockHits(List<RockLayerHitResult> results)
		{
		}
	}
}
