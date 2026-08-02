using System;
using System.Collections.Generic;
using MoonSharp.Interpreter.Debugging;

namespace MoonSharp.Interpreter
{
	[Serializable]
	public class InterpreterException : Exception
	{
		public int InstructionPtr { get; internal set; }

		public IList<WatchItem> CallStack { get; internal set; }

		public string DecoratedMessage { get; internal set; }

		public bool DoNotDecorateMessage { get; set; }

		protected InterpreterException(Exception ex, string message)
		{
		}

		protected InterpreterException(Exception ex)
		{
		}

		protected InterpreterException(string message)
		{
		}

		protected InterpreterException(string format, params object[] args)
		{
		}

		internal void DecorateMessage(Script script, SourceRef sref, int ip = -1)
		{
		}

		public virtual void Rethrow()
		{
		}
	}
}
