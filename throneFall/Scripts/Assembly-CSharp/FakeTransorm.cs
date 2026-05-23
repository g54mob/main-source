using System;
using UnityEngine;

[Serializable]
public class FakeTransorm
{
	private Vector3 localPosition;

	private Vector3 localScale;

	private Quaternion localRotation;

	public FakeTransorm(Transform _transform)
	{
		SetToTransormValues(_transform);
	}

	public void SetToTransormValues(Transform _transform)
	{
		localPosition = _transform.localPosition;
		localScale = _transform.localScale;
		localRotation = _transform.localRotation;
	}

	public bool IsEqualTo(Transform _transform)
	{
		if (localPosition != _transform.localPosition)
		{
			return false;
		}
		if (localScale != _transform.localScale)
		{
			return false;
		}
		if (localRotation != _transform.localRotation)
		{
			return false;
		}
		return true;
	}
}
