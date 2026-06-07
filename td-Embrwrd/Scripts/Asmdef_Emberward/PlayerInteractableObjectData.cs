using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractableObjectData
{
	[Serializable]
	public struct InteractableEntry
	{
		public APlayerInteractableObjects obj;

		public int priority;

		public InteractableEntry(APlayerInteractableObjects obj, int priority)
		{
			this.obj = null;
			this.priority = 0;
		}
	}

	public List<InteractableEntry> list_RegisteredObjects;

	public Vector3Int position;

	public PlayerInteractableObjectData(Vector3Int pos)
	{
	}

	public APlayerInteractableObjects GetTopPriorityObject()
	{
		return null;
	}

	public void RegisterObject(APlayerInteractableObjects obj, int priority = 0)
	{
	}

	public void UnregisterObject(APlayerInteractableObjects obj)
	{
	}

	private void SortObjects()
	{
	}

	public List<APlayerInteractableObjects> GetAllRegisteredObjects()
	{
		return null;
	}
}
