using System;
using System.Threading;
using Cysharp.Threading.Tasks;

public class AsyncObjectPool<T> : AsyncObjectPoolBase<T> where T : class
{
	private readonly Func<CancellationToken, UniTask<T>> _createFunc;

	private readonly Action<T> _onRent;

	private readonly Action<T> _onReturn;

	private readonly Action<T> _onDestroy;

	public AsyncObjectPool(Func<CancellationToken, UniTask<T>> createFunc, Action<T> onRent = null, Action<T> onReturn = null, Action<T> onDestroy = null)
	{
		_createFunc = createFunc;
		_onRent = onRent;
		_onReturn = onReturn;
		_onDestroy = onDestroy;
	}

	public AsyncObjectPool(Func<UniTask<T>> createFunc, Action<T> onRent = null, Action<T> onReturn = null, Action<T> onDestroy = null)
	{
		_createFunc = (CancellationToken _) => createFunc();
		_onRent = onRent;
		_onReturn = onReturn;
		_onDestroy = onDestroy;
	}

	protected override UniTask<T> CreateInstanceAsync(CancellationToken cancellationToken)
	{
		return _createFunc(cancellationToken);
	}

	protected override void OnRent(T instance)
	{
		_onRent?.Invoke(instance);
	}

	protected override void OnReturn(T instance)
	{
		_onReturn?.Invoke(instance);
	}

	protected override void OnDestroy(T instance)
	{
		_onDestroy?.Invoke(instance);
	}
}
