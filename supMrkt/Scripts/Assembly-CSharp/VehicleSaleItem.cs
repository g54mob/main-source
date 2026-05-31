using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.Computer.Shopping;
using __Project__.Scripts.ControllerInputModule;

public class VehicleSaleItem : ToolSalesItem
{
	[SerializeField]
	private int m_VehicleLevel;

	[SerializeField]
	private float m_Price;

	[SerializeField]
	private int m_RequiredLevel;

	[SerializeField]
	private TMP_Text m_PriceText;

	[SerializeField]
	private Button m_ConfirmButton;

	[SerializeField]
	private Button m_RejectButton;

	[SerializeField]
	private GameObject m_ConfirmPanel;

	[SerializeField]
	private GamePadUIPanel m_ConfirmUIPanel;

	[SerializeField]
	private Button m_PurchaseButton;

	[SerializeField]
	private Button m_SellButton;

	[SerializeField]
	private Button m_ResetButton;

	[SerializeField]
	private TMP_Text m_RequiredStoreLevelText;

	[SerializeField]
	private TMP_Text m_RequiredStoreText;

	[SerializeField]
	private Color m_False;

	[SerializeField]
	private Color m_True;

	[SerializeField]
	private GamePadUIPanel m_GamePadUIPanel;

	private bool m_IsWarningShowed;

	private bool m_IsPurchased;

	private bool m_IsUnlocked;

	public bool IsPurchased
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool IsUnlocked
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int VehicleLevel => 0;

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	public void SubscribeSaleItemIntoManager()
	{
	}

	private void OnComputerInteractionStopped()
	{
	}

	public void Setup()
	{
	}

	private void LockVehicle()
	{
	}

	private void UnlockVehicle()
	{
	}

	private void Purchased()
	{
	}

	public bool IsPurchaseAvailable()
	{
		return false;
	}

	public void Purchase()
	{
	}

	public void Purchase_Network()
	{
	}

	public bool IsSellAvailable(out int errorCode)
	{
		errorCode = default(int);
		return false;
	}

	public void Sell()
	{
	}

	public void Sell_Network(int _VehicleLevel, float _Price)
	{
	}

	public void SelectVehicleItemOnGamepad()
	{
	}

	public void ResetVehicle()
	{
	}

	public void OpenConfirmPanel()
	{
	}

	public void CloseConfirmPanel()
	{
	}

	private void UpdateButtonInteraction(float _, MoneyManager.TransitionType type)
	{
	}

	public void GamepadBack()
	{
	}

	public void GamepadConfirm()
	{
	}
}
