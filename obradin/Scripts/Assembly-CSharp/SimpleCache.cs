using System.Collections.Generic;

public class SimpleCache<T> where T : new()
{
	public class Entry
	{
		public T value { get; protected set; }
	}

	private class EntryC : Entry
	{
		public bool inUse;

		public int index;

		public EntryC(int index_)
		{
			index = index_;
			base.value = new T();
			inUse = true;
		}
	}

	private List<EntryC> entries = new List<EntryC>();

	public Entry Alloc()
	{
		foreach (EntryC entry in entries)
		{
			if (!entry.inUse)
			{
				entry.inUse = true;
				return entry;
			}
		}
		EntryC entryC = new EntryC(entries.Count);
		entries.Add(entryC);
		return entryC;
	}

	public void Free(Entry entry)
	{
		EntryC entryC = (EntryC)entry;
		entries[entryC.index].inUse = false;
	}
}
