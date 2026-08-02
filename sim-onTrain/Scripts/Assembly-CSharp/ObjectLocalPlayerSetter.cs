using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class ObjectLocalPlayerSetter : NetworkBehaviour
{
	public List<GameObject> destroyedObjects = new List<GameObject>();

	public List<GameObject> instantiatedObjects = new List<GameObject>();

	private void Start()
	{
		if (!base.isLocalPlayer)
		{
			DestroyObjects();
		}
	}

	public void DestroyObjects()
	{
		foreach (GameObject destroyedObject in destroyedObjects)
		{
			Object.Destroy(destroyedObject);
		}
		destroyedObjects.Clear();
	}

	public override bool Weaved()
	{
		return true;
	}
}
