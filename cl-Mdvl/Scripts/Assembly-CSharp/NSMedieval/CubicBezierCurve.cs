using UnityEngine;

namespace NSMedieval
{
	internal class CubicBezierCurve
	{
		private Vector3[] controlVerts = new Vector3[4];

		public CubicBezierCurve(Vector3[] cvs)
		{
			for (int i = 0; i < 4; i++)
			{
				controlVerts[i] = cvs[i];
			}
		}

		public Vector3 GetPoint(float t)
		{
			float num = 1f - t;
			float num2 = num * num * num;
			float num3 = 3f * t * num * num;
			float num4 = 3f * t * t * num;
			float num5 = t * t * t;
			return controlVerts[0] * num2 + controlVerts[1] * num3 + controlVerts[2] * num4 + controlVerts[3] * num5;
		}

		public Vector3 GetTangent(float t)
		{
			Vector3 vector = controlVerts[0] + (controlVerts[1] - controlVerts[0]) * t;
			Vector3 vector2 = controlVerts[1] + (controlVerts[2] - controlVerts[1]) * t;
			Vector3 vector3 = controlVerts[2] + (controlVerts[3] - controlVerts[2]) * t;
			Vector3 vector4 = vector + (vector2 - vector) * t;
			return vector2 + (vector3 - vector2) * t - vector4;
		}

		public float GetClosestParam(Vector3 pos, float paramThreshold = 1E-06f)
		{
			return GetClosestParamRec(pos, 0f, 1f, paramThreshold);
		}

		private float GetClosestParamRec(Vector3 pos, float beginT, float endT, float thresholdT)
		{
			float num = (beginT + endT) / 2f;
			if (endT - beginT < thresholdT)
			{
				return num;
			}
			float t = (beginT + num) / 2f;
			float t2 = (num + endT) / 2f;
			Vector3 point = GetPoint(t);
			Vector3 point2 = GetPoint(t2);
			float sqrMagnitude = (point - pos).sqrMagnitude;
			float sqrMagnitude2 = (point2 - pos).sqrMagnitude;
			if (sqrMagnitude < sqrMagnitude2)
			{
				endT = num;
			}
			else
			{
				beginT = num;
			}
			return GetClosestParamRec(pos, beginT, endT, thresholdT);
		}
	}
}
