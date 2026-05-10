using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.BakeryWorker;
using __Project__.Scripts.FloorPaintSystem;
using __Project__.Scripts.WallPaintSystem;

public class IDManager : NoktaSingleton<IDManager>
{
	[SerializeField]
	private List<ProductSO> m_Products;

	[SerializeField]
	private List<BankCreditSO> m_BankCredits;

	[SerializeField]
	private List<ProductLicenseSO> m_ProductLicenses;

	[SerializeField]
	private List<FurnitureSO> m_Furnitures;

	[SerializeField]
	private List<BucketSo> m_Buckets;

	[SerializeField]
	private List<FloorSo> m_Floors;

	[SerializeField]
	private List<DisplaySO> m_Displays;

	[SerializeField]
	private List<SectionSO> m_Sections;

	[SerializeField]
	private List<StorageSO> m_StorageSections;

	[SerializeField]
	private List<CashierSO> m_Cashiers;

	[SerializeField]
	private List<RestockerSO> m_Restockers;

	[SerializeField]
	private List<CustomerHelperSO> m_CustomerHelpers;

	[SerializeField]
	private List<SecurityGuardSO> m_SecurityGuards;

	[SerializeField]
	private List<JanitorSO> m_Janitor;

	[SerializeField]
	private List<BakerSO> m_Bakers;

	[SerializeField]
	private List<IceCreamHelperSO> m_IceCreamHelpers;

	[SerializeField]
	private List<BoxSO> m_Boxes;

	[SerializeField]
	private List<IceCreamFlavour> m_IceCreamFlavours;

	[SerializeField]
	private List<IceCreamTopping> m_IceCreamToppings;

	public int BoxUniqueIdCount;

	public List<ProductSO> Products => null;

	public List<ProductLicenseSO> ProductLicenses => null;

	public List<FurnitureSO> Furnitures => null;

	public List<SectionSO> Sections => null;

	public List<BankCreditSO> Loans => null;

	public List<StorageSO> StorageSections => null;

	public List<BoxSO> Boxes => null;

	public List<BucketSo> Buckets => null;

	public List<FloorSo> Floors => null;

	public IReadOnlyList<IceCreamFlavour> IceCreamFlavours => null;

	public int DisplayIDByType(DisplayType displayType)
	{
		return 0;
	}

	public IceCreamFlavour IceCreamFlavour(int id)
	{
		return null;
	}

	public IceCreamTopping IceCreamTopping(int toppingId)
	{
		return null;
	}

	public IceCreamFlavour IceCreamFlavourOfProduct(int productId)
	{
		return null;
	}

	public ProductSO ProductSO(int id)
	{
		return null;
	}

	public ProductLicenseSO ProductLicenseSO(int id)
	{
		return null;
	}

	public FurnitureSO FurnitureSO(int id)
	{
		return null;
	}

	public BucketSo BucketSo(int id)
	{
		return null;
	}

	public SectionSO SectionSO(int id)
	{
		return null;
	}

	public StorageSO StorageSO(int id)
	{
		return null;
	}

	public BankCreditSO BankCreditSO(int id)
	{
		return null;
	}

	public CashierSO CashierSO(int id)
	{
		return null;
	}

	public RestockerSO RestockerSO(int id)
	{
		return null;
	}

	public CustomerHelperSO CustomerHelperSO(int id)
	{
		return null;
	}

	public SecurityGuardSO SecurityGuardSO(int id)
	{
		return null;
	}

	public JanitorSO JanitorSO(int id)
	{
		return null;
	}

	public BakerSO BakerSO(int id)
	{
		return null;
	}

	public BoxSO BoxSO(int id)
	{
		return null;
	}

	public FloorSo FloorSO(int floorId)
	{
		return null;
	}

	public int GenerateBoxUniqueID()
	{
		return 0;
	}

	public IceCreamHelperSO IceCreamHelperSO(int id)
	{
		return null;
	}
}
