using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 152)]
	[CallbackIdentity(1103)]
	public struct UserAchievementStored_t
	{
		public const int k_iCallback = 1103;

		public ulong m_nGameID;

		public bool m_bGroupAchievement;

		public string m_rgchAchievementName;

		public uint m_nCurProgress;

		public uint m_nMaxProgress;
	}
}
