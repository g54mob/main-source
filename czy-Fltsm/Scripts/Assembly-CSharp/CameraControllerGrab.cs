using UnityEngine;

public class CameraControllerGrab : IUpdateManagerLateUpdateTarget
{
	private Camera _camera;

	private int _activateActionId;

	private int[] _cancelButtons;

	private Plane _grabPlane;

	private bool _isGrabbing;

	private Vector3 _grabbedPosition;

	public CameraControllerGrab(Camera camera)
		: this(camera, 143)
	{
	}

	public CameraControllerGrab(Camera camera, int activateActionId, params int[] cancelActionIds)
	{
		_camera = camera;
		_activateActionId = activateActionId;
		_cancelButtons = cancelActionIds;
		_grabPlane = new Plane(Vector3.up, Vector3.zero);
	}

	public void UpdateManager_LateUpdate()
	{
		_grabbedPosition = GetGrabPosition();
	}

	public bool TryGetFocusPosition(out Vector3 position)
	{
		position = GetGrabPosition();
		return FlotsamInputManager.GetButtonDoublePressUp(_activateActionId);
	}

	public Vector3 GetMovement()
	{
		if (FlotsamInputManager.GetButtonDown(_activateActionId))
		{
			_isGrabbing = true;
			GameManager.UpdateManager.RegisterLateUpdateTarget(this);
		}
		else if (FlotsamInputManager.GetButtonUp(_activateActionId) || IsInterupted())
		{
			GameManager.UpdateManager.UnregisterLateUpdateTarget(this);
			_isGrabbing = false;
		}
		else if (FlotsamInputManager.GetButton(_activateActionId) && _isGrabbing)
		{
			Vector3 grabPosition = GetGrabPosition();
			return _grabbedPosition - grabPosition;
		}
		return Vector3.zero;
	}

	private Vector3 GetGrabPosition()
	{
		Ray ray = _camera.ScreenPointToRay(FlotsamInputManager.MousePosition);
		if (_grabPlane.Raycast(ray, out var enter))
		{
			return ray.origin + ray.direction * enter;
		}
		return Vector3.zero;
	}

	private bool IsInterupted()
	{
		if (_cancelButtons.IsNullOrEmpty())
		{
			return false;
		}
		int[] cancelButtons = _cancelButtons;
		for (int i = 0; i < cancelButtons.Length; i++)
		{
			if (FlotsamInputManager.GetButton(cancelButtons[i]))
			{
				return true;
			}
		}
		return false;
	}
}
