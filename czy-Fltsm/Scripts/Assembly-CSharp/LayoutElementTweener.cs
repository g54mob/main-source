using System;
using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct LayoutElementTweener : ITweenPropertyTweener, IPropertyTweener
{
	public enum Properties
	{
		None = 0,
		MinWidth = 1,
		MinHeight = 2,
		PreferrredWidth = 4,
		PreferrredHeight = 8,
		MinWidthAndMinHeight = int.MinValue
	}

	private struct Values
	{
		public float From;

		public float To;

		public float Evaluate(float progress)
		{
			return Mathf.Lerp(From, To, progress);
		}
	}

	[SerializeField]
	private LayoutElement _layoutElement;

	[SerializeField]
	private Properties _propertiesToTween;

	[SerializeField]
	private RangedFloat _minWidthRange;

	[SerializeField]
	private RangedFloat _minHeightRange;

	private bool _invert;

	private RangedFloat _minWidth;

	private RangedFloat _minHeight;

	private Values _preferredWidth;

	private Values _preferredHeight;

	public void Initialize(bool invert = false)
	{
		_invert = invert;
		if (_invert)
		{
			_minWidth.Minimum = _minWidthRange.Minimum;
			_minWidth.Maximum = _layoutElement.minWidth;
			_minHeight.Minimum = _minHeightRange.Minimum;
			_minHeight.Maximum = _layoutElement.minHeight;
		}
		else
		{
			_minWidth.Minimum = _layoutElement.minWidth;
			_minWidth.Maximum = _minWidthRange.Maximum;
			_minHeight.Minimum = _layoutElement.minHeight;
			_minHeight.Maximum = _minHeightRange.Maximum;
		}
		_propertiesToTween |= Properties.MinWidthAndMinHeight;
	}

	public void InitializeProperty(Properties property, float to)
	{
		switch (property)
		{
		case Properties.PreferrredWidth:
			_preferredWidth.From = _layoutElement.preferredWidth;
			_preferredWidth.To = to;
			_propertiesToTween |= property;
			break;
		case Properties.PreferrredHeight:
			_preferredHeight.From = _layoutElement.preferredHeight;
			_preferredHeight.To = to;
			_propertiesToTween |= property;
			break;
		default:
			Debug.LogException(new NotImplementedException());
			break;
		}
	}

	public void UpdateProgress(float progress)
	{
		if (_invert)
		{
			progress = 1f - progress;
		}
		if (_propertiesToTween.HasFlag(Properties.PreferrredWidth))
		{
			_layoutElement.preferredWidth = _preferredWidth.Evaluate(progress);
		}
		if (_propertiesToTween.HasFlag(Properties.PreferrredHeight))
		{
			_layoutElement.preferredHeight = _preferredHeight.Evaluate(progress);
		}
		if (_propertiesToTween.HasFlag(Properties.MinWidthAndMinHeight))
		{
			_layoutElement.minWidth = _minWidth.Evaluate(progress);
			_layoutElement.minHeight = _minHeight.Evaluate(progress);
		}
	}

	public void SetTarget(LayoutElement layoutElement)
	{
		_layoutElement = layoutElement;
	}
}
