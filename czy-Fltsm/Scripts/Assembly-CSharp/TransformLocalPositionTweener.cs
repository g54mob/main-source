using UnityEngine;

public struct TransformLocalPositionTweener : IPropertyTweener
{
	private Transform _transform;

	private Vector3 _from;

	private Vector3 _to;

	public TransformLocalPositionTweener(Transform transform, Vector3 to)
	{
		_transform = transform;
		_from = transform.localPosition;
		_to = to;
	}

	public void Initialize(Transform transform, Vector3 to)
	{
		_transform = transform;
		_from = transform.localPosition;
		_to = to;
	}

	public void UpdateProgress(float progress)
	{
		Vector3 localPosition = Vector3.LerpUnclamped(_from, _to, progress);
		_transform.localPosition = localPosition;
	}

	public bool IsNull()
	{
		return _transform == null;
	}
}
