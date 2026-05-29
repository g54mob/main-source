using System;
using System.Collections.Generic;
using MyBox;
using UnityEngine;

public class Crate : MonoBehaviour
{
	private enum RotationAxis
	{
		Default = 0,
		X = 1,
		Y = 2,
		Z = 3
	}

	public const float m_SpreadForce = 22f;

	public bool IsGuardCrate;

	public bool isCrateFull;

	public bool IsUnlimitedCapacity;

	private bool m_IsEnabled;

	private bool m_HasProduct;

	private GridPoint[,,] m_Grid;

	[SerializeField]
	private GameObject m_CrateModel;

	[SerializeField]
	private Transform m_CrateArea;

	[SerializeField]
	private Transform leftCover;

	[SerializeField]
	private Transform rightCover;

	[SerializeField]
	private Vector3Int m_Size;

	[SerializeField]
	private float m_Distance;

	[SerializeField]
	private List<Product> m_Product;

	[SerializeField]
	private List<Product> m_UnlimitedProducts;

	[SerializeField]
	private Vector3 m_EnablePosition;

	[SerializeField]
	private Vector3 m_DisablePosition;

	public Action onCrateBought;

	public Action onCrateEnabled;

	[SerializeField]
	private bool _shouldDrawGizmos;

	public bool IsEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool HasProduct => false;

	public bool HasProductOnUnlimitedList => false;

	public List<Product> Products
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Product> UnlimitedProducts
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public GameObject CrateModel
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void OnDrawGizmos()
	{
	}

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	public void DisableCrateInstant()
	{
	}

	public void SpreadSingle()
	{
	}

	public void SpreadSingleNetwork()
	{
	}

	public void SpreadAllProduct()
	{
	}

	public void SpreadAllProductNetwork()
	{
	}

	public bool TryToAddProduct(ProductSO productSO)
	{
		return false;
	}

	public void AddProduct(Product product, bool canReorder, bool isJump)
	{
	}

	public void AddProductNetwork(Product product, bool canReorder, bool isJump)
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void ReorderGrid()
	{
	}

	public void ChangeProductIndex()
	{
	}

	public bool IsTargetProductExist(DisplaySlot targetDisplaySlot)
	{
		return false;
	}

	public bool IsTargetProductExist(VendingSlot vendingSlot)
	{
		return false;
	}

	public Product RemoveProduct(DisplayType ProductDisplayType)
	{
		return null;
	}

	public Product RemoveProductVending()
	{
		return null;
	}

	public Product RemoveProductBaker()
	{
		return null;
	}

	public Product RemoveProduct()
	{
		return null;
	}

	public Product RemoveProduct(bool isFirst)
	{
		return null;
	}

	public Product RemoveProductBaker(int targetProductID)
	{
		return null;
	}

	public Product RemoveProduct(int targetProductID)
	{
		return null;
	}

	public void OpenCrateModel(bool isOpen)
	{
	}

	public bool HasEnoughSpace(ItemQuantity itemQuantity, int NextProductID)
	{
		return false;
	}

	private void UpdateSaveData()
	{
	}

	public void OpenCrateCovers()
	{
	}

	private void LoadProductFromSave()
	{
	}

	public void InstantLoadCrate(int[] CrateProductsData)
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	private void CreateGrid()
	{
	}

	private bool ScanGrid(Product product, bool shouldPlace, bool isJump = true, bool canReorder = false)
	{
		return false;
	}

	private bool ScanGrid(ProductSO productSO)
	{
		return false;
	}

	private void PlaceProduct(GridPoint gridPoint, Product product, bool isJump, RotationAxis _Axis, bool canReorder)
	{
	}

	private Vector3 GetColliderDiff(ProductSO productSO, RotationAxis _Axis)
	{
		return default(Vector3);
	}

	private bool IsPointAvailable(GridPoint gridPoint, Vector3Int productSize)
	{
		return false;
	}

	private bool IsInRange(GridPoint gridPoint, Vector3Int productSize)
	{
		return false;
	}

	private void Animate(bool isOpen)
	{
	}
}
