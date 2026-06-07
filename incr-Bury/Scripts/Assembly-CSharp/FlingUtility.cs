using UnityEngine;

public static class FlingUtility
{
	public static Vector3 CalculateArcVelocity(Vector3 start, Vector3 end, float arcHeight)
	{
		float num = Mathf.Abs(Physics.gravity.y);
		Vector3 vector = end - start;
		Vector3 vector2 = new Vector3(vector.x, 0f, vector.z);
		_ = vector2.magnitude;
		float y = vector.y;
		float num2 = Mathf.Sqrt(2f * arcHeight / num);
		float num3 = num * num2;
		float num4 = Mathf.Sqrt(2f * (arcHeight - y) / num);
		float num5 = num2 + num4;
		return vector2 / num5 + Vector3.up * num3;
	}
}
