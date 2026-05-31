using System;
using System.Collections.Generic;
using UnityEngine;

public class ProductLicenseManager : NoktaSingleton<ProductLicenseManager>
{
	[SerializeField]
	private List<ProductLicenseSO> m_Licenses;

	[SerializeField]
	private List<ProductLicenseSO> m_DefaultUnlockedLicenses;

	private List<int> m_UnlockedLicenses;

	private List<int> m_UnlockedProducts;

	private List<int> m_AllProducts;

	private List<int> m_ProductsExpectedByLevel;

	private List<int> m_DiscountedProducts;

	public Action<int> onLicensePurchased;

	public Action onDisabled;

	public Action onSlaveLicencesLoaded;

	public bool HasLicencesLoaded;

	public bool HasSlaveLicencesLoaded;

	private LicensesTab m_LicensesTab;

	public List<int> UnlockedProducts => null;

	public List<int> AllPoducts => null;

	public List<int> ProductsExpectedByLevel => null;

	public List<int> DiscountedProducts => null;

	public int UnlockedLicenseCount => 0;

	public bool HasAllLicencesUnlocked => false;

	public List<ProductLicenseSO> Licenses => null;

	public List<int> UnlockedLicences => null;

	public bool IsLicenseUnlocked(int id)
	{
		return false;
	}

	public bool IsProductLicenseUnlocked(int id)
	{
		return false;
	}

	private void Awake()
	{
	}

	public void LoadSaveProgress()
	{
	}

	private void OnDisable()
	{
	}

	public void PurchaseLicense(int licenseID)
	{
	}

	private void InitializeLicensesMenu()
	{
	}

	public void PurchaseLicense_Order(int licenseID)
	{
	}

	public void ClearAllLicences()
	{
	}

	private void UpdateUnlockedProducts()
	{
	}

	private void UpdateExpectedProducts(bool levelUp)
	{
	}

	private void UnsubscribeStoreLevelManager()
	{
	}

	private void LoadAllProducts()
	{
	}

	private void LoadProductsExpectedByLevel()
	{
	}
}
