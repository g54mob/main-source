namespace FlyingWormConsole3.LiteNetLib
{
	public interface INetLogger
	{
		void WriteNet(NetLogLevel level, string str, params object[] args);
	}
}
