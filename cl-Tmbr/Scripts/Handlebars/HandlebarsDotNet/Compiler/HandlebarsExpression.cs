using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal abstract class HandlebarsExpression : Expression
	{
		public override Type Type => GetType();

		public override bool CanReduce { get; }

		public static HelperExpression Helper(string helperName, bool isBlock, IEnumerable<Expression> arguments, bool isRaw = false)
		{
			return new HelperExpression(helperName, isBlock, arguments, isRaw);
		}

		public static HelperExpression Helper(string helperName, bool isBlock, bool isRaw = false, IReaderContext context = null)
		{
			return new HelperExpression(helperName, isBlock, isRaw, context);
		}

		public static BlockHelperExpression BlockHelper(string helperName, IEnumerable<Expression> arguments, BlockParamsExpression blockParams, Expression body, Expression inversion, bool isRaw = false)
		{
			return new BlockHelperExpression(helperName, arguments, blockParams, body, inversion, isRaw);
		}

		public static PathExpression Path(string path)
		{
			return new PathExpression(path);
		}

		public static BlockParamsExpression BlockParams(string action, string blockParams)
		{
			return new BlockParamsExpression(action, blockParams);
		}

		public static StaticExpression Static(string value)
		{
			return new StaticExpression(value);
		}

		public static StatementExpression Statement(Expression body, bool isEscaped, bool trimBefore, bool trimAfter)
		{
			return new StatementExpression(body, isEscaped, trimBefore, trimAfter);
		}

		public static IteratorExpression Iterator(string helperName, Expression sequence, BlockParamsExpression blockParams, Expression template)
		{
			return new IteratorExpression(helperName, sequence, blockParams, template, Expression.Empty());
		}

		public static IteratorExpression Iterator(string helperName, Expression sequence, BlockParamsExpression blockParams, Expression template, Expression ifEmpty)
		{
			return new IteratorExpression(helperName, sequence, blockParams, template, ifEmpty);
		}

		public static PartialExpression Partial(Expression partialName)
		{
			return Partial(partialName, null);
		}

		public static PartialExpression Partial(Expression partialName, Expression argument)
		{
			return new PartialExpression(partialName, argument, null);
		}

		public static PartialExpression Partial(Expression partialName, Expression argument, Expression fallback)
		{
			return new PartialExpression(partialName, argument, fallback);
		}

		public static BoolishExpression Boolish(Expression condition)
		{
			return new BoolishExpression(condition);
		}

		public static SubExpressionExpression SubExpression(Expression expression)
		{
			return new SubExpressionExpression(expression);
		}

		public static HashParameterAssignmentExpression HashParameterAssignmentExpression(string name)
		{
			return new HashParameterAssignmentExpression(name);
		}

		public static HashParametersExpression HashParametersExpression(Dictionary<string, Expression> parameters)
		{
			return new HashParametersExpression(parameters);
		}

		public static CommentExpression Comment(string value)
		{
			return new CommentExpression(value);
		}
	}
}
