using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.ControllerAnchors
{
	public class ControllerAnchorsSpec
	{
		public class ControllerSpec
		{
			public Vector3 sphereOffset;

			public Vector3 sphereRotation;

			public Vector3 handOffset;

			public Vector3 handRotation;
		}

		public string jsonFilePath;

		private JObject loadedObj;

		private bool wasLoadAttempted;

		public const int DATA_VERSION = 3;

		private const string VERSION_KEY = "DataVersion";

		internal readonly Dictionary<string, ControllerSpec> mapping = new Dictionary<string, ControllerSpec>
		{
			{
				"SteamVR/ViveWand",
				new ControllerSpec
				{
					handOffset = new Vector3(4.5854f, 7.7017f, -15.8089f),
					handRotation = new Vector3(27.1808f, 173.1347f, 102.2739f)
				}
			},
			{
				"SteamVR/ValveIndex",
				new ControllerSpec
				{
					handOffset = new Vector3(4.7513f, 8.6143f, -15.0199f),
					handRotation = new Vector3(20.9395f, 179.5371f, 108.8092f)
				}
			},
			{
				"SteamVR/RiftTouch",
				new ControllerSpec
				{
					handOffset = new Vector3(5.1182f, 6.711f, -17.3367f),
					handRotation = new Vector3(27.5159f, 182.204f, 112.1978f)
				}
			},
			{
				"SteamVR/QuestTouch",
				new ControllerSpec
				{
					handOffset = new Vector3(4.2256f, 7.178f, -15.4573f),
					handRotation = new Vector3(23.6809f, 170.4807f, 104.8619f)
				}
			},
			{
				"SteamVR/WMR",
				new ControllerSpec
				{
					handOffset = new Vector3(4.0835f, 5.5223f, -18.1055f),
					handRotation = new Vector3(38.7443f, 177.4983f, 106.4427f)
				}
			},
			{
				"SteamVR/Cosmos",
				new ControllerSpec
				{
					handOffset = new Vector3(4.2256f, 7.178f, -15.4573f),
					handRotation = new Vector3(23.6809f, 170.4807f, 104.8619f)
				}
			},
			{
				"SteamVR/HPReverbG2",
				new ControllerSpec
				{
					handOffset = new Vector3(2.4732f, 8.2141f, -18.3424f),
					handRotation = new Vector3(28.5922f, 177.1868f, 96.7126f)
				}
			},
			{
				"Oculus/RiftTouch",
				new ControllerSpec
				{
					handOffset = new Vector3(5.7124f, -0.8759f, -12.0035f),
					handRotation = new Vector3(62.2198f, 157.8546f, 85.9333f)
				}
			},
			{
				"Oculus/QuestTouch",
				new ControllerSpec
				{
					handOffset = new Vector3(5.7124f, -0.8759f, -12.0035f),
					handRotation = new Vector3(62.2198f, 157.8546f, 85.9333f)
				}
			}
		};

		public void Set(string sdk, string controllerType, string anchor, Vector3 value)
		{
			if (!wasLoadAttempted)
			{
				Load();
			}
			if (loadedObj != null)
			{
				if (loadedObj[sdk + "/" + controllerType] == null)
				{
					loadedObj[sdk + "/" + controllerType] = new JObject();
				}
				loadedObj[sdk + "/" + controllerType][anchor] = JToken.Parse(JsonUtility.ToJson(value));
			}
		}

		public Vector3 Get(string sdk, string controllerType, string anchor)
		{
			if (!wasLoadAttempted)
			{
				Load();
			}
			if (loadedObj == null)
			{
				return GetDefault(sdk, controllerType, anchor);
			}
			JToken jToken = loadedObj[sdk + "/" + controllerType]?[anchor];
			if (jToken == null)
			{
				Log("Data for '" + sdk + "/" + controllerType + "/" + anchor + "' not found in JSON file, returning default");
				Vector3 vector = GetDefault(sdk, controllerType, anchor);
				Set(sdk, controllerType, anchor, vector);
				Save();
				return vector;
			}
			try
			{
				return jToken.ToObject<Vector3>();
			}
			catch (Exception ex)
			{
				if (ex is ArgumentNullException || ex is InvalidCastException)
				{
					LogError("Malformed vector '" + sdk + "/" + controllerType + "/" + anchor + "' in JSON file '" + jsonFilePath + "', returning default value");
				}
				else
				{
					LogError("Unexpected exception when parsing vector '" + sdk + "/" + controllerType + "/" + anchor + "' in JSON file '{jsonFilePath}', returning default value, original exception is below");
					Debug.LogException(ex);
				}
				return GetDefault(sdk, controllerType, anchor);
			}
		}

		public Vector3 GetDefault(string sdk, string controllerType, string anchorFieldName)
		{
			if (mapping.TryGetValue(sdk + "/" + controllerType, out var value))
			{
				FieldInfo field = value.GetType().GetField(anchorFieldName);
				if (field != null)
				{
					return (Vector3)field.GetValue(value);
				}
			}
			else if (mapping.TryGetValue("SteamVR/QuestTouch", out value))
			{
				FieldInfo field2 = value.GetType().GetField(anchorFieldName);
				if (field2 != null)
				{
					return (Vector3)field2.GetValue(value);
				}
				Log("Couldn't get default value for '" + sdk + "/" + controllerType + "/" + anchorFieldName + "' field, returning QuestTouch values");
			}
			Log("Couldn't get default value for '" + sdk + "/" + controllerType + "/" + anchorFieldName + "' field, returning zero vector");
			return Vector3.zero;
		}

		public void LoadDefaults()
		{
			loadedObj = new JObject();
			foreach (KeyValuePair<string, JToken> item in JObject.FromObject(mapping))
			{
				loadedObj[item.Key] = item.Value.DeepClone();
			}
		}

		public void Load()
		{
			wasLoadAttempted = true;
			loadedObj = null;
			if (!File.Exists(jsonFilePath))
			{
				Log("File '" + jsonFilePath + "' doesn't exist");
				return;
			}
			try
			{
				string json = File.ReadAllText(jsonFilePath);
				try
				{
					loadedObj = JObject.Parse(json);
					int num = 1;
					if (loadedObj["DataVersion"] != null)
					{
						num = loadedObj["DataVersion"].Value<int>();
					}
					int num2 = num;
					if (num < 2)
					{
						foreach (KeyValuePair<string, JToken> item in JObject.FromObject(mapping))
						{
							loadedObj[item.Key] = item.Value.DeepClone();
						}
						num = 2;
					}
					if (num == 2)
					{
						loadedObj["SteamVR/ViveWand"] = JObject.FromObject(mapping["SteamVR/ViveWand"]);
						num = 3;
					}
					if (num2 != num)
					{
						Save();
						Debug.Log($"Performed VR controller anchor data upgrade from version {num2} to version {num} at {jsonFilePath}.");
					}
				}
				catch (JsonReaderException exception)
				{
					LogError("Couldn't parse JSON file '" + jsonFilePath + "', original exception is below");
					Debug.LogException(exception);
				}
			}
			catch (IOException exception2)
			{
				LogError("Couldn't read JSON file '" + jsonFilePath + "', original exception is below");
				Debug.LogException(exception2);
			}
		}

		public void Save()
		{
			try
			{
				loadedObj["DataVersion"] = 3;
				File.WriteAllText(jsonFilePath, loadedObj.ToString(Formatting.Indented));
			}
			catch (Exception ex)
			{
				Debug.LogError("Failed to save controller anchor data: " + ex.Message);
				Debug.LogException(ex);
			}
		}

		private static void Log(string msg)
		{
			Debug.Log("[ControllerAnchors] " + msg);
		}

		private static void LogError(string msg)
		{
			Debug.LogError("[ControllerAnchors] " + msg);
		}
	}
}
