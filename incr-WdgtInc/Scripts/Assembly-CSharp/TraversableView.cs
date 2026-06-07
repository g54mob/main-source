using Assets.Source.UI;
using UnityEngine;

public class TraversableView : MonoBehaviour
{
	public const float MoveSpeed = 10f;

	[SerializeField]
	protected Camera _cam;

	[SerializeField]
	private float _minZoom = 0.1f;

	[SerializeField]
	private float _maxZoom = 1f;

	protected Vector2 _boundsMin;

	protected Vector2 _boundsMax;

	protected int? _scrollButton;

	protected Vector2 _scrollMouse;

	protected float _defaultOrthographicSize;

	public Vector2 MouseWorld => _cam.ScreenToWorldPoint(PlayerControls.MousePosition);

	public float ScrollDistance { get; private set; }

	public float Zoom { get; protected set; } = 1f;

	public Vector2 Position
	{
		get
		{
			return _cam.transform.position;
		}
		set
		{
			_cam.transform.position = new Vector3(Mathf.Clamp(value.x, _boundsMin.x, _boundsMax.x), Mathf.Clamp(value.y, _boundsMin.y, _boundsMax.y), -10f);
		}
	}

	private void Start()
	{
		_defaultOrthographicSize = _cam.orthographicSize;
	}

	protected virtual void Update()
	{
		_checkScroll(2, checkNoHover: false);
		_checkScroll(1, checkNoHover: true);
		if (!OverviewUI.Instance.CopyActive)
		{
			_checkScroll(0, checkNoHover: true);
		}
		if (!_scrollButton.HasValue && PlayerControls.CanWASDMove())
		{
			Vector2 traversalDelta = PlayerControls.TraversalDelta;
			if (traversalDelta != Vector2.zero)
			{
				Position += traversalDelta * (Time.deltaTime * 10f) / Zoom;
			}
		}
		float mouseScroll = PlayerControls.MouseScroll;
		if (mouseScroll != 0f && !UIHelper.IsMouseOverUi)
		{
			float num = Mathf.Clamp(Zoom + ((mouseScroll > 0f) ? 0.1f : (-0.1f)), _minZoom, _maxZoom);
			if (num != Zoom)
			{
				Vector2 mouseWorld = MouseWorld;
				SetZoom(num);
				Vector2 mouseWorld2 = MouseWorld;
				Position -= new Vector2(mouseWorld2.x - mouseWorld.x, mouseWorld2.y - mouseWorld.y);
			}
		}
		if (_scrollButton.HasValue)
		{
			Vector2 mousePosition = PlayerControls.MousePosition;
			float num2 = Camera.main.orthographicSize * 2f;
			float num3 = (float)Screen.height / num2;
			Vector2 vector = new Vector2((mousePosition.x - _scrollMouse.x) / num3, (mousePosition.y - _scrollMouse.y) / num3);
			ScrollDistance += vector.magnitude;
			Position -= vector;
			_scrollMouse = mousePosition;
		}
	}

	public void SetZoom(float newZoom)
	{
		if (newZoom != 0f)
		{
			Zoom = newZoom;
			_cam.orthographicSize = _defaultOrthographicSize / Zoom;
		}
	}

	public void UpdateBounds(Vector2 position)
	{
		_boundsMin.x = Mathf.Min(_boundsMin.x, position.x - 10f);
		_boundsMin.y = Mathf.Min(_boundsMin.y, position.y - 10f);
		_boundsMax.x = Mathf.Max(_boundsMax.x, position.x + 10f);
		_boundsMax.y = Mathf.Max(_boundsMax.y, position.y + 10f);
	}

	protected virtual void _checkScroll(int button, bool checkNoHover)
	{
		if (Input.GetMouseButtonUp(button) && button == (_scrollButton ?? (-1)))
		{
			_scrollButton = null;
			UITooltip.TooltipEnabled = true;
		}
		else if (!_scrollButton.HasValue && Input.GetMouseButtonDown(button) && !UIHelper.IsMouseOverUi && (!checkNoHover || !(UIHelper.GetMouseOverGameObject() != null)) && !_scrollButton.HasValue)
		{
			_scrollButton = button;
			_scrollMouse = PlayerControls.MousePosition;
			ScrollDistance = 0f;
			UITooltip.TooltipEnabled = false;
		}
	}

	private void OnDisable()
	{
		if (_scrollButton.HasValue)
		{
			_scrollButton = null;
			ScrollDistance = 0f;
			UITooltip.TooltipEnabled = true;
		}
	}
}
