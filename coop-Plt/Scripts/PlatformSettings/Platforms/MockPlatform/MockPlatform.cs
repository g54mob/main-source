using System.Collections.Generic;
using System.Threading.Tasks;
using Kitchen;
using KitchenData;
using Photon.Realtime;
using UnityEngine.InputSystem;

namespace Platforms.MockPlatform
{
	public class MockPlatform : Platform
	{
		public override async Task<byte[]> ReadAllBytes(string path)
		{
			return null;
		}

		public override async Task WriteAllBytes(string path, byte[] bytes)
		{
		}

		public override async Task CreateDirectory(string directory)
		{
		}

		public override async Task DeleteFile(string path)
		{
		}

		public override async Task<IEnumerable<FileReference>> GetFiles(string path, string ext, bool filter_empty)
		{
			return null;
		}

		public override async Task RenameFile(string old_path, string new_path)
		{
		}

		public override void OpenInviteUI(NetworkInviteData invite)
		{
		}

		public override async Task<Result<AuthenticationValues>> GetPhotonAuth(bool force_skip_cache = false)
		{
			return default(Result<AuthenticationValues>);
		}

		public override MultiplayerAccessResult CanUseMultiplayer(IEnumerable<PlatformUser> main_local_users, bool force_rerun = false)
		{
			return MultiplayerAccessResult.Success;
		}

		public override string GetLocale()
		{
			return "English";
		}

		protected override Dictionary<string, string> GetAchievementMapping(AchievementConfiguration config)
		{
			return new Dictionary<string, string>();
		}

		protected override async Task<IEnumerable<string>> RetrieveUserAchievements(PlatformUser user)
		{
			return new List<string>();
		}

		protected override async Task GrantUserAchievement(PlatformUser user, string identifier)
		{
		}

		public override string GetInfoString(PlatformUser user)
		{
			return "User Info String";
		}

		public override string GetDisplayName(PlatformUser user)
		{
			return "User Display Name";
		}

		public override async Task<PlatformUser> GetUserUsingDevice(InputDevice device)
		{
			return default(PlatformUser);
		}
	}
}
