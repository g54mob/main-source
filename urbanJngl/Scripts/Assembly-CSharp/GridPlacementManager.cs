using System;
using System.Collections;
using System.Collections.Generic;
using GridPlacementSystem;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using UnityEngine;

public class GridPlacementManager : MonoBehaviour, ISavedProgress, ISavedProgressReader
{
	public class OnObjectPlacedEventArgs : EventArgs
	{
		public ObjectSO objectSO;

		public bool isMoveObject;

		public int ID;

		public int plantScore;
	}

	public class OnObjectRemovedEventArgs : EventArgs
	{
		public int score;
	}

	public class OnSelectedChangedEventArgs : EventArgs
	{
		public Transform objectToPlace;
	}

	public enum Dir
	{
		Down = 0,
		Left = 1,
		Up = 2,
		Right = 3
	}

	[SerializeField]
	private GridManager gridManager;

	[SerializeField]
	private PlacementGhost placementGhost;

	[SerializeField]
	private Transform selectedCellTransformTemplate;

	[SerializeField]
	private Transform placementParticle;

	[SerializeField]
	private ZonesBacklighting ZonesBacklighting;

	private ObjectSO objectSO;

	private int ID;

	private Transform prefab;

	private Vector2Int size;

	private int variantIndex;

	private bool hasVariant;

	private (Transform, int) pot;

	private int plantScore;

	private bool isBuilding;

	private bool isMoveObject;

	private Transform selectedCellTransform;

	private Vector3 lastSelectedCell;

	private Vector3Int oldCellPosition;

	private int previousVariantIndex;

	private ISaveLoadService _saveLoadService;

	private List<PlacedObject> _plantsOnLevel = new List<PlacedObject>();

	private InfoForPlantConstructor currentPlant = new InfoForPlantConstructor();

	private Dir dir;

	private Dir[] dirArray;

	private bool IsFirstObjectSelected = true;

	private bool IsFirstObjectPlaced = true;

	private bool IsFirstObjectMoved = true;

	public static GridPlacementManager Instance { get; private set; }

	public event EventHandler<OnObjectPlacedEventArgs> OnObjectPlaced;

	public event EventHandler<OnObjectRemovedEventArgs> OnObjectRemoved;

	public event EventHandler OnSelectedChanged;

	public event EventHandler OnCanNotPlaceObject;

	public event EventHandler OnFirstObjectSelected;

	public event EventHandler OnFirstObjectPlaced;

	public event EventHandler OnFirstObjectMoved;

	private void Awake()
	{
		Instance = this;
		isBuilding = false;
		isMoveObject = false;
		previousVariantIndex = -1;
		dirArray = new Dir[4];
		dirArray[0] = Dir.Down;
		dirArray[1] = Dir.Left;
		dirArray[2] = Dir.Up;
		dirArray[3] = Dir.Right;
		dir = dirArray[UnityEngine.Random.Range(0, dirArray.Length)];
		_saveLoadService = AllServices.Container.Single<ISaveLoadService>();
	}

	private void Start()
	{
		gridManager.ToggleGridRenderer(value: false);
	}

	private void Update()
	{
		if (isBuilding)
		{
			if (Input.GetMouseButtonDown(0) && objectSO != null)
			{
				TryToPlaceObject(objectSO, isMoveObject);
			}
			if (Input.mouseScrollDelta.y > 0f)
			{
				dir = GetNextDir(dir);
			}
			if (Input.mouseScrollDelta.y < 0f)
			{
				dir = GetPreviousDir(dir);
			}
		}
	}

