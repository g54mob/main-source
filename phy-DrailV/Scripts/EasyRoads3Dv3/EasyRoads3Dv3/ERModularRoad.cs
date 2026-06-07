using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERModularRoad : MonoBehaviour
	{
		public ERModularBase baseScript;

		public string roadName;

		public bool locked = false;

		public double roadType = 0.0;

		public bool isCustomRoadSet = false;

		public bool isCustomRoad = false;

		public List<ERMarker> markers = new List<ERMarker>();

		public List<ERMarker> tmpMarkers = new List<ERMarker>();

		public List<ERMarkerExt> markersExt = new List<ERMarkerExt>();

		public List<ERMarkerExt> tmpMarkersExt = new List<ERMarkerExt>();

		public List<float> tValues = new List<float>();

		public float roadWidth = 5f;

		public float faceDistance = 2f;

		public float angleTreshold = 45f;

		public bool closedTrack = false;

		public float minNodeDistance = 5f;

		public int nodeWithinRange = -1;

		public float uvTiling = 1f;

		public bool planarUVs = false;

		public bool flipNormals = false;

		public bool randomnessFlag = false;

		public bool randomnessMarkerFlag = false;

		public float randomYPosition = 0f;

		public float randomMinYPosition = -0.02f;

		public float randomMaxYPosition = 0.02f;

		public float minRandomYPositionDistance = 15f;

		public float maxRandomYPositionDistance = 35f;

		public float randomMinRotation = 0f;

		public float randomMaxRotation = 0f;

		public float minRandomRotationDistance = 15f;

		public float maxRandomRotationDistance = 35f;

		public float vegetationStudioGrassPerimeter = 2f;

		public float vegetationStudioPlantPerimeter = 3f;

		public float vegetationStudioTreePerimeter = 4f;

		public float vegetationStudioObjectPerimeter = 3f;

		public float vegetationStudioLargeObjectPerimeter = 4f;

		public int vertsStats = 0;

		public int trisStats = 0;

		public float indent = 0.5f;

		public float surrounding = 0.5f;

		public bool followTerrainContours;

		public float terrainContoursOffset = 5f;

		public List<Vector2> roadShape = new List<Vector2>();

		public List<int> roadShapeIntsStart = new List<int>();

		public List<int> roadShapeIntsEnd = new List<int>();

		public List<int> roadShapeIntsStartFull = new List<int>();

		public List<int> roadShapeIntsEndFull = new List<int>();

		public string roadShapeString = "";

		public string roadShapeReversedString = "";

		public int roadShapeMatchCount = 0;

		public int geoReversed = -1;

		public int roadShapeCols = 0;

		public int subSegments = 1;

		public List<float> nodeDistance = new List<float>();

		public List<float> roadShapeUVs = new List<float>();

		public List<float> roadShapeUVs2 = new List<float>();

		public List<bool> doConnectionTri = new List<bool>();

		public List<float> randomRotations = new List<float>();

		public List<bool> hardEdge = new List<bool>();

		public List<int> roadShapeMaterialInts = new List<int>();

		public int subMeshCount = 1;

		public List<int> roadShapeMaterialIntCounts = new List<int>();

		public List<Vector3> controlPoints = new List<Vector3>();

		public List<Vector3> splinePoints = new List<Vector3>();

		public List<float> distances = new List<float>();

		public List<int> markerInts = new List<int>();

		public List<Vector3> insertSplinePoints = new List<Vector3>();

		public List<Vector3> soSplinePoints = new List<Vector3>();

		public List<Vector3> soSplinePointsLeft = new List<Vector3>();

		public List<Vector3> soSplinePointsRight = new List<Vector3>();

		public List<float> OOQDQQOQCD = new List<float>();

		public List<float> OQCODCDCDC = new List<float>();

		public List<Vector3> meshVecs = new List<Vector3>();

		public List<Vector2> meshUVs = new List<Vector2>();

		public List<Vector2> meshUVs2 = new List<Vector2>();

		public List<List<int>> tris = new List<List<int>>();

		public List<Vector3> surfaceMeshVecs = new List<Vector3>();

		public List<Vector3> leftIndentVecs = new List<Vector3>();

		public List<Vector3> rightIndentVecs = new List<Vector3>();

		public List<Vector3> middleIndentVecs = new List<Vector3>();

		public List<Vector3> leftSurroundingVecs = new List<Vector3>();

		public List<Vector3> rightSurroundingVecs = new List<Vector3>();

		public List<Vector3> leftIndentVecsSV = new List<Vector3>();

		public List<Vector3> rightIndentVecsSV = new List<Vector3>();

		public List<bool> bridgeElement = new List<bool>();

		public List<Vector3> vecsBelowTerrain = new List<Vector3>();

		public List<Vector3> treeVecs = new List<Vector3>();

		public List<Vector3> detailVecs = new List<Vector3>();

		public List<int> vegetationTris = new List<int>();

		public float totalDistance = 0f;

		public List<int> nodeSplinePoint = new List<int>();

		public string totalDistanceString = "";

		public ERCrossingPrefabs startPrefabScript;

		public ERCrossingPrefabs endPrefabScript;

		public int startConnectionSegment = 0;

		public bool startConnectionFlag = true;

		public int endConnectionSegment = 0;

		public bool endConnectionFlag = true;

		public bool tCrossingConnected = false;

		public Material roadMaterial;

		public Material[] roadMaterials;

		public Material roadPhysicsMaterial;

		public Material[] roadPhysicsMaterials;

		public Vector3 startDir;

		public Vector3 endDir;

		public float startAngle;

		public float endAngle;

		private int ᙃ;

		private int ᙄ;

		public int startbendLeftRight = 0;

		public int endbendLeftRight = 0;

		public Vector3 pivotp;

		public Vector3 p1;

		public Vector3 p2;

		public Vector3 p3;

		public Vector3 p4;

		public Vector3 p5;

		public Vector3 p6;

		public Vector3 p7;

		public Vector3 cp1;

		public Vector3 cp2;

		public Vector3 cp3;

		public Vector3 cp4;

		public Vector3 cp5;

		public Vector3 cp6;

		public Vector3 cp7;

		public Vector3 cp8;

		public Vector3 cp9;

		public Vector3 cpcenter;

		public Vector3 p1Circle;

		public Vector3 p2Circle;

		public float cpradius;

		public float cpangle;

		public Vector3 dp1;

		public Vector3 dp2;

		public Vector3 dp3;

		public Vector3 dp4;

		public List<Vector3> segPoints = new List<Vector3>();

		public List<Vector3> testPoints = new List<Vector3>();

		public List<Vector3> testPoints2 = new List<Vector3>();

		public Vector3 ODODCOOOCD = Vector3.zero;

		public Vector3 OOOQOODOCD = Vector3.zero;

		public Vector3 endLeft = Vector3.zero;

		public Vector3 endRight = Vector3.zero;

		public Mesh testmesh;

		public GameObject surfaceMesh;

		public Vector3 sv1;

		public Vector3 sv2;

		public Vector3 prefabIndentLeft;

		public Vector3 prefabIndentRight;

		public Vector3 roadIndent1;

		public static int OQDCDQDDOQ;

		public static int OCDQODQQOQ;

		public static int OQQDDDQODC;

		public static int ODQQQCCDDO;

		public static int ODQQOCOQDD;

		public static int ODODDDOCDC;

		public Vector3 tmpPerpCP;

		public Vector3 tmpCP;

		private int ᙅ = 0;

		private int _4AAAA = 0;

		public float splinePos = 0.001f;

		public float camHeight = 5f;

		public Vector3[] flyOverPoints;

		public Vector3 splinePosV3;

		public List<float> markerDistances = new List<float>();

		public string osmRoadType = "";

		public List<ERSORoad> soData = new List<ERSORoad>();

		public List<ERSORoadExt> soDataExt = new List<ERSORoadExt>();

		public string[] sideObjectNames = new string[0];

		public int selectedSO = 0;

		public bool rebuildSos = false;

		public bool sosCleared = false;

		public bool isSideObject = false;

		public int startOffsetActiveMarker = -1;

		public int endOffsetActiveMarker = -1;

		public float leftToCenterPerc = 0f;

		public ERRoad road;

		public bool splatMapActive = false;

		public int splatIndex = 0;

		public int expandLevel = 0;

		public int smoothLevel = 1;

		public float splatOpacity = 1f;

		public int layer = 0;

		public new string tag = "";

		public bool castShadow = false;

		public bool fadeInFlag = false;

		public float fadeInDistance = 0f;

		public bool fadeOutFlag = false;

		public float fadeOutDistance = 0f;

		public bool doSurroundingSurfaces = false;

		public bool terrainDeformation = true;

		public bool snapToTerrain = false;

		public bool snapVertices = false;

		public float snapOffset = 0.01f;

		public bool hasMeshCollider = true;

		public bool isUpdated = false;

		public bool QDDDQODQQDQDQQD = false;

		public int uv4Type = 0;

		public float detailDistance = 50f;

		public bool startDecalCollapsed = false;

		public ERDecal startDecal;

		public ERDecal endDecal;

		public GameObject startDecalPrefab;

		public GameObject startDecalPrefabSource;

		public bool endDecalCollapsed = false;

		public GameObject endDecalPrefab;

		public GameObject endDecalPrefabSource;

		public int startDecalID = -1;

		public int endDecalID = -1;

		public Vector3 lastForward;

		public bool roadUpdate = false;

		public Bounds bounds;

		public bool OQCDCDQDCQ(ERCrossingPrefabs prefabScript)
		{
			if (startPrefabScript == prefabScript)
			{
				if (endPrefabScript != null)
				{
					return endPrefabScript.isCustomPrefab;
				}
			}
			else if (startPrefabScript != null)
			{
				return startPrefabScript.isCustomPrefab;
			}
			return true;
		}

		public void OOOQOCDDOQ(List<ERDecal> decalPresets)
		{
			if (startDecalPrefab != null)
			{
				UnityEngine.Object.DestroyImmediate(startDecalPrefab);
			}
			if (endDecalPrefab != null)
			{
				UnityEngine.Object.DestroyImmediate(endDecalPrefab);
			}
			startDecalID = -1;
			endDecalID = -1;
			List<int> list = new List<int>();
			int num = 0;
			foreach (ERDecal decalPreset in decalPresets)
			{
				if (decalPreset.priority == 0)
				{
					list.Add(num);
					list.Add(num);
					list.Add(num);
				}
				else if (decalPreset.priority == 1)
				{
					list.Add(num);
					list.Add(num);
				}
				else if (decalPreset.priority == 2)
				{
					list.Add(num);
				}
				num++;
			}
			if (list.Count > 0)
			{
				int min = 0;
				int count = list.Count;
				int index = UnityEngine.Random.Range(min, count);
				startDecalID = decalPresets[list[index]].id;
				startDecal = decalPresets[list[index]];
				index = UnityEngine.Random.Range(min, count);
				endDecalID = decalPresets[list[index]].id;
				endDecal = decalPresets[list[index]];
			}
		}

		public void ODQQOOCQOD()
		{
			List<GameObject> list = new List<GameObject>();
			foreach (Transform item in base.transform)
			{
				if (item.name.IndexOf("_ERDecal_Start") != -1 || item.name.IndexOf("_ERDecal_End") != -1)
				{
					list.Add(item.gameObject);
				}
			}
			foreach (GameObject item2 in list)
			{
				UnityEngine.Object.DestroyImmediate(item2);
			}
		}

		public float GetRoadWidth()
		{
			if (roadType != 0.0)
			{
				return QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType)?.roadWidth ?? roadWidth;
			}
			return roadWidth;
		}

		public void OCOCOCDQDD(Vector3 pos)
		{
			float num = 10000f;
			nodeWithinRange = -1;
			float num2 = 10000f;
			for (int i = 0; i < markersExt.Count; i++)
			{
				float num3 = Vector3.Distance(markersExt[i].position, pos);
				if (num3 < minNodeDistance && num2 > num3)
				{
					num2 = num3;
					nodeWithinRange = i;
				}
				if (num3 < num)
				{
					num = num3;
				}
			}
		}

		public void GetInsertPointExt(Vector3 pos, ref int n1, int marker)
		{
			OOQODDCODD(pos, ref n1);
		}

		public void OOQODDCODD(Vector3 pos, ref int n1)
		{
			float num = 10000f;
			int num2 = 0;
			float num3 = 0f;
			for (int i = 1; i < insertSplinePoints.Count - 1; i++)
			{
				num3 = Vector3.Distance(insertSplinePoints[i], pos);
				if (num3 < num)
				{
					num2 = i;
					num = num3;
				}
			}
			for (int i = 0; i < markersExt.Count - 1; i++)
			{
				if (num2 >= markersExt[i].startSplinePoint - 1 && num2 < markersExt[i + 1].startSplinePoint - 1)
				{
					n1 = i + 1;
					break;
				}
			}
		}

		public void ODCQOCCQCD(Vector3 pos, ref int n1, int selectedMarker, bool sameRoad)
		{
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			if (sameRoad)
			{
				if (selectedMarker > 0)
				{
					num = markersExt[selectedMarker - 1].startSplinePoint;
				}
				num2 = ((selectedMarker >= markersExt.Count - 1) ? markersExt[selectedMarker].startSplinePoint : markersExt[selectedMarker + 1].startSplinePoint);
			}
			float num4 = 10000f;
			int num5 = 0;
			float num6 = 0f;
			for (int i = 1; i < insertSplinePoints.Count - 1; i++)
			{
				num6 = Vector3.Distance(insertSplinePoints[i], pos);
				if (num6 < num4 && (i < num || i > num2))
				{
					num5 = i;
					num4 = num6;
				}
			}
			for (int i = 0; i < markersExt.Count - 1; i++)
			{
				if (num5 >= markersExt[i].startSplinePoint - 1 && num5 < markersExt[i + 1].startSplinePoint - 1)
				{
					n1 = i + 1;
					break;
				}
			}
		}

		public int OOQQDOOODC(Vector3 pos)
		{
			bool flag = false;
			int result = -1;
			if (markersExt.Count < 2)
			{
				markersExt.Add(ERMarkerExt.CreateInstance(pos, this, markersExt.Count));
				flag = true;
			}
			else if (nodeWithinRange == -1)
			{
				if (insertSplinePoints.Count == 0)
				{
					Debug.Log("no splinepoints available, insert point cannot be calculated");
					return 0;
				}
				int n = 0;
				OOQODDCODD(pos, ref n);
				switch (n)
				{
				case 0:
				{
					float num = Vector3.Distance(markersExt[0].position, pos);
					float num2 = Vector3.Distance(markersExt[markersExt.Count - 1].position, pos);
					if (num <= num2)
					{
						if (startPrefabScript == null)
						{
							HandleAddMarkerAtStart(pos, 0);
							return 0;
						}
					}
					else if (endPrefabScript == null)
					{
						OQQQDOQCDQ(pos, 0);
						return markersExt.Count - 1;
					}
					break;
				}
				case 1:
				{
					float num = Vector3.Distance(markersExt[1].position, pos);
					float num2 = Vector3.Distance(markersExt[0].position, markersExt[1].position);
					if (num > num2)
					{
						if (startPrefabScript == null)
						{
							HandleAddMarkerAtStart(pos, 0);
						}
						return 0;
					}
					break;
				}
				}
				flag = true;
				markersExt.Insert(n, ERMarkerExt.CreateInstance(pos, this, n));
				if (endPrefabScript != null)
				{
					endPrefabScript.crossingElements[endConnectionSegment].connectedMarker = markersExt.Count - 1;
				}
				result = n;
			}
			if (markersExt.Count >= 2 && flag)
			{
				OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
			}
			return result;
		}

		public int OQQQDOQCDQ(Vector3 pos, int selectedMarker)
		{
			if (endPrefabScript == null)
			{
				markersExt.Add(ERMarkerExt.CreateInstance(pos, this, markersExt.Count));
				nodeWithinRange++;
				OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
				selectedMarker = markersExt.Count - 1;
			}
			return selectedMarker;
		}

		public int HandleAddMarkerAtStart(Vector3 pos, int selectedMarker)
		{
			if (startPrefabScript == null)
			{
				markersExt.Insert(0, ERMarkerExt.CreateInstance(pos, this, 0));
				OCCCCCCDCC(ignorePrefabAlignment: false, forceAutoRotate: false);
				selectedMarker = 0;
			}
			return selectedMarker;
		}

		public void OQCCCCQCCO(ERCrossingPrefabs ODDOCQCCDQ, int targetElement, bool reverse, bool uvReverse)
		{
			ODQCQOODDO.OOCCDCOODQ(this, ODDOCQCCDQ, targetElement, reverse, uvReverse);
		}

		public void ODCQOCQDOO(bool ignorePrefabAlignment, int selectedMarker)
		{
		}

		public void PrintRoadShape(List<Vector2> lst)
		{
			string text = "";
			for (int i = 0; i < lst.Count; i++)
			{
				object obj = text;
				text = string.Concat(obj, lst[i].x, " ", lst[i].y, "; ");
			}
			Debug.Log(text);
		}

		public void OCCCCCCDCC(bool ignorePrefabAlignment, bool forceAutoRotate)
		{
			if (baseScript == null)
			{
				if ((bool)base.transform.parent.parent.gameObject.GetComponent<ERModularBase>())
				{
					baseScript = base.transform.parent.parent.gameObject.GetComponent<ERModularBase>();
				}
				else if ((bool)base.transform.parent.parent.parent.gameObject.GetComponent<ERModularBase>())
				{
					baseScript = base.transform.parent.parent.parent.gameObject.GetComponent<ERModularBase>();
				}
				else if ((bool)base.transform.parent.parent.parent.parent.gameObject.GetComponent<ERModularBase>())
				{
					baseScript = base.transform.parent.parent.parent.parent.gameObject.GetComponent<ERModularBase>();
				}
				if (baseScript == null)
				{
					Debug.Log("EasyRoads3Dv3 Warning: Unable to find road network script, please report. Are you using deeply nested connection prefabs?");
					roadUpdate = false;
					return;
				}
			}
			float num = baseScript.terrainMinIndent;
			if (markersExt.Count > 0)
			{
				foreach (ERSOMarkerExt soDatum in markersExt[0].soData)
				{
					float num2 = 0f;
					if (soDatum != null && soDatum.sideObject.indentExt > num2)
					{
						num2 = soDatum.sideObject.indentExt;
					}
					num += num2;
				}
			}
			isUpdated = true;
			if (roadUpdate)
			{
				return;
			}
			roadUpdate = true;
			base.transform.position = Vector3.zero;
			lastForward = Vector3.zero;
			if (!isCustomRoadSet && roadType != 0.0)
			{
				isCustomRoadSet = true;
				for (int i = 0; i < baseScript.roadTypes.Count; i++)
				{
					if (baseScript.roadTypes[i].id == roadType)
					{
						if (baseScript.roadTypes[i].isCustomRoad)
						{
							isCustomRoad = true;
						}
						break;
					}
				}
			}
			if (markersExt.Count <= 1)
			{
				if ((bool)base.gameObject.GetComponent<MeshFilter>().sharedMesh)
				{
					base.gameObject.GetComponent<MeshFilter>().sharedMesh.Clear();
				}
				if (surfaceMesh != null)
				{
					surfaceMesh.GetComponent<MeshFilter>().sharedMesh.Clear();
				}
				roadUpdate = false;
				return;
			}
			baseScript.dirtyOnSceneBool = true;
			if (!sosCleared && baseScript != null)
			{
				rebuildSos = OCQQCCQCCO.ODDCCQDCOC(baseScript, this);
				if (rebuildSos && !isSideObject && baseScript.buildSOinEditMode)
				{
					baseScript.RoadObjectsSoUpdates.Add(this);
				}
				sosCleared = true;
			}
			if (markersExt.Count > 0 && markersExt[markersExt.Count - 1].controlType == 3)
			{
				markersExt[markersExt.Count - 1].controlType = 0;
				Debug.Log("EasyRoads3Dv3 Warning: The Contol Type the last marker of a road cannot be Circular. Road: " + base.gameObject.name);
			}
			vecsBelowTerrain.Clear();
			if (base.gameObject == null)
			{
				roadUpdate = false;
				return;
			}
			if (base.gameObject.GetComponent<MeshFilter>() == null)
			{
				base.gameObject.AddComponent<MeshFilter>();
			}
			if (base.gameObject.GetComponent<MeshRenderer>() == null)
			{
				base.gameObject.AddComponent<MeshRenderer>();
				if (roadMaterials.Length != 0)
				{
					base.gameObject.GetComponent<MeshRenderer>().sharedMaterials = roadMaterials;
				}
			}
			if (base.gameObject.GetComponent<MeshCollider>() == null && hasMeshCollider)
			{
				base.gameObject.AddComponent<MeshCollider>();
			}
			Mesh mesh;
			if (base.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			base.gameObject.isStatic = true;
			if ((startPrefabScript != null && startConnectionSegment == -1) || (startPrefabScript == null && startConnectionSegment != -1))
			{
				startPrefabScript = null;
				startConnectionSegment = -1;
			}
			if ((endPrefabScript != null && endConnectionSegment == -1) || (endPrefabScript == null && endConnectionSegment != -1))
			{
				endPrefabScript = null;
				endConnectionSegment = -1;
			}
			Transform transform = null;
			Transform transform2 = null;
			if (startPrefabScript != null)
			{
				transform = startPrefabScript.transform;
				if (startPrefabScript.surfaceObject != null)
				{
					transform = startPrefabScript.surfaceObject.transform;
				}
			}
			if (endPrefabScript != null)
			{
				transform2 = endPrefabScript.transform;
				if (endPrefabScript.surfaceObject != null)
				{
					transform2 = endPrefabScript.surfaceObject.transform;
				}
			}
			bool flag = false;
			if (roadShape == null)
			{
				flag = true;
			}
			else if (roadShape.Count <= 1)
			{
				flag = true;
			}
			if (flag || roadShape.Count != roadShapeUVs.Count)
			{
				OCQQDQQCQQ.GetRoadShape(roadWidth, subSegments, ref roadShape, ref roadShapeUVs, ref roadShapeUVs2, -1f);
				roadShapeMaterialInts.Add(0);
				roadShapeMaterialInts.Add(0);
				if (roadMaterials == null)
				{
					roadMaterials = new Material[1];
				}
				else if (roadMaterials.Length != 1)
				{
					roadMaterials = new Material[1];
				}
				roadShapeMatchCount = subSegments + 1;
				int num3 = 1;
				for (int i = 1; i < roadShape.Count; i++)
				{
					if ((double)Vector2.Distance(roadShape[i - 1], roadShape[i]) > 0.01)
					{
						num3++;
					}
				}
				roadShapeMatchCount = num3;
				for (int i = 0; i < markersExt.Count; i++)
				{
					markersExt[i].roadShape = new List<Vector2>(roadShape);
				}
			}
			if (roadShapeUVs.Count != roadShape.Count)
			{
				roadShapeUVs.Clear();
				roadShapeUVs2.Clear();
				float num4 = 0f;
				for (int i = 0; i < roadShape.Count - 1; i++)
				{
					num4 += Vector2.Distance(roadShape[i], roadShape[i + 1]);
				}
				float num5 = 0f;
				roadShapeUVs.Add(0f);
				roadShapeUVs2.Add(0f);
				for (int i = 0; i < roadShape.Count - 1; i++)
				{
					num5 += Vector2.Distance(roadShape[i], roadShape[i + 1]);
					roadShapeUVs.Add(num5 / num4);
					roadShapeUVs2.Add(num5 / num4);
				}
			}
			if (roadShapeUVs.Count != roadShapeUVs2.Count)
			{
				roadShapeUVs2 = new List<float>(roadShapeUVs);
			}
			if (roadShapeMatchCount == 0)
			{
				int num3 = 1;
				for (int i = 1; i < roadShape.Count; i++)
				{
					if ((double)Vector2.Distance(roadShape[i - 1], roadShape[i]) > 0.01)
					{
						num3++;
					}
				}
				roadShapeMatchCount = num3;
			}
			int num6 = 0;
			if (startPrefabScript != null && (roadShapeIntsStart.Count == 0 || roadShapeIntsStart.Count != roadShape.Count))
			{
				ODQCQOODDO.OOQQOQDODQ(this, roadShape, null, 0);
			}
			if (endPrefabScript != null && (roadShapeIntsEnd.Count == 0 || roadShapeIntsEnd.Count != roadShape.Count))
			{
				ODQCQOODDO.OOQQOQDODQ(this, roadShape, null, 1);
			}
			if (roadShape.Count != roadShapeMaterialInts.Count)
			{
				roadShapeMaterialInts.Clear();
				for (int i = 0; i < roadShape.Count; i++)
				{
					roadShapeMaterialInts.Add(0);
				}
				num6 = 0;
			}
			if (roadShapeMaterialIntCounts.Count != roadMaterials.Length && roadShapeMaterialInts.Count > 0)
			{
				roadShapeMaterialIntCounts.Clear();
				for (int i = 0; i < roadShapeMaterialInts.Count; i++)
				{
					if (roadShapeMaterialInts[i] >= roadShapeMaterialIntCounts.Count)
					{
						while (roadShapeMaterialInts[i] >= roadShapeMaterialIntCounts.Count)
						{
							roadShapeMaterialIntCounts.Add(0);
						}
					}
					roadShapeMaterialIntCounts[roadShapeMaterialInts[i]]++;
				}
			}
			if (roadMaterials.Length == 0)
			{
				roadMaterials = new Material[1];
				roadMaterials[0] = roadMaterial;
				base.gameObject.GetComponent<MeshRenderer>().sharedMaterials = roadMaterials;
			}
			if (markersExt.Count < controlPoints.Count)
			{
				markersExt.Clear();
				for (int i = 0; i < controlPoints.Count; i++)
				{
					markersExt.Add(ERMarkerExt.CreateInstance(controlPoints[i], this, markersExt.Count));
				}
			}
			tValues.Clear();
			markerDistances.Clear();
			List<float> leftIndents = new List<float>();
			List<float> rightIndents = new List<float>();
			List<float> leftSurrounding = new List<float>();
			List<float> rightSurrounding = new List<float>();
			if (markersExt[0].roadShape.Count == 0)
			{
				foreach (ERMarkerExt item2 in markersExt)
				{
					item2.roadShape = new List<Vector2>(roadShape);
				}
			}
			if (angleTreshold < 1f)
			{
				angleTreshold = 1f;
			}
			randomRotations.Clear();
			if (startConnectionFlag && startPrefabScript == null)
			{
				markersExt[0].roadShape = new List<Vector2>(roadShape);
				markersExt[0].roadShapeDistanceMin = 0f;
				markersExt[0].roadShapeDistanceMax = 1f;
				startConnectionFlag = false;
			}
			if (endConnectionFlag && endPrefabScript == null)
			{
				markersExt[markersExt.Count - 1].roadShape = new List<Vector2>(roadShape);
				markersExt[markersExt.Count - 1].roadShapeDistanceMin = 0f;
				markersExt[markersExt.Count - 1].roadShapeDistanceMax = 1f;
				endConnectionFlag = false;
			}
			if (startPrefabScript != null && endPrefabScript != null && startPrefabScript.crossingElements[startConnectionSegment].roadShapeMatchCount != endPrefabScript.crossingElements[endConnectionSegment].roadShapeMatchCount && !startPrefabScript.isIConnector && !endPrefabScript.isIConnector)
			{
				Debug.LogWarning("EasyRoads3Dv3 Warning: The geometry structure of the connection at the start does not match the geometry at the end, road update aborted: " + base.gameObject.name);
				roadUpdate = false;
				return;
			}
			splinePoints = OQQOQCQQQD(markersExt, faceDistance, ignorePrefabAlignment, ref tValues, ref markerDistances, forceAutoRotate, ref randomRotations);
			if (splinePoints == null)
			{
				roadUpdate = false;
				return;
			}
			if (splinePoints.Count == 1)
			{
				roadUpdate = false;
				return;
			}
			bool flag2 = true;
			bool flag3 = false;
			bool startSurfacesSafe = false;
			Vector3 vector = Vector3.zero;
			Vector3 startPrefabIndent = Vector3.zero;
			Vector3 oDDOCQCCDQIndent = Vector3.zero;
			Vector3 a = Vector3.zero;
			Vector3 zero = Vector3.zero;
			bool flag4 = false;
			float num7 = 0f;
			int num8 = -1;
			float num9 = 0f;
			Vector3 a2 = Vector3.zero;
			Vector3 startPrefabIndent2 = Vector3.zero;
			Vector3 oDDOCQCCDQIndent2 = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			float num10 = 0f;
			int num11 = -1;
			int endAdjustInt = 0;
			float num12 = 0f;
			float num13 = 30f;
			if (totalDistance < num13)
			{
				num13 = totalDistance;
			}
			if (totalDistance * 0.5f < num13)
			{
				num13 = totalDistance * 0.5f;
			}
			bool flag5 = false;
			if (startPrefabScript != null && endPrefabScript != null && markersExt.Count == 2)
			{
				flag5 = true;
				if (num13 > totalDistance - baseScript.minIndent * 2f * 0.5f)
				{
					num13 = totalDistance - baseScript.minIndent * 2f * 0.5f;
				}
			}
			if (flag5 && totalDistance * 0.5f < num13)
			{
				num13 = totalDistance * 0.5f;
			}
			float num14 = num13;
			if (num14 < markersExt[0].totalDistance && !flag5)
			{
				num14 = markersExt[0].totalDistance;
			}
			float endAdjustDistance = num13;
			if (!closedTrack)
			{
				markersExt[markersExt.Count - 2].totalDistance = totalDistance - markersExt[markersExt.Count - 2].startDistance;
			}
			if (endAdjustDistance < markersExt[markersExt.Count - 2].totalDistance && !flag5)
			{
				endAdjustDistance = markersExt[markersExt.Count - 2].totalDistance;
			}
			int num15 = 0;
			int num16 = roadShape.Count - 1;
			if (startPrefabScript == null && endPrefabScript == null)
			{
				float num17 = 100000f;
				float num18 = -100000f;
				for (int i = 0; i < roadShape.Count; i++)
				{
					if (roadShape[i].x < num17)
					{
						num16 = i;
						num17 = roadShape[i].x;
					}
					if (roadShape[i].x > num18)
					{
						num15 = i;
						num18 = roadShape[i].x;
					}
				}
			}
			bool flag6 = false;
			if (startPrefabScript != null)
			{
				QDOODOQQDQODD qDOODOQQDQODD = startPrefabScript.crossingElements[startConnectionSegment];
				if (qDOODOQQDQODD.rightInt == 0 && qDOODOQQDQODD.leftInt == 0)
				{
					qDOODOQQDQODD.leftInt = 0;
					qDOODOQQDQODD.rightInt = qDOODOQQDQODD.connectionVecInts.Count - 1;
					qDOODOQQDQODD.leftIntFull = 0;
					qDOODOQQDQODD.rightIntFull = qDOODOQQDQODD.fullConnectionVecInts.Count - 1;
				}
				if (roadShape.Count > qDOODOQQDQODD.leftInt && roadShape.Count > qDOODOQQDQODD.rightInt)
				{
					num15 = qDOODOQQDQODD.leftInt;
					num16 = qDOODOQQDQODD.rightInt;
				}
				if (roadShape.Count == qDOODOQQDQODD.connectionVecInts.Count)
				{
					flag6 = true;
				}
				if (startPrefabScript.isCustomPrefab)
				{
					ODODCOOOCD = startPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.rightInt]];
				}
				else
				{
					ODODCOOOCD = startPrefabScript.tmpFullMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.rightInt]];
				}
				Vector3 oDODCOOOCD = ODODCOOOCD;
				ODODCOOOCD = startPrefabScript.transform.TransformPoint(ODODCOOOCD);
				if (startPrefabScript.isCustomPrefab)
				{
					OOOQOODOCD = startPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.leftInt]];
				}
				else
				{
					OOOQOODOCD = startPrefabScript.tmpFullMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.leftInt]];
				}
				Vector3 oOOQOODOCD = OOOQOODOCD;
				OOOQOODOCD = startPrefabScript.transform.TransformPoint(OOOQOODOCD);
				if (startPrefabScript.crossingElements[startConnectionSegment].leftIndentV3 != Vector3.zero)
				{
					startPrefabIndent = startPrefabScript.transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].leftIndentV3);
				}
				else
				{
					startPrefabIndent = oDODCOOOCD;
					startPrefabIndent.y = 0f;
					startPrefabIndent = startPrefabScript.transform.TransformPoint(startPrefabIndent);
				}
				if (startPrefabScript.crossingElements[startConnectionSegment].rightIndentV3 != Vector3.zero)
				{
					oDDOCQCCDQIndent = startPrefabScript.transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].rightIndentV3);
				}
				else
				{
					oDDOCQCCDQIndent = oOOQOODOCD;
					oDDOCQCCDQIndent.y = 0f;
					oDDOCQCCDQIndent = startPrefabScript.transform.TransformPoint(oDDOCQCCDQIndent);
				}
				a = startPrefabScript.transform.TransformPoint(Vector3.zero);
				zero = startPrefabScript.transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].tmpCenterPoint);
				num7 = startPrefabScript.crossingElements[startConnectionSegment].additionalIndentDistance;
				flag4 = false;
				float num19 = Vector3.Distance(splinePoints[0], zero) - 0.75f * faceDistance;
				Vector3 a3 = splinePoints[0];
				if (startPrefabScript.tCrossing && startConnectionSegment <= 1)
				{
					float num4 = Vector3.Distance(a, zero);
					int i = 0;
					while (i < splinePoints.Count && Vector3.Distance(a3, splinePoints[i]) < num19)
					{
						splinePoints.RemoveAt(0);
						tValues.RemoveAt(0);
						i--;
						i++;
					}
				}
				num8 = ((startbendLeftRight != -1) ? ODQCQOODDO.OOQOCQDDDC(this, splinePoints, baseScript.minIndent, roadShape[roadShape.Count - 1].x, oDDOCQCCDQIndent, startPrefabIndent, startbendLeftRight) : ODQCQOODDO.OOQOCQDDDC(this, splinePoints, baseScript.minIndent, roadShape[0].x, oDDOCQCCDQIndent, startPrefabIndent, startbendLeftRight));
			}
			else
			{
				flag3 = true;
				startSurfacesSafe = true;
			}
			int num20 = 0;
			bool surfacesSafe = true;
			bool flag7 = false;
			if (endPrefabScript != null)
			{
				surfacesSafe = false;
				QDOODOQQDQODD qDOODOQQDQODD = endPrefabScript.crossingElements[endConnectionSegment];
				qDOODOQQDQODD.connectedMarker = markersExt.Count - 1;
				if (qDOODOQQDQODD.rightInt == 0 && qDOODOQQDQODD.leftInt == 0)
				{
					qDOODOQQDQODD.leftInt = 0;
					qDOODOQQDQODD.rightInt = qDOODOQQDQODD.connectionVecInts.Count - 1;
					qDOODOQQDQODD.leftIntFull = 0;
					qDOODOQQDQODD.rightIntFull = qDOODOQQDQODD.fullConnectionVecInts.Count - 1;
				}
				if (roadShape.Count > qDOODOQQDQODD.leftInt && roadShape.Count > qDOODOQQDQODD.rightInt)
				{
					num15 = qDOODOQQDQODD.leftInt;
					num16 = qDOODOQQDQODD.rightInt;
				}
				if (roadShape.Count == qDOODOQQDQODD.connectionVecInts.Count)
				{
					flag7 = true;
				}
				if (endPrefabScript.isCustomPrefab)
				{
					endLeft = endPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.leftInt]];
				}
				else
				{
					endLeft = endPrefabScript.tmpFullMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.leftInt]];
				}
				Vector3 vector3 = endLeft;
				endLeft = endPrefabScript.transform.TransformPoint(endLeft);
				if (endPrefabScript.isCustomPrefab)
				{
					endRight = endPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.rightInt]];
				}
				else
				{
					endRight = endPrefabScript.tmpFullMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.rightInt]];
				}
				Vector3 vector4 = endRight;
				endRight = endPrefabScript.transform.TransformPoint(endRight);
				num20 = Mathf.RoundToInt(Mathf.Ceil(roadWidth / (faceDistance * 1f)));
				if (endPrefabScript.crossingElements[endConnectionSegment].leftIndentV3 != Vector3.zero)
				{
					startPrefabIndent2 = endPrefabScript.transform.TransformPoint(endPrefabScript.crossingElements[endConnectionSegment].leftIndentV3);
				}
				else
				{
					startPrefabIndent2 = vector3;
					startPrefabIndent2.y = 0f;
					startPrefabIndent2 = endPrefabScript.transform.TransformPoint(startPrefabIndent2);
				}
				if (endPrefabScript.crossingElements[endConnectionSegment].rightIndentV3 != Vector3.zero)
				{
					oDDOCQCCDQIndent2 = endPrefabScript.transform.TransformPoint(endPrefabScript.crossingElements[endConnectionSegment].rightIndentV3);
				}
				else
				{
					oDDOCQCCDQIndent2 = vector4;
					oDDOCQCCDQIndent2.y = 0f;
					oDDOCQCCDQIndent2 = endPrefabScript.transform.TransformPoint(oDDOCQCCDQIndent2);
				}
				vector2 = endPrefabScript.transform.TransformPoint(Vector3.zero);
				zero2 = endPrefabScript.transform.TransformPoint(endPrefabScript.crossingElements[endConnectionSegment].tmpCenterPoint);
				num10 = endPrefabScript.crossingElements[endConnectionSegment].additionalIndentDistance;
				if (endPrefabScript.tCrossing && endConnectionSegment <= 1)
				{
					float num4 = Vector3.Distance(vector2, zero2);
					int i = splinePoints.Count;
					while (i < splinePoints.Count && num4 > -1f + Vector3.Distance(splinePoints[0], vector2))
					{
						splinePoints.RemoveAt(i);
						tValues.RemoveAt(i);
						i++;
						i--;
					}
				}
				num11 = ((endbendLeftRight != -1) ? ODQCQOODDO.ODODDODDCO(this, splinePoints, baseScript.minIndent, roadShape[0].x, oDDOCQCCDQIndent2, startPrefabIndent2, endbendLeftRight, ref endAdjustInt, ref endAdjustDistance) : ODQCQOODDO.ODODDODDCO(this, splinePoints, baseScript.minIndent, roadShape[roadShape.Count - 1].x, oDDOCQCCDQIndent2, startPrefabIndent2, endbendLeftRight, ref endAdjustInt, ref endAdjustDistance));
			}
			bool flag8 = false;
			if (startPrefabScript != null && startPrefabScript.surfaceMeshVecs.Length == 0 && startPrefabScript.doTerrainDeformation)
			{
				flag8 = true;
			}
			bool flag9 = false;
			if (endPrefabScript != null && endPrefabScript.surfaceMeshVecs.Length == 0 && endPrefabScript.doTerrainDeformation)
			{
				flag9 = true;
			}
			if (!isSideObject)
			{
				ODCOCCDCQC.OCQOCOCDQC(markersExt, ref splinePoints, ref tValues);
			}
			soSplinePoints = new List<Vector3>(splinePoints);
			soSplinePointsLeft = new List<Vector3>(splinePoints);
			soSplinePointsRight = new List<Vector3>(splinePoints);
			distances.Clear();
			OOQDQQOQCD = OQCDDDCOOD(tValues, markerDistances, markersExt, 0, tmpMarkersExt.Count, ref OQCODCDCDC, randomRotations);
			List<List<Vector2>> roadShapeValues = GetRoadShapeValues(tValues, markerDistances, markersExt, 0, tmpMarkersExt.Count, roadShape);
			if (isSideObject)
			{
				insertSplinePoints.Clear();
				insertSplinePoints.AddRange(splinePoints);
				lastForward = (soSplinePoints[soSplinePoints.Count - 1] - soSplinePoints[soSplinePoints.Count - 2]).normalized;
				OOOOOQQQQQ(null);
				OCQQCCQCCO.OQOCCODQOC(baseScript, this, isSideObjectFlag: true);
				roadUpdate = false;
				return;
			}
			if (markersExt.Count > 1)
			{
				GetSurfaceValues(tValues, markerDistances, markersExt, 0, tmpMarkersExt.Count, ref leftIndents, ref rightIndents, ref leftSurrounding, ref rightSurrounding, num);
			}
			List<Vector3> vecs = new List<Vector3>();
			List<Vector2> list = new List<Vector2>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector3> surfaceVecs = new List<Vector3>();
			List<Vector2> list3 = new List<Vector2>();
			indent = baseScript.minIndent;
			surrounding = baseScript.minSurrounding;
			float terrainMinIndent = baseScript.terrainMinIndent;
			treeVecs.Clear();
			detailVecs.Clear();
			vegetationTris.Clear();
			leftIndentVecs.Clear();
			rightIndentVecs.Clear();
			middleIndentVecs.Clear();
			leftSurroundingVecs.Clear();
			rightSurroundingVecs.Clear();
			leftIndentVecsSV.Clear();
			rightIndentVecsSV.Clear();
			tris.Clear();
			for (int i = 0; i < roadMaterials.Length; i++)
			{
				tris.Add(new List<int>());
			}
			int num21 = 0;
			float num22 = 0f;
			float num23 = 0f;
			float num24 = 0f;
			float num25 = 0f;
			float num26 = 0f;
			if (uvTiling == 0f)
			{
				uvTiling = 1f;
			}
			float num27 = 5f * uvTiling;
			if (roadShape[0].x != roadShape[roadShape.Count - 1].x)
			{
				roadWidth = Vector2.Distance(new Vector2(roadShape[0].x, 0f), new Vector2(roadShape[roadShape.Count - 1].x, 0f));
			}
			else
			{
				float num28 = 10000f;
				float num29 = -10000f;
				for (int i = 0; i < roadShape.Count; i++)
				{
					if (roadShape[i].x < num28)
					{
						num28 = roadShape[i].x;
					}
					if (roadShape[i].x > num29)
					{
						num29 = roadShape[i].x;
					}
				}
				roadWidth = num29 - num28;
			}
			leftToCenterPerc = 0f;
			if (leftToCenterPerc == 0f)
			{
				if (num15 >= roadShape.Count || num16 >= roadShape.Count)
				{
					Debug.LogWarning("EasyRoasds3D Warning: the road shape does not match: " + base.gameObject.name);
					roadUpdate = false;
					return;
				}
				leftToCenterPerc = OQOOOODDDO.GetleftToCenterPerc(roadShape, num15, num16);
			}
			nodeDistance.Clear();
			nodeDistance.Add(0f);
			for (int i = 1; i < roadShape.Count; i++)
			{
				nodeDistance.Add(Vector2.Distance(new Vector2(roadShape[0].x, 0f), new Vector2(roadShape[i].x, 0f)) / roadWidth);
				if (roadShape[i - 1].x <= 0f && roadShape[i].x >= 0f)
				{
					num6 = roadShapeMaterialInts[i];
				}
			}
			Vector3 zero3 = Vector3.zero;
			int num30 = 0;
			bool flag10 = false;
			bool flag11 = false;
			List<bool> list4 = new List<bool>();
			List<Vector3> list5 = new List<Vector3>();
			List<float> list6 = new List<float>();
			Vector3 firstDir = Vector3.zero;
			Vector3 vector5 = Vector3.zero;
			ᙅ = -1;
			_4AAAA = -1;
			if (hardEdge.Count == 0 || hardEdge.Count != roadShape.Count)
			{
				hardEdge.Clear();
				for (int i = 0; i < roadShape.Count; i++)
				{
					hardEdge.Add(item: false);
				}
			}
			if (doConnectionTri.Count != roadShape.Count)
			{
				doConnectionTri.Clear();
				for (int i = 0; i < roadShape.Count; i++)
				{
					doConnectionTri.Add(item: true);
				}
			}
			int num31 = num15;
			int num32 = num16;
			int num33 = roadShape.Count;
			int num34 = 0;
			List<int> list7 = new List<int>();
			for (int i = 0; i < hardEdge.Count; i++)
			{
				if (hardEdge[i] && i > 0 && i < hardEdge.Count - 1)
				{
					num33++;
					list7.Add(num34);
					num34++;
				}
				if (i == num15)
				{
					num31 = num15 + num34;
				}
				if (i == num16)
				{
					num32 = num16 + num34;
				}
				list7.Add(num34);
			}
			float y = roadShape[num15].y;
			float y2 = roadShape[num16].y;
			int count = hardEdge.Count;
			roadShapeCols = num33;
			int[] array = new int[num33];
			int[] array2 = new int[num33];
			bool[] array3 = new bool[num33];
			bool[] array4 = new bool[num33];
			List<bool> list8 = new List<bool>();
			float num35 = 0.5f;
			if (baseScript.terrainMinIndent > 0.5f * roadWidth)
			{
				num35 = baseScript.terrainMinIndent / roadWidth;
				if ((double)num35 > 0.9)
				{
					num35 = 0.9f;
				}
			}
			num35 = 0.2f;
			Vector2 zero4 = Vector2.zero;
			bool flag12 = true;
			bool flag13 = true;
			bool flag14 = true;
			float num36 = 0f;
			float num37 = 0f;
			float num38 = 0f;
			bool flag15 = true;
			List<Color> list9 = new List<Color>();
			Color customColor = markersExt[0].customColor;
			float num39 = 0f;
			float num40 = 0f;
			float num41 = 0f;
			if (uv4Type == 1)
			{
				num41 = Mathf.Floor(totalDistance / detailDistance);
				num39 = ((num41 != 0f) ? (totalDistance / num41) : totalDistance);
			}
			for (int i = 0; i < splinePoints.Count; i++)
			{
				if (num30 + 1 >= tmpMarkersExt.Count)
				{
					num30 = tmpMarkersExt.Count - 2;
				}
				if (i == tmpMarkersExt[num30 + 1].startSplinePoint - 1)
				{
					flag10 = tmpMarkersExt[num30 + 1].bridgeObject;
					if (tmpMarkersExt[num30 + 1].bridgeObject)
					{
						if (tmpMarkersExt[num30 + 1].bridgeStartLevelDistance == 0f || tmpMarkersExt[num30].bridgeObject)
						{
							flag11 = true;
						}
						else
						{
							num37 = tmpMarkersExt[num30 + 1].bridgeStartLevelDistance;
						}
					}
					else
					{
						flag11 = false;
					}
					flag12 = true;
					flag8 = true;
					if (tmpMarkersExt.Count > num30 + 1 && i != 0)
					{
						num30++;
					}
					if (num30 >= markersExt.Count)
					{
						num30 = markersExt.Count - 1;
					}
					customColor = markersExt[num30].customColor;
				}
				else if (i != 0)
				{
					if (tmpMarkersExt[num30].bridgeObject)
					{
						flag11 = true;
					}
					flag12 = false;
					num38 = 0f;
					num36 = num37;
					num37 = 0f;
					if (flag11 && tmpMarkersExt.Count > num30 + 1 && splinePoints.Count > i + 1 && i + 2 == tmpMarkersExt[num30 + 1].startSplinePoint && !tmpMarkersExt[num30 + 1].bridgeObject && tmpMarkersExt[num30].bridgeEndLevelDistance > 0f)
					{
						num38 = tmpMarkersExt[num30].bridgeEndLevelDistance;
						flag11 = false;
					}
				}
				list4.Add(flag11);
				if (i > 0)
				{
					num23 = Vector3.Distance(splinePoints[i - 1], splinePoints[i]);
					num22 += num23;
				}
				num26 = num22 / num27;
				num40 = num22 / num39;
				Vector3 vector6 = ((i == 0) ? (splinePoints[i + 1] - splinePoints[i]).normalized : ((i != splinePoints.Count - 1) ? (splinePoints[i + 1] - splinePoints[i - 1]).normalized : (splinePoints[i] - splinePoints[i - 1]).normalized));
				if (i == 0)
				{
					firstDir = vector6;
				}
				vector5 = vector6;
				zero3 = ODQCQOODDO.GetEulerAngles(vector6);
				vector6 = new Vector3(0f - vector6.z, 0f, vector6.x);
				if (!flag3 && i < splinePoints.Count - 2)
				{
					vector = (splinePoints[i + 1] - splinePoints[i]).normalized;
					vector = new Vector3(0f - vector.z, 0f, vector.x);
				}
				Vector3 vector8;
				Vector3 zero5;
				Vector3 vector7 = (vector8 = (zero5 = Vector3.zero));
				Vector3 position = Vector3.zero;
				float num42 = 0f;
				if (OOQDQQOQCD[i] != 0f)
				{
					Vector3 a4 = splinePoints[i] + vector6 * roadShape[num15].x;
					Vector3 b = splinePoints[i] + vector6 * roadShape[num16].x;
					position = Vector3.Lerp(a4, b, OQCODCDCDC[i]);
					num42 = Mathf.Lerp(roadShape[num15].x, roadShape[num16].x, OQCODCDCDC[i]);
				}
				int num43 = 0;
				Vector3 pos;
				for (int j = 0; j < roadShape.Count; j++)
				{
					zero4 = roadShapeValues[j][i];
					bool flag16 = false;
					if (count > 0 && hardEdge[j] && j > 0 && j < roadShape.Count - 1)
					{
						flag16 = true;
					}
					if (OOQDQQOQCD[i] != 0f)
					{
						float x = zero4.x - num42;
						pos = ODQCQOODDO.ODCCODOOQQ(position, new Vector2(x, zero4.y), 180f - OOQDQQOQCD[i], zero3);
					}
					else
					{
						pos = splinePoints[i] + vector6 * zero4.x;
					}
					if (terrainDeformation && startPrefabScript != null && i < num8 && !flag8 && !startPrefabScript.isIConnector)
					{
						pos.y = OCQCDQCQOQ.OQOQQQQCQD(startPrefabIndent, oDDOCQCCDQIndent, a, pos);
						num9 = num22;
						if (OOQDQQOQCD[i] != 0f)
						{
							pos.y += zero4.y;
						}
					}
					else if (terrainDeformation && startPrefabScript != null && num22 - num9 < num14 - num9 && !flag8 && !startPrefabScript.isIConnector)
					{
						Vector3 p = pos;
						p.y = OCQCDQCQOQ.OQOQQQQCQD(startPrefabIndent, oDDOCQCCDQIndent, a, p);
						float t = (num22 - num9) / (num14 - num9);
						if (OOQDQQOQCD[i] != 0f)
						{
							p.y += zero4.y;
						}
						p.y = Mathf.Lerp(p.y, pos.y, t);
						pos.y = Mathf.Lerp(p.y, pos.y, Mathf.SmoothStep(0f, 1f, t));
					}
					if (terrainDeformation && endPrefabScript != null && i > num11 && !flag9 && !endPrefabScript.isIConnector)
					{
						pos.y = OCQCDQCQOQ.OQOQQQQCQD(startPrefabIndent2, oDDOCQCCDQIndent2, vector2, pos);
						if (OOQDQQOQCD[i] != 0f)
						{
							pos.y += zero4.y;
						}
					}
					else if (terrainDeformation && endPrefabScript != null && i >= endAdjustInt && !flag9 && !endPrefabScript.isIConnector)
					{
						if (j == 0)
						{
							num24 += num23;
						}
						Vector3 p2 = pos;
						p2.y = OCQCDQCQOQ.OQOQQQQCQD(startPrefabIndent2, oDDOCQCCDQIndent2, vector2, p2);
						float t = num24 / endAdjustDistance;
						if (OOQDQQOQCD[i] != 0f)
						{
							p2.y += zero4.y;
						}
						p2.y = Mathf.Lerp(pos.y, p2.y, t);
						pos.y = Mathf.Lerp(pos.y, p2.y, Mathf.SmoothStep(0f, 1f, t));
					}
					if (j == num15)
					{
						vector7 = pos;
						vector7.y -= 0.02f;
					}
					if (j == num16)
					{
						vector8 = pos;
						vector8.y -= 0.02f;
					}
					list5.Add(pos);
					if (j == num15)
					{
						soSplinePointsLeft[i] = pos;
						if (flag12)
						{
							markersExt[num30].rl = pos + vector6;
						}
					}
					if (j == num16)
					{
						soSplinePointsRight[i] = pos;
						if (flag12)
						{
							markersExt[num30].rr = pos - vector6;
						}
					}
					if (OOQDQQOQCD[i] == 0f)
					{
						pos.y += zero4.y;
					}
					if (snapVertices)
					{
						baseScript.OCCDCQCOQC(ref pos);
						pos.y += snapOffset + zero4.y;
					}
					vecs.Add(pos);
					list9.Add(customColor);
					if (flag12 || i == 0)
					{
						tmpMarkersExt[num30].roadShapeVecsGlobal.Add(pos);
					}
					list6.Add(zero4.y);
					if (!planarUVs || roadShapeMaterialInts[j] != num6)
					{
						list.Add(new Vector2(roadShapeUVs[j], num26));
						list8.Add(item: false);
					}
					else
					{
						list.Add(new Vector2(pos.x * uvTiling, pos.z * uvTiling));
						list8.Add(item: true);
					}
					if (uv4Type == 1)
					{
						list2.Add(new Vector2(roadShapeUVs[j], num40));
					}
					else
					{
						list2.Add(baseScript.GetTerrainUV(pos));
					}
					if (flag16)
					{
						vecs.Add(pos);
						list9.Add(customColor);
						if (!planarUVs || roadShapeMaterialInts[j] != num6)
						{
							list.Add(new Vector2(roadShapeUVs2[j], num26));
							list8.Add(item: false);
						}
						else
						{
							list.Add(new Vector2(pos.x * uvTiling, pos.z * uvTiling));
							list8.Add(item: true);
						}
						if (uv4Type == 1)
						{
							list2.Add(new Vector2(roadShapeUVs[j], num40));
						}
						else
						{
							list2.Add(baseScript.GetTerrainUV(pos));
						}
					}
					if (i < splinePoints.Count - 1 && j < roadShape.Count - 1)
					{
						flag2 = true;
						if (!flag3)
						{
							flag2 = false;
							if (!array3[j + num43] || !array3[j + 1 + num43])
							{
								if (i == 0)
								{
									array[j + num43] = -1;
									array[j + 1 + num43] = -1;
									if (flag16)
									{
										array[j + num43 + 1] = -1;
										array[j + 1 + num43 + 1] = -1;
									}
								}
								if (!array3[j + num43])
								{
									Vector3 pCheck = splinePoints[i + 1] + vector * zero4.x;
									if (ERCrossingPrefabs.OOOOCDQQOC(ODODCOOOCD, OOOQOODOCD, pCheck))
									{
										array3[j + num43] = true;
									}
								}
								if (!array3[j + 1 + num43])
								{
									Vector3 pCheck = splinePoints[i + 1] + vector * roadShape[j + 1].x;
									if (ERCrossingPrefabs.OOOOCDQQOC(ODODCOOOCD, OOOQOODOCD, pCheck))
									{
										array3[j + 1 + num43] = true;
									}
								}
								if (array3[j + num43] && array3[j + 1 + num43])
								{
									flag2 = true;
									if (array[j + num43] == -1)
									{
										array[j + num43] = i;
										if (flag16)
										{
											array[j + num43 + 1] = i;
										}
									}
									if (array[j + 1 + num43] == -1)
									{
										array[j + 1 + num43] = i;
										if (flag16)
										{
											array[j + 1 + num43 + 1] = i;
										}
									}
								}
							}
							if (j == roadShape.Count - 2 && j + 1 + num43 < num33 - 1 && array3[array3.Length - 2])
							{
								array3[array3.Length - 1] = true;
								array[array.Length - 1] = array[array.Length - 2];
							}
							flag2 = true;
						}
						if (endPrefabScript != null && i > splinePoints.Count - num20)
						{
							flag2 = true;
							Vector3 pCheck = splinePoints[i] + vector6 * roadShape[j].x;
							if (ERCrossingPrefabs.OOOOCDQQOC(endRight, endLeft, pCheck))
							{
								pCheck = splinePoints[i] + vector6 * roadShape[j + 1].x;
								if (ERCrossingPrefabs.OOOOCDQQOC(endRight, endLeft, pCheck))
								{
									flag2 = true;
								}
							}
						}
						num21 = roadShapeMaterialInts[j];
						if (j < roadShapeMaterialInts.Count - 2 && num21 != roadShapeMaterialInts[j + 1])
						{
							flag2 = false;
						}
						if (doConnectionTri.Count > 0 && !doConnectionTri[j])
						{
							flag2 = false;
						}
						if (flag16)
						{
							num43++;
						}
						if (flag2)
						{
							if (!flipNormals)
							{
								tris[num21].Add(i * num33 + j + num43);
								tris[num21].Add((i + 1) * num33 + j + 1 + num43);
								tris[num21].Add(i * num33 + j + 1 + num43);
								tris[num21].Add((i + 1) * num33 + j + num43);
								tris[num21].Add((i + 1) * num33 + j + 1 + num43);
								tris[num21].Add(i * num33 + j + num43);
							}
							else
							{
								tris[num21].Add(i * num33 + j + num43);
								tris[num21].Add(i * num33 + j + 1 + num43);
								tris[num21].Add((i + 1) * num33 + j + 1 + num43);
								tris[num21].Add((i + 1) * num33 + j + num43);
								tris[num21].Add(i * num33 + j + num43);
								tris[num21].Add((i + 1) * num33 + j + 1 + num43);
							}
						}
					}
					if (flag3)
					{
						continue;
					}
					flag3 = true;
					for (int k = 0; k < array3.Length; k++)
					{
						if (!array3[k])
						{
							flag3 = false;
						}
					}
				}
				if (flag12 || i == 0)
				{
					tmpMarkersExt[num30].perpDir = vector6;
					tmpMarkersExt[num30].perpDirRotated = (vector7 - vector8).normalized;
				}
				soSplinePoints[i] = Vector3.Lerp(soSplinePointsLeft[i], soSplinePointsRight[i], leftToCenterPerc);
				if (startPrefabScript != null && num25 < num7 * 6f)
				{
					if (startbendLeftRight == -1)
					{
						if (i > 0)
						{
							num25 += Vector3.Distance(a2, vector7);
						}
						a2 = vector7;
					}
					else
					{
						if (i > 0)
						{
							num25 += Vector3.Distance(a2, vector8);
						}
						a2 = vector8;
					}
				}
				Vector3 normalized = (vector7 - vector8).normalized;
				if (flag12 && num38 > 0f)
				{
					Vector3 pos2 = vector7 + normalized * (leftIndents[i] + leftSurrounding[i]);
					pos2 += -vector5 * num38;
					baseScript.OCCDCQCOQC(ref pos2);
					surfaceVecs[surfaceVecs.Count - 5] = pos2;
					leftSurroundingVecs[leftSurroundingVecs.Count - 1] = pos2;
					pos2 = vector7 + normalized * leftIndents[i];
					pos2 += -vector5 * num38;
					baseScript.OCCDCQCOQC(ref pos2);
					surfaceVecs[surfaceVecs.Count - 4] = pos2;
					leftIndentVecs[leftIndentVecs.Count - 1] = pos2;
					leftIndentVecsSV[leftIndentVecsSV.Count - 1] = pos2;
					pos2 = splinePoints[i];
					pos2 += -vector5 * num38;
					baseScript.OCCDCQCOQC(ref pos2);
					surfaceVecs[surfaceVecs.Count - 3] = pos2;
					pos2 = vector8 + -normalized * rightIndents[i];
					pos2 += -vector5 * num38;
					baseScript.OCCDCQCOQC(ref pos2);
					surfaceVecs[surfaceVecs.Count - 2] = pos2;
					rightIndentVecs[rightIndentVecs.Count - 1] = pos2;
					rightIndentVecsSV[rightIndentVecsSV.Count - 1] = pos2;
					pos2 = vector8 + -normalized * (rightIndents[i] + rightSurrounding[i]);
					pos2 += -vector5 * num38;
					baseScript.OCCDCQCOQC(ref pos2);
					surfaceVecs[surfaceVecs.Count - 1] = pos2;
					rightSurroundingVecs[rightSurroundingVecs.Count - 1] = pos2;
					num38 = 0f;
				}
				pos = vector7 + normalized * (leftIndents[i] + leftSurrounding[i]);
				if (num36 > 0f)
				{
					pos += vector5 * num36;
				}
				else if (num38 > 0f)
				{
					pos += -vector5 * num38;
				}
				baseScript.OCCDCQCOQC(ref pos);
				surfaceVecs.Add(pos);
				list3.Add(new Vector2(0f, 0f));
				leftSurroundingVecs.Add(pos);
				pos = vector7 + normalized * leftIndents[i];
				if (tmpMarkersExt[markerInts[i]].leftIndentAlignment == 1)
				{
					baseScript.OCCDCQCOQC(ref pos);
				}
				else if (tmpMarkersExt[markerInts[i]].leftIndentAlignment == 2)
				{
					pos.y = surfaceVecs[surfaceVecs.Count - 1].y;
				}
				else if (tmpMarkersExt[markerInts[i]].leftIndentAlignment != 3)
				{
				}
				if (num36 > 0f)
				{
					pos += vector5 * num36;
					baseScript.OCCDCQCOQC(ref pos);
				}
				else if (num38 > 0f)
				{
					pos += -vector5 * num38;
					baseScript.OCCDCQCOQC(ref pos);
				}
				surfaceVecs.Add(pos);
				list3.Add(new Vector2(0f, 1f));
				leftIndentVecs.Add(pos);
				leftIndentVecsSV.Add(pos);
				if (pos.y < baseScript.terrainY - 0.02f && terrainDeformation)
				{
					vecsBelowTerrain.Add(soSplinePointsLeft[i]);
				}
				pos = ((tmpMarkersExt[markerInts[i]].leftIndentAlignment != 0 && tmpMarkersExt[markerInts[i]].rightIndentAlignment == 0) ? Vector3.Lerp(vector7, vector8, num35) : ((tmpMarkersExt[markerInts[i]].leftIndentAlignment != 0 || tmpMarkersExt[markerInts[i]].rightIndentAlignment == 0) ? Vector3.Lerp(vector7, vector8, 0.5f) : Vector3.Lerp(vector8, vector7, num35)));
				if (num36 > 0f)
				{
					pos += vector5 * num36;
					baseScript.OCCDCQCOQC(ref pos);
				}
				else if (num38 > 0f)
				{
					pos += -vector5 * num38;
					baseScript.OCCDCQCOQC(ref pos);
				}
				surfaceVecs.Add(pos);
				list3.Add(new Vector2(0f, 1f));
				middleIndentVecs.Add(pos);
				Vector3 pos3;
				pos = (pos3 = vector8 + -normalized * rightIndents[i]);
				if (num36 > 0f)
				{
					pos += vector5 * num36;
					baseScript.OCCDCQCOQC(ref pos);
				}
				else if (num38 > 0f)
				{
					pos += -vector5 * num38;
					baseScript.OCCDCQCOQC(ref pos);
				}
				surfaceVecs.Add(pos);
				list3.Add(new Vector2(0f, 1f));
				rightIndentVecs.Add(pos + -normalized);
				rightIndentVecsSV.Add(pos);
				if (pos.y < baseScript.terrainY - 0.02f && terrainDeformation)
				{
					vecsBelowTerrain.Add(soSplinePointsRight[i]);
				}
				pos = vector8 + -normalized * (rightIndents[i] + rightSurrounding[i]);
				if (num36 > 0f)
				{
					pos += vector5 * num36;
				}
				else if (num38 > 0f)
				{
					pos += -vector5 * num38;
				}
				baseScript.OCCDCQCOQC(ref pos);
				surfaceVecs.Add(pos);
				list3.Add(new Vector2(0f, 0f));
				rightSurroundingVecs.Add(pos);
				if (tmpMarkersExt[markerInts[i]].rightIndentAlignment == 1)
				{
					baseScript.OCCDCQCOQC(ref pos3);
					surfaceVecs[surfaceVecs.Count - 2] = pos3;
				}
				else if (tmpMarkersExt[markerInts[i]].rightIndentAlignment == 2)
				{
					pos3.y = pos.y;
					surfaceVecs[surfaceVecs.Count - 2] = pos3;
				}
				else if (tmpMarkersExt[markerInts[i]].rightIndentAlignment != 3)
				{
				}
				if (!startSurfacesSafe && !flag8)
				{
					if (i == 0 && startPrefabScript.doTerrainDeformation)
					{
						surfaceVecs[4] = transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].leftSurroundingV3);
						surfaceVecs[0] = transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].rightSurroundingV3);
						surfaceVecs[3] = transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].leftIndentV3);
						surfaceVecs[1] = transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].rightIndentV3);
						surfaceVecs[2] = Vector3.Lerp(surfaceVecs[1], surfaceVecs[3], 0.5f);
						leftSurroundingVecs[0] = surfaceVecs[4];
						leftIndentVecs[0] = surfaceVecs[3];
						middleIndentVecs[0] = surfaceVecs[2];
						rightIndentVecs[0] = surfaceVecs[1];
						rightSurroundingVecs[0] = surfaceVecs[0];
					}
					else if (terrainDeformation && startPrefabScript.doTerrainDeformation)
					{
						ODQCQOODDO.OCOCQQCCCC(this, ref surfaceVecs, startPrefabScript, ref startSurfacesSafe, num22, baseScript.minIndent);
					}
				}
				if (i == 0)
				{
					sv1 = vector7;
					sv2 = vector8;
					sv1 = vector7 + vector6 * indent;
					sv2 = vector8 + -vector6 * indent;
				}
				treeVecs.Add(soSplinePointsLeft[i] + vector6 * baseScript.treeDistance);
				treeVecs.Add(soSplinePointsRight[i] + -vector6 * baseScript.treeDistance);
				detailVecs.Add(soSplinePointsLeft[i] + vector6 * baseScript.detailDistance - baseScript.detailOffsetVec);
				detailVecs.Add(soSplinePointsRight[i] + -vector6 * baseScript.detailDistance - baseScript.detailOffsetVec);
				if (i < splinePoints.Count - 1 && !flag10)
				{
					vegetationTris.Add(i * 2);
					vegetationTris.Add((i + 1) * 2 + 1);
					vegetationTris.Add(i * 2 + 1);
					vegetationTris.Add((i + 1) * 2);
					vegetationTris.Add((i + 1) * 2 + 1);
					vegetationTris.Add(i * 2);
				}
			}
			Vector2[] array5 = list.ToArray();
			Vector2[] collection = list2.ToArray();
			float num44 = Mathf.Round(array5[array5.Length - 1].y) / array5[array5.Length - num33].y;
			if (totalDistance > 5f && baseScript.clampUVs)
			{
				for (int i = 0; i < array5.Length - 1; i += num33)
				{
					for (int j = 0; j < num33; j++)
					{
						if (list8[i + j])
						{
							continue;
						}
						if (!planarUVs)
						{
							if (j == 0)
							{
								array5[i + j].y = array5[i].y * num44;
							}
							else
							{
								array5[i + j].y = array5[i].y;
							}
						}
						else
						{
							array5[i + j].y = array5[i + j].y * num44;
						}
					}
				}
			}
			List<int> list10 = new List<int>();
			List<int> list11 = new List<int>();
			if (startPrefabScript != null)
			{
				if (startPrefabScript.meshVecs.Length == 0)
				{
				}
				int num45 = vecs.Count - 1;
				int num46 = num33;
				bool flag17 = false;
				if (ERCrossingPrefabs.OOOOCDQQOC(vecs[num46], vecs[0], vecs[num46 * 2]))
				{
					flag17 = true;
				}
				List<int> connectionVecInts = startPrefabScript.crossingElements[startConnectionSegment].connectionVecInts;
				List<int> fullConnectionVecInts = startPrefabScript.crossingElements[startConnectionSegment].fullConnectionVecInts;
				List<Vector3> list12 = new List<Vector3>();
				List<Vector3> list13 = new List<Vector3>();
				List<int> list14 = new List<int>();
				for (int i = 0; i < num33; i++)
				{
					if (i + array[i] * num33 < 0)
					{
						Debug.LogError(base.gameObject.name + ": The angle with the crossing is too sharp " + startPrefabScript);
						flag15 = false;
						break;
					}
					bool flag18 = false;
					if (startPrefabScript.isIConnector && endPrefabScript != null && endPrefabScript.isCustomPrefab)
					{
						flag18 = true;
					}
					Vector3 value = ((startPrefabScript.isCustomPrefab || flag18) ? startPrefabScript.transform.TransformPoint(startPrefabScript.tmpMeshVecs[connectionVecInts[connectionVecInts.Count - roadShapeIntsStart[i - list7[i]] - 1]]) : startPrefabScript.transform.TransformPoint(startPrefabScript.tmpFullMeshVecs[connectionVecInts[connectionVecInts.Count - roadShapeIntsStart[i] - 1]]));
					if (fullConnectionVecInts.Count - i - 1 >= 0)
					{
						list11.Add(fullConnectionVecInts[fullConnectionVecInts.Count - i - 1]);
					}
					else
					{
						flag13 = false;
					}
					vecs[i + array[i] * num33] = value;
					list10.Add(i + array[i] * num33);
					if (!startPrefabScript.crossingElements[startConnectionSegment].rotationPriority)
					{
						float num47 = roadWidth / Mathf.Tan(startAngle * ((float)Math.PI / 180f));
						float num48 = (flag17 ? (10f + (1f - nodeDistance[i - list7[i]]) * num47 * 2f) : (10f + nodeDistance[i - list7[i]] * num47 * 2f));
						float num4 = 0f;
						int num49 = 1;
						Vector3 pos3;
						Vector3 pos = (pos3 = vecs[i + array[i] * num33]);
						while (num4 < num48)
						{
							Vector3 vector9 = vecs[i + (array[i] + num49) * num33];
							num4 += Vector3.Distance(pos3, vector9);
							Vector3 normalized2 = (vector9 - pos).normalized;
							Vector3 vector10 = Vector3.Lerp(-startDir, normalized2, num4 / num48);
							Vector3 vector11 = pos + vector10 * num4;
							pos3 = vector9;
							if (i == num31)
							{
								Vector3 item = vecs[i + (array[i] + num49) * num33];
								item.y -= y;
								list12.Add(item);
								list14.Add(array[i] + num49);
							}
							if (i == num32)
							{
								Vector3 item = vecs[i + (array[i] + num49) * num33];
								item.y -= y2;
								list13.Add(item);
							}
							num49++;
							if (i + (array[i] + num49) * num33 > vecs.Count - 1)
							{
								break;
							}
						}
					}
					if (!list8[i + array[i] * num33])
					{
						float num50 = Vector3.Distance(vecs[i + array[i] * num33], vecs[i + num33 + array[i] * num33]);
						float y3 = array5[i + num33 + array[i] * num33].y - num50 / num27;
						array5[i + array[i] * num33].y = y3;
						array5[i + array[i] * num33].y = 0f;
					}
					else
					{
						value = vecs[i + array[i] * num33];
						ref Vector2 reference = ref array5[i + array[i] * num33];
						reference = new Vector2(value.x * uvTiling, value.z * uvTiling);
					}
				}
				int count2 = list12.Count;
				if (list13.Count < list12.Count)
				{
					count2 = list13.Count;
				}
				for (int i = 0; i < count2; i++)
				{
					soSplinePoints[list14[i]] = Vector3.Lerp(list12[i], list13[i], leftToCenterPerc);
					soSplinePointsLeft[list14[i]] = list12[i];
					soSplinePointsRight[list14[i]] = list13[i];
				}
				List<Vector3> list15 = soSplinePointsLeft;
				List<Vector3> list16 = vecs;
				int index = num31;
				_ = array[0];
				list15[0] = list16[index];
				if (roadShape[num15].y != 0f)
				{
					Vector3 value2 = soSplinePointsLeft[0];
					value2.y -= roadShape[num15].y;
					soSplinePointsLeft[0] = value2;
				}
				if (num32 + array[num32] * num33 >= 0)
				{
					soSplinePointsRight[0] = vecs[num32 + array[num32] * num33];
					if (roadShape[num16].y != 0f)
					{
						Vector3 value2 = soSplinePointsRight[0];
						value2.y -= roadShape[num16].y;
						soSplinePointsRight[0] = value2;
					}
					soSplinePoints[0] = Vector3.Lerp(soSplinePointsLeft[0], soSplinePointsRight[0], leftToCenterPerc);
				}
			}
			List<int> list17 = new List<int>();
			List<int> list18 = new List<int>();
			if (endPrefabScript != null)
			{
				if (endPrefabScript.meshVecs.Length == 0)
				{
					endPrefabScript.OODDCDQQDO();
				}
				int num45 = vecs.Count - 1;
				int num46 = num33;
				bool flag17 = false;
				if (ERCrossingPrefabs.OOOOCDQQOC(vecs[num45], vecs[num45 - num46], vecs[num45 - num46 * 2]))
				{
					flag17 = true;
				}
				int num51 = vecs.Count - num33;
				List<int> connectionVecInts = endPrefabScript.crossingElements[endConnectionSegment].connectionVecInts;
				List<int> fullConnectionVecInts = endPrefabScript.crossingElements[endConnectionSegment].fullConnectionVecInts;
				List<Vector3> list12 = new List<Vector3>();
				List<Vector3> list13 = new List<Vector3>();
				List<int> list14 = new List<int>();
				for (int i = 0; i < num33; i++)
				{
					if (!endPrefabScript.isCustomPrefab && !endPrefabScript.isIConnector)
					{
						vecs[num51 + i] = endPrefabScript.transform.TransformPoint(endPrefabScript.tmpFullMeshVecs[connectionVecInts[roadShapeIntsEnd[i]]]);
					}
					else
					{
						vecs[num51 + i] = endPrefabScript.transform.TransformPoint(endPrefabScript.tmpMeshVecs[connectionVecInts[roadShapeIntsEnd[i - list7[i]]]]);
					}
					list17.Add(num51 + i);
					if (fullConnectionVecInts.Count > i)
					{
						list18.Add(fullConnectionVecInts[i]);
					}
					else
					{
						flag14 = false;
					}
					if (!endPrefabScript.crossingElements[endConnectionSegment].rotationPriority)
					{
						float num47 = roadWidth / Mathf.Tan(endAngle * ((float)Math.PI / 180f));
						float num48 = (flag17 ? (10f + (1f - nodeDistance[i - list7[i]]) * num47 * 2f) : (3f + nodeDistance[i - list7[i]] * num47 * 2f));
						float num4 = 0f;
						int num49 = 0;
						Vector3 pos3;
						Vector3 pos = (pos3 = vecs[num51 + i - num49 * num33]);
						num49 = 1;
						while (num4 < num48 && num51 + i - num49 * num33 >= 0)
						{
							Vector3 vector9 = vecs[num51 + i - num49 * num33];
							num4 += Vector3.Distance(pos3, vector9);
							Vector3 normalized2 = (vector9 - pos).normalized;
							Vector3 vector10 = Vector3.Lerp(-endDir, normalized2, num4 / num48);
							Vector3 vector11 = pos + vector10 * num4;
							pos3 = vector9;
							if (i == num31)
							{
								Vector3 item = vecs[num51 + i - num49 * num33];
								item.y -= y;
								list12.Add(item);
								list14.Add(splinePoints.Count - 1 - num49);
							}
							if (i == num32)
							{
								Vector3 item = vecs[num51 + i - num49 * num33];
								item.y -= y2;
								list13.Add(item);
							}
							num49++;
							if (num51 + i - num49 * num33 > vecs.Count - 1)
							{
								break;
							}
						}
					}
					if (!list8[num51 + i])
					{
						float num50 = Vector3.Distance(vecs[num51 + i], vecs[num51 + i - num33]);
						float y3 = array5[num51 + i - num33].y + num50 / num27;
						array5[num51 + i].y = y3;
					}
					else
					{
						Vector3 value = vecs[num51 + i];
						ref Vector2 reference2 = ref array5[num51 + i];
						reference2 = new Vector2(value.x * uvTiling, value.z * uvTiling);
					}
				}
				if (endPrefabScript.isIConnector)
				{
					num44 = 1f / array5[array5.Length - 1].y * Mathf.Round(array5[array5.Length - 1].y);
					num44 = Mathf.Round(array5[array5.Length - 1].y) / array5[array5.Length - num33].y;
					if (totalDistance > 5f && baseScript.clampUVs)
					{
						for (int i = 0; i < array5.Length; i += num33)
						{
							for (int j = 0; j < num33; j++)
							{
								if (list8[i + j])
								{
									continue;
								}
								if (!planarUVs)
								{
									if (j == 0)
									{
										array5[i + j].y = array5[i].y * num44;
									}
									else
									{
										array5[i + j].y = array5[i].y;
									}
								}
								else
								{
									array5[i + j].y = array5[i + j].y * num44;
								}
							}
						}
					}
				}
				if (leftToCenterPerc == 0f)
				{
					leftToCenterPerc = OQOOOODDDO.GetleftToCenterPerc(roadShape, num15, num16);
				}
				int count2 = list12.Count;
				if (list13.Count < list12.Count)
				{
					count2 = list13.Count;
				}
				for (int i = 0; i < count2; i++)
				{
					soSplinePoints[list14[i]] = Vector3.Lerp(list12[i], list13[i], leftToCenterPerc);
					soSplinePointsLeft[list14[i]] = list12[i];
					soSplinePointsRight[list14[i]] = list13[i];
				}
				soSplinePointsLeft[soSplinePointsLeft.Count - 1] = vecs[num51 + num31];
				soSplinePointsRight[soSplinePointsRight.Count - 1] = vecs[num51 + num32];
				if (roadShape[num15].y != 0f)
				{
					Vector3 value2 = soSplinePointsLeft[soSplinePointsLeft.Count - 1];
					value2.y -= roadShape[num15].y;
					soSplinePointsLeft[soSplinePointsLeft.Count - 1] = value2;
				}
				if (roadShape[num16].y != 0f)
				{
					Vector3 value2 = soSplinePointsRight[soSplinePointsRight.Count - 1];
					value2.y -= roadShape[num16].y;
					soSplinePointsRight[soSplinePointsRight.Count - 1] = value2;
				}
				soSplinePoints[soSplinePoints.Count - 1] = Vector3.Lerp(soSplinePointsLeft[soSplinePointsLeft.Count - 1], soSplinePointsRight[soSplinePointsRight.Count - 1], leftToCenterPerc);
			}
			Color[] array6 = new Color[vecs.Count];
			for (int i = 0; i < array6.Length; i++)
			{
				ref Color reference3 = ref array6[i];
				reference3 = Color.white;
			}
			if (closedTrack)
			{
				for (int i = 0; i < num33; i++)
				{
					vecs[vecs.Count - num33 + i] = vecs[i];
				}
			}
			else
			{
				if ((double)fadeInDistance > 0.5)
				{
					float num4 = 0f;
					float a5 = 0f;
					int num49 = 0;
					while (num4 < fadeInDistance)
					{
						for (int i = 0; i < num33; i++)
						{
							array6[num49 * num33 + i].a = a5;
						}
						if (vecs.Count > (num49 + 2) * num33)
						{
							num4 += faceDistance;
							a5 = num4 / fadeInDistance;
							a5 *= a5;
							num49++;
							continue;
						}
						break;
					}
				}
				if ((double)fadeOutDistance > 0.5)
				{
					if (array6 == null)
					{
					}
					float num4 = 0f;
					float a5 = 0f;
					int num49 = 0;
					int count3 = vecs.Count;
					while (num4 < fadeOutDistance)
					{
						for (int i = 0; i < num33; i++)
						{
							array6[count3 - 1 - num49 * num33 - i].a = a5;
						}
						if (vecs.Count > (num49 + 2) * num33)
						{
							num4 += faceDistance;
							a5 = num4 / fadeOutDistance;
							a5 *= a5;
							num49++;
							continue;
						}
						break;
					}
				}
			}
			if (tCrossingConnected)
			{
				float num52 = totalDistance;
				totalDistance = 0f;
				for (int i = 1; i < soSplinePoints.Count; i++)
				{
					totalDistance += Vector3.Distance(soSplinePoints[i - 1], soSplinePoints[i]);
				}
				if (totalDistance < 1000f)
				{
					totalDistanceString = totalDistance.ToString("N2") + " m";
				}
				else
				{
					totalDistanceString = (totalDistance / 1000f).ToString("N3") + " km";
				}
			}
			meshVecs.Clear();
			meshVecs.AddRange(vecs);
			meshUVs.Clear();
			meshUVs = new List<Vector2>(array5);
			meshUVs2.Clear();
			meshUVs2 = new List<Vector2>(collection);
			if (roadMaterials == null)
			{
				roadMaterials = new List<Material>(base.gameObject.GetComponent<MeshRenderer>().sharedMaterials).ToArray();
			}
			else if (roadMaterials[0] == null)
			{
				roadMaterials = new List<Material>(base.gameObject.GetComponent<MeshRenderer>().sharedMaterials).ToArray();
			}
			if (base.gameObject.GetComponent<MeshRenderer>().sharedMaterials != null)
			{
				int num53 = 0;
				Material[] sharedMaterials = base.gameObject.GetComponent<MeshRenderer>().sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (roadMaterials.Length > num53 && material != roadMaterials[num53])
					{
						roadMaterials[num53] = material;
					}
					num53++;
				}
			}
			Material[] materialsList = new List<Material>(roadMaterials).ToArray();
			if (!isSideObject)
			{
				ODCOCCDCQC.ODCDDCDOOQ(baseScript, markersExt, ref soSplinePointsLeft, ref soSplinePointsRight);
				if (roadMaterials == null)
				{
					roadMaterials = new List<Material>(base.gameObject.GetComponent<MeshRenderer>().sharedMaterials).ToArray();
				}
				else if (roadMaterials[0] == null)
				{
					roadMaterials = new List<Material>(base.gameObject.GetComponent<MeshRenderer>().sharedMaterials).ToArray();
				}
				ODCOCCDCQC.OCDCQQCOOQ(baseScript, markersExt, ref vecs, ref meshUVs, ref meshUVs2, ref tris, ref materialsList);
			}
			if (uv4Type == 1 && (double)Mathf.Abs(num41 - meshUVs2[meshUVs2.Count - 1].y) > 0.01)
			{
				float num54 = num41 / meshUVs2[meshUVs2.Count - 1].y;
				for (int i = 0; i < meshUVs2.Count; i++)
				{
					meshUVs2[i] = new Vector2(meshUVs2[i].x, meshUVs2[i].y * num54);
				}
			}
			if (vecs.Count < 65000)
			{
				mesh.Clear();
				mesh.vertices = vecs.ToArray();
				mesh.uv = meshUVs.ToArray();
				mesh.uv4 = meshUVs2.ToArray();
				if (fadeInDistance == 0f && fadeOutDistance == 0f)
				{
					mesh.colors = list9.ToArray();
				}
				else if (array6.Length == vecs.Count)
				{
					mesh.colors = array6;
				}
				else
				{
					mesh.colors = new Color[vecs.Count];
					Debug.Log("Road: " + base.gameObject.name + " , colors array is out of bounds ");
				}
				mesh.tangents = new Vector4[vecs.Count];
				mesh.subMeshCount = tris.Count;
				trisStats = 0;
				for (int i = 0; i < tris.Count; i++)
				{
					mesh.SetTriangles(tris[i].ToArray(), i);
					trisStats += tris[i].Count;
				}
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				OOOOOQQQQQ(mesh);
				OCQQDQQCQQ.OOCCQOQQQC(mesh);
				if (closedTrack)
				{
					int num3 = vecs.Count - 1;
					int count4 = roadShape.Count;
					for (int i = 0; i < count4; i++)
					{
						ref Vector3 reference4 = ref mesh.normals[i];
						ref Vector3 reference5 = ref mesh.normals[num3 - count4 + i];
						reference4 = (reference5 = Vector3.Lerp(mesh.normals[i], mesh.normals[num3 - count4 + i], 0.5f));
					}
				}
				if (!closedTrack && ((bool)startPrefabScript || (bool)endPrefabScript))
				{
					mesh.normals = AdjustNormals(mesh.normals);
				}
				if ((bool)startPrefabScript && flag6 && flag13)
				{
					AdjustPrefabNormals(list10, list11, mesh.normals, startPrefabScript.gameObject, mesh.vertices);
				}
				if ((bool)endPrefabScript && flag7 && flag14)
				{
					AdjustPrefabNormals(list17, list18, mesh.normals, endPrefabScript.gameObject, mesh.vertices);
				}
				vertsStats = vecs.Count;
				trisStats /= 3;
				if (hasMeshCollider && flag15)
				{
					base.gameObject.GetComponent<MeshCollider>().sharedMesh = null;
					base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
				}
				else if (hasMeshCollider)
				{
					base.gameObject.GetComponent<MeshCollider>().sharedMesh = null;
				}
				base.gameObject.GetComponent<MeshRenderer>().sharedMaterials = materialsList;
				if ((bool)base.gameObject.GetComponent<MeshRenderer>())
				{
					base.gameObject.GetComponent<MeshRenderer>().enabled = true;
				}
				if ((bool)base.gameObject.GetComponent<MeshCollider>())
				{
					base.gameObject.GetComponent<MeshCollider>().enabled = true;
				}
				testmesh = mesh;
			}
			else
			{
				Debug.Log("The new road mesh exceeds Unity’s vertices limit of 65.000, updating the mesh is aborted");
			}
			num22 = 0f;
			if ((bool)endPrefabScript && !flag9)
			{
				for (int m = 0; (!surfacesSafe || m < surfaceVecs.Count - 5) && surfaceVecs.Count - m - 6 >= 0; m += 5)
				{
					if (!surfacesSafe && terrainDeformation && endPrefabScript.doTerrainDeformation)
					{
						ODQCQOODDO.OCQDQDDCQO(this, ref surfaceVecs, endPrefabScript, m, ref surfacesSafe, num22, baseScript.minIndent);
					}
					num22 += Vector3.Distance(surfaceVecs[surfaceVecs.Count - 2 - m], surfaceVecs[surfaceVecs.Count - 2 - m - 5]);
				}
			}
			if (closedTrack)
			{
				surfaceVecs[surfaceVecs.Count - 5] = surfaceVecs[0];
				surfaceVecs[surfaceVecs.Count - 4] = surfaceVecs[1];
				surfaceVecs[surfaceVecs.Count - 3] = surfaceVecs[2];
				surfaceVecs[surfaceVecs.Count - 2] = surfaceVecs[3];
				surfaceVecs[surfaceVecs.Count - 1] = surfaceVecs[4];
				leftSurroundingVecs[leftSurroundingVecs.Count - 1] = leftSurroundingVecs[0];
				leftIndentVecs[leftIndentVecs.Count - 1] = leftIndentVecs[0];
				middleIndentVecs[middleIndentVecs.Count - 1] = middleIndentVecs[0];
				rightIndentVecs[rightIndentVecs.Count - 1] = rightIndentVecs[0];
				rightSurroundingVecs[rightSurroundingVecs.Count - 1] = rightSurroundingVecs[0];
				if (endDecalPrefab != null)
				{
					UnityEngine.Object.DestroyImmediate(endDecalPrefab);
				}
			}
			else
			{
				if (endDecalPrefab == null && endDecalID != -1)
				{
					QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType);
					if (roadTypeElByID != null)
					{
						endDecal = ERDecal.OCOQQQDOOQ(endDecalID, roadTypeElByID.decalPresets);
						if (endDecal != null && endDecal.decalPrefab != null)
						{
							OODODQCCCO(endDecal, ref endDecalPrefab, "_ERDecal_End");
						}
					}
				}
				if (endDecalPrefab != null)
				{
					ODDQQOCOCO(1);
					OCOCDQDQOQ(endDecalPrefab, soSplinePoints.Count - 1);
				}
			}
			if (startDecalPrefab == null && startDecalID != -1)
			{
				QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType);
				if (roadTypeElByID != null)
				{
					startDecal = ERDecal.OCOQQQDOOQ(startDecalID, roadTypeElByID.decalPresets);
					if (startDecal != null && startDecal.decalPrefab != null)
					{
						OODODQCCCO(startDecal, ref startDecalPrefab, "_ERDecal_Start");
					}
				}
			}
			if (startDecalPrefab != null)
			{
				ODDQQOCOCO(0);
				OCOCDQDQOQ(startDecalPrefab, 0);
			}
			if (markersExt.Count > 2)
			{
				doSurroundingSurfaces = true;
			}
			if (doSurroundingSurfaces)
			{
				OOCCDQQODC(surfaceVecs, list3, splinePoints.Count, list4, firstDir, vector5, indent, surrounding);
			}
			insertSplinePoints.Clear();
			insertSplinePoints.AddRange(splinePoints);
			for (int i = 0; i < markersExt.Count; i++)
			{
				if (markersExt[i].controlTypeTmp == 3)
				{
					markersExt[i].controlType = 3;
					markersExt[i].controlTypeTmp = 0;
				}
			}
			if (lastForward == Vector3.zero)
			{
				lastForward = (soSplinePoints[soSplinePoints.Count - 1] - soSplinePoints[soSplinePoints.Count - 2]).normalized;
			}
			if (startPrefabScript != null)
			{
				Vector3 value3 = leftSurroundingVecs[0];
				leftSurroundingVecs[0] = rightSurroundingVecs[0];
				rightSurroundingVecs[0] = value3;
			}
			roadUpdate = false;
		}

		public void OOOOOQQQQQ(Mesh m)
		{
			if (m != null)
			{
				bounds = m.bounds;
			}
			else
			{
				bounds = default(Bounds);
				foreach (ERMarkerExt item in markersExt)
				{
					bounds.Encapsulate(item.position);
				}
			}
			bounds.Expand(baseScript.markerDistance);
			Vector3 min = bounds.min;
			min.y = -1000000f;
			bounds.min = min;
			min = bounds.max;
			min.y = 10000000f;
			bounds.max = min;
		}

		public void OODODQCCCO(ERDecal decal, ref GameObject decalPrefab, string name)
		{
			decalPrefab = UnityEngine.Object.Instantiate(decal.decalPrefab);
			decalPrefab.name = decal.decalPrefab.name + name;
			decalPrefab.transform.parent = base.transform;
			decalPrefab.transform.localScale *= decal.scale;
		}

		public float OQDQQDQQOO(ERDecal decal, float roadWidth)
		{
			return 1f;
		}

		public void ODDQCQOCDD(string type)
		{
			List<GameObject> list = new List<GameObject>();
			foreach (Transform item in base.transform)
			{
				if (item.name.IndexOf("_ERDecal_" + type) != -1)
				{
					list.Add(item.gameObject);
				}
			}
			foreach (GameObject item2 in list)
			{
				UnityEngine.Object.DestroyImmediate(item2);
			}
			QDQDOOQQDQODD roadTypeElByID;
			ERDecal eRDecal;
			if (startDecalPrefab == null && startDecalID != -1)
			{
				roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType);
				if (roadTypeElByID != null)
				{
					eRDecal = ERDecal.OCOQQQDOOQ(startDecalID, roadTypeElByID.decalPresets);
					if (eRDecal != null && eRDecal.decalPrefab != null)
					{
						OODODQCCCO(eRDecal, ref startDecalPrefab, "_ERDecal_Start");
					}
					OCOCDQDQOQ(startDecalPrefab, 0);
				}
			}
			if (!(endDecalPrefab == null) || endDecalID == -1)
			{
				return;
			}
			roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType);
			if (roadTypeElByID == null)
			{
				return;
			}
			eRDecal = ERDecal.OCOQQQDOOQ(endDecalID, roadTypeElByID.decalPresets);
			if (eRDecal != null)
			{
				if (eRDecal.decalPrefab != null)
				{
					OODODQCCCO(eRDecal, ref endDecalPrefab, "_ERDecal_End");
				}
				OCOCDQDQOQ(endDecalPrefab, soSplinePoints.Count - 1);
			}
		}

		public void OCOCDQDQOQ(GameObject decal, int index)
		{
			int index2 = 0;
			int num = 1;
			bool flag = false;
			int num2 = 0;
			ERDecal eRDecal = null;
			if (index != 0)
			{
				num = -1;
				index2 = markersExt.Count - 1;
				num2 = endDecalID;
				eRDecal = endDecal;
				if (endPrefabScript != null && endPrefabScript.isIConnector)
				{
					flag = true;
				}
			}
			else
			{
				num2 = startDecalID;
				eRDecal = startDecal;
				if (startPrefabScript != null && startPrefabScript.isIConnector)
				{
					flag = true;
				}
			}
			if (eRDecal == null)
			{
				QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType);
				if (roadTypeElByID != null)
				{
					eRDecal = ERDecal.OCOQQQDOOQ(num2, roadTypeElByID.decalPresets);
				}
			}
			Vector3 position = soSplinePoints[index];
			if (eRDecal != null)
			{
				position.y += eRDecal.heightOffset;
			}
			decal.transform.position = position;
			Vector3 vector = soSplinePointsLeft[index] - soSplinePointsRight[index];
			vector = ((index != 0) ? new Vector3(vector.z, 0f, 0f - vector.x).normalized : new Vector3(0f - vector.z, 0f, vector.x).normalized);
			decal.transform.forward = vector;
			Vector3 vector2 = OCQCDQCQOQ.OCCQQCOQCD(Vector3.Lerp(soSplinePoints[index], soSplinePoints[index + num], 0.5f), this);
			Vector3 forward = decal.transform.forward;
			Vector3 vector3 = forward - Vector3.Dot(forward, vector2) * vector2;
			if (vector3 != Vector3.zero)
			{
				decal.transform.rotation = Quaternion.LookRotation(vector3, vector2);
			}
			if (eRDecal != null)
			{
				if (eRDecal.meshWidth == 0f)
				{
					eRDecal.ODCDDQCCOC();
				}
				float num3 = ODDQQOCOCO(index);
				decal.transform.localScale = num3 / eRDecal.meshWidth * new Vector3(1f, 1f, 1f) * eRDecal.scale;
			}
			if (!flag)
			{
				position = markersExt[index2].position;
				if (eRDecal != null)
				{
					position.y += eRDecal.heightOffset;
				}
				decal.transform.position = position;
			}
		}

		public float ODDQQOCOCO(int startEnd)
		{
			float num = 0f;
			QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType);
			if (roadTypeElByID == null)
			{
				return 0f;
			}
			List<Vector2> list = null;
			Vector3 a;
			Vector3 b;
			if (startEnd == 0)
			{
				list = markersExt[0].roadShape;
				a = soSplinePointsLeft[0];
				b = soSplinePointsRight[0];
			}
			else
			{
				list = markersExt[markersExt.Count - 1].roadShape;
				a = soSplinePointsLeft[soSplinePointsLeft.Count - 1];
				b = soSplinePointsRight[soSplinePointsRight.Count - 1];
			}
			if (roadTypeElByID.roadShape.Count == list.Count)
			{
				return Vector3.Distance(a, b);
			}
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < roadTypeElByID.roadShape.Count; i++)
			{
				if (list[0].x < 0f)
				{
					if (roadTypeElByID.roadShape[i].x < 0f)
					{
						num2++;
					}
					else
					{
						num3++;
					}
				}
				else if (roadTypeElByID.roadShape[i].x > 0f)
				{
					num3++;
				}
				else
				{
					num2++;
				}
			}
			if (list[0].x < 0f)
			{
				num2--;
			}
			else
			{
				num3--;
			}
			int num4 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[0].x < 0f)
				{
					if (list[i].x < 0f)
					{
						num4++;
					}
				}
				else if (list[i].x > 0f)
				{
					num4++;
				}
			}
			int num5 = 0;
			int index = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[0].x < 0f)
				{
					if (list[i].x >= 0f && num5 == 0)
					{
						num5 = i - num2 - 1;
						index = i + num3 - 1;
						break;
					}
				}
				else if (list[i].x <= 0f && num5 == 0)
				{
					index = i - num3 - 1;
					num5 = i + num2 - 1;
					break;
				}
			}
			return Vector3.Distance(list[num5], list[index]);
		}

		public Vector3[] AdjustNormals(Vector3[] normals)
		{
			int num = roadShapeCols;
			if (startPrefabScript != null)
			{
				for (int i = 0; i < roadShapeCols; i++)
				{
					ref Vector3 reference = ref normals[i];
					reference = normals[i + num];
				}
			}
			if (endPrefabScript != null)
			{
				for (int i = 0; i < roadShapeCols; i++)
				{
					ref Vector3 reference2 = ref normals[normals.Length - num - i - 1];
					reference2 = normals[normals.Length - i - 1 - num];
				}
			}
			return normals;
		}

		public void AdjustPrefabNormals(List<int> roadInts, List<int> prefabInts, Vector3[] normals, GameObject prefab, Vector3[] verts)
		{
			if (!(prefab.GetComponent<MeshFilter>() == null) && (bool)prefab.GetComponent<MeshFilter>().sharedMesh)
			{
				Mesh sharedMesh = prefab.GetComponent<MeshFilter>().sharedMesh;
				Vector3[] normals2 = sharedMesh.normals;
				for (int i = 0; i < roadInts.Count; i++)
				{
					ref Vector3 reference = ref normals2[prefabInts[i]];
					reference = prefab.transform.InverseTransformDirection(normals[roadInts[i]]);
				}
				sharedMesh.normals = normals2;
			}
		}

		public bool OOOOCDQQOC(Vector3 pTarget, Vector3 pSource, Vector3 pCheck)
		{
			Vector3 normalized = (pTarget - pSource).normalized;
			Vector3 normalized2 = (pCheck - pSource).normalized;
			if (Vector3.Cross(normalized, normalized2).y < 0f)
			{
				return false;
			}
			return true;
		}

		public void OCOCQQCCCC(ref List<Vector3> surfaceVecs, ERCrossingPrefabs prefabScript, ref bool startSurfacesSafe, float distance, float minIndent)
		{
		}

		public void OCQDQDDCQO(ref List<Vector3> surfaceVecs, ERCrossingPrefabs prefabScript, int el, ref bool surfacesSafe, float distance, float minIndent)
		{
		}

		public bool OQQCDQOCDO(Vector3 ODDOCQCCDQIndent, Vector3 otherPrefabIndent, Vector3 v)
		{
			return false;
		}

		public void OOCCDQQODC(List<Vector3> surfaceVecs, List<Vector2> uvs, int h, List<bool> doBridge, Vector3 firstDir, Vector3 lastDir, float indent, float surrounding)
		{
			List<ERVSData> list = new List<ERVSData>();
			Vector3 a = Vector3.zero;
			bool flag = true;
			if (!baseScript.vegetationStudio || baseScript.vegetationStudioActive)
			{
			}
			if (surfaceMesh == null)
			{
				ERSurfaceScript componentInChildren = base.gameObject.GetComponentInChildren<ERSurfaceScript>();
				if (componentInChildren != null)
				{
					surfaceMesh = componentInChildren.gameObject;
				}
			}
			if (surfaceMesh == null)
			{
				surfaceMesh = new GameObject("surface");
				surfaceMesh.hideFlags = HideFlags.HideInHierarchy;
				surfaceMesh.AddComponent<MeshFilter>();
				surfaceMesh.AddComponent<MeshRenderer>();
				surfaceMesh.AddComponent<MeshCollider>();
				surfaceMesh.AddComponent<ERSurfaceScript>();
				surfaceMesh.GetComponent<MeshRenderer>().material = Resources.Load("Materials/surfaceMaterial") as Material;
				surfaceMesh.transform.parent = base.transform;
				surfaceMesh.GetComponent<MeshRenderer>().enabled = !baseScript.hideSurfaces;
				surfaceMesh.GetComponent<MeshCollider>().enabled = !baseScript.hideSurfaces;
				surfaceMesh.layer = 31;
			}
			if (surfaceMesh.GetComponent<MeshFilter>() == null)
			{
				surfaceMesh.AddComponent<MeshFilter>();
			}
			Mesh mesh;
			if (surfaceMesh.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = surfaceMesh.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				surfaceMesh.GetComponent<MeshFilter>().sharedMesh = mesh;
				if (surfaceMesh.GetComponent<MeshCollider>() == null)
				{
					surfaceMesh.AddComponent<MeshCollider>();
				}
				surfaceMesh.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			if (surfaceMesh.GetComponent<MeshCollider>() == null)
			{
				surfaceMesh.AddComponent<MeshCollider>();
				surfaceMesh.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
			if (!terrainDeformation)
			{
				UnityEngine.Object.DestroyImmediate(surfaceMesh);
				return;
			}
			surfaceMesh.layer = 31;
			List<int> list2 = new List<int>();
			int num = 5;
			int num2 = 1;
			float num3 = 0f;
			int num4 = 0;
			bool flag2 = false;
			int num5 = 0;
			int num6 = 0;
			for (int i = 0; i < h - 1; i += num2)
			{
				if (!doBridge[i])
				{
					num3 = ((i == 0) ? 0f : (doBridge[i + 1] ? 1f : ((!doBridge[i - 1]) ? 0f : 2f)));
					for (int j = 0; j < num - 1; j++)
					{
						int num7 = i * num + j;
						int num8 = i * num + j + 1;
						int num9 = (i + num2) * num + j;
						int num10 = (i + num2) * num + j + 1;
						if ((num3 == 2f && j == 3) || (num3 == 1f && j == 0))
						{
							if (surfaceVecs[num7] != surfaceVecs[num8])
							{
								list2.Add(num7);
								list2.Add(num9);
								list2.Add(num8);
							}
							if (surfaceVecs[num8] != surfaceVecs[num10])
							{
								list2.Add(num8);
								list2.Add(num9);
								list2.Add(num10);
							}
						}
						else
						{
							if (surfaceVecs[num10] != surfaceVecs[num8])
							{
								list2.Add(num7);
								list2.Add(num10);
								list2.Add(num8);
							}
							if (surfaceVecs[num9] != surfaceVecs[num7])
							{
								list2.Add(num9);
								list2.Add(num10);
								list2.Add(num7);
							}
						}
					}
				}
				if (!baseScript.vegetationStudio)
				{
					continue;
				}
				flag = false;
				if (i > 1)
				{
					if (doBridge[i] && !doBridge[i - 1])
					{
						flag = true;
					}
					if (!doBridge[i] && doBridge[i - 1])
					{
						flag = true;
					}
				}
				if (Vector3.Distance(a, soSplinePoints[i]) > 10f || flag)
				{
					Vector3 node = Vector3.Lerp(soSplinePointsLeft[i], soSplinePointsRight[i], 0.5f);
					float width = Vector3.Distance(soSplinePointsLeft[i], soSplinePointsRight[i]);
					list.Add(new ERVSData(node, !doBridge[i], width));
					a = soSplinePoints[i];
				}
			}
			int count = surfaceVecs.Count;
			if (startPrefabScript == null && !doBridge[0] && !closedTrack)
			{
				InterpolateSurfaces(ref surfaceVecs, ref uvs, ref list2, firstDir, count, 0, indent, surrounding);
			}
			if (endPrefabScript == null && !doBridge[h - 2] && !closedTrack)
			{
				InterpolateSurfaces(ref surfaceVecs, ref uvs, ref list2, lastDir, count, 1, indent, surrounding);
			}
			surfaceMesh.GetComponent<MeshCollider>().sharedMesh = null;
			for (int k = 0; k < surfaceVecs.Count; k++)
			{
				if (surfaceVecs[k].x != surfaceVecs[k].x)
				{
					Vector3 value = surfaceVecs[k - 1];
					value += new Vector3(0.2f, 0.2f, 0.2f);
					surfaceVecs[k] = value;
				}
			}
			mesh.Clear();
			mesh.vertices = surfaceVecs.ToArray();
			mesh.uv = uvs.ToArray();
			mesh.tangents = new Vector4[surfaceVecs.Count];
			mesh.triangles = list2.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			surfaceMesh.GetComponent<MeshCollider>().sharedMesh = null;
			surfaceMesh.GetComponent<MeshCollider>().sharedMesh = mesh;
			if (surfaceMesh.GetComponent<MeshCollider>().sharedMesh == null)
			{
				UnityEngine.Object.DestroyImmediate(surfaceMesh.GetComponent<MeshCollider>());
				surfaceMesh.AddComponent<MeshCollider>();
				if (surfaceMesh.GetComponent<MeshCollider>().sharedMesh == null)
				{
					Debug.LogWarning("EasyRoads3Dv3 Warning: No mesh assigned to the surface mesh Collider");
				}
			}
			if (baseScript.hideSurfaces)
			{
				surfaceMesh.GetComponent<MeshCollider>().enabled = false;
				surfaceMesh.SetActive(value: false);
				surfaceMesh.SetActive(value: true);
			}
			else
			{
				if ((bool)surfaceMesh.GetComponent<MeshRenderer>())
				{
					surfaceMesh.GetComponent<MeshRenderer>().enabled = true;
				}
				if ((bool)surfaceMesh.GetComponent<MeshCollider>())
				{
					surfaceMesh.GetComponent<MeshCollider>().enabled = true;
				}
			}
			testmesh = mesh;
			if (baseScript.vegetationStudio && baseScript.vegetationStudioActive)
			{
				Vector3 node = Vector3.Lerp(soSplinePointsLeft[h - 1], soSplinePointsRight[h - 1], 0.5f);
				float width = Vector3.Distance(soSplinePointsLeft[h - 1], soSplinePointsRight[h - 1]);
				list.Add(new ERVSData(node, !doBridge[h - 1], width));
				if (startPrefabScript != null && !doBridge[0])
				{
					list.Insert(0, new ERVSData(startPrefabScript.transform.position, active: true, list[0].width));
				}
				if (endPrefabScript != null && !doBridge[h - 1])
				{
					list.Add(new ERVSData(endPrefabScript.transform.position, active: true, width));
				}
				object[] parameters = new object[7]
				{
					base.gameObject,
					list.ToArray(),
					2f * vegetationStudioGrassPerimeter,
					2f * vegetationStudioPlantPerimeter,
					2f * vegetationStudioTreePerimeter,
					2f * vegetationStudioObjectPerimeter,
					2f * vegetationStudioLargeObjectPerimeter
				};
				if ((object)baseScript.upMethod != null)
				{
					baseScript.upMethod.Invoke(null, parameters);
				}
			}
		}

		public void InterpolateSurfaces(ref List<Vector3> surfaceVecs, ref List<Vector2> uvs, ref List<int> tris, Vector3 dir, int vecCount, int startEnd, float indent, float surrounding)
		{
			int count = surfaceVecs.Count;
			int num = 0;
			if (startEnd == 0)
			{
				dir *= -1f;
				num = 0;
			}
			else
			{
				num = vecCount - 5;
			}
			surfaceVecs.Add(surfaceVecs[num]);
			surfaceVecs.Add(surfaceVecs[num + 1]);
			surfaceVecs.Add(surfaceVecs[num + 2]);
			surfaceVecs.Add(surfaceVecs[num + 3]);
			surfaceVecs.Add(surfaceVecs[num + 4]);
			uvs.Add(new Vector2(0f, 0f));
			uvs.Add(new Vector2(0f, 1f));
			uvs.Add(new Vector2(0f, 1f));
			uvs.Add(new Vector2(0f, 1f));
			uvs.Add(new Vector2(0f, 0f));
			surfaceVecs.Add(surfaceVecs[num] + dir * indent);
			surfaceVecs.Add(surfaceVecs[num + 1] + dir * indent);
			surfaceVecs.Add(surfaceVecs[num + 2] + dir * indent);
			surfaceVecs.Add(surfaceVecs[num + 3] + dir * indent);
			surfaceVecs.Add(surfaceVecs[num + 4] + dir * indent);
			uvs.Add(new Vector2(0f, 0f));
			uvs.Add(new Vector2(0f, 1f));
			uvs.Add(new Vector2(0f, 1f));
			uvs.Add(new Vector2(0f, 1f));
			uvs.Add(new Vector2(0f, 0f));
			Vector3 pos = surfaceVecs[num] + dir * (indent + surrounding);
			baseScript.OCCDCQCOQC(ref pos);
			surfaceVecs.Add(pos);
			pos = surfaceVecs[num + 1] + dir * (indent + surrounding);
			baseScript.OCCDCQCOQC(ref pos);
			surfaceVecs.Add(pos);
			pos = surfaceVecs[num + 2] + dir * (indent + surrounding);
			baseScript.OCCDCQCOQC(ref pos);
			surfaceVecs.Add(pos);
			pos = surfaceVecs[num + 3] + dir * (indent + surrounding);
			baseScript.OCCDCQCOQC(ref pos);
			surfaceVecs.Add(pos);
			pos = surfaceVecs[num + 4] + dir * (indent + surrounding);
			baseScript.OCCDCQCOQC(ref pos);
			surfaceVecs.Add(pos);
			uvs.Add(new Vector2(0f, 0f));
			uvs.Add(new Vector2(0f, 0f));
			uvs.Add(new Vector2(0f, 0f));
			uvs.Add(new Vector2(0f, 0f));
			uvs.Add(new Vector2(0f, 0f));
			int count2 = tris.Count;
			int num2 = 5;
			int num3 = 1;
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < num2 - 1; j++)
				{
					if (num == 0)
					{
						tris.Add(count + i * num2 + j);
						tris.Add(count + i * num2 + j + 1);
						tris.Add(count + (i + num3) * num2 + j + 1);
						tris.Add(count + (i + num3) * num2 + j);
						tris.Add(count + i * num2 + j);
						tris.Add(count + (i + num3) * num2 + j + 1);
					}
					else
					{
						tris.Add(count + i * num2 + j);
						tris.Add(count + (i + num3) * num2 + j + 1);
						tris.Add(count + i * num2 + j + 1);
						tris.Add(count + (i + num3) * num2 + j);
						tris.Add(count + (i + num3) * num2 + j + 1);
						tris.Add(count + i * num2 + j);
					}
				}
			}
		}

		public List<Vector3> OQQOQCQQQD(List<ERMarkerExt> markersExt, float faceDist, bool ignorePrefabAlignment, ref List<float> tValues, ref List<float> markerDistances, bool forceAutoRotate, ref List<float> rotationArray)
		{
			if (testPoints != null)
			{
				testPoints.Clear();
			}
			List<Vector3> list = new List<Vector3>();
			if (markersExt[0].oldPosition == Vector3.zero)
			{
				for (int i = 0; i < markersExt.Count; i++)
				{
					markersExt[i].oldPosition = markersExt[i].position;
				}
			}
			if (!baseScript.localGridActive && !baseScript.globalGridActive)
			{
				for (int i = 1; i < markersExt.Count - 2; i++)
				{
					if (markersExt[i].controlType == 3)
					{
						bool flag = true;
						if (!(markersExt[i].oldPosition != markersExt[i].position) && !(markersExt[i + 1].oldPosition != markersExt[i + 1].position) && !(markersExt[i + 2].oldPosition != markersExt[i + 2].position))
						{
						}
					}
				}
			}
			bool flag2 = false;
			bool flag3 = false;
			if (forceAutoRotate)
			{
				if (nodeWithinRange == 0)
				{
					flag2 = true;
				}
				else
				{
					flag3 = true;
				}
			}
			startDir = (endDir = Vector3.zero);
			tmpMarkersExt.Clear();
			tmpMarkersExt.AddRange(markersExt);
			if (closedTrack)
			{
				tmpMarkersExt.Add(tmpMarkersExt[0]);
			}
			List<Vector3> tmpNodes = new List<Vector3>();
			List<float> list2 = new List<float>();
			for (int i = 0; i < tmpMarkersExt.Count; i++)
			{
				tmpNodes.Add(tmpMarkersExt[i].position);
				if (tmpMarkersExt[i].splineStrength == 0f)
				{
					tmpMarkersExt[i].splineStrength = 0.5f;
				}
				list2.Add(tmpMarkersExt[i].splineStrength);
			}
			if (tmpNodes.Count != list2.Count)
			{
				Debug.Log("array lengths " + tmpNodes.Count + " " + list2.Count);
			}
			float num = 0f;
			float num2 = 1f;
			if (startPrefabScript == null)
			{
				if (closedTrack && tmpMarkersExt[0].controlType == 0)
				{
					tmpNodes.Insert(0, tmpNodes[tmpNodes.Count - 2]);
					list2.Insert(0, list2[0]);
				}
				else
				{
					tmpNodes.Insert(0, tmpNodes[0]);
					list2.Insert(0, list2[0]);
				}
			}
			else
			{
				if ((!ignorePrefabAlignment && startPrefabScript.crossingElements[startConnectionSegment].rotationPriority) || flag2)
				{
					tmpNodes.Insert(0, tmpNodes[0]);
					list2.Insert(0, list2[0]);
					Vector3 vector = tmpNodes[2];
					if (tmpNodes.Count >= 4)
					{
						vector = tmpNodes[3];
					}
					Vector3 v = OQODDDCOQD(tmpNodes[0], tmpNodes[1], tmpNodes[2], vector, 0.5f, 0.5f);
					startPrefabScript.ODOOOQODQC(tmpNodes[0], v, startConnectionSegment, this);
				}
				else if (startPrefabScript.isIConnector)
				{
					ERIConnector component = startPrefabScript.gameObject.GetComponent<ERIConnector>();
					if (!ignorePrefabAlignment)
					{
						component.OCCCCCCDCC(this);
					}
					tmpNodes[0] = startPrefabScript.transform.position;
					Vector3 vector = startPrefabScript.transform.position;
					int index = 1;
					if (startConnectionSegment == 1)
					{
						index = 0;
					}
					if (startPrefabScript.crossingElements[index].connectedRoad != null)
					{
						ERModularRoad connectedRoad = startPrefabScript.crossingElements[index].connectedRoad;
						if (connectedRoad.markersExt.Count > 0)
						{
							vector = ((startPrefabScript.crossingElements[index].connectedMarker != 0) ? connectedRoad.markersExt[connectedRoad.markersExt.Count - 2].position : connectedRoad.markersExt[1].position);
						}
					}
					tmpNodes.Insert(0, vector);
					num = ((!(component.road1 == this)) ? component.t2 : component.t1);
				}
				else
				{
					Vector3 zero = Vector3.zero;
					ODQCQOODDO.ODOOOQOOQO(this, ref tmpNodes, list2, startPrefabScript, startConnectionSegment, ref startDir, ref zero, 0);
				}
				if (startPrefabScript.tStraightBending)
				{
					tCrossingConnected = true;
				}
			}
			if (endPrefabScript == null)
			{
				if (closedTrack && tmpMarkersExt[0].controlType == 0)
				{
					tmpNodes.Add(tmpNodes[2]);
					list2.Add(list2[2]);
				}
				else if (closedTrack && (tmpMarkersExt[0].controlType == 1 || tmpMarkersExt[0].controlType == 2))
				{
					Vector3 endCP = Vector3.zero;
					OQDCOOCQOQ(ref endCP, tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 1], tmpNodes[2]);
					tmpNodes.Add(endCP);
					list2.Add(list2[list2.Count - 1]);
				}
				else
				{
					tmpNodes.Add(tmpNodes[tmpNodes.Count - 1]);
					list2.Add(list2[list2.Count - 1]);
				}
			}
			else
			{
				if ((!ignorePrefabAlignment && endPrefabScript.crossingElements[endConnectionSegment].rotationPriority) || flag3)
				{
					tmpNodes.Add(tmpNodes[tmpNodes.Count - 1]);
					list2.Add(list2[list2.Count - 1]);
					Vector3 vector = tmpNodes[tmpNodes.Count - 3];
					if (tmpNodes.Count >= 4)
					{
						vector = tmpNodes[tmpNodes.Count - 4];
					}
					Vector3 v2 = OQODDDCOQD(vector, tmpNodes[tmpNodes.Count - 3], tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 1], 0.5f, 0.5f);
					endPrefabScript.ODOOOQODQC(tmpNodes[tmpNodes.Count - 1], v2, endConnectionSegment, this);
				}
				else if (endPrefabScript.isIConnector)
				{
					ERIConnector component = endPrefabScript.gameObject.GetComponent<ERIConnector>();
					if (!ignorePrefabAlignment)
					{
						component.OCCCCCCDCC(this);
					}
					tmpNodes[tmpNodes.Count - 1] = endPrefabScript.transform.position;
					Vector3 vector = endPrefabScript.transform.position;
					int index = 1;
					if (endConnectionSegment == 1)
					{
						index = 0;
					}
					if (endPrefabScript.crossingElements[index].connectedRoad != null)
					{
						ERModularRoad connectedRoad = endPrefabScript.crossingElements[index].connectedRoad;
						if (connectedRoad.markersExt.Count > 0)
						{
							vector = ((endPrefabScript.crossingElements[index].connectedMarker != 0) ? connectedRoad.markersExt[connectedRoad.markersExt.Count - 2].position : connectedRoad.markersExt[1].position);
						}
					}
					tmpNodes.Add(vector);
					num2 = ((!(component.road1 == this)) ? (1f - component.t2) : (1f - component.t1));
					if (num2 < 0f)
					{
						num2 = 0.2f;
					}
				}
				else
				{
					ODQCQOODDO.ODOOOQOOQO(this, ref tmpNodes, list2, endPrefabScript, endConnectionSegment, ref endDir, ref lastForward, 1);
				}
				if (endPrefabScript.tStraightBending)
				{
					tCrossingConnected = true;
				}
			}
			Vector3[] array = tmpNodes.ToArray();
			float num3 = 0f;
			Vector3 vector2 = array[1];
			Vector3 v3 = Vector3.zero;
			Vector3 circleDir = Vector3.zero;
			bool flag4 = false;
			totalDistance = 0f;
			int num4 = 0;
			Vector3 startCP = array[0];
			Vector3 endCP2 = array[3];
			Vector3 lastHeightAdjustCP = Vector3.zero;
			if (tmpMarkersExt.Count == 0)
			{
				return null;
			}
			nodeSplinePoint.Clear();
			nodeSplinePoint.Add(0);
			if (tmpMarkersExt[1].controlType == 3 && tmpMarkersExt.Count > 2)
			{
				Vector3 normalized = (array[2] - array[1]).normalized;
				endCP2 = array[2] + normalized * Vector3.Distance(array[2], array[3]);
				endCP2.y = array[3].y;
			}
			markerDistances.Add(0f);
			segPoints.Clear();
			testPoints.Clear();
			List<float> list3 = new List<float>();
			List<Vector3> vecs = new List<Vector3>();
			float num5 = 0f;
			int num6 = 0;
			Vector3 b = vector2;
			b.y = 0f;
			Vector3 to = new Vector3(0f, 50f, 0f);
			float xzDistance = 0f;
			Vector3 vector4;
			Vector3 vector3 = (vector4 = Vector3.zero);
			float num7 = 0f;
			float num8 = 0f;
			Vector3 zero2 = Vector3.zero;
			bool flag5 = false;
			bool flag6 = false;
			float randomYDistanceStart = 0f;
			float randomYDistanceEnd = 0f;
			float randomYDistanceMiddle = 0f;
			Vector3 randomYDistanceV = Vector3.zero;
			float num9 = 0f;
			float currentRandomYDistance = 0f;
			float randomRotationStart = 0f;
			float randomRotationEnd = 0f;
			float randomRotationMiddle = 0f;
			Vector3 randomRotationV = Vector3.zero;
			float currentRandomRotation = 0f;
			for (int j = 1; j < array.Length - 2; j++)
			{
				float totalDist = 0f;
				markersExt[j - 1].startSplinePoint = list.Count;
				markersExt[j - 1].startDistance = totalDistance;
				if (j > 1)
				{
					if (j > 2)
					{
						markersExt[j - 2].totalDistance = totalDistance - markersExt[j - 2].startDistance;
					}
					else
					{
						markersExt[j - 2].totalDistance = totalDistance;
					}
					if (markersExt[j - 2].totalDistance < 1000f)
					{
						markersExt[j - 2].totalDistanceString = markersExt[j - 2].totalDistance.ToString("N2") + " m";
					}
					else
					{
						markersExt[j - 2].totalDistanceString = (markersExt[j - 2].totalDistance / 1000f).ToString("N3") + " km";
					}
					Vector3 vector5 = new Vector3(0f, Mathf.Abs(markersExt[j - 2].position.y - markersExt[j - 1].position.y), xzDistance);
					float num10 = 90f - Vector3.Angle(vector5, to);
					if (num10 > 10f)
					{
						markersExt[j - 2].angleString = Mathf.Round(num10).ToString();
					}
					else
					{
						markersExt[j - 2].angleString = num10.ToString("N2");
					}
					float num11 = Mathf.Abs(markersExt[j - 2].position.y - markersExt[j - 1].position.y);
					float num12 = Vector3.Distance(new Vector3(markersExt[j - 2].position.x, 0f, markersExt[j - 2].position.z), new Vector3(markersExt[j - 1].position.x, 0f, markersExt[j - 1].position.z));
					markersExt[j - 2].gradeString = (num11 / num12 * 100f).ToString("N2");
					if (list.Count > 2)
					{
						vector3 = (list[list.Count - 1] - list[list.Count - 2]).normalized;
					}
				}
				list3.Clear();
				vecs.Clear();
				xzDistance = 0f;
				num9 = totalDistance + Vector3.Distance(array[j], array[j + 1]);
				if (tmpMarkersExt[j - 1].controlType == 0)
				{
					float num13 = Vector3.Distance(array[j], array[j + 1]);
					float num14 = 0.2f / num13;
					if (num3 > 0f)
					{
						num3 -= 1f;
					}
					num3 = 0f;
					if (j == 1)
					{
						num3 = num;
					}
					float num15 = ((j != array.Length - 3) ? 1f : num2);
					float num16 = 0.5f;
					for (float num17 = num3; num17 < num15; num17 += num14)
					{
						flag4 = false;
						flag5 = false;
						if (num17 + num14 > 1f && j == array.Length - 3 && !closedTrack)
						{
							flag4 = true;
							flag5 = true;
							num17 = 1f;
						}
						Vector3 pos = OQODDDCOQD(startCP, array[j], array[j + 1], endCP2, num17, list2[j]);
						if (num6 == 3)
						{
							vector2 = pos;
							b = vector2;
							b.y = 0f;
							num6 = 0;
						}
						num7 = Vector3.Distance(vector2, pos);
						num8 = Vector3.Distance(pos, array[j + 1]);
						if (vecs.Count > 0 || list.Count > 0)
						{
							zero2 = ((vecs.Count <= 0) ? list[list.Count - 1] : vecs[vecs.Count - 1]);
							vector4 = (pos - zero2).normalized;
							if (vector3 != Vector3.zero && Vector3.Angle(vector3, vector4) > angleTreshold && num7 >= 1f && (double)num8 > 1.5)
							{
								flag4 = true;
								flag5 = true;
							}
						}
						if (snapToTerrain)
						{
							baseScript.OCCDCQCOQC(ref pos);
						}
						if (num17 + num14 + 0.1f > num15 && num8 < 0.5f * faceDistance && !flag5 && !flag6)
						{
							pos = array[j + 1];
							flag4 = true;
							num17 = 1f;
						}
						if (num17 + num14 > num15)
						{
							pos = array[j + 1];
							flag4 = true;
							num17 = 1f;
						}
						if (Vector3.Distance(vector2, pos) > faceDist || flag4 || (j == 1 && num17 == 0f))
						{
							num13 = Vector3.Distance(vector2, pos);
							totalDistance += num13;
							totalDist += num13;
							Vector3 vector6 = pos;
							vector6.y = 0f;
							xzDistance += Vector3.Distance(vector6, b);
							vector2 = pos;
							v3 = pos;
							b = vector6;
							flag6 = flag5;
							if (tmpMarkersExt[j - 1].randomMinYPosition != 0f || tmpMarkersExt[j - 1].randomMaxYPosition != 0f || tmpMarkersExt[j - 1].randomMinRotation != 0f || tmpMarkersExt[j - 1].randomMaxRotation != 0f)
							{
								RoadSmoothness(totalDistance, tmpMarkersExt[j - 1], num9, ref randomYDistanceStart, ref randomYDistanceEnd, ref randomYDistanceMiddle, ref randomYDistanceV, ref v3, ref currentRandomYDistance, ref randomRotationStart, ref randomRotationEnd, ref randomRotationMiddle, ref randomRotationV, ref currentRandomRotation, ref rotationArray);
							}
							else
							{
								rotationArray.Add(0f);
							}
							vecs.Add(v3);
							list3.Add(num17);
							if (flag4)
							{
								nodeSplinePoint.Add(num4);
							}
							num4++;
							vector3 = vector4;
						}
					}
					num6 = 0;
				}
				else if (tmpMarkersExt[j - 1].controlType == 1 || tmpMarkersExt[j - 1].controlType == 2)
				{
					if (j == 1)
					{
						v3 = array[j];
					}
					Vector3 normalized = (array[j + 1] - array[j]).normalized;
					totalDist = Vector3.Distance(array[j + 1], array[j]);
					b = v3;
					b.y = 0f;
					Vector3 vector6 = array[j + 1];
					vector6.y = 0f;
					xzDistance += Vector3.Distance(vector6, b);
					float num13 = faceDist;
					if (j == 1)
					{
						num13 = 0f;
					}
					List<float> list4 = new List<float>();
					for (; num13 < totalDist - faceDist; num13 += faceDist)
					{
						currentRandomYDistance = 0f;
						Vector3 zero = v3 + normalized * num13;
						if (Vector3.Distance(zero, array[j + 1]) > 0.5f * faceDist)
						{
							Vector3 pos2 = v3 + normalized * num13;
							if (snapToTerrain)
							{
								baseScript.OCCDCQCOQC(ref pos2);
							}
							if (tmpMarkersExt[j - 1].randomMinYPosition != 0f || tmpMarkersExt[j - 1].randomMaxYPosition != 0f || tmpMarkersExt[j - 1].randomMinRotation != 0f || tmpMarkersExt[j - 1].randomMaxRotation != 0f)
							{
								RoadSmoothness(totalDistance + num13, tmpMarkersExt[j - 1], num9, ref randomYDistanceStart, ref randomYDistanceEnd, ref randomYDistanceMiddle, ref randomYDistanceV, ref pos2, ref currentRandomYDistance, ref randomRotationStart, ref randomRotationEnd, ref randomRotationMiddle, ref randomRotationV, ref currentRandomRotation, ref rotationArray);
							}
							else
							{
								rotationArray.Add(0f);
							}
							vecs.Add(pos2);
							list4.Add(currentRandomYDistance);
							num5 = num13 / totalDist;
							list3.Add(num5);
						}
					}
					if (!snapToTerrain && tmpMarkersExt[j - 1].controlType == 1)
					{
						for (int i = 0; i < list3.Count; i++)
						{
							Vector3 zero = OQODDDCOQD(array[j - 1], array[j], array[j + 1], array[j + 2], list3[i], 0.5f);
							Vector3 value = vecs[i];
							value.y = zero.y + list4[i];
							vecs[i] = value;
						}
					}
					if (vecs.Count == 0)
					{
						vecs.Add(array[j + 1]);
						totalDist = Vector3.Distance(v3, array[j + 1]);
						list3.Add(1f);
						rotationArray.Add(0f);
					}
					if (vecs.Count > 0 && vecs[vecs.Count - 1] != array[j + 1])
					{
						if (Vector3.Distance(vecs[vecs.Count - 1], array[j + 1]) < 0.5f * faceDist)
						{
							vecs[vecs.Count - 1] = array[j + 1];
							list3[list3.Count - 1] = 1f;
						}
						else
						{
							vecs.Add(array[j + 1]);
							totalDist += Vector3.Distance(vecs[vecs.Count - 1], array[j + 1]);
							list3.Add(1f);
							rotationArray.Add(0f);
						}
					}
					num4 += vecs.Count;
					vector2 = (v3 = vecs[vecs.Count - 1]);
					totalDistance += totalDist;
					nodeSplinePoint.Add(num4);
					num6 = tmpMarkersExt[j - 1].controlType;
				}
				else if (tmpMarkersExt[j - 1].controlType == 3)
				{
					if (j - 1 < tmpMarkersExt.Count - 2 || closedTrack)
					{
						ODQCQOODDO.ODDCDDDCOQ(ref list, this, j, ref vecs, ref list3, ref totalDist, 0, ref xzDistance, getDistance: false);
					}
					else
					{
						ODQCQOODDO.OODCQODQDD(ref list, this, j, ref vecs, ref list3, ref totalDist, 0, ref xzDistance, getDistance: false);
					}
					float num18 = 0f;
					for (int i = 0; i < list3.Count; i++)
					{
						Vector3 value = vecs[i];
						if (!snapToTerrain)
						{
							value.y = OQODDDCOQD(array[j - 1], array[j], array[j + 1], array[j + 2], list3[i], 0.5f).y;
							vecs[i] = value;
						}
						else
						{
							baseScript.OCCDCQCOQC(ref value);
						}
						if (i > 0)
						{
							if (tmpMarkersExt[j - 1].randomMinYPosition != 0f || tmpMarkersExt[j - 1].randomMaxYPosition != 0f || tmpMarkersExt[j - 1].randomMinRotation != 0f || tmpMarkersExt[j - 1].randomMaxRotation != 0f)
							{
								num18 += Vector3.Distance(vecs[i - 1], vecs[i]);
								RoadSmoothness(totalDistance + num18, tmpMarkersExt[j - 1], num9, ref randomYDistanceStart, ref randomYDistanceEnd, ref randomYDistanceMiddle, ref randomYDistanceV, ref value, ref currentRandomYDistance, ref randomRotationStart, ref randomRotationEnd, ref randomRotationMiddle, ref randomRotationV, ref currentRandomRotation, ref rotationArray);
							}
							else
							{
								rotationArray.Add(0f);
							}
						}
						else
						{
							rotationArray.Add(0f);
						}
						vecs[i] = value;
					}
					if (list3.Count > 0)
					{
						if (list3[list3.Count - 1] > 1f)
						{
							list3[list3.Count - 1] = 1f;
							vecs[vecs.Count - 1] = array[j + 1];
						}
						else if (vecs[vecs.Count - 1] != array[j + 1])
						{
							if (Vector3.Distance(vecs[vecs.Count - 1], array[j + 1]) < 0.5f * faceDist)
							{
								vecs[vecs.Count - 1] = array[j + 1];
								list3[list3.Count - 1] = 1f;
							}
							else
							{
								vecs.Add(array[j + 1]);
								totalDist += Vector3.Distance(vecs[vecs.Count - 1], array[j + 1]);
								list3.Add(1f);
								rotationArray.Add(0f);
							}
						}
					}
					else
					{
						vecs.Add(array[j + 1]);
						totalDist += Vector3.Distance(array[j], array[j + 1]);
						list3.Add(1f);
						rotationArray.Add(0f);
					}
					num4 += vecs.Count;
					v3 = vecs[vecs.Count - 1];
					if (vecs.Count >= 2)
					{
						circleDir = (vecs[vecs.Count - 2] - vecs[vecs.Count - 1]).normalized;
					}
					totalDistance += totalDist;
					nodeSplinePoint.Add(num4);
					b = v3;
					b.y = 0f;
					float num19 = 0f;
					if (list.Count > 0)
					{
						num19 = (float)list.Count - (float)markersExt[j - 2].startSplinePoint;
						float num20 = markerDistances[markerDistances.Count - 1];
						if (markerDistances.Count > 1)
						{
							num20 -= markerDistances[markerDistances.Count - 2];
						}
						Vector3 normalized = (list[list.Count - 1] - vecs[0]).normalized;
						Vector3 vector7 = list[list.Count - 1];
						float num21 = num20 / num19 * 1f;
						Vector3 b2 = list[list.Count - 1];
						float num22 = 0f;
						int count = list.Count;
						for (int i = 1; (float)i <= num19; i++)
						{
							if (count - 1 - i >= 0)
							{
								vector7 += normalized * num21;
								Vector3 vector8 = list[list.Count - 1 - i];
								num22 += Vector3.Distance(vector8, b2);
								float f = num22 / num20;
								vector8.y = Mathf.Lerp(vector7.y, vector8.y, Mathf.Sqrt(f));
								list[list.Count - 1 - i] = vector8;
								b2 = vector8;
							}
						}
					}
					num6 = 3;
				}
				if (tmpMarkersExt[j - 1].followTerrainContours)
				{
					ODQCQOODDO.OQOQQDOQDD(baseScript, ref vecs, list3, terrainContoursOffset, ref lastHeightAdjustCP, faceDistance, totalDist, tmpMarkersExt[j].followTerrainContours, list, ref testPoints, ref rotationArray);
				}
				list.AddRange(vecs);
				tValues.AddRange(list3);
				OOCCQOOOCQ(tmpMarkersExt, j, array, circleDir, totalDist, ref startCP, 0, list);
				if (array.Length > j + 3)
				{
					OOQDDDDDCD(tmpMarkersExt, j, array, ref endCP2, 0);
				}
				markerDistances.Add(totalDistance);
				try
				{
					if (markersExt.Count > j)
					{
						markersExt[j].direction = (markersExt[j].direction1 = (list[list.Count - 1] - list[list.Count - 2]).normalized);
					}
					if (j > 1 && markersExt.Count > j && list.Count > markersExt[j - 1].startSplinePoint + 1 && markersExt[j - 1].controlType != 3)
					{
						Vector3 vector9 = list[markersExt[j - 1].startSplinePoint + 1];
						Vector3 vector10 = list[markersExt[j - 1].startSplinePoint];
						markersExt[j - 1].direction = (vector9 - vector10).normalized;
						if (j != markersExt.Count)
						{
							vector9.y = vector10.y;
						}
						markersExt[j - 1].direction1 = (vector9 - vector10).normalized;
					}
				}
				catch
				{
					if (markersExt.Count > 2)
					{
						Debug.LogWarning("road error: " + base.gameObject.name + " please check the distances between markers, it seems two markers are located at the same position");
					}
					else if (list.Count <= 1)
					{
						Debug.LogWarning("road error: only 1 spline point was extracted, please check the marker positions against the road resolution value");
					}
					else
					{
						Debug.LogError("road error: " + list.Count);
					}
				}
				if (j == 1)
				{
					try
					{
						markersExt[j - 1].direction = (markersExt[j - 1].direction1 = (list[1] - list[0]).normalized);
					}
					catch
					{
						if (list.Count <= 1)
						{
							Debug.LogWarning("EasyRoads3Dv3 warning: only 1 spline point was extracted, please check the marker positions against the road resolution value: " + base.gameObject.name);
						}
						else
						{
							Debug.LogError("EasyRoads3Dv3 warning: road error: " + list.Count + " " + base.gameObject.name);
						}
					}
				}
				if (markersExt.Count > j)
				{
					markersExt[j].oldPosition = markersExt[j].position;
				}
			}
			if (!closedTrack)
			{
				markersExt[markersExt.Count - 1].startSplinePoint = list.Count;
				markersExt[markersExt.Count - 1].startDistance = totalDistance;
				markersExt[0].startSplinePoint = 0;
				markersExt[0].startDistance = 0f;
				if (markersExt.Count > 2)
				{
					markersExt[markersExt.Count - 2].totalDistance = totalDistance - markersExt[markersExt.Count - 2].startDistance;
					if (markersExt[markersExt.Count - 2].totalDistance < 1000f)
					{
						markersExt[markersExt.Count - 2].totalDistanceString = markersExt[markersExt.Count - 2].totalDistance.ToString("N2") + " m";
					}
					else
					{
						markersExt[markersExt.Count - 2].totalDistanceString = (markersExt[markersExt.Count - 2].totalDistance / 1000f).ToString("N3") + " km";
					}
					Vector3 vector5 = new Vector3(0f, Mathf.Abs(markersExt[markersExt.Count - 2].position.y - markersExt[markersExt.Count - 1].position.y), xzDistance);
					float num10 = 90f - Vector3.Angle(vector5, to);
					if (num10 > 10f)
					{
						markersExt[markersExt.Count - 2].angleString = Mathf.Round(num10).ToString();
					}
					else
					{
						markersExt[markersExt.Count - 2].angleString = num10.ToString("N2");
					}
					float num11 = Mathf.Abs(markersExt[markersExt.Count - 2].position.y - markersExt[markersExt.Count - 1].position.y);
					float num12 = Vector3.Distance(new Vector3(markersExt[markersExt.Count - 2].position.x, 0f, markersExt[markersExt.Count - 2].position.z), new Vector3(markersExt[markersExt.Count - 1].position.x, 0f, markersExt[markersExt.Count - 1].position.z));
					markersExt[markersExt.Count - 2].gradeString = (num11 / num12 * 100f).ToString("N2");
				}
			}
			else
			{
				markersExt[0].startSplinePoint = list.Count;
				markersExt[0].startDistance = totalDistance;
				if (markersExt.Count > 2)
				{
					markersExt[markersExt.Count - 1].totalDistance = totalDistance - markersExt[markersExt.Count - 1].startDistance;
					if (markersExt[markersExt.Count - 1].totalDistance < 1000f)
					{
						markersExt[markersExt.Count - 1].totalDistanceString = markersExt[markersExt.Count - 1].totalDistance.ToString("N2") + " m";
					}
					else
					{
						markersExt[markersExt.Count - 1].totalDistanceString = (markersExt[markersExt.Count - 1].totalDistance / 1000f).ToString("N3") + " km";
					}
					Vector3 vector5 = new Vector3(0f, Mathf.Abs(markersExt[markersExt.Count - 1].position.y - markersExt[0].position.y), xzDistance);
					float num10 = 90f - Vector3.Angle(vector5, to);
					if (num10 > 10f)
					{
						markersExt[markersExt.Count - 1].angleString = Mathf.Round(num10).ToString();
					}
					else
					{
						markersExt[markersExt.Count - 1].angleString = num10.ToString("N2");
					}
					float num11 = Mathf.Abs(markersExt[markersExt.Count - 2].position.y - markersExt[markersExt.Count - 1].position.y);
					float num12 = Vector3.Distance(new Vector3(markersExt[markersExt.Count - 2].position.x, 0f, markersExt[markersExt.Count - 2].position.z), new Vector3(markersExt[markersExt.Count - 1].position.x, 0f, markersExt[markersExt.Count - 1].position.z));
					markersExt[markersExt.Count - 1].gradeString = (num11 / num12 * 100f).ToString("N2");
				}
			}
			if (totalDistance < 1000f)
			{
				totalDistanceString = totalDistance.ToString("N2") + " m";
			}
			else
			{
				totalDistanceString = (totalDistance / 1000f).ToString("N3") + " km";
			}
			if (markersExt.Count == 2)
			{
				if (markersExt[0].totalDistance < 1000f)
				{
					markersExt[0].totalDistanceString = markersExt[0].totalDistance.ToString("N2") + " m";
				}
				else
				{
					markersExt[0].totalDistanceString = (markersExt[0].totalDistance / 1000f).ToString("N3") + " km";
				}
			}
			if (!closedTrack)
			{
				markersExt[markersExt.Count - 1].totalDistanceString = "0";
			}
			for (int i = 1; i < list.Count - 1; i++)
			{
				Vector3 normalized2 = (list[i - 1] - list[i]).normalized;
				Vector3 normalized3 = (list[i + 1] - list[i]).normalized;
			}
			markersExt[0].direction1 = new Vector3(markersExt[0].direction1.x, 0f, markersExt[0].direction1.z).normalized;
			markersExt[markersExt.Count - 1].direction1 = new Vector3(markersExt[markersExt.Count - 1].direction1.x, 0f, markersExt[markersExt.Count - 1].direction1.z).normalized;
			return list;
		}

		public void OOCCQOOOCQ(List<ERMarkerExt> tmpMarkers, int j, Vector3[] tr, Vector3 circleDir, float totalDist, ref Vector3 startCP, int startMarker, List<Vector3> p)
		{
			startCP = tr[j];
			if (tmpMarkersExt[startMarker + j - 1].controlType == 1 || tmpMarkersExt[startMarker + j - 1].controlType == 2)
			{
				Vector3 vector = tr[j] - tr[j + 1];
				vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				Vector3 vA = tr[j + 1] + vector * 1500f;
				Vector3 vB = tr[j + 1] + -vector * 1500f;
				Vector3 vector2 = OCQCDQCQOQ.OQQQDCODQD(vA, vB, tr[j + 2]);
				Vector3 vector3 = tr[j + 2];
				vector3.y = vector2.y;
				float num = Vector3.Distance(vector3, vector2);
				tmpPerpCP = tr[j + 1];
				vector = (vector2 - vector3).normalized;
				startCP = vector2 + vector * num;
				startCP.y = tr[j + 2].y;
				tmpCP = startCP;
			}
			else if (tmpMarkersExt[startMarker + j - 1].controlType == 3)
			{
				float num = Vector3.Distance(tmpMarkersExt[startMarker + j - 1].position, tmpMarkersExt[startMarker + j].position);
				Vector3 vector = circleDir;
				startCP = tmpMarkersExt[startMarker + j].position + vector * num;
				vector = (p[p.Count - 2] - tr[j + 1]).normalized;
			}
		}

		public void OOQDDDDDCD(List<ERMarkerExt> tmpMarkersExt, int j, Vector3[] tr, ref Vector3 endCP, int startMarker)
		{
			if (tr.Length <= j + 3)
			{
				return;
			}
			endCP = tr[j + 3];
			if (tmpMarkersExt.Count <= startMarker + j + 1)
			{
				endCP = tr[j + 3];
			}
			else if (tmpMarkersExt[startMarker + j + 1].controlType == 3)
			{
				endCP = tr[j + 2];
				Vector3 normalized = (tmpMarkersExt[startMarker + j + 1].position - tmpMarkersExt[startMarker + j].position).normalized;
				endCP = tmpMarkersExt[startMarker + j + 1].position + normalized * Vector3.Distance(tmpMarkersExt[startMarker + j].position, tmpMarkersExt[startMarker + j + 1].position);
				if (startMarker + j + 2 < tmpMarkersExt.Count)
				{
					endCP.y = tmpMarkersExt[startMarker + j + 2].position.y;
				}
				else if (closedTrack)
				{
					endCP.y = markersExt[0].position.y;
				}
				else
				{
					endCP.y = tmpMarkersExt[startMarker + j + 1].position.y;
				}
				p5 = endCP;
				testPoints.Add(endCP);
			}
			else if (tmpMarkersExt.Count > startMarker + j + 2 && (tmpMarkersExt[startMarker + j + 1].controlType == 1 || tmpMarkersExt[startMarker + j + 1].controlType == 2))
			{
				Vector3 normalized = tr[j + 3] - tr[j + 2];
				normalized = new Vector3(normalized.z, 0f, 0f - normalized.x).normalized;
				Vector3 vA = tr[j + 2] + normalized * 1500f;
				Vector3 vB = tr[j + 2] + -normalized * 1500f;
				Vector3 vector = OCQCDQCQOQ.OQQQDCODQD(vA, vB, tr[j + 1]);
				Vector3 vector2 = tr[j + 1];
				vector2.y = vector.y;
				float num = Vector3.Distance(vector2, vector);
				normalized = (vector - vector2).normalized;
				endCP = vector + normalized * num;
				endCP.y = tr[j + 1].y;
			}
		}

		public void OQDCOOCQOQ(ref Vector3 endCP, Vector3 curV3, Vector3 nextV3, Vector3 nextNextV3)
		{
			Vector3 vector = nextNextV3 - nextV3;
			vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
			Vector3 vA = nextV3 + vector * 1500f;
			Vector3 vB = nextV3 + -vector * 1500f;
			Vector3 vector2 = OCQCDQCQOQ.OQQQDCODQD(vA, vB, curV3);
			Vector3 vector3 = curV3;
			vector3.y = vector2.y;
			float num = Vector3.Distance(vector3, vector2);
			vector = (vector2 - vector3).normalized;
			endCP = vector2 + vector * num;
			endCP.y = curV3.y;
		}

		public List<float> OQCDDDCOOD(List<float> tValues, List<float> markerDistances, List<ERMarkerExt> markers, int startMarker, int endMarker, ref List<float> OQCODCDCDC, List<float> randomRotations)
		{
			List<float> list = new List<float>();
			List<Vector3> list2 = new List<Vector3>();
			List<float> list3 = new List<float>();
			List<float> list4 = new List<float>();
			markerInts.Clear();
			bridgeElement.Clear();
			for (int i = startMarker; i < endMarker; i++)
			{
				list.Add(tmpMarkersExt[i].rotation);
				list3.Add(tmpMarkersExt[i].rotationCenter);
			}
			list.Insert(0, list[0]);
			list.Add(list[list.Count - 1]);
			list3.Insert(0, list3[0]);
			list3.Add(list3[list3.Count - 1]);
			List<float> list5 = new List<float>();
			OQCODCDCDC.Clear();
			int num = 0;
			int num2 = 1;
			bool flag = false;
			while (num2 < list.Count - 2)
			{
				while (!flag)
				{
					if (num < tValues.Count)
					{
						float num3 = Mathf.Lerp(list[num2], list[num2 + 1], Mathf.SmoothStep(0f, 1f, tValues[num]));
						float item = Mathf.Lerp(list3[num2], list3[num2 + 1], Mathf.SmoothStep(0f, 1f, tValues[num]));
						if (randomRotations.Count > num)
						{
							list5.Add(num3 + randomRotations[num]);
						}
						else
						{
							list5.Add(num3);
						}
						OQCODCDCDC.Add(item);
						if (num + 1 < tValues.Count)
						{
							if (tValues[num + 1] <= tValues[num])
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
						num++;
					}
					else
					{
						flag = true;
					}
					try
					{
						if (!flag)
						{
							markerInts.Add(num2 - 1);
							bridgeElement.Add(tmpMarkersExt[num2 - 1].bridgeObject);
						}
						else
						{
							markerInts.Add(num2);
							bridgeElement.Add(tmpMarkersExt[num2].bridgeObject);
						}
					}
					catch
					{
						Debug.Log(num2 + " " + tmpMarkersExt.Count);
					}
				}
				flag = false;
				num2++;
				if (list[num2] == 360f && list[num2 + 1] < 360f)
				{
					list[num2] = 0f;
				}
				else if (list[num2] == -360f && list[num2 + 1] > -360f)
				{
					list[num2] = 0f;
				}
			}
			return list5;
		}

		public void RoadSmoothness(float curDist, ERMarkerExt marker, float totalDistance, ref float randomYDistanceStart, ref float randomYDistanceEnd, ref float randomYDistanceMiddle, ref Vector3 randomYDistanceV3, ref Vector3 v, ref float currentRandomYDistance, ref float randomRotationStart, ref float randomRotationEnd, ref float randomRotationMiddle, ref Vector3 randomRotationV3, ref float currentRandomRotation, ref List<float> rotationArray)
		{
			if (marker.minRandomYPositionDistance != 0f || marker.maxRandomYPositionDistance != 0f)
			{
				if (curDist >= randomYDistanceEnd)
				{
					if (marker.maxRandomYPositionDistance == 0f)
					{
						marker.maxRandomYPositionDistance = 25f;
					}
					randomYDistanceStart = (randomYDistanceEnd = curDist);
					float num = UnityEngine.Random.Range(marker.minRandomYPositionDistance, marker.maxRandomYPositionDistance);
					randomYDistanceEnd += num;
					randomYDistanceMiddle = Mathf.Lerp(randomYDistanceStart, randomYDistanceEnd, 0.5f);
					randomYDistanceV3.x = UnityEngine.Random.Range(marker.randomMinYPosition, marker.randomMaxYPosition);
					if (randomYDistanceEnd > totalDistance)
					{
						randomYDistanceEnd = totalDistance;
						if (randomYDistanceEnd - randomYDistanceStart < marker.minRandomYPositionDistance)
						{
							randomYDistanceV3.x = 0f;
						}
					}
					if (randomYDistanceMiddle > totalDistance)
					{
						randomYDistanceMiddle = Mathf.Lerp(randomYDistanceStart, randomYDistanceEnd, 0.5f);
					}
				}
				if (randomYDistanceV3.x != 0f)
				{
					float num2 = 0f;
					if (curDist < randomYDistanceMiddle)
					{
						num2 = (curDist - randomYDistanceStart) / (randomYDistanceMiddle - randomYDistanceStart);
						currentRandomYDistance = Mathf.Lerp(0f, randomYDistanceV3.x, Mathf.SmoothStep(0f, 1f, num2));
					}
					else
					{
						num2 = (curDist - randomYDistanceMiddle) / (randomYDistanceEnd - randomYDistanceMiddle);
						currentRandomYDistance = Mathf.Lerp(randomYDistanceV3.x, 0f, Mathf.SmoothStep(0f, 1f, num2));
					}
				}
				v.y += currentRandomYDistance;
			}
			currentRandomRotation = 0f;
			if (marker.minRandomRotationDistance != 0f || marker.maxRandomRotationDistance != 0f)
			{
				if (curDist >= randomRotationEnd)
				{
					if (marker.maxRandomRotationDistance == 0f)
					{
						marker.maxRandomRotationDistance = 25f;
					}
					randomRotationStart = (randomRotationEnd = curDist);
					float num = UnityEngine.Random.Range(marker.minRandomRotationDistance, marker.maxRandomRotationDistance);
					randomRotationEnd += num;
					randomRotationMiddle = Mathf.Lerp(randomRotationStart, randomRotationEnd, 0.5f);
					randomRotationV3.x = UnityEngine.Random.Range(marker.randomMinRotation, marker.randomMaxRotation);
					if (randomRotationEnd > totalDistance)
					{
						randomRotationEnd = totalDistance;
						if (randomRotationEnd - randomRotationStart < marker.minRandomRotationDistance)
						{
							randomRotationV3.x = 0f;
						}
					}
					if (randomRotationMiddle > totalDistance)
					{
						randomRotationMiddle = Mathf.Lerp(randomRotationStart, randomRotationEnd, 0.5f);
					}
				}
				if (randomRotationV3.x != 0f)
				{
					float num2 = 0f;
					if (curDist < randomRotationMiddle)
					{
						num2 = (curDist - randomRotationStart) / (randomRotationMiddle - randomRotationStart);
						currentRandomRotation = Mathf.Lerp(0f, randomRotationV3.x, Mathf.SmoothStep(0f, 1f, num2));
					}
					else
					{
						num2 = (curDist - randomRotationMiddle) / (randomRotationEnd - randomRotationMiddle);
						currentRandomRotation = Mathf.Lerp(randomRotationV3.x, 0f, Mathf.SmoothStep(0f, 1f, num2));
					}
				}
			}
			rotationArray.Add(currentRandomRotation);
		}

		public List<List<Vector2>> GetRoadShapeValues(List<float> tValues, List<float> markerDistances, List<ERMarkerExt> markers, int startMarker, int endMarker, List<Vector2> roadShape)
		{
			List<List<Vector2>> list = new List<List<Vector2>>();
			List<List<Vector3>> list2 = new List<List<Vector3>>();
			List<List<Vector3>> list3 = new List<List<Vector3>>();
			List<float> list4 = new List<float>();
			List<float> list5 = new List<float>();
			bool flag = false;
			for (int i = 0; i < roadShape.Count; i++)
			{
				list2.Add(new List<Vector3>());
				list3.Add(new List<Vector3>());
			}
			int count = roadShape.Count;
			for (int j = startMarker; j < endMarker; j++)
			{
				list4.Add(tmpMarkersExt[j].roadShapeDistanceMin);
				list5.Add(tmpMarkersExt[j].roadShapeDistanceMax);
				if (tmpMarkersExt[j].roadShape.Count != count)
				{
					tmpMarkersExt[j].roadShape = new List<Vector2>(roadShape);
				}
				for (int i = 0; i < roadShape.Count; i++)
				{
					Vector3 item = new Vector3(markerDistances[j - startMarker], tmpMarkersExt[j].roadShape[i].x, 0f);
					list2[i].Add(item);
					item = new Vector3(markerDistances[j - startMarker], tmpMarkersExt[j].roadShape[i].y, 0f);
					list3[i].Add(item);
					if (tmpMarkersExt[j].roadShape[i] != roadShape[i])
					{
						flag = true;
					}
				}
				tmpMarkersExt[j].roadShapeVecsGlobal.Clear();
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
			if (!closedTrack)
			{
				list5.Insert(0, list5[0]);
				list5.Add(list5[list5.Count - 1]);
			}
			else
			{
				list5.Insert(0, list5[list5.Count - 2]);
				list5.Add(list5[2]);
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
						float t;
						if (tValues[num] < list4[k])
						{
							t = 0f;
						}
						else if (tValues[num] < list5[k])
						{
							t = tValues[num] - list4[k];
							t /= list5[k] - list4[k];
						}
						else
						{
							t = 1f;
						}
						for (int i = 0; i < roadShape.Count; i++)
						{
							Vector3 vector;
							Vector3 vector2;
							if (list2[i][k] != list2[i][k + 1] || list3[i][k] != list3[i][k + 1])
							{
								vector = OQODDDCOQD(list2[i][k - 1], list2[i][k], list2[i][k + 1], list2[i][k + 2], t, 0.5f);
								vector2 = OQODDDCOQD(list3[i][k - 1], list3[i][k], list3[i][k + 1], list3[i][k + 2], t, 0.5f);
							}
							else
							{
								vector = list2[i][k];
								vector2 = list3[i][k];
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

		public List<float> GetSurfaceValues(List<float> tValues, List<float> markerDistances, List<ERMarkerExt> markers, int startMarker, int endMarker, ref List<float> leftIndents, ref List<float> rightIndents, ref List<float> leftSurrounding, ref List<float> rightSurrounding, float minRequiredIndent)
		{
			List<Vector3> list = new List<Vector3>();
			List<Vector3> list2 = new List<Vector3>();
			List<Vector3> list3 = new List<Vector3>();
			List<Vector3> list4 = new List<Vector3>();
			List<Vector3> list5 = new List<Vector3>();
			List<float> list6 = new List<float>();
			float num = 0f;
			float num2 = 0f;
			for (int i = startMarker; i < endMarker; i++)
			{
				num = tmpMarkersExt[i].leftIndent;
				num2 = tmpMarkersExt[i].rightIndent;
				if (num < minRequiredIndent)
				{
					num = minRequiredIndent;
				}
				if (num2 < minRequiredIndent)
				{
					num2 = minRequiredIndent;
				}
				Vector3 item = new Vector3(markerDistances[i - startMarker], num, 0f);
				list2.Add(item);
				item = new Vector3(markerDistances[i - startMarker], num2, 0f);
				list3.Add(item);
				item = new Vector3(markerDistances[i - startMarker], tmpMarkersExt[i].leftSurrounding, 0f);
				list4.Add(item);
				item = new Vector3(markerDistances[i - startMarker], tmpMarkersExt[i].rightSurrounding, 0f);
				list5.Add(item);
			}
			list2.Insert(0, list2[0]);
			list2.Add(list2[list2.Count - 1]);
			list3.Insert(0, list3[0]);
			list3.Add(list3[list3.Count - 1]);
			list4.Insert(0, list4[0]);
			list4.Add(list4[list4.Count - 1]);
			list5.Insert(0, list5[0]);
			list5.Add(list5[list5.Count - 1]);
			List<float> result = new List<float>();
			int num3 = 0;
			int j = 1;
			bool flag = false;
			for (; j < list2.Count - 2; j++)
			{
				while (!flag)
				{
					if (num3 < tValues.Count)
					{
						Vector3 vector = OQODDDCOQD(list2[j - 1], list2[j], list2[j + 1], list2[j + 2], tValues[num3], 0.5f);
						leftIndents.Add(vector.y);
						vector = OQODDDCOQD(list3[j - 1], list3[j], list3[j + 1], list3[j + 2], tValues[num3], 0.5f);
						rightIndents.Add(vector.y);
						vector = OQODDDCOQD(list4[j - 1], list4[j], list4[j + 1], list4[j + 2], tValues[num3], 0.5f);
						leftSurrounding.Add(vector.y);
						vector = OQODDDCOQD(list5[j - 1], list5[j], list5[j + 1], list5[j + 2], tValues[num3], 0.5f);
						rightSurrounding.Add(vector.y);
						if (num3 + 1 < tValues.Count)
						{
							if (tValues[num3 + 1] <= tValues[num3])
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
						num3++;
					}
					else
					{
						flag = true;
					}
				}
				flag = false;
			}
			return result;
		}

		public List<Vector3> OQCQDOODCO(bool flag)
		{
			List<Vector3> list = new List<Vector3>();
			foreach (ERMarkerExt item in markersExt)
			{
				list.Add(item.position);
			}
			if (flag)
			{
				if (closedTrack)
				{
					list.Insert(0, list[list.Count - 1]);
					list.Add(list[1]);
					list.Add(list[2]);
				}
				else
				{
					list.Add(list[list.Count - 1]);
					list.Insert(0, list[0]);
				}
			}
			flyOverPoints = list.ToArray();
			return list;
		}

		public void ODOOCDDOOD()
		{
			List<float> list = new List<float>();
			markerDistances = ODQQQCDCOQ(flyOverPoints);
		}

		public List<float> ODQQQCDCOQ(Vector3[] tr)
		{
			List<float> list = new List<float>();
			list.Add(0f);
			List<Vector3> list2 = new List<Vector3>();
			float num = 0f;
			float num2 = 0f;
			Vector3 vector = Vector3.zero;
			float num3 = 0f;
			for (int i = 1; i < tr.Length - 2; i++)
			{
				if (num3 > 0f)
				{
					num3 -= 1f;
				}
				num3 = 0f;
				float num4 = 0.0005f;
				for (float num5 = num3; num5 < 1f; num5 += num4)
				{
					Vector3 vector2 = OQODDDCOQD(tr[i - 1], tr[i], tr[i + 1], tr[i + 2], num5, 0.5f);
					list2.Add(vector2);
					if (vector != Vector3.zero)
					{
						float num6 = Vector3.Distance(vector, vector2);
						num += num6;
						num2 += num6;
					}
					vector = vector2;
					num3 = num5;
				}
				list.Add(num2);
			}
			return list;
		}

		public Vector3 OQCQQOCQQO(float offset)
		{
			float num = offset * totalDistance;
			int num2 = 0;
			for (int i = 0; i < markerDistances.Count; i++)
			{
				if (markerDistances[i] > num)
				{
					num2 = i - 1;
					break;
				}
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			float t = (num - markerDistances[num2]) / (markerDistances[num2 + 1] - markerDistances[num2]);
			num2++;
			return OQODDDCOQD(flyOverPoints[num2 - 1], flyOverPoints[num2], flyOverPoints[num2 + 1], flyOverPoints[num2 + 2], t, 0.5f);
		}

		public static Vector3 OQODDDCOQD(Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3, float t, float tension)
		{
			float num = t * t;
			float num2 = num * t;
			Vector3 vector = tension * (P2 - P0);
			Vector3 vector2 = tension * (P3 - P1);
			float num3 = 2f * num2 - 3f * num + 1f;
			float num4 = -2f * num2 + 3f * num;
			float num5 = num2 - 2f * num + t;
			float num6 = num2 - num;
			return num3 * P1 + num4 * P2 + num5 * vector + num6 * vector2;
		}

		public ERRoadType GetRoadType(ERRoadType[] roadTypes)
		{
			foreach (ERRoadType eRRoadType in roadTypes)
			{
				if (eRRoadType.id == roadType)
				{
					return eRRoadType;
				}
			}
			return null;
		}
	}
}
