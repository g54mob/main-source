using System;

public abstract class AkBaseArray<T> : IDisposable
{
	private IntPtr m_Buffer;

	public int Capacity { get; private set; }

	protected abstract int StructureSize { get; }

	public T this[int index]
	{
		get
		{
			return default(T);
		}
		set
		{
		}
	}

	public AkBaseArray(int capacity)
	{
	}

	public void Dispose()
	{
	}

	~AkBaseArray()
	{
	}

	public virtual int Count()
	{
		return 0;
	}

	protected virtual void DefaultConstructAtIntPtr(IntPtr address)
	{
	}

	protected virtual void ReleaseAllocatedMemoryFromReferenceAtIntPtr(IntPtr address)
	{
	}

	protected abstract T CreateNewReferenceFromIntPtr(IntPtr address);

	protected abstract void CloneIntoReferenceFromIntPtr(IntPtr address, T other);

	public IntPtr GetBuffer()
	{
		return (IntPtr)0;
	}

	protected IntPtr GetObjectPtr(int index)
	{
		return (IntPtr)0;
	}
}
