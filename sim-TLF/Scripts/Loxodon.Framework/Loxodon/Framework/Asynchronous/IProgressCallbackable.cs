using System;

namespace Loxodon.Framework.Asynchronous
{
	public interface IProgressCallbackable<TProgress>
	{
		void OnCallback(Action<IProgressResult<TProgress>> callback);

		void OnProgressCallback(Action<TProgress> callback);
	}
	public interface IProgressCallbackable<TProgress, TResult>
	{
		void OnCallback(Action<IProgressResult<TProgress, TResult>> callback);

		void OnProgressCallback(Action<TProgress> callback);
	}
}
