using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OCQCDQCQOQ : MonoBehaviour
	{
		public static Vector3 OCDCDCDCQD(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
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
			return new Vector3(x, p1.y, z);
		}

		public static float OQOQQQQCQD(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p)
		{
			float x = p.x;
			float z = p.z;
			float num = (p2.z - p3.z) * (p1.x - p3.x) + (p3.x - p2.x) * (p1.z - p3.z);
			float num2 = ((p2.z - p3.z) * (x - p3.x) + (p3.x - p2.x) * (z - p3.z)) / num;
			float num3 = ((p3.z - p1.z) * (x - p3.x) + (p1.x - p3.x) * (z - p3.z)) / num;
			float num4 = 1f - num2 - num3;
			return num2 * p1.y + num3 * p2.y + num4 * p3.y;
		}

		public static bool OOOOCDQQOC(Vector3 pTarget, Vector3 pSource, Vector3 pCheck)
		{
			Vector3 normalized = (pTarget - pSource).normalized;
			Vector3 normalized2 = (pCheck - pSource).normalized;
			if (Vector3.Cross(normalized, normalized2).y < 0f)
			{
				return false;
			}
			return true;
		}

		public static Vector3 OQQQDCODQD(Vector3 vA, Vector3 vB, Vector3 vPoint)
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

		public static Vector3 OCQDOQQQOD(Vector3 point, Vector3 pivot, Quaternion angle)
		{
			Vector3 vector = point - pivot;
			vector = angle * vector;
			return vector + pivot;
		}

		public static int OQOQDQCODD(List<Material> mats, Material mat)
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

		public static float OCQDCQCOQQ(Vector3 fwd, Vector3 targetDir, Vector3 up)
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

		public static bool OQCOCOCOQO(GameObject go, ref Bounds bounds)
		{
			Renderer component = go.GetComponent<Renderer>();
			if (component != null)
			{
				bounds = component.bounds;
				return true;
			}
			foreach (Transform item in go.transform)
			{
				component = item.GetComponent<Renderer>();
				if (component != null && component.bounds.size.z > bounds.size.z)
				{
					bounds = component.bounds;
				}
			}
			if (bounds.size.z > 0f)
			{
				return true;
			}
			return false;
		}

		public static float OOOQQOODDD(Vector3 pos, ERModularBase scr)
		{
			if (!scr.isInBuildMode)
			{
				LayerMask layerMask = int.MinValue;
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
					scr.OCCDCQCOQC(ref pos);
				}
			}
			else
			{
				scr.OCCDCQCOQC(ref pos);
			}
			return pos.y;
		}

		public static Vector3 OCCQQCOQCD(Vector3 pos, ERModularRoad scr)
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

		public static int ODOQDCOOOQ(int segmentCount, SideObject so, bool newSegment, ERMesh mobject, bool lastSegment, bool skipStartBlend, bool skipEndBlend)
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

		public static void OQOCCODDQQ(ref Vector3 v2, Vector3 v, Vector3 dir, Vector2 vec, ERModularRoad roadScr, Vector3 randomRotation)
		{
			Vector3 vector = roadScr.baseScript.ODQQCDQCQO(v);
			Vector3 vector2 = dir - Vector3.Dot(dir, vector) * vector;
			if (vector2 != Vector3.zero)
			{
				Quaternion quaternion = Quaternion.LookRotation(vector2, vector);
				Vector3 eulerAngles = ODQCQOODDO.GetEulerAngles(dir);
				v2 = ODQCQOODDO.OQDDQDOQQQ(v, vec, 180f + quaternion.eulerAngles.z + randomRotation.x, eulerAngles);
			}
		}

		public static void OQQCCQCQQC(ref Vector3 v2, Vector3 v, Vector3 dir, Vector2 vec, float angle, Vector3 randomRotation)
		{
			Vector3 eulerAngles = ODQCQOODDO.GetEulerAngles(dir);
			v2 = ODQCQOODDO.OQDDQDOQQQ(v, vec, 180f - angle + randomRotation.x, eulerAngles);
		}

		public static void RandomAlignment(ref Vector3 v2, Vector3 v, Vector3 dir, Vector2 vec, Vector3 randomRotation)
		{
			dir = new Vector3(dir.x, 0f, dir.z).normalized;
			Vector3 eulerAngles = ODQCQOODDO.GetEulerAngles(dir);
			v2 = ODQCQOODDO.OQDDQDOQQQ(v, vec, 180f + randomRotation.x, eulerAngles);
		}

		public static void OQOCDQCDCQ(GameObject go, Vector3 v, ERModularRoad roadScr, Vector3 randomRotation)
		{
			Vector3 vector = roadScr.baseScript.ODQQCDQCQO(v);
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

		public static void OODCQODDQQ(GameObject go, Vector3 v1, Vector3 v3, Vector3 dir, Vector3 randomRotation)
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

		public static void ODQOQDCQDC(GameObject go, Vector3 v1, ERModularRoad roadScr, Vector3 randomRotation)
		{
			Vector3 vector = OCCQQCOQCD(v1, roadScr);
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

		public static bool RayTriangleOCDCDCDCQD(Vector3 p1, Vector3 p2, Vector3 p3, Ray ray)
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

		public static void ODOCDDQCQQ(ERModularBase scr, Vector3 v1, Vector3 v2, ref float minY, ref float maxY)
		{
			float num = Vector3.Distance(v1, v2);
			float num2 = 1f / (num / 0.5f);
			float num3 = 0f;
			for (float num4 = 0f; num4 <= 1f; num4 += num2)
			{
				num3 = OOOQQOODDD(Vector3.Lerp(v1, v2, num4), scr);
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
					Vector3 vector2 = ERModularRoad.OQODDDCOQD(list[j - 1], list[j], list[j + 1], list[j + 2], num5, 0.5f);
					if (Vector3.Distance(a, vector2) > 1f || (j == 1 && num5 == 0f))
					{
						list5.Add(vector2);
						num3 += Vector3.Distance(a, vector2);
						a = vector2;
						if (!OOOOCDQQOC(list4[num2], list3[num2], vector2))
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
			for (int j = startMarker; j < endMarker; j++)
			{
				list4.Add(shapeTransitionTypes[j - startMarker]);
				for (int i = 0; i < roadShape.Count; i++)
				{
					Vector3 item = new Vector3(markerDistances[j - startMarker], nodeListValues[j][i].x, 0f);
					list2[i].Add(item);
					item = new Vector3(markerDistances[j - startMarker], nodeListValues[j][i].y, 0f);
					list3[i].Add(item);
				}
			}
			for (int i = 0; i < list2.Count; i++)
			{
				if (!closedTrack)
				{
					list2[i].Insert(0, list2[i][0]);
					list2[i].Add(list2[i][list2[i].Count - 1]);
				}
				else
				{
					list2[i].Insert(0, list2[i][list2[i].Count - 2]);
					list2[i].Add(list2[i][2]);
				}
				if (!closedTrack)
				{
					list3[i].Insert(0, list3[i][0]);
					list3[i].Add(list3[i][list3[i].Count - 1]);
				}
				else
				{
					list3[i].Insert(0, list3[i][list3[i].Count - 2]);
					list3[i].Add(list3[i][2]);
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
			for (int i = 0; i < roadShape.Count; i++)
			{
				list.Add(new List<Vector2>());
			}
			int num = 0;
			int k = 1;
			bool flag2 = false;
			for (; k < list2[0].Count - 2; k++)
			{
				while (!flag2)
				{
					if (num < tValues.Count)
					{
						for (int i = 0; i < roadShape.Count; i++)
						{
							Vector3 vector;
							Vector3 vector2;
							if (list4[k] == 0f)
							{
								vector = ERModularRoad.OQODDDCOQD(list2[i][k - 1], list2[i][k], list2[i][k + 1], list2[i][k + 2], tValues[num], 0.5f);
								vector2 = ERModularRoad.OQODDDCOQD(list3[i][k - 1], list3[i][k], list3[i][k + 1], list3[i][k + 2], tValues[num], 0.5f);
							}
							else if (list4[k] == 1f)
							{
								vector = Vector3.Lerp(list2[i][k], list2[i][k + 1], Mathf.SmoothStep(0f, 1f, tValues[num]));
								vector2 = Vector3.Lerp(list3[i][k], list3[i][k + 1], Mathf.SmoothStep(0f, 1f, tValues[num]));
							}
							else
							{
								vector = Vector3.Lerp(list2[i][k], list2[i][k + 1], tValues[num]);
								vector2 = Vector3.Lerp(list3[i][k], list3[i][k + 1], tValues[num]);
							}
							list[i].Add(new Vector2(vector.y, vector2.y));
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
						if (OCQQCCQCCO.GetSidewaysPosition(scr, scr.markersExt[marker].soData[scr.selectedSO].sideObject, ref sidewaysList, ref customNodelistFlag, ref nodeListValues, ref shapeTransitionTypes))
						{
							soMarkerVecs = GetSoMarkerPositionVecs(scr, sidewaysList, ref soMarkerDir, ref soMarkerInt);
							if (scr.markersExt[marker].soData[scr.selectedSO].sideObject.snapToTerrain)
							{
								for (int i = 0; i < soMarkerVecs.Count; i++)
								{
									Vector3 vector = soMarkerVecs[i];
									vector.y = OOOQQOODDD(vector, scr.baseScript);
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
				float num9;
				float num10;
				int num11;
				int num12;
				int num13;
				int num14;
				int num15;
				if (zero.x >= num4 && zero.x < num6 && zero.z >= num5 && zero.z <= z2 + num7)
				{
					num9 = (zero.x - position.x) / terrainData.size.x;
					num10 = (zero.z - position.z) / terrainData.size.z;
					num11 = Convert.ToInt32(num9 * (float)terrainData.heightmapResolution) - num - smoothStep;
					num12 = Convert.ToInt32(num10 * (float)terrainData.heightmapResolution) - num2 - smoothStep;
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
					num13 = 0;
					num14 = 0;
					num15 = 0;
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
									num16 = Mathf.Lerp(num16, Smooth(l + num11, k + num12, terrainData), t);
								}
								else
								{
									num16 = Mathf.Lerp(num16, (leftIndentVecs[j].y - position.y) / y, Smooth1(leftIndentVecs[j].y, leftSurroundingVecs[j].y, num16 * y + position.y));
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
				if (!(zero.x >= num4) || !(zero.x < num6) || !(zero.z >= num5) || !(zero.z <= z2 + num7))
				{
					continue;
				}
				num9 = (zero.x - position.x) / terrainData.size.x;
				num10 = (zero.z - position.z) / terrainData.size.z;
				num11 = Convert.ToInt32(num9 * (float)terrainData.heightmapResolution) - num;
				num12 = Convert.ToInt32(num10 * (float)terrainData.heightmapResolution) - num2;
				num13 = 0;
				num14 = 0;
				num15 = 0;
				for (int k = 0; k < 2 * num2; k++)
				{
					for (int l = 0; l < 2 * num; l++)
					{
						num14 = k + num12;
						num15 = l + num11;
						if (heightmapResolution2 <= num15 || heightmapResolution3 <= num14)
						{
							continue;
						}
						float num16 = heights[num14, num15];
						flag = true;
						if (!array2[k + num12, l + num11] && flag && array3[(k + num12) * heightmapResolution + l + num11] != 2)
						{
							if (type != 0)
							{
								num16 = Mathf.Lerp(num16, Smooth(l + num11, k + num12, terrainData), t);
							}
							else
							{
								num16 = Mathf.Lerp(num16, (rightIndentVecs[j].y - position.y) / y, Smooth1(rightIndentVecs[j].y, rightSurroundingVecs[j].y, num16 * y + position.y));
								array2[k + num12, l + num11] = true;
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
			terrainData.SetHeights(0, 0, heights);
		}

		public static bool CheckSmoothPoint(int x, int z, float sampleWidth, float sampleHeight, ERModularBase scr)
		{
			bool result = true;
			Vector3 pos = Vector3.zero;
			pos.x = Terrain.activeTerrain.gameObject.transform.position.x + (float)x * sampleWidth;
			pos.z = Terrain.activeTerrain.gameObject.transform.position.z + (float)z * sampleHeight;
			scr.OCCDCQCOQC(ref pos);
			LayerMask layerMask = int.MinValue;
			pos.y += 20f;
			if (Physics.Raycast(pos, -Vector3.up, out var _, 30f, layerMask))
			{
				result = false;
			}
			return result;
		}

		private static float Smooth(int x, int y, TerrainData terrainInfo)
		{
			float num = 0f;
			float num2 = 1f / terrainInfo.size.y;
			num += terrainInfo.GetHeight(x, y) * num2;
			num += terrainInfo.GetHeight(x + 1, y) * num2;
			num += terrainInfo.GetHeight(x - 1, y) * num2;
			num += terrainInfo.GetHeight(x + 1, y + 1) * num2 * 0.75f;
			num += terrainInfo.GetHeight(x - 1, y + 1) * num2 * 0.75f;
			num += terrainInfo.GetHeight(x + 1, y - 1) * num2 * 0.75f;
			num += terrainInfo.GetHeight(x - 1, y - 1) * num2 * 0.75f;
			num += terrainInfo.GetHeight(x, y + 1) * num2;
			num += terrainInfo.GetHeight(x, y - 1) * num2;
			return num / 8f;
		}

		private static float Smooth1(float indent, float surrounding, float posY)
		{
			float num = 1f - Mathf.Abs(indent - posY) / Mathf.Abs(indent - surrounding);
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

		public static void ODCQQDODDC(Mesh m, MeshRenderer ren)
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
				bool flag = false;
				for (int k = 0; k < j; k++)
				{
					if (sharedMaterials[j] == sharedMaterials[k])
					{
						flag = true;
						list2[k].AddRange(m.GetTriangles(j));
						break;
					}
				}
				if (!flag)
				{
					list2.Add(new List<int>(m.GetTriangles(j)));
				}
			}
			ren.sharedMaterials = list.ToArray();
			m.subMeshCount = list.Count;
			for (int j = 0; j < list2.Count; j++)
			{
				m.SetTriangles(list2[j].ToArray(), j);
			}
		}

		public static List<float> ODQCODDDDC(List<Vector2> nodes)
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
			for (int i = 0; i < nodes.Count; i++)
			{
				list2.Add(list[i] / num);
			}
			return list2;
		}

		public List<Vector2> OCODCDDCQC(List<Vector3> vecs, float x)
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

		public static void OODCCQCQCC(ERModularBase scr)
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
		}
	}
}
