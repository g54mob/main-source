using Assets.Scripts;
using ModApi;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraOrbitScript : MonoBehaviour, IDragHandler, IEventSystemHandler
{
	public float Scale;

	[SerializeField]
	private bool _autoMove = true;

	[SerializeField]
	private Camera _camera;

	[SerializeField]
	private Transform _cameraTarget;

	private Vector2 _deltaRotation = Vector3.zero;

	private float _lastZoomTime;

	private double _minZoomDistance;

	private Vector3 _prevDeltaVec;

	private float _targetDistance = 2f;

	public Camera Camera => _camera;

	public Transform CameraTarget
	{
		get
		{
			return _cameraTarget;
		}
		set
		{
			_cameraTarget = value;
			_minZoomDistance = 0.0;
			DistanceFromTarget = Vector3.Distance(Camera.transform.position, _cameraTarget.position);
			_targetDistance = (((double)DistanceFromTarget > MaxZoomDistance) ? DistanceFromTarget : _targetDistance);
			_prevDeltaVec = Camera.transform.position - _cameraTarget.position;
		}
	}

	public float CurrentZoomDistance => _targetDistance;

	public float CurrentZoomPercent
	{
		get
		{
			float num = (float)(MaxZoomDistance - MinZoomDistance);
			float num2 = (float)((double)CurrentZoomDistance - MinZoomDistance);
			return 1f - num2 / num;
		}
	}

	public float DistanceFromTarget { get; private set; }

	public double MaxZoomDistance => 500000.0;

	public double MinZoomDistance => _minZoomDistance;

	public double ZoomStep => (MaxZoomDistance - MinZoomDistance) / 50.0;

	public void OnDrag(PointerEventData eventData)
	{
		float num = 0.25f;
		Vector2 delta = new Vector2(eventData.delta.y * num, (0f - eventData.delta.x) * num);
		Rotate(delta);
	}

	public void OnEnable()
	{
		CameraTarget = _cameraTarget;
		float targetDistance = (DistanceFromTarget = Vector3.Distance(Camera.transform.position, _cameraTarget.position));
		_targetDistance = targetDistance;
		if (_autoMove)
		{
			AutoMove();
		}
	}

	public void Update()
	{
		if (!_autoMove)
		{
			UpdateCamera();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			Screen.SetResolution(1280, 720, fullscreen: false);
		}
	}

	public void Zoom(float amount)
	{
		float num = ((!((double)(Time.unscaledTime - _lastZoomTime) > 0.15)) ? (_targetDistance * 0.2f) : (_targetDistance * 0.1f));
		_targetDistance -= num * Mathf.Sign(amount);
		_lastZoomTime = Time.unscaledTime;
	}

	private void AutoMove()
	{
	}

	private void EnsureCameraIsInBounds()
	{
		float num = 35f;
		if (!Device.IsMobileBuild)
		{
			num *= 2f;
		}
		Vector3 position = Camera.transform.position;
		if (position.magnitude > num)
		{
			position = position.normalized * num;
			Camera.transform.position = position;
			Camera.transform.LookAt(_cameraTarget.transform);
		}
	}

	private void OnDisable()
	{
	}

	private void Rotate(Vector2 delta, bool additiveRotation = true)
	{
		if (additiveRotation)
		{
			_deltaRotation += delta * 1f;
			_deltaRotation.x = Mathf.Clamp(_deltaRotation.x, -89f, 89f);
		}
		else
		{
			_deltaRotation = delta;
		}
	}

	private void UpdateCamera()
	{
		Camera.transform.position = _cameraTarget.position + _prevDeltaVec;
		DistanceFromTarget = Vector3.Distance(Camera.transform.position, _cameraTarget.position);
		float num = Game.Instance.Inputs.CameraLookZoom.GetAxis() * 0.5f;
		num = Input.GetAxis("MouseAxis3");
		if (num != 0f)
		{
			Zoom(num);
		}
		_targetDistance = Mathf.Clamp(_targetDistance, (float)MinZoomDistance, (float)MaxZoomDistance);
		Quaternion b = Quaternion.Euler(0f - _deltaRotation.x, 0f - _deltaRotation.y, 0f);
		Quaternion quaternion = Quaternion.Slerp(Camera.transform.rotation, b, 3f * Time.unscaledDeltaTime);
		float num2 = Mathf.Lerp(DistanceFromTarget, _targetDistance, 3f * Time.unscaledDeltaTime);
		Camera.transform.position = _cameraTarget.position - quaternion * Vector3.forward * num2;
		Camera.transform.LookAt(_cameraTarget, Vector3.up);
		_prevDeltaVec = Camera.transform.position - _cameraTarget.position;
	}
}
