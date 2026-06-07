using System;
using System.Collections;
using PajamaLlama;
using PajamaLlama.Extensions;
using PajamaLlama.Generic;
using PajamaLlama.Math;
using PajamaLlama.Utilities;
using TMPro;
using UnityEngine;

public class WorldMapLandmark : WorldMapPointOfInterest
{
	[SerializeField]
	private GameObject _informationGameObject;

	[SerializeField]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	private float _markerPositionY = 80f;

	[SerializeField]
	[Tooltip("The renderers that need to be updated to show the progress made on the Landmark")]
	private Renderer[] _progressRenderers;

	[SerializeField]
	private ParticleSystem _rescueParticle;

	[SerializeField]
	private GameObject _revealMapIcon;

	[SerializeField]
	private WorldMapReveal _reveal;

	private LandmarkBehaviour _landmarkBehaviour;

	private float _poweredRadius;

	private Bounds _mapBounds;

	private Bounds _worldBounds;

	private RangedFloat _scaleRange;

	private Coroutine _showCoroutine;

	private Collider _collider3D;

	private WorldMapLandmarkPolygonVisual _footprint;

	public LandmarkSpawner LandmarkSpawner { get; private set; }

	public float MarkerPositionY => _markerPositionY;

	public PolygonCollider2D Collider2D { get; private set; }

	public Vector3 Scale => Vector3.one * _scaleRange.Evaluate(GameManager.WorldMapManager.WorldMap.WorldCameraController.ZoomController.CurrentZoomLevel);

	private void Awake()
	{
		if ((bool)_rescueParticle)
		{
			ParticleSystem.MainModule main = _rescueParticle.main;
			main.playOnAwake = false;
			_rescueParticle.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
		}
	}

	private void OnEnable()
	{
		if (_landmarkBehaviour is ActionsBehaviour actionsBehaviour)
		{
			foreach (LandmarkAction action in actionsBehaviour.Actions)
			{
				UpdateLandmarkAction(action);
			}
		}
		if ((bool)_landmarkBehaviour)
		{
			OnLandmarkUpdate(_landmarkBehaviour, null);
		}
		if (_showCoroutine != null)
		{
			StopCoroutine(_showCoroutine);
			_showCoroutine = StartCoroutine(ShowCoroutine());
		}
	}

	private void OnMouseEnter()
	{
		_informationGameObject.SetActive(value: true);
		AudioManager.Play(GameManager.Settings.AudioSettings.LandmarkHoverEnterAudio);
	}

	private void OnMouseExit()
	{
		_informationGameObject.SetActive(value: false);
		AudioManager.Play(GameManager.Settings.AudioSettings.LandmarkHoverExitAudio);
	}

	private void OnDisable()
	{
		_informationGameObject.SetActive(value: false);
	}

	protected override void OnDestroy()
	{
		_landmarkBehaviour.UpdatedEvent.RemoveListener(OnLandmarkUpdate);
		base.OnDestroy();
	}

	public void Initialize(LandmarkSpawner landmarkSpawner)
	{
		LandmarkSpawner = landmarkSpawner;
		_landmarkBehaviour = landmarkSpawner.LandmarkBehaviour;
		_landmarkBehaviour.UpdatedEvent.AddListener(OnLandmarkUpdate);
		_collider3D = GetComponent<Collider>();
		if (_nameText == null)
		{
			Debug.LogErrorFormat("_nameText == null: '{0}'", base.name);
		}
		else
		{
			_nameText.text = _landmarkBehaviour.Name;
		}
		base.name = _landmarkBehaviour.name;
		base.transform.localPosition = landmarkSpawner.TilePosition.Vector3TopDown();
		base.transform.rotation = landmarkSpawner.Rotation;
		_poweredRadius = Mathf.Pow(GameManager.Settings.GameplaySettings.ConstructionRadius, 2f);
		_informationGameObject.SetActive(value: false);
		_scaleRange = GameSettings.Instance.LandmarkSettings.MapScaling;
		LandmarkMooringPoint landmarkMooringPoint = _landmarkBehaviour.ReturnMooringPoint();
		if ((bool)landmarkMooringPoint)
		{
			Transform entranceTransform = landmarkMooringPoint.EntranceTransform;
			GameObject obj = UnityEngine.Object.Instantiate(GameSettings.Instance.LandmarkSettings.MapMooringPointPrefab, base.transform);
			Vector3 eulerAngles = entranceTransform.transform.rotation.eulerAngles;
			eulerAngles.x = 0f;
			eulerAngles.z = 0f;
			obj.transform.localRotation = Quaternion.Euler(eulerAngles);
			obj.transform.localPosition = entranceTransform.transform.position;
		}
		Initialize((ISpawner)landmarkSpawner);
		if ((bool)_reveal)
		{
			_reveal.Initialize(this);
		}
		if (base.isActiveAndEnabled)
		{
			FinalUpdate.RegisterOneShot(OnEnable);
		}
	}

