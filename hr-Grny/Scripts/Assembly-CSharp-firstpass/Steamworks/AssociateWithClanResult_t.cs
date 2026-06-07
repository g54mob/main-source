using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	[CallbackIdentity(210)]
	public struct AssociateWithClanResult_t
	{
		public const int k_iCallback = 210;

		public EResult m_eResult;
	}
}
