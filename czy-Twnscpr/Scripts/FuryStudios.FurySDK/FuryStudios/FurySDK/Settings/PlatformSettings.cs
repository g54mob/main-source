using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[CreateAssetMenu]
	public class PlatformSettings : ScriptableObject
	{
		public const string MAIN_ASSET_NAME = "MainGamePlatformSettings";

		[SerializeField]
		private SharedPlatformSettings shared;

		[SerializeField]
		private PlatformPlayerPrefsSettings playerPrefs;

		[SerializeField]
		private StandalonePlatformSettings standalone;

		[SerializeField]
		private NintendoSwitchPlatformSettings nintendoSwitch;

		[SerializeField]
		private Playstation4PlatformSettings playstation4;

		[SerializeField]
		private GameCorePlatformSettings gameCore;

		[SerializeField]
		private SteamPlatformSettings steam;

		[SerializeField]
		private GogPlatformSettings gog;

		[SerializeField]
		private EpicPlatformSettings epic;

		[SerializeField]
		private iOSPlatformSettings ios;

		[SerializeField]
		private AndroidPlatformSettings android;

		public SharedPlatformSettings Shared => null;

		public PlatformPlayerPrefsSettings PlayerPrefs => null;

		public StandalonePlatformSettings Standalone => null;

		public NintendoSwitchPlatformSettings NintendoSwitch => null;

		public Playstation4PlatformSettings Playstation4 => null;

		public GameCorePlatformSettings GameCore => null;

		public SteamPlatformSettings Steam => null;

		public GogPlatformSettings Gog => null;

		public EpicPlatformSettings Epic => null;

		public iOSPlatformSettings iOS => null;

		public AndroidPlatformSettings Android => null;
	}
}
