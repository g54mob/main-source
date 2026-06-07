using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class QDQDOOQQOOQDD : MonoBehaviour
	{
		private List<Vector3> ᙂ;

		private float[,] ᙃ;

		private float[] ᙄ;

		private TerrainData ᙅ;

		public static float minx;

		public static float minz;

		public static float maxx;

		public static float maxz;

		public static Vector2 splatMapScale;

		public static List<GameObject> surfaceObjects = new List<GameObject>();

		public static int crossingSurfacesStart = 0;

		public static int sideObjectSurfacesStart = 0;

		public static List<GameObject> treeObjects = new List<GameObject>();

		public static List<GameObject> detailObjects = new List<GameObject>();

		public static void OQOCCDODCO(ERModularBase scr, Terrain terrain)
		{
			minx = (minz = 100000f);
			maxx = (maxz = -100000f);
			surfaceObjects.Clear();
			treeObjects.Clear();
			detailObjects.Clear();
			scr.soSplatmapObjects.Clear();
			ERTerrain[] array = Object.FindObjectsOfType(typeof(ERTerrain)) as ERTerrain[];
			OQCOCOCOQO(scr, ref minx, ref minz, ref maxx, ref maxz, 0f);
			ERTerrain[] array2 = array;
			foreach (ERTerrain eRTerrain in array2)
			{
				ODOCOOOQDQ(scr, eRTerrain, eRTerrain.gameObject.GetComponent<Terrain>(), minx, maxx, minz, maxz);
				eRTerrain.enabled = false;
			}
			foreach (GameObject surfaceObject in surfaceObjects)
			{
				if (surfaceObject != null)
				{
					surfaceObject.SetActive(value: false);
				}
			}
		}

		public static void ODOCOOOQDQ(ERModularBase scr, ERTerrain terrainScr, Terrain terrain, float m_minx, float m_maxx, float m_minz, float m_maxz)
		{
			scr.terrainHits.Clear();
			terrainScr.terrainTrees.Clear();
			terrainScr.detailInstances.Clear();
			terrainScr.splatData.Clear();
			terrainScr.terrainChanges.Clear();
			if (terrainScr.terrainData == null || terrainScr.terrainData != terrain.terrainData)
			{
				terrainScr.terrainData = terrain.terrainData;
			}
			TerrainData terrainData = terrainScr.terrainData;
			float[,] heights = terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
			int heightmapResolution = terrainData.heightmapResolution;
			int num = 0;
			float num2 = m_minx;
			float num3 = m_maxx;
			float num4 = m_minz;
			float num5 = m_maxz;
			float num6 = terrain.transform.position.x;
			float num7 = terrain.transform.position.z;
			if (terrain.transform.position.x != 0f)
			{
				num2 -= terrain.transform.position.x;
				num3 -= terrain.transform.position.x;
				num6 = 0f;
			}
			if (terrain.transform.position.z != 0f)
			{
				num4 -= terrain.transform.position.z;
				num5 -= terrain.transform.position.z;
				num7 = 0f;
			}
			if (num2 < num6)
			{
				num2 = 0f;
			}
			if (num4 < num7)
			{
				num4 = 0f;
			}
			num3 -= num6;
			if (num3 > terrainData.size.x)
			{
				num3 = terrainData.size.x;
			}
			num5 -= num7;
			if (num5 > terrainData.size.z)
			{
				num5 = terrainData.size.z;
			}
			int num8 = Mathf.RoundToInt(Mathf.Floor(num2 / terrainData.heightmapScale.x));
			int num9 = Mathf.RoundToInt(Mathf.Ceil(num3 / terrainData.heightmapScale.x));
			int num10 = Mathf.RoundToInt(Mathf.Floor(num4 / terrainData.heightmapScale.z));
			int num11 = Mathf.RoundToInt(Mathf.Ceil(num5 / terrainData.heightmapScale.z));
			if (terrainData.heightmapResolution - num9 == 1)
			{
				num9 = terrainData.heightmapResolution;
			}
			if (terrainData.heightmapResolution - num11 == 1)
			{
				num11 = terrainData.heightmapResolution;
			}
			if (num8 < 0 || num8 > terrainData.heightmapResolution || num10 < 0 || num10 > terrainData.heightmapResolution || num9 < 0 || num9 > terrainData.heightmapResolution || num11 < 0 || num11 > terrainData.heightmapResolution)
			{
				return;
			}
			float[,] heights2 = terrainData.GetHeights(num8, num10, num9 - num8, num11 - num10);
			terrainScr.xStart = num8;
			terrainScr.zStart = num10;
			float x = terrain.transform.position.x;
			float z = terrain.transform.position.z;
			float y = terrain.transform.position.y;
			terrainScr.terrainDataStored.Clear();
			foreach (GameObject surfaceObject in surfaceObjects)
			{
				surfaceObject.SetActive(value: true);
			}
			LayerMask layerMask = int.MinValue;
			Ray ray = new Ray
			{
				direction = Vector3.down
			};
			float y2 = terrainData.size.y;
			float perc = 0f;
			bool critical = false;
			float num12 = 0f;
			float outerHeight = 0f;
			Vector3 zero = Vector3.zero;
			float y3 = terrain.transform.position.y;
			float preserveTerrainFloat = scr.preserveTerrainFloat;
			try
			{
				if (scr.doHeightmap)
				{
					scr.progressMax = num9 - num8;
					for (int i = 0; i < num9 - num8; i++)
					{
						scr.progressStatus = i;
						for (int j = 0; j < num11 - num10; j++)
						{
							float y4 = y3 + heights2[j, i] * y2 + 100f;
							Vector3 origin = new Vector3(x + (float)(num8 + i) * terrainData.heightmapScale.x, y4, z + (float)(num10 + j) * terrainData.heightmapScale.z);
							if (Physics.Raycast(origin, -Vector3.up, out var hitInfo, 500f, layerMask))
							{
								Vector3 point = hitInfo.point;
								point.y -= y3;
								zero = Vector3.zero;
								OCDOCDDODC(hitInfo.triangleIndex, hitInfo.collider, point, ref perc, ref critical, ref outerHeight, ref zero, hitInfo);
								float num13 = point.y / terrainData.size.y;
								outerHeight = (outerHeight - y3) / terrainData.size.y;
								ERTerrainData eRTerrainData = new ERTerrainData(j, i, heights2[j, i], num13, critical, perc, outerHeight, point, zero);
								terrainScr.terrainDataStored.Add(eRTerrainData);
								if (critical)
								{
									terrainScr.terrainChanges.Add(new ERTerrainChange((num10 + j) * heightmapResolution + (num8 + i), 2));
								}
								else
								{
									terrainScr.terrainChanges.Add(new ERTerrainChange((num10 + j) * heightmapResolution + (num8 + i), 1));
								}
								if (hitInfo.collider.name == "surface")
								{
									num12 = Mathf.Lerp(1f, perc, preserveTerrainFloat);
									num13 = Mathf.Lerp(heights2[j, i], num13, num12);
								}
								else
								{
									eRTerrainData.ignorePreserveHeights = true;
								}
								heights2[j, i] = num13;
							}
						}
					}
					terrainData.SetHeights(num8, num10, heights2);
					terrainScr.heightmapFlag = true;
				}
			}
			catch
			{
				Debug.LogError("EasyRoads3Dv3: Updating the heightmap of terrain " + terrain.name + " failed, please report with details!");
				Debug.LogError("Additional info: " + num8 + " " + num9 + " " + num10 + " " + num11 + " " + heights2.Length);
			}
			for (int i = 0; i < crossingSurfacesStart; i++)
			{
				surfaceObjects[i].SetActive(value: false);
			}
			if (scr.doTrees)
			{
				try
				{
					ODDCOOOQOQ(scr, terrainScr, terrain, num2, num3, num4, num5);
					terrainScr.treeFlag = true;
				}
				catch
				{
					Debug.LogError("EasyRoads3Dv3: Removing trees from terrain " + terrain.name + " failed, please report with details!");
				}
			}
			if (scr.doDetail)
			{
				try
				{
					OQCOCQDOCD(scr, terrainScr, terrain, num2, num3, num4, num5);
					terrainScr.detailFlag = true;
				}
				catch
				{
					Debug.LogError("EasyRoads3Dv3: Removing detail objects from terrain " + terrain.name + " failed, please report with details!");
				}
			}
			if (scr.doSplatmaps && scr.soSplatmapObjects.Count > 0)
			{
				try
				{
					OQDDDCDOOO(scr, terrainScr, terrain, num2, num3, num4, num5);
					terrainScr.splatmapFlag = true;
				}
				catch
				{
					Debug.LogError("EasyRoads3Dv3: Adding road shape to terrain " + terrain.name + " failed, please report with details!");
				}
			}
			foreach (GameObject surfaceObject2 in surfaceObjects)
			{
				surfaceObject2.SetActive(value: false);
			}
			terrain.Flush();
			terrainScr.terrainDone = true;
		}

		public static void OCDOCDDODC(int triangleIndex, Collider collider, Vector3 hitPos, ref float perc, ref bool critical, ref float outerHeight, ref Vector3 outerPoint, RaycastHit hit)
		{
			Mesh sharedMesh = collider.gameObject.GetComponent<MeshCollider>().sharedMesh;
			critical = true;
			if (hitPos != Vector3.zero)
			{
				perc = hit.textureCoord.y;
				if (perc != 1f)
				{
					critical = false;
				}
				return;
			}
			Debug.Log("##############################");
			int num = Mathf.RoundToInt(Mathf.Floor((float)triangleIndex * 0.5f) * 2f);
			float num2 = (float)num * 0.5f;
			float num3 = Mathf.Floor(num2 * 0.25f);
			float num4 = num2 - Mathf.Round(num3 * 4f);
			if (num4 == 0f)
			{
				critical = false;
				try
				{
					Vector3 vA = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 1]];
					Vector3 vB = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 2]];
					num++;
					Vector3 a;
					Vector3 vector = (a = sharedMesh.vertices[sharedMesh.triangles[num * 3]]);
					Vector3 b;
					Vector3 vector2 = (b = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 2]]);
					vector.y = (vector2.y = (vA.y = (vB.y = hitPos.y)));
					Vector3 a2 = OCQCDQCQOQ.OQQQDCODQD(vA, vB, hitPos);
					Vector3 vector3 = OCQCDQCQOQ.OQQQDCODQD(vector, vector2, hitPos);
					perc = Vector3.Distance(hitPos, vector3) / Vector3.Distance(a2, vector3);
					float t = Vector3.Distance(vector3, vector) / Vector3.Distance(vector, vector2);
					vector3 = Vector3.Lerp(a, b, t);
					outerHeight = hitPos.y - vector3.y;
					outerPoint = vector3;
					return;
				}
				catch
				{
					perc = 1f;
					return;
				}
			}
			if (num4 == 1f || num4 == 2f)
			{
				critical = true;
				perc = 1f;
				return;
			}
			critical = false;
			try
			{
				Vector3 a;
				Vector3 vector = (a = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 1]]);
				Vector3 b;
				Vector3 vector2 = (b = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 2]]);
				num++;
				Vector3 vA = sharedMesh.vertices[sharedMesh.triangles[num * 3]];
				Vector3 vB = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 2]];
				vector.y = (vector2.y = (vA.y = (vB.y = hitPos.y)));
				Vector3 a2 = OCQCDQCQOQ.OQQQDCODQD(vA, vB, hitPos);
				Vector3 vector3 = OCQCDQCQOQ.OQQQDCODQD(vector, vector2, hitPos);
				perc = Vector3.Distance(hitPos, vector3) / Vector3.Distance(a2, vector3);
				float t = Vector3.Distance(vector3, vector) / Vector3.Distance(vector, vector2);
				vector3 = Vector3.Lerp(a, b, t);
				outerHeight = hitPos.y - vector3.y;
				outerPoint = vector3;
			}
			catch
			{
				perc = 1f;
			}
		}

		public static void GetHitPointInfoOld(int triangleIndex, Collider collider, Vector3 hitPos, ref float perc, ref bool critical, ref float outerHeight, ref Vector3 outerPoint)
		{
			Mesh sharedMesh = collider.gameObject.GetComponent<MeshCollider>().sharedMesh;
			int num = Mathf.RoundToInt(Mathf.Floor((float)triangleIndex * 0.5f) * 2f);
			float num2 = (float)num * 0.5f;
			float num3 = Mathf.Floor(num2 * 0.333333f);
			float num4 = num2 - Mathf.Round(num3 * 3f);
			Debug.Log(triangleIndex + " surface " + num4);
			if (num4 == 0f || num4 == 3f)
			{
				critical = false;
				try
				{
					Vector3 vA = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 1]];
					Vector3 vB = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 2]];
					num++;
					Vector3 a;
					Vector3 vector = (a = sharedMesh.vertices[sharedMesh.triangles[num * 3]]);
					Vector3 b;
					Vector3 vector2 = (b = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 2]]);
					vector.y = (vector2.y = (vA.y = (vB.y = hitPos.y)));
					Vector3 a2 = OCQCDQCQOQ.OQQQDCODQD(vA, vB, hitPos);
					Vector3 vector3 = OCQCDQCQOQ.OQQQDCODQD(vector, vector2, hitPos);
					perc = Vector3.Distance(hitPos, vector3) / Vector3.Distance(a2, vector3);
					float t = Vector3.Distance(vector3, vector) / Vector3.Distance(vector, vector2);
					vector3 = Vector3.Lerp(a, b, t);
					outerHeight = hitPos.y - vector3.y;
					outerPoint = vector3;
					return;
				}
				catch
				{
					perc = 1f;
					return;
				}
			}
			if (num4 == 1f)
			{
				critical = true;
				perc = 1f;
				return;
			}
			critical = false;
			try
			{
				Vector3 a;
				Vector3 vector = (a = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 1]]);
				Vector3 b;
				Vector3 vector2 = (b = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 2]]);
				num++;
				Vector3 vA = sharedMesh.vertices[sharedMesh.triangles[num * 3]];
				Vector3 vB = sharedMesh.vertices[sharedMesh.triangles[num * 3 + 2]];
				vector.y = (vector2.y = (vA.y = (vB.y = hitPos.y)));
				Vector3 a2 = OCQCDQCQOQ.OQQQDCODQD(vA, vB, hitPos);
				Vector3 vector3 = OCQCDQCQOQ.OQQQDCODQD(vector, vector2, hitPos);
				perc = Vector3.Distance(hitPos, vector3) / Vector3.Distance(a2, vector3);
				float t = Vector3.Distance(vector3, vector) / Vector3.Distance(vector, vector2);
				vector3 = Vector3.Lerp(a, b, t);
				outerHeight = hitPos.y - vector3.y;
				outerPoint = vector3;
			}
			catch
			{
				perc = 1f;
			}
		}

		public static void OQCOCOCOQO(ERModularBase scr, ref float minx, ref float minz, ref float maxx, ref float maxz, float splatmapScale)
		{
			minx = 10000000f;
			minz = 10000000f;
			maxx = -10000000f;
			maxz = -10000000f;
			ERModularRoad[] array = Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
			Mesh mesh = null;
			ERModularRoad[] array2 = array;
			foreach (ERModularRoad eRModularRoad in array2)
			{
				bool flag = true;
				if (scr.selectedRoadsOnly)
				{
					flag = false;
					for (int j = 0; j < scr.selectedObjects.Count; j++)
					{
						if (scr.selectedObjects[j].roadScr == eRModularRoad)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					continue;
				}
				Mesh mesh2 = null;
				if ((bool)eRModularRoad.gameObject.GetComponent<MeshFilter>())
				{
					mesh2 = eRModularRoad.gameObject.GetComponent<MeshFilter>().sharedMesh;
				}
				Transform transform = eRModularRoad.transform.Find("surface");
				if (eRModularRoad.isSideObject)
				{
					foreach (ERSORoadExt item in eRModularRoad.soDataExt)
					{
						if (!item.sideObject.deformationObject || !item.active || item.sideObject.objectType != 1)
						{
							continue;
						}
						foreach (Transform item2 in eRModularRoad.transform)
						{
							if ((bool)item2.GetComponent<ERSideObjectInstance>() && item2.GetComponent<ERSideObjectInstance>().so == item.sideObject)
							{
								transform = item2;
								break;
							}
						}
					}
				}
				if ((transform != null || eRModularRoad.snapVertices) && eRModularRoad.markersExt.Count > 1)
				{
					if (transform != null)
					{
						transform.gameObject.layer = 31;
						surfaceObjects.Add(transform.gameObject);
						mesh = transform.gameObject.GetComponent<MeshFilter>().sharedMesh;
						if ((bool)transform.gameObject.GetComponent<MeshCollider>() && transform.gameObject.GetComponent<MeshCollider>().sharedMesh == null)
						{
							transform.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
							if (transform.gameObject.GetComponent<MeshCollider>().sharedMesh == null)
							{
								Object.DestroyImmediate(transform.gameObject.GetComponent<MeshCollider>());
								transform.gameObject.AddComponent<MeshCollider>();
							}
						}
					}
					else if ((bool)eRModularRoad.gameObject.GetComponent<MeshFilter>())
					{
						mesh = eRModularRoad.gameObject.GetComponent<MeshFilter>().sharedMesh;
					}
					if (mesh != null)
					{
						if (minx > mesh.bounds.min.x)
						{
							minx = mesh.bounds.min.x;
						}
						if (minz > mesh.bounds.min.z)
						{
							minz = mesh.bounds.min.z;
						}
						if (maxx < mesh.bounds.max.x)
						{
							maxx = mesh.bounds.max.x;
						}
						if (maxz < mesh.bounds.max.z)
						{
							maxz = mesh.bounds.max.z;
						}
					}
					OCQQDQQCQQ.OOCCQOQQQC(mesh2);
					if (!scr.doLightmapUVs || !eRModularRoad.isUpdated || mesh2 != null)
					{
					}
					if (scr.lodGroups && scr.doLODGroups && !eRModularRoad.isSideObject)
					{
						int num = 0;
						int num2 = 0;
						for (int j = 0; j < scr.LODLevels; j++)
						{
							num = 10 - Mathf.RoundToInt(scr.LODLevelResolution[j] * 10f);
							if (num == 0)
							{
								num = 1;
							}
							if (num <= num2)
							{
								num = num2;
							}
							ODQCQOODDO.OCCCOQOCDO(eRModularRoad.gameObject, mesh, j, num, eRModularRoad.roadShape.Count, eRModularRoad.hardEdge, eRModularRoad.roadShapeMaterialIntCounts);
							num2 = num;
						}
						OCQQDQQCQQ.ODDQDOODQD(scr, eRModularRoad);
					}
					if (scr.doSplatmaps && eRModularRoad.splatMapActive && splatmapScale != 0f)
					{
						OQOOOODDDO.CreateSplatMeshes(eRModularRoad, ref scr.soSplatmapObjects, splatmapScale);
					}
					if (transform != null)
					{
						transform.gameObject.GetComponent<MeshCollider>().enabled = true;
					}
				}
				if (eRModularRoad.markersExt.Count > 1 && (!eRModularRoad.isSideObject || transform != null) && (eRModularRoad.terrainDeformation || eRModularRoad.snapVertices) && splatmapScale != 0f)
				{
					ODCCOCCQDD(scr, eRModularRoad);
					treeObjects.Add(CreateMesh(eRModularRoad.transform, eRModularRoad.treeVecs, eRModularRoad.vegetationTris, 31, "treesERMesh"));
					detailObjects.Add(CreateMesh(eRModularRoad.transform, eRModularRoad.detailVecs, eRModularRoad.vegetationTris, 31, "detailERMesh"));
				}
			}
			crossingSurfacesStart = surfaceObjects.Count;
			if (scr.selectedRoadsOnly)
			{
				return;
			}
			ERCrossingPrefabs[] array3 = Object.FindObjectsOfType(typeof(ERCrossingPrefabs)) as ERCrossingPrefabs[];
			ERCrossingPrefabs[] array4 = array3;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array4)
			{
				Transform transform;
				if (!(transform = eRCrossingPrefabs.transform.Find("surface")))
				{
					continue;
				}
				transform.gameObject.layer = 31;
				surfaceObjects.Add(transform.gameObject);
				mesh = transform.gameObject.GetComponent<MeshFilter>().sharedMesh;
				if (mesh != null)
				{
					if (minx > mesh.bounds.min.x + eRCrossingPrefabs.transform.position.x)
					{
						minx = mesh.bounds.min.x + eRCrossingPrefabs.transform.position.x;
					}
					if (minz > mesh.bounds.min.z + eRCrossingPrefabs.transform.position.z)
					{
						minz = mesh.bounds.min.z + eRCrossingPrefabs.transform.position.z;
					}
					if (maxx < mesh.bounds.max.x + eRCrossingPrefabs.transform.position.x)
					{
						maxx = mesh.bounds.max.x + eRCrossingPrefabs.transform.position.x;
					}
					if (maxz < mesh.bounds.max.z + eRCrossingPrefabs.transform.position.z)
					{
						maxz = mesh.bounds.max.z + eRCrossingPrefabs.transform.position.z;
					}
				}
				if (!transform.gameObject.GetComponent<MeshCollider>())
				{
					continue;
				}
				if (transform.gameObject.GetComponent<MeshCollider>().sharedMesh == null)
				{
					transform.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
					if (transform.gameObject.GetComponent<MeshCollider>().sharedMesh == null)
					{
						Object.DestroyImmediate(transform.gameObject.GetComponent<MeshCollider>());
						transform.gameObject.AddComponent<MeshCollider>();
					}
				}
				transform.gameObject.GetComponent<MeshCollider>().enabled = true;
			}
			sideObjectSurfacesStart = surfaceObjects.Count;
			ERSideObjectInstance[] array5 = Object.FindObjectsOfType(typeof(ERSideObjectInstance)) as ERSideObjectInstance[];
			ERSideObjectInstance[] array6 = array5;
			foreach (ERSideObjectInstance eRSideObjectInstance in array6)
			{
				if (eRSideObjectInstance.so != null)
				{
					if (!eRSideObjectInstance.so.deformationObject || eRSideObjectInstance.so.objectType != 1)
					{
						continue;
					}
					mesh = eRSideObjectInstance.gameObject.GetComponent<MeshFilter>().sharedMesh;
					if (mesh != null)
					{
						if (minx > mesh.bounds.min.x + eRSideObjectInstance.transform.position.x)
						{
							minx = mesh.bounds.min.x + eRSideObjectInstance.transform.position.x;
						}
						if (minz > mesh.bounds.min.z + eRSideObjectInstance.transform.position.z)
						{
							minz = mesh.bounds.min.z + eRSideObjectInstance.transform.position.z;
						}
						if (maxx < mesh.bounds.max.x + eRSideObjectInstance.transform.position.x)
						{
							maxx = mesh.bounds.max.x + eRSideObjectInstance.transform.position.x;
						}
						if (maxz < mesh.bounds.max.z + eRSideObjectInstance.transform.position.z)
						{
							maxz = mesh.bounds.max.z + eRSideObjectInstance.transform.position.z;
						}
					}
					eRSideObjectInstance.gameObject.layer = 31;
					surfaceObjects.Add(eRSideObjectInstance.gameObject);
					if (!eRSideObjectInstance.gameObject.GetComponent<MeshCollider>())
					{
						continue;
					}
					if (eRSideObjectInstance.gameObject.GetComponent<MeshCollider>().sharedMesh == null)
					{
						eRSideObjectInstance.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
						if (eRSideObjectInstance.gameObject.GetComponent<MeshCollider>().sharedMesh == null)
						{
							Object.DestroyImmediate(eRSideObjectInstance.gameObject.GetComponent<MeshCollider>());
							eRSideObjectInstance.gameObject.AddComponent<MeshCollider>();
						}
					}
					eRSideObjectInstance.gameObject.GetComponent<MeshCollider>().enabled = true;
				}
				else
				{
					string text = "";
					if (eRSideObjectInstance.transform.parent != null)
					{
						text = ", parent object: " + eRSideObjectInstance.transform.parent.gameObject.name;
					}
					Debug.LogWarning("Side Object detected with empty Side Object Instance: " + eRSideObjectInstance.gameObject.name + text);
				}
			}
		}

		public static void ODDCOOOQOQ(ERModularBase scr, ERTerrain terrainScr, Terrain terrain, float minx, float maxx, float minz, float maxz)
		{
			foreach (GameObject treeObject in treeObjects)
			{
				treeObject.GetComponent<MeshCollider>().enabled = true;
			}
			List<TreeInstance> list = new List<TreeInstance>(terrain.terrainData.treeInstances);
			Vector3 position = terrain.gameObject.transform.position;
			LayerMask layerMask = int.MinValue;
			Ray ray = new Ray
			{
				direction = Vector3.down
			};
			int num = 0;
			minx += position.x;
			maxx += position.x;
			minz += position.z;
			maxz += position.z;
			for (int i = 0; i < list.Count; i++)
			{
				Vector3 position2 = list[i].position;
				position2.x *= terrain.terrainData.size.x;
				position2.y *= terrain.terrainData.size.y;
				position2.z *= terrain.terrainData.size.z;
				position2 += position;
				if (position2.x > minx && position2.x < maxx && position2.z > minz && position2.z < maxz)
				{
					position2.y += 100f;
					if (Physics.Raycast(position2, -Vector3.up, out var _, 200f, layerMask))
					{
						terrainScr.terrainTrees.Add(new ERTree(list[i]));
						list.RemoveAt(i);
						i--;
					}
					num++;
				}
			}
			terrain.terrainData.treeInstances = list.ToArray();
			foreach (GameObject treeObject2 in treeObjects)
			{
				treeObject2.GetComponent<MeshCollider>().enabled = false;
			}
		}

		public static void OQCOCQDOCD(ERModularBase scr, ERTerrain terrainScr, Terrain terrain, float minx, float maxx, float minz, float maxz)
		{
			foreach (GameObject detailObject in detailObjects)
			{
				if ((bool)detailObject.GetComponent<MeshCollider>())
				{
					detailObject.GetComponent<MeshCollider>().enabled = true;
				}
			}
			TerrainData terrainData = terrain.terrainData;
			Vector3 position = terrain.gameObject.transform.position;
			minx += position.x;
			maxx += position.x;
			minz += position.z;
			maxz += position.z;
			List<tPoint> list = OQCQCQDOOO(terrain, terrain.terrainData, minx, maxx, minz, maxz);
			List<tPoint> list2 = new List<tPoint>();
			for (int i = 0; i < terrainData.detailPrototypes.Length; i++)
			{
				terrainScr.detailInstanceStarts.Add(list2.Count);
				int[,] detailLayer = terrainData.GetDetailLayer(0, 0, terrainData.detailResolution, terrainData.detailResolution, i);
				foreach (tPoint item in list)
				{
					if (detailLayer[item.z, item.x] != 0)
					{
						item.v = detailLayer[item.z, item.x];
						list2.Add(item);
						detailLayer[item.z, item.x] = 0;
					}
				}
				terrainData.SetDetailLayer(0, 0, i, detailLayer);
			}
			terrainScr.detailInstances.AddRange(list2);
			foreach (GameObject detailObject2 in detailObjects)
			{
				if ((bool)detailObject2.GetComponent<MeshCollider>())
				{
					detailObject2.GetComponent<MeshCollider>().enabled = false;
				}
			}
		}

		public static void OQDDDCDOOO(ERModularBase scr, ERTerrain terrainScr, Terrain terrain, float minx, float maxx, float minz, float maxz)
		{
			for (int i = 0; i < scr.soSplatmapObjects.Count; i++)
			{
				scr.soSplatmapObjects[i].GetComponent<MeshCollider>().enabled = true;
			}
			List<ERSplatmap> instances = new List<ERSplatmap>();
			TerrainData terrainData = terrainScr.terrainData;
			float[,,] alphamaps = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
			float x = terrain.transform.position.x;
			float z = terrain.transform.position.z;
			if (terrain.transform.position.x != 0f)
			{
				x = 0f;
			}
			if (terrain.transform.position.z != 0f)
			{
				z = 0f;
			}
			float num = terrainData.size.x / (float)terrainData.alphamapWidth;
			float num2 = terrainData.size.z / (float)terrainData.alphamapHeight;
			float num3 = num * 0.5f;
			float num4 = num2 * 0.5f;
			int num5 = Mathf.RoundToInt(Mathf.Floor(minx / num));
			int num6 = Mathf.RoundToInt(Mathf.Ceil(maxx / num));
			int num7 = Mathf.RoundToInt(Mathf.Floor(minz / num2));
			int num8 = Mathf.RoundToInt(Mathf.Ceil(maxz / num2));
			if (terrainData.alphamapWidth - num6 == 1)
			{
				num6 = terrainData.alphamapWidth;
			}
			if (terrainData.alphamapHeight - num8 == 1)
			{
				num8 = terrainData.alphamapHeight;
			}
			if (num5 < 0 || num5 > terrainData.alphamapWidth || num7 < 0 || num7 > terrainData.alphamapHeight || num6 < 0 || num6 > terrainData.alphamapWidth || num8 < 0 || num8 > terrainData.alphamapHeight)
			{
				return;
			}
			float x2 = terrain.transform.position.x;
			float z2 = terrain.transform.position.z;
			float y = terrain.transform.position.y;
			LayerMask layerMask = int.MinValue;
			Ray ray = new Ray
			{
				direction = Vector3.down
			};
			float y2 = terrainData.size.y;
			float num9 = 0f;
			bool flag = false;
			float num10 = 0f;
			float num11 = 0f;
			Vector3 zero = Vector3.zero;
			int alphamapLayers = terrainData.alphamapLayers;
			float y3 = terrain.transform.position.y;
			GameObject gameObject = GameObject.Find("Cube");
			for (int i = 0; i < num6 - num5; i++)
			{
				for (int j = 0; j < num8 - num7; j++)
				{
					Vector3 origin = new Vector3(num3 + x2 + (float)(num5 + i) * num, 10f, num4 + z2 + (float)(num7 + j) * num2);
					if (Physics.Raycast(origin, -Vector3.up, out var hitInfo, 20f, layerMask))
					{
						string text = hitInfo.collider.gameObject.name;
						OOCCOOCCCO(hitInfo.collider.gameObject, num7 + j, num5 + i, ref instances, alphamaps, alphamapLayers);
					}
				}
			}
			terrainScr.splatData.AddRange(instances);
			terrainData.SetAlphamaps(0, 0, ODCODODDDO(instances, alphamaps, alphamapLayers));
			for (int i = 0; i < scr.soSplatmapObjects.Count; i++)
			{
				scr.soSplatmapObjects[i].GetComponent<MeshCollider>().enabled = false;
			}
		}

		public static float[,,] ODCODODDDO(List<ERSplatmap> mapData, float[,,] trmap, int layers)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < mapData.Count; i++)
			{
				num = mapData[i].x;
				num2 = mapData[i].y;
				int index = mapData[i].index;
				float value = mapData[i].value;
				float num3 = 1f - value;
				float num4 = 0f;
				for (int j = 0; j < layers; j++)
				{
					if (j != index - 1)
					{
						num4 += trmap[num, num2, j];
					}
				}
				float num5 = 1f - trmap[num, num2, index - 1];
				float num6 = 0f;
				if (trmap[num, num2, index - 1] >= value)
				{
					continue;
				}
				if (value == 1f)
				{
					if (trmap[num, num2, index - 1] == 1f)
					{
						continue;
					}
					for (int j = 0; j < layers; j++)
					{
						if (j != index - 1)
						{
							trmap[num, num2, j] = 0f;
						}
						else
						{
							trmap[num, num2, j] = 1f;
						}
					}
				}
				else if (index <= 4)
				{
					if (layers >= 1)
					{
						if (index == 1)
						{
							if (trmap[num, num2, 0] < value)
							{
								trmap[num, num2, 0] = value;
							}
						}
						else
						{
							num6 = trmap[num, num2, 0] / num4;
							trmap[num, num2, 0] = num3 * num6;
						}
					}
					if (layers >= 2)
					{
						if (index == 2)
						{
							if (trmap[num, num2, 1] < value)
							{
								trmap[num, num2, 1] = value;
							}
						}
						else
						{
							num6 = trmap[num, num2, 1] / num4;
							trmap[num, num2, 1] = num3 * num6;
						}
					}
					if (layers >= 3)
					{
						if (index == 3)
						{
							if (trmap[num, num2, 2] < value)
							{
								trmap[num, num2, 2] = value;
							}
						}
						else
						{
							num6 = trmap[num, num2, 2] / num4;
							trmap[num, num2, 2] = num3 * num6;
						}
					}
					if (layers >= 4)
					{
						if (index == 4)
						{
							if (trmap[num, num2, 3] < value)
							{
								trmap[num, num2, 3] = value;
							}
						}
						else
						{
							num6 = trmap[num, num2, 3] / num4;
							trmap[num, num2, 3] = num3 * num6;
						}
					}
					if (layers >= 5)
					{
						if (index == 5)
						{
							if (trmap[num, num2, 4] < value)
							{
								trmap[num, num2, 4] = value;
							}
						}
						else
						{
							num6 = trmap[num, num2, 4] / num4;
							trmap[num, num2, 4] = num3 * num6;
						}
					}
					if (layers >= 6)
					{
						if (index == 6)
						{
							if (trmap[num, num2, 5] < value)
							{
								trmap[num, num2, 5] = value;
							}
						}
						else
						{
							num6 = trmap[num, num2, 5] / num4;
							trmap[num, num2, 5] = num3 * num6;
						}
					}
					if (layers >= 7)
					{
						if (index == 7)
						{
							if (trmap[num, num2, 6] < value)
							{
								trmap[num, num2, 6] = value;
							}
						}
						else
						{
							num6 = trmap[num, num2, 6] / num4;
							trmap[num, num2, 6] = num3 * num6;
						}
					}
					if (layers < 8)
					{
						continue;
					}
					if (index == 8)
					{
						if (trmap[num, num2, 7] < value)
						{
							trmap[num, num2, 7] = value;
						}
					}
					else
					{
						num6 = trmap[num, num2, 7] / num4;
						trmap[num, num2, 7] = num3 * num6;
					}
				}
				else
				{
					if (index > 8)
					{
						continue;
					}
					num6 = trmap[num, num2, 0] / num4;
					trmap[num, num2, 0] = num3 * num6;
					num6 = trmap[num, num2, 1] / num4;
					trmap[num, num2, 1] = num3 * num6;
					num6 = trmap[num, num2, 2] / num4;
					trmap[num, num2, 2] = num3 * num6;
					num6 = trmap[num, num2, 3] / num4;
					trmap[num, num2, 3] = num3 * num6;
					if (layers >= 5)
					{
						if (index == 5)
						{
							if (trmap[num, num2, 4] < value)
							{
								trmap[num, num2, 4] = value;
							}
						}
						else
						{
							num6 = trmap[num, num2, 4] / num4;
							trmap[num, num2, 4] = num3 * num6;
						}
					}
					if (layers >= 6)
					{
						if (index == 6)
						{
							if (trmap[num, num2, 5] < value)
							{
								trmap[num, num2, 5] = value;
							}
						}
						else
						{
							num6 = trmap[num, num2, 5] / num4;
							trmap[num, num2, 5] = num3 * num6;
						}
					}
					if (layers >= 7)
					{
						if (index == 7)
						{
							if (trmap[num, num2, 6] < value)
							{
								trmap[num, num2, 6] = value;
							}
						}
						else
						{
							num6 = trmap[num, num2, 6] / num4;
							trmap[num, num2, 6] = num3 * num6;
						}
					}
					if (layers < 8)
					{
						continue;
					}
					if (index == 8)
					{
						if (trmap[num, num2, 7] < value)
						{
							trmap[num, num2, 7] = value;
						}
					}
					else
					{
						num6 = trmap[num, num2, 7] / num4;
						trmap[num, num2, 7] = num3 * num6;
					}
				}
			}
			return trmap;
		}

		public static void OQDQDDDOOQ(ERModularBase scr, ERTerrain terrainScr, Terrain terrain)
		{
			if (terrainScr.heightmapFlag)
			{
				try
				{
					terrainScr.terrainTestPoints.Clear();
					float[,] heights = terrainScr.terrainData.GetHeights(0, 0, terrainScr.terrainData.heightmapResolution, terrainScr.terrainData.heightmapResolution);
					foreach (ERTerrainData item in terrainScr.terrainDataStored)
					{
						if (terrainScr.zStart + item.terrainWidth < 0 || terrainScr.zStart + item.terrainWidth > terrainScr.terrainData.heightmapResolution)
						{
							Debug.Log("z: " + (terrainScr.zStart + item.terrainWidth) + ": " + terrainScr.zStart + " " + item.terrainWidth);
						}
						if (terrainScr.xStart + item.terrainHeight < 0 || terrainScr.xStart + item.terrainHeight > terrainScr.terrainData.heightmapResolution)
						{
							Debug.Log("x: " + (terrainScr.xStart + item.terrainHeight) + ": " + terrainScr.xStart + " " + item.terrainHeight);
						}
						heights[terrainScr.zStart + item.terrainWidth, terrainScr.xStart + item.terrainHeight] = item.originalHeight;
					}
					terrain.terrainData.SetHeights(0, 0, heights);
					terrainScr.terrainDataStored.Clear();
				}
				catch
				{
					Debug.LogError("EasyRoads3Dv3: Restoring the heightmap of terrain " + terrain.name + " failed, please report with details!");
				}
			}
			if (scr.doTrees && terrainScr.treeFlag)
			{
				try
				{
					OQOQQDQDQQ(terrainScr, terrain);
				}
				catch
				{
					Debug.LogError("EasyRoads3Dv3: Restoring trees removed from terrain " + terrain.name + " failed, please report with details with details!");
				}
			}
			if (scr.doDetail && terrainScr.detailFlag)
			{
				try
				{
					OCODOQCDQD(terrainScr, terrain);
				}
				catch
				{
					Debug.LogError("EasyRoads3Dv3: Restoring detail objects removed from terrain " + terrain.name + " failed, please report with details!");
				}
			}
			terrain.Flush();
			terrainScr.heightmapFlag = false;
			terrainScr.treeFlag = false;
			terrainScr.detailFlag = false;
			terrainScr.terrainDone = false;
		}

		public static void OQOQQDQDQQ(ERTerrain terrainScr, Terrain terrain)
		{
			List<TreeInstance> list = new List<TreeInstance>(terrain.terrainData.treeInstances);
			for (int i = 0; i < terrainScr.terrainTrees.Count; i++)
			{
				list.Add(terrainScr.terrainTrees[i].SetERTreeInstance(terrainScr.terrainTrees[i]));
			}
			terrain.terrainData.treeInstances = list.ToArray();
			terrainScr.terrainTrees.Clear();
		}

		public static void OCODOQCDQD(ERTerrain terrainScr, Terrain terrain)
		{
			TerrainData terrainData = terrain.terrainData;
			List<tPoint> list = new List<tPoint>();
			int[,] detailLayer = terrainData.GetDetailLayer(0, 0, terrainData.detailResolution, terrainData.detailResolution, 0);
			int num = -1;
			int num2 = 0;
			if (num2 + 1 < terrainScr.detailInstanceStarts.Count)
			{
				num = terrainScr.detailInstanceStarts[num2 + 1];
			}
			for (int i = 0; i < terrainScr.detailInstances.Count; i++)
			{
				if (i == num)
				{
					ODCOCCDDCO(terrain.terrainData, num2, list);
					num2++;
					if (num2 + 1 < terrainScr.detailInstanceStarts.Count)
					{
						num = terrainScr.detailInstanceStarts[num2 + 1];
					}
					list.Clear();
				}
				list.Add(terrainScr.detailInstances[i]);
			}
			if (list.Count > 0)
			{
				ODCOCCDDCO(terrain.terrainData, num2, list);
			}
			terrainScr.detailInstances.Clear();
			terrainScr.detailInstanceStarts.Clear();
		}

		public static void ODCOCCDDCO(TerrainData terrainInfo, int layer, List<tPoint> points)
		{
			int[,] detailLayer = terrainInfo.GetDetailLayer(0, 0, terrainInfo.detailResolution, terrainInfo.detailResolution, layer);
			for (int i = 0; i < points.Count; i++)
			{
				detailLayer[points[i].z, points[i].x] = points[i].v;
			}
			terrainInfo.SetDetailLayer(0, 0, layer, detailLayer);
		}

		public static List<tPoint> OQCQCQDOOO(Terrain terrain, TerrainData terrainInfo, float minx, float maxx, float minz, float maxz)
		{
			float num = terrainInfo.size.x / (float)terrainInfo.detailResolution;
			float num2 = terrainInfo.size.z / (float)terrainInfo.detailResolution;
			float x = terrain.transform.position.x;
			float z = terrain.transform.position.z;
			float num3 = (minx + maxx) * 0.5f;
			float num4 = (minz + maxz) * 0.5f;
			float num5 = maxx - minx;
			float num6 = maxz - minz;
			int num7 = (int)((num3 - x) / num);
			int num8 = (int)((num4 - z) / num2);
			int num9 = (int)(num5 / num);
			int num10 = (int)(num6 / num2);
			List<tPoint> list = new List<tPoint>();
			for (int i = 0; i < num10; i++)
			{
				for (int j = 0; j < num9; j++)
				{
					tPoint tPoint2 = new tPoint();
					tPoint2.x = (int)((double)num7 - (double)num9 * 0.5 + (double)j);
					tPoint2.z = (int)((double)num8 - (double)num10 * 0.5 + (double)i);
					if (tPoint2.x >= 0 && tPoint2.z >= 0 && tPoint2.x < terrainInfo.detailResolution && tPoint2.z < terrainInfo.detailResolution)
					{
						list.Add(tPoint2);
					}
				}
			}
			List<tPoint> list2 = new List<tPoint>();
			foreach (tPoint item in list)
			{
				if (item.z < terrainInfo.detailResolution && item.x < terrainInfo.detailResolution)
				{
					Vector3 zero = Vector3.zero;
					zero.x = terrain.gameObject.transform.position.x + (float)item.x * num;
					zero.z = terrain.gameObject.transform.position.z + (float)item.z * num2;
					zero.y = terrain.SampleHeight(zero) + terrain.transform.position.y;
					LayerMask layerMask = int.MinValue;
					zero.y += 20f;
					if (Physics.Raycast(zero, -Vector3.up, out var _, 30f, layerMask))
					{
						list2.Add(item);
					}
				}
			}
			return list2;
		}

		public static void OODDOOQCQQ(ERTerrain tr, Terrain terrain)
		{
			float[,] heights = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
			foreach (ERTerrainData item in tr.terrainDataStored)
			{
				if (item.critical)
				{
					heights[tr.zStart + item.terrainWidth, tr.xStart + item.terrainHeight] = item.flattenedHeight;
				}
			}
			terrain.terrainData.SetHeights(0, 0, heights);
		}

		public static void OQOCQQDOOQ(ERTerrain tr, Terrain terrain, float perc)
		{
			float[,] heights = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
			float num = 0f;
			float num2 = terrain.transform.position.y / terrain.terrainData.size.y;
			foreach (ERTerrainData item in tr.terrainDataStored)
			{
				if (!item.critical && !item.ignorePreserveHeights)
				{
					num = Mathf.Lerp(1f, item.perc, perc);
					float num3 = Mathf.Lerp(item.originalHeight, item.flattenedHeight, num);
					heights[tr.zStart + item.terrainWidth, tr.xStart + item.terrainHeight] = num3;
				}
			}
			terrain.terrainData.SetHeights(0, 0, heights);
		}

		public static void OOCCOOCCCO(GameObject go, int x, int y, ref List<ERSplatmap> instances, float[,,] trmap, int layers)
		{
			string[] array = go.name.Split('_');
			if (go.name.IndexOf("SplatGO") == -1)
			{
				return;
			}
			int index = int.Parse(array[0].Replace("SplatGOcolor", ""));
			float value = float.Parse(array[1]);
			float tv2;
			float tv3;
			float tv4;
			float tv5;
			float tv6;
			float tv7;
			float tv8;
			float num;
			float num2;
			float num3;
			float num4;
			float tv = (tv2 = (tv3 = (tv4 = (tv5 = (tv6 = (tv7 = (tv8 = (num = (num2 = (num3 = (num4 = 0f)))))))))));
			if (layers > 0)
			{
				tv = trmap[x, y, 0];
				if (layers > 1)
				{
					tv2 = trmap[x, y, 1];
					if (layers > 2)
					{
						tv3 = trmap[x, y, 2];
						if (layers > 3)
						{
							tv4 = trmap[x, y, 3];
							if (layers > 4)
							{
								tv5 = trmap[x, y, 4];
								if (layers > 5)
								{
									tv6 = trmap[x, y, 5];
									if (layers > 6)
									{
										tv7 = trmap[x, y, 6];
										if (layers > 7)
										{
											tv8 = trmap[x, y, 7];
											if (layers > 8)
											{
												num = trmap[x, y, 8];
												if (layers > 9)
												{
													num2 = trmap[x, y, 9];
													if (layers > 10)
													{
														num3 = trmap[x, y, 10];
														if (layers > 11)
														{
															num4 = trmap[x, y, 11];
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			instances.Add(new ERSplatmap(x, y, index, layers, value, go.transform.parent.GetComponent<ERModularRoad>(), tv, tv2, tv3, tv4, tv5, tv6, tv7, tv8));
		}

		public static void ODCCOCCQDD(ERModularBase baseScript, ERModularRoad scr)
		{
			scr.treeVecs.Clear();
			scr.detailVecs.Clear();
			for (int i = 0; i < scr.soSplinePointsLeft.Count; i++)
			{
				Vector3 normalized = (scr.soSplinePointsLeft[i] - scr.soSplinePointsRight[i]).normalized;
				if (i == 0 || i == scr.soSplinePointsLeft.Count - 1)
				{
					Vector3 vector = scr.soSplinePointsLeft[i];
					Vector3 vector2 = scr.soSplinePointsRight[i];
					Vector3 vector3 = new Vector3(normalized.z, 0f, 0f - normalized.x);
					if (i == 0)
					{
						vector += -vector3 * 1.5f;
						vector2 += -vector3 * 1.5f;
					}
					else
					{
						vector += vector3 * 1.5f;
						vector2 += vector3 * 1.5f;
					}
					scr.treeVecs.Add(vector + normalized * baseScript.treeDistance);
					scr.treeVecs.Add(vector2 + -normalized * baseScript.treeDistance);
					scr.detailVecs.Add(vector + normalized * baseScript.detailDistance - baseScript.detailOffsetVec);
					scr.detailVecs.Add(vector2 + -normalized * baseScript.detailDistance - baseScript.detailOffsetVec);
				}
				else
				{
					scr.treeVecs.Add(scr.soSplinePointsLeft[i] + normalized * baseScript.treeDistance);
					scr.treeVecs.Add(scr.soSplinePointsRight[i] + -normalized * baseScript.treeDistance);
					scr.detailVecs.Add(scr.soSplinePointsLeft[i] + normalized * baseScript.detailDistance - baseScript.detailOffsetVec);
					scr.detailVecs.Add(scr.soSplinePointsRight[i] + -normalized * baseScript.detailDistance - baseScript.detailOffsetVec);
				}
			}
		}

		public static GameObject CreateMesh(Transform parent, List<Vector3> vecs, List<int> tris, int layer, string name)
		{
			GameObject gameObject = new GameObject(name);
			gameObject.AddComponent<MeshFilter>();
			gameObject.AddComponent<MeshRenderer>();
			gameObject.AddComponent<MeshCollider>();
			gameObject.transform.parent = parent;
			gameObject.layer = layer;
			Mesh mesh = new Mesh();
			gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			if (vecs.Count > 0)
			{
				mesh.vertices = vecs.ToArray();
				mesh.uv = new Vector2[vecs.Count];
				mesh.tangents = new Vector4[vecs.Count];
				mesh.triangles = tris.ToArray();
				mesh.RecalculateBounds();
			}
			gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
			gameObject.GetComponent<MeshCollider>().enabled = false;
			return gameObject;
		}

		public static void OQDDDDQQCO(ERTerrain terrain, string folder)
		{
			Terrain component = terrain.gameObject.GetComponent<Terrain>();
			if (!(component != null))
			{
				return;
			}
			TerrainData terrainData = component.terrainData;
			terrain.terrainHeightsBackup.Clear();
			float[,] heights = component.terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
			for (int i = 0; i < terrainData.heightmapResolution; i++)
			{
				for (int j = 0; j < terrainData.heightmapResolution; j++)
				{
					terrain.terrainHeightsBackup.Add(new ERTerrainData(j, i, heights[j, i], 0f, m_critical: false, 0f, 0f, Vector3.zero, Vector3.zero));
				}
			}
		}

		public static void OOQDOQCDDD(ERTerrain terrain, string folder)
		{
			Terrain component = terrain.gameObject.GetComponent<Terrain>();
			if (component != null)
			{
				TerrainData terrainData = component.terrainData;
				terrain.terrainTreesBackup.Clear();
				for (int i = 0; i < terrainData.treeInstances.Length; i++)
				{
					terrain.terrainTreesBackup.Add(new ERTree(terrainData.treeInstances[i]));
				}
			}
		}

		public static void OCDQQQDOCD(ERTerrain terrain, string folder)
		{
			Terrain component = terrain.gameObject.GetComponent<Terrain>();
			if (!(component != null))
			{
				return;
			}
			TerrainData terrainData = component.terrainData;
			terrain.terrainDetailBackup.Clear();
			terrain.detailInstanceStartsBackUp.Clear();
			List<tPoint> list = new List<tPoint>();
			for (int i = 0; i < terrainData.detailPrototypes.Length; i++)
			{
				terrain.detailInstanceStartsBackUp.Add(list.Count);
				int[,] detailLayer = terrainData.GetDetailLayer(0, 0, terrainData.detailResolution, terrainData.detailResolution, i);
				for (int j = 0; j < terrainData.detailResolution; j++)
				{
					for (int k = 0; k < terrainData.detailResolution; k++)
					{
						tPoint tPoint2 = new tPoint();
						tPoint2.x = j;
						tPoint2.z = k;
						if (detailLayer[tPoint2.z, tPoint2.x] != 0)
						{
							tPoint2.v = detailLayer[tPoint2.z, tPoint2.x];
							list.Add(tPoint2);
						}
					}
				}
			}
			terrain.terrainDetailBackup.AddRange(list);
		}

		public static void OQCCDOCCCO(ERTerrain terrain, string folder)
		{
			Terrain component = terrain.gameObject.GetComponent<Terrain>();
			if (!(component != null))
			{
				return;
			}
			TerrainData terrainData = component.terrainData;
			terrain.terrainSplatBackup.Clear();
			int alphamapLayers = terrainData.alphamapLayers;
			if (alphamapLayers > 0)
			{
				float[,,] alphamaps = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
				for (int i = 0; i < terrainData.alphamapWidth; i++)
				{
					for (int j = 0; j < terrainData.alphamapHeight; j++)
					{
						float tv2;
						float tv3;
						float tv4;
						float tv5;
						float tv6;
						float tv7;
						float tv8;
						float tv = (tv2 = (tv3 = (tv4 = (tv5 = (tv6 = (tv7 = (tv8 = 0f)))))));
						if (alphamapLayers >= 1)
						{
							tv = alphamaps[i, j, 0];
						}
						if (alphamapLayers >= 2)
						{
							tv2 = alphamaps[i, j, 1];
						}
						if (alphamapLayers >= 3)
						{
							tv3 = alphamaps[i, j, 2];
						}
						if (alphamapLayers >= 4)
						{
							tv4 = alphamaps[i, j, 3];
						}
						terrain.terrainSplatBackup.Add(new ERSplatmap(i, j, 0, 0, 0f, null, tv, tv2, tv3, tv4, tv5, tv6, tv7, tv8));
						if (alphamapLayers >= 5)
						{
							tv = (tv2 = (tv3 = (tv4 = (tv5 = (tv6 = (tv7 = (tv8 = 0f)))))));
							if (alphamapLayers >= 4)
							{
								tv = alphamaps[i, j, 4];
							}
							if (alphamapLayers >= 5)
							{
								tv2 = alphamaps[i, j, 5];
							}
							if (alphamapLayers >= 6)
							{
								tv3 = alphamaps[i, j, 6];
							}
							if (alphamapLayers >= 7)
							{
								tv4 = alphamaps[i, j, 7];
							}
							terrain.terrainSplatBackup.Add(new ERSplatmap(i, j, 5, 5, 0f, null, tv, tv2, tv3, tv4, tv5, tv6, tv7, tv8));
						}
						if (alphamapLayers >= 9)
						{
							tv = (tv2 = (tv3 = (tv4 = (tv5 = (tv6 = (tv7 = (tv8 = 0f)))))));
							if (alphamapLayers >= 8)
							{
								tv = alphamaps[i, j, 8];
							}
							if (alphamapLayers >= 9)
							{
								tv2 = alphamaps[i, j, 9];
							}
							if (alphamapLayers >= 10)
							{
								tv3 = alphamaps[i, j, 10];
							}
							if (alphamapLayers >= 11)
							{
								tv4 = alphamaps[i, j, 11];
							}
							terrain.terrainSplatBackup.Add(new ERSplatmap(i, j, 9, 9, 0f, null, tv, tv2, tv3, tv4, tv5, tv6, tv7, tv8));
						}
					}
				}
			}
			terrain.terrainHeightsBackup.Clear();
		}

		public static void OCCQQQQOQC(ERTerrain terrain, string folder)
		{
			Terrain component = terrain.gameObject.GetComponent<Terrain>();
			if (!(component != null))
			{
				return;
			}
			TerrainData terrainData = component.terrainData;
			float[,] heights = terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);
			foreach (ERTerrainData item in terrain.terrainHeightsBackup)
			{
				heights[item.terrainWidth, item.terrainHeight] = item.originalHeight;
			}
			terrainData.SetHeights(0, 0, heights);
			component.Flush();
		}

		public static void OCDCQOOQDD(ERTerrain terrain, string folder)
		{
			Terrain component = terrain.gameObject.GetComponent<Terrain>();
			if (component != null)
			{
				TerrainData terrainData = component.terrainData;
				List<TreeInstance> list = new List<TreeInstance>();
				for (int i = 0; i < terrain.terrainTreesBackup.Count; i++)
				{
					list.Add(terrain.terrainTreesBackup[i].SetERTreeInstance(terrain.terrainTreesBackup[i]));
				}
				terrainData.treeInstances = list.ToArray();
				component.Flush();
			}
		}

		public static void OODQQQDOQD(ERTerrain terrain, string folder)
		{
			Terrain component = terrain.gameObject.GetComponent<Terrain>();
			if (!(component != null))
			{
				return;
			}
			TerrainData terrainData = component.terrainData;
			List<tPoint> list = new List<tPoint>();
			int[,] detailLayer = terrainData.GetDetailLayer(0, 0, terrainData.detailResolution, terrainData.detailResolution, 0);
			int num = -1;
			int num2 = 0;
			if (num2 + 1 < terrain.detailInstanceStartsBackUp.Count)
			{
				num = terrain.detailInstanceStartsBackUp[num2 + 1];
			}
			for (int i = 0; i < terrain.terrainDetailBackup.Count; i++)
			{
				if (i == num)
				{
					ODCOCCDDCO(terrainData, num2, list);
					if (num2 + 1 < terrain.detailInstanceStartsBackUp.Count)
					{
						num = terrain.detailInstanceStartsBackUp[num2 + 1];
					}
					num2++;
					list.Clear();
				}
			}
			if (list.Count > 0)
			{
				ODCOCCDDCO(terrainData, num2, list);
			}
			component.Flush();
		}

		public static void OQDOQDOQOD(ERTerrain terrain, string folder)
		{
			Terrain component = terrain.gameObject.GetComponent<Terrain>();
			if (!(component != null))
			{
				return;
			}
			TerrainData terrainData = component.terrainData;
			int alphamapLayers = terrainData.alphamapLayers;
			if (alphamapLayers > 0 && terrain.terrainSplatBackup.Count > 0)
			{
				float[,,] alphamaps = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
				foreach (ERSplatmap item in terrain.terrainSplatBackup)
				{
					if (item.index <= 4)
					{
						if (alphamapLayers > 0)
						{
							alphamaps[item.x, item.y, 0] = item.tValue1;
						}
						if (alphamapLayers > 1)
						{
							alphamaps[item.x, item.y, 1] = item.tValue2;
						}
						if (alphamapLayers > 2)
						{
							alphamaps[item.x, item.y, 2] = item.tValue3;
						}
						if (alphamapLayers > 3)
						{
							alphamaps[item.x, item.y, 3] = item.tValue4;
						}
					}
					else if (item.index <= 8)
					{
						if (alphamapLayers > 4)
						{
							alphamaps[item.x, item.y, 4] = item.tValue1;
						}
						if (alphamapLayers > 5)
						{
							alphamaps[item.x, item.y, 5] = item.tValue2;
						}
						if (alphamapLayers > 6)
						{
							alphamaps[item.x, item.y, 6] = item.tValue3;
						}
						if (alphamapLayers > 7)
						{
							alphamaps[item.x, item.y, 7] = item.tValue4;
						}
					}
					else if (item.index <= 12)
					{
						if (alphamapLayers > 8)
						{
							alphamaps[item.x, item.y, 8] = item.tValue1;
						}
						if (alphamapLayers > 9)
						{
							alphamaps[item.x, item.y, 9] = item.tValue2;
						}
						if (alphamapLayers > 10)
						{
							alphamaps[item.x, item.y, 10] = item.tValue3;
						}
						if (alphamapLayers > 11)
						{
							alphamaps[item.x, item.y, 11] = item.tValue4;
						}
					}
				}
				terrainData.SetAlphamaps(0, 0, alphamaps);
			}
			component.Flush();
		}
	}
}
