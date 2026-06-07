using I2.Loc;
using UnityEngine;

public class T_DeliveryPointInteractable : InteractableBase
{
	[Header("Visual Feedback")]
	[Tooltip("Complete durumunda kullanılacak material")]
	[SerializeField]
	private Material completeMaterial;

	[Tooltip("Normal durumda kullanılacak material")]
	[SerializeField]
	private Material normalMaterial;

	[Tooltip("Material değiştirilecek renderer")]
	[SerializeField]
	private Renderer buttonRenderer;

	[Tooltip("Material değiştirilecek material index")]
	[SerializeField]
	private int materialIndex;

	private DeliveryInteractionState _currentState;

	private bool _lastIsComplete;

	public DeliveryInteractionState CurrentState => _currentState;

	private void Update()
	{
		UpdateState();
		UpdateVisuals();
	}

	private void UpdateState()
	{
		ComputerContractManager instance = ComputerContractManager.Instance;
		T_DeliveryZone instance2 = T_DeliveryZone.Instance;
		if (instance == null)
		{
			_currentState = DeliveryInteractionState.NoContract;
		}
		else if (!instance.HasActiveContracts)
		{
			_currentState = DeliveryInteractionState.NoContract;
		}
		else if (!instance.HasDeliveryRequest)
		{
			_currentState = DeliveryInteractionState.ContractExistsNoDelivery;
		}
		else if (instance2 != null && instance2.TotalDeliveredCount > 0)
		{
			_currentState = DeliveryInteractionState.DeliveryExistsHasItems;
		}
		else
		{
			_currentState = DeliveryInteractionState.DeliveryExistsNoItems;
		}
	}

	private void UpdateVisuals()
	{
		if (buttonRenderer == null || completeMaterial == null || normalMaterial == null)
		{
			return;
		}
		bool num = _currentState == DeliveryInteractionState.DeliveryExistsHasItems;
		bool flag = T_DeliveryZone.Instance != null && T_DeliveryZone.Instance.IsZoneItemsMatchContract();
		bool flag2 = num && flag;
		if (flag2 != _lastIsComplete)
		{
			_lastIsComplete = flag2;
			Material[] materials = buttonRenderer.materials;
			if (materialIndex >= 0 && materialIndex < materials.Length)
			{
				materials[materialIndex] = (flag2 ? completeMaterial : normalMaterial);
				buttonRenderer.materials = materials;
			}
		}
	}

	public override bool CanInteractPrimary()
	{
		return _currentState != DeliveryInteractionState.NoContract;
	}

	public override void OnPrimaryInteracted()
	{
		switch (_currentState)
		{
		case DeliveryInteractionState.ContractExistsNoDelivery:
			OpenContractSelectionUI();
			break;
		case DeliveryInteractionState.DeliveryExistsNoItems:
			CancelDelivery();
			break;
		case DeliveryInteractionState.DeliveryExistsHasItems:
			CompleteDelivery();
			break;
		}
	}

	private void OpenContractSelectionUI()
	{
		if (GameManager.Instance != null && GameManager.Instance.dayNightManager.IsNighttime)
		{
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Too Late For This Action"));
		}
		else if (GameManager.Instance != null && GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.deliveryPointUI != null)
		{
			GameManager.Instance.UImanager.deliveryPointUI.Open();
		}
	}

	private void CancelDelivery()
	{
		if (T_DeliveryZone.Instance != null && T_DeliveryZone.Instance.HasOccupants)
		{
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_DeliveryZone_Occupied"));
		}
		else
		{
			ComputerContractManager.Instance?.RequestCancelDeliveryOnly();
		}
	}

	private void CompleteDelivery()
	{
		if (T_DeliveryZone.Instance != null && T_DeliveryZone.Instance.HasOccupants)
		{
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_DeliveryZone_Occupied"));
		}
		else
		{
			ComputerContractManager.Instance?.RequestClearDeliveryContract();
		}
	}
}
