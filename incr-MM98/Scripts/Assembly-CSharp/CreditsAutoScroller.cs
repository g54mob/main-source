using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class CreditsAutoScroller : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IScrollHandler
{
	private const float ScrollTopValue = 1f;

	private const float ScrollBottomValue = 0f;

	[Tooltip("Pixels per second the content scrolls downward at full speed.")]
	[SerializeField]
	private float scrollSpeed = 30f;

	[Tooltip("Seconds to wait before auto-scrolling begins (or resumes after interaction).")]
	[SerializeField]
	private float idleDelay = 3f;

	[Tooltip("Time in seconds to ease in to full speed.")]
	[SerializeField]
	private float easeDuration = 1.5f;

	private ScrollRect _scrollRect;

	private float _idleTimer;

	private bool _isAutoScrolling;

	private float _currentSpeed;

	private float _speedVelocity;

	private void Awake()
	{
		_scrollRect = GetComponent<ScrollRect>();
		_scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
	}

	private void Start()
	{
		_scrollRect.verticalNormalizedPosition = 1f;
		ResetIdleTimer();
	}

	private void OnDestroy()
	{
		_scrollRect.onValueChanged.RemoveListener(OnScrollValueChanged);
	}

	private void Update()
	{
		if (!_isAutoScrolling)
		{
			_idleTimer -= Time.deltaTime;
			if (_idleTimer <= 0f)
			{
				_isAutoScrolling = true;
			}
		}
		float target = ResolveTargetSpeed();
		_currentSpeed = Mathf.SmoothDamp(_currentSpeed, target, ref _speedVelocity, easeDuration);
		if (!(_currentSpeed <= 0f) && !(_scrollRect.verticalNormalizedPosition <= 0f))
		{
			float height = _scrollRect.content.rect.height;
			float height2 = _scrollRect.viewport.rect.height;
			float num = height - height2;
			if (!(num <= 0f))
			{
				float num2 = _currentSpeed * Time.deltaTime / num;
				_scrollRect.verticalNormalizedPosition = Mathf.Max(0f, _scrollRect.verticalNormalizedPosition - num2);
			}
		}
	}

	private float ResolveTargetSpeed()
	{
		if (!_isAutoScrolling || _scrollRect.verticalNormalizedPosition <= 0f)
		{
			return 0f;
		}
		return scrollSpeed;
	}

	private void OnScrollValueChanged(Vector2 value)
	{
		if (!_isAutoScrolling)
		{
			InterruptAutoScroll();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		InterruptAutoScroll();
	}

	public void OnScroll(PointerEventData eventData)
	{
		InterruptAutoScroll();
	}

	private void InterruptAutoScroll()
	{
		_currentSpeed = 0f;
		_speedVelocity = 0f;
		ResetIdleTimer();
	}

	private void ResetIdleTimer()
	{
		_idleTimer = idleDelay;
		_isAutoScrolling = false;
	}
}
