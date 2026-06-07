using Rewired;
using RewiredConsts;
using UnityEngine;

public class WorldMapManager : SceneBehaviour
{
	public WorldMap WorldMap;

	[SerializeField]
	[ActionIdProperty(typeof(Action))]
	private int _toggleMapAction;

	private void Update()
	{
		if (!GameManager.Gamepaused && FlotsamInputManager.GetButtonDown(_toggleMapAction) && !TryCloseMap())
		{
			OpenMap();
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.CameraMaxZoom, OnCameraMaximumZoom);
		GameEventDispatcher.RemoveListener(GameEventType.CameraMinZoom, OnCameraMinimumZoom);
	}

	public void Initialize()
	{
		WorldMap.Initialize();
		WorldMap.gameObject.SetActive(value: false);
		GameEventDispatcher.AddListener(GameEventType.CameraMaxZoom, OnCameraMaximumZoom);
		GameEventDispatcher.AddListener(GameEventType.CameraMinZoom, OnCameraMinimumZoom);
	}

	private void OnCameraMaximumZoom(GameEvent gameEvent)
	{
		OpenMap();
	}

	private void OnCameraMinimumZoom(GameEvent gameEvent)
	{
		TryCloseMap();
	}

	private void OpenMap()
	{
		if (UIManager.State != UIState.Building && UIManager.State != UIState.Architect)
		{
			WorldMap.Open();
		}
	}

	private bool TryCloseMap()
	{
		if (WorldMap.isActiveAndEnabled)
		{
			return WorldMap.Close();
		}
		return false;
	}

	public static bool CenterOnTownheart()
	{
		if (TryReturnInstance(out var instance) && (bool)instance.WorldMap && instance.WorldMap.isActiveAndEnabled)
		{
			instance.WorldMap.CenterOnTownheart();
			return true;
		}
		return false;
	}

	public static void InstantiateMarker(IWorldMapMarkerTarget target)
	{
		GameManager.UIManager.WorldMapCanvas.InstantiateMarker(target);
	}

	public static void DestroyMarker(IWorldMapMarkerTarget target)
	{
		GameManager.UIManager.WorldMapCanvas.TryDestroyMarker(target);
	}

	private static bool TryReturnInstance(out WorldMapManager instance)
	{
		instance = GameManager.WorldMapManager;
		return instance != null;
	}

	public static float ReturnTileSpawningRange(float defaultValue)
	{
		if (TryReturnInstance(out var instance) && (bool)instance.WorldMap)
		{
			return instance.WorldMap.ReturnTileSpawningRange();
		}
		return defaultValue;
	}
}
