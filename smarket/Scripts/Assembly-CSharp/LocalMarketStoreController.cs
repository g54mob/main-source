using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LocalMarketStoreController : MonoBehaviour
{
	[SerializeField]
	private LocalMarketProductDatabase m_Database;

	private PurchasableProduct[] m_Products;

	private bool m_IsOpened;

	public IEnumerable<PurchasableProduct> Products => null;

	public bool IsOpened => false;

	public event Action StoreOpened
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLicensePurchased(int obj)
	{
	}

	public bool TestAvailability()
	{
		return false;
	}

	public void UpdateAvailability()
	{
	}

	private void AssignDatabase()
	{
	}

	private void GenerateStore()
	{
	}
}
