using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public abstract class Expression
	{
		public Location Location { get; protected set; }

		public Location EndLocation { get; protected set; }

		public bool HasError { get; set; }

		public virtual bool CanEmitPointer => false;

		public void Emit(EmitContext ec)
		{
		}

		public void EmitPointer(EmitContext ec)
		{
		}

		public abstract CType GetEvaluatedCType(EmitContext ec);

		protected abstract void DoEmit(EmitContext ec);

		protected virtual void DoEmitPointer(EmitContext ec)
		{
		}

		protected static CType GetPromotedType(Expression expr, string op, EmitContext ec)
		{
			return null;
		}

		protected static CType GetArithmeticType(Expression leftExpr, Expression rightExpr, string op, EmitContext ec)
		{
			return null;
		}

		public virtual Value EvalConstant(EmitContext ec)
		{
			return default(Value);
		}
	}
}
