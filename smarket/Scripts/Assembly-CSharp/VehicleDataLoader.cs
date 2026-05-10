using UnityEngine;

public class VehicleDataLoader : MonoBehaviour
{
	[SerializeField]
	private int m_Index;

	private VehicleData m_VehicleData;

	private IPlacementArea m_PlacementArea;

	[SerializeField]
	private OrderPaperBag m_OrderPaperBagPrefab;

	public VehicleData VehicleData
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnBoxAdded(SortableBox obj)
	{
	}

	private void OnBoxReleased(SortableBox obj)
	{
	}

	private void Start()
	{
	}

	private void Load()
	{
	}

	private void ApplyVehicleData()
	{
	}

	public int GetVehicleIndex()
	{
		return 0;
	}
}
