using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class WorldMapCanvas : SceneBehaviour
{
	public EventButton MovementButton;

	[SerializeField]
	private Canvas _canvas;

	[SerializeField]
	private RewiredActionInfoBar _rewiredActionInfoBar;

	[Header("Trackers")]
	[SerializeField]
	private Tracker _trackerPrefab;

	[SerializeField]
	private Transform _trackerParent;

	[Header("Markers")]
	[SerializeField]
	private WorldMapMarker _markerPrefab;

	[SerializeField]
	private Transform _markerParent;

	[Header("Energy Cost Tooltip")]
	[SerializeField]
	private RectTransform _tooltipCanvas;

	[SerializeField]
	private RectTransform _costTooltip;

	[SerializeField]
	private TextMeshProUGUI _costTooltipText;

	private Tracker _townheartTracker;

	private WorldMap _worldMap;

	private readonly Queue<IWorldMapMarkerTarget> _instantiateAgentMarkerQueue = new Queue<IWorldMapMarkerTarget>(8);

	private readonly Dictionary<IWorldMapMarkerTarget, WorldMapMarker> _markers = new Dictionary<IWorldMapMarkerTarget, WorldMapMarker>(32);

	public RewiredActionInfoBar RewiredActionInfoBar => _rewiredActionInfoBar;

	public void Initialize(WorldMap worldMap)
	{
		_worldMap = worldMap;
		_townheartTracker = Object.Instantiate(_trackerPrefab, _trackerParent);
		_townheartTracker.Initialize(_worldMap.WorldCameraController.Camera, _worldMap.WorldCameraController.transform, _worldMap.Townheart.transform);
	}

	private void Start()
	{
		while (_instantiateAgentMarkerQueue.Count > 0)
		{
			InstantiateMarker(_instantiateAgentMarkerQueue.Dequeue());
		}
	}

	public void EnableUI()
	{
		_canvas.enabled = true;
	}

	public void DisableUI()
	{
		_canvas.enabled = false;
	}

	public void InstantiateMarker(IWorldMapMarkerTarget target)
	{
		if (!_markers.ContainsKey(target))
		{
			if (_worldMap == null)
			{
				_instantiateAgentMarkerQueue.Enqueue(target);
				return;
			}
			WorldMapMarker worldMapMarker = Object.Instantiate(_markerPrefab, _markerParent);
			worldMapMarker.Initialize(_worldMap, _canvas.transform as RectTransform, target);
			_markers.Add(target, worldMapMarker);
		}
	}

	public bool TryDestroyMarker(IWorldMapMarkerTarget target)
	{
		if (_markers.TryGetValue(target, out var value))
		{
			if ((bool)value)
			{
				Object.Destroy(value.gameObject);
			}
			_markers.Remove(target);
			return true;
		}
		return _instantiateAgentMarkerQueue.Remove(target);
	}

	public void SetCostTooltipActive(bool active)
	{
		_costTooltip.gameObject.SetActive(active);
	}

	public void UpdateCostTooltip(float energyCost, Vector2 screenPosition)
	{
		_costTooltipText.text = energyCost.ToString("F0");
		RectTransformUtility.ScreenPointToLocalPointInRectangle(_tooltipCanvas, screenPosition, null, out var localPoint);
		_costTooltip.localPosition = localPoint;
	}
}
