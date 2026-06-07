using System;
using System.Collections.Generic;
using DV.CabControls;
using DV.Items;
using UnityEngine;

public class TrainPhysicsLod : MonoBehaviour
{
	public delegate void TrainPhysicsLodChangedDelegate(int currentLod);

	public const byte MAX_LOD = 5;

	private static readonly ushort[] lodThresholdsVR = new ushort[5] { 12, 25, 40, 80, 500 };

	private static readonly ushort[] lodThresholdsNonVR = new ushort[5] { 12, 30, 60, 200, 1000 };

	private TrainCar car;

	private TrainCarColliders colliders;

	private TrainCarInteriorPhysics interiorPhysics;

	private TrainItemActivityHandler trainItemActivityHandler;

	private DistanceLod distanceLod;

	public bool HasRegisteredItems
	{
		get
		{
			if (trainItemActivityHandler != null)
			{
				return trainItemActivityHandler.HasRegisteredItems;
			}
			return false;
		}
	}

	public int CurrentLod { get; private set; } = 5;

	public bool LockedHighestLOD { get; private set; }

	public bool PlayerInCar { get; private set; }

	public event TrainPhysicsLodChangedDelegate TrainPhysicsLodChanged;

	public void LockHighestLOD()
	{
		if (!LockedHighestLOD)
		{
			LockedHighestLOD = true;
			SetLod(-1, force: true);
		}
	}

	public void UnlockHighestLOD()
	{
		if (LockedHighestLOD)
		{
			LockedHighestLOD = false;
			if (PlayerInCar)
			{
				SetLod(-1, force: false);
			}
			else
			{
				SetLod(distanceLod.CurrentLod, force: false);
			}
		}
	}

