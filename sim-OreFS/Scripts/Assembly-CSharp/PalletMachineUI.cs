using System.Collections.Generic;
using I2.Loc;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PalletMachineUI : MonoBehaviour
{
	[Header("Panel References")]
	[SerializeField]
	private GameObject uiPanel;

	[SerializeField]
	private GameObject idlePanel;

	[SerializeField]
	private GameObject processingPanel;

	[Header("Contract Info")]
	[SerializeField]
	private GameObject contractInfoPanel;

	[SerializeField]
	private TextMeshProUGUI contractNameText;

	[Header("Material List")]
	[SerializeField]
	private Transform materialListParent;

	[SerializeField]
	private GameObject materialItemPrefab;

	[Header("No Delivery Panel")]
	[SerializeField]
	private GameObject noDeliveryPanel;

	[SerializeField]
	private GameObject contractNameObject;

	[Header("Status Indicators")]
	[SerializeField]
	private GameObject readyIndicator;

	[Header("Controls")]
	[SerializeField]
	private Button startButton;

	[SerializeField]
	private Toggle autoWorkToggle;

	private T_PalletMachine currentMachine;

	private List<ContractHUDMaterialUI> materialItems = new List<ContractHUDMaterialUI>();

	private PalletMachineState lastKnownState;

	private uint lastKnownInputPalletNetId;

	private void Start()
	{
		if (startButton != null)
		{
			startButton.onClick.RemoveAllListeners();
			startButton.onClick.AddListener(OnStartButtonClicked);
		}
		if (autoWorkToggle != null)
		{
			autoWorkToggle.onValueChanged.RemoveAllListeners();
			autoWorkToggle.onValueChanged.AddListener(OnAutoWorkToggleChanged);
		}
		if (uiPanel != null)
		{
			uiPanel.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (!(currentMachine == null) && !(uiPanel == null) && uiPanel.activeSelf)
		{
			if (currentMachine.MachineState != lastKnownState)
			{
				lastKnownState = currentMachine.MachineState;
				UpdateUI();
			}
			if (currentMachine.InputPalletNetId != lastKnownInputPalletNetId)
			{
				lastKnownInputPalletNetId = currentMachine.InputPalletNetId;
				UpdateMaterialPalletCounts();
			}
		}
	}

	public void OpenUIPanel(T_PalletMachine machine)
	{
		if (machine == null)
		{
			Debug.LogWarning("[PalletMachineUI] Machine null, UI açılamadı");
			return;
		}
		if (currentMachine != null)
		{
			UnsubscribeFromMachine(currentMachine);
		}
		currentMachine = machine;
		lastKnownState = machine.MachineState;
		lastKnownInputPalletNetId = machine.InputPalletNetId;
		SubscribeToMachine(machine);
		if (uiPanel != null)
		{
			uiPanel.SetActive(value: true);
		}
		if (autoWorkToggle != null)
		{
			autoWorkToggle.SetIsOnWithoutNotify(machine.AutoWork);
		}
		UpdateUI();
	}

	public void CloseUIEvents()
	{
		currentMachine.closeUIEvent?.Invoke();
	}

	public void CloseUIPanel()
	{
		if (currentMachine != null)
		{
			UnsubscribeFromMachine(currentMachine);
		}
		currentMachine = null;
		lastKnownInputPalletNetId = 0u;
		Debug.LogWarning("[T_PalletMachineInteractable]  CloseUIPanel tetiklendi! 2");
		if (uiPanel != null)
		{
			uiPanel.SetActive(value: false);
		}
	}

	private void SubscribeToMachine(T_PalletMachine machine)
	{
		if (!(machine == null))
		{
			machine.onStateChanged.AddListener(OnMachineStateChanged);
			machine.onAutoWorkChanged.AddListener(OnAutoWorkValueChanged);
		}
	}

	private void UnsubscribeFromMachine(T_PalletMachine machine)
	{
		if (!(machine == null))
		{
			machine.onStateChanged.RemoveListener(OnMachineStateChanged);
			machine.onAutoWorkChanged.RemoveListener(OnAutoWorkValueChanged);
		}
	}

	private void OnMachineStateChanged(PalletMachineState newState)
	{
		lastKnownState = newState;
		UpdateUI();
	}

	private void UpdateUI()
	{
		if (!(currentMachine == null))
		{
			bool flag = ComputerContractManager.Instance != null && ComputerContractManager.Instance.HasDeliveryRequest;
			if (noDeliveryPanel != null)
			{
				noDeliveryPanel.SetActive(!flag);
			}
			if (contractNameObject != null)
			{
				contractNameObject.SetActive(flag);
			}
			if (idlePanel != null)
			{
				idlePanel.SetActive(currentMachine.MachineState != PalletMachineState.Processing);
			}
			if (processingPanel != null)
			{
				processingPanel.SetActive(currentMachine.MachineState == PalletMachineState.Processing);
			}
			if (!flag)
			{
				ClearMaterialList();
				return;
			}
			UpdateContractInfo();
			UpdateMaterialList();
			UpdateReadyIndicator();
			UpdateStartButton();
		}
	}

	private void UpdateContractInfo()
	{
		if (ComputerContractManager.Instance == null)
		{
			return;
		}
		bool hasDeliveryRequest = ComputerContractManager.Instance.HasDeliveryRequest;
		ActiveContractData? deliveryRequestedContract = ComputerContractManager.Instance.GetDeliveryRequestedContract();
		if (contractInfoPanel != null)
		{
			contractInfoPanel.SetActive(hasDeliveryRequest && deliveryRequestedContract.HasValue);
		}
		if (contractNameText != null && deliveryRequestedContract.HasValue)
		{
			string text = LocalizationManager.GetTranslation("Contract");
			if (string.IsNullOrEmpty(text))
			{
				text = "Contract";
			}
			contractNameText.text = $"{text} #{deliveryRequestedContract.Value.contractNumber:D3}";
		}
	}

	private void ClearMaterialList()
	{
		foreach (ContractHUDMaterialUI materialItem in materialItems)
		{
			if (materialItem != null && materialItem.gameObject != null)
			{
				Object.Destroy(materialItem.gameObject);
			}
		}
		materialItems.Clear();
	}

	private void UpdateMaterialList()
	{
		if (materialListParent == null || materialItemPrefab == null)
		{
			return;
		}
		ClearMaterialList();
		if (ComputerContractManager.Instance == null)
		{
			return;
		}
		ActiveContractData? deliveryRequestedContract = ComputerContractManager.Instance.GetDeliveryRequestedContract();
		if (!deliveryRequestedContract.HasValue)
		{
			return;
		}
		T_Pallet t_Pallet = null;
		if (currentMachine != null && currentMachine.InputPalletNetId != 0)
		{
			NetworkIdentity networkIdentity = (NetworkClient.spawned.ContainsKey(currentMachine.InputPalletNetId) ? NetworkClient.spawned[currentMachine.InputPalletNetId] : null);
			if (networkIdentity != null)
			{
				t_Pallet = networkIdentity.GetComponent<T_Pallet>();
			}
		}
		ActiveContractData value = deliveryRequestedContract.Value;
		if (value.materialIds == null || value.materialCounts == null)
		{
			return;
		}
		for (int i = 0; i < value.materialIds.Length; i++)
		{
			string text = value.materialIds[i];
			if (!string.IsNullOrEmpty(text) && !(ItemSOManager.Instance?.GetItemSOById(text) == null))
			{
				int palletCount = 0;
				if (t_Pallet != null && t_Pallet.PaletItemId == text)
				{
					palletCount = t_Pallet.PaletItemCount;
				}
				int requiredCount = value.materialCounts[i];
				int deliveredCount = ((T_DeliveryZone.Instance != null) ? T_DeliveryZone.Instance.GetItemCount(text) : 0);
				ContractHUDMaterialUI component = Object.Instantiate(materialItemPrefab, materialListParent).GetComponent<ContractHUDMaterialUI>();
				if (component != null)
				{
					component.Initialize(text, requiredCount, deliveredCount);
					component.UpdatePalletCount(palletCount);
					materialItems.Add(component);
				}
			}
		}
	}

	private void UpdateMaterialPalletCounts()
	{
		if (materialItems == null || materialItems.Count == 0)
		{
			return;
		}
		T_Pallet t_Pallet = null;
		if (currentMachine != null && currentMachine.InputPalletNetId != 0)
		{
			NetworkIdentity networkIdentity = (NetworkClient.spawned.ContainsKey(currentMachine.InputPalletNetId) ? NetworkClient.spawned[currentMachine.InputPalletNetId] : null);
			if (networkIdentity != null)
			{
				t_Pallet = networkIdentity.GetComponent<T_Pallet>();
			}
		}
		foreach (ContractHUDMaterialUI materialItem in materialItems)
		{
			if (!(materialItem == null))
			{
				int palletCount = 0;
				if (t_Pallet != null && t_Pallet.PaletItemId == materialItem.ItemId)
				{
					palletCount = t_Pallet.PaletItemCount;
				}
				materialItem.UpdatePalletCount(palletCount);
			}
		}
	}

	private void UpdateReadyIndicator()
	{
		if (!(currentMachine == null))
		{
			bool active = currentMachine.MachineState == PalletMachineState.Ready;
			if (readyIndicator != null)
			{
				readyIndicator.SetActive(active);
			}
		}
	}

	private void UpdateStartButton()
	{
		if (!(startButton == null))
		{
			if (currentMachine == null)
			{
				startButton.interactable = false;
				return;
			}
			bool interactable = currentMachine.MachineState != PalletMachineState.Processing;
			startButton.interactable = interactable;
		}
	}

	private void OnStartButtonClicked()
	{
		if (!(currentMachine == null))
		{
			currentMachine.RequestStartProcessing();
		}
	}

	private void OnAutoWorkToggleChanged(bool value)
	{
		if (!(currentMachine == null))
		{
			currentMachine.RequestSetAutoWork(value);
		}
	}

	private void OnAutoWorkValueChanged(bool value)
	{
		if (autoWorkToggle != null)
		{
			autoWorkToggle.SetIsOnWithoutNotify(value);
		}
		UpdateStartButton();
	}

	public T_PalletMachine GetCurrentMachine()
	{
		return currentMachine;
	}

	public bool IsOpen()
	{
		if (uiPanel != null)
		{
			return uiPanel.activeSelf;
		}
		return false;
	}
}
