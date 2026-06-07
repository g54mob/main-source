using UnityEngine;

public class BoxVolume : Volume
{
	public BoxCollider box;

	public override bool IsWithin(Vector3 point)
	{
		return PointInOABB(point, box);
	}

	public static bool PointInOABB(Vector3 point, BoxCollider box)
	{
		point = box.transform.InverseTransformPoint(point) - box.center;
		float num = box.size.x * 0.5f;
		float num2 = box.size.y * 0.5f;
		float num3 = box.size.z * 0.5f;
		if (point.x < num && point.x > 0f - num && point.y < num2 && point.y > 0f - num2 && point.z < num3 && point.z > 0f - num3)
		{
			return true;
		}
		return false;
	}
}
