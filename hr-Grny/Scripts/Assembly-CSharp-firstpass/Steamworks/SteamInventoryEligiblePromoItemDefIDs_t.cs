using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 20)]
	[CallbackIdentity(4703)]
	public struct SteamInventoryEligiblePromoItemDefIDs_t
	{
		public const int k_iCallback = 4703;

		public EResult m_result;

		public CSteamID m_steamID;

		public int m_numEligiblePromoItemDefs;

		public bool m_bCachedData;
	}
}