	public void UpdateScale(Vector3 scale)
	{
		if (ScoutingState.Rumored < base.Spawner.ScoutingState && _showCoroutine == null)
		{
			base.transform.localScale = Scale;
		}
	}

	public void Show(bool instant)
	{
		if (!base.IsActive)
		{
			if (instant)
			{
				Activate();
			}
			else if (_showCoroutine == null)
			{
				_showCoroutine = StartCoroutine(ShowCoroutine());
			}
		}
	}

	private IEnumerator ShowCoroutine()
	{
		Activate();
		base.transform.localScale = Vector3.zero;
		yield return Tweener.TweenRoutine(0.5f, Easing.BounceIn, true, new TransformScaleTweener(base.transform, Scale.x));
		_showCoroutine = null;
	}

	public void AquireCollider(PolygonCollider2D prefab, Transform parent)
	{
		if (!Collider2D)
		{
			Collider2D = PrefabPool.GetInstance(prefab);
			Collider2D.name = LandmarkSpawner.LandmarkBehaviour.Name;
			Collider2D.transform.SetParent(parent);
			Collider2D.transform.Reset();
			Collider2D.SetPath(0, LandmarkSpawner.TileSpacePolygon.Polygon2D);
		}
	}

	public void ReleaseCollider()
	{
		if (Collider2D != null)
		{
			PrefabPool.Repool(Collider2D);
			Collider2D = null;
		}
	}

	public bool RayCast(Ray ray, float maxDistance)
	{
		RaycastHit hitInfo;
		if ((bool)_collider3D)
		{
			return _collider3D.Raycast(ray, out hitInfo, maxDistance);
		}
		return false;
	}

	public Vector3 SelectAndCalulateEntrancePosition()
	{
		Transform transform = GameManager.WorldMapManager.WorldMap.Townheart.transform;
		Vector3 relativePosition = transform.rotation * transform.InverseTransformPoint(base.transform.position);
		GameManager.WorldMapManager.WorldMap.WorldCameraController.SetRelativePosition(relativePosition);
		return ReturnEntrancePosition(base.transform.position, base.transform.rotation);
	}

	public override bool InitializeReveal()
	{
		if ((bool)_reveal)
		{
			return _reveal.InitializeReveal(this);
		}
		return false;
	}

	public override IEnumerator RevealRoutine()
	{
		if ((bool)_reveal)
		{
			yield return _reveal.Reveal(this);
		}
	}

	protected override void OnSpawnerUpdated(ISpawner spawner)
	{
		if (!base.IsActive && LandmarkSpawner.IsBearingActive())
		{
			Activate();
		}
	}

	private void OnLandmarkUpdate(LandmarkBehaviour behaviour, object trigger)
	{
		float value = behaviour.ReturnProgress();
		UpdateLandmarkAction(trigger as ILandmarkAction);
		if (_progressRenderers.IsNullOrEmpty())
		{
			Debug.LogException(new Exception("[ART] Landmark map visual '" + base.name + "' its progress renderers have not been set yet."));
		}
		else
		{
			Renderer[] progressRenderers = _progressRenderers;
			for (int i = 0; i < progressRenderers.Length; i++)
			{
				progressRenderers[i].material.SetFloat("_Progress", value);
			}
		}
		OnSpawnerUpdated(base.Spawner);
	}

