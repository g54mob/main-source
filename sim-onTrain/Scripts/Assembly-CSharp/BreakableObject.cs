using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
	public ObjectServerData objectServerData;

	protected bool isPreloaded;

	private static readonly Dictionary<long, BreakableObject> registry = new Dictionary<long, BreakableObject>();

	private bool isRegistered;

	private long registeredKey;

	private static long GetKey(int cellID, int objectID)
	{
		return ((long)cellID << 32) | (uint)objectID;
	}

	private void Awake()
	{
		Register();
	}

	public void Register()
	{
		if (isRegistered)
		{
			registry.Remove(registeredKey);
		}
		long key = GetKey(objectServerData.cellID, objectServerData.objectID);
		registry[key] = this;
		registeredKey = key;
		isRegistered = true;
	}

	public void Unregister()
	{
		if (isRegistered)
		{
			registry.Remove(registeredKey);
			isRegistered = false;
		}
	}

	private void OnDestroy()
	{
		Unregister();
	}

	public static BreakableObject Find(int cellID, int objectID)
	{
		long key = GetKey(cellID, objectID);
		registry.TryGetValue(key, out var value);
		return value;
	}

	public void MarkAsPreloaded()
	{
		isPreloaded = true;
	}
}
