using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERRoadNetwork
	{
		public ERModularBase roadNetwork;

		public bool isInBuildMode = false;

		public string str = "EasyRoads3Dv3 Warning: The free version does not support API calls";

		public ERRoadNetwork()
		{
			roadNetwork = Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
			if (roadNetwork == null)
			{
				GameObject gameObject = (GameObject)Object.Instantiate(Resources.Load("ER Road Network"));
				roadNetwork = gameObject.GetComponent<ERModularBase>();
				gameObject.name = "Road Network";
				gameObject.transform.position = Vector3.zero;
				gameObject.GetComponent<ERModularBase>().importSideObjectsAlert = false;
				gameObject.GetComponent<ERModularBase>().importRoadPresetsAlert = false;
				gameObject.GetComponent<ERModularBase>().importCrossingPresetsAlert = false;
				gameObject.GetComponent<ERModularBase>().importSidewalkPresetsAlert = false;
			}
			roadNetwork.OOQOOCQDCQ();
			roadNetwork.OOQODQOQDD();
		}

		public void GetTerrainData()
		{
			roadNetwork.OOQOOCQDCQ();
		}

		public void Translate(Vector3 pos)
		{
			ERModularRoad[] componentsInChildren = roadNetwork.gameObject.GetComponentsInChildren<ERModularRoad>();
			ERModularRoad[] array = componentsInChildren;
			foreach (ERModularRoad eRModularRoad in array)
			{
				foreach (ERMarkerExt item in eRModularRoad.markersExt)
				{
					item.position += pos;
				}
			}
			ERCrossingPrefabs[] componentsInChildren2 = roadNetwork.gameObject.GetComponentsInChildren<ERCrossingPrefabs>();
			ERCrossingPrefabs[] array2 = componentsInChildren2;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array2)
			{
				eRCrossingPrefabs.gameObject.transform.position += pos;
			}
			OCQCDQCQOQExt.ODDDQODDQQ(roadNetwork);
		}

		public void CenterPivotPoints()
		{
			ERModularRoad[] componentsInChildren = roadNetwork.gameObject.GetComponentsInChildren<ERModularRoad>();
			ERModularRoad[] array = componentsInChildren;
			foreach (ERModularRoad eRModularRoad in array)
			{
				Vector3 zero = Vector3.zero;
				foreach (ERMarkerExt item in eRModularRoad.markersExt)
				{
					zero += item.position;
				}
				zero /= (float)eRModularRoad.markersExt.Count;
				Mesh mesh = null;
				bool flag = false;
				MeshFilter component = eRModularRoad.GetComponent<MeshFilter>();
				if (component != null && component.sharedMesh != null)
				{
					mesh = component.sharedMesh;
				}
				MeshFilter[] componentsInChildren2 = eRModularRoad.gameObject.GetComponentsInChildren<MeshFilter>();
				MeshFilter[] array2 = componentsInChildren2;
				foreach (MeshFilter meshFilter in array2)
				{
					if (!(meshFilter.sharedMesh != null))
					{
						continue;
					}
					if (meshFilter.transform.position == Vector3.zero)
					{
						Mesh sharedMesh = meshFilter.sharedMesh;
						if (sharedMesh != mesh || !flag)
						{
							Vector3[] vertices = sharedMesh.vertices;
							for (int k = 0; k < vertices.Length; k++)
							{
								vertices[k] -= zero;
							}
							sharedMesh.vertices = vertices;
							if ((bool)meshFilter.gameObject.GetComponent<MeshCollider>())
							{
								meshFilter.gameObject.GetComponent<MeshCollider>().sharedMesh = null;
								meshFilter.gameObject.GetComponent<MeshCollider>().sharedMesh = sharedMesh;
							}
							sharedMesh.RecalculateBounds();
							if (sharedMesh == mesh)
							{
								flag = true;
							}
						}
						else if (sharedMesh == mesh && (bool)meshFilter.gameObject.GetComponent<MeshCollider>())
						{
							meshFilter.gameObject.GetComponent<MeshCollider>().sharedMesh = null;
							meshFilter.gameObject.GetComponent<MeshCollider>().sharedMesh = sharedMesh;
						}
					}
					else if (meshFilter.GetComponent<ERPrefabInstance>() != null)
					{
						meshFilter.transform.position -= zero;
					}
					else if (meshFilter.transform.parent.GetComponent<ERPrefabInstance>() != null)
					{
						meshFilter.transform.parent.position -= zero;
					}
				}
				eRModularRoad.transform.position = zero;
				if ((bool)eRModularRoad.GetComponent<LODGroup>())
				{
					eRModularRoad.GetComponent<LODGroup>().RecalculateBounds();
				}
			}
		}

		public ERRoad[] GetRoads()
		{
			ERModularRoad[] componentsInChildren = roadNetwork.gameObject.GetComponentsInChildren<ERModularRoad>();
			List<ERRoad> list = new List<ERRoad>();
			ERModularRoad[] array = componentsInChildren;
			foreach (ERModularRoad eRModularRoad in array)
			{
				if (eRModularRoad.road == null)
				{
					eRModularRoad.road = new ERRoad(eRModularRoad);
				}
				list.Add(eRModularRoad.road);
			}
			return list.ToArray();
		}

		public ERRoad GetRoadByName(string name)
		{
			ERModularRoad[] componentsInChildren = roadNetwork.gameObject.GetComponentsInChildren<ERModularRoad>();
			ERRoad result = null;
			ERModularRoad[] array = componentsInChildren;
			foreach (ERModularRoad eRModularRoad in array)
			{
				if (eRModularRoad.name == name)
				{
					if (eRModularRoad.road == null)
					{
						eRModularRoad.road = new ERRoad(eRModularRoad);
					}
					result = eRModularRoad.road;
					break;
				}
			}
			return result;
		}

		public ERRoad GetRoadByGameObject(GameObject go)
		{
			ERModularRoad component = go.GetComponent<ERModularRoad>();
			ERRoad result = null;
			if (component != null)
			{
				if (component.road == null)
				{
					component.road = new ERRoad(component);
				}
				result = component.road;
			}
			return result;
		}

		public ERRoad CreateRoad(string roadName)
		{
			ERModularRoad eRModularRoad = InitRoad(roadName, null, null);
			eRModularRoad.road = new ERRoad(eRModularRoad);
			return eRModularRoad.road;
		}

		public ERRoad CreateRoad(string roadName, Vector3[] markers)
		{
			ERModularRoad eRModularRoad = InitRoad(roadName, null, null);
			eRModularRoad.road = new ERRoad(eRModularRoad);
			ERRoad road = eRModularRoad.road;
			AddInititialMarkers(road, markers);
			eRModularRoad.OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
			return road;
		}

		public ERRoad CreateRoad(string roadName, ERRoadType roadType)
		{
			ERModularRoad eRModularRoad = InitRoad(roadName, roadType, null);
			eRModularRoad.road = new ERRoad(eRModularRoad);
			ERRoad road = eRModularRoad.road;
			if (roadType != null)
			{
				road.SetWidth(roadType.roadWidth);
				road.SetMaterial(roadType.roadMaterial);
				road.roadScript.roadShape = new List<Vector2>(roadType.roadShape);
				road.roadScript.doConnectionTri = new List<bool>(roadType.doConnectionTri);
				road.roadScript.roadShapeUVs = new List<float>(roadType.roadShapeUVs);
				road.roadScript.roadShapeUVs2 = new List<float>(roadType.roadShapeUVs2);
				road.roadScript.hardEdge = new List<bool>(roadType.hardEdge);
				road.IsSideObject(roadType.isSideObject);
				if (roadType.isSideObject)
				{
					road.roadScript.snapToTerrain = true;
				}
				road.SetSideObjects(roadType.soDataExt);
				eRModularRoad.gameObject.layer = (eRModularRoad.layer = roadType.layer);
				if (roadType.tag != "")
				{
					eRModularRoad.gameObject.tag = (eRModularRoad.tag = roadType.tag);
				}
				eRModularRoad.hasMeshCollider = roadType.hasMeshCollider;
				eRModularRoad.terrainDeformation = roadType.terrainDeformation;
			}
			else
			{
				Debug.LogError("EasyRoads3Dv3: the passed road type is null");
			}
			return road;
		}

		public ERRoad CreateRoad(string roadName, ERRoadType roadType, Vector3[] markers)
		{
			ERModularRoad eRModularRoad = InitRoad(roadName, roadType, null);
			eRModularRoad.road = new ERRoad(eRModularRoad);
			ERRoad road = eRModularRoad.road;
			if (roadType != null)
			{
				road.SetWidth(roadType.roadWidth);
				road.roadScript.roadShape = new List<Vector2>(roadType.roadShape);
				road.roadScript.doConnectionTri = new List<bool>(roadType.doConnectionTri);
				road.roadScript.roadShapeUVs = new List<float>(roadType.roadShapeUVs);
				road.roadScript.roadShapeUVs2 = new List<float>(roadType.roadShapeUVs2);
				road.roadScript.hardEdge = new List<bool>(roadType.hardEdge);
				road.SetMaterial(roadType.roadMaterial);
				road.IsSideObject(roadType.isSideObject);
				if (roadType.isSideObject)
				{
					road.roadScript.snapToTerrain = true;
				}
				road.SetSideObjects(roadType.soDataExt);
				eRModularRoad.gameObject.layer = (eRModularRoad.layer = roadType.layer);
				if (roadType.tag != "")
				{
					eRModularRoad.gameObject.tag = (eRModularRoad.tag = roadType.tag);
				}
				eRModularRoad.hasMeshCollider = roadType.hasMeshCollider;
				eRModularRoad.terrainDeformation = roadType.terrainDeformation;
				road.SetRoadType(roadType);
			}
			else
			{
				Debug.LogError("EasyRoads3Dv3: the passed road type is null");
			}
			AddInititialMarkers(road, markers);
			road.Refresh();
			return road;
		}

		public ERModularRoad InitRoad(string roadName, ERRoadType roadType, Material roadMaterial)
		{
			GameObject gameObject = (GameObject)Object.Instantiate(Resources.Load("ERProRoad"));
			if (roadName == "")
			{
				roadName = "road";
			}
			gameObject.name = roadName;
			gameObject.AddComponent<MeshFilter>();
			gameObject.AddComponent<MeshRenderer>();
			if (roadMaterial != null)
			{
				gameObject.GetComponent<MeshRenderer>().sharedMaterial = roadMaterial;
			}
			else
			{
				gameObject.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load("Materials/roads/road material") as Material;
			}
			gameObject.transform.position = Vector3.zero;
			gameObject.transform.parent = roadNetwork.roadObjectsParent;
			ERModularRoad component = gameObject.GetComponent<ERModularRoad>();
			component.roadMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
			component.roadMaterials = new List<Material>(gameObject.GetComponent<MeshRenderer>().sharedMaterials).ToArray();
			component.roadName = roadName;
			component.roadWidth = 6f;
			component.doSurroundingSurfaces = true;
			if (roadType != null)
			{
				component.roadShape = new List<Vector2>(roadType.roadShape);
				component.doConnectionTri = new List<bool>(roadType.doConnectionTri);
				component.roadShapeUVs = new List<float>(roadType.roadShapeUVs);
				component.roadShapeUVs2 = new List<float>(roadType.roadShapeUVs2);
				component.hardEdge = new List<bool>(roadType.hardEdge);
			}
			component.indent = roadNetwork.minIndent;
			component.surrounding = roadNetwork.minSurrounding;
			if (roadType != null)
			{
				component.gameObject.layer = (component.layer = roadType.layer);
				if (roadType.tag != "")
				{
					component.gameObject.tag = (component.tag = roadType.tag);
				}
				component.hasMeshCollider = roadType.hasMeshCollider;
				component.terrainDeformation = roadType.terrainDeformation;
			}
			return component;
		}

		public void AddInititialMarkers(ERRoad road, Vector3[] markers)
		{
			for (int i = 0; i < markers.Length; i++)
			{
				if (road.roadScript.snapToTerrain)
				{
					Vector3 pos = markers[i];
					road.roadScript.baseScript.OCCDCQCOQC(ref pos);
					markers[i] = pos;
				}
				road.AddInititialMarkers(markers[i]);
			}
		}

		public void AddIntersection(ERCrossingPrefabs crossing, GameObject crossingPrefab)
		{
		}

		public void BuildRoadNetwork(bool splatmaps, bool trees, bool detail, ERRoad[] roads)
		{
			roadNetwork.selectedObjects.Clear();
			foreach (ERRoad eRRoad in roads)
			{
				roadNetwork.selectedObjects.Add(SelectedObject.CreateInstance(eRRoad.roadScript, null, 0));
			}
			roadNetwork.selectedRoadsOnly = true;
			roadNetwork.doSplatmaps = splatmaps;
			roadNetwork.doTrees = trees;
			roadNetwork.doDetail = detail;
			DoBuildRoadNetwork();
			roadNetwork.selectedRoadsOnly = false;
			roadNetwork.selectedObjects.Clear();
		}

		public void BuildRoadNetwork(bool splatmaps, bool trees, bool detail)
		{
			roadNetwork.doSplatmaps = splatmaps;
			roadNetwork.doTrees = trees;
			roadNetwork.doDetail = detail;
			DoBuildRoadNetwork();
		}

		public void BuildRoadNetwork()
		{
			roadNetwork.doSplatmaps = false;
			roadNetwork.doTrees = false;
			roadNetwork.doDetail = false;
			DoBuildRoadNetwork();
		}

		public void DoBuildRoadNetwork()
		{
			List<Terrain> list = new List<Terrain>();
			Terrain[] terrainObjects = roadNetwork.terrainObjects;
			foreach (Terrain terrain in terrainObjects)
			{
				if (terrain != null && terrain.terrainData != null)
				{
					list.Add(terrain);
				}
			}
			roadNetwork.surfaceObjects.Clear();
			if (list.Count == 0)
			{
				Debug.Log("Currently no Unity terrain objects are present!");
				QDQDOOQQOOQDD.OQCOCOCOQO(roadNetwork, ref QDQDOOQQOOQDD.minx, ref QDQDOOQQOOQDD.minz, ref QDQDOOQQOOQDD.maxx, ref QDQDOOQQOOQDD.maxz, 0f);
			}
			else
			{
				isInBuildMode = true;
				roadNetwork.terrainDone = true;
				QDQDOOQQOOQDD.minx = (QDQDOOQQOOQDD.minz = 100000f);
				QDQDOOQQOOQDD.maxx = (QDQDOOQQOOQDD.maxz = -100000f);
				QDQDOOQQOOQDD.surfaceObjects.Clear();
				QDQDOOQQOOQDD.treeObjects.Clear();
				QDQDOOQQOOQDD.detailObjects.Clear();
				roadNetwork.soSplatmapObjects.Clear();
				QDQDOOQQOOQDD.OQCOCOCOQO(splatmapScale: (!(list[0].terrainData.size.x > list[0].terrainData.size.z)) ? (list[0].terrainData.size.z / (float)list[0].terrainData.alphamapResolution) : (list[0].terrainData.size.x / (float)list[0].terrainData.alphamapResolution), scr: roadNetwork, minx: ref QDQDOOQQOOQDD.minx, minz: ref QDQDOOQQOOQDD.minz, maxx: ref QDQDOOQQOOQDD.maxx, maxz: ref QDQDOOQQOOQDD.maxz);
				ERTerrain[] array = Object.FindObjectsOfType(typeof(ERTerrain)) as ERTerrain[];
				roadNetwork.surfaceObjects.AddRange(QDQDOOQQOOQDD.surfaceObjects);
				int num = 1;
				foreach (Terrain item in list)
				{
					ERTerrain component = item.gameObject.GetComponent<ERTerrain>();
					if (component != null)
					{
						QDQDOOQQOOQDD.ODOCOOOQDQ(roadNetwork, component, item, QDQDOOQQOOQDD.minx, QDQDOOQQOOQDD.maxx, QDQDOOQQOOQDD.minz, QDQDOOQQOOQDD.maxz);
					}
					else
					{
						Debug.LogWarning("ER terrain script missing on terrain object: " + item);
					}
					num++;
				}
			}
			foreach (GameObject surfaceObject in QDQDOOQQOOQDD.surfaceObjects)
			{
				if (surfaceObject != null)
				{
					surfaceObject.SetActive(value: false);
				}
			}
			foreach (GameObject treeObject in QDQDOOQQOOQDD.treeObjects)
			{
				if (treeObject != null)
				{
					Object.DestroyImmediate(treeObject);
				}
			}
			foreach (GameObject detailObject in QDQDOOQQOOQDD.detailObjects)
			{
				if (detailObject != null)
				{
					Object.DestroyImmediate(detailObject);
				}
			}
			foreach (GameObject soSplatmapObject in roadNetwork.soSplatmapObjects)
			{
				if (soSplatmapObject != null)
				{
					Object.DestroyImmediate(soSplatmapObject);
				}
			}
			roadNetwork.terrainDone = true;
			roadNetwork.baseVector = new Vector3(0f, roadNetwork.raise, 0f);
			Transform transform = roadNetwork.transform.Find("Connection Objects");
			if (transform != null)
			{
				transform.position = roadNetwork.baseVector;
			}
			transform = roadNetwork.transform.Find("Road Objects");
			if (transform != null)
			{
				transform.position = roadNetwork.baseVector;
			}
		}

		public void RestoreRoadNetwork()
		{
			roadNetwork.OOQQOOQODO(restoreTerrain: true);
			isInBuildMode = (roadNetwork.terrainDone = false);
		}

		public ERRoadType[] GetRoadTypes()
		{
			return roadNetwork.GetRoadTypes();
		}

		public ERRoadType GetRoadTypeByName(string name)
		{
			return roadNetwork.GetRoadTypeByName(name);
		}

		public ERRoadType AddRoadType()
		{
			return null;
		}

		public void HideWhiteSurfaces(bool flag)
		{
			roadNetwork.hideSurfaces = flag;
			roadNetwork.ODCQOCQDOD();
		}

		public ERConnection[] GetConnections()
		{
			List<ERConnection> list = new List<ERConnection>();
			ERCrossingPrefabs[] array = Object.FindObjectsOfType(typeof(ERCrossingPrefabs)) as ERCrossingPrefabs[];
			ERCrossingPrefabs[] array2 = array;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array2)
			{
				list.Add(ERConnection.Create(eRCrossingPrefabs.gameObject));
			}
			return list.ToArray();
		}

		public ERConnection GetConnectionByName(string name)
		{
			ERCrossingPrefabs[] array = Object.FindObjectsOfType(typeof(ERCrossingPrefabs)) as ERCrossingPrefabs[];
			ERCrossingPrefabs[] array2 = array;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array2)
			{
				if (eRCrossingPrefabs.gameObject.name == name)
				{
					return ERConnection.Create(eRCrossingPrefabs.gameObject);
				}
			}
			return null;
		}

		public ERConnection[] LoadConnections()
		{
			List<ERConnection> list = new List<ERConnection>();
			Object[] array = Resources.LoadAll("custom prefabs", typeof(GameObject));
			Object[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				GameObject gameObject = (GameObject)array2[i];
				if ((bool)gameObject.GetComponent<ERCrossingPrefabs>())
				{
					list.Add(ERConnection.Create(gameObject));
				}
			}
			array = Resources.LoadAll("dynamic prefabs", typeof(GameObject));
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				GameObject gameObject = (GameObject)array2[i];
				if ((bool)gameObject.GetComponent<ERCrossingPrefabs>())
				{
					list.Add(ERConnection.Create(gameObject));
				}
			}
			return list.ToArray();
		}

		public ERConnection GetSourceConnectionByName(string name)
		{
			Object[] array = Resources.LoadAll("custom prefabs", typeof(GameObject));
			ERConnection result = null;
			Object[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				GameObject gameObject = (GameObject)array2[i];
				if (gameObject.name == name && (bool)gameObject.GetComponent<ERCrossingPrefabs>())
				{
					return ERConnection.Create(gameObject);
				}
			}
			array = Resources.LoadAll("dynamic prefabs", typeof(GameObject));
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				GameObject gameObject = (GameObject)array2[i];
				if (gameObject.name == name && (bool)gameObject.GetComponent<ERCrossingPrefabs>())
				{
					return ERConnection.Create(gameObject);
				}
			}
			return result;
		}

		public ERConnection InstantiateConnection(ERConnection sourceConnection, string name, Vector3 position, Vector3 euler)
		{
			if (sourceConnection != null)
			{
				GameObject newPrefab = null;
				ERCrossingPrefabs prefabScript = null;
				ERCrossings crossingsScript = null;
				GameObject gameObject = roadNetwork.OQDCOCDDQD(sourceConnection.gameObject, position, ref newPrefab, ref prefabScript, ref crossingsScript);
				newPrefab.transform.position = position;
				newPrefab.transform.eulerAngles = euler;
				newPrefab.gameObject.name = name;
				for (int i = 0; i < prefabScript.crossingElements.Count; i++)
				{
					prefabScript.crossingElements[i].connectedRoad = null;
					prefabScript.crossingElements[i].connectedMarker = -1;
					prefabScript.crossingElements[i].connectedRoadGO = null;
				}
				return new ERConnection(newPrefab, name);
			}
			return null;
		}

		public void SetRaiseOffset(float value)
		{
			roadNetwork.raise = value;
			if (roadNetwork.terrainDone)
			{
				roadNetwork.baseVector = new Vector3(0f, roadNetwork.raise, 0f);
			}
			else
			{
				roadNetwork.baseVector = Vector3.zero;
			}
			if (roadNetwork.terrainDone)
			{
				Transform transform = roadNetwork.transform.Find("Connection Objects");
				if (transform != null)
				{
					transform.position = roadNetwork.baseVector;
				}
				transform = roadNetwork.transform.Find("Road Objects");
				if (transform != null)
				{
					transform.position = roadNetwork.baseVector;
				}
			}
		}

		public ERRoad OQODQCOCDD(ERRoad road)
		{
			ERModularRoad eRModularRoad = OQOOOODDDO.DuplicateObject(road.roadScript);
			eRModularRoad.road = new ERRoad(eRModularRoad);
			return eRModularRoad.road;
		}

		public float GetRaiseOffset()
		{
			return roadNetwork.raise;
		}

		public void ClampUVs(bool clamp)
		{
			roadNetwork.clampUVs = clamp;
		}

		public ERRoad ConnectRoads(ERRoad road1, ERRoad road2)
		{
			string message = "";
			if (CheckRoads(road1, road2, ref message))
			{
				Debug.LogError(message);
				return null;
			}
			float num = Vector3.Distance(road1.roadScript.markersExt[0].position, road2.roadScript.markersExt[0].position);
			float num2 = Vector3.Distance(road1.roadScript.markersExt[0].position, road2.roadScript.markersExt[road2.roadScript.markersExt.Count - 1].position);
			float num3 = Vector3.Distance(road1.roadScript.markersExt[road1.roadScript.markersExt.Count - 1].position, road2.roadScript.markersExt[0].position);
			float num4 = Vector3.Distance(road1.roadScript.markersExt[road1.roadScript.markersExt.Count - 1].position, road2.roadScript.markersExt[road2.roadScript.markersExt.Count - 1].position);
			int marker = 0;
			int marker2 = 0;
			if (num2 < num)
			{
				marker2 = road2.roadScript.markersExt.Count - 1;
				num = num2;
			}
			if (num3 < num)
			{
				marker = road1.roadScript.markersExt.Count - 1;
				marker2 = 0;
				num = num3;
			}
			if (num4 < num)
			{
				marker = road1.roadScript.markersExt.Count - 1;
				marker2 = road2.roadScript.markersExt.Count - 1;
				num = num3;
			}
			List<SelectedObject> objects = new List<SelectedObject>();
			objects.Add(SelectedObject.CreateInstance(road1.roadScript, null, marker));
			objects.Add(SelectedObject.CreateInstance(road2.roadScript, null, marker2));
			ERModularRoad road3 = null;
			int marker3 = 0;
			GameObject gameObject = ODQCQOODDO.JoinRoads(ref objects, ref road3, ref marker3);
			if (road3 == road1.roadScript)
			{
				road1.Refresh();
				if (road2.roadScript.gameObject != null)
				{
					Object.DestroyImmediate(road2.roadScript.gameObject);
				}
				return road1;
			}
			road2.Refresh();
			if (road1.roadScript.gameObject != null)
			{
				Object.DestroyImmediate(road1.roadScript.gameObject);
			}
			return road2;
		}

		public ERRoad ConnectRoads(ERRoad road1, int marker1, ERRoad road2, int marker2)
		{
			string message = "";
			if (CheckRoads(road1, road2, ref message))
			{
				Debug.LogError(message);
				return null;
			}
			if (marker1 > 0 && marker1 < road1.roadScript.markersExt.Count - 1)
			{
				marker1 = road1.roadScript.markersExt.Count - 1;
			}
			if (marker2 > 0 && marker2 < road2.roadScript.markersExt.Count - 1)
			{
				marker2 = road2.roadScript.markersExt.Count - 1;
			}
			List<SelectedObject> objects = new List<SelectedObject>();
			objects.Add(SelectedObject.CreateInstance(road1.roadScript, null, marker1));
			objects.Add(SelectedObject.CreateInstance(road2.roadScript, null, marker2));
			ERModularRoad road3 = null;
			int marker3 = 0;
			GameObject gameObject = ODQCQOODDO.JoinRoads(ref objects, ref road3, ref marker3);
			if (road3 == road1.roadScript)
			{
				road1.Refresh();
				if (road2.roadScript.gameObject != null)
				{
					Object.DestroyImmediate(road2.roadScript.gameObject);
				}
				return road1;
			}
			road2.Refresh();
			if (road1.roadScript.gameObject != null)
			{
				Object.DestroyImmediate(road1.roadScript.gameObject);
			}
			return road2;
		}

		private bool CheckRoads(ERRoad road1, ERRoad road2, ref string str)
		{
			if (road1.roadScript.closedTrack)
			{
				str = "EasyRoads3Dv3 Warning: Road 1 is a closed track";
				return true;
			}
			if (road2.roadScript.closedTrack)
			{
				str = "EasyRoads3Dv3 Warning: Road 2 is a closed track";
				return true;
			}
			if (road1.roadScript.roadType != road2.roadScript.roadType)
			{
				str = "EasyRoads3Dv3 Warning: Road 1 and Road 2 do not share the same road type";
				return true;
			}
			return false;
		}

		public static void SetTerrainNormals(Mesh m, GameObject go)
		{
			Vector3[] normals = go.GetComponent<MeshFilter>().sharedMesh.normals;
			ERModularRoad component = go.GetComponent<ERModularRoad>();
			for (int i = 0; i < normals.Length; i++)
			{
				ref Vector3 reference = ref normals[i];
				reference = component.baseScript.ODQQCDQCQO(m.vertices[i]);
			}
			m.normals = normals;
		}

		public void Refresh()
		{
			OCQCDQCQOQExt.ODDDQODDQQ(roadNetwork);
		}

		public void FinalizeObjects()
		{
			OCQCDQCQOQ.OODCCQCQCC(roadNetwork);
			Object.DestroyImmediate(roadNetwork);
		}
	}
}
