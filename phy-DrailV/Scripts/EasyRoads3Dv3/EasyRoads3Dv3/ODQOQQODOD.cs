using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ODQOQQODOD : MonoBehaviour
	{
		public static void OOQCCCODOD(ERCrossings scr, ref float firstSegmentDistance)
		{
			float cornerRadius = scr.prefabScript.sidewalkControlElements[0].cornerRadius;
			float angle = 90f / ((float)(scr.prefabScript.sidewalkControlElements[0].cornerSegments - 1) * 1f);
			float num = 0.5f * scr.frontRoadWidth;
			float num2 = 0.5f * scr.leftRoadWidth;
			List<Vector3> vecs = new List<Vector3>();
			for (int i = 0; i < scr.prefabScript.sidewalkControlElements[0].cornerSegments; i++)
			{
				Vector3 vector = OCODCDOOQO(i, cornerRadius, angle);
				Vector3 item = new Vector3(0f - vector.x - num, 0f, vector.z - num2 - cornerRadius);
				vecs.Add(item);
			}
			OCQDQCQQQO(ref vecs, 0f, -1f, -1f, 0f);
			scr.startConnectionV3.Add(new List<Vector3>());
			scr.startConnectionV3[0].AddRange(vecs);
			cornerRadius = scr.prefabScript.sidewalkControlElements[1].cornerRadius;
			angle = 90f / ((float)(scr.prefabScript.sidewalkControlElements[1].cornerSegments - 1) * 1f);
			num = 0.5f * scr.frontRoadWidth;
			num2 = 0.5f * scr.rightRoadWidth;
			vecs.Clear();
			for (int i = 0; i < scr.prefabScript.sidewalkControlElements[1].cornerSegments; i++)
			{
				Vector3 vector = OCODCDOOQO(i, cornerRadius, angle);
				Vector3 item = new Vector3(vector.x + num, 0f, vector.z - num2 - cornerRadius);
				vecs.Add(item);
			}
			OCQDQCQQQO(ref vecs, 0f, -1f, 1f, 0f);
			scr.startConnectionV3.Add(new List<Vector3>());
			scr.startConnectionV3[1].AddRange(vecs);
			cornerRadius = scr.prefabScript.sidewalkControlElements[3].cornerRadius;
			angle = 90f / ((float)(scr.prefabScript.sidewalkControlElements[3].cornerSegments - 1) * 1f);
			num = 0.5f * scr.backRoadWidth;
			num2 = 0.5f * scr.rightRoadWidth;
			vecs.Clear();
			for (int i = 0; i < scr.prefabScript.sidewalkControlElements[3].cornerSegments; i++)
			{
				Vector3 vector = OCODCDOOQO(i, cornerRadius, 0f - angle);
				Vector3 item = new Vector3(vector.x + num, 0f, vector.z + num2 + cornerRadius);
				vecs.Add(item);
			}
			OCQDQCQQQO(ref vecs, 0f, 1f, 1f, 0f);
			scr.endConnectionV3.Add(new List<Vector3>());
			scr.endConnectionV3[0].AddRange(vecs);
			cornerRadius = scr.prefabScript.sidewalkControlElements[2].cornerRadius;
			angle = 90f / ((float)(scr.prefabScript.sidewalkControlElements[2].cornerSegments - 1) * 1f);
			num = 0.5f * scr.backRoadWidth;
			num2 = 0.5f * scr.leftRoadWidth;
			vecs.Clear();
			for (int i = 0; i < scr.prefabScript.sidewalkControlElements[2].cornerSegments; i++)
			{
				Vector3 vector = OCODCDOOQO(i, cornerRadius, 0f - angle);
				Vector3 item = new Vector3(0f - vector.x - num, 0f, vector.z + num2 + cornerRadius);
				vecs.Add(item);
			}
			OCQDQCQQQO(ref vecs, 0f, 1f, -1f, 0f);
			scr.endConnectionV3.Add(new List<Vector3>());
			scr.endConnectionV3[1].AddRange(vecs);
			int num3 = Mathf.RoundToInt(Mathf.Ceil((float)scr.endConnectionV3[1].Count * 0.5f));
			vecs.Clear();
			vecs.AddRange(scr.endConnectionV3[1]);
			vecs.RemoveRange(0, num3 - 1);
			scr.leftConnectionV3.Add(new List<Vector3>());
			vecs.Reverse();
			scr.leftConnectionV3[0].AddRange(vecs);
			scr.endConnectionV3[1].RemoveRange(num3, scr.endConnectionV3[1].Count - num3);
			num3 = Mathf.RoundToInt(Mathf.Ceil((float)scr.startConnectionV3[0].Count * 0.5f));
			vecs.Clear();
			vecs.AddRange(scr.startConnectionV3[0]);
			vecs.RemoveRange(0, num3 - 1);
			scr.leftConnectionV3.Add(new List<Vector3>());
			vecs.Reverse();
			scr.leftConnectionV3[1].AddRange(vecs);
			scr.startConnectionV3[0].RemoveRange(num3, scr.startConnectionV3[0].Count - num3);
			num3 = Mathf.RoundToInt(Mathf.Ceil((float)scr.startConnectionV3[1].Count * 0.5f));
			vecs.Clear();
			vecs.AddRange(scr.startConnectionV3[1]);
			vecs.RemoveRange(0, num3 - 1);
			scr.rightConnectionV3.Add(new List<Vector3>());
			vecs.Reverse();
			scr.rightConnectionV3[0].AddRange(vecs);
			scr.startConnectionV3[1].RemoveRange(num3, scr.startConnectionV3[1].Count - num3);
			num3 = Mathf.RoundToInt(Mathf.Ceil((float)scr.endConnectionV3[0].Count * 0.5f));
			vecs.Clear();
			vecs.AddRange(scr.endConnectionV3[0]);
			vecs.RemoveRange(0, num3 - 1);
			scr.rightConnectionV3.Add(new List<Vector3>());
			vecs.Reverse();
			scr.rightConnectionV3[1].AddRange(vecs);
			scr.endConnectionV3[0].RemoveRange(num3, scr.endConnectionV3[0].Count - num3);
		}

		public static void OCQDQCQQQO(ref List<Vector3> vecs, float firstX, float firstZ, float lastX, float lastZ)
		{
			float num = Vector3.Distance(vecs[0], vecs[1]);
			vecs.Insert(0, vecs[0] + new Vector3(firstX, 0f, firstZ).normalized * num);
			vecs.Add(vecs[vecs.Count - 1] + new Vector3(lastX, 0f, lastZ).normalized * num);
		}

		public static Vector3 OCODCDOOQO(int i, float radius, float angle)
		{
			return ERRoundabouts.OCQDOQQQOD(Vector3.zero, new Vector3(radius, 0f, 0f), Quaternion.Euler(0f, angle * (float)i, 0f));
		}

		public static void OQDOQOOQDC(ERCrossings scr)
		{
			float num = scr.prefabScript.sidewalkControlElements[0].cornerRadius + Vector3.Distance(scr.startConnectionV3[0][0], scr.startConnectionV3[0][1]);
			if (scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1 > num)
			{
				OCQCDCCDQO(scr.startConnectionV3[0], 0f, -1f, scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1, 1f, num);
				OCQCDCCDQO(scr.leftConnectionV3[1], -1f, 0f, scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1, 1f, num);
			}
			num = scr.prefabScript.sidewalkControlElements[1].cornerRadius + Vector3.Distance(scr.startConnectionV3[1][0], scr.startConnectionV3[1][1]);
			if (scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1 > num)
			{
				OCQCDCCDQO(scr.startConnectionV3[1], 0f, -1f, scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1, 1f, num);
				OCQCDCCDQO(scr.rightConnectionV3[0], 1f, 0f, scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1, 1f, num);
			}
			num = scr.prefabScript.sidewalkControlElements[3].cornerRadius + Vector3.Distance(scr.endConnectionV3[0][0], scr.endConnectionV3[0][1]);
			if (scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1 > num)
			{
				OCQCDCCDQO(scr.endConnectionV3[0], 0f, 1f, scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1, 1f, num);
				OCQCDCCDQO(scr.rightConnectionV3[1], 1f, 0f, scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1, 1f, num);
			}
			num = scr.prefabScript.sidewalkControlElements[2].cornerRadius + Vector3.Distance(scr.endConnectionV3[1][0], scr.endConnectionV3[1][1]);
			if (scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1 > num)
			{
				OCQCDCCDQO(scr.endConnectionV3[1], 0f, 1f, scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1, 1f, num);
				OCQCDCCDQO(scr.leftConnectionV3[0], -1f, 0f, scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1, 1f, num);
			}
		}

		public static void OCQCDCCDQO(List<Vector3> vecs, float firstX, float firstZ, float sidewalkWidth, float resolution, float currentDist)
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

		public static void OODDQDCQQC(ERCrossings scr)
		{
			if (scr.startConnectionV3[0][0].z != scr.startConnectionV3[1][0].z)
			{
				if (scr.startConnectionV3[0][0].z > scr.startConnectionV3[1][0].z)
				{
					OQCQQQDDDD(scr.startConnectionV3[0], scr.startConnectionV3[1][0].z, 0f, -1f, 1f, 1);
				}
				else
				{
					OQCQQQDDDD(scr.startConnectionV3[1], scr.startConnectionV3[0][0].z, 0f, -1f, 1f, 1);
				}
			}
			if (scr.endConnectionV3[0][0].z != scr.endConnectionV3[1][0].z)
			{
				if (scr.endConnectionV3[0][0].z < scr.endConnectionV3[1][0].z)
				{
					OQCQQQDDDD(scr.endConnectionV3[0], scr.endConnectionV3[1][0].z, 0f, 1f, 1f, 1);
				}
				else
				{
					OQCQQQDDDD(scr.endConnectionV3[1], scr.endConnectionV3[0][0].z, 0f, 1f, 1f, 1);
				}
			}
			if (scr.leftConnectionV3[0][0].x != scr.leftConnectionV3[1][0].x)
			{
				if (scr.leftConnectionV3[0][0].x > scr.leftConnectionV3[1][0].x)
				{
					OQCQQQDDDD(scr.leftConnectionV3[0], scr.leftConnectionV3[1][0].x, -1f, 0f, 1f, 0);
				}
				else
				{
					OQCQQQDDDD(scr.leftConnectionV3[1], scr.leftConnectionV3[0][0].x, -1f, 0f, 1f, 0);
				}
			}
			if (scr.rightConnectionV3[0][0].x != scr.rightConnectionV3[1][0].x)
			{
				if (scr.rightConnectionV3[0][0].x < scr.rightConnectionV3[1][0].x)
				{
					OQCQQQDDDD(scr.rightConnectionV3[0], scr.rightConnectionV3[1][0].x, 1f, 0f, 1f, 0);
				}
				else
				{
					OQCQQQDDDD(scr.rightConnectionV3[1], scr.rightConnectionV3[0][0].x, 1f, 0f, 1f, 0);
				}
			}
		}

		public static void OQCQQQDDDD(List<Vector3> targetVecs, float targetValue, float firstX, float firstZ, float resolution, int xorz)
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

		public static void OCDDQOODCC(ERCrossings scr)
		{
			float innerSegmentDistance = scr.prefabScript.sidewalkControlElements[0].innerSegmentDistance;
			scr.startConnectionV3.Insert(1, OCODCDDDCO(scr.startConnectionV3[0], 1f, innerSegmentDistance));
			innerSegmentDistance = scr.prefabScript.sidewalkControlElements[1].innerSegmentDistance;
			scr.startConnectionV3.Insert(2, OCODCDDDCO(scr.startConnectionV3[2], -1f, innerSegmentDistance));
			innerSegmentDistance = scr.prefabScript.sidewalkControlElements[3].innerSegmentDistance;
			scr.endConnectionV3.Insert(1, OCODCDDDCO(scr.endConnectionV3[0], 1f, innerSegmentDistance));
			innerSegmentDistance = scr.prefabScript.sidewalkControlElements[2].innerSegmentDistance;
			scr.endConnectionV3.Insert(2, OCODCDDDCO(scr.endConnectionV3[2], -1f, innerSegmentDistance));
			innerSegmentDistance = scr.prefabScript.sidewalkControlElements[2].innerSegmentDistance;
			scr.leftConnectionV3.Insert(1, OCODCDDDCO(scr.leftConnectionV3[0], 1f, innerSegmentDistance));
			innerSegmentDistance = scr.prefabScript.sidewalkControlElements[0].innerSegmentDistance;
			scr.leftConnectionV3.Insert(2, OCODCDDDCO(scr.leftConnectionV3[2], -1f, innerSegmentDistance));
			innerSegmentDistance = scr.prefabScript.sidewalkControlElements[1].innerSegmentDistance;
			scr.rightConnectionV3.Insert(1, OCODCDDDCO(scr.rightConnectionV3[0], 1f, innerSegmentDistance));
			innerSegmentDistance = scr.prefabScript.sidewalkControlElements[3].innerSegmentDistance;
			scr.rightConnectionV3.Insert(2, OCODCDDDCO(scr.rightConnectionV3[2], -1f, innerSegmentDistance));
		}

		public static List<Vector3> OCODCDDDCO(List<Vector3> sourceVecs, float leftRight, float distance)
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

		public static void OCDQQOQDOC(ERCrossings scr)
		{
			if (scr.startConnectionV3[0].Count > scr.startConnectionV3[3].Count)
			{
				scr.startConnectionV3.Insert(2, OCODQQDDOD(scr.startConnectionV3[1], 1));
			}
			else
			{
				scr.startConnectionV3.Insert(2, OCODQQDDOD(scr.startConnectionV3[2], 1));
			}
			if (scr.endConnectionV3[0].Count > scr.endConnectionV3[3].Count)
			{
				scr.endConnectionV3.Insert(2, OCODQQDDOD(scr.endConnectionV3[1], 1));
			}
			else
			{
				scr.endConnectionV3.Insert(2, OCODQQDDOD(scr.endConnectionV3[2], 1));
			}
			if (scr.leftConnectionV3[0].Count > scr.leftConnectionV3[3].Count)
			{
				scr.leftConnectionV3.Insert(2, OCODQQDDOD(scr.leftConnectionV3[1], 0));
			}
			else
			{
				scr.leftConnectionV3.Insert(2, OCODQQDDOD(scr.leftConnectionV3[2], 0));
			}
			if (scr.rightConnectionV3[0].Count > scr.rightConnectionV3[3].Count)
			{
				scr.rightConnectionV3.Insert(2, OCODQQDDOD(scr.rightConnectionV3[1], 0));
			}
			else
			{
				scr.rightConnectionV3.Insert(2, OCODQQDDOD(scr.rightConnectionV3[2], 0));
			}
		}

		public static List<Vector3> OCODQQDDOD(List<Vector3> sourceVecs, int xorz)
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
