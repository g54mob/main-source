using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Transform node_CameraCenterNode;

	[SerializeField]
	private bool doOverrideMainCamera;

	[SerializeField]
	private float rangeLimit;

	[FormerlySerializedAs("orthoLerpRate")]
	[SerializeField]
	private float screenScaleLerpRate;

	[SerializeField]
	private float positionLerpSpeed;

	[Header("[Ortho]")]
	[SerializeField]
	private Vector2 camOrthoSizeRange;

	private float camDefaultOrthoSize;

	private float camTargetOrthoSize;

	[SerializeField]
	[Header("[Perspective]")]
	private Vector2 camPerspectiveFOVScaleRange;

	private float camDefaultFOV;

	private float camTargetFOV;

	private Camera camera;

	private Vector3 lastRightClickOrigin;

	private Vector3 rightClickDiff;

	private float cameraDistanceToGround;

	private Vector3 targetCameraLerpPosition;

	private Vector3 startPos;

	private Vector3 lastFramePosition;

	private bool isMovingCamera;

	private bool isMouseInWindow;

	private bool isLockCameraForPlayer;

	private int movingCameraMouseButtonIndex;

	private Transform cameraLockTarget;

	private bool isCameraLockOnTarget;

	private int mouseButtonInEditMode;

	public float RangeLimit => 0f;

	public bool IsMovingCamera => false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void SetupCenterNode()
	{
	}

	private void Initialize()
	{
	}

	public float GetCurrentFOV()
	{
		return 0f;
	}

	public void OverrideFOV(float fov)
	{
	}

	public void OverrideFOVLimitRange_Min(float min)
	{
	}

	public void OverrideFOVLimitRange_Max(float max)
	{
	}

	public Vector3 GetCurrentCameraOffset()
	{
		return default(Vector3);
	}

	public Vector3 GetCurrentCameraPosition()
	{
		return default(Vector3);
	}

	public void SetCameraPositionByOffset(Vector3 offset, bool isImmediate)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGameStateChanged(eGameState fromState, eGameState toState)
	{
	}

	private void OnInitializeEnvSceneBindings(GameSceneReferenceHandler handler)
	{
	}

	private void OnToggleLockCameraForPlayer(bool doLock)
	{
	}

	private void OnShowStageAnnounce(int index, float duration)
	{
	}

	private bool IsCameraLocked()
	{
		return false;
	}

	private void RotateClockwise()
	{
	}

	private void RotateCounterClockwise()
	{
	}

	private void Update()
	{
	}

	private void Update_KeyboardMouseControl()
	{
	}

	private Vector3 LimitPositionInRange(Vector3 pos)
	{
		return default(Vector3);
	}

	private float GetDistanceToPlane(Vector3 planePosition, Vector3 planeNormal)
	{
		return 0f;
	}

	private float GetDistanceToPlaneFromScreenCenter(Vector3 planePosition, Vector3 planeNormal, Camera overrideCamera = null)
	{
		return 0f;
	}

	public void BindWeatherEffectToCamera(Transform item, Vector3 offset)
	{
	}

	public Vector3 GetMouseWorldPos()
	{
		return default(Vector3);
	}

	public Vector3 GetCameraForward()
	{
		return default(Vector3);
	}

	public Vector3 GetCameraCenterPointOnGround()
	{
		return default(Vector3);
	}

	public void SetCameraLockTarget(Transform target)
	{
	}

	public void ClearCameraLockTarget(Transform target)
	{
	}
}
