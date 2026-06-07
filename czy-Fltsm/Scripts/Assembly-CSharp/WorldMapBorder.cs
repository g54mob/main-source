using System;
using PajamaLlama.Math;
using UnityEngine;

public class WorldMapBorder : MonoBehaviour
{
	public enum Sides
	{
		North = 0,
		East = 1,
		South = 2,
		West = 3
	}

	[SerializeField]
	private float _width = 1000f;

	[SerializeField]
	private WorldMapTable _table;

	[SerializeField]
	private Transform _stencilTransform;

	[SerializeField]
	[Min(0f)]
	[Tooltip("The size of the FOW padding on the east side of the map, make sure this value equals Scale.X of the 'InnerBorderEast->Padding (FOW)'")]
	private float _paddingEast;

	[SerializeField]
	private WorldMapFogOfWar _paddingFogOfWar;

	[Header("Inner Borders")]
	[SerializeField]
	private WorldMapInnerBorder _north;

	[SerializeField]
	private WorldMapInnerBorder _east;

	[SerializeField]
	private WorldMapInnerBorder _south;

	[SerializeField]
	private WorldMapInnerBorder _west;

	[Header("Notches")]
	[SerializeField]
	private Transform _notchNorthWest;

	[SerializeField]
	private Transform _notchNorthEast;

	[SerializeField]
	private Transform _notchSouthEast;

	[SerializeField]
	private Transform _notchSouthWest;

	[Header("Physics")]
	[SerializeField]
	private Collider2D _colliderNorth;

	[SerializeField]
	private Collider2D _colliderEast;

	[SerializeField]
	private Collider2D _colliderSouth;

	[SerializeField]
	private Collider2D _colliderWest;

	private void Awake()
	{
		Vector3 localPosition = _paddingFogOfWar.transform.localPosition;
		_paddingFogOfWar.Initialize(new Rect(0f - _paddingEast, 0f - _width, _paddingEast, _width), Vector3.zero);
		_paddingFogOfWar.transform.localPosition = new Vector3(0f, localPosition.y, _width / 2f);
	}

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.WorldTileAdded, OnWorldUpdated);
		GameEventDispatcher.AddListener(GameEventType.WorldTileRemoved, OnWorldUpdated);
		OnWorldUpdated();
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.WorldTileAdded, OnWorldUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.WorldTileRemoved, OnWorldUpdated);
	}

	private void OnWorldUpdated(GameEvent gameEvent = null)
	{
		Rect worldBounds = WorldManager.ReturnWorldBounds();
		float markerLabelOffsetX = WorldManager.ReturnFirstTileOffsetX();
		float doubleWidth = _width * 2f;
		float halfWidth = _width / 2f;
		worldBounds.xMax += GetPaddingEast();
		_north.UpdateWorldBounds(worldBounds, Sides.North, markerLabelOffsetX);
		_east.UpdateWorldBounds(worldBounds, Sides.East);
		_south.UpdateWorldBounds(worldBounds, Sides.South, markerLabelOffsetX);
		_west.UpdateWorldBounds(worldBounds, Sides.West);
		_notchNorthWest.position = new Vector3(worldBounds.xMin, 0f, worldBounds.yMax);
		_notchNorthEast.position = worldBounds.max.Vector3TopDown();
		_notchSouthEast.position = new Vector3(worldBounds.xMax, 0f, worldBounds.yMin);
		_notchSouthWest.position = worldBounds.min.Vector3TopDown();
		SetBorderScaleAndPosition(Sides.North, _colliderNorth, worldBounds, doubleWidth, halfWidth);
		SetBorderScaleAndPosition(Sides.East, _colliderEast, worldBounds, doubleWidth, halfWidth);
		SetBorderScaleAndPosition(Sides.South, _colliderSouth, worldBounds, doubleWidth, halfWidth);
		SetBorderScaleAndPosition(Sides.West, _colliderWest, worldBounds, doubleWidth, halfWidth);
		_table.UpdateWorldBounds(worldBounds);
		_stencilTransform.localScale = new Vector3(worldBounds.size.x, worldBounds.size.y, 1f);
		_stencilTransform.position = new Vector3(worldBounds.center.x, 0f, worldBounds.center.y);
	}

	private void SetBorderScaleAndPosition(Sides side, Collider2D collider, Rect worldBounds, float doubleWidth, float halfWidth)
	{
		Vector2 vector;
		Vector2 vector2;
		switch (side)
		{
		case Sides.North:
			vector = new Vector2(worldBounds.center.x, worldBounds.yMax + halfWidth);
			vector2 = new Vector2(worldBounds.size.x + doubleWidth, _width);
			break;
		case Sides.East:
			vector = new Vector2(worldBounds.xMax + halfWidth - GetPaddingEast(), worldBounds.center.y);
			vector2 = new Vector2(_width, worldBounds.size.y + doubleWidth);
			break;
		case Sides.South:
			vector = new Vector2(worldBounds.center.x, worldBounds.yMin - halfWidth);
			vector2 = new Vector2(worldBounds.size.x + doubleWidth, _width);
			break;
		case Sides.West:
			vector = new Vector2(worldBounds.xMin - halfWidth, worldBounds.center.y);
			vector2 = new Vector2(_width, worldBounds.size.y + doubleWidth);
			break;
		default:
			throw new NotImplementedException();
		}
		collider.transform.position = vector;
		collider.transform.localScale = vector2;
	}

	public float GetPaddingEast()
	{
		if (WorldManager.HasEndTile)
		{
			_paddingFogOfWar.gameObject.SetActive(value: false);
			return 0f;
		}
		return _paddingEast;
	}
}
