using System;
using System.Linq.Expressions;
using ModApi.Expressions.Exceptions;

namespace ModApi.Expressions.Tokens
{
	internal class DataSlotToken : Token<double>
	{
		private int _index = -1;

		public int Index => _index;

		public override bool IsFinal => true;

		public DataSlotToken(int index)
		{
			_index = index;
		}

		public static Token Create(string res)
		{
			res = res.Substring(1, res.Length - 2);
			if (int.TryParse(res, out var result))
			{
				return new DataSlotToken(result);
			}
			return new NameToken(res);
		}

		public override Expression GetExpression(Context context, ParameterExpression dataSlots)
		{
			if (_index >= 10 || _index < 0)
			{
				throw new ExpressionCompileException($"Data slot index {_index} out of range");
			}
			return Expression.ArrayAccess(dataSlots, Expression.Constant(_index));
		}

		public override Func<double[], double> GetFunc(Context context)
		{
			if (_index >= 10 || _index < 0)
			{
				throw new ExpressionCompileException($"Data slot index {_index} out of range");
			}
			int index = _index;
			return (double[] data) => data[index];
		}

		public override string ToString()
		{
			return "[" + _index + "]";
		}
	}
}