	public void StartPlacingObject(ObjectSO objectSO, int ID)
	{
		if (isBuilding)
		{
			return;
		}
		this.objectSO = ProgressManager.Instance.GetObjectSO(ID);
		this.ID = ID;
		if (!isMoveObject)
		{
			if (objectSO.variantsList.Count > 0)
			{
				do
				{
					variantIndex = UnityEngine.Random.Range(0, objectSO.variantsList.Count);
				}
				while (variantIndex == previousVariantIndex);
				hasVariant = true;
				prefab = objectSO.variantsList[variantIndex].prefab;
				size = objectSO.variantsList[variantIndex].size;
				previousVariantIndex = variantIndex;
			}
			else
			{
				hasVariant = false;
				prefab = objectSO.prefab;
				size = objectSO.size;
			}
			pot = PlantConstructor.Instance.GetRandomPot(size);
		}
		placementGhost.StartShowingPlacementGhost();
		plantScore = placementGhost.GetPlantScore();
		isBuilding = true;
		ZonesBacklighting.TurnOnColor(objectSO);
		this.OnSelectedChanged?.Invoke(this, EventArgs.Empty);
		if (IsFirstObjectSelected)
		{
			IsFirstObjectSelected = false;
			this.OnFirstObjectSelected?.Invoke(this, EventArgs.Empty);
		}
	}

	public void StopPlacingObject()
	{
		placementGhost.StopShowingPlacementGhost();
		StartCoroutine(CanMoveTimer());
		objectSO = null;
		ID = 9999;
		prefab = null;
		size = Vector2Int.zero;
		hasVariant = false;
		variantIndex = 9999;
		plantScore = 0;
		dir = dirArray[UnityEngine.Random.Range(0, dirArray.Length)];
		ZonesBacklighting.TurnOffColor();
		_saveLoadService.SaveProgress();
		pot = (null, -1);
		isMoveObject = false;
		oldCellPosition = Vector3Int.zero;
	}

	private IEnumerator CanMoveTimer()
	{
		yield return new WaitForSeconds(0.5f);
		isBuilding = false;
	}

	public List<Vector2Int> GetGridPositionList(Vector2Int size, Vector2Int offset, Dir dir)
	{
		List<Vector2Int> list = new List<Vector2Int>();
		switch (dir)
		{
		default:
		{
			for (int k = 0; k < size.x; k++)
			{
				for (int l = 0; l < size.y; l++)
				{
					list.Add(offset + new Vector2Int(k, l));
				}
			}
			break;
		}
		case Dir.Left:
		case Dir.Right:
		{
			for (int i = 0; i < size.y; i++)
			{
				for (int j = 0; j < size.x; j++)
				{
					list.Add(offset + new Vector2Int(i, j));
				}
			}
			break;
		}
		}
		return list;
	}

	public Vector2Int GetRotationOffset(Dir dir, Vector2Int size)
	{
		return dir switch
		{
			Dir.Left => new Vector2Int(0, size.x), 
			Dir.Up => new Vector2Int(size.x, size.y), 
			Dir.Right => new Vector2Int(size.y, 0), 
			_ => new Vector2Int(0, 0), 
		};
	}

	public int GetRotationAngle(Dir dir)
	{
		return dir switch
		{
			Dir.Left => 90, 
			Dir.Up => 180, 
			Dir.Right => 270, 
			_ => 0, 
		};
	}

	public static Dir GetNextDir(Dir dir)
	{
		if (dir == Dir.Right)
		{
			return Dir.Down;
		}
		return dir + 1;
	}

	public static Dir GetPreviousDir(Dir dir)
	{
		if (dir == Dir.Down)
		{
			return Dir.Right;
		}
		return dir - 1;
	}

	public Quaternion GetPlacedObjectRotation()
	{
		if (!(objectSO != null))
		{
			return Quaternion.identity;
		}
		return Quaternion.Euler(0f, GetRotationAngle(dir), 0f);
	}

	public Vector3 GetMouseWorldSnappedPosition()
	{
		Transform selectedTransform;
		Vector3 selectedMapPosition = InputManager.Instance.GetSelectedMapPosition(out selectedTransform);
		Vector3Int cellPosition = gridManager.GetCellPosition(selectedMapPosition);
		if (objectSO != null)
		{
			Vector2Int rotationOffset = GetRotationOffset(dir, size);
			Vector3 worldPosition = GridManager.Instance.GetWorldPosition(cellPosition);
			worldPosition += GridManager.Instance.GetWorldPosition(new Vector3Int(rotationOffset.x, 0, rotationOffset.y));
			if (selectedTransform != null)
			{
				float y = selectedTransform.GetComponent<SurfaceToPlace>().GetTopPointTransform().position.y;
				worldPosition.y = y;
			}
			return worldPosition;
		}
		return selectedMapPosition;
	}

