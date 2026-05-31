using System;
using UnityEngine;

[RequireComponent(typeof(VisionDetection))]
public class VisionConeGizmos : MonoBehaviour
{
	public int resolution = 20;

	private void OnDrawGizmos()
	{
		VisionDetection component = GetComponent<VisionDetection>();
		float visionAngle = component.VisionAngle;
		float visionDistance = component.VisionDistance;
		Gizmos.color = Color.green;
		for (int i = 0; i <= resolution; i++)
		{
			float f = (0f - visionAngle + (float)i * (2f * visionAngle) / (float)resolution) * (MathF.PI / 180f);
			Vector3 vector = new Vector3(Mathf.Sin(f), 0f, Mathf.Cos(f)) * visionDistance;
			Gizmos.DrawSphere(base.transform.position + base.transform.rotation * vector, 0.1f);
		}
		for (int j = -1; j <= 1; j += 2)
		{
			float f2 = (float)j * visionAngle * (MathF.PI / 180f);
			Vector3 vector2 = new Vector3(Mathf.Sin(f2), 0f, Mathf.Cos(f2));
			for (int k = 1; k <= resolution; k++)
			{
				float num = (float)k / (float)resolution;
				Gizmos.DrawSphere(base.transform.position + base.transform.rotation * (vector2 * (visionDistance * num)), 0.1f);
			}
		}
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * visionDistance);
	}
}
