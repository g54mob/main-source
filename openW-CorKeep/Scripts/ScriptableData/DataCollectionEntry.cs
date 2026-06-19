using System;
using UnityEngine;

[Serializable]
public struct DataCollectionEntry<T> where T : ScriptableDataBlock
{
	[SerializeField]
	private DataBlockRef<T> m_dataBlockRef;

	[SerializeReference]
	private CollectionEntryData m_data;

	public DataBlockRef<T> dataBlockRef => m_dataBlockRef;

	public CollectionEntryData data => m_data;

	public Type entryDataType => m_data?.GetType();

	public DataCollectionEntry(DataBlockRef<T> dataBlockRef, Type dataType)
	{
		m_dataBlockRef = dataBlockRef;
		m_data = null;
		if ((object)dataType != null)
		{
			if (dataType.IsSubclassOf(typeof(CollectionEntryData)))
			{
				m_data = Activator.CreateInstance(dataType) as CollectionEntryData;
			}
			else
			{
				Debug.LogError("dataType (" + dataType.Name + ") must inherit CollectionEntryData!");
			}
		}
	}
}
