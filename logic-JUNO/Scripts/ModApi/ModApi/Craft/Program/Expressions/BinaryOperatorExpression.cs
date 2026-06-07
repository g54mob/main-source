using System;
using UnityEngine;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class BinaryOperatorExpression : ProgramExpression
	{
		[ProgramNodeProperty]
		private string _op = "+";

		private ExpressionResult _result;

		public ProgramExpression ExpressionA => GetExpression(0);

		public ProgramExpression ExpressionB => GetExpression(1);

		public override bool IsBoolean => false;

		public string Operator
		{
			get
			{
				return _op;
			}
			set
			{
				_op = value;
			}
		}

		public BinaryOperatorExpression()
		{
			_result = new ExpressionResult();
		}

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			ExpressionResult expressionResult = ExpressionA.Evaluate(context);
			ExpressionResult expressionResult2 = ExpressionB.Evaluate(context);
			if (expressionResult.IsVectorOrVectorAsText || expressionResult2.IsVectorOrVectorAsText)
			{
				return EvaluateAsVectors(context, expressionResult, expressionResult2);
			}
			return EvaluateAsNumbers(context, expressionResult, expressionResult2);
		}

		private ExpressionResult EvaluateAsNumbers(IThreadContext context, ExpressionResult lhs, ExpressionResult rhs)
		{
			double numberValue = lhs.NumberValue;
			double numberValue2 = rhs.NumberValue;
			double numberValue3 = 0.0;
			switch (_op)
			{
			case "+":
				numberValue3 = numberValue + numberValue2;
				break;
			case "-":
				numberValue3 = numberValue - numberValue2;
				break;
			case "/":
				if (numberValue2 != 0.0)
				{
					numberValue3 = numberValue / numberValue2;
				}
				break;
			case "*":
				numberValue3 = numberValue * numberValue2;
				break;
			case "^":
				numberValue3 = System.Math.Pow(numberValue, numberValue2);
				break;
			case "rand":
				numberValue3 = UnityEngine.Random.Range((float)numberValue, (float)numberValue2);
				break;
			case "min":
				numberValue3 = Mathd.Min(numberValue, numberValue2);
				break;
			case "max":
				numberValue3 = Mathd.Max(numberValue, numberValue2);
				break;
			case "atan2":
				numberValue3 = Mathd.Atan2(numberValue, numberValue2);
				break;
			case "%":
				if (numberValue2 != 0.0)
				{
					numberValue3 = numberValue % numberValue2;
				}
				break;
			}
			_result.NumberValue = numberValue3;
			return _result;
		}

		private ExpressionResult EvaluateAsVectors(IThreadContext context, ExpressionResult lhs, ExpressionResult rhs)
		{
			switch (_op)
			{
			case "+":
				_result.VectorValue = lhs.VectorValue + rhs.VectorValue;
				break;
			case "-":
				_result.VectorValue = lhs.VectorValue - rhs.VectorValue;
				break;
			case "/":
				if (rhs.NumberValue != 0.0)
				{
					_result.VectorValue = lhs.VectorValue / rhs.NumberValue;
				}
				else
				{
					_result.VectorValue = Vector3d.zero;
				}
				break;
			case "*":
				if (lhs.IsVectorOrVectorAsText)
				{
					_result.VectorValue = lhs.VectorValue * rhs.NumberValue;
				}
				else
				{
					_result.VectorValue = lhs.NumberValue * rhs.VectorValue;
				}
				break;
			default:
				_result.VectorValue = Vector3d.zero;
				break;
			}
			return _result;
		}
	}
}
