using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Stonescript.Compiler
{
	public class CompileException : StonescriptException
	{
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

		public override string Message => $"{script.name} line {LineNumber}: {base.Message}";

		public CompileException(Script script, IParseTree node, string message, Level level = Level.Error)
			: base(message, level)
		{
			this.script = script;
			this.node = node;
		}

		public CompileException(Script script, IParseTree node, Exception innerException, Level level = Level.Error)
			: base(innerException, level)
		{
			this.script = script;
			this.node = node;
		}

		public CompileException(Script script, IParseTree node, string message, Exception innerException, Level level = Level.Error)
			: base(message, innerException, level)
		{
			this.script = script;
			this.node = node;
		}
	}
}
