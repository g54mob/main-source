using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Debugging;

namespace MoonSharp.VsCodeDebugger.DebuggerLogic
{
	internal class AsyncDebugger : IDebugger
	{
		private static object s_AsyncDebuggerIdLock;

		private static int s_AsyncDebuggerIdCounter;

		private object m_Lock;

		private IAsyncDebuggerClient m_Client__;

		private DebuggerAction m_PendingAction;

		private List<WatchItem>[] m_WatchItems;

		private Dictionary<int, SourceCode> m_SourcesMap;

		private Dictionary<int, string> m_SourcesOverride;

		private Func<SourceCode, string> m_SourceFinder;

		public DebugService DebugService { get; private set; }

		public Regex ErrorRegex { get; set; }

		public Script Script { get; private set; }

		public bool PauseRequested { get; set; }

		public string Name { get; set; }

		public int Id { get; private set; }

		public IAsyncDebuggerClient Client
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AsyncDebugger(Script script, Func<SourceCode, string> sourceFinder, string name)
		{
		}

		DebuggerAction IDebugger.GetAction(int ip, SourceRef sourceref)
		{
			return null;
		}

		public void QueueAction(DebuggerAction action)
		{
		}

		private void Sleep(int v)
		{
		}

		private DynamicExpression CreateDynExpr(string code)
		{
			return null;
		}

		List<DynamicExpression> IDebugger.GetWatchItems()
		{
			return null;
		}

		bool IDebugger.IsPauseRequested()
		{
			return false;
		}

		void IDebugger.RefreshBreakpoints(IEnumerable<SourceRef> refs)
		{
		}

		void IDebugger.SetByteCode(string[] byteCode)
		{
		}

		void IDebugger.SetSourceCode(SourceCode sourceCode)
		{
		}

		private string GetFooterForTempFile()
		{
			return null;
		}

		public string GetSourceFile(int sourceId)
		{
			return null;
		}

		public bool IsSourceOverride(int sourceId)
		{
			return false;
		}

		void IDebugger.SignalExecutionEnded()
		{
		}

		bool IDebugger.SignalRuntimeException(ScriptRuntimeException ex)
		{
			return false;
		}

		void IDebugger.Update(WatchType watchType, IEnumerable<WatchItem> items)
		{
		}

		public List<WatchItem> GetWatches(WatchType watchType)
		{
			return null;
		}

		public SourceCode GetSource(int id)
		{
			return null;
		}

		public SourceCode FindSourceByName(string path)
		{
			return null;
		}

		void IDebugger.SetDebugService(DebugService debugService)
		{
		}

		public DynValue Evaluate(string expression)
		{
			return null;
		}

		DebuggerCaps IDebugger.GetDebuggerCaps()
		{
			return default(DebuggerCaps);
		}
	}
}
