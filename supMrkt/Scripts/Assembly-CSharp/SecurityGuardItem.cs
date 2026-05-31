using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class SecurityGuardItem : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private SecurityGuardSO m_SecurityGuardSetup;

	[Header("Components")]
	[SerializeField]
	private LocalizeStringEvent m_SecurityGuardName;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedDailyWageText;

	[SerializeField]
	private TMP_Text m_DailyWageText;

	[SerializeField]
	private LocalizeStringEvent m_LocalizedHiringCostText;

	[SerializeField]
	private TMP_Text m_HiringCostText;

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

	private void UpdateRequiredStoreLevel(bool _)
	{
	}

	private void MoneyChanged(float _amount, MoneyManager.TransitionType _type)
	{
	}
}
