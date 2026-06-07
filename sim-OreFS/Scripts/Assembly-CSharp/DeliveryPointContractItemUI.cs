using System;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryPointContractItemUI : MonoBehaviour
{
	[Header("References")]
	[Tooltip("Contract bilgilerini gösteren ContractHUDItemUI")]
	[SerializeField]
	private ContractHUDItemUI contractHUDItem;

	[Tooltip("Tüm item'ı seçilebilir yapan button")]
	[SerializeField]
	private Button selectButton;

	private Action<DeliveryPointContractItemUI> _onClicked;

	public string ActiveId
	{
		get
		{
			if (!(contractHUDItem != null))
			{
				return string.Empty;
			}
			return contractHUDItem.ActiveId;
		}
	}

	public ActiveContractData ContractData
	{
		get
		{
			if (!(contractHUDItem != null))
			{
				return default(ActiveContractData);
			}
			return contractHUDItem.ContractData;
		}
	}

	private void Awake()
	{
		if (selectButton != null)
		{
			selectButton.onClick.AddListener(OnSelectClicked);
		}
	}

	public void Initialize(ActiveContractData contract, Action<DeliveryPointContractItemUI> onClicked)
	{
		_onClicked = onClicked;
		if (contractHUDItem != null)
		{
			contractHUDItem.Initialize(contract);
			contractHUDItem.SetDetailsExpanded(expanded: true);
			contractHUDItem.SetFirstItemOnly(isFirstItem: false);
		}
	}

	private void OnSelectClicked()
	{
		_onClicked?.Invoke(this);
	}
}
