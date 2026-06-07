using System.Collections.Generic;
using UnityEngine;

public class LimitNumberOfInstances : MonoBehaviour
{
	public int maxInstances = 20;

	private Queue<GameObject> spawned;

	public bool InstanceAllowed
	{
		get
		{
			if (spawned != null)
			{
				return spawned.Count < maxInstances;
			}
			return false;
		}
	}

	private void Start()
	{
		spawned = new Queue<GameObject>();
	}

	public void Add(GameObject newObject)
	{
		spawned.Enqueue(newObject);
		while (spawned.Count > maxInstances && maxInstances > 0)
		{
			DV_GameObjectDestructionHandler.RemoveGameObject(spawned.Dequeue());
		}
	}
}
