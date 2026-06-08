using FlyingWormConsole3.LiteNetLib.Utils;

namespace FlyingWormConsole3.LiteNetLib
{
	public interface INtpEventListener
	{
		void OnNtpResponse(NtpPacket packet);
	}
}
