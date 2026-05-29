using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Platforms/Steam Resources")]
	public class PlatformResourcesSteam : GamePlatformResources
	{
		[SerializeField]
		private PlatformUserSteam _user;

		[SerializeField]
		private PlatformLibrarySteam _library;

		public override bool IsCurrentPlatform()
		{
			return SteamManager.Initialized;
		}

		public override IPlatformLibrary GetLibrary()
		{
			return _library;
		}

		public override IPlatformUser GetUser()
		{
			return _user;
		}
	}
}
