using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class DataBlockCollection : ScriptableDataBlock, IEnumerable
{
	public abstract Type collectionType { get; }

	public abstract int Count { get; }

	public virtual bool isRuntimeInitialized => false;

	public virtual Type entryDataType => null;

	public virtual bool hasBeenSorted => false;

	public abstract bool HasStaticReferenceTo(DataBlockAddress address);

	public abstract bool HasStaticReferenceTo(ScriptableDataBlock dataBlock);

	public abstract void Initialize(IEnumerable<ScriptableDataBlock> allDataBlocks);

	public abstract IEnumerator GetEnumerator();

	public abstract CollectionEntryData GetEntryData(int index);

	public abstract CollectionEntryData GetEntryData(ScriptableDataBlock dataBlock);

	protected virtual void OnInitialized()
	{
	}

	protected abstract void ValidateStatic();

	public abstract void Sort();
}
[DataBlockPicker(DataBlockPickerType.Dropdown)]
public abstract class DataBlockCollection<T> : DataBlockCollection, ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T> where T : ScriptableDataBlock
{
	[SerializeField]
	private List<DataCollectionEntry<T>> m_staticReferences = new List<DataCollectionEntry<T>>();

	private bool m_isRuntimeInitialized;

	private List<T> m_runtimeList;

	private List<CollectionEntryData> m_runtimeEntryData;

	private Dictionary<ScriptableDataBlock, CollectionEntryData> m_runtimeEntryDataLookup;

	private List<int> m_sortIndices;

	private bool m_hasBeenSorted;

	private const string MODIFICATION_ERROR = "Data block collections cannot be modified!";

	public sealed override Type collectionType => typeof(T);

	public bool IsFixedSize => true;

	public bool IsReadOnly => true;

	public sealed override int Count
	{
		get
		{
			if (!m_isRuntimeInitialized)
			{
				return -1;
			}
			return m_runtimeList.Count;
		}
	}

	public sealed override bool isRuntimeInitialized => m_isRuntimeInitialized;

	public sealed override bool hasBeenSorted => m_hasBeenSorted;

	public T this[int index]
	{
		get
		{
			if (!m_isRuntimeInitialized)
			{
				return null;
			}
			return m_runtimeList[index];
		}
		set
		{
			throw new NotSupportedException("Data block collections cannot be modified!");
		}
	}

	public bool IsSynchronized => false;

	public object SyncRoot
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public sealed override CollectionEntryData GetEntryData(int index)
	{
		return m_runtimeEntryData[index];
	}

	public sealed override CollectionEntryData GetEntryData(ScriptableDataBlock dataBlock)
	{
		if (!m_runtimeEntryDataLookup.TryGetValue(dataBlock, out var value))
		{
			Debug.LogError("Unable to get entry data for " + (dataBlock?.name ?? "NULL") + " in collection " + base.name + ": The data block is not part of the collection.");
		}
		return value;
	}

	public override void Sort()
	{
		if (RuntimeSortCheck())
		{
			ApplySort((int i, int j) => Comparer<T>.Default.Compare(m_runtimeList[i], m_runtimeList[j]));
		}
	}

	public void Sort(IComparer<T> comparer)
	{
		if (RuntimeSortCheck())
		{
			ApplySort((int i, int j) => comparer.Compare(m_runtimeList[i], m_runtimeList[j]));
		}
	}

	public void Sort(Comparison<T> comparison)
	{
		if (RuntimeSortCheck())
		{
			ApplySort((int i, int j) => comparison(m_runtimeList[i], m_runtimeList[j]));
		}
	}

	public void Sort(int index, int count, IComparer<T> comparer)
	{
		if (RuntimeSortCheck())
		{
			ApplySort((int i, int j) => comparer.Compare(m_runtimeList[i], m_runtimeList[j]), index, count);
		}
	}

	private bool RuntimeSortCheck()
	{
		if (m_isRuntimeInitialized)
		{
			return true;
		}
		Debug.LogError("Collections can only be sorted at runtime!");
		return false;
	}

