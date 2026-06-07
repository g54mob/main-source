using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	public struct SteamItemDetails_t
	{
		public SteamItemInstanceID_t m_itemId;

		public SteamItemDef_t m_iDefinition;

		public ushort m_unQuantity;

		public ushort m_unFlags;
	}
}
