using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Stonescript.Compiler
{
	public class Compiler : Visitor
	{
		protected Script currentScript;

		protected bool cache = true;

		protected bool anyExeceptions;

		public bool compileImports = true;

		public Action<Exception> onWarning;

		public Action<string> CacheSubstituteExpression;

		public override Script script => currentScript;

		protected override StonescriptObject target
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public Compiler(Machine machine)
			: base(machine)
		{
		}

		public bool Compile(Script script, bool cache = true)
		{
			bool flag = this.cache;
			Script script2 = currentScript;
			currentScript = script;
			this.cache = cache;
			bool flag2 = anyExeceptions;
			anyExeceptions = false;
			script.parseTree.root.Accept(this);
			bool result = !anyExeceptions;
			currentScript = script2;
			this.cache = flag;
			anyExeceptions = flag2;
			return result;
		}

		protected override StonescriptException CreateException(string message, IParseTree node, Exception innerException = null, StonescriptException.Level level = StonescriptException.Level.Error)
		{
			return new CompileException(script, node, message, innerException, level);
		}

		public override object VisitChildren(IRuleNode node)
		{
			for (int i = 0; i < node.ChildCount; i++)
			{
				IParseTree child = node.GetChild(i);
				if (!(child is ParserRuleContext))
				{
					continue;
				}
				ParserRuleContext parserRuleContext = child as ParserRuleContext;
				Exception exception = parserRuleContext.exception;
				if (exception != null)
				{
					string message = "Invalid statement.";
					StonescriptException.Level level = StonescriptException.Level.Error;
					CompileException ex = new CompileException(currentScript, parserRuleContext, message, exception, level);
					if (ex.level >= StonescriptException.Level.Error)
					{
						throw ex;
					}
					onWarning?.Invoke(ex);
				}
			}
			return base.VisitChildren(node);
		}

		public override object VisitTerminal(ITerminalNode node)
		{
			switch (node.Symbol.Type)
			{
			case 29:
				onWarning?.Invoke(new CompileException(currentScript, node, "Use single =", StonescriptException.Level.Warning));
				break;
			case 45:
				onWarning?.Invoke(new CompileException(currentScript, node, "Use single &", StonescriptException.Level.Warning));
				break;
			case 44:
				onWarning?.Invoke(new CompileException(currentScript, node, "Use single |", StonescriptException.Level.Warning));
				break;
			case 41:
				onWarning?.Invoke(new CompileException(currentScript, node, "Use single !", StonescriptException.Level.Warning));
				break;
			}
			return base.VisitTerminal(node);
		}

		public override object VisitErrorNode(IErrorNode node)
		{
			if (node.GetText().Trim().Length == 0)
			{
				return null;
			}
			throw new CompileException(currentScript, node, "Invalid statement: \"" + node.Symbol.Text + "\".");
		}

		public override object VisitCmd_stmt([NotNull] StonescriptParser.Cmd_stmtContext context)
		{
			if (!cache)
			{
				return null;
			}
			string text = context.GetText();
			CacheSubstituteExpression?.Invoke(text);
			return text;
		}

		public override object VisitDecl_stmt([NotNull] StonescriptParser.Decl_stmtContext context)
		{
			string varId = ((context.ID() == null) ? null : GetId(context.ID()));
			string text = machine.ValidateVariableName(varId);
			if (text != null)
			{
				throw new CompileException(currentScript, context.VAR(), text);
			}
			return base.VisitDecl_stmt(context);
		}

		public override object VisitExpression([NotNull] StonescriptParser.ExpressionContext context)
		{
			return base.VisitExpression(context);
		}

		public override object VisitImport_stmt([NotNull] StonescriptParser.Import_stmtContext context)
		{
			if (compileImports)
			{
				string text = context.children[1].GetText();
				machine.CompileImport(text);
			}
			return base.VisitImport_stmt(context);
		}

		public override object VisitNew_stmt([NotNull] StonescriptParser.New_stmtContext context)
		{
			if (compileImports)
			{
				string text = context.children[1].GetText();
				machine.CompileImport(text);
			}
			return base.VisitNew_stmt(context);
		}
	}
}
