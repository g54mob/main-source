using System;
using System.Collections.Generic;
using MoonSharp.Interpreter.Debugging;

namespace MoonSharp.Interpreter
{
	public class InterpreterException : Exception
	{
		public int InstructionPtr { get; internal set; }

		public IList<WatchItem> CallStack { get; internal set; }

		public string DecoratedMessage { get; internal set; }

		protected InterpreterException(Exception ex)
			: base(ex.Message, ex)
		{
		}

		protected InterpreterException(string message)
			: base(message)
		{
		}

		protected InterpreterException(string format, params object[] args)
			: base(string.Format(format, args))
		{
		}

		internal void DecorateMessage(Script script, SourceRef sref, int ip = -1)
		{
			if (sref != null)
			{
				DecoratedMessage = string.Format("{0}: {1}", sref.FormatLocation(script), Message);
			}
			else
			{
				DecoratedMessage = string.Format("bytecode:{0}: {1}", ip, Message);
			}
		}
	}
}
