using MoonSharp.Interpreter;
using MoonSharp.VsCodeDebugger.SDK;

namespace MoonSharp.VsCodeDebugger.DebuggerLogic
{
	internal class EmptyDebugSession : DebugSession
	{
		private MoonSharpVsCodeDebugServer m_Server;

		internal EmptyDebugSession(MoonSharpVsCodeDebugServer server)
			: base(debuggerLinesStartAt1: false)
		{
		}

		public override void Initialize(Response response, Table args)
		{
		}

		private void SendList()
		{
		}

		public override void Attach(Response response, Table arguments)
		{
		}

		public override void Continue(Response response, Table arguments)
		{
		}

		public override void Disconnect(Response response, Table arguments)
		{
		}

		private static string getString(Table args, string property, string dflt = null)
		{
			return null;
		}

		public override void Evaluate(Response response, Table args)
		{
		}

		private void ExecuteRepl(string cmd)
		{
		}

		public override void Launch(Response response, Table arguments)
		{
		}

		public override void Next(Response response, Table arguments)
		{
		}

		public override void Pause(Response response, Table arguments)
		{
		}

		public override void Scopes(Response response, Table arguments)
		{
		}

		public override void SetBreakpoints(Response response, Table args)
		{
		}

		public override void StackTrace(Response response, Table args)
		{
		}

		public override void StepIn(Response response, Table arguments)
		{
		}

		public override void StepOut(Response response, Table arguments)
		{
		}

		public override void Threads(Response response, Table arguments)
		{
		}

		public override void Variables(Response response, Table arguments)
		{
		}

		private void SendText(string msg, params object[] args)
		{
		}

		public void Unbind()
		{
		}
	}
}
