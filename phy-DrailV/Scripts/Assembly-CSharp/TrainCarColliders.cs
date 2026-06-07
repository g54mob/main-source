using System.Collections.Generic;
using System.Linq;
using DV;
using DV.Customization;
using UnityEngine;

public class TrainCarColliders : MonoBehaviour
{
	public delegate void CargoCollidersChangedDelegate(bool hasCargoColliders);

	public const string ROOT_NAME = "[colliders]";

	public const string COLLISION_NAME = "[collision]";

	public const string BOGIES_NAME = "[bogies]";

	public const string ITEMS_ENVIRONMENT_NAME = "[items]";

	public const string WALKABLE_NAME = "[walkable]";

	public const string CAMERA_DAMPENING_NAME = "[camera dampening]";

	public const string FALL_SAFETY_NAME = "[fall safety]";

	public const string CAB_NAME = "[cab]";

	public const string BOGIES_PHYSIC_MATERIAL = "Bogies_PM";

	public const string TRAINCAR_PHYSIC_MATERIAL = "TrainCar_PM";

	private static Option<PhysicMaterial> _bogiesPhysicMaterial;

	private static Option<PhysicMaterial> _trainCarPhysicMaterial;

	private Transform cargoColliderRoot;

	private Transform cargoCollisionRoot;

	private Transform cargoWalkableRoot;

	private Transform cargoItemsEnvironmentRoot;

	private Transform cargoCameraDampeningRoot;

	private TrainCar car;

	private Transform carColliderRoot;

	private Transform interior;

	private Transform bogiesRoot;

	private Transform collisionRoot;

	private Transform walkableRoot;

	private Transform itemsEnvironmentRoot;

	private Transform cameraDampeningRoot;

	private static PhysicMaterial BogiesPhysicMaterial
	{
		get
		{
			if (_bogiesPhysicMaterial.IsSome(out var value))
			{
				return value;
			}
			_bogiesPhysicMaterial = (value = Resources.Load("Bogies_PM", typeof(PhysicMaterial)) as PhysicMaterial);
			return value;
		}
	}

	private static PhysicMaterial TrainCarPhysicMaterial
	{
		get
		{
			if (_trainCarPhysicMaterial.IsSome(out var value))
			{
				return value;
			}
			_trainCarPhysicMaterial = (value = Resources.Load("TrainCar_PM", typeof(PhysicMaterial)) as PhysicMaterial);
			return value;
		}
	}

	public event CargoCollidersChangedDelegate CargoCollidersChanged;

