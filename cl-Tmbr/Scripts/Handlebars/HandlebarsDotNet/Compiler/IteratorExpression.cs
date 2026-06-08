using System;
using System.Linq;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class IteratorExpression : BlockHelperExpression
	{
		public Expression Sequence { get; }

		public Expression Template { get; }

		public Expression IfEmpty { get; }

		public override Type Type => typeof(void);

		public override ExpressionType NodeType => (ExpressionType)6005;

		public IteratorExpression(string helperName, Expression sequence, BlockParamsExpression blockParams, Expression template, Expression ifEmpty)
			: base(helperName, Enumerable.Empty<Expression>(), blockParams, template, ifEmpty)
		{
			Sequence = sequence;
			Template = template;
			IfEmpty = ifEmpty;
		}
	}
}
