using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	[CallbackIdentity(347)]
	public struct SetPersonaNameResponse_t
	{
		public const int k_iCallback = 347;

		public bool m_bSuccess;

		public bool m_bLocalSuccess;

		public EResult m_result;
	}
}
