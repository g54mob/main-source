using System;
using System.Linq.Expressions;

namespace Jundroo.Common.Expressions.Tokens
{
	public abstract class Token<T> : Token
	{
		public override Type Type => typeof(T);

		public virtual Func<T> GetFunc(Context context)
		{
			throw new NotImplementedException();
		}

		public override Func<TTo> GetFuncAs<TTo>(Context context)
		{
			return Parser.ConvertIfNecessary<T, TTo>(GetFunc(context));
		}
	}
	public abstract class Token
	{
		public Token Next;

		public Token Prev;

		public virtual Type Type => null;

		public virtual bool IsFinal => false;

		public virtual Expression GetExpression(Context context)
		{
			throw new NotImplementedException();
		}

		public abstract Func<T> GetFuncAs<T>(Context context);
	}
}