	private void ApplySort(Comparison<int> indexCompare, int index = 0, int count = -1)
	{
		InitializeSortIndices();
		if (count < 0)
		{
			count = m_sortIndices.Count - index;
		}
		m_sortIndices.Sort(index, count, Comparer<int>.Create(indexCompare));
		ReorderList<T>(m_runtimeList, m_sortIndices);
		if (m_runtimeEntryData != null)
		{
			ReorderList<CollectionEntryData>(m_runtimeEntryData, m_sortIndices);
		}
		m_hasBeenSorted = true;
		static void ReorderList<U>(List<U> list, List<int> sortedIndices)
		{
			List<U> list2 = new List<U>(list.Count);
			for (int i = 0; i < sortedIndices.Count; i++)
			{
				list2.Add(list[sortedIndices[i]]);
			}
			list.Clear();
			list.AddRange(list2);
		}
	}

	private void InitializeSortIndices()
	{
		if (m_sortIndices == null)
		{
			m_sortIndices = new List<int>(m_runtimeList.Count);
		}
		m_sortIndices.Clear();
		for (int i = 0; i < m_runtimeList.Count; i++)
		{
			m_sortIndices.Add(i);
		}
	}

	protected sealed override void ValidateStatic()
	{
	}

	public sealed override bool HasStaticReferenceTo(DataBlockAddress address)
	{
		return m_staticReferences.FindIndex((DataCollectionEntry<T> x) => x.dataBlockRef.address == address) >= 0;
	}

	public sealed override bool HasStaticReferenceTo(ScriptableDataBlock dataBlock)
	{
		return HasStaticReferenceTo(dataBlock.address);
	}

	public sealed override void Initialize(IEnumerable<ScriptableDataBlock> allDataBlocks)
	{
		if (!ScriptableData.isInitializingCollections)
		{
			Debug.LogError("Initializing collection from outside of ScriptableData.OnLoadCompleted. This is not allowed.");
			return;
		}
		m_runtimeList = new List<T>();
		m_runtimeEntryData = null;
		m_runtimeEntryDataLookup = null;
		if ((object)entryDataType != null)
		{
			if (entryDataType.IsSubclassOf(typeof(CollectionEntryData)))
			{
				m_runtimeEntryData = new List<CollectionEntryData>();
				m_runtimeEntryDataLookup = new Dictionary<ScriptableDataBlock, CollectionEntryData>();
			}
			else
			{
				Debug.LogError("entryDataType (" + entryDataType.Name + ") must inherit from CollectionEntryData!");
			}
		}
		foreach (DataCollectionEntry<T> staticReference in m_staticReferences)
		{
			T val = staticReference.dataBlockRef.Get();
			if (val == null)
			{
				Debug.LogError("Null static entry in " + base.name, this);
			}
			else if (m_runtimeEntryDataLookup == null || !m_runtimeEntryDataLookup.ContainsKey(val))
			{
				m_runtimeList.Add(val);
				m_runtimeEntryData?.Add(staticReference.data);
				m_runtimeEntryDataLookup?.Add(val, staticReference.data);
			}
		}
		foreach (T item in allDataBlocks.Where((ScriptableDataBlock x) => collectionType.IsAssignableFrom(x.GetType()) && x.IsPartOf(base.address, CollectionReferenceType.Dynamic)))
		{
			if (m_runtimeEntryDataLookup == null || !m_runtimeEntryDataLookup.ContainsKey(item))
			{
				m_runtimeList.Add(item);
				CollectionEntryData data = item.GetDynamicCollection(base.address).data;
				m_runtimeEntryData?.Add(data);
				m_runtimeEntryDataLookup?.Add(item, data);
			}
		}
		m_isRuntimeInitialized = true;
		OnInitialized();
	}

	public void CopyTo(T[] array, int index)
	{
		m_runtimeList.CopyTo(array, index);
	}

	public int IndexOf(T value)
	{
		return m_runtimeList.IndexOf(value);
	}

	public bool Contains(T value)
	{
		return m_runtimeList.Contains(value);
	}

	public sealed override IEnumerator GetEnumerator()
	{
		return m_runtimeList.GetEnumerator();
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return m_runtimeList.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		if (!m_isRuntimeInitialized)
		{
			return null;
		}
		return m_runtimeList.GetEnumerator();
	}

	public void Clear()
	{
		throw new NotSupportedException("Data block collections cannot be modified!");
	}

	public void Insert(int index, T value)
	{
		throw new NotSupportedException("Data block collections cannot be modified!");
	}

	public void RemoveAt(int index)
	{
		throw new NotSupportedException("Data block collections cannot be modified!");
	}

	public void Add(T item)
	{
		throw new NotSupportedException("Data block collections cannot be modified!");
	}

	public bool Remove(T item)
	{
		throw new NotSupportedException("Data block collections cannot be modified!");
	}
}
