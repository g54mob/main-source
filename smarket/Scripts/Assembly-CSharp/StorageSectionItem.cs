using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class StorageSectionItem : MonoBehaviour
{
	[Header("Components")]
	[SerializeField]
	private LocalizeStringEvent m_SectionName;

	[SerializeField]
	private TMP_Text m_CostText;

	[Header("Required Level")]
	[SerializeField]
	private LocalizeStringEvent m_RequiredLevelLocalizedText;

	[SerializeField]
	private TMP_Text m_RequiredLevelText;

	[SerializeField]
	private LocalizeStringEvent m_RequiredSectionLocalizedText;

	[SerializeField]
	private TMP_Text m_RequiredSectionText;

	[SerializeField]
	private Color m_ReachedRequiredStoreLevelColor;

	[SerializeField]
	private Color m_NotReachedRequiredStoreLevelColor;

	[Header("Purchase Button")]
	[SerializeField]
	private Button m_PurchaseButton;

	private float m_Cost;

	private int m_sectionID;

	private StorageSO m_Section;

	public int ID => 0;

	private bool m_ReachedRequiredStoreLevel => false;

	private bool m_ReachedRequiredSection => false;

	public void Setup(int sectionID)
	{
	}

	public void Purchase()
	{
	}

	private void OnStoreLevelChanged(bool increase)
	{
	}

	private void OnSectionPurchased(int id)
	{
	}

	private void UpdatePurchaseButton(float _amount, MoneyManager.TransitionType _type)
	{
	}

	private void OnSectionsDisabled()
	{
	}

	private void OnStoreLevelDisabled()
	{
	}

	private void OnMoneyManagerDisabled()
	{
	}

	private void CheckRequirements()
	{
	}
}
