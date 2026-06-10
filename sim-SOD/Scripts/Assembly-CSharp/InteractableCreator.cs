using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class InteractableCreator : MonoBehaviour
{
	[Header("Debug")]
	public int debugFindID;

	private static InteractableCreator _instance;

	public static InteractableCreator Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public Interactable CreateCitizenInteractable(InteractablePreset preset, Human citizen, Transform trans, Evidence evidence)
	{
		return null;
	}

	public Interactable CreateTransformInteractable(InteractablePreset preset, Transform trans, Human belongsTo, Evidence evidence, Vector3 localPos, Vector3 localEuler, List<Interactable.Passed> passedVars)
	{
		return null;
	}

	public Interactable CreateFurnitureIntegratedInteractable(InteractablePreset preset, NewRoom room, FurnitureLocation furniture, Human belongsTo, Human writer, Human recevier, Vector3 localPos, Vector3 localEuler, InteractableController.InteractableID pairTo, FurniturePreset.SubObjectOwnership pairToOwner, LightingPreset isLight, List<Interactable.Passed> passedVars)
	{
		return null;
	}

	public Interactable CreateFurnitureSpawnedInteractableThreadSafe(InteractablePreset preset, NewRoom room, FurnitureLocation furniture, FurniturePreset.SubObject subObject, Human belongsTo, Human writer, Human recevier, List<Interactable.Passed> passedVars, LightingPreset isLight, object passedObject, string ddsOverride = "")
	{
		return null;
	}

	public Interactable CreateFurnitureSpawnedInteractable(InteractablePreset preset, FurnitureLocation furniture, FurniturePreset.SubObject subObject, Human belongsTo, Human writer, Human recevier, List<Interactable.Passed> passedVars, LightingPreset isLight, object passedObject, string ddsOverride = "")
	{
		return null;
	}

	public Interactable CreateWorldInteractable(InteractablePreset preset, Human belongsTo, Human writer, Human recevier, Vector3 worldPos, Vector3 worldEuler, List<Interactable.Passed> passedVars, object passedObject, string ddsOverride = "")
	{
		return null;
	}

	public Interactable CreateWorldInteractableFromMetaObject(MetaObject meta, InteractablePreset preset, Vector3 worldPos, Vector3 worldEuler)
	{
		return null;
	}

	public Interactable CreateDoorParentedInteractable(InteractablePreset preset, NewDoor door, Human belongsTo, Vector3 localPos, Vector3 localEuler, List<Interactable.Passed> passedVars, string ddsOverride = "")
	{
		return null;
	}

	public Interactable CreateMainLightInteractable(InteractablePreset preset, NewRoom room, Vector3 worldPos, Vector3 worldEuler, LightingPreset lightPreset, Interactable.LightConfiguration preconfiguredLight, int lightZoneSize = -1)
	{
		return null;
	}

	public Interactable CreateBookInteractable(InteractablePreset preset, NewRoom room, FurnitureLocation furniture, Human belongsTo, Vector3 localPos, Vector3 localEuler, BookPreset book)
	{
		return null;
	}

	public Interactable CreateFingerprintInteractable(Human belongsTo, Vector3 worldPos, Vector3 worldEuler, FingerprintScannerController.Print print)
	{
		return null;
	}

	public Interactable CreateFootprintInteractable(Human belongsTo, Vector3 worldPos, Vector3 worldEuler, GameplayController.Footprint print)
	{
		return null;
	}

	public Interactable CreateInteractableLock(InteractablePreset preset, FurnitureLocation furniture, Human belongsTo, Vector3 localPos, Vector3 localEuler, InteractableController.InteractableID pairTo)
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void FindInteractable()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ForceSpawnCheck()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListFurnitureParentSpawned()
	{
	}

	public int GetRoomBasedInteractableID(NewRoom r)
	{
		return 0;
	}

	public int GetFurnitureBasedInteractableID(FurnitureLocation f)
	{
		return 0;
	}
}
