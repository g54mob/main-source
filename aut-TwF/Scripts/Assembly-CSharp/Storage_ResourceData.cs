using System;
using System.Collections.Generic;
using UnityEngine;

public class Storage_ResourceData : Storage<ResourceData>
{
	public enum EStoreSource
	{
		None = 0,
		Production = 1,
		Refund = 2,
		Chest = 3,
		Enemy = 4,
		Effect = 5,
		Trade = 6,
		LoadGame = 7
	}

	[SerializeField]
	private Dictionary<string, int> filters;

	[SerializeField]
	[Tooltip("Si es true, los objetos que no se puedan almacenar porque no cumplen los requisitos del filter se destruirán")]
	private bool destroyUnfilteredObjects;

	public bool DestroyUnfilteredObjects => destroyUnfilteredObjects;

	public event Action<string, bool> onCanStoreFailed;

	protected override void Awake()
	{
		base.Awake();
		filters = new Dictionary<string, int>();
	}

	public int StoreObject(ResourceData objToStore, int amount = 1, EStoreSource storeSource = EStoreSource.None)
	{
		return StoreObject(objToStore, objToStore.Id, amount, storeSource.ToString());
	}

	public void ClearFilters()
	{
		filters.Clear();
	}

	public void AddFilter(string resourceId, int maxAmount)
	{
		filters.Add(resourceId, maxAmount);
	}

	public bool HasFilter(string resourceId)
	{
		if (filters != null)
		{
			return filters.ContainsKey(resourceId);
		}
		return false;
	}

	public override bool CanStore(string objectId, int amount)
	{
		if (!base.StorageEnabled)
		{
			return false;
		}
		bool flag = true;
		bool flag2 = false;
		if (filters != null && filters.Count > 0)
		{
			if (!filters.ContainsKey(objectId))
			{
				flag = false;
			}
			else if (GetStoredObjectAmount(objectId) >= filters[objectId])
			{
				flag = false;
				flag2 = true;
			}
		}
		flag2 |= !base.CanStore(objectId, amount);
		int num;
		if (flag)
		{
			num = ((!flag2) ? 1 : 0);
			if (num != 0)
			{
				goto IL_007c;
			}
		}
		else
		{
			num = 0;
		}
		Action<string, bool> action = this.onCanStoreFailed;
		if (action == null)
		{
			return (byte)num != 0;
		}
		action(objectId, flag2);
		goto IL_007c;
		IL_007c:
		return (byte)num != 0;
	}

	public void SendAllResourcesToInventory()
	{
		if (base.StoredObjects != null)
		{
			int num = 0;
			for (int num2 = base.StoredObjects.Count - 1; num2 >= 0; num2 -= num)
			{
				num = GetStoredObjectAmount(GetStoredObjectAtIndex(num2).Id);
				LTFunctionLibrary.GetPlayerInventory()?.StoreObject(GetStoredObjectAtIndex(num2), num, EStoreSource.Production);
				RemoveStoredObjectByID(GetStoredObjectAtIndex(num2).Id, num);
			}
		}
	}

	public override void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		base.OnLoad(data, hasLoadedSomething);
		if (!hasLoadedSomething || !data.ContainsKey("storedObjects"))
		{
			return;
		}
		List<Dictionary<string, object>> list = data["storedObjects"] as List<Dictionary<string, object>>;
		for (int i = 0; i < list.Count; i++)
		{
			string resourceId = list[i]["id"] as string;
			int amount = (int)list[i]["amount"];
			ResourceData resourceDataById = LTAssetsReferences.instance.GetResourceDataById(resourceId);
			if ((bool)resourceDataById)
			{
				StoreObject(resourceDataById, amount, EStoreSource.LoadGame);
			}
		}
	}
}
