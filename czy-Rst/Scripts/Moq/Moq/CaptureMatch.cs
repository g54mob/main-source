using System;
using System.Linq.Expressions;

namespace Moq
{
	public class CaptureMatch<T> : Match<T>
	{
		private static readonly Predicate<T> matchAllPredicate = (T _) => true;

		public CaptureMatch(Action<T> captureCallback)
			: base(matchAllPredicate, (Expression<Func<T>>)(() => It.IsAny<T>()), captureCallback)
		{
		}

		public CaptureMatch(Action<T> captureCallback, Expression<Func<T, bool>> predicate)
			: base(BuildCondition(predicate), (Expression<Func<T>>)(() => It.Is(predicate)), captureCallback)
		{
		}

		private static Predicate<T> BuildCondition(Expression<Func<T, bool>> predicateExpression)
		{
			Func<T, bool> predicate = predicateExpression.CompileUsingExpressionCompiler();
			return (T value) => predicate(value);
		}
	}
}
