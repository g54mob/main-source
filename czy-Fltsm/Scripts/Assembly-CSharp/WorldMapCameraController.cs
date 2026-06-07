using FMODUnity;
using PajamaLlama.Generic;
using UnityEngine;

public class WorldMapCameraController : SceneBehaviour
{
	[SerializeField]
	private float _followSmoothness = 2.5f;

	[SerializeField]
	[MinMaxRangeInt(200, 1000)]
	private RangedInt _movementSpeedRange;

	public Camera Camera;

	[SerializeField]
	private CameraFrustum _frustum;

	[SerializeField]
	[Range(0f, 1f)]
	[Tooltip("The padding between the border and the position of the camera. The padding is a percentage of the ZoomController.Range.Maximum.")]
	private float _padding = 0.75f;

	private AudioListener _audioListener;

	private StudioListener _fmodListener;

	private Transform _followTransform;

	private WorldMap _worldMap;

	private CameraControllerGrab _grabber;

	private Rect _worldBounds;

	private Rect _paddedWorldBounds;

	public CameraZoomController ZoomController { get; private set; }

	public Vector3 RelativePosition { get; private set; } = Vector3.zero;

	public CameraFrustum Frustum => _frustum;

	public void Initialize(WorldMap worldMap, Transform transformToFollow)
	{
		_worldMap = worldMap;
		_followTransform = transformToFollow;
		ZoomController = GetComponentInChildren<CameraZoomController>();
		_audioListener = GetComponentInChildren<AudioListener>();
		_fmodListener = GetComponentInChildren<StudioListener>();
		_grabber = new CameraControllerGrab(Camera, 143, 144);
		SetAudioListenerEnabled(enabled: false);
		OnWorldBoundsUpdated();
	}

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.WorldTileAdded, OnWorldBoundsUpdated);
		GameEventDispatcher.AddListener(GameEventType.WorldTileRemoved, OnWorldBoundsUpdated);
		OnWorldBoundsUpdated();
	}

	private void Update()
	{
		if (_grabber.TryGetFocusPosition(out var position))
		{
			RelativePosition = position - _worldMap.Townheart.transform.position;
		}
		float pausableUnscaledDeltaTime = GameSpeedManager.PausableUnscaledDeltaTime;
		float num = _movementSpeedRange.EvaluateRounded(ZoomController.DesiredZoomLevel);
		Vector3 vector = Vector3.Lerp(base.transform.position - RelativePosition, _followTransform.position, pausableUnscaledDeltaTime * _followSmoothness);
		Vector4 cameraInput = FlotsamInputManager.GetCameraInput(FlotsamInputManager.Layouts.Map);
		RelativePosition += _grabber.GetMovement();
		RelativePosition += cameraInput.x * num * pausableUnscaledDeltaTime * base.transform.right;
		RelativePosition += cameraInput.y * num * pausableUnscaledDeltaTime * base.transform.forward;
		UpdatePaddedWorldBounds();
		Vector3 vector2 = vector + RelativePosition;
		vector2.x = Mathf.Clamp(vector2.x, _paddedWorldBounds.xMin, _paddedWorldBounds.xMax);
		vector2.z = Mathf.Clamp(vector2.z, _paddedWorldBounds.yMin, _paddedWorldBounds.yMax);
		base.transform.position = vector2;
		RelativePosition = vector2 - vector;
		RotateCamera(cameraInput.z);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.WorldTileAdded, OnWorldBoundsUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.WorldTileRemoved, OnWorldBoundsUpdated);
	}

	public void SetAudioListenerEnabled(bool enabled)
	{
		if ((bool)_audioListener)
		{
			_audioListener.enabled = enabled;
		}
		if ((bool)_fmodListener)
		{
			_fmodListener.enabled = enabled;
		}
	}

	public void SetRelativePosition(Vector3 position)
	{
		RelativePosition = position;
	}

	private void RotateCamera(float rotationInput)
	{
		float num = rotationInput * GameSpeedManager.PausableUnscaledDeltaTime * Settings.Instance.GameplayPlayerData.RotationSensitivity;
		if (Settings.Instance.GameplayPlayerData.InvertHorizontalRotation)
		{
			num *= -1f;
		}
		base.transform.Rotate(Vector3.up * num, Space.World);
	}

	private void OnWorldBoundsUpdated(GameEvent gameEvent = null)
	{
		_worldBounds = WorldManager.ReturnWorldBounds();
	}

	private void UpdatePaddedWorldBounds()
	{
		float num = ZoomController.ZoomRange.Evaluate(ZoomController.CurrentZoomLevel) * _padding;
		_paddedWorldBounds = _worldBounds;
		_paddedWorldBounds.xMin += num;
		_paddedWorldBounds.yMin += num;
		_paddedWorldBounds.xMax -= num;
		_paddedWorldBounds.yMax -= num;
	}
}
