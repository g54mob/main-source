using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OCQDCOOCOO : MonoBehaviour
	{
		public static void OCQCCCCDOQ(ERBend scr, ref List<Vector3> leftOuterSegments, ref List<Vector3> leftInnerSegments, ref List<Vector3> rightOuterSegments, ref List<Vector3> rightInnerSegments)
		{
			float roundAboutRadius = scr.roundAboutRadius;
			Vector3 vector = new Vector3(scr.roadWidth * 0.5f, 0f, 0f);
			Vector3 vector2 = new Vector3(scr.roadWidth * 0.5f - scr.innerSegmentDistance, 0f, 0f);
			Vector3 pivot = vector + Vector3.right * roundAboutRadius;
			float num = scr.bendAngle / ((float)scr.roundingSegments * 1f);
			float num2 = 0f;
			rightOuterSegments.Add(vector);
			rightInnerSegments.Add(vector2);
			for (int i = 0; i <= scr.roundingSegments; i++)
			{
				rightOuterSegments.Add(ERRoundabouts.OOQOCODQOO(vector, pivot, Quaternion.Euler(0f, num2 + (float)i * num, 0f)));
				rightInnerSegments.Add(ERRoundabouts.OOQOCODQOO(vector2, pivot, Quaternion.Euler(0f, num2 + (float)i * num, 0f)));
			}
			vector = new Vector3(scr.roadWidth * -0.5f, 0f, 0f);
			vector2 = new Vector3(scr.roadWidth * -0.5f + scr.innerSegmentDistance, 0f, 0f);
			leftOuterSegments.Add(vector);
			leftInnerSegments.Add(vector2);
			float num3 = roundAboutRadius * 4f;
			vector += Vector3.forward * ((roundAboutRadius + scr.roadWidth - num3) * (scr.bendAngle / 90f));
			leftOuterSegments.Add(vector);
			vector2 += Vector3.forward * ((roundAboutRadius + scr.roadWidth - num3) * (scr.bendAngle / 90f));
			leftInnerSegments.Add(vector2);
			pivot = vector + Vector3.right * num3;
			for (int j = 0; j <= scr.roundingSegments; j++)
			{
				leftOuterSegments.Add(ERRoundabouts.OOQOCODQOO(vector, pivot, Quaternion.Euler(0f, num2 + (float)j * num, 0f)));
				leftInnerSegments.Add(ERRoundabouts.OOQOCODQOO(vector2, pivot, Quaternion.Euler(0f, num2 + (float)j * num, 0f)));
			}
			Vector3 normalized = (rightInnerSegments[rightInnerSegments.Count - 1] - rightOuterSegments[rightOuterSegments.Count - 1]).normalized;
			vector = rightOuterSegments[rightOuterSegments.Count - 1] + normalized * scr.roadWidth;
			leftOuterSegments.Add(vector);
			vector2 = rightOuterSegments[rightOuterSegments.Count - 1] + normalized * (scr.roadWidth - scr.innerSegmentDistance);
			leftInnerSegments.Add(vector2);
		}

		public static List<Vector3> OCDDCDOODD(Vector3 prefabCenterpos, Vector3 cpCenterposV3, Vector3 v1, Vector3 cp, ref float totalDistance, ref List<Vector3> controlPoints)
		{
			Vector3 vector = prefabCenterpos - cpCenterposV3;
			vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
			Vector3 vA = prefabCenterpos + vector * 1000f;
			Vector3 vB = prefabCenterpos + -vector * 1000f;
			vA = OQQOCDQCQD.OCOOQOQCDC(vA, vB, v1);
			vector = (vA - v1).normalized;
			float num = Vector3.Distance(v1, vA);
			vA += vector * num;
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			controlPoints.Add(cp);
			controlPoints.Add(v1);
			controlPoints.Add(prefabCenterpos);
			controlPoints.Add(vA);
			Vector3 vector2;
			Vector3 a = (vector2 = Vector3.zero);
			for (int i = 1; i < controlPoints.Count - 2; i++)
			{
				float num2 = 0.01f;
				for (float num3 = 0f; num3 <= 1f; num3 += num2)
				{
					vector2 = ERModularRoad.OQQCQOQOOD(controlPoints[i - 1], controlPoints[i], controlPoints[i + 1], controlPoints[i + 2], num3, 0.5f);
					if (Vector3.Distance(a, vector2) > 1f)
					{
						if (list.Count > 0)
						{
							totalDistance += Vector3.Distance(a, vector2);
						}
						list.Add(vector2);
						a = vector2;
					}
				}
			}
			totalDistance += Vector3.Distance(a, vector2);
			float num4 = Vector3.Distance(prefabCenterpos, cpCenterposV3);
			return controlPoints;
		}

		public static List<Vector3> OOQCCQQODQ(Vector3 prefabCenterpos, Vector3 cpCenterposV3, Vector3 v1, Vector3 cp, ref float totalDistance, ref List<Vector3> controlPoints, float angle, float multiplyFactor)
		{
			angle *= 0.55f;
			Vector3 normalized = (prefabCenterpos - cpCenterposV3).normalized;
			Vector3 zero = Vector3.zero;
			zero = ((!OQQOCDQCQD.OOCQODQDQD(cpCenterposV3, prefabCenterpos, v1)) ? OQQOCDQCQD.OOQOCODQOO(cpCenterposV3, prefabCenterpos, Quaternion.Euler(0f, 0f - angle, 0f)) : OQQOCDQCQD.OOQOCODQOO(cpCenterposV3, prefabCenterpos, Quaternion.Euler(0f, angle, 0f)));
			normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
			Vector3 vA = prefabCenterpos + normalized * 1000f;
			Vector3 vB = prefabCenterpos + -normalized * 1000f;
			vA = OQQOCDQCQD.OCOOQOQCDC(vA, vB, zero);
			normalized = (vA - zero).normalized;
			float num = Vector3.Distance(zero, vA);
			vA += normalized * num;
			normalized = (v1 - zero).normalized;
			v1 = zero + normalized * Vector3.Distance(zero, prefabCenterpos);
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			Vector3 normalized2 = (v1 - zero).normalized;
			normalized = (zero - prefabCenterpos).normalized;
			float num2 = Vector3.Distance(zero, v1);
			controlPoints.Add(v1);
			controlPoints.Add(zero);
			controlPoints.Add(prefabCenterpos);
			controlPoints.Add(vA);
			Vector3 vector;
			Vector3 a = (vector = Vector3.zero);
			for (int i = 1; i < controlPoints.Count - 2; i++)
			{
				float num3 = 0.01f;
				for (float num4 = 0f; num4 <= 1f; num4 += num3)
				{
					vector = ERModularRoad.OQQCQOQOOD(controlPoints[i - 1], controlPoints[i], controlPoints[i + 1], controlPoints[i + 2], num4, 0.5f);
					if (Vector3.Distance(a, vector) > 1f)
					{
						if (list.Count > 0)
						{
							totalDistance += Vector3.Distance(a, vector);
						}
						list.Add(vector);
						a = vector;
					}
				}
			}
			totalDistance += Vector3.Distance(a, vector);
			return controlPoints;
		}

		public static Vector3[] OQOQDOCOCQ(ERCrossingPrefabs scr, int connection, List<Vector3> controlPoints, float segmentDistance, float defaultDistance, Vector3[] meshVecs, ref Vector3[] tCrossingTmpFullMeshVecs, float multiplyFactor, float angle, float curveStrength)
		{
			Transform transform = scr.transform;
			Vector3[] array = new Vector3[meshVecs.Length];
			Array.Copy(meshVecs, array, meshVecs.Length);
			int tCrossingLeftRight = scr.tCrossingLeftRight;
			Vector3 pTarget = scr.transform.TransformPoint(new Vector3(0f, 0f, 1f));
			Vector3 pSource = scr.transform.TransformPoint(Vector3.zero);
			if (!OQQOCDQCQD.OOCQODQDQD(pTarget, pSource, controlPoints[2]))
			{
				angle *= -1f;
			}
			float num = angle;
			if (num < 0f)
			{
				num *= -1f;
			}
			float num2 = 1000f;
			float num3 = -1000f;
			Vector3 zero = Vector3.zero;
			float num4 = 0f;
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				if ((array[i].z > 0f && connection == 1) || ((array[i].z < 0f && connection == 0) ? true : false))
				{
					Vector3 vector = array[i];
					float z = array[i].z;
					if ((tCrossingLeftRight == 0 && angle > 0f) || (tCrossingLeftRight == 1 && angle < 0f))
					{
						num4 = array[i].z / segmentDistance * Mathf.Lerp(1.15f, 0.5f, num / 90f) * multiplyFactor;
					}
					else
					{
						num4 = array[i].z / segmentDistance * Mathf.Lerp(1f, 2.1f, num / 90f) * multiplyFactor;
						if (i < scr.tCrossingBlendData.Count && scr.tCrossingBlendData[i].blendWeight == 1f && !flag)
						{
							flag = true;
						}
					}
					if (connection == 0)
					{
						num4 *= -1f;
					}
					zero = ERModularRoad.OQQCQOQOOD(controlPoints[0], controlPoints[1], controlPoints[2], controlPoints[3], num4, curveStrength);
					Vector3 vector2 = ERModularRoad.OQQCQOQOOD(controlPoints[0], controlPoints[1], controlPoints[2], controlPoints[3], num4 - 0.001f, curveStrength);
					Vector3 vector3 = ERModularRoad.OQQCQOQOOD(controlPoints[0], controlPoints[1], controlPoints[2], controlPoints[3], num4 + 0.001f, curveStrength);
					Vector3 vector4 = vector3 - vector2;
					vector4 = ((connection != 1) ? new Vector3(0f - vector4.z, 0f, vector4.x).normalized : new Vector3(vector4.z, 0f, 0f - vector4.x).normalized);
					zero += vector4 * array[i].x;
					zero = transform.InverseTransformPoint(zero);
					zero.y = meshVecs[i].y;
					if (scr.tCrossingBlendData.Count > i)
					{
						if (meshVecs[i].x < num2)
						{
							num2 = meshVecs[i].x;
						}
						if (meshVecs[i].x > num3)
						{
							num3 = meshVecs[i].x;
						}
						if (scr.tCrossingBlendData[i].blendWeight > 0f)
						{
							zero.z = Mathf.Lerp(array[i].z, zero.z, scr.tCrossingBlendData[i].blendWeight);
						}
						else if (scr.tCrossingBlendData[i].blendWeight < 0f)
						{
							if ((tCrossingLeftRight == 0 && angle < 0f) || (tCrossingLeftRight == 1 && angle > 0f))
							{
								zero.z = array[i].z;
							}
							else
							{
								zero.z = array[i].z;
								zero.x = Mathf.Lerp(array[i].x, zero.x, 0.5f);
							}
						}
						else
						{
							zero = array[i];
						}
					}
					else if (meshVecs[i].x <= num2 || meshVecs[i].x >= num3)
					{
						zero = array[i];
					}
					tCrossingTmpFullMeshVecs[i] = zero;
				}
				array[i] = tCrossingTmpFullMeshVecs[i];
			}
			return array;
		}

		public static Vector3[] OOOCDQDQDD(ERCrossingPrefabs scr, int connection, List<Vector3> controlPoints, float segmentDistance, float defaultDistance, Vector3[] meshVecs, ref Vector3[] tmpSurfaceVecsTCrossings, float multiplyFactor, float angle, float curveStrength)
		{
			Transform transform = scr.transform;
			Vector3[] array = new Vector3[meshVecs.Length];
			Array.Copy(meshVecs, array, meshVecs.Length);
			int tCrossingLeftRight = scr.tCrossingLeftRight;
			Vector3 pTarget = scr.transform.TransformPoint(new Vector3(0f, 0f, 1f));
			Vector3 pSource = scr.transform.TransformPoint(Vector3.zero);
			if (!OQQOCDQCQD.OOCQODQDQD(pTarget, pSource, controlPoints[2]))
			{
				angle *= -1f;
			}
			float num = 0f;
			for (int i = 0; i < array.Length; i++)
			{
				if ((array[i].z > 0f && connection == 1) || ((array[i].z < 0f && connection == 0) ? true : false))
				{
					float z = array[i].z;
					num = (((tCrossingLeftRight != 0 || !(angle > 0f)) && (tCrossingLeftRight != 1 || !(angle < 0f))) ? (array[i].z / segmentDistance * Mathf.Lerp(1f, 1.9f, angle / 90f) * multiplyFactor) : (array[i].z / segmentDistance * 1f));
					if (connection == 0)
					{
						num *= -1f;
					}
					Vector3 position = ERModularRoad.OQQCQOQOOD(controlPoints[0], controlPoints[1], controlPoints[2], controlPoints[3], num, curveStrength);
					Vector3 vector = ERModularRoad.OQQCQOQOOD(controlPoints[0], controlPoints[1], controlPoints[2], controlPoints[3], num - 0.001f, curveStrength);
					Vector3 vector2 = ERModularRoad.OQQCQOQOOD(controlPoints[0], controlPoints[1], controlPoints[2], controlPoints[3], num + 0.001f, curveStrength);
					Vector3 vector3 = vector2 - vector;
					vector3 = ((connection != 1) ? new Vector3(0f - vector3.z, 0f, vector3.x).normalized : new Vector3(vector3.z, 0f, 0f - vector3.x).normalized);
					position += vector3 * array[i].x;
					position = transform.InverseTransformPoint(position);
					position.y = array[i].y;
					array[i] = (tmpSurfaceVecsTCrossings[i] = position);
				}
				else
				{
					array[i] = tmpSurfaceVecsTCrossings[i];
				}
			}
			return array;
		}

		public static Vector3[] OQDCQDODCO(ERCrossingPrefabs scr, int connection, List<Vector3> controlPoints, float segmentDistance, Vector3[] meshVecs, float multiplyFactor, float angle, Vector3 cpCenterPoint)
		{
			multiplyFactor *= multiplyFactor * multiplyFactor * multiplyFactor;
			Transform transform = scr.transform;
			Vector3 pCheck = transform.InverseTransformPoint(controlPoints[3]);
			cpCenterPoint = transform.InverseTransformPoint(cpCenterPoint);
			if (!OQQOCDQCQD.OOCQODQDQD(new Vector3(0f, 0f, 1f), Vector3.zero, pCheck))
			{
				angle *= -1f;
			}
			Vector3[] array = new Vector3[meshVecs.Length];
			Array.Copy(meshVecs, array, meshVecs.Length);
			float num = scr.tConnectionRoadWidth * 0.5f;
			float num2 = scr.tMainRoadWidth * 0.5f;
			int tCrossingLeftRight = scr.tCrossingLeftRight;
			float topRightSidewalkWidth = scr.topRightSidewalkWidth;
			float topRightSidewalkCurbDepth = scr.topRightSidewalkCurbDepth;
			float num3 = 0f;
			Vector3 tssss = Vector3.zero;
			if (tCrossingLeftRight == 0)
			{
				num3 = array[scr.crossingElements[2].connectionVecInts[0]].x + 0.5f;
				switch (connection)
				{
				case 0:
					tssss = array[scr.crossingElements[connection].connectionVecInts[0]];
					break;
				case 1:
					tssss = array[scr.crossingElements[connection].connectionVecInts[scr.crossingElements[connection].connectionVecInts.Count - 1]];
					break;
				}
			}
			else
			{
				num3 = array[scr.crossingElements[3].connectionVecInts[0]].x - 0.5f;
				switch (connection)
				{
				case 0:
					tssss = array[scr.crossingElements[connection].connectionVecInts[scr.crossingElements[connection].connectionVecInts.Count - 1]];
					break;
				case 1:
					tssss = array[scr.crossingElements[connection].connectionVecInts[0]];
					break;
				}
			}
			Debug.Log(num3 + " " + num);
			Vector3 zero = Vector3.zero;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (!(array[i].z > 0f))
				{
					continue;
				}
				bool flag2 = true;
				if (tCrossingLeftRight == 0)
				{
					if (array[i].x < num3)
					{
						flag2 = false;
					}
					else if (array[i].x < 0f && array[i].z <= num)
					{
						flag2 = false;
					}
				}
				else if (array[i].x > num3)
				{
					flag2 = false;
				}
				else if (array[i].x > 0f && array[i].z <= num)
				{
					flag2 = false;
				}
				if (!flag2)
				{
					continue;
				}
				float x = array[i].x;
				float z = array[i].z;
				Vector3 vector = array[i];
				float num7 = angle;
				float num8 = array[i].z - num;
				float z2 = array[i].z;
				if (angle > 0f)
				{
					if (tCrossingLeftRight == 1)
					{
						if (!(x <= 0f))
						{
						}
					}
					else
					{
						num5 = ussst(tssss, num7);
					}
				}
				else if (tCrossingLeftRight == 1)
				{
					num5 = ussst(tssss, num7);
				}
				num7 = array[i].z / cpCenterPoint.z * num7;
				array[i] = OQQOCDQCQD.OOQOCODQOO(array[i], zero, Quaternion.Euler(0f, num7, 0f));
				if ((angle < 0f && tCrossingLeftRight == 1) || (angle > 0f && tCrossingLeftRight == 0))
				{
					if ((x < 0f && tCrossingLeftRight == 1) || (x > 0f && tCrossingLeftRight == 0))
					{
						num6 = vector.z / cpCenterPoint.z;
						flag = false;
					}
					else
					{
						num6 = (vector.z - num) / (cpCenterPoint.z - num);
						flag = true;
					}
				}
				if ((x < 0f && tCrossingLeftRight == 0) || (x > 0f && tCrossingLeftRight == 1))
				{
					if (!(vector.z >= num + topRightSidewalkWidth - topRightSidewalkCurbDepth) || !(vector.z <= num + topRightSidewalkWidth) || !(vector.x >= num2 + topRightSidewalkWidth - topRightSidewalkCurbDepth) || vector.x <= num2 + topRightSidewalkWidth)
					{
					}
					if (vector.z >= num + topRightSidewalkWidth - topRightSidewalkCurbDepth && vector.z <= num + topRightSidewalkWidth && !(vector.x >= num2 + topRightSidewalkWidth - topRightSidewalkCurbDepth))
					{
					}
				}
			}
			return array;
		}

		private static float ussst(Vector3 tssss, float ussss)
		{
			Vector3 vector = OQQOCDQCQD.OOQOCODQOO(tssss, Vector3.zero, Quaternion.Euler(0f, ussss, 0f));
			return Mathf.Abs(tssss.z - vector.z);
		}

		public static void ODDOQQDQOC(ERCrossings scr, int connection, int x, int y, List<List<Vector3>> vecArray)
		{
			float num = 1f;
			int tCrossingLeftRight = scr.prefabScript.tCrossingLeftRight;
			float num2 = scr.frontRoadWidth * 0.5f;
			float num3 = 0f;
			if (tCrossingLeftRight == 0)
			{
				num3 = scr.leftRoadWidth * 0.5f;
			}
			num3 = scr.rightRoadWidth * 0.5f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			float num10 = 0f;
			float num11 = 0f;
			float num12 = 0f;
			if (connection == 0 && tCrossingLeftRight == 0)
			{
				num4 = scr.prefabScript.sidewalkControlElements[0].cornerRadius;
				num5 = scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1;
				num6 = scr.prefabScript.sidewalkControlElements[0].curbDepth;
			}
			else if (connection == 0 && tCrossingLeftRight == 1)
			{
				num4 = scr.prefabScript.sidewalkControlElements[1].cornerRadius;
				num5 = scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1;
				num6 = scr.prefabScript.sidewalkControlElements[1].curbDepth;
			}
			else if (connection == 1 && tCrossingLeftRight == 0)
			{
				num4 = scr.prefabScript.sidewalkControlElements[2].cornerRadius;
				num5 = scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1;
				num6 = scr.prefabScript.sidewalkControlElements[2].curbDepth;
			}
			else if (connection == 1 && tCrossingLeftRight == 1)
			{
				num4 = scr.prefabScript.sidewalkControlElements[3].cornerRadius;
				num5 = scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1;
				num6 = scr.prefabScript.sidewalkControlElements[3].curbDepth;
			}
			else
			{
				switch (connection)
				{
				case 2:
					num7 = scr.prefabScript.sidewalkControlElements[2].cornerRadius;
					num8 = scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1;
					num9 = scr.prefabScript.sidewalkControlElements[2].curbDepth;
					num10 = scr.prefabScript.sidewalkControlElements[0].cornerRadius;
					num11 = scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1;
					num12 = scr.prefabScript.sidewalkControlElements[0].curbDepth;
					break;
				case 3:
					num7 = scr.prefabScript.sidewalkControlElements[3].cornerRadius;
					num8 = scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1;
					num9 = scr.prefabScript.sidewalkControlElements[3].curbDepth;
					num10 = scr.prefabScript.sidewalkControlElements[1].cornerRadius;
					num11 = scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1;
					num12 = scr.prefabScript.sidewalkControlElements[1].curbDepth;
					break;
				}
			}
			float num13 = num5 - num6;
			float num14 = num8 - num9;
			float num15 = num11 - num12;
			if (num4 < num5)
			{
				num4 = num5;
			}
			if (num7 < num8)
			{
				num7 = num8;
			}
			if (num10 < num11)
			{
				num10 = num11;
			}
			if (connection <= 1)
			{
				num4 = Mathf.Abs(vecArray[0][0].z) - num3;
			}
			else
			{
				num7 = scr.leftSidewalkEndV3[0][0].z;
				num10 = -1f * scr.leftSidewalkStartV3[0][0].z;
			}
			for (int i = 0; i < vecArray.Count; i++)
			{
				for (int j = 0; j < vecArray[i].Count; j++)
				{
					num = 1f;
					float num16 = Mathf.Abs(vecArray[i][j].x);
					float num17 = Mathf.Abs(vecArray[i][j].z);
					if (connection < 2)
					{
						if (((tCrossingLeftRight == 0 && vecArray[i][j].x < 0f) || (tCrossingLeftRight == 1 && vecArray[i][j].x > 0f)) && num16 <= num2 + num4 && num17 <= num3 + num4)
						{
							num = (num17 - num3) / num4;
						}
						if (((tCrossingLeftRight != 0 || !(vecArray[i][j].x < 0f)) && (tCrossingLeftRight != 1 || !(vecArray[i][j].x > 0f))) || !(num16 >= num2 + num13) || !(num16 <= num2 + num5) || !(num17 <= num3 + num5) || num17 >= num3 + num13)
						{
						}
						if (connection >= 2 && vecArray[0][j].z == vecArray[0][0].z)
						{
							num = 0f;
						}
					}
					else
					{
						if (num17 < num3)
						{
							if (i == 1)
							{
								num16 = Mathf.Abs(vecArray[0][j].x);
								num17 = Mathf.Abs(vecArray[0][j].z);
							}
							if (i == 3)
							{
								num16 = Mathf.Abs(vecArray[4][j].x);
								num17 = Mathf.Abs(vecArray[4][j].z);
							}
						}
						if ((tCrossingLeftRight == 0 && vecArray[i][j].x < 0f) || (tCrossingLeftRight == 1 && vecArray[i][j].x > 0f))
						{
							num = ((!(vecArray[i][j].z > 0f)) ? ((num17 - num3) / num10) : ((num17 - num3) / num7));
						}
						if ((vecArray[i][j].z > 0f && tCrossingLeftRight == 1) || (vecArray[i][j].z < 0f && tCrossingLeftRight == 0))
						{
							if (vecArray[4].Count > j && vecArray[4][j].z == vecArray[4][0].z)
							{
								num = 0f;
							}
						}
						else if (vecArray[0].Count > j && vecArray[0][j].z == vecArray[0][0].z)
						{
							num = 0f;
						}
					}
					scr.prefabScript.tCrossingBlendData.Add(new ERBlendVecs(scr.prefabScript.tCrossingBlendData.Count, 0, num, connection, 0));
				}
			}
		}

		public static void OQDDDCOQQD(ERCrossings scr, int connection, List<List<Vector3>> vecArray, int leftright)
		{
			float num = 1f;
			int tCrossingLeftRight = scr.prefabScript.tCrossingLeftRight;
			float num2 = scr.frontRoadWidth * 0.5f;
			float num3 = 0f;
			if (tCrossingLeftRight == 0)
			{
				num3 = scr.leftRoadWidth * 0.5f;
			}
			num3 = scr.rightRoadWidth * 0.5f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			if ((connection == 0 && leftright == 0 && tCrossingLeftRight == 0) || (connection == 2 && leftright == 1 && tCrossingLeftRight == 0) || (connection == 1 && leftright == 0 && tCrossingLeftRight == 1))
			{
				num4 = scr.prefabScript.sidewalkControlElements[0].cornerRadius;
				num5 = scr.prefabScript.sidewalkControlElements[0].sidewalkWidth1;
				num6 = scr.prefabScript.sidewalkControlElements[0].curbDepth;
			}
			else if ((connection == 0 && leftright == 1 && tCrossingLeftRight == 1) || (connection == 3 && leftright == 0 && tCrossingLeftRight == 1) || (connection == 1 && leftright == 0 && tCrossingLeftRight == 0))
			{
				num4 = scr.prefabScript.sidewalkControlElements[1].cornerRadius;
				num5 = scr.prefabScript.sidewalkControlElements[1].sidewalkWidth1;
				num6 = scr.prefabScript.sidewalkControlElements[1].curbDepth;
			}
			else if ((connection == 1 && leftright == 1 && tCrossingLeftRight == 0) || (connection == 2 && leftright == 1 && tCrossingLeftRight == 0))
			{
				num4 = scr.prefabScript.sidewalkControlElements[2].cornerRadius;
				num5 = scr.prefabScript.sidewalkControlElements[2].sidewalkWidth1;
				num6 = scr.prefabScript.sidewalkControlElements[2].curbDepth;
			}
			else if ((connection == 1 && leftright == 0 && tCrossingLeftRight == 1) || (connection == 3 && leftright == 1 && tCrossingLeftRight == 1))
			{
				num4 = scr.prefabScript.sidewalkControlElements[3].cornerRadius;
				num5 = scr.prefabScript.sidewalkControlElements[3].sidewalkWidth1;
				num6 = scr.prefabScript.sidewalkControlElements[3].curbDepth;
			}
			float num7 = num5 - num6;
			if (num4 < num5)
			{
				num4 = num5;
			}
			num4 = ((connection <= 1) ? (Mathf.Abs(vecArray[0][0].z) - num3) : (((connection != 2 || leftright != 0) && (connection != 3 || leftright != 1)) ? (-1f * scr.leftSidewalkStartV3[0][0].z) : scr.leftSidewalkEndV3[0][0].z));
			bool flag = false;
			for (int i = 0; i < vecArray.Count; i++)
			{
				for (int j = 0; j < vecArray[i].Count; j++)
				{
					num = 1f;
					flag = false;
					float num8 = Mathf.Abs(vecArray[i][j].x);
					float num9 = Mathf.Abs(vecArray[i][j].z);
					if (((tCrossingLeftRight == 0 && vecArray[i][j].x < 0f) || (tCrossingLeftRight == 1 && vecArray[i][j].x > 0f)) && num8 <= num2 + num4 && num9 <= num3 + num4)
					{
						num = (num9 - num3) / num4;
					}
					if (((tCrossingLeftRight == 0 && vecArray[i][j].x < 0f) || (tCrossingLeftRight == 1 && vecArray[i][j].x > 0f)) && num8 >= num2 + num7 - 0.2f && num8 <= num2 + num5 + 0.1f && num9 <= num3 + num5 + 0.1f && num9 >= num3 + num7 - 0.2f)
					{
						num = -1f;
						flag = true;
					}
					if (connection >= 2 && vecArray[0][j].z == vecArray[0][0].z)
					{
						num = 0f;
					}
					scr.prefabScript.tCrossingBlendData.Add(new ERBlendVecs(scr.prefabScript.tCrossingBlendData.Count, 0, num, connection, 0));
				}
			}
		}
	}
}