	private void UpdateLandmarkAction(ILandmarkAction action)
	{
		if (!base.isActiveAndEnabled || action == null)
		{
			return;
		}
		if (action is LandmarkActionRescue && (bool)_rescueParticle)
		{
			if (action.IsCompleted)
			{
				if (_rescueParticle.isPlaying)
				{
					_rescueParticle.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
				}
			}
			else if (!_rescueParticle.isPlaying)
			{
				_rescueParticle.Play(withChildren: true);
			}
		}
		else if (action is LandmarkActionRevealMap && (bool)_revealMapIcon)
		{
			_revealMapIcon.SetActive(!action.IsCompleted);
		}
	}

	public Vector3 ReturnEntrancePosition()
	{
		return ReturnEntrancePosition(base.transform.position, base.transform.rotation);
	}

	private Vector3 ReturnEntrancePosition(Vector3 position, Quaternion rotation)
	{
		LandmarkMooringPoint landmarkMooringPoint = _landmarkBehaviour.ReturnMooringPoint();
		Vector3 vector = position + rotation * landmarkMooringPoint.transform.position.Vector3TopDown();
		Vector3 vector2 = position + rotation * landmarkMooringPoint.EntranceTransform.position.Vector3TopDown();
		Vector3 normalized = (vector2 - vector).normalized;
		if (normalized.magnitude == 0f)
		{
			return Vector3.zero;
		}
		vector2 += normalized * GameManager.Settings.GameplaySettings.ConstructionRadius;
		for (; IsInSquareRadius(vector2.Vector2TopDown(), _poweredRadius); vector2 += normalized)
		{
		}
		return vector2;
	}

	public bool IsInSquareRadius(Vector2 center, float squareRadius)
	{
		Vector2[] polygon2D = LandmarkSpawner.TileSpacePolygon.Polygon2D;
		for (int i = 0; i < polygon2D.Length; i++)
		{
			if ((center - polygon2D[i]).sqrMagnitude < squareRadius)
			{
				return true;
			}
		}
		return false;
	}

	private Vector3 ReturnClosestPosition(Bounds bounds, Vector3 position)
	{
		Vector2 vector = position.Vector2TopDown() - LandmarkSpawner.WorldPosition2D;
		Vector3 vector2 = bounds.ClosestPoint(vector.Vector3TopDown()).SetY(0f);
		return LandmarkSpawner.WorldPosition2D.Vector3TopDown() + vector2;
	}

	public Vector3 ReturnClosestMapPosition(Vector3 worldPosition)
	{
		return ReturnClosestPosition(_mapBounds, worldPosition);
	}

	public Vector3 ReturnClosestWorldPosition(Vector3 worldPosition)
	{
		return ReturnClosestPosition(_worldBounds, worldPosition);
	}

	public Vector3 ReturnClosestPolygonPosition(Vector3 position, out Vector3 edgeStart, out Vector3 edgeEnd, out float distance)
	{
		Polygon2DLine closestSide;
		Vector3 result = LandmarkSpawner.TileSpacePolygon.GetClosestPointOnPolygon(out closestSide, out distance, position.Vector2TopDown()).Vector3TopDown();
		edgeStart = closestSide.Point.Vector3TopDown();
		edgeEnd = edgeStart + closestSide.Vector.Vector3TopDown();
		return result;
	}

	private void OnDrawGizmos()
	{
		if (LandmarkSpawner != null && LandmarkSpawner.TileSpacePolygon != null)
		{
			Vector2[] polygon2D = LandmarkSpawner.TileSpacePolygon.Polygon2D;
			for (int i = 0; i < polygon2D.Length; i++)
			{
				Vector3 start = polygon2D[i].Vector3TopDown();
				int num = (i + 1) % polygon2D.Length;
				Vector3 end = polygon2D[num].Vector3TopDown();
				Debug.DrawLine(start, end);
			}
		}
	}
}
