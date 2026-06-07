using UnityEngine;

namespace UnityFS
{
	[AddComponentMenu("UnityFS/Dynamics/Ground Effect")]
	[RequireComponent(typeof(Wing))]
	public class GroundEffect : AircraftAttachment
	{
		public AnimationCurve CDHeightVsSpan;

		public AnimationCurve CLHeightVsChord;

		public Vector3 RayCastAxis = new Vector3(0f, -1f, 0f);

		public LayerMask RayCastLayers = 1;

		public float Wingspan = 10f;

		public void GetGroundEffectCoefficients(Vector3 PointA, Vector3 PointB, Vector3 PointC, Vector3 PointD, out float clMultiplier, out float cdMultiplier)
		{
			clMultiplier = 1f;
			cdMultiplier = 1f;
			Vector3 vector = PointD + (PointA - PointD) * 0.5f;
			Vector3 vector2 = PointC + (PointB - PointC) * 0.5f;
			Vector3 vector3 = vector + (vector2 - vector) * 0.5f;
			float num = ((PointA - PointD).magnitude + (PointB - PointC).magnitude) * 0.5f;
			float wingspan = Wingspan;
			Vector3 vector4 = base.transform.rotation * RayCastAxis;
			Ray ray = new Ray(vector3, vector4);
			Debug.DrawLine(vector3, vector3 + vector4 * wingspan, Color.white);
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray, out hitInfo, wingspan, RayCastLayers))
			{
				float num2 = Mathf.Clamp(Vector3.Dot(-vector4, hitInfo.normal), 0f, 1f);
				float value = hitInfo.distance / num;
				value = Mathf.Clamp(value, 0f, 1f);
				float value2 = hitInfo.distance / Wingspan;
				value2 = Mathf.Clamp(value2, 0f, 1f);
				float num3 = 1f - (1f - value) * num2;
				float num4 = 1f - (1f - value2) * num2;
				Debug.DrawLine(hitInfo.point, hitInfo.point + hitInfo.normal * num3, Color.green);
				Debug.DrawLine(hitInfo.point, hitInfo.point + hitInfo.normal * num4, Color.red);
				clMultiplier = CLHeightVsChord.Evaluate(num3);
				cdMultiplier = CDHeightVsSpan.Evaluate(num4);
			}
		}

		protected virtual void Start()
		{
			RayCastAxis.Normalize();
		}
	}
}
