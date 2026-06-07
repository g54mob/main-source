using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Storage<T> : SerializedMonoBehaviour, ISavable
{
	[Serializable]
	public class StoredObjectData : ISavable
	{
		public T obj;

		[Savable("id", true, false)]
		public string id;

		private int maxAmount;

		[Savable("amount", true, false)]
		public int amount;

		public int MaxAmount
		{
			get
			{
				return maxAmount;
			}
			private set
			{
				maxAmount = value;
			}
		}

		public StoredObjectData(T obj, string id, int amount, int maxAmount = int.MaxValue)
		{
			this.obj = obj;
			this.id = id;
			this.amount = amount;
			if (maxAmount > 0)
			{
				MaxAmount = maxAmount;
			}
			else
			{
				MaxAmount = int.MaxValue;
			}
		}

		public int AddAmount(int amountToAdd)
		{
			int a = MaxAmount - amount;
			amount = Mathf.Min(amount + amountToAdd, MaxAmount);
			return Mathf.Min(a, amountToAdd);
		}

		public int RemoveAmount(int amountToRemove)
		{
			int num = amount;
			amount = Mathf.Max(amount - amountToRemove, 0);
			return num - amount;
		}

		public void OnSave()
		{
		}

		public void OnPreLoad()
		{
		}

		public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
		{
		}
	}

	public delegate void OnStoreObject(StoredObjectData storedObject, int storedAmount, string storeSourceID);

	public delegate void OnRemoveObject(StoredObjectData storedObject, int removedAmount);

	[Savable("storedObjects", false, false)]
	private List<StoredObjectData> storedObjects;

	[SerializeField]
	[Savable("size", true, false)]
	[Tooltip("Available \"slots\". Infinite if <= 0")]
	private int size = 5;

	[SerializeField]
	[Savable("stackSize", true, false)]
	[Tooltip("How many items can be stacked on each slot (size). Infinite if <= 0")]
	private int stackSize = 10;

	private bool storageEnabled = true;

	private Storage<T> currentStorage;

	[SerializeField]
	private Storage<T> externalStorage;

	public List<StoredObjectData> StoredObjects => CurrentStorage.storedObjects;

	public int Size
	{
		get
		{
			return CurrentStorage.size;
		}
		set
		{
			CurrentStorage.size = value;
		}
	}

	public int StackSize
	{
		get
		{
			return CurrentStorage.stackSize;
		}
		set
		{
			CurrentStorage.stackSize = value;
		}
	}

	public Storage<T> CurrentStorage
	{
		get
		{
			if (!currentStorage)
			{
				if (externalStorage != null)
				{
					CurrentStorage = externalStorage;
				}
				else
				{
					storedObjects = new List<StoredObjectData>();
					CurrentStorage = this;
				}
			}
			return currentStorage;
		}
		set
		{
			currentStorage = value;
		}
	}

	public bool StorageEnabled
	{
		get
		{
			return storageEnabled;
		}
		set
		{
			storageEnabled = value;
		}
	}

	public event OnStoreObject onStoreObject;

	public event OnRemoveObject onRemoveObject;

	protected virtual void Awake()
	{
	}

	protected StoredObjectData GetNotFullStoredObjectData(string id)
	{
		foreach (StoredObjectData storedObject in StoredObjects)
		{
			if (storedObject.id == id && storedObject.amount < storedObject.MaxAmount)
			{
				return storedObject;
			}
		}
		return null;
	}

	public int StoreObject(T objToStore, string id, int amount = 1, string storeSourceID = "")
	{
		int i = 0;
		StoredObjectData storedObjectData;
		for (storedObjectData = null; i < amount; i += storedObjectData.AddAmount(amount))
		{
			if (IsFull() && !CanStore(id, 1))
			{
				break;
			}
			storedObjectData = GetNotFullStoredObjectData(id);
			if (storedObjectData == null)
			{
				storedObjectData = new StoredObjectData(objToStore, id, 0, StackSize);
				StoredObjects.Add(storedObjectData);
			}
		}
		if (i > 0)
		{
			this.onStoreObject?.Invoke(storedObjectData, i, storeSourceID);
		}
		return i;
	}

	public T GetStoredObjectByID(string objectId)
	{
		T result = default(T);
		foreach (StoredObjectData storedObject in StoredObjects)
		{
			if (objectId == storedObject.id)
			{
				result = storedObject.obj;
				return result;
			}
		}
		return result;
	}

	public T GetStoredObjectAtIndex(int index)
	{
		T result = default(T);
		if (index >= 0 && index < StoredObjects.Count)
		{
			return StoredObjects[index].obj;
		}
		return result;
	}

	public int GetStoredObjectIndex(string objectId)
	{
		int result = -1;
		for (int i = 0; i < StoredObjects.Count; i++)
		{
			if (objectId == StoredObjects[i].id)
			{
				return i;
			}
		}
		return result;
	}

	public int RemoveStoredObjectByID(string objectId, int amountToRemove)
	{
		int num = 0;
		StoredObjectData storedObjectData = null;
		for (int num2 = StoredObjects.Count - 1; num2 >= 0; num2--)
		{
			if (objectId == StoredObjects[num2].id)
			{
				num += StoredObjects[num2].RemoveAmount(amountToRemove - num);
				storedObjectData = StoredObjects[num2];
				if (StoredObjects[num2].amount == 0)
				{
					StoredObjects.RemoveAt(num2);
				}
				if (num == amountToRemove)
				{
					break;
				}
			}
		}
		if (storedObjectData != null)
		{
			this.onRemoveObject?.Invoke(storedObjectData, num);
		}
		return num;
	}

	public int RemoveStoredObjectAtIndex(int index, int amountToRemove)
	{
		int num = 0;
		StoredObjectData storedObject = null;
		if (StoredObjects.Count > index)
		{
			num = StoredObjects[index].RemoveAmount(amountToRemove);
			storedObject = storedObjects[index];
			if (StoredObjects[index].amount == 0)
			{
				StoredObjects.RemoveAt(index);
			}
		}
		this.onRemoveObject?.Invoke(storedObject, num);
		return num;
	}

	public int GetStoredObjectAmount(string objectId)
	{
		int num = 0;
		foreach (StoredObjectData storedObject in StoredObjects)
		{
			if (objectId == storedObject.id)
			{
				num += storedObject.amount;
			}
		}
		return num;
	}

	public virtual bool CanStore(string objectId, int amount)
	{
		if (Size <= 0)
		{
			return true;
		}
		int num = (Size - StoredObjects.Count) * StackSize;
		if (num >= amount)
		{
			return true;
		}
		foreach (StoredObjectData storedObject in StoredObjects)
		{
			if (objectId == storedObject.id)
			{
				num += storedObject.MaxAmount - storedObject.amount;
			}
		}
		return num >= amount;
	}

	public bool IsFull()
	{
		if (Size > 0)
		{
			return StoredObjects.Count >= Size;
		}
		return false;
	}

	public bool IsEmpty()
	{
		return StoredObjects.Count == 0;
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public virtual void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
