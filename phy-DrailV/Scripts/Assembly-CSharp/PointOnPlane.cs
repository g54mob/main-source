using UnityEngine;

public class PointOnPlane : MonoBehaviour
{
	public float xSize = 1f;

	public float zSize = 1f;

	public float randomLocalYRotationOffsetMin = -100f;

	public float randomLocalYRotationOffsetMax = -80f;

	public (Vector3 position, Quaternion rotation) GetRandomPointWithRotationOnPlane()
	{
		float x = Random.Range((0f - xSize) / 2f, xSize / 2f);
		float z = Random.Range((0f - zSize) / 2f, zSize / 2f);
		Vector3 position = new Vector3(x, 0f, z);
		Vector3 item = base.transform.TransformPoint(position);
		float y = Random.Range(randomLocalYRotationOffsetMin, randomLocalYRotationOffsetMax);
		Quaternion quaternion = Quaternion.Euler(0f, y, 0f);
		Quaternion item2 = base.transform.rotation * quaternion;
		return (position: item, rotation: item2);
	}
}
