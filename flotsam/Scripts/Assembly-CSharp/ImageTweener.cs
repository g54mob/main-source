using System;
using UnityEngine;
using UnityEngine.UI;

public struct ImageTweener : IPropertyTweener
{
	[Flags]
	public enum Properties
	{
		None = 0,
		Alpha = 1,
		FillAmount = 2
	}

	private Image _target;

	private Properties _propertiesToTween;

	private Vector2 _alphaFromTo;

	private Vector2 _fillAmountFromTo;

	public void Initialize(Image target)
	{
		_target = target;
	}

	public void InitializeProperty(Properties property, float to)
	{
		if (_target == null)
		{
			Debug.LogException(new NotSupportedException());
			return;
		}
		switch (property)
		{
		case Properties.Alpha:
			_alphaFromTo.x = _target.color.a;
			_alphaFromTo.y = to;
			break;
		case Properties.FillAmount:
			_fillAmountFromTo.x = _target.fillAmount;
			_fillAmountFromTo.y = to;
			break;
		default:
			Debug.LogException(new NotImplementedException());
			return;
		}
		_propertiesToTween |= property;
	}

	public void InitializeProperty(Properties property, float from, float to)
	{
		switch (property)
		{
		case Properties.Alpha:
			_alphaFromTo.x = from;
			_alphaFromTo.y = to;
			break;
		case Properties.FillAmount:
			_fillAmountFromTo.x = from;
			_fillAmountFromTo.y = to;
			break;
		default:
			Debug.LogException(new NotImplementedException());
			return;
		}
		_propertiesToTween |= property;
	}

	public void UpdateProgress(float progress)
	{
		if ((_propertiesToTween & Properties.Alpha) != Properties.None)
		{
			Color color = _target.color;
			color.a = Mathf.Lerp(_alphaFromTo.x, _alphaFromTo.y, progress);
			_target.color = color;
		}
		if ((_propertiesToTween & Properties.FillAmount) != Properties.None)
		{
			_target.fillAmount = Mathf.Lerp(_fillAmountFromTo.x, _fillAmountFromTo.y, progress);
		}
	}
}
