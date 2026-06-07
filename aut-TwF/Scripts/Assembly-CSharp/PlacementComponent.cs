using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(GameplayObject))]
public class PlacementComponent : MonoBehaviour
{
	[Serializable]
	public class ChildGameplayObject
	{
		public GameplayObject gameplayObject;

		public Vector3 relativePosition;

		public ChildGameplayObject(GameplayObject gameplayObject, Vector3 relativePosition)
		{
			this.gameplayObject = gameplayObject;
			this.relativePosition = relativePosition;
		}
	}

	private const float ROTATION_ANIMATION_TIME = 0.3f;

	[SerializeField]
	private bool canBeMovedByPlayer;

	[SerializeField]
	[Tooltip("Si es true, se llama Place() en el Start. Se usa para objetos que ya están colocados en el nivel desde el principio.")]
	protected bool autoCallPlace;

	[SerializeField]
	private bool canBuildOnAnyTile;

	[SerializeField]
	[Min(1f)]
	private int width = 1;

	[SerializeField]
	[Min(1f)]
	private int length = 1;

	[SerializeField]
	private ChildGameplayObject[] childObjects;

	[SerializeField]
	[Tooltip("GameplayObjects que se venden automáticamente si este objeto se coloca encima de ellos")]
	private GameplayObjectDataGroup autoSellableObjects;

	[SerializeField]
	[Tooltip("Objetos a activar en cuanto la fog of war revele al menos una casilla de este placement component")]
	private GameObject[] objectsToReveal;

	[SerializeField]
	[Tooltip("Radio extra a la hora de comprobar si el objeto tiene que revelarse o no")]
	private int extraVisibilityCheckRadius;

	[SerializeField]
	[Tooltip("Posiciones del objeto que no se consideran ocupadas por el mismo")]
	private Vector2[] ignoredPositions;

	private GameplayObject mainObject;

	private Tween rotationAnimationTween;

	private bool isPlaced;

	public GameplayObject MainObject
	{
		get
		{
			return mainObject;
		}
		private set
		{
			mainObject = value;
		}
	}

	public bool CanBeMovedByPlayer => canBeMovedByPlayer;

	public bool IsPlaced
	{
		get
		{
			return isPlaced;
		}
		set
		{
			isPlaced = value;
		}
	}

	public int Width => width;

	public int Length => length;

	public bool CanBuildOnAnyTile => canBuildOnAnyTile;

	public ChildGameplayObject[] ChildObjects => childObjects;

	public event Action<PlacementComponent> onPlace;

	public event Action<PlacementComponent> onUnplace;

	public event Action<PlacementComponent> onChangePosition;

	public event Action<PlacementComponent> onDestroyAndSubstitute;

	public event Action onBecomeVisible;

	private void Awake()
	{
		MainObject = GetComponent<GameplayObject>();
	}

	protected virtual void Start()
	{
		if (autoCallPlace)
		{
			Place();
		}
		if (objectsToReveal != null && objectsToReveal.Length != 0)
		{
			LTFunctionLibrary.GetFogOfWarController().onFogOfWarUpdated += OnFogOfWarUpdated;
		}
	}

	private void OnDestroy()
	{
		if (rotationAnimationTween != null && rotationAnimationTween.IsActive())
		{
			rotationAnimationTween.Kill();
		}
	}

