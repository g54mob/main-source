using System;
using System.Threading;

public class ReadWriteLockUse : IDisposable
{
	public ReaderWriterLockSlim Lock;

	private readonly bool _locked;

	private readonly bool _write;

	public ReadWriteLockUse(ReaderWriterLockSlim l, bool write = false)
	{
		Lock = l;
		_write = write;
		if (_write)
		{
			Lock.EnterWriteLock();
			_locked = true;
		}
		else
		{
			_locked = Lock.TryEnterReadLock(-1);
		}
	}

	public void Dispose()
	{
		if (_locked)
		{
			if (_write)
			{
				Lock.ExitWriteLock();
			}
			else
			{
				Lock.ExitReadLock();
			}
		}
	}
}
