using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class BlockHelperAccumulatorContext : BlockAccumulatorContext
	{
		private readonly HelperExpression _startingNode;

		private readonly bool _trimBefore;

		private readonly bool _trimAfter;

		private Expression _accumulatedBody;

		private Expression _accumulatedInversion;

		private List<Expression> _body = new List<Expression>();

		public sealed override string BlockName
		{
			get
			{
				return _startingNode.HelperName;
			}
			protected set
			{
				throw new NotSupportedException();
			}
		}

		public BlockHelperAccumulatorContext(Expression startingNode)
			: base(startingNode)
		{
			if (startingNode is StatementExpression statementExpression)
			{
				_trimBefore = statementExpression.TrimBefore;
				_trimAfter = statementExpression.TrimAfter;
			}
			startingNode = BlockAccumulatorContext.UnwrapStatement(startingNode);
			_startingNode = (HelperExpression)startingNode;
		}

		public override void HandleElement(Expression item)
		{
			if (IsInversionBlock(item))
			{
				_accumulatedBody = GetBlockBody();
				_body = new List<Expression>();
			}
			else
			{
				_body.Add(item);
			}
		}

		private bool IsInversionBlock(Expression item)
		{
			item = BlockAccumulatorContext.UnwrapStatement(item);
			if (item is HelperExpression)
			{
				return ((HelperExpression)item).HelperName == "else";
			}
			return false;
		}

		public override bool IsClosingElement(Expression item)
		{
			item = BlockAccumulatorContext.UnwrapStatement(item);
			return IsClosingNode(item);
		}

		private bool IsClosingNode(Expression item)
		{
			string text = _startingNode.HelperName.Replace("#", string.Empty).Replace("^", string.Empty).Replace("*", string.Empty);
			if (item is PathExpression pathExpression)
			{
				return pathExpression.Path == "/" + text;
			}
			return false;
		}

		public override Expression GetAccumulatedBlock()
		{
			if (_accumulatedBody == null)
			{
				_accumulatedBody = GetBlockBody();
				_accumulatedInversion = Expression.Block(Expression.Empty());
			}
			else if (_accumulatedInversion == null)
			{
				_accumulatedInversion = GetBlockBody();
			}
			BlockHelperExpression blockHelperExpression = HandlebarsExpression.BlockHelper(_startingNode.HelperName, _startingNode.Arguments.Where((Expression o) => o.NodeType != (ExpressionType)6013), _startingNode.Arguments.OfType<BlockParamsExpression>().SingleOrDefault() ?? BlockParamsExpression.Empty(), _accumulatedBody, _accumulatedInversion, _startingNode.IsRaw);
			if (_startingNode.IsRaw)
			{
				return HandlebarsExpression.Statement(blockHelperExpression, isEscaped: false, _trimBefore, _trimAfter);
			}
			return blockHelperExpression;
		}

		private Expression GetBlockBody()
		{
			if (!_body.Any())
			{
				return Expression.Block(Expression.Empty());
			}
			return Expression.Block(_body);
		}
	}
}