	public Vector3[] GetOccupiedPositions()
	{
		Vector3[] array = new Vector3[Width * Length - ignoredPositions.Length];
		Vector3 vector = base.transform.position - (base.transform.right * ((Width - 1) / 2) + base.transform.forward * ((Length - 1) / 2));
		int num = 0;
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Length; j++)
			{
				Vector3 vector2 = vector + base.transform.right * i + base.transform.forward * j;
				if (!ignoredPositions.Contains(base.transform.position.XZ() - vector2.XZ()))
				{
					array[num] = vector2;
					num++;
				}
			}
		}
		return array;
	}

	public List<PlacementComponent> GetPlacementComponentsInCurrentPosition()
	{
		List<PlacementComponent> list = new List<PlacementComponent>();
		GridCell gridCell = null;
		Vector3[] occupiedPositions = GetOccupiedPositions();
		foreach (Vector3 position in occupiedPositions)
		{
			gridCell = LTFunctionLibrary.GetGrid().GetGridCell(position);
			if (gridCell != null && (bool)gridCell.BuiltObject)
			{
				list.AddUnique(gridCell.BuiltObject);
			}
		}
		return list;
	}

	public virtual bool CanBuildOnCurrentPosition(bool checkPositionVisible = true, bool allowAutoSellableObjects = true)
	{
		GridCell gridCell = null;
		Vector3[] occupiedPositions = GetOccupiedPositions();
		foreach (Vector3 position in occupiedPositions)
		{
			gridCell = LTFunctionLibrary.GetGrid().GetGridCell(position);
			if (gridCell == null || (!canBuildOnAnyTile && !gridCell.CanBuild() && !(gridCell.BuiltObject == this) && (!allowAutoSellableObjects || !(autoSellableObjects != null) || autoSellableObjects.Group == null || !gridCell.BuiltObject || !autoSellableObjects.Group.Contains(gridCell.BuiltObject.MainObject.ObjectData))) || (checkPositionVisible && !autoCallPlace && !FogOfWarController.instance.IsPositionVisible(position)))
			{
				return false;
			}
		}
		return true;
	}

	public bool IsSquared()
	{
		return length == width;
	}

	public Vector3 GetCenter(bool localSpace = false)
	{
		Vector3 result = (localSpace ? Vector3.zero : base.transform.position);
		if (Width % 2 == 0)
		{
			result += base.transform.right * 0.5f;
		}
		if (Length % 2 == 0)
		{
			result += base.transform.forward * 0.5f;
		}
		return result;
	}

	public GameplayObject GetObjectByPosition(Vector3 cellPosition)
	{
		if (ChildObjects == null || ChildObjects.Length == 0)
		{
			return MainObject;
		}
		GameplayObject gameplayObject = null;
		cellPosition.y = 0f;
		for (int i = 0; i < ChildObjects.Length; i++)
		{
			if (base.transform.TransformPoint(ChildObjects[i].relativePosition) == cellPosition)
			{
				gameplayObject = ChildObjects[i].gameplayObject;
				break;
			}
		}
		if (gameplayObject == null)
		{
			gameplayObject = MainObject;
		}
		return gameplayObject;
	}

	public void SetPositon(Vector3 newPosition)
	{
		base.transform.position = newPosition;
		this.onChangePosition?.Invoke(this);
	}

	public void SetRotation(Quaternion newRotation)
	{
		base.transform.rotation = newRotation;
		if (rotationAnimationTween != null)
		{
			rotationAnimationTween.Kill();
			mainObject.Model.transform.localRotation = Quaternion.identity;
		}
		this.onChangePosition?.Invoke(this);
	}

	public void Rotate(float rotationY, bool doAnimation = false)
	{
		Quaternion rotation = mainObject.Model.transform.rotation;
		if (rotationAnimationTween != null && rotationAnimationTween.IsActive())
		{
			rotationAnimationTween.Kill(complete: true);
			mainObject.Model.transform.localRotation = Quaternion.identity;
		}
		if (IsSquared())
		{
			base.transform.RotateAround(GetCenter(), Vector3.up, rotationY);
		}
		else
		{
			base.transform.rotation *= Quaternion.Euler(0f, rotationY, 0f);
		}
		Vector3 eulerAngles = mainObject.Model.transform.rotation.eulerAngles;
		if (doAnimation)
		{
			mainObject.Model.transform.rotation = rotation;
			rotationAnimationTween = mainObject.Model.transform.DORotate(eulerAngles, 0.3f).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
		}
		this.onChangePosition?.Invoke(this);
	}

	public bool IsVisible()
	{
		List<Vector3> list = GetOccupiedPositions().ToList();
		if (extraVisibilityCheckRadius > 0)
		{
			GridCell[] array = LTFunctionLibrary.GetGridCellsAroundPosition(LTFunctionLibrary.GetGrid(), list, extraVisibilityCheckRadius).ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i]?.Tile != null)
				{
					list.Add(array[i].Tile.transform.position);
				}
			}
		}
		foreach (Vector3 item in list)
		{
			if (LTFunctionLibrary.GetFogOfWarController().IsPositionVisible(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool Place(bool checkCanBuildOnCurrentPosition = true, bool allowAutoSellableObjects = true, bool checkVisibility = true)
	{
		if (isPlaced || (checkCanBuildOnCurrentPosition && !CanBuildOnCurrentPosition(checkVisibility, allowAutoSellableObjects)))
		{
			return false;
		}
		Vector3[] occupiedPositions = GetOccupiedPositions();
		foreach (Vector3 position in occupiedPositions)
		{
			GridCell gridCell = LTFunctionLibrary.GetGrid().GetGridCell(position);
			if (gridCell != null && (bool)gridCell.BuiltObject && gridCell.BuiltObject != this)
			{
				LTFunctionLibrary.GetLTGameManager().SellBuilding(gridCell.BuiltObject.MainObject);
			}
		}
		occupiedPositions = GetOccupiedPositions();
		foreach (Vector3 position2 in occupiedPositions)
		{
			LTFunctionLibrary.GetGrid().GetGridCell(position2).BuiltObject = this;
		}
		IsPlaced = true;
		this.onPlace?.Invoke(this);
		return true;
	}

	public void Unplace()
	{
		if (isPlaced)
		{
			Vector3[] occupiedPositions = GetOccupiedPositions();
			foreach (Vector3 position in occupiedPositions)
			{
				LTFunctionLibrary.GetGrid().GetGridCell(position).BuiltObject = null;
			}
			IsPlaced = false;
			this.onUnplace?.Invoke(this);
		}
	}

	public void DestroyAndSubstitute(PlacementComponent substitute)
	{
		PlayerData playerData = LTFunctionLibrary.GetPlayerData();
		if ((object)playerData != null && playerData.RemovePlayerBuilding(MainObject))
		{
			LTFunctionLibrary.GetPlayerData().AddPlayerBuilding(substitute.MainObject);
		}
		this.onDestroyAndSubstitute?.Invoke(substitute);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void OnFogOfWarUpdated(bool importantUpdate)
	{
		if (importantUpdate && IsVisible())
		{
			LTFunctionLibrary.GetFogOfWarController().onFogOfWarUpdated -= OnFogOfWarUpdated;
			GameObject[] array = objectsToReveal;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
			this.onBecomeVisible?.Invoke();
		}
	}
}
