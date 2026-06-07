using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using UnityEngine;
using UnityEngine.Events;

namespace SettingScripts
{
	public class ZoneGroupSettings : ISaveable
	{
		public ZoneSettings template;

		public List<ZoneSettings> zones = new List<ZoneSettings>();

		public static int groupCount = 1;

		public StringSimulationSetting groupName = new StringSimulationSetting
		{
			Name = "Name",
			val = $"Group {groupCount++}"
		};

		public BoolSetting scaleWithSim = new BoolSetting
		{
			Name = "Count scales with sim",
			val = false,
			DefaultValue = false,
			HelperText = "Is the number of random zones fixed or should it be proportional to the simulation area (bigger sim => more zones)?"
		};

		public IntSetting zoneCount = new IntSetting
		{
			Name = "Zones Count",
			HelperText = "How many Zones should be generated on startup?",
			minValue = 1,
			maxValue = 1000,
			DefaultValue = 10,
			val = 10
		};

		public FloatSetting zoneDensity = new FloatSetting
		{
			Name = "Zones Density",
			HelperText = "How many Zones should be generated on startup?",
			minValue = 0.01f,
			maxValue = 50f,
			DefaultValue = 0.66f,
			val = 0.66f,
			units = " z/ku²",
			precision = 2,
			SI = false
		};

		public UnityEvent onAnyChangeFromTemplate = new UnityEvent();

		public UnityEvent onTotalBiomassChange = new UnityEvent();

		public bool generatedZones => zones.Count > 0;

		public int count
		{
			get
			{
				if (!scaleWithSim.val)
				{
					return zoneCount.val;
				}
				return Mathf.CeilToInt(zoneDensity.val * ScenarioIndependentSettings.simArea / 1000000f);
			}
		}

		public ZoneGroupSettings()
		{
			template = ZoneSettings.DefaultTemplate();
			template.radiusRelative.SetValue(0.05f);
			template.onAnySettingChange.AddListener(onAnyChangeFromTemplate.Invoke);
			onAnyChangeFromTemplate.AddListener(onTotalBiomassChange.Invoke);
			onTotalBiomassChange.AddListener(ScenarioSettings.onZoneBiomassChange.Invoke);
			groupName.Subscribe(RenameZones);
			zoneCount.Subscribe(AlignCountTypes);
			zoneDensity.Subscribe(AlignCountTypes);
		}

		private void RenameZones(string val)
		{
			int i = 0;
			zones.ForEach(delegate(ZoneSettings z)
			{
				z.zoneName.SetValue($"{val}_{i++}");
			});
		}

		public void ApplyChangesToAllZones()
		{
			zones.ForEach(delegate(ZoneSettings z)
			{
				template.CopySettings(z, forceUpdate: true);
			});
		}

		public void ClearZones()
		{
			zones.ForEach(ScenarioSettings.onZoneFromGroupRemoved.Invoke);
			zones.Clear();
		}

		public void GenerateZones()
		{
			ClearZones();
			for (int i = 0; i < count; i++)
			{
				ZoneSettings zoneSettings = new ZoneSettings();
				template.CopySettings(zoneSettings);
				zoneSettings.zoneName.SetValue($"{groupName.val}_{i}");
				zoneSettings.SetRandomPositionInRange();
				zones.Add(zoneSettings);
				ScenarioSettings.onZoneFromGroupAdded.Invoke(zoneSettings);
			}
			ScenarioSettings.Instance.UpdateAllZonesList();
		}

		private void AlignCountTypes()
		{
			if (scaleWithSim.val)
			{
				zoneCount.val = count;
			}
			else
			{
				zoneDensity.val = (float)zoneCount.val / (ScenarioIndependentSettings.simArea / 1000000f);
			}
			onTotalBiomassChange.Invoke();
		}

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			jObject["name"] = groupName.val;
			jObject["scaleWithSim"] = scaleWithSim.val;
			if (scaleWithSim.val)
			{
				jObject["count"] = zoneDensity.val;
			}
			else
			{
				jObject["count"] = zoneCount.val;
			}
			AlignCountTypes();
			jObject["template"] = template.SaveState();
			return jObject;
		}

		public JObject SaveStateWithZones()
		{
			JObject jObject = SaveState();
			JArray jArray = new JArray();
			foreach (ZoneSettings zone in zones)
			{
				jArray.Add(zone.SaveState());
			}
			jObject["zones"] = jArray;
			return jObject;
		}

		public void LoadState(JObject state)
		{
			groupName.val = state["name"].ToString();
			scaleWithSim.val = state["scaleWithSim"].ToObject<bool>();
			if (scaleWithSim.val)
			{
				zoneDensity.val = state["count"].ToObject<float>();
			}
			else
			{
				zoneCount.val = state["count"].ToObject<int>();
			}
			template.LoadState((JObject)state["template"]);
			if (state["zones"] != null)
			{
				SerializationHelper.DeserializeISavableCollection(zones, (JArray)state["zones"]);
			}
		}
	}
}
