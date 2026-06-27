using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions.Execution;
using FluentAssertions.Specialized;

namespace FluentAssertions
{
	public static class ExceptionAssertionsExtensions
	{
		public static async Task<ExceptionAssertions<TException>> WithMessage<TException>(this Task<ExceptionAssertions<TException>> task, string expectedWildcardPattern, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
		{
			return (await task).WithMessage(expectedWildcardPattern, because, becauseArgs);
		}

		public static async Task<ExceptionAssertions<TException>> Where<TException>(this Task<ExceptionAssertions<TException>> task, Expression<Func<TException, bool>> exceptionExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
		{
			return (await task).Where(exceptionExpression, because, becauseArgs);
		}

		public static async Task<ExceptionAssertions<TInnerException>> WithInnerException<TException, TInnerException>(this Task<ExceptionAssertions<TException>> task, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception where TInnerException : Exception
		{
			return (await task).WithInnerException<TInnerException>(because, becauseArgs);
		}

		public static async Task<ExceptionAssertions<Exception>> WithInnerException<TException>(this Task<ExceptionAssertions<TException>> task, Type innerException, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
		{
			return (await task).WithInnerException(innerException, because, becauseArgs);
		}

		public static async Task<ExceptionAssertions<TInnerException>> WithInnerExceptionExactly<TException, TInnerException>(this Task<ExceptionAssertions<TException>> task, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception where TInnerException : Exception
		{
			return (await task).WithInnerExceptionExactly<TInnerException>(because, becauseArgs);
		}

		public static async Task<ExceptionAssertions<Exception>> WithInnerExceptionExactly<TException>(this Task<ExceptionAssertions<TException>> task, Type innerException, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
		{
			return (await task).WithInnerExceptionExactly(innerException, because, becauseArgs);
		}

		public static ExceptionAssertions<TException> WithParameterName<TException>(this ExceptionAssertions<TException> parent, string paramName, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : ArgumentException
		{
			AssertionChain.GetOrCreate().ForCondition(parent.Which.ParamName == paramName).BecauseOf(because, becauseArgs)
				.FailWith("Expected exception with parameter name {0}{reason}, but found {1}.", paramName, parent.Which.ParamName);
			return parent;
		}

		public static async Task<ExceptionAssertions<TException>> WithParameterName<TException>(this Task<ExceptionAssertions<TException>> task, string paramName, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : ArgumentException
		{
			return (await task).WithParameterName(paramName, because, becauseArgs);
		}
	}
}
