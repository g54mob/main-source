using System;
using UnityEngine;

[Serializable]
public class TransformPositionTweener : IPropertyTweener
{
	[SerializeField]
	private Transform _transform;

	[SerializeField]
	private Easing _easing;

	[SerializeField]
	private float _duration;

	private Vector3 _from;

	private Vector3 _to;

	public Easing Easing => _easing;

	public float Duration => _duration;

	public void Initialize(Vector3 to)
	{
		_from = _transform.position;
		_to = to;
	}

	public void UpdateProgress(float progress)
	{
		_transform.position = Vector3.Lerp(_from, _to, progress);
	}
}
