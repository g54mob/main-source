using UnityEngine;

namespace ScheduleOne.Weather
{
	public class SkyOverrideEnclosure : WorldEnclosure
	{
		[SerializeField]
		[Tooltip("Higher priority overrides will take precedence over lower ones")]
		[Header("Settings")]
		private int _priority;

		[SerializeField]
		private SkySettings _skySettings;

		public int Priority => 0;

		public SkySettings SkySettings => null;
	}
}
