using I2.Loc;
using UnityEngine;

public class T_PalletMachineInteractable : InteractableBase
{
	[Header("References")]
	[SerializeField]
	private T_PalletMachine palletMachine;

	private void Awake()
	{
		if (palletMachine == null)
		{
			palletMachine = GetComponent<T_PalletMachine>();
		}
		if (palletMachine == null)
		{
			palletMachine = GetComponentInParent<T_PalletMachine>();
		}
		if (palletMachine == null)
		{
			Debug.LogError("[T_PalletMachineInteractable] T_PalletMachine component bulunamadı!");
		}
	}

	public override bool CanInteractPrimary()
	{
		if (palletMachine == null)
		{
			return false;
		}
		if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
			}
			return false;
		}
		ComputerContractManager instance = ComputerContractManager.Instance;
		if (instance == null || !instance.HasActiveContracts)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_PalletMachine_NoContract"));
			}
			return false;
		}
		if (!instance.HasDeliveryRequest)
		{
			OpenDeliverySelectionUI();
			return false;
		}
		return true;
	}

	public override void OnPrimaryInteracted()
	{
		if (!(palletMachine == null))
		{
			OpenUIPanel();
		}
	}

	private void OpenDeliverySelectionUI()
	{
		if (GameManager.Instance != null && GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.deliveryPointUI != null)
		{
			GameManager.Instance.UImanager.deliveryPointUI.Open();
		}
	}

	public void OpenUIPanel()
	{
		if (!(palletMachine == null))
		{
			if (GameManager.Instance != null && GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.palletMachineUI != null)
			{
				GameManager.Instance.UImanager.palletMachineUI.OpenUIPanel(palletMachine);
			}
			else
			{
				Debug.LogWarning("[T_PalletMachineInteractable] PalletMachineUI bulunamadı!");
			}
		}
	}

	public void CloseUIPanel()
	{
		Debug.LogWarning("[T_PalletMachineInteractable]  CloseUIPanel tetiklendi!");
		if (GameManager.Instance != null && GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.palletMachineUI != null)
		{
			GameManager.Instance.UImanager.palletMachineUI.CloseUIPanel();
		}
	}

	public void CloseUIEvents()
	{
		if (GameManager.Instance.UImanager.palletMachineUI != null)
		{
			GameManager.Instance.UImanager.palletMachineUI.CloseUIEvents();
		}
	}
}
