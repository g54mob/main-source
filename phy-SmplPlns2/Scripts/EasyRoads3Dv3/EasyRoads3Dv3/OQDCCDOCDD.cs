using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OQDCCDOCDD : MonoBehaviour
	{
		public static void OOOQOCDODC(ERCrossings scr, ref float firstSegmentDistance)
		{
			List<Vector3> vecs = new List<Vector3>();
			int num = 0;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0.5f * scr.frontRoadWidth;
			if (scr.tCrossingLeftRight == 0)
			{
				float cornerRadius = scr.prefabScript.sidewalkControlElements[0].cornerRadius;
				float angle = 90f / ((float)(scr.prefabScript.sidewalkControlElements[0].cornerSegments - 1) * 1f);
				float num5 = 0.5f * scr.leftRoadWidth;
				for (int i = 0; i < scr.prefabScript.sidewalkControlElements[0].cornerSegments; i++)
				{
					Vector3 vector = OODOCQDDQD(i, cornerRadius, angle);
					Vector3 item = new Vector3(0f - vector.x - num4, 0f, vector.z - num5 - cornerRadius);
					vecs.Add(item);
				}
				OOQOOQQOQQ(ref vecs, 0f, -1f, -1f, 0f);
			}
			else
			{
				num3 = 0.5f * scr.rightRoadWidth;
				num3 += scr.prefabScript.sidewalkControlElements[1].cornerRadius;
				num = Mathf.RoundToInt(Mathf.Ceil(num3 / scr.resolution));
				num2 = num3 / ((float)num * 1f);
				for (int j = 0; j <= num; j++)
				{
					Vector3 item = new Vector3(0f - num4, 0f, 0f - num3 + (float)j * num2);
					vecs.Add(item);
				}
			}
			scr.startConnectionV3.Add(new List<Vector3>());
			scr.startConnectionV3[0].AddRange(vecs);
			vecs.Clear();
			num4 = 0.5f * scr.frontRoadWidth;
			if (scr.tCrossingLeftRight == 1)
			{
				float cornerRadius = scr.prefabScript.sidewalkControlElements[1].cornerRadius;
				float angle = 90f / ((float)(scr.prefabScript.sidewalkControlElements[1].cornerSegments - 1) * 1f);
				float num5 = 0.5f * scr.rightRoadWidth;
				for (int k = 0; k < scr.prefabScript.sidewalkControlElements[1].cornerSegments; k++)
				{
					Vector3 vector = OODOCQDDQD(k, cornerRadius, angle);
					Vector3 item = new Vector3(vector.x + num4, 0f, vector.z - num5 - cornerRadius);
					vecs.Add(item);
				}
				OOQOOQQOQQ(ref vecs, 0f, -1f, 1f, 0f);
			}
			else
			{
				num3 = 0.5f * scr.leftRoadWidth;
				num3 += scr.prefabScript.sidewalkControlElements[0].cornerRadius;
				num = Mathf.RoundToInt(Mathf.Ceil(num3 / scr.resolution));
				num2 = num3 / ((float)num * 1f);
				for (int l = 0; l <= num; l++)
				{
					Vector3 item = new Vector3(num4, 0f, 0f - num3 + (float)l * num2);
					vecs.Add(item);
				}
			}
			scr.startConnectionV3.Add(new List<Vector3>());
			scr.startConnectionV3[1].AddRange(vecs);
			vecs.Clear();
			num4 = 0.5f * scr.backRoadWidth;
			if (scr.tCrossingLeftRight == 1)
			{
				float cornerRadius = scr.prefabScript.sidewalkControlElements[3].cornerRadius;
				float angle = 90f / ((float)(scr.prefabScript.sidewalkControlElements[3].cornerSegments - 1) * 1f);
				float num5 = 0.5f * scr.rightRoadWidth;
				for (int m = 0; m < scr.prefabScript.sidewalkControlElements[3].cornerSegments; m++)
				{
					Vector3 vector = OODOCQDDQD(m, cornerRadius, 0f - angle);
					Vector3 item = new Vector3(vector.x + num4, 0f, vector.z + num5 + cornerRadius);
					vecs.Add(item);
				}
				OOQOOQQOQQ(ref vecs, 0f, 1f, 1f, 0f);
			}
			else
			{
				num3 = 0.5f * scr.leftRoadWidth;
				num3 += scr.prefabScript.sidewalkControlElements[2].cornerRadius;
				num = Mathf.RoundToInt(Mathf.Ceil(num3 / scr.resolution));
				num2 = num3 / ((float)num * 1f);
				for (int n = 0; n <= num; n++)
				{
					Vector3 item = new Vector3(num4, 0f, num3 - (float)n * num2);
					vecs.Add(item);
				}
			}
			scr.endConnectionV3.Add(new List<Vector3>());
			scr.endConnectionV3[0].AddRange(vecs);
			vecs.Clear();
			num4 = 0.5f * scr.backRoadWidth;
			if (scr.tCrossingLeftRight == 0)
			{
				float cornerRadius = scr.prefabScript.sidewalkControlElements[2].cornerRadius;
				float angle = 90f / ((float)(scr.prefabScript.sidewalkControlElements[2].cornerSegments - 1) * 1f);
				float num5 = 0.5f * scr.leftRoadWidth;
				for (int num6 = 0; num6 < scr.prefabScript.sidewalkControlElements[2].cornerSegments; num6++)
				{
					Vector3 vector = OODOCQDDQD(num6, cornerRadius, 0f - angle);
					Vector3 item = new Vector3(0f - vector.x - num4, 0f, vector.z + num5 + cornerRadius);
					vecs.Add(item);
				}
				OOQOOQQOQQ(ref vecs, 0f, 1f, -1f, 0f);
			}
			else
			{
				num3 = 0.5f * scr.rightRoadWidth;
				num3 += scr.prefabScript.sidewalkControlElements[3].cornerRadius;
				num = Mathf.RoundToInt(Mathf.Ceil(num3 / scr.resolution));
				num2 = num3 / ((float)num * 1f);
				for (int num7 = 0; num7 <= num; num7++)
				{
					Vector3 item = new Vector3(0f - num4, 0f, num3 - (float)num7 * num2);
					vecs.Add(item);
				}
			}
			scr.endConnectionV3.Add(new List<Vector3>());
			scr.endConnectionV3[1].AddRange(vecs);
			vecs.Clear();
			if (scr.tCrossingLeftRight == 0)
			{
				int num8 = Mathf.RoundToInt(Mathf.Ceil((float)scr.endConnectionV3[1].Count * 0.5f));
				vecs.Clear();
				vecs.AddRange(scr.endConnectionV3[1]);
				vecs.RemoveRange(0, num8 - 1);
				scr.leftConnectionV3.Add(new List<Vector3>());
				vecs.Reverse();
				scr.leftConnectionV3[0].AddRange(vecs);
				scr.endConnectionV3[1].RemoveRange(num8, scr.endConnectionV3[1].Count - num8);
				num8 = Mathf.RoundToInt(Mathf.Ceil((float)scr.startConnectionV3[0].Count * 0.5f));
				vecs.Clear();
				vecs.AddRange(scr.startConnectionV3[0]);
				vecs.RemoveRange(0, num8 - 1);
				scr.leftConnectionV3.Add(new List<Vector3>());
				vecs.Reverse();
				scr.leftConnectionV3[1].AddRange(vecs);
				scr.startConnectionV3[0].RemoveRange(num8, scr.startConnectionV3[0].Count - num8);
			}
			if (scr.tCrossingLeftRight == 1)
			{
				int num9 = Mathf.RoundToInt(Mathf.Ceil((float)scr.startConnectionV3[1].Count * 0.5f));
				vecs.Clear();
				vecs.AddRange(scr.startConnectionV3[1]);
				vecs.RemoveRange(0, num9 - 1);
				scr.rightConnectionV3.Add(new List<Vector3>());
				vecs.Reverse();
				scr.rightConnectionV3[0].AddRange(vecs);
				scr.startConnectionV3[1].RemoveRange(num9, scr.startConnectionV3[1].Count - num9);
				num9 = Mathf.RoundToInt(Mathf.Ceil((float)scr.endConnectionV3[0].Count * 0.5f));
				vecs.Clear();
				vecs.AddRange(scr.endConnectionV3[0]);
				vecs.RemoveRange(0, num9 - 1);
				scr.rightConnectionV3.Add(new List<Vector3>());
				vecs.Reverse();
				scr.rightConnectionV3[1].AddRange(vecs);
				scr.endConnectionV3[0].RemoveRange(num9, scr.endConnectionV3[0].Count - num9);
			}
		}

		public static void OOQOOQQOQQ(ref List<Vector3> vecs, float firstX, float firstZ, float lastX, float lastZ)
		{
			float num = Vector3.Distance(vecs[0], vecs[1]);
			vecs.Insert(0, vecs[0] + new Vector3(firstX, 0f, firstZ).normalized * num);
			vecs.Add(vecs[vecs.Count - 1] + new Vector3(lastX, 0f, lastZ).normalized * num);
		}

		public static Vector3 OODOCQDDQD(int i, float radius, float angle)
		{
			return ERRoundabouts.OOQOCODQOO(Vector3.zero, new Vector3(radius, 0f, 0f), Quaternion.Euler(0f, angle * (float)i, 0f));
		}

		public static void OQODQOCOOQ(ERCrossings scr)
		{
			if (scr.tCrossingLeftRight == 0)
			{
				float num = scr.prefabScript.sidewalkControlElements[0].cornerRadius + Vector3.Distance(scr.startConnectionV3[0][0], scr.startConnectionV3[0][1]);
				if (scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1 > num)
				{
					ODQQCQQCQQ(scr.startConnectionV3[0], 0f, -1f, scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1, 1f, num);
					ODQQCQQCQQ(scr.leftConnectionV3[1], -1f, 0f, scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1, 1f, num);
				}
			}
			if (scr.tCrossingLeftRight == 1)
			{
				float num = scr.prefabScript.sidewalkControlElements[1].cornerRadius + Vector3.Distance(scr.startConnectionV3[1][0], scr.startConnectionV3[1][1]);
				if (scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1 > num)
				{
					ODQQCQQCQQ(scr.startConnectionV3[1], 0f, -1f, scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1, 1f, num);
					ODQQCQQCQQ(scr.rightConnectionV3[0], 1f, 0f, scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1, 1f, num);
				}
			}
			if (scr.tCrossingLeftRight == 1)
			{
				float num = scr.prefabScript.sidewalkControlElements[3].cornerRadius + Vector3.Distance(scr.endConnectionV3[0][0], scr.endConnectionV3[0][1]);
				if (scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1 > num)
				{
					ODQQCQQCQQ(scr.endConnectionV3[0], 0f, 1f, scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1, 1f, num);
					ODQQCQQCQQ(scr.rightConnectionV3[1], 1f, 0f, scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1, 1f, num);
				}
			}
			if (scr.tCrossingLeftRight == 0)
			{
				float num = scr.prefabScript.sidewalkControlElements[2].cornerRadius + Vector3.Distance(scr.endConnectionV3[1][0], scr.endConnectionV3[1][1]);
				if (scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1 > num)
				{
					ODQQCQQCQQ(scr.endConnectionV3[1], 0f, 1f, scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1, 1f, num);
					ODQQCQQCQQ(scr.leftConnectionV3[0], -1f, 0f, scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1, 1f, num);
				}
			}
		}

		public static void ODQQCQQCQQ(List<Vector3> vecs, float firstX, float firstZ, float sidewalkWidth, float resolution, float currentDist)
		{
			Vector3 normalized = new Vector3(firstX, 0f, firstZ).normalized;
			float num = 0f;
			bool flag = false;
			while (!flag)
			{
				if (currentDist + resolution < sidewalkWidth)
				{
					num = resolution;
				}
				else if (currentDist == sidewalkWidth)
				{
					num = resolution;
					flag = true;
				}
				else if (currentDist + resolution > sidewalkWidth)
				{
					num = sidewalkWidth - currentDist;
				}
				Vector3 vector = vecs[0] + normalized * num;
				if (Vector3.Distance(vector, vecs[0]) < 0.25f * resolution)
				{
					vecs[0] = vector;
				}
				else
				{
					vecs.Insert(0, vector);
				}
				currentDist += num;
			}
		}

		public static void OOQQQOCCOQ(ERCrossings scr)
		{
			if (scr.startConnectionV3[0][0].z != scr.startConnectionV3[1][0].z)
			{
				if (scr.startConnectionV3[0][0].z > scr.startConnectionV3[1][0].z)
				{
					OOQQOOCDQC(scr.startConnectionV3[0], scr.startConnectionV3[1][0].z, 0f, -1f, scr.resolution, 1);
				}
				else
				{
					OOQQOOCDQC(scr.startConnectionV3[1], scr.startConnectionV3[0][0].z, 0f, -1f, scr.resolution, 1);
				}
			}
			if (scr.endConnectionV3[0][0].z != scr.endConnectionV3[1][0].z)
			{
				if (scr.endConnectionV3[0][0].z < scr.endConnectionV3[1][0].z)
				{
					OOQQOOCDQC(scr.endConnectionV3[0], scr.endConnectionV3[1][0].z, 0f, 1f, scr.resolution, 1);
				}
				else
				{
					OOQQOOCDQC(scr.endConnectionV3[1], scr.endConnectionV3[0][0].z, 0f, 1f, scr.resolution, 1);
				}
			}
			if (scr.tCrossingLeftRight == 0 && scr.leftConnectionV3[0][0].x != scr.leftConnectionV3[1][0].x)
			{
				if (scr.leftConnectionV3[0][0].x > scr.leftConnectionV3[1][0].x)
				{
					OOQQOOCDQC(scr.leftConnectionV3[0], scr.leftConnectionV3[1][0].x, -1f, 0f, scr.resolution, 0);
				}
				else
				{
					OOQQOOCDQC(scr.leftConnectionV3[1], scr.leftConnectionV3[0][0].x, -1f, 0f, scr.resolution, 0);
				}
			}
			if (scr.tCrossingLeftRight == 1 && scr.rightConnectionV3[0][0].x != scr.rightConnectionV3[1][0].x)
			{
				if (scr.rightConnectionV3[0][0].x < scr.rightConnectionV3[1][0].x)
				{
					OOQQOOCDQC(scr.rightConnectionV3[0], scr.rightConnectionV3[1][0].x, 1f, 0f, scr.resolution, 0);
				}
				else
				{
					OOQQOOCDQC(scr.rightConnectionV3[1], scr.rightConnectionV3[0][0].x, 1f, 0f, scr.resolution, 0);
				}
			}
		}

		public static void OOQQOOCDQC(List<Vector3> targetVecs, float targetValue, float firstX, float firstZ, float resolution, int xorz)
		{
			bool flag = false;
			while (!flag)
			{
				Vector3 item = targetVecs[0];
				if (xorz == 0)
				{
					item.x += resolution * firstX;
					if (firstX < 0f)
					{
						if (item.x <= targetValue)
						{
							item.x = targetValue;
							flag = true;
						}
					}
					else if (item.x >= targetValue)
					{
						item.x = targetValue;
						flag = true;
					}
				}
				else
				{
					item.z += resolution * firstZ;
					if (firstZ < 0f)
					{
						if (item.z <= targetValue)
						{
							item.z = targetValue;
							flag = true;
						}
					}
					else if (item.z >= targetValue)
					{
						item.z = targetValue;
						flag = true;
					}
				}
				targetVecs.Insert(0, item);
			}
		}

		public static void ODDDCCQQQC(ERCrossings scr)
		{
			float innerSegmentDistance = scr.prefabScript.sidewalkControlElements[0].innerSegmentDistance;
			scr.startConnectionV3.Insert(1, OQDODQQDQC(scr.startConnectionV3[0], 1f, innerSegmentDistance));
			innerSegmentDistance = scr.prefabScript.sidewalkControlElements[1].innerSegmentDistance;
			scr.startConnectionV3.Insert(2, OQDODQQDQC(scr.startConnectionV3[2], -1f, innerSegmentDistance));
			innerSegmentDistance = ((scr.tCrossingLeftRight != 1) ? scr.prefabScript.sidewalkControlElements[1].innerSegmentDistance : scr.prefabScript.sidewalkControlElements[3].innerSegmentDistance);
			scr.endConnectionV3.Insert(1, OQDODQQDQC(scr.endConnectionV3[0], 1f, innerSegmentDistance));
			innerSegmentDistance = ((scr.tCrossingLeftRight != 0) ? scr.prefabScript.sidewalkControlElements[0].innerSegmentDistance : scr.prefabScript.sidewalkControlElements[2].innerSegmentDistance);
			scr.endConnectionV3.Insert(2, OQDODQQDQC(scr.endConnectionV3[2], -1f, innerSegmentDistance));
			if (scr.tCrossingLeftRight == 0)
			{
				innerSegmentDistance = scr.prefabScript.sidewalkControlElements[2].innerSegmentDistance;
				scr.leftConnectionV3.Insert(1, OQDODQQDQC(scr.leftConnectionV3[0], 1f, innerSegmentDistance));
				innerSegmentDistance = scr.prefabScript.sidewalkControlElements[0].innerSegmentDistance;
				scr.leftConnectionV3.Insert(2, OQDODQQDQC(scr.leftConnectionV3[2], -1f, innerSegmentDistance));
			}
			if (scr.tCrossingLeftRight == 1)
			{
				innerSegmentDistance = scr.prefabScript.sidewalkControlElements[1].innerSegmentDistance;
				scr.rightConnectionV3.Insert(1, OQDODQQDQC(scr.rightConnectionV3[0], 1f, innerSegmentDistance));
				innerSegmentDistance = scr.prefabScript.sidewalkControlElements[3].innerSegmentDistance;
				scr.rightConnectionV3.Insert(2, OQDODQQDQC(scr.rightConnectionV3[2], -1f, innerSegmentDistance));
			}
		}

		public static List<Vector3> OQDODQQDQC(List<Vector3> sourceVecs, float leftRight, float distance)
		{
			List<Vector3> list = new List<Vector3>();
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < sourceVecs.Count; i++)
			{
				if (i == 0)
				{
					zero = sourceVecs[i + 1] - sourceVecs[i];
					zero = new Vector3(zero.z, 0f, 0f - zero.x).normalized * leftRight;
				}
				else if (i == sourceVecs.Count - 1)
				{
					zero = (Vector3.zero - sourceVecs[i]).normalized;
				}
				else
				{
					zero = sourceVecs[i + 1] - sourceVecs[i - 1];
					zero = new Vector3(zero.z, 0f, 0f - zero.x).normalized * leftRight;
				}
				list.Add(sourceVecs[i] + zero * distance);
			}
			return list;
		}

		public static void OQCCODQQCC(ERCrossings scr)
		{
			if (scr.startConnectionV3[0].Count > scr.startConnectionV3[3].Count)
			{
				scr.startConnectionV3.Insert(2, ODDQOCQQDQ(scr.startConnectionV3[1], 1));
			}
			else
			{
				scr.startConnectionV3.Insert(2, ODDQOCQQDQ(scr.startConnectionV3[2], 1));
			}
			if (scr.endConnectionV3[0].Count > scr.endConnectionV3[3].Count)
			{
				scr.endConnectionV3.Insert(2, ODDQOCQQDQ(scr.endConnectionV3[1], 1));
			}
			else
			{
				scr.endConnectionV3.Insert(2, ODDQOCQQDQ(scr.endConnectionV3[2], 1));
			}
			if (scr.tCrossingLeftRight == 0)
			{
				if (scr.leftConnectionV3[0].Count > scr.leftConnectionV3[3].Count)
				{
					scr.leftConnectionV3.Insert(2, ODDQOCQQDQ(scr.leftConnectionV3[1], 0));
				}
				else
				{
					scr.leftConnectionV3.Insert(2, ODDQOCQQDQ(scr.leftConnectionV3[2], 0));
				}
			}
			if (scr.tCrossingLeftRight == 1)
			{
				if (scr.rightConnectionV3[0].Count > scr.rightConnectionV3[3].Count)
				{
					scr.rightConnectionV3.Insert(2, ODDQOCQQDQ(scr.rightConnectionV3[1], 0));
				}
				else
				{
					scr.rightConnectionV3.Insert(2, ODDQOCQQDQ(scr.rightConnectionV3[2], 0));
				}
			}
		}

		public static List<Vector3> ODDQOCQQDQ(List<Vector3> sourceVecs, int xorz)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < sourceVecs.Count; i++)
			{
				if (xorz == 0)
				{
					list.Add(new Vector3(sourceVecs[i].x, 0f, 0f));
				}
				else
				{
					list.Add(new Vector3(0f, 0f, sourceVecs[i].z));
				}
			}
			return list;
		}
	}
}
