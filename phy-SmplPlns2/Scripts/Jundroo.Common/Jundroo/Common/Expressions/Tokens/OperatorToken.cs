using System;
using Jundroo.Common.Expressions.Exceptions;

namespace Jundroo.Common.Expressions.Tokens
{
	public class OperatorToken : Token
	{
		public Operator Op { get; set; }

		public OperatorToken(string op)
		{
			switch (op)
			{
			case "+":
				Op = Operator.Plus;
				break;
			case "-":
				Op = Operator.Minus;
				break;
			case "*":
				Op = Operator.Multiply;
				break;
			case "/":
				Op = Operator.Divide;
				break;
			case "&":
				Op = Operator.And;
				break;
			case "|":
				Op = Operator.Or;
				break;
			case "!":
				Op = Operator.Not;
				break;
			case ">":
				Op = Operator.Gt;
				break;
			case "<":
				Op = Operator.Lt;
				break;
			case ">=":
				Op = Operator.Gte;
				break;
			case "<=":
				Op = Operator.Lte;
				break;
			case "=":
				Op = Operator.Equal;
				break;
			case "!=":
				Op = Operator.NotEqual;
				break;
			case "?":
				Op = Operator.ConditionalSelect;
				break;
			case ":":
				Op = Operator.ConditionalSeparator;
				break;
			case "%":
				Op = Operator.Modulus;
				break;
			default:
				throw new ExpressionCompileException("Unknown Operator: " + op);
			}
		}

		public override Func<T> GetFuncAs<T>(Context context)
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return Op.ToString();
		}
	}
}
