using System;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Tree;

namespace MoonSharp.Interpreter
{
	[Serializable]
	public class SyntaxErrorException : InterpreterException
	{
		internal Token Token { get; private set; }

		public bool IsPrematureStreamTermination { get; set; }

		internal SyntaxErrorException(Token t, string format, params object[] args)
			: base((Exception)null, (string)null)
		{
		}

		internal SyntaxErrorException(Token t, string message)
			: base((Exception)null, (string)null)
		{
		}

		internal SyntaxErrorException(Script script, SourceRef sref, string format, params object[] args)
			: base((Exception)null, (string)null)
		{
		}

		internal SyntaxErrorException(Script script, SourceRef sref, string message)
			: base((Exception)null, (string)null)
		{
		}

		private SyntaxErrorException(SyntaxErrorException syntaxErrorException)
			: base((Exception)null, (string)null)
		{
		}

		internal void DecorateMessage(Script script)
		{
		}

		public override void Rethrow()
		{
		}
	}
}
