using System;
using DV.Utils;
using JetBrains.Annotations;
using Steamworks;
using UnityEngine;

namespace DV.Platform.Steam
{
	public class DVSteamworks : SingletonBehaviour<DVSteamworks>
	{
		private const int APP_ID = 588030;

		private const string NAME = "[DVSteamworks]";

		public static bool Success { get; private set; }

		public static bool IsSteamDeck
		{
			get
			{
				if (Success)
				{
					return SteamUtils.IsRunningOnSteamDeck;
				}
				return false;
			}
		}

		public static bool IsSteamInBigPictureMode
		{
			get
			{
				if (Success)
				{
					return SteamUtils.IsSteamInBigPictureMode;
				}
				return false;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void StaticReload()
		{
			Success = false;
		}

		protected override void Awake()
		{
			base.Awake();
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			if (BuildInfo.BUILD_DESTINATION != "steam")
			{
				Debug.Log("[DVSteamworks] Will not initialize Steamworks (not running a Steam build)");
				return;
			}
			try
			{
				SteamClient.Init(588030u);
				Debug.Log(string.Format("{0} Steamworks initialized. Name: {1} ID: {2}", "[DVSteamworks]", SteamClient.Name, SteamClient.SteamId));
				Success = true;
			}
			catch (Exception ex)
			{
				if (ex.Message.StartsWith("SteamApi_Init failed with"))
				{
					Debug.LogError("[DVSteamworks] Steamworks failed to initialize! Steam integration will not be available. " + ex.Message);
					return;
				}
				Debug.LogError("[DVSteamworks] Failed to initialize Steamworks! Steam integration will not be available.");
				Debug.LogException(ex);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (Success)
			{
				Debug.Log("[DVSteamworks] Calling SteamClient.Shutdown");
				SteamClient.Shutdown();
			}
		}

		[UsedImplicitly]
		public new static string AllowAutoCreate()
		{
			return "[DVSteamworks]";
		}
	}
}
