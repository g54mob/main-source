using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OQQOCDQCQD : MonoBehaviour
	{
		public static bool LineLineIntersection(out Vector3 intersection, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
		{
			Vector3 lhs = linePoint2 - linePoint1;
			Vector3 rhs = Vector3.Cross(lineVec1, lineVec2);
			Vector3 lhs2 = Vector3.Cross(lhs, lineVec2);
			float f = Vector3.Dot(lhs, rhs);
			if (Mathf.Abs(f) < 0.0001f && rhs.sqrMagnitude > 0.0001f)
			{
				float num = Vector3.Dot(lhs2, rhs) / rhs.sqrMagnitude;
				intersection = linePoint1 + lineVec1 * num;
				return true;
			}
			intersection = Vector3.zero;
			return false;
		}

		public static Vector3 OCDCQCDDCC(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, bool flag)
		{
			float num = p1.x - p3.x;
			float num2 = p1.z - p3.z;
			float num3 = p2.z - p1.z;
			float num4 = p2.x - p1.x;
			float num5 = num3 * p1.x + num4 * p1.z;
			float num6 = p4.z - p3.z;
			float num7 = p4.x - p3.x;
			float num8 = num6 * p3.x + num7 * p3.z;
			float num9 = num3 * num7 - num6 * num4;
			if (num9 == 0f)
			{
				return Vector3.zero;
			}
			float num10 = num6 * num4 - num7 * num3;
			float num11 = (num7 * num2 - num6 * num) / num10;
			float num12 = (num4 * num2 - num3 * num) / num10;
			float x = p1.x + num11 * num4;
			float z = p1.z + num11 * num3;
			if (!flag || (num11 >= 0f && num11 <= 1f && num12 >= 0f && num12 <= 1f))
			{
				return new Vector3(x, p1.y, z);
			}
			return Vector3.zero;
		}

		public static bool TwoListsPointOCDCQCDDCC(List<Vector3> points1, List<Vector3> points2, ref Vector3 cp, ref int index1, ref int index2)
		{
			bool flag = false;
			for (int i = 0; i < points1.Count - 1; i++)
			{
				for (int j = 0; j < points2.Count - 1; j++)
				{
					cp = OCDCQCDDCC(points1[i], points1[i + 1], points2[j], points2[j + 1], flag: true);
					if (cp != Vector3.zero)
					{
						index1 = i;
						index2 = j;
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			return false;
		}

		public static bool ListPointsOCDCQCDDCC(ERCrossingPrefabs scr, List<Vector3> points, ref int index1, ref int index2, ref Vector3 cp)
		{
			int count = points.Count;
			cp = Vector3.zero;
			for (int i = 1; i < count - 1; i++)
			{
				for (int num = count - 2; num > 0; num--)
				{
					cp = OCDCQCDDCC(points[i], points[i - 1], points[num], points[num + 1], flag: true);
					if (cp != Vector3.zero && cp != points[i] && cp != points[i - 1])
					{
						index1 = i - 1;
						index2 = num;
						return true;
					}
				}
			}
			return false;
		}

		public static Vector3 GetIntersectionByDir(Vector3 p1, Vector3 dir1, Vector3 p2, Vector3 dir2)
		{
			Vector3 p3 = p1 + dir1 * 150f;
			Vector3 p4 = p2 + dir2 * 150f;
			return OCDCQCDDCC(p1, p3, p2, p4, flag: false);
		}

		public static float OQOOCCQQOQ(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p)
		{
			float x = p.x;
			float z = p.z;
			float num = (p2.z - p3.z) * (p1.x - p3.x) + (p3.x - p2.x) * (p1.z - p3.z);
			float num2 = ((p2.z - p3.z) * (x - p3.x) + (p3.x - p2.x) * (z - p3.z)) / num;
			float num3 = ((p3.z - p1.z) * (x - p3.x) + (p1.x - p3.x) * (z - p3.z)) / num;
			float num4 = 1f - num2 - num3;
			return num2 * p1.y + num3 * p2.y + num4 * p3.y;
		}

		public static bool OOCQODQDQD(Vector3 pTarget, Vector3 pSource, Vector3 pCheck)
		{
			Vector3 normalized = (pTarget - pSource).normalized;
			Vector3 normalized2 = (pCheck - pSource).normalized;
			if (Vector3.Cross(normalized, normalized2).y < 0f)
			{
				return false;
			}
			return true;
		}

		public static Vector3 OCOOQOQCDC(Vector3 vA, Vector3 vB, Vector3 vPoint)
		{
			Vector3 rhs = vPoint - vA;
			Vector3 normalized = (vB - vA).normalized;
			float num = Vector3.Distance(vA, vB);
			float num2 = Vector3.Dot(normalized, rhs);
			if (num2 <= 0f)
			{
				return vA;
			}
			if (num2 >= num)
			{
				return vB;
			}
			Vector3 vector = normalized * num2;
			return vA + vector;
		}

		public static Vector3 OOQOCODQOO(Vector3 point, Vector3 pivot, Quaternion angle)
		{
			Vector3 vector = point - pivot;
			vector = angle * vector;
			return vector + pivot;
		}

		public static float GetYAngleByDir(Vector3 dir)
		{
			return Mathf.Atan2(dir.x, dir.z) * 57.29578f;
		}

		public static Vector3 OCDOCCCDCC(Vector3 point, float angle, Vector3 axis)
		{
			Quaternion quaternion = Quaternion.AngleAxis(angle, axis);
			return quaternion * point;
		}

		public static Vector3 OCCDOQQODO(Vector3 source, float angle)
		{
			Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.up);
			return quaternion * source;
		}

		public static int OCQQDQCDOD(List<Material> mats, Material mat)
		{
			for (int i = 0; i < mats.Count; i++)
			{
				if (mats[i] == mat)
				{
					return i;
				}
			}
			return 0;
		}

		public static float OQDDDQOOQO(Vector3 fwd, Vector3 targetDir, Vector3 up)
		{
			Vector3 lhs = Vector3.Cross(fwd, targetDir);
			float num = Vector3.Dot(lhs, up);
			if ((double)num > 0.0)
			{
				return 1f;
			}
			if ((double)num < 0.0)
			{
				return -1f;
			}
			return 0f;
		}

		public static bool ODDOODDCDC(GameObject go, ref Bounds bounds)
		{
			Renderer component = go.GetComponent<Renderer>();
			if (component != null)
			{
				bounds = component.bounds;
				return true;
			}
			LODGroup component2 = go.GetComponent<LODGroup>();
			if (component2 != null)
			{
				LOD[] lODs = component2.GetLODs();
				Renderer[] renderers = lODs[0].renderers;
				Renderer[] array = renderers;
				foreach (Renderer renderer in array)
				{
					if (renderer.bounds.size.z > bounds.size.z)
					{
						bounds = renderer.bounds;
					}
				}
			}
			else
			{
				foreach (Transform item in go.transform)
				{
					component = item.GetComponent<Renderer>();
					if (component != null && component.bounds.size.z > bounds.size.z)
					{
						bounds = component.bounds;
					}
				}
			}
			if (bounds.size.z > 0f)
			{
				return true;
			}
			return false;
		}

		public static float OQDODCCCCQ(Vector3 pos, ERModularBase scr)
		{
			if (!scr.isInBuildMode)
			{
				LayerMask layerMask = 1 << scr.sLayer;
				Ray ray = new Ray
				{
					direction = Vector3.down
				};
				Vector3 origin = pos;
				origin.y += 50f;
				if (Physics.Raycast(origin, -Vector3.up, out var hitInfo, 100f, layerMask))
				{
					pos.y = hitInfo.point.y;
				}
				else
				{
					scr.OQCCDQOQOO(ref pos);
				}
			}
			else
			{
				scr.OQCCDQOQOO(ref pos);
			}
			return pos.y;
		}

		public static Vector3 OQOOOCQDDO(Vector3 pos, Vector3 dir, ref float distance)
		{
			Ray ray = new Ray
			{
				direction = dir
			};
			Vector3 origin = pos;
			if (Physics.Raycast(origin, dir, out var hitInfo, 100f))
			{
				pos = hitInfo.point;
				distance = hitInfo.distance;
			}
			else
			{
				pos += 5f * dir;
			}
			return pos;
		}

		public static Vector3 OCOODDDQDO(Vector3 pos, Vector3 dir, Vector2 sourceV2)
		{
			Ray ray = new Ray
			{
				direction = dir
			};
			Vector3 origin = pos;
			if ((double)sourceV2.y < 0.2)
			{
				origin.y += 0.2f - sourceV2.y;
			}
			if (Physics.Raycast(origin, dir, out var hitInfo, 100f) && hitInfo.distance < 20f)
			{
				pos = hitInfo.point;
				pos.y -= 0.1f;
			}
			return pos;
		}

		public static Bounds OQDDDQDCOQ(GameObject go)
		{
			Bounds result = default(Bounds);
			Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>(go.GetComponent<Renderer>());
			Renderer[] array = componentsInChildren;
			foreach (Renderer renderer in array)
			{
				if (result.size == Vector3.zero)
				{
					result = renderer.bounds;
				}
				result.Encapsulate(renderer.bounds);
			}
			return result;
		}

		public static bool ODCOODDCOD(GameObject go, Vector3 pos, ERModularRoad thisRoad)
		{
			Bounds bounds = OQDDDQDCOQ(go);
			float num = 1f;
			bool result = true;
			if (!ODQDCODQCC(pos, thisRoad))
			{
				Vector3 pos2 = new Vector3(bounds.min.x, pos.y, bounds.min.z);
				if (!ODQDCODQCC(pos2, thisRoad))
				{
					pos2 = new Vector3(bounds.min.x, pos.y, bounds.max.z);
					if (!ODQDCODQCC(pos2, thisRoad))
					{
						pos2 = new Vector3(bounds.max.x, pos.y, bounds.max.z);
						if (!ODQDCODQCC(pos2, thisRoad))
						{
							pos2 = new Vector3(bounds.max.x, pos.y, bounds.min.z);
							if (!ODQDCODQCC(pos2, thisRoad))
							{
								result = false;
							}
						}
					}
				}
			}
			return result;
		}

		public static bool ODQDCODQCC(Vector3 pos, ERModularRoad thisRoad)
		{
			bool result = false;
			Ray ray = new Ray
			{
				origin = pos,
				direction = Vector3.down
			};
			RaycastHit[] array = Physics.RaycastAll(pos, ray.direction, 50f);
			for (int i = 0; i < array.Length; i++)
			{
				if (((bool)array[i].transform.GetComponent<ERModularRoad>() && array[i].transform.GetComponent<ERModularRoad>() != thisRoad) || (bool)array[i].transform.GetComponent<ERCrossingPrefabs>())
				{
					result = true;
				}
			}
			return result;
		}

		public static Vector3 OOCCQQCCQQ(Vector3 pos, ERModularRoad scr)
		{
			Collider component = scr.gameObject.GetComponent<MeshCollider>();
			Vector3 result = Vector3.up;
			if (component != null)
			{
				Ray ray = new Ray
				{
					direction = Vector3.down
				};
				Vector3 origin = pos;
				origin.y += 50f;
				ray.origin = origin;
				if (component.Raycast(ray, out var hitInfo, 100f))
				{
					result = hitInfo.normal;
				}
			}
			return result;
		}

		public static int OOQDQCCCQQ(int segmentCount, SideObject so, bool newSegment, ERMesh mobject, bool lastSegment, bool skipStartBlend, bool skipEndBlend)
		{
			if (segmentCount == 1 && so.includeStartSegment && !newSegment && !skipStartBlend)
			{
				return 0;
			}
			if ((((segmentCount > 1 && !lastSegment) || (!so.includeStartSegment && segmentCount == 1)) && !newSegment) || (skipStartBlend && segmentCount == 1 && !lastSegment))
			{
				return 1;
			}
			if (lastSegment && !newSegment)
			{
				return 2;
			}
			return -1;
		}

		public static void OOCQDCCDQO(ref Vector3 v2, ref Vector3 n, Vector3 v, Vector3 dir, Vector2 vec, ERModularRoad roadScr, Vector3 randomRotation)
		{
			Vector3 vector = roadScr.baseScript.OOQDDODCDO(v);
			Vector3 vector2 = dir - Vector3.Dot(dir, vector) * vector;
			if (vector2 != Vector3.zero)
			{
				Quaternion quaternion = Quaternion.LookRotation(vector2, vector);
				Vector3 eulerAngles = OQOCQDQODD.GetEulerAngles(dir);
				v2 = OQOCQDQODD.OOCCOCQQDQ(v, vec, 180f + quaternion.eulerAngles.z + randomRotation.x, eulerAngles);
				if (n != Vector3.zero)
				{
					n = OCDOCCCDCC(n, quaternion.eulerAngles.z + randomRotation.x, dir);
				}
			}
		}

		public static void OQDQDOOOCC(ref Vector3 v2, ref Vector3 n, Vector3 v, Vector3 dir, Vector2 vec, float angle, Vector3 randomRotation)
		{
			Vector3 eulerAngles = OQOCQDQODD.GetEulerAngles(dir);
			v2 = OQOCQDQODD.OOCCOCQQDQ(v, vec, 180f - angle + randomRotation.x, eulerAngles);
		}

		public static void RandomAlignment(ref Vector3 v2, ref Vector3 n, Vector3 v, Vector3 dir, Vector2 vec, Vector3 randomRotation)
		{
			dir = new Vector3(dir.x, 0f, dir.z).normalized;
			Vector3 eulerAngles = OQOCQDQODD.GetEulerAngles(dir);
			v2 = OQOCQDQODD.OOCCOCQQDQ(v, vec, 180f + randomRotation.x, eulerAngles);
		}

		public static void OCDCCQCDOO(GameObject go, Vector3 v, ERModularRoad roadScr, Vector3 randomRotation)
		{
			Vector3 vector = roadScr.baseScript.OOQDDODCDO(v);
			Vector3 forward = go.transform.forward;
			Vector3 vector2 = forward - Vector3.Dot(forward, vector) * vector;
			if (vector2 != Vector3.zero)
			{
				go.transform.rotation = Quaternion.LookRotation(vector2, vector);
			}
			if (randomRotation.x != 0f)
			{
				go.transform.Rotate(new Vector3(0f, 0f, randomRotation.x));
			}
		}

		public static void ODODQOCCOQ(GameObject go, Vector3 v1, Vector3 v3, Vector3 dir, Vector3 randomRotation)
		{
			Vector3 vector = v3 + new Vector3(dir.z, 0f, 0f - dir.x) * 2f;
			Vector3 lhs = v1 - vector;
			Vector3 rhs = v3 - vector;
			Vector3 vector2 = -Vector3.Cross(lhs, rhs).normalized;
			Vector3 forward = go.transform.forward;
			Vector3 vector3 = forward - Vector3.Dot(forward, vector2) * vector2;
			if (vector3 != Vector3.zero)
			{
				go.transform.rotation = Quaternion.LookRotation(vector3, vector2);
			}
			if (randomRotation.x != 0f)
			{
				go.transform.Rotate(new Vector3(0f, 0f, randomRotation.x));
			}
		}

		public static void OQOCQQOCOC(GameObject go, Vector3 v1, ERModularRoad roadScr, Vector3 randomRotation, Vector3 cp2, Vector3 cp3, float flipped)
		{
			Vector3 lhs = cp2 - v1;
			Vector3 rhs = cp3 - v1;
			Vector3 vector = Vector3.Cross(lhs, rhs).normalized * flipped;
			Vector3 forward = go.transform.forward;
			Vector3 vector2 = forward - Vector3.Dot(forward, vector) * vector;
			if (vector2 != Vector3.zero)
			{
				go.transform.rotation = Quaternion.LookRotation(vector2, vector);
			}
			if (randomRotation.x != 0f)
			{
				go.transform.Rotate(new Vector3(0f, 0f, randomRotation.x));
			}
		}

		public static void InstantiatedRandomRotation(GameObject go, Vector3 v1, ERModularRoad roadScr, Vector3 randomRotation)
		{
			if (!float.IsNaN(randomRotation.x))
			{
				go.transform.Rotate(new Vector3(0f, 0f, 0f - randomRotation.x));
			}
		}

		public static bool RayTriangleOCDCQCDDCC(Vector3 p1, Vector3 p2, Vector3 p3, Ray ray)
		{
			Vector3 vector = p2 - p1;
			Vector3 vector2 = p3 - p1;
			Vector3 rhs = Vector3.Cross(ray.direction, vector2);
			float num = Vector3.Dot(vector, rhs);
			if (num > 0f - Mathf.Epsilon && num < Mathf.Epsilon)
			{
				return false;
			}
			float num2 = 1f / num;
			Vector3 lhs = ray.origin - p1;
			float num3 = Vector3.Dot(lhs, rhs) * num2;
			if (num3 < 0f || num3 > 1f)
			{
				return false;
			}
			Vector3 rhs2 = Vector3.Cross(lhs, vector);
			float num4 = Vector3.Dot(ray.direction, rhs2) * num2;
			if (num4 < 0f || num3 + num4 > 1f)
			{
				return false;
			}
			if (Vector3.Dot(vector2, rhs2) * num2 > Mathf.Epsilon)
			{
				return true;
			}
			return false;
		}

		public static void OQDOOCQCCQ(ERModularBase scr, Vector3 v1, Vector3 v2, ref float minY, ref float maxY)
		{
			float num = Vector3.Distance(v1, v2);
			float num2 = 1f / (num / 0.5f);
			float num3 = 0f;
			for (float num4 = 0f; num4 <= 1f; num4 += num2)
			{
				num3 = OQDODCCCCQ(Vector3.Lerp(v1, v2, num4), scr);
				if (num3 < minY)
				{
					minY = num3;
				}
				if (num3 > maxY)
				{
					maxY = num3;
				}
			}
		}

		public static List<Vector3> GetSoSplinePoints(ERModularRoad scr, List<float> sidewaysList, ref List<int> markerInts, ref List<float> tValues, ref List<float> markerDistances, ref List<Vector3> tmpMarkers)
		{
			List<Vector3> list = new List<Vector3>();
			List<bool> list2 = new List<bool>();
			List<Vector3> list3 = new List<Vector3>();
			List<Vector3> list4 = new List<Vector3>();
			Vector3 vector;
			Vector3 item;
			for (int i = 0; i < scr.markersExt.Count - 1; i++)
			{
				vector = ((i != 0) ? (scr.splinePoints[scr.markersExt[i].startSplinePoint + 1] - scr.markersExt[i].position) : (scr.splinePoints[1] - scr.markersExt[i].position));
				vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				item = scr.markersExt[i].position + vector * sidewaysList[i];
				list3.Add(scr.markersExt[i].position);
				list4.Add(scr.markersExt[i].position + vector * 1f);
				if (sidewaysList[i] != -1E+10f)
				{
					list.Add(item);
					list2.Add(item: true);
				}
				else
				{
					list2.Add(item: false);
				}
			}
			vector = scr.splinePoints[scr.splinePoints.Count - 1] - scr.splinePoints[scr.splinePoints.Count - 2];
			vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
			item = scr.markersExt[scr.markersExt.Count - 1].position + vector * sidewaysList[sidewaysList.Count - 1];
			list3.Add(scr.markersExt[scr.markersExt.Count - 1].position);
			list4.Add(scr.markersExt[scr.markersExt.Count - 1].position + vector * 1f);
			list.Add(item);
			tmpMarkers = new List<Vector3>(list);
			if (scr.closedTrack)
			{
				list.Add(list[0]);
				list.Add(list[1]);
				list.Insert(0, list[list.Count - 3]);
				list3.Add(list3[0]);
				list4.Add(list4[0]);
			}
			else
			{
				list.Add(list[list.Count - 1]);
				list.Insert(0, list[0]);
			}
			Vector3 a = list[1];
			float num = 0f;
			List<Vector3> list5 = new List<Vector3>();
			int num2 = 1;
			markerDistances.Add(0f);
			float num3 = 0f;
			for (int j = 1; j < list.Count - 2; j++)
			{
				if (num > 0f)
				{
					num -= 1f;
				}
				num = 0f;
				float num4 = 0.0005f;
				for (float num5 = num; num5 < 1f; num5 += num4)
				{
					Vector3 vector2 = ERModularRoad.OQQCQOQOOD(list[j - 1], list[j], list[j + 1], list[j + 2], num5, 0.5f);
					if (Vector3.Distance(a, vector2) > 1f || (j == 1 && num5 == 0f))
					{
						list5.Add(vector2);
						num3 += Vector3.Distance(a, vector2);
						a = vector2;
						if (!OOCQODQDQD(list4[num2], list3[num2], vector2))
						{
							num2++;
							if (num2 >= list3.Count)
							{
								num2 = list3.Count - 1;
							}
						}
						markerInts.Add(num2 - 1);
						tValues.Add(num5);
					}
					num = num5;
				}
				markerDistances.Add(num3);
			}
			return list5;
		}

		public static List<Vector3> ODOQDOQCOD(List<Vector3> points, float tension, float incr)
		{
			List<Vector3> list = new List<Vector3>();
			float num = 0f;
			for (int i = 1; i < points.Count - 2; i++)
			{
				for (float num2 = num; num2 < 1f; num2 += incr)
				{
					Vector3 item = ERModularRoad.OQQCQOQOOD(points[i - 1], points[i], points[i + 1], points[i + 2], num2, tension);
					list.Add(item);
					if (num2 + incr > 1f)
					{
						num = num2 + incr - 1f;
						break;
					}
				}
			}
			return list;
		}

		public static List<Vector3> OOQOOCCQOQ(List<Vector3> points, float tension, float distance, bool addFirstControlPoint = true, float totalDistance = 100000f)
		{
			List<Vector3> list = new List<Vector3>();
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			bool flag = false;
			if (addFirstControlPoint)
			{
				list.Add(points[0]);
			}
			Vector3 b = points[1];
			for (int i = 1; i < points.Count - 2; i++)
			{
				for (float num5 = num; num5 < 1f; num5 += 0.05f)
				{
					Vector3 vector = ERModularRoad.OQQCQOQOOD(points[i - 1], points[i], points[i + 1], points[i + 2], num5, tension);
					num4 = Vector3.Distance(vector, b);
					num2 += num4;
					if (totalDistance != 100000f)
					{
						if (num3 + num4 >= totalDistance)
						{
							flag = true;
						}
						num3 += num4;
					}
					if (num2 > distance)
					{
						list.Add(vector);
						num2 -= distance;
					}
					if (flag)
					{
						break;
					}
					b = vector;
					if (num5 + 0.05f > 1f)
					{
						num = num5 + 0.05f - 1f;
						break;
					}
				}
			}
			return list;
		}

		public static List<Vector3> ODOQDOQCOD(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float incr)
		{
			List<Vector3> list = new List<Vector3>();
			float num = 0f;
			for (float num2 = incr; (double)num2 < 0.99; num2 += incr)
			{
				list.Add(ERModularRoad.OQQCQOQOOD(p1, p2, p3, p4, num2, 0.5f));
			}
			return list;
		}

		public static List<List<Vector2>> GetRoadShapeValues(List<float> tValues, List<float> markerDistances, List<List<Vector2>> nodeListValues, int startMarker, int endMarker, List<Vector2> roadShape, List<int> shapeTransitionTypes, bool closedTrack)
		{
			List<List<Vector2>> list = new List<List<Vector2>>();
			List<List<Vector3>> list2 = new List<List<Vector3>>();
			List<List<Vector3>> list3 = new List<List<Vector3>>();
			List<float> list4 = new List<float>();
			bool flag = false;
			for (int i = 0; i < roadShape.Count; i++)
			{
				list2.Add(new List<Vector3>());
				list3.Add(new List<Vector3>());
			}
			if (markerDistances.Count < nodeListValues.Count)
			{
				for (int j = markerDistances.Count; j < nodeListValues.Count; j++)
				{
					markerDistances.Add(0f);
				}
			}
			for (int k = startMarker; k < endMarker; k++)
			{
				list4.Add(shapeTransitionTypes[k - startMarker]);
				for (int l = 0; l < roadShape.Count; l++)
				{
					Vector3 item = new Vector3(markerDistances[k - startMarker], nodeListValues[k][l].x, 0f);
					list2[l].Add(item);
					item = new Vector3(markerDistances[k - startMarker], nodeListValues[k][l].y, 0f);
					list3[l].Add(item);
				}
			}
			for (int m = 0; m < list2.Count; m++)
			{
				if (!closedTrack)
				{
					list2[m].Insert(0, list2[m][0]);
					list2[m].Add(list2[m][list2[m].Count - 1]);
				}
				else
				{
					list2[m].Insert(0, list2[m][list2[m].Count - 2]);
					list2[m].Add(list2[m][2]);
				}
				if (!closedTrack)
				{
					list3[m].Insert(0, list3[m][0]);
					list3[m].Add(list3[m][list3[m].Count - 1]);
				}
				else
				{
					list3[m].Insert(0, list3[m][list3[m].Count - 2]);
					list3[m].Add(list3[m][2]);
				}
			}
			if (!closedTrack)
			{
				list4.Insert(0, list4[0]);
				list4.Add(list4[list4.Count - 1]);
			}
			else
			{
				list4.Insert(0, list4[list4.Count - 2]);
				list4.Add(list4[2]);
			}
			for (int n = 0; n < roadShape.Count; n++)
			{
				list.Add(new List<Vector2>());
			}
			int num = 0;
			int num2 = 1;
			bool flag2 = false;
			for (; num2 < list2[0].Count - 2; num2++)
			{
				while (!flag2)
				{
					if (num < tValues.Count)
					{
						for (int num3 = 0; num3 < roadShape.Count; num3++)
						{
							Vector3 vector;
							Vector3 vector2;
							if (list4[num2] == 0f)
							{
								vector = ERModularRoad.OQQCQOQOOD(list2[num3][num2 - 1], list2[num3][num2], list2[num3][num2 + 1], list2[num3][num2 + 2], tValues[num], 0.5f);
								vector2 = ERModularRoad.OQQCQOQOOD(list3[num3][num2 - 1], list3[num3][num2], list3[num3][num2 + 1], list3[num3][num2 + 2], tValues[num], 0.5f);
							}
							else if (list4[num2] == 1f)
							{
								vector = Vector3.Lerp(list2[num3][num2], list2[num3][num2 + 1], Mathf.SmoothStep(0f, 1f, tValues[num]));
								vector2 = Vector3.Lerp(list3[num3][num2], list3[num3][num2 + 1], Mathf.SmoothStep(0f, 1f, tValues[num]));
							}
							else
							{
								vector = Vector3.Lerp(list2[num3][num2], list2[num3][num2 + 1], tValues[num]);
								vector2 = Vector3.Lerp(list3[num3][num2], list3[num3][num2 + 1], tValues[num]);
							}
							list[num3].Add(new Vector2(vector.y, vector2.y));
						}
						if (num + 1 < tValues.Count)
						{
							if (tValues[num + 1] <= tValues[num])
							{
								flag2 = true;
							}
						}
						else
						{
							flag2 = true;
						}
						num++;
					}
					else
					{
						flag2 = true;
					}
				}
				flag2 = false;
			}
			return list;
		}

		public static List<Vector3> GetSoMarkerPositionVecs(ERModularRoad scr, List<float> sidewaysList, ref List<Vector3> soMarkerDir, ref List<int> soMarkerInt)
		{
			List<Vector3> list = new List<Vector3>();
			Vector3 vector;
			Vector3 item;
			for (int i = 0; i < scr.markersExt.Count - 1; i++)
			{
				if (sidewaysList[i] == -1E+10f)
				{
					continue;
				}
				vector = ((i != 0) ? (scr.splinePoints[scr.markersExt[i].startSplinePoint + 1] - scr.markersExt[i].position) : (scr.splinePoints[1] - scr.markersExt[i].position));
				vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				item = scr.markersExt[i].position + vector * sidewaysList[i];
				if (soMarkerDir != null)
				{
					if (sidewaysList[i] >= 0f)
					{
						soMarkerDir.Add(vector);
					}
					else
					{
						soMarkerDir.Add(-vector);
					}
				}
				if (soMarkerInt != null)
				{
					soMarkerInt.Add(i);
				}
				list.Add(item);
			}
			vector = scr.splinePoints[scr.splinePoints.Count - 1] - scr.splinePoints[scr.splinePoints.Count - 2];
			vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
			item = scr.markersExt[scr.markersExt.Count - 1].position + vector * sidewaysList[sidewaysList.Count - 1];
			list.Add(item);
			if (soMarkerDir != null)
			{
				if (sidewaysList[sidewaysList.Count - 1] >= 0f)
				{
					soMarkerDir.Add(vector);
				}
				else
				{
					soMarkerDir.Add(-vector);
				}
			}
			if (soMarkerInt != null)
			{
				soMarkerInt.Add(scr.markersExt.Count - 1);
			}
			return list;
		}

		public static void CheckGetSoMarkerPositionVecs(ERModularRoad scr, int marker, ref List<Vector3> soMarkerVecs, ref List<Vector3> soMarkerDir, ref List<int> soMarkerInt)
		{
			if (scr == null)
			{
				Debug.Log("Road script is null: check this situation (did this happen after crossing settings changes?)");
			}
			else
			{
				if (marker >= scr.markersExt.Count)
				{
					return;
				}
				if (marker < 0 && scr.markersExt.Count > 1)
				{
					marker = 0;
				}
				else if (scr.markersExt.Count <= 1)
				{
					return;
				}
				List<float> sidewaysList = new List<float>();
				soMarkerInt.Clear();
				soMarkerDir.Clear();
				bool customNodelistFlag = false;
				List<List<Vector2>> nodeListValues = new List<List<Vector2>>();
				List<int> shapeTransitionTypes = new List<int>();
				if (scr.markersExt[marker].soData.Count > 0)
				{
					if (scr.markersExt[marker].soData[scr.selectedSO] != null)
					{
						if (OCQODDCQDD.GetSidewaysPosition(scr, scr.markersExt[marker].soData[scr.selectedSO].sideObject, ref sidewaysList, ref customNodelistFlag, ref nodeListValues, ref shapeTransitionTypes))
						{
							soMarkerVecs = GetSoMarkerPositionVecs(scr, sidewaysList, ref soMarkerDir, ref soMarkerInt);
							if (scr.markersExt[marker].soData[scr.selectedSO].sideObject.snapToTerrain)
							{
								for (int i = 0; i < soMarkerVecs.Count; i++)
								{
									Vector3 vector = soMarkerVecs[i];
									vector.y = OQDODCCCCQ(vector, scr.baseScript);
									soMarkerVecs[i] = vector;
								}
							}
						}
						else
						{
							soMarkerVecs.Clear();
						}
					}
					else
					{
						soMarkerVecs.Clear();
					}
				}
				else
				{
					soMarkerVecs.Clear();
				}
			}
		}

		public static void TerrainSmooth(Terrain terrain, ERModularRoad road, float size, int type, ref int smoothStep)
		{
			TerrainData terrainData = terrain.terrainData;
			int heightmapResolution = terrainData.heightmapResolution;
			float x = terrainData.heightmapScale.x;
			float z = terrainData.heightmapScale.z;
			Vector3 position = terrain.gameObject.transform.position;
			int num = Convert.ToInt32(Mathf.Ceil(size / x));
			int num2 = Convert.ToInt32(Mathf.Ceil(size / z));
			float t = 1f;
			float x2 = position.x;
			float z2 = position.z;
			int num3 = 0;
			int heightmapResolution2 = terrainData.heightmapResolution;
			int heightmapResolution3 = terrainData.heightmapResolution;
			float[,] heights = terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
			bool[,] array = new bool[terrainData.heightmapResolution, terrainData.heightmapResolution];
			bool[,] array2 = new bool[terrainData.heightmapResolution, terrainData.heightmapResolution];
			float num4 = x2 + 1.5f * size;
			float num5 = z2 + 1.5f * size;
			float num6 = x2 + terrainData.size.x - 1.5f * size;
			float num7 = z2 + terrainData.size.z - 1.5f * size;
			float y = terrainData.size.y;
			ERTerrain component = terrain.gameObject.GetComponent<ERTerrain>();
			if (component == null)
			{
				Debug.Log("EasyRoads3Dv3 Warning: ERTerrain component is missing on terrain: " + terrain.gameObject);
				return;
			}
			int[] array3 = new int[terrainData.heightmapResolution * terrainData.heightmapResolution];
			for (int i = 0; i < component.terrainChanges.Count; i++)
			{
				array3[component.terrainChanges[i].index] = component.terrainChanges[i].value;
			}
			int xStart = component.xStart;
			int zStart = component.zStart;
			bool flag = false;
			int num8 = 0;
			Vector3 zero = Vector3.zero;
			List<Vector3> list;
			List<Vector3> list2;
			if (type == 0)
			{
				list = road.rightIndentVecs;
				list2 = road.leftIndentVecs;
			}
			else
			{
				list = road.rightSurroundingVecs;
				list2 = road.leftSurroundingVecs;
			}
			List<Vector3> leftIndentVecs = road.leftIndentVecs;
			List<Vector3> rightIndentVecs = road.rightIndentVecs;
			List<Vector3> leftSurroundingVecs = road.leftSurroundingVecs;
			List<Vector3> rightSurroundingVecs = road.rightSurroundingVecs;
			for (int j = 0; j < list.Count; j++)
			{
				if (road.bridgeElement[j])
				{
					continue;
				}
				zero = list2[j];
				if (zero.x >= num4 && zero.x < num6 && zero.z >= num5 && zero.z <= num7)
				{
					float num9 = (zero.x - position.x) / terrainData.size.x;
					float num10 = (zero.z - position.z) / terrainData.size.z;
					int num11 = Convert.ToInt32(num9 * (float)terrainData.heightmapResolution) - num - smoothStep;
					int num12 = Convert.ToInt32(num10 * (float)terrainData.heightmapResolution) - num2 - smoothStep;
					if (smoothStep == 0)
					{
						smoothStep = -1;
					}
					else
					{
						smoothStep = 0;
					}
					if (num11 < 0)
					{
						num11 = 0;
					}
					if (num12 < 0)
					{
						num12 = 0;
					}
					int num13 = 0;
					int num14 = 0;
					int num15 = 0;
					for (int k = 0; k < 2 * num2; k++)
					{
						for (int l = 0; l < 2 * num; l++)
						{
							num14 = k + num12;
							num15 = l + num11;
							if (heightmapResolution2 <= l + num11 || heightmapResolution3 <= k + num12)
							{
								continue;
							}
							float num16 = heights[k + num12, l + num11];
							flag = true;
							if (!array[k + num12, l + num11] && flag && array3[(k + num12) * heightmapResolution + l + num11] != 2)
							{
								if (type != 0)
								{
									num16 = Mathf.Lerp(num16, ussst(l + num11, k + num12, terrainData), t);
								}
								else
								{
									num16 = Mathf.Lerp(num16, (leftIndentVecs[j].y - position.y) / y, vssss(leftIndentVecs[j].y, leftSurroundingVecs[j].y, num16 * y + position.y));
									array[k + num12, l + num11] = true;
								}
								if (array3[(k + num12) * heightmapResolution + l + num11] == 0)
								{
									component.terrainDataStored.Add(new ERTerrainData(k + num12 - zStart, l + num11 - xStart, heights[k + num12, l + num11], num16, m_critical: false, 0f, 0f, Vector3.zero, Vector3.zero));
									array3[(k + num12) * heightmapResolution + l + num11] = 1;
								}
								heights[k + num12, l + num11] = num16;
							}
						}
					}
				}
				zero = list[j];
				if (!(zero.x >= num4) || !(zero.x < num6) || !(zero.z >= num5) || !(zero.z <= num7))
				{
					continue;
				}
				float num17 = (zero.x - position.x) / terrainData.size.x;
				float num18 = (zero.z - position.z) / terrainData.size.z;
				int num19 = Convert.ToInt32(num17 * (float)terrainData.heightmapResolution) - num;
				int num20 = Convert.ToInt32(num18 * (float)terrainData.heightmapResolution) - num2;
				int num21 = 0;
				int num22 = 0;
				int num23 = 0;
				for (int m = 0; m < 2 * num2; m++)
				{
					for (int n = 0; n < 2 * num; n++)
					{
						num22 = m + num20;
						num23 = n + num19;
						if (heightmapResolution2 <= num23 || heightmapResolution3 <= num22)
						{
							continue;
						}
						float num24 = heights[num22, num23];
						flag = true;
						if (!array2[m + num20, n + num19] && flag && array3[(m + num20) * heightmapResolution + n + num19] != 2)
						{
							if (type != 0)
							{
								num24 = Mathf.Lerp(num24, ussst(n + num19, m + num20, terrainData), t);
							}
							else
							{
								num24 = Mathf.Lerp(num24, (rightIndentVecs[j].y - position.y) / y, vssss(rightIndentVecs[j].y, rightSurroundingVecs[j].y, num24 * y + position.y));
								array2[m + num20, n + num19] = true;
							}
							if (array3[(m + num20) * heightmapResolution + n + num19] == 0)
							{
								component.terrainDataStored.Add(new ERTerrainData(m + num20 - zStart, n + num19 - xStart, heights[m + num20, n + num19], num24, m_critical: false, 0f, 0f, Vector3.zero, Vector3.zero));
								array3[(m + num20) * heightmapResolution + n + num19] = 1;
							}
							heights[m + num20, n + num19] = num24;
						}
					}
				}
			}
			terrainData.SetHeights(0, 0, heights);
		}

		public static bool CheckSmoothPoint(int x, int z, float sampleWidth, float sampleHeight, ERModularBase scr)
		{
			bool result = true;
			Vector3 pos = Vector3.zero;
			pos.x = Terrain.activeTerrain.gameObject.transform.position.x + (float)x * sampleWidth;
			pos.z = Terrain.activeTerrain.gameObject.transform.position.z + (float)z * sampleHeight;
			scr.OQCCDQOQOO(ref pos);
			LayerMask layerMask = 1 << scr.sLayer;
			pos.y += 20f;
			if (Physics.Raycast(pos, -Vector3.up, out var _, 30f, layerMask))
			{
				result = false;
			}
			return result;
		}

		private static float ussst(int tssss, int ussss, TerrainData vssss)
		{
			float num = 0f;
			float num2 = 1f / vssss.size.y;
			num += vssss.GetHeight(tssss, ussss) * num2;
			num += vssss.GetHeight(tssss + 1, ussss) * num2;
			num += vssss.GetHeight(tssss - 1, ussss) * num2;
			num += vssss.GetHeight(tssss + 1, ussss + 1) * num2 * 0.75f;
			num += vssss.GetHeight(tssss - 1, ussss + 1) * num2 * 0.75f;
			num += vssss.GetHeight(tssss + 1, ussss - 1) * num2 * 0.75f;
			num += vssss.GetHeight(tssss - 1, ussss - 1) * num2 * 0.75f;
			num += vssss.GetHeight(tssss, ussss + 1) * num2;
			num += vssss.GetHeight(tssss, ussss - 1) * num2;
			return num / 8f;
		}

		private static float vssss(float tssss, float ussss, float vssss)
		{
			float num = 1f - Mathf.Abs(tssss - vssss) / Mathf.Abs(tssss - ussss);
			return num * 0.5f;
		}

		public static bool CompareVector2List(List<Vector2> list1, List<Vector2> list2)
		{
			if (list1.Count != list2.Count)
			{
				return false;
			}
			for (int i = 0; i < list1.Count; i++)
			{
				if (list1[i] != list2[i])
				{
					return false;
				}
			}
			return true;
		}

		public static string CheckMesh(GameObject go)
		{
			if (go != null)
			{
				return go.name + " " + go.GetComponent<MeshFilter>().sharedMesh.vertices.Length;
			}
			return " ";
		}

		public static void OQDDQQQCDC(Mesh m, MeshRenderer ren)
		{
			Material[] sharedMaterials = ren.sharedMaterials;
			List<Material> list = new List<Material>();
			Material[] array = sharedMaterials;
			foreach (Material material in array)
			{
				bool flag = false;
				foreach (Material item in list)
				{
					if (material == item)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(material);
				}
			}
			if (list.Count >= sharedMaterials.Length)
			{
				return;
			}
			List<List<int>> list2 = new List<List<int>>();
			list2.Add(new List<int>());
			list2[0] = new List<int>(m.GetTriangles(0));
			for (int j = 1; j < sharedMaterials.Length; j++)
			{
				bool flag2 = false;
				for (int k = 0; k < j; k++)
				{
					if (sharedMaterials[j] == sharedMaterials[k])
					{
						flag2 = true;
						list2[k].AddRange(m.GetTriangles(j));
						break;
					}
				}
				if (!flag2)
				{
					list2.Add(new List<int>(m.GetTriangles(j)));
				}
			}
			ren.sharedMaterials = list.ToArray();
			m.subMeshCount = list.Count;
			for (int l = 0; l < list2.Count; l++)
			{
				m.SetTriangles(list2[l].ToArray(), l);
			}
		}

		public static List<float> OCDQQOCDCQ(List<Vector2> nodes)
		{
			float num = 0f;
			List<float> list = new List<float>();
			list.Add(0f);
			for (int i = 1; i < nodes.Count; i++)
			{
				num += Vector2.Distance(nodes[i - 1], nodes[i]);
				list.Add(num);
			}
			List<float> list2 = new List<float>();
			for (int j = 0; j < nodes.Count; j++)
			{
				list2.Add(list[j] / num);
			}
			return list2;
		}

		public List<Vector2> OQQQDQOCOD(List<Vector3> vecs, float x)
		{
			List<Vector2> list = new List<Vector2>();
			list.Add(new Vector2(x, 0f));
			float num = 0f;
			for (int i = 0; i < vecs.Count - 1; i++)
			{
				num += Vector3.Distance(vecs[i], vecs[i + 1]);
				list.Add(new Vector2(x, num * 0.1f));
			}
			return list;
		}

		public static bool CheckConnectAngle(Vector3 r1, Vector3 p1, Vector3 p2)
		{
			Vector3 normalized = (p2 - r1).normalized;
			Vector3 normalized2 = (p2 - p1).normalized;
			float num = Vector3.Angle(normalized, normalized2);
			float num2 = Vector3.Distance(r1, p2);
			Debug.Log("angle: " + num + " dist: " + num2);
			if ((num2 < 10f && num < 160f) || num < 135f)
			{
				return false;
			}
			if (num2 > 30f)
			{
				return true;
			}
			float num3 = (num2 - 10f) / 20f;
			float num4 = 155f - num3 * 25f;
			if (num > num4)
			{
				return true;
			}
			return false;
		}

		public static GameObject OOOQODQOQD(string name, Vector3 size, Vector2 tiling, Vector2 offset, float drawDistance, Material mat, int rendermask, int transparentTextureResolution)
		{
			GameObject result = null;
			if (ERModularBase.dpcMethod != null)
			{
				object[] parameters = new object[8]
				{
					name,
					size,
					tiling,
					offset,
					drawDistance,
					mat,
					rendermask - 1,
					transparentTextureResolution
				};
				result = ERModularBase.dpcMethod.Invoke(null, parameters) as GameObject;
			}
			return result;
		}

		public static void BuildCrosswalkDecalPreview(QDQDOOQQDQODD roadType, ERDecal decal, GameObject Prefab)
		{
			List<Vector3> list = new List<Vector3>();
			Vector3 camdir = ODDOQDDQCQ.camdir;
			Vector3 forward = new Vector3(camdir.z, 0f, 0f - camdir.x);
			if (!(ODDOQDDQCQ.rtg == null) && !(decal == null))
			{
				Vector3 position = ODDOQDDQCQ.rtg.transform.position + camdir * (decal.width + 2f);
				if (roadType.crosswalkType == ERCrossWalkType.DecalProjector && roadType.crosswalkDecal != null)
				{
					float num = roadType.roadWidth - decal.startOffset;
					Vector3 size = new Vector3(decal.width, num, 1f);
					float y = ERSideWalkVecs.CrosswalkYTiling(decal, num);
					Vector2 tiling = new Vector2(decal.uvLeftTop.x - decal.uvRightBottom.x, y);
					Vector2 offset = new Vector2(decal.uvLeftTop.x, decal.uvRightBottom.y);
					GameObject gameObject = OOOQODQOQD("Crosswalk", size, tiling, offset, decal.drawDistance, decal.material, decal.renderingLayerMask, 2);
					gameObject.name = "Crosswalk";
					gameObject.transform.position = position;
					gameObject.transform.parent = ODDOQDDQCQ.rtg.transform;
					gameObject.transform.forward = forward;
					gameObject.transform.Rotate(90f, 0f, 0f, Space.Self);
				}
				else if (roadType.crosswalkType == ERCrossWalkType.Prefab && roadType.crosswalkPrefab != null)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(roadType.crosswalkPrefab);
					position.y += roadType.crosswalkHeightOffset;
					gameObject2.transform.position = position;
					gameObject2.transform.parent = ODDOQDDQCQ.rtg.transform;
					gameObject2.transform.forward = camdir;
					gameObject2.name = "Crosswalk";
				}
			}
		}

		public static void OCQQQQDDOC(QDQDOOQQDQODD roadType, ERDecal decal)
		{
			if (decal.previewDecalObject == null)
			{
				decal.previewDecalObject = new GameObject(decal.name);
			}
			float num = roadType.roadWidth * 0.5f;
			List<Vector3> list = new List<Vector3>();
			Vector3 camdir = ODDOQDDQCQ.camdir;
			Vector3 vector = new Vector3(camdir.z, 0f, 0f - camdir.x);
			decal.previewDecalObject.transform.position = ODDOQDDQCQ.rtg.transform.position;
			decal.previewDecalObject.transform.parent = ODDOQDDQCQ.rtg.transform;
			Vector3 item = ODDOQDDQCQ.rtg.transform.position + vector * num;
			item += vector * decal.xOffset;
			float num2 = 1f;
			item += camdir * num2;
			item += camdir * decal.length * 0.5f;
			list.Add(item);
			float num3 = roadType.roadWidth * 1.75f - 2f * num2;
			for (num3 -= decal.length; num3 > 0f; num3 -= decal.length - decal.overlap)
			{
				item += camdir * (decal.length - decal.overlap);
				list.Add(item);
			}
			OQQDCDCDOQ(decal.previewDecalObject.transform, list, decal, 0f);
		}

		public static void OCCQCCQDQC(QDQDOOQQDQODD roadType, ERDecal decal)
		{
		}

		public static void OQQDCDCDOQ(Transform parent, List<Vector3> OOQOQCDCQC, ERDecal decal, float tiltingAngle)
		{
			for (int i = 0; i < OOQOQCDCQC.Count; i++)
			{
				Vector3 forward = ((i == 0) ? (OOQOQCDCQC[1] - OOQOQCDCQC[0]).normalized : ((i != OOQOQCDCQC.Count - 1) ? (OOQOQCDCQC[i + 1] - OOQOQCDCQC[i - 1]).normalized : (OOQOQCDCQC[OOQOQCDCQC.Count - 1] - OOQOQCDCQC[OOQOQCDCQC.Count - 2]).normalized));
				GameObject gameObject = OOOQODQOQD(size: new Vector3(decal.width, decal.length, 1f), tiling: new Vector2(decal.uvLeftTop.x - decal.uvRightBottom.x, decal.uvLeftTop.y - decal.uvRightBottom.y), offset: new Vector2(decal.uvLeftTop.x, decal.uvRightBottom.y), name: decal.name, drawDistance: decal.drawDistance, mat: decal.material, rendermask: decal.renderingLayerMask, transparentTextureResolution: 2);
				gameObject.transform.position = OOQOQCDCQC[i];
				gameObject.transform.parent = parent;
				gameObject.transform.forward = forward;
				if (tiltingAngle > 1f || tiltingAngle < -1f)
				{
					gameObject.transform.Rotate(0f, 0f, tiltingAngle, Space.Self);
				}
				gameObject.transform.Rotate(90f, 0f, 0f, Space.Self);
			}
		}

		public static void OQCDCDDDDO(Transform parent, ref GameObject go, string name, List<Vector3> OOQOQCDCQC, List<Vector3> decalSourceStartVecs, List<Vector3> decalSourceEndVecs, Material mat, float OQCQCDCCDO, float OOODCCODDD, float OQCCQOCOCO, float ODDQOCDQOC, float ODQCQQQQQQ, float OOQCCQDDQO, Vector2 ODQOQOQCDO, Vector2 OOODDCDDDQ, float uvRatio, ERDecal decal)
		{
			Mesh mesh = null;
			if (go == null)
			{
				go = new GameObject(name);
			}
			if (!go.GetComponent<MeshRenderer>())
			{
				go.AddComponent<MeshRenderer>();
				go.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			go.GetComponent<MeshRenderer>().sharedMaterial = mat;
			if (!go.GetComponent<MeshFilter>())
			{
				go.AddComponent<MeshFilter>();
			}
			if (go.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = go.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				go.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			go.transform.parent = parent;
			go.transform.localPosition = Vector3.zero;
			go.transform.localEulerAngles = Vector3.zero;
			List<Vector2> list = new List<Vector2>();
			list.Add(new Vector2((0f - OOQCCQDDQO) * 0.5f, ODDQOCDQOC));
			list.Add(new Vector2(OOQCCQDDQO * 0.5f, ODDQOCDQOC));
			List<float> list2 = new List<float>();
			list2.Add(ODQOQOQCDO.x);
			list2.Add(OOODDCDDDQ.x);
			list = decal.shape;
			list2 = decal.shapeUVs;
			List<Vector3> list3 = new List<Vector3>();
			List<Vector2> list4 = new List<Vector2>();
			List<Vector2> list5 = new List<Vector2>();
			List<Vector2> list6 = new List<Vector2>();
			List<Color> list7 = new List<Color>();
			List<int> list8 = new List<int>();
			List<int> list9 = new List<int>();
			float y = OOODDCDDDQ.y;
			float y2 = ODQOQOQCDO.y;
			if (decal.startEndSections && decal.uvBreakPoints.Count >= 2)
			{
				y = decal.uvBreakPoints[0].y;
				y2 = decal.uvBreakPoints[decal.uvBreakPoints.Count - 1].y;
			}
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 zero = Vector3.zero;
			float num2;
			float num3;
			float num = (num2 = (num3 = 0f));
			float num4 = y;
			float num5 = 0f;
			float num6 = y;
			int num7 = 0;
			bool flag = false;
			for (int i = 0; i < OOQOQCDCQC.Count; i++)
			{
				Vector3 vector3;
				Vector3 vector4;
				if (i == 0)
				{
					vector3 = (vector4 = OOQOQCDCQC[i + 1] - OOQOQCDCQC[i]);
				}
				else if (i == OOQOQCDCQC.Count - 1)
				{
					vector3 = (vector4 = OOQOQCDCQC[i] - OOQOQCDCQC[i - 1]);
				}
				else
				{
					vector3 = OOQOQCDCQC[i + 1] - OOQOQCDCQC[i - 1];
					vector4 = OOQOQCDCQC[i] - OOQOQCDCQC[i - 1];
				}
				Vector3 normalized = new Vector3(vector3.z, 0f, 0f - vector3.x).normalized;
				if (i == 0)
				{
					vector = normalized;
				}
				else if (i == OOQOQCDCQC.Count - 1)
				{
					vector2 = normalized;
				}
				vector4 = vector4.normalized;
				if (i > 0)
				{
					num = Vector3.Distance(OOQOQCDCQC[i], OOQOQCDCQC[i - 1]);
				}
				num3 += num;
				float num8 = num2 + num;
				float num9 = num8 / uvRatio + y;
				Vector3 vector5;
				if (num9 > y2)
				{
					list9.Add(num7);
					float num10 = (y2 - num4) * uvRatio;
					vector5 = OOQOQCDCQC[i - 1] + vector4 * num10;
					num9 = y2;
					for (int j = 0; j < list.Count; j++)
					{
						Vector3 item = vector5 + normalized * list[j].x;
						item.y += list[j].y;
						list3.Add(item);
						list4.Add(new Vector2(list2[j], num9));
					}
					num9 = y;
					for (int k = 0; k < list.Count; k++)
					{
						Vector3 item = vector5 + normalized * list[k].x;
						item.y += list[k].y;
						list3.Add(item);
						list4.Add(new Vector2(list2[k], num9));
					}
					num2 = num - num10;
					num7 += 2;
				}
				else
				{
					num2 += num;
				}
				num9 = num2 / uvRatio + y;
				vector5 = OOQOQCDCQC[i];
				if (i == 0 || i == OOQOQCDCQC.Count - 1 || i == OOQOQCDCQC.Count - 2)
				{
					vector5.y -= ODDQOCDQOC;
				}
				for (int l = 0; l < list.Count; l++)
				{
					Vector3 item = vector5 + normalized * list[l].x;
					item.y += list[l].y;
					list3.Add(item);
					list4.Add(new Vector2(list2[l], num9));
				}
				num4 = num9;
				num7++;
			}
			int num11 = num7 - 1;
			int count = list.Count;
			int num12 = 1;
			int num13 = 0;
			if (list9.Count == 0)
			{
				list9.Add(-1);
			}
			for (int m = 0; m < num11; m += num12)
			{
				if (m != list9[num13])
				{
					for (int n = 0; n < count - 1; n++)
					{
						list8.Add(m * count + n);
						list8.Add((m + num12) * count + n + 1);
						list8.Add(m * count + n + 1);
						list8.Add((m + num12) * count + n);
						list8.Add((m + num12) * count + n + 1);
						list8.Add(m * count + n);
					}
				}
				else if (list9.Count > num13 + 1)
				{
					num13++;
				}
			}
			if (decal.startEndSections)
			{
				if (decalSourceStartVecs.Count > 1)
				{
					float num9 = (y = OOODDCDDDQ.y);
					num3 = 0f;
					num = 0f;
					float num14 = Vector3.Distance(decalSourceStartVecs[0], decalSourceStartVecs[decalSourceStartVecs.Count - 1]);
					for (int num15 = 0; num15 < decalSourceStartVecs.Count; num15++)
					{
						Vector3 normalized;
						if (num15 == 0)
						{
							Vector3 vector4;
							Vector3 vector3 = (vector4 = decalSourceStartVecs[num15 + 1] - decalSourceStartVecs[num15]);
							normalized = new Vector3(vector3.z, 0f, 0f - vector3.x).normalized;
						}
						else if (num15 == decalSourceStartVecs.Count - 1)
						{
							normalized = vector;
						}
						else
						{
							Vector3 vector3 = decalSourceStartVecs[num15 + 1] - decalSourceStartVecs[num15 - 1];
							Vector3 vector4 = decalSourceStartVecs[num15] - decalSourceStartVecs[num15 - 1];
							normalized = new Vector3(vector3.z, 0f, 0f - vector3.x).normalized;
						}
						if (num15 > 0)
						{
							num = Vector3.Distance(decalSourceStartVecs[num15], decalSourceStartVecs[num15 - 1]);
							num3 += num;
							num9 = Mathf.Lerp(y, decal.uvBreakPoints[0].y, num3 / num14);
						}
						for (int num16 = 0; num16 < list.Count; num16++)
						{
							Vector3 item = decalSourceStartVecs[num15] + normalized * list[num16].x;
							item.y += list[num16].y;
							list3.Add(item);
							list4.Add(new Vector2(list2[num16], num9));
						}
					}
					num11 = decalSourceStartVecs.Count - 1;
					int num17 = num7;
					for (int num18 = 0; num18 < num11; num18 += num12)
					{
						for (int num19 = 0; num19 < count - 1; num19++)
						{
							list8.Add((num18 + num17) * count + num19);
							list8.Add((num18 + num17 + num12) * count + num19 + 1);
							list8.Add((num18 + num17) * count + num19 + 1);
							list8.Add((num18 + num17 + num12) * count + num19);
							list8.Add((num18 + num17 + num12) * count + num19 + 1);
							list8.Add((num18 + num17) * count + num19);
						}
					}
				}
				if (decalSourceEndVecs.Count > 1)
				{
					float num9 = (y = decal.uvBreakPoints[decal.uvBreakPoints.Count - 1].y);
					num3 = 0f;
					num = 0f;
					float y3 = decal.uvBreakPoints[decal.uvBreakPoints.Count - 1].y;
					float y4 = ODQOQOQCDO.y;
					float num20 = Vector3.Distance(decalSourceEndVecs[0], decalSourceEndVecs[decalSourceEndVecs.Count - 1]);
					for (int num21 = 0; num21 < decalSourceEndVecs.Count; num21++)
					{
						Vector3 normalized;
						if (num21 == 0)
						{
							normalized = vector2;
						}
						else if (num21 == decalSourceEndVecs.Count - 1)
						{
							Vector3 vector4;
							Vector3 vector3 = (vector4 = decalSourceEndVecs[num21] - decalSourceEndVecs[num21 - 1]);
							normalized = new Vector3(vector3.z, 0f, 0f - vector3.x).normalized;
						}
						else
						{
							Vector3 vector3 = decalSourceEndVecs[num21 + 1] - decalSourceEndVecs[num21 - 1];
							Vector3 vector4 = decalSourceEndVecs[num21] - decalSourceEndVecs[num21 - 1];
							normalized = new Vector3(vector3.z, 0f, 0f - vector3.x).normalized;
						}
						if (num21 > 0)
						{
							num = Vector3.Distance(decalSourceEndVecs[num21], decalSourceEndVecs[num21 - 1]);
							num3 += num;
							num9 = Mathf.Lerp(y3, y4, num3 / num20);
						}
						for (int num22 = 0; num22 < list.Count; num22++)
						{
							Vector3 item = decalSourceEndVecs[num21] + normalized * list[num22].x;
							item.y += list[num22].y;
							list3.Add(item);
							list4.Add(new Vector2(list2[num22], num9));
						}
					}
					num11 = decalSourceEndVecs.Count - 1;
					int num23 = num7 + decalSourceStartVecs.Count;
					for (int num24 = 0; num24 < num11; num24 += num12)
					{
						for (int num25 = 0; num25 < count - 1; num25++)
						{
							list8.Add((num24 + num23) * count + num25);
							list8.Add((num24 + num23 + num12) * count + num25 + 1);
							list8.Add((num24 + num23) * count + num25 + 1);
							list8.Add((num24 + num23 + num12) * count + num25);
							list8.Add((num24 + num23 + num12) * count + num25 + 1);
							list8.Add((num24 + num23) * count + num25);
						}
					}
				}
			}
			mesh.Clear();
			mesh.vertices = list3.ToArray();
			mesh.uv = list4.ToArray();
			mesh.triangles = list8.ToArray();
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			mesh.RecalculateTangents();
			go.GetComponent<MeshFilter>().sharedMesh = mesh;
		}

		public static bool InIntArray(int v, List<int> arr)
		{
			for (int i = 0; i < arr.Count; i++)
			{
				if (v == arr[i])
				{
					return true;
				}
			}
			return false;
		}

		public static void ODQCOCCODD(ERModularBase scr)
		{
			string text = "";
			ERModularRoad[] componentsInChildren = scr.gameObject.GetComponentsInChildren<ERModularRoad>();
			ERModularRoad[] array = componentsInChildren;
			foreach (ERModularRoad obj in array)
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
			foreach (GameObject surfaceObject in scr.surfaceObjects)
			{
				UnityEngine.Object.DestroyImmediate(surfaceObject);
			}
			ERSurfaceScript[] componentsInChildren2 = scr.gameObject.GetComponentsInChildren<ERSurfaceScript>();
			ERSurfaceScript[] array2 = componentsInChildren2;
			foreach (ERSurfaceScript eRSurfaceScript in array2)
			{
				UnityEngine.Object.DestroyImmediate(eRSurfaceScript.gameObject);
			}
			ERCrossingPrefabs[] componentsInChildren3 = scr.gameObject.GetComponentsInChildren<ERCrossingPrefabs>();
			ERCrossingPrefabs[] array3 = componentsInChildren3;
			foreach (ERCrossingPrefabs obj2 in array3)
			{
				UnityEngine.Object.DestroyImmediate(obj2);
			}
			ERCrossings[] componentsInChildren4 = scr.gameObject.GetComponentsInChildren<ERCrossings>();
			ERCrossings[] array4 = componentsInChildren4;
			foreach (ERCrossings obj3 in array4)
			{
				UnityEngine.Object.DestroyImmediate(obj3);
			}
			ERRoundabouts[] componentsInChildren5 = scr.gameObject.GetComponentsInChildren<ERRoundabouts>();
			ERRoundabouts[] array5 = componentsInChildren5;
			foreach (ERRoundabouts obj4 in array5)
			{
				UnityEngine.Object.DestroyImmediate(obj4);
			}
			ERConnectionParent[] componentsInChildren6 = scr.gameObject.GetComponentsInChildren<ERConnectionParent>();
			ERConnectionParent[] array6 = componentsInChildren6;
			foreach (ERConnectionParent obj5 in array6)
			{
				UnityEngine.Object.DestroyImmediate(obj5);
			}
			ERTerrain[] array7 = UnityEngine.Object.FindObjectsOfType(typeof(ERTerrain)) as ERTerrain[];
			ERTerrain[] array8 = array7;
			foreach (ERTerrain obj6 in array8)
			{
				UnityEngine.Object.DestroyImmediate(obj6);
			}
			ERSideObjectInstance[] componentsInChildren7 = scr.gameObject.GetComponentsInChildren<ERSideObjectInstance>();
			ERSideObjectInstance[] array9 = componentsInChildren7;
			foreach (ERSideObjectInstance obj7 in array9)
			{
				UnityEngine.Object.DestroyImmediate(obj7);
			}
			ERPrefabInstance[] componentsInChildren8 = scr.gameObject.GetComponentsInChildren<ERPrefabInstance>();
			ERPrefabInstance[] array10 = componentsInChildren8;
			foreach (ERPrefabInstance obj8 in array10)
			{
				UnityEngine.Object.DestroyImmediate(obj8);
			}
			ERSideObjectSection[] componentsInChildren9 = scr.gameObject.GetComponentsInChildren<ERSideObjectSection>();
			ERSideObjectSection[] array11 = componentsInChildren9;
			foreach (ERSideObjectSection obj9 in array11)
			{
				UnityEngine.Object.DestroyImmediate(obj9);
			}
			ERRoadNetworkObject[] componentsInChildren10 = scr.gameObject.GetComponentsInChildren<ERRoadNetworkObject>();
			ERRoadNetworkObject[] array12 = componentsInChildren10;
			foreach (ERRoadNetworkObject obj10 in array12)
			{
				UnityEngine.Object.DestroyImmediate(obj10);
			}
		}

		public static OCDCDDDQOC OQDCQQCCDQ(ERModularRoad road, Vector3 pos, QDQDOOQQDQODD rt, int splineIndex)
		{
			if (rt == null)
			{
				return null;
			}
			GameObject gameObject = new GameObject("Exit Road");
			gameObject.AddComponent<MeshFilter>();
			gameObject.AddComponent<MeshRenderer>();
			gameObject.AddComponent<MeshCollider>();
			gameObject.transform.parent = road.transform;
			gameObject.layer = road.baseScript.sLayer;
			if (rt.roadMaterial == null)
			{
				Debug.LogWarning("EasyRoads3Dv3 Warning: No material is assigned to Motorway ramp: " + rt.roadTypeName);
			}
			else
			{
				gameObject.GetComponent<MeshRenderer>().material = rt.roadMaterial;
			}
			Mesh mesh = new Mesh();
			MeshFilter component = gameObject.GetComponent<MeshFilter>();
			Mesh sharedMesh = (gameObject.GetComponent<MeshCollider>().sharedMesh = mesh);
			component.sharedMesh = sharedMesh;
			gameObject.transform.parent = road.transform;
			OCDCDDDQOC oCDCDDDQOC = gameObject.AddComponent<OCDCDDDQOC>();
			road.exitRoads.Add(oCDCDDDQOC);
			oCDCDDDQOC.road = road;
			oCDCDDDQOC.roadType = rt;
			int num = 0;
			if (road.markersExt.Count > 2)
			{
				for (int i = 0; i < road.markersExt.Count; i++)
				{
					if (road.markersExt[i].startSplinePoint > splineIndex)
					{
						oCDCDDDQOC.markerIndex = i - 1;
						break;
					}
				}
			}
			else
			{
				oCDCDDDQOC.markerIndex = 0;
			}
			float totalDistance = road.markersExt[oCDCDDDQOC.markerIndex].totalDistance;
			float num2 = Vector3.Distance(road.markersExt[oCDCDDDQOC.markerIndex].position, pos);
			float num3 = Vector3.Distance(road.markersExt[oCDCDDDQOC.markerIndex + 1].position, pos);
			oCDCDDDQOC.offset = num2 / (num2 + num3);
			Vector3 pos2 = Vector3.zero;
			int num4 = ODDQOCDCQQ(road.soSplinePoints, oCDCDDDQOC.offset * road.markersExt[oCDCDDDQOC.markerIndex].totalDistance, road.markersExt[oCDCDDDQOC.markerIndex].startSplinePoint, ref pos2);
			oCDCDDDQOC.OQCCCQCQOD = OCOOQOQCDC(road.soSplinePointsRight[num4], road.soSplinePointsRight[num4 + 1], pos);
			oCDCDDDQOC.OQCCCQCQOD = oCDCDDDQOC.OOQODDDCQC();
			float distance = 0.5f * (oCDCDDDQOC.extrusionDistance + oCDCDDDQOC.fixedDistance);
			oCDCDDDQOC.startSplineIndex = GetSplinePointIndex(road.soSplinePoints, distance, num4, -1);
			oCDCDDDQOC.endSplineIndex = GetSplinePointIndex(road.soSplinePoints, distance, num4, 1);
			GameObject gameObject2 = new GameObject("Exit Road Connector");
			ERConnectionParent eRConnectionParent = (ERConnectionParent)UnityEngine.Object.FindObjectOfType(typeof(ERConnectionParent));
			if (eRConnectionParent != null)
			{
				gameObject2.transform.parent = eRConnectionParent.transform;
			}
			oCDCDDDQOC.connector = gameObject2.AddComponent<ERCrossingPrefabs>();
			oCDCDDDQOC.connector.crossingElements.Add(new QDOODOQQDQODD());
			oCDCDDDQOC.connector.isExitRoadConnector = true;
			oCDCDDDQOC.connector.isSnapConnector = true;
			Debug.Log(oCDCDDDQOC);
			return oCDCDDDQOC;
		}

		public static int GetEdgePositionByDistance(List<Vector3> splinePoints, float distance, int startSplinePoint)
		{
			float num = 0f;
			for (int i = startSplinePoint; i < splinePoints.Count - 1; i++)
			{
				float num2 = Vector3.Distance(splinePoints[i], splinePoints[i + 1]);
				if (!(num + num2 > distance))
				{
					num += num2;
				}
			}
			return 0;
		}

		public static int ODDQOCDCQQ(List<Vector3> splinePoints, float distance, int startSplinePoint, ref Vector3 pos)
		{
			float num = 0f;
			for (int i = startSplinePoint; i < splinePoints.Count - 1; i++)
			{
				float num2 = Vector3.Distance(splinePoints[i], splinePoints[i + 1]);
				if (num + num2 > distance)
				{
					Vector3 normalized = (splinePoints[i + 1] - splinePoints[i]).normalized;
					pos = splinePoints[i] + normalized * (distance - num);
					return i;
				}
				num += num2;
			}
			return 0;
		}

		public static int GetSplinePointIndex(List<Vector3> splinePoints, float distance, int startIndex, int dir)
		{
			int result = 0;
			for (int i = startIndex; i < splinePoints.Count && i >= 0; i += dir)
			{
			}
			return result;
		}

		public static float OCCOCQQCCQ(Terrain terrain, Vector3 p1, Vector3 p2)
		{
			if (terrain == null)
			{
				terrain = Terrain.activeTerrain;
			}
			float num = Mathf.Abs(p1.x - p2.x);
			float num2 = Mathf.Abs(p1.z - p2.z);
			float num3;
			float num4;
			if (num > num2)
			{
				num3 = num2 / num;
				num4 = terrain.terrainData.heightmapScale.z;
			}
			else
			{
				num3 = num / num2;
				num4 = terrain.terrainData.heightmapScale.x;
			}
			return num4 * (1f + num3 * 0.5f);
		}

		public static bool RaycastRoadsSurfaces(int layer, Vector3 pos, ref Vector2 uv, ref GameObject go, bool checkHeightFlag)
		{
			LayerMask layerMask = 1 << layer;
			Ray ray = new Ray
			{
				direction = Vector3.down
			};
			Vector3 origin = pos;
			origin.y += 50f;
			ray.origin = origin;
			if (Physics.Raycast(origin, -Vector3.up, out var hitInfo, 500f, layerMask))
			{
				if (hitInfo.point.y < pos.y || !checkHeightFlag)
				{
					uv = hitInfo.textureCoord;
					return true;
				}
				go = hitInfo.collider.gameObject;
				return true;
			}
			return false;
		}

		public static void GetIndexAndFraction(List<Vector3> points, float fraction, int index, float dist, ref int targetIndex, ref float targetFraction, int dir)
		{
			float num = 0f;
			float num2 = 0f;
			bool flag = false;
			int count = points.Count;
			int num3 = 0;
			for (int i = index; i > 0 && i < count; i += dir)
			{
				num3 = i + dir;
				if (num3 <= 0 || num3 >= count)
				{
					continue;
				}
				num2 = Vector3.Distance(points[i + dir], points[i]);
				if (num + num2 > dist)
				{
					if (dir < 0)
					{
						targetIndex = i - 1;
						targetFraction = num2 - (dist - num);
					}
					else
					{
						targetIndex = i;
						targetFraction = dist - num;
					}
					break;
				}
				num += num2;
			}
			if (flag)
			{
			}
		}

		public static ERPoint OOQCQDDQQD(ERPoint source)
		{
			double num = Math.PI / 180.0;
			double a = source.y * num;
			double num2 = Math.Sin(a);
			double num3 = 0.017453292519943;
			double num4 = 6378137.0;
			double y = num4 / 2.0 * Math.Log((1.0 + num2) / (1.0 - num2));
			double x = source.x * num3 * num4;
			return new ERPoint(x, y);
		}

		public static void MergeVertices(Mesh m)
		{
			Vector3[] vertices = m.vertices;
			Vector2[] uv = m.uv;
			int[] triangles = m.triangles;
			Color[] colors = m.colors;
			List<Vector3> list = new List<Vector3>();
			List<Color> list2 = new List<Color>();
			List<Vector2> list3 = new List<Vector2>();
			for (int i = 0; i < vertices.Length; i++)
			{
				int num = in_array(list, list2, vertices[i], colors[i]);
				if (num == -1)
				{
					list.Add(vertices[i]);
					list2.Add(colors[i]);
					list3.Add(uv[i]);
					num = list.Count - 1;
				}
				for (int j = 0; j < triangles.Length; j++)
				{
					if (triangles[j] == i)
					{
						triangles[j] = num;
					}
				}
			}
			m.Clear();
			m.vertices = list.ToArray();
			m.colors = list2.ToArray();
			m.uv = list3.ToArray();
			m.triangles = triangles;
			m.RecalculateNormals();
			m.RecalculateTangents();
		}

		public static float OCODCQDDCD(Vector3 startPos, Vector3 endPos, Vector3 dirPos1, Vector3 dirPos2, float curDist, float minValue, bool surrounding)
		{
			float num = 0f;
			Vector3 normalized = (dirPos1 - dirPos2).normalized;
			Vector3 vector = startPos + normalized * 1000f;
			Vector3 vA = startPos + normalized * -1000f;
			Vector3 b = OCOOQOQCDC(vA, vector, endPos);
			float num2 = Vector3.Distance(startPos, b);
			float num3 = Vector3.Distance(vector, b);
			float num4 = Vector3.Distance(vector, startPos);
			if (num3 > num4)
			{
				curDist -= num2;
				if (curDist < minValue)
				{
					curDist = 0f;
				}
			}
			else
			{
				curDist += num2;
			}
			return curDist;
		}

		public static int in_array(List<Vector3> vecs, List<Color> colors, Vector3 v, Color c)
		{
			for (int i = 0; i < vecs.Count; i++)
			{
				if (vecs[i] == v && colors[i] == c)
				{
					return i;
				}
			}
			return -1;
		}

		public static bool Vector2ListComparer(List<Vector2> list1, List<Vector2> list2)
		{
			List<Vector2> source = list1.Except(list2).ToList();
			List<Vector2> source2 = list2.Except(list1).ToList();
			return !source.Any() && !source2.Any();
		}

		public static bool FloatListComparer(List<float> list1, List<float> list2)
		{
			List<float> source = list1.Except(list2).ToList();
			List<float> source2 = list2.Except(list1).ToList();
			return !source.Any() && !source2.Any();
		}

		public static Mesh GameObjectInit(ref GameObject go, string name, Transform parent, Material mat)
		{
			if (go == null)
			{
				go = new GameObject(name);
				go.transform.parent = parent;
			}
			if (go.GetComponent<MeshRenderer>() == null)
			{
				go.AddComponent<MeshRenderer>();
			}
			if (mat != null && go.GetComponent<MeshRenderer>().sharedMaterial != mat)
			{
				go.GetComponent<MeshRenderer>().sharedMaterial = mat;
			}
			if (go.GetComponent<MeshFilter>() == null)
			{
				go.AddComponent<MeshFilter>();
			}
			Mesh mesh = go.GetComponent<MeshFilter>().sharedMesh;
			if (mesh == null)
			{
				mesh = new Mesh();
			}
			mesh.Clear();
			return mesh;
		}

		public static Texture GetMaterialTexture(Material m)
		{
			Texture texture = m.mainTexture;
			if (texture == null && m.HasProperty("_Diffuse") && m.GetTexture("_Diffuse") != null)
			{
				texture = m.GetTexture("_Diffuse");
			}
			return texture;
		}

		public static List<int> Triangulate(List<Vector3> vecs, List<Vector3> edges)
		{
			List<Vector2> list = new List<Vector2>();
			List<PointER> list2 = new List<PointER>();
			for (int i = 0; i < vecs.Count; i++)
			{
				Vector3 vector = vecs[i];
				list2.Add(new PointER(vector.x, vector.z, 0f));
			}
			for (int j = 0; j < edges.Count; j++)
			{
				Vector3 vector = edges[j];
				list.Add(new Vector2(vector.x, vector.z));
			}
			List<int> list3 = new List<int>();
			List<int> list4 = new List<int>();
			List<TriangleER> list5 = delaunayER.Triangulate(list2);
			for (int k = 0; k < list5.Count; k++)
			{
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex1.x, list5[k].Vertex1.z, list5[k].Vertex1.y), vecs));
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex3.x, list5[k].Vertex3.z, list5[k].Vertex3.y), vecs));
				list3.Add(delaunayER.FindVertice(new Vector3(list5[k].Vertex2.x, list5[k].Vertex2.z, list5[k].Vertex2.y), vecs));
			}
			for (int l = 0; l < list3.Count; l += 3)
			{
				if (list.Count == 0)
				{
					list4.Add(list3[l]);
					list4.Add(list3[l + 1]);
					list4.Add(list3[l + 2]);
					continue;
				}
				Vector3 vector2 = (vecs[list3[l]] + vecs[list3[l + 1]] + vecs[list3[l + 2]]) / 3f;
				if (OQOQOOCDCC.OCDCDOCQCQ(list.Count, list, vector2.x, vector2.z))
				{
					list4.Add(list3[l]);
					list4.Add(list3[l + 1]);
					list4.Add(list3[l + 2]);
				}
			}
			return list4;
		}

		public static uint GetLayerMask(int index, bool includeDefault)
		{
			int[] array = new int[16]
			{
				1, 2, 4, 8, 16, 32, 64, 128, 256, 512,
				1024, 2048, 4096, 8192, 16384, 32768
			};
			uint num = 0u;
			num = ((index == 0) ? 1u : ((uint)array[index - 1]));
			if (includeDefault && index != 0)
			{
				num++;
			}
			return num;
		}
	}
}
