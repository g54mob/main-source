using UnityEngine;

public class LevitationParabola : MonoBehaviour
{
	private LineRenderer renderRef;

	private Transform t1;

	private Transform t2;

	private int linePoints = 100;

	private float maxBezierOffset = 0.35f;

	private float currentCycleTimer;

	private float lineSpeedMultiplier = 2f;

	private void Awake()
	{
		renderRef = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		if (t1 != null && t2 != null)
		{
			DrawQuadraticBezierCurve(t1.position, t2.position);
		}
	}

	public void SetTransforms(Transform newT1, Transform newT2)
	{
		t1 = newT1;
		t2 = newT2;
	}

	private void DrawQuadraticBezierCurve(Vector3 point0, Vector3 point2)
	{
		currentCycleTimer += Time.deltaTime * lineSpeedMultiplier;
		float num = Mathf.Cos(currentCycleTimer) * maxBezierOffset;
		float num2 = Vector3.Distance(point0, point2) * num;
		Vector3 vector = Vector3.Cross(point0 - point2, Vector3.forward);
		vector.Normalize();
		Vector3 vector2 = Mathf.Abs(num2) * vector + point0;
		Vector3 normalized = ((0f - Mathf.Abs(num2)) * vector + point0 - vector2).normalized;
		Vector3 vector3 = point2 - point0;
		Vector3 vector4 = point0 + vector3 / 2f + normalized * num2;
		renderRef.positionCount = linePoints;
		float num3 = 0f;
		for (int i = 0; i < renderRef.positionCount; i++)
		{
			Vector3 position = (1f - num3) * (1f - num3) * point0 + 2f * (1f - num3) * num3 * vector4 + num3 * num3 * point2;
			renderRef.SetPosition(i, position);
			num3 += 1f / (float)renderRef.positionCount;
		}
	}
}
