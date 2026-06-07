using System;

namespace Jundroo.Common.Expressions.Tokens
{
	public class SeperatorToken : Token
	{
		public override bool IsFinal => false;

		public SeperatorToken(string s)
		{
		}

		public override Func<T> GetFuncAs<T>(Context context)
		{
			throw new NotImplementedException();
		}
	}
}
