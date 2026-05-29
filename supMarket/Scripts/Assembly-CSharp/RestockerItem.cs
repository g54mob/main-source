using MyBox;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;
using __Project__.Scripts.Multiplayer.NetworkComputer;

public class RestockerItem : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private RestockerSO m_RestockerSetup;

	[Header("Components")]
	[SerializeField]
	private LocalizeStringEvent m_RestockerName;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedDailyWageText;

	[SerializeField]
	private TMP_Text m_DailyWageText;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedHiringCostText;

	[SerializeField]
	private TMP_Text m_HiringCostText;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedStorageObjectiveText;

	[SerializeField]
	private TMP_Text m_StorageObjectiveText;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedRackObjectiveText;

	[SerializeField]
	private TMP_Text m_RackObjectiveText;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedRequiredStoreLevelText;

	[SerializeField]
	private TMP_Text m_RequiredStoreLevelText;

	[SerializeField]
	private Button m_HireButton;

	[SerializeField]
	private Button m_FireButton;

	[SerializeField]
	private RestockerManagementUI m_ManagementUI;

	[SerializeField]
	private GameObject m_RequirementsPanel;

	[SerializeField]
	private GameObject m_SettingsPanel;

	[SerializeField]
	private GamePadUIPanel m_GamePadUIPanel;

	[Header("Colors")]
	[SerializeField]
	private Color m_CompletedRequirementColor;

	[SerializeField]
	private Color m_IncompletedRequirementColor;

	private bool m_Hired;

	private NetworkComputer m_NetworkComputer;

	public RestockerManagementData RestockerManagementData;

	private bool PurchasedRack => false;

	private bool ReachedRequiredLevel => false;

	public RestockerSO RestockerSO => null;

	public int RestockerId => 0;

	public bool Hired
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public NetworkComputer NetworkComputer => null;

	public void OnEnable()
	{
	}

	public void SetRestockerManagmentData()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SetRestockerDataRemote()
	{
	}

	private void Start()
	{
	}

	public void SetRestockerManagmentDataNetwork(RestockerManagementData restockerManagementData)
	{
	}

	public void SetupNetwork(bool isHired, int id, int RequiredStoreLevel, float DailyWage, float HiringCost, bool canHire, bool purchasedStorage, int purchasedRack, int currentStoreLevel)
	{
	}

	public bool CanHire()
	{
		return false;
	}

	public void Hire()
	{
	}

	public void Fire()
	{
	}

	public void GamepadBack()
	{
	}

	public void GamepadConfirm()
	{
	}

	private void Setup()
	{
	}

	private void UpdateStorageObjective()
	{
	}

	private void UpdateRackObjective()
	{
	}

	private void UpdateRequiredStoreLevel(bool _)
	{
	}

	private void MoneyChanged(float _amount, MoneyManager.TransitionType _type)
	{
	}
}
