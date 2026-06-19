using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Aggro.Core
{
	public static class AggroUtil
	{
		public const string GLOBAL_DATA_PATH = "GlobalData";

		public const string FAILEDGLOBALIPTEXT = "FAILED";

		public static void CheckGetComponent<T>(MonoBehaviour behaviour, ref T comp) where T : class
		{
		}

		public static void CheckGetComponentInParent<T>(MonoBehaviour behaviour, ref T comp) where T : class
		{
		}

		public static void CheckGetComponentInChild<T>(MonoBehaviour behaviour, ref T comp, bool includeInactive = false) where T : class
		{
		}

		public static void CheckGetGameObject(MonoBehaviour behaviour, ref GameObject gameObject)
		{
		}

		public static bool IsEnabledAndActive<T>(T check) where T : class
		{
			if (check == null)
			{
				return false;
			}
			if (check is Behaviour behaviour)
			{
				if (behaviour == null)
				{
					return false;
				}
				return behaviour.isActiveAndEnabled;
			}
			return true;
		}

		public static Type[] GetTypesWithAttribute<T>() where T : Attribute
		{
			List<Type> list = new List<Type>();
			GetTypesWithAttribute<T>(list);
			return list.ToArray();
		}

		public static void GetTypesWithAttribute<T>(List<Type> list) where T : Attribute
		{
			Type typeFromHandle = typeof(IEntityTyped);
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Type[] types = assemblies[i].GetTypes();
				foreach (Type type in types)
				{
					if (!type.IsInterface && !type.IsGenericTypeDefinition && !type.IsAbstract && type.GetCustomAttribute<T>() == null && typeFromHandle.IsAssignableFrom(type))
					{
						list.Add(type);
					}
				}
			}
		}

		public static void InitializeGlobalScrobs()
		{
			ScriptableObject[] array = Resources.LoadAll<ScriptableObject>("GlobalData");
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] is IGlobalScriptableObject globalScriptableObject)
				{
					globalScriptableObject.SetSingleton();
				}
			}
		}

		public static bool IsCurrentGamepadProController()
		{
			if (Gamepad.current != null)
			{
				string obj = Gamepad.current.displayName ?? "";
				string text = Gamepad.current.description.product ?? "";
				if (!obj.Contains("Pro Controller"))
				{
					return text.Contains("Pro Controller");
				}
				return true;
			}
			return false;
		}

		public static void PlaySfxIfValid(EventReference sfx)
		{
			if (!sfx.IsNull)
			{
				RuntimeManager.PlayOneShot(sfx);
			}
		}

		public static async Task<string> GetGlobalIp()
		{
			WebClient _webClient = new WebClient();
			Task<string> ipTask;
			try
			{
				ipTask = _webClient.DownloadStringTaskAsync("https://api.ipify.org/");
				await ipTask;
			}
			finally
			{
				_webClient.Dispose();
			}
			_ = string.Empty;
			if (ipTask.IsFaulted)
			{
				return "FAILED";
			}
			return ipTask.Result;
		}

		public static Guid GetBuildGuid()
		{
			using MD5 mD = MD5.Create();
			byte[] bytes = Encoding.Default.GetBytes(Application.version);
			return new Guid(mD.ComputeHash(bytes));
		}
	}
}