	public static Bounds GetCollisionBounds(TrainCar car)
	{
		BoxCollider[] componentsInChildren = GetCollision(GetCollidersRoot(car.transform)).GetComponentsInChildren<BoxCollider>();
		if (componentsInChildren.Length == 0)
		{
			return default(Bounds);
		}
		Bounds result = BoundsUtil.BoxColliderAABB(componentsInChildren[0], car.transform);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			result.Encapsulate(BoundsUtil.BoxColliderAABB(componentsInChildren[i], car.transform));
		}
		return result;
	}

	private static Transform GetCollidersRoot(Transform root)
	{
		return root.Find("[colliders]");
	}

	private static Transform GetCollision(Transform collidersRoot)
	{
		return collidersRoot.Find("[collision]");
	}

	private static Transform GetBogies(Transform collidersRoot)
	{
		return collidersRoot.Find("[bogies]");
	}

	private static Transform GetWalkable(Transform collidersRoot)
	{
		return collidersRoot.Find("[walkable]");
	}

	private static Transform GetItemsEnvironment(Transform collidersRoot)
	{
		return collidersRoot.Find("[items]");
	}

	private static Transform GetCameraDampening(Transform collidersRoot)
	{
		return collidersRoot.Find("[camera dampening]");
	}

	public Transform GetCargoCollision()
	{
		return cargoCollisionRoot;
	}

	public Transform GetBogies()
	{
		return bogiesRoot;
	}

	public void TempDisableCollisionColliders(bool disable)
	{
		Collider[] componentsInChildren = collisionRoot.GetComponentsInChildren<Collider>();
		Collider[] array = ((cargoCollisionRoot != null) ? cargoCollisionRoot.GetComponentsInChildren<Collider>() : null);
		Collider[] array2 = componentsInChildren;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].isTrigger = disable;
		}
		if (array != null)
		{
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].isTrigger = disable;
			}
		}
	}

	public void ToggleItemsEnvironment(bool on)
	{
		Toggle(itemsEnvironmentRoot, on);
		Toggle(cargoItemsEnvironmentRoot, on);
	}

	public void ToggleCameraDampening(bool on)
	{
		Toggle(cameraDampeningRoot, on);
		Toggle(cargoCameraDampeningRoot, on);
	}

	public void ToggleWalkable(bool on)
	{
		Toggle(walkableRoot, on);
		Toggle(cargoWalkableRoot, on);
	}

	private void Toggle(Transform target, bool on)
	{
		if ((bool)target)
		{
			GameObject gameObject = target.gameObject;
			if (gameObject.activeSelf != on)
			{
				gameObject.SetActive(on);
			}
		}
	}

	private void InitCollisionColliders(Transform collisionRoot)
	{
		Collider[] componentsInChildren = collisionRoot.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].sharedMaterial = TrainCarPhysicMaterial;
		}
		collisionRoot.SetParent(car.transform);
		collisionRoot.localPosition = Vector3.zero;
		collisionRoot.localRotation = Quaternion.identity;
	}

	private void ReparentToInterior(Transform objectToReparent)
	{
		objectToReparent.SetParent(interior, worldPositionStays: true);
	}

	private static string ValidateCommon(Transform root)
	{
		Transform collidersRoot = GetCollidersRoot(root);
		if (!collidersRoot)
		{
			return "Couldn't find colliders root object '[colliders]' on '" + root.name + "'";
		}
		Transform collision = GetCollision(collidersRoot);
		if (!collision)
		{
			return "Couldn't find collision object '[collision]' on '" + root.name + "'";
		}
		Transform walkable = GetWalkable(collidersRoot);
		if (!walkable)
		{
			return "Couldn't find walkable colliders object '[walkable]' on '" + root.name + "'";
		}
		Transform itemsEnvironment = GetItemsEnvironment(collidersRoot);
		if (!itemsEnvironment)
		{
			return "Couldn't find items environment colliders object '[items]' on '" + root.name + "'";
		}
		Transform cameraDampening = GetCameraDampening(collidersRoot);
		if (!cameraDampening)
		{
			return "Couldn't find camera dampening colliders object '[camera dampening]' on '" + root.name + "'";
		}
		IReadOnlyCollection<int> layersRecursive = walkable.gameObject.GetLayersRecursive();
		if (layersRecursive.Count != 1 || layersRecursive.First() != Layers.DVLayer.Train_Walkable.ToInt())
		{
			return "Bad layers on '[walkable]' on '" + root.name + "'";
		}
		IReadOnlyCollection<int> layersRecursive2 = itemsEnvironment.gameObject.GetLayersRecursive();
		if (layersRecursive2.Count != 1 || layersRecursive2.First() != Layers.DVLayer.Train_Interior.ToInt())
		{
			return "Bad layers on '[items]' on '" + root.name + "'";
		}
		IReadOnlyCollection<int> layersRecursive3 = cameraDampening.gameObject.GetLayersRecursive();
		if (layersRecursive3.Count != 1 || layersRecursive3.First() != Layers.DVLayer.Camera_Dampening.ToInt())
		{
			return "Bad layers on '[camera dampening]' on '" + root.name + "'";
		}
		if (!collision.gameObject.activeSelf)
		{
			return "Collision root '[collision]' on '" + root.name + "' must be active in the prefab";
		}
		if (walkable.gameObject.activeSelf)
		{
			return "Walkable root '[walkable]' on '" + root.name + "' must be disabled in the prefab";
		}
		if (itemsEnvironment.gameObject.activeSelf)
		{
			return "Items root '[items]' on '" + root.name + "' must be disabled in the prefab";
		}
		if (cameraDampening.gameObject.activeSelf)
		{
			return "Camera dampening root '[camera dampening]' on '" + root.name + "' must be disabled in the prefab";
		}
		if (collision.localPosition != Vector3.zero || collision.localRotation != Quaternion.identity || collision.localScale != Vector3.one)
		{
			return "Bad offset detected for [collision] on '" + root.name + "'";
		}
		Collider[] componentsInChildren = walkable.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			if (collider.name.StartsWith("[fall safety]") && !collider.name.Equals("[fall safety]"))
			{
				return "Bad fall safety name detected in [walkable] on '" + root.name + "'";
			}
		}
		int num = root.GetComponents<Collider>().Length;
		if (num != 0)
		{
			return $"Root object of car/cargo '{root.name}' shouldn't have any colliders attached, but {num} were found";
		}
		return null;
	}

	public void SetupCargo(GameObject cargoGO)
	{
		bool flag = cargoGO != null;
		if (flag)
		{
			cargoColliderRoot = GetCollidersRoot(cargoGO.transform);
			Setup_Cargo_CarCollision(cargoColliderRoot);
			Setup_Cargo_Walkable(cargoColliderRoot);
			Setup_Cargo_ItemsEnvironment(cargoColliderRoot);
			Setup_Cargo_CameraDampening(cargoColliderRoot);
		}
		else if (cargoCollisionRoot != null)
		{
			Object.Destroy(cargoCollisionRoot.gameObject);
		}
		this.CargoCollidersChanged?.Invoke(flag);
	}

	private void Setup_Cargo_CarCollision(Transform cargoCollidersRoot)
	{
		cargoCollisionRoot = GetCollision(cargoCollidersRoot);
		InitCollisionColliders(cargoCollisionRoot);
	}

	private void Setup_Cargo_Walkable(Transform cargoCollidersRoot)
	{
		cargoWalkableRoot = GetWalkable(cargoCollidersRoot);
		if ((bool)cargoWalkableRoot)
		{
			CharacterReparentTarget characterReparentTarget = cargoWalkableRoot.gameObject.AddComponent<CharacterReparentTarget>();
			characterReparentTarget.target = interior;
			characterReparentTarget.isTrain = true;
		}
	}

	private void Setup_Cargo_ItemsEnvironment(Transform cargoCollidersRoot)
	{
		cargoItemsEnvironmentRoot = GetItemsEnvironment(cargoCollidersRoot);
		_ = (bool)cargoItemsEnvironmentRoot;
	}

	private void Setup_Cargo_CameraDampening(Transform cargoCollidersRoot)
	{
		cargoCameraDampeningRoot = GetCameraDampening(cargoCollidersRoot);
		_ = (bool)cargoCameraDampeningRoot;
	}

	public static string ValidateCargo(Transform cargo)
	{
		return ValidateCommon(cargo);
	}

	public void SetupTrainCar(TrainCar car, Transform interior)
	{
		this.car = car;
		this.interior = interior;
		carColliderRoot = GetCollidersRoot(car.transform);
		Setup_CarCollision_And_Bogies();
		Setup_Walkable();
		Setup_ItemsEnvironment();
		Setup_CameraDampening();
		Transform transform = car.transform.Find("[cab]");
		if ((bool)transform)
		{
			transform.SetParent(interior, worldPositionStays: true);
			car.cabTeleportDestination = transform.GetComponentInChildren<CabTeleportDestination>(includeInactive: true);
		}
		SetupListeners(on: true);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			car.OnRerailed += OnRerailed;
			car.OnDerailed += OnDerailed;
		}
		else
		{
			car.OnRerailed -= OnRerailed;
			car.OnDerailed -= OnDerailed;
		}
	}

	private void OnDerailed(TrainCar _)
	{
		bogiesRoot.gameObject.SetActive(value: true);
	}

	private void OnRerailed()
	{
		bogiesRoot.gameObject.SetActive(value: false);
	}

	public void SetBogieColliders(bool trainDerailed)
	{
		bogiesRoot.gameObject.SetActive(trainDerailed);
	}

	private void Setup_CarCollision_And_Bogies()
	{
		collisionRoot = GetCollision(carColliderRoot);
		bogiesRoot = GetBogies(carColliderRoot);
		InitCollisionColliders(collisionRoot);
		PhysicMaterial bogiesPhysicMaterial = BogiesPhysicMaterial;
		Collider[] componentsInChildren = bogiesRoot.GetComponentsInChildren<Collider>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].sharedMaterial = bogiesPhysicMaterial;
		}
		bogiesRoot.SetParent(car.transform);
		bogiesRoot.gameObject.SetActive(value: false);
	}

	private void Setup_Walkable()
	{
		walkableRoot = GetWalkable(carColliderRoot);
		if ((bool)walkableRoot)
		{
			ReparentToInterior(walkableRoot);
			CharacterReparentTarget characterReparentTarget = walkableRoot.gameObject.AddComponent<CharacterReparentTarget>();
			characterReparentTarget.target = interior;
			characterReparentTarget.isTrain = true;
		}
	}

	private void Setup_ItemsEnvironment()
	{
		itemsEnvironmentRoot = GetItemsEnvironment(carColliderRoot);
		if ((bool)itemsEnvironmentRoot)
		{
			if (TryGetComponent<CustomizationPlacementMeshes>(out var component))
			{
				component.TryGenerateInteriorCols(car, itemsEnvironmentRoot);
				component.GenerateCustomizationMeshes(car);
			}
			if ((bool)car.carLivery.interiorPrefab && car.carLivery.interiorPrefab.TryGetComponent<CustomizationPlacementMeshes>(out component))
			{
				component.GenerateCustomizationMeshes(car);
			}
			if ((bool)car.carLivery.externalInteractablesPrefab && car.carLivery.externalInteractablesPrefab.TryGetComponent<CustomizationPlacementMeshes>(out component))
			{
				component.GenerateCustomizationMeshes(car);
			}
			ReparentToInterior(itemsEnvironmentRoot);
		}
	}

	private void Setup_CameraDampening()
	{
		cameraDampeningRoot = GetCameraDampening(carColliderRoot);
		if ((bool)cameraDampeningRoot)
		{
			ReparentToInterior(cameraDampeningRoot);
		}
	}

	public static string ValidateTrainCar(Transform car)
	{
		Transform collidersRoot = GetCollidersRoot(car);
		Transform bogies = GetBogies(collidersRoot);
		if (!bogies)
		{
			return "Couldn't find bogies object '[bogies]' on '" + car.name + "'";
		}
		IReadOnlyCollection<int> layersRecursive = bogies.gameObject.GetLayersRecursive();
		if (layersRecursive.Count != 1 || layersRecursive.First() != Layers.DVLayer.Train_Big_Collider.ToInt())
		{
			return "Bad layers on '[bogies]' on '" + car.name + "'";
		}
		Collider[] componentsInChildren = GetWalkable(collidersRoot).GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			if (collider.name == "[fall safety]" && !collider.TryGetComponent<TeleportArcPassThrough>(out var _))
			{
				return "Missing TeleportArcPassThrough on one of [fall safety] colliders on car'" + car.name + "'";
			}
		}
		return ValidateCommon(car);
	}
}
