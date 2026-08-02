using System.Collections.Generic;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.VsCodeDebugger.SDK;

namespace MoonSharp.VsCodeDebugger.DebuggerLogic
{
	internal class MoonSharpDebugSession : DebugSession, IAsyncDebuggerClient
	{
		private AsyncDebugger m_Debug;

		private MoonSharpVsCodeDebugServer m_Server;

		private List<DynValue> m_Variables;

		private bool m_NotifyExecutionEnd;

		private const int SCOPE_LOCALS = 65536;

		private const int SCOPE_SELF = 65537;

		private readonly SourceRef DefaultSourceRef;

		internal MoonSharpDebugSession(MoonSharpVsCodeDebugServer server, AsyncDebugger debugger)
			: base(debuggerLinesStartAt1: false)
		{
		}

		public override void Initialize(Response response, Table args)
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

		private StoppedEvent CreateStoppedEvent(string reason, string text = null)
		{
			return null;
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

		private int getInt(Table args, string propName, int defaultValue)
		{
			return 0;
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

		void IAsyncDebuggerClient.SendStopEvent()
		{
		}

		void IAsyncDebuggerClient.OnWatchesUpdated(WatchType watchType)
		{
		}

		void IAsyncDebuggerClient.OnSourceCodeChanged(int sourceID)
		{
		}

		public void OnExecutionEnded()
		{
		}

		private void SendText(string msg, params object[] args)
		{
		}

		public void OnException(ScriptRuntimeException ex)
		{
		}

		public void Unbind()
		{
		}
	}
}
