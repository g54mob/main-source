using System.Collections.Generic;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class UserProfileData
	{
		[Key(0)]
		public bool IsSandboxUnlocked;

		[Key(1)]
		public bool HasSeenSandboxCutscene;

		[Key(2)]
		public bool IsCollaborativeProjectsUnlocked;

		[Key(3)]
		public bool HasSeenCollaborativeProjectCutscene;

		[Key(4)]
		public SuperBugRewardRecord SuperBugRewardRecord;

		[Key(5)]
		public List<string> PrimeGamingEntitlements;

		[Key(6)]
		public string PrimeGamingRefreshToken;

		[Key(7)]
		public List<string>[] PrimeGamingKudoshIDsClaimed;

		[Key(8)]
		public ulong FGWPUserID;
	}
}
