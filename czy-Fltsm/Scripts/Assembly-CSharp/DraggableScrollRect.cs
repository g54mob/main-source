using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class DraggableScrollRect : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IScrollHandler
{
	[Tooltip("The transform of the viewPort object.")]
	public RectTransform ViewPortRectTransform;

	[Tooltip("The scrollbar of the scroll rect component.")]
	[SerializeField]
	private Scrollbar _scrollBar;

	[Tooltip("Use values between 0 and 1.")]
	[SerializeField]
	private float _paddingPercentage;

	[Tooltip("The delay before we calculate the position of the element, the lower the delay the faster the scroll.")]
	[SerializeField]
	private float _positionCalculationDelay = 0.1f;

	[HideInInspector]
	public bool _outsideBottomSide;

	[HideInInspector]
	public bool _outsideTopSide;

	private bool _initialized;

	private ScrollRect _scrollRect;

	private RectTransform _contentRectTransform;

	private float _padding;

	private float _rectSize;

	private float _startingSize;

	private Vector3 contentPosition = Vector3.zero;

	private bool drag;

	private float currentDelay;

	public UnityEvent OnDraggableChangedPositionEvent;

	[HideInInspector]
	public bool OutsideTopSide => _outsideTopSide;

	[HideInInspector]
	public bool OutsideBottomSide => _outsideBottomSide;

	[HideInInspector]
	public bool Initialized => _initialized;

	private void Start()
	{
		_scrollRect = GetComponent<ScrollRect>();
		_contentRectTransform = _scrollRect.content;
		ViewPortRectTransform = _scrollRect.viewport;
		_rectSize = ViewPortRectTransform.rect.height;
		_startingSize = ViewPortRectTransform.position.y;
		_padding = _rectSize * _paddingPercentage;
		currentDelay = _positionCalculationDelay;
		if (OnDraggableChangedPositionEvent == null)
		{
			OnDraggableChangedPositionEvent = new UnityEvent();
		}
		_initialized = true;
	}

	private void Update()
	{
		_rectSize = ViewPortRectTransform.rect.height;
		_startingSize = ViewPortRectTransform.position.y;
		_padding = _rectSize * _paddingPercentage;
		_scrollBar.numberOfSteps = _contentRectTransform.childCount * 2;
		if (drag)
		{
			CalculateMovement();
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		drag = true;
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		drag = false;
		_outsideBottomSide = false;
		_outsideTopSide = false;
	}

	public void OnScroll(PointerEventData eventData)
	{
		_scrollRect.OnScroll(eventData);
	}

	private void CalculateMovement()
	{
		currentDelay += Time.unscaledDeltaTime;
		float num = _startingSize - _rectSize + 2f * _padding;
		float num2 = _startingSize - _padding;
		Vector3 mousePosition = FlotsamInputManager.MousePosition;
		bool flag = num > mousePosition.y;
		bool flag2 = num2 < mousePosition.y;
		_outsideBottomSide = _startingSize - _rectSize > mousePosition.y;
		_outsideTopSide = _startingSize < mousePosition.y;
		if (currentDelay > _positionCalculationDelay)
		{
			currentDelay = 0f;
			if (flag)
			{
				Move(down: true);
			}
			else if (flag2)
			{
				Move(down: false);
			}
		}
	}

	private void Move(bool down)
	{
		if (down)
		{
			if (Mathf.Approximately(_contentRectTransform.offsetMax.y, _contentRectTransform.sizeDelta.y))
			{
				return;
			}
		}
		else if (Mathf.Approximately(0f - _contentRectTransform.offsetMin.y, _contentRectTransform.sizeDelta.y))
		{
			return;
		}
		float height = _contentRectTransform.rect.height;
		contentPosition = _contentRectTransform.position;
		float num = 0f;
		contentPosition = new Vector3(y: (!down) ? (contentPosition.y - height / (float)_scrollBar.numberOfSteps) : (contentPosition.y + height / (float)_scrollBar.numberOfSteps), x: contentPosition.x, z: contentPosition.z);
		_contentRectTransform.position = contentPosition;
	}
}
