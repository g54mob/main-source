using Assets.Behaviour.Overview;
using Assets.Source.Player;
using Assets.Source.World;
using UnityEngine;

public class WorldOverview : MonoBehaviour
{
	[SerializeField]
	public WorldTerrain Terrain;

	[SerializeField]
	private TraversableView _traversable;

	[SerializeField]
	private WorldFrameBorder _border;

	[SerializeField]
	private Transform _cellsParent;

	[SerializeField]
	private WorldOverviewCell _cellPrefab;

	private WorldFrame _currentHighlight;

	public static WorldOverview Instance { get; private set; }

	public static Vector2Int MousePosition { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		ReloadOverview();
		_traversable.Position = WorldMap.Current.CameraPosition;
		_traversable.SetZoom(WorldMap.Current.CameraZoom);
	}

	private void Update()
	{
		WorldMap.Current.CameraPosition = _traversable.Position;
		WorldMap.Current.CameraZoom = _traversable.Zoom;
		Vector2 mouseWorld = OverviewUI.Instance.MouseWorld;
		MousePosition = new Vector2Int(Mathf.RoundToInt(mouseWorld.x / 1.5f), Mathf.RoundToInt(mouseWorld.y / 1.5f));
	}

	public void ReloadOverview()
	{
		_cellsParent.DestroyChildren();
		foreach (WorldFrame frame in WorldMap.Current.Frames)
		{
			AddCell(frame);
		}
	}

	public void AddCell(WorldFrame frame)
	{
		WorldOverviewCell worldOverviewCell = Object.Instantiate(_cellPrefab, _cellsParent);
		worldOverviewCell.SetFrame(frame);
		worldOverviewCell.transform.localPosition = new Vector3((float)frame.Position.x * 1.5f, (float)frame.Position.y * 1.5f, -0.01f);
		frame.ActiveCell = worldOverviewCell;
		_traversable.UpdateBounds(worldOverviewCell.transform.position);
		_border.AddFrame(frame);
		WorldMap.Current.LazyLoadTerrain(frame.Position);
	}

	public void OnCellRemoved(WorldFrame frame)
	{
		_border.RemoveFrame(frame);
		if ((bool)frame.ActiveCell)
		{
			Object.Destroy(frame.ActiveCell.gameObject);
		}
	}

	public void HighlightCell(WorldFrame cellType)
	{
		if (_currentHighlight == cellType)
		{
			cellType = null;
		}
		_currentHighlight = cellType;
		foreach (WorldFrame frame in WorldMap.Current.Frames)
		{
			if ((bool)frame.ActiveCell)
			{
				frame.ActiveCell.SetHighlight(cellType);
			}
		}
	}

	public void ReloadAvailableUpgrades(TechNode tech)
	{
		foreach (WorldFrame frame in WorldMap.Current.Frames)
		{
			if (tech.UpgradedFrame == frame.Identifier && (bool)frame.ActiveCell)
			{
				frame.ActiveCell.UpdateWarningIcon();
			}
		}
	}
}
