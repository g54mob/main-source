using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.VsCodeDebugger.DebuggerLogic;

namespace MoonSharp.VsCodeDebugger
{
	public class MoonSharpVsCodeDebugServer : IDisposable
	{
		private object m_Lock;

		private List<AsyncDebugger> m_DebuggerList;

		private AsyncDebugger m_Current;

		private ManualResetEvent m_StopEvent;

		private bool m_Started;

		private int m_Port;

		public int? CurrentId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Script Current
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Action<string> Logger { get; set; }

		public MoonSharpVsCodeDebugServer(int port = 41912)
		{
		}

		[Obsolete("Use the constructor taking only a port, and the 'Attach' method instead.")]
		public MoonSharpVsCodeDebugServer(Script script, int port, Func<SourceCode, string> sourceFinder = null)
		{
		}

		public void AttachToScript(Script script, string name, Func<SourceCode, string> sourceFinder = null)
		{
		}

		public IEnumerable<KeyValuePair<int, string>> GetAttachedDebuggersByIdAndName()
		{
			return null;
		}

		public void Detach(Script script)
		{
		}

		[Obsolete("Use the Attach method instead.")]
		public IDebugger GetDebugger()
		{
			return null;
		}

		public void Dispose()
		{
		}

		public MoonSharpVsCodeDebugServer Start()
		{
			return null;
		}

		private void ListenThread(TcpListener serverSocket)
		{
		}

		private void RunSession(string sessionId, NetworkStream stream)
		{
		}

		private void Log(string format, params object[] args)
		{
		}

		private static void SpawnThread(string name, Action threadProc)
		{
		}
	}
}
