using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

public class UITweener : MonoBehaviour
{
	public enum Type
	{
		Entry = 0,
		Exit = 1,
		Expand = 2,
		Collapse = 3
	}

	public delegate void UITweenUpdate();

	[SerializeField]
	[Tooltip("Available tweens for this tweener.")]
	private List<UITween> _tweens = new List<UITween>();

	private UITween _currentTween;

	private Vector2 _startPosition;

	private RectTransform _rectTransform;

	private float _countdown;

	public event UITweenUpdate FinishedTween;

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
		if (_rectTransform == null)
		{
			Debugger.Warning("No rect transform found!", this);
		}
	}

	private void Update()
	{
		if (_currentTween != null)
		{
			PlayTween();
		}
	}

	private void PlayTween()
	{
		float t = _currentTween.Curve.Evaluate((_currentTween.Duration - _countdown) / _currentTween.Duration);
		_countdown -= GameSpeedManager.PausableUnscaledDeltaTime;
		_rectTransform.anchoredPosition = Vector2.Lerp(_startPosition, _currentTween.TargetPosition, t);
		if (_countdown < 0f)
		{
			_countdown = 0f;
			_rectTransform.anchoredPosition = _currentTween.TargetPosition;
			if (this.FinishedTween != null)
			{
				this.FinishedTween();
			}
			_currentTween = null;
		}
	}

	private void InitializeTween(UITween tween)
	{
		_currentTween = tween;
		_startPosition = _rectTransform.anchoredPosition;
		_countdown = tween.Duration;
	}

	public void Play(Type type)
	{
		UITween uITween = _tweens.Find((UITween uitween) => uitween.Type == type);
		if (uITween == null)
		{
			Debugger.Warning("No tween for type " + type.ToString() + " found.", this);
		}
		else
		{
			InitializeTween(uITween);
		}
	}
}
