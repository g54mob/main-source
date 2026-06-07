using System;

namespace Jundroo.Common.Expressions.Tokens
{
	public class MemberAccessorToken : Token
	{
		public bool IsNullCoalescing { get; private set; }

		public MemberAccessorToken(bool isNullCoalescing)
		{
			IsNullCoalescing = isNullCoalescing;
		}

		public override Func<T> GetFuncAs<T>(Context context)
		{
			throw new NotImplementedException();
		}
	}
}
