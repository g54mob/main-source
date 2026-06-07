using Dhs5.Utility.Settings;
using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("General/Day Cycle", Scope.Project)]
	public class DayCycleSettings : CustomSettings<DayCycleSettings>
	{
		[Header("Date & Time")]
		[SerializeField]
		private Date m_startDate;

		[SerializeField]
		private DayTime m_startDayTime;

		[SerializeField]
		private DayTime m_endDayTime;

		[Header("Lighting")]
		[SerializeField]
		private Gradient m_lightColorGradient;

		[SerializeField]
		private AnimationCurve m_lightIntensityCurve;

		[SerializeField]
		private float m_lightIntensityMultiplier;

		[SerializeField]
		private UpdateTimelineObject m_timeline;

		public static Date StartDate => CustomSettings<DayCycleSettings>.I.m_startDate;

		public static DayTime StartDayTime => CustomSettings<DayCycleSettings>.I.m_startDayTime;

		public static DayTime EndDayTime => CustomSettings<DayCycleSettings>.I.m_endDayTime;

		public static Gradient LightColorGradient => CustomSettings<DayCycleSettings>.I.m_lightColorGradient;

		public static AnimationCurve LightIntensityCurve => CustomSettings<DayCycleSettings>.I.m_lightIntensityCurve;

		public static float LightIntensityMultiplier => CustomSettings<DayCycleSettings>.I.m_lightIntensityMultiplier;

		public static bool TryGetUpdateTimeline(out UpdateTimelineObject updateTimeline)
		{
			updateTimeline = CustomSettings<DayCycleSettings>.I.m_timeline;
			return updateTimeline != null;
		}
	}
}
