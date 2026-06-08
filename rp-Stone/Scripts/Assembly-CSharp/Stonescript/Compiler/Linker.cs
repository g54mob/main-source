using System;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Stonescript.Runtime;

namespace Stonescript.Compiler
{
	public class Linker : Visitor
	{
		private Executable currentExecutable;

		public override Script script => currentExecutable.script;

		protected override StonescriptObject target => currentExecutable.Target;

		public Linker(Machine machine)
			: base(machine)
		{
		}

		public object Link(Executable executable)
		{
			Executable executable2 = currentExecutable;
			currentExecutable = executable;
			if (executable.script.parseTree == null)
			{
				throw new Exception("Incomplete parsing " + executable.script.name);
			}
			object result = executable.script.parseTree.root.Accept(this);
			executable.Target.Link();
			currentExecutable = executable2;
			return result;
		}

		protected override StonescriptException CreateException(string message, IParseTree node, Exception innerException = null, StonescriptException.Level level = StonescriptException.Level.Error)
		{
			return new CompileException(currentExecutable.script, node, message, innerException, level);
		}

		protected override bool ShouldVisitNextChild(IRuleNode node, object currentResult)
		{
			return true;
		}

		public override object VisitStmt([NotNull] StonescriptParser.StmtContext context)
		{
			return VisitChildren(context);
		}

		public override object VisitQualifiedId([NotNull] StonescriptParser.QualifiedIdContext context)
		{
			return VisitChildren(context);
		}

		public override object VisitFuncdef([NotNull] StonescriptParser.FuncdefContext context)
		{
			string id = GetId(context.ID());
			string text = machine.ValidateVariableName(id);
			if (text != null)
			{
				throw CreateException(text, context.ID());
			}
			List<string> parameterNames = ((context.varlist() == null) ? new List<string>() : (context.varlist().Accept(this) as List<string>));
			ScriptFunction scriptFunction;
			if (target.IsVariable(id, allowParentChaining: false))
			{
				scriptFunction = target.GetFunction(id) as ScriptFunction;
				scriptFunction.ParameterNames = parameterNames;
				scriptFunction.declarationContext = context;
				scriptFunction.executable = currentExecutable;
				return scriptFunction;
			}
			scriptFunction = new ScriptFunction(id, parameterNames, context, currentExecutable);
			target.Declare(id, scriptFunction);
			return scriptFunction;
		}

		public override object VisitVarlist([NotNull] StonescriptParser.VarlistContext context)
		{
			List<string> list = new List<string>();
			ITerminalNode[] array = context.ID();
			foreach (ITerminalNode node in array)
			{
				list.Add(GetId(node));
			}
			return list;
		}
	}
}
