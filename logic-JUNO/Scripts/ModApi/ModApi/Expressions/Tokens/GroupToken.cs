using System;
using System.Text;

namespace ModApi.Expressions.Tokens
{
	internal class GroupToken : Token
	{
		public override bool IsFinal => false;

		internal Token First { get; set; }

		public GroupToken(Token content)
		{
			First = content;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Group:");
			for (Token token = First; token != null; token = token.Next)
			{
				stringBuilder.Append("\n");
				stringBuilder.Append("  ");
				stringBuilder.Append(token.ToString());
			}
			return stringBuilder.ToString();
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
