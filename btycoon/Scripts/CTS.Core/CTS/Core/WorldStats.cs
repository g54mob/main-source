using UnityEngine;

namespace CTS.Core
{
	public class WorldStats : CTSSingleton<WorldStats>
	{
		[SerializeField]
		private Stats _stats;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public static void AddStatList(StatList list)
		{
			if (CTSSingleton<WorldStats>.InstanceExists())
			{
				CTSSingleton<WorldStats>.Instance._stats.AddStatList(list);
			}
		}

		public static float Get(StringKey key)
		{
			if (CTSSingleton<WorldStats>.InstanceExists())
			{
				return CTSSingleton<WorldStats>.Instance._stats.Get(key);
			}
			return 0f;
		}

		public static int GetRounded(StringKey key)
		{
			return Mathf.RoundToInt(Get(key));
		}

		public static int GetCeiled(StringKey key)
		{
			return Mathf.CeilToInt(Get(key));
		}

		public static int GetFloored(StringKey key)
		{
			return Mathf.FloorToInt(Get(key));
		}

		public static void ClearStatistics()
		{
			if (CTSSingleton<WorldStats>.InstanceExists())
			{
				CTSSingleton<WorldStats>.Instance._stats.ClearStatistics();
			}
		}
	}
}
