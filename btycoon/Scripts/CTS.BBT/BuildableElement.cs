using System;
using CTS;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using CTS.Core.Pooling;
using NaughtyAttributes;
using UnityEngine;

public class BuildableElement : MonoBehaviour, IPoolable
{
	public enum EBuildableElementConnectionVisuel
	{
		Single = 0,
		Left = 1,
		Right = 2,
		Middle = 3
	}

	[SerializeField]
	public Renderer[] Renderers;

	[SerializeField]
	public Renderer[] CursorRenderers;

	[SerializeField]
	private WallCutter SingleWallCutter;

	[SerializeField]
	private WallCutter LeftWallCutter;

	[SerializeField]
	private WallCutter RightWallCutter;

	[SerializeField]
	[ShowIf("BuildableType", BuildableElementSO.EBuildableType.Arch)]
	private WallCutter MiddleWallCutter;

	private EBuildableElementConnectionVisuel _currentConnectionVisuel;

	[ShowNonSerializedField]
	private BuildableElement _connectedBuildableLeft;

	[ShowNonSerializedField]
	private BuildableElement _connectedBuildableRight;

	private BuildingWall _currentWall;

	[HideInInspector]
	public BuildableElementSO BuildableElementSO;

	[field: SerializeField]
	public BuildableElementSO.EBuildableType BuildableType { get; protected set; }

	[field: SerializeField]
	public GameObject SingleElement { get; private set; }

	[field: SerializeField]
	public GameObject LeftElement { get; private set; }

	[field: SerializeField]
	public GameObject RightElement { get; private set; }

	[field: SerializeField]
	[field: ShowIf("BuildableType", BuildableElementSO.EBuildableType.Arch)]
	public GameObject MiddleElement { get; private set; }

	[field: SerializeField]
	public BoxCollider NoFurnitureCollider { get; private set; }

	[field: SerializeField]
	public LayerMask FurnitureMask { get; private set; }

	[field: SerializeField]
	public SpriteRenderer SpriteRenderer { get; private set; }

	[field: SerializeField]
	public PlacementFeedback PlacementFeedback { get; private set; }

	PoolGuid IPoolable.PoolGuid { get; set; }

	public ConstructionCell MainCell { get; set; }

	public WallCutter CurrentWallCutter => _currentConnectionVisuel switch
	{
		EBuildableElementConnectionVisuel.Single => SingleWallCutter, 
		EBuildableElementConnectionVisuel.Left => LeftWallCutter, 
		EBuildableElementConnectionVisuel.Right => RightWallCutter, 
		EBuildableElementConnectionVisuel.Middle => MiddleWallCutter, 
		_ => null, 
	};

	public GameObject GetCurrentActiveVisual => _currentConnectionVisuel switch
	{
		EBuildableElementConnectionVisuel.Single => SingleElement, 
		EBuildableElementConnectionVisuel.Left => LeftElement, 
		EBuildableElementConnectionVisuel.Right => RightElement, 
		EBuildableElementConnectionVisuel.Middle => MiddleElement, 
		_ => null, 
	};

	public static event Action<BuildableElement> Destroyed;

	private void Start()
	{
		PlacementFeedback.Setup(SpriteRenderer, NoFurnitureCollider);
		PlacementFeedback.SetRenderers(Renderers);
	}

	public void DestroyElement()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void OnDestroy()
	{
		BeforeDestoy();
	}

