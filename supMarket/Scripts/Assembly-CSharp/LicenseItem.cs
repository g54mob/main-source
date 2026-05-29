using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class LicenseItem : MonoBehaviour
{
	[Header("Components")]
	[SerializeField]
	private TMP_Text m_LicenseName;

	[SerializeField]
	private TMP_Text m_ProductItem;

	[SerializeField]
	private TMP_Text m_CostText;

	[SerializeField]
	private Transform m_ProductListContent;

	[SerializeField]
	private LayoutGroup m_DisplayTypeLayout;

	[SerializeField]
	private float m_ProductTypeTextSize;

	[Header("Required Level")]
	[SerializeField]
	private LocalizeStringEvent m_RequiredLevelLocalizedText;

	[SerializeField]
	private TMP_Text m_RequiredLevelText;

	[SerializeField]
	private Color m_ReachedRequiredStoreLevelColor;

	[SerializeField]
	private Color m_NotReachedRequiredStoreLevelColor;

	[Header("Purchase Button")]
	[SerializeField]
	private Button m_PurchaseButton;

	[SerializeField]
	private TMP_Text m_PurchaseButtonText;

	[Header("DLC Category")]
	[SerializeField]
	private LocalizeStringEvent m_DLCCategoryText;

	[Header("Display Type")]
	[SerializeField]
	private GameObject m_DisplayTypeImagePrefab;

	[SerializeField]
	private SerializedDictionary<DisplayType, Sprite> m_DisplayTypeImages;

	private float m_Cost;

	private int m_licenseID;

	private ProductLicenseSO m_ProductLicense;

	private bool m_Purchased;

	private List<DisplayType> m_IncludedDisplayTypes;

	private List<Image> m_CreatedDisplayTypeImages;

	public int LicenseID => 0;

	private bool m_AvailableStoreLevel => false;

	public void Setup(int licenseID)
	{
	}

	private void SetupDisplayTypeLayout()
	{
	}

	private Image CreateDisplayTypeImage(DisplayType displayType)
	{
		return null;
	}

	public void Purchase()
	{
	}

	public void Purchase_NetworkOrder()
	{
	}

	private void SpawnProductsList()
	{
	}

	private void UpdatePurchaseButton(float _amount, MoneyManager.TransitionType _type)
	{
	}

	private void CheckIfReachedRequiredLevel(bool _)
	{
	}

	private void OnMoneyManagerDisabled()
	{
	}

	private void OnStoreLevelDisabled()
	{
	}
}
