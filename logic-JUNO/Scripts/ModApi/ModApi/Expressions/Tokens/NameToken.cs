using System;

namespace ModApi.Expressions.Tokens
{
	internal class NameToken : Token
	{
		public override bool IsFinal => false;

		public string Name { get; set; }

		public NameToken(string name)
		{
			Name = name;
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
