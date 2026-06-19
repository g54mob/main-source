using System.Collections;
using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraController : AggroManagerBase<CameraController>, IInputController
{
	public enum Mode
	{
		PlayerFollow = 0,
		FocusPosition = 1,
		Stopped = 2,
		FreeFixedCam = 3,
		FreeCam = 4,
		EntityLocked = 5
	}

	public Vector3 offset;

	public float fov = 30f;

	public float vcFovAffectThresholdSpeed = 5f;

	public float fovMaxSpeedOffset = 10f;

	public float fovLerpSpeed = 15f;

	[Min(0f)]
	public float lerpSpeed = 10f;

	[Header("Focus")]
	public EasingFunction.Ease focusEase = EasingFunction.Ease.EaseInOutQuad;

	[Header("Debug Free Fixed")]
	[Min(0f)]
	public float freeFixedSpeed = 14f;

	[Min(0f)]
	public float freeFixedLerpSpeed = 8f;

	[Header("Debug Free Cam")]
	[Min(0f)]
	public float freeCamMouseSensitivity = 0.5f;

	[Range(0f, 90f)]
	public float freeCamYRotationLimitDegrees = 80f;

	[Min(0f)]
	public float freeCamPositionLerpSpeed = 10f;

	[Min(0f)]
	public float freeCamRotationSlerpSpeed = 10f;

	[Min(0f)]
	public float freeCamForwardSpeed = 10f;

	[Min(0f)]
	public float freeCamSideSpeed = 7f;

	public Volume freeCamPost;

	private Camera _cam;

	private float _targetFOV;

	private TipTapPhoneVisual _localTipTapPhoneVisual;

	private Transform _transform;

	private Mode _mode;

	private bool _snapToPlayer;

	private Quaternion _originalRot;

	private Vector3 _freePos;

	private float _freeCamYaw;

	private float _freeCamPitch;

	private Entity _lockedTarget;

	public Mode mode => _mode;

	protected override void OnEntityCreated()
	{
		_cam = GetComponent<Camera>();
		_transform = base.transform;
		_snapToPlayer = true;
		FollowPlayer();
		_originalRot = _transform.localRotation;
	}

	protected override void OnUpdatePresentation()
	{
		float num = 0f;
		bool flag = false;
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			VehicleController vehicleController = player.GetObject<VehicleController>();
			num = vehicleController.velocitySync.magnitude / vehicleController.maxSpeedForward;
			flag = vehicleController.drifting;
		}
		float b = fov;
		if (num > vcFovAffectThresholdSpeed)
		{
			b = fov + fovMaxSpeedOffset * num;
		}
		if (flag)
		{
			b = fov + fovMaxSpeedOffset;
		}
		_cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, b, fovLerpSpeed * Time.deltaTime);
		if ((bool)freeCamPost)
		{
			freeCamPost.gameObject.SetActive(_mode == Mode.FreeCam);
			if (_mode == Mode.FreeCam)
			{
				bool flag2 = AggroInputManager.input.DebugCam.ZoomIn.WasPressedThisFrame();
				bool flag3 = AggroInputManager.input.DebugCam.ZoomOut.WasPressedThisFrame();
				bool flag4 = AggroInputManager.input.DebugCam.Modifier.IsPressed();
				if (freeCamPost.profile.TryGet<DepthOfField>(out var component))
				{
					if (flag2)
					{
						component.focusDistance.value += (flag4 ? 0.1f : 1f);
					}
					if (flag3)
					{
						component.focusDistance.value -= (flag4 ? 0.1f : 1f);
					}
				}
			}
		}
		switch (_mode)
		{
		case Mode.PlayerFollow:
		{
			if (!GameUtil.TryGetLocalPlayer(out var player2))
			{
				_snapToPlayer = true;
				break;
			}
			Vector3 vector6 = player2.transform.position + offset;
			if (_snapToPlayer)
			{
				_snapToPlayer = false;
				_transform.position = vector6;
			}
			else
			{
				_transform.position = Vector3.Lerp(_transform.position, vector6, lerpSpeed * Time.deltaTime);
			}
			break;
		}
		case Mode.EntityLocked:
			if (_lockedTarget.Exists())
			{
				_transform.position = Vector3.Lerp(_transform.position, _lockedTarget.transform.position + offset, lerpSpeed * Time.deltaTime);
			}
			break;
		case Mode.FreeFixedCam:
			if (AggroInputManager.HasControl(this))
			{
				Vector2 vector5 = AggroInputManager.input.DebugCam.Move.ReadValue<Vector2>();
				if (vector5.sqrMagnitude > 1f)
				{
					vector5.Normalize();
				}
				_freePos += new Vector3(vector5.x, 0f, vector5.y) * (freeFixedSpeed * Time.deltaTime);
			}
			_transform.position = Vector3.Lerp(_transform.position, _freePos + offset, freeFixedLerpSpeed * Time.deltaTime);
			break;
		case Mode.FreeCam:
			if (AggroInputManager.HasControl(this))
			{
				Vector2 vector = AggroInputManager.input.DebugCam.Look.ReadValue<Vector2>();
				_freeCamYaw += vector.x * freeCamMouseSensitivity;
				_freeCamPitch += vector.y * freeCamMouseSensitivity;
				_freeCamPitch = math.clamp(_freeCamPitch, 0f - freeCamYRotationLimitDegrees, freeCamYRotationLimitDegrees);
				Quaternion obj = Quaternion.AngleAxis(_freeCamYaw, Vector3.up);
				Quaternion quaternion2 = Quaternion.AngleAxis(_freeCamPitch, Vector3.left);
				Quaternion b2 = obj * quaternion2;
				_transform.localRotation = Quaternion.Slerp(_transform.localRotation, b2, freeCamRotationSlerpSpeed * Time.deltaTime);
				Quaternion localRotation = _transform.localRotation;
				Vector2 vector2 = AggroInputManager.input.DebugCam.Move.ReadValue<Vector2>();
				if (vector2.sqrMagnitude > 1f)
				{
					vector2.Normalize();
				}
				Vector3 vector3 = localRotation * Vector3.forward;
				Vector3 vector4 = localRotation * Vector3.right;
				_freePos += vector3 * (vector2.y * freeCamForwardSpeed * Time.deltaTime) + vector4 * (vector2.x * freeCamSideSpeed * Time.deltaTime);
				_transform.position = Vector3.Lerp(_transform.position, _freePos, freeCamPositionLerpSpeed * Time.deltaTime);
			}
			break;
		default:
			throw new InvalidEnumException();
		case Mode.FocusPosition:
		case Mode.Stopped:
			break;
		}
	}

	public void FollowPlayer()
	{
		if (_mode != Mode.PlayerFollow)
		{
			_mode = Mode.PlayerFollow;
			_snapToPlayer = true;
		}
	}

	private void SnapToPlayer()
	{
		if (GameUtil.TryGetLocalPlayer(out var player) && player.TryGetObject<VehicleController>(out var obj))
		{
			_transform.position = obj.transform.position + offset;
		}
	}

	public void SetToPosition(Vector3 targetPosition)
	{
		_mode = Mode.FocusPosition;
		_transform.position = targetPosition + offset;
	}

	public IEnumerator SetFocusPositionCo(Vector3 targetPosition, float duration)
	{
		_mode = Mode.FocusPosition;
		Vector3 startPosition = _transform.position - offset;
		float focusTime = 0f;
		do
		{
			yield return null;
			focusTime += Time.deltaTime;
			float t = EasingFunction.Evaluate(focusEase, 0f, 1f, math.saturate(focusTime / duration));
			_transform.position = Vector3.Lerp(startPosition, targetPosition, t) + offset;
		}
		while (focusTime < duration);
		_mode = Mode.Stopped;
	}

	public void LockToEntity(Entity e)
	{
		_mode = Mode.EntityLocked;
		_lockedTarget = e;
		if (_lockedTarget.Exists())
		{
			_transform.position = _lockedTarget.transform.position + offset;
		}
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.DebugCam.Enable();
		AggroInputManager.HideMouseCursor();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.DebugCam.Disable();
		AggroInputManager.ResetMouseCursor();
	}
}
