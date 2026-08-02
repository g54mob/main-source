using JUTPS.InventorySystem;
using UnityEngine;

public class TsPlayerHitManager : MonoBehaviour
{
	public SphereCollider hitSphere;

	public CollectableItemData axeData;

	public CollectableItemData pickaxeData;

	private JUInventory inventory;

	private PlayerInventory playerInventory;

	private void Start()
	{
		playerInventory = GetComponent<PlayerInventory>();
	}

	public void AxeHit()
	{
	}

	public bool CheckAxeHit(float hitDamage)
	{
		Vector3 position = hitSphere.transform.position;
		Physics.SyncTransforms();
		Collider[] array = Physics.OverlapSphere(position, hitSphere.radius);
		bool flag = false;
		string text = "";
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			text = text + collider.name + ", ";
			if (collider.TryGetComponent<TreeCollectable>(out var component))
			{
				component.GetDamage(playerInventory, hitDamage, position);
				flag = true;
			}
		}
		Debug.Log($"[AXE_HIT] center={position} radius={hitSphere.radius} colliderSayısı={array.Length} ağaçBulundu={flag} | {text}");
		return flag;
	}

	public bool CheckPickaxeHit(float hitDamage)
	{
		Vector3 position = hitSphere.transform.position;
		Physics.SyncTransforms();
		Collider[] array = Physics.OverlapSphere(position, hitSphere.radius);
		bool result = false;
		Collider[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			if (array2[i].TryGetComponent<OreCollectable>(out var component))
			{
				component.GetDamage(playerInventory, hitDamage, position);
				result = true;
			}
		}
		return result;
	}
}
