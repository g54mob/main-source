using System.Collections.Generic;
using UnityEngine;

public class CheckoutBelt : MonoBehaviour
{
	private const float m_SlidingTime = 0.5f;

	public CheckoutBeltGrid gridPrefab;

	[SerializeField]
	private Checkout m_Checkout;

	[SerializeField]
	private float m_GridSize;

	[SerializeField]
	private Vector2Int m_LineSize;

	[SerializeField]
	private int m_VisibleLineLength;

	private CheckoutBeltGrid[][] m_Grid;

	private bool m_AvailableGrid;

	private List<Product> m_Products;

	public ItemQuantity ItemQuantities;

	public List<Product> Products => null;

	public CheckoutBeltGrid[][] Grid => null;

	private void Start()
	{
	}

	public void GenerateGrid()
	{
	}

	public void PlaceProducts(ItemQuantity shoppingCart)
	{
	}

	public void ProductScanned(Product product)
	{
	}

	public void ClearBelt()
	{
	}

	private void CheckSlidingProducts()
	{
	}

	private void SlideProducts(int emptyLineCount)
	{
	}

	private Vector3 GetLocalProductPosition(Vector2Int gridPosition, Vector2Int productSize)
	{
		return default(Vector3);
	}

	private void SetOccupied(Vector2Int baseGrid, Vector2Int productSize, bool occupied)
	{
	}
}