	public ObjectSO GetObjectSO()
	{
		return objectSO;
	}

	public Transform GetPrefab()
	{
		return prefab;
	}

	public Vector2Int GetSize()
	{
		return size;
	}

	public Transform GetPot()
	{
		return pot.Item1;
	}

	public void TryToPlaceObject(ObjectSO objectSO, bool IsMoveObject)
	{
		Transform selectedTransform;
		Vector3 selectedMapPosition = InputManager.Instance.GetSelectedMapPosition(out selectedTransform);
		Vector3Int cellPosition = gridManager.GetCellPosition(selectedMapPosition);
		List<Vector2Int> gridPositionList = GetGridPositionList(size, new Vector2Int(cellPosition.x, cellPosition.z), dir);
		if (!BuildCheck())
		{
			this.OnCanNotPlaceObject?.Invoke(this, EventArgs.Empty);
			Debug.Log("Can't place here");
			return;
		}
		Vector2Int rotationOffset = GetRotationOffset(dir, size);
		Vector3 vector = new Vector3(GridManager.Instance.GetWorldPosition(cellPosition).x, 0f, GridManager.Instance.GetWorldPosition(cellPosition).z);
		vector += GridManager.Instance.GetWorldPosition(new Vector3Int(rotationOffset.x, 0, rotationOffset.y));
		if (selectedTransform != null)
		{
			float y = selectedTransform.GetComponent<SurfaceToPlace>().GetTopPointTransform().position.y;
			vector.y = y;
		}
		plantScore = placementGhost.GetPlantScore();
		PlacedObject placedObject = PlacedObject.Create(vector, cellPosition, dir, objectSO, prefab, size, hasVariant, variantIndex, pot.Item1, plantScore, ID);
		RegisterPlacedObjectForSaveProgress(vector, cellPosition);
		foreach (Vector2Int item in gridPositionList)
		{
			gridManager.GetGridObject(new Vector3Int(item.x, 0, item.y)).SetPlacedObject(placedObject);
		}
		this.OnObjectPlaced?.Invoke(this, new OnObjectPlacedEventArgs
		{
			objectSO = objectSO,
			isMoveObject = isMoveObject,
			ID = ID,
			plantScore = plantScore
		});
		if (IsFirstObjectPlaced)
		{
			IsFirstObjectPlaced = false;
			this.OnFirstObjectPlaced?.Invoke(this, EventArgs.Empty);
		}
		StopPlacingObject();
	}

	public bool BuildCheck()
	{
		Transform selectedTransform;
		Vector3 selectedMapPosition = InputManager.Instance.GetSelectedMapPosition(out selectedTransform);
		Vector3Int cellPosition = gridManager.GetCellPosition(selectedMapPosition);
		foreach (Vector2Int gridPosition in GetGridPositionList(size, new Vector2Int(cellPosition.x, cellPosition.z), dir))
		{
			if (gridPosition.x > GridManager.Instance.GetGridCellsAmount().x / 2 - 1 || gridPosition.y > GridManager.Instance.GetGridCellsAmount().y / 2 - 1)
			{
				return false;
			}
			if (!gridManager.GetGridObject(new Vector3Int(gridPosition.x, 0, gridPosition.y)).CanBuild())
			{
				return false;
			}
			if (!gridManager.IsCellEmpty(gridPosition) && selectedTransform == null)
			{
				return false;
			}
		}
		return true;
	}

