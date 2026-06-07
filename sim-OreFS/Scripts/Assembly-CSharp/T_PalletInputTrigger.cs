using Mirror;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class T_PalletInputTrigger : MonoBehaviour
{
	[Header("Palet Reference")]
	[Tooltip("Bu trigger'ın bağlı olduğu palet")]
	[SerializeField]
	private T_Pallet pallet;

	public T_Pallet Pallet => pallet;

	private void Awake()
	{
		Collider component = GetComponent<Collider>();
		if (component != null && !component.isTrigger)
		{
			Debug.LogWarning("[PaletInputTrigger] Collider trigger değil! Trigger olarak ayarlanıyor. GameObject: " + base.gameObject.name);
			component.isTrigger = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerStay(Collider other)
	{
		if (!NetworkServer.active || pallet == null)
		{
			return;
		}
		if (!other.TryGetComponent<T_Item>(out var component))
		{
			Rigidbody attachedRigidbody = other.attachedRigidbody;
			if (attachedRigidbody == null || !attachedRigidbody.TryGetComponent<T_Item>(out component))
			{
				return;
			}
		}
		if (pallet.buildingObject != null && !pallet.buildingObject.IsPlaced)
		{
			return;
		}
		if (component.currentBelt != null || component.currentBeltNetId != 0)
		{
			if (component.targetPallet != pallet)
			{
				component.SetTargetPallet(pallet);
			}
			return;
		}
		if (component.targetPallet != pallet)
		{
			component.SetTargetPallet(pallet);
		}
		pallet.ServerTryAddItemFromBelt(component);
	}
}
