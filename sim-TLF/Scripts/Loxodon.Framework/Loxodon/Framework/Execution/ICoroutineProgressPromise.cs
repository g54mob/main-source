using Loxodon.Framework.Asynchronous;

namespace Loxodon.Framework.Execution
{
	public interface ICoroutineProgressPromise<TProgress> : IProgressPromise<TProgress>, IPromise, ICoroutinePromise
	{
	}
	public interface ICoroutineProgressPromise<TProgress, TResult> : IProgressPromise<TProgress, TResult>, IProgressPromise<TProgress>, IPromise, IPromise<TResult>, ICoroutineProgressPromise<TProgress>, ICoroutinePromise
	{
	}
}
