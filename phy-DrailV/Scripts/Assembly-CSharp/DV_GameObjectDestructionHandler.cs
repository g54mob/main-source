using DV.Utils;
using UnityEngine;

public static class DV_GameObjectDestructionHandler
{
	public static void RemoveGameObject(GameObject go)
	{
		if (go == null)
		{
			Debug.LogError("Unexpected state: Attempted to destroy null GameObject via 'DV_GameObjectDestructionHandler'. Ignoring request, GO might be already destroyed.");
			return;
		}
		DV_GameObjectPoolMarker component = go.GetComponent<DV_GameObjectPoolMarker>();
		if (component != null)
		{
			SingletonBehaviour<DV_GameObjectPools>.Instance.ReturnGameObjectToPool(go, component.gameObjectPoolCategory);
		}
		else
		{
			Object.Destroy(go);
		}
	}
}
