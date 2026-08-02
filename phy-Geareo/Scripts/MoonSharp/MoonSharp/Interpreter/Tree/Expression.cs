using System.Collections.Generic;
using MoonSharp.Interpreter.Execution;

namespace MoonSharp.Interpreter.Tree
{
	internal abstract class Expression : NodeBase
	{
		public Expression(ScriptLoadingContext lcontext)
			: base(null)
		{
		}

		public virtual string GetFriendlyDebugName()
		{
			return null;
		}

		public abstract DynValue Eval(ScriptExecutionContext context);

		public virtual SymbolRef FindDynamic(ScriptExecutionContext context)
		{
			return null;
		}

		internal static List<Expression> ExprListAfterFirstExpr(ScriptLoadingContext lcontext, Expression expr1)
		{
			return null;
		}

		internal static List<Expression> ExprList(ScriptLoadingContext lcontext)
		{
			return null;
		}

		internal static Expression Expr(ScriptLoadingContext lcontext)
		{
			return null;
		}

		internal static Expression SubExpr(ScriptLoadingContext lcontext, bool isPrimary)
		{
			return null;
		}

		internal static Expression SimpleExp(ScriptLoadingContext lcontext)
		{
			return null;
		}

		internal static Expression PrimaryExp(ScriptLoadingContext lcontext)
		{
			return null;
		}

		private static Expression PrefixExp(ScriptLoadingContext lcontext)
		{
			return null;
		}
	}
}
