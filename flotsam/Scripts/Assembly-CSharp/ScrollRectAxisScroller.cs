using Rewired;
using RewiredConsts;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectAxisScroller : MonoBehaviour
{
	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	[ActionIdProperty(typeof(Action))]
	private int _horizontalAction = -1;

	[SerializeField]
	[ActionIdProperty(typeof(Action))]
	private int _verticalAction = -1;

	[SerializeField]
	[Tooltip("the scroll speed in pixels per second")]
	private float _scrollSpeed = 512f;

	[SerializeField]
	private InputFlags _activeInputs = InputFlags.Joystick;

	private int _horizontalNumberOfSteps;

	private int _verticalNumberOfSteps;

	private void OnEnable()
	{
		if ((bool)_scrollRect.horizontalScrollbar)
		{
			_horizontalNumberOfSteps = _scrollRect.horizontalScrollbar.numberOfSteps;
		}
		if ((bool)_scrollRect.verticalScrollbar)
		{
			_verticalNumberOfSteps = _scrollRect.verticalScrollbar.numberOfSteps;
		}
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputChanged);
		OnActiveInputChanged();
	}

	private void Update()
	{
		if ((bool)_scrollRect.horizontalScrollbar)
		{
			float num = ReturnScrollDistance(_scrollRect.content.rect.width, _scrollRect.viewport.rect.width);
			_scrollRect.horizontalScrollbar.value = Mathf.Clamp01(_scrollRect.horizontalScrollbar.value + num * FlotsamInputManager.GetAxis(_horizontalAction));
		}
		if ((bool)_scrollRect.verticalScrollbar)
		{
			float num = ReturnScrollDistance(_scrollRect.content.rect.height, _scrollRect.viewport.rect.height);
			_scrollRect.verticalScrollbar.value = Mathf.Clamp01(_scrollRect.verticalScrollbar.value + num * FlotsamInputManager.GetAxis(_verticalAction));
		}
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputChanged);
		RestoreNumberOfSteps();
	}

	public void ScrollHorizontal(float value)
	{
		if ((bool)_scrollRect.horizontalScrollbar)
		{
			float num = ReturnNormalizedScrollDistance(value, _scrollRect.content.rect.width, _scrollRect.viewport.rect.width);
			_scrollRect.horizontalScrollbar.value = Mathf.Clamp01(_scrollRect.horizontalScrollbar.value + num);
		}
	}

	public void ScrollVertical(float value)
	{
		if ((bool)_scrollRect.verticalScrollbar)
		{
			float num = ReturnNormalizedScrollDistance(value, _scrollRect.content.rect.height, _scrollRect.viewport.rect.height);
			_scrollRect.verticalScrollbar.value = Mathf.Clamp01(_scrollRect.verticalScrollbar.value + num);
		}
	}

	private void OnActiveInputChanged(GameEvent gameEvent = null)
	{
		if (FlotsamInputManager.HasActiveInput(_activeInputs))
		{
			if ((bool)_scrollRect.horizontalScrollbar)
			{
				_scrollRect.horizontalScrollbar.numberOfSteps = 0;
			}
			if ((bool)_scrollRect.verticalScrollbar)
			{
				_scrollRect.verticalScrollbar.numberOfSteps = 0;
			}
		}
		else
		{
			RestoreNumberOfSteps();
		}
	}

	private void RestoreNumberOfSteps()
	{
		if ((bool)_scrollRect.horizontalScrollbar)
		{
			_scrollRect.horizontalScrollbar.numberOfSteps = _horizontalNumberOfSteps;
		}
		if ((bool)_scrollRect.verticalScrollbar)
		{
			_scrollRect.verticalScrollbar.numberOfSteps = _verticalNumberOfSteps;
		}
	}

	private float ReturnScrollDistance(float content, float viewport)
	{
		if (content <= viewport)
		{
			return 0f;
		}
		return _scrollSpeed / (content - viewport) * Time.unscaledDeltaTime;
	}

	private float ReturnNormalizedScrollDistance(float distance, float content, float viewport)
	{
		if (content <= viewport)
		{
			return 0f;
		}
		return distance / (content - viewport);
	}
}
