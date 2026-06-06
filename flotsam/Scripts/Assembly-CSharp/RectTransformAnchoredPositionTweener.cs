using System;
using UnityEngine;

public class RectTransformAnchoredPositionTweener : IPropertyTweener
{
	private RectTransform _rectTransform;

	private Vector3 _from;

	private Vector3 _to;

	public RectTransformAnchoredPositionTweener(RectTransform rectTransform, Vector3 to)
	{
		Initialize(rectTransform, to);
	}

	public RectTransformAnchoredPositionTweener(Transform transform, Vector3 to)
		: this(transform as RectTransform, to)
	{
		if (_rectTransform == null)
		{
			throw new NotSupportedException("RectTransformAnchoredPositionTweener only supports RectTransforms!");
		}
	}

	public void Initialize(RectTransform rectTransform, Vector3 to)
	{
		_rectTransform = rectTransform;
		_from = rectTransform.anchoredPosition;
		_to = to;
	}

	public void UpdateProgress(float progress)
	{
		_rectTransform.anchoredPosition = Vector3.LerpUnclamped(_from, _to, progress);
	}
}
