using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ODQCQOODDO : MonoBehaviour
	{
		public static float ODDCDDDCOQ(ref List<Vector3> splinePoints, ERModularRoad scr, int marker, ref List<Vector3> segPoints, ref List<float> tValues, ref float totalDist, int startMarker, ref float xzDistance, bool getDistance)
		{
			segPoints.Clear();
			int num = 1;
			Vector3 dir = Vector3.zero;
			Vector3 dir2 = Vector3.zero;
			int num2 = 0;
			Vector3 vector = Vector3.zero;
			if (splinePoints.Count > 2)
			{
				vector = splinePoints[splinePoints.Count - 1];
				if ((double)Vector3.Distance(scr.markersExt[startMarker + marker - 1].position, splinePoints[splinePoints.Count - 1]) < 0.5)
				{
					num = 2;
					vector = splinePoints[splinePoints.Count - 2];
					num2 = 1;
				}
			}
			else if (marker > 1)
			{
				vector = scr.splinePoints[scr.markersExt[startMarker + marker - 1].startSplinePoint];
				if ((double)Vector3.Distance(scr.markersExt[startMarker + marker - 1].position, vector) < 0.5)
				{
					num = 2;
					vector = scr.splinePoints[scr.markersExt[startMarker + marker - 1].startSplinePoint - 1];
					num2 = 1;
				}
			}
			else if (scr.closedTrack)
			{
				vector = scr.markersExt[scr.markersExt.Count - 1].position;
			}
			Vector3 m = scr.markersExt[startMarker + marker - 1].position + new Vector3(0.001f, 0f, 0.001f);
			Vector3 vector2 = vector;
			Vector3 m2 = scr.markersExt[startMarker + marker].position + new Vector3(0.001f, 0f, 0.001f);
			m.y = (vector2.y = m2.y);
			bool flag = OCQCDQCQOQ.OOOOCDQQOC(m, vector2, m2);
			Vector3 vector3 = Vector3.zero;
			if (scr.markersExt.Count > startMarker + marker + 1)
			{
				vector3 = scr.markersExt[startMarker + marker + 1].position;
			}
			else if (scr.closedTrack)
			{
				vector3 = scr.markersExt[0].position;
			}
			vector3.y = m2.y;
			bool isAhead = true;
			int firstLastAdjust = 0;
			Vector3 vector4 = m;
			Vector3 vector5 = m2;
			bool isNoAdjust = false;
			Vector3 vector6 = OCCQQQCCCD(ref m2, ref m, ref dir, ref dir2, vector2, vector3, ref isAhead, ref firstLastAdjust, ref isNoAdjust, scr);
			scr.p1Circle = m;
			scr.p2Circle = m2;
			scr.cp7 = m;
			scr.cp8 = m + dir * 500f;
			scr.cp9 = m + -dir * 500f;
			scr.cp3 = m2 + dir2 * 500f;
			scr.cp4 = m2 + -dir2 * 500f;
			bool flag2 = true;
			if ((OCQCDQCQOQ.OOOOCDQQOC(vector4, vector2, vector5) ? (OCQCDQCQOQ.OOOOCDQQOC(vector5, vector4, vector3) ? 1 : 0) : ((!OCQCDQCQOQ.OOOOCDQQOC(vector5, vector4, vector3)) ? 1 : 0)) == 0)
			{
				segPoints.Add(Vector3.Lerp(vector4, vector5, 0.5f));
				segPoints.Add(vector5);
				tValues.Add(0.5f);
				tValues.Add(1f);
				return Vector3.Distance(vector4, vector5);
			}
			Vector3 normalized = (vector6 - m).normalized;
			Vector3 normalized2 = (vector6 - m2).normalized;
			float num3 = Vector3.Angle(dir, dir2);
			if (num3 == 90f || vector6 == Vector3.zero)
			{
				vector6 = Vector3.Lerp(m, m2, 0.5f);
			}
			if (!isAhead)
			{
				num3 = 360f - num3;
			}
			bool flag3 = false;
			float num4 = Vector3.Distance(vector6, m);
			if (num4 > 150f)
			{
				dir = (m - vector6).normalized;
				vector6 = m + dir * 150f;
				num4 = Vector3.Distance(vector6, m);
			}
			float num5 = num4 * 2f * (float)Math.PI;
			dir = (m - vector6).normalized;
			dir2 = (m2 - vector6).normalized;
			num3 = Vector3.Angle(dir, dir2);
			if (!isAhead)
			{
				num3 = 360f - num3;
			}
			scr.cpradius = Vector3.Distance(vector6, m);
			scr.cpangle = num3;
			scr.cpcenter = vector6;
			totalDist = num5 / 360f * num3;
			if (getDistance)
			{
				return totalDist;
			}
			xzDistance = totalDist;
			float num6 = totalDist / scr.faceDistance;
			float num7 = num3 / scr.angleTreshold;
			if (num6 < num7)
			{
				num6 = num7;
			}
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			if (firstLastAdjust == 0)
			{
				zero = vector4;
				zero2 = m;
			}
			else
			{
				zero = m2;
				zero2 = vector5;
			}
			float num8 = Vector3.Distance(zero, zero2);
			if (isNoAdjust)
			{
				num8 = 0f;
			}
			float num9 = num3 / num6;
			float num10 = 1f / num6;
			float num11 = 0f;
			float num12 = 0f;
			if (firstLastAdjust == 0)
			{
				num11 = num8 / (totalDist + num8);
				num10 = (1f - num11) / (num6 + 1f - (float)num2);
			}
			else
			{
				num12 = totalDist / (totalDist + num8);
				num10 = num12 / (num6 + 1f - (float)num2);
			}
			Vector3 point = m;
			float y = scr.markersExt[startMarker + marker - 1].position.y;
			float num13 = num11;
			if (!flag)
			{
				num9 *= -1f;
			}
			bool flag4 = false;
			for (int i = num2; (float)i < num6; i++)
			{
				Vector3 item = ERRoundabouts.OCQDOQQQOD(point, vector6, Quaternion.Euler(0f, (float)i * num9, 0f));
				item.y = y;
				segPoints.Add(item);
				num13 += num10;
				tValues.Add(num13);
			}
			if (!isNoAdjust)
			{
				float num14 = Mathf.Ceil(num8 / scr.faceDistance);
				float num15 = num8 / num14;
				num10 = num8 / (totalDist + num8) / num14;
				List<Vector3> list = new List<Vector3>();
				List<float> list2 = new List<float>();
				dir = (zero2 - zero).normalized;
				num2 = 1;
				if (firstLastAdjust == 1 && Vector3.Distance(segPoints[segPoints.Count - 1], zero) > scr.faceDistance * 0.35f)
				{
					num2 = 0;
				}
				for (int i = num2; (float)i <= num14; i++)
				{
					Vector3 item2 = zero + dir * num15 * i;
					list.Add(item2);
					list2.Add(num12 + num10 * (float)i);
				}
				if (firstLastAdjust == 0)
				{
					segPoints.InsertRange(0, list);
					tValues.InsertRange(0, list2);
				}
				else
				{
					segPoints.AddRange(list);
					tValues.AddRange(list2);
				}
			}
			if (segPoints.Count > 1)
			{
				if (splinePoints.Count > 0)
				{
					Vector3 a = splinePoints[splinePoints.Count - 1];
					a.y = segPoints[0].y;
					if (Vector3.Distance(a, segPoints[0]) < 0.25f)
					{
						segPoints[0] = Vector3.Lerp(a, segPoints[1], 0.5f);
						tValues[0] = Mathf.Lerp(0f, tValues[1], 0.5f);
					}
				}
				if (marker == scr.markersExt.Count - 1 && scr.closedTrack)
				{
					Vector3 a = splinePoints[0];
					a.y = segPoints[segPoints.Count - 1].y;
					if (Vector3.Distance(a, segPoints[segPoints.Count - 1]) < 0.25f)
					{
						segPoints[segPoints.Count - 1] = Vector3.Lerp(a, segPoints[segPoints.Count - 2], 0.5f);
						tValues[tValues.Count - 1] = Mathf.Lerp(0f, tValues[tValues.Count - 2], 0.5f);
					}
				}
			}
			return totalDist + num8;
		}

		public static Vector3 OCCQQQCCCD(ref Vector3 m2, ref Vector3 m1, ref Vector3 dir1, ref Vector3 dir2, Vector3 p1, Vector3 p4, ref bool isAhead, ref int firstLastAdjust, ref bool isNoAdjust, ERModularRoad scr)
		{
			dir1 = (m1 - p1).normalized;
			dir2 = (m2 - p4).normalized;
			Vector3 vector = Vector3.Lerp(dir1, dir2, 0.5f);
			Vector3 vector2 = OCQCDQCQOQ.OCDCDCDCQD(p1, m1, p4, m2);
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 zero3 = Vector3.zero;
			isAhead = OCQCDQCQOQ.OOOOCDQQOC(m1, m2, vector2);
			if (OCQCDQCQOQ.OOOOCDQQOC(m2, p4, m1) && OCQCDQCQOQ.OOOOCDQQOC(m2, p4, p1))
			{
				isAhead = !isAhead;
			}
			if (vector2 != Vector3.zero)
			{
				zero = vector2 - vector * 500f;
				zero2 = vector2 + vector * 500f;
				scr.cp1 = m1;
				scr.cp2 = p1;
				scr.cp3 = m2;
				scr.cp4 = p4;
				scr.cp5 = zero;
				scr.cp6 = zero2;
				Vector3 normalized = new Vector3(dir1.z, 0f, 0f - dir1.x).normalized;
				Vector3 normalized2 = new Vector3(dir2.z, 0f, 0f - dir2.x).normalized;
				Vector3 vector3 = OCQCDQCQOQ.OQQQDCODQD(zero, zero2, m1);
				float num = Vector3.Distance(vector3, m1);
				Vector3 a = OCQCDQCQOQ.OQQQDCODQD(zero, zero2, m2);
				float num2 = Vector3.Distance(a, m2);
				zero3 = vector3;
				if ((num < num2 && isAhead) || (num > num2 && !isAhead))
				{
					Vector3 p5 = m1 + -normalized * 500f;
					Vector3 p6 = m1 + normalized * 500f;
					zero3 = OCQCDQCQOQ.OCDCDCDCQD(p5, p6, zero, zero2);
					zero = m2 - dir2 * 500f;
					zero2 = m2 + dir2 * 500f;
					m2 = OCQCDQCQOQ.OQQQDCODQD(zero, zero2, zero3);
					scr.cp3 = m2;
					firstLastAdjust = 1;
				}
				else if (num != num2)
				{
					Vector3 p5 = m2 + -normalized2 * 500f;
					Vector3 p6 = m2 + normalized2 * 500f;
					zero3 = OCQCDQCQOQ.OCDCDCDCQD(p5, p6, zero, zero2);
					zero = m1 - dir1 * 500f;
					zero2 = m1 + dir1 * 500f;
					m1 = OCQCDQCQOQ.OQQQDCODQD(zero, zero2, zero3);
					scr.cp1 = m1;
					firstLastAdjust = 0;
				}
				else
				{
					isNoAdjust = true;
				}
				scr.cp7 = zero3;
				return zero3;
			}
			zero = m2 - dir2 * 500f;
			zero2 = m2 + dir2 * 500f;
			Vector3 vector4 = OCQCDQCQOQ.OQQQDCODQD(zero, zero2, m1);
			zero = m1 - dir1 * 500f;
			zero2 = m1 + dir1 * 500f;
			Vector3 vector5 = OCQCDQCQOQ.OQQQDCODQD(zero, zero2, m2);
			float num3 = Vector3.Distance(vector4, p4);
			float num4 = Vector3.Distance(m2, p4);
			if (num3 < num4)
			{
				m1 = vector5;
				firstLastAdjust = 0;
			}
			else if (num3 > num4)
			{
				m2 = vector4;
				firstLastAdjust = 1;
			}
			else
			{
				isNoAdjust = true;
			}
			return Vector3.Lerp(m1, m2, 0.5f);
		}

		public static float OODCQODQDD(ref List<Vector3> splinePoints, ERModularRoad scr, int marker, ref List<Vector3> segPoints, ref List<float> tValues, ref float totalDist, int startMarker, ref float xzDistance, bool getDistance)
		{
			segPoints.Clear();
			int num = 1;
			int num2 = 0;
			Vector3 zero = Vector3.zero;
			if (splinePoints.Count > 2)
			{
				zero = splinePoints[splinePoints.Count - 1];
				if ((double)Vector3.Distance(scr.markersExt[startMarker + marker - 1].position, splinePoints[splinePoints.Count - 1]) < 0.5)
				{
					num = 2;
					zero = splinePoints[splinePoints.Count - 2];
					num2 = 1;
				}
			}
			else
			{
				zero = scr.splinePoints[scr.markersExt[startMarker + marker - 1].startSplinePoint];
				if ((double)Vector3.Distance(scr.markersExt[startMarker + marker - 1].position, zero) < 0.5)
				{
					num = 2;
					zero = scr.splinePoints[scr.markersExt[startMarker + marker - 1].startSplinePoint - 1];
					num2 = 1;
				}
			}
			Vector3 position = scr.markersExt[startMarker + marker - 1].position;
			Vector3 pSource = zero;
			Vector3 position2 = scr.markersExt[startMarker + marker].position;
			position.y = (pSource.y = position2.y);
			bool flag = OCQCDQCQOQ.OOOOCDQQOC(position, pSource, position2);
			Vector3 normalized = (scr.markersExt[startMarker + marker - 1].position - zero).normalized;
			Vector3 normalized2 = (scr.markersExt[startMarker + marker - 1].position - scr.markersExt[startMarker + marker].position).normalized;
			normalized.y = 0f;
			normalized.Normalize();
			normalized2.y = 0f;
			normalized2.Normalize();
			float num3 = Vector3.Angle(normalized, normalized2);
			scr.pivotp = scr.markersExt[startMarker + marker - 1].position;
			scr.p1 = zero;
			scr.p2 = scr.markersExt[startMarker + marker].position;
			Vector3 position3 = scr.markersExt[startMarker + marker].position;
			position3.y = 0f;
			Vector3 vector = position3 + normalized2 * 2f;
			bool flag2 = false;
			float num4 = -1f;
			float num5 = 1f;
			if (flag)
			{
				if (num3 >= 90f)
				{
					num3 = 180f - num3;
				}
				else
				{
					num4 = 1f;
					num5 = -1f;
					flag2 = true;
				}
			}
			else if (num3 >= 90f)
			{
				num3 = 180f - num3;
				num4 = 1f;
				num5 = -1f;
			}
			else
			{
				num4 = -1f;
				num5 = 1f;
				flag2 = true;
			}
			float num6 = 2f * Mathf.Tan(num3 * ((float)Math.PI / 180f));
			Vector3 normalized3 = new Vector3(num5 * normalized2.z, 0f, num4 * normalized2.x).normalized;
			Vector3 vector2 = vector + normalized3 * num6;
			normalized3 = new Vector3(normalized.z, 0f, 0f - normalized.x);
			Vector3 position4 = scr.markersExt[startMarker + marker - 1].position;
			position4.y = 0f;
			Vector3 p = position4 + normalized3;
			normalized2 = position3 - vector2;
			normalized3 = new Vector3(normalized2.z, 0f, 0f - normalized2.x).normalized;
			Vector3 p2 = position3 + normalized3;
			Vector3 vector3 = (scr.p2 = OCQCDQCQOQ.OCDCDCDCQD(position4, p, position3, p2));
			if (num3 == 90f)
			{
				vector3 = Vector3.Lerp(position3, position4, 0.5f);
			}
			float num7 = Vector3.Distance(vector3, position4);
			if (num7 > 150f)
			{
				normalized = (position4 - vector3).normalized;
				vector3 = position4 + normalized * 150f;
				num7 = Vector3.Distance(vector3, position4);
			}
			float num8 = num7 * 2f * (float)Math.PI;
			normalized = (position4 - vector3).normalized;
			normalized2 = (position3 - vector3).normalized;
			num3 = Vector3.Angle(normalized, normalized2);
			if (flag2)
			{
				num3 = 360f - num3;
			}
			totalDist = num8 / 360f * num3;
			if (getDistance)
			{
				return totalDist;
			}
			xzDistance = totalDist;
			float num9 = totalDist / scr.faceDistance;
			float num10 = num3 / scr.angleTreshold;
			if (num9 < num10)
			{
				num9 = num10;
			}
			float num11 = num3 / num9;
			float num12 = 1f / num9;
			Vector3 position5 = scr.markersExt[startMarker + marker - 1].position;
			float num13 = 0f;
			if (!flag)
			{
				num11 *= -1f;
			}
			bool flag3 = false;
			for (int i = num2; (float)i < num9; i++)
			{
				Vector3 item = ERRoundabouts.OCQDOQQQOD(position5, vector3, Quaternion.Euler(0f, (float)i * num11, 0f));
				segPoints.Add(item);
				num13 += num12;
				tValues.Add(num13);
			}
			return totalDist;
		}

		public static Vector3 ODDCDDDCOQ(ERModularRoad scr, int marker, ref bool flag)
		{
			int num = 0;
			Vector3 position = scr.markersExt[num + marker - 1].position;
			Vector3 position2 = scr.markersExt[num + marker].position;
			Vector3 vector = scr.markersExt[num + marker + 1].position;
			Vector3 position3 = scr.markersExt[num + marker + 2].position;
			position.y = (position2.y = (position3.y = vector.y));
			float num2 = Vector3.Distance(position2, vector);
			float num3 = Vector3.Distance(vector, position3);
			float num4 = Vector3.Distance(position2, position3);
			Vector3 normalized = (position2 - position).normalized;
			Vector3 normalized2 = (position2 - vector).normalized;
			Vector3 normalized3 = (position3 - vector).normalized;
			float num5 = Vector3.Angle(normalized2, normalized3);
			if (num5 > 160f || num5 < 5f)
			{
				if (num2 < 100f)
				{
					scr.markersExt[num + marker].controlTypeTmp = 3;
					scr.markersExt[num + marker].controlType = 0;
					Vector3 b = (scr.p5 = OCQCDQCQOQ.OQQQDCODQD(position, position2 + normalized * 2000f, vector));
					float num6 = Vector3.Distance(vector, b);
					vector = (scr.markersExt[num + marker + 1].position = Vector3.Lerp(vector, b, 1f - (180f - num5) / 20f));
					if (Vector3.Distance(position2, vector) < 3f)
					{
						vector = (scr.markersExt[num + marker + 1].position = position2 + normalized * 3f);
					}
					return vector;
				}
				if (num2 > num4)
				{
					vector = position3 + normalized3;
				}
			}
			Vector3 normalized4 = (vector - position3).normalized;
			if (num3 < num2 && num3 < 10f)
			{
				vector += (position2 - vector).normalized * 0.66f;
				normalized4 = (vector - position3).normalized;
			}
			Vector3 vector2 = OCQCDQCQOQ.OCDCDCDCQD(position, position2, vector, position3);
			Vector3 vector3 = (normalized + normalized4) * 0.5f;
			Vector3 p = vector2 + -vector3 * 100f;
			Vector3 vector4 = new Vector3(normalized.z, 0f, 0f - normalized.x);
			Vector3 vector5 = new Vector3(0f - normalized4.z, 0f, normalized4.x);
			num5 = Vector3.Angle(vector4, vector5);
			Vector3 vector6 = position2 + vector4 * 20f;
			Vector3 vector7 = OCQCDQCQOQ.OCDCDCDCQD(position2, vector6, vector2, p);
			if (OCQCDQCQOQ.OOOOCDQQOC(vector7, position2, vector2))
			{
				num5 = 360f - num5;
			}
			if (vector7 == Vector3.zero)
			{
				return scr.markersExt[marker + 1].position;
			}
			Vector3 vector8 = ERRoundabouts.OCQDOQQQOD(position2, vector7, Quaternion.Euler(0f, num5, 0f));
			scr.dp1 = position2;
			scr.dp2 = vector6;
			scr.dp3 = vector;
			scr.dp4 = vector + vector5 * 20f;
			float num7 = Vector3.Distance(vector7, vector8);
			if (num7 > Vector3.Distance(position2, position3))
			{
				vector8 = vector;
			}
			scr.markersExt[marker + 1].position = vector8;
			return vector8;
		}

		public static void OQCDOOOCDO(ref List<Vector3> splinePoints, ERModularRoad scr, int marker, ref Vector3 pivotp, ref Vector3 p1, ref Vector3 p2, ref List<Vector3> segPoints, ref List<float> tValues)
		{
			Vector3 normalized = (splinePoints[splinePoints.Count - 1] - splinePoints[splinePoints.Count - 2]).normalized;
			Vector3 vector = new Vector3(normalized.z, 0f, 0f - normalized.x);
			float num = scr.markersExt[marker].circularAngle / ((float)scr.markersExt[marker].circularSegments * 1f);
			Vector3 vector2 = (pivotp = ((!(scr.markersExt[marker].circularAngle < 0f)) ? (splinePoints[splinePoints.Count - 1] - vector * scr.markersExt[marker].circularRadius * (scr.roadWidth * 0.5f)) : (splinePoints[splinePoints.Count - 1] + vector * scr.markersExt[marker].circularRadius * (scr.roadWidth * 0.5f))));
			p1 = splinePoints[splinePoints.Count - 1];
			segPoints.Clear();
			Vector3 vector3 = splinePoints[splinePoints.Count - 1];
			normalized = (vector2 - vector3).normalized;
			float num2 = Mathf.Atan2(normalized.x, normalized.z) * 57.29578f;
			float num3 = 0f;
			float num4 = 1f / ((float)scr.markersExt[marker].circularSegments * 1f);
			for (int i = 1; i <= 1; i++)
			{
				splinePoints.Add(ERRoundabouts.OCQDOQQQOD(vector3, vector2, Quaternion.Euler(0f, (float)i * num, 0f)));
				segPoints.Add(ERRoundabouts.OCQDOQQQOD(vector3, vector2, Quaternion.Euler(0f, (float)i * num, 0f)));
				num3 += num4;
				tValues.Add(num3);
			}
		}

		public static void ODOOOQOOQO(ERModularRoad roadScr, ref List<Vector3> tmpNodes, List<float> splineStrength, ERCrossingPrefabs prefabInstance, int connectionSegment, ref Vector3 connectionDir, ref Vector3 lastForward, int startEnd)
		{
			Vector3 vector = prefabInstance.transform.TransformPoint(Vector3.zero);
			Vector3 vector2 = prefabInstance.transform.TransformPoint(prefabInstance.crossingElements[connectionSegment].centerPoint);
			Vector3 vector3 = prefabInstance.transform.TransformPoint(prefabInstance.crossingElements[connectionSegment].controlPointV3);
			Vector3 normalized = (vector3 - vector2).normalized;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			float num = 0.5f;
			Vector3 vector4;
			if (startEnd == 0)
			{
				zero = (zero2 = tmpNodes[1]);
				num = splineStrength[1];
				if (tmpNodes.Count > 2)
				{
					zero = tmpNodes[2];
				}
				vector4 = ERModularRoad.OQODDDCOQD(vector3, vector3, tmpNodes[1], zero, 0.02f, 0.5f);
			}
			else
			{
				zero = (zero2 = tmpNodes[tmpNodes.Count - 2]);
				num = splineStrength[splineStrength.Count - 2];
				if (tmpNodes.Count > 2 && splineStrength.Count > 2)
				{
					zero = tmpNodes[tmpNodes.Count - 3];
					num = splineStrength[splineStrength.Count - 3];
				}
				vector4 = ERModularRoad.OQODDDCOQD(zero, tmpNodes[tmpNodes.Count - 2], vector3, vector3, 0.98f, 0.5f);
			}
			Vector3 normalized2 = (vector3 - vector4).normalized;
			float num2 = Vector3.Angle(normalized, normalized2);
			float num3 = Vector3.Distance(vector2, vector3);
			float num4 = Mathf.Tan(num2 * ((float)Math.PI / 180f)) * num3;
			if (ERCrossingPrefabs.OOOOCDQQOC(vector3, vector2, vector4))
			{
				num4 *= -1f;
				if (startEnd == 0)
				{
					roadScr.startbendLeftRight = -1;
				}
				else
				{
					roadScr.endbendLeftRight = 1;
				}
			}
			else if (startEnd == 0)
			{
				roadScr.startbendLeftRight = 1;
			}
			else
			{
				roadScr.endbendLeftRight = -1;
			}
			if (startEnd == 0)
			{
				roadScr.startAngle = 90f - num2;
			}
			else
			{
				roadScr.endAngle = 90f - num2;
			}
			List<Vector3> controlPoints = new List<Vector3>();
			if (prefabInstance.tCrossing && connectionSegment <= 1 && prefabInstance.tStraightBending)
			{
				float num5 = Vector3.Distance(vector, vector2);
				float num6 = num5 / Mathf.Cos(num2 * ((float)Math.PI / 180f));
				float totalDistance = 0f;
				roadScr.testPoints2 = OQDDODCOQQ.OQOODOQQDC(vector, vector2, zero2, zero, ref totalDistance, ref controlPoints);
				prefabInstance.DeformTCossingConnection(connectionSegment, totalDistance, num5, controlPoints, num6 / num5, num2, vector2, num);
			}
			prefabInstance.ODDQOCQDDO(connectionSegment, num4 * 0.75f);
			Vector3 vector5 = prefabInstance.transform.TransformPoint(prefabInstance.crossingElements[connectionSegment].tmpCenterPoint);
			if (startEnd == 0)
			{
				ERMarkerExt eRMarkerExt = roadScr.markersExt[0];
				Vector3 position = (tmpNodes[0] = vector5);
				eRMarkerExt.position = position;
			}
			else
			{
				ERMarkerExt eRMarkerExt2 = roadScr.markersExt[roadScr.markersExt.Count - 1];
				Vector3 position = (tmpNodes[tmpNodes.Count - 1] = vector5);
				eRMarkerExt2.position = position;
			}
			if (startEnd == 0)
			{
				Vector3 vector10;
				Vector3 vector8;
				if (prefabInstance.tCrossing && connectionSegment <= 1 && prefabInstance.tStraightBending)
				{
					vector8 = prefabInstance.transform.TransformPoint(prefabInstance.tmpFullMeshVecs[prefabInstance.crossingElements[connectionSegment].fullConnectionVecInts[0]]);
					Vector3 vector9 = prefabInstance.transform.TransformPoint(prefabInstance.tmpFullMeshVecs[prefabInstance.crossingElements[connectionSegment].fullConnectionVecInts[prefabInstance.crossingElements[connectionSegment].fullConnectionVecInts.Count - 1]]);
					vector10 = vector8 - vector9;
					vector10 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
					Vector3 item = tmpNodes[0] + vector10 * Vector3.Distance(tmpNodes[0], tmpNodes[1]);
					tmpNodes.Insert(0, item);
					splineStrength.Insert(0, splineStrength[0]);
					tmpNodes[0] = controlPoints[0];
					tmpNodes[1] = controlPoints[1];
					return;
				}
				Vector3 vector11 = prefabInstance.transform.TransformPoint(prefabInstance.tmpMeshVecs[prefabInstance.crossingElements[connectionSegment].connectionVecInts[prefabInstance.crossingElements[connectionSegment].leftInt]]);
				Vector3 vector12 = prefabInstance.transform.TransformPoint(prefabInstance.tmpMeshVecs[prefabInstance.crossingElements[connectionSegment].connectionVecInts[prefabInstance.crossingElements[connectionSegment].rightInt]]);
				roadScr.p6 = vector11;
				roadScr.p7 = vector12;
				vector10 = vector11 - vector12;
				vector8 = Vector3.zero;
				if (!roadScr.QDDDQODQQDQDQQD)
				{
					vector10 = new Vector3(vector10.x, 0f, vector10.z).normalized;
					vector8 = vector5 + vector10 * 1000f;
					Vector3 vector9 = vector5 + -vector10 * 1000f;
					vector8 = OCQCDQCQOQ.OQQQDCODQD(vector8, vector9, tmpNodes[1]);
					vector10 = (vector8 - tmpNodes[1]).normalized;
					float num7 = Vector3.Distance(tmpNodes[1], vector8);
					vector8 += vector10 * num7;
				}
				else
				{
					Vector3 vector13 = vector2;
					Vector3 normalized3 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
					vector8 = vector13 + normalized3 * 5f;
					zero = vector;
					normalized = (zero - vector13).normalized;
					zero.y = vector13.y;
					normalized2 = (zero - vector13).normalized;
					num2 = Vector3.Angle(normalized, normalized2);
					if (vector.y > vector13.y)
					{
						num2 *= -1f;
					}
					Vector3 vector14 = new Vector3(vector10.x, 0f, vector10.z);
					Vector3 vA = vector11 + -vector14 * 500f;
					Vector3 vB = vector12 + vector14 * 500f;
					vA.y = (vB.y = vector13.y);
					Vector3 vector15 = OCQCDQCQOQ.OQQQDCODQD(vA, vB, tmpNodes[1]);
					Vector3 eulerAngles = GetEulerAngles(vector14);
					vector8 = ODCCODOOQQ(vector13, new Vector2(5f, 0f), 90f - num2, eulerAngles);
					Vector3 normalized4 = (vector8 - vector13).normalized;
					Vector3 vector16 = vector15 - tmpNodes[1];
					Vector3 item = (-2f * (Vector3.Dot(vector16, normalized4) * normalized4) + vector16).normalized;
					float num7 = Vector3.Distance(tmpNodes[1], vector15);
					vector8 = vector15 + num7 * item;
				}
				tmpNodes.Insert(0, vector8);
				splineStrength.Insert(0, splineStrength[0]);
			}
			else if (prefabInstance.tCrossing && connectionSegment <= 1 && prefabInstance.tStraightBending)
			{
				Vector3 vector8 = prefabInstance.transform.TransformPoint(prefabInstance.tmpFullMeshVecs[prefabInstance.crossingElements[connectionSegment].fullConnectionVecInts[0]]);
				Vector3 vector9 = prefabInstance.transform.TransformPoint(prefabInstance.tmpFullMeshVecs[prefabInstance.crossingElements[connectionSegment].fullConnectionVecInts[prefabInstance.crossingElements[connectionSegment].fullConnectionVecInts.Count - 1]]);
				Vector3 vector10 = vector8 - vector9;
				vector10 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
				Vector3 item = tmpNodes[tmpNodes.Count - 1] + vector10 * Vector3.Distance(tmpNodes[tmpNodes.Count - 1], tmpNodes[tmpNodes.Count - 2]);
				tmpNodes.Add(item);
				splineStrength.Add(splineStrength[splineStrength.Count - 1]);
			}
			else
			{
				Vector3 vector11 = prefabInstance.transform.TransformPoint(prefabInstance.tmpMeshVecs[prefabInstance.crossingElements[connectionSegment].connectionVecInts[prefabInstance.crossingElements[connectionSegment].leftInt]]);
				Vector3 vector12 = prefabInstance.transform.TransformPoint(prefabInstance.tmpMeshVecs[prefabInstance.crossingElements[connectionSegment].connectionVecInts[prefabInstance.crossingElements[connectionSegment].rightInt]]);
				roadScr.p6 = vector11;
				roadScr.p7 = vector12;
				Vector3 vector10 = vector11 - vector12;
				vector10 = new Vector3(vector10.x, 0f, vector10.z).normalized;
				Vector3 vector8 = vector5 + vector10 * 1000f;
				Vector3 vector9 = vector5 + -vector10 * 1000f;
				vector8 = OCQCDQCQOQ.OQQQDCODQD(vector8, vector9, tmpNodes[tmpNodes.Count - 2]);
				vector10 = (vector8 - tmpNodes[tmpNodes.Count - 2]).normalized;
				float num7 = Vector3.Distance(tmpNodes[tmpNodes.Count - 2], vector8);
				vector8 += vector10 * num7;
				tmpNodes.Add(vector8);
				splineStrength.Add(splineStrength[splineStrength.Count - 1]);
				lastForward = (vector3 - tmpNodes[tmpNodes.Count - 2]).normalized;
			}
		}

		public static int OOQOCQDDDC(ERModularRoad scr, List<Vector3> splinePoints, float minIndent, float outerRoadDistance, Vector3 ODDOCQCCDQIndent, Vector3 startPrefabIndent, int leftright)
		{
			int num = 1;
			float num2 = outerRoadDistance - minIndent;
			if (leftright == -1)
			{
				num2 = outerRoadDistance + minIndent;
			}
			bool flag = false;
			int num3 = 0;
			while (!flag && num3 < splinePoints.Count)
			{
				Vector3 vector = ((num3 == 0) ? (splinePoints[num3 + 1] - splinePoints[num3]).normalized : ((num3 != splinePoints.Count - 1) ? (splinePoints[num3 + 1] - splinePoints[num3 - 1]).normalized : (splinePoints[num3] - splinePoints[num3 - 1]).normalized));
				vector = new Vector3(0f - vector.z, 0f, vector.x);
				Vector3 vector2 = splinePoints[num3] + vector * num2;
				if (num3 == 0)
				{
					scr.prefabIndentLeft = startPrefabIndent;
					scr.prefabIndentRight = ODDOCQCCDQIndent;
					scr.roadIndent1 = vector2;
				}
				if (OCQCDQCQOQ.OOOOCDQQOC(ODDOCQCCDQIndent, startPrefabIndent, vector2))
				{
					flag = true;
				}
				else
				{
					num3++;
				}
			}
			return num3;
		}

		public static int ODODDODDCO(ERModularRoad scr, List<Vector3> splinePoints, float minIndent, float outerRoadDistance, Vector3 ODDOCQCCDQIndent, Vector3 startPrefabIndent, int leftright, ref int endAdjustInt, ref float endAdjustDistance)
		{
			int num = 1;
			float num2 = outerRoadDistance + minIndent;
			if (leftright == -1)
			{
				num2 = outerRoadDistance - minIndent;
			}
			bool flag = false;
			bool flag2 = false;
			float num3 = 0f;
			int num4 = splinePoints.Count - 1;
			int result = num4;
			endAdjustInt = 0;
			while (!flag && num4 > 0)
			{
				Vector3 vector = ((num4 == splinePoints.Count - 1) ? (splinePoints[num4 - 1] - splinePoints[num4]).normalized : ((num4 != 0) ? (splinePoints[num4 - 1] - splinePoints[num4 + 1]).normalized : (splinePoints[num4] - splinePoints[num4 + 1]).normalized));
				vector = new Vector3(0f - vector.z, 0f, vector.x);
				Vector3 vector2 = splinePoints[num4] + vector * num2;
				if (num4 == splinePoints.Count - 1)
				{
					scr.prefabIndentLeft = startPrefabIndent;
					scr.prefabIndentRight = ODDOCQCCDQIndent;
					scr.roadIndent1 = vector2;
				}
				if (!flag2)
				{
					if (OCQCDQCQOQ.OOOOCDQQOC(ODDOCQCCDQIndent, startPrefabIndent, vector2) && !flag2)
					{
						flag2 = true;
						result = num4;
					}
					else
					{
						num4--;
					}
				}
				else if (num3 >= endAdjustDistance)
				{
					flag = true;
				}
				else
				{
					num4--;
					if (flag2)
					{
						num3 += scr.faceDistance;
					}
				}
			}
			if (endAdjustDistance > num3)
			{
				endAdjustDistance = num3;
			}
			endAdjustInt = num4;
			return result;
		}

		public static ERModularRoad ODCQCQODDD(ERModularRoad scr, int marker)
		{
			scr.closedTrack = false;
			OQQOOODQDQ.UnlockSORotation(scr.soDataExt);
			GameObject gameObject = UnityEngine.Object.Instantiate(scr.gameObject);
			gameObject.transform.position = Vector3.zero;
			ERModularRoad component = gameObject.GetComponent<ERModularRoad>();
			component.gameObject.name = (component.roadName = scr.gameObject.name + "_2");
			component.transform.parent = scr.transform.parent;
			component.soDataExt.Clear();
			foreach (ERSORoadExt item in scr.soDataExt)
			{
				component.soDataExt.Add(UnityEngine.Object.Instantiate(item));
			}
			component.markersExt.Clear();
			for (int i = marker; i < scr.markersExt.Count; i++)
			{
				component.markersExt.Add(DuplicateMarker(scr.markersExt[i]));
			}
			scr.markersExt.RemoveRange(marker + 1, scr.markersExt.Count - marker - 1);
			component.startPrefabScript = null;
			component.startConnectionSegment = 0;
			if (scr.endPrefabScript != null)
			{
				scr.endPrefabScript.crossingElements[scr.endConnectionSegment].connectedRoad = component;
				scr.endPrefabScript.crossingElements[scr.endConnectionSegment].connectedMarker = component.markersExt.Count - 1;
				scr.endPrefabScript = null;
				scr.endConnectionSegment = 0;
			}
			component.gameObject.GetComponent<MeshFilter>().sharedMesh = new Mesh();
			component.gameObject.GetComponent<MeshFilter>().sharedMesh.name = component.gameObject.name;
			if (component.hasMeshCollider)
			{
				component.gameObject.GetComponent<MeshCollider>().sharedMesh = null;
				component.gameObject.GetComponent<MeshCollider>().sharedMesh = component.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			Transform transform = component.transform.Find("surface");
			if (transform != null)
			{
				transform.gameObject.GetComponent<MeshFilter>().sharedMesh = new Mesh();
				transform.gameObject.GetComponent<MeshFilter>().sharedMesh.name = "surface";
				transform.gameObject.GetComponent<MeshCollider>().sharedMesh = transform.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			for (int i = 0; i < scr.transform.childCount; i++)
			{
				GameObject gameObject2 = scr.transform.GetChild(i).gameObject;
				if ((bool)gameObject2.GetComponent<ERSideObjectInstance>())
				{
					UnityEngine.Object.DestroyImmediate(gameObject2);
					i--;
				}
			}
			for (int i = 0; i < component.transform.childCount; i++)
			{
				GameObject gameObject2 = component.transform.GetChild(i).gameObject;
				if ((bool)gameObject2.GetComponent<ERSideObjectInstance>())
				{
					UnityEngine.Object.DestroyImmediate(gameObject2);
					i--;
				}
			}
			Vector3 normalized = (scr.markersExt[scr.markersExt.Count - 2].position - scr.markersExt[scr.markersExt.Count - 1].position).normalized;
			scr.markersExt[scr.markersExt.Count - 1].position += normalized * 2f;
			normalized = (component.markersExt[1].position - component.markersExt[0].position).normalized;
			component.markersExt[0].position += normalized * 2f;
			scr.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
			component.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
			return component;
		}

		public static ERMarkerExt DuplicateMarker(ERMarkerExt sourceMarker)
		{
			ERMarkerExt eRMarkerExt = UnityEngine.Object.Instantiate(sourceMarker);
			eRMarkerExt.soData.Clear();
			foreach (ERSOMarkerExt soDatum in sourceMarker.soData)
			{
				eRMarkerExt.soData.Add(UnityEngine.Object.Instantiate(soDatum));
			}
			return eRMarkerExt;
		}

		public static GameObject JoinRoads(ref List<SelectedObject> objects, ref ERModularRoad road, ref int marker)
		{
			GameObject gameObject = null;
			ERModularRoad roadScr = objects[0].roadScr;
			ERModularRoad roadScr2 = objects[1].roadScr;
			OQQOOODQDQ.UnlockSORotation(roadScr.soDataExt);
			OQQOOODQDQ.UnlockSORotation(roadScr2.soDataExt);
			if (objects[0].markers[0] == roadScr.markersExt.Count - 1 || objects[1].markers[0] == 0)
			{
				if (objects[0].markers[0] != 0 && objects[1].markers[0] != 0)
				{
					roadScr2.markersExt.Reverse();
					SwapIndentsSurroundings(roadScr2);
					SwapSideObjects(roadScr2);
				}
				if (objects[0].markers[0] == 0 && objects[1].markers[0] == 0)
				{
					roadScr2.markersExt.Reverse();
					SwapIndentsSurroundings(roadScr2);
					SwapSideObjects(roadScr2);
				}
				OCQQCCQCCO.SynchSideObjects(roadScr, roadScr2);
				if (objects[0].markers[0] == 0)
				{
					roadScr.markersExt.InsertRange(0, roadScr2.markersExt);
				}
				else
				{
					roadScr.markersExt.AddRange(roadScr2.markersExt);
				}
				if (objects[0].markers[0] != 0 && objects[1].markers[0] == 0 && roadScr2.endPrefabScript != null)
				{
					roadScr.endPrefabScript = roadScr2.endPrefabScript;
					roadScr.endConnectionSegment = roadScr2.endConnectionSegment;
					roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].connectedRoad = roadScr;
					roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].connectedMarker = roadScr.markersExt.Count - 1;
					roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].connectedRoadGO = roadScr.gameObject;
				}
				else if (objects[0].markers[0] == 0 && objects[1].markers[0] == 0 && roadScr2.endPrefabScript != null)
				{
					roadScr.startPrefabScript = roadScr2.endPrefabScript;
					roadScr.startConnectionSegment = roadScr2.endConnectionSegment;
					roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].connectedRoad = roadScr;
					roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].connectedMarker = 0;
					roadScr.startPrefabScript.crossingElements[roadScr.startConnectionSegment].connectedRoadGO = roadScr.gameObject;
				}
				else if (objects[1].markers[0] == roadScr2.markersExt.Count - 1 && roadScr2.startPrefabScript != null)
				{
					roadScr.endPrefabScript = roadScr2.startPrefabScript;
					roadScr.endConnectionSegment = roadScr2.startConnectionSegment;
					roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].connectedRoad = roadScr;
					roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].connectedMarker = roadScr.markersExt.Count - 1;
					roadScr.endPrefabScript.crossingElements[roadScr.endConnectionSegment].connectedRoadGO = roadScr.gameObject;
				}
				gameObject = roadScr2.gameObject;
				roadScr.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
				road = roadScr;
				marker = objects[0].markers[0];
			}
			else
			{
				OCQQCCQCCO.SynchSideObjects(roadScr2, roadScr);
				roadScr2.markersExt.AddRange(roadScr.markersExt);
				if (objects[0].markers[0] == 0 && objects[1].markers[0] != 0 && roadScr.endPrefabScript != null)
				{
					roadScr2.endPrefabScript = roadScr.endPrefabScript;
					roadScr2.endConnectionSegment = roadScr.endConnectionSegment;
					roadScr2.endPrefabScript.crossingElements[roadScr.endConnectionSegment].connectedRoad = roadScr2;
					roadScr2.endPrefabScript.crossingElements[roadScr.endConnectionSegment].connectedMarker = roadScr2.markersExt.Count - 1;
					roadScr2.endPrefabScript.crossingElements[roadScr.endConnectionSegment].connectedRoadGO = roadScr2.gameObject;
				}
				gameObject = roadScr.gameObject;
				roadScr2.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
				road = roadScr2;
				marker = objects[1].markers[0];
			}
			return gameObject;
		}

		public static void SwapIndentsSurroundings(ERModularRoad scr)
		{
			foreach (ERMarkerExt item in scr.markersExt)
			{
				float leftIndent = item.leftIndent;
				item.leftIndent = item.rightIndent;
				item.rightIndent = leftIndent;
				leftIndent = item.leftSurrounding;
				item.leftSurrounding = item.rightSurrounding;
				item.rightSurrounding = leftIndent;
				item.rotation *= -1f;
				item.rotationCenter = 1f - item.rotationCenter;
				int leftIndentAlignment = item.leftIndentAlignment;
				item.leftIndentAlignment = item.rightIndentAlignment;
				item.rightIndentAlignment = leftIndentAlignment;
			}
			float fadeInDistance = scr.fadeInDistance;
			scr.fadeInDistance = scr.fadeOutDistance;
			scr.fadeOutDistance = fadeInDistance;
		}

		public static void SwapSideObjects(ERModularRoad scr)
		{
			for (int i = 0; i < scr.markersExt.Count - 1; i++)
			{
				for (int j = 0; j < scr.markersExt[i].soData.Count; j++)
				{
					SoIndexMatch(scr.markersExt[i].soData[j], scr.markersExt[i + 1].soData, i + 1);
					scr.markersExt[i].soData[j].active = scr.markersExt[i + 1].soData[j].active;
					scr.markersExt[i].soData[j].startOffset = -1f * scr.markersExt[i + 1].soData[j].endOffset;
					scr.markersExt[i].soData[j].endOffset = -1f * scr.markersExt[i + 1].soData[j].startOffset;
					scr.markersExt[i].soData[j].splineActive = scr.markersExt[i + 1].soData[j].splineActive;
					scr.markersExt[i].soData[j].sidewaysDistance = scr.markersExt[i + 1].soData[j].sidewaysDistance;
				}
			}
		}

		public static int SoIndexMatch(ERSOMarkerExt markerSO, List<ERSOMarkerExt> Sos, int index)
		{
			for (int i = 0; i < Sos.Count; i++)
			{
			}
			return -1;
		}

		public static bool ODDDQDCQOQ(List<Vector3> splinePoints, int markers)
		{
			if (splinePoints.Count < markers || markers != 4)
			{
				return false;
			}
			return true;
		}

		public static void OCOQODCDCQ(ERModularRoad scr, Vector3 OCCDODODDQ, ERCrossingPrefabs ODDOCQCCDQ, int targetElement, bool reverse, bool uvReverse, bool forceAutoRotate)
		{
			bool flag = true;
			ODDOCQCCDQ.crossingElements[targetElement].connectedRoad = scr;
			ODDOCQCCDQ.crossingElements[targetElement].connectedMarker = scr.nodeWithinRange;
			int num = 0;
			if (scr.nodeWithinRange == 0)
			{
				scr.startPrefabScript = ODDOCQCCDQ;
				scr.startConnectionSegment = targetElement;
				num = 0;
				scr.startConnectionFlag = true;
			}
			else if (scr.nodeWithinRange == scr.markersExt.Count - 1)
			{
				scr.endPrefabScript = ODDOCQCCDQ;
				scr.endConnectionSegment = targetElement;
				num = 1;
				scr.endConnectionFlag = true;
			}
			ODDOCQCCDQ.crossingElements[targetElement].connectedRoadGO = scr.gameObject;
			if (ODDOCQCCDQ.isIConnector)
			{
				return;
			}
			bool flag2 = false;
			if (scr.nodeWithinRange != 0 && scr.startPrefabScript != null)
			{
				flag2 = scr.startPrefabScript.isIConnector;
			}
			if (scr.nodeWithinRange == 0 && scr.endPrefabScript != null)
			{
				flag2 = scr.endPrefabScript.isIConnector;
			}
			if ((scr.nodeWithinRange != 0 && (scr.startPrefabScript == null || flag2)) || (scr.nodeWithinRange == 0 && (scr.endPrefabScript == null || flag2)))
			{
				if (scr.roadType == ODDOCQCCDQ.crossingElements[targetElement].roadType && scr.roadType != 0.0 && !ODDOCQCCDQ.isCustomPrefab)
				{
					scr.OQCCCCQCCO(ODDOCQCCDQ, targetElement, reverse, uvReverse);
				}
			}
			else if (reverse)
			{
				OQDODODDQC(scr, scr.roadShape, ODDOCQCCDQ, targetElement, 0);
			}
			else
			{
				OQDODODDQC(scr, scr.roadShape, ODDOCQCCDQ, targetElement, 1);
			}
			if (scr.roadType != ODDOCQCCDQ.crossingElements[targetElement].roadType && scr.roadType != 0.0 && (ODDOCQCCDQ.crossingElements[targetElement].includeLeftSidewalk || ODDOCQCCDQ.crossingElements[targetElement].includeRightSidewalk))
			{
				for (int i = 0; i < ODDOCQCCDQ.sidewalkControlElements.Count; i++)
				{
					if (ODDOCQCCDQ.sidewalkControlElements[i].crossingElementLeftIndex == targetElement)
					{
						ODDOCQCCDQ.sidewalkControlElements[i].leftConnectionHandle = false;
					}
					if (ODDOCQCCDQ.sidewalkControlElements[i].crossingElementRightIndex == targetElement)
					{
						ODDOCQCCDQ.sidewalkControlElements[i].rightConnectionHandle = false;
					}
				}
				ODDOCQCCDQ.crossingElements[targetElement].includeLeftSidewalk = false;
				ODDOCQCCDQ.crossingElements[targetElement].includeRightSidewalk = false;
				if ((bool)ODDOCQCCDQ.gameObject.GetComponent<ERCrossings>())
				{
					ODDOCQCCDQ.gameObject.GetComponent<ERCrossings>().OODDODOQCQ(sidewalkSceneHandleFlag: false, rebuildRoads: false);
				}
			}
			Vector3 localScale = ODDOCQCCDQ.transform.localScale;
			if ((scr.roadType != ODDOCQCCDQ.crossingElements[targetElement].roadType && scr.roadType != 0.0) || localScale != new Vector3(1f, 1f, 1f))
			{
				List<Vector2> list = new List<Vector2>(ODDOCQCCDQ.crossingElements[targetElement].roadShapeVecs);
				if (scr.roadShape[0].x > 0f)
				{
					list.Reverse();
				}
				for (int i = 0; i < list.Count; i++)
				{
					list[i] = new Vector2(list[i].x * localScale.x, list[i].y * localScale.y);
				}
				if (num == 0)
				{
					scr.markersExt[0].roadShape = list;
					scr.markersExt[0].roadShapeDistanceMin = 0f;
					scr.markersExt[0].roadShapeDistanceMax = 0.3f;
				}
				else
				{
					scr.markersExt[scr.markersExt.Count - 1].roadShape = list;
					scr.markersExt[scr.markersExt.Count - 1].roadShapeDistanceMin = 0.7f;
					scr.markersExt[scr.markersExt.Count - 1].roadShapeDistanceMax = 1f;
					scr.markersExt[scr.markersExt.Count - 2].roadShapeDistanceMin = 0.7f;
					scr.markersExt[scr.markersExt.Count - 2].roadShapeDistanceMax = 1f;
				}
				flag = false;
			}
			scr.markersExt[scr.nodeWithinRange].position = OCCDODODDQ;
			bool ignorePrefabAlignment = false;
			if (ODDOCQCCDQ.crossingElements[targetElement].rotationPriority)
			{
				for (int i = 0; i < ODDOCQCCDQ.crossingElements.Count; i++)
				{
					if (ODDOCQCCDQ.crossingElements[i].connectedRoad != null && i != targetElement)
					{
						ignorePrefabAlignment = true;
					}
				}
			}
			OCOCOOQQCD.OCDQDCCOCQ(scr.baseScript, ODDOCQCCDQ, targetElement, scr, num);
			if (flag)
			{
				for (int i = 0; i < scr.markersExt.Count; i++)
				{
					scr.markersExt[i].roadShape.Clear();
					scr.markersExt[i].roadShape = new List<Vector2>(scr.roadShape);
				}
			}
			scr.OCCCCCCDCC(ignorePrefabAlignment, forceAutoRotate);
		}

		public static void OCOCQQCCCC(ERModularRoad scr, ref List<Vector3> surfaceVecs, ERCrossingPrefabs prefabScript, ref bool startSurfacesSafe, float distance, float minIndent)
		{
			startSurfacesSafe = true;
			Transform transform = prefabScript.transform;
			if (prefabScript.surfaceObject != null)
			{
				transform = prefabScript.surfaceObject.transform;
			}
			Vector3 vector = transform.TransformPoint(prefabScript.crossingElements[scr.startConnectionSegment].leftSurroundingV3);
			Vector3 vector2 = transform.TransformPoint(prefabScript.crossingElements[scr.startConnectionSegment].rightSurroundingV3);
			Vector3 vector3 = transform.TransformPoint(prefabScript.crossingElements[scr.startConnectionSegment].leftIndentV3);
			Vector3 vector4 = transform.TransformPoint(prefabScript.crossingElements[scr.startConnectionSegment].rightIndentV3);
			if (OCQCDQCQOQ.OOOOCDQQOC(vector, vector2, surfaceVecs[surfaceVecs.Count - 1]))
			{
				scr.vecsBelowTerrain.Add(surfaceVecs[surfaceVecs.Count - 1]);
				surfaceVecs[surfaceVecs.Count - 1] = vector;
				startSurfacesSafe = false;
			}
			if (OCQCDQCQOQ.OOOOCDQQOC(vector3, vector4, surfaceVecs[surfaceVecs.Count - 2]))
			{
				if (distance < minIndent)
				{
					surfaceVecs[surfaceVecs.Count - 2] = vector3;
				}
				else
				{
					Vector3 vector5 = OCQCDQCQOQ.OCDCDCDCQD(vector3, vector4, surfaceVecs[surfaceVecs.Count - 2], surfaceVecs[surfaceVecs.Count - 3]);
					if (Vector3.Distance(vector5, vector3) > Vector3.Distance(surfaceVecs[surfaceVecs.Count - 2], vector3))
					{
						surfaceVecs[surfaceVecs.Count - 2] = vector3;
					}
					else if (OQQCDQOCDO(vector3, vector4, vector5))
					{
						surfaceVecs[surfaceVecs.Count - 2] = vector3;
					}
					else if ((double)(distance - minIndent) < 0.25)
					{
						surfaceVecs[surfaceVecs.Count - 2] = vector3;
					}
					else
					{
						Vector3 normalized = (surfaceVecs[surfaceVecs.Count - 2] - surfaceVecs[surfaceVecs.Count - 3]).normalized;
						Vector3 p = surfaceVecs[surfaceVecs.Count - 2] + new Vector3(normalized.z, normalized.y, 0f - normalized.x) * 0.01f;
						vector5.y = OCQCDQCQOQ.OQOQQQQCQD(surfaceVecs[surfaceVecs.Count - 2], surfaceVecs[surfaceVecs.Count - 3], p, vector5);
						if (Vector3.Distance(vector5, vector3) > Vector3.Distance(surfaceVecs[surfaceVecs.Count - 2], vector3))
						{
							surfaceVecs[surfaceVecs.Count - 2] = vector3;
						}
						else
						{
							surfaceVecs[surfaceVecs.Count - 2] = vector5;
						}
					}
				}
				startSurfacesSafe = false;
			}
			if (!OCQCDQCQOQ.OOOOCDQQOC(vector2, vector, surfaceVecs[surfaceVecs.Count - 5]))
			{
				surfaceVecs[surfaceVecs.Count - 5] = vector2;
				startSurfacesSafe = false;
			}
			if (!OCQCDQCQOQ.OOOOCDQQOC(vector4, vector3, surfaceVecs[surfaceVecs.Count - 4]))
			{
				if (distance < minIndent)
				{
					surfaceVecs[surfaceVecs.Count - 4] = vector4;
				}
				else
				{
					Vector3 vector5 = OCQCDQCQOQ.OCDCDCDCQD(vector3, vector4, surfaceVecs[surfaceVecs.Count - 2], surfaceVecs[surfaceVecs.Count - 4]);
					scr.vecsBelowTerrain.Add(surfaceVecs[surfaceVecs.Count - 1]);
					if (Vector3.Distance(vector5, vector4) > Vector3.Distance(surfaceVecs[surfaceVecs.Count - 2], vector4))
					{
						surfaceVecs[surfaceVecs.Count - 4] = vector4;
					}
					else if (OQQCDQOCDO(vector4, vector3, vector5))
					{
						surfaceVecs[surfaceVecs.Count - 4] = vector4;
					}
					else if ((double)(distance - minIndent) < 0.25)
					{
						surfaceVecs[surfaceVecs.Count - 4] = vector4;
					}
					else
					{
						Vector3 normalized = (surfaceVecs[surfaceVecs.Count - 4] - surfaceVecs[surfaceVecs.Count - 2]).normalized;
						Vector3 p = surfaceVecs[surfaceVecs.Count - 4] + new Vector3(normalized.z, normalized.y, 0f - normalized.x) * 0.01f;
						vector5.y = OCQCDQCQOQ.OQOQQQQCQD(surfaceVecs[surfaceVecs.Count - 2], surfaceVecs[surfaceVecs.Count - 4], p, vector5);
						surfaceVecs[surfaceVecs.Count - 4] = vector5;
					}
				}
				startSurfacesSafe = false;
			}
			if (!startSurfacesSafe)
			{
				surfaceVecs[surfaceVecs.Count - 3] = Vector3.Lerp(surfaceVecs[surfaceVecs.Count - 2], surfaceVecs[surfaceVecs.Count - 4], 0.5f);
			}
		}

		public static void OCQDQDDCQO(ERModularRoad scr, ref List<Vector3> surfaceVecs, ERCrossingPrefabs prefabScript, int el, ref bool surfacesSafe, float distance, float minIndent)
		{
			surfacesSafe = true;
			Transform transform = prefabScript.transform;
			if (prefabScript.surfaceObject != null)
			{
				transform = prefabScript.surfaceObject.transform;
			}
			Vector3 vector = transform.TransformPoint(prefabScript.crossingElements[scr.endConnectionSegment].leftSurroundingV3);
			Vector3 vector2 = transform.TransformPoint(prefabScript.crossingElements[scr.endConnectionSegment].rightSurroundingV3);
			Vector3 vector3 = transform.TransformPoint(prefabScript.crossingElements[scr.endConnectionSegment].leftIndentV3);
			Vector3 vector4 = transform.TransformPoint(prefabScript.crossingElements[scr.endConnectionSegment].rightIndentV3);
			if (OCQCDQCQOQ.OOOOCDQQOC(vector, vector2, surfaceVecs[surfaceVecs.Count - 1 - el]) || el == 0)
			{
				surfaceVecs[surfaceVecs.Count - el - 1] = vector2;
				surfacesSafe = false;
			}
			if (OCQCDQCQOQ.OOOOCDQQOC(vector3, vector4, surfaceVecs[surfaceVecs.Count - el - 2]) || el == 0)
			{
				if (distance < minIndent)
				{
					surfaceVecs[surfaceVecs.Count - el - 2] = vector4;
				}
				else
				{
					Vector3 vector5 = OCQCDQCQOQ.OCDCDCDCQD(vector3, vector4, surfaceVecs[surfaceVecs.Count - el - 2], surfaceVecs[surfaceVecs.Count - el - 3]);
					if (Vector3.Distance(vector5, vector4) > Vector3.Distance(surfaceVecs[surfaceVecs.Count - 2], vector4))
					{
						surfaceVecs[surfaceVecs.Count - el - 2] = vector4;
					}
					else if (OQQCDQOCDO(vector4, vector3, vector5))
					{
						surfaceVecs[surfaceVecs.Count - el - 2] = vector4;
					}
					else if ((double)(distance - minIndent) < 0.25)
					{
						surfaceVecs[surfaceVecs.Count - el - 2] = vector4;
					}
					else
					{
						Vector3 normalized = (surfaceVecs[surfaceVecs.Count - el - 2] - surfaceVecs[surfaceVecs.Count - el - 3]).normalized;
						Vector3 p = surfaceVecs[surfaceVecs.Count - 2] + new Vector3(normalized.z, normalized.y, 0f - normalized.x) * 0.01f;
						vector5.y = OCQCDQCQOQ.OQOQQQQCQD(surfaceVecs[surfaceVecs.Count - el - 2], surfaceVecs[surfaceVecs.Count - el - 3], p, vector5);
						surfaceVecs[surfaceVecs.Count - el - 2] = vector5;
					}
				}
				surfacesSafe = false;
			}
			if (OCQCDQCQOQ.OOOOCDQQOC(vector3, vector4, surfaceVecs[surfaceVecs.Count - el - 4]) || el == 0)
			{
				if (distance < minIndent)
				{
					surfaceVecs[surfaceVecs.Count - el - 4] = vector3;
				}
				else
				{
					Vector3 vector5 = OCQCDQCQOQ.OCDCDCDCQD(vector3, vector4, surfaceVecs[surfaceVecs.Count - el - 4], surfaceVecs[surfaceVecs.Count - el - 2]);
					if (Vector3.Distance(vector5, vector3) > Vector3.Distance(surfaceVecs[surfaceVecs.Count - 2], vector3))
					{
						surfaceVecs[surfaceVecs.Count - el - 4] = vector3;
					}
					else if (OQQCDQOCDO(vector3, vector4, vector5))
					{
						surfaceVecs[surfaceVecs.Count - el - 4] = vector3;
					}
					else
					{
						Vector3 normalized = (surfaceVecs[surfaceVecs.Count - el - 4] - surfaceVecs[surfaceVecs.Count - el - 2]).normalized;
						Vector3 p = surfaceVecs[surfaceVecs.Count - 4] + new Vector3(normalized.z, normalized.y, 0f - normalized.x) * 0.01f;
						vector5.y = OCQCDQCQOQ.OQOQQQQCQD(surfaceVecs[surfaceVecs.Count - el - 4], surfaceVecs[surfaceVecs.Count - el - 2], p, vector5);
						surfaceVecs[surfaceVecs.Count - el - 4] = vector5;
					}
				}
				surfacesSafe = false;
			}
			if (OCQCDQCQOQ.OOOOCDQQOC(vector, vector2, surfaceVecs[surfaceVecs.Count - 5 - el]) || el == 0)
			{
				surfaceVecs[surfaceVecs.Count - el - 5] = vector;
				surfacesSafe = false;
			}
			if (!surfacesSafe)
			{
				surfaceVecs[surfaceVecs.Count - el - 3] = Vector3.Lerp(surfaceVecs[surfaceVecs.Count - el - 4], surfaceVecs[surfaceVecs.Count - el - 2], 0.5f);
			}
		}

		public static void OOCCDCOODQ(ERModularRoad scr, ERCrossingPrefabs ODDOCQCCDQ, int targetElement, bool reverse, bool uvReverse)
		{
			if (scr.baseScript == null)
			{
				if ((bool)scr.transform.parent.parent.gameObject.GetComponent<ERModularBase>())
				{
					scr.baseScript = scr.transform.parent.parent.gameObject.GetComponent<ERModularBase>();
				}
				else if (scr.baseScript == null)
				{
					scr.baseScript = scr.transform.parent.parent.parent.gameObject.GetComponent<ERModularBase>();
				}
			}
			if (scr.baseScript != null)
			{
				QDQDOOQQDQODD.UpdateResolution(scr.baseScript.roadTypes, scr.roadType, ref scr.faceDistance, ref scr.angleTreshold);
			}
			List<Vector2> list = new List<Vector2>(scr.roadShape);
			if (reverse)
			{
				scr.geoReversed = 1;
			}
			else
			{
				scr.geoReversed = 0;
			}
			scr.roadShapeUVs.Clear();
			scr.roadShapeUVs2.Clear();
			scr.roadShapeMaterialInts.Clear();
			scr.roadShape.Clear();
			scr.doConnectionTri.Clear();
			scr.hardEdge.Clear();
			if (ODDOCQCCDQ.crossingElements[targetElement].roadMaterials != null)
			{
				scr.roadMaterials = new List<Material>(ODDOCQCCDQ.crossingElements[targetElement].roadMaterials).ToArray();
				scr.gameObject.GetComponent<MeshRenderer>().sharedMaterials = scr.roadMaterials;
			}
			if (reverse)
			{
				if (ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightVecs.Count != 0)
				{
					scr.roadShape = new List<Vector2>(ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightVecs);
					scr.roadShape.Reverse();
					scr.roadShapeUVs.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightUVY);
					scr.roadShapeUVs.Reverse();
					scr.roadShapeUVs2.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightUVY);
					scr.roadShapeUVs2.Reverse();
					scr.roadShapeMaterialInts.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightMaterialInts);
				}
			}
			else if (ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftVecs.Count != 0)
			{
				scr.roadShape = new List<Vector2>(ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftVecs);
				scr.roadShapeUVs.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftUVY);
				scr.roadShapeUVs2.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftUVY);
				scr.roadShapeMaterialInts.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftMaterialInts);
			}
			List<Vector2> list2 = new List<Vector2>(ODDOCQCCDQ.crossingElements[targetElement].roadShapeVecs);
			List<float> uv = new List<float>(ODDOCQCCDQ.crossingElements[targetElement].roadShapeUVY);
			List<float> uv2 = new List<float>(ODDOCQCCDQ.crossingElements[targetElement].roadShapeUVY2);
			List<bool> list3 = new List<bool>(ODDOCQCCDQ.crossingElements[targetElement].hardEdge);
			scr.doConnectionTri.AddRange(ODDOCQCCDQ.crossingElements[targetElement].doConnectionTri);
			scr.hardEdge.AddRange(ODDOCQCCDQ.crossingElements[targetElement].hardEdge);
			List<Vector2> list4 = new List<Vector2>(ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftVecs);
			list4.AddRange(ODDOCQCCDQ.crossingElements[targetElement].roadShapeVecs);
			list4.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightVecs);
			if (reverse)
			{
				list2.Reverse();
				uv.Reverse();
				uv2.Reverse();
				scr.doConnectionTri.Reverse();
				scr.hardEdge.Reverse();
				for (int i = 1; i < scr.doConnectionTri.Count; i++)
				{
					scr.doConnectionTri[i - 1] = scr.doConnectionTri[i];
				}
			}
			if (ODDOCQCCDQ.isCustomPrefab && !reverse && !uvReverse)
			{
				for (int i = 0; i < uv.Count; i++)
				{
				}
				ODOODQDQQC(ref uv, ref uv2);
			}
			scr.roadShape.AddRange(list2);
			scr.roadShapeUVs.AddRange(uv);
			scr.roadShapeUVs2.AddRange(uv2);
			scr.roadShapeMaterialInts.AddRange(ODDOCQCCDQ.crossingElements[targetElement].roadShapeMaterialInts);
			if (reverse)
			{
				if (ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftVecs.Count != 0)
				{
					list2 = new List<Vector2>(ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftVecs);
					list2.Reverse();
					scr.roadShape.AddRange(list2);
					uv.Clear();
					uv2.Clear();
					uv.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftUVY);
					uv2.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftUVY);
					uv.Reverse();
					uv2.Reverse();
					scr.roadShapeUVs.AddRange(uv);
					scr.roadShapeUVs2.AddRange(uv2);
					scr.roadShapeMaterialInts.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkLeftMaterialInts);
				}
			}
			else if (ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightVecs.Count != 0)
			{
				scr.roadShape.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightVecs);
				scr.roadShapeUVs.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightUVY);
				scr.roadShapeUVs2.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightUVY);
				scr.roadShapeMaterialInts.AddRange(ODDOCQCCDQ.crossingElements[targetElement].sidewalkRightMaterialInts);
			}
			if (reverse)
			{
				scr.roadShapeMaterialInts.Reverse();
			}
			if (scr.nodeWithinRange > 0)
			{
				for (int i = 0; i < scr.roadShape.Count; i++)
				{
					Vector3 vector = scr.roadShape[i];
					vector.x *= -1f;
					scr.roadShape[i] = vector;
				}
			}
			else if (ODDOCQCCDQ.isCustomPrefab && targetElement == 0)
			{
				for (int i = 0; i < scr.roadShapeUVs.Count; i++)
				{
				}
				ODOODQDQQC(ref uv, ref uv2);
			}
			scr.roadShapeMatchCount = 0;
			string text = "";
			string text2 = "";
			bool flag = true;
			for (int i = 0; i < list4.Count; i++)
			{
				flag = true;
				if (i > 0 && (double)Vector2.Distance(list4[i - 1], list4[i]) < 0.01)
				{
					flag = false;
				}
				if (flag)
				{
					Vector2 vector2 = list4[i];
					vector2.x = (float)Math.Round(vector2.x, 1, MidpointRounding.AwayFromZero);
					vector2.y = (float)Math.Round(vector2.y, 1, MidpointRounding.AwayFromZero);
					string text3 = text;
					text = text3 + vector2.x + ", " + vector2.y + ";";
					vector2.x *= -1f;
					text2 = vector2.x + ", " + vector2.y + ";" + text2;
					scr.roadShapeMatchCount++;
				}
			}
			if (reverse)
			{
				scr.roadShapeString = text;
				scr.roadShapeReversedString = text2;
			}
			else
			{
				scr.roadShapeString = text2;
				scr.roadShapeReversedString = text;
			}
			if (reverse)
			{
				OOQQOQDODQ(scr, scr.roadShape, null, 0);
			}
			else
			{
				OOQQOQDODQ(scr, scr.roadShape, null, 1);
			}
			for (int i = 0; i < scr.markersExt.Count; i++)
			{
				bool flag2 = true;
				if (list.Count == scr.roadShape.Count)
				{
					for (int j = 0; j < scr.markersExt[i].roadShape.Count; j++)
					{
						if (scr.markersExt[i].roadShape[j] != list[j])
						{
							flag2 = false;
							Debug.Log("no match");
							break;
						}
					}
				}
				if (flag2)
				{
					scr.markersExt[i].roadShape.Clear();
					scr.markersExt[i].roadShape = new List<Vector2>(scr.roadShape);
				}
			}
		}

		public static void ODOODQDQQC(ref List<float> uv1, ref List<float> uv2)
		{
			if (uv1.Count != uv2.Count)
			{
				uv2 = new List<float>(uv1);
			}
			string text = "";
			string text2 = "";
			for (int i = 0; i < uv1.Count; i++)
			{
				text = text + uv1[i] + ",";
				text2 = text2 + uv2[i] + ",";
			}
			if (text == text2)
			{
				for (int i = 0; i < uv1.Count; i++)
				{
					uv1[i] = 1f - uv1[i];
					uv2[i] = 1f - uv2[i];
				}
				return;
			}
			List<float> list = new List<float>();
			List<float> list2 = new List<float>();
			List<float> list3 = new List<float>();
			List<float> list4 = new List<float>();
			list = new List<float>(uv2);
			list2 = new List<float>(uv1);
			uv1 = new List<float>(list);
			uv2 = new List<float>(list2);
		}

		public static List<int> OOQQOQDODQ(ERModularRoad scr, List<Vector2> roadShapeVecs, List<Vector2> connectionVecs, int startend)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			int num = 0;
			for (int i = 0; i < roadShapeVecs.Count; i++)
			{
				list.Add(i);
				list2.Add(i + num);
				if (scr.hardEdge.Count > i && scr.hardEdge[i])
				{
					num++;
					list2.Add(i + num);
				}
			}
			if (startend == 0)
			{
				scr.roadShapeIntsStart = new List<int>(list);
			}
			else
			{
				scr.roadShapeIntsEnd = new List<int>(list);
			}
			if (scr.startPrefabScript != null && scr.endPrefabScript != null)
			{
				scr.roadShapeIntsStart = new List<int>(list);
				scr.roadShapeIntsEnd = new List<int>(list);
			}
			return list;
		}

		public static List<int> OQDODODDQC(ERModularRoad scr, List<Vector2> roadShapeVecs, ERCrossingPrefabs prefab, int connection, int startend)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<Vector2> list3 = new List<Vector2>();
			list3.AddRange(prefab.crossingElements[connection].sidewalkLeftVecs);
			list3.AddRange(prefab.crossingElements[connection].roadShapeVecs);
			list3.AddRange(prefab.crossingElements[connection].sidewalkRightVecs);
			List<Vector2> list4 = new List<Vector2>(list3);
			if (roadShapeVecs.Count == list3.Count)
			{
				for (int i = 0; i < roadShapeVecs.Count; i++)
				{
					list.Add(i);
				}
			}
			else if (roadShapeVecs.Count > list3.Count)
			{
				int num = 0;
				list.Add(0);
				for (int i = 1; i < roadShapeVecs.Count; i++)
				{
					if ((double)Vector2.Distance(roadShapeVecs[i], roadShapeVecs[i - 1]) > 0.01)
					{
						num++;
					}
					list.Add(num);
				}
			}
			else
			{
				int num = 0;
				list.Add(0);
				for (int i = 1; i < list3.Count; i++)
				{
					if ((double)Vector2.Distance(list3[i], list3[i - 1]) > 0.01)
					{
						list.Add(i);
					}
				}
			}
			if (startend == 0)
			{
				scr.roadShapeIntsStart = new List<int>(list);
			}
			else
			{
				scr.roadShapeIntsEnd = new List<int>(list);
			}
			return list;
		}

		public static void ODCOOQCQQD(ERModularBase baseScr, ERModularRoad scr, int m1, int m2, int m3)
		{
			if (scr.startPrefabScript == null)
			{
				return;
			}
			GameObject gameObject = scr.startPrefabScript.gameObject;
			scr.startPrefabScript.crossingElements[scr.startConnectionSegment].connectedRoad = null;
			scr.startPrefabScript.crossingElements[scr.startConnectionSegment].connectedMarker = -1;
			scr.startPrefabScript.crossingElements[scr.startConnectionSegment].connectedRoadGO = null;
			scr.startPrefabScript = null;
			scr.startConnectionSegment = -1;
			Vector3 normalized = (scr.markersExt[m1].position - scr.markersExt[m2].position).normalized;
			scr.markersExt[m3].position += 5f * normalized;
			scr.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
			if ((bool)gameObject.GetComponent<ERCrossings>())
			{
				ERCrossings component = gameObject.GetComponent<ERCrossings>();
				if (component.tCrossing && component.tStraightBending)
				{
					component.OODDODOQCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
				}
			}
		}

		public static void OQDOCOCDDO(ERModularBase baseScr, ERModularRoad scr, int m1, int m2, int m3)
		{
			Debug.Log("Undo");
			if (scr.endPrefabScript == null)
			{
				return;
			}
			GameObject gameObject = scr.endPrefabScript.gameObject;
			scr.endPrefabScript.crossingElements[scr.endConnectionSegment].connectedRoad = null;
			scr.endPrefabScript.crossingElements[scr.endConnectionSegment].connectedMarker = -1;
			scr.endPrefabScript.crossingElements[scr.endConnectionSegment].connectedRoadGO = null;
			scr.endPrefabScript = null;
			scr.endConnectionSegment = -1;
			Vector3 normalized = (scr.markersExt[m1].position - scr.markersExt[m2].position).normalized;
			scr.markersExt[m3].position += 5f * normalized;
			scr.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
			if ((bool)gameObject.GetComponent<ERCrossings>())
			{
				ERCrossings component = gameObject.GetComponent<ERCrossings>();
				if (component.tCrossing && component.tStraightBending)
				{
					component.OODDODOQCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
				}
			}
		}

		public static void OQOQQDOQDD(ERModularBase baseScript, ref List<Vector3> vecs, List<float> tValues, float heigthOffset, ref Vector3 lastHeightAdjustCP, float resolution, float distance, bool nextMarkerContourAdjust, List<Vector3> currentVecs, ref List<Vector3> testPoints, ref List<float> randomRotations)
		{
			Vector3 zero = Vector3.zero;
			Vector3 vector = vecs[0];
			float y = vector.y;
			int num = 0;
			Vector3 vector2 = vecs[0];
			Vector3 vector3 = vecs[0];
			List<float> tmpTValues = new List<float>();
			List<List<float>> list = new List<List<float>>();
			List<Vector3> list2 = new List<Vector3>();
			float num2 = 0f;
			Vector3 vector4 = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 zero3 = Vector3.zero;
			float num3 = 0f;
			if (lastHeightAdjustCP == Vector3.zero)
			{
				vector4 = (vecs[0] - vecs[1]).normalized;
				Vector3 pos = vecs[0] + vector4 * 10f;
				baseScript.OCCDCQCOQC(ref pos);
				list2.Add(pos);
			}
			else
			{
				list2.Add(lastHeightAdjustCP);
				num2 = lastHeightAdjustCP.x;
			}
			zero2 = vector4;
			Vector3 vector5 = (zero3 = vector);
			Vector3 pos2 = vecs[vecs.Count - 1] + (vecs[vecs.Count - 1] - vecs[vecs.Count - 2]).normalized * 5f;
			baseScript.OCCDCQCOQC(ref pos2);
			list2.Add(vector);
			float num4 = 8f;
			if (!nextMarkerContourAdjust)
			{
				num4 = 20f;
			}
			int num5 = 0;
			float num6 = (float)vecs.Count * 0.5f;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			bool flag = false;
			for (int i = 0; i < vecs.Count; i++)
			{
				if (i > 0)
				{
					num8 += Vector3.Distance(vecs[i - 1], vecs[i]);
				}
				flag = false;
				vector = vecs[i];
				if (nextMarkerContourAdjust || (float)i < num6)
				{
					baseScript.OCCDCQCOQC(ref vector);
				}
				else
				{
					Vector3 pos3 = vector;
					baseScript.OCCDCQCOQC(ref pos3);
					num7 = pos3.y;
					vector.y = Mathf.Lerp(num7, vector.y, ((float)i - num6) / num6);
				}
				if (Mathf.Abs(vector.y - y) > heigthOffset && num8 > 5f && num8 + num4 < distance)
				{
					flag = true;
				}
				if (!flag && i < vecs.Count - 1)
				{
					vector4 = (vector5 - vector).normalized;
					if (((vector4.y > 0f && zero2.y < 0f) || (vector4.y < 0f && zero2.y > 0f)) && Vector3.Distance(vector, zero3) > 2f * heigthOffset && num8 > 5f && num8 + num4 < distance)
					{
						flag = true;
					}
				}
				zero2 = vector4;
				vector5 = vector;
				if (flag)
				{
					list.Add(new List<float>());
					ODOQCDQDQQ(num, i, tValues, ref tmpTValues);
					list[num5].AddRange(tmpTValues);
					list2.Add(vector);
					num5++;
					num = i;
					y = vector.y;
					zero3 = vector;
				}
			}
			if (num != vecs.Count - 1)
			{
				vector = vecs[vecs.Count - 1];
				if (nextMarkerContourAdjust)
				{
					baseScript.OCCDCQCOQC(ref vector);
				}
				list.Add(new List<float>());
				ODOQCDQDQQ(num, vecs.Count - 1, tValues, ref tmpTValues);
				list[num5].AddRange(tmpTValues);
				list2.Add(vector);
			}
			list2.Add(pos2);
			num5 = 0;
			for (int i = 1; i < list2.Count - 2; i++)
			{
				for (int j = 0; j < list[i - 1].Count; j++)
				{
					vector = ERModularRoad.OQODDDCOQD(list2[i - 1], list2[i], list2[i + 1], list2[i + 2], list[i - 1][j], 0.5f);
					if (num5 < vecs.Count - 1)
					{
						zero = vecs[num5];
						zero.y = vector.y;
						vecs[num5] = zero;
					}
					num5++;
				}
			}
			lastHeightAdjustCP = list2[list2.Count - 3];
		}

		public static void ODOQCDQDQQ(int lastInt, int currentInt, List<float> tValues, ref List<float> tmpTValues)
		{
			tmpTValues.Clear();
			float num = tValues[lastInt];
			float num2 = tValues[currentInt];
			float num3 = num2 - num;
			for (int i = lastInt; i < currentInt; i++)
			{
				tmpTValues.Add((tValues[i] - num) / num3);
			}
		}

		public static bool OQQCDQOCDO(Vector3 ODDOCQCCDQIndent, Vector3 otherPrefabIndent, Vector3 v)
		{
			ODDOCQCCDQIndent.y = (otherPrefabIndent.y = (v.y = 0f));
			if (Vector3.Distance(v, otherPrefabIndent) < Vector3.Distance(ODDOCQCCDQIndent, otherPrefabIndent))
			{
				return true;
			}
			return false;
		}

		public static Vector3 ODCCODOOQQ(Vector3 position, Vector3 sourceV3, float angle, Vector3 euler)
		{
			Vector3 point = new Vector3(sourceV3.x, 0f - sourceV3.y, 0f);
			return position + OCQCDQCQOQ.OCQDOQQQOD(point, Vector3.zero, Quaternion.Euler(euler.x, euler.y, angle));
		}

		public static Vector3 OQDDQDOQQQ(Vector3 position, Vector3 sourceV3, float angle, Vector3 euler)
		{
			Vector3 point = new Vector3(0f - sourceV3.x, 0f - sourceV3.y, 0f);
			return position + OCQCDQCQOQ.OCQDOQQQOD(point, Vector3.zero, Quaternion.Euler(euler.x, euler.y, angle));
		}

		public static Vector3 GetEulerAngles(Vector3 v3direction)
		{
			float num = Mathf.Atan2(v3direction.x, v3direction.z) * 57.29578f;
			Quaternion identity = Quaternion.identity;
			if (v3direction != Vector3.zero)
			{
				identity.SetLookRotation(v3direction, Vector3.up);
			}
			return identity.eulerAngles;
		}

		public static void OCCCOQOCDO(GameObject road, Mesh sourceMesh, int LODCount, int LODLevel, int colCount, List<bool> hardEdge, List<int> roadShapeMaterialIntCounts)
		{
			for (int i = 0; i < hardEdge.Count; i++)
			{
				if (hardEdge[i])
				{
					colCount++;
				}
			}
			Mesh sharedMesh = road.GetComponent<MeshFilter>().sharedMesh;
			Transform transform = road.transform.Find("LOD " + LODCount);
			GameObject gameObject;
			Mesh mesh;
			if (transform == null)
			{
				gameObject = new GameObject("LOD " + LODCount);
				gameObject.AddComponent<MeshFilter>();
				gameObject.AddComponent<MeshRenderer>();
				gameObject.AddComponent<MeshCollider>();
				gameObject.transform.parent = road.transform;
				gameObject.isStatic = true;
				gameObject.layer = road.layer;
				gameObject.tag = road.tag;
				gameObject.GetComponent<MeshRenderer>().useLightProbes = road.GetComponent<MeshRenderer>().useLightProbes;
				gameObject.GetComponent<MeshRenderer>().castShadows = road.GetComponent<MeshRenderer>().castShadows;
				mesh = new Mesh();
				gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
				gameObject.GetComponent<MeshCollider>().sharedMesh = sharedMesh;
				gameObject.isStatic = true;
			}
			else
			{
				gameObject = transform.gameObject;
				if (gameObject.GetComponent<MeshFilter>() == null)
				{
					gameObject.AddComponent<MeshFilter>();
				}
				if (gameObject.GetComponent<MeshRenderer>() == null)
				{
					gameObject.AddComponent<MeshRenderer>();
				}
				if (gameObject.GetComponent<MeshCollider>() == null)
				{
					gameObject.AddComponent<MeshCollider>();
				}
				mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
				gameObject.isStatic = true;
				mesh = new Mesh();
				gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
				gameObject.GetComponent<MeshCollider>().sharedMesh = sharedMesh;
			}
			gameObject.GetComponent<MeshRenderer>().sharedMaterials = road.GetComponent<MeshRenderer>().sharedMaterials;
			if (LODCount == 0)
			{
				gameObject.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
				gameObject.GetComponent<MeshCollider>().sharedMesh = sharedMesh;
				return;
			}
			List<List<int>> list = new List<List<int>>();
			List<int> list2 = new List<int>();
			int num = colCount * LODLevel;
			for (int i = 0; i < sharedMesh.subMeshCount; i++)
			{
				list.Add(new List<int>());
				num = colCount * LODLevel;
				int[] triangles = sharedMesh.GetTriangles(i);
				int num2 = 0;
				bool flag = true;
				int num3 = 1;
				while (flag)
				{
					list[i].Add(triangles[num2]);
					list[i].Add(triangles[num2 + 1] + num);
					list[i].Add(triangles[num2 + 2]);
					list[i].Add(triangles[num2 + 3] + num);
					list[i].Add(triangles[num2 + 4] + num);
					list[i].Add(triangles[num2 + 5]);
					num2 += 6;
					num3++;
					if (num3 > roadShapeMaterialIntCounts[i] - 1)
					{
						num3 = 1;
						num2 += 6 * (roadShapeMaterialIntCounts[i] - 1) * LODLevel;
					}
					if (num2 + 4 < triangles.Length)
					{
						if (triangles[num2 + 4] + num >= sharedMesh.vertices.Length)
						{
							num = 0;
						}
					}
					else
					{
						flag = false;
					}
				}
				int num4 = 0;
				int num5 = sharedMesh.vertices.Length - colCount;
				int num6 = list[i].Count - 1;
				for (int num7 = triangles.Length - 1; num7 > 0; num7 -= 3)
				{
					bool flag2 = false;
					if (triangles[num7] >= num5)
					{
						list[i][num6 - num4] = triangles[num7];
						flag2 = true;
					}
					num4++;
					if (triangles[num7 - 1] >= num5)
					{
						flag2 = true;
						list[i][num6 - num4] = triangles[num7 - 1];
					}
					num4++;
					if (triangles[num7 - 2] >= num5)
					{
						flag2 = true;
						list[i][num6 - num4] = triangles[num7 - 2];
					}
					num4++;
					if (!flag2)
					{
						break;
					}
				}
			}
			List<Vector3> vecs = new List<Vector3>();
			List<Vector2> uvs = new List<Vector2>();
			List<Vector2> uvs2 = new List<Vector2>();
			List<Color> colors = new List<Color>();
			List<Vector3> normals = new List<Vector3>();
			List<Vector4> tangents = new List<Vector4>();
			List<List<int>> tris = new List<List<int>>();
			OCQQDQQCQQ.CleanMeshData(sharedMesh, list, ref vecs, ref uvs, ref uvs2, ref normals, ref tangents, ref colors, ref tris);
			mesh.Clear();
			mesh.vertices = vecs.ToArray();
			mesh.uv = uvs.ToArray();
			mesh.uv4 = uvs2.ToArray();
			mesh.colors = colors.ToArray();
			mesh.tangents = tangents.ToArray();
			mesh.subMeshCount = list.Count;
			for (int i = 0; i < tris.Count; i++)
			{
				mesh.SetTriangles(tris[i].ToArray(), i);
			}
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
		}

		public static void ODOQDCODCQ(ERCrossingPrefabs prefab, ERModularRoad road, int connectionIndex, int startEnd)
		{
			Vector3 vector = road.soSplinePoints[0];
			Vector3 vector2 = road.soSplinePoints[1];
			if (startEnd == 0)
			{
				vector = road.soSplinePoints[0];
				vector2 = road.soSplinePoints[1];
			}
			else
			{
				vector = road.soSplinePoints[road.soSplinePoints.Count - 1];
				vector2 = road.soSplinePoints[road.soSplinePoints.Count - 2];
			}
			Vector3 normalized = (vector - vector2).normalized;
			float num = Vector3.Distance(prefab.crossingElements[connectionIndex].centerPoint, Vector3.zero);
			prefab.transform.position = vector + normalized * num;
		}
	}
}
