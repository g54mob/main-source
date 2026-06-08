using System;
using System.Linq;
using System.Linq.Expressions;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.Compiler
{
	internal class BlockParamsExpression : HandlebarsExpression
	{
		public readonly BlockParam BlockParam;

		public override ExpressionType NodeType { get; } = (ExpressionType)6013;

		public override Type Type { get; } = typeof(BlockParam);

		public new static BlockParamsExpression Empty()
		{
			return new BlockParamsExpression(null);
		}

		private BlockParamsExpression(BlockParam blockParam)
		{
			BlockParam = blockParam;
		}

		public BlockParamsExpression(string action, string blockParams)
			: this(new BlockParam
			{
				Action = action,
				Parameters = blockParams.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(ChainSegment.Create).ToArray()
			})
		{
		}

		protected override Expression Accept(ExpressionVisitor visitor)
		{
			return visitor.Visit(Expression.Constant(BlockParam, typeof(BlockParam)));
		}
	}
}
