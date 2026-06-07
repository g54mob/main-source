using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class OQQOCDQCQDExt : MonoBehaviour
	{
		public static void OOODDOCDCD(ERModularBase scr)
		{
			ERCrossings[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERCrossings)) as ERCrossings[];
			int num = 0;
			ERCrossings[] array2 = array;
			foreach (ERCrossings eRCrossings in array2)
			{
				num++;
				try
				{
					if (!OQQCQDQDCC.CheckRoadTypeChanges(scr, eRCrossings.prefabScript, ercrossing: true, erroundabout: false))
					{
						eRCrossings.OQDCCQOCCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
					}
				}
				catch
				{
					Debug.Log("Refresh failed: " + eRCrossings.gameObject.name);
				}
			}
			ERRoundabouts[] array3 = UnityEngine.Object.FindObjectsOfType(typeof(ERRoundabouts)) as ERRoundabouts[];
			num = 0;
			ERRoundabouts[] array4 = array3;
			foreach (ERRoundabouts eRRoundabouts in array4)
			{
				num++;
				try
				{
					if (OQQCQDQDCC.CheckRoadTypeChanges(scr, eRRoundabouts.prefabScript, ercrossing: false, erroundabout: true))
					{
						continue;
					}
					eRRoundabouts.OOODQQDOOD();
					eRRoundabouts.OCODQOOOCQ();
					if (eRRoundabouts.leftFlag && eRRoundabouts.rightFlag)
					{
						eRRoundabouts.OCOCDCDDOD();
						if (eRRoundabouts.connections.Count > 0)
						{
							eRRoundabouts.OCCCDCOOOC();
						}
					}
				}
				catch
				{
					Debug.Log("Refresh failed: " + eRRoundabouts.gameObject.name);
				}
			}
			ERCrossingPrefabs[] array5 = UnityEngine.Object.FindObjectsOfType(typeof(ERCrossingPrefabs)) as ERCrossingPrefabs[];
			num = 0;
			ERCrossingPrefabs[] array6 = array5;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array6)
			{
				num++;
				try
				{
					eRCrossingPrefabs.ODCQOCQODQ(forceFlag: true);
				}
				catch
				{
				}
			}
			ERModularRoad[] array7 = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
			num = 0;
			ERModularRoad[] array8 = array7;
			foreach (ERModularRoad eRModularRoad in array8)
			{
				num++;
				try
				{
					if (eRModularRoad.markersExt.Count <= 1)
					{
						UnityEngine.Object.DestroyImmediate(eRModularRoad.gameObject);
						continue;
					}
					eRModularRoad.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
					Transform transform = eRModularRoad.transform.Find("treesERMesh");
					while (transform != null)
					{
						UnityEngine.Object.DestroyImmediate(transform.gameObject);
						transform = eRModularRoad.transform.Find("treesERMesh");
					}
					transform = eRModularRoad.transform.Find("detailERMesh");
					while (transform != null)
					{
						UnityEngine.Object.DestroyImmediate(transform.gameObject);
						transform = eRModularRoad.transform.Find("detailERMesh");
					}
				}
				catch
				{
					Debug.Log("Refresh failed: " + eRModularRoad.gameObject.name);
				}
			}
			ERSideObjectInstance[] array9 = UnityEngine.Object.FindObjectsOfType(typeof(ERSideObjectInstance)) as ERSideObjectInstance[];
			num = 0;
			ERSideObjectInstance[] array10 = array9;
			foreach (ERSideObjectInstance eRSideObjectInstance in array10)
			{
				num++;
				if (!(eRSideObjectInstance.so != null))
				{
					continue;
				}
				ERModularRoad component = eRSideObjectInstance.transform.parent.GetComponent<ERModularRoad>();
				bool flag = false;
				try
				{
					for (int n = 0; n < component.soDataExt.Count; n++)
					{
						if (component.soDataExt[n].sideObject.id == eRSideObjectInstance.so.id && component.soDataExt[n].active)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						OCQODDCQDD.OOOQQQOOQC(scr, component, eRSideObjectInstance.so, updateSideObjectsOnOtherRoadObjects: false);
						continue;
					}
					Debug.LogWarning("EasyRoads3Dv3 warning: the side object " + eRSideObjectInstance.so.name + " (game object ) exists while this side object is currently not active for this road: road name: " + component.gameObject.name + ". The side object has been removed.");
					UnityEngine.Object.DestroyImmediate(eRSideObjectInstance.gameObject);
				}
				catch
				{
					Debug.LogWarning("EasyRoads3Dv3 warning: the side object " + eRSideObjectInstance.so.name + " (game object ) exists while this side object currently does not exist in road object: " + component.gameObject.name);
				}
			}
		}

		public static string[] OOOODQQQCQ(ERModularRoad scr, string[] prefabs, ref ERCrossingPrefabs[] prefs, int type)
		{
			if (scr == null)
			{
				return null;
			}
			GameObject gameObject = null;
			List<string> list = new List<string>();
			List<ERCrossingPrefabs> list2 = new List<ERCrossingPrefabs>();
			bool flag = true;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (scr.startPrefabScript != null || scr.endPrefabScript != null)
			{
				flag = false;
				if (scr.startPrefabScript != null && scr.startPrefabScript.crossingElements.Count > scr.startConnectionSegment && scr.startConnectionSegment >= 0)
				{
					num = scr.startPrefabScript.crossingElements[scr.startConnectionSegment].roadShapeMatchCount;
					num2 = scr.startPrefabScript.prefabId;
				}
				if (scr.endPrefabScript != null && scr.endPrefabScript.crossingElements.Count > scr.endConnectionSegment && scr.endConnectionSegment >= 0)
				{
					num = scr.endPrefabScript.crossingElements[scr.endConnectionSegment].roadShapeMatchCount;
					num3 = scr.endPrefabScript.prefabId;
				}
			}
			for (int i = 0; i < prefabs.Length; i++)
			{
				if (type == 1)
				{
					gameObject = Resources.Load("custom prefabs/" + prefabs[i]) as GameObject;
					string text = "custom prefabs/";
				}
				else
				{
					gameObject = Resources.Load("dynamic prefabs/" + prefabs[i]) as GameObject;
					string text = "dynamic prefabs/";
				}
				if (!(gameObject != null))
				{
					continue;
				}
				ERCrossingPrefabs component = gameObject.GetComponent<ERCrossingPrefabs>();
				if (!(component != null) || !(gameObject.GetComponent<ERRoundabouts>() == null))
				{
					continue;
				}
				for (int j = 0; j < component.crossingElements.Count; j++)
				{
					bool flag2 = false;
					if (component.crossingElements[j].roadType == scr.roadType)
					{
						flag2 = true;
						if (num != 0 && num2 != component.prefabId && num3 != component.prefabId && num != component.crossingElements[j].roadShapeMatchCount)
						{
							flag2 = false;
						}
					}
					if (flag2 || scr.roadShapeMatchCount == component.crossingElements[j].roadShapeMatchCount || scr.roadShapeMatchCount == 0 || (component.crossingElements[j].roadShapeMatchCount == 0 && flag))
					{
						list.Add(prefabs[i]);
						list2.Add(component);
						break;
					}
				}
			}
			if (list.Count == 0)
			{
				list.Add("No matches Found");
			}
			prefs = list2.ToArray();
			return list.ToArray();
		}

		public static bool ODQDDQODCC(ERModularRoad road, ref bool left, ref bool right)
		{
			QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(road.baseScript.roadTypes, road.roadType);
			if (roadTypeElByID != null)
			{
				if (road.roadShape.Count <= 1 || roadTypeElByID.roadShape.Count <= 1)
				{
					return false;
				}
				if (roadTypeElByID.roadWidth != road.roadWidth)
				{
					if (-1f * road.roadShape[0].x < roadTypeElByID.roadShape[0].x && -1f * road.roadShape[1].x < roadTypeElByID.roadShape[0].x)
					{
						left = true;
					}
					if (-1f * road.roadShape[road.roadShape.Count - 1].x > roadTypeElByID.roadShape[roadTypeElByID.roadShape.Count - 1].x && -1f * road.roadShape[road.roadShape.Count - 2].x > roadTypeElByID.roadShape[roadTypeElByID.roadShape.Count - 1].x)
					{
						right = true;
					}
				}
				return true;
			}
			return false;
		}

		public static bool OOCQOCCCDQ(ERCrossingPrefabs prefab, ERModularRoad road, int marker, int connection)
		{
			if (prefab.isCustomPrefab || prefab.isIConnector)
			{
				return false;
			}
			if (prefab.sidewalkControlElements.Count != prefab.crossingElements.Count)
			{
				Debug.LogError("EasyRoads3Dv3: Sidewalk data is not valid for the following connection prefab: " + prefab.gameObject.name);
				return false;
			}
			if (marker == 0)
			{
				if (road.endPrefabScript != null && road.endPrefabScript.isCustomPrefab)
				{
					return false;
				}
			}
			else if (road.startPrefabScript != null && road.startPrefabScript.isCustomPrefab)
			{
				return false;
			}
			prefab.ODCQOOCOQQ(flag: false);
			bool left = false;
			bool right = false;
			if (!ODQDDQODCC(road, ref left, ref right))
			{
				return false;
			}
			if (marker == 0)
			{
				bool flag = left;
				left = right;
				right = flag;
			}
			bool flag2 = false;
			if (left || right)
			{
				flag2 = true;
			}
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			switch (connection)
			{
			case 0:
				num = 1;
				num2 = 2;
				num3 = 3;
				break;
			case 1:
				num = 0;
				num2 = 3;
				num3 = 2;
				break;
			case 2:
				num = 3;
				num2 = 1;
				num3 = 0;
				break;
			case 3:
				num = 2;
				num2 = 0;
				num3 = 1;
				break;
			}
			bool flag6 = left;
			bool flag7 = right;
			for (int i = 0; i < prefab.sidewalkControlElements.Count; i++)
			{
				int crossingElementLeftIndex = prefab.sidewalkControlElements[i].crossingElementLeftIndex;
				int crossingElementRightIndex = prefab.sidewalkControlElements[i].crossingElementRightIndex;
				bool flag8 = false;
				flag8 = ((left == right) ? (flag6 = (flag7 = left)) : ((crossingElementLeftIndex != connection) ? ((crossingElementLeftIndex != num) ? ((crossingElementLeftIndex != num2) ? right : left) : right) : left));
				prefab.sidewalkControlElements[i].renderFlag = flag8;
				prefab.sidewalkControlElements[i].leftConnectionHandle = flag8;
				prefab.crossingElements[prefab.sidewalkControlElements[i].crossingElementLeftIndex].includeLeftSidewalk = flag8;
				prefab.sidewalkControlElements[i].rightConnectionHandle = flag8;
				prefab.crossingElements[prefab.sidewalkControlElements[i].crossingElementRightIndex].includeRightSidewalk = flag8;
			}
			if ((bool)prefab.gameObject.GetComponent<ERCrossings>())
			{
				prefab.gameObject.GetComponent<ERCrossings>().OQDCCQOCCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
			}
			return true;
		}

		public static bool OCQDQQQODO(ERCrossingPrefabs prefab, ERModularRoad road, int marker, int connection)
		{
			return true;
		}

		public static List<int> OCCDQCCQDC(Vector3[] meshVecsV3, int[] tris, int version, ref List<int> edgeGroupsInts, bool debugGroupCount = false)
		{
			List<CRedge> edges = new List<CRedge>();
			for (int i = 0; i < tris.Length; i += 3)
			{
				if (!OQDOCQDCOO(ref edges, tris[i], tris[i + 1]))
				{
					edges.Add(new CRedge(tris[i], tris[i + 1]));
				}
				if (!OQDOCQDCOO(ref edges, tris[i], tris[i + 2]))
				{
					edges.Add(new CRedge(tris[i], tris[i + 2]));
				}
				if (!OQDOCQDCOO(ref edges, tris[i + 1], tris[i + 2]))
				{
					edges.Add(new CRedge(tris[i + 1], tris[i + 2]));
				}
			}
			List<int> list = new List<int>();
			List<CRedge> list2 = new List<CRedge>();
			for (int j = 0; j < edges.Count; j++)
			{
				if (edges[j].count == 1)
				{
					if (OOODDQDDOO(list, edges[j].v1))
					{
						list.Add(edges[j].v1);
					}
					if (OOODDQDDOO(list, edges[j].v2))
					{
						list.Add(edges[j].v2);
					}
					list2.Add(edges[j]);
				}
			}
			if (list.Count == 0)
			{
				Debug.Log("edge array is empty: harmless for procedural mesh side object types");
				return null;
			}
			List<int> list3 = new List<int>();
			list3.AddRange(list);
			float num = 100000f;
			int num2 = 0;
			for (int k = 0; k < list.Count; k++)
			{
				if (meshVecsV3[list[k]].x < num)
				{
					num = meshVecsV3[list[k]].x;
					num2 = k;
				}
			}
			List<int> range = list.GetRange(num2, list.Count - num2);
			List<int> range2 = list.GetRange(0, num2);
			list = new List<int>(range);
			list.AddRange(range2);
			List<List<int>> list4 = new List<List<int>>();
			list4.Add(new List<int>());
			int num3 = -1;
			int num4 = list[0];
			list4[0].Add(num4);
			int num5 = list[0];
			bool flag = false;
			int num6 = 0;
			bool flag2 = false;
			int num7 = 0;
			int num8 = 0;
			while (!flag)
			{
				flag2 = true;
				for (int l = 0; l < list2.Count; l++)
				{
					if (list2[l].v1 == num5)
					{
						num3 = num5;
						num5 = list2[l].v2;
						if (num5 != num4)
						{
							list4[num6].Add(num5);
						}
						list2.RemoveAt(l);
						flag2 = false;
						break;
					}
					if (list2[l].v2 == num5)
					{
						num3 = num5;
						num5 = list2[l].v1;
						if (num5 != num4)
						{
							list4[num6].Add(num5);
						}
						list2.RemoveAt(l);
						flag2 = false;
						break;
					}
				}
				num7 = list.Count;
				for (int m = 0; m < list.Count; m++)
				{
					if (list[m] == num3)
					{
						list.RemoveAt(m);
						break;
					}
				}
				if (list.Count == 0 || list2.Count == 0)
				{
					flag = true;
				}
				else if (num5 == num4 || flag2)
				{
					if (flag2)
					{
						list4[num6].Add(num5);
						for (int n = 0; n < list.Count; n++)
						{
							if (list[n] == num5)
							{
								list.RemoveAt(n);
								break;
							}
						}
					}
					if (list2.Count > 0)
					{
						num6++;
						list4.Add(new List<int>());
						num3 = -1;
						num4 = list[0];
						list4[num6].Add(num4);
						num5 = list[0];
						flag = false;
					}
					flag2 = false;
				}
				num8 = ((num7 == list.Count) ? (num8 + 1) : 0);
				if (num8 > 1000)
				{
					Debug.Log("EasyRoads3Dv3 Alert: extracting edge vertices failed. Please check the manual and verify whether this mesh meets the requirements. Or email us for feedback. (Count: " + num8 + ")");
					return null;
				}
			}
			int index = 0;
			if (list4.Count > 1)
			{
				float num9 = -100000f;
				float num10 = 100000f;
				float num11 = -100000f;
				float num12 = 100000f;
				float num13 = -100000f;
				float num14 = 100000f;
				float num15 = -100000f;
				float num16 = 100000f;
				for (int num17 = 0; num17 < list4.Count; num17++)
				{
					for (int num18 = 0; num18 < list4[num17].Count; num18++)
					{
						if (meshVecsV3[list4[num17][num18]].x < num14)
						{
							num14 = meshVecsV3[list4[num17][num18]].x;
						}
						if (meshVecsV3[list4[num17][num18]].x > num13)
						{
							num13 = meshVecsV3[list4[num17][num18]].x;
						}
						if (meshVecsV3[list4[num17][num18]].z < num16)
						{
							num16 = meshVecsV3[list4[num17][num18]].z;
						}
						if (meshVecsV3[list4[num17][num18]].z > num15)
						{
							num15 = meshVecsV3[list4[num17][num18]].z;
						}
					}
					if (num14 < num10 && num13 > num9 && num16 < num12 && num15 > num11)
					{
						num9 = num13;
						num10 = num14;
						num11 = num15;
						num12 = num12;
						index = num17;
					}
				}
			}
			if (debugGroupCount && list4.Count > 1)
			{
				Debug.Log("EasyRoads3Dv3: Multiple edge groups detected while extracting tunnel edges (" + list4.Count + ")");
			}
			List<int> list5 = new List<int>();
			if (version == 0)
			{
				list4[index].Add(list4[index][0]);
				if (!ODODCDQQCQ(list4[index], meshVecsV3))
				{
					list4[index].Reverse();
				}
				list4[index].RemoveAt(list4[index].Count - 1);
				list5.AddRange(list4[index]);
			}
			else
			{
				edgeGroupsInts.Clear();
				for (int num19 = 0; num19 < list4.Count; num19++)
				{
					list4[num19].Add(list4[num19][0]);
					if (!ODODCDQQCQ(list4[num19], meshVecsV3))
					{
						list4[num19].Reverse();
					}
					list4[num19].RemoveAt(list4[num19].Count - 1);
					list5.AddRange(list4[num19]);
					edgeGroupsInts.Add(list5.Count);
				}
			}
			return list5;
		}

		public static bool OQDOCQDCOO(ref List<CRedge> edges, int v1, int v2)
		{
			for (int i = 0; i < edges.Count; i++)
			{
				if ((edges[i].v1 == v1 && edges[i].v2 == v2) || (edges[i].v1 == v2 && edges[i].v2 == v1))
				{
					CRedge value = edges[i];
					value.count++;
					edges[i] = value;
					return true;
				}
			}
			return false;
		}

		public static bool OOODDQDDOO(List<int> vecs, int v)
		{
			for (int i = 0; i < vecs.Count; i++)
			{
				if (vecs[i] == v)
				{
					return false;
				}
			}
			return true;
		}

		public static bool ODODCDQQCQ(List<int> polygon, Vector3[] vecs)
		{
			bool flag = false;
			double num = 0.0;
			for (int i = 0; i < polygon.Count - 1; i++)
			{
				num += (double)((vecs[polygon[i + 1]].x - vecs[polygon[i]].x) * (vecs[polygon[i + 1]].z + vecs[polygon[i]].z));
			}
			return num > 0.0;
		}

		public static List<int> OOQOQOCODD(List<Vector3> vecs, List<Vector3> edges, List<ERCell> cEdges)
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
			List<int> tmptris = new List<int>();
			List<int> list3 = new List<int>();
			List<TriangleER> list4 = delaunayER.Triangulate(list2);
			List<ERCell> list5 = new List<ERCell>();
			for (int k = 0; k < list4.Count; k++)
			{
				int num = delaunayER.FindVertice(new Vector3(list4[k].Vertex1.x, list4[k].Vertex1.z, list4[k].Vertex1.y), vecs);
				int num2 = delaunayER.FindVertice(new Vector3(list4[k].Vertex3.x, list4[k].Vertex3.z, list4[k].Vertex3.y), vecs);
				int num3 = delaunayER.FindVertice(new Vector3(list4[k].Vertex2.x, list4[k].Vertex2.z, list4[k].Vertex2.y), vecs);
				tmptris.Add(num);
				tmptris.Add(num2);
				tmptris.Add(num3);
				if (cEdges != null && cEdges.Count > 0)
				{
					list5.Add(new ERCell(num, num2));
					list5.Add(new ERCell(num2, num));
					list5.Add(new ERCell(num, num3));
					list5.Add(new ERCell(num3, num));
					list5.Add(new ERCell(num3, num2));
					list5.Add(new ERCell(num2, num3));
				}
			}
			if (cEdges != null && cEdges.Count > 0)
			{
				List<int> leftVecs = new List<int>();
				List<int> rightVecs = new List<int>();
				List<ERHalfEdge> leftEdges = new List<ERHalfEdge>();
				List<ERHalfEdge> rightEdges = new List<ERHalfEdge>();
				for (int l = 0; l < cEdges.Count; l++)
				{
					if (list5.Contains(cEdges[l]))
					{
						continue;
					}
					leftVecs.Clear();
					rightVecs.Clear();
					leftEdges.Clear();
					rightEdges.Clear();
					for (int m = 0; m < tmptris.Count; m += 3)
					{
						bool flag = true;
						int added = -1;
						int added2 = -1;
						int added3 = -1;
						if (ussst(vecs[tmptris[m]], vecs[tmptris[m + 1]], vecs[cEdges[l].x], vecs[cEdges[l].y]))
						{
							flag = false;
							PopulateTriangleArray(ref leftVecs, ref rightVecs, ref added, vecs[tmptris[m]], tmptris[m], vecs[cEdges[l].x], vecs[cEdges[l].y]);
							PopulateTriangleArray(ref leftVecs, ref rightVecs, ref added2, vecs[tmptris[m + 1]], tmptris[m + 1], vecs[cEdges[l].x], vecs[cEdges[l].y]);
							if (tmptris[m + 2] != cEdges[l].x && tmptris[m + 2] != cEdges[l].y)
							{
								PopulateTriangleArray(ref leftVecs, ref rightVecs, ref added3, vecs[tmptris[m + 2]], tmptris[m + 2], vecs[cEdges[l].x], vecs[cEdges[l].y]);
							}
							SetHalfEdgeArrays(ref leftVecs, ref rightVecs, ref leftEdges, ref rightEdges, added, added2, added3, tmptris[m], tmptris[m + 1], tmptris[m + 2], cEdges[l].x, cEdges[l].y);
						}
						else if (ussst(vecs[tmptris[m]], vecs[tmptris[m + 2]], vecs[cEdges[l].x], vecs[cEdges[l].y]))
						{
							flag = false;
							PopulateTriangleArray(ref leftVecs, ref rightVecs, ref added, vecs[tmptris[m]], tmptris[m], vecs[cEdges[l].x], vecs[cEdges[l].y]);
							PopulateTriangleArray(ref leftVecs, ref rightVecs, ref added2, vecs[tmptris[m + 2]], tmptris[m + 2], vecs[cEdges[l].x], vecs[cEdges[l].y]);
							if (tmptris[m + 1] != cEdges[l].x && tmptris[m + 1] != cEdges[l].y)
							{
								PopulateTriangleArray(ref leftVecs, ref rightVecs, ref added3, vecs[tmptris[m + 1]], tmptris[m + 1], vecs[cEdges[l].x], vecs[cEdges[l].y]);
							}
							SetHalfEdgeArrays(ref leftVecs, ref rightVecs, ref leftEdges, ref rightEdges, added, added2, added3, tmptris[m], tmptris[m + 2], tmptris[m + 1], cEdges[l].x, cEdges[l].y);
						}
						else if (ussst(vecs[tmptris[m + 1]], vecs[tmptris[m + 2]], vecs[cEdges[l].x], vecs[cEdges[l].y]))
						{
							flag = false;
							PopulateTriangleArray(ref leftVecs, ref rightVecs, ref added, vecs[tmptris[m + 1]], tmptris[m + 1], vecs[cEdges[l].x], vecs[cEdges[l].y]);
							PopulateTriangleArray(ref leftVecs, ref rightVecs, ref added2, vecs[tmptris[m + 2]], tmptris[m + 2], vecs[cEdges[l].x], vecs[cEdges[l].y]);
							if (tmptris[m] != cEdges[l].x && tmptris[m] != cEdges[l].y)
							{
								PopulateTriangleArray(ref leftVecs, ref rightVecs, ref added3, vecs[tmptris[m]], tmptris[m], vecs[cEdges[l].x], vecs[cEdges[l].y]);
							}
							SetHalfEdgeArrays(ref leftVecs, ref rightVecs, ref leftEdges, ref rightEdges, added, added2, added3, tmptris[m + 1], tmptris[m + 2], tmptris[m], cEdges[l].x, cEdges[l].y);
						}
						if (!flag)
						{
							tmptris.RemoveRange(m, 3);
							m -= 3;
						}
					}
					if (leftVecs.Count == 1)
					{
						tmptris.Add(cEdges[l].x);
						tmptris.Add(leftVecs[0]);
						tmptris.Add(cEdges[l].y);
					}
					else if (leftVecs.Count > 1)
					{
						TriangulateConstraint(ref tmptris, leftEdges, vecs, cEdges[l].x, cEdges[l].y);
					}
					if (rightVecs.Count == 1)
					{
						tmptris.Add(cEdges[l].x);
						tmptris.Add(cEdges[l].y);
						tmptris.Add(rightVecs[0]);
					}
					else if (rightVecs.Count > 1)
					{
						TriangulateConstraint(ref tmptris, rightEdges, vecs, cEdges[l].x, cEdges[l].y);
					}
				}
			}
			for (int n = 0; n < tmptris.Count; n += 3)
			{
				if (list.Count == 0)
				{
					list3.Add(tmptris[n]);
					list3.Add(tmptris[n + 1]);
					list3.Add(tmptris[n + 2]);
					continue;
				}
				Vector3 vector2 = (vecs[tmptris[n]] + vecs[tmptris[n + 1]] + vecs[tmptris[n + 2]]) / 3f;
				if (OQOQOOCDCC.OCDCDOCQCQ(list.Count, list, vector2.x, vector2.z))
				{
					list3.Add(tmptris[n]);
					list3.Add(tmptris[n + 1]);
					list3.Add(tmptris[n + 2]);
				}
			}
			return list3;
		}

		private static void PopulateTriangleArray(ref List<int> leftVecs, ref List<int> rightVecs, ref int added, Vector3 p, int index, Vector3 source, Vector3 target)
		{
			if (OQQOCDQCQD.OOCQODQDQD(target, source, p))
			{
				if (!rightVecs.Contains(index))
				{
					rightVecs.Add(index);
				}
				added = 1;
			}
			else
			{
				if (!leftVecs.Contains(index))
				{
					leftVecs.Add(index);
				}
				added = 0;
			}
		}

		private static bool ussst(Vector3 tssss, Vector3 ussss, Vector3 vssss, Vector3 wssss)
		{
			if (tssss.Equals(vssss) || tssss.Equals(wssss) || ussss.Equals(vssss) || ussss.Equals(wssss))
			{
				return false;
			}
			if (OQQOCDQCQD.OCDCQCDDCC(tssss, ussss, vssss, wssss, flag: true) != Vector3.zero)
			{
				return true;
			}
			return false;
		}

		private static void SetHalfEdgeArrays(ref List<int> leftVecs, ref List<int> rightVecs, ref List<ERHalfEdge> leftEdges, ref List<ERHalfEdge> rightEdges, int added1, int added2, int added3, int index1, int index2, int index3, int constraint1, int constraint2)
		{
			switch (added1)
			{
			case 0:
			{
				ERHalfEdge item2 = new ERHalfEdge(index1);
				switch (added3)
				{
				case 0:
					item2.next = index3;
					break;
				case -1:
					item2.constraint = index3;
					item2.next = index3;
					break;
				}
				leftEdges.Add(item2);
				break;
			}
			case 1:
			{
				ERHalfEdge item = new ERHalfEdge(index1);
				switch (added3)
				{
				case 1:
					item.next = index3;
					break;
				case -1:
					item.constraint = index3;
					item.next = index3;
					break;
				}
				rightEdges.Add(item);
				break;
			}
			}
			switch (added2)
			{
			case 0:
			{
				ERHalfEdge item4 = new ERHalfEdge(index2);
				switch (added3)
				{
				case 0:
					item4.next = index3;
					break;
				case -1:
					item4.constraint = index3;
					item4.next = index3;
					break;
				}
				leftEdges.Add(item4);
				break;
			}
			case 1:
			{
				ERHalfEdge item3 = new ERHalfEdge(index2);
				switch (added3)
				{
				case 1:
					item3.next = index3;
					break;
				case -1:
					item3.constraint = index3;
					item3.next = index3;
					break;
				}
				rightEdges.Add(item3);
				break;
			}
			}
		}

		private static void TriangulateConstraint(ref List<int> tmptris, List<ERHalfEdge> _edges, List<Vector3> vecs, int constraint1, int constraint2)
		{
			List<ERHalfEdge> list = new List<ERHalfEdge>();
			bool flag = false;
			bool flag2 = false;
			List<int> list2 = new List<int>();
			for (int i = 0; i < _edges.Count; i++)
			{
				if (_edges[i].constraint == constraint1)
				{
					list.Insert(0, _edges[i]);
					list2.Insert(0, _edges[i].index);
					_edges.RemoveAt(i);
					i--;
					flag = true;
				}
				else if (_edges[i].constraint == constraint2)
				{
					list.Add(_edges[i]);
					_edges.RemoveAt(i);
					i--;
					flag2 = true;
				}
				if (flag && flag2)
				{
					break;
				}
			}
			int num = list[0].index;
			for (int j = 0; j < _edges.Count; j++)
			{
				ERHalfEdge item = _edges[j];
				if (item.index == num || item.next == num)
				{
					num = ((item.index != num) ? item.index : item.next);
					list.Insert(list.Count - 1, item);
					list2.Add(num);
					_edges.RemoveAt(j);
					j = -1;
				}
			}
			if (_edges.Count != 0)
			{
				Debug.LogError("Constraints Error:  " + _edges.Count + " edges " + list.Count);
			}
			if (!OQQOCDQCQD.OOCQODQDQD(vecs[constraint2], vecs[constraint1], vecs[list2[0]]))
			{
				list2.Reverse();
			}
			Vector3 b = Vector3.Lerp(vecs[constraint1], vecs[constraint2], 0.5f);
			float num2 = 10000f;
			int num3 = -1;
			for (int k = 0; k < list2.Count; k++)
			{
				Vector3 a = OQQOCDQCQD.OCOOQOQCDC(vecs[constraint1], vecs[constraint2], vecs[list2[k]]);
				float num4 = Vector3.Distance(a, b);
				if (num4 < num2)
				{
					num2 = num4;
					num3 = k;
				}
			}
			int item2 = constraint1;
			for (int l = 0; l < list2.Count - 1; l++)
			{
				if (l == num3)
				{
					tmptris.Add(constraint1);
					tmptris.Add(constraint2);
					tmptris.Add(list2[l]);
					item2 = constraint2;
				}
				tmptris.Add(list2[l]);
				tmptris.Add(item2);
				tmptris.Add(list2[l + 1]);
			}
			if (num3 == list2.Count - 1)
			{
				tmptris.Add(constraint1);
				tmptris.Add(constraint2);
				tmptris.Add(list2[list2.Count - 1]);
			}
		}

		public static void GenerateOSMDataObf(XmlDocument doc, ERRoadNetwork roadNetwork, out EROSMData osmData)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			XmlNodeList elementsByTagName = doc.GetElementsByTagName("bounds");
			foreach (XmlNode item in elementsByTagName)
			{
				num = double.Parse(item.Attributes["minlat"].InnerText, CultureInfo.InvariantCulture);
				num2 = double.Parse(item.Attributes["maxlat"].InnerText, CultureInfo.InvariantCulture);
				num3 = double.Parse(item.Attributes["minlon"].InnerText, CultureInfo.InvariantCulture);
				num4 = double.Parse(item.Attributes["maxlon"].InnerText, CultureInfo.InvariantCulture);
			}
			osmData.latitudeTop = num;
			osmData.latitudeBottom = num2;
			osmData.longitudeLeft = num3;
			osmData.longitudeRight = num4;
			float num5 = Mathf.Round(LonLatDistance(num, num3, num, num4) * 1000f);
			float num6 = Mathf.Round(LonLatDistance(num, num3, num2, num3) * 1000f);
			osmData = new EROSMData(num5, num6);
			XmlNodeList elementsByTagName2 = doc.GetElementsByTagName("way");
			foreach (XmlNode item2 in elementsByTagName2)
			{
				XmlNodeList childNodes = item2.ChildNodes;
				bool flag = false;
				foreach (XmlNode item3 in childNodes)
				{
					if ((item3.Attributes[0].InnerText == "highway" || item3.Attributes[0].InnerText == "crossing" || item3.Attributes[0].InnerText == roadNetwork.roadNetwork.osmHighwayString) && item2.Attributes.Count >= 2)
					{
						switch (item3.Attributes[1].InnerText)
						{
						case "motorway":
							osmData.Motorway++;
							break;
						case "motorway_link":
							osmData.MotorwayLink++;
							break;
						case "trunk":
							osmData.Trunk++;
							break;
						case "primary":
							osmData.Primary++;
							break;
						case "secondary":
							osmData.Secondary++;
							break;
						case "tertiary":
							osmData.Tertiary++;
							break;
						case "residential":
							osmData.Residential++;
							break;
						case "service":
							osmData.Service++;
							break;
						case "track":
							osmData.Track++;
							break;
						case "path":
							osmData.Path++;
							break;
						case "footway":
							osmData.Walkway++;
							break;
						case "raceway":
							osmData.Raceway++;
							break;
						}
					}
					osmData.total = osmData.Motorway + osmData.MotorwayLink + osmData.Trunk + osmData.Primary + osmData.Secondary + osmData.Tertiary + osmData.Residential + osmData.Service + osmData.Track + osmData.Path + osmData.Walkway + osmData.Raceway;
				}
			}
		}

		public static void GenerateOSMDataObf(XmlDocument doc, ERRoadNetwork roadNetwork, bool buildIntersections, bool insertFlexConnectors, bool setERRoad = false, float bridgeHeightOffset = 0f)
		{
			List<Transform> list = new List<Transform>();
			float num = 34f;
			float num2 = -118f;
			float num3 = 0f;
			float num4 = 0f;
			bool flag = false;
			string text = "/EasyRoads3D";
			float num5 = 0f;
			float num6 = 5f;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			List<ERNode> list2 = new List<ERNode>();
			List<ERWay> list3 = new List<ERWay>();
			List<ERModularRoad> list4 = new List<ERModularRoad>();
			List<EROQDCQOCDDC> osmCrossings = new List<EROQDCQOCDDC>();
			List<OOCDDDCQOD> list5 = new List<OOCDDDCQOD>();
			list3.Clear();
			osmCrossings.Clear();
			list5.Clear();
			list4.Clear();
			list.Clear();
			list2.Clear();
			roadNetwork.roadNetwork.osmRoadObjects.Clear();
			roadNetwork.roadNetwork.osmConnectionObjects.Clear();
			num6 = 5f;
			Terrain[] array = UnityEngine.Object.FindObjectsOfType(typeof(Terrain)) as Terrain[];
			if (array.Length == 0)
			{
				Debug.Log("A Unity terrain object is required to parse the osm file.");
				return;
			}
			ERModularBase roadNetwork2 = roadNetwork.roadNetwork;
			ERModularRoad[] array2 = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
			Vector2 zero = Vector2.zero;
			Vector3 vector = new Vector2(1000000f, 1000000f);
			if (0 == 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					Vector3 position = array[i].transform.position;
					if (array[i].terrainData.size.x + position.x > zero.x)
					{
						zero.x = array[i].terrainData.size.x + position.x;
					}
					if (array[i].terrainData.size.z + position.z > zero.y)
					{
						zero.y = array[i].terrainData.size.z + position.z;
					}
					if (position.x < vector.x)
					{
						vector.x = position.x;
					}
					if (position.z < vector.y)
					{
						vector.y = position.z;
					}
				}
				zero.x -= vector.x;
				zero.y -= vector.y;
			}
			double num12;
			double num13;
			double num14;
			double num11 = (num12 = (num13 = (num14 = 0.0)));
			XmlNodeList elementsByTagName = doc.GetElementsByTagName("bounds");
			foreach (XmlNode item2 in elementsByTagName)
			{
				num11 = double.Parse(item2.Attributes["minlat"].InnerText, CultureInfo.InvariantCulture);
				num12 = double.Parse(item2.Attributes["maxlat"].InnerText, CultureInfo.InvariantCulture);
				num13 = double.Parse(item2.Attributes["minlon"].InnerText, CultureInfo.InvariantCulture);
				num14 = double.Parse(item2.Attributes["maxlon"].InnerText, CultureInfo.InvariantCulture);
			}
			float num15 = Mathf.Round(LonLatDistance(num11, num13, num11, num14) * 1000f);
			float num16 = Mathf.Round(LonLatDistance(num11, num13, num12, num13) * 1000f);
			Debug.Log("OSM Data Stats: Width: " + num15 + " Length: " + num16);
			Debug.Log("OSM Width Length Ratio: " + num15 / num16);
			Debug.Log("Terrain Stats: Width: " + zero.x + " Length: " + zero.y);
			Debug.Log("Terrain Width Length Ratio: " + zero.x / zero.y);
			ERPoint source = new ERPoint(num13, num11);
			ERPoint source2 = new ERPoint(num14, num12);
			source = OQQOCDQCQD.OOQCQDDQQD(source);
			source2 = OQQOCDQCQD.OOQCQDDQQD(source2);
			num11 = source.y;
			num12 = source2.y;
			num13 = source.x;
			num14 = source2.x;
			float num17 = num15 / num16;
			float num18 = zero.x / zero.y;
			Vector3 vector2 = zero;
			vector2.x *= 0.5f;
			vector2.y *= 0.5f;
			if (roadNetwork2.roadDataScale != 1f)
			{
				if (num15 > num16)
				{
					if (zero.x >= zero.y)
					{
						vector.y += vector2.y - zero.x * (num16 / num15) * 0.5f;
					}
					zero.y = zero.x * (num16 / num15);
				}
				else
				{
					if (zero.y >= zero.x)
					{
						vector.x += vector2.x - zero.y * (num15 / num16) * 0.5f;
					}
					zero.x = zero.y * (num15 / num16);
				}
			}
			if (roadNetwork2.osmTerrainLeftLat != 0.0)
			{
				num11 = roadNetwork2.osmTerrainLeftLat;
			}
			if (roadNetwork2.osmTerrainRightLat != 0.0)
			{
				num12 = roadNetwork2.osmTerrainRightLat;
			}
			if (roadNetwork2.osmTerrainTopLon != 0.0)
			{
				num13 = roadNetwork2.osmTerrainTopLon;
			}
			if (roadNetwork2.osmTerrainBottomLon != 0.0)
			{
				num14 = roadNetwork2.osmTerrainBottomLon;
			}
			if (roadNetwork2.osmTerrainLeftLat != 0.0 && roadNetwork2.osmTerrainRightLat != 0.0 && roadNetwork2.osmTerrainTopLon != 0.0 && roadNetwork2.osmTerrainBottomLon != 0.0)
			{
				num11 = roadNetwork2.osmTerrainLeftLat;
				num12 = roadNetwork2.osmTerrainRightLat;
				num13 = roadNetwork2.osmTerrainTopLon;
				num14 = roadNetwork2.osmTerrainBottomLon;
				source = new ERPoint(num13, num11);
				source2 = new ERPoint(num14, num12);
				source = OQQOCDQCQD.OOQCQDDQQD(source);
				source2 = OQQOCDQCQD.OOQCQDDQQD(source2);
				num11 = source.y;
				num12 = source2.y;
				num13 = source.x;
				num14 = source2.x;
			}
			if (num11 > num12)
			{
				double num19 = num12;
				num12 = num11;
				num11 = num19;
			}
			if (num13 > num14)
			{
				double num20 = num14;
				num14 = num13;
				num13 = num20;
			}
			if (num11 == 0.0 || num12 == 0.0 || num13 == 0.0 || num14 == 0.0)
			{
				Debug.LogError("Missing bounds data - parsing is aborted...");
				return;
			}
			float num21 = 0f;
			XmlNodeList elementsByTagName2 = doc.GetElementsByTagName("node");
			foreach (XmlNode item3 in elementsByTagName2)
			{
				num21 = 0f;
				try
				{
					if (item3.Attributes["ele"] != null)
					{
						num21 = float.Parse(item3.Attributes["ele"].InnerText, CultureInfo.InvariantCulture);
					}
					list2.Add(new ERNode(Convert.ToInt64(item3.Attributes["id"].InnerText), double.Parse(item3.Attributes["lat"].InnerText, CultureInfo.InvariantCulture), double.Parse(item3.Attributes["lon"].InnerText, CultureInfo.InvariantCulture), num21));
				}
				catch
				{
					Debug.Log(item3.Attributes["id"].InnerText + " " + item3.Attributes["lat"].InnerText + " " + item3.Attributes["lon"].InnerText);
				}
			}
			XmlNodeList elementsByTagName3 = doc.GetElementsByTagName("way");
			int num22 = 0;
			Vector3 vector3 = new Vector3(vector2.x, 0f, vector2.y);
			float num23 = 0f;
			float roadDataScale = roadNetwork2.roadDataScale;
			foreach (XmlNode item4 in elementsByTagName3)
			{
				XmlNodeList childNodes = item4.ChildNodes;
				ERWay item = new ERWay(int.Parse(item4.Attributes["id"].InnerText));
				bool flag2 = false;
				foreach (XmlNode item5 in childNodes)
				{
					if (item5.Attributes[0].Name == "ref")
					{
						item.nodes.Add(Convert.ToInt64(item5.Attributes["ref"].InnerText));
					}
					if (IsRoadActive(item4, item5, roadNetwork2))
					{
						if (item5.Attributes[0].InnerText == "highway")
						{
							item.t1 = "highway";
							if (item4.Attributes.Count >= 2)
							{
								item.t2 = item5.Attributes[1].InnerText;
							}
						}
						if (item5.Attributes[0].InnerText == "crossing")
						{
							item.t1 = "highway";
							if (item5.Attributes.Count >= 2)
							{
								item.t2 = item5.Attributes[1].InnerText;
							}
						}
						if (item5.Attributes[0].InnerText == roadNetwork2.osmHighwayString)
						{
							item.t1 = "highway";
							item.t2 = roadNetwork2.osmHighwayString;
						}
						flag2 = true;
					}
					if (item4.Attributes.Count < 2)
					{
						continue;
					}
					if (item5.Attributes[0].InnerText == "bridge" && item5.Attributes[1].InnerText == "yes")
					{
						item.bridge = true;
					}
					if (item5.Attributes[0].InnerText == "lanes")
					{
						item.lanes = int.Parse(item5.Attributes["v"].InnerText);
					}
					if (item5.Attributes[0].InnerText == "oneway")
					{
						if (item5.Attributes["v"].InnerText == "yes")
						{
							item.oneWay = true;
						}
						else
						{
							item.oneWay = false;
						}
					}
					if (item5.Attributes[0].InnerText == "name")
					{
						item.name = item5.Attributes["v"].InnerText;
					}
					if (item5.Attributes[0].InnerText == "surface")
					{
						item.surface = item5.Attributes["v"].InnerText;
					}
					if (item5.Attributes[0].InnerText == "maxspeed")
					{
						item.speed = item5.Attributes["v"].InnerText;
					}
				}
				if (item.t1 == "highway" && flag2)
				{
					list3.Add(item);
				}
				num22++;
			}
			Transform parent = GameObject.Find("Road Objects").transform;
			Transform connectionsParent = GameObject.Find("Connection Objects").transform;
			List<Vector3> list6 = new List<Vector3>();
			List<long> list7 = new List<long>();
			Vector3 pos = Vector3.zero;
			GameObject gameObject = null;
			float num24 = 0f;
			Vector3 zero2 = Vector3.zero;
			Vector3 a = Vector3.zero;
			bool flag3 = false;
			num4 = -2f;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			Material roadMaterial = null;
			float roadWidth = 0f;
			int num25 = 0;
			int num26 = 0;
			ERPoint eRPoint = new ERPoint(0.0, 0.0);
			for (int j = 0; j < list3.Count; j++)
			{
				foreach (ERModularRoad item6 in list4)
				{
					item6.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
				}
				roadNetwork2.UpdateSideObjectsInScene();
				roadNetwork2.OOOCDDCQCD = null;
				list6.Clear();
				list7.Clear();
				for (int k = 0; k < list3[j].nodes.Count; k++)
				{
					num24 = 0f;
					flag3 = false;
					foreach (ERNode item7 in list2)
					{
						if (item7.id != list3[j].nodes[k])
						{
							continue;
						}
						double lat = item7.lat;
						double lon = item7.lon;
						eRPoint.x = lon;
						eRPoint.y = lat;
						eRPoint = OQQOCDQCQD.OOQCQDDQQD(eRPoint);
						lon = eRPoint.x;
						lat = eRPoint.y;
						if (lat > num11 && lat < num12 && lon > num13 && lon < num14)
						{
							pos.z = vector.y + (float)((lat - num11) / (num12 - num11) * (double)zero.y);
							pos.x = vector.x + (float)((lon - num13) / (num14 - num13) * (double)zero.x);
							pos.y = 0f;
							if (roadNetwork2.roadDataScale != 1f)
							{
								Vector3 normalized = (pos - vector3).normalized;
								num23 = Vector3.Distance(pos, vector3);
								pos = vector3 + normalized * num23 * roadDataScale;
							}
							if (item7.height != 0f)
							{
								pos.y = item7.height;
							}
							else
							{
								roadNetwork2.OQCCDQOQOO(ref pos);
							}
							if (list3[j].bridge)
							{
								pos.y += bridgeHeightOffset;
							}
							list6.Add(pos);
							list7.Add(list3[j].nodes[k]);
							if (flag3)
							{
								num24 += Vector3.Distance(a, pos);
							}
							a = pos;
							flag3 = true;
						}
					}
				}
				if (list6.Count <= 1 || (list6.Count == 2 && Vector3.Distance(list6[0], list6[1]) < 5f))
				{
					continue;
				}
				int num27 = 0;
				gameObject = new GameObject();
				gameObject.AddComponent<MeshFilter>();
				gameObject.AddComponent<MeshRenderer>();
				gameObject.AddComponent<MeshCollider>();
				gameObject.transform.position = Vector3.zero;
				gameObject.transform.parent = parent;
				ERModularRoad eRModularRoad = gameObject.AddComponent<ERModularRoad>();
				list4.Add(eRModularRoad);
				int roadTypeInt = -1;
				ODODQDCCCO(ref roadMaterial, ref roadWidth, list3[j].t2, ref roadTypeInt, roadNetwork2);
				gameObject.GetComponent<MeshRenderer>().sharedMaterial = roadMaterial;
				eRModularRoad.roadWidth = roadWidth;
				string roadName = (eRModularRoad.gameObject.name = "road_" + j + "_" + list3[j].t2);
				eRModularRoad.roadName = roadName;
				if (list3[j].name != "")
				{
					roadName = (eRModularRoad.gameObject.name = list3[j].name);
					eRModularRoad.roadName = roadName;
				}
				eRModularRoad.osmRoadType = list3[j].t2;
				eRModularRoad.osmID = list3[j].id;
				eRModularRoad.osmOneWay = list3[j].oneWay;
				eRModularRoad.osmSpeed = list3[j].speed;
				eRModularRoad.osmSurface = list3[j].surface;
				eRModularRoad.osmLanes = list3[j].lanes;
				eRModularRoad.isBridge = list3[j].bridge;
				if (roadTypeInt != -1)
				{
					eRModularRoad.roadType = roadNetwork2.roadTypes[roadTypeInt - 1].id;
					AssignSideObjects(roadNetwork2, eRModularRoad, roadTypeInt);
					roadNetwork2.OOOCDDCQCD = eRModularRoad;
					ODDOQDDQCQ.UpdateRoadType(roadNetwork2, roadTypeInt);
				}
				gameObject.transform.position = Vector3.zero;
				num26++;
				if (list3[j].t2 == "primary" || list3[j].t2 == "residential" || list3[j].t2 == "service")
				{
					list5.Add(new OOCDDDCQOD(eRModularRoad, list3[j].t2));
				}
				num24 = 0f;
				for (int l = 0; l < list6.Count; l++)
				{
					zero2 = list6[l];
					eRModularRoad.markersExt.Add(ERMarkerExt.CreateInstance(zero2, eRModularRoad, 0));
					eRModularRoad.markersExt[eRModularRoad.markersExt.Count - 1].leftIndent = roadNetwork2.minIndent;
					eRModularRoad.markersExt[eRModularRoad.markersExt.Count - 1].rightIndent = roadNetwork2.minIndent;
					eRModularRoad.markersExt[eRModularRoad.markersExt.Count - 1].leftSurrounding = roadNetwork2.minSurrounding;
					eRModularRoad.markersExt[eRModularRoad.markersExt.Count - 1].rightSurrounding = roadNetwork2.minSurrounding;
					eRModularRoad.markersExt[eRModularRoad.markersExt.Count - 1].OSMNodeID = list7[l];
				}
				flag4 = false;
				flag5 = false;
				flag6 = false;
				if (!buildIntersections)
				{
					continue;
				}
				for (int m = 0; m < list5.Count; m++)
				{
					for (int n = 0; n < list5[m].ErRoad.markersExt.Count; n++)
					{
						for (int num28 = m + 1; num28 < list5.Count; num28++)
						{
							for (int num29 = 0; num29 < list5[num28].ErRoad.markersExt.Count; num29++)
							{
								if (!(Vector3.Distance(list5[m].ErRoad.markersExt[n].position, list5[num28].ErRoad.markersExt[num29].position) < num6))
								{
									continue;
								}
								if (!OCOODCCDDD(osmCrossings, list5[m].ErRoad, n))
								{
									if (n != 0 && list5[m].ErRoad.markersExt.Count - 1 > n)
									{
										ERModularRoad scr = OQOCQDQODD.ODOOOQCQCQ(list5[m].ErRoad, n);
										list5.Insert(m + 1, new OOCDDDCQOD(scr, list5[m].osmType));
									}
									if (num29 != 0 && list5[num28].ErRoad.markersExt.Count - 1 > num29)
									{
										ERModularRoad scr2 = OQOCQDQODD.ODOOOQCQCQ(list5[num28].ErRoad, num29);
										list5.Insert(num28 + 1, new OOCDDDCQOD(scr2, list5[num28].osmType));
									}
								}
								break;
							}
						}
					}
				}
			}
			if (setERRoad)
			{
				foreach (ERModularRoad item8 in list4)
				{
					roadNetwork.roadNetwork.osmRoadObjects.Add(new ERRoad(item8));
				}
			}
			if (buildIntersections)
			{
				ERModularRoad[] array3 = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
				int markerRoad = 0;
				int markerRoad2 = 0;
				for (int num30 = 0; num30 < array3.Length; num30++)
				{
					for (int num31 = num30 + 1; num31 < array3.Length; num31++)
					{
						if (OODCQQDDQD(array3[num30], array3[num31], num6, ref markerRoad, ref markerRoad2) && !OCCQDDOODQ(osmCrossings, array3[num30], markerRoad, array3[num31], markerRoad2, ref osmCrossings))
						{
							OQQQOCCOCO(array3[num30], markerRoad, array3[num31], markerRoad2, null, -1, null, -1, ref osmCrossings);
						}
					}
				}
				Debug.Log("Crossing Count: " + osmCrossings.Count);
			}
			foreach (ERModularRoad item9 in list4)
			{
				item9.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
			}
			roadNetwork2.UpdateSideObjectsInScene();
			if (buildIntersections)
			{
				roadNetwork = new ERRoadNetwork();
				num7 = 0;
				num8 = 0;
				num9 = 0;
				num10 = 0;
				for (int num32 = 0; num32 < osmCrossings.Count; num32++)
				{
					EROQDCQOCDDC crossing = osmCrossings[num32];
					if (crossing.road3 == crossing.road4 && crossing.marker3 == crossing.marker4)
					{
						crossing.road4 = null;
						crossing.marker4 = -1;
					}
					OQDCCQOCCQ(crossing, connectionsParent, ref num7, ref num8, ref num9, ref num10, roadNetwork, insertFlexConnectors, num32.ToString());
				}
				Debug.Log("Roads: " + list3.Count);
				Debug.Log("X Crossings: " + num10);
				Debug.Log("T Crossings: " + num9);
				Debug.Log("Two roads Connected: " + num8);
				Debug.Log("One road only: " + num8);
				Debug.Log("Crossing instances: " + osmCrossings.Count);
				Debug.Log("Possible Crossing roads: " + list5.Count);
			}
			int num33 = 0;
			ERModularBase eRModularBase = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
			eRModularBase.osmCrossingPoints.Clear();
			foreach (EROQDCQOCDDC item10 in osmCrossings)
			{
				if (item10.road2 != null || item10.road3 != null)
				{
					try
					{
					}
					catch
					{
						string text4 = item10.road1.markersExt.Count.ToString();
						int marker = item10.marker1;
						Debug.LogError(text4 + " " + marker);
					}
					num33++;
				}
			}
			roadNetwork2.OOOCDDCQCD = null;
			Debug.Log(num26 + " Objects Extracted");
		}

		public static bool OODCQQDDQD(ERModularRoad road1, ERModularRoad road2, float crossingDistanceOffset, ref int markerRoad1, ref int markerRoad2)
		{
			if (road1.markersExt.Count == 0 || road2.markersExt.Count == 0)
			{
				return false;
			}
			if (Vector3.Distance(road1.markersExt[0].position, road2.markersExt[0].position) < crossingDistanceOffset)
			{
				markerRoad1 = 0;
				markerRoad2 = 0;
				return true;
			}
			if (Vector3.Distance(road1.markersExt[0].position, road2.markersExt[road2.markersExt.Count - 1].position) < crossingDistanceOffset)
			{
				markerRoad1 = 0;
				markerRoad2 = road2.markersExt.Count - 1;
				return true;
			}
			if (Vector3.Distance(road1.markersExt[road1.markersExt.Count - 1].position, road2.markersExt[road2.markersExt.Count - 1].position) < crossingDistanceOffset)
			{
				markerRoad1 = road1.markersExt.Count - 1;
				markerRoad2 = road2.markersExt.Count - 1;
				return true;
			}
			if (Vector3.Distance(road1.markersExt[road1.markersExt.Count - 1].position, road2.markersExt[0].position) < crossingDistanceOffset)
			{
				markerRoad1 = road1.markersExt.Count - 1;
				markerRoad2 = 0;
				return true;
			}
			return false;
		}

		public static void OQQODDDDQD(int el, ERModularRoad OOOCDDCQCD, int marker, ref List<EROQDCQOCDDC> osmCrossings)
		{
			EROQDCQOCDDC value = osmCrossings[el];
			if (osmCrossings[el].road2 == null)
			{
				value.road2 = OOOCDDCQCD;
				value.marker2 = marker;
				Debug.Log("added as road 2: " + OOOCDDCQCD.gameObject.name);
			}
			else if (osmCrossings[el].road3 == null)
			{
				value.road3 = OOOCDDCQCD;
				value.marker3 = marker;
				Debug.Log("added as road 3: " + OOOCDDCQCD.gameObject.name);
			}
			else if (osmCrossings[el].road4 == null)
			{
				value.road4 = OOOCDDCQCD;
				value.marker4 = marker;
				Debug.Log("added as road 4: " + OOOCDDCQCD.gameObject.name);
			}
			osmCrossings[el] = value;
		}

		public static void OQQQOCCOCO(ERModularRoad scr1, int marker1, ERModularRoad scr2, int marker2, ERModularRoad scr3, int marker3, ERModularRoad scr4, int marker4, ref List<EROQDCQOCDDC> osmCrossings)
		{
			EROQDCQOCDDC item = new EROQDCQOCDDC(scr1, marker1);
			item.road1 = scr1;
			item.marker1 = marker1;
			item.road2 = scr2;
			item.marker2 = marker2;
			item.road3 = scr3;
			item.marker3 = marker3;
			item.road4 = scr4;
			item.marker4 = marker4;
			osmCrossings.Add(item);
		}

		public static bool OCOODCCDDD(List<EROQDCQOCDDC> data, ERModularRoad road, int marker)
		{
			bool result = false;
			int num = 0;
			foreach (EROQDCQOCDDC datum in data)
			{
				if (!(road != datum.road1) || marker == datum.marker1)
				{
					continue;
				}
				try
				{
					if (Vector3.Distance(datum.road1.markersExt[datum.marker1].position, road.markersExt[marker].position) < 25f)
					{
						return true;
					}
				}
				catch
				{
					string[] obj2 = new string[5]
					{
						datum.ToString(),
						" ",
						datum.road1.markersExt.Count.ToString(),
						" ",
						null
					};
					int marker2 = datum.marker1;
					obj2[4] = marker2.ToString();
					Debug.LogError(string.Concat(obj2));
				}
			}
			return result;
		}

		public static bool OCCQDDOODQ(List<EROQDCQOCDDC> data, ERModularRoad road, int marker, ERModularRoad newroad, int newmarker, ref List<EROQDCQOCDDC> osmCrossings)
		{
			bool result = false;
			for (int i = 0; i < osmCrossings.Count; i++)
			{
				EROQDCQOCDDC cScr = osmCrossings[i];
				if (road == cScr.road1 && marker == cScr.marker1)
				{
					OQQODDDDQD(ref cScr, newroad, newmarker);
					osmCrossings[i] = cScr;
					return true;
				}
				if (road == cScr.road2 && marker == cScr.marker2)
				{
					OQQODDDDQD(ref cScr, newroad, newmarker);
					osmCrossings[i] = cScr;
					return true;
				}
				if (road == cScr.road3 && marker == cScr.marker3)
				{
					OQQODDDDQD(ref cScr, newroad, newmarker);
					osmCrossings[i] = cScr;
					return true;
				}
				if (road == cScr.road4 && marker == cScr.marker4)
				{
					OQQODDDDQD(ref cScr, newroad, newmarker);
					osmCrossings[i] = cScr;
					return true;
				}
			}
			return result;
		}

		public static void OQQODDDDQD(ref EROQDCQOCDDC cScr, ERModularRoad newroad, int newmarker)
		{
			if (cScr.road2 == null)
			{
				cScr.road2 = newroad;
				cScr.marker2 = newmarker;
			}
			else if (cScr.road3 == null)
			{
				cScr.road3 = newroad;
				cScr.marker3 = newmarker;
			}
			else if (cScr.road4 == null)
			{
				cScr.road4 = newroad;
				cScr.marker4 = newmarker;
			}
		}

		public static void OQCCDOODDQ(ERModularRoad road, ERModularRoad newroad, ref List<EROQDCQOCDDC> osmCrossings)
		{
			for (int i = 0; i < osmCrossings.Count; i++)
			{
				if (road == osmCrossings[i].road1 && osmCrossings[i].marker1 != 0)
				{
					EROQDCQOCDDC eROQDCQOCDDC = osmCrossings[i];
					eROQDCQOCDDC.road1 = newroad;
					eROQDCQOCDDC.marker1 = newroad.markersExt.Count - 1;
				}
				else if (road == osmCrossings[i].road2 && osmCrossings[i].marker2 != 0)
				{
					EROQDCQOCDDC eROQDCQOCDDC2 = osmCrossings[i];
					eROQDCQOCDDC2.road2 = newroad;
					eROQDCQOCDDC2.marker2 = newroad.markersExt.Count - 1;
				}
				else if (road == osmCrossings[i].road3 && osmCrossings[i].marker3 != 0)
				{
					EROQDCQOCDDC eROQDCQOCDDC3 = osmCrossings[i];
					eROQDCQOCDDC3.road3 = newroad;
					eROQDCQOCDDC3.marker3 = newroad.markersExt.Count - 1;
				}
				else if (road == osmCrossings[i].road4 && osmCrossings[i].marker4 != 0)
				{
					EROQDCQOCDDC eROQDCQOCDDC4 = osmCrossings[i];
					eROQDCQOCDDC4.road4 = newroad;
					eROQDCQOCDDC4.marker4 = newroad.markersExt.Count - 1;
				}
			}
		}

		public static void OODQQQQQQC(string osmRoadType, double rtid, ERModularBase baseScript)
		{
			for (int i = 0; i < baseScript.roadTypes.Count; i++)
			{
				if (baseScript.roadTypes[i].id == rtid)
				{
					switch (osmRoadType)
					{
					case "motorway":
						baseScript.osmMotorway = i + 1;
						break;
					case "motorway_link":
						baseScript.osmMotorwayLink = i + 1;
						break;
					case "trunk":
						baseScript.osmTrunk = i + 1;
						break;
					case "primary":
						baseScript.osmPrimary = i + 1;
						break;
					case "secondary":
						baseScript.osmSecondary = i + 1;
						break;
					case "tertiary":
						baseScript.osmTertiary = i + 1;
						break;
					case "unclassified":
						baseScript.osmUnclassified = i + 1;
						break;
					case "residential":
						baseScript.osmResidential = i + 1;
						break;
					case "service":
						baseScript.osmService = i + 1;
						break;
					case "track":
						baseScript.osmTrack = i + 1;
						break;
					case "path":
						baseScript.osmPath = i + 1;
						break;
					case "footway":
						baseScript.osmWalkway = i + 1;
						break;
					case "raceway":
						baseScript.osmRaceway = i + 1;
						break;
					}
					break;
				}
			}
		}

		public static void ODODQDCCCO(ref Material roadMaterial, ref float roadWidth, string roadType, ref int roadTypeInt, ERModularBase baseScript)
		{
			Material roadMaterial2 = baseScript.roadMaterial;
			float num = 5f;
			if (baseScript.roadTypes.Count == 0)
			{
				roadMaterial = roadMaterial2;
				roadWidth = num;
				return;
			}
			switch (roadType)
			{
			case "motorway":
				if (baseScript.roadTypes.Count >= baseScript.osmMotorway - 1 && baseScript.osmMotorway != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmMotorway - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmMotorway - 1].roadWidth;
					roadTypeInt = baseScript.osmMotorway;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "motorway_link":
				if (baseScript.roadTypes.Count >= baseScript.osmMotorwayLink - 1 && baseScript.osmMotorwayLink != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmMotorwayLink - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmMotorwayLink - 1].roadWidth;
					roadTypeInt = baseScript.osmMotorwayLink;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "trunk":
				if (baseScript.roadTypes.Count >= baseScript.osmTrunk - 1 && baseScript.osmTrunk != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmTrunk - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmTrunk - 1].roadWidth;
					roadTypeInt = baseScript.osmTrunk;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "primary":
				if (baseScript.roadTypes.Count >= baseScript.osmPrimary - 1 && baseScript.osmPrimary != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmPrimary - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmPrimary - 1].roadWidth;
					roadTypeInt = baseScript.osmPrimary;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "secondary":
				if (baseScript.roadTypes.Count >= baseScript.osmSecondary - 1 && baseScript.osmSecondary != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmSecondary - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmSecondary - 1].roadWidth;
					roadTypeInt = baseScript.osmSecondary;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "tertiary":
				if (baseScript.roadTypes.Count >= baseScript.osmTertiary - 1 && baseScript.osmTertiary != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmTertiary - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmTertiary - 1].roadWidth;
					roadTypeInt = baseScript.osmTertiary;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "unclassified":
				if (baseScript.roadTypes.Count >= baseScript.osmUnclassified - 1 && baseScript.osmUnclassified != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmUnclassified - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmUnclassified - 1].roadWidth;
					roadTypeInt = baseScript.osmUnclassified;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "residential":
				if (baseScript.roadTypes.Count >= baseScript.osmResidential - 1 && baseScript.osmResidential != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmResidential - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmResidential - 1].roadWidth;
					roadTypeInt = baseScript.osmResidential;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "service":
				if (baseScript.roadTypes.Count >= baseScript.osmService - 1 && baseScript.osmService != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmService - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmService - 1].roadWidth;
					roadTypeInt = baseScript.osmService;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "track":
				if (baseScript.roadTypes.Count >= baseScript.osmTrack - 1 && baseScript.osmTrack != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmTrack - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmTrack - 1].roadWidth;
					roadTypeInt = baseScript.osmTrack;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "path":
				if (baseScript.roadTypes.Count >= baseScript.osmPath - 1 && baseScript.osmPath != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmPath - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmPath - 1].roadWidth;
					roadTypeInt = baseScript.osmPath;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "footway":
				if (baseScript.roadTypes.Count >= baseScript.osmWalkway - 1 && baseScript.osmWalkway != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmWalkway - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmWalkway - 1].roadWidth;
					roadTypeInt = baseScript.osmWalkway;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			case "raceway":
				if (baseScript.roadTypes.Count >= baseScript.osmRaceway - 1 && baseScript.osmRaceway != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmRaceway - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmRaceway - 1].roadWidth;
					roadTypeInt = baseScript.osmRaceway;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
				return;
			}
			if (baseScript.osmHighwayString != "" && roadType == baseScript.osmHighwayString)
			{
				if (baseScript.roadTypes.Count >= baseScript.osmHighwayStringInt - 1 && baseScript.osmHighwayStringInt != 0)
				{
					roadMaterial = baseScript.roadTypes[baseScript.osmHighwayStringInt - 1].roadMaterial;
					roadWidth = baseScript.roadTypes[baseScript.osmHighwayStringInt - 1].roadWidth;
					roadTypeInt = baseScript.osmHighwayStringInt;
				}
				else
				{
					roadMaterial = roadMaterial2;
					roadWidth = num;
				}
			}
		}

		public static bool IsRoadActive(XmlNode node, XmlNode nod, ERModularBase baseScript)
		{
			if (nod.Attributes[0].InnerText == "highway" || nod.Attributes[0].InnerText == "crossing" || nod.Attributes[0].InnerText == baseScript.osmHighwayString)
			{
				if (node.Attributes.Count >= 2)
				{
					string innerText = nod.Attributes[1].InnerText;
					if (innerText == "motorway" && baseScript.osmMotorwayFlag)
					{
						return true;
					}
					if (innerText == "motorway_link" && baseScript.osmMotorwayLinkFlag)
					{
						return true;
					}
					if (innerText == "trunk" && baseScript.osmTrunkFlag)
					{
						return true;
					}
					if (innerText == "primary" && baseScript.osmPrimaryFlag)
					{
						return true;
					}
					if (innerText == "secondary" && baseScript.osmSecondaryFlag)
					{
						return true;
					}
					if (innerText == "tertiary" && baseScript.osmTertiaryFlag)
					{
						return true;
					}
					if (innerText == "residential" && baseScript.osmResidentialFlag)
					{
						return true;
					}
					if (innerText == "service" && baseScript.osmServiceFlag)
					{
						return true;
					}
					if (innerText == "track" && baseScript.osmTrackFlag)
					{
						return true;
					}
					if (innerText == "path" && baseScript.osmPathFlag)
					{
						return true;
					}
					if (innerText == "footway" && baseScript.osmWalkwayFlag)
					{
						return true;
					}
					if (innerText == "raceway" && baseScript.osmRacewayFlag)
					{
						return true;
					}
					if (innerText == "unclassified" && baseScript.osmUnclassifiedFlag)
					{
						return true;
					}
					if ((baseScript.osmHighwayString != "" && innerText == baseScript.osmHighwayString) || nod.Attributes[0].InnerText == baseScript.osmHighwayString)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public static ERConnection OQDCCQOCCQ(EROQDCQOCDDC crossing, Transform connectionsParent, ref int ccount1, ref int ccount2, ref int ccount3, ref int ccount4, ERRoadNetwork roadNetwork, bool insertFlexConnectors, string connCount)
		{
			ERConnection eRConnection = null;
			Vector3 pos = Vector3.zero;
			bool flag = false;
			bool flag2 = true;
			bool flag3 = true;
			GameObject gameObject = null;
			if (crossing.road2 == null && crossing.road3 == null && crossing.road4 == null)
			{
				ccount1++;
			}
			else if (crossing.road2 != null && crossing.road3 == null && crossing.road4 == null)
			{
				ccount2++;
			}
			else if (crossing.road2 != null && crossing.road3 != null && crossing.road4 == null)
			{
				ccount3++;
				gameObject = Resources.Load("standard prefabs/X Crossing") as GameObject;
				pos += crossing.road1.markersExt[crossing.marker1].position;
				pos += crossing.road2.markersExt[crossing.marker2].position;
				pos += crossing.road3.markersExt[crossing.marker3].position;
				pos /= 3f;
				flag = true;
				if (crossing.road1.roadType == 0.0)
				{
					flag2 = false;
				}
				else if (crossing.road2.roadType == 0.0)
				{
					flag2 = false;
				}
				else if (crossing.road3.roadType == 0.0)
				{
					flag2 = false;
				}
			}
			else if (crossing.road2 != null && crossing.road3 != null && crossing.road4 != null)
			{
				ccount4++;
				gameObject = Resources.Load("standard prefabs/X Crossing") as GameObject;
				pos += crossing.road1.markersExt[crossing.marker1].position;
				pos += crossing.road2.markersExt[crossing.marker2].position;
				pos += crossing.road3.markersExt[crossing.marker3].position;
				pos += crossing.road4.markersExt[crossing.marker4].position;
				pos /= 4f;
				if (crossing.road1.roadType == 0.0)
				{
					flag2 = false;
				}
				else if (crossing.road2.roadType == 0.0)
				{
					flag2 = false;
				}
				else if (crossing.road3.roadType == 0.0)
				{
					flag2 = false;
				}
				else if (crossing.road4.roadType == 0.0)
				{
					flag2 = false;
				}
			}
			if (gameObject != null)
			{
				ERConnection oQCQQDQOCD = ERConnection.Create(gameObject);
				eRConnection = roadNetwork.InstantiateConnection(oQCQQDQOCD, "Connection " + connCount, pos, Vector3.zero);
				eRConnection.gameObject.name = "Connection " + connCount;
				OQDOOCDQCO(crossing, eRConnection.gameObject, ref pos, roadNetwork.roadNetwork);
				ERCrossingPrefabs component = eRConnection.gameObject.GetComponent<ERCrossingPrefabs>();
				if (component != null)
				{
					component.isSceneObject = true;
				}
				ERCrossings component2 = eRConnection.gameObject.GetComponent<ERCrossings>();
				if (component2 != null)
				{
					component2.isSceneObject = true;
				}
				if (crossing.road1 != null)
				{
					Vector3 vector = ((crossing.marker1 != 0) ? (crossing.road1.markersExt[crossing.marker1 - 1].position - crossing.road1.markersExt[crossing.marker1].position).normalized : (crossing.road1.markersExt[1].position - crossing.road1.markersExt[0].position).normalized);
					Vector3 position = crossing.road1.markersExt[crossing.marker1].position + 3f * vector;
					int connectionIndex = eRConnection.FindNearestConnectionIndex(position);
					crossing.road1.road = new ERRoad(crossing.road1);
					if (crossing.marker1 == 0)
					{
						crossing.road1.road.ConnectToStart(eRConnection, connectionIndex);
					}
					else
					{
						crossing.road1.road.ConnectToEnd(eRConnection, connectionIndex);
					}
				}
				if (crossing.road2 != null)
				{
					Vector3 vector2 = ((crossing.marker2 != 0) ? (crossing.road2.markersExt[crossing.marker2 - 1].position - crossing.road2.markersExt[crossing.marker2].position).normalized : (crossing.road2.markersExt[1].position - crossing.road2.markersExt[0].position).normalized);
					Vector3 position2 = crossing.road2.markersExt[crossing.marker2].position + 3f * vector2;
					int connectionIndex2 = eRConnection.FindNearestConnectionIndex(position2);
					crossing.road2.road = new ERRoad(crossing.road2);
					if (crossing.marker2 == 0)
					{
						crossing.road2.road.ConnectToStart(eRConnection, connectionIndex2);
					}
					else
					{
						crossing.road2.road.ConnectToEnd(eRConnection, connectionIndex2);
					}
				}
				if (crossing.road3 != null)
				{
					Vector3 vector3 = ((crossing.marker3 != 0) ? (crossing.road3.markersExt[crossing.marker3 - 1].position - crossing.road3.markersExt[crossing.marker3].position).normalized : (crossing.road3.markersExt[1].position - crossing.road3.markersExt[0].position).normalized);
					Vector3 position3 = crossing.road3.markersExt[crossing.marker3].position + 3f * vector3;
					int connectionIndex3 = eRConnection.FindNearestConnectionIndex(position3);
					crossing.road3.road = new ERRoad(crossing.road3);
					if (crossing.marker3 == 0)
					{
						crossing.road3.road.ConnectToStart(eRConnection, connectionIndex3);
					}
					else
					{
						crossing.road3.road.ConnectToEnd(eRConnection, connectionIndex3);
					}
				}
				if (crossing.road4 != null && crossing.marker4 >= 0 && crossing.road4.markersExt.Count > crossing.marker4 - 1)
				{
					Vector3 vector4 = ((crossing.marker4 != 0) ? (crossing.road4.markersExt[crossing.marker4 - 1].position - crossing.road3.markersExt[crossing.marker4].position).normalized : (crossing.road4.markersExt[1].position - crossing.road4.markersExt[0].position).normalized);
					Vector3 position4 = crossing.road4.markersExt[crossing.marker4].position + 3f * vector4;
					int connectionIndex4 = eRConnection.FindNearestConnectionIndex(position4);
					crossing.road4.road = new ERRoad(crossing.road4);
					if (crossing.marker4 == 0)
					{
						crossing.road4.road.ConnectToStart(eRConnection, connectionIndex4);
					}
					else
					{
						crossing.road4.road.ConnectToEnd(eRConnection, connectionIndex4);
					}
				}
				if (flag)
				{
					if (component.crossingsScript == null)
					{
						component.crossingsScript = component.gameObject.GetComponent<ERCrossings>();
					}
					if (component.crossingsScript != null)
					{
						component.crossingsScript.tCrossing = flag;
						if (component.crossingElements[2].connectedRoad == null)
						{
							component.crossingsScript.tCrossingLeftRight = 1;
						}
						else
						{
							component.crossingsScript.tCrossingLeftRight = 0;
						}
						component.crossingsScript.OQDCCQOCCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
					}
					if (crossing.road1.roadType != crossing.road2.roadType && crossing.road1.roadType != crossing.road3.roadType && crossing.road2.roadType != crossing.road3.roadType)
					{
						flag3 = false;
					}
				}
				else if (flag2 && component.crossingElements[0].connectedRoad.roadType != component.crossingElements[1].connectedRoad.roadType && component.crossingElements[3].connectedRoad.roadType != component.crossingElements[4].connectedRoad.roadType)
				{
					flag3 = false;
				}
				if (insertFlexConnectors && eRConnection != null && flag2 && flag2 && flag3)
				{
					bool flag4 = true;
					for (int i = 0; i < 4; i++)
					{
						if (component.crossingElements[i].connectedRoad != null && component.crossingElements[i].connectedRoad.totalDistance < 25f)
						{
							flag4 = false;
							break;
						}
					}
					if (flag4)
					{
						eRConnection.IsFlexConnector();
					}
				}
				else if (component != null && !flag2)
				{
					Debug.Log("EasyRoads3Dv3 Warning: " + component.gameObject.name + ": Generating Flex Connector aborted, not all connected road objects have road types assigned");
				}
				else if (component != null && !flag3)
				{
					Debug.Log("EasyRoads3Dv3 Warning: " + component.gameObject.name + ": Generating Flex Connector aborted, the order of icoming road types is not supported, currently Flex Connectors require that at least one of the two opposite connection pairs share the same road type");
				}
			}
			else
			{
				Debug.LogError("EasyRoads3Dv3: The default 'X Crossing' prefab is not present in the /Assets/EasyRoads3D/Resources/standard prefabs/. Inserting intersections failed. Please reimport this specific asset from the EasyRoads3Dv3 pro Package.");
			}
			return eRConnection;
		}

		public static void OQDOOCDQCO(EROQDCQOCDDC crossing, GameObject cr, ref Vector3 pos, ERModularBase baseScript)
		{
			Vector3 vector = OOQQOOQQDO(crossing.road1, crossing.marker1);
			Vector3 vector2 = OOQQOOQQDO(crossing.road2, crossing.marker2);
			Vector3 vector3 = OOQQOOQQDO(crossing.road3, crossing.marker3);
			Vector3 vector4 = OOQQOOQQDO(crossing.road4, crossing.marker4);
			if (!(crossing.road4 == null))
			{
				return;
			}
			pos = (crossing.road1.markersExt[crossing.marker1].position + crossing.road2.markersExt[crossing.marker2].position + crossing.road3.markersExt[crossing.marker3].position) / 3f;
			float num = Mathf.Abs(Vector3.Angle(vector - pos, vector2 - pos));
			float num2 = Mathf.Abs(Vector3.Angle(vector - pos, vector3 - pos));
			float num3 = Mathf.Abs(Vector3.Angle(vector2 - pos, vector3 - pos));
			float num4 = num;
			int num5 = 1;
			if (num2 > num4)
			{
				num4 = num2;
				num5 = 2;
			}
			if (num3 > num4)
			{
				num4 = num3;
				num5 = 3;
			}
			ERModularRoad eRModularRoad = null;
			int num6 = -1;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			ERModularRoad eRModularRoad2 = null;
			int num7 = 0;
			ERModularRoad eRModularRoad3 = null;
			int num8 = 0;
			Vector3 vector5;
			switch (num5)
			{
			case 1:
				vector5 = vector - vector2;
				eRModularRoad2 = crossing.road1;
				num7 = crossing.marker1;
				zero = vector;
				eRModularRoad3 = crossing.road2;
				num8 = crossing.marker2;
				eRModularRoad = crossing.road3;
				num6 = crossing.marker3;
				zero2 = vector3;
				break;
			case 2:
				vector5 = vector - vector3;
				eRModularRoad2 = crossing.road1;
				num7 = crossing.marker1;
				zero = vector;
				eRModularRoad3 = crossing.road3;
				num8 = crossing.marker3;
				eRModularRoad = crossing.road2;
				num6 = crossing.marker2;
				zero2 = vector2;
				break;
			default:
				vector5 = vector2 - vector3;
				eRModularRoad2 = crossing.road2;
				num7 = crossing.marker2;
				zero = vector2;
				eRModularRoad3 = crossing.road3;
				num8 = crossing.marker3;
				eRModularRoad = crossing.road1;
				num6 = crossing.marker1;
				zero2 = vector;
				break;
			}
			float num9 = Vector3.Angle(Vector3.forward, vector5);
			if (OQQOCDQCQD.OQDDDQOOQO(Vector3.forward, vector5, Vector3.up) == -1f)
			{
				num9 = 360f - num9;
			}
			baseScript.OQCCDQOQOO(ref pos);
			cr.transform.position = pos;
			cr.transform.eulerAngles = new Vector3(0f, num9, 0f);
			ERCrossingPrefabs component = cr.GetComponent<ERCrossingPrefabs>();
			Vector3 pSource = cr.transform.TransformPoint(component.crossingElements[0].centerPoint);
			Vector3 pTarget = cr.transform.TransformPoint(component.crossingElements[1].centerPoint);
			Vector3 centerPoint = component.crossingElements[2].centerPoint;
			if (component.crossingElements[2].centerPoint == Vector3.zero)
			{
				centerPoint = component.crossingElements[3].centerPoint;
			}
			centerPoint = cr.transform.TransformPoint(centerPoint);
			if (OQQOCDQCQD.OOCQODQDQD(pTarget, pSource, centerPoint) != OQQOCDQCQD.OOCQODQDQD(pTarget, pSource, zero2))
			{
				num9 += 180f;
				if (num9 > 360f)
				{
					num9 -= 360f;
				}
				cr.transform.eulerAngles = new Vector3(0f, num9, 0f);
			}
			pSource = cr.transform.TransformPoint(component.crossingElements[0].centerPoint);
			pTarget = cr.transform.TransformPoint(component.crossingElements[1].centerPoint);
			centerPoint = component.crossingElements[2].centerPoint;
			if (component.crossingElements[2].centerPoint == Vector3.zero)
			{
				centerPoint = component.crossingElements[3].centerPoint;
			}
			centerPoint = cr.transform.TransformPoint(centerPoint);
			if (Vector3.Distance(zero, pSource) < Vector3.Distance(zero, pTarget))
			{
				eRModularRoad2.markersExt[num7].position = pSource;
				eRModularRoad3.markersExt[num8].position = pTarget;
			}
			else
			{
				eRModularRoad2.markersExt[num7].position = pTarget;
				eRModularRoad3.markersExt[num8].position = pSource;
			}
			eRModularRoad.markersExt[num6].position = centerPoint;
			if ((bool)cr.GetComponent<ERCrossings>())
			{
				cr.GetComponent<ERCrossings>().OQDCCQOCCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
			}
		}

		public static Vector3 OOQQOOQQDO(ERModularRoad road, int marker)
		{
			if (road == null)
			{
				return Vector3.zero;
			}
			Vector3 result = ((marker != 0) ? road.markersExt[road.markersExt.Count - 2].position : road.markersExt[1].position);
			result.y = 0f;
			return result;
		}

		public static void AssignSideObjects(ERModularBase scr, ERModularRoad OOOCDDCQCD, int roadTypeInt)
		{
			OOOCDDCQCD.soDataExt = new List<ERSORoadExt>();
			for (int i = 0; i < scr.roadTypes[roadTypeInt - 1].soDataExt.Count; i++)
			{
				if (scr.roadTypes[roadTypeInt - 1].soDataExt[i] != null)
				{
					OOOCDDCQCD.soDataExt.Add(ERSORoadExt.CreateInstance(scr.roadTypes[roadTypeInt - 1].soDataExt[i].sideObject));
					if (scr.roadTypes[roadTypeInt - 1].soDataExt[i].active)
					{
						OOOCDDCQCD.soDataExt[OOOCDDCQCD.soDataExt.Count - 1].active = true;
					}
				}
			}
			OOOCDDCQCD.sideObjectNames = OCQODDCQDD.OQCCQCDQQO(OOOCDDCQCD);
		}

		public static float LonLatDistance(double lat1, double lon1, double lat2, double lon2)
		{
			double num = 3.1415927410125732 * lat1 / 180.0;
			double num2 = 3.1415927410125732 * lat2 / 180.0;
			double num3 = lon1 - lon2;
			double d = 3.1415927410125732 * num3 / 180.0;
			double d2 = Math.Sin(num) * Math.Sin(num2) + Math.Cos(num) * Math.Cos(num2) * Math.Cos(d);
			d2 = Math.Acos(d2);
			d2 = d2 * 180.0 / Math.PI;
			d2 = d2 * 60.0 * 1.1515;
			return (float)d2 * 1.609344f;
		}
	}
}
