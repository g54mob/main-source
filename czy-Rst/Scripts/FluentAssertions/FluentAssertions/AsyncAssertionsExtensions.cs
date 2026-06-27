using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FluentAssertions.Specialized;

namespace FluentAssertions
{
	public static class AsyncAssertionsExtensions
	{
		public static async Task<AndWhichConstraint<GenericAsyncFunctionAssertions<T>, T>> WithResult<T>(this Task<AndWhichConstraint<GenericAsyncFunctionAssertions<T>, T>> task, T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AndWhichConstraint<GenericAsyncFunctionAssertions<T>, T> obj = await task;
			AssertionExtensions.Should(obj.Subject).Be(expected, because, becauseArgs);
			return obj;
		}

		public static async Task<AndWhichConstraint<TaskCompletionSourceAssertions<T>, T>> WithResult<T>(this Task<AndWhichConstraint<TaskCompletionSourceAssertions<T>, T>> task, T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AndWhichConstraint<TaskCompletionSourceAssertions<T>, T> obj = await task;
			AssertionExtensions.Should(obj.Subject).Be(expected, because, becauseArgs);
			return obj;
		}
	}
}
