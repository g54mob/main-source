using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using PG;
using UnityEngine;

public class VehicleManager : NoktaSingleton<VehicleManager>
{
	public bool VehicleInUse;

	public CarController CurrentCarController;

	[SerializeField]
	private PlayerController m_PlayerController;

	[SerializeField]
	private List<GameObject> m_VehiclePrefabs;

	[SerializeField]
	private List<GameObject> m_Vehicles;

	[SerializeField]
	private Transform m_SpawnPoint;

	[SerializeField]
	private BoxCollider m_ParkAreaSpawnControlTrigger;

	public Action<int> onVehicleBought;

	public Action<int> onVehicleBoughtNetwork;

	public Action<int> onVehicleReset;

	public Action<int, float> onVehicleSold;

	public Action<CarController> onEnterVehicle;

	public Action onExitVehicle;

	public bool IsResetting;

	public List<VehicleSaleItem> VehicleSaleItems;

	[SerializeField]
	private List<Vector3> m_Waypoints;

	private Coroutine _freezeRoutine;

	private Tween m_ResetTween;

	public List<GameObject> Vehicles => null;

	public event Action VehicleRemoved
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

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	public void SubscribeSaleItems(VehicleSaleItem saleItem)
	{
	}

	public VehicleSaleItem GetVehicleSaleItem(int index)
	{
		return null;
	}

	private void OnEnterVehicle(CarController controller)
	{
	}

	public void OnExitVehicle(CarController controller)
	{
	}

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void OnVehicleSold(int _VehicleLevel, float _Price)
	{
	}

	private void OnVehicleBought(int _VehicleLevel)
	{
	}

	private void OnVehicleReset(int _VehicleLevel)
	{
	}

	private void OnPressGameSave()
	{
	}

	public void RespawnVehicle(Transform _Vehicle)
	{
	}

	private void SpawnVehicle(int _VehicleLevel)
	{
	}

	public void SetVehicleToIndex(int _vehicleLevel, GameObject _vehicle)
	{
	}

	private void ResetVehicle(int _VehicleLevel)
	{
	}

	public void SetResetStatus()
	{
	}

	public bool IsSpawnPointAvailable()
	{
		return false;
	}

	public Vector3 FindClosestWaypoint()
	{
		return default(Vector3);
	}

	public bool IsResetPointAvailable(Vector3 _point)
	{
		return false;
	}

	private void DrawCube(Vector3 _point)
	{
	}

	private void OnDrawGizmosSelected()
	{
	}

	public GameObject GetVehicleFromIndex(int vehicleLevel)
	{
		return null;
	}

	public void RemoveVehicle(int vehicleLevel)
	{
	}

	public bool IsVehiclePurchased(int vehicleLevel)
	{
		return false;
	}

	public void AddVehicle(int vehicleLevel)
	{
	}

	public CarController GetVehicleOfIndex(int _index)
	{
		return null;
	}

	public VehicleData GetVehicleData(int index)
	{
		return null;
	}

	public IEnumerable<GameObject> GetVehicles()
	{
		return null;
	}
}
