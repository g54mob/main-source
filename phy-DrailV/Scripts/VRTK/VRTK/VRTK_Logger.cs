using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace VRTK
{
	public class VRTK_Logger : MonoBehaviour
	{
		public enum LogLevels
		{
			Trace = 0,
			Debug = 1,
			Info = 2,
			Warn = 3,
			Error = 4,
			Fatal = 5,
			None = 6
		}

		public enum CommonMessageKeys
		{
			NOT_DEFINED = 0,
			REQUIRED_COMPONENT_MISSING_FROM_SCENE = 1,
			REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT = 2,
			REQUIRED_COMPONENT_MISSING_FROM_PARAMETER = 3,
			REQUIRED_COMPONENT_MISSING_NOT_INJECTED = 4,
			COULD_NOT_FIND_OBJECT_FOR_ACTION = 5,
			SDK_OBJECT_NOT_FOUND = 6,
			SDK_NOT_FOUND = 7,
			SDK_MANAGER_ERRORS = 8,
			SCRIPTING_DEFINE_SYMBOLS_ADDED = 9,
			SCRIPTING_DEFINE_SYMBOLS_REMOVED = 10,
			SCRIPTING_DEFINE_SYMBOLS_NOT_FOUND = 11
		}

		public static VRTK_Logger instance = null;

		public static Dictionary<CommonMessageKeys, string> commonMessages = new Dictionary<CommonMessageKeys, string>
		{
			{
				CommonMessageKeys.NOT_DEFINED,
				"`{0}` not defined{1}."
			},
			{
				CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_SCENE,
				"`{0}` requires the `{1}` component to be available in the scene{2}."
			},
			{
				CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT,
				"`{0}` requires the `{1}` component to be attached to {2} GameObject{3}."
			},
			{
				CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_PARAMETER,
				"`{0}` requires a `{1}` component to be specified as the `{2}` parameter{3}."
			},
			{
				CommonMessageKeys.REQUIRED_COMPONENT_MISSING_NOT_INJECTED,
				"`{0}` requires the `{1}` component. Either the `{2}` parameter is not set or no `{1}` component is attached to {3} GameObject{4}."
			},
			{
				CommonMessageKeys.COULD_NOT_FIND_OBJECT_FOR_ACTION,
				"The `{0}` could not automatically find {1} to {2}."
			},
			{
				CommonMessageKeys.SDK_OBJECT_NOT_FOUND,
				"No {0} could be found. Have you selected a valid {1} in the SDK Manager? If you are unsure, then click the GameObject with the `VRTK_SDKManager` script attached to it in Edit Mode and select a {1} from the dropdown."
			},
			{
				CommonMessageKeys.SDK_NOT_FOUND,
				"The SDK '{0}' doesn't exist anymore. The fallback SDK '{1}' will be used instead."
			},
			{
				CommonMessageKeys.SDK_MANAGER_ERRORS,
				"The current SDK Manager setup is causing the following errors:\n\n{0}"
			},
			{
				CommonMessageKeys.SCRIPTING_DEFINE_SYMBOLS_ADDED,
				"Scripting Define Symbols added to [Project Settings->Player] for {0}: {1}"
			},
			{
				CommonMessageKeys.SCRIPTING_DEFINE_SYMBOLS_REMOVED,
				"Scripting Define Symbols removed from [Project Settings->Player] for {0}: {1}"
			}
		};

		public static Dictionary<CommonMessageKeys, int> commonMessageParts = new Dictionary<CommonMessageKeys, int>();

		public LogLevels minLevel;

		public bool throwExceptions = true;

		public static void CreateIfNotExists()
		{
			if (instance == null)
			{
				instance = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, "Logger"))
				{
					hideFlags = (HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor)
				}.AddComponent<VRTK_Logger>();
			}
			if (commonMessageParts.Count == commonMessages.Count)
			{
				return;
			}
			commonMessageParts.Clear();
			foreach (KeyValuePair<CommonMessageKeys, string> commonMessage in commonMessages)
			{
				int value = Regex.Matches(commonMessage.Value, "(?<!\\{)\\{([0-9]+).*?\\}(?!})").Cast<Match>().DefaultIfEmpty()
					.Max((Match m) => (m != null) ? int.Parse(m.Groups[1].Value) : (-1)) + 1;
				commonMessageParts.Add(commonMessage.Key, value);
			}
		}

		public static string GetCommonMessage(CommonMessageKeys messageKey, params object[] parameters)
		{
			CreateIfNotExists();
			string result = "";
			string dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(commonMessages, messageKey);
			if (dictionaryValue != null)
			{
				int dictionaryValue2 = VRTK_SharedMethods.GetDictionaryValue(commonMessageParts, messageKey, 0);
				if (parameters.Length != dictionaryValue2)
				{
					Array.Resize(ref parameters, dictionaryValue2);
				}
				result = string.Format(dictionaryValue, parameters);
			}
			return result;
		}

		public static void Trace(string message)
		{
			Log(LogLevels.Trace, message);
		}

		public static void Debug(string message)
		{
			Log(LogLevels.Debug, message);
		}

		public static void Info(string message)
		{
			Log(LogLevels.Info, message);
		}

		public static void Warn(string message)
		{
			Log(LogLevels.Warn, message);
		}

		public static void Error(string message, bool forcePause = false)
		{
			Log(LogLevels.Error, message, forcePause);
		}

		public static void Fatal(string message, bool forcePause = false)
		{
			Log(LogLevels.Fatal, message, forcePause);
		}

		public static void Fatal(Exception exception, bool forcePause = false)
		{
			Log(LogLevels.Fatal, exception.Message, forcePause);
		}

		public static void Log(LogLevels level, string message, bool forcePause = false)
		{
			CreateIfNotExists();
			if (instance.minLevel > level)
			{
				return;
			}
			switch (level)
			{
			case LogLevels.Trace:
			case LogLevels.Debug:
			case LogLevels.Info:
				UnityEngine.Debug.Log(message);
				break;
			case LogLevels.Warn:
				UnityEngine.Debug.LogWarning(message);
				break;
			case LogLevels.Error:
			case LogLevels.Fatal:
				if (forcePause)
				{
					UnityEngine.Debug.Break();
				}
				if (instance.throwExceptions)
				{
					throw new Exception(message);
				}
				UnityEngine.Debug.LogError(message);
				break;
			}
		}

		protected virtual void Awake()
		{
			instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
	}
}
