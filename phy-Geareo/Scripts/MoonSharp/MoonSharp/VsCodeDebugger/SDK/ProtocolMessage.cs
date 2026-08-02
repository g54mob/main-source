namespace MoonSharp.VsCodeDebugger.SDK
{
	public class ProtocolMessage
	{
		public int seq;

		public string type { get; private set; }

		public ProtocolMessage(string typ)
		{
		}

		public ProtocolMessage(string typ, int sq)
		{
		}
	}
}
