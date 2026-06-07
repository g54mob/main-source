using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Player/Sensor", Scope.Project)]
	public class PlayerSensorSettings : CustomSettings<PlayerSensorSettings>
	{
		[Header("Sensables")]
		[SerializeField]
		private float m_sensableMaxDistance = 5f;

		[SerializeField]
		private LayerMask m_sensableMask;

		[Header("Ground")]
		[SerializeField]
		private float m_groundMaxDistance = 10f;

		[SerializeField]
		private LayerMask m_groundMask;

		[SerializeField]
		private LayerMask m_wallsMask;

		[SerializeField]
		private LayerMask m_ceilingMask;

		public static float SensableMaxDistance => CustomSettings<PlayerSensorSettings>.I.m_sensableMaxDistance;

		public static int SensableMask => CustomSettings<PlayerSensorSettings>.I.m_sensableMask;

		public static float GroundMaxDistance => CustomSettings<PlayerSensorSettings>.I.m_groundMaxDistance;

		public static int GroundMask => CustomSettings<PlayerSensorSettings>.I.m_groundMask;

		public static int WallsMask => CustomSettings<PlayerSensorSettings>.I.m_wallsMask;

		public static int CeilingMask => CustomSettings<PlayerSensorSettings>.I.m_ceilingMask;
	}
}
