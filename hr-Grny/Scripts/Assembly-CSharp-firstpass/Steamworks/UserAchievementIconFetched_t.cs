using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 144)]
	[CallbackIdentity(1109)]
	public struct UserAchievementIconFetched_t
	{
		public const int k_iCallback = 1109;

		public CGameID m_nGameID;

		public string m_rgchAchievementName;

		public bool m_bAchieved;

		public int m_nIconHandle;
	}
}
