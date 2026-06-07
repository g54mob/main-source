using DV.CabControls;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ItemBuoyancyEnabler : MonoBehaviour
{
	private int grabbedItemLayer;

	private int worldItemLayer;

	private void Awake()
	{
		BoxCollider component = GetComponent<BoxCollider>();
		Vector3 center = component.center;
		center.y = component.size.y / -2f + LevelInfo.WaterLevel;
		component.center = center;
		grabbedItemLayer = LayerMask.NameToLayer("Grabbed_Item");
		worldItemLayer = LayerMask.NameToLayer("World_Item");
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == worldItemLayer || other.gameObject.layer == grabbedItemLayer)
		{
			ItemBase componentInParent = other.GetComponentInParent<ItemBase>();
			if ((bool)componentInParent)
			{
				componentInParent.GetComponent<ItemBuoyancy>().enabled = true;
			}
		}
	}
}
