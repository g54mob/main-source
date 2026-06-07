using System;
using System.Collections.Generic;

public abstract class ObjectPoolBase<T> : IObjectPool<T>, IDisposable where T : class
{
	protected readonly Stack<T> Stack = new Stack<T>(32);

	protected readonly List<T> RentedOut = new List<T>(16);

	private bool _isDisposed;

	public int Count => Stack.Count;

	public int RentedCount => RentedOut.Count;

	public IReadOnlyList<T> Rented => RentedOut;

	public bool IsDisposed => _isDisposed;

	protected abstract T CreateInstance();

	protected virtual void OnRent(T instance)
	{
	}

	protected virtual void OnReturn(T instance)
	{
	}

	protected virtual void OnDestroy(T instance)
	{
	}

	public virtual T Rent()
	{
		ThrowIfDisposed();
		if (!Stack.TryPop(out var result))
		{
			result = CreateInstance();
		}
		OnRent(result);
		if (result is IPoolRentListener poolRentListener)
		{
			poolRentListener.OnRent();
		}
		RentedOut.Add(result);
		return result;
	}

	public virtual void Return(T instance)
	{
		ThrowIfDisposed();
		if (instance == null)
		{
			throw new ArgumentNullException("instance");
		}
		RentedOut.Remove(instance);
		OnReturn(instance);
		if (instance is IPoolReturnListener poolReturnListener)
		{
			poolReturnListener.OnReturn();
		}
		Stack.Push(instance);
	}

	public virtual void ReturnAll()
	{
		ThrowIfDisposed();
		for (int num = RentedOut.Count - 1; num >= 0; num--)
		{
			Return(RentedOut[num]);
		}
	}

	public virtual void Clear()
	{
		ThrowIfDisposed();
		T result;
		while (Stack.TryPop(out result))
		{
			OnDestroy(result);
		}
		foreach (T item in RentedOut)
		{
			OnDestroy(item);
		}
		RentedOut.Clear();
	}

	public void Prewarm(int count)
	{
		ThrowIfDisposed();
		for (int i = 0; i < count; i++)
		{
			Return(CreateInstance());
		}
	}

	public virtual void Dispose()
	{
		if (!_isDisposed)
		{
			Clear();
			_isDisposed = true;
		}
	}

	protected void ThrowIfDisposed()
	{
		if (IsDisposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
	}
}
