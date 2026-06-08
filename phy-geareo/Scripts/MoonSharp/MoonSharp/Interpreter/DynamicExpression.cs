using MoonSharp.Interpreter.Tree.Expressions;

namespace MoonSharp.Interpreter
{
	public class DynamicExpression : IScriptPrivateResource
	{
		private DynamicExprExpression m_Exp;

		private DynValue m_Constant;

		public readonly string ExpressionCode;

		public Script OwnerScript { get; private set; }

		internal DynamicExpression(Script S, string strExpr, DynamicExprExpression expr)
		{
		}

		internal DynamicExpression(Script S, string strExpr, DynValue constant)
		{
		}

		public DynValue Evaluate(ScriptExecutionContext context = null)
		{
			return null;
		}

		public SymbolRef FindSymbol(ScriptExecutionContext context)
		{
			return null;
		}

		public bool IsConstant()
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}
	}
}
