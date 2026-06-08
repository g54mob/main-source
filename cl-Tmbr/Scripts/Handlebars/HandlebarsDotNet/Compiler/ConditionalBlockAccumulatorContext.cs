using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class ConditionalBlockAccumulatorContext : BlockAccumulatorContext
	{
		private enum TestType
		{
			Direct = 0,
			Reverse = 1
		}

		private static readonly HashSet<string> ValidHelperNames = new HashSet<string> { "if", "unless" };

		private readonly List<ConditionalExpression> _conditionalBlock = new List<ConditionalExpression>();

		private Expression _currentCondition;

		private List<Expression> _bodyBuffer = new List<Expression>();

		public sealed override string BlockName { get; protected set; }

		public ConditionalBlockAccumulatorContext(Expression startingNode)
			: base(startingNode)
		{
			startingNode = BlockAccumulatorContext.UnwrapStatement(startingNode);
			HelperExpression helperExpression = (HelperExpression)startingNode;
			TestType testType = ((helperExpression.HelperName[0] != '#') ? TestType.Reverse : TestType.Direct);
			BlockName = helperExpression.HelperName.Substring(1, helperExpression.HelperName.Length - 1);
			if (!ValidHelperNames.Contains(BlockName))
			{
				throw new HandlebarsCompilerException("Tried to convert " + BlockName + " expression to conditional block", helperExpression.Context);
			}
			BoolishExpression boolishExpression = HandlebarsExpression.Boolish(helperExpression.Arguments.Single());
			string blockName = BlockName;
			Expression currentCondition;
			if (!(blockName == "if"))
			{
				if (!(blockName == "unless"))
				{
					goto IL_00f2;
				}
				if (testType == TestType.Direct)
				{
					currentCondition = Expression.Not(boolishExpression);
				}
				else
				{
					if (testType != TestType.Reverse)
					{
						goto IL_00f2;
					}
					currentCondition = boolishExpression;
				}
			}
			else if (testType == TestType.Direct)
			{
				currentCondition = boolishExpression;
			}
			else
			{
				if (testType != TestType.Reverse)
				{
					goto IL_00f2;
				}
				currentCondition = Expression.Not(boolishExpression);
			}
			_currentCondition = currentCondition;
			return;
			IL_00f2:
			throw new HandlebarsCompilerException("Tried to convert " + BlockName + " expression to conditional block", helperExpression.Context);
		}

		public override void HandleElement(Expression item)
		{
			if (IsElseBlock(item))
			{
				_conditionalBlock.Add(Expression.IfThen(_currentCondition, SinglifyExpressions(_bodyBuffer)));
				if (IsElseIfBlock(item))
				{
					_currentCondition = GetElseIfTestExpression(item);
				}
				else
				{
					_currentCondition = null;
				}
				_bodyBuffer = new List<Expression>();
			}
			else
			{
				_bodyBuffer.Add(item);
			}
		}

		public override bool IsClosingElement(Expression item)
		{
			if (IsClosingNode(item))
			{
				if (_currentCondition != null)
				{
					_conditionalBlock.Add(Expression.IfThen(_currentCondition, SinglifyExpressions(_bodyBuffer)));
				}
				else
				{
					ConditionalExpression conditionalExpression = _conditionalBlock.Last();
					_conditionalBlock[_conditionalBlock.Count - 1] = Expression.IfThenElse(conditionalExpression.Test, conditionalExpression.IfTrue, SinglifyExpressions(_bodyBuffer));
				}
				return true;
			}
			return false;
		}

		public override Expression GetAccumulatedBlock()
		{
			ConditionalExpression conditionalExpression = null;
			foreach (ConditionalExpression item in _conditionalBlock.AsEnumerable().Reverse())
			{
				conditionalExpression = Expression.IfThenElse(item.Test, item.IfTrue, conditionalExpression ?? item.IfFalse);
			}
			return conditionalExpression;
		}

		private bool IsElseBlock(Expression item)
		{
			item = BlockAccumulatorContext.UnwrapStatement(item);
			if (item is HelperExpression)
			{
				return ((HelperExpression)item).HelperName == "else";
			}
			return false;
		}

		private bool IsElseIfBlock(Expression item)
		{
			item = BlockAccumulatorContext.UnwrapStatement(item);
			if (IsElseBlock(item))
			{
				return ((HelperExpression)item).Arguments.Count() == 2;
			}
			return false;
		}

		private Expression GetElseIfTestExpression(Expression item)
		{
			item = BlockAccumulatorContext.UnwrapStatement(item);
			return HandlebarsExpression.Boolish(((HelperExpression)item).Arguments.Skip(1).Single());
		}

		private bool IsClosingNode(Expression item)
		{
			item = BlockAccumulatorContext.UnwrapStatement(item);
			if (item is PathExpression pathExpression)
			{
				return pathExpression.Path == "/" + BlockName;
			}
			return false;
		}

		private static Expression SinglifyExpressions(IEnumerable<Expression> expressions)
		{
			if (expressions.IsMultiple())
			{
				return Expression.Block(expressions);
			}
			return expressions.SingleOrDefault() ?? Expression.Empty();
		}
	}
}
