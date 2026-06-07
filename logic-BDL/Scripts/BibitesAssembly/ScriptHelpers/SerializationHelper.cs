using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using SettingScripts;
using SimulationScripts;
using UIScripts.UIReferences;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace ScriptHelpers
{
	public static class SerializationHelper
	{
		public static bool loadingSettings = false;

		public static UnityEvent settingsLoadingDone = new UnityEvent();

		public static JToken SerializeObject(object obj)
		{
			if (obj is ISaveable saveable)
			{
				return saveable.SaveState();
			}
			if (obj is ICollection collection)
			{
				return SerializeCollection(collection);
			}
			return SerializeGeneralObject(obj);
		}

		public static JToken SerializeCollection(ICollection collection)
		{
			JArray jArray = new JArray();
			foreach (object item in collection)
			{
				if (item is ISaveable saveable)
				{
					jArray.Add(saveable.SaveState());
				}
				else if (item is ISaveableArray saveableArray)
				{
					jArray.Add(saveableArray.SaveState());
				}
				else
				{
					jArray.Add(JToken.FromObject(item));
				}
			}
			return jArray;
		}

		public static JObject SerializeGeneralObject(object obj, JObject jObj = null)
		{
			if (jObj == null)
			{
				jObj = new JObject();
			}
			foreach (FieldInfo item in from field in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				where field.IsDefined(typeof(SerializeField), inherit: false)
				select field)
			{
				object value = item.GetValue(obj);
				if (value != null)
				{
					if (item.FieldType.Name == "String" || item.FieldType.IsPrimitive)
					{
						jObj[item.Name] = JToken.FromObject(value);
					}
					else if (item.FieldType.IsEnum)
					{
						jObj[item.Name] = value.ToString();
					}
					else
					{
						jObj[item.Name] = SerializeObject(value);
					}
				}
			}
			return jObj;
		}

		public static void DeserializeObject(object obj, JToken state)
		{
			if (state.HasValues)
			{
				if (obj is ISaveable saveable)
				{
					saveable.LoadState((JObject)state);
				}
				else if (obj is ICollection)
				{
					obj = state.ToObject(obj.GetType());
				}
				else
				{
					DeserializeGeneralObject(obj, state);
				}
			}
		}

		public static void DeserializeGeneralObject(object obj, JToken state)
		{
			foreach (KeyValuePair<string, JToken> item in (JObject)state)
			{
				FieldInfo field = obj.GetType().GetField(item.Key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field == null || !field.IsDefined(typeof(SerializeField), inherit: false))
				{
					continue;
				}
				if (field.FieldType.Name == "String" || field.FieldType.IsPrimitive)
				{
					field.SetValue(obj, item.Value.ToObject(field.FieldType));
					continue;
				}
				if (field.FieldType.IsEnum)
				{
					field.SetValue(obj, Enum.Parse(field.FieldType, item.Value.ToString()));
					continue;
				}
				object value = field.GetValue(obj);
				if (value != null)
				{
					DeserializeObject(value, item.Value);
				}
				else
				{
					field.SetValue(obj, item.Value.ToObject(field.FieldType));
				}
			}
		}

		public static void DeserializeISavableCollection<T>(ICollection<T> obj, JArray state) where T : ISaveable, new()
		{
			obj.Clear();
			foreach (JToken item2 in state)
			{
				T item = new T();
				item.LoadState((JObject)item2);
				obj.Add(item);
			}
		}

		public static void DeserializeCollection<T>(IList<T> obj, JArray state)
		{
			if (typeof(ISaveable).IsAssignableFrom(typeof(T)))
			{
				foreach (JToken item in state)
				{
					ISaveable saveable = (ISaveable)Activator.CreateInstance(typeof(T));
					saveable.LoadState((JObject)item);
					obj.Add((T)saveable);
				}
				return;
			}
			if (typeof(ISaveableArray).IsAssignableFrom(typeof(T)))
			{
				for (int i = 0; i < state.Count; i++)
				{
					ISaveableArray saveableArray = (ISaveableArray)Activator.CreateInstance(typeof(T));
					saveableArray.LoadState((JArray)state[i]);
					obj[i] = (T)saveableArray;
				}
				return;
			}
			foreach (JToken item2 in state)
			{
				obj.Add(item2.ToObject<T>());
			}
		}

		public static JObject SerializeRigidBody2D(Rigidbody2D rb)
		{
			return new JObject
			{
				["px"] = rb.position.x,
				["py"] = rb.position.y,
				["vx"] = rb.linearVelocity.x,
				["vy"] = rb.linearVelocity.y,
				["r"] = rb.rotation
			};
		}

		public static void DeserializeRigidBody2D(Rigidbody2D rb, JObject obj)
		{
			rb.position = new Vector2((float)obj["px"], (float)obj["py"]);
			rb.linearVelocity = new Vector2((float)obj["vx"], (float)obj["vy"]);
			rb.rotation = (float)obj["r"];
		}

		public static void SerializePosition(JObject store, GameObject obj)
		{
			store["transform"] = JObject.FromObject(new SerializedTransform(obj.transform));
			Rigidbody2D component = obj.GetComponent<Rigidbody2D>();
			if (component != null)
			{
				store["rb2d"] = SerializeRigidBody2D(component);
			}
		}

		public static void DeserializePosition(JObject store, GameObject obj, DialogGroupHandle problemsList = null)
		{
			SerializedTransform serializedTransform;
			try
			{
				serializedTransform = store["transform"].ToObject<SerializedTransform>();
			}
			catch
			{
				try
				{
					serializedTransform = store["transform"].ToObject<OldSerializedTransform>().ToNew();
				}
				catch
				{
					problemsList?.Add(PopupManager.DisplayDialog("Load System", "The transform component was not in an correct format."));
					return;
				}
			}
			serializedTransform.DeserializeTransform(obj.transform);
			Rigidbody2D component = obj.GetComponent<Rigidbody2D>();
			if (component != null && store["rb2d"] != null)
			{
				DeserializeRigidBody2D(component, (JObject)store["rb2d"]);
			}
		}

		public static Vector3 DeserializePos(JObject state)
		{
			float[] position = state["transform"].ToObject<SerializedTransform>().position;
			return new Vector3(position[0], position[1], 0f);
		}

		public static JObject SerializeSettings()
		{
			string json = JsonUtility.ToJson(ScenarioIndependentSettings.Instance);
			JObject jObject = SerializeScenarioSettingsCommon();
			JArray jArray = new JArray();
			foreach (ZoneGroupSettings zoneGroup in ScenarioSettings.Instance.zoneGroups)
			{
				jArray.Add(zoneGroup.SaveStateWithZones());
			}
			jObject["zoneGroups"] = jArray;
			jObject["independents"] = JObject.Parse(json);
			return jObject;
		}

		public static JObject SerializeScenario(bool saveRecommendations = false)
		{
			JObject jObject = SerializeScenarioSettingsCommon();
			jObject["zoneGroups"] = SerializeObject(ScenarioSettings.Instance.zoneGroups);
			if (saveRecommendations)
			{
				string json = JsonUtility.ToJson(ScenarioIndependentSettings.Instance);
				jObject["recommended"] = JObject.Parse(json);
			}
			return jObject;
		}

		public static JObject SerializeScenarioSettingsCommon()
		{
			JObject jObject = JObject.Parse(JsonUtility.ToJson(ScenarioSettings.Instance));
			jObject["materials"] = SerializeObject(MatterMaterialManager.Instance);
			jObject["zones"] = SerializeObject(ScenarioSettings.Instance.zones);
			jObject["bibites"] = SerializeObject(ScenarioSettings.Instance.bibites);
			jObject["settingsChangers"] = SerializeObject(ScenarioSettings.Instance.settingsChangers);
			if (ScenarioSettings.Instance.challengeParameters != null)
			{
				jObject["challenge"] = ScenarioSettings.Instance.challengeParameters.SaveState();
			}
			return jObject;
		}

		public static void DeserializeSettings(JObject settingsJSON, Utility.Version version)
		{
			loadingSettings = true;
			ScenarioIndependentSettings instance = ScenarioIndependentSettings.Instance;
			JToken jToken = settingsJSON["independents"] ?? settingsJSON;
			JsonUtility.FromJsonOverwrite(jToken.ToString(), instance);
			foreach (KeyValuePair<string, JToken> item in (JObject)jToken)
			{
				FieldInfo field = typeof(ScenarioIndependentSettings).GetField(item.Key);
				if (!(field == null))
				{
					(field.GetValue(instance) as IForceUpdateSetting)?.ForceUpdate();
				}
			}
			if (version < new Utility.Version(0, 5, 0, 6) && jToken["plantGrowth"] != null)
			{
				ScenarioIndependentSettings.Instance.pelletGrowth.SetValue(float.Parse(jToken["plantGrowth"]["Value"].ToString()));
			}
			DeserializeScenario(settingsJSON, version);
			loadingSettings = false;
		}

		public static void DeserializeScenario(JObject scenarioJson, Utility.Version version, bool checkForModifiers = false)
		{
			loadingSettings = true;
			ScenarioSettings instance = ScenarioSettings.Instance;
			JsonUtility.FromJsonOverwrite(scenarioJson.ToString(), instance);
			FieldInfo[] fields = typeof(ScenarioSettings).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.GetValue(instance) is IForceUpdateSetting forceUpdateSetting)
				{
					if (scenarioJson[fieldInfo.Name] == null)
					{
						forceUpdateSetting.ResetValue();
					}
					else
					{
						forceUpdateSetting.ForceUpdate();
					}
				}
			}
			JToken jToken = scenarioJson["recommended"];
			if (checkForModifiers && jToken != null && jToken.HasValues)
			{
				ScenarioIndependentSettings instance2 = ScenarioIndependentSettings.Instance;
				JsonUtility.FromJsonOverwrite(jToken.ToString(), instance2);
				fields = typeof(ScenarioIndependentSettings).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo2 in fields)
				{
					if (fieldInfo2.GetValue(instance2) is IForceUpdateSetting forceUpdateSetting2)
					{
						if (jToken[fieldInfo2.Name] == null)
						{
							forceUpdateSetting2.ResetValue();
						}
						else
						{
							forceUpdateSetting2.ForceUpdate();
						}
					}
				}
			}
			MatterMaterialManager.ResetAllMaterials();
			if (scenarioJson["materials"] != null)
			{
				DeserializeObject(MatterMaterialManager.Instance, scenarioJson["materials"]);
				if (version < new Utility.Version(0, 6, 0, 16))
				{
					FloatSetting reactivity = MatterMaterialManager.SettingsOfMaterial(MatterMaterialManager.Fat).reactivity;
					float val = reactivity.val;
					foreach (MatterMaterialSettings materialSetting in MatterMaterialManager.MaterialSettings)
					{
						materialSetting.reactivity.val = materialSetting.reactivity.val / 30f;
						materialSetting.UpdateMaterial();
					}
					reactivity.SetValue(Mathf.Sqrt(val) * MathF.PI);
				}
			}
			if (scenarioJson["challenge"] != null)
			{
				instance.challengeParameters = new ChallengeParameters();
				instance.challengeParameters.LoadState((JObject)scenarioJson["challenge"]);
			}
			else
			{
				instance.challengeParameters = null;
			}
			if (version < new Utility.Version(0, 6, 0, 9))
			{
				FloatSetting maxEfficiency = MatterMaterialManager.FatParameters.maxEfficiency;
				FloatSetting minEfficiency = MatterMaterialManager.FatParameters.minEfficiency;
				if (maxEfficiency.val > maxEfficiency.maxValue)
				{
					maxEfficiency.SetValue(maxEfficiency.val / 100f);
				}
				if (minEfficiency.val > minEfficiency.maxValue)
				{
					minEfficiency.SetValue(minEfficiency.val / 100f);
				}
			}
			if (version < new Utility.Version(0, 6, 0, 13))
			{
				ScenarioSettings.Instance.neuronDefaultChance.ResetValue();
				ScenarioSettings.Instance.neuronMutationChance.ResetValue();
			}
			ScenarioSettings.Instance.zones.Clear();
			if (scenarioJson["zones"] != null && ((JArray)scenarioJson["zones"]).HasValues)
			{
				ZoneSettings.maxID = 0;
				List<ZoneSettings> list = new List<ZoneSettings>();
				DeserializeISavableCollection(list, (JArray)scenarioJson["zones"]);
				if (version < new Utility.Version(0, 6, 0, 6))
				{
					foreach (JToken zoneJson in (IEnumerable<JToken>)scenarioJson["zones"])
					{
						ZoneSettings zoneSettings = list.FirstOrDefault((ZoneSettings z) => z.zoneName.val == zoneJson["name"].ToString());
						if (zoneSettings != null)
						{
							zoneSettings.fertility.SetValue(Mathf.Pow(10f, zoneJson["fertility"].ToObject<float>()));
							zoneSettings.biomassDensity.SetValue(Mathf.Pow(10f, zoneJson["fertility"].ToObject<float>()));
							zoneSettings.pelletSize.SetValue(Mathf.Pow(10f, zoneJson["pelletSize"].ToObject<float>()));
							zoneSettings.speed.SetValue(Mathf.Pow(10f, zoneJson["speed"].ToObject<float>()));
						}
					}
					float num = 4f * ScenarioIndependentSettings.Instance.SimulationSize.val * ScenarioIndependentSettings.Instance.SimulationSize.val;
					float num2 = list.Sum((ZoneSettings z) => z.biomassDensity.val * z.area);
					float a = float.PositiveInfinity;
					float num3 = float.NegativeInfinity;
					foreach (ZoneSettings item in list)
					{
						float num4 = num * item.biomassDensity.val / num2;
						a = Mathf.Min(a, num4);
						num3 = Mathf.Max(num3, num4);
						item.fertility.SetValue(num4);
						item.biomassDensity.SetValue(num4);
					}
					if (10f * num3 > list[0].fertility.maxValue)
					{
						float num5 = 10f * (num3 / list[0].fertility.maxValue);
						ScenarioIndependentSettings.Instance.biomassDensity.SetValue(ScenarioIndependentSettings.Instance.biomassDensity.val * num5);
						ScenarioIndependentSettings.Instance.pelletGrowth.SetValue(ScenarioIndependentSettings.Instance.pelletGrowth.val * num5);
						foreach (ZoneSettings item2 in list)
						{
							item2.fertility.SetValue(item2.fertility.val / num5);
							item2.biomassDensity.SetValue(item2.biomassDensity.val / num5);
						}
					}
				}
				ScenarioSettings.Instance.zones = list;
			}
			ScenarioSettings.Instance.zoneGroups.Clear();
			if (scenarioJson["zoneGroups"] != null)
			{
				DeserializeISavableCollection(ScenarioSettings.Instance.zoneGroups, (JArray)scenarioJson["zoneGroups"]);
				foreach (ZoneGroupSettings zoneGroup in ScenarioSettings.Instance.zoneGroups)
				{
					if (zoneGroup.zones.Count < 1)
					{
						zoneGroup.GenerateZones();
					}
				}
			}
			ScenarioSettings.Instance.UpdateAllZonesList();
			ScenarioSettings.Instance.bibites.Clear();
			if (scenarioJson["bibites"] != null && scenarioJson["bibites"].HasValues)
			{
				DeserializeISavableCollection(ScenarioSettings.Instance.bibites, (JArray)scenarioJson["bibites"]);
			}
			if (version < new Utility.Version(0, 6, 0, 7))
			{
				if (scenarioJson["bibiteMassDensity"] != null)
				{
					ScenarioSettings.Instance.bibiteMassDensity.SetValue(ScenarioSettings.Instance.bibiteMassDensity.val / 1.9f);
				}
				if (scenarioJson["pelletGrowth"] != null)
				{
					ScenarioIndependentSettings.Instance.pelletGrowth.SetValue(ScenarioIndependentSettings.Instance.pelletGrowth.val * 0.7f);
				}
				if (scenarioJson["pelletEnergy"] != null)
				{
					ScenarioSettings.Instance.pelletEnergy.SetValue(ScenarioSettings.Instance.pelletEnergy.val * 1.5f);
				}
			}
			if (version < new Utility.Version(0, 6, 0, 17) && ScenarioSettings.Instance.bitePeriodFactor.val > 10f)
			{
				ScenarioSettings.Instance.bitePeriodFactor.SetValue(ScenarioSettings.Instance.bitePeriodFactor.val / 35f);
			}
			ScenarioSettings.Instance.settingsChangers.Clear();
			if (scenarioJson["settingsChangers"] != null && ((JArray)scenarioJson["settingsChangers"]).HasValues)
			{
				DeserializeISavableCollection(ScenarioSettings.Instance.settingsChangers, (JArray)scenarioJson["settingsChangers"]);
			}
			ScenarioSettings.Instance.RebindListeners();
			settingsLoadingDone.Invoke();
			loadingSettings = false;
		}
	}
}
