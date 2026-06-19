using Mirror;
using UnityEngine;

[CreateAssetMenu(menuName = "Shift/Box Order", fileName = "shiftorder-NAME")]
public class ShiftOrderObject : ScriptableObject
{
	public GameObject prefab;

	public GameObject orderVisualPrefab;

	public Sprite UIImage;

	public bool hasMaxOutboundCount;

	[Min(1f)]
	public int maxOutboundCount = 2;

	public bool TryGetAssetId(out uint assetId)
	{
		if (prefab == null || !prefab.TryGetComponent<NetworkIdentity>(out var component))
		{
			assetId = 0u;
			return false;
		}
		assetId = component.assetId;
		return true;
	}

	public bool GetCanBeStackedOn()
	{
		if (!prefab.TryGetComponent<Grabbable>(out var component))
		{
			Debug.LogWarning("Could not find Grabbable on prefab's root! " + prefab.name, prefab);
			return false;
		}
		return component.canBeStackedOn;
	}
}
