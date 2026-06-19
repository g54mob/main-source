using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Execution
{
	public interface ICoroutinePromise : IPromise
	{
		void AddCoroutine(Coroutine coroutine);
	}
	public interface ICoroutinePromise<TResult> : IPromise<TResult>, IPromise, ICoroutinePromise
	{
	}
}
