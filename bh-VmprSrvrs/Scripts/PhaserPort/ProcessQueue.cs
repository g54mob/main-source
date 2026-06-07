using System.Collections.Generic;
using Unity.Profiling;

public class ProcessQueue<T>
{
	private List<T> _pending;

	private List<KeyValuePair<T, int>> _pendingInserts;

	private List<T> _active;

	private List<T> _destroy;

	private int _toProcess;

	private bool _checkQueue;

	private static readonly ProfilerMarker s_processQueueMarker;

	public T add(T item)
	{
		return default(T);
	}

	public T insert(T item, int position)
	{
		return default(T);
	}

	public T remove(T item)
	{
		return default(T);
	}

	public ProcessQueue<T> removeAll()
	{
		return null;
	}

	public List<T> Update()
	{
		return null;
	}

	private List<T> getActive()
	{
		return null;
	}

	private int length()
	{
		return 0;
	}

	public void destroy()
	{
	}
}
