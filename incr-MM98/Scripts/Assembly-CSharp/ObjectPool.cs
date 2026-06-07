using System;

public class ObjectPool<T> : ObjectPoolBase<T> where T : class
{
	private readonly Func<T> _createFunc;

	private readonly Action<T> _onRent;

	private readonly Action<T> _onReturn;

	private readonly Action<T> _onDestroy;

	public ObjectPool(Func<T> createFunc, Action<T> onRent = null, Action<T> onReturn = null, Action<T> onDestroy = null)
	{
		_createFunc = createFunc;
		_onRent = onRent;
		_onReturn = onReturn;
		_onDestroy = onDestroy;
	}

	protected override T CreateInstance()
	{
		return _createFunc();
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
