using System;
using System.Collections;
using DV.CabControls;
using UnityEngine;

public class SnapItem : MonoBehaviour
{
	private ItemBase item;

	private SnapItemZone currentSnapZone;

	public event Action<SnapItem, SnapItemZone> ItemSnapped;

	private IEnumerator Start()
	{
		yield return null;
		item = GetComponent<ItemBase>();
	}

	public void SetupSnapZoneListener(bool set, SnapItemZone snapZone = null)
	{
		if (snapZone != null && currentSnapZone != null)
		{
			item.Ungrabbed -= OnUnGrabbed;
		}
		currentSnapZone = snapZone;
		if (set)
		{
			item.Ungrabbed += OnUnGrabbed;
		}
		else
		{
			item.Ungrabbed -= OnUnGrabbed;
		}
	}

	private void OnUnGrabbed(ControlImplBase _)
	{
		item.Ungrabbed -= OnUnGrabbed;
		Vector3 position = item.transform.position;
		if (!currentSnapZone.IsOccupied && currentSnapZone.zoneTrigger.ClosestPoint(position) == position)
		{
			Rigidbody component = item.GetComponent<Rigidbody>();
			component.isKinematic = true;
			component.detectCollisions = false;
			item.transform.SetPositionAndRotation(currentSnapZone.snapAnchor.position, currentSnapZone.snapAnchor.rotation);
			item.transform.SetParent(currentSnapZone.snapAnchor);
			currentSnapZone.SetSnappedItem(item);
			this.ItemSnapped?.Invoke(this, currentSnapZone);
		}
	}

	public bool IsGrabbed()
	{
		return item.IsGrabbed();
	}
}
