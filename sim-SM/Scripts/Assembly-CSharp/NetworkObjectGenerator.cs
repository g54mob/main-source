using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.FloorPaintSystem;
using __Project__.Scripts.WallPaintSystem;

public class NetworkObjectGenerator : NoktaSingleton<NetworkObjectGenerator>
{
	private PhotonView m_PhotonView;

	public PhotonView PhotonView => null;

	public Box SpawnNetworkBoxClient(Vector3 position, Quaternion rotation, BoxData data, int PhotonViewID = -1)
	{
		return null;
	}

	public Box SpawnNetworkBox(Vector3 position, Quaternion rotation, BoxData data, int PhotonViewID = -1, int rackSlotIndex = -1)
	{
		return null;
	}

	public FloorBox SpawnFloorBox(Vector3 position, Quaternion rotation, FloorBoxData data)
	{
		return null;
	}

	public FurnitureBox SpawnNetworkFurnitureBox(Vector3 position, Quaternion rotation, FurnitureBoxData data, string interactionUserId = null)
	{
		return null;
	}

	public FurnitureBox SpawnNetworkFurnitureBox(Vector3 position, Quaternion rotation, FurnitureBoxData data, int uniqueID, string interactionUserId = null)
	{
		return null;
	}

	public GameObject SpawnNetworkRack(FurnitureSO furnitureSO, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public GameObject SpawnNetworkDisplay(FurnitureSO furnitureSO, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public GameObject SpawnNetworkVendingMachine(FurnitureSO furnitureSo, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public GameObject SpawnNetworkCheckout(FurnitureSO furnitureSO, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public GameObject SpawnNetworkCategorySign(FurnitureSO furnitureSO, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public GameObject SpawnNetworkScale(FurnitureSO furnitureSO, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public GameObject SpawnNetworkIceCreamStand(FurnitureSO furnitureSO, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public GameObject SpawnNetworkInteriorLight(FurnitureSO furnitureSO, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public GameObject SpawnNetworkSpeaker(FurnitureSO furnitureSO, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public GameObject SpawnNetworkSecurityCamera(FurnitureSO furnitureSO, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public GameObject SpawnNetworkAntenna(FurnitureSO furnitureSO, Vector3 position, Quaternion rotation, int furnitureBoxInteractionViewId = -1)
	{
		return null;
	}

	public Product SpawnProduct(Vector3 position, Quaternion rotation, ProductSO productSO, bool isDropped)
	{
		return null;
	}

	public GameObject SpawnVehicle(GameObject vehiclePrefab, VehicleData _vehicleData, Vector3 position, Quaternion rotation)
	{
		return null;
	}

	public PaintBucket SpawnPaintBucket(BucketSo bucketSo, Vector3 position, Quaternion rotation, object[] bucketData)
	{
		return null;
	}

	public IceCreamBucket SpawnIceCreamBucket(IceCreamFlavour bucketSo, Vector3 position, Quaternion rotation, object[] bucketData)
	{
		return null;
	}
}
