using System;
using System.Collections.Generic;

namespace ModApi.Craft.Program.Expressions
{
	[Serializable]
	public class ListOperatorExpression : ProgramExpression
	{
		[ProgramNodeProperty]
		private string _op;

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

		public override ExpressionResult Evaluate(IThreadContext context)
		{
			ExpressionResult result = null;
			switch (_op)
			{
			case "create":
				result = EvaluteCreate(context);
				break;
			case "get":
				result = EvaluteGet(context);
				break;
			case "index":
				result = EvaluteIndex(context);
				break;
			case "length":
				result = EvaluteLength(context);
				break;
			}
			return result;
		}

		private ExpressionResult EvaluteCreate(IThreadContext context)
		{
			string[] array = GetExpression(0).Evaluate(context).TextValue.Split(new char[1] { ',' });
			List<ExpressionListItem> list = new List<ExpressionListItem>();
			string[] array2 = array;
			foreach (string text in array2)
			{
				list.Add(text.Trim());
			}
			return new ExpressionResult(list);
		}

		private ExpressionResult EvaluteGet(IThreadContext context)
		{
			IReadOnlyList<ExpressionListItem> list = GetList(context);
			int num = (int)GetExpression(1).Evaluate(context).NumberValue;
			ExpressionResult expressionResult = new ExpressionResult();
			if (num >= 1 && num <= list.Count)
			{
				list[num - 1].Apply(expressionResult);
			}
			else
			{
				expressionResult.TextValue = string.Empty;
			}
			return expressionResult;
		}

		private ExpressionResult EvaluteIndex(IThreadContext context)
		{
			IReadOnlyList<ExpressionListItem> list = GetList(context);
			string textValue = GetExpression(1).Evaluate(context).TextValue;
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].StringValue == textValue)
				{
					num = i + 1;
					break;
				}
			}
			return new ExpressionResult
			{
				NumberValue = num
			};
		}

		private ExpressionResult EvaluteLength(IThreadContext context)
		{
			IReadOnlyList<ExpressionListItem> list = GetList(context);
			return new ExpressionResult
			{
				NumberValue = list.Count
			};
		}

		private IReadOnlyList<ExpressionListItem> GetList(IThreadContext context)
		{
			return GetExpression(0).Evaluate(context).ListValue;
		}
	}
}
