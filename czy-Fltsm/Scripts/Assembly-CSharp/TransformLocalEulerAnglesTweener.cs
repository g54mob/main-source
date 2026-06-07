using UnityEngine;

public struct TransformLocalEulerAnglesTweener : IPropertyTweener
{
	public enum Axis
	{
		X = 1,
		Y = 2,
		Z = 4
	}

	private Transform _transform;

	private float _from;

	private float _to;

	private Axis _axis;

	public TransformLocalEulerAnglesTweener(Transform transform, float toRotation, Axis axis)
	{
		_transform = transform;
		switch (axis)
		{
		default:
			_from = transform.localEulerAngles.x;
			break;
		case Axis.Y:
			_from = transform.localEulerAngles.y;
			break;
		case Axis.Z:
			_from = transform.localEulerAngles.z;
			break;
		}
		if (180f < _from)
		{
			_from -= 360f;
		}
		_to = toRotation;
		_axis = axis;
	}

	public void UpdateProgress(float progress)
	{
		float num = Mathf.Lerp(_from, _to, progress);
		Vector3 localEulerAngles = _transform.localEulerAngles;
		switch (_axis)
		{
		case Axis.X:
			localEulerAngles.x = num;
			break;
		case Axis.Y:
			localEulerAngles.y = num;
			break;
		case Axis.Z:
			localEulerAngles.z = num;
			break;
		}
		_transform.localEulerAngles = localEulerAngles;
	}
}
