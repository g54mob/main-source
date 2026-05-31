using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class LocalizationManager : NoktaSingleton<LocalizationManager>
{
	[SerializeField]
	private DisplayTypeEntry[] m_DisplayTypeLocalizations;

	[SerializeField]
	private CustomerSpeechEntry[] m_CustomerSpeeches;

	[SerializeField]
	private List<string> m_ShoplifterSpeechEntry;

	[SerializeField]
	private InteractionWarningEntry[] m_InteractionWarnings;

	[SerializeField]
	private LocalizeStringEvent m_LocalizeStringEvent;

	[SerializeField]
	private PlayerPaymentTypeEntry[] m_PlayerPayments;

	private Dictionary<int, string> m_LocalizedProductNames;

	private Dictionary<int, string> m_LocalizedFurnitureNames;

	private Dictionary<int, string> m_LocalizedBucketNames;

	private Dictionary<int, string> m_LocalizedDefaultBucketNames;

	private Dictionary<int, string> m_LocalizedFloorBoxNames;

	private Dictionary<int, string> m_LocalizedProductLicenceNames;

	private Dictionary<int, string> m_LocalizedSectionNames;

	private Dictionary<int, string> m_LocalizedLoanNames;

	public string RandomShoplifterSpeechEntry => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public string LocalizedProductName(int productID)
	{
		return null;
	}

	public string LocalizedFurnitureName(int furnitureID)
	{
		return null;
	}

	public string LocalizedBucketName(int bucketID)
	{
		return null;
	}

	public string LocalizedFloorBoxName(int floorBoxId)
	{
		return null;
	}

	public string LocalizedProductLicenceName(int licenceID)
	{
		return null;
	}

	public string LocalizedSectionName(int sectionID)
	{
		return null;
	}

	public string LocalizedLoanName(int loanID)
	{
		return null;
	}

	public LocalizationEntry LocalizedEntry(DisplayType displayType)
	{
		return null;
	}

	public LocalizationEntry LocalizedEntry(CustomerSpeechType speechType)
	{
		return null;
	}

	public LocalizationEntry LocalizedEntry(InteractionWarningType warningType)
	{
		return null;
	}

	public LocalizationEntry LocalizedEntry(PlayerPaymentType paymentType)
	{
		return null;
	}

	private void InitLocalization()
	{
	}

	private void OnLocaleChanged(Locale newLocale)
	{
	}

	private void UpdateLocalization()
	{
	}
}
