using System.Runtime.InteropServices;

namespace Steamworks
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	[CallbackIdentity(714)]
	public struct GamepadTextInputDismissed_t
	{
		public const int k_iCallback = 714;

		public bool m_bSubmitted;

		public uint m_unSubmittedText;
	}
}
