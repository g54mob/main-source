using System;
using UnityEngine;

namespace DistantLands.Cozy
{
	public class SystemTimeModule : CozyTimeModule
	{
		public enum TimeGatherMode
		{
			Local = 0,
			UTC = 1
		}

		[MeridiemTime]
		[SerializeField]
		private float m_SystemTime = 0.5f;

		[SerializeField]
		[CozySearchable(new string[] { })]
		public bool pauseTime;

		[Tooltip("How many times should the COZY day complete per real world day.")]
		[CozySearchable(new string[] { })]
		public float timeMultiplier = 1f;

		[Tooltip("How many times should the COZY year complete per real world year.")]
		[CozySearchable(new string[] { })]
		public float dateMultiplier = 1f;

		[CozySearchable(new string[] { })]
		public TimeGatherMode timeGatherMode;

		[Tooltip("Adds an offset to the gathered time in hours.")]
		[CozySearchable(new string[] { })]
		public float hourOffset;

		public new float modifiedTimeSpeed => timeMultiplier / 86400f;

		internal override bool CheckIfModuleCanBeAdded(out string warning)
		{
			if (base.weatherSphere.moduleHolder.GetComponents<CozyTimeModule>().Length != 1)
			{
				warning = "Time Module";
				return false;
			}
			warning = "";
			return true;
		}

		public void Update()
		{
			if (base.weatherSphere.timeModule == null)
			{
				base.weatherSphere.timeModule = this;
			}
			if (!pauseTime)
			{
				if (timeGatherMode == TimeGatherMode.Local)
				{
					m_SystemTime = (hourOffset * 3600000f + (float)DateTime.Now.TimeOfDay.TotalMilliseconds) * timeMultiplier / 86400000f % 1f;
					yearPercentage = (float)DateTime.Now.DayOfYear / 365f * dateMultiplier % 1f;
				}
				else
				{
					m_SystemTime = (hourOffset * 3600000f + (float)DateTime.UtcNow.TimeOfDay.TotalMilliseconds) * timeMultiplier / 86400000f % 1f;
					yearPercentage = (float)DateTime.UtcNow.DayOfYear / 365f * dateMultiplier % 1f;
				}
				currentTime = m_SystemTime;
			}
		}
	}
}
