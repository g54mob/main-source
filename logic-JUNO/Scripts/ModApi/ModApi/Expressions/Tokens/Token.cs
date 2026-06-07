using System;
using System.Linq.Expressions;

namespace ModApi.Expressions.Tokens
{
	public abstract class Token<T> : Token
	{
		public override Type Type => typeof(T);

		public virtual Func<double[], T> GetFunc(Context context)
		{
			throw new NotImplementedException();
		}

		public override Func<double[], TTo> GetFuncAs<TTo>(Context context)
		{
			return Parser.ConvertIfNecessary<T, TTo>(GetFunc(context));
		}

		public override Delegate GetFuncNoData(Context context)
		{
			Func<double[], T> f1 = GetFunc(context);
			return (Func<T>)(() => f1(null));
		}
	}
	public abstract class Token
	{
		public Token Next;

		public Token Prev;

		public virtual bool IsFinal => false;

		public virtual Type Type => null;

		public virtual Expression GetExpression(Context context, ParameterExpression dataSlots)
		{
			throw new NotImplementedException();
		}

		public void Replace(Token toReplace)
		{
			Next = toReplace.Next;
			Prev = toReplace.Prev;
			toReplace.Next = null;
			toReplace.Prev = null;
			if (Next != null)
			{
				Next.Prev = this;
			}
			if (Prev != null)
			{
				Prev.Next = this;
			}
		}

		public abstract Func<double[], T> GetFuncAs<T>(Context context);

		public abstract Delegate GetFuncNoData(Context context);
	}
}
