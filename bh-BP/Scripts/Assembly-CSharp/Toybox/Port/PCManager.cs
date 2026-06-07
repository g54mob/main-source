namespace Toybox.Port
{
	public class PCManager : IPlatformManager
	{
		private bool _isInitialized;

		public IPlatformAchievement PlatformAchievement { get; private set; }

		public IPlatformSave PlatformSave { get; private set; }

		public IPlatformPlayerPrefs PlatformPlayerPrefs { get; private set; }

		public IPlatformGamepad PlatformGamepad { get; private set; }

		public IPlatformLeaderboard PlatformLeaderboard { get; private set; }

		public bool IsConstrained { get; private set; }

		public bool IsInitialized => false;

		public void Init()
		{
		}

		public void Update()
		{
		}
	}
}
