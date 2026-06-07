using System.Threading.Tasks;

namespace Stateless
{
	internal static class TaskResult
	{
		internal static readonly Task Done = FromResult(1);

		private static Task<T> FromResult<T>(T value)
		{
			TaskCompletionSource<T> taskCompletionSource = new TaskCompletionSource<T>();
			taskCompletionSource.SetResult(value);
			return taskCompletionSource.Task;
		}
	}
}
