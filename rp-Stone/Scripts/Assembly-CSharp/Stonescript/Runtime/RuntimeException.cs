using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Stonescript.Compiler;

namespace Stonescript.Runtime
{
	public class RuntimeException : StonescriptException
	{
		private string scriptStackTrace;

		private Script script;

		private IParseTree node;

		public string ScriptName => script.name;

		public int LineNumber
		{
			get
			{
				if (node is ITerminalNode)
				{
					return (node as ITerminalNode).Symbol.Line;
				}
				if (node is ParserRuleContext)
				{
					return (node as ParserRuleContext).Start.Line;
				}
				return -1;
			}
		}

		public string NativeStackTrace => base.StackTrace;

		public override string StackTrace => scriptStackTrace;

		public override string Message => $"{ScriptName} line {LineNumber}: {base.Message}";

		public RuntimeException(InvocationContext invCtx, string message, Level level = Level.Error)
			: this(invCtx.execCtx, invCtx.node, message, null, level)
		{
		}

		public RuntimeException(ExecutionContext execCtx, IParseTree node, string message, Level level = Level.Error)
			: this(execCtx, node, message, null, level)
		{
		}

		public RuntimeException(ExecutionContext execCtx, IParseTree node, string message, Exception innerException, Level level = Level.Error)
			: base(message, innerException, level)
		{
			script = execCtx.CurrentExecutable.script;
			this.node = node;
			scriptStackTrace = execCtx.StackTrace;
		}
	}
}
