using System;
using System.Collections;
using PajamaLlama.Extensions;
using PajamaLlama.Flotsam.World;
using UnityEngine;
using UnityEngine.PajamaLlama;

public class WorldMapScoutableLandmark : MonoBehaviour
{
	[Serializable]
	public struct RegionVisual
	{
		public WorldRegionType Region;

		[Tooltip("Reference to the instanced rumored visuals in the Prefab (should not reference a prefab asset!)")]
		[SceneReference]
		public GameObject Visual;
	}

	[SerializeField]
	[NamedArrayElement(new string[] { "Region" })]
	private RegionVisual[] _rumoredVisuals;

	[SerializeField]
	private WorldMapLandmarkMarker _marker;

	private GameObject _rumoredVisual;

	private ScoutingState _scoutingState;

	private Coroutine _setScoutingStateCoroutine;

	private Vector3 _scale;

	private WorldMapLandmarkPolygonVisual _visual;

	public WorldMapLandmark Landmark { get; private set; }

	public void Initialize(WorldMapLandmark worldMapLandmark, LandmarkSpawner landmarkSpawner)
	{
		base.transform.position = worldMapLandmark.transform.position;
		base.name = $"{worldMapLandmark.Spawner.Name} ({worldMapLandmark.Spawner.RegionType})";
		InstantiateRumoredVisual(landmarkSpawner);
		Landmark = worldMapLandmark;
		Landmark.transform.SetParent(base.transform, worldPositionStays: true);
		Landmark.gameObject.SetActive(value: true);
		_marker.Initialize(worldMapLandmark);
		Landmark.LandmarkSpawner.ApplyScoutingState();
		OnSpawnerUpdated(Landmark.Spawner);
		Landmark.LandmarkSpawner.UpdatedEvent.AddListener(OnSpawnerUpdated);
	}

	private void LateUpdate()
	{
		Vector3 scale = Landmark.Scale;
		if (scale != _scale)
		{
			_scale = scale;
			if ((bool)_rumoredVisual && _rumoredVisual.gameObject.activeInHierarchy && _setScoutingStateCoroutine == null)
			{
				_rumoredVisual.transform.localScale = _scale;
			}
			if ((bool)Landmark && Landmark.gameObject.activeInHierarchy)
			{
				Landmark.UpdateScale(_scale);
			}
			if ((bool)_marker && _marker.gameObject.activeInHierarchy)
			{
				_marker.UpdateScale(_scale);
			}
		}
	}

	private void OnDestroy()
	{
		if ((bool)Landmark && Landmark.LandmarkSpawner != null)
		{
			Landmark.LandmarkSpawner.UpdatedEvent.RemoveListener(OnSpawnerUpdated);
		}
	}

	public bool IsInSquareRadius(Vector2 center, float squareRadius)
	{
		if ((bool)Landmark)
		{
			return Landmark.IsInSquareRadius(center, squareRadius);
		}
		return false;
	}

	private void OnSpawnerUpdated(ISpawner spawner)
	{
		if (_scoutingState >= spawner.ScoutingState)
		{
			return;
		}
		_scoutingState = spawner.ScoutingState;
		switch (_scoutingState)
		{
		case ScoutingState.None:
		case ScoutingState.Selected:
			return;
		case ScoutingState.Rumored:
			if (!base.isActiveAndEnabled && (bool)_rumoredVisual)
			{
				_rumoredVisual.SetActive(value: true);
				return;
			}
			break;
		case ScoutingState.Confirmed:
		case ScoutingState.Scouted:
			if (!base.isActiveAndEnabled)
			{
				if ((bool)_rumoredVisual)
				{
					_rumoredVisual.SetActive(value: false);
				}
				ShowLandmark(instant: true);
				return;
			}
			break;
		}
		if (_setScoutingStateCoroutine != null)
		{
			StopCoroutine(_setScoutingStateCoroutine);
		}
		_setScoutingStateCoroutine = StartCoroutine(SetScoutingStateCoroutine(spawner.ScoutingState));
	}

	private IEnumerator SetScoutingStateCoroutine(ScoutingState scoutingState)
	{
		switch (scoutingState)
		{
		case ScoutingState.Rumored:
			if ((bool)_rumoredVisual && !_rumoredVisual.gameObject.activeSelf)
			{
				_rumoredVisual.transform.localScale = Vector3.zero;
				_rumoredVisual.gameObject.SetActive(value: true);
				yield return Tweener.TweenRoutine(0.5f, EasingFunctions.BounceOut, true, new TransformScaleTweener(_rumoredVisual.transform, Landmark.Scale.x));
			}
			break;
		case ScoutingState.Confirmed:
		case ScoutingState.Scouted:
			if ((bool)_rumoredVisual && _rumoredVisual.gameObject.activeSelf)
			{
				ShowLandmark();
				yield return Tweener.TweenRoutine(0.5f, EasingFunctions.BounceIn, true, new TransformScaleTweener(_rumoredVisual.transform, 0f));
				_rumoredVisual.gameObject.SetActive(value: false);
			}
			else
			{
				ShowLandmark();
			}
			break;
		}
		_setScoutingStateCoroutine = null;
	}

	private void ShowLandmark(bool instant = false)
	{
		if (_visual == null)
		{
			_visual = UnityEngine.Object.Instantiate(GameSettings.Instance.LandmarkSettings.LandmarkPolygonVisual, base.transform);
			_visual.Initialize(Landmark.LandmarkSpawner);
		}
		Landmark.Show(instant || LoadingScreen.IsLoading);
	}

	private void InstantiateRumoredVisual(LandmarkSpawner landmarkSpawner)
	{
		if (landmarkSpawner.LandmarkBehaviour.ReturnHasLandmarkActionReference<LandmarkActionRevealMap>())
		{
			GameObject gameObject = ReturnRegionVisual(landmarkSpawner);
			if ((bool)gameObject)
			{
				_rumoredVisual = UnityEngine.Object.Instantiate(gameObject, base.transform);
				_rumoredVisual.transform.Reset();
				_rumoredVisual.gameObject.SetActive(value: false);
			}
		}
	}

	private GameObject ReturnRegionVisual(ISpawner spawner)
	{
		RegionVisual[] rumoredVisuals = _rumoredVisuals;
		for (int i = 0; i < rumoredVisuals.Length; i++)
		{
			RegionVisual regionVisual = rumoredVisuals[i];
			if (regionVisual.Region == spawner.RegionType)
			{
				return regionVisual.Visual;
			}
		}
		Debug.LogException(new Exception($"'{base.name}' was unable to return region visual for region '{spawner.RegionType}', AD please add this ASAP."));
		return null;
	}
}
