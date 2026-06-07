using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Jundroo.Common.Expressions.Tokens
{
	public static class ConstantToken
	{
		private static readonly Regex UnescapeRegex = new Regex("\\\\(.)");

		public static Token CreateFromNumber(string value)
		{
			return new ConstantToken<float>(float.Parse(value));
		}

		public static Token CreateFromObject(object value)
		{
			Type type = value.GetType();
			return (Token)Activator.CreateInstance(typeof(ConstantToken<>).MakeGenericType(type), value);
		}

		public static Token CreateFromStringLiteral(string match)
		{
			string input = match.Substring(1, match.Length - 2);
			input = UnescapeRegex.Replace(input, "$1");
			return new ConstantToken<string>(input);
		}
	}
	public class ConstantToken<T> : Token<T>
	{
		public override bool IsFinal => true;

		public T Value { get; set; }

		public ConstantToken(T val)
		{
			Value = val;
		}

		public override Expression GetExpression(Context context)
		{
			return Expression.Constant(Value);
		}

		public override Func<T> GetFunc(Context context)
		{
			return () => Value;
		}

		public override string ToString()
		{
			return "[" + Value?.ToString() + "]";
		}
	}
}
