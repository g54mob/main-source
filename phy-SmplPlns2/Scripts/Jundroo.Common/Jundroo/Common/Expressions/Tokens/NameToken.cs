using System;

namespace Jundroo.Common.Expressions.Tokens
{
	public class NameToken : Token
	{
		public override bool IsFinal => false;

		public string Name { get; set; }

		public NameToken(string name)
		{
			Name = name;
		}

		public override Func<T> GetFuncAs<T>(Context context)
		{
			throw new NotImplementedException();
		}
	}
}
