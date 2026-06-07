using System.Collections.Generic;
using Factory;
using Factory.Pools;

[Serializable(1)]
public class Journal<T> : IReleasedFromScopeHandler, IReusable
{
	private List<T> _entries = new List<T>();

	public int EntryCount => _entries.Count;

	public void Record(T entry)
	{
		_entries.Add(entry);
	}

	public T GetEntry(int entryIndex)
	{
		return _entries[entryIndex];
	}

	public void Clear()
	{
		_entries.Clear();
	}

	public void OnReleasedFromScope(IScope scope)
	{
		foreach (T entry in _entries)
		{
			scope.Release(entry);
		}
		_entries.Clear();
	}

	public void Reset()
	{
		Clear();
	}
}
