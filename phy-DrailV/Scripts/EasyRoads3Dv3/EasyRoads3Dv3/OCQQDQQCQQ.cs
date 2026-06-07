using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class OCQQDQQCQQ : MonoBehaviour
	{
		public static GameObject rtg;

		public static GameObject swgLeft;

		public static GameObject swgRight;

		public static Vector3 camdir;

		public static List<List<Vector3>> vecs = new List<List<Vector3>>();

		public static void ODDQDOODQD(ERModularBase baseScript, ERModularRoad scr)
		{
			LODGroup lODGroup = null;
			lODGroup = ((!(scr.gameObject.GetComponent<LODGroup>() == null)) ? scr.gameObject.GetComponent<LODGroup>() : scr.gameObject.AddComponent<LODGroup>());
			ERModularRoad[] array = (ERModularRoad[])Object.FindObjectsOfType(typeof(ERModularRoad));
			LOD[] array2 = new LOD[4];
			for (int i = 0; i < baseScript.LODLevelValues.Count; i++)
			{
				Transform transform = scr.transform.Find("LOD " + i);
				Renderer[] renderers = new Renderer[1] { transform.gameObject.GetComponent<Renderer>() };
				ref LOD reference = ref array2[i];
				reference = new LOD(baseScript.LODLevelValues[i], renderers);
			}
			lODGroup.SetLODS(array2);
			lODGroup.RecalculateBounds();
			if ((bool)scr.GetComponent<MeshRenderer>())
			{
				scr.GetComponent<MeshRenderer>().enabled = false;
			}
			if ((bool)scr.GetComponent<MeshCollider>())
			{
				scr.GetComponent<MeshCollider>().enabled = false;
			}
		}

		public static void CleanMeshData(Mesh m, List<List<int>> mtris, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs2, ref List<Vector3> normals, ref List<Vector4> tangents, ref List<Color> colors, ref List<List<int>> tris)
		{
			int[] array = new int[m.vertices.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			int num = 0;
			foreach (List<int> mtri in mtris)
			{
				tris.Add(new List<int>());
				for (int i = 0; i < mtri.Count; i++)
				{
					if (array.Length <= mtri[i])
					{
						continue;
					}
					if (array[mtri[i]] == -1)
					{
						vecs.Add(m.vertices[mtri[i]]);
						uvs.Add(m.uv[mtri[i]]);
						if (m.uv2.Length == 0)
						{
							uvs2.Add(m.uv[mtri[i]]);
						}
						else
						{
							uvs2.Add(m.uv2[mtri[i]]);
						}
						normals.Add(m.normals[mtri[i]]);
						tangents.Add(m.tangents[mtri[i]]);
						colors.Add(m.colors[mtri[i]]);
						array[mtri[i]] = vecs.Count - 1;
						tris[num].Add(vecs.Count - 1);
					}
					else
					{
						tris[num].Add(array[mtri[i]]);
					}
				}
				num++;
			}
		}

		public static void OOCCQOQQQC(Mesh mesh)
		{
			int[] triangles = mesh.triangles;
			Vector3[] vertices = mesh.vertices;
			Vector2[] array = mesh.uv;
			Vector3[] normals = mesh.normals;
			if (array == null)
			{
				array = new Vector2[vertices.Length];
			}
			if (array.Length != vertices.Length)
			{
				array = new Vector2[vertices.Length];
			}
			int num = triangles.Length;
			int num2 = vertices.Length;
			Vector3[] array2 = new Vector3[num2];
			Vector3[] array3 = new Vector3[num2];
			Vector4[] array4 = new Vector4[num2];
			for (long num3 = 0L; num3 < num; num3 += 3)
			{
				long num4 = triangles[num3];
				long num5 = triangles[num3 + 1];
				long num6 = triangles[num3 + 2];
				Vector3 vector = vertices[num4];
				Vector3 vector2 = vertices[num5];
				Vector3 vector3 = vertices[num6];
				Vector2 vector4 = array[num4];
				Vector2 vector5 = array[num5];
				Vector2 vector6 = array[num6];
				float num7 = vector2.x - vector.x;
				float num8 = vector3.x - vector.x;
				float num9 = vector2.y - vector.y;
				float num10 = vector3.y - vector.y;
				float num11 = vector2.z - vector.z;
				float num12 = vector3.z - vector.z;
				float num13 = vector5.x - vector4.x;
				float num14 = vector6.x - vector4.x;
				float num15 = vector5.y - vector4.y;
				float num16 = vector6.y - vector4.y;
				float num17 = 1f / (num13 * num16 - num14 * num15);
				Vector3 vector7 = new Vector3((num16 * num7 - num15 * num8) * num17, (num16 * num9 - num15 * num10) * num17, (num16 * num11 - num15 * num12) * num17);
				Vector3 vector8 = new Vector3((num13 * num8 - num14 * num7) * num17, (num13 * num10 - num14 * num9) * num17, (num13 * num12 - num14 * num11) * num17);
				array2[num4] += vector7;
				array2[num5] += vector7;
				array2[num6] += vector7;
				array3[num4] += vector8;
				array3[num5] += vector8;
				array3[num6] += vector8;
			}
			for (long num3 = 0L; num3 < num2; num3++)
			{
				Vector3 normal = normals[num3];
				Vector3 tangent = array2[num3];
				Vector3.OrthoNormalize(ref normal, ref tangent);
				array4[num3].x = tangent.x;
				array4[num3].y = tangent.y;
				array4[num3].z = tangent.z;
				array4[num3].w = ((Vector3.Dot(Vector3.Cross(normal, tangent), array3[num3]) < 0f) ? (-1f) : 1f);
			}
			mesh.tangents = array4;
		}

		public static void OCOODOCCOQ(Mesh mesh)
		{
			Vector2[] array = (Vector2[])mesh.uv.Clone();
			float y = array[array.Length - 1].y;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].y = array[i].y / y;
			}
			mesh.uv2 = array;
		}

		public static void GenerateWaypoints(ERModularRoad scr, float distance)
		{
			for (int i = 0; i < scr.transform.childCount; i++)
			{
				GameObject gameObject = scr.transform.GetChild(i).gameObject;
				if (gameObject.name.IndexOf("Waypoint") != -1)
				{
					Object.DestroyImmediate(gameObject);
					i--;
				}
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			int num5 = 1;
			GameObject gameObject2;
			for (int i = 1; i < scr.soSplinePoints.Count; i++)
			{
				num2 = Vector3.Distance(scr.soSplinePoints[i - 1], scr.soSplinePoints[i]);
				if (i == 1)
				{
					gameObject2 = new GameObject("Waypoint " + num5);
					gameObject2.transform.parent = scr.transform;
					gameObject2.transform.position = scr.soSplinePoints[0];
					num5++;
				}
				if (num + num2 > distance)
				{
					num3 = num + num2 - distance;
					num4 = num3 / num2;
					Vector3 position = Vector3.Lerp(scr.soSplinePoints[i - 1], scr.soSplinePoints[i], num4);
					gameObject2 = new GameObject("Waypoint " + num5);
					gameObject2.transform.parent = scr.transform;
					gameObject2.transform.position = position;
					num = num2 - num3;
					num5++;
				}
				else
				{
					num += num2;
				}
			}
			gameObject2 = new GameObject("Waypoint " + num5);
			gameObject2.transform.parent = scr.transform;
			gameObject2.transform.position = scr.soSplinePoints[scr.soSplinePoints.Count - 1];
			Debug.Log(num5 + " waypoint created as child objects of the selected road");
		}

		public static void OCCOCQDDQQ(List<SelectedObject> selectedObjects, int alignType)
		{
			if (selectedObjects.Count == 0 || selectedObjects[0].markers.Count < 2)
			{
				return;
			}
			List<int> list = new List<int>();
			list.Add(selectedObjects[0].markers[0]);
			selectedObjects[0].markers.RemoveAt(0);
			bool flag = false;
			int num;
			for (num = 0; num < selectedObjects[0].markers.Count; num++)
			{
				flag = false;
				for (int i = 0; i < list.Count; i++)
				{
					if (selectedObjects[0].markers[num] < list[i])
					{
						list.Insert(i, selectedObjects[0].markers[num]);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(selectedObjects[0].markers[num]);
				}
				selectedObjects[0].markers.RemoveAt(num);
				num--;
			}
			ERModularRoad roadScr = selectedObjects[0].roadScr;
			for (num = 0; num < list.Count; num++)
			{
				if (list[num] >= roadScr.markersExt.Count)
				{
					list.RemoveAt(num);
					num--;
				}
			}
			if (alignType == 0 || alignType == 1)
			{
				Vector3 position = roadScr.markersExt[list[0]].position;
				Vector3 position2 = roadScr.markersExt[list[list.Count - 1]].position;
				for (num = list[0] + 1; num < list[list.Count - 1]; num++)
				{
					Vector3 position3 = roadScr.markersExt[num].position;
					position3 = OCQCDQCQOQ.OQQQDCODQD(position, position2, position3);
					if (alignType == 1)
					{
						roadScr.baseScript.OCCDCQCOQC(ref position3);
					}
					roadScr.markersExt[num].position = position3;
				}
			}
			else if (alignType == 2)
			{
				float num2 = 0f;
				for (num = list[0]; num < list[list.Count - 1]; num++)
				{
					num2 += roadScr.markersExt[num].totalDistance;
				}
				float y = roadScr.markersExt[list[0]].position.y;
				float y2 = roadScr.markersExt[list[list.Count - 1]].position.y;
				float num3 = 0f;
				for (num = list[0]; num < list[list.Count - 1]; num++)
				{
					roadScr.markersExt[num].position.y = Mathf.Lerp(y, y2, num3 / num2);
					num3 += roadScr.markersExt[num].totalDistance;
				}
			}
		}

		public static void ODCQQOQQDQ(GameObject go, SideObject so, List<Vector3> vecs, List<Vector2> uvs, List<Vector2> uvs1, List<Color> color, List<Vector4> tangents, List<int> triangles, List<Vector3> normals, List<int> normalArray1, List<int> normalArray2)
		{
			Mesh mesh = null;
			mesh.Clear();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			List<Vector3> list = new List<Vector3>(mesh.normals);
			for (int i = 0; i < normalArray1.Count; i++)
			{
				int index = normalArray1[i];
				Vector3 value = (list[normalArray2[i]] = (mesh.normals[normalArray1[i]] + mesh.normals[normalArray2[i]]) * 0.5f);
				list[index] = value;
			}
			if (list.Count == mesh.normals.Length)
			{
				mesh.normals = list.ToArray();
			}
			if (so.collider)
			{
				if ((bool)go.GetComponent<MeshCollider>())
				{
					go.GetComponent<MeshCollider>().sharedMesh = null;
				}
				else
				{
					go.AddComponent<MeshCollider>();
				}
				go.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
		}

		public static void GetRoadShape(float width, int subSegments, ref List<Vector2> roadShape, ref List<float> uvs, ref List<float> uvs1, float dir)
		{
			float num = width / ((float)subSegments * dir);
			float num2 = (0f - width) * 0.5f * dir;
			roadShape.Clear();
			uvs.Clear();
			uvs1.Clear();
			for (int i = 0; i <= subSegments; i++)
			{
				roadShape.Add(new Vector2(num2 + (float)i * num, 0f));
				uvs.Add((float)i / ((float)subSegments * 1f));
				uvs1.Add((float)i / ((float)subSegments * 1f));
			}
		}

		public static void UpdateRoadType(ERModularBase scr, int index)
		{
			UpdateRoadTypeByRoad(scr, scr.OCCCQDQOCQ, index, null);
		}

		public static bool UpdateRoadTypeByRoad(ERModularBase scr, ERModularRoad road, int index, QDQDOOQQDQODD type)
		{
			if (index == 0)
			{
				road.roadType = 0.0;
				return false;
			}
			if (type == null)
			{
				type = scr.roadTypes[index - 1];
			}
			road.faceDistance = type.faceDistance;
			road.roadWidth = type.roadWidth;
			road.subSegments = type.subSegments;
			if (road.subSegments == 0)
			{
				road.subSegments = 1;
			}
			road.uvTiling = type.uvTiling;
			road.planarUVs = type.planarUVs;
			road.roadMaterial = type.roadMaterial;
			road.roadMaterials = type.roadMaterials;
			road.isSideObject = type.isSideObject;
			road.layer = type.layer;
			road.castShadow = type.castShadow;
			road.splatMapActive = type.splatMapActive;
			road.splatIndex = type.splatIndex;
			road.expandLevel = type.expandLevel;
			road.smoothLevel = type.smoothLevel;
			road.splatOpacity = type.splatOpacity;
			road.angleTreshold = type.angleTreshold;
			road.isCustomRoad = type.isCustomRoad;
			road.roadShape = new List<Vector2>(type.roadShape);
			road.doConnectionTri = new List<bool>(type.doConnectionTri);
			road.roadShapeUVs = new List<float>(type.roadShapeUVs);
			road.roadShapeUVs2 = new List<float>(type.roadShapeUVs2);
			if (road.roadShape.Count > 0 && road.roadShape[0].x <= road.roadShape[road.roadShape.Count - 1].x)
			{
				road.roadShape.Reverse();
			}
			road.roadShapeMatchCount = OQDDCCCQCC(road.roadShape);
			if (road.roadShapeUVs.Count == 0)
			{
				road.roadShapeUVs.Clear();
				road.roadShapeUVs.Add(0f);
				road.roadShapeUVs.Add(1f);
			}
			foreach (ERMarkerExt item in road.markersExt)
			{
				item.roadShape = new List<Vector2>(road.roadShape);
			}
			if (road.startPrefabScript != null)
			{
				QDOODOQQDQODD qDOODOQQDQODD = null;
				if (road.startPrefabScript != null && !road.startPrefabScript.isIConnector)
				{
					qDOODOQQDQODD = road.startPrefabScript.crossingElements[road.startConnectionSegment];
				}
				if (qDOODOQQDQODD != null)
				{
					Vector3 localScale = road.startPrefabScript.transform.localScale;
					if (type.id != qDOODOQQDQODD.roadType || localScale != new Vector3(1f, 1f, 1f))
					{
						List<Vector2> list = new List<Vector2>(qDOODOQQDQODD.roadShapeVecs);
						if (road.roadShape[0].x > 0f)
						{
							list.Reverse();
						}
						for (int i = 0; i < list.Count; i++)
						{
							list[i] = new Vector2(list[i].x * localScale.x, list[i].y * localScale.y);
						}
						road.markersExt[0].roadShape = list;
						road.markersExt[0].roadShapeDistanceMin = 0f;
						road.markersExt[0].roadShapeDistanceMax = 0.3f;
					}
				}
			}
			if (road.endPrefabScript != null)
			{
				QDOODOQQDQODD qDOODOQQDQODD = null;
				if (road.endPrefabScript != null && !road.endPrefabScript.isIConnector)
				{
					qDOODOQQDQODD = road.endPrefabScript.crossingElements[road.endConnectionSegment];
				}
				if (qDOODOQQDQODD != null)
				{
					Vector3 localScale = road.endPrefabScript.transform.localScale;
					if ((type.id != qDOODOQQDQODD.roadType && road.roadType != 0.0) || localScale != new Vector3(1f, 1f, 1f))
					{
						List<Vector2> list = new List<Vector2>(qDOODOQQDQODD.roadShapeVecs);
						if (road.roadShape[0].x > 0f)
						{
							list.Reverse();
						}
						for (int i = 0; i < list.Count; i++)
						{
							list[i] = new Vector2(list[i].x * localScale.x, list[i].y * localScale.y);
						}
						road.markersExt[road.markersExt.Count - 1].roadShape = list;
						road.markersExt[road.markersExt.Count - 1].roadShapeDistanceMin = 0.7f;
						road.markersExt[road.markersExt.Count - 1].roadShapeDistanceMax = 1f;
						road.markersExt[road.markersExt.Count - 2].roadShapeDistanceMin = 0.7f;
						road.markersExt[road.markersExt.Count - 2].roadShapeDistanceMax = 1f;
					}
				}
			}
			road.hardEdge = new List<bool>(type.hardEdge);
			road.terrainDeformation = type.terrainDeformation;
			GameObject gameObject = road.gameObject;
			gameObject.GetComponent<MeshRenderer>().sharedMaterial = type.roadMaterial;
			gameObject.GetComponent<MeshRenderer>().castShadows = type.castShadow;
			gameObject.layer = type.layer;
			road.roadType = type.id;
			road.roadMaterials = new Material[1];
			road.roadMaterials[0] = type.roadMaterial;
			road.OOOQOCDDOQ(type.decalPresets);
			return true;
		}

		public static int OQDDCCCQCC(List<Vector2> roadShape)
		{
			int num = 1;
			for (int i = 1; i < roadShape.Count; i++)
			{
				if ((double)Vector2.Distance(roadShape[i - 1], roadShape[i]) > 0.01)
				{
					num++;
				}
			}
			return num;
		}

		public static void OQCCQCOQQD(ref List<ERMarkerExt> tmpMarkersExt)
		{
			for (int i = 0; i < tmpMarkersExt.Count; i++)
			{
				if (tmpMarkersExt[i].controlType == 3 && tmpMarkersExt.Count > i + 2)
				{
					Vector3 position = tmpMarkersExt[i].position;
					Vector3 position2 = tmpMarkersExt[i + 1].position;
					Vector3 position3 = tmpMarkersExt[i + 2].position;
					position2.y = (position3.y = position.y);
					float num = Vector3.Distance(position, position2);
					float num2 = Vector3.Distance(position, position2);
					Vector3 normalized = (position2 - position).normalized;
					Vector3 normalized2 = (position2 - position3).normalized;
					float num3 = Vector3.Angle(normalized, normalized2);
				}
			}
		}

		public static void VisualizeRoadType(ERModularBase baseScript, QDQDOOQQDQODD rt, Vector3 pos, Vector3 dir)
		{
			Transform transform = null;
			if (baseScript != null)
			{
				transform = baseScript.transform.Find("Temp Road Type");
			}
			if (transform == null)
			{
				GameObject gameObject = new GameObject("Temp Road Type");
				transform = gameObject.transform;
				transform.parent = baseScript.transform;
			}
			else
			{
				rtg = GameObject.Find(rt.roadTypeName);
			}
			if (rtg == null)
			{
				rtg = new GameObject(rt.roadTypeName);
			}
			rtg.transform.parent = transform;
			dir.y = 0f;
			camdir = dir.normalized;
			pos.y -= 2f;
			rtg.transform.position = pos;
			if (rtg.GetComponent<MeshRenderer>() == null)
			{
				rtg.AddComponent<MeshRenderer>();
				if (rt.roadMaterial != null)
				{
					rtg.GetComponent<MeshRenderer>().sharedMaterial = rt.roadMaterial;
				}
			}
			if (rtg.GetComponent<MeshFilter>() == null)
			{
				rtg.AddComponent<MeshFilter>().sharedMesh = new Mesh();
			}
			rtg.GetComponent<MeshRenderer>().castShadows = false;
			OOOCDQDODQ(rt);
		}

		public static void OOOCDQDODQ(QDQDOOQQDQODD rt)
		{
			List<Vector3> list = new List<Vector3>();
			vecs.Clear();
			List<List<Vector2>> list2 = new List<List<Vector2>>();
			for (int i = 0; i < rt.roadShape.Count; i++)
			{
				vecs.Add(new List<Vector3>());
				list2.Add(new List<Vector2>());
			}
			float num = 0f;
			float num2 = rt.roadWidth * 3f;
			for (int i = 0; (float)i < num2; i++)
			{
				list.Add(camdir * num);
				num += 2f;
			}
			float num3 = rt.roadWidth * rt.uvTiling;
			num = 0f;
			for (int i = 0; i < list.Count; i++)
			{
				Vector3 vector = ((i > 0 && i < list.Count - 1) ? (list[i + 1] - list[i - 1]) : ((i != 0) ? (list[i] - list[i - 1]) : (list[i + 1] - list[0])));
				Vector3 normalized = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				if (i > 0)
				{
					num += Vector3.Distance(list[i - 1], list[i]);
				}
				float y = num / num3;
				Vector3 vector2 = list[i];
				for (int j = 0; j < rt.roadShape.Count; j++)
				{
					Vector3 vector3 = vector2;
					vector3.y += rt.roadShape[j].y;
					vecs[j].Add(vector3 + rt.roadShape[j].x * normalized);
					list2[j].Add(new Vector2(rt.roadShapeUVs[j], y));
				}
			}
			List<Vector3> list3 = new List<Vector3>();
			List<Vector2> list4 = new List<Vector2>();
			List<int> list5 = new List<int>();
			int count = vecs.Count;
			int num4 = 0;
			for (int i = 0; i < vecs[0].Count; i++)
			{
				for (int j = 0; j < count; j++)
				{
					list3.Add(vecs[j][i]);
					list4.Add(list2[j][i]);
					if (j < count - 1 && i < vecs[0].Count && rt.doConnectionTri[j])
					{
						list5.Add(num4 + j);
						list5.Add(num4 + j + count);
						list5.Add(num4 + j + count + 1);
						list5.Add(num4 + j);
						list5.Add(num4 + j + count + 1);
						list5.Add(num4 + j + 1);
					}
				}
				num4 = i * count;
			}
			Mesh sharedMesh = rtg.GetComponent<MeshFilter>().sharedMesh;
			sharedMesh.Clear();
			sharedMesh.vertices = list3.ToArray();
			sharedMesh.uv = list4.ToArray();
			sharedMesh.triangles = list5.ToArray();
			sharedMesh.RecalculateNormals();
			sharedMesh.RecalculateBounds();
			rtg.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
		}
	}
}
