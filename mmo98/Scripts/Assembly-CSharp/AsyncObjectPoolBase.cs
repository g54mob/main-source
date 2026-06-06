using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

public abstract class AsyncObjectPoolBase<T> : IAsyncObjectPool<T> where T : class
{
	protected readonly Stack<T> Stack = new Stack<T>(32);

	protected readonly List<T> Rented = new List<T>(16);

	private bool _isDisposed;

	public int Count => Stack.Count;

	public int RentedCount => Rented.Count;

	public bool IsDisposed => _isDisposed;

	protected abstract UniTask<T> CreateInstanceAsync(CancellationToken cancellationToken);

	protected virtual void OnRent(T instance)
	{
	}

	protected virtual void OnReturn(T instance)
	{
	}

	protected virtual void OnDestroy(T instance)
	{
	}

	public virtual async UniTask<T> RentAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		ThrowIfDisposed();
		if (!Stack.TryPop(out var result))
		{
			result = await CreateInstanceAsync(cancellationToken);
		}
		cancellationToken.ThrowIfCancellationRequested();
		if (_isDisposed)
		{
			OnDestroy(result);
		}
		OnRent(result);
		if (result is IPoolRentListener poolRentListener)
		{
			poolRentListener.OnRent();
		}
		Rented.Add(result);
		return result;
	}

	public virtual void Return(T instance)
	{
		ThrowIfDisposed();
		if (instance == null)
		{
			throw new ArgumentNullException("instance");
		}
		Rented.Remove(instance);
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
		foreach (T item in Rented)
		{
			Return(item);
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
		foreach (T item in Rented)
		{
			OnDestroy(item);
		}
		Rented.Clear();
	}

	public async UniTask PrewarmAsync(int count, CancellationToken cancellationToken = default(CancellationToken))
	{
		ThrowIfDisposed();
		for (int i = 0; i < count; i++)
		{
			Return(await CreateInstanceAsync(cancellationToken));
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
