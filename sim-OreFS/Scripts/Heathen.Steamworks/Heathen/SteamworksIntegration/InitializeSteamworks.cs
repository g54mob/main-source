using System.Collections.Generic;
using Heathen.SteamworksIntegration.API;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	[HelpURL("https://kb.heathen.group/toolkit-for-steamworks/unity/getting-started#component")]
	[DisallowMultipleComponent]
	public class InitializeSteamworks : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		internal SteamSettings targetSettings;

		[SerializeField]
		[HideInInspector]
		internal SteamSettings mainSettings;

		[SerializeField]
		[HideInInspector]
		internal SteamSettings demoSettings;

		[SerializeField]
		[HideInInspector]
		internal List<SteamSettings> playtestSettings;

		private void Start()
		{
			if (targetSettings != null && !App.Initialized)
			{
				targetSettings.Initialize();
			}
			else
			{
				Debug.LogError("No settings found");
			}
		}
	}
}
