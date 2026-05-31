using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class CustomerHelperItem : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private CustomerHelperSO m_CustomerHelperSetup;

	[Header("Components")]
	[SerializeField]
	private LocalizeStringEvent m_CustomerHelperName;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedDailyWageText;

	[SerializeField]
	private TMP_Text m_DailyWageText;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedHiringCostText;

	[SerializeField]
	private TMP_Text m_HiringCostText;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedCheckoutObjectiveText;

	[SerializeField]
	private TMP_Text m_CheckoutObjectiveText;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedRequiredStoreLevelText;

	[SerializeField]
	private TMP_Text m_RequiredStoreLevelText;

	[SerializeField]
	private Button m_HireButton;

	[SerializeField]
	private Button m_FireButton;

	[Header("Colors")]
	[SerializeField]
	private Color m_CompletedRequirementColor;

	[SerializeField]
	private Color m_IncompletedRequirementColor;

	private bool m_Hired;

	private bool Level => false;

	private bool ReachedRequiredLevel => false;

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

	public int HelperId => 0;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void Hire()
	{
	}

	public void Fire()
	{
	}

	public void SwitchForGamepad()
	{
	}

	private void Setup()
	{
	}

	private void UpdateCheckoutObjective()
	{
	}

	private void UpdateRequiredStoreLevel(bool _)
	{
	}

	private void MoneyChanged(float _amount, MoneyManager.TransitionType _type)
	{
	}
}