	public void OnCreated(TrainCar car, TrainCarColliders colliders)
	{
		this.car = car;
		this.colliders = colliders;
		interiorPhysics = car.GetComponent<TrainCarInteriorPhysics>();
		trainItemActivityHandler = new TrainItemActivityHandler(this, car, this.colliders);
		distanceLod = car.gameObject.AddComponent<DistanceLod>();
		distanceLod.GetLodThresholds = delegate
		{
			Vector3 extents = car.Bounds.extents;
			float num = Mathf.Max(Mathf.Max(extents.x, extents.y), extents.z);
			ushort[] array = (ushort[])(VRManager.IsVREnabled() ? lodThresholdsVR : lodThresholdsNonVR).Clone();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (ushort)((float)(int)array[i] + num);
			}
			return array;
		};
		distanceLod.OnLodChanged += OnLodChanged;
		if (colliders != null)
		{
			colliders.CargoCollidersChanged += OnCargoCollidersChanged;
		}
	}

	private void OnCargoCollidersChanged(bool hasCargo)
	{
		if (hasCargo)
		{
			ForceCurrentLodUpdate();
		}
	}

	public void ResetToInitialState()
	{
		LockedHighestLOD = false;
		PlayerInCar = false;
		distanceLod.SetLod(5);
		trainItemActivityHandler.ResetToInitialState();
	}

	public void UnregisterAndActivateItems()
	{
		trainItemActivityHandler.UnregisterAndActivateItems();
	}

	public void SetupListeners(bool set)
	{
		if (set)
		{
			PlayerManager.CarChanged += OnPlayerCarChanged;
		}
		else
		{
			PlayerManager.CarChanged -= OnPlayerCarChanged;
		}
	}

	private void OnDestroy()
	{
		SetupListeners(set: false);
	}

	private void OnPlayerCarChanged(TrainCar newCar)
	{
		bool playerInCar = PlayerInCar;
		PlayerInCar = newCar == car;
		if (PlayerInCar)
		{
			SetLod(-1, force: false);
		}
		else if (playerInCar)
		{
			SetLod(distanceLod.CurrentLod, force: false);
		}
	}

	private void OnLodChanged(byte lod)
	{
		if (!PlayerInCar)
		{
			SetLod(lod, force: false);
		}
	}

	private void SetLod(int lod, bool force)
	{
		if (LockedHighestLOD)
		{
			if (!force)
			{
				return;
			}
			lod = -1;
		}
		if (lod == CurrentLod && !force)
		{
			return;
		}
		CurrentLod = lod;
		switch (CurrentLod)
		{
		case -1:
			colliders.ToggleItemsEnvironment(on: true);
			colliders.ToggleCameraDampening(on: true);
			colliders.ToggleWalkable(on: true);
			if (!car.IsInteriorLoaded)
			{
				car.LoadInterior();
			}
			interiorPhysics.syncColliders = true;
			if (car.AreDummyExternalInteractablesLoaded)
			{
				car.UnloadDummyExternalInteractables();
			}
			if (!car.AreExternalInteractablesLoaded)
			{
				car.LoadExternalInteractables();
			}
			break;
		case 0:
			colliders.ToggleItemsEnvironment(on: true);
			colliders.ToggleCameraDampening(on: false);
			colliders.ToggleWalkable(on: true);
			if (car.IsInteriorLoaded)
			{
				car.UnloadInterior();
			}
			interiorPhysics.syncColliders = true;
			if (car.AreDummyExternalInteractablesLoaded)
			{
				car.UnloadDummyExternalInteractables();
			}
			if (!car.AreExternalInteractablesLoaded)
			{
				car.LoadExternalInteractables();
			}
			break;
		case 1:
		case 2:
			colliders.ToggleItemsEnvironment(on: false);
			colliders.ToggleCameraDampening(on: false);
			colliders.ToggleWalkable(on: true);
			if (car.IsInteriorLoaded)
			{
				car.UnloadInterior();
			}
			interiorPhysics.syncColliders = true;
			if (car.AreExternalInteractablesLoaded)
			{
				car.SwitchExternalInteractablesToDummy();
			}
			else if (!car.AreDummyExternalInteractablesLoaded)
			{
				car.LoadDummyExternalInteractables();
			}
			break;
		case 3:
			colliders.ToggleItemsEnvironment(on: false);
			colliders.ToggleCameraDampening(on: false);
			colliders.ToggleWalkable(on: false);
			if (car.IsInteriorLoaded)
			{
				car.UnloadInterior();
			}
			interiorPhysics.syncColliders = false;
			if (car.AreExternalInteractablesLoaded)
			{
				car.UnloadExternalInteractables();
			}
			if (car.AreDummyExternalInteractablesLoaded)
			{
				car.UnloadDummyExternalInteractables();
			}
			break;
		case 4:
		case 5:
			colliders.ToggleItemsEnvironment(on: false);
			colliders.ToggleCameraDampening(on: false);
			colliders.ToggleWalkable(on: false);
			if (car.IsInteriorLoaded)
			{
				car.UnloadInterior();
			}
			interiorPhysics.syncColliders = false;
			if (car.AreExternalInteractablesLoaded)
			{
				car.UnloadExternalInteractables();
			}
			if (car.AreDummyExternalInteractablesLoaded)
			{
				car.UnloadDummyExternalInteractables();
			}
			break;
		default:
			throw new ArgumentOutOfRangeException("CurrentLod", CurrentLod, null);
		}
		this.TrainPhysicsLodChanged?.Invoke(CurrentLod);
	}

	public void ForceCurrentLodUpdate()
	{
		SetLod(CurrentLod, force: true);
	}

	public void AddItem(ItemBase item)
	{
		trainItemActivityHandler.Register(item);
	}

	public void RemoveItem(ItemBase item)
	{
		trainItemActivityHandler.Unregister(item);
	}

	public List<ItemSnapPointCoupler> GetCouplerSnapPoints()
	{
		return trainItemActivityHandler.GetCouplerSnapPoints();
	}

	public static void RemoveItemFromAnyCar(ItemBase item)
	{
		TrainPhysicsLod trainPhysicsLod = TrainCar.Resolve(item.gameObject)?.GetComponent<TrainPhysicsLod>();
		if (trainPhysicsLod != null)
		{
			trainPhysicsLod.RemoveItem(item);
		}
	}
}
