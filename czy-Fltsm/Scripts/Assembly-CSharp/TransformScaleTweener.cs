using System;
using UnityEngine;

[Serializable]
public struct TransformScaleTweener : ITweenPropertyTweener, IPropertyTweener
{
	[SerializeField]
	private Transform _transform;

	[SerializeField]
	private Vector3 _from;

	[SerializeField]
	private Vector3 _to;

	private Vector3 _fromScale;

	private Vector3 _toScale;

	public TransformScaleTweener(Transform transform, float targetScale, bool is2D = false)
	{
		_transform = transform;
		_fromScale = (_from = transform.localScale);
		_toScale = (_to = (is2D ? new Vector3(targetScale, targetScale, _fromScale.z) : new Vector3(targetScale, targetScale, targetScale)));
	}

	public void Initialize(bool invert = false)
	{
		_fromScale = _transform.localScale;
		if (invert)
		{
			_toScale = _from;
		}
		else
		{
			_toScale = _to;
		}
	}

	public void UpdateProgress(float progress)
	{
		_transform.localScale = Vector3.Lerp(_fromScale, _toScale, progress);
	}
}
