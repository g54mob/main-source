using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimeDevTool : Slider
{
	private TimeManager _timeManager;

	private bool _isDragging;

	protected override void OnEnable()
	{
		base.OnEnable();
		_timeManager = GameManager.TimeManager;
		base.onValueChanged.AddListener(OnValueChanged);
	}

	private void LateUpdate()
	{
		if (!_isDragging && !(_timeManager == null))
		{
			SetValueWithoutNotify(_timeManager.CurrentDay.NormalizedDayProgress);
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		base.onValueChanged.RemoveListener(OnValueChanged);
	}

	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);
		_isDragging = true;
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		_isDragging = false;
	}

	private void OnValueChanged(float value)
	{
		if ((bool)_timeManager)
		{
			_timeManager.CurrentDay.SetPercentualTime(value);
		}
	}
}
