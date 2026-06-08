using System.Collections.Generic;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class BlockHelperExpression : HelperExpression
	{
		public Expression Body { get; }

		public Expression Inversion { get; }

		public new BlockParamsExpression BlockParams { get; }

		public override ExpressionType NodeType => (ExpressionType)6002;

		public BlockHelperExpression(string helperName, IEnumerable<Expression> arguments, Expression body, Expression inversion, bool isRaw = false)
			: this(helperName, arguments, BlockParamsExpression.Empty(), body, inversion, isRaw)
		{
		}

		public BlockHelperExpression(string helperName, IEnumerable<Expression> arguments, BlockParamsExpression blockParams, Expression body, Expression inversion, bool isRaw = false)
			: base(helperName, isBlock: true, arguments, isRaw)
		{
			Body = body;
			Inversion = inversion;
			BlockParams = blockParams;
			base.IsBlock = true;
		}
	}
}
