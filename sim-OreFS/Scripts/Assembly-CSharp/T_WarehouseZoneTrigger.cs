using System.Collections.Generic;
using Mirror;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class T_WarehouseZoneTrigger : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private T_Warehouse warehouse;

	public HashSet<uint> palletsInTrigger = new HashSet<uint>();

	public HashSet<uint> PalletsInTrigger => palletsInTrigger;

	private void Awake()
	{
		Collider component = GetComponent<Collider>();
		if (component != null && !component.isTrigger)
		{
			Debug.LogWarning("[WarehouseZoneTrigger] Collider trigger değil, otomatik düzeltiliyor. GameObject: " + base.gameObject.name);
			component.isTrigger = true;
		}
	}

	public void SetWarehouse(T_Warehouse wh)
	{
		warehouse = wh;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!NetworkServer.active)
		{
			return;
		}
		if (warehouse == null)
		{
			Debug.LogWarning("[WarehouseZoneTrigger] warehouse == null!");
		}
		else
		{
			if (!other.CompareTag("Pallet"))
			{
				return;
			}
			T_PalletInputTrigger component = other.GetComponent<T_PalletInputTrigger>();
			if (component == null)
			{
				Debug.LogWarning("[WarehouseZoneTrigger] T_PalletInputTrigger component bulunamadı! Object: " + other.name);
				return;
			}
			T_Pallet pallet = component.Pallet;
			if (pallet == null)
			{
				Debug.LogWarning("[WarehouseZoneTrigger] palletTrigger.Pallet == null!");
				return;
			}
			NetworkIdentity component2 = pallet.GetComponent<NetworkIdentity>();
			if (component2 == null)
			{
				return;
			}
			uint netId = component2.netId;
			if (!palletsInTrigger.Contains(netId))
			{
				palletsInTrigger.Add(netId);
				if (!pallet.IsLifted)
				{
					warehouse.ServerOnPalletEnter(pallet);
					Debug.Log($"[WarehouseZoneTrigger] Eşya eklendi - NetId: {netId}");
				}
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!NetworkServer.active)
		{
			return;
		}
		if (warehouse == null)
		{
			Debug.LogWarning("[WarehouseZoneTrigger] OnTriggerExit - warehouse == null!");
		}
		else
		{
			if (!other.CompareTag("Pallet"))
			{
				return;
			}
			T_PalletInputTrigger component = other.GetComponent<T_PalletInputTrigger>();
			if (component == null)
			{
				Debug.LogWarning("[WarehouseZoneTrigger] OnTriggerExit - T_PalletInputTrigger bulunamadı! Object: " + other.name);
				return;
			}
			T_Pallet pallet = component.Pallet;
			if (pallet == null)
			{
				Debug.LogWarning("[WarehouseZoneTrigger] OnTriggerExit - palletTrigger.Pallet == null!");
				return;
			}
			NetworkIdentity component2 = pallet.GetComponent<NetworkIdentity>();
			if (component2 == null)
			{
				Debug.LogWarning("[WarehouseZoneTrigger] OnTriggerExit - NetworkIdentity bulunamadı!");
				return;
			}
			uint netId = component2.netId;
			if (!palletsInTrigger.Contains(netId))
			{
				Debug.LogWarning($"[WarehouseZoneTrigger] OnTriggerExit - Palet zaten trigger'da DEĞİL, atlanıyor - NetId: {netId}");
				return;
			}
			palletsInTrigger.Remove(netId);
			warehouse.ServerOnPalletExit(pallet);
		}
	}

	public void OnPalletDestroyed(uint palletNetId)
	{
		if (palletsInTrigger.Contains(palletNetId))
		{
			palletsInTrigger.Remove(palletNetId);
		}
	}

	public bool IsPalletInTrigger(uint palletNetId)
	{
		return palletsInTrigger.Contains(palletNetId);
	}

	public void ValidatePalletReferences()
	{
		if (!NetworkServer.active)
		{
			return;
		}
		List<uint> list = new List<uint>();
		foreach (uint item in palletsInTrigger)
		{
			if (!NetworkServer.spawned.ContainsKey(item))
			{
				list.Add(item);
			}
		}
		foreach (uint item2 in list)
		{
			palletsInTrigger.Remove(item2);
		}
	}

	public int GetPalletsInTriggerCount()
	{
		return palletsInTrigger.Count;
	}
}
