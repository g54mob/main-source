using UnityEngine;

public class IndicatorGauge : Indicator
{
	public Transform needle;

	public float minAngle = -180f;

	public float maxAngle = 180f;

	public bool unclamped;

	public Vector3 rotationAxis = Vector3.forward;

	public float gizmoRadius = 0.1f;

	private const int GIZMO_SEGMENTS = 20;

	private Color startColor = new Color(0f, 0f, 0.65f);

	private Color endColor = new Color(0.65f, 0f, 0f);

	protected override void Start()
	{
		base.Start();
		if (!needle)
		{
			Debug.LogError("IndicatorGauge doesn't have needle set", this);
		}
	}

	protected override void OnValueSet()
	{
		SetNeedleRotation(value);
	}

	protected void SetNeedleRotation(float value)
	{
		float angle = (unclamped ? Mathf.LerpUnclamped(minAngle, maxAngle, NormalizeValue(value, clamped: false)) : Mathf.Lerp(minAngle, maxAngle, NormalizeValue(value)));
		needle.localRotation = Quaternion.AngleAxis(angle, rotationAxis);
	}

	private void OnDrawGizmosSelected()
	{
		if (!needle)
		{
			return;
		}
		float num = gizmoRadius;
		Vector3 start = Vector3.zero;
		for (int i = 0; i <= 20; i++)
		{
			Color color = Color.Lerp(startColor, endColor, (float)i / 20f);
			Vector3 position = Quaternion.AngleAxis(Mathf.Lerp(minAngle, maxAngle, (float)i / 20f), rotationAxis) * Vector3.right * num;
			position = base.transform.TransformPoint(position);
			if (i == 0 || i == 20)
			{
				Debug.DrawLine(needle.position, position, color, 0f, depthTest: false);
			}
			if (i != 0)
			{
				Debug.DrawLine(start, position, color, 0f, depthTest: false);
			}
			start = position;
		}
	}
}
