using System;
using System.Text;

namespace Jundroo.Common.Expressions.Tokens
{
	public class GroupToken : Token
	{
		public Token First { get; set; }

		public override bool IsFinal => false;

		public GroupToken(Token content)
		{
			First = content;
		}

		public override Func<T> GetFuncAs<T>(Context context)
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Group:");
			for (Token token = First; token != null; token = token.Next)
			{
				stringBuilder.Append('\n');
				stringBuilder.Append("  ");
				stringBuilder.Append(token.ToString());
			}
			return stringBuilder.ToString();
		}
	}
}
