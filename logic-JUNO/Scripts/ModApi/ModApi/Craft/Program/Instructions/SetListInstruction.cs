using System;
using System.Collections.Generic;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class SetListInstruction : ProgramInstruction
	{
		[ProgramNodeProperty]
		private string _op = string.Empty;

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

		public override ProgramInstruction Execute(IThreadContext context)
		{
			ExpressionResult expressionResult = GetExpression(0).Evaluate(context);
			List<ExpressionListItem> listForModification = expressionResult.GetListForModification();
			switch (_op)
			{
			case "add":
				ExecuteAdd(context, listForModification);
				break;
			case "clear":
				ExecuteClear(context, listForModification);
				break;
			case "insert":
				ExecuteInsert(context, listForModification);
				break;
			case "remove":
				ExecuteRemove(context, listForModification);
				break;
			case "reverse":
				ExecuteReverse(context, listForModification);
				break;
			case "set":
				ExecuteSet(context, listForModification);
				break;
			case "sort":
				ExecuteSort(context, listForModification);
				break;
			}
			expressionResult.OnListModified();
			return base.Execute(context);
		}

		private void ExecuteAdd(IThreadContext context, List<ExpressionListItem> list)
		{
			ExpressionResult expressionResult = GetExpression(1).Evaluate(context);
			if (expressionResult.ExpressionType == ExpressionType.List)
			{
				list.AddRange(expressionResult.ListValue);
			}
			else
			{
				list.Add((ExpressionListItem)expressionResult);
			}
		}

		private void ExecuteClear(IThreadContext context, List<ExpressionListItem> list)
		{
			list.Clear();
		}

		private void ExecuteInsert(IThreadContext context, List<ExpressionListItem> list)
		{
			ExpressionResult expressionResult = GetExpression(1).Evaluate(context);
			int num = (int)GetExpression(2).Evaluate(context).NumberValue;
			if (num >= 1 && num <= list.Count)
			{
				if (expressionResult.ExpressionType == ExpressionType.List)
				{
					list.InsertRange(num - 1, expressionResult.ListValue);
				}
				else
				{
					list.Insert(num - 1, (ExpressionListItem)expressionResult);
				}
			}
		}

		private void ExecuteRemove(IThreadContext context, List<ExpressionListItem> list)
		{
			int num = (int)GetExpression(1).Evaluate(context).NumberValue;
			if (num >= 1 && num <= list.Count)
			{
				list.RemoveAt(num - 1);
			}
		}

		private void ExecuteReverse(IThreadContext context, List<ExpressionListItem> list)
		{
			list.Reverse();
		}

		private void ExecuteSet(IThreadContext context, List<ExpressionListItem> list)
		{
			ExpressionResult expressionResult = GetExpression(1).Evaluate(context);
			int num = (int)GetExpression(2).Evaluate(context).NumberValue;
			if (num >= 1 && num <= list.Count)
			{
				list[num - 1] = (ExpressionListItem)expressionResult;
			}
		}

		private void ExecuteSort(IThreadContext context, List<ExpressionListItem> list)
		{
			list.Sort((ExpressionListItem a, ExpressionListItem b) => a.StringValue.CompareTo(b.StringValue));
		}
	}
}
