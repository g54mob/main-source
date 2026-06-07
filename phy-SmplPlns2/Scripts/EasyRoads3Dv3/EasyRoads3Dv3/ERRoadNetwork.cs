using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERRoadNetwork
	{
		public delegate void SideObjectUpdate(ERSideObjectInstance soInstance);

		public delegate void RoadUpdateCallback(ERRoad road);

		public delegate void BuildModeCallback();

		public delegate void EditModeCallback();

		public ERModularBase roadNetwork;

		public bool isInBuildMode = false;

		public string str = "EasyRoads3D Warning: The free version does not support API calls";

		public static List<ERSnapSideObjects> snapObjects = new List<ERSnapSideObjects>();

		public static List<ERSORoadUpdate> soRoadUpdate = new List<ERSORoadUpdate>();

		public static RoadUpdateCallback onRoadUpdate;

		public static BuildModeCallback onBuildModeEnter;

		public static EditModeCallback onEditModeEnter;

		public static SideObjectUpdate onSideObjectUpdate;

		public static void OnBuildModeEnter()
		{
			if (onBuildModeEnter != null)
			{
				onBuildModeEnter();
			}
		}

		public static void OnEditModeEnter()
		{
			if (onEditModeEnter != null)
			{
				onEditModeEnter();
			}
		}

		public static void OnRoadUpdated(ERRoad road)
		{
			if (onRoadUpdate != null)
			{
				onRoadUpdate(road);
			}
		}

		public static void OnSideObjectUpdated(ERSideObjectInstance soInstance)
		{
			if (onSideObjectUpdate != null)
			{
				onSideObjectUpdate(soInstance);
			}
		}

		public ERRoadNetwork(ERModularBase roadNetworkObject = null)
		{
			if (roadNetworkObject == null)
			{
				roadNetwork = UnityEngine.Object.FindObjectOfType(typeof(ERModularBase)) as ERModularBase;
			}
			else
			{
				roadNetwork = roadNetworkObject;
			}
			if (roadNetwork == null)
			{
				GameObject gameObject = Resources.Load("ERRoadNetwork") as GameObject;
				if (gameObject == null)
				{
					gameObject = Resources.Load("ER Road Network") as GameObject;
				}
				if (gameObject == null)
				{
					return;
				}
				gameObject = UnityEngine.Object.Instantiate(gameObject);
				roadNetwork = gameObject.GetComponent<ERModularBase>();
				gameObject.name = "Road Network";
				gameObject.transform.position = Vector3.zero;
				roadNetwork.RoadNetworkInit();
			}
			bool multTerrainResFlag = false;
			roadNetwork.ODCQDDDDDO(ref multTerrainResFlag);
			roadNetwork.OCDODCCOOD();
			if (!ERModularBase.AssembliesSet)
			{
				roadNetwork.OOCQCCDDDC();
			}
		}

		public string Version()
		{
			return ERModularBase.version;
		}

		public void GetTerrainData()
		{
			bool multTerrainResFlag = false;
			roadNetwork.ODCQDDDDDO(ref multTerrainResFlag);
		}

		public ERTrafficDirection GetTrafficDirection()
		{
			if (roadNetwork.rightHandDriving == 0)
			{
				return ERTrafficDirection.LHT;
			}
			return ERTrafficDirection.RHT;
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
			OQQOCDQCQDExt.OOODDOCDCD(roadNetwork);
		}

		public void Rotate(Vector3 origin, float angle, bool snap = false)
		{
			ERModularRoad[] componentsInChildren = roadNetwork.gameObject.GetComponentsInChildren<ERModularRoad>();
			ERModularRoad[] array = componentsInChildren;
			foreach (ERModularRoad eRModularRoad in array)
			{
				foreach (ERMarkerExt item in eRModularRoad.markersExt)
				{
					Vector3 pos = OQQOCDQCQD.OOQOCODQOO(item.position, origin, Quaternion.Euler(0f, angle, 0f));
					if (snap)
					{
						roadNetwork.OQCCDQOQOO(ref pos);
					}
					item.position = pos;
				}
			}
			ERCrossingPrefabs[] componentsInChildren2 = roadNetwork.gameObject.GetComponentsInChildren<ERCrossingPrefabs>();
			ERCrossingPrefabs[] array2 = componentsInChildren2;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array2)
			{
				Vector3 pos = OQQOCDQCQD.OOQOCODQOO(eRCrossingPrefabs.gameObject.transform.position, origin, Quaternion.Euler(0f, angle, 0f));
				if (snap)
				{
					roadNetwork.OQCCDQOQOO(ref pos);
				}
				eRCrossingPrefabs.gameObject.transform.position = pos;
				float num = eRCrossingPrefabs.gameObject.transform.eulerAngles.y + angle;
				if (num > 360f)
				{
					num -= Mathf.Floor(num / 360f);
				}
				eRCrossingPrefabs.gameObject.transform.eulerAngles = new Vector3(eRCrossingPrefabs.gameObject.transform.eulerAngles.x, num, eRCrossingPrefabs.gameObject.transform.eulerAngles.z);
			}
			OQQOCDQCQDExt.OOODDOCDCD(roadNetwork);
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
					if (meshFilter.transform.position.x == 0f && meshFilter.transform.position.z == 0f)
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
				eRModularRoad.centerPivotPointsFlag = true;
				if ((bool)eRModularRoad.GetComponent<LODGroup>())
				{
					eRModularRoad.GetComponent<LODGroup>().RecalculateBounds();
				}
				if (eRModularRoad.vgData.Count <= 0)
				{
					continue;
				}
				if (eRModularRoad.baseScript.upMethod == null)
				{
					eRModularRoad.baseScript.OOCQCCDDDC();
				}
				object[] array3 = null;
				if (eRModularRoad.vegetationStudioMaskLineActive)
				{
					array3 = new object[7]
					{
						eRModularRoad.gameObject,
						eRModularRoad.vgData.ToArray(),
						eRModularRoad.vegetationStudioGrassPerimeter,
						eRModularRoad.vegetationStudioPlantPerimeter,
						eRModularRoad.vegetationStudioTreePerimeter,
						eRModularRoad.vegetationStudioObjectPerimeter,
						eRModularRoad.vegetationStudioLargeObjectPerimeter
					};
				}
				else if (eRModularRoad.vegetationStudioBiomeMaskActive)
				{
					array3 = new object[5]
					{
						eRModularRoad.gameObject,
						eRModularRoad.vgData.ToArray(),
						eRModularRoad.vegetationStudioBiomeMaskDistance,
						eRModularRoad.vegetationStudioBiomeMaskBlendDistance,
						eRModularRoad.vegetationStudioBiomeMaskNoiseScale
					};
				}
				if (eRModularRoad.vegetationStudioMaskLineActive && array3 != null)
				{
					if (eRModularRoad.baseScript.upMethod != null)
					{
						eRModularRoad.baseScript.upMethod.Invoke(null, array3);
					}
				}
				else if (eRModularRoad.vegetationStudioBiomeMaskActive && array3 != null && eRModularRoad.baseScript.upBiomeMethod != null)
				{
					eRModularRoad.baseScript.upBiomeMethod.Invoke(null, array3);
				}
			}
		}

		[Obsolete("obsolete")]
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

		public ERRoad[] GetRoadObjects()
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
			ERRoad eRRoad = null;
			ERModularRoad[] array = componentsInChildren;
			foreach (ERModularRoad eRModularRoad in array)
			{
				if (eRModularRoad.name == name)
				{
					if (eRModularRoad.road == null)
					{
						eRModularRoad.road = new ERRoad(eRModularRoad);
					}
					eRRoad = eRModularRoad.road;
					if (eRRoad.gameObject == null)
					{
						eRRoad.gameObject = eRModularRoad.gameObject;
					}
					break;
				}
			}
			return eRRoad;
		}

		public ERRoad GetRoadByGameObject(GameObject go)
		{
			ERModularRoad component = go.GetComponent<ERModularRoad>();
			ERRoad eRRoad = null;
			if (component != null)
			{
				if (component.road == null)
				{
					component.road = new ERRoad(component);
				}
				eRRoad = component.road;
				if (eRRoad.gameObject == null)
				{
					eRRoad.gameObject = component.gameObject;
				}
			}
			return eRRoad;
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
			eRModularRoad.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
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
				road.roadScript.roadType = roadType.id;
				road.roadScript.roadShape = new List<Vector2>(roadType.roadShape);
				road.roadScript.doConnectionTri = new List<bool>(roadType.doConnectionTri);
				road.roadScript.roadShapeUVs = new List<float>(roadType.roadShapeUVs);
				road.roadScript.roadShapeUVs2 = new List<float>(roadType.roadShapeUVs2);
				road.roadScript.hardEdge = new List<bool>(roadType.hardEdge);
				road.roadScript.vertexColor = roadType.vertexColor;
				road.IsSideObject(roadType.isSideObject);
				if (roadType.isSideObject)
				{
					road.roadScript.snapToTerrain = true;
				}
				road.SetSideObjects(roadType.soDataExt, roadType.id);
				eRModularRoad.gameObject.layer = (eRModularRoad.layer = roadType.layer);
				if (!string.IsNullOrEmpty(roadType.tag))
				{
					eRModularRoad.gameObject.tag = (eRModularRoad.tag = roadType.tag);
				}
				eRModularRoad.hasMeshCollider = roadType.hasMeshCollider;
				eRModularRoad.terrainDeformation = roadType.terrainDeformation;
				road.SetRoadType(roadType);
			}
			else
			{
				Debug.LogError("EasyRoads3D: the passed road type is null");
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
				road.roadScript.roadType = roadType.id;
				road.roadScript.roadShape = new List<Vector2>(roadType.roadShape);
				road.roadScript.doConnectionTri = new List<bool>(roadType.doConnectionTri);
				road.roadScript.roadShapeUVs = new List<float>(roadType.roadShapeUVs);
				road.roadScript.roadShapeUVs2 = new List<float>(roadType.roadShapeUVs2);
				road.roadScript.hardEdge = new List<bool>(roadType.hardEdge);
				road.roadScript.vertexColor = roadType.vertexColor;
				road.SetMaterial(roadType.roadMaterial);
				road.IsSideObject(roadType.isSideObject);
				if (roadType.isSideObject)
				{
					road.roadScript.snapToTerrain = true;
				}
				road.SetSideObjects(roadType.soDataExt, roadType.id);
				eRModularRoad.gameObject.layer = (eRModularRoad.layer = roadType.layer);
				if (!string.IsNullOrEmpty(roadType.tag))
				{
					eRModularRoad.gameObject.tag = (eRModularRoad.tag = roadType.tag);
				}
				eRModularRoad.hasMeshCollider = roadType.hasMeshCollider;
				eRModularRoad.terrainDeformation = roadType.terrainDeformation;
				road.SetRoadType(roadType);
			}
			else
			{
				Debug.LogError("EasyRoads3D: the passed road type is null");
			}
			AddInititialMarkers(road, markers);
			road.Refresh();
			return road;
		}

		public ERRoad CreateRoad(string roadName, ERRoadType roadType, Vector3[] markers, ERMarkerControlType[] controlTypes)
		{
			ERModularRoad eRModularRoad = InitRoad(roadName, roadType, null);
			eRModularRoad.road = new ERRoad(eRModularRoad);
			ERRoad road = eRModularRoad.road;
			if (roadType != null)
			{
				road.SetWidth(roadType.roadWidth);
				road.roadScript.roadType = roadType.id;
				road.roadScript.roadShape = new List<Vector2>(roadType.roadShape);
				road.roadScript.doConnectionTri = new List<bool>(roadType.doConnectionTri);
				road.roadScript.roadShapeUVs = new List<float>(roadType.roadShapeUVs);
				road.roadScript.roadShapeUVs2 = new List<float>(roadType.roadShapeUVs2);
				road.roadScript.hardEdge = new List<bool>(roadType.hardEdge);
				road.roadScript.vertexColor = roadType.vertexColor;
				road.SetMaterial(roadType.roadMaterial);
				road.IsSideObject(roadType.isSideObject);
				if (roadType.isSideObject)
				{
					road.roadScript.snapToTerrain = true;
				}
				road.SetSideObjects(roadType.soDataExt, roadType.id);
				eRModularRoad.gameObject.layer = (eRModularRoad.layer = roadType.layer);
				if (!string.IsNullOrEmpty(roadType.tag))
				{
					eRModularRoad.gameObject.tag = (eRModularRoad.tag = roadType.tag);
				}
				eRModularRoad.hasMeshCollider = roadType.hasMeshCollider;
				eRModularRoad.terrainDeformation = roadType.terrainDeformation;
				road.SetRoadType(roadType);
			}
			else
			{
				Debug.LogError("EasyRoads3D: the passed road type is null");
			}
			AddInititialMarkers(road, markers);
			SetControlTypes(road, road.roadScript.markersExt.Count, controlTypes);
			road.Refresh();
			return road;
		}

		public ERModularRoad InitRoad(string roadName, ERRoadType roadType, Material roadMaterial)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("ERProRoad"));
			if (Application.isPlaying)
			{
				gameObject.isStatic = false;
			}
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
				component.roadType = roadType.id;
				component.roadShape = new List<Vector2>(roadType.roadShape);
				component.doConnectionTri = new List<bool>(roadType.doConnectionTri);
				component.roadShapeUVs = new List<float>(roadType.roadShapeUVs);
				component.roadShapeUVs2 = new List<float>(roadType.roadShapeUVs2);
				component.hardEdge = new List<bool>(roadType.hardEdge);
			}
			component.indent = roadNetwork.minIndent;
			component.surrounding = roadNetwork.minSurrounding;
			int num = -1;
			if (roadType != null)
			{
				component.gameObject.layer = (component.layer = roadType.layer);
				if (!string.IsNullOrEmpty(roadType.tag))
				{
					component.gameObject.tag = (component.tag = roadType.tag);
				}
				component.hasMeshCollider = roadType.hasMeshCollider;
				component.terrainDeformation = roadType.terrainDeformation;
				for (int i = 0; i < roadNetwork.roadTypes.Count; i++)
				{
					if (roadNetwork.roadTypes[i].id == roadType.id)
					{
						num = i + 1;
						break;
					}
				}
			}
			if (num != -1)
			{
				QDQDOOQQDQODD.AssignSideObjects(roadNetwork, num, component);
			}
			else
			{
				OCQODDCQDD.OCODCOOQOC(roadNetwork.QOQDQOOQDDQOOQ, ref component.soDataExt);
			}
			return component;
		}

		public void AddInititialMarkers(ERRoad road, Vector3[] markers)
		{
			if (markers == null)
			{
				Debug.LogError("EasyRoads3D: the passed array of marker positions is null");
				return;
			}
			for (int i = 0; i < markers.Length; i++)
			{
				if (road.roadScript.snapToTerrain)
				{
					Vector3 pos = markers[i];
					road.roadScript.baseScript.OQCCDQOQOO(ref pos);
					markers[i] = pos;
				}
				road.AddInititialMarkers(markers[i]);
			}
		}

		public void SynchSideObjects(bool value)
		{
			roadNetwork.synchSideObjects = value;
		}

		public void SetControlTypes(ERRoad road, int length, ERMarkerControlType[] controlTypes)
		{
			for (int i = 0; i < length; i++)
			{
				if (controlTypes.Length > i)
				{
					road.roadScript.markersExt[i].SetControlType(controlTypes[i]);
				}
			}
		}

		public void SetTerrainRaycastDistance(float value)
		{
			roadNetwork.terrainRaycastHeight = value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddIntersection(ERCrossingPrefabs crossing, GameObject crossingPrefab)
		{
		}

		public void ClearSideObjectsQueue()
		{
			roadNetwork.ClearSideObjectsQueue();
		}

		public void UpdateSideObjects()
		{
			roadNetwork.UpdateSideObjectsInScene();
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
			roadNetwork.doHeightmap = true;
			DoBuildRoadNetwork();
			roadNetwork.selectedRoadsOnly = false;
			roadNetwork.selectedObjects.Clear();
		}

		public void BuildRoadNetwork(bool splatmaps, bool trees, bool detail, bool heightmap = true, Terrain targetTerrain = null)
		{
			roadNetwork.selectedRoadsOnly = false;
			roadNetwork.doSplatmaps = splatmaps;
			roadNetwork.doTrees = trees;
			roadNetwork.doDetail = detail;
			roadNetwork.doHeightmap = heightmap;
			DoBuildRoadNetwork(targetTerrain);
		}

		public void BuildRoadNetwork()
		{
			roadNetwork.selectedRoadsOnly = false;
			roadNetwork.doSplatmaps = false;
			roadNetwork.doTrees = false;
			roadNetwork.doDetail = false;
			roadNetwork.doHeightmap = true;
			DoBuildRoadNetwork();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DoBuildRoadNetwork(Terrain targetTerrain = null)
		{
			List<Terrain> list = new List<Terrain>();
			Terrain[] terrainObjects = roadNetwork.terrainObjects;
			foreach (Terrain terrain in terrainObjects)
			{
				if (terrain != null && (targetTerrain == null || terrain == targetTerrain) && terrain.terrainData != null)
				{
					list.Add(terrain);
				}
			}
			roadNetwork.surfaceObjects.Clear();
			roadNetwork.newSplatMapRestoreCode = true;
			if (list.Count == 0)
			{
				Debug.Log("EasyRoads3D: Currently no Unity terrain objects are present!");
				QDQDOOQQOOQDD.ODDOODDCDC(roadNetwork, ref QDQDOOQQOOQDD.minx, ref QDQDOOQQOOQDD.minz, ref QDQDOOQQOOQDD.maxx, ref QDQDOOQQOOQDD.maxz, 0f);
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
				QDQDOOQQOOQDD.ODDOODDCDC(splatmapScale: (!(list[0].terrainData.size.x > list[0].terrainData.size.z)) ? (list[0].terrainData.size.z / (float)list[0].terrainData.alphamapResolution) : (list[0].terrainData.size.x / (float)list[0].terrainData.alphamapResolution), scr: roadNetwork, minx: ref QDQDOOQQOOQDD.minx, minz: ref QDQDOOQQOOQDD.minz, maxx: ref QDQDOOQQOOQDD.maxx, maxz: ref QDQDOOQQOOQDD.maxz);
				ERTerrain[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERTerrain)) as ERTerrain[];
				roadNetwork.surfaceObjects.AddRange(QDQDOOQQOOQDD.surfaceObjects);
				int num = 1;
				foreach (Terrain item in list)
				{
					ERTerrain component = item.gameObject.GetComponent<ERTerrain>();
					if (component != null)
					{
						QDQDOOQQOOQDD.ODOQCCCQDD(roadNetwork, component, item, QDQDOOQQOOQDD.minx, QDQDOOQQOOQDD.maxx, QDQDOOQQOOQDD.minz, QDQDOOQQOOQDD.maxz);
					}
					else
					{
						Debug.LogWarning("EasyRoads3D: ER terrain script missing on terrain object: " + item);
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
					UnityEngine.Object.DestroyImmediate(treeObject);
				}
			}
			foreach (GameObject detailObject in QDQDOOQQOOQDD.detailObjects)
			{
				if (detailObject != null)
				{
					UnityEngine.Object.DestroyImmediate(detailObject);
				}
			}
			foreach (GameObject soSplatmapObject in roadNetwork.soSplatmapObjects)
			{
				if (soSplatmapObject != null)
				{
					UnityEngine.Object.DestroyImmediate(soSplatmapObject);
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
			roadNetwork.OQCCDDOCQC();
		}

		public void SmoothenSurroundingFalloff(ERModularRoad roadObject = null, Terrain terrain = null)
		{
			if (terrain != null)
			{
				if (roadObject != null)
				{
					OQQOCDQCQD.TerrainSmooth(terrain, roadObject, roadNetwork.terrainSmoothSurroundingDistance, 1, ref roadNetwork.surroundingSmoothStep);
				}
				return;
			}
			ERModularRoad[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
			Terrain[] terrainObjects = roadNetwork.terrainObjects;
			foreach (Terrain terrain2 in terrainObjects)
			{
				if (!(terrain2 != null))
				{
					continue;
				}
				ERModularRoad[] array2 = array;
				foreach (ERModularRoad eRModularRoad in array2)
				{
					if (eRModularRoad.terrainDeformation && !eRModularRoad.isSideObject)
					{
						OQQOCDQCQD.TerrainSmooth(terrain2, eRModularRoad, roadNetwork.terrainSmoothSurroundingDistance, 1, ref roadNetwork.surroundingSmoothStep);
					}
				}
			}
		}

		public void RestoreRoadNetwork()
		{
			if (isInBuildMode)
			{
				roadNetwork.ODOCCDODCQ(restoreTerrain: true);
				isInBuildMode = (roadNetwork.terrainDone = false);
			}
		}

		public ERRoadType[] GetRoadTypes()
		{
			return roadNetwork.GetRoadTypes();
		}

		public ERRoadType GetRoadTypeByName(string name)
		{
			return roadNetwork.GetRoadTypeByName(name);
		}

		public SideObject GetSideObjectByName(string name)
		{
			return roadNetwork.ODQDQODQCD(name);
		}

		public SideObject[] GetSideObjects()
		{
			return roadNetwork.QOQDQOOQDDQOOQ.ToArray();
		}

		public bool SideObjectIsDualSided(SideObject obj)
		{
			return roadNetwork.SideObjectIsDualSided(obj);
		}

		public ERSideWalk GetSidewalkByName(string name)
		{
			return roadNetwork.OOCCDQDQDO(name);
		}

		public ERRoadType AddRoadType()
		{
			return null;
		}

		public void HideWhiteSurfaces(bool flag)
		{
			roadNetwork.hideSurfaces = flag;
			roadNetwork.OOCOOCQOQO();
		}

		public ERConnection[] GetConnections()
		{
			List<ERConnection> list = new List<ERConnection>();
			ERCrossingPrefabs[] componentsInChildren = roadNetwork.gameObject.GetComponentsInChildren<ERCrossingPrefabs>();
			ERCrossingPrefabs[] array = componentsInChildren;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array)
			{
				list.Add(ERConnection.Create(eRCrossingPrefabs.gameObject));
			}
			return list.ToArray();
		}

		public ERConnection GetConnectionByGameObject(GameObject _gameObject)
		{
			ERCrossingPrefabs[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERCrossingPrefabs)) as ERCrossingPrefabs[];
			ERCrossingPrefabs[] array2 = array;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array2)
			{
				if (eRCrossingPrefabs.gameObject == _gameObject)
				{
					return ERConnection.Create(eRCrossingPrefabs.gameObject);
				}
			}
			return null;
		}

		public ERConnection GetConnectionByName(string name)
		{
			ERCrossingPrefabs[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERCrossingPrefabs)) as ERCrossingPrefabs[];
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
			UnityEngine.Object[] array = Resources.LoadAll("custom prefabs", typeof(GameObject));
			UnityEngine.Object[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				GameObject gameObject = (GameObject)array2[i];
				if ((bool)gameObject.GetComponent<ERCrossingPrefabs>())
				{
					list.Add(ERConnection.Create(gameObject));
				}
			}
			array = Resources.LoadAll("dynamic prefabs", typeof(GameObject));
			UnityEngine.Object[] array3 = array;
			for (int j = 0; j < array3.Length; j++)
			{
				GameObject gameObject2 = (GameObject)array3[j];
				if ((bool)gameObject2.GetComponent<ERCrossingPrefabs>())
				{
					list.Add(ERConnection.Create(gameObject2));
				}
			}
			return list.ToArray();
		}

		[Obsolete("obsolete")]
		public ERConnection GetSourceConnectionByName(string name)
		{
			UnityEngine.Object[] array = Resources.LoadAll("custom prefabs", typeof(GameObject));
			ERConnection result = null;
			UnityEngine.Object[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				GameObject gameObject = (GameObject)array2[i];
				if (gameObject.name == name && (bool)gameObject.GetComponent<ERCrossingPrefabs>())
				{
					return ERConnection.Create(gameObject);
				}
			}
			array = Resources.LoadAll("dynamic prefabs", typeof(GameObject));
			UnityEngine.Object[] array3 = array;
			for (int j = 0; j < array3.Length; j++)
			{
				GameObject gameObject2 = (GameObject)array3[j];
				if (gameObject2.name == name && (bool)gameObject2.GetComponent<ERCrossingPrefabs>())
				{
					return ERConnection.Create(gameObject2);
				}
			}
			return result;
		}

		public ERConnection GetConnectionPrefabByName(string name)
		{
			UnityEngine.Object[] array = Resources.LoadAll("custom prefabs", typeof(GameObject));
			ERConnection result = null;
			UnityEngine.Object[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				GameObject gameObject = (GameObject)array2[i];
				if (gameObject.name == name && (bool)gameObject.GetComponent<ERCrossingPrefabs>())
				{
					return ERConnection.Create(gameObject);
				}
			}
			array = Resources.LoadAll("dynamic prefabs", typeof(GameObject));
			UnityEngine.Object[] array3 = array;
			for (int j = 0; j < array3.Length; j++)
			{
				GameObject gameObject2 = (GameObject)array3[j];
				if (gameObject2.name == name && (bool)gameObject2.GetComponent<ERCrossingPrefabs>())
				{
					return ERConnection.Create(gameObject2);
				}
			}
			return result;
		}

		public ERConnection InstantiateConnection(ERConnection OQCQQDQOCD, string name, Vector3 position, Vector3 euler)
		{
			if (OQCQQDQOCD != null)
			{
				GameObject newPrefab = null;
				ERCrossingPrefabs prefabScript = null;
				ERCrossings crossingsScript = null;
				GameObject gameObject = roadNetwork.OOQDOCCDCC(OQCQQDQOCD.gameObject, position, ref newPrefab, ref prefabScript, ref crossingsScript);
				newPrefab.transform.position = position;
				newPrefab.transform.eulerAngles = euler;
				newPrefab.gameObject.name = name;
				if (prefabScript.crossingsScript != null)
				{
					prefabScript.crossingsScript.isSceneObject = true;
					if (!prefabScript.isERCrossingExt)
					{
					}
				}
				else if ((bool)gameObject.GetComponent<ERRoundabouts>())
				{
					gameObject.GetComponent<ERRoundabouts>().isSceneObject = true;
				}
				else if (gameObject.GetComponent<ERCrossingPrefabs>().isCustomPrefab)
				{
					gameObject.GetComponent<ERCrossingPrefabs>().isSceneObject = true;
				}
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateTerrainInfo()
		{
			bool multTerrainResFlag = false;
			roadNetwork.ODCQDDDDDO(ref multTerrainResFlag);
		}

		public ERRoadNetworkStatus GetRoadNetworkStatus()
		{
			if (roadNetwork.terrainDone)
			{
				return ERRoadNetworkStatus.BuildMode;
			}
			return ERRoadNetworkStatus.EditMode;
		}

		public ERRoad ODCCOOCCCO(ERRoad road)
		{
			ERModularRoad eRModularRoad = OODCDDQOQC.DuplicateObject(road.roadScript);
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
			if (road1 == null)
			{
				Debug.LogError("EasyRoads3D: NullReferenceException, road1 is not set to an instance of ERRoad");
				return null;
			}
			if (road2 == null)
			{
				Debug.LogError("EasyRoads3D: NullReferenceException, road2 is not set to an instance of ERRoad");
				return null;
			}
			string vssss = "";
			if (ussst(road1, road2, ref vssss))
			{
				Debug.LogError(vssss);
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
			GameObject gameObject = OQOCQDQODD.JoinRoads(ref objects, ref road3, ref marker3);
			if (road3 == road1.roadScript)
			{
				road1.Refresh();
				if (road2.roadScript.gameObject != null)
				{
					UnityEngine.Object.DestroyImmediate(road2.roadScript.gameObject);
				}
				if (!road1.IsClosedTrack())
				{
					road1.roadScript.markersExt[road1.roadScript.markersExt.Count - 1].totalDistance = 0f;
				}
				return road1;
			}
			road2.Refresh();
			if (road1.roadScript.gameObject != null)
			{
				UnityEngine.Object.DestroyImmediate(road1.roadScript.gameObject);
			}
			if (!road2.IsClosedTrack())
			{
				road2.roadScript.markersExt[road2.roadScript.markersExt.Count - 1].totalDistance = 0f;
			}
			return road2;
		}

		public ERRoad ConnectRoads(ERRoad road1, int marker1, ERRoad road2, int marker2)
		{
			string vssss = "";
			if (ussst(road1, road2, ref vssss))
			{
				Debug.LogError(vssss);
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
			GameObject gameObject = OQOCQDQODD.JoinRoads(ref objects, ref road3, ref marker3);
			if (road3 == road1.roadScript)
			{
				road1.Refresh();
				if (road2.roadScript.gameObject != null)
				{
					UnityEngine.Object.DestroyImmediate(road2.roadScript.gameObject);
				}
				if (!road1.IsClosedTrack())
				{
					road1.roadScript.markersExt[road1.roadScript.markersExt.Count - 1].totalDistance = 0f;
				}
				return road1;
			}
			road2.Refresh();
			if (road1.roadScript.gameObject != null)
			{
				UnityEngine.Object.DestroyImmediate(road1.roadScript.gameObject);
			}
			if (!road2.IsClosedTrack())
			{
				road2.roadScript.markersExt[road2.roadScript.markersExt.Count - 1].totalDistance = 0f;
			}
			return road2;
		}

		public ERConnection InsertFlexConnector(ERRoad road1, ERRoad road2, ERRoad road3)
		{
			return InsertFlexConnector(road1, road2, road3, Vector3.zero);
		}

		public ERConnection InsertFlexConnector(ERRoad road1, ERRoad road2, ERRoad road3, Vector3 connectionPosition)
		{
			if (road1 == null || road1.roadScript == null || road1.roadScript.roadType == 0.0)
			{
				Debug.LogError("EasyRoads3D: valid road objects and road types for the involved road objects are required for Flex Connectors. Please verify this for road1");
				return null;
			}
			if (road2 == null || road2.roadScript == null || road2.roadScript.roadType == 0.0)
			{
				Debug.LogError("EasyRoads3D: valid road objects and road types for the involved road objects are required for Flex Connectors. Please verify this for road2");
				return null;
			}
			if (road3 == null || road3.roadScript == null || road3.roadScript.roadType == 0.0)
			{
				Debug.LogError("EasyRoads3D: valid road objects and road types for the involved road objects are required for Flex Connectors. Please verify this for road2");
				return null;
			}
			if (road1.roadScript.roadType != road2.roadScript.roadType && road2.roadScript.roadType != road3.roadScript.roadType && road2.roadScript.roadType != road3.roadScript.roadType)
			{
				Debug.LogError("EasyRoads3D: At least two of the three road objects must be based on the same road type");
				return null;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			float num4 = Vector3.Distance(road1.roadScript.markersExt[0].position, road2.roadScript.markersExt[0].position);
			float num5 = Vector3.Distance(road1.roadScript.markersExt[0].position, road2.roadScript.markersExt[road2.roadScript.markersExt.Count - 1].position);
			float num6 = Vector3.Distance(road1.roadScript.markersExt[road1.roadScript.markersExt.Count - 1].position, road2.roadScript.markersExt[0].position);
			float num7 = Vector3.Distance(road1.roadScript.markersExt[road1.roadScript.markersExt.Count - 1].position, road2.roadScript.markersExt[road2.roadScript.markersExt.Count - 1].position);
			if (road1.roadScript.startPrefabScript == null && num4 < num5)
			{
				if (num4 < num6)
				{
					if (num4 < num7)
					{
						num = 0;
						num2 = 0;
					}
					else
					{
						num = 1;
						num2 = 1;
					}
				}
				else if (num6 < num7)
				{
					num = 1;
					num2 = 0;
				}
				else
				{
					num = 1;
					num2 = 1;
				}
			}
			else if (num5 < num6)
			{
				if (num5 < num7)
				{
					num = 0;
					num2 = 1;
				}
				else
				{
					num = 1;
					num2 = 1;
				}
			}
			else if (num6 < num7)
			{
				num = 1;
				num2 = 0;
			}
			else
			{
				num = 1;
				num2 = 1;
			}
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 zero3 = Vector3.zero;
			Vector3 zero4 = Vector3.zero;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			if (num == 0)
			{
				float num8 = Vector3.Distance(road1.roadScript.markersExt[0].position, road3.roadScript.markersExt[0].position);
				float num9 = Vector3.Distance(road1.roadScript.markersExt[0].position, road3.roadScript.markersExt[road3.roadScript.markersExt.Count - 1].position);
				zero = road1.roadScript.soSplinePoints[0];
				zero2 = road1.roadScript.soSplinePoints[1];
				num3 = ((!(num8 < num9)) ? 1 : 0);
			}
			else
			{
				float num10 = Vector3.Distance(road1.roadScript.markersExt[road1.roadScript.markersExt.Count - 1].position, road3.roadScript.markersExt[0].position);
				float num11 = Vector3.Distance(road1.roadScript.markersExt[road1.roadScript.markersExt.Count - 1].position, road3.roadScript.markersExt[road3.roadScript.markersExt.Count - 1].position);
				zero = road1.roadScript.soSplinePoints[road1.roadScript.soSplinePoints.Count - 1];
				zero2 = road1.roadScript.soSplinePoints[road1.roadScript.soSplinePoints.Count - 2];
				if (num10 < num11)
				{
					num3 = 0;
					vector = road3.roadScript.soSplinePoints[0];
					vector2 = road3.roadScript.soSplinePoints[1];
				}
				else
				{
					num3 = 1;
					vector = road3.roadScript.soSplinePoints[road3.roadScript.soSplinePoints.Count - 1];
					vector2 = road3.roadScript.soSplinePoints[road3.roadScript.soSplinePoints.Count - 2];
				}
			}
			if (num2 == 0)
			{
				zero3 = road2.roadScript.soSplinePoints[0];
				zero4 = road1.roadScript.soSplinePoints[1];
			}
			else
			{
				zero3 = road2.roadScript.soSplinePoints[road2.roadScript.soSplinePoints.Count - 1];
				zero4 = road2.roadScript.soSplinePoints[road2.roadScript.soSplinePoints.Count - 2];
			}
			if (num == 0 && road1.roadScript.startPrefabScript != null)
			{
				Debug.LogError("EasyRoads3D: the nearest marker is a the start of road 1 which is already attached to a connection");
				return null;
			}
			if (num == 1 && road1.roadScript.endPrefabScript != null)
			{
				Debug.LogError("EasyRoads3D: the nearest marker is a the end of road 1 which is already attached to a connection");
				return null;
			}
			if (num2 == 0 && road2.roadScript.startPrefabScript != null)
			{
				Debug.LogError("EasyRoads3D: the nearest marker is a the start of road 2 which is already attached to a connection");
				return null;
			}
			if (num2 == 1 && road2.roadScript.endPrefabScript != null)
			{
				Debug.LogError("EasyRoads3D: the nearest marker is a the end of road 2 which is already attached to a connection");
				return null;
			}
			if (num3 == 0 && road3.roadScript.startPrefabScript != null)
			{
				Debug.LogError("EasyRoads3D: the nearest marker is a the start of road 3 which is already attached to a connection");
				return null;
			}
			if (num3 == 1 && road3.roadScript.endPrefabScript != null)
			{
				Debug.LogError("EasyRoads3D: the nearest marker is a the end of road 3 which is already attached to a connection");
				return null;
			}
			Vector3 normalized = (zero - zero2).normalized;
			Vector3 normalized2 = (zero3 - zero4).normalized;
			Vector3 normalized3 = (vector - vector2).normalized;
			float num12 = Vector3.Angle(normalized, normalized2);
			if (num12 < ERModularBase.minSnapAngle || num12 > ERModularBase.maxSnapAngle)
			{
				Debug.LogError("EasyRoads3D: the angle between road object 1 and road object 2 is too sharp");
				return null;
			}
			num12 = Vector3.Angle(normalized, normalized3);
			if (num12 < ERModularBase.minSnapAngle || num12 > ERModularBase.maxSnapAngle)
			{
				Debug.LogError("EasyRoads3D: the angle between road object 1 and road object 3 is too sharp");
				return null;
			}
			num12 = Vector3.Angle(normalized2, normalized3);
			if (num12 < ERModularBase.minSnapAngle || num12 > ERModularBase.maxSnapAngle)
			{
				Debug.LogError("EasyRoads3D: the angle between road object 2 and road object 3 is too sharp");
				return null;
			}
			Vector3 position = Vector3.zero;
			Vector3 position2;
			if (num == 0)
			{
				position += road1.roadScript.markersExt[0].position;
				position2 = road1.roadScript.markersExt[0].position;
			}
			else
			{
				position += road1.roadScript.markersExt[road1.roadScript.markersExt.Count - 1].position;
				position2 = road1.roadScript.markersExt[road1.roadScript.markersExt.Count - 1].position;
			}
			Vector3 position3;
			if (num2 == 0)
			{
				position += road2.roadScript.markersExt[0].position;
				position3 = road1.roadScript.markersExt[0].position;
			}
			else
			{
				position += road2.roadScript.markersExt[road2.roadScript.markersExt.Count - 1].position;
				position3 = road2.roadScript.markersExt[road2.roadScript.markersExt.Count - 1].position;
			}
			Vector3 position4;
			if (num3 == 0)
			{
				position += road3.roadScript.markersExt[0].position;
				position4 = road1.roadScript.markersExt[0].position;
			}
			else
			{
				position += road3.roadScript.markersExt[road3.roadScript.markersExt.Count - 1].position;
				position4 = road3.roadScript.markersExt[road3.roadScript.markersExt.Count - 1].position;
			}
			position /= 3f;
			if (connectionPosition != Vector3.zero)
			{
				position = connectionPosition;
			}
			if (position2 == position3 || position2 == position4 || position3 == position4)
			{
				position.x += 0.01f;
			}
			int num13 = 0;
			GameObject gameObject = new GameObject(ERCrossingPrefabs.SetFlexConnectorName(roadNetwork));
			gameObject.transform.position = position;
			ERConnectionParent eRConnectionParent = (ERConnectionParent)UnityEngine.Object.FindObjectOfType(typeof(ERConnectionParent));
			if (eRConnectionParent != null)
			{
				gameObject.transform.parent = eRConnectionParent.transform;
			}
			ERCrossingPrefabs eRCrossingPrefabs = gameObject.AddComponent<ERCrossingPrefabs>();
			eRCrossingPrefabs.isFlexConnector = true;
			eRCrossingPrefabs.baseScript = roadNetwork;
			eRCrossingPrefabs.crossingsScript = gameObject.AddComponent<ERCrossings>();
			eRCrossingPrefabs.crossingsScript.prefabScript = eRCrossingPrefabs;
			eRCrossingPrefabs.crossingsScript.baseScript = roadNetwork;
			Vector3 zero5 = Vector3.zero;
			Vector3 zero6 = Vector3.zero;
			QDOODOQQDQODD qDOODOQQDQODD = new QDOODOQQDQODD();
			qDOODOQQDQODD.roadType = road1.roadScript.roadType;
			eRCrossingPrefabs.crossingElements.Add(qDOODOQQDQODD);
			qDOODOQQDQODD.connectedRoad = road1.roadScript;
			if (num == 0)
			{
				road1.roadScript.startPrefabScript = eRCrossingPrefabs;
				road1.roadScript.startConnectionSegment = 0;
			}
			else
			{
				road1.roadScript.endPrefabScript = eRCrossingPrefabs;
				road1.roadScript.endConnectionSegment = 0;
			}
			qDOODOQQDQODD = new QDOODOQQDQODD();
			qDOODOQQDQODD.roadType = road2.roadScript.roadType;
			eRCrossingPrefabs.crossingElements.Add(qDOODOQQDQODD);
			qDOODOQQDQODD.connectedRoad = road2.roadScript;
			if (num2 == 0)
			{
				road2.roadScript.startPrefabScript = eRCrossingPrefabs;
				road2.roadScript.startConnectionSegment = 1;
			}
			else
			{
				road2.roadScript.endPrefabScript = eRCrossingPrefabs;
				road2.roadScript.endConnectionSegment = 1;
			}
			qDOODOQQDQODD = new QDOODOQQDQODD();
			qDOODOQQDQODD.roadType = road3.roadScript.roadType;
			eRCrossingPrefabs.crossingElements.Add(qDOODOQQDQODD);
			qDOODOQQDQODD.connectedRoad = road3.roadScript;
			if (num3 == 0)
			{
				road3.roadScript.startPrefabScript = eRCrossingPrefabs;
				road3.roadScript.startConnectionSegment = 2;
			}
			else
			{
				road3.roadScript.endPrefabScript = eRCrossingPrefabs;
				road3.roadScript.endConnectionSegment = 2;
			}
			ERSideWalkVecs.OCQCQODCOO(road2.roadScript, road2.roadScript, road1.roadScript, eRCrossingPrefabs, zero5, zero6);
			eRCrossingPrefabs.InitFlexConnector(updateRoadTypes: true);
			roadNetwork.UpdateQueue();
			road1.roadScript.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
			road2.roadScript.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
			road3.roadScript.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
			eRCrossingPrefabs.crossingsScript.updateQueue = 0;
			eRCrossingPrefabs.crossingsScript.OCOQDOOOQC(null);
			eRCrossingPrefabs.baseScript.UpdateSideObjectsInScene();
			return new ERConnection(eRCrossingPrefabs.gameObject, eRCrossingPrefabs.gameObject.name);
		}

		private bool ussst(ERRoad tssss, ERRoad ussss, ref string vssss)
		{
			if (tssss.roadScript.closedTrack)
			{
				vssss = "EasyRoads3D Warning: Road 1 is a closed track";
				return true;
			}
			if (ussss.roadScript.closedTrack)
			{
				vssss = "EasyRoads3D Warning: Road 2 is a closed track";
				return true;
			}
			if (tssss.roadScript.roadType != 0.0 && tssss.roadScript.roadType != ussss.roadScript.roadType)
			{
				vssss = "EasyRoads3D Warning: Road 1 and Road 2 do not share the same road type";
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
				normals[i] = component.baseScript.OOQDDODCDO(m.vertices[i]);
			}
			m.normals = normals;
		}

		public void Refresh()
		{
			OQQOCDQCQDExt.OOODDOCDCD(roadNetwork);
		}

		public void FinalizeObjects()
		{
			OQQOCDQCQD.ODQCOCCODD(roadNetwork);
			UnityEngine.Object.DestroyImmediate(roadNetwork);
		}

		public void ReadOSMData(XmlDocument osmDoc, bool createIntersections = false)
		{
			if (createIntersections)
			{
				Debug.Log("EasyRoads3D: Creating intersections is experimental and not fully implemented");
			}
			OQQOCDQCQDExt.GenerateOSMDataObf(osmDoc, this, createIntersections, insertFlexConnectors: false);
		}

		public void ReadOSMData(XmlDocument osmDoc, bool createIntersections, bool insertFlexConnectors, float bridgeHeightOffset = 0f)
		{
			if (createIntersections)
			{
				Debug.Log("EasyRoads3D: Creating intersections is experimental and not fully implemented");
			}
			OQQOCDQCQDExt.GenerateOSMDataObf(osmDoc, this, createIntersections, insertFlexConnectors, setERRoad: true, bridgeHeightOffset);
		}

		public void ReadOSMMetaData(XmlDocument osmDoc, out EROSMData osmData)
		{
			OQQOCDQCQDExt.GenerateOSMDataObf(osmDoc, this, out osmData);
		}

		public void SetOSMRoadType(string osmRoadType, ERRoadType erRoadType)
		{
			OQQOCDQCQDExt.OODQQQQQQC(osmRoadType, erRoadType.id, roadNetwork);
		}

		public void SetOSMTerrainCoordinates(double top, double bottom, double left, double right)
		{
			roadNetwork.osmTerrainTopLon = top;
			roadNetwork.osmTerrainBottomLon = bottom;
			roadNetwork.osmTerrainLeftLat = left;
			roadNetwork.osmTerrainRightLat = right;
		}

		public GameObject[] GetAvailableRoadMarkerHandles()
		{
			return roadNetwork.FindAvailableRoadMarkerHandles();
		}

		public GameObject[] GetAvailableConnectionHandles()
		{
			return roadNetwork.OCODOCQDCO();
		}
	}
}
