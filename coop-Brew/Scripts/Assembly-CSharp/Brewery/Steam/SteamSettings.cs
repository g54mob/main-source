using UnityEngine;

namespace Brewery.Steam
{
	[CreateAssetMenu(fileName = "SteamSettings", menuName = "Brewery/Steam Settings")]
	public class SteamSettings : ScriptableObject
	{
		private const string RESOURCE_PATH = "SteamSettings";

		[Header("App IDs")]
		[Tooltip("Your real Steam App ID (used in Release builds)")]
		public uint releaseAppId;

		[Tooltip("Test App ID - Spacewar (480) doesn't show on your profile")]
		public uint testAppId;

		[Tooltip("Demo App ID (used when DEMO_MODE define is active)")]
		public uint demoAppId;

		[Header("Editor Settings")]
		[Tooltip("If true, use your real App ID in the Editor (will show 'Playing Brewgether' on Steam)")]
		public bool useRealAppIdInEditor;

		[Header("Development Build Settings")]
		[Tooltip("If true, use your real App ID in Development Builds")]
		public bool useRealAppIdInDevBuild;

		private static SteamSettings _instance;

		public static SteamSettings Instance => null;

		public uint GetAppId()
		{
			return 0u;
		}

		public string GetAppIdDescription()
		{
			return null;
		}
	}
}
