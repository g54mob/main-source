using System;
using System.Collections.Generic;
using CLanguage.Compiler;
using CLanguage.Types;

namespace CLanguage.Syntax
{
	public class FuncallExpression : Expression
	{
		private class Overload
		{
			public readonly CType? CType;

			public readonly Action<EmitContext> Emit;

			public static readonly Action<EmitContext> NoEmit;

			public static readonly Overload Error;

			public Overload(CType? type, Action<EmitContext> emit)
			{
			}
		}

		public Expression Function { get; }

		public List<Expression> Arguments { get; }

		public FuncallExpression(Expression fun)
		{
		}

		public FuncallExpression(Expression fun, IEnumerable<Expression> args)
		{
		}

		public override CType GetEvaluatedCType(EmitContext ec)
		{
			return null;
		}

		protected override void DoEmit(EmitContext ec)
		{
		}

		private Overload ResolveOverload(Expression function, CType[] argTypes, EmitContext ec)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
