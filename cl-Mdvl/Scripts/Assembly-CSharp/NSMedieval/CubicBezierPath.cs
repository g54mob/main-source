using UnityEngine;

namespace NSMedieval
{
	public class CubicBezierPath
	{
		public enum Type
		{
			Open = 0,
			Closed = 1
		}

		private Type type;

		private int numCurveSegments;

		private int numControlVerts;

		private Vector3[] controlVerts;

		public CubicBezierPath(Vector3[] knots, Type t = Type.Open)
		{
			InterpolatePoints(knots, t);
		}

		public Type GetPathType()
		{
			return type;
		}

		public bool IsClosed()
		{
			if (type != Type.Closed)
			{
				return false;
			}
			return true;
		}

		public bool IsValid()
		{
			if (numCurveSegments <= 0)
			{
				return false;
			}
			return true;
		}

		public void Clear()
		{
			controlVerts = null;
			type = Type.Open;
			numCurveSegments = 0;
			numControlVerts = 0;
		}

		public int GetNumCurveSegments()
		{
			return numCurveSegments;
		}

		public float GetMaxParam()
		{
			return numCurveSegments;
		}

		public int GetNumControlVerts()
		{
			return numControlVerts;
		}

		public Vector3[] GetControlVerts()
		{
			return controlVerts;
		}

		public float ComputeApproxLength()
		{
			if (!IsValid())
			{
				return 0f;
			}
			int num = numCurveSegments + 1;
			if (num < 2)
			{
				return 0f;
			}
			float num2 = 0f;
			for (int i = 1; i < num; i++)
			{
				Vector3 vector = controlVerts[(i - 1) * 3];
				Vector3 vector2 = controlVerts[i * 3];
				num2 += (vector - vector2).magnitude;
			}
			if (num2 == 0f)
			{
				return 0f;
			}
			return num2;
		}

		public float ComputeApproxParamPerUnitLength()
		{
			float num = ComputeApproxLength();
			return (float)numCurveSegments / num;
		}

		public float ComputeApproxNormParamPerUnitLength()
		{
			float num = ComputeApproxLength();
			return 1f / num;
		}

		public void InterpolatePoints(Vector3[] knots, Type t)
		{
			int num = knots.Length;
			Clear();
			type = t;
			switch (type)
			{
			case Type.Open:
			{
				numCurveSegments = num - 1;
				numControlVerts = 3 * num - 2;
				controlVerts = new Vector3[numControlVerts];
				for (int k = 0; k < num; k++)
				{
					controlVerts[k * 3] = knots[k];
				}
				Vector3 vector4 = (knots[1] - knots[0]) * 0.25f;
				controlVerts[1] = knots[0] + vector4;
				Vector3 vector5 = (knots[num - 2] - knots[num - 1]) * 0.25f;
				controlVerts[numControlVerts - 2] = knots[num - 1] + vector5;
				for (int l = 1; l < numCurveSegments; l++)
				{
					Vector3 vector6 = knots[l - 1] - knots[l];
					Vector3 vector7 = knots[l + 1] - knots[l];
					float magnitude3 = vector6.magnitude;
					float magnitude4 = vector7.magnitude;
					if (magnitude3 > 0f && magnitude4 > 0f)
					{
						float num8 = (magnitude3 + magnitude4) / 8f;
						Vector3 vector8 = vector7 / magnitude4 - vector6 / magnitude3;
						vector8.Normalize();
						vector8 *= num8;
						controlVerts[l * 3 - 1] = knots[l] - vector8;
						controlVerts[l * 3 + 1] = knots[l] + vector8;
					}
					else
					{
						controlVerts[l * 3 - 1] = knots[l];
						controlVerts[l * 3 + 1] = knots[l];
					}
				}
				break;
			}
			case Type.Closed:
			{
				numCurveSegments = num;
				numControlVerts = 3 * num + 1;
				controlVerts = new Vector3[numControlVerts];
				for (int i = 0; i < num; i++)
				{
					controlVerts[i * 3] = knots[i];
				}
				controlVerts[numControlVerts - 1] = knots[0];
				for (int j = 1; j <= numCurveSegments; j++)
				{
					int num2 = j - 1;
					int num3 = (j + 1) % numCurveSegments;
					int num4 = j % numCurveSegments;
					Vector3 vector = knots[num2] - knots[num4];
					Vector3 vector2 = knots[num3] - knots[num4];
					float magnitude = vector.magnitude;
					float magnitude2 = vector2.magnitude;
					int num5 = 3 * j - 1;
					int num6 = (3 * j + 1) % (numControlVerts - 1);
					if (magnitude > 0f && magnitude2 > 0f)
					{
						float num7 = (magnitude + magnitude2) / 8f;
						Vector3 vector3 = vector2 / magnitude2 - vector / magnitude;
						vector3.Normalize();
						vector3 *= num7;
						controlVerts[num5] = knots[num4] - vector3;
						controlVerts[num6] = knots[num4] + vector3;
					}
					else
					{
						controlVerts[num5] = knots[num4];
						controlVerts[num6] = knots[num4];
					}
				}
				break;
			}
			}
		}

