using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SimulationScripts;

namespace SettingScripts
{
	[Serializable]
	public class TargetZoneSetting : SimulationSetting<ZoneSettings>, ISaveable
	{
		[NonSerialized]
		public int targetID = -1;

		[NonSerialized]
		public string labelForNoTarget;

		public Zone zone => ZoneManager.instance.zones.FirstOrDefault((Zone z) => z.settings == val);

		public JObject SaveState()
		{
			return (JObject)(JToken)val.zoneID;
		}

		public void LoadState(JObject state)
		{
			targetID = state.ToObject<int>();
		}

		public void RebindToTarget()
		{
			if (targetID >= 0)
			{
				SetValue(ScenarioSettings.Instance.zones.FirstOrDefault((ZoneSettings z) => z.zoneID == targetID));
			}
		}

		public TargetZoneSetting(string labelOnNoTarget = "None")
		{
			labelForNoTarget = labelOnNoTarget;
			DefaultValue = null;
			SetValue(null);
		}
	}
}
