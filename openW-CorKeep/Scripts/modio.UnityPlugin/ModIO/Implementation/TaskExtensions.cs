using System.Threading.Tasks;

namespace ModIO.Implementation
{
	internal static class TaskExtensions
	{
		public static Result GetResult(this Task<Result> t)
		{
			return t.Result;
		}

		public static Result GetResult<T>(this Task<ResultAnd<T>> t)
		{
			return t.Result.result;
		}

		public static T GetValue<T>(this Task<ResultAnd<T>> t)
		{
			return t.Result.value;
		}
	}
}
