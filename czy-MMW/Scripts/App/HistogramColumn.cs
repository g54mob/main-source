using Easing;
using Motorways.Themes;
using UnityEngine;

public class HistogramColumn : MonoBehaviour
{
	public RectTransform RectTransform;

	public RectTransform SubRectTransform;

	[SerializeField]
	private ThemeTypeToggler _toggler;

	private float _startRange;

	private float _endRange;

	private float _numberOfEntries;

	private float _targetHeight;

	private float _tweenTimer;

	private float _tweenDuration;

	private Easings.Functions _tweenFunction;

	public float NumberOfEntries => _numberOfEntries;

	public float StartRange => _startRange;

	public float EndRange => _endRange;

	public void Initialise(float startRange, float endRange, float numberOfEntries, bool evenColumn)
	{
		_startRange = startRange;
		_endRange = endRange;
		_numberOfEntries = numberOfEntries;
		_toggler.SetSelectedTheme(evenColumn);
	}

	public void SetHeight(float height, float duration, float delay, Easings.Functions easingFunction)
	{
		SubRectTransform.sizeDelta = new Vector2(0f, 0f);
		_targetHeight = height;
		_tweenTimer = 0f - delay;
		_tweenDuration = duration;
		_tweenFunction = easingFunction;
	}

	public void Update()
	{
		if (_tweenDuration > 0f)
		{
			_tweenTimer += Time.deltaTime;
			float y = _targetHeight;
			if (!(_tweenTimer >= _tweenDuration))
			{
				y = ((!(_tweenTimer <= 0f)) ? (_targetHeight * Easings.Interpolate(_tweenTimer / _tweenDuration, _tweenFunction)) : 0f);
			}
			else
			{
				_tweenDuration = 0f;
			}
			SubRectTransform.sizeDelta = new Vector2(0f, y);
		}
	}
}
