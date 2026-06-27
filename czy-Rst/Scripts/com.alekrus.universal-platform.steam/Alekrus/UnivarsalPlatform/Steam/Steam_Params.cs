using System;
using System.IO;
using Alekrus.UnivarsalPlatform.Utilities;
using UnityEngine;

namespace Alekrus.UnivarsalPlatform.Steam
{
	public class Steam_Params : ScriptableObject
	{
		public const int DEFAULT_APP_ID = 480;

		private static Steam_Params _instance;

		[SerializeField]
		private int _appId = 480;

		[SerializeField]
		private bool _restartAppIfNecessaryEnable = true;

		public static Steam_Params Instance
		{
			get
			{
				if (_instance != null)
				{
					return _instance;
				}
				_instance = LoadOrCreateParams();
				return _instance;
			}
		}

		public uint AppId => (uint)_appId;

		public bool RestartAppIfNecessaryEnable => _restartAppIfNecessaryEnable;

		public void ResetParams()
		{
			_appId = 480;
		}

		public void CreateSteamAppIdFile()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "steam_appid.txt");
			Debug.Log(PlatformDebugging.GetMessage(GetType(), "CreateSteamAppIdFile", "'steam_appid.txt' is not present in the project root. Writing..."));
			try
			{
				StreamWriter streamWriter = File.CreateText(path);
				streamWriter.Write(_appId);
				streamWriter.Close();
				Debug.Log(PlatformDebugging.GetMessage(GetType(), "CreateSteamAppIdFile", "Successfully copied 'steam_appid.txt' into the project root."));
			}
			catch (Exception exception)
			{
				Debug.Log(PlatformDebugging.GetMessage(GetType(), "CreateSteamAppIdFile", "Could not copy 'steam_appid.txt' into the project root. Please place 'steam_appid.txt' into the project root manually."));
				Debug.LogException(exception);
			}
		}

		private static string GetNameAsset()
		{
			return "Steam_Params";
		}

		private static Steam_Params LoadOrCreateParams()
		{
			Steam_Params steam_Params = Resources.Load<Steam_Params>("Alekrus/UnivarsalPlatform/Steam/" + GetNameAsset());
			if (steam_Params != null)
			{
				return steam_Params;
			}
			return ScriptableObject.CreateInstance<Steam_Params>();
		}
	}
}
