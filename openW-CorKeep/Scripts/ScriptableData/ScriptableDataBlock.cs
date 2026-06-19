using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ScriptableDataBlock : ScriptableObject
{
	[Serializable]
	public struct DynamicCollections
	{
		[SerializeField]
		private List<DataCollectionEntry<ScriptableDataBlock>> m_list;

		public int Count => m_list.Count;

		public DataCollectionEntry<ScriptableDataBlock> this[int index]
		{
			get
			{
				return m_list[index];
			}
			set
			{
				m_list[index] = value;
			}
		}

		public static DynamicCollections empty => new DynamicCollections
		{
			m_list = new List<DataCollectionEntry<ScriptableDataBlock>>()
		};

		public int FindIndex(Predicate<DataCollectionEntry<ScriptableDataBlock>> match)
		{
			return m_list.FindIndex(match);
		}

		public void Add(DataCollectionEntry<ScriptableDataBlock> item)
		{
			m_list.Add(item);
		}

		public void RemoveAt(int index)
		{
			m_list.RemoveAt(index);
		}
	}

	[Serializable]
	public enum CollectionReferenceType
	{
		Static = 1,
		Dynamic = 2,
		Any = 3
	}

	[SerializeField]
	[HideInInspector]
	internal DataBlockRef<ScriptableDataBlock> m_overload;

	[SerializeField]
	[HideInInspector]
	[FormerlySerializedAs("m_guid")]
	private DataBlockAddress m_address;

	[SerializeField]
	private DynamicCollections m_dynamicCollections = DynamicCollections.empty;

	private static List<Type> s_cachedTypes;

	public DataBlockAddress address => m_address;

	public int dynamicCollectionsCount => m_dynamicCollections.Count;

	public static List<Type> types
	{
		get
		{
			if (s_cachedTypes == null)
			{
				s_cachedTypes = new List<Type>();
				Type typeFromHandle = typeof(ScriptableDataBlock);
				Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				for (int i = 0; i < assemblies.Length; i++)
				{
					Type[] array = assemblies[i].GetTypes();
					foreach (Type type in array)
					{
						if (type.IsClass && type.IsSubclassOf(typeFromHandle))
						{
							if (dictionary.TryGetValue(type.Name, out var value))
							{
								Debug.LogError($"The data block type {type} already exists in another namespace or assembly as {value}. Data block type names must be globally unique. {type} will be skipped.");
								continue;
							}
							s_cachedTypes.Add(type);
							dictionary.Add(type.Name, type);
						}
					}
				}
			}
			return s_cachedTypes;
		}
	}

	public virtual string errorLabel => null;

	public virtual string warningLabel => null;

	public DataCollectionEntry<ScriptableDataBlock> GetDynamicCollection(int i)
	{
		return m_dynamicCollections[i];
	}

	public DataCollectionEntry<ScriptableDataBlock> GetDynamicCollection(DataBlockAddress collectionAddress)
	{
		return m_dynamicCollections[FindDynamicIndex(collectionAddress)];
	}

	protected virtual void OnStart()
	{
	}

	public int FindDynamicIndex(DataBlockAddress collectionAddress)
	{
		return m_dynamicCollections.FindIndex((DataCollectionEntry<ScriptableDataBlock> x) => x.dataBlockRef.address == collectionAddress);
	}

	public bool IsPartOf(DataBlockAddress collectionAddress, CollectionReferenceType referenceType = CollectionReferenceType.Any)
	{
		bool flag = false;
		if ((referenceType & CollectionReferenceType.Static) == CollectionReferenceType.Static && ScriptableData.TryGetDataBlock<DataBlockCollection>(collectionAddress, out var dataBlock))
		{
			flag = flag || dataBlock.HasStaticReferenceTo(m_address);
		}
		if ((referenceType & CollectionReferenceType.Dynamic) == CollectionReferenceType.Dynamic)
		{
			flag = flag || m_dynamicCollections.FindIndex((DataCollectionEntry<ScriptableDataBlock> x) => x.dataBlockRef.address == collectionAddress) >= 0;
		}
		return flag;
	}

	public bool IsPartOf(DataBlockCollection collection, CollectionReferenceType referenceType = CollectionReferenceType.Any)
	{
		return IsPartOf(collection.address, referenceType);
	}

	private void ValidateDynamicCollections()
	{
	}
}
