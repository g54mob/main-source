using Factory;
using UnityEngine;
using UnityEngine.UI;

public class GameCenterAccessPointButton : MonoBehaviour
{
	private IGameCenterAccessPoint _gameCenterAccessPoint;

	private Camera _camera;

	private RectTransform _rectTransform;

	private RectTransform _parentRectTransform;

	[SerializeField]
	private Canvas _parentCanvas;

	[SerializeField]
	private TouchButton _touchButton;

	protected void Awake()
	{
		_camera = Camera.main;
		_rectTransform = GetComponent<RectTransform>();
		_parentRectTransform = base.transform.parent.GetComponent<RectTransform>();
	}

	public void Initialise(IScope scope)
	{
		_gameCenterAccessPoint = scope.Get<IGameCenterAccessPoint>();
		RefreshButtonState();
	}

	public void Show()
	{
		if (_gameCenterAccessPoint.IsAvailable())
		{
			_gameCenterAccessPoint.Show();
		}
	}

	public void Hide()
	{
		if (_gameCenterAccessPoint.IsAvailable())
		{
			_gameCenterAccessPoint.Hide();
		}
	}

	protected void Update()
	{
		RefreshButtonState();
	}

	private void RefreshButtonState()
	{
		if (_gameCenterAccessPoint.IsAvailable())
		{
			Rect accessPointRect = GetAccessPointRect();
			if (accessPointRect.size == Vector2.zero)
			{
				_touchButton.gameObject.SetActive(value: false);
				return;
			}
			_touchButton.gameObject.SetActive(value: true);
			ResizeButtonTo(accessPointRect);
		}
		else
		{
			_touchButton.gameObject.SetActive(value: false);
		}
	}

	private Rect GetAccessPointRect()
	{
		Rect rect = _gameCenterAccessPoint.GetRect();
		if (rect.size == Vector2.zero)
		{
			return rect;
		}
		return new Rect(rect.x, (float)Screen.height - rect.yMin - rect.height, rect.width, rect.height);
	}

	private void ResizeButtonTo(Rect rect)
	{
		float num = Mathf.Min(rect.width, rect.height);
		Vector2 vector = new Vector2(num, num);
		rect.min = rect.center - vector * 0.5f;
		rect.size = vector;
		Camera cam = _camera;
		if (_parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
		{
			cam = null;
		}
		RectTransformUtility.ScreenPointToWorldPointInRectangle(_parentRectTransform, new Vector2(rect.xMin, rect.yMin), cam, out var worldPoint);
		RectTransformUtility.ScreenPointToWorldPointInRectangle(_parentRectTransform, new Vector2(rect.xMax, rect.yMax), cam, out var worldPoint2);
		Vector2 vector2 = (Vector2)(worldPoint2 - worldPoint) / (Vector2)_rectTransform.lossyScale;
		_rectTransform.position = worldPoint;
		_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, vector2.x);
		_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, vector2.y);
	}

	public void OnAccessPointClick()
	{
		if (Diagnostics.Verify(_gameCenterAccessPoint != null, this, "No valid AccessPoint. Has this object been initialised?"))
		{
			_gameCenterAccessPoint.Select();
		}
	}
}