	protected virtual void BeforeDestoy()
	{
		if (MonoSingleton<AbsMoneyHandlerBridge>.InstanceExists())
		{
			MonoSingleton<AbsMoneyHandlerBridge>.Instance.SpendMoney(-BuildableElementSO.PurchasePrice);
		}
		if (MonoSingleton<TransactionsHandlers>.InstanceExists())
		{
			MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, BuildableElementSO.PurchasePrice, TransactionTag.OtherSale);
		}
		MainCell.GetNeighborCellFromBuildable()?.RemoveBuildableElement();
		MainCell.RemoveBuildableElement();
		MainCell.GetNeighborCellFromBuildable()?.RefreshBuildable(canDestroy: false);
		MainCell.RefreshBuildable(canDestroy: false);
		MainCell = null;
		if (_connectedBuildableLeft != null)
		{
			_connectedBuildableLeft.CheckIfFusionnable();
		}
		if (_connectedBuildableRight != null)
		{
			_connectedBuildableRight.CheckIfFusionnable();
		}
		BuildableElement.Destroyed?.Invoke(this);
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RemoveBySelection()
	{
		DestroyElement();
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SelectAllRenderers()
	{
		Renderers = GetComponentsInChildren<Renderer>();
	}

	public void SetConnectionVisuel(BuildableElement leftConnectedElement, BuildableElement rightConnectedElement)
	{
		if (leftConnectedElement != null)
		{
			SingleElement.SetActive(value: false);
			if (rightConnectedElement != null)
			{
				if (MiddleElement != null)
				{
					MiddleElement?.SetActive(value: true);
				}
				if (LeftElement != null)
				{
					LeftElement.SetActive(value: false);
				}
				if (RightElement != null)
				{
					RightElement.SetActive(value: false);
				}
				_currentConnectionVisuel = EBuildableElementConnectionVisuel.Middle;
			}
			else
			{
				if (MiddleElement != null)
				{
					MiddleElement?.SetActive(value: false);
				}
				if (RightElement != null)
				{
					RightElement.SetActive(value: true);
				}
				if (LeftElement != null)
				{
					LeftElement.SetActive(value: false);
				}
				_currentConnectionVisuel = EBuildableElementConnectionVisuel.Right;
			}
		}
		else if (rightConnectedElement != null)
		{
			SingleElement.SetActive(value: false);
			if (RightElement != null)
			{
				RightElement?.SetActive(value: false);
			}
			if (LeftElement != null)
			{
				LeftElement?.SetActive(value: true);
			}
			if (MiddleElement != null)
			{
				MiddleElement?.SetActive(value: false);
			}
			_currentConnectionVisuel = EBuildableElementConnectionVisuel.Left;
		}
		else
		{
			SingleElement.SetActive(value: true);
			if (LeftElement != null)
			{
				LeftElement?.SetActive(value: false);
			}
			if (RightElement != null)
			{
				RightElement?.SetActive(value: false);
			}
			if (MiddleElement != null)
			{
				MiddleElement?.SetActive(value: false);
			}
			_currentConnectionVisuel = EBuildableElementConnectionVisuel.Single;
		}
		switch (_currentConnectionVisuel)
		{
		case EBuildableElementConnectionVisuel.Single:
			_connectedBuildableLeft = null;
			_connectedBuildableRight = null;
			break;
		case EBuildableElementConnectionVisuel.Left:
			_connectedBuildableLeft = null;
			_connectedBuildableRight = rightConnectedElement;
			break;
		case EBuildableElementConnectionVisuel.Right:
			_connectedBuildableLeft = leftConnectedElement;
			_connectedBuildableRight = null;
			break;
		case EBuildableElementConnectionVisuel.Middle:
			_connectedBuildableRight = rightConnectedElement;
			_connectedBuildableLeft = leftConnectedElement;
			break;
		}
		MainCell?.RefreshBuildable(canDestroy: false);
		MainCell?.GetNeighborCellFromBuildable()?.RefreshBuildable(canDestroy: false);
		if (this is BuildableDoor buildableDoor)
		{
			if (_currentWall.IsExteriorLimitWall)
			{
				buildableDoor.ShowExterior();
			}
			else
			{
				buildableDoor.ShowInterior();
			}
		}
	}

	private void CheckIfFusionnable(ConstructionCell left, ConstructionCell right, ConstructionCell nextLeft, ConstructionCell nextRight, ConstructionCell center)
	{
		if (BuildableType == BuildableElementSO.EBuildableType.Arch)
		{
			SetConnectionVisuel((left.BuildableElement != null && left.BuildableRotation == center.BuildableRotation && left.BuildableElement.BuildableType == BuildableType && left.BuildableElement.BuildableElementSO == BuildableElementSO) ? left.BuildableElement : null, (right.BuildableElement != null && right.BuildableRotation == center.BuildableRotation && right.BuildableElement.BuildableType == BuildableType && right.BuildableElement.BuildableElementSO == BuildableElementSO) ? right.BuildableElement : null);
			if (left.BuildableElement != null && left.BuildableElement.BuildableType == BuildableType && BuildableElementSO == left.BuildableElement.BuildableElementSO && left.BuildableRotation == center.BuildableRotation)
			{
				if (nextLeft.BuildableElement != null && nextLeft.BuildableElement.BuildableType == BuildableType && nextLeft.BuildableRotation == center.BuildableRotation && BuildableElementSO == nextLeft.BuildableElement.BuildableElementSO)
				{
					left.BuildableElement.SetConnectionVisuel(nextLeft.BuildableElement, this);
				}
				else
				{
					left.BuildableElement.SetConnectionVisuel(null, this);
				}
			}
			if (right.BuildableElement != null && right.BuildableElement.BuildableType == BuildableType && BuildableElementSO == right.BuildableElement.BuildableElementSO && right.BuildableRotation == center.BuildableRotation)
			{
				if (nextRight.BuildableElement != null && nextRight.BuildableElement.BuildableType == BuildableType && nextRight.BuildableRotation == center.BuildableRotation && BuildableElementSO == nextRight.BuildableElement.BuildableElementSO)
				{
					right.BuildableElement.SetConnectionVisuel(this, nextRight.BuildableElement);
				}
				else
				{
					right.BuildableElement.SetConnectionVisuel(this, null);
				}
			}
		}
		else if (left.BuildableElement != null && left.BuildableRotation == center.BuildableRotation && left.BuildableElement.BuildableType == BuildableType && BuildableElementSO == left.BuildableElement.BuildableElementSO && left.BuildableElement._currentConnectionVisuel == EBuildableElementConnectionVisuel.Single)
		{
			SetConnectionVisuel(left.BuildableElement, null);
			left.BuildableElement.SetConnectionVisuel(null, this);
		}
		else if (right.BuildableElement != null && right.BuildableRotation == center.BuildableRotation && right.BuildableElement.BuildableType == BuildableType && BuildableElementSO == right.BuildableElement.BuildableElementSO && right.BuildableElement._currentConnectionVisuel == EBuildableElementConnectionVisuel.Single)
		{
			SetConnectionVisuel(null, right.BuildableElement);
			right.BuildableElement.SetConnectionVisuel(this, null);
		}
		else
		{
			SetConnectionVisuel(null, null);
		}
	}

	public void CheckIfFusionnable()
	{
		SingleElement.SetActive(value: false);
		if (BuildableType == BuildableElementSO.EBuildableType.Arch)
		{
			MiddleElement?.SetActive(value: false);
		}
		if (!(MainCell == null))
		{
			switch (MainCell.BuildableRotation)
			{
			case ERotationAngle.Nord:
				CheckIfFusionnable(MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.left), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.right), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.left * 2), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.right * 2), MainCell.LinkedGrid.GetCell(MainCell.Coordinate));
				break;
			case ERotationAngle.East:
				CheckIfFusionnable(MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.up), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.down), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.up * 2), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.down * 2), MainCell.LinkedGrid.GetCell(MainCell.Coordinate));
				break;
			case ERotationAngle.South:
				CheckIfFusionnable(MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.right), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.left), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.right * 2), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.left * 2), MainCell.LinkedGrid.GetCell(MainCell.Coordinate));
				break;
			case ERotationAngle.West:
				CheckIfFusionnable(MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.down), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.up), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.down * 2), MainCell.LinkedGrid.GetCell(MainCell.Coordinate + Vector2Int.up * 2), MainCell.LinkedGrid.GetCell(MainCell.Coordinate));
				break;
			}
		}
	}

	public void ChangeVisibility(bool visible)
	{
		Renderer[] renderers = Renderers;
		for (int i = 0; i < renderers.Length; i++)
		{
			renderers[i].enabled = visible;
		}
	}

	public virtual bool CanBePlaced(BuildingWall wall)
	{
		bool flag = true;
		Collider[] array = Physics.OverlapBox(wall.transform.position + NoFurnitureCollider.center, NoFurnitureCollider.size / 2f, wall.transform.rotation, FurnitureMask);
		flag = array.Length == 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].TryGetComponent<PlacementFeedback>(out var component))
			{
				MonoSingleton<PlacementFeedbackManager>.Instance.AddToList(component);
			}
		}
		return flag;
	}

	public virtual void OnPlaced(BuildingWall wall)
	{
		_currentWall = wall;
	}
}
