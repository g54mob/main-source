using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Dorfromantik;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileSlot : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, ISelectable
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<GroupType, bool> _003C_003E9__33_0;

		internal bool _003CHasAdaptiveEdge_003Eb__33_0(GroupType x)
		{
			return x.constraining;
		}
	}

	[SerializeField]
	private AudioClipOptions invalidPlacementSound;

	[SerializeField]
	private Tile[] neighborTiles = new Tile[6];

	private Vector2Int _003CGridPos_003Ek__BackingField;

	private TileSlotVisual visual;

	private MeshCollider collider;

	private InvalidTileSlotPreview invalidVisual;

	private int _003CEmptyNeighbors_003Ek__BackingField;

	private int _003CEmptyNeighborsExcludingPreplacedTiles_003Ek__BackingField;

	private bool _003CIsValid_003Ek__BackingField;

	public Tile[] NeighborTiles
	{
		get
		{
			return neighborTiles;
		}
		private set
		{
			neighborTiles = value;
		}
	}

	public Vector2Int GridPos
	{
		get
		{
			return _003CGridPos_003Ek__BackingField;
		}
		private set
		{
			_003CGridPos_003Ek__BackingField = value;
		}
	}

	public bool IsVisible => visual.IsVisible;

	public int EmptyNeighbors
	{
		get
		{
			return _003CEmptyNeighbors_003Ek__BackingField;
		}
		private set
		{
			_003CEmptyNeighbors_003Ek__BackingField = value;
		}
	}

	public int EmptyNeighborsExcludingPreplacedTiles
	{
		get
		{
			return _003CEmptyNeighborsExcludingPreplacedTiles_003Ek__BackingField;
		}
		private set
		{
			_003CEmptyNeighborsExcludingPreplacedTiles_003Ek__BackingField = value;
		}
	}

	public bool IsValid
	{
		get
		{
			return _003CIsValid_003Ek__BackingField;
		}
		private set
		{
			_003CIsValid_003Ek__BackingField = value;
		}
	}

	public int Layer => 8;

	public Transform Transform => base.transform;

	private void Awake()
	{
		NeighborTiles = new Tile[6];
		visual = GetComponentInChildren<TileSlotVisual>();
		collider = GetComponentInChildren<MeshCollider>();
		invalidVisual = GetComponentInChildren<InvalidTileSlotPreview>(includeInactive: true);
		EmptyNeighbors = 6;
		EmptyNeighborsExcludingPreplacedTiles = 6;
	}

	internal void Initialize(Tile originTile, Vector2Int neighborDirection, int directionIndex)
	{
		GridPos = originTile.GridPos + neighborDirection;
		AddNeighbor(originTile, directionIndex);
	}

	internal void Initialize(Vector2Int gridPos)
	{
		GridPos = gridPos;
	}

	public void AddNeighbor(Tile neighborTile, int directionIndex, bool isPreplacedTile = false)
	{
		NeighborTiles[(directionIndex + 3) % 6] = neighborTile;
		EmptyNeighbors--;
		if (!isPreplacedTile)
		{
			EmptyNeighborsExcludingPreplacedTiles--;
		}
	}

	public void AnimateSpawn(Tile originTile)
	{
		Vector3 position = originTile.transform.position;
		visual.transform.localRotation = Quaternion.AngleAxis(UnityEngine.Random.Range(0, 6) * 60, Vector3.up);
		TweenSettingsExtensions.From(ShortcutExtensions.DOMove(visual.transform, base.transform.position, 0.2f), position);
	}

	public void SetState(TileSlotState targetState)
	{
		visual.ChangeState(targetState);
		invalidVisual.gameObject.SetActive(value: false);
		IsValid = targetState == TileSlotState.Valid;
	}

	public List<GroupType> GetEdgeTypes(int worldDirection, TileEdgeType edgeType = TileEdgeType.Any)
	{
		if (NeighborTiles[worldDirection] == null)
		{
			return new List<GroupType>();
		}
		return NeighborTiles[worldDirection].GetEdgeTypes((worldDirection + 3) % 6, Space.World, edgeType);
	}

	public bool HasAdaptiveEdge()
	{
		for (int i = 0; i < 6; i++)
		{
			if (Enumerable.Any(GetEdgeTypes(i), (GroupType x) => x.constraining))
			{
				return true;
			}
		}
		return false;
	}

	public void RemoveNeighbor(Tile previousNeighbor, int directionIndex)
	{
		NeighborTiles[(directionIndex + 3) % 6] = null;
		EmptyNeighbors++;
		EmptyNeighborsExcludingPreplacedTiles++;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!IsValid)
		{
			invalidVisual.gameObject.SetActive(value: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!IsValid)
		{
			invalidVisual.StopHighlighting();
			invalidVisual.gameObject.SetActive(value: false);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!IsValid)
		{
			invalidVisual.StartHighlighting();
			AudioManager.Instance.PlaySoundAtPosition(invalidPlacementSound, base.transform.position);
		}
	}

	public void RemovePreplacedTileNeighbor()
	{
		EmptyNeighborsExcludingPreplacedTiles--;
	}
}
