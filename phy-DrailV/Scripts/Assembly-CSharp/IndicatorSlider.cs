using UnityEngine;

public class IndicatorSlider : Indicator
{
	public Transform pointer;

	public Vector3 startPosition = -Vector3.right;

	public Vector3 endPosition = Vector3.right;

	protected override void OnValueSet()
	{
		if ((bool)pointer)
		{
			pointer.localPosition = Vector3.Lerp(startPosition, endPosition, GetNormalizedValue());
		}
	}

	private void OnDrawGizmosSelected()
	{
		if ((bool)pointer)
		{
			Vector3 vector = pointer.parent.TransformPoint(startPosition);
			Vector3 vector2 = pointer.parent.TransformPoint(endPosition);
			float num = Vector3.Distance(startPosition, endPosition) * 0.1f;
			Gizmos.DrawLine(vector, vector2);
			Gizmos.DrawLine(vector + Vector3.up * num, vector + Vector3.up * (0f - num));
			Gizmos.DrawLine(vector2 + Vector3.up * num, vector2 + Vector3.up * (0f - num));
		}
	}
}
