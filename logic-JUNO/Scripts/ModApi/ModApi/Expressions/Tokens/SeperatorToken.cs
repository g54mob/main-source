using System;

namespace ModApi.Expressions.Tokens
{
	internal class SeperatorToken : Token
	{
		public override bool IsFinal => false;

		public SeperatorToken(string s)
		{
		}

		public override Func<double[], T> GetFuncAs<T>(Context context)
		{
			throw new NotImplementedException();
		}

		public override Delegate GetFuncNoData(Context context)
		{
			throw new NotImplementedException();
		}
	}
}
