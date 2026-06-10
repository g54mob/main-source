using System.Threading.Tasks;

namespace ModIO.Implementation
{
	internal static class TaskExtensions
	{
		public static Result GetResult(this Task<Result> t)
		{
			return default(Result);
		}

		public static Result GetResult<T>(this Task<ResultAnd<T>> t)
		{
			return default(Result);
		}

		public static T GetValue<T>(this Task<ResultAnd<T>> t)
		{
			return default(T);
		}
	}
}
