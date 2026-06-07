using DV.CabControls;
using UnityEngine;

public class SnapItemZone : MonoBehaviour
{
	public Collider zoneTrigger;

	public Transform snapAnchor;

	private ItemBase snappedItem;

	public bool IsOccupied => snappedItem != null;

	private void OnTriggerEnter(Collider other)
	{
		if (!IsOccupied)
		{
			SnapItem componentInParent = other.GetComponentInParent<SnapItem>();
			if ((bool)componentInParent && componentInParent.IsGrabbed())
			{
				componentInParent.SetupSnapZoneListener(set: true, this);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		SnapItem componentInParent = other.GetComponentInParent<SnapItem>();
		if ((bool)componentInParent)
		{
			componentInParent.SetupSnapZoneListener(set: false);
		}
	}

	public void SetSnappedItem(ItemBase item)
	{
		snappedItem = item;
	}
}
