using MoonSharp.Interpreter;

namespace MoonSharp.VsCodeDebugger.SDK
{
	public abstract class DebugSession : ProtocolServer
	{
		private bool _debuggerLinesStartAt1;

		private bool _debuggerPathsAreURI;

		private bool _clientLinesStartAt1;

		private bool _clientPathsAreURI;

		public DebugSession(bool debuggerLinesStartAt1, bool debuggerPathsAreURI = false)
		{
		}

		public void SendResponse(Response response, ResponseBody body = null)
		{
		}

		public void SendErrorResponse(Response response, int id, string format, object arguments = null, bool user = true, bool telemetry = false)
		{
		}

		protected override void DispatchRequest(string command, Table args, Response response)
		{
		}

		public abstract void Initialize(Response response, Table args);

		public abstract void Launch(Response response, Table arguments);

		public abstract void Attach(Response response, Table arguments);

		public abstract void Disconnect(Response response, Table arguments);

		public virtual void SetFunctionBreakpoints(Response response, Table arguments)
		{
		}

		public virtual void SetExceptionBreakpoints(Response response, Table arguments)
		{
		}

		public abstract void SetBreakpoints(Response response, Table arguments);

		public abstract void Continue(Response response, Table arguments);

		public abstract void Next(Response response, Table arguments);

		public abstract void StepIn(Response response, Table arguments);

		public abstract void StepOut(Response response, Table arguments);

		public abstract void Pause(Response response, Table arguments);

		public abstract void StackTrace(Response response, Table arguments);

		public abstract void Scopes(Response response, Table arguments);

		public abstract void Variables(Response response, Table arguments);

		public virtual void Source(Response response, Table arguments)
		{
		}

		public abstract void Threads(Response response, Table arguments);

		public abstract void Evaluate(Response response, Table arguments);

		protected int ConvertDebuggerLineToClient(int line)
		{
			return 0;
		}

		protected int ConvertClientLineToDebugger(int line)
		{
			return 0;
		}

		protected string ConvertDebuggerPathToClient(string path)
		{
			return null;
		}

		protected string ConvertClientPathToDebugger(string clientPath)
		{
			return null;
		}
	}
}
