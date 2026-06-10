using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

public class PlayerApartmentController : MonoBehaviour
{
	[Serializable]
	public class PlayerFurniture
	{
		public Toolbox.MaterialKey matKey;

		public string presetStr;

		[NonSerialized]
		public FurniturePreset preset;

		[NonSerialized]
		public FurnitureLocation placement;
	}

	[Serializable]
	public class FurniturePlacement
	{
		public FurniturePreset preset;

		public FurnitureLocation existing;

		public Toolbox.MaterialKey materialKey;

		public ArtPreset art;

		public NewNode anchorNode;

		public List<NewNode> coversNodes;

		public int angle;

		public Vector3 offset;
	}

	public delegate void FurnitureChange();

	[Header("Components")]
	public Transform placementCursor;

	[Header("Settings")]
	public Color placementValidLerpColour;

	public Color placementInvalidLerpColour;

	public FirstPersonItem furnitureFPSItem;

	public FurnitureCluster nullCluster;

	[Header("State")]
	public List<Color> swatches;

	public List<FurnitureLocation> furnitureStorage;

	public List<Interactable> itemStorage;

	[Space(7f)]
	public bool furniturePlacementMode;

	public bool placeExistingRoomObject;

	public FurniturePlacement furnPlacement;

	public NewRoom furnPlacementRoom;

	public GameObject spawnedPlacementObj;

	public MeshRenderer spawnedPlacementMesh;

	public int furnitureRotation;

	public List<Material> cloneMaterials;

	public List<Collider> placementColliders;

	public float materialPulse;

	public Color lerpColour;

	[Space(7f)]
	public NewNode placementNode;

	public bool isPlacementValid;

	[Space(7f)]
	public bool decoratingMode;

	public MaterialGroupPreset decoratingMaterial;

	public MaterialGroupPreset.MaterialType decoratingType;

	public Toolbox.MaterialKey decoratingKey;

	public NewRoom decoratingRoom;

	[Space(7f)]
	public InfoWindow materialKeyWindow;

	[Space(7f)]
	public WindowTabPreset.TabContentType rememberContent;

	public MaterialGroupPreset.MaterialType rememberDecorType;

	public FurnishingsController.TabState rememberRoomStorageShop;

	public List<FurniturePreset.DecorClass> rememberDisplayClasses;

	public List<InteractablePreset.ItemClass> rememberItemDisplayClasses;

	private static PlayerApartmentController _instance;

	public static PlayerApartmentController Instance => null;

	public event FurnitureChange OnFurnitureChange
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

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SortSwatches()
	{
	}

	public int Step(Color colour)
	{
		return 0;
	}

	public void BuyNewResidence(ResidenceController newHome, bool removePreviousResidence = false)
	{
	}

	public void SetFurniturePlacementMode(bool val, FurniturePlacement newPlacement, NewRoom forRoom, bool newPlaceExistingRoomObject = false, bool forceUpdate = false)
	{
	}

	public InfoWindow OpenOrUpdateMaterialWindow(FurniturePreset furn, Toolbox.MaterialKey useKey, MaterialGroupPreset newSelection)
	{
		return null;
	}

	public void SetDecoratingMode(bool val, MaterialGroupPreset materialPreset, MaterialGroupPreset.MaterialType editType = MaterialGroupPreset.MaterialType.walls, Toolbox.MaterialKey editKey = null, NewRoom forRoom = null)
	{
	}

	private void Update()
	{
	}

	public void RemoveBeingPlaced()
	{
	}

	public FurnitureLocation GetExistingFurniture()
	{
		return null;
	}

	public void UpdatePlacementColourKey()
	{
	}

	private NewNode UpdateFurnitureDesiredPosition()
	{
		return null;
	}

	public void RotateFurn(bool right)
	{
	}

	public void AddFurnitureRotation(int angle)
	{
	}

	public void ExecutePlacement()
	{
	}

	public void ResetExisting()
	{
	}

	public int GetCurrentCost()
	{
		return 0;
	}

	public void CancelPlacement(bool restoreExistingPosition)
	{
	}

	public void MoveFurnitureToStorage(FurnitureLocation newStorage)
	{
	}

	public void RemoveFromStorage(FurnitureLocation newStorage)
	{
	}

	public void SellFurniture(FurnitureLocation newSell)
	{
	}

	public void MoveItemToStorage(Interactable newStorage)
	{
	}

	public void RemoveItemFromStorage(Interactable newStorage)
	{
	}

	public void SellItem(Interactable newSell)
	{
	}

	public void UpdateDecorColourKey()
	{
	}

	public void ApplyDecor(MaterialGroupPreset.MaterialType decorType, MaterialGroupPreset material, Toolbox.MaterialKey key, bool saveChanges)
	{
	}

	public void RevertDecor(MaterialGroupPreset.MaterialType decorType)
	{
	}

	public void PlaceIndividualCluster(FurnitureCluster cluster, NewAddress address, DesignStylePreset styleOverride = null)
	{
	}
}
