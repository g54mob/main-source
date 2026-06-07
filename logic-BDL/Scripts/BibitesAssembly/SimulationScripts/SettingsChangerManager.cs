using System;
using OneUseScripts;
using SettingScripts;
using UnityEngine;

namespace SimulationScripts
{
	public class SettingsChangerManager : MonoBehaviour
	{
		[NonSerialized]
		public double time;

		[NonSerialized]
		public float progress;

		[NonSerialized]
		public float period = 0.1f;

		private void Start()
		{
			if (ScenarioSettings.Instance.settingsChangers.Count < 1)
			{
				base.enabled = false;
			}
		}

		private void FixedUpdate()
		{
			time = TimeKeeper.simulatedTime;
			progress += Time.fixedDeltaTime;
			if (progress < period)
			{
				return;
			}
			progress -= period;
			bool flag = false;
			foreach (SettingsChanger settingsChanger in ScenarioSettings.Instance.settingsChangers)
			{
				settingsChanger.Update(time);
				flag |= settingsChanger.ended;
			}
			if (flag)
			{
				ScenarioSettings.Instance.settingsChangers.RemoveAll((SettingsChanger s) => s.ended);
			}
			if (ScenarioSettings.Instance.settingsChangers.Count < 1)
			{
				base.enabled = false;
			}
		}
	}
}
