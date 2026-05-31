using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	private int ScreenWidth;

	private int ScreenHeight;

	private bool _isDragging;

	private Vector3 _dragOrigin;

	private float _zoomSpeed = 0.6f;

	private float _minZoom = 2f;

	private float _maxZoom = 20f;

	public InputActionReference InputRef;

	public InputActionReference InputShiftRef;

	public InputActionReference InputEscRef;

	public InputActionReference InputZoomInRef;

	public InputActionReference InputZoomOutRef;

	public static CameraController Instance;

	public GameObject BottomRight;

	public GameObject TopLeft;

	private Tweener _shakeTween;

	private bool _stopMovement;

	private float _zoomTo;

	public bool IsStopMovement => _stopMovement;

	private void Start()
	{
		ScreenWidth = Screen.width;
		ScreenHeight = Screen.height;
		_zoomTo = Camera.main.orthographicSize;
		Instance = this;
		base.transform.position = new Vector3(14.61604f, -1.118728f, base.transform.position.z);
	}

	private void Update()
	{
		Vector3 zero = Vector3.zero;
		if (InputEscRef.action.triggered)
		{
			if (_stopMovement)
			{
				GameController.Instance.InGameMenuController.Close_OnClick();
			}
			else
			{
				GameController.Instance.InGameMenuController.OpenPanel_Settings();
			}
		}
		if (!Sign.PreventEvent)
		{
			Vector2 vector = InputRef.action.ReadValue<Vector2>();
			if (vector != Vector2.zero && !_stopMovement)
			{
				Vector3 vector2 = Camera.main.ScreenToViewportPoint(vector) * new Vector2(4f, 2f);
				Vector3 vector3 = new Vector3(vector2.x * Camera.main.orthographicSize, vector2.y * Camera.main.orthographicSize, 0f);
				if (InputShiftRef.action.inProgress)
				{
					vector3 *= 3f;
				}
				zero += vector3 * 3f;
			}
			if (InputZoomInRef.action.IsPressed())
			{
				if (_zoomTo > _minZoom)
				{
					if (InputShiftRef.action.inProgress)
					{
						_zoomTo -= _zoomSpeed / 3f;
					}
					else
					{
						_zoomTo -= _zoomSpeed / 6f;
					}
				}
			}
			else if (InputZoomOutRef.action.IsPressed() && _zoomTo < _maxZoom)
			{
				if (InputShiftRef.action.inProgress)
				{
					_zoomTo += _zoomSpeed / 3f;
				}
				else
				{
					_zoomTo += _zoomSpeed / 6f;
				}
			}
		}
		if (IsMouseOverUI())
		{
			_isDragging = false;
			return;
		}
		if ((Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) && !_isDragging)
		{
			_isDragging = true;
			_dragOrigin = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
		{
			_isDragging = false;
		}
		if (_isDragging)
		{
			Vector3 vector4 = Camera.main.ScreenToViewportPoint(_dragOrigin - Input.mousePosition);
			Vector3 vector5 = new Vector3(vector4.x * Camera.main.orthographicSize, vector4.y * Camera.main.orthographicSize, 0f);
			zero += vector5 * 3f;
			_dragOrigin = Input.mousePosition;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			if (_zoomTo > _minZoom)
			{
				_zoomTo -= _zoomSpeed;
			}
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0f && _zoomTo < _maxZoom)
		{
			_zoomTo += _zoomSpeed;
		}
		if (Camera.main.orthographicSize != _zoomTo)
		{
			float num = _zoomTo - Camera.main.orthographicSize;
			Vector3 vector6 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (MathF.Abs(num) < num * 6f * Time.deltaTime)
			{
				Camera.main.orthographicSize = _zoomTo;
			}
			else
			{
				Camera.main.orthographicSize += num * 6f * Time.deltaTime;
			}
			Vector3 vector7 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			zero += vector6 - vector7;
		}
		if (zero != Vector3.zero)
		{
			base.transform.Translate(zero, Space.World);
			GameController.Instance.Hole.SetBackgroundParallax(base.transform.position.x);
		}
	}

	private void LateUpdate()
	{
		float orthographicSize = Camera.main.orthographicSize;
		float num = orthographicSize * Camera.main.aspect;
		float num2 = TopLeft.transform.position.y - orthographicSize;
		float num3 = BottomRight.transform.position.y + orthographicSize;
		float num4 = TopLeft.transform.position.x + num;
		float num5 = BottomRight.transform.position.x - num;
		float y = ((!(num2 < num3)) ? Mathf.Clamp(base.transform.position.y, num3, num2) : ((num2 + num3) / 2f));
		float x = ((!(num5 < num4)) ? Mathf.Clamp(base.transform.position.x, num4, num5) : ((num4 + num5) / 2f));
		base.transform.position = new Vector3(x, y, base.transform.position.z);
	}

	public void SetPosition(Vector3 p)
	{
		p.x = (float)Math.Round(p.x, 2);
		p.y = (float)Math.Round(p.y, 2);
		base.transform.position = new Vector3(p.x, p.y, base.transform.position.z);
	}

	public void PrestigeShake()
	{
		if (_shakeTween == null || !_shakeTween.IsActive() || !_shakeTween.IsPlaying())
		{
			_shakeTween = base.transform.DOShakePosition(2f);
		}
	}

	public void QuickZoom()
	{
		Sequence sequence = DOTween.Sequence();
		float orthographicSize = Camera.main.orthographicSize;
		sequence.Append(Camera.main.DOOrthoSize(orthographicSize * 0.95f, 0.1f).SetEase(Ease.InOutQuad));
		sequence.Append(Camera.main.DOOrthoSize(orthographicSize, 0.1f).SetEase(Ease.InOutQuad));
		sequence.SetLoops(1);
	}

	private bool IsMouseOverUI()
	{
		if (EventSystem.current != null)
		{
			return EventSystem.current.IsPointerOverGameObject();
		}
		return false;
	}

	public void StopMovement()
	{
		_stopMovement = true;
	}

	public void StartMovement()
	{
		_stopMovement = false;
	}
}
