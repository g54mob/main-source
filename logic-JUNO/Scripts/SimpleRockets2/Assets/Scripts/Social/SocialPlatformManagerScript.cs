using System;
using Assets.Packages.SocialPlatforms;
using Assets.Packages.SocialPlatforms.Steam;
using Assets.Packages.SocialPlatforms.Steam.Events;
using Assets.Scripts.OperatingSystem;
using Assets.Scripts.Social.Achievements;
using UnityEngine;

namespace Assets.Scripts.Social
{
	internal class SocialPlatformManagerScript : MonoBehaviour
	{
		public ISteamManager SteamManager { get; private set; }

		protected AchievementManagerScript AchievementManager { get; private set; }

		public static SocialPlatformManagerScript Create(GameObject parent)
		{
			SocialPlatformManagerScript socialPlatformManagerScript = new GameObject("SocialPlatformManager").AddComponent<SocialPlatformManagerScript>();
			socialPlatformManagerScript.transform.SetParent(parent.transform);
			return socialPlatformManagerScript;
		}

		protected virtual void Awake()
		{
			Initialize();
		}

		private void Initialize()
		{
			AchievementManager = Game.Instance.AchievementManager;
			SocialExt.Initialize(AchievementManager.Achievements);
			AchievementManager.LoadAchievements();
			if (SocialExt.IsSteam)
			{
				SteamPlatform steamPlatform = (SteamPlatform)SocialExt.Active;
				steamPlatform.SteamManager.Transform.parent = base.transform;
				steamPlatform.GameWebCallback += OnGameWebCallback;
				steamPlatform.NewLaunchParameters += OnNewLaunchParameters;
				try
				{
					Debug.Log("Steam Branch: " + steamPlatform.GetCurrentBetaName());
				}
				catch (Exception exception)
				{
					Debug.LogError("Unable to determine Steam branch name.");
					Debug.LogException(exception);
				}
			}
		}

		private void OnGameWebCallback(object sender, GameWebCallbackEventArgs e)
		{
			Debug.Log("Game web callback received: " + e.Url);
			if (!string.IsNullOrEmpty(e.Url))
			{
				string url = e.Url.Replace("steam://gamewebcallback/870200/", "simplerockets2://");
				Game.Instance.UrlHandler.HandleUrl(url);
			}
		}

		private void OnNewLaunchParameters(object sender, NewLaunchParametersEventArgs e)
		{
			string parameter = e.GetParameter("arg");
			Debug.LogFormat("Received new launch parameters: arg={0}", parameter);
			SystemUtils.SwitchToThisWindow();
			if (!string.IsNullOrEmpty(parameter))
			{
				Game.Instance.UrlHandler.HandleUrl(parameter);
			}
		}
	}
}
