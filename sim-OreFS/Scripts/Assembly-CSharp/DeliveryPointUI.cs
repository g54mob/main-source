using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public class DeliveryPointUI : MonoBehaviour
{
	[Header("Panel")]
	[Tooltip("Ana panel objesi")]
	[SerializeField]
	private GameObject panelRoot;

	[Header("Contract List")]
	[Tooltip("DeliveryPointContractItemUI prefab'ı")]
	[SerializeField]
	private GameObject contractItemPrefab;

	[Tooltip("Contract item'larının parent'ı (ScrollView Content)")]
	[SerializeField]
	private Transform contractListContent;

	private List<DeliveryPointContractItemUI> _spawnedContractItems = new List<DeliveryPointContractItemUI>();

	public bool IsOpen
	{
		get
		{
			if (panelRoot != null)
			{
				return panelRoot.activeSelf;
			}
			return false;
		}
	}

	private void Awake()
	{
		if (panelRoot != null)
		{
			panelRoot.SetActive(value: false);
		}
	}

	public void Open()
	{
		if (GameManager.Instance != null && GameManager.Instance.dayNightManager.IsNighttime)
		{
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Too Late For This Action"), isComputer: true);
			return;
		}
		if (panelRoot != null)
		{
			panelRoot.SetActive(value: true);
		}
		RefreshContractList();
	}

	public void Close()
	{
		if (panelRoot != null)
		{
			panelRoot.SetActive(value: false);
		}
	}

	private void RefreshContractList()
	{
		ComputerContractManager instance = ComputerContractManager.Instance;
		if (instance == null)
		{
			return;
		}
		IReadOnlyList<ActiveContractData> activeContracts = instance.ActiveContracts;
		if (activeContracts == null || activeContracts.Count == 0)
		{
			return;
		}
		int count = activeContracts.Count;
		while (_spawnedContractItems.Count < count)
		{
			CreateContractItem();
		}
		for (int i = 0; i < _spawnedContractItems.Count; i++)
		{
			bool flag = i < count;
			_spawnedContractItems[i].gameObject.SetActive(flag);
			if (flag)
			{
				ActiveContractData contract = activeContracts[i];
				_spawnedContractItems[i].Initialize(contract, OnContractItemClicked);
			}
		}
	}

	private void CreateContractItem()
	{
		if (!(contractItemPrefab == null) && !(contractListContent == null))
		{
			GameObject gameObject = Object.Instantiate(contractItemPrefab, contractListContent);
			DeliveryPointContractItemUI component = gameObject.GetComponent<DeliveryPointContractItemUI>();
			if (component != null)
			{
				_spawnedContractItems.Add(component);
				return;
			}
			Debug.LogWarning("[DeliveryPointUI] DeliveryPointContractItemUI component bulunamadı!");
			Object.Destroy(gameObject);
		}
	}

	private void ClearContractItems()
	{
		foreach (DeliveryPointContractItemUI spawnedContractItem in _spawnedContractItems)
		{
			if (spawnedContractItem != null)
			{
				Object.Destroy(spawnedContractItem.gameObject);
			}
		}
		_spawnedContractItems.Clear();
	}

	private void OnContractItemClicked(DeliveryPointContractItemUI clickedItem)
	{
		if (!(clickedItem == null))
		{
			if (GameManager.Instance != null && GameManager.Instance.dayNightManager.IsNighttime)
			{
				NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Too Late For This Action"), isComputer: true);
				return;
			}
			if (T_DeliveryZone.Instance != null && T_DeliveryZone.Instance.HasOccupants)
			{
				NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_DeliveryZone_Occupied"), isComputer: true);
				return;
			}
			string activeId = clickedItem.ActiveId;
			ComputerContractManager.Instance?.RequestSetDeliveryContract(activeId);
			Close();
		}
	}

	private void OnDestroy()
	{
		ClearContractItems();
	}
}
