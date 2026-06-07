using Mirror;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class T_MachineInputTrigger : MonoBehaviour
{
	[Header("Machine Reference")]
	[Tooltip("Bu trigger'ın bağlı olduğu makine")]
	[SerializeField]
	private T_Machine machine;

	private void Awake()
	{
		Collider component = GetComponent<Collider>();
		if (component != null && !component.isTrigger)
		{
			Debug.LogWarning("[MachineInputTrigger] Collider trigger değil! Trigger olarak ayarlanıyor. GameObject: " + base.gameObject.name);
			component.isTrigger = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!NetworkServer.active)
		{
			return;
		}
		if (machine == null)
		{
			Debug.LogWarning("[MachineInputTrigger] Machine referansı null! GameObject: " + base.gameObject.name);
			return;
		}
		Debug.Log("[MachineInputTrigger] OnTriggerEnter - Collider: " + other.name + ", Machine: " + machine.name);
		T_Item t_Item = other.GetComponent<T_Item>();
		if (t_Item == null)
		{
			t_Item = other.GetComponentInParent<T_Item>();
		}
		if (t_Item == null)
		{
			Debug.Log("[MachineInputTrigger] OnTriggerEnter - Collider'da T_Item component'i yok: " + other.name);
			return;
		}
		Debug.Log("[MachineInputTrigger] OnTriggerEnter - Item bulundu: " + t_Item.name + ", ItemId: " + t_Item.itemId);
		machine.ServerTryAddItemFromCollider(t_Item);
	}
}
