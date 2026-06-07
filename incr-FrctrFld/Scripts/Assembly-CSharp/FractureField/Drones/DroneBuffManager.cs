using System.Collections.Generic;
using Reactivity;

namespace FractureField.Drones
{
	public class DroneBuffManager
	{
		private readonly Dictionary<DroneBuffSourceType, string> _sourceTypeCache;

		private bool _sourceCacheDirty;

		public Dictionary<BuffType, RList<DroneBuff>> ActiveBuffsForType { get; set; }

		public RTrigger CacheChanged { get; }

		public void Init()
		{
		}

		private void SetupActiveBuffsForType()
		{
		}

		public void OnDestroy()
		{
		}

		public void RefreshBuff(DroneBuff buff)
		{
		}

		public void RefreshMultipleBuffs(DroneBuff[] buffs)
		{
		}

		public float GetTotalMultiplier(BuffType type)
		{
			return 0f;
		}

		public bool HasAnyBuffForSourceType(DroneBuffSourceType sourceType)
		{
			return false;
		}

		public bool HasBuffFromDifferentSource(DroneBuffSourceType sourceType, string currentSource)
		{
			return false;
		}

		private void RebuildSourceCacheIfDirty()
		{
		}

		public void FixedTick()
		{
		}
	}
}