		public void SetControlVerts(Vector3[] cvs, Type t)
		{
			int num = cvs.Length;
			Clear();
			type = t;
			numControlVerts = num;
			numCurveSegments = (num - 1) / 3;
			controlVerts = cvs;
		}

		public Vector3 GetPoint(float t)
		{
			if (type == Type.Closed)
			{
				while (t < 0f)
				{
					t += (float)numCurveSegments;
				}
				while (t > (float)numCurveSegments)
				{
					t -= (float)numCurveSegments;
				}
			}
			else
			{
				t = Mathf.Clamp(t, 0f, numCurveSegments);
			}
			int num = (int)t;
			if (num >= numCurveSegments)
			{
				num = numCurveSegments - 1;
			}
			return new CubicBezierCurve(new Vector3[4]
			{
				controlVerts[3 * num],
				controlVerts[3 * num + 1],
				controlVerts[3 * num + 2],
				controlVerts[3 * num + 3]
			}).GetPoint(t - (float)num);
		}

		public Vector3 GetPointNorm(float t)
		{
			return GetPoint(t * (float)numCurveSegments);
		}

		public Vector3 GetTangent(float t)
		{
			if (type == Type.Closed)
			{
				while (t < 0f)
				{
					t += (float)numCurveSegments;
				}
				while (t > (float)numCurveSegments)
				{
					t -= (float)numCurveSegments;
				}
			}
			else
			{
				t = Mathf.Clamp(t, 0f, numCurveSegments);
			}
			int num = (int)t;
			if (num >= numCurveSegments)
			{
				num = numCurveSegments - 1;
			}
			return new CubicBezierCurve(new Vector3[4]
			{
				controlVerts[3 * num],
				controlVerts[3 * num + 1],
				controlVerts[3 * num + 2],
				controlVerts[3 * num + 3]
			}).GetTangent(t - (float)num);
		}

		public Vector3 GetTangentNorm(float t)
		{
			return GetTangent(t * (float)numCurveSegments);
		}

		public float ComputeClosestParam(Vector3 pos, float paramThreshold)
		{
			float num = float.MaxValue;
			float result = 0f;
			for (int i = 0; i < controlVerts.Length - 1; i += 3)
			{
				Vector3[] array = new Vector3[4];
				for (int j = 0; j < 4; j++)
				{
					array[j] = controlVerts[i + j];
				}
				CubicBezierCurve cubicBezierCurve = new CubicBezierCurve(array);
				float closestParam = cubicBezierCurve.GetClosestParam(pos, paramThreshold);
				float sqrMagnitude = (cubicBezierCurve.GetPoint(closestParam) - pos).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = (float)i / 3f + closestParam;
				}
			}
			return result;
		}

		public float ComputeClosestNormParam(Vector3 pos, float paramThreshold)
		{
			return ComputeClosestParam(pos, paramThreshold * (float)numCurveSegments);
		}
	}
}