	private bool TryToRemoveObject(out ObjectSO objectSO, out bool hasVariant, out int variantIndex)
	{
		bool result = false;
		PlacedObject selectedObject = InputManager.Instance.GetSelectedObject();
		hasVariant = false;
		variantIndex = this.variantIndex;
		if (selectedObject != null)
		{
			objectSO = selectedObject.GetObjectSO();
			ID = selectedObject.GetID();
			if (selectedObject.HasVariant())
			{
				hasVariant = selectedObject.HasVariant();
				variantIndex = selectedObject.GetVariantIndex();
			}
			pot.Item1 = selectedObject.GetPotVisual();
			dir = selectedObject.GetDir();
			Debug.Log(objectSO.objectName);
			List<Vector2Int> gridPositionList = selectedObject.GetGridPositionList();
			oldCellPosition = selectedObject.GetCellPosition();
			this.OnObjectRemoved?.Invoke(this, new OnObjectRemovedEventArgs
			{
				score = selectedObject.GetScore()
			});
			selectedObject.DestroySelf();
			foreach (Vector2Int item in gridPositionList)
			{
				gridManager.GetGridObject(new Vector3Int(item.x, 0, item.y)).ClearPlacedObject();
			}
			result = true;
		}
		else
		{
			objectSO = null;
		}
		return result;
	}

	public void TryToMoveObject()
	{
		if (TryToRemoveObject(out objectSO, out hasVariant, out var index))
		{
			if (IsFirstObjectMoved)
			{
				IsFirstObjectMoved = false;
				this.OnFirstObjectMoved?.Invoke(this, EventArgs.Empty);
			}
			isMoveObject = true;
			if (hasVariant)
			{
				prefab = objectSO.variantsList[index].prefab;
				size = objectSO.variantsList[index].size;
				variantIndex = index;
			}
			else
			{
				prefab = objectSO.prefab;
				size = objectSO.size;
			}
			StartPlacingObject(objectSO, ID);
		}
	}

	private void ShowSelectedCell()
	{
		Transform selectedTransform;
		Vector3 b = gridManager.GetCellPosition(InputManager.Instance.GetSelectedMapPosition(out selectedTransform));
		if (selectedTransform != null)
		{
			b.y = selectedTransform.GetComponent<SurfaceToPlace>().GetTopPointTransform().position.y + 0.015f;
		}
		else
		{
			b.y = 0.015f;
		}
		selectedCellTransform.position = Vector3.Lerp(selectedCellTransform.position, b, Time.deltaTime * 15f);
	}

	private void StartShowingSelectedCell()
	{
		selectedCellTransform = UnityEngine.Object.Instantiate(selectedCellTransformTemplate, base.transform);
	}

	private void StopShowingSelectedCell()
	{
		if (selectedCellTransform.gameObject != null)
		{
			UnityEngine.Object.Destroy(selectedCellTransform.gameObject);
		}
	}

	public bool IsBuilding()
	{
		return isBuilding;
	}

	private void RegisterPlacedObjectForSaveProgress(Vector3 placedObjectWorldPosition, Vector3Int cellPosition)
	{
		currentPlant.worldPositionX = placedObjectWorldPosition.x;
		currentPlant.worldPositionY = placedObjectWorldPosition.y;
		currentPlant.worldPositionZ = placedObjectWorldPosition.z;
		currentPlant.objectSOID = ID;
		currentPlant.size = size;
		currentPlant.hasVariant = hasVariant;
		currentPlant.variantIndex = variantIndex;
		currentPlant.score = plantScore;
		currentPlant.floorPotIndex = pot.Item2;
	}

	public void LoadProgress(PlayerProgress progress)
	{
		if (progress.infoForPlants.Count == 0)
		{
			return;
		}
		foreach (InfoForPlantConstructor infoForPlant in progress.infoForPlants)
		{
			if (infoForPlant.objectSOID != -1)
			{
				ObjectSO objectSO = ProgressManager.Instance.GetObjectSO(infoForPlant.objectSOID);
				if (!infoForPlant.hasVariant)
				{
					_ = objectSO.prefab;
				}
				else
				{
					_ = objectSO.variantsList[infoForPlant.variantIndex].prefab;
				}
				PlantConstructor.Instance.GetPotByIndex(infoForPlant.size, infoForPlant.floorPotIndex);
			}
		}
	}

	public void UpdateProgress(PlayerProgress progress)
	{
	}
}
