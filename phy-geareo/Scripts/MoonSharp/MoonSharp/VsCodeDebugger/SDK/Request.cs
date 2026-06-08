using MoonSharp.Interpreter;

namespace MoonSharp.VsCodeDebugger.SDK
{
	public class Request : ProtocolMessage
	{
		public string command;

		public Table arguments;

		public Request(int id, string cmd, Table arg)
			: base(null)
		{
		}
	}
}
