using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Shop/Dirt", Scope.Project)]
	public class DirtSettings : CustomSettings<DirtSettings>
	{
		[Header("Dirt Spawn")]
		[SerializeField]
		private EnumValues<DirtData.EType, float> m_dirtSpawnFromDirtRadius = new EnumValues<DirtData.EType, float>();

		[SerializeField]
		private EnumValues<DirtData.EType, int> m_maxDirtInShop = new EnumValues<DirtData.EType, int>();

		[SerializeField]
		private EnumValues<DirtData.EType, float> m_dirtSpawnTimerInSeconds = new EnumValues<DirtData.EType, float>();

		[SerializeField]
		private EnumValues<DirtData.EType, float> m_dirtSpawnCooldownInSeconds = new EnumValues<DirtData.EType, float>();

		[SerializeField]
		private EnumValues<DirtData.EType, float> m_dirtSpawnPercentage = new EnumValues<DirtData.EType, float>();

		[SerializeField]
		private LayerMask m_blockingLayerDirtSpawn;

		[Header("Broom Settings")]
		[SerializeField]
		private float m_broomUpAngle = 30f;

		[SerializeField]
		private float m_broomCleaningRate = 10f;

		[SerializeField]
		private float m_singleSwipeDuration = 0.29f;

		public static LayerMask BlockingLayerDirtSpawn => CustomSettings<DirtSettings>.I.m_blockingLayerDirtSpawn;

		public static float BroomUpAngle => CustomSettings<DirtSettings>.I.m_broomUpAngle;

		public static float BroomCleaningRate => CustomSettings<DirtSettings>.I.m_broomCleaningRate;

		public static float SingleSweepDuration => CustomSettings<DirtSettings>.I.m_singleSwipeDuration;

		public static float GetDirtSpawnFromDirtRadius(DirtData.EType type)
		{
			return CustomSettings<DirtSettings>.I.m_dirtSpawnFromDirtRadius[type];
		}

		public static int GetMaxDirtInShop(DirtData.EType type)
		{
			return CustomSettings<DirtSettings>.I.m_maxDirtInShop[type];
		}

		public static float GetDirtSpawnTimer(DirtData.EType type)
		{
			return CustomSettings<DirtSettings>.I.m_dirtSpawnTimerInSeconds[type];
		}

		public static float GetDirtSpawnCooldown(DirtData.EType type)
		{
			return CustomSettings<DirtSettings>.I.m_dirtSpawnCooldownInSeconds[type];
		}

		public static float GetDirtSpawnPercentage(DirtData.EType type)
		{
			return CustomSettings<DirtSettings>.I.m_dirtSpawnPercentage[type];
		}
	}
}
