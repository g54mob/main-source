using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ODDOQDDQCQ : MonoBehaviour
	{
		public static GameObject rtg;

		public static GameObject swgLeft;

		public static GameObject swgRight;

		public static Vector3 camdir;

		public static List<List<Vector3>> vecs = new List<List<Vector3>>();

		public static void ODOQOQOOQO(ERModularBase baseScript, ERModularRoad scr)
		{
			LODGroup lODGroup = null;
			lODGroup = ((!(scr.gameObject.GetComponent<LODGroup>() == null)) ? scr.gameObject.GetComponent<LODGroup>() : scr.gameObject.AddComponent<LODGroup>());
			ERModularRoad[] array = (ERModularRoad[])Object.FindObjectsOfType(typeof(ERModularRoad));
			LOD[] array2 = new LOD[baseScript.LODLevelValues.Count];
			for (int i = 0; i < baseScript.LODLevelValues.Count; i++)
			{
				Transform transform = scr.transform.Find("LOD " + i);
				Renderer[] renderers = new Renderer[1] { transform.gameObject.GetComponent<Renderer>() };
				array2[i] = new LOD(baseScript.LODLevelValues[i], renderers);
			}
			lODGroup.SetLODs(array2);
			lODGroup.RecalculateBounds();
			if ((bool)scr.GetComponent<MeshRenderer>())
			{
				scr.GetComponent<MeshRenderer>().enabled = false;
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
				for (int j = 0; j < mtri.Count; j++)
				{
					if (array.Length <= mtri[j])
					{
						continue;
					}
					if (array[mtri[j]] == -1)
					{
						vecs.Add(m.vertices[mtri[j]]);
						uvs.Add(m.uv[mtri[j]]);
						if (m.uv2.Length == 0)
						{
							uvs2.Add(m.uv[mtri[j]]);
						}
						else
						{
							uvs2.Add(m.uv2[mtri[j]]);
						}
						normals.Add(m.normals[mtri[j]]);
						tangents.Add(m.tangents[mtri[j]]);
						colors.Add(m.colors[mtri[j]]);
						array[mtri[j]] = vecs.Count - 1;
						tris[num].Add(vecs.Count - 1);
					}
					else
					{
						tris[num].Add(array[mtri[j]]);
					}
				}
				num++;
			}
		}

		public static void OOODCQQQCC(Mesh mesh)
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
			for (long num18 = 0L; num18 < num2; num18++)
			{
				Vector3 normal = normals[num18];
				Vector3 tangent = array2[num18];
				Vector3.OrthoNormalize(ref normal, ref tangent);
				array4[num18].x = tangent.x;
				array4[num18].y = tangent.y;
				array4[num18].z = tangent.z;
				array4[num18].w = ((Vector3.Dot(Vector3.Cross(normal, tangent), array3[num18]) < 0f) ? (-1f) : 1f);
			}
			mesh.tangents = array4;
		}

		public static void OQQDCQODDO(Mesh mesh)
		{
			Vector2[] array = (Vector2[])mesh.uv.Clone();
			float y = array[^1].y;
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
			for (int j = 1; j < scr.soSplinePoints.Count; j++)
			{
				num2 = Vector3.Distance(scr.soSplinePoints[j - 1], scr.soSplinePoints[j]);
				if (j == 1)
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
					Vector3 position = Vector3.Lerp(scr.soSplinePoints[j - 1], scr.soSplinePoints[j], num4);
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

		public static void OQQOOOQOCO(List<SelectedObject> selectedObjects, int alignType)
		{
			if (selectedObjects.Count == 0 || (selectedObjects[0].markers.Count < 2 && selectedObjects.Count == 1))
			{
				return;
			}
			if (selectedObjects.Count == 1)
			{
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
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j] >= roadScr.markersExt.Count)
					{
						list.RemoveAt(j);
						j--;
					}
				}
				if (alignType == 0 || alignType == 3 || alignType == 4)
				{
					Vector3 position = roadScr.markersExt[list[0]].position;
					Vector3 position2 = roadScr.markersExt[list[list.Count - 1]].position;
					float num2 = 0f;
					for (int k = list[0] + 1; k < list[list.Count - 1]; k++)
					{
						Vector3 position3 = roadScr.markersExt[k].position;
						num2 = position3.y;
						position3 = OQQOCDQCQD.OCOOQOQCDC(position, position2, position3);
						switch (alignType)
						{
						case 3:
							roadScr.baseScript.OQCCDQOQOO(ref position3);
							break;
						case 4:
							position3.y = num2;
							break;
						}
						roadScr.markersExt[k].position = position3;
					}
				}
				else if (alignType == 2)
				{
					float num3 = 0f;
					for (int l = list[0]; l < list[list.Count - 1]; l++)
					{
						num3 += roadScr.markersExt[l].totalDistance;
					}
					float y = roadScr.markersExt[list[0]].position.y;
					float y2 = roadScr.markersExt[list[list.Count - 1]].position.y;
					float num4 = 0f;
					for (int m = list[0]; m < list[list.Count - 1]; m++)
					{
						roadScr.markersExt[m].position.y = Mathf.Lerp(y, y2, num4 / num3);
						num4 += roadScr.markersExt[m].totalDistance;
					}
				}
				return;
			}
			if (alignType == 0 || alignType == 1)
			{
				Vector3 position4 = selectedObjects[0].roadScr.markersExt[selectedObjects[0].markers[0]].position;
				Vector3 position5 = selectedObjects[1].roadScr.markersExt[selectedObjects[1].markers[0]].position;
				int num5 = 1;
				if (selectedObjects[0].startEnd == 0)
				{
					num5 = -1;
				}
				int num6 = selectedObjects[0].markers[0];
				int count = selectedObjects[0].roadScr.markersExt.Count;
				for (int n = num6; n >= 0 && n < count; n += num5)
				{
					Vector3 position6 = selectedObjects[0].roadScr.markersExt[n].position;
					position6 = OQQOCDQCQD.OCOOQOQCDC(position4, position5, position6);
					if (alignType == 1)
					{
						selectedObjects[0].roadScr.baseScript.OQCCDQOQOO(ref position6);
					}
					selectedObjects[0].roadScr.markersExt[n].position = position6;
				}
				num5 = 1;
				if (selectedObjects[1].startEnd == 0)
				{
					num5 = -1;
				}
				num6 = selectedObjects[1].markers[0];
				count = selectedObjects[1].roadScr.markersExt.Count;
				for (int num7 = num6; num7 >= 0 && num7 < count; num7 += num5)
				{
					Vector3 position6 = selectedObjects[1].roadScr.markersExt[num7].position;
					position6 = OQQOCDQCQD.OCOOQOQCDC(position4, position5, position6);
					if (alignType == 1)
					{
						selectedObjects[1].roadScr.baseScript.OQCCDQOQOO(ref position6);
					}
					selectedObjects[1].roadScr.markersExt[num7].position = position6;
				}
				ERCrossingPrefabs eRCrossingPrefabs = null;
				if (selectedObjects[0].startEnd == 0)
				{
					eRCrossingPrefabs = selectedObjects[0].roadScr.startPrefabScript;
				}
				else if (selectedObjects[0].startEnd == 1)
				{
					eRCrossingPrefabs = selectedObjects[0].roadScr.endPrefabScript;
				}
				if (eRCrossingPrefabs != null)
				{
					Vector3 position6 = eRCrossingPrefabs.transform.position;
					position6 = OQQOCDQCQD.OCOOQOQCDC(position4, position5, position6);
					if (alignType == 1)
					{
						selectedObjects[0].roadScr.baseScript.OQCCDQOQOO(ref position6);
					}
					eRCrossingPrefabs.transform.position = position6;
				}
				return;
			}
			float y3 = selectedObjects[0].roadScr.markersExt[selectedObjects[0].markers[0]].position.y;
			float y4 = selectedObjects[1].roadScr.markersExt[selectedObjects[1].markers[0]].position.y;
			float num8 = 0f;
			float num9 = 0f;
			int num10 = 1;
			if (selectedObjects[0].startEnd == 0)
			{
				num10 = -1;
			}
			int num11 = selectedObjects[0].markers[0];
			if (num10 == -1)
			{
				num11--;
			}
			int count2 = selectedObjects[0].roadScr.markersExt.Count;
			for (int num12 = num11; num12 >= 0 && num12 < count2; num12 += num10)
			{
				num9 += selectedObjects[0].roadScr.markersExt[num12].totalDistance;
			}
			num10 = 1;
			if (selectedObjects[1].startEnd == 0)
			{
				num10 = -1;
			}
			num11 = selectedObjects[1].markers[0];
			if (num10 == -1)
			{
				num11--;
			}
			count2 = selectedObjects[1].roadScr.markersExt.Count;
			for (int num13 = num11; num13 >= 0 && num13 < count2; num13 += num10)
			{
				num9 += selectedObjects[0].roadScr.markersExt[num13].totalDistance;
			}
			Debug.Log("To Do: we have to add distances to I Connector ");
			num10 = 1;
			if (selectedObjects[0].startEnd == 0)
			{
				num10 = -1;
			}
			num11 = selectedObjects[0].markers[0];
			if (num10 == -1)
			{
				num11--;
			}
			count2 = selectedObjects[0].roadScr.markersExt.Count;
			num8 += selectedObjects[0].roadScr.markersExt[num11].totalDistance;
			for (int num14 = num11; num14 >= 0 && num14 < count2; num14 += num10)
			{
				selectedObjects[0].roadScr.markersExt[num14].position.y = Mathf.Lerp(y3, y4, num8 / num9);
				num8 += selectedObjects[0].roadScr.markersExt[num14].totalDistance;
			}
			int num15 = 0;
			num10 = 1;
			if (selectedObjects[1].startEnd == 0)
			{
				num15 = selectedObjects[1].roadScr.markersExt.Count - 1;
				num10 = -1;
			}
			for (int num16 = num15; num16 >= 0 && num16 < count2; num16 += num10)
			{
				selectedObjects[1].roadScr.markersExt[num16].position.y = Mathf.Lerp(y3, y4, num8 / num9);
				if (num16 > 0 && num16 < selectedObjects[1].roadScr.markersExt.Count - 1)
				{
					num8 += selectedObjects[1].roadScr.markersExt[num16 + num10].totalDistance;
				}
			}
		}

		public static void ODCODCQCOO(GameObject go, SideObject so, List<Vector3> vecs, List<Vector2> uvs, List<Vector2> uvs1, List<Color> color, List<Vector4> tangents, List<int> triangles, List<Vector3> normals, List<int> normalArray1, List<int> normalArray2)
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

		public static void GetRoadShape(float oldWidth, QDQDOOQQDQODD roadType, float dir, bool bothAxis = false)
		{
			float num = roadType.roadWidth / oldWidth;
			if (roadType.roadShape.Count > 0 && roadType.roadShapeExt2.Count > 0)
			{
				for (int i = 0; i < roadType.roadShape.Count; i++)
				{
					Vector2 value = roadType.roadShape[i];
					value.x *= num;
					if (bothAxis)
					{
						value.y *= num;
					}
					roadType.roadShape[i] = value;
				}
				if (roadType.roadShapeExt2.Count == 0)
				{
					RebuildMainRoadShape(roadType);
					return;
				}
				for (int j = 0; j < roadType.roadShapeExt2.Count; j++)
				{
					Vector2 value2 = roadType.roadShapeExt2[j];
					value2.x *= num;
					if (bothAxis)
					{
						value2.y *= num;
					}
					roadType.roadShapeExt2[j] = value2;
					roadType.roadShapeData.nodes[j] = value2;
				}
			}
			else
			{
				GetRoadShape(roadType.roadWidth, roadType.subSegments, ref roadType.roadShape, ref roadType.roadShapeUVs, ref roadType.roadShapeUVs2, -1f);
			}
		}

		public static void UpdateRoadType(ERModularBase scr, int index)
		{
			UpdateRoadTypeByRoad(scr, scr.OOOCDDCQCD, index, null);
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
			road.uv4Type = type.uv4Type;
			road.detailDistance = type.detailDistance;
			road.roadMaterial = type.roadMaterial;
			road.roadMaterials = type.roadMaterials;
			road.roadPhysicsMaterial = type.roadPhysicsMaterial;
			road.roadPhysicsMaterials = type.roadPhysicsMaterials;
			road.isSideObject = type.isSideObject;
			int layer = (road.gameObject.layer = type.layer);
			road.layer = layer;
			if (!string.IsNullOrEmpty(type.tag))
			{
				string text = (road.gameObject.tag = type.tag);
				road.tag = text;
			}
			road.castShadow = type.castShadow;
			road.splatMapActive = type.splatMapActive;
			road.splatIndex = type.splatIndex;
			road.expandLevel = type.expandLevel;
			road.smoothLevel = type.smoothLevel;
			road.splatOpacity = type.splatOpacity;
			road.angleTreshold = type.angleTreshold;
			road.isCustomRoad = type.isCustomRoad;
			road.followTerrainContours = type.followTerrainContours;
			road.terrainContoursOffset = type.terrainContoursOffset;
			road.roadShape = new List<Vector2>(type.roadShape);
			road.doConnectionTri = new List<bool>(type.doConnectionTri);
			road.roadShapeUVs = new List<float>(type.roadShapeUVs);
			road.roadShapeUVs2 = new List<float>(type.roadShapeUVs2);
			if (road.roadShape.Count > 0 && road.roadShape[0].x <= road.roadShape[road.roadShape.Count - 1].x)
			{
				road.roadShape.Reverse();
			}
			if (road.roadShape.Count != road.roadShapeMaterialInts.Count)
			{
				road.roadShapeMaterialInts.Clear();
				for (int i = 0; i < road.roadShape.Count; i++)
				{
					road.roadShapeMaterialInts.Add(0);
				}
			}
			road.roadShapeMaterialIntCounts.Clear();
			for (int j = 0; j < road.roadShapeMaterialInts.Count; j++)
			{
				if (road.roadShapeMaterialInts[j] >= road.roadShapeMaterialIntCounts.Count)
				{
					while (road.roadShapeMaterialInts[j] >= road.roadShapeMaterialIntCounts.Count)
					{
						road.roadShapeMaterialIntCounts.Add(0);
					}
				}
				road.roadShapeMaterialIntCounts[road.roadShapeMaterialInts[j]]++;
			}
			road.roadShapeMatchCount = ODCQDDQCCD(road.roadShape);
			if (road.roadShapeUVs.Count == 0)
			{
				road.roadShapeUVs.Clear();
				road.roadShapeUVs.Add(0f);
				road.roadShapeUVs.Add(1f);
			}
			foreach (ERMarkerExt item in road.markersExt)
			{
				item.roadShape = new List<Vector2>(road.roadShape);
				item.followTerrainContours = road.followTerrainContours;
			}
			if (road.startPrefabScript != null)
			{
				QDOODOQQDQODD qDOODOQQDQODD = null;
				if (road.startPrefabScript != null && !road.startPrefabScript.isIConnector)
				{
					qDOODOQQDQODD = road.startPrefabScript.crossingElements[road.startConnectionSegment];
				}
				if (qDOODOQQDQODD != null && !road.startPrefabScript.isFlexConnector)
				{
					Vector3 localScale = road.startPrefabScript.transform.localScale;
					if (type.id != qDOODOQQDQODD.roadType || localScale != new Vector3(1f, 1f, 1f))
					{
						List<Vector2> list = new List<Vector2>(qDOODOQQDQODD.roadShapeVecs);
						if (road.roadShape[0].x > 0f)
						{
							list.Reverse();
						}
						for (int k = 0; k < list.Count; k++)
						{
							list[k] = new Vector2(list[k].x * localScale.x, list[k].y * localScale.y);
						}
						road.markersExt[0].roadShape = list;
						road.markersExt[0].roadShapeDistanceMin = 0f;
						road.markersExt[0].roadShapeDistanceMax = 0.3f;
					}
				}
			}
			if (road.endPrefabScript != null)
			{
				QDOODOQQDQODD qDOODOQQDQODD2 = null;
				if (road.endPrefabScript != null && !road.endPrefabScript.isIConnector)
				{
					qDOODOQQDQODD2 = road.endPrefabScript.crossingElements[road.endConnectionSegment];
				}
				if (qDOODOQQDQODD2 != null && !road.endPrefabScript.isFlexConnector)
				{
					Vector3 localScale2 = road.endPrefabScript.transform.localScale;
					if ((type.id != qDOODOQQDQODD2.roadType && road.roadType != 0.0) || localScale2 != new Vector3(1f, 1f, 1f))
					{
						List<Vector2> list2 = new List<Vector2>(qDOODOQQDQODD2.roadShapeVecs);
						if (road.roadShape[0].x > 0f)
						{
							list2.Reverse();
						}
						for (int l = 0; l < list2.Count; l++)
						{
							list2[l] = new Vector2(list2[l].x * localScale2.x, list2[l].y * localScale2.y);
						}
						road.markersExt[road.markersExt.Count - 1].roadShape = list2;
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
			if (gameObject.GetComponent<MeshCollider>() != null)
			{
				if (type.roadPhysicsMaterial == null)
				{
					gameObject.GetComponent<MeshCollider>().sharedMaterial = null;
				}
				else
				{
					gameObject.GetComponent<MeshCollider>().sharedMaterial = type.roadPhysicsMaterial;
				}
			}
			if (type.castShadow)
			{
				gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
			}
			else
			{
				gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			gameObject.layer = type.layer;
			road.roadType = type.id;
			road.roadMaterials = new Material[1];
			road.roadMaterials[0] = type.roadMaterial;
			road.ODOQQDDQOC(type.decalPresets);
			if (type.isSideObject)
			{
				if (gameObject.GetComponent<MeshRenderer>() != null)
				{
					Object.DestroyImmediate(gameObject.GetComponent<MeshRenderer>());
				}
				if (gameObject.GetComponent<MeshCollider>() != null)
				{
					Object.DestroyImmediate(gameObject.GetComponent<MeshCollider>());
				}
				if (gameObject.GetComponent<MeshFilter>() != null)
				{
					Object.DestroyImmediate(gameObject.GetComponent<MeshFilter>());
				}
				if (road.surfaceMesh != null)
				{
					Object.DestroyImmediate(road.surfaceMesh);
				}
				road.snapToTerrain = true;
			}
			else
			{
				road.snapToTerrain = false;
			}
			return true;
		}

		public static int ODCQDDQCCD(List<Vector2> roadShape)
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

		public static void OQDDOCQOQQ(ref List<ERMarkerExt> tmpMarkersExt)
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

		public static void OODDOQCCDQ(QDQDOOQQDQODD roadType)
		{
			if (roadType.roadShapeData.symmetrical)
			{
				List<Vector2> nodes = roadType.roadShapeData.nodes;
				int selectedNode = roadType.roadShapeData.selectedNode;
				Vector2 value = roadType.roadShapeData.nodes[selectedNode];
				if (value.y < -0.05f)
				{
					value.y = -0.05f;
					roadType.roadShapeData.nodes[selectedNode] = value;
				}
				value.x = 0f - roadType.roadShapeData.nodes[selectedNode].x;
				if (selectedNode != nodes.Count - selectedNode - 1)
				{
					roadType.roadShapeData.nodes[nodes.Count - selectedNode - 1] = value;
				}
			}
			int count = roadType.roadShapeExt2.Count;
			roadType.roadShapeExt2 = new List<Vector2>(roadType.roadShapeData.nodes);
			if (count != roadType.roadShapeExt2.Count || !roadType.preserveUVs)
			{
				roadType.roadShapeExtUVs2 = OQQOCDQCQD.OCDQQOCDCQ(roadType.roadShapeData.nodes);
			}
			roadType.roadShapeData.IsSymmetrical();
			RebuildMainRoadShape(roadType);
		}

		public static void RebuildMainRoadShape(QDQDOOQQDQODD roadType)
		{
			int outerLaneMarkingLeftIndex = roadType.roadShapeData.outerLaneMarkingLeftIndex;
			int outerLaneMarkingRightIndex = roadType.roadShapeData.outerLaneMarkingRightIndex;
			bool includeOuterlaneLeftInShape = roadType.roadShapeData.includeOuterlaneLeftInShape;
			bool includeOuterlaneRightInShape = roadType.roadShapeData.includeOuterlaneRightInShape;
			int outerOuterLaneMarkingLeftIndex = roadType.roadShapeData.outerOuterLaneMarkingLeftIndex;
			int outerOuterLaneMarkingRightIndex = roadType.roadShapeData.outerOuterLaneMarkingRightIndex;
			if (roadType.roadShapeExt2.Count == 0)
			{
				roadType.roadShapeExtUVs2.Clear();
				roadType.doConnectionTriExt.Clear();
				roadType.roadShapeExt2 = new List<Vector2>(roadType.roadShape);
				roadType.roadShapeExtUVs2 = new List<float>(roadType.roadShapeUVs);
				roadType.doConnectionTriExt = new List<bool>(roadType.doConnectionTri);
				if (roadType.roadShapeData.isset)
				{
					roadType.roadShapeData.hardEdge = new List<bool>(roadType.hardEdge);
				}
			}
			roadType.roadShape.Clear();
			roadType.roadShapeUVs.Clear();
			roadType.hardEdge.Clear();
			roadType.doConnectionTri.Clear();
			roadType.maxRoadheight = 0f;
			for (int i = 0; i < roadType.roadShapeExt2.Count; i++)
			{
				if (roadType.doConnectionTriExt.Count <= i)
				{
					roadType.doConnectionTriExt.Add(item: true);
				}
				if (i == 0 || i == roadType.roadShapeExt2.Count - 1 || ((i != outerLaneMarkingLeftIndex || includeOuterlaneLeftInShape) && (i != outerLaneMarkingRightIndex || includeOuterlaneRightInShape) && i != outerOuterLaneMarkingLeftIndex && i != outerOuterLaneMarkingRightIndex))
				{
					roadType.roadShape.Add(roadType.roadShapeExt2[i]);
					roadType.roadShapeUVs.Add(roadType.roadShapeExtUVs2[i]);
					if (roadType.roadShapeData.hardEdge.Count > i)
					{
						roadType.hardEdge.Add(roadType.roadShapeData.hardEdge[i]);
					}
					else
					{
						roadType.hardEdge.Add(item: false);
						roadType.roadShapeData.hardEdge.Add(item: false);
					}
					roadType.doConnectionTri.Add(roadType.doConnectionTriExt[i]);
				}
				if (roadType.roadShapeExt2[i].y > roadType.maxRoadheight)
				{
					roadType.maxRoadheight = roadType.roadShapeExt2[i].y;
				}
			}
			if (roadType.roadShape.Count > 0)
			{
				Vector2 a = roadType.roadShape[0];
				a.y = 0f;
				Vector2 b = roadType.roadShape[roadType.roadShape.Count - 1];
				b.y = 0f;
				roadType.roadWidth = Vector2.Distance(a, b);
			}
			else
			{
				roadType.roadWidth = 0f;
			}
		}

		public static void OQQOOOOQCC(QDQDOOQQDQODD roadType, ref List<Vector2> roadShape, ref List<float> roadShapeUVs, ref List<bool> doConnectionTri, ref List<bool> hardEdge, ref int currentMostLeftInt, ref int currentMostRightInt, ref int sectionRoadShapeCols, int leftright, int lineIndexTarget, bool transition, List<Vector2> origRoadShape)
		{
			if (roadType == null)
			{
				return;
			}
			int outerLaneMarkingLeftIndex = roadType.roadShapeData.outerLaneMarkingLeftIndex;
			int outerLaneMarkingRightIndex = roadType.roadShapeData.outerLaneMarkingRightIndex;
			bool flag = roadType.roadShapeData.includeOuterlaneLeftInShape;
			bool flag2 = roadType.roadShapeData.includeOuterlaneRightInShape;
			int outerOuterLaneMarkingLeftIndex = roadType.roadShapeData.outerOuterLaneMarkingLeftIndex;
			int outerOuterLaneMarkingRightIndex = roadType.roadShapeData.outerOuterLaneMarkingRightIndex;
			bool flag3 = false;
			bool flag4 = false;
			int num = 0;
			int num2 = roadType.roadShapeExt2.Count - 1;
			roadShape.Clear();
			roadShapeUVs.Clear();
			hardEdge.Clear();
			doConnectionTri.Clear();
			if (roadType.roadShapeExt2 == null || roadType.roadShapeExt2.Count < 2)
			{
				Debug.Log("EasyRoads3Dv3: Road type " + roadType.roadTypeName + ", missing road shape data");
				return;
			}
			bool flag5 = false;
			if (origRoadShape.Count > 0 && origRoadShape[0].x > origRoadShape[origRoadShape.Count - 1].x)
			{
				flag5 = true;
			}
			if (!flag5)
			{
				if (leftright == 0)
				{
					if (lineIndexTarget == 0 || (transition && lineIndexTarget != 2))
					{
						flag = true;
					}
					if (lineIndexTarget == 1)
					{
						num = outerOuterLaneMarkingLeftIndex;
						flag3 = true;
					}
					if (lineIndexTarget == 2)
					{
						flag3 = true;
					}
				}
				else
				{
					if (lineIndexTarget == 0 || (transition && lineIndexTarget != 2))
					{
						flag2 = true;
					}
					if (lineIndexTarget == 1)
					{
						flag4 = true;
						num2 = outerOuterLaneMarkingRightIndex;
					}
					if (lineIndexTarget == 2)
					{
						flag4 = true;
					}
				}
			}
			else if (leftright == 1)
			{
				if (lineIndexTarget == 0 || (transition && lineIndexTarget != 2))
				{
					flag = true;
				}
				if (lineIndexTarget == 1)
				{
					flag3 = true;
					num = outerOuterLaneMarkingLeftIndex;
				}
				if (lineIndexTarget == 2)
				{
					flag3 = true;
				}
			}
			else
			{
				if (lineIndexTarget == 0 || (transition && lineIndexTarget != 2))
				{
					flag2 = true;
				}
				if (lineIndexTarget == 1)
				{
					flag4 = true;
					num2 = outerOuterLaneMarkingRightIndex;
				}
				if (lineIndexTarget == 2)
				{
					flag4 = true;
				}
			}
			for (int i = 0; i < roadType.roadShapeExt2.Count; i++)
			{
				if (!(i != outerLaneMarkingLeftIndex || flag) || !(i != outerLaneMarkingRightIndex || flag2) || !(i != outerOuterLaneMarkingLeftIndex || flag3) || !(i != outerOuterLaneMarkingRightIndex || flag4))
				{
					continue;
				}
				if (!flag5)
				{
					if ((leftright == 0 && (i >= outerLaneMarkingLeftIndex || transition) && i >= num) || (leftright == 1 && (i <= outerLaneMarkingRightIndex || transition) && i <= num2))
					{
						sectionRoadShapeCols++;
						if (roadType.roadShapeData.hardEdge[i])
						{
							sectionRoadShapeCols++;
						}
						roadShape.Add(roadType.roadShapeExt2[i]);
						roadShapeUVs.Add(roadType.roadShapeExtUVs2[i]);
						hardEdge.Add(roadType.roadShapeData.hardEdge[i]);
						doConnectionTri.Add(roadType.doConnectionTriExt[i]);
					}
				}
				else if ((leftright == 0 && (i <= outerLaneMarkingRightIndex || transition || (i == outerOuterLaneMarkingRightIndex && flag4)) && i <= num2) || (leftright == 1 && (i >= outerLaneMarkingLeftIndex || transition || (i == outerOuterLaneMarkingLeftIndex && flag3)) && i >= num))
				{
					sectionRoadShapeCols++;
					if (roadType.roadShapeData.hardEdge[i])
					{
						sectionRoadShapeCols++;
					}
					roadShape.Add(roadType.roadShapeExt2[i]);
					roadShapeUVs.Add(roadType.roadShapeExtUVs2[roadType.roadShapeExt2.Count - i - 1]);
					hardEdge.Add(roadType.roadShapeData.hardEdge[i]);
					doConnectionTri.Add(roadType.doConnectionTriExt[i]);
				}
			}
			if (origRoadShape.Count > 0 && origRoadShape[0].x > origRoadShape[origRoadShape.Count - 1].x)
			{
				roadShape.Reverse();
				roadShapeUVs.Reverse();
				hardEdge.Reverse();
				doConnectionTri.Reverse();
			}
			currentMostLeftInt = 0;
			currentMostRightInt = roadShape.Count - 1;
		}

		public static List<int> ODQCQCOCDC(List<Vector2> _rs1, List<bool> _hd1, int cols1, List<Vector2> _rs2, List<bool> _hd2, int cols2, ref List<int> tris, bool flipNormals, int vecCount, int i1, int i2, int last1, int last2)
		{
			List<Vector2> list = new List<Vector2>(_rs1);
			List<bool> list2 = new List<bool>(_hd1);
			List<Vector2> list3 = new List<Vector2>(_rs2);
			List<bool> list4 = new List<bool>(_hd2);
			if (list[0].x > list[list.Count - 1].x)
			{
				list.Reverse();
				list2.Reverse();
				list3.Reverse();
				list4.Reverse();
			}
			int num = vecCount + cols1;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			while (i1 < cols1 && i2 < cols2 && num4 < 10)
			{
				if (i1 < last1 - 2 && list[i1].x == list3[i2].x && i2 < last2 - 2 && list[i1 + 1].x == list3[i2 + 1].x)
				{
					tris.Add(vecCount + i1 + num2);
					tris.Add(num + i2 + num3);
					tris.Add(num + i2 + num3 + 1);
					tris.Add(vecCount + i1 + num2);
					tris.Add(num + i2 + num3 + 1);
					tris.Add(vecCount + i1 + num2 + 1);
					if (i2 < list3.Count)
					{
						i2++;
					}
					if (list2[i1])
					{
						num2++;
					}
					if (list4[i2])
					{
						num3++;
					}
				}
				else if (i1 < last1 - 1 && i2 < last2 - 1 && list3[i2 + 1].x < list[i1 + 1].x)
				{
					tris.Add(vecCount + i1 + num2);
					tris.Add(num + i2 + num3);
					tris.Add(num + i2 + num3 + 1);
					i2++;
					float num5 = list3[i2 + 1].x - list3[i2].x;
					float num6 = list[i1 + 1].x - list[i1].x;
					if (2f * num5 > num6)
					{
						tris.Add(vecCount + num2 + i1);
						tris.Add(num + num3 + i2);
						tris.Add(vecCount + num2 + i1 + 1);
						i1++;
					}
					if (list[i1].x == list3[i2].x)
					{
						if (list2[i1])
						{
							num2++;
						}
						if (list4[i2])
						{
							num3++;
						}
					}
				}
				else if (i1 < last1 - 1 && i2 < last2 - 1 && list[i1 + 1].x < list3[i2 + 1].x)
				{
					tris.Add(vecCount + i1 + num2);
					tris.Add(num + i2 + num3);
					tris.Add(vecCount + i1 + num2 + 1);
					i1++;
					float num7 = list3[i2 + 1].x - list3[i2].x;
					float num8 = list[i1 + 1].x - list[i1].x;
					if (2f * num8 > num7)
					{
						tris.Add(num + num3 + i2);
						tris.Add(num + num3 + i2 + 1);
						tris.Add(vecCount + num2 + i1);
						i2++;
					}
					if (list[i1].x == list3[i2].x)
					{
						if (list2[i1])
						{
							num2++;
						}
						if (list4[i2])
						{
							num3++;
						}
					}
				}
				else if (i1 < last1 && i2 < last2 - 1 && list3[i2].x < list[i1].x)
				{
					tris.Add(vecCount + i1 + num2);
					tris.Add(num + i2 + num3);
					tris.Add(num + i2 + num3 + 1);
					i2++;
					if (list[i1].x == list3[i2].x)
					{
						if (list2[i1])
						{
							num2++;
						}
						if (list4[i2])
						{
							num3++;
						}
					}
				}
				else if (i1 < last1 - 1 && i2 < last2 && list[i1].x < list3[i2].x)
				{
					tris.Add(vecCount + i1 + num2);
					tris.Add(num + i2 + num3);
					tris.Add(vecCount + i1 + num2 + 1);
					i1++;
					if (list[i1].x == list3[i2].x)
					{
						if (list2[i1])
						{
							num2++;
						}
						if (list4[i2])
						{
							num3++;
						}
					}
				}
				num4++;
			}
			return tris;
		}

		public static void ODCQCCCDOC(QDQDOOQQDQODD roadType, ref List<Vector2> roadShapeVecs, ref List<float> roadShapeUVs, ref List<bool> hardEdge, ref int rightOuterIndex)
		{
			int outerLaneMarkingLeftIndex = roadType.roadShapeData.outerLaneMarkingLeftIndex;
			int outerLaneMarkingRightIndex = roadType.roadShapeData.outerLaneMarkingRightIndex;
			bool includeOuterlaneLeftInShape = roadType.roadShapeData.includeOuterlaneLeftInShape;
			bool includeOuterlaneRightInShape = roadType.roadShapeData.includeOuterlaneRightInShape;
			int outerOuterLaneMarkingLeftIndex = roadType.roadShapeData.outerOuterLaneMarkingLeftIndex;
			int outerOuterLaneMarkingRightIndex = roadType.roadShapeData.outerOuterLaneMarkingRightIndex;
			roadShapeVecs.Clear();
			roadShapeUVs.Clear();
			hardEdge.Clear();
			for (int i = 0; i < roadType.roadShapeExt2.Count; i++)
			{
				if ((i != outerLaneMarkingLeftIndex || includeOuterlaneLeftInShape) && i != outerOuterLaneMarkingRightIndex)
				{
					roadShapeVecs.Add(roadType.roadShapeExt2[i]);
					roadShapeUVs.Add(roadType.roadShapeExtUVs2[i]);
					hardEdge.Add(roadType.roadShapeData.hardEdge[i]);
					if (i == outerLaneMarkingRightIndex)
					{
						rightOuterIndex = roadShapeVecs.Count - 1;
					}
				}
			}
		}

		public static void VisualizeRoadType(ERModularBase baseScript, GameObject prefab, QDQDOOQQDQODD rt, Vector3 pos, Vector3 dir)
		{
			Transform transform = null;
			if (baseScript != null)
			{
				transform = baseScript.transform.Find("Temp Road Type");
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
			}
			else
			{
				rtg = prefab;
			}
			if (rtg == null)
			{
				rtg = new GameObject(rt.roadTypeName);
			}
			if (baseScript != null)
			{
				rtg.transform.parent = transform;
				pos.y -= 2f;
			}
			dir.y = 0f;
			camdir = dir.normalized;
			rtg.transform.position = pos;
			if (rtg.GetComponent<MeshRenderer>() == null)
			{
				rtg.AddComponent<MeshRenderer>();
			}
			if (ERModularBase.isHDRP || ERModularBase.isURP)
			{
				rtg.GetComponent<MeshRenderer>().renderingLayerMask = OQQOCDQCQD.GetLayerMask(rt.renderingLayerMask, includeDefault: true);
			}
			if (rt.roadMaterial != null && rtg.GetComponent<MeshRenderer>().sharedMaterial == null)
			{
				rtg.GetComponent<MeshRenderer>().sharedMaterial = rt.roadMaterial;
			}
			if (rtg.GetComponent<MeshFilter>() == null)
			{
				rtg.AddComponent<MeshFilter>().sharedMesh = new Mesh();
			}
			rtg.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			OCQODDQQCQ(rt);
		}

		public static void RemoveSidewalks(string name)
		{
			if (rtg == null)
			{
				return;
			}
			int childCount = rtg.transform.childCount;
			for (int num = childCount - 1; num >= 0; num--)
			{
				if (rtg.transform.GetChild(num).name == name)
				{
					Object.DestroyImmediate(rtg.transform.GetChild(num).gameObject);
				}
			}
		}

		public static void RemoveProjectors()
		{
			if (!(rtg == null))
			{
				int childCount = rtg.transform.childCount;
				for (int num = childCount - 1; num >= 0; num--)
				{
					Object.DestroyImmediate(rtg.transform.GetChild(num).gameObject);
				}
			}
		}

		public static void OCQODDQQCQ(QDQDOOQQDQODD rt)
		{
			List<Vector3> list = new List<Vector3>();
			vecs.Clear();
			List<List<Vector2>> list2 = new List<List<Vector2>>();
			rt.roadShapeData.nodesV3.Clear();
			if (rt.roadShapeExt2.Count == 0)
			{
				rt.roadShapeExt2 = new List<Vector2>(rt.roadShape);
				rt.roadShapeExtUVs2 = new List<float>(rt.roadShapeUVs);
				rt.doConnectionTriExt = new List<bool>(rt.doConnectionTri);
			}
			if (rt.hardEdge.Count != rt.roadShapeExt2.Count)
			{
				Debug.Log("EasyRoads3Dv3 Warning: incorrect road type data detected for road type: " + rt.roadTypeName + ". Please report this issue.");
			}
			for (int i = 0; i < rt.roadShapeExt2.Count; i++)
			{
				vecs.Add(new List<Vector3>());
				list2.Add(new List<Vector2>());
			}
			float num = 0f;
			float num2 = rt.roadWidth * 1f;
			if (num2 < 5f)
			{
				num2 = 5f;
			}
			for (int j = 0; (float)j < num2; j++)
			{
				list.Add(camdir * num);
				num += 2f;
			}
			float num3 = 5f * rt.uvTiling;
			num = 0f;
			for (int k = 0; k < list.Count; k++)
			{
				Vector3 vector = ((k > 0 && k < list.Count - 1) ? (list[k + 1] - list[k - 1]) : ((k != 0) ? (list[k] - list[k - 1]) : (list[k + 1] - list[0])));
				Vector3 normalized = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				if (k > 0)
				{
					num += Vector3.Distance(list[k - 1], list[k]);
				}
				float y = num / num3;
				Vector3 vector2 = list[k];
				for (int l = 0; l < rt.roadShapeExt2.Count; l++)
				{
					Vector3 vector3 = vector2;
					vector3.y += rt.roadShapeExt2[l].y;
					Vector3 item = vector3 + rt.roadShapeExt2[l].x * normalized;
					vecs[l].Add(item);
					list2[l].Add(new Vector2(rt.roadShapeExtUVs2[l], y));
					if (k == 0)
					{
						rt.roadShapeData.nodesV3.Add(item);
					}
				}
			}
			if (rt.doConnectionTri.Count != rt.roadShape.Count)
			{
				rt.doConnectionTri.Clear();
				int num4 = 0;
				foreach (Vector2 item2 in rt.roadShape)
				{
					rt.doConnectionTri.Add(item: true);
					num4++;
				}
			}
			if (rt.doConnectionTriExt.Count != rt.roadShapeExt2.Count)
			{
				rt.doConnectionTriExt.Clear();
				int num5 = 0;
				foreach (Vector2 item3 in rt.roadShapeExt2)
				{
					rt.doConnectionTriExt.Add(item: true);
					num5++;
				}
			}
			int num6 = 0;
			int num7 = 0;
			foreach (bool item4 in rt.roadShapeData.hardEdge)
			{
				if (rt.roadShapeData.hardEdge[num6])
				{
					num7++;
				}
				num6++;
			}
			List<Vector3> list3 = new List<Vector3>();
			List<Vector2> list4 = new List<Vector2>();
			List<int> list5 = new List<int>();
			int count = vecs.Count;
			int num8 = 0;
			if (vecs.Count == 0)
			{
				Debug.Log("EasyRoads3Dv3: creating road type preview failed. The roadd type is not upgraded to v3.2");
				return;
			}
			if (rt.roadShapeData.hardEdge.Count != count)
			{
				rt.roadShapeData.hardEdge = new List<bool>(new bool[count]);
			}
			int num9 = 0;
			for (int m = 0; m < vecs[0].Count; m++)
			{
				num9 = 0;
				for (int n = 0; n < count; n++)
				{
					list3.Add(vecs[n][m]);
					list4.Add(list2[n][m]);
					if (n < count - 1 && m < vecs[0].Count)
					{
						if (rt.roadShapeData.hardEdge[n])
						{
							list3.Add(vecs[n][m]);
							list4.Add(list2[n][m]);
							num9++;
						}
						if (rt.doConnectionTriExt[n])
						{
							list5.Add(num8 + n + num9);
							list5.Add(num8 + n + num9 + count + num7);
							list5.Add(num8 + n + num9 + count + 1 + num7);
							list5.Add(num8 + n + num9);
							list5.Add(num8 + n + num9 + count + 1 + num7);
							list5.Add(num8 + n + num9 + 1);
						}
					}
				}
				num8 = m * (count + num7);
			}
			Mesh sharedMesh = rtg.GetComponent<MeshFilter>().sharedMesh;
			sharedMesh.Clear();
			sharedMesh.vertices = list3.ToArray();
			sharedMesh.uv = list4.ToArray();
			sharedMesh.triangles = list5.ToArray();
			sharedMesh.RecalculateNormals();
			sharedMesh.RecalculateTangents();
			sharedMesh.RecalculateBounds();
			rtg.GetComponent<MeshFilter>().sharedMesh = sharedMesh;
		}

		public static void OCQQDCCCQC(Transform parent, List<Vector3> cvecs, float OQCQCDCCDO, float OOODCCODDD, float OQCCQOCOCO, List<float> breakpoints, float OCDDDQQOQQ, Vector3 startDir, Vector3 endDir, ref List<Vector3> projectorsPositions, ref List<Vector3> startVecs, ref List<Vector3> endVecs, float length, float overlap, Vector3 firstRounding, float uvRatio, bool startEnds, bool interpolatedStartEnds)
		{
			List<Vector3> list = new List<Vector3>();
			float num = 0f;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			for (int i = 0; i < cvecs.Count; i++)
			{
				Vector3 vector3 = ((i == 0) ? (vector = (cvecs[i + 1] - cvecs[i]).normalized) : ((i != cvecs.Count - 1) ? (cvecs[i + 1] - cvecs[i - 1]).normalized : (vector2 = (cvecs[i] - cvecs[i - 1]).normalized)));
				Vector3 normalized = new Vector3(vector3.z, 0f, 0f - vector3.x).normalized;
				list.Add(cvecs[i] + normalized * OQCQCDCCDO);
				if (i > 0)
				{
					num += Vector3.Distance(list[i - 1], list[i]);
				}
			}
			Vector3 vector4 = Vector3.zero;
			Vector3 vector5 = Vector3.zero;
			int num2 = 0;
			float num3 = 0f;
			float num4 = 0f;
			if (OOODCCODDD != 0f)
			{
				if (OOODCCODDD < 0f)
				{
					list[0] += vector * OOODCCODDD;
				}
				else
				{
					num4 = Vector3.Distance(list[0], list[1]);
					num2 = 0;
					num3 = 0f;
					float num5 = OOODCCODDD;
					while (num4 < num5)
					{
						list.RemoveAt(0);
						num5 -= num3;
						num4 = Vector3.Distance(list[0], list[1]);
					}
					vector4 = (list[1] - list[0]).normalized;
					list[0] += vector4 * num5;
				}
			}
			if (vector4 == Vector3.zero)
			{
				vector4 = (list[1] - list[0]).normalized;
			}
			num3 = 0f;
			if (OQCCQOCOCO != 0f)
			{
				if (OQCCQOCOCO > 0f)
				{
					list.Add(list[list.Count - 1] + vector2 * OQCCQOCOCO);
				}
				else
				{
					num4 = Vector3.Distance(list[list.Count - 1], list[list.Count - 2]);
					num2 = 0;
					num3 = 0f;
					for (; num4 < OQCCQOCOCO * -1f; num4 += num3)
					{
						list.RemoveAt(list.Count - 1);
						num3 = Vector3.Distance(list[list.Count - 1], list[list.Count - 2]);
					}
					vector5 = (list[list.Count - 2] - list[list.Count - 1]).normalized;
					list[list.Count - 1] += vector5 * (OQCCQOCOCO - num4);
				}
			}
			if (vector5 == Vector3.zero)
			{
				vector5 = (list[list.Count - 2] - list[list.Count - 1]).normalized;
			}
			num += OOODCCODDD;
			num += OQCCQOCOCO;
			float num6 = length - overlap;
			int num7 = 1;
			while (num6 < num)
			{
				num6 += length - overlap;
				num7++;
			}
			float num8 = num6 - num;
			num += num8;
			list[0] += -vector4 * 0.5f * num8;
			list[list.Count - 1] += -vector5 * 0.5f * num8;
			float num9 = length - overlap;
			num3 = 0f;
			float num10 = 0f;
			float num11 = 0f;
			Vector3 a = list[0];
			num2 = 0;
			int num12 = list.Count - 1;
			int num13 = 0;
			while (num11 < num && num2 < num12)
			{
				num3 = Vector3.Distance(list[num2], list[num2 + 1]);
				if (num3 + num10 > length || num2 == num12 - 1)
				{
					Vector3 vector6;
					if (num13 - 1 == num7)
					{
						vector6 = list[num2 + 1];
						Vector3 vector7 = vector6;
						Debug.Log("Last projector: " + vector7.ToString());
					}
					else
					{
						vector6 = Vector3.Lerp(list[num2], list[num2 + 1], (length - num10) / num3);
					}
					Vector3 item = parent.TransformPoint(Vector3.Lerp(a, vector6, 0.5f));
					item.y += 0.25f;
					projectorsPositions.Add(item);
					vector6 = (list[num2] = vector6 + (list[num2] - list[num2 + 1]).normalized * overlap);
					num11 += num9;
					for (num10 = 0f; num10 > num9; num10 -= num9)
					{
						a = vector6;
						vector6 = Vector3.Lerp(list[num2], list[num2 + 1], (num9 - num10) / num3);
						projectorsPositions.Add(parent.TransformPoint(Vector3.Lerp(a, vector6, 0.5f)));
						num11 += num9;
					}
					a = vector6;
					num13++;
				}
				else
				{
					num10 += num3;
					num2++;
				}
			}
		}

		public static void OCDDOCCOOC(Transform parent, List<Vector3> cvecs, float OQCQCDCCDO, float OOODCCODDD, float OQCCQOCOCO, List<float> breakpoints, float OCDDDQQOQQ, Vector3 startDir, Vector3 endDir, ref List<Vector3> vecs, ref List<Vector3> startVecs, ref List<Vector3> endVecs, float length, Vector3 firstRounding, float uvRatio, bool startEnds, bool interpolatedStartEnds)
		{
			List<Vector3> list = new List<Vector3>();
			float num = 0f;
			for (int i = 0; i < cvecs.Count; i++)
			{
				Vector3 vector = ((i == 0) ? (cvecs[i + 1] - cvecs[i]) : ((i != cvecs.Count - 1) ? (cvecs[i + 1] - cvecs[i - 1]) : (cvecs[i] - cvecs[i - 1])));
				Vector3 normalized = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				list.Add(cvecs[i] + normalized * (0f - OQCQCDCCDO));
				if (i > 0)
				{
					num += Vector3.Distance(list[i - 1], list[i]);
				}
			}
			List<Vector3> list2 = new List<Vector3>(list);
			float num2 = num;
			float num3 = length;
			float num4 = 0f;
			float num5 = 0f;
			if (startEnds)
			{
				num3 = breakpoints[breakpoints.Count - 1] - breakpoints[0];
				num4 = breakpoints[0];
				num5 = length - breakpoints[breakpoints.Count - 1];
			}
			num = num - num4 - num5;
			num = num - OOODCCODDD - OQCCQOCOCO;
			float num6 = num;
			float f = num / num3;
			float num7 = num - Mathf.Floor(f) * num3;
			int num8 = 0;
			int count = breakpoints.Count;
			if (startEnds)
			{
			}
			for (int j = num8; j < count; j++)
			{
				if (breakpoints[j] - num4 > num7 || j == breakpoints.Count - 1)
				{
					if (j != breakpoints.Count - 1)
					{
						num = ((j != num8) ? ((!(!startEnds || interpolatedStartEnds)) ? (Mathf.Floor(f) * num3 + breakpoints[j] - num4) : ((!(num7 - breakpoints[j - 1] < breakpoints[j] - num7)) ? (Mathf.Floor(f) * num3 + breakpoints[j] - num4) : ((j <= 0) ? (Mathf.Floor(f) * num3 + breakpoints[0] - num4) : (Mathf.Floor(f) * num3 + breakpoints[j - 1] - num4)))) : (Mathf.Floor(f) * num3 + breakpoints[num8]));
						break;
					}
					num = Mathf.Floor(f) * num3 + num3;
				}
			}
			float num9 = num - num6;
			float num10 = OOODCCODDD;
			float num11 = OQCCQOCOCO;
			OOODCCODDD -= 0.5f * num9;
			OQCCQOCOCO -= 0.5f * num9;
			float num12 = Vector3.Distance(firstRounding, cvecs[0]);
			float num13 = Vector3.Distance(firstRounding, cvecs[cvecs.Count - 1]);
			if (num13 > num12)
			{
				Vector3 vector2 = startDir;
				startDir = endDir;
				endDir = vector2;
			}
			float num14 = OOODCCODDD + num4;
			if (num14 != 0f)
			{
				if (num14 < 0f)
				{
					list.Insert(0, list[0] + startDir * num14);
				}
				else
				{
					num = 0f;
					float num15 = 0f;
					int num16;
					for (num16 = 0; num16 < list.Count - 1; num16++)
					{
						num = Vector3.Distance(list[num16], list[num16 + 1]);
						if (num15 + num > num14)
						{
							num = num14 - num15;
							Vector3 vector = (list[num16 + 1] - list[num16]).normalized;
							list[num16] += vector * num;
							break;
						}
						list.RemoveAt(num16);
						num16--;
						num15 += num;
					}
				}
			}
			float num17 = OQCCQOCOCO + num5;
			if (num17 != 0f)
			{
				if (num17 < 0f)
				{
					list.Add(list[list.Count - 1] + endDir * num17);
				}
				else
				{
					num = 0f;
					float num18 = 0f;
					for (int num19 = list.Count - 1; num19 > 0; num19--)
					{
						num = Vector3.Distance(list[num19], list[num19 - 1]);
						if (num18 + num > num17)
						{
							num = num17 - num18;
							Vector3 vector = (list[num19 - 1] - list[num19]).normalized;
							list[num19] += vector * num;
							break;
						}
						list.RemoveAt(num19);
						num18 += num;
					}
				}
			}
			if (num4 != 0f)
			{
				if (interpolatedStartEnds)
				{
					num10 = OOODCCODDD;
					num11 = OQCCQOCOCO;
				}
				float num20 = 0f;
				int num21 = 0;
				if (num10 == 0f)
				{
					startVecs.Add(list2[0]);
				}
				else if (num10 < 0f)
				{
					startVecs.Add(list2[0] + startDir * num10);
				}
				else if (num10 > 0f)
				{
					bool flag = false;
					int num22 = 0;
					float num23 = 0f;
					while (!flag)
					{
						float num24 = Vector3.Distance(list2[num22], list2[num22 + 1]);
						if (num23 + num24 > num10)
						{
							Vector3 vector = (list2[num22 + 1] - list2[num22]).normalized;
							float num25 = num10 - num23;
							startVecs.Add(list2[num22] + vector * num25);
							num21 = num22;
							flag = true;
						}
						num23 += num24;
						num22++;
					}
				}
				Vector3 vector3 = startVecs[0];
				bool flag2 = false;
				if (num10 < 0f)
				{
					num20 = -1f * num10;
					vector3 = list2[0];
				}
				if (num20 > num4)
				{
					startVecs.Add(startVecs[0] + startDir * num4);
					vector3 = startVecs[0];
					flag2 = true;
				}
				int num26 = 0;
				while (!flag2)
				{
					num = Vector3.Distance(vector3, list2[num21 + 1]);
					if (num20 + num > num4)
					{
						float num27 = num4 - num20;
						Vector3 vector = (list2[num21 + 1] - vector3).normalized;
						startVecs.Add(vector3 + vector * num27);
						num20 = num4;
					}
					else
					{
						startVecs.Add(list2[num21 + 1]);
						num20 += num;
						num21++;
					}
					vector3 = startVecs[startVecs.Count - 1];
					if (num20 >= num4 || num26 > 10)
					{
						flag2 = true;
					}
					num26++;
				}
				if (num5 != 0f)
				{
					num20 = 0f;
					num21 = list2.Count - 1;
					if (num11 == 0f)
					{
						endVecs.Add(list2[list2.Count - 1]);
					}
					else if (num11 < 0f)
					{
						endVecs.Add(list2[list2.Count - 1] + endDir * num11);
					}
					else if (num11 > 0f)
					{
						bool flag3 = false;
						int num28 = num21;
						float num29 = 0f;
						while (!flag3)
						{
							float num30 = Vector3.Distance(list2[num28 - 1], list2[num28]);
							if (num29 + num30 >= num11)
							{
								Vector3 vector = (list2[num28 - 1] - list2[num28]).normalized;
								float num31 = num11 - num29;
								endVecs.Add(list2[num28] + vector * num31);
								num21 = num28;
								flag3 = true;
							}
							num29 += num30;
							num28--;
							if (num28 == 1)
							{
								flag3 = true;
							}
						}
					}
					vector3 = endVecs[0];
					flag2 = false;
					if (num11 < 0f)
					{
						num20 = -1f * num11;
						vector3 = list2[num21];
					}
					if (num20 > num5)
					{
						endVecs.Add(endVecs[0] + endDir * num5);
						vector3 = endVecs[0];
						flag2 = true;
					}
					num26 = 0;
					while (!flag2)
					{
						num = Vector3.Distance(vector3, list2[num21 - 1]);
						if (num20 + num > num5)
						{
							float num32 = num5 - num20;
							Vector3 vector = (list2[num21 - 1] - vector3).normalized;
							endVecs.Add(vector3 + vector * num32);
							num20 = num5;
							flag2 = true;
						}
						else
						{
							endVecs.Add(list2[num21 - 1]);
							num20 += num;
							num21--;
						}
						vector3 = endVecs[endVecs.Count - 1];
						if (num20 >= num5 || num26 > 10)
						{
							flag2 = true;
						}
						num26++;
					}
					endVecs.Reverse();
				}
			}
			vecs = list;
		}

		public static void RoadShapeChangeTriangulation(List<Vector3> shape1, List<Vector3> shape2, int startIndex1, int endIndex1, int startIndex2, int endIndex2, ref List<int> tris)
		{
		}

		public static void GenerateLaneDirectionMarkings(ERModularRoad road)
		{
			if (road.rt == null && road.roadType != 0.0 && road.baseScript != null)
			{
				road.rt = QDQDOOQQDQODD.GetRoadTypeElByID(road.baseScript.roadTypes, road.roadType);
			}
			if (road.rt == null || !road.spawnDirectionMarkings)
			{
				return;
			}
			if (road.rt.decalPresets == null || road.rt.decalPresets.Count == 0)
			{
				QDQDOOQQDQODD qDQDOOQQDQODD = null;
				if (road.baseScript != null)
				{
					qDQDOOQQDQODD = QDQDOOQQDQODD.GetRoadTypeElByID(road.baseScript.roadTypes, road.roadType);
				}
				if (qDQDOOQQDQODD != null && qDQDOOQQDQODD.decalPresets.Count > 0)
				{
					road.rt = QDQDOOQQDQODD.GetRoadTypeElByID(road.baseScript.roadTypes, road.roadType, clone: true);
				}
			}
			ERDecal eRDecal = ERDecal.OCDDCQOQOO(road.rt.decalPresets, ERLaneDirectionOptions.Straight);
			ERDecal eRDecal2 = null;
			ERDecal eRDecal3 = null;
			ERDecal eRDecal4 = null;
			ERDecal eRDecal5 = null;
			if (eRDecal == null)
			{
				return;
			}
			if (road.laneDirectionObject == null)
			{
				Transform transform = road.transform.Find("Lane Direction Markings");
				if (transform != null)
				{
					road.laneDirectionObject = transform.gameObject;
				}
				else
				{
					road.laneDirectionObject = ODCOQDDDDQ("Lane Direction Markings", road.transform, eRDecal.material, colliderFlag: false, castShadows: false, hide: false, isStatic: true);
				}
			}
			else if (road.laneDirectionObject.transform.parent == road.transform)
			{
				OCDCOCQOCD(road.laneDirectionObject, "Lane Direction Markings", road.transform, eRDecal.material, colliderFlag: false, castShadows: false, hide: false, isStatic: true);
			}
			else
			{
				Transform transform2 = road.transform.Find("Lane Direction Markings");
				if (transform2 != null)
				{
					road.laneDirectionObject = transform2.gameObject;
					OCDCOCQOCD(road.laneDirectionObject, "Lane Direction Markings", road.transform, eRDecal.material, colliderFlag: false, castShadows: false, hide: false, isStatic: true);
				}
				else
				{
					road.laneDirectionObject = ODCOQDDDDQ("Lane Direction Markings", road.transform, eRDecal.material, colliderFlag: false, castShadows: false, hide: false, isStatic: true);
				}
			}
			List<Vector3> list = new List<Vector3>();
			List<Vector2> uvs = new List<Vector2>();
			List<int> tris = new List<int>();
			foreach (ERLaneData laneDatum in road.laneData)
			{
				GenerateLaneDirectionMarking(road, ref list, ref uvs, ref tris, laneDatum, eRDecal);
			}
			Object.DestroyImmediate(road.laneDirectionObject.GetComponent<MeshFilter>().sharedMesh);
			Mesh mesh = new Mesh();
			mesh.Clear();
			mesh.vertices = list.ToArray();
			mesh.uv = uvs.ToArray();
			mesh.triangles = tris.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			mesh.RecalculateTangents();
			road.laneDirectionObject.GetComponent<MeshFilter>().sharedMesh = mesh;
		}

		public static void GenerateLaneDirectionMarking(ERModularRoad road, ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<int> tris, ERLaneData lane, ERDecal decalStraight)
		{
			int count = road.soSplinePoints.Count;
			List<float> list = new List<float>(road.distances);
			List<Vector3> list2 = new List<Vector3>(lane.points);
			if (list2.Count < 3)
			{
				return;
			}
			ERDecal eRDecal = decalStraight;
			ERDecal eRDecal2 = decalStraight;
			int num = lane.points.Length - 1;
			if (num > list.Count - 1)
			{
				num = list.Count - 1;
			}
			float num2 = list[num];
			bool flag = false;
			bool flag2 = false;
			if (!road.oneWayRoad)
			{
				if ((lane.direction == ERLaneDirection.Left && road.baseScript.rightHandDriving == 1) || (lane.direction == ERLaneDirection.Right && road.baseScript.rightHandDriving == 0))
				{
					flag2 = true;
					list2.Reverse();
				}
			}
			else if ((road.oneWayDirection == ERLaneDirection.Left && road.baseScript.rightHandDriving == 1) || (road.oneWayDirection == ERLaneDirection.Right && road.baseScript.rightHandDriving == 0))
			{
				list2.Reverse();
				flag2 = true;
			}
			ERCrossingPrefabs eRCrossingPrefabs = null;
			int num3 = 0;
			ERDecal eRDecal3 = null;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 1f;
			Vector3 b = list2[0];
			if (!flag2)
			{
				eRCrossingPrefabs = road.endPrefabScript;
				num3 = road.endConnectionSegment;
				b = list2[num];
			}
			else
			{
				eRCrossingPrefabs = road.startPrefabScript;
				num3 = road.startConnectionSegment;
				num7 = -1f;
			}
			if (eRCrossingPrefabs != null)
			{
				if (eRCrossingPrefabs.siblings.Count > num3 && eRCrossingPrefabs.siblings[num3].laneData != null && eRCrossingPrefabs.siblings[num3].laneData.connectors != null)
				{
					List<ERLaneConnector> connectors = eRCrossingPrefabs.siblings[num3].laneData.connectors;
					if (!eRCrossingPrefabs.isFlexConnector && eRCrossingPrefabs.siblings[num3].roadTypeID != eRCrossingPrefabs.crossingElements[num3].roadType)
					{
						eRCrossingPrefabs.siblings[num3].roadTypeID = eRCrossingPrefabs.crossingElements[num3].roadType;
						eRCrossingPrefabs.siblings[num3].roadType = QDQDOOQQDQODD.GetRoadTypeElByID(eRCrossingPrefabs.baseScript.roadTypes, eRCrossingPrefabs.crossingElements[num3].roadType);
					}
					if (road.baseScript.rightHandDriving == 1)
					{
						int num8 = eRCrossingPrefabs.siblings[num3].roadType.OCDCDCODCO(lane.laneIndex, ERLaneDirection.Right);
					}
					else
					{
						int num8 = eRCrossingPrefabs.siblings[num3].roadType.OCDCDCODCO(lane.laneIndex, ERLaneDirection.Left);
					}
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					for (int i = 0; i < connectors.Count; i++)
					{
						if (connectors[i].points.Length != 0 && Vector3.Distance(connectors[i].points[0], b) < 1f)
						{
							if (connectors[i].laneDirection == ERDirectionType.Left)
							{
								flag3 = true;
							}
							else if (connectors[i].laneDirection == ERDirectionType.Right)
							{
								flag4 = true;
							}
							else if (connectors[i].laneDirection == ERDirectionType.Straight)
							{
								flag5 = true;
							}
						}
					}
					if (connectors.Count == 0)
					{
						flag5 = true;
					}
					if (!flag3 && !flag4 && !flag5)
					{
						return;
					}
					ERLaneDirectionOptions direction = ERLane.ODQQCOOCOQ(flag3, flag4, flag5);
					eRDecal3 = ERDecal.OCDDCQOQOO(road.rt.decalPresets, direction);
					if (eRDecal3 == null)
					{
						eRDecal3 = decalStraight;
					}
					else if (!flag2)
					{
						num4 = num2 - eRDecal3.distanceToIntersection;
						eRDecal = eRDecal3;
					}
					else
					{
						num4 = eRDecal3.distanceToIntersection;
						eRDecal2 = eRDecal3;
						eRDecal = decalStraight;
					}
				}
				if (eRDecal3 != null)
				{
					num5 = eRDecal3.length * 0.5f;
					num6 = (eRDecal3.uvRightBottom.x - eRDecal3.uvLeftTop.x) / (eRDecal3.uvLeftTop.y - eRDecal3.uvRightBottom.y) * num5;
				}
			}
			float num9 = 0f;
			float num10 = 0f;
			int num11 = vecs.Count;
			float num12 = eRDecal2.length * 0.5f;
			float num13 = (eRDecal2.uvRightBottom.x - eRDecal2.uvLeftTop.x) / (eRDecal2.uvLeftTop.y - eRDecal2.uvRightBottom.y) * num12;
			float num14 = 3f;
			float num15 = num14;
			float num16 = decalStraight.distance;
			float num17 = 0f;
			float num18 = Mathf.Round((num2 - 2.5f * (num15 + num12)) / decalStraight.distance);
			if (num18 == 0f)
			{
				num18 = 1f;
			}
			if (num18 >= 2f)
			{
				num16 = (num2 - 2.5f * (num15 + num12)) / num18;
			}
			int num19 = 0;
			int num20 = road.crosswalkDistances.Count - 1;
			bool flag6 = false;
			if (num2 < 2f * decalStraight.length)
			{
				return;
			}
			if (num2 < 2f * decalStraight.distance && !flag2)
			{
				num15 = num2 - num14;
				if (eRDecal3 != null)
				{
					eRDecal2 = eRDecal3;
					num12 = eRDecal2.length * 0.5f;
					num13 = (eRDecal2.uvRightBottom.x - eRDecal2.uvLeftTop.x) / (eRDecal2.uvLeftTop.y - eRDecal2.uvRightBottom.y) * num12;
				}
			}
			for (int j = 1; j < num; j++)
			{
				num9 = list[j] - num10;
				if (num20 > -1)
				{
					if (list[j] > road.crosswalkDistances[num19] - 10f && list[j] < road.crosswalkDistances[num19] + 10f)
					{
						flag6 = true;
					}
					else
					{
						flag6 = false;
						if (list[j] > road.crosswalkDistances[num19] && num19 < num20)
						{
							num19++;
						}
					}
				}
				if (eRDecal3 != null && list[j] > num4)
				{
					eRDecal2 = eRDecal;
					num12 = eRDecal2.length * 0.5f;
					num13 = (eRDecal2.uvRightBottom.x - eRDecal2.uvLeftTop.x) / (eRDecal2.uvLeftTop.y - eRDecal2.uvRightBottom.y) * num12;
				}
				if (!(num9 > num15))
				{
					continue;
				}
				if (!flag6)
				{
					num17 = num9 - num15;
					Vector3 normalized = (list2[j] - list2[j - 1]).normalized;
					Vector3 vector = list2[j] - normalized * num17;
					normalized = (list2[j + 1] - list2[j - 1]).normalized;
					Vector3 vector2 = -(road.soSplinePointsLeft[j] - road.soSplinePointsRight[j]).normalized;
					if (!flag2)
					{
						Vector3 item = vector;
						item -= normalized * num12;
						item -= vector2 * num13;
						item.y += eRDecal2.heightOffset;
						vecs.Add(item);
						uvs.Add(new Vector2(eRDecal2.uvLeftTop.x, eRDecal2.uvRightBottom.y));
						item += vector2 * num13 * 2f;
						vecs.Add(item);
						uvs.Add(new Vector2(eRDecal2.uvRightBottom.x, eRDecal2.uvRightBottom.y));
						item = vector;
						item += normalized * num12;
						item -= vector2 * num13;
						item.y += eRDecal2.heightOffset;
						vecs.Add(item);
						uvs.Add(new Vector2(eRDecal2.uvLeftTop.x, eRDecal2.uvLeftTop.y));
						item += vector2 * num13 * 2f;
						vecs.Add(item);
						uvs.Add(new Vector2(eRDecal2.uvRightBottom.x, eRDecal2.uvLeftTop.y));
					}
					else
					{
						Vector3 item = vector;
						item += normalized * num12;
						item += vector2 * num13;
						item.y += eRDecal2.heightOffset;
						vecs.Add(item);
						uvs.Add(new Vector2(eRDecal2.uvLeftTop.x, eRDecal2.uvRightBottom.y));
						item -= vector2 * num13 * 2f;
						vecs.Add(item);
						uvs.Add(new Vector2(eRDecal2.uvRightBottom.x, eRDecal2.uvRightBottom.y));
						item = vector;
						item -= normalized * num12;
						item += vector2 * num13;
						item.y += eRDecal2.heightOffset;
						vecs.Add(item);
						uvs.Add(new Vector2(eRDecal2.uvLeftTop.x, eRDecal2.uvLeftTop.y));
						item -= vector2 * num13 * 2f;
						vecs.Add(item);
						uvs.Add(new Vector2(eRDecal2.uvRightBottom.x, eRDecal2.uvLeftTop.y));
					}
					tris.Add(num11);
					tris.Add(num11 + 2);
					tris.Add(num11 + 1);
					tris.Add(num11 + 2);
					tris.Add(num11 + 3);
					tris.Add(num11 + 1);
					num11 += 4;
				}
				num10 += num9;
				num9 = 0f;
				num15 = num16;
			}
		}

		public static GameObject ODCOQDDDDQ(string name, Transform parent, Material mat, bool colliderFlag, bool castShadows, bool hide, bool isStatic)
		{
			GameObject gameObject = new GameObject(name);
			gameObject.AddComponent<MeshRenderer>().sharedMaterial = mat;
			gameObject.AddComponent<MeshFilter>();
			gameObject.GetComponent<MeshFilter>().sharedMesh = new Mesh();
			if (colliderFlag)
			{
				gameObject.AddComponent<MeshCollider>();
				gameObject.GetComponent<MeshCollider>().sharedMesh = gameObject.AddComponent<MeshFilter>().sharedMesh;
			}
			if (castShadows)
			{
				gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
			}
			else
			{
				gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			if (hide)
			{
				gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			gameObject.transform.parent = parent;
			gameObject.isStatic = isStatic;
			return gameObject;
		}

		public static GameObject OCDCOCQOCD(GameObject go, string name, Transform parent, Material mat, bool colliderFlag, bool castShadows, bool hide, bool isStatic)
		{
			if (go.GetComponent<MeshRenderer>() == null)
			{
				go.AddComponent<MeshRenderer>();
			}
			go.GetComponent<MeshRenderer>().sharedMaterial = mat;
			if (go.GetComponent<MeshFilter>() == null)
			{
				go.AddComponent<MeshFilter>();
			}
			if (go.GetComponent<MeshFilter>().sharedMesh == null)
			{
				go.GetComponent<MeshFilter>().sharedMesh = new Mesh();
			}
			if (colliderFlag)
			{
				if (go.GetComponent<MeshCollider>() == null)
				{
					go.AddComponent<MeshCollider>();
				}
				if (go.GetComponent<MeshCollider>().sharedMesh == null)
				{
					go.GetComponent<MeshCollider>().sharedMesh = go.GetComponent<MeshFilter>().sharedMesh;
				}
			}
			if (castShadows)
			{
				go.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
			}
			else
			{
				go.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			if (hide)
			{
				go.hideFlags = HideFlags.HideInHierarchy;
			}
			go.transform.parent = parent;
			go.isStatic = isStatic;
			return go;
		}
	}
}
