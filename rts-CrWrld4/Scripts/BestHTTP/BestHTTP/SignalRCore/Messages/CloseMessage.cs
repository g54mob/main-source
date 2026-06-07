using System.Runtime.InteropServices;

namespace BestHTTP.SignalRCore.Messages
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct CloseMessage
	{
		public MessageTypes type => default(MessageTypes);
	}
}
