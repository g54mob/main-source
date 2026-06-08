using MoonSharp.Interpreter;

namespace MoonSharp.VsCodeDebugger.SDK
{
	public class Response : ProtocolMessage
	{
		public bool success { get; private set; }

		public string message { get; private set; }

		public int request_seq { get; private set; }

		public string command { get; private set; }

		public ResponseBody body { get; private set; }

		public Response(Table req)
			: base(null)
		{
		}

		public void SetBody(ResponseBody bdy)
		{
		}

		public void SetErrorBody(string msg, ResponseBody bdy = null)
		{
		}
	}
}
