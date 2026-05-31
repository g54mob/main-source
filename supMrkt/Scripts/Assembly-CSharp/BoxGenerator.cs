using UnityEngine;
using __Project__.Scripts.FloorPaintSystem;
using __Project__.Scripts.WallPaintSystem;

public class BoxGenerator : NoktaSingleton<BoxGenerator>
{
	[SerializeField]
	private FurnitureBox[] m_ShelfBoxPrefabs;

	[SerializeField]
	private FloorBox m_FloorBoxPrefab;

	[SerializeField]
	private Box m_ProduceBox;

	public Box SpawnBox(Vector3 position, Quaternion rotation, BoxData data)
	{
		return null;
	}

	public Box SpawnBoxInRack(Vector3 position, Quaternion rotation, BoxData data, Transform parent, Rack OwnerRack, RackSlot RackSlot)
	{
		return null;
	}

	public Box SpawnBoxLocalMarket(ProductSO product, Vector3 position, Quaternion rotation)
	{
		return null;
	}

	public Box SpawnBox(ProductSO product, Vector3 position, Quaternion rotation, Transform parent)
	{
		return null;
	}

	public Box SpawnBox(ProductSO product, Vector3 position, Quaternion rotation)
	{
		return null;
	}

	public FurnitureBox SpawnBox(FurnitureSO shelf, Vector3 position, Quaternion rotation, int uniqueId, FurnitureBoxData boxData = null, string interactionUserId = null)
	{
		return null;
	}

	public FurnitureBox SpawnBox(FurnitureSO shelf, Vector3 position, Quaternion rotation, FurnitureBoxData boxData = null, string interactionUserId = null)
	{
		return null;
	}

	public FurnitureBox SpawnBox(FurnitureSO shelf, Vector3 position, Quaternion rotation, Transform parent)
	{
		return null;
	}

	public FurnitureBox SpawnBox(FurnitureSO shelf, Vector3 position, Quaternion rotation, Transform parent, VendingData vendingDataParam)
	{
		return null;
	}

	public FurnitureBox SpawnBox(BucketData data, BucketSo bucket, Vector3 position, Quaternion rotation, bool newBox, string furnitureBoxInteractionViewId = null)
	{
		return null;
	}

	public FurnitureBox SpawnBox(Vector3 position, Quaternion rotation, FurnitureBoxData data)
	{
		return null;
	}

	public FloorBox SpawnBox(Vector3 position, Quaternion rotation, FloorBoxData data)
	{
		return null;
	}

	private Box GetBoxBySize(BoxSize boxSize)
	{
		return null;
	}

	private FurnitureBox GetShelfBoxBySize(BoxSize boxSize)
	{
		return null;
	}
}
