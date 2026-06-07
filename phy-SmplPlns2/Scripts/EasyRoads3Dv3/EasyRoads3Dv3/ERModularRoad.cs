using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[HelpURL("https://www.easyroads3d.com/v3/html/scene.html#roadProperties")]
	[AddComponentMenu("")]
	public class ERModularRoad : MonoBehaviour
	{
		public ERModularBase baseScript;

		public string roadName;

		[HideInInspector]
		public long id = 0L;

		[HideInInspector]
		public bool locked = false;

		public double roadType = 0.0;

		public QDQDOOQQDQODD rt;

		[HideInInspector]
		public int defaultControlType = 0;

		[HideInInspector]
		public bool isCustomRoadSet = false;

		public bool isCustomRoad = false;

		[HideInInspector]
		public bool isBridge = false;

		[HideInInspector]
		public bool bridgeAtStart = false;

		[HideInInspector]
		public bool bridgeAtEnd = false;

		[HideInInspector]
		public List<ERMarker> markers = new List<ERMarker>();

		[HideInInspector]
		public List<ERMarker> tmpMarkers = new List<ERMarker>();

		[HideInInspector]
		public List<ERMarkerExt> markersExt = new List<ERMarkerExt>();

		[HideInInspector]
		public List<ERMarkerExt> tmpMarkersExt = new List<ERMarkerExt>();

		[HideInInspector]
		public List<float> tValues = new List<float>();

		[HideInInspector]
		public float roadWidth = 5f;

		[HideInInspector]
		public int lanes = 0;

		[HideInInspector]
		public float leftShoulderWidth = 3f;

		[HideInInspector]
		public float rightShoulderWidth = 3f;

		[HideInInspector]
		public float laneWidth = 3f;

		[HideInInspector]
		public float faceDistance = 2f;

		[HideInInspector]
		public float angleTreshold = 45f;

		[HideInInspector]
		public bool resolutionFlag = false;

		[HideInInspector]
		public bool angleThresholdFlag = false;

		public bool closedTrack = false;

		[HideInInspector]
		public float minNodeDistance = 5f;

		[HideInInspector]
		public int nodeWithinRange = -1;

		public float uvTiling = 1f;

		[HideInInspector]
		public bool lockUVTiling = false;

		[HideInInspector]
		public bool planarUVs = false;

		[HideInInspector]
		public bool flipNormals = false;

		[HideInInspector]
		public Color vertexColor = Color.white;

		[HideInInspector]
		public int defaultLeftSidewalk = 0;

		public int defaultRightSidewalk = 0;

		[HideInInspector]
		public double defaultLeftSidewalkid = 0.0;

		[HideInInspector]
		public double defaultRightSidewalkid = 0.0;

		[HideInInspector]
		public bool leftSidewalkActive = false;

		[HideInInspector]
		public bool rightSidewalkActive = false;

		[HideInInspector]
		public List<ERSideWalkInstance> leftSidewalks = new List<ERSideWalkInstance>();

		[HideInInspector]
		public List<ERSideWalkInstance> rightSidewalks = new List<ERSideWalkInstance>();

		[HideInInspector]
		public List<GameObject> crosswalkObjects = new List<GameObject>();

		[HideInInspector]
		public List<float> crosswalkDistances = new List<float>();

		[HideInInspector]
		public List<OCDCDDDQOC> exitRoads = new List<OCDCDDDQOC>();

		[HideInInspector]
		public int selectedExit = 0;

		[HideInInspector]
		public bool randomnessFlag = false;

		[HideInInspector]
		public bool randomnessMarkerFlag = false;

		[HideInInspector]
		public float randomYPosition = 0f;

		[HideInInspector]
		public float randomMinYPosition = -0.02f;

		[HideInInspector]
		public float randomMaxYPosition = 0.02f;

		[HideInInspector]
		public float minRandomYPositionDistance = 15f;

		[HideInInspector]
		public float maxRandomYPositionDistance = 35f;

		[HideInInspector]
		public float randomMinRotation = 0f;

		[HideInInspector]
		public float randomMaxRotation = 0f;

		[HideInInspector]
		public float minRandomRotationDistance = 15f;

		[HideInInspector]
		public float maxRandomRotationDistance = 35f;

		[HideInInspector]
		public bool vegetationStudioMaskLineActive = true;

		[HideInInspector]
		public float vegetationStudioGrassPerimeter = 2f;

		[HideInInspector]
		public float vegetationStudioPlantPerimeter = 3f;

		[HideInInspector]
		public float vegetationStudioTreePerimeter = 4f;

		[HideInInspector]
		public float vegetationStudioObjectPerimeter = 3f;

		[HideInInspector]
		public float vegetationStudioLargeObjectPerimeter = 4f;

		[HideInInspector]
		public bool vegetationStudioBiomeMaskActive = false;

		[HideInInspector]
		public float vegetationStudioBiomeMaskDistance = 0f;

		[HideInInspector]
		public float vegetationStudioBiomeMaskBlendDistance = 0f;

		[HideInInspector]
		public float vegetationStudioBiomeMaskNoiseScale = 0f;

		[HideInInspector]
		public int vertsStats = 0;

		[HideInInspector]
		public int trisStats = 0;

		[HideInInspector]
		public float indent = 0.5f;

		[HideInInspector]
		public float surrounding = 0.5f;

		public bool followTerrainContours;

		public float terrainContoursOffset = 5f;

		[HideInInspector]
		public List<Vector2> roadShape = new List<Vector2>();

		[HideInInspector]
		public List<int> roadShapeIntsStart = new List<int>();

		[HideInInspector]
		public List<int> roadShapeIntsEnd = new List<int>();

		[HideInInspector]
		public List<int> roadShapeIntsStartFull = new List<int>();

		[HideInInspector]
		public List<int> roadShapeIntsEndFull = new List<int>();

		[HideInInspector]
		public string roadShapeString = "";

		[HideInInspector]
		public string roadShapeReversedString = "";

		[HideInInspector]
		public int roadShapeMatchCount = 0;

		[HideInInspector]
		public int geoReversed = -1;

		[HideInInspector]
		public int roadShapeCols = 0;

		[HideInInspector]
		public bool flipRoadUVs = false;

		[HideInInspector]
		public int subSegments = 1;

		[HideInInspector]
		public List<float> nodeDistance = new List<float>();

		[HideInInspector]
		public List<float> roadShapeUVs = new List<float>();

		[HideInInspector]
		public List<float> roadShapeUVs2 = new List<float>();

		[HideInInspector]
		public List<bool> doConnectionTri = new List<bool>();

		[HideInInspector]
		public List<float> randomRotations = new List<float>();

		[HideInInspector]
		public List<float> randomLeftTerrainHeightOffset = new List<float>();

		[HideInInspector]
		public List<float> randomRightTerrainHeightOffset = new List<float>();

		[HideInInspector]
		public List<bool> hardEdge = new List<bool>();

		[HideInInspector]
		public List<int> roadShapeMaterialInts = new List<int>();

		[HideInInspector]
		public int subMeshCount = 1;

		[HideInInspector]
		public List<int> roadShapeMaterialIntCounts = new List<int>();

		[HideInInspector]
		public List<Vector3> controlPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> splinePoints = new List<Vector3>();

		[HideInInspector]
		public List<float> distances = new List<float>();

		[HideInInspector]
		public List<int> markerInts = new List<int>();

		[HideInInspector]
		public List<Vector3> insertSplinePoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> soSplinePoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> soSplinePointsLeft = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> soSplinePointsRight = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> soSplinePointsLeftClamped = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> soSplinePointsRightClamped = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> soSplinePointsLeftFixed = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> soSplinePointsRightFixed = new List<Vector3>();

		public int startXPositionIndex = 0;

		public int endXPositionIndex = 0;

		[HideInInspector]
		public List<float> OODOCCDDCQ = new List<float>();

		[HideInInspector]
		public List<float> ODCODQCCDQ = new List<float>();

		[HideInInspector]
		public List<float> bendAngles = new List<float>();

		[HideInInspector]
		public List<Vector3> meshVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector2> meshUVs = new List<Vector2>();

		[HideInInspector]
		public List<Vector2> meshUVs2 = new List<Vector2>();

		[HideInInspector]
		public List<List<int>> tris = new List<List<int>>();

		[HideInInspector]
		public List<Vector3> surfaceMeshVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> leftIndentVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightIndentVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> middleIndentVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> leftSurroundingVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightSurroundingVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> leftIndentVecsSV = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightIndentVecsSV = new List<Vector3>();

		[HideInInspector]
		public List<bool> bridgeElement = new List<bool>();

		[HideInInspector]
		public List<Vector3> vecsBelowTerrain = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> treeVecs = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> detailVecs = new List<Vector3>();

		[HideInInspector]
		public List<int> vegetationTris = new List<int>();

		[HideInInspector]
		public List<int> vegetationTreeTris = new List<int>();

		[HideInInspector]
		public List<bool> doLeftSurrounding = new List<bool>();

		[HideInInspector]
		public List<bool> doRightSurrounding = new List<bool>();

		public float totalDistance = 0f;

		[HideInInspector]
		public List<int> nodeSplinePoint = new List<int>();

		[HideInInspector]
		public string totalDistanceString = "";

		[HideInInspector]
		public ERCrossingPrefabs startPrefabScript;

		[HideInInspector]
		public ERCrossingPrefabs endPrefabScript;

		[HideInInspector]
		public int startConnectionSegment = 0;

		[HideInInspector]
		public bool startConnectionFlag = true;

		[HideInInspector]
		public int endConnectionSegment = 0;

		[HideInInspector]
		public bool endConnectionFlag = true;

		[HideInInspector]
		public bool startSegmentIntAdjusted;

		[HideInInspector]
		public bool endSegmentIntAdjusted;

		[HideInInspector]
		public bool tCrossingConnected = false;

		public Material roadMaterial;

		[HideInInspector]
		public Material[] roadMaterials;

		public PhysicsMaterial roadPhysicsMaterial;

		[HideInInspector]
		public PhysicsMaterial[] roadPhysicsMaterials;

		[HideInInspector]
		public Vector3 startDir;

		[HideInInspector]
		public Vector3 endDir;

		[HideInInspector]
		public float startAngle;

		[HideInInspector]
		public float endAngle;

		[HideInInspector]
		private int ussst;

		[HideInInspector]
		private int vssss;

		[HideInInspector]
		public int startbendLeftRight = 0;

		[HideInInspector]
		public int endbendLeftRight = 0;

		[HideInInspector]
		public float connectionAdjustDistanceStart = 30f;

		[HideInInspector]
		public float connectionAdjustDistanceEnd = 30f;

		[HideInInspector]
		public Vector3 pivotp;

		[HideInInspector]
		public Vector3 p1;

		[HideInInspector]
		public Vector3 p2;

		[HideInInspector]
		public Vector3 p3;

		[HideInInspector]
		public Vector3 p4;

		[HideInInspector]
		public Vector3 p5;

		[HideInInspector]
		public Vector3 p6;

		[HideInInspector]
		public Vector3 p7;

		[HideInInspector]
		public Vector3 cp1;

		[HideInInspector]
		public Vector3 cp2;

		[HideInInspector]
		public Vector3 cp3;

		[HideInInspector]
		public Vector3 cp4;

		[HideInInspector]
		public Vector3 cp5;

		[HideInInspector]
		public Vector3 cp6;

		[HideInInspector]
		public Vector3 cp7;

		[HideInInspector]
		public Vector3 cp8;

		[HideInInspector]
		public Vector3 cp9;

		[HideInInspector]
		public Vector3 cpcenter;

		[HideInInspector]
		public Vector3 p1Circle;

		[HideInInspector]
		public Vector3 p2Circle;

		[HideInInspector]
		public float cpradius;

		[HideInInspector]
		public float cpangle;

		[HideInInspector]
		public Vector3 dp1;

		[HideInInspector]
		public Vector3 dp2;

		[HideInInspector]
		public Vector3 dp3;

		[HideInInspector]
		public Vector3 dp4;

		[HideInInspector]
		public List<Vector3> segPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> testPoints = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> testPoints2 = new List<Vector3>();

		[HideInInspector]
		public Vector3 OCQOOQODCQ = Vector3.zero;

		[HideInInspector]
		public Vector3 OQQCCQDCOO = Vector3.zero;

		[HideInInspector]
		public Vector3 endLeft = Vector3.zero;

		[HideInInspector]
		public Vector3 endRight = Vector3.zero;

		[HideInInspector]
		public Mesh testmesh;

		public GameObject surfaceMesh;

		[HideInInspector]
		public Vector3 sv1;

		[HideInInspector]
		public Vector3 sv2;

		[HideInInspector]
		public Vector3 prefabIndentLeft;

		[HideInInspector]
		public Vector3 prefabIndentRight;

		[HideInInspector]
		public Vector3 roadIndent1;

		[HideInInspector]
		public static int ODDOCODDQO;

		[HideInInspector]
		public static int OQOCCCOCCO;

		[HideInInspector]
		public static int OOQQQODOQC;

		[HideInInspector]
		public static int OODQCODOCO;

		[HideInInspector]
		public static int OQCOQQOCOD;

		[HideInInspector]
		public static int OCOOCCDCOQ;

		[HideInInspector]
		public Vector3 tmpPerpCP;

		[HideInInspector]
		public Vector3 tmpCP;

		[HideInInspector]
		private int wssst = 0;

		[HideInInspector]
		private int xssss = 0;

		[HideInInspector]
		public float splinePos = 0.001f;

		public float camHeight = 2f;

		public float camSpeed = 50f;

		public Vector3[] flyOverPoints;

		[HideInInspector]
		public Vector3 splinePosV3;

		[HideInInspector]
		public List<float> markerDistances = new List<float>();

		[HideInInspector]
		public string osmRoadType = "";

		[HideInInspector]
		public int osmID = 0;

		[HideInInspector]
		public string osmName = "";

		[HideInInspector]
		public bool osmOneWay = false;

		[HideInInspector]
		public int osmLanes = 0;

		[HideInInspector]
		public string osmSurface = "";

		[HideInInspector]
		public string osmturnLanes = "";

		[HideInInspector]
		public bool osmBridge = false;

		[HideInInspector]
		public string osmSpeed = "";

		[HideInInspector]
		public List<ERSORoad> soData = new List<ERSORoad>();

		[HideInInspector]
		public List<ERSORoadExt> soDataExt = new List<ERSORoadExt>();

		[HideInInspector]
		public string[] sideObjectNames = new string[0];

		[HideInInspector]
		public int selectedSO = 0;

		[HideInInspector]
		public bool rebuildSos = false;

		[HideInInspector]
		public bool sosCleared = false;

		[HideInInspector]
		public bool isSideObject = false;

		[HideInInspector]
		public int startOffsetActiveMarker = -1;

		[HideInInspector]
		public int endOffsetActiveMarker = -1;

		[HideInInspector]
		public float leftToCenterPerc = 0f;

		public ERRoad road;

		public bool splatMapActive = false;

		public int splatIndex = 0;

		public int expandLevel = 0;

		public int smoothLevel = 1;

		public float splatOpacity = 1f;

		public int layer = 0;

		public bool isStatic = true;

		public new string tag = "Untagged";

		[HideInInspector]
		public int tagInt = 0;

		public bool castShadow = false;

		[HideInInspector]
		public bool fadeInFlag = false;

		[HideInInspector]
		public float fadeInDistance = 0f;

		[HideInInspector]
		public bool fadeOutFlag = false;

		[HideInInspector]
		public float fadeOutDistance = 0f;

		[HideInInspector]
		public bool doSurroundingSurfaces = false;

		[HideInInspector]
		public bool terrainDeformation = true;

		[HideInInspector]
		public bool snapToTerrain = false;

		[HideInInspector]
		public List<ERSOSection> soSectionList1 = new List<ERSOSection>();

		[HideInInspector]
		public List<ERSOSection> soSectionList2 = new List<ERSOSection>();

		[HideInInspector]
		public List<ERSOSection> soSectionList3 = new List<ERSOSection>();

		[HideInInspector]
		public List<ERSOSection> soSectionList4 = new List<ERSOSection>();

		[HideInInspector]
		public List<ERSOSection> soSectionList5 = new List<ERSOSection>();

		[HideInInspector]
		public List<ERSOSection> soSectionList6 = new List<ERSOSection>();

		[HideInInspector]
		public List<ERSOSection> soSectionList7 = new List<ERSOSection>();

		[HideInInspector]
		public List<ERSOSection> soSectionList8 = new List<ERSOSection>();

		[HideInInspector]
		public bool snapVertices = false;

		[HideInInspector]
		public float snapOffset = 0.01f;

		[HideInInspector]
		public bool hasMeshCollider = true;

		[HideInInspector]
		public bool isUpdated = false;

		[HideInInspector]
		public bool forceSORefresh = false;

		[HideInInspector]
		public bool QDDDQODQQDQDQQD = false;

		[HideInInspector]
		public int uv4Type = 0;

		[HideInInspector]
		public float detailDistance = 50f;

		[HideInInspector]
		public bool startDecalCollapsed = false;

		[HideInInspector]
		public ERDecal startDecal;

		[HideInInspector]
		public ERDecal endDecal;

		public GameObject startDecalPrefab;

		[HideInInspector]
		public GameObject startDecalPrefabSource;

		[HideInInspector]
		public bool endDecalCollapsed = false;

		public GameObject endDecalPrefab;

		[HideInInspector]
		public GameObject endDecalPrefabSource;

		public int startDecalID = -1;

		public int endDecalID = -1;

		[HideInInspector]
		public Vector3 lastForward;

		[HideInInspector]
		public bool roadUpdate = false;

		[HideInInspector]
		public Bounds bounds;

		[HideInInspector]
		public List<Vector3> debugVecs = new List<Vector3>();

		[HideInInspector]
		public List<float> debugFloats = new List<float>();

		[HideInInspector]
		public Vector3 exitExtrudeEnd;

		[HideInInspector]
		public Vector3 exitFixedEnd;

		[HideInInspector]
		public Vector3 exitSplitEnd;

		[HideInInspector]
		public Texture2D splatTextureMask;

		[HideInInspector]
		public bool lockUVs = false;

		public List<ERLaneData> laneData = new List<ERLaneData>();

		[HideInInspector]
		public bool oneWayRoad = false;

		[HideInInspector]
		public ERLaneDirection oneWayDirection = ERLaneDirection.Right;

		[HideInInspector]
		public GameObject laneDirectionObject;

		[HideInInspector]
		public bool rotationsAdjustedFlag = false;

		[HideInInspector]
		public int lastRotationStartInt = 0;

		[HideInInspector]
		public int lastRotationEndInt = 0;

		[HideInInspector]
		public bool spawnDirectionMarkings = true;

		[HideInInspector]
		public List<ERVSData> vgData = new List<ERVSData>();

		[HideInInspector]
		public bool centerPivotPointsFlag = false;

		[HideInInspector]
		public int terrainXStart = 0;

		[HideInInspector]
		public int terrainYStart = 0;

		[HideInInspector]
		public int terrainHMRows = 0;

		[HideInInspector]
		public int terrainHMCols = 0;

		public bool OQCOCOQCDD(ERCrossingPrefabs prefabScript)
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

		public void ODOQQDDQOC(List<ERDecal> decalPresets)
		{
			if (startDecalPrefab != null)
			{
				if (Application.isEditor && !Application.isPlaying)
				{
					UnityEngine.Object.DestroyImmediate(startDecalPrefab);
				}
				else
				{
					UnityEngine.Object.Destroy(startDecalPrefab);
				}
			}
			if (endDecalPrefab != null)
			{
				if (Application.isEditor && !Application.isPlaying)
				{
					UnityEngine.Object.DestroyImmediate(endDecalPrefab);
				}
				else
				{
					UnityEngine.Object.Destroy(endDecalPrefab);
				}
			}
			startDecalID = -1;
			endDecalID = -1;
			List<int> list = new List<int>();
			int num = 0;
			foreach (ERDecal decalPreset in decalPresets)
			{
				if (decalPreset != null && decalPreset.type == ERDecalType.StartEnd)
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
			}
			if (list.Count > 0)
			{
				int minInclusive = 0;
				int count = list.Count;
				int index = UnityEngine.Random.Range(minInclusive, count);
				startDecalID = decalPresets[list[index]].id;
				startDecal = decalPresets[list[index]];
				index = UnityEngine.Random.Range(minInclusive, count);
				endDecalID = decalPresets[list[index]].id;
				endDecal = decalPresets[list[index]];
			}
		}

		public void ODDODOQOOQ()
		{
			List<GameObject> list = new List<GameObject>();
			foreach (Transform item in base.transform)
			{
				if (item.name.IndexOf("_ERDecal_Start") != -1 || item.name.IndexOf("_ERDecal_End") != -1)
				{
					list.Add(item.gameObject);
				}
			}
			if (Application.isEditor && !Application.isPlaying)
			{
				foreach (GameObject item2 in list)
				{
					UnityEngine.Object.DestroyImmediate(item2);
				}
				return;
			}
			foreach (GameObject item3 in list)
			{
				UnityEngine.Object.Destroy(item3);
			}
		}

		public QDQDOOQQDQODD GetRoadType()
		{
			if (rt == null && roadType != 0.0)
			{
				rt = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType, clone: true);
			}
			return rt;
		}

		public float GetRoadWidth()
		{
			if (roadType != 0.0)
			{
				rt = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType, clone: true);
				if (rt != null)
				{
					return rt.roadWidth;
				}
				return roadWidth;
			}
			return roadWidth;
		}

		public void ODDCDQQDOD(Vector3 pos)
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

		public int ODOQDQQOQD(Vector3 pos)
		{
			float num = 10000f;
			nodeWithinRange = -1;
			float num2 = 10000f;
			for (int i = 0; i < markersExt.Count; i++)
			{
				float num3 = Vector3.Distance(markersExt[i].position, pos);
				if (num > num3)
				{
					num = num3;
					nodeWithinRange = i;
				}
			}
			return nodeWithinRange;
		}

		public void GetInsertPointExt(Vector3 pos, ref int n1, int marker)
		{
			OCQCDQOQDD(pos, ref n1);
		}

		public void OCQCDQOQDD(Vector3 pos, ref int n1)
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
			int num4 = 0;
			for (int j = 0; j < markersExt.Count - 1; j++)
			{
				if (j > 0)
				{
					num4 = markersExt[j].startSplinePoint;
				}
				if (num2 >= num4 - 1 && num2 < markersExt[j + 1].startSplinePoint - 1)
				{
					n1 = j + 1;
					break;
				}
			}
		}

		public void OCDQCQQQDD(Vector3 pos, ref int n1, int selectedMarker, bool sameRoad)
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
			for (int j = 0; j < markersExt.Count - 1; j++)
			{
				if (num5 >= markersExt[j].startSplinePoint - 1 && num5 < markersExt[j + 1].startSplinePoint - 1)
				{
					n1 = j + 1;
					break;
				}
			}
		}

		public int GetSplinePointByPosition(Vector3 pos)
		{
			float num = 10000f;
			int result = 0;
			float num2 = 0f;
			for (int i = 1; i < soSplinePoints.Count - 1; i++)
			{
				num2 = Vector3.Distance(soSplinePoints[i], pos);
				if (num2 < num)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		public int OOODDDDQDO(Vector3 pos)
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
				OCQCDQOQDD(pos, ref n);
				switch (n)
				{
				case 0:
				{
					float num3 = Vector3.Distance(markersExt[0].position, pos);
					float num4 = Vector3.Distance(markersExt[markersExt.Count - 1].position, pos);
					if (num3 <= num4)
					{
						if (startPrefabScript == null)
						{
							HandleAddMarkerAtStart(pos, 0);
							return 0;
						}
					}
					else if (endPrefabScript == null)
					{
						OOOQCOQOQD(pos, 0);
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
				ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
			}
			return result;
		}

		public int OOOQCOQOQD(Vector3 pos, int selectedMarker)
		{
			if (endPrefabScript == null)
			{
				markersExt.Add(ERMarkerExt.CreateInstance(pos, this, markersExt.Count));
				nodeWithinRange++;
				ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
				selectedMarker = markersExt.Count - 1;
			}
			return selectedMarker;
		}

		public int HandleAddMarkerAtStart(Vector3 pos, int selectedMarker)
		{
			if (startPrefabScript == null)
			{
				markersExt.Insert(0, ERMarkerExt.CreateInstance(pos, this, 0));
				ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
				selectedMarker = 0;
			}
			return selectedMarker;
		}

		public void ReverseRoadmarkers()
		{
			markersExt.Reverse();
			int controlType = markersExt[markersExt.Count - 2].controlType;
			for (int i = 0; i < markersExt.Count - 1; i++)
			{
				markersExt[i].controlType = markersExt[i + 1].controlType;
			}
			markersExt[markersExt.Count - 1].controlType = 0;
			ERCrossingPrefabs eRCrossingPrefabs = startPrefabScript;
			int num = startConnectionSegment;
			if (endPrefabScript != null)
			{
				startPrefabScript = endPrefabScript;
				startConnectionSegment = endConnectionSegment;
				startPrefabScript.crossingElements[startConnectionSegment].connectedMarker = 0;
			}
			if (eRCrossingPrefabs != null)
			{
				endPrefabScript = eRCrossingPrefabs;
				endConnectionSegment = num;
				endPrefabScript.crossingElements[endConnectionSegment].connectedMarker = markersExt.Count - 1;
			}
			ERDecal eRDecal = startDecal;
			GameObject gameObject = startDecalPrefab;
			GameObject gameObject2 = startDecalPrefabSource;
			int num2 = startDecalID;
			startDecal = endDecal;
			startDecalPrefab = endDecalPrefab;
			startDecalID = endDecalID;
			startDecalPrefabSource = endDecalPrefabSource;
			endDecal = eRDecal;
			endDecalPrefab = gameObject;
			endDecalPrefabSource = gameObject2;
			endDecalID = num2;
			OQOCQDQODD.SwapIndentsSurroundings(this);
			OQOCQDQODD.SwapSideObjects(this);
		}

		public void OODCDQQQDD(ERCrossingPrefabs OCCDODCDCO, int targetElement, bool reverse, bool uvReverse, bool UpdateResolutionFlag, bool reset = false)
		{
			OQOCQDQODD.OCCCQQQCCD(this, OCCDODCDCO, targetElement, reverse, uvReverse, UpdateResolutionFlag, reset);
		}

		public void OCQCCOOODO(bool ignorePrefabAlignment, int selectedMarker)
		{
		}

		public void PrintRoadShape(List<Vector2> lst)
		{
			string text = "";
			for (int i = 0; i < lst.Count; i++)
			{
				text = text + lst[i].x + " " + lst[i].y + "; ";
			}
			Debug.Log(text);
		}

		public void ODDDQDQOOD(bool ignorePrefabAlignment, bool forceAutoRotate, bool updateIsSideObject = true)
		{
			if (id == 0)
			{
				id = (id = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
			}
			rotationsAdjustedFlag = false;
			lastRotationStartInt = 0;
			lastRotationEndInt = 0;
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
					Debug.Log("EasyRoads3Dv3 Warning: Unable to find road network script, please report. Are you using deeply nested connection prefabs? Road Object:" + base.gameObject.name);
					roadUpdate = false;
					return;
				}
			}
			if (surfaceMesh != null && surfaceMesh.GetComponent<MeshFilter>() != null)
			{
				surfaceMesh.GetComponent<MeshFilter>().sharedMesh = null;
			}
			if (baseScript.terrainCellAngleThreshold < 30f)
			{
				baseScript.terrainCellAngleThreshold = 30f;
			}
			float num = baseScript.terrainMinIndent;
			if (markersExt.Count > 0 && markersExt[0] != null)
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
			debugVecs.Clear();
			base.transform.position = Vector3.zero;
			lastForward = Vector3.zero;
			centerPivotPointsFlag = false;
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
				if (base.gameObject.GetComponent<MeshFilter>() != null && (bool)base.gameObject.GetComponent<MeshFilter>().sharedMesh)
				{
					base.gameObject.GetComponent<MeshFilter>().sharedMesh.Clear();
				}
				if (surfaceMesh != null && surfaceMesh.GetComponent<MeshFilter>() != null && surfaceMesh.GetComponent<MeshFilter>().sharedMesh != null)
				{
					surfaceMesh.GetComponent<MeshFilter>().sharedMesh.Clear();
				}
				roadUpdate = false;
				if (laneDirectionObject != null)
				{
					UnityEngine.Object.DestroyImmediate(laneDirectionObject);
				}
				foreach (ERSideWalkInstance leftSidewalk in leftSidewalks)
				{
					if (leftSidewalk.swObject != null)
					{
						UnityEngine.Object.DestroyImmediate(leftSidewalk.swObject);
					}
				}
				foreach (ERSideWalkInstance rightSidewalk in rightSidewalks)
				{
					if (rightSidewalk.swObject != null)
					{
						UnityEngine.Object.DestroyImmediate(rightSidewalk.swObject);
					}
				}
				foreach (GameObject crosswalkObject in crosswalkObjects)
				{
					if (crosswalkObject != null)
					{
						UnityEngine.Object.DestroyImmediate(crosswalkObject);
					}
				}
				ERSideObjectInstance[] componentsInChildren = base.gameObject.GetComponentsInChildren<ERSideObjectInstance>();
				ERSideObjectInstance[] array = componentsInChildren;
				foreach (ERSideObjectInstance eRSideObjectInstance in array)
				{
					UnityEngine.Object.DestroyImmediate(eRSideObjectInstance.gameObject);
				}
				return;
			}
			if ((rt == null && roadType != 0.0) || (rt != null && rt.id != roadType))
			{
				rt = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType, clone: true);
			}
			baseScript.dirtyOnSceneBool = true;
			if ((!sosCleared && baseScript != null) || spawnDirectionMarkings)
			{
				rebuildSos = OCQODDCQDD.OCOCDCQQOQ(baseScript, this);
				if ((rebuildSos && baseScript.buildSOinEditMode) || spawnDirectionMarkings)
				{
					if (!baseScript.RoadObjectsSoUpdates.Contains(this))
					{
						baseScript.RoadObjectsSoUpdates.Add(this);
					}
					if (isSideObject && updateIsSideObject)
					{
						forceSORefresh = true;
					}
				}
				sosCleared = true;
				if (laneDirectionObject != null && laneDirectionObject.GetComponent<MeshFilter>() != null && laneDirectionObject.GetComponent<MeshFilter>().sharedMesh != null)
				{
					laneDirectionObject.GetComponent<MeshFilter>().sharedMesh.Clear();
				}
			}
			if (baseScript != null && baseScript.surfaceChangeFlag && (baseScript.OOOCDDCQCD == this || baseScript.OCQODOCCCD == this))
			{
				if ((baseScript.OODOOQQDQD == 0 && startPrefabScript != null && !startPrefabScript.isIConnector && !startPrefabScript.isIConnector) || baseScript.OCQODOCCCD == this)
				{
					if (startPrefabScript.surfaceObject != null && (bool)startPrefabScript.surfaceObject.GetComponent<MeshFilter>() && startPrefabScript.surfaceObject.GetComponent<MeshFilter>().sharedMesh != null)
					{
						if (!startPrefabScript.isFlexConnector)
						{
							startPrefabScript.ODOQCOOOCC(ignorePriority: true, this);
						}
						else if (startPrefabScript.crossingsScript != null)
						{
							startPrefabScript.crossingsScript.UpdateAllConnectionAngles();
							startPrefabScript.crossingsScript.OCOQDOOOQC(null);
						}
						baseScript.surfaceChangeFlag = false;
					}
				}
				else if (baseScript.OODOOQQDQD == markersExt.Count - 1 && endPrefabScript != null && !endPrefabScript.isIConnector && endPrefabScript.surfaceObject != null && (bool)endPrefabScript.surfaceObject.GetComponent<MeshFilter>() && endPrefabScript.surfaceObject.GetComponent<MeshFilter>().sharedMesh != null)
				{
					if (!endPrefabScript.isFlexConnector)
					{
						endPrefabScript.ODOQCOOOCC(ignorePriority: true, this);
					}
					else if (endPrefabScript.crossingsScript != null)
					{
						endPrefabScript.crossingsScript.UpdateAllConnectionAngles();
						endPrefabScript.crossingsScript.OCOQDOOOQC(null);
					}
					baseScript.surfaceChangeFlag = false;
				}
			}
			baseScript.surfaceChangeFlag = false;
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
			if (base.gameObject.GetComponent<MeshCollider>() != null && roadPhysicsMaterial != null)
			{
				try
				{
					if (roadPhysicsMaterial == roadMaterial)
					{
						roadPhysicsMaterial = null;
					}
					base.gameObject.GetComponent<MeshCollider>().material = null;
					base.gameObject.GetComponent<MeshCollider>().material = roadPhysicsMaterial;
				}
				catch
				{
				}
			}
			else if (!(base.gameObject.GetComponent<MeshCollider>() != null))
			{
			}
			Mesh mesh;
			if (base.gameObject.GetComponent<MeshFilter>().sharedMesh != null)
			{
				mesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			else
			{
				mesh = new Mesh();
				mesh.MarkDynamic();
				mesh.name = "ER Road Mesh";
				base.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			if (!Application.isPlaying)
			{
				base.gameObject.isStatic = isStatic;
			}
			else
			{
				base.gameObject.isStatic = false;
			}
			if ((startPrefabScript != null && startConnectionSegment == -1) || (startPrefabScript == null && startConnectionSegment != -1) || (startPrefabScript != null && startConnectionSegment >= startPrefabScript.crossingElements.Count))
			{
				startPrefabScript = null;
				startConnectionSegment = -1;
			}
			if ((endPrefabScript != null && endConnectionSegment == -1) || (endPrefabScript == null && endConnectionSegment != -1) || (endPrefabScript != null && endConnectionSegment >= endPrefabScript.crossingElements.Count))
			{
				endPrefabScript = null;
				endConnectionSegment = -1;
			}
			bool flag = false;
			bool flag2 = false;
			Transform transform = null;
			Transform transform2 = null;
			if (startPrefabScript != null)
			{
				transform = startPrefabScript.transform;
				if (startPrefabScript.surfaceObject != null)
				{
					transform = startPrefabScript.surfaceObject.transform;
				}
				if (transform.eulerAngles.x != 0f || transform.eulerAngles.y != 0f)
				{
					flag = true;
				}
			}
			if (endPrefabScript != null)
			{
				transform2 = endPrefabScript.transform;
				if (endPrefabScript.surfaceObject != null)
				{
					transform2 = endPrefabScript.surfaceObject.transform;
				}
				if (transform2.eulerAngles.x != 0f || transform2.eulerAngles.y != 0f)
				{
					flag2 = true;
				}
			}
			bool flag3 = false;
			if (roadShape == null)
			{
				flag3 = true;
			}
			else if (roadShape.Count <= 1)
			{
				flag3 = true;
			}
			if (flag3 || roadShape.Count != roadShapeUVs.Count)
			{
				ODDOQDDQCQ.GetRoadShape(roadWidth, subSegments, ref roadShape, ref roadShapeUVs, ref roadShapeUVs2, -1f);
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
				for (int k = 1; k < roadShape.Count; k++)
				{
					if ((double)Vector2.Distance(roadShape[k - 1], roadShape[k]) > 0.01)
					{
						num3++;
					}
				}
				roadShapeMatchCount = num3;
				for (int l = 0; l < markersExt.Count; l++)
				{
					markersExt[l].roadShape = new List<Vector2>(roadShape);
				}
			}
			if (roadShapeUVs.Count != roadShape.Count)
			{
				roadShapeUVs.Clear();
				roadShapeUVs2.Clear();
				float num4 = 0f;
				for (int m = 0; m < roadShape.Count - 1; m++)
				{
					num4 += Vector2.Distance(roadShape[m], roadShape[m + 1]);
				}
				float num5 = 0f;
				roadShapeUVs.Add(0f);
				roadShapeUVs2.Add(0f);
				for (int n = 0; n < roadShape.Count - 1; n++)
				{
					num5 += Vector2.Distance(roadShape[n], roadShape[n + 1]);
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
				int num6 = 1;
				for (int num7 = 1; num7 < roadShape.Count; num7++)
				{
					if ((double)Vector2.Distance(roadShape[num7 - 1], roadShape[num7]) > 0.01)
					{
						num6++;
					}
				}
				roadShapeMatchCount = num6;
			}
			int num8 = 0;
			if (startPrefabScript != null && (roadShapeIntsStart.Count == 0 || roadShapeIntsStart.Count != roadShape.Count))
			{
				OQOCQDQODD.OCDOODDCOD(this, roadShape, null, 0);
			}
			if (endPrefabScript != null && (roadShapeIntsEnd.Count == 0 || roadShapeIntsEnd.Count != roadShape.Count))
			{
				OQOCQDQODD.OCDOODDCOD(this, roadShape, null, 1);
			}
			if (roadShape.Count != roadShapeMaterialInts.Count)
			{
				roadShapeMaterialInts.Clear();
				for (int num9 = 0; num9 < roadShape.Count; num9++)
				{
					roadShapeMaterialInts.Add(0);
				}
				num8 = 0;
			}
			if (roadShapeMaterialIntCounts.Count != roadMaterials.Length && roadShapeMaterialInts.Count > 0)
			{
				roadShapeMaterialIntCounts.Clear();
				for (int num10 = 0; num10 < roadShapeMaterialInts.Count; num10++)
				{
					if (roadShapeMaterialInts[num10] >= roadShapeMaterialIntCounts.Count)
					{
						while (roadShapeMaterialInts[num10] >= roadShapeMaterialIntCounts.Count)
						{
							roadShapeMaterialIntCounts.Add(0);
						}
					}
					roadShapeMaterialIntCounts[roadShapeMaterialInts[num10]]++;
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
				for (int num11 = 0; num11 < controlPoints.Count; num11++)
				{
					markersExt.Add(ERMarkerExt.CreateInstance(controlPoints[num11], this, markersExt.Count));
				}
			}
			tValues.Clear();
			markerDistances.Clear();
			bendAngles.Clear();
			doLeftSurrounding.Clear();
			doRightSurrounding.Clear();
			foreach (GameObject crosswalkObject2 in crosswalkObjects)
			{
				if (crosswalkObject2 != null)
				{
					UnityEngine.Object.DestroyImmediate(crosswalkObject2);
				}
			}
			crosswalkObjects.Clear();
			List<float> leftIndents = new List<float>();
			List<float> rightIndents = new List<float>();
			List<float> leftSurrounding = new List<float>();
			List<float> rightSurrounding = new List<float>();
			if (markersExt[0].roadShape.Count == 0)
			{
				foreach (ERMarkerExt item6 in markersExt)
				{
					item6.roadShape = new List<Vector2>(roadShape);
				}
			}
			if (angleTreshold < 1f)
			{
				angleTreshold = 1f;
			}
			randomRotations.Clear();
			randomLeftTerrainHeightOffset.Clear();
			randomRightTerrainHeightOffset.Clear();
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
			splinePoints = OCCQQDQODQ(markersExt, faceDistance, ignorePrefabAlignment, ref tValues, ref markerDistances, forceAutoRotate, ref randomRotations, ref bendAngles, ref randomLeftTerrainHeightOffset, ref randomRightTerrainHeightOffset);
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
			if (splinePoints.Count == 2)
			{
				splinePoints.Insert(1, Vector3.Lerp(splinePoints[0], splinePoints[1], 0.5f));
				tValues.Insert(1, Mathf.Lerp(tValues[0], tValues[1], 0.5f));
				randomRotations.Insert(1, Mathf.Lerp(randomRotations[0], randomRotations[1], 0.5f));
			}
			bool flag4 = true;
			bool flag5 = false;
			bool startSurfacesSafe = false;
			Vector3 vector = Vector3.zero;
			Vector3 startPrefabIndent = Vector3.zero;
			Vector3 oCCDODCDCOIndent = Vector3.zero;
			Vector3 a = Vector3.zero;
			Vector3 zero = Vector3.zero;
			bool flag6 = false;
			float num12 = 0f;
			int num13 = -1;
			float num14 = 0f;
			Vector3 a2 = Vector3.zero;
			Vector3 startPrefabIndent2 = Vector3.zero;
			Vector3 oCCDODCDCOIndent2 = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			float num15 = 0f;
			int num16 = -1;
			int endAdjustInt = 0;
			float num17 = 0f;
			float num18 = 30f;
			if (totalDistance < num18)
			{
				num18 = totalDistance;
			}
			if (totalDistance * 0.5f < num18)
			{
				num18 = totalDistance * 0.5f;
			}
			bool flag7 = false;
			if (startPrefabScript != null && endPrefabScript != null && markersExt.Count == 2)
			{
				flag7 = true;
				if (num18 > totalDistance - baseScript.minIndent * 2f * 0.5f)
				{
					num18 = totalDistance - baseScript.minIndent * 2f * 0.5f;
				}
			}
			if (flag7 && totalDistance * 0.5f < num18)
			{
				num18 = totalDistance * 0.5f;
			}
			float num19 = num18;
			if (num19 < markersExt[0].totalDistance && !flag7)
			{
				num19 = markersExt[0].totalDistance;
			}
			float endAdjustDistance = num18;
			if (markersExt.Count > 1 && endAdjustDistance < markersExt[markersExt.Count - 2].totalDistance && !flag7)
			{
				endAdjustDistance = markersExt[markersExt.Count - 2].totalDistance;
			}
			if (!closedTrack)
			{
				markersExt[markersExt.Count - 2].totalDistance = totalDistance - markersExt[markersExt.Count - 2].startDistance;
			}
			if (endAdjustDistance < markersExt[markersExt.Count - 2].totalDistance && !flag7)
			{
				endAdjustDistance = markersExt[markersExt.Count - 2].totalDistance;
			}
			int num20 = 0;
			int num21 = roadShape.Count - 1;
			if (startPrefabScript == null && endPrefabScript == null)
			{
				float num22 = 100000f;
				float num23 = -100000f;
				for (int num24 = 0; num24 < roadShape.Count; num24++)
				{
					if (roadShape[num24].x < num22 || (roadShape[num24].x == num22 && roadShape[num24].y < roadShape[num21].y))
					{
						num21 = num24;
						num22 = roadShape[num24].x;
					}
					if (roadShape[num24].x > num23 || (roadShape[num24].x == num23 && roadShape[num24].y < roadShape[num20].y))
					{
						num20 = num24;
						num23 = roadShape[num24].x;
					}
				}
			}
			bool flag8 = false;
			if (startPrefabScript != null && (!startPrefabScript.isSnapConnector || startPrefabScript.isExitRoadConnector))
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
					num20 = qDOODOQQDQODD.leftInt;
					num21 = qDOODOQQDQODD.rightInt;
				}
				if (roadShape.Count == qDOODOQQDQODD.connectionVecInts.Count)
				{
					flag8 = true;
				}
				if (!isSideObject || startPrefabScript.tmpMeshVecs.Length != 0)
				{
					if (startPrefabScript.isCustomPrefab)
					{
						OCQOOQODCQ = startPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.rightInt]];
					}
					else if (startPrefabScript.tmpFullMeshVecs.Length != 0)
					{
						OCQOOQODCQ = startPrefabScript.tmpFullMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.rightInt]];
					}
				}
				Vector3 oCQOOQODCQ = OCQOOQODCQ;
				OCQOOQODCQ = startPrefabScript.transform.TransformPoint(OCQOOQODCQ);
				if (!isSideObject || startPrefabScript.tmpMeshVecs.Length != 0)
				{
					if (startPrefabScript.isCustomPrefab)
					{
						OQQCCQDCOO = startPrefabScript.tmpMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.leftInt]];
					}
					else if (startPrefabScript.tmpFullMeshVecs.Length != 0)
					{
						OQQCCQDCOO = startPrefabScript.tmpFullMeshVecs[qDOODOQQDQODD.connectionVecInts[qDOODOQQDQODD.leftInt]];
					}
				}
				Vector3 oQQCCQDCOO = OQQCCQDCOO;
				OQQCCQDCOO = startPrefabScript.transform.TransformPoint(OQQCCQDCOO);
				if (startPrefabScript.crossingElements[startConnectionSegment].leftIndentV3 != Vector3.zero)
				{
					startPrefabIndent = startPrefabScript.transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].leftIndentV3);
				}
				else
				{
					startPrefabIndent = oCQOOQODCQ;
					startPrefabIndent.y = 0f;
					startPrefabIndent = startPrefabScript.transform.TransformPoint(startPrefabIndent);
				}
				if (startPrefabScript.crossingElements[startConnectionSegment].rightIndentV3 != Vector3.zero)
				{
					oCCDODCDCOIndent = startPrefabScript.transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].rightIndentV3);
				}
				else
				{
					oCCDODCDCOIndent = oQQCCQDCOO;
					oCCDODCDCOIndent.y = 0f;
					oCCDODCDCOIndent = startPrefabScript.transform.TransformPoint(oCCDODCDCOIndent);
				}
				a = startPrefabScript.transform.TransformPoint(Vector3.zero);
				zero = startPrefabScript.transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].tmpCenterPoint);
				num12 = startPrefabScript.crossingElements[startConnectionSegment].additionalIndentDistance;
				flag6 = false;
				if (startPrefabScript.isExitRoadConnector)
				{
					a = startPrefabScript.prefabCenterDummy;
				}
				float num25 = Vector3.Distance(splinePoints[0], zero) - 0.75f * faceDistance;
				Vector3 a3 = splinePoints[0];
				if (startPrefabScript.tCrossing && startConnectionSegment <= 1)
				{
					float num26 = Vector3.Distance(a, zero);
					for (int num27 = 0; num27 < splinePoints.Count && Vector3.Distance(a3, splinePoints[num27]) < num25; num27++)
					{
						splinePoints.RemoveAt(0);
						tValues.RemoveAt(0);
						num27--;
					}
				}
				num13 = ((startbendLeftRight != -1) ? OQOCQDQODD.OCQCOODQDD(this, splinePoints, baseScript.terrainMinIndent, roadShape[roadShape.Count - 1].x, oCCDODCDCOIndent, startPrefabIndent, startbendLeftRight) : OQOCQDQODD.OCQCOODQDD(this, splinePoints, baseScript.terrainMinIndent, roadShape[0].x, oCCDODCDCOIndent, startPrefabIndent, startbendLeftRight));
			}
			else
			{
				flag5 = true;
				startSurfacesSafe = true;
			}
			int num28 = 0;
			bool surfacesSafe = true;
			bool flag9 = false;
			if (endPrefabScript != null && (!endPrefabScript.isSnapConnector || endPrefabScript.isExitRoadConnector))
			{
				surfacesSafe = false;
				QDOODOQQDQODD qDOODOQQDQODD2 = endPrefabScript.crossingElements[endConnectionSegment];
				qDOODOQQDQODD2.connectedMarker = markersExt.Count - 1;
				if (qDOODOQQDQODD2.rightInt == 0 && qDOODOQQDQODD2.leftInt == 0)
				{
					qDOODOQQDQODD2.leftInt = 0;
					qDOODOQQDQODD2.rightInt = qDOODOQQDQODD2.connectionVecInts.Count - 1;
					qDOODOQQDQODD2.leftIntFull = 0;
					qDOODOQQDQODD2.rightIntFull = qDOODOQQDQODD2.fullConnectionVecInts.Count - 1;
				}
				if (roadShape.Count > qDOODOQQDQODD2.leftInt && roadShape.Count > qDOODOQQDQODD2.rightInt)
				{
					num20 = qDOODOQQDQODD2.leftInt;
					num21 = qDOODOQQDQODD2.rightInt;
				}
				if (roadShape.Count == qDOODOQQDQODD2.connectionVecInts.Count)
				{
					flag9 = true;
				}
				if (endPrefabScript.isCustomPrefab)
				{
					endLeft = endPrefabScript.tmpMeshVecs[qDOODOQQDQODD2.connectionVecInts[qDOODOQQDQODD2.leftInt]];
				}
				else if (qDOODOQQDQODD2.leftInt >= 0 && qDOODOQQDQODD2.leftInt < qDOODOQQDQODD2.connectionVecInts.Count)
				{
					endLeft = endPrefabScript.tmpFullMeshVecs[qDOODOQQDQODD2.connectionVecInts[qDOODOQQDQODD2.leftInt]];
				}
				Vector3 vector3 = endLeft;
				endLeft = endPrefabScript.transform.TransformPoint(endLeft);
				if (!isSideObject || endPrefabScript.tmpMeshVecs.Length != 0)
				{
					if (endPrefabScript.isCustomPrefab)
					{
						endRight = endPrefabScript.tmpMeshVecs[qDOODOQQDQODD2.connectionVecInts[qDOODOQQDQODD2.rightInt]];
					}
					else if (qDOODOQQDQODD2.rightInt >= 0 && qDOODOQQDQODD2.rightInt < qDOODOQQDQODD2.connectionVecInts.Count)
					{
						endRight = endPrefabScript.tmpFullMeshVecs[qDOODOQQDQODD2.connectionVecInts[qDOODOQQDQODD2.rightInt]];
					}
				}
				Vector3 vector4 = endRight;
				endRight = endPrefabScript.transform.TransformPoint(endRight);
				num28 = Mathf.RoundToInt(Mathf.Ceil(roadWidth / (faceDistance * 1f)));
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
					oCCDODCDCOIndent2 = endPrefabScript.transform.TransformPoint(endPrefabScript.crossingElements[endConnectionSegment].rightIndentV3);
				}
				else
				{
					oCCDODCDCOIndent2 = vector4;
					oCCDODCDCOIndent2.y = 0f;
					oCCDODCDCOIndent2 = endPrefabScript.transform.TransformPoint(oCCDODCDCOIndent2);
				}
				vector2 = endPrefabScript.transform.TransformPoint(Vector3.zero);
				zero2 = endPrefabScript.transform.TransformPoint(endPrefabScript.crossingElements[endConnectionSegment].tmpCenterPoint);
				num15 = endPrefabScript.crossingElements[endConnectionSegment].additionalIndentDistance;
				if (endPrefabScript.isExitRoadConnector)
				{
					vector2 = endPrefabScript.prefabCenterDummy;
				}
				if (endPrefabScript.tCrossing && endConnectionSegment <= 1)
				{
					float num29 = Vector3.Distance(vector2, zero2);
					for (int count = splinePoints.Count; count < splinePoints.Count; count--)
					{
						if (!(num29 > -1f + Vector3.Distance(splinePoints[0], vector2)))
						{
							break;
						}
						splinePoints.RemoveAt(count);
						tValues.RemoveAt(count);
						count++;
					}
				}
				num16 = ((endbendLeftRight != -1) ? OQOCQDQODD.ODDOQQQCCC(this, splinePoints, baseScript.minIndent, roadShape[0].x, oCCDODCDCOIndent2, startPrefabIndent2, endbendLeftRight, ref endAdjustInt, ref endAdjustDistance) : OQOCQDQODD.ODDOQQQCCC(this, splinePoints, baseScript.minIndent, roadShape[roadShape.Count - 1].x, oCCDODCDCOIndent2, startPrefabIndent2, endbendLeftRight, ref endAdjustInt, ref endAdjustDistance));
			}
			bool flag10 = false;
			if (startPrefabScript != null && startPrefabScript.surfaceMeshVecs != null && startPrefabScript.surfaceMeshVecs.Length == 0 && startPrefabScript.doTerrainDeformation)
			{
				flag10 = true;
			}
			bool flag11 = false;
			if (endPrefabScript != null && endPrefabScript.surfaceMeshVecs != null && endPrefabScript.surfaceMeshVecs.Length == 0 && endPrefabScript.doTerrainDeformation)
			{
				flag11 = true;
			}
			if (!isSideObject)
			{
				OCDCDDDQOC.OCOQQDDDOD(markersExt, exitRoads, ref splinePoints, ref tValues);
			}
			soSplinePoints = new List<Vector3>(splinePoints);
			soSplinePointsLeft = new List<Vector3>(splinePoints);
			soSplinePointsRight = new List<Vector3>(splinePoints);
			soSplinePointsLeftClamped = new List<Vector3>(splinePoints);
			soSplinePointsRightClamped = new List<Vector3>(splinePoints);
			distances.Clear();
			if (isSideObject)
			{
				insertSplinePoints.Clear();
				insertSplinePoints.AddRange(splinePoints);
				lastForward = (soSplinePoints[soSplinePoints.Count - 1] - soSplinePoints[soSplinePoints.Count - 2]).normalized;
				OCOQOCQDDC(null);
				if (markerInts.Count != splinePoints.Count)
				{
					markerInts.Clear();
					int num30 = 0;
					for (int num31 = 0; num31 < splinePoints.Count; num31++)
					{
						markerInts.Add(num30);
						if (num30 + 1 < markersExt.Count && num31 == markersExt[num30 + 1].startSplinePoint)
						{
							num30++;
						}
					}
				}
				if (!baseScript.ctrlKey && updateIsSideObject)
				{
					OCQODDCQDD.OOODQOOOCO(baseScript, this, isSideObjectFlag: true);
				}
				roadUpdate = false;
				return;
			}
			List<List<Vector2>> roadShapeValues = GetRoadShapeValues(tValues, markerDistances, markersExt, 0, tmpMarkersExt.Count, roadShape);
			if (roadShapeValues[0].Count != splinePoints.Count)
			{
				for (int num32 = 0; num32 < roadShapeValues.Count; num32++)
				{
					if (roadShapeValues[num32].Count == 0)
					{
						roadShapeValues[num32].Add(markersExt[0].roadShape[num32]);
					}
					for (int count2 = roadShapeValues[num32].Count; count2 < splinePoints.Count; count2++)
					{
						roadShapeValues[num32].Add(roadShapeValues[num32][roadShapeValues[num32].Count - 1]);
					}
				}
			}
			if (markersExt.Count > 1)
			{
				GetSurfaceValues(tValues, markerDistances, markersExt, 0, tmpMarkersExt.Count, ref leftIndents, ref rightIndents, ref leftSurrounding, ref rightSurrounding, num);
			}
			if (leftIndents.Count < splinePoints.Count)
			{
				if (leftIndents.Count == 0)
				{
					leftIndents.Add(markersExt[0].leftIndent);
					rightIndents.Add(markersExt[0].rightIndent);
					leftSurrounding.Add(markersExt[0].leftSurrounding);
					rightSurrounding.Add(markersExt[0].rightSurrounding);
				}
				for (int count3 = leftIndents.Count; count3 < splinePoints.Count; count3++)
				{
					leftIndents.Add(leftIndents[0]);
					rightIndents.Add(rightIndents[0]);
					leftSurrounding.Add(leftSurrounding[0]);
					rightSurrounding.Add(rightSurrounding[0]);
				}
			}
			List<Vector3> vecs = new List<Vector3>();
			List<Vector2> uvs = new List<Vector2>();
			List<Vector2> uvs2 = new List<Vector2>();
			List<Vector3> surfaceVecs = new List<Vector3>();
			List<Vector2> list = new List<Vector2>();
			if (indent < baseScript.terrainMinIndent)
			{
				indent = baseScript.terrainMinIndent;
			}
			if (surrounding < 1f)
			{
				surrounding = 1f;
			}
			float terrainMinIndent = baseScript.terrainMinIndent;
			treeVecs.Clear();
			detailVecs.Clear();
			vegetationTris.Clear();
			vegetationTreeTris.Clear();
			leftIndentVecs.Clear();
			rightIndentVecs.Clear();
			middleIndentVecs.Clear();
			leftSurroundingVecs.Clear();
			rightSurroundingVecs.Clear();
			leftIndentVecsSV.Clear();
			rightIndentVecsSV.Clear();
			tris.Clear();
			for (int num33 = 0; num33 < roadMaterials.Length; num33++)
			{
				tris.Add(new List<int>());
			}
			int num34 = 0;
			float num35 = 0f;
			float num36 = 0f;
			float num37 = 0f;
			float num38 = 0f;
			float num39 = 0f;
			if (uvTiling == 0f)
			{
				uvTiling = 1f;
			}
			float num40 = 5f * uvTiling;
			if (roadShape[0].x != roadShape[roadShape.Count - 1].x)
			{
				roadWidth = Vector2.Distance(new Vector2(roadShape[0].x, 0f), new Vector2(roadShape[roadShape.Count - 1].x, 0f));
			}
			else
			{
				float num41 = 10000f;
				float num42 = -10000f;
				for (int num43 = 0; num43 < roadShape.Count; num43++)
				{
					if (roadShape[num43].x < num41)
					{
						num41 = roadShape[num43].x;
					}
					if (roadShape[num43].x > num42)
					{
						num42 = roadShape[num43].x;
					}
				}
				roadWidth = num42 - num41;
			}
			leftToCenterPerc = 0f;
			if (leftToCenterPerc == 0f)
			{
				if (num20 >= roadShape.Count || num21 >= roadShape.Count)
				{
					Debug.LogWarning("EasyRoasds3D Warning: the road shape does not match: " + base.gameObject.name);
					roadUpdate = false;
					return;
				}
				if (num21 == -1)
				{
					num21 = roadShape.Count - 1;
				}
				leftToCenterPerc = OODCDDQOQC.GetleftToCenterPerc(roadShape, num20, num21);
			}
			nodeDistance.Clear();
			nodeDistance.Add(0f);
			for (int num44 = 1; num44 < roadShape.Count; num44++)
			{
				nodeDistance.Add(Vector2.Distance(new Vector2(roadShape[0].x, 0f), new Vector2(roadShape[num44].x, 0f)) / roadWidth);
				if (roadShape[num44 - 1].x <= 0f && roadShape[num44].x >= 0f)
				{
					num8 = roadShapeMaterialInts[num44];
				}
			}
			Vector3 zero3 = Vector3.zero;
			int num45 = 0;
			bool flag12 = false;
			bool flag13 = false;
			List<bool> list2 = new List<bool>();
			List<float> list3 = new List<float>();
			Vector3 firstDir = Vector3.zero;
			Vector3 vector5 = Vector3.zero;
			wssst = -1;
			xssss = -1;
			if (hardEdge.Count == 0 || hardEdge.Count != roadShape.Count)
			{
				hardEdge.Clear();
				for (int num46 = 0; num46 < roadShape.Count; num46++)
				{
					hardEdge.Add(item: false);
				}
			}
			if (doConnectionTri.Count != roadShape.Count)
			{
				doConnectionTri.Clear();
				for (int num47 = 0; num47 < roadShape.Count; num47++)
				{
					doConnectionTri.Add(item: true);
				}
			}
			int num48 = num20;
			int num49 = num21;
			int count4 = roadShape.Count;
			int num50 = 0;
			List<int> list4 = new List<int>();
			for (int num51 = 0; num51 < hardEdge.Count; num51++)
			{
				if (hardEdge[num51] && num51 > 0 && num51 < hardEdge.Count - 1)
				{
					count4++;
					list4.Add(num50);
					num50++;
				}
				if (num51 == num20)
				{
					num48 = num20 + num50;
				}
				if (num51 == num21)
				{
					num49 = num21 + num50;
				}
				list4.Add(num50);
			}
			float y = roadShape[num20].y;
			float y2 = roadShape[num21].y;
			int count5 = hardEdge.Count;
			roadShapeCols = count4;
			int[] array2 = new int[count4];
			int[] array3 = new int[count4];
			bool[] array4 = new bool[count4];
			bool[] array5 = new bool[count4];
			List<bool> isPlanar = new List<bool>();
			float num52 = 0.5f;
			if (baseScript.terrainMinIndent > 0.5f * roadWidth)
			{
				num52 = baseScript.terrainMinIndent / roadWidth;
				if ((double)num52 > 0.9)
				{
					num52 = 0.9f;
				}
			}
			num52 = 0.2f;
			Vector2 zero4 = Vector2.zero;
			bool flag14 = true;
			bool flag15 = true;
			bool flag16 = true;
			float num53 = 0f;
			float num54 = 0f;
			float num55 = 0f;
			bool flag17 = true;
			List<Color> colors = new List<Color>();
			Color customColor = markersExt[0].customColor;
			float num56 = 0f;
			float num57 = 0f;
			float num58 = 0f;
			if (uv4Type == 1)
			{
				num58 = Mathf.Floor(totalDistance / detailDistance);
				num56 = ((num58 != 0f) ? (totalDistance / num58) : totalDistance);
			}
			if (roadShapeUVs.Count != roadShapeUVs2.Count)
			{
				roadShapeUVs2 = new List<float>(roadShapeUVs);
			}
			Vector2 item = new Vector2(0f, 0f);
			if (rt != null && rt.type == ERRoadWayType.MotorwayRamp)
			{
				item = new Vector2(0f, 1f);
			}
			int num59 = 0;
			int addedRows = 0;
			float num60 = 0f;
			float roadUvThreshold = baseScript.roadUvThreshold;
			bool flag18 = false;
			List<int> list5 = new List<int>();
			int count6 = roadShape.Count;
			int num61 = num20;
			int num62 = num21;
			List<float> list6 = new List<float>(roadShapeUVs);
			List<bool> list7 = new List<bool>(hardEdge);
			List<Vector2> list8 = new List<Vector2>();
			List<Vector2> list9 = new List<Vector2>();
			List<float> collection = new List<float>();
			List<bool> list10 = new List<bool>();
			List<bool> list11 = new List<bool>();
			int currentMostLeftInt = 0;
			int currentMostRightInt = 0;
			int sectionRoadShapeCols = 0;
			List<Vector2> list12 = new List<Vector2>();
			List<float> collection2 = new List<float>();
			List<bool> list13 = new List<bool>();
			List<bool> list14 = new List<bool>();
			int currentMostLeftInt2 = 0;
			int currentMostRightInt2 = 0;
			int sectionRoadShapeCols2 = 0;
			List<Vector2> list15 = new List<Vector2>();
			List<float> collection3 = new List<float>();
			List<bool> list16 = new List<bool>();
			List<bool> list17 = new List<bool>();
			int num63 = 0;
			int num64 = 0;
			int num65 = 0;
			bool flag19 = false;
			int num66 = 0;
			int num67 = -1;
			int num68 = -1;
			int num69 = -1;
			if (exitRoads.Count > 0)
			{
				flag19 = true;
				num67 = exitRoads[num66].startSplineIndex;
				num68 = exitRoads[num66].fixedDistanceIndex;
				num69 = exitRoads[num66].endSplineIndex;
			}
			bool flag20 = false;
			int num70 = 0;
			List<SideObject> list18 = new List<SideObject>();
			List<SideObject> list19 = new List<SideObject>();
			List<SideObject> list20 = new List<SideObject>();
			List<SideObject> list21 = new List<SideObject>();
			List<SideObject> list22 = new List<SideObject>();
			float num71 = 1000f;
			float num72 = 1000f;
			float num73 = 1000f;
			float num74 = 1000f;
			float num75 = 1000f;
			float num76 = 1000f;
			float num77 = 1000f;
			float num78 = -1000f;
			bool flag21 = false;
			bool flag22 = false;
			bool flag23 = false;
			bool flag24 = false;
			bool flag25 = false;
			bool flag26 = false;
			List<float> list23 = new List<float>();
			List<float> list24 = new List<float>();
			List<float> list25 = new List<float>();
			bool flag27 = false;
			bool flag28 = false;
			bridgeAtStart = false;
			bridgeAtEnd = false;
			for (int num79 = 0; num79 < soDataExt.Count; num79++)
			{
				if (soDataExt[num79].active && soDataExt[num79].sideObject != null && soDataExt[num79].autoGenerate)
				{
					if (soDataExt[num79].sideObject.tunnelObject)
					{
						list18.Add(soDataExt[num79].sideObject);
						num75 = soDataExt[num79].sideObject.heightThreshold;
						if (num75 < soDataExt[num79].sideObject.y1)
						{
							num75 = soDataExt[num79].sideObject.y1 + 1f;
						}
						flag28 = true;
					}
					if (soDataExt[num79].sideObject.bridgeObject)
					{
						list19.Add(soDataExt[num79].sideObject);
						if (soDataExt[num79].sideObject.heightThreshold < num76)
						{
							num76 = soDataExt[num79].sideObject.heightThreshold;
						}
						flag28 = true;
					}
					if (soDataExt[num79].sideObject.category == 0 && !soDataExt[num79].sideObject.tunnelObject && !soDataExt[num79].sideObject.bridgeObject)
					{
						list20.Add(soDataExt[num79].sideObject);
						if (soDataExt[num79].sideObject.angleThreshold < num72)
						{
							num72 = soDataExt[num79].sideObject.angleThreshold;
						}
						if (soDataExt[num79].sideObject.heightThreshold < num74)
						{
							num74 = soDataExt[num79].sideObject.heightThreshold;
						}
						flag28 = true;
					}
					if (soDataExt[num79].sideObject.category == 4 && soDataExt[num79].sideObject.autoGenerate && !soDataExt[num79].sideObject.tunnelObject && !soDataExt[num79].sideObject.bridgeObject)
					{
						list21.Add(soDataExt[num79].sideObject);
						if (soDataExt[num79].sideObject.angleThreshold < num73)
						{
							num73 = soDataExt[num79].sideObject.angleThreshold;
						}
						flag28 = true;
					}
					if (soDataExt[num79].sideObject.category == 2 && soDataExt[num79].sideObject.autoGenerate && soDataExt[num79].sideObject.retainingWall && !soDataExt[num79].sideObject.tunnelObject && !soDataExt[num79].sideObject.bridgeObject)
					{
						list22.Add(soDataExt[num79].sideObject);
						if (soDataExt[num79].sideObject.heightThreshold < num77)
						{
							num77 = soDataExt[num79].sideObject.heightThreshold;
						}
						if (soDataExt[num79].sideObject.heightMaxThreshold > num78)
						{
							num78 = soDataExt[num79].sideObject.heightMaxThreshold;
						}
						flag28 = true;
					}
				}
				else
				{
					if (!soDataExt[num79].active || !(soDataExt[num79].sideObject != null) || soDataExt[num79].autoGenerate || !soDataExt[num79].sideObject.bridgeObject || soDataExt[num79].sideObject.objectType != 1 || !soDataExt[num79].sideObject.continueOnConnections)
					{
						continue;
					}
					foreach (ERSOMarkerExt soDatum2 in markersExt[0].soData)
					{
						if (soDatum2.id == soDataExt[num79].sideObject.id && soDatum2.active && soDatum2.startOffset == 0f && soDatum2.otherSide != null && soDatum2.otherSide.active && soDatum2.otherSide.startOffset == 0f)
						{
							bridgeAtStart = true;
						}
					}
					foreach (ERSOMarkerExt soDatum3 in markersExt[markersExt.Count - 2].soData)
					{
						if (soDatum3.id == soDataExt[num79].sideObject.id && soDatum3.active && soDatum3.endOffset == 0f && soDatum3.otherSide != null && soDatum3.otherSide.active && soDatum3.otherSide.endOffset == 0f)
						{
							bridgeAtEnd = true;
						}
					}
				}
			}
			int num80 = 0;
			bool flag29 = false;
			ERSOSection eRSOSection = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
			ERSOSection eRSOSection2 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
			ERSOSection eRSOSection3 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
			bool flag30 = false;
			int num81 = 0;
			if (true)
			{
				bendAngles.Clear();
				bendAngles.Add(0f);
				bendAngles.Add(0f);
				for (int num82 = 2; num82 < splinePoints.Count - 1; num82++)
				{
					Vector3 normalized = (splinePoints[num82 - 1] - splinePoints[num82]).normalized;
					Vector3 normalized2 = (splinePoints[num82] - splinePoints[num82 + 1]).normalized;
					float num83 = Vector3.Angle(normalized, normalized2);
					float num84 = Vector3.Distance(splinePoints[num82 - 1], splinePoints[num82]);
					if (num84 > 5f)
					{
						bendAngles.Add(Mathf.Round(num83));
					}
					else
					{
						bendAngles.Add(Mathf.Round(num83 / num84 * 5f));
					}
				}
				bendAngles.Add(0f);
				SideObject sideObject = null;
				SideObject sideObject2 = null;
				if (list18.Count > 0)
				{
					bool flag31 = false;
					if (soSectionList1.Count > 0)
					{
						flag31 = OCQODDCQDD.OQQDQDQCDO(list18, soSectionList1[0].so);
					}
					if (soSectionList1.Count > 0 && flag31)
					{
						sideObject = soSectionList1[0].so;
						eRSOSection = soSectionList1[0];
					}
					else
					{
						sideObject = (eRSOSection.so = list18[0]);
						eRSOSection.OODDCOCDOD();
					}
					num75 = sideObject.heightThreshold;
				}
				else
				{
					soSectionList1.Clear();
				}
				if (list19.Count > 0)
				{
					if (soSectionList2.Count > 0)
					{
						sideObject2 = soSectionList2[0].so;
					}
					else
					{
						sideObject2 = list19[0];
					}
				}
				else
				{
					soSectionList2.Clear();
				}
				list23.Add(0f);
				list24.Add(0f);
				list25.Add(0f);
				distances.Add(0f);
				float num85 = 0f;
				float num86 = roadWidth * 0.5f;
				Vector3 zero5;
				Vector3 vector6 = (zero5 = Vector3.zero);
				int num88;
				int num87 = (num88 = 0);
				float num90;
				float num91;
				float num89;
				float startFraction = (num89 = (num90 = (num91 = 0f)));
				int num92 = 0;
				bool flag32 = false;
				int num93 = 0;
				bool flag33 = false;
				float num94 = 0f;
				bool snappedMarker = markersExt[0].snappedMarker;
				List<float> list26 = new List<float>();
				List<float> list27 = new List<float>();
				List<float> list28 = new List<float>();
				int num95 = 0;
				int count7 = markersExt.Count;
				float num96 = 0f;
				for (int num97 = 1; num97 < splinePoints.Count; num97++)
				{
					if (num95 < count7 - 1 && num97 == markersExt[num95 + 1].startSplinePoint - 1)
					{
						num95++;
						if (num95 >= markersExt.Count)
						{
							num95 = markersExt.Count - 1;
						}
						snappedMarker = markersExt[num95].snappedMarker;
						if (snappedMarker && flag22)
						{
							flag22 = false;
						}
					}
					num96 += Vector3.Distance(splinePoints[num97 - 1], splinePoints[num97]);
					distances.Add(num96);
					Vector3 vector7 = ((num97 >= splinePoints.Count - 1) ? (splinePoints[num97] - splinePoints[num97 - 1]) : (splinePoints[num97 + 1] - splinePoints[num97 - 1]));
					vector7 = new Vector3(vector7.z, 0f, 0f - vector7.x).normalized;
					Vector3 pos = splinePoints[num97] - vector7 * num86;
					Vector3 pos2 = splinePoints[num97] + vector7 * num86;
					Vector3 pos3;
					Vector3 vector8 = (pos3 = splinePoints[num97]);
					baseScript.OQCCDQOQOO(ref pos);
					baseScript.OQCCDQOQOO(ref pos2);
					baseScript.OQCCDQOQOO(ref pos3);
					list23.Add(vector8.y - pos.y);
					list24.Add(vector8.y - pos2.y);
					if (!flag21 && list18.Count > 0)
					{
						if (pos.y - vector8.y > num75 && pos2.y - vector8.y > num75)
						{
							if (num97 == 1)
							{
								flag30 = true;
							}
							float num98 = 10f;
							float num99 = 0f;
							float num100 = num96;
							for (int num101 = num97 + 1; num101 < splinePoints.Count - 1; num101++)
							{
								num100 += Vector3.Distance(splinePoints[num97 - 1], splinePoints[num97]);
								list26.Add(num100);
								vector7 = ((num97 >= splinePoints.Count - 1) ? (splinePoints[num101] - splinePoints[num101 - 1]) : (splinePoints[num101 + 1] - splinePoints[num101 - 1]));
								vector7 = new Vector3(vector7.z, 0f, 0f - vector7.x).normalized;
								pos = splinePoints[num101] - vector7 * num86;
								pos2 = splinePoints[num101] + vector7 * num86;
								vector8 = (pos3 = splinePoints[num101]);
								baseScript.OQCCDQOQOO(ref pos);
								baseScript.OQCCDQOQOO(ref pos2);
								baseScript.OQCCDQOQOO(ref pos3);
								list27.Add(vector8.y - pos.y);
								list28.Add(vector8.y - pos2.y);
								Vector3 pos4 = splinePoints[num101];
								baseScript.OQCCDQOQOO(ref pos4);
								if (pos4.y - splinePoints[num101].y > num75)
								{
									num99 += Vector3.Distance(splinePoints[num101], splinePoints[num101 + 1]);
									if (!(num99 > num98))
									{
										continue;
									}
									Vector3 b;
									Vector3 vector9;
									Vector3 a4 = (b = (pos4 = (vector9 = (vector6 = splinePoints[num97]))));
									if (num97 > 0)
									{
										a4 = splinePoints[num97 - 1];
									}
									float num102 = Vector3.Distance(a4, b);
									float num103 = 1f / (num102 / 0.5f);
									for (float num104 = num103; num104 < 1f; num104 += num103)
									{
										pos4 = (vector9 = Vector3.Lerp(a4, b, num104));
										baseScript.OQCCDQOQOO(ref pos4);
										if (pos4.y - splinePoints[num101].y > num75)
										{
											vector6 = vector9;
											break;
										}
									}
									num90 = OQQOCDQCQD.OCCOCQQCCQ(baseScript.activeTerrain, splinePoints[num97 - 1], splinePoints[num97]);
									vector9 = vector6;
									float num105 = num90 + eRSOSection.innerStartOffset;
									int num106 = num97 - 1;
									while (num105 > 0f && num106 > 0)
									{
										num99 = Vector3.Distance(splinePoints[num106], vector9);
										if (num99 > num105)
										{
											float t = num105 / num99;
											vector6 = Vector3.Lerp(vector9, splinePoints[num106], t);
											num87 = num106 + 1;
											startFraction = Vector3.Distance(splinePoints[num106], vector6) / Vector3.Distance(splinePoints[num106], splinePoints[num106 + 1]);
											num105 = 0f;
										}
										else
										{
											num105 -= num99;
											vector9 = splinePoints[num106];
											num106--;
										}
									}
									flag21 = true;
									num97 = num101;
									distances.AddRange(list26);
									num96 = num100;
									list26.Clear();
									list23.AddRange(list27);
									list24.AddRange(list28);
									list27.Clear();
									list28.Clear();
									while (soSectionList1.Count > num92)
									{
										if (Vector3.Distance(soSectionList1[num92].startPosition, splinePoints[num87]) < 20f)
										{
											eRSOSection = soSectionList1[num92];
											if (OCQODDCQDD.OQQDQDQCDO(list18, eRSOSection.so))
											{
												sideObject = eRSOSection.so;
											}
											else
											{
												sideObject = (eRSOSection.so = list18[0]);
												eRSOSection.OODDCOCDOD();
											}
											num92++;
											flag32 = true;
											break;
										}
										if (Mathf.Abs(soSectionList1[num92].startDistance - distances[num97]) < 10f)
										{
											eRSOSection = soSectionList1[num92];
											if (OCQODDCQDD.OQQDQDQCDO(list18, eRSOSection.so))
											{
												sideObject = eRSOSection.so;
											}
											else
											{
												sideObject = (eRSOSection.so = list18[0]);
												eRSOSection.OODDCOCDOD();
											}
											num92++;
											flag32 = true;
											break;
										}
										if (soSectionList1[num92].startDistance < distances[num97])
										{
											soSectionList1.RemoveAt(num92);
											continue;
										}
										break;
									}
									break;
								}
								num97 = num101;
								distances.AddRange(list26);
								num96 = num100;
								list26.Clear();
								list23.AddRange(list27);
								list24.AddRange(list28);
								list27.Clear();
								list28.Clear();
								break;
							}
						}
					}
					else if (flag21 && pos3.y - vector8.y < num75)
					{
						float num107 = 10f;
						float num108 = 0f;
						flag21 = false;
						int num109 = num97;
						float num110 = num96;
						while (num109 < splinePoints.Count - 2 && !flag21)
						{
							num109++;
							num110 += Vector3.Distance(splinePoints[num109 - 1], splinePoints[num109]);
							list26.Add(num110);
							vector7 = ((num109 >= splinePoints.Count - 1) ? (splinePoints[num109] - splinePoints[num109 - 1]) : (splinePoints[num109 + 1] - splinePoints[num109 - 1]));
							vector7 = new Vector3(vector7.z, 0f, 0f - vector7.x).normalized;
							pos = splinePoints[num109] - vector7 * num86;
							pos2 = splinePoints[num109] + vector7 * num86;
							vector8 = (pos3 = splinePoints[num109]);
							baseScript.OQCCDQOQOO(ref pos);
							baseScript.OQCCDQOQOO(ref pos2);
							baseScript.OQCCDQOQOO(ref pos3);
							list27.Add(vector8.y - pos.y);
							list28.Add(vector8.y - pos2.y);
							Vector3 pos4 = splinePoints[num109];
							baseScript.OQCCDQOQOO(ref pos4);
							if (!(pos4.y - splinePoints[num109].y < num75))
							{
								continue;
							}
							num108 += Vector3.Distance(splinePoints[num109], splinePoints[num109 + 1]);
							if (!(num108 > num107))
							{
								continue;
							}
							num88 = num97;
							if (num88 >= splinePoints.Count)
							{
								num88 = splinePoints.Count - 1;
							}
							Vector3 b;
							Vector3 a4 = (b = (pos4 = (zero5 = splinePoints[num97])));
							if (num97 > 0)
							{
								a4 = splinePoints[num97 - 1];
							}
							float num111 = Vector3.Distance(a4, b);
							float num112 = 1f / (num111 / 0.5f);
							Vector3 vector9;
							for (float num113 = num112; num113 < 1f; num113 += num112)
							{
								pos4 = (vector9 = Vector3.Lerp(a4, b, num113));
								baseScript.OQCCDQOQOO(ref pos4);
								if (pos4.y - splinePoints[num109].y < num75)
								{
									zero5 = vector9;
									break;
								}
							}
							num91 = OQQOCDQCQD.OCCOCQQCCQ(baseScript.activeTerrain, splinePoints[num97 - 1], splinePoints[num97]);
							vector9 = zero5;
							float num114 = num91 + eRSOSection.innerEndOffset;
							int num115 = num97 + 1;
							while (num114 > 0f && num115 < splinePoints.Count)
							{
								num108 = Vector3.Distance(splinePoints[num115], splinePoints[num115 - 1]);
								if (num108 > num114)
								{
									float num116 = num114 / num108;
									zero5 = Vector3.Lerp(splinePoints[num115 - 1], splinePoints[num115], num116);
									num88 = num115 - 1;
									if (num88 >= splinePoints.Count)
									{
										num88 = splinePoints.Count - 1;
									}
									num89 = num116;
									if (!flag32)
									{
										eRSOSection = new ERSOSection(vector6, zero5, num87, num88, startFraction, num89, num90, num91);
										eRSOSection.so = sideObject;
										eRSOSection.OODDCOCDOD();
										eRSOSection.startDistance = distances[num87];
										if (num92 < soSectionList1.Count)
										{
											soSectionList1.Insert(num92, eRSOSection);
										}
										else
										{
											soSectionList1.Add(eRSOSection);
										}
										num92++;
									}
									else
									{
										eRSOSection.startPosition = vector6;
										eRSOSection.endPosition = zero5;
										eRSOSection.startSplinePoint = (eRSOSection.startSplinePointObject = num87);
										eRSOSection.endSplinePoint = num88;
										eRSOSection.startFraction = startFraction;
										eRSOSection.endFraction = num89;
										eRSOSection.hsStart = num90;
										eRSOSection.hsEnd = num91;
										soSectionList1[num92 - 1] = eRSOSection;
									}
									float num117 = sideObject.xf2Total - sideObject.xf1Total;
									if (num117 < 3f * num91)
									{
										Debug.LogWarning("EasyRoads3Dv3 Warning: The tunnel width at the start and end of '" + sideObject.name + "' is too small for the terrain in the scene. Terrain holes may be visible outside the tunnel area");
									}
									flag21 = true;
									if (eRSOSection.snapIndentWidthStart > 0f || eRSOSection.snapIndentWidthEnd > 0f)
									{
										float x2;
										float x;
										if (roadShapeValues[num61][num87].x < roadShapeValues[num62][num87].x)
										{
											x = roadShapeValues[num61][num87].x;
											x2 = roadShapeValues[num62][num87].x;
										}
										else
										{
											x2 = roadShapeValues[num61][num87].x;
											x = roadShapeValues[num62][num87].x;
										}
										float num118 = 0f;
										if (eRSOSection.snapIndentWidthStart > 0f)
										{
											num118 = Mathf.Abs(sideObject.xf1) + x;
											num118 *= eRSOSection.snapIndentWidthStart;
											num118 += baseScript.minIndent;
											if (0f - x - leftIndents[num88] < num118)
											{
												float num119 = 15f + num90;
												num114 = 0f;
												num115 = num87;
												while (num114 < num119 && num115 > 0)
												{
													num114 += Vector3.Distance(splinePoints[num115 - 1], splinePoints[num115]);
													if (num114 > num119)
													{
														int num120 = num87 - num115;
														float num121 = 1f / ((float)num120 * 1f);
														for (int num122 = 0; num122 <= num120; num122++)
														{
															leftIndents[num115 + num122] = Mathf.Lerp(leftIndents[num115 + num122], num118, (float)(num122 + 1) * num121);
														}
														break;
													}
													num115--;
												}
											}
											num118 = Mathf.Abs(sideObject.xf1) - x2;
											num118 *= eRSOSection.snapIndentWidthStart;
											num118 += baseScript.minIndent;
											if (x2 + rightIndents[num87] < num118)
											{
												float num123 = 15f + num90;
												num114 = 0f;
												num115 = num87;
												while (num114 < num123 && num115 > 0)
												{
													num114 += Vector3.Distance(splinePoints[num115 - 1], splinePoints[num115]);
													if (num114 > num123)
													{
														int num124 = num87 - num115;
														float num125 = 1f / ((float)num124 * 1f);
														for (int num126 = 0; num126 <= num124; num126++)
														{
															rightIndents[num115 + num126] = Mathf.Lerp(rightIndents[num115 + num126], num118, (float)(num126 + 1) * num125);
														}
														break;
													}
													num115--;
												}
											}
										}
										if (eRSOSection.snapIndentWidthEnd > 0f)
										{
											int num127 = splinePoints.Count - 1;
											num118 = Mathf.Abs(sideObject.xf1) + x;
											num118 *= eRSOSection.snapIndentWidthEnd;
											num118 += baseScript.minIndent;
											if (0f - x - leftIndents[num88] < num118)
											{
												x = Mathf.Abs(x);
												float num128 = 15f + num91;
												num114 = 0f;
												num115 = num88;
												while (num114 < num128 && num115 > 0 && num115 < num127)
												{
													num114 += Vector3.Distance(splinePoints[num115 + 1], splinePoints[num115]);
													if (num114 > num128)
													{
														int num129 = num115 - num88;
														float num130 = 1f / ((float)num129 * 1f);
														for (int num131 = 0; num131 <= num129; num131++)
														{
															try
															{
																leftIndents[num115 - num131] = Mathf.Lerp(leftIndents[num115 + num131], num118, (float)(num131 + 1) * num130);
															}
															catch
															{
															}
														}
														break;
													}
													num115++;
												}
											}
											num118 = Mathf.Abs(sideObject.xf1) - x2;
											num118 *= eRSOSection.snapIndentWidthEnd;
											num118 += baseScript.minIndent;
											if (x2 + rightIndents[num88] < num118)
											{
												float num132 = 15f + num91;
												num114 = 0f;
												num115 = num88;
												while (num114 < num132 && num115 > 0 && num115 < num127)
												{
													num114 += Vector3.Distance(splinePoints[num115 + 1], splinePoints[num115]);
													if (num114 > num132)
													{
														int num133 = num115 - num88;
														float num134 = 1f / ((float)num133 * 1f);
														for (int num135 = 0; num135 <= num133; num135++)
														{
															try
															{
																rightIndents[num115 - num135] = Mathf.Lerp(rightIndents[num115 + num135], num118, (float)(num135 + 1) * num134);
															}
															catch
															{
															}
														}
														break;
													}
													num115++;
												}
											}
										}
									}
									num114 = 0f;
									break;
								}
								num114 -= num108;
								vector9 = splinePoints[num115];
								num115++;
							}
							num96 = num110;
							list26.Clear();
							list27.Clear();
							list28.Clear();
						}
						eRSOSection = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
						flag21 = false;
						flag32 = false;
						num81++;
						if (soSectionList1.Count > num92)
						{
							sideObject = soSectionList1[num92].so;
							eRSOSection = soSectionList1[num92];
						}
						else
						{
							sideObject = list18[0];
						}
					}
					if (!flag21 && pos.y > vector8.y && pos2.y > vector8.y)
					{
						float num136 = baseScript.minIndent + (pos3.y - vector8.y) * 0.15f;
						if (rightIndents[num97] < num136)
						{
							rightIndents[num97] = num136;
						}
						if (leftIndents[num97] < num136)
						{
							leftIndents[num97] = num136;
						}
					}
					if (!flag22 && list19.Count > 0)
					{
						if (!(list23[num97] > num76) || !(list24[num97] > num76) || snappedMarker)
						{
							continue;
						}
						while (soSectionList2.Count > num93)
						{
							if (Vector3.Distance(soSectionList2[num93].startPosition, splinePoints[num97]) < 20f)
							{
								eRSOSection3 = soSectionList2[num93];
								num93++;
								flag33 = true;
								break;
							}
							if (Mathf.Abs(soSectionList2[num93].startDistance - distances[num97]) < 10f)
							{
								eRSOSection3 = soSectionList2[num93];
								num93++;
								flag33 = true;
								break;
							}
							if (soSectionList2[num93].startDistance < distances[num97])
							{
								soSectionList2.RemoveAt(num93);
								continue;
							}
							break;
						}
						eRSOSection3.startSplinePoint = num97;
						eRSOSection3.startPosition = splinePoints[num97];
						eRSOSection3.startDistance = distances[num97];
						flag22 = true;
					}
					else
					{
						if (!flag22)
						{
							continue;
						}
						if (list23[num97] > list24[num97])
						{
							if (list23[num97] > num94)
							{
								num94 = list23[num97];
							}
						}
						else if (list24[num97] > num94)
						{
							num94 = list24[num97];
						}
						randomRotations[num97] = 0f;
						if (!(list23[num97] < num76) || !(list24[num97] < num76))
						{
							continue;
						}
						float num137 = 0f;
						if (false)
						{
							continue;
						}
						bool flag34 = OCQODDCQDD.OQQDQDQCDO(list19, eRSOSection3.so);
						if (!flag33 || !flag34)
						{
							eRSOSection3.so = list19[0];
							eRSOSection3.soid = list19[0].id;
							eRSOSection3.acceptBarriers = list19[0].acceptBarriers;
						}
						int num138 = eRSOSection3.startSplinePoint - 1;
						num137 = eRSOSection3.so.heightMaxStartThreshold;
						float num139 = 0f;
						bool flag35 = false;
						if (num137 != 0f)
						{
							for (int num140 = num138; num140 > 0; num140--)
							{
								randomRotations[num140] = 0f;
								if (!(list23[num140] < num137) && !(list24[num140] < num137))
								{
									continue;
								}
								eRSOSection3.startSplinePoint = num140 + 1;
								baseScript.OQQOQQCOOQ(splinePoints[num140]);
								eRSOSection3.hsStart = OQQOCDQCQD.OCCOCQQCCQ(baseScript.activeTerrain, splinePoints[num140], splinePoints[num140 - 1]);
								int targetIndex = 0;
								float targetFraction = 0f;
								OQQOCDQCQD.GetIndexAndFraction(splinePoints, 0f, eRSOSection3.startSplinePoint, eRSOSection3.hsStart, ref targetIndex, ref targetFraction, -1);
								float num141 = (list23[num140] + list24[num140]) * 0.5f;
								float num142 = (list23[num140 + 1] + list24[num140 + 1]) * 0.5f;
								float num143 = distances[num140 + 1] - distances[num140];
								float num144 = num142 - num141;
								float num145 = num137 - num141;
								float num146 = 1f - num145 / num144;
								targetFraction = num146 * num143;
								eRSOSection3.startSplinePointGeo = targetIndex;
								eRSOSection3.startDistanceGeo = targetFraction;
								if (num140 <= 0)
								{
									break;
								}
								if (num140 > 1 && Mathf.Abs(randomRotations[num140 - 1]) > 1f)
								{
									randomRotations[num140 - 2] = Mathf.Lerp(randomRotations[num140 - 2], 0f, 0.9f);
									if (num140 > 2)
									{
										randomRotations[num140 - 3] = Mathf.Lerp(randomRotations[num140 - 3], 0f, 0.7f);
									}
									if (num140 > 3)
									{
										randomRotations[num140 - 4] = Mathf.Lerp(randomRotations[num140 - 4], 0f, 0.5f);
									}
									if (num140 > 4)
									{
										randomRotations[num140 - 5] = Mathf.Lerp(randomRotations[num140 - 5], 0f, 0.3f);
									}
									if (num140 > 5)
									{
										randomRotations[num140 - 6] = Mathf.Lerp(randomRotations[num140 - 6], 0f, 0.15f);
									}
								}
								randomRotations[num140 - 1] = 0f;
								break;
							}
							if (flag35)
							{
							}
						}
						int num147 = num97 - 1;
						num137 = eRSOSection3.so.heightMaxStartThreshold;
						if (num137 < 1f)
						{
							num137 = 1f;
						}
						num139 = 0f;
						flag35 = false;
						List<float> list29 = new List<float>();
						List<float> list30 = new List<float>();
						if (num137 != 0f)
						{
							float num148 = num96;
							int num149 = splinePoints.Count - 1;
							for (int num150 = num147; num150 < num149; num150++)
							{
								vector7 = splinePoints[num150 + 1] - splinePoints[num150 - 1];
								vector7 = new Vector3(vector7.z, 0f, 0f - vector7.x).normalized;
								pos = splinePoints[num150] - vector7 * num86;
								pos2 = splinePoints[num150] + vector7 * num86;
								vector8 = (pos3 = splinePoints[num150]);
								baseScript.OQCCDQOQOO(ref pos);
								baseScript.OQCCDQOQOO(ref pos2);
								baseScript.OQCCDQOQOO(ref pos3);
								if (num150 > num97)
								{
									num148 += Vector3.Distance(splinePoints[num150 - 1], splinePoints[num150]);
									list26.Add(num148);
									list29.Add(vector8.y - pos.y);
									list30.Add(vector8.y - pos2.y);
								}
								randomRotations[num150] = 0f;
								if (!(vector8.y - pos.y < num137) && !(vector8.y - pos2.y < num137))
								{
									continue;
								}
								eRSOSection3.endSplinePoint = num150 - 1;
								if (num150 - 1 >= splinePoints.Count)
								{
									eRSOSection3.endSplinePoint = splinePoints.Count - 1;
								}
								num97 = num150;
								distances.AddRange(list26);
								num96 = num148;
								list26.Clear();
								list23.AddRange(list29);
								list24.AddRange(list30);
								baseScript.OQQOQQCOOQ(splinePoints[num150]);
								eRSOSection3.hsEnd = OQQOCDQCQD.OCCOCQQCCQ(baseScript.activeTerrain, splinePoints[num150 - 1], splinePoints[num150]);
								int targetIndex2 = 0;
								float targetFraction2 = 0f;
								OQQOCDQCQD.GetIndexAndFraction(splinePoints, 0f, eRSOSection3.endSplinePoint, eRSOSection3.hsEnd, ref targetIndex2, ref targetFraction2, 1);
								float num151 = (list23[num150 - 1] + list24[num150 - 1]) * 0.5f;
								float num152 = (list23[num150] + list24[num150]) * 0.5f;
								float num153 = distances[num150] - distances[num150 - 1];
								float num154 = num151 - num152;
								float num155 = num137 - num152;
								float num156 = 1f - num155 / num154;
								targetFraction2 = num156 * num153;
								eRSOSection3.endSplinePointGeo = targetIndex2;
								eRSOSection3.endDistanceGeo = targetFraction2;
								eRSOSection3.maxHeightDifference = num94;
								if (!eRSOSection3.forceSo && (eRSOSection3.so.heightThreshold > num94 || eRSOSection3.so.heightMaxThreshold < num94))
								{
									bool flag36 = false;
									for (int num157 = 0; num157 < list19.Count; num157++)
									{
										if (eRSOSection3.so.heightThreshold < num94 && list19[num157].heightMaxThreshold > num94)
										{
											eRSOSection3.so = list19[num157];
											eRSOSection3.soid = list19[num157].id;
											flag36 = true;
											break;
										}
									}
								}
								if (num150 >= num149)
								{
									break;
								}
								if (num150 + 2 < num149 && Mathf.Abs(randomRotations[num150 + 1]) > 1f)
								{
									randomRotations[num150 + 2] = Mathf.Lerp(randomRotations[num150 + 2], 0f, 0.9f);
									if (num150 + 3 < num149)
									{
										randomRotations[num150 + 3] = Mathf.Lerp(randomRotations[num150 + 3], 0f, 0.7f);
									}
									if (num150 + 4 < num149)
									{
										randomRotations[num150 + 4] = Mathf.Lerp(randomRotations[num150 + 4], 0f, 0.5f);
									}
									if (num150 + 5 < num149)
									{
										randomRotations[num150 + 5] = Mathf.Lerp(randomRotations[num150 + 5], 0f, 0.3f);
									}
									if (num150 + 6 < num149)
									{
										randomRotations[num150 + 6] = Mathf.Lerp(randomRotations[num150 + 6], 0f, 0.15f);
									}
								}
								randomRotations[num150 + 1] = 0f;
								break;
							}
						}
						else
						{
							eRSOSection3.endSplinePoint = num97 - 1;
							eRSOSection3.endFraction = 0f;
						}
						if (eRSOSection3.so.objectType == 1 && eRSOSection3.so.continueOnConnections && eRSOSection3.startSplinePoint <= 1 && startPrefabScript != null)
						{
							eRSOSection3.startSplinePoint = 0;
							eRSOSection3.startFraction = 0f;
							bridgeAtStart = true;
						}
						if (eRSOSection3.so.objectType == 1 && eRSOSection3.so.continueOnConnections && eRSOSection3.endSplinePoint >= splinePoints.Count - 2 && endPrefabScript != null)
						{
							eRSOSection3.endSplinePoint = splinePoints.Count - 1;
							eRSOSection3.endFraction = 0f;
							bridgeAtEnd = true;
						}
						if (!flag33)
						{
							if (num93 < soSectionList2.Count)
							{
								soSectionList2.Insert(num93, eRSOSection3);
							}
							else
							{
								soSectionList2.Add(eRSOSection3);
							}
							num93++;
						}
						else
						{
							soSectionList2[num93 - 1] = eRSOSection3;
						}
						eRSOSection3 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
						flag22 = (flag33 = false);
						num94 = 0f;
					}
				}
				if (soSectionList1.Count > 0)
				{
					if (num92 == 0)
					{
						soSectionList1.Clear();
					}
					else
					{
						if (flag30)
						{
							soSectionList1.RemoveAt(0);
						}
						if (soSectionList1.Count > 0 && soSectionList1[soSectionList1.Count - 1].endSplinePoint >= splinePoints.Count)
						{
							soSectionList1.RemoveAt(soSectionList1.Count - 1);
						}
						if (num92 < 0)
						{
							num92 = 0;
						}
						for (int num158 = num92; num158 < soSectionList1.Count; num158++)
						{
							soSectionList1.RemoveAt(num158);
							num158--;
						}
					}
				}
				if (num81 == 0 && soSectionList1.Count > 0)
				{
					soSectionList1.Clear();
				}
				if (flag21)
				{
				}
				if (flag22)
				{
					bool flag37 = OCQODDCQDD.OQQDQDQCDO(list19, eRSOSection3.so);
					if (!flag33 || !flag37)
					{
						eRSOSection3.so = list19[0];
						eRSOSection3.soid = list19[0].id;
						eRSOSection3.acceptBarriers = list19[0].acceptBarriers;
					}
					int num159 = eRSOSection3.startSplinePoint - 1;
					float heightMaxStartThreshold = eRSOSection3.so.heightMaxStartThreshold;
					float num160 = 0f;
					bool flag38 = false;
					if (heightMaxStartThreshold != 0f)
					{
						for (int num161 = num159; num161 > 0; num161--)
						{
							randomRotations[num161] = 0f;
							if (!(list23[num161] < heightMaxStartThreshold) && !(list24[num161] < heightMaxStartThreshold))
							{
								continue;
							}
							eRSOSection3.startSplinePoint = num161 + 1;
							baseScript.OQQOQQCOOQ(splinePoints[num161]);
							eRSOSection3.hsStart = OQQOCDQCQD.OCCOCQQCCQ(baseScript.activeTerrain, splinePoints[num161], splinePoints[num161 - 1]);
							int targetIndex3 = 0;
							float targetFraction3 = 0f;
							OQQOCDQCQD.GetIndexAndFraction(splinePoints, 0f, eRSOSection3.startSplinePoint, eRSOSection3.hsStart, ref targetIndex3, ref targetFraction3, -1);
							eRSOSection3.startSplinePointGeo = targetIndex3;
							eRSOSection3.startDistanceGeo = targetFraction3;
							if (num161 <= 0)
							{
								break;
							}
							if (num161 > 1 && Mathf.Abs(randomRotations[num161 - 1]) > 1f)
							{
								randomRotations[num161 - 2] = Mathf.Lerp(randomRotations[num161 - 2], 0f, 0.9f);
								if (num161 > 2)
								{
									randomRotations[num161 - 3] = Mathf.Lerp(randomRotations[num161 - 3], 0f, 0.7f);
								}
								if (num161 > 3)
								{
									randomRotations[num161 - 4] = Mathf.Lerp(randomRotations[num161 - 4], 0f, 0.5f);
								}
								if (num161 > 4)
								{
									randomRotations[num161 - 5] = Mathf.Lerp(randomRotations[num161 - 5], 0f, 0.3f);
								}
								if (num161 > 5)
								{
									randomRotations[num161 - 6] = Mathf.Lerp(randomRotations[num161 - 6], 0f, 0.15f);
								}
							}
							randomRotations[num161 - 1] = 0f;
							break;
						}
						if (flag38)
						{
						}
					}
					eRSOSection3.endSplinePoint = splinePoints.Count - 1;
					eRSOSection3.endFraction = 0f;
					if (eRSOSection3.so.objectType == 1 && eRSOSection3.so.continueOnConnections && eRSOSection3.startSplinePoint <= 1 && startPrefabScript != null)
					{
						eRSOSection3.startSplinePoint = 0;
						eRSOSection3.startFraction = 0f;
						bridgeAtStart = true;
					}
					if (eRSOSection3.so.objectType == 1 && eRSOSection3.so.continueOnConnections && eRSOSection3.endSplinePoint >= splinePoints.Count - 2 && endPrefabScript != null)
					{
						eRSOSection3.endSplinePoint = splinePoints.Count - 1;
						eRSOSection3.endFraction = splinePoints.Count - 1;
						bridgeAtEnd = true;
					}
					if (!flag33)
					{
						if (num93 < soSectionList2.Count)
						{
							soSectionList2.Insert(num93, eRSOSection3);
						}
						else
						{
							soSectionList2.Add(eRSOSection3);
						}
						num93++;
					}
					else
					{
						soSectionList2[num93 - 1] = eRSOSection3;
					}
				}
				if (num93 == 0)
				{
					soSectionList2.Clear();
				}
				else
				{
					if (num93 < 0)
					{
						num93 = 0;
					}
					for (int num162 = num93; num162 < soSectionList2.Count; num162++)
					{
						soSectionList2.RemoveAt(num162);
						num162--;
					}
				}
			}
			OODOCCDDCQ = ODOCQDOCDD(tValues, markerDistances, markersExt, 0, tmpMarkersExt.Count, ref ODCODQCCDQ, randomRotations);
			if (OODOCCDDCQ.Count != splinePoints.Count)
			{
				if (OODOCCDDCQ.Count == 0)
				{
					OODOCCDDCQ.Add(markersExt[0].rotation);
				}
				for (int count8 = OODOCCDDCQ.Count; count8 < splinePoints.Count; count8++)
				{
					OODOCCDDCQ.Add(OODOCCDDCQ[OODOCCDDCQ.Count - 1]);
				}
			}
			if (markerInts.Count != splinePoints.Count)
			{
				for (int count9 = markerInts.Count; count9 < splinePoints.Count; count9++)
				{
					markerInts.Add(markerInts[0]);
				}
			}
			if (bridgeElement.Count != splinePoints.Count)
			{
				int count10 = bridgeElement.Count;
				for (int num163 = count10; num163 < splinePoints.Count; num163++)
				{
					bridgeElement.Add(item: false);
				}
			}
			bool flag39 = false;
			int num164 = 0;
			int num165 = -1;
			int num166 = -1;
			int num167 = -1;
			bool flag40 = false;
			if (soSectionList1.Count > 0)
			{
				flag40 = true;
			}
			if (flag40)
			{
				num165 = soSectionList1[0].startSplinePoint;
				num166 = soSectionList1[0].endSplinePoint + 1;
				if (num165 == 0)
				{
					flag39 = true;
				}
			}
			List<bool> list31 = new List<bool>();
			list31.Add(flag39);
			float num168 = 0f;
			if (lockUVs && markersExt.Count > 1)
			{
				num168 = markersExt[1].markerStartUVY - Mathf.Floor(markersExt[1].markerStartUVY);
				flag18 = true;
			}
			bool flag41 = false;
			bool flag42 = false;
			int count11 = doConnectionTri.Count;
			int count12 = roadShapeMaterialInts.Count;
			bool flag43 = true;
			Vector3 zero6 = Vector3.zero;
			bool flag44 = true;
			bool flag45 = false;
			int count13 = ODCODQCCDQ.Count;
			if (splinePoints.Count <= 1)
			{
				return;
			}
			int count14 = splinePoints.Count;
			for (int num169 = 0; num169 < count14; num169++)
			{
				if (num169 > 0)
				{
					num36 = Vector3.Distance(splinePoints[num169 - 1], splinePoints[num169]);
					num35 += num36;
				}
				if (flag40)
				{
					if (num169 == num165)
					{
						flag39 = true;
					}
					else if (num169 == num166)
					{
						flag39 = false;
						num167 = num166;
						if (soSectionList1.Count > num164 + 1)
						{
							flag39 = false;
							num164++;
							num165 = soSectionList1[num164].startSplinePoint;
							num166 = soSectionList1[num164].endSplinePoint + 1;
						}
					}
				}
				list31.Add(flag39);
				if (num45 + 1 >= tmpMarkersExt.Count)
				{
					num45 = tmpMarkersExt.Count - 2;
				}
				if (num169 == tmpMarkersExt[num45 + 1].startSplinePoint - 1)
				{
					flag12 = tmpMarkersExt[num45 + 1].bridgeObject;
					if (tmpMarkersExt[num45 + 1].bridgeObject)
					{
						if (tmpMarkersExt[num45 + 1].bridgeStartLevelDistance == 0f || tmpMarkersExt[num45].bridgeObject)
						{
							flag13 = true;
							if (num54 == 0f && !tmpMarkersExt[num45].bridgeObject)
							{
								num54 = 0.01f;
							}
						}
						else
						{
							num54 = tmpMarkersExt[num45 + 1].bridgeStartLevelDistance;
							if (num54 == 0f && !tmpMarkersExt[num45].bridgeObject)
							{
								num54 = 0.01f;
							}
						}
					}
					else
					{
						flag13 = false;
					}
					flag14 = true;
					flag10 = true;
					if (markersExt[num45].snappedMarker)
					{
						int startSplinePoint = tmpMarkersExt[num45].startSplinePoint;
						list2[startSplinePoint - 1] = false;
						float num170 = OQQOCDQCQD.OCCOCQQCCQ(baseScript.activeTerrain, splinePoints[startSplinePoint], splinePoints[startSplinePoint - 1]);
						Vector3 normalized3 = (splinePoints[startSplinePoint] - splinePoints[startSplinePoint - 1]).normalized;
						surfaceVecs[startSplinePoint * 5] = surfaceVecs[(startSplinePoint - 1) * 5] + normalized3 * num170;
						surfaceVecs[startSplinePoint * 5 + 1] = surfaceVecs[(startSplinePoint - 1) * 5 + 1] + normalized3 * num170;
						surfaceVecs[startSplinePoint * 5 + 2] = surfaceVecs[(startSplinePoint - 1) * 5 + 2] + normalized3 * num170;
						surfaceVecs[startSplinePoint * 5 + 3] = surfaceVecs[(startSplinePoint - 1) * 5 + 3] + normalized3 * num170;
						surfaceVecs[startSplinePoint * 5 + 4] = surfaceVecs[(startSplinePoint - 1) * 5 + 4] + normalized3 * num170;
						list2[num169 - 1] = false;
						num170 -= Vector3.Distance(splinePoints[num169 - 1], splinePoints[num169]);
						startSplinePoint = num169 - 1;
						normalized3 = (splinePoints[num169 - 1] - splinePoints[num169]).normalized;
						surfaceVecs[startSplinePoint * 5] += normalized3 * num170;
						surfaceVecs[startSplinePoint * 5 + 1] += normalized3 * num170;
						surfaceVecs[startSplinePoint * 5 + 2] += normalized3 * num170;
						surfaceVecs[startSplinePoint * 5 + 3] += normalized3 * num170;
						surfaceVecs[startSplinePoint * 5 + 4] += normalized3 * num170;
					}
					if (tmpMarkersExt.Count > num45 + 1 && num169 != 0)
					{
						num45++;
					}
					if (num45 >= markersExt.Count)
					{
						num45 = markersExt.Count - 1;
					}
					flag44 = false;
					if (flag)
					{
						lastRotationStartInt = num169;
					}
					if (num45 == markersExt.Count - 2)
					{
						flag45 = true;
						if (flag2)
						{
							lastRotationEndInt = num169;
						}
					}
					customColor = markersExt[num45].customColor;
					if (num45 == 1 && lockUVs)
					{
						float num171 = num35 / num40;
						num171 -= Mathf.Floor(num171);
						num60 = (num168 - num171) * -1f;
					}
				}
				else if (num169 != 0)
				{
					if (tmpMarkersExt[num45].bridgeObject)
					{
						flag13 = true;
					}
					flag14 = false;
					num55 = 0f;
					num53 = num54;
					num54 = 0f;
					if (flag13 && tmpMarkersExt.Count > num45 + 1 && splinePoints.Count > num169 + 1 && num169 + 2 == tmpMarkersExt[num45 + 1].startSplinePoint && !tmpMarkersExt[num45 + 1].bridgeObject)
					{
						num55 = 0.01f;
						if (tmpMarkersExt[num45].bridgeEndLevelDistance > 0f)
						{
							num55 = tmpMarkersExt[num45].bridgeEndLevelDistance;
							flag13 = false;
						}
					}
				}
				if (bridgeElement[num169])
				{
					list2.Add(item: true);
				}
				else
				{
					list2.Add(flag13);
				}
				if (num53 > 0f)
				{
					list2[num169 - 1] = false;
					bridgeElement[num169 - 1] = false;
				}
				if (num55 > 0f)
				{
					list2[num169] = false;
					bridgeElement[num169] = false;
				}
				doLeftSurrounding.Add(item: true);
				doRightSurrounding.Add(item: true);
				num39 = num35 / num40 - num60;
				num57 = num35 / num56;
				if (flag14)
				{
					markersExt[num45].markerStartUVY = num39 - Mathf.Floor(num39);
				}
				Vector3 vector10 = ((num169 == 0) ? (splinePoints[num169 + 1] - splinePoints[num169]).normalized : ((num169 != splinePoints.Count - 1) ? (splinePoints[num169 + 1] - splinePoints[num169 - 1]).normalized : (splinePoints[num169] - splinePoints[num169 - 1]).normalized));
				if (num169 == 0)
				{
					firstDir = vector10;
				}
				vector5 = vector10;
				zero3 = OQOCQDQODD.GetEulerAngles(vector10);
				vector10 = new Vector3(0f - vector10.z, 0f, vector10.x);
				if (!flag5 && num169 < splinePoints.Count - 2)
				{
					vector = (splinePoints[num169 + 1] - splinePoints[num169]).normalized;
					vector = new Vector3(0f - vector.z, 0f, vector.x);
				}
				Vector3 vector12;
				Vector3 zero7;
				Vector3 vector11 = (vector12 = (zero7 = Vector3.zero));
				Vector3 position = Vector3.zero;
				float num172 = 0f;
				if (OODOCCDDCQ[num169] != 0f)
				{
					Vector3 a5 = splinePoints[num169] + vector10 * roadShape[num61].x;
					Vector3 b2 = splinePoints[num169] + vector10 * roadShape[num62].x;
					if (count13 > num169)
					{
						position = Vector3.Lerp(a5, b2, ODCODQCCDQ[num169]);
						num172 = Mathf.Lerp(roadShape[num61].x, roadShape[num62].x, ODCODQCCDQ[num169]);
					}
					else if (num169 == 0 || markersExt.Count == 1)
					{
						position = Vector3.Lerp(a5, b2, markersExt[0].rotationCenter);
						num172 = Mathf.Lerp(roadShape[num61].x, roadShape[num62].x, markersExt[0].rotationCenter);
					}
					else
					{
						position = Vector3.Lerp(a5, b2, markersExt[1].rotationCenter);
						num172 = Mathf.Lerp(roadShape[num61].x, roadShape[num62].x, markersExt[1].rotationCenter);
					}
				}
				num59 = vecs.Count;
				if (num39 > roadUvThreshold)
				{
					list5.Add(num59);
					num59 += count4;
				}
				num70 = 0;
				flag20 = false;
				if (flag19)
				{
					if (num169 >= num67 && num169 <= num69)
					{
						flag20 = true;
					}
					if (num169 == num67 - 1)
					{
						sectionRoadShapeCols2 = 0;
						ODDOQDDQCQ.OQQOOOOQCC(rt, ref list12, ref collection2, ref list14, ref list13, ref currentMostLeftInt2, ref currentMostRightInt2, ref sectionRoadShapeCols2, 1, 0, transition: true, roadShape);
						num70 = 1;
						List<int> list32 = tris[0];
						ODDOQDDQCQ.ODQCQCOCDC(roadShape, hardEdge, count4, list12, list13, sectionRoadShapeCols2, ref list32, flipNormals, vecs.Count, 0, 0, roadShape.Count, list12.Count);
					}
					else if (num169 == num67)
					{
						count6 = list12.Count;
						list8 = new List<Vector2>(list12);
						list6 = new List<float>(collection2);
						list7 = new List<bool>(list13);
						roadShapeCols = sectionRoadShapeCols2;
						List<int> list33 = tris[0];
						int last = rt.roadShapeData.outerLaneMarkingRightIndex + 1;
						if (!rt.roadShapeData.includeOuterlaneLeftInShape)
						{
							last--;
						}
						last--;
						sectionRoadShapeCols = 0;
						ODDOQDDQCQ.OQQOOOOQCC(rt, ref list9, ref collection, ref list11, ref list10, ref currentMostLeftInt, ref currentMostRightInt, ref sectionRoadShapeCols, 1, 0, transition: false, roadShape);
						ODDOQDDQCQ.ODQCQCOCDC(list12, list13, sectionRoadShapeCols2, list9, list10, sectionRoadShapeCols, ref list33, flipNormals, vecs.Count, 0, 0, last, list9.Count);
						if (roadShapeCols != count4)
						{
							flag18 = true;
						}
						num70 = 2;
					}
					else if (num169 == num67 + 1)
					{
						count6 = list9.Count;
						list8 = new List<Vector2>(list9);
						list6 = new List<float>(collection);
						list7 = new List<bool>(list10);
						roadShapeCols = sectionRoadShapeCols;
						num70 = 0;
					}
					else if (num169 == num68 - 1)
					{
						List<int> list34 = tris[0];
						int last2 = rt.roadShapeData.outerLaneMarkingRightIndex + 1;
						if (!rt.roadShapeData.includeOuterlaneLeftInShape)
						{
							last2--;
						}
						last2--;
						ODDOQDDQCQ.ODQCQCOCDC(list9, list10, sectionRoadShapeCols, list15, list16, num65, ref list34, flipNormals, vecs.Count, 0, 0, roadShape.Count, last2);
						num70 = 1;
					}
					else if (num169 == num68)
					{
						count6 = list15.Count;
						list8 = new List<Vector2>(list15);
						list6 = new List<float>(collection3);
						list7 = new List<bool>(list16);
						roadShapeCols = num65;
						List<int> list35 = tris[0];
						ODDOQDDQCQ.ODQCQCOCDC(list15, list16, num65, list9, list10, sectionRoadShapeCols, ref list35, flipNormals, vecs.Count, 0, 0, list15.Count, list9.Count);
						num70 = 1;
					}
					else if (num169 == num68 + 1)
					{
						sectionRoadShapeCols = 0;
						ODDOQDDQCQ.OQQOOOOQCC(rt, ref list9, ref collection, ref list11, ref list10, ref currentMostLeftInt, ref currentMostRightInt, ref sectionRoadShapeCols, 1, 1, transition: false, roadShape);
						count6 = list9.Count;
						list8 = new List<Vector2>(list9);
						list6 = new List<float>(collection);
						list7 = new List<bool>(list10);
						roadShapeCols = sectionRoadShapeCols;
						num70 = 0;
					}
					else if (num169 > num69 && num169 < num69 - 1)
					{
						num70 = 0;
					}
					else if (num169 == num69 - 1)
					{
						sectionRoadShapeCols2 = 0;
						ODDOQDDQCQ.OQQOOOOQCC(rt, ref list12, ref collection2, ref list14, ref list13, ref currentMostLeftInt2, ref currentMostRightInt2, ref sectionRoadShapeCols2, 1, 2, transition: true, roadShape);
						List<int> list36 = tris[0];
						int last3 = rt.roadShapeData.outerLaneMarkingRightIndex + 1;
						if (!rt.roadShapeData.includeOuterlaneLeftInShape)
						{
							last3--;
						}
						last3--;
						ODDOQDDQCQ.ODQCQCOCDC(list9, list10, sectionRoadShapeCols, list12, list13, sectionRoadShapeCols2, ref list36, flipNormals, vecs.Count, 0, 0, list9.Count, last3);
						num70 = 3;
					}
					else if (num169 == num69)
					{
						count6 = list12.Count;
						list8 = new List<Vector2>(list12);
						list6 = new List<float>(collection2);
						list7 = new List<bool>(list13);
						roadShapeCols = sectionRoadShapeCols2;
						List<int> list37 = tris[0];
						ODDOQDDQCQ.ODQCQCOCDC(list12, list13, sectionRoadShapeCols2, roadShape, hardEdge, count4, ref list37, flipNormals, vecs.Count, 0, 0, list12.Count, roadShape.Count);
						num70 = 3;
					}
					else if (num169 == num69 + 1)
					{
						count6 = roadShape.Count;
						list6 = new List<float>(roadShapeUVs);
						list7 = new List<bool>(hardEdge);
						roadShapeCols = count4;
						num70 = 0;
						num66++;
						if (num66 < exitRoads.Count - 1)
						{
							num67 = exitRoads[num66].startSplineIndex;
							num69 = exitRoads[num66].endSplineIndex;
							num68 = exitRoads[num66].fixedDistanceIndex;
						}
						else
						{
							flag19 = false;
						}
					}
				}
				float num173 = roadWidth * 0.5f;
				int num174 = 0;
				Vector3 pos5;
				for (int num175 = 0; num175 < count6; num175++)
				{
					zero4 = ((!flag20) ? roadShapeValues[num175][num169] : list8[num175]);
					bool flag46 = false;
					if (count5 > 0 && list7[num175] && num175 > 0 && num175 < count6 - 1)
					{
						flag46 = true;
					}
					if (OODOCCDDCQ[num169] != 0f)
					{
						float x3 = zero4.x - num172;
						pos5 = OQOCQDQODD.OODCODQCCQ(position, new Vector2(x3, zero4.y), 180f - OODOCCDDCQ[num169], zero3);
					}
					else
					{
						pos5 = splinePoints[num169] + vector10 * zero4.x;
					}
					if (terrainDeformation && startPrefabScript != null && num169 < num13 && !flag10 && !startPrefabScript.isIConnector && !startPrefabScript.isERCrossingExt)
					{
						pos5.y = OQQOCDQCQD.OQOOCCQQOQ(startPrefabIndent, oCCDODCDCOIndent, a, pos5);
						num14 = num35;
						if (OODOCCDDCQ[num169] != 0f)
						{
							pos5.y += zero4.y;
						}
					}
					else if (terrainDeformation && startPrefabScript != null && num35 - num14 < num19 - num14 && !flag10 && !startPrefabScript.isIConnector && !startPrefabScript.isERCrossingExt)
					{
						Vector3 p = pos5;
						p.y = OQQOCDQCQD.OQOOCCQQOQ(startPrefabIndent, oCCDODCDCOIndent, a, p);
						float t2 = (num35 - num14) / (num19 - num14);
						if (OODOCCDDCQ[num169] != 0f)
						{
							p.y += zero4.y;
						}
						p.y = Mathf.Lerp(p.y, pos5.y, t2);
						pos5.y = Mathf.Lerp(p.y, pos5.y, Mathf.SmoothStep(0f, 1f, t2));
					}
					if (terrainDeformation && endPrefabScript != null && num169 > num16 && !flag11 && !endPrefabScript.isIConnector && !endPrefabScript.isERCrossingExt)
					{
						pos5.y = OQQOCDQCQD.OQOOCCQQOQ(startPrefabIndent2, oCCDODCDCOIndent2, vector2, pos5);
						if (OODOCCDDCQ[num169] != 0f)
						{
							pos5.y += zero4.y;
						}
					}
					else if (terrainDeformation && endPrefabScript != null && num169 >= endAdjustInt && !flag11 && !endPrefabScript.isIConnector && !endPrefabScript.isERCrossingExt)
					{
						if (num175 == 0)
						{
							num37 += num36;
						}
						Vector3 p2 = pos5;
						p2.y = OQQOCDQCQD.OQOOCCQQOQ(startPrefabIndent2, oCCDODCDCOIndent2, vector2, p2);
						float t2 = num37 / endAdjustDistance;
						if (OODOCCDDCQ[num169] != 0f)
						{
							p2.y += zero4.y;
						}
						p2.y = Mathf.Lerp(pos5.y, p2.y, t2);
						pos5.y = Mathf.Lerp(pos5.y, p2.y, Mathf.SmoothStep(0f, 1f, t2));
					}
					if (OODOCCDDCQ[num169] != 0f)
					{
						pos5.y -= zero4.y;
					}
					if (num175 == num61)
					{
						vector11 = pos5;
						if (OODOCCDDCQ[num169] != 0f)
						{
							vector11.y -= 0.02f;
						}
					}
					if (num175 == num62)
					{
						vector12 = pos5;
						if (OODOCCDDCQ[num169] != 0f)
						{
							vector12.y -= 0.02f;
						}
					}
					if (num175 == num61)
					{
						soSplinePointsLeft[num169] = pos5;
						if (flag14)
						{
							markersExt[num45].rl = pos5 + vector10;
						}
					}
					if (num175 == num62)
					{
						soSplinePointsRight[num169] = pos5;
						if (flag14)
						{
							markersExt[num45].rr = pos5 - vector10;
						}
					}
					if (num175 == num61)
					{
						soSplinePointsLeftClamped[num169] = pos5;
					}
					else if (num175 == num62)
					{
						soSplinePointsRightClamped[num169] = pos5;
					}
					pos5.y += zero4.y;
					if (snapVertices)
					{
						baseScript.OQCCDQOQOO(ref pos5);
						pos5.y += snapOffset + zero4.y;
						if (num175 == num61)
						{
							soSplinePointsLeft[num169] = pos5;
						}
						else if (num175 == num62)
						{
							soSplinePointsRight[num169] = pos5;
						}
					}
					vecs.Add(pos5);
					colors.Add(customColor);
					if (flag14 || num169 == 0)
					{
						tmpMarkersExt[num45].roadShapeVecsGlobal.Add(pos5);
					}
					if (!planarUVs || roadShapeMaterialInts[num175] != num8)
					{
						uvs.Add(new Vector2(list6[num175], num39));
						isPlanar.Add(item: false);
					}
					else
					{
						uvs.Add(new Vector2(pos5.x * uvTiling, pos5.z * uvTiling));
						isPlanar.Add(item: true);
					}
					if (uv4Type == 1)
					{
						uvs2.Add(new Vector2(list6[num175], num57));
					}
					else
					{
						uvs2.Add(baseScript.GetTerrainUV(pos5));
					}
					if (flag46)
					{
						vecs.Add(pos5);
						colors.Add(customColor);
						if (!planarUVs || roadShapeMaterialInts[num175] != num8)
						{
							uvs.Add(new Vector2(roadShapeUVs2[num175], num39));
							isPlanar.Add(item: false);
						}
						else
						{
							uvs.Add(new Vector2(pos5.x * uvTiling, pos5.z * uvTiling));
							isPlanar.Add(item: true);
						}
						if (uv4Type == 1)
						{
							uvs2.Add(new Vector2(list6[num175], num57));
						}
						else
						{
							uvs2.Add(baseScript.GetTerrainUV(pos5));
						}
					}
					if (num169 < splinePoints.Count - 1 && num175 < count6 - 1)
					{
						flag4 = true;
						if (!flag5)
						{
							flag4 = false;
							if (!array4[num175 + num174] || !array4[num175 + 1 + num174])
							{
								if (num169 == 0)
								{
									array2[num175 + num174] = -1;
									array2[num175 + 1 + num174] = -1;
									if (flag46)
									{
										array2[num175 + num174 + 1] = -1;
										array2[num175 + 1 + num174 + 1] = -1;
									}
								}
								if (!array4[num175 + num174])
								{
									Vector3 pCheck = splinePoints[num169 + 1] + vector * zero4.x;
									if (ERCrossingPrefabs.OOCQODQDQD(OCQOOQODCQ, OQQCCQDCOO, pCheck))
									{
										array4[num175 + num174] = true;
									}
								}
								if (!array4[num175 + 1 + num174])
								{
									Vector3 pCheck = splinePoints[num169 + 1] + vector * roadShape[num175 + 1].x;
									if (ERCrossingPrefabs.OOCQODQDQD(OCQOOQODCQ, OQQCCQDCOO, pCheck))
									{
										array4[num175 + 1 + num174] = true;
									}
								}
								if (array4[num175 + num174] && array4[num175 + 1 + num174])
								{
									flag4 = true;
									if (array2[num175 + num174] == -1)
									{
										array2[num175 + num174] = num169;
										if (flag46)
										{
											array2[num175 + num174 + 1] = num169;
										}
									}
									if (array2[num175 + 1 + num174] == -1)
									{
										array2[num175 + 1 + num174] = num169;
										if (flag46)
										{
											array2[num175 + 1 + num174 + 1] = num169;
										}
									}
								}
							}
							if (num175 == count6 - 2 && num175 + 1 + num174 < roadShapeCols - 1 && array4[^2])
							{
								array4[^1] = true;
								array2[^1] = array2[^2];
							}
							flag4 = true;
						}
						if (endPrefabScript != null && num169 > splinePoints.Count - num28)
						{
							flag4 = true;
							Vector3 pCheck = splinePoints[num169] + vector10 * roadShape[num175].x;
							if (ERCrossingPrefabs.OOCQODQDQD(endRight, endLeft, pCheck))
							{
								pCheck = splinePoints[num169] + vector10 * roadShape[num175 + 1].x;
								if (ERCrossingPrefabs.OOCQODQDQD(endRight, endLeft, pCheck))
								{
									flag4 = true;
								}
							}
						}
						num34 = 0;
						if (num175 < count12)
						{
							num34 = (num34 = roadShapeMaterialInts[num175]);
						}
						if (num175 < count12 - 2 && num34 != roadShapeMaterialInts[num175 + 1])
						{
							flag4 = false;
						}
						if (count11 > num175 && !doConnectionTri[num175])
						{
							flag4 = false;
						}
						if (flag46)
						{
							num174++;
						}
						if (flag4 && num70 == 0)
						{
							if (!flipNormals)
							{
								tris[num34].Add(num59 + num175 + num174);
								tris[num34].Add(num59 + roadShapeCols + num175 + 1 + num174);
								tris[num34].Add(num59 + num175 + 1 + num174);
								tris[num34].Add(num59 + roadShapeCols + num175 + num174);
								tris[num34].Add(num59 + roadShapeCols + num175 + 1 + num174);
								tris[num34].Add(num59 + num175 + num174);
							}
							else
							{
								tris[num34].Add(num59 + num175 + num174);
								tris[num34].Add(num59 + num175 + 1 + num174);
								tris[num34].Add(num59 + roadShapeCols + num175 + 1 + num174);
								tris[num34].Add(num59 + roadShapeCols + num175 + num174);
								tris[num34].Add(num59 + num175 + num174);
								tris[num34].Add(num59 + roadShapeCols + num175 + 1 + num174);
							}
						}
					}
					if (flag5)
					{
						continue;
					}
					flag5 = true;
					for (int num176 = 0; num176 < array4.Length; num176++)
					{
						if (!array4[num176])
						{
							flag5 = false;
						}
					}
				}
				if (num39 > roadUvThreshold && num169 < splinePoints.Count - 1)
				{
					float num177 = num39;
					OCQCQCCDOO(ref vecs, ref uvs, ref uvs2, count4, ref addedRows, ref isPlanar, ref colors, ref num39, ref num57);
					num60 += num177 - num39;
					flag18 = true;
				}
				if (flag14 || num169 == 0)
				{
					tmpMarkersExt[num45].perpDir = vector10;
					tmpMarkersExt[num45].perpDirRotated = (vector11 - vector12).normalized;
				}
				soSplinePoints[num169] = Vector3.Lerp(soSplinePointsLeft[num169], soSplinePointsRight[num169], leftToCenterPerc);
				if (startPrefabScript != null && num38 < num12 * 6f)
				{
					if (startbendLeftRight == -1)
					{
						if (num169 > 0)
						{
							num38 += Vector3.Distance(a2, vector11);
						}
						a2 = vector11;
					}
					else
					{
						if (num169 > 0)
						{
							num38 += Vector3.Distance(a2, vector12);
						}
						a2 = vector12;
					}
				}
				Vector3 normalized4 = (vector11 - vector12).normalized;
				if (flag14 && num55 > 0f)
				{
					Vector3 pos6 = vector11 + normalized4 * (leftIndents[num169] + leftSurrounding[num169]);
					pos6 += -vector5 * num55;
					baseScript.OQCCDQOQOO(ref pos6);
					surfaceVecs[surfaceVecs.Count - 5] = pos6;
					leftSurroundingVecs[leftSurroundingVecs.Count - 1] = pos6;
					pos6 = vector11 + normalized4 * leftIndents[num169];
					pos6 += -vector5 * num55;
					baseScript.OQCCDQOQOO(ref pos6);
					surfaceVecs[surfaceVecs.Count - 4] = pos6;
					leftIndentVecs[leftIndentVecs.Count - 1] = pos6;
					leftIndentVecsSV[leftIndentVecsSV.Count - 1] = pos6;
					pos6 = splinePoints[num169];
					pos6 += -vector5 * num55;
					baseScript.OQCCDQOQOO(ref pos6);
					surfaceVecs[surfaceVecs.Count - 3] = pos6;
					pos6 = vector12 + -normalized4 * rightIndents[num169];
					pos6 += -vector5 * num55;
					baseScript.OQCCDQOQOO(ref pos6);
					surfaceVecs[surfaceVecs.Count - 2] = pos6;
					rightIndentVecs[rightIndentVecs.Count - 1] = pos6;
					rightIndentVecsSV[rightIndentVecsSV.Count - 1] = pos6;
					pos6 = vector12 + -normalized4 * (rightIndents[num169] + rightSurrounding[num169]);
					pos6 += -vector5 * num55;
					baseScript.OQCCDQOQOO(ref pos6);
					surfaceVecs[surfaceVecs.Count - 1] = pos6;
					rightSurroundingVecs[rightSurroundingVecs.Count - 1] = pos6;
					num55 = 0f;
				}
				flag43 = true;
				if (!bridgeElement[num169])
				{
					pos5 = vector11 + normalized4 * (leftIndents[num169] + leftSurrounding[num169]);
					Vector3 pos7 = pos5;
					baseScript.OQCCDQOQOO(ref pos7);
					if (baseScript.surroundingHeightFactor > 0f)
					{
						if (pos7.y > pos5.y)
						{
							float num178 = (pos7.y - pos5.y) * baseScript.surroundingHeightFactor;
							if (leftSurrounding[num169] < num178 && (double)leftSurrounding[num169] >= 0.5)
							{
								leftSurrounding[num169] = num178;
							}
							else if ((double)leftSurrounding[num169] < 0.5)
							{
								flag43 = false;
							}
							if (flag14)
							{
								markersExt[num45].leftSurroundingAdjusted = num178;
							}
						}
						else if (flag14)
						{
							markersExt[num45].leftSurroundingAdjusted = 0f;
						}
					}
					if (baseScript.terrainCellAngleThreshold > 0f && !baseScript.highlightSurfacesDrag)
					{
						float num179 = Mathf.Abs(pos7.y - pos5.y) / baseScript.terrainCellHeightThreshold * baseScript.terrainCellSize;
						if (leftSurrounding[num169] < num179)
						{
							leftSurrounding[num169] = num179;
						}
					}
				}
				else if (flag14)
				{
					markersExt[num45].leftSurroundingAdjusted = 0f;
				}
				pos5 = vector11 + normalized4 * (leftIndents[num169] + leftSurrounding[num169]);
				if (num53 > 0f)
				{
					vector11 = soSplinePointsLeft[num169 - 1];
					pos5 = vector11 + normalized4 * (leftIndents[num169] + leftSurrounding[num169]);
					pos5 += vector5 * num53;
					vector12 = soSplinePointsRight[num169 - 1];
				}
				else if (num55 > 0f)
				{
					pos5 += -vector5 * num55;
				}
				if (flag43)
				{
					baseScript.OQCCDQOQOO(ref pos5);
				}
				surfaceVecs.Add(pos5);
				list.Add(item);
				flag43 = true;
				leftSurroundingVecs.Add(pos5);
				pos5 = vector11 + normalized4 * leftIndents[num169];
				if (tmpMarkersExt[markerInts[num169]].leftIndentAlignment == 1)
				{
					baseScript.OQCCDQOQOO(ref pos5);
				}
				else if (tmpMarkersExt[markerInts[num169]].leftIndentAlignment == 2)
				{
					pos5.y = surfaceVecs[surfaceVecs.Count - 1].y;
				}
				else if (tmpMarkersExt[markerInts[num169]].leftIndentAlignment != 3)
				{
				}
				if (num53 > 0f)
				{
					pos5 += vector5 * num53;
					baseScript.OQCCDQOQOO(ref pos5);
				}
				else if (num55 > 0f)
				{
					pos5 += -vector5 * num55;
					baseScript.OQCCDQOQOO(ref pos5);
				}
				if (rt != null && rt.maxTerrainHeightOffset > 0f && count14 > 5)
				{
					pos5.y += randomLeftTerrainHeightOffset[num169];
				}
				surfaceVecs.Add(pos5);
				list.Add(new Vector2(0f, 1f));
				leftIndentVecs.Add(pos5);
				leftIndentVecsSV.Add(pos5);
				if (pos5.y < baseScript.terrainY - 0.02f && terrainDeformation)
				{
					vecsBelowTerrain.Add(soSplinePointsLeft[num169]);
				}
				pos5 = ((tmpMarkersExt[markerInts[num169]].leftIndentAlignment != 0 && tmpMarkersExt[markerInts[num169]].rightIndentAlignment == 0) ? Vector3.Lerp(vector11, vector12, num52) : ((tmpMarkersExt[markerInts[num169]].leftIndentAlignment != 0 || tmpMarkersExt[markerInts[num169]].rightIndentAlignment == 0) ? Vector3.Lerp(vector11, vector12, 0.5f) : Vector3.Lerp(vector12, vector11, num52)));
				if (rt != null && rt.maxTerrainHeightOffset > 0f && count14 > 5)
				{
					if (randomLeftTerrainHeightOffset[num169] > randomRightTerrainHeightOffset[num169])
					{
						pos5.y += randomLeftTerrainHeightOffset[num169];
					}
					else
					{
						pos5.y += randomRightTerrainHeightOffset[num169];
					}
				}
				if (num53 > 0f)
				{
					pos5 += vector5 * num53;
					baseScript.OQCCDQOQOO(ref pos5);
				}
				else if (num55 > 0f)
				{
					pos5 += -vector5 * num55;
					baseScript.OQCCDQOQOO(ref pos5);
				}
				surfaceVecs.Add(pos5);
				list.Add(new Vector2(0f, 1f));
				middleIndentVecs.Add(pos5);
				Vector3 pos8;
				pos5 = (pos8 = vector12 + -normalized4 * rightIndents[num169]);
				if (num53 > 0f)
				{
					pos5 += vector5 * num53;
					baseScript.OQCCDQOQOO(ref pos5);
				}
				else if (num55 > 0f)
				{
					pos5 += -vector5 * num55;
					baseScript.OQCCDQOQOO(ref pos5);
				}
				if (rt != null && rt.maxTerrainHeightOffset > 0f && count14 > 5)
				{
					pos5.y += randomRightTerrainHeightOffset[num169];
				}
				surfaceVecs.Add(pos5);
				list.Add(new Vector2(0f, 1f));
				rightIndentVecs.Add(pos5 + -normalized4);
				rightIndentVecsSV.Add(pos5);
				if (pos5.y < baseScript.terrainY - 0.02f && terrainDeformation)
				{
					vecsBelowTerrain.Add(soSplinePointsRight[num169]);
				}
				if (!bridgeElement[num169])
				{
					pos5 = vector12 + -normalized4 * (rightIndents[num169] + rightSurrounding[num169]);
					Vector3 pos9 = pos5;
					baseScript.OQCCDQOQOO(ref pos9);
					if (!bridgeElement[num169] && baseScript.surroundingHeightFactor > 0f)
					{
						if (pos9.y > pos5.y)
						{
							float num180 = (pos9.y - pos5.y) * baseScript.surroundingHeightFactor;
							if (rightSurrounding[num169] < num180 && (double)rightSurrounding[num169] >= 0.5)
							{
								rightSurrounding[num169] = num180;
							}
							else if ((double)rightSurrounding[num169] < 0.5)
							{
								flag43 = false;
							}
							if (flag14)
							{
								markersExt[num45].rightSurroundingAdjusted = num180;
							}
						}
						else if (flag14)
						{
							markersExt[num45].rightSurroundingAdjusted = 0f;
						}
					}
					if (baseScript.terrainCellAngleThreshold > 0f && !baseScript.highlightSurfacesDrag)
					{
						float num181 = Mathf.Abs(pos9.y - pos5.y) / baseScript.terrainCellHeightThreshold * baseScript.terrainCellSize;
						if (rightSurrounding[num169] < num181)
						{
							rightSurrounding[num169] = num181;
						}
					}
				}
				else if (flag14)
				{
					markersExt[num45].rightSurroundingAdjusted = 0f;
				}
				pos5 = vector12 + -normalized4 * (rightIndents[num169] + rightSurrounding[num169]);
				if (num53 > 0f)
				{
					pos5 += vector5 * num53;
				}
				else if (num55 > 0f)
				{
					pos5 += -vector5 * num55;
				}
				if (flag43)
				{
					baseScript.OQCCDQOQOO(ref pos5);
				}
				surfaceVecs.Add(pos5);
				list.Add(item);
				rightSurroundingVecs.Add(pos5);
				if (tmpMarkersExt[markerInts[num169]].rightIndentAlignment == 1)
				{
					baseScript.OQCCDQOQOO(ref pos8);
					surfaceVecs[surfaceVecs.Count - 2] = pos8;
				}
				else if (tmpMarkersExt[markerInts[num169]].rightIndentAlignment == 2)
				{
					pos8.y = pos5.y;
					surfaceVecs[surfaceVecs.Count - 2] = pos8;
				}
				else if (tmpMarkersExt[markerInts[num169]].rightIndentAlignment != 3)
				{
				}
				if (!startSurfacesSafe && !flag10)
				{
					if (num169 == 0 && startPrefabScript.doTerrainDeformation)
					{
						if (startPrefabScript.crossingElements[startConnectionSegment].leftSurroundingV3 != Vector3.zero)
						{
							surfaceVecs[4] = transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].leftSurroundingV3);
						}
						if (startPrefabScript.crossingElements[startConnectionSegment].rightSurroundingV3 != Vector3.zero)
						{
							surfaceVecs[0] = transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].rightSurroundingV3);
						}
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
						OQOCQDQODD.OODQDQCCOQ(this, ref surfaceVecs, startPrefabScript, ref startSurfacesSafe, num35, baseScript.minIndent);
					}
				}
				if (num169 == 0)
				{
					sv1 = vector11;
					sv2 = vector12;
					sv1 = vector11 + vector10 * indent;
					sv2 = vector12 + -vector10 * indent;
				}
				treeVecs.Add(soSplinePointsLeft[num169] + vector10 * baseScript.treeDistance);
				treeVecs.Add(soSplinePointsRight[num169] + -vector10 * baseScript.treeDistance);
				detailVecs.Add(soSplinePointsLeft[num169] + vector10 * baseScript.detailDistance - baseScript.detailOffsetVec);
				detailVecs.Add(soSplinePointsRight[num169] + -vector10 * baseScript.detailDistance - baseScript.detailOffsetVec);
				if (num169 < splinePoints.Count - 1)
				{
					flag41 = false;
					if (num169 > 0 && bridgeElement[num169 - 1])
					{
						flag41 = true;
					}
					flag42 = false;
					if (flag39 && num169 + 2 >= num166)
					{
						flag42 = true;
					}
					if (!flag12 && (!flag39 || flag42) && (!bridgeElement[num169] || !flag41 || !bridgeElement[num169 + 1]))
					{
						vegetationTris.Add(num169 * 2);
						vegetationTris.Add((num169 + 1) * 2 + 1);
						vegetationTris.Add(num169 * 2 + 1);
						vegetationTris.Add((num169 + 1) * 2);
						vegetationTris.Add((num169 + 1) * 2 + 1);
						vegetationTris.Add(num169 * 2);
					}
					if (!flag39 || flag42)
					{
						vegetationTreeTris.Add(num169 * 2);
						vegetationTreeTris.Add((num169 + 1) * 2 + 1);
						vegetationTreeTris.Add(num169 * 2 + 1);
						vegetationTreeTris.Add((num169 + 1) * 2);
						vegetationTreeTris.Add((num169 + 1) * 2 + 1);
						vegetationTreeTris.Add(num169 * 2);
					}
				}
				zero6 = vector11;
			}
			float num182 = 0f;
			float num183 = 0f;
			if (startPrefabScript != null && startPrefabScript.siblings.Count > startConnectionSegment && startPrefabScript.siblings[startConnectionSegment] != null)
			{
				num182 = startPrefabScript.siblings[startConnectionSegment].uvy;
			}
			if (endPrefabScript != null && endPrefabScript.siblings.Count > endConnectionSegment && endPrefabScript.siblings[endConnectionSegment] != null)
			{
				num183 = 1f - endPrefabScript.siblings[endConnectionSegment].uvy;
			}
			bool flag47 = false;
			float num184 = 0f;
			Vector2[] array6 = uvs.ToArray();
			Vector2[] collection4 = uvs2.ToArray();
			if (count4 > 0 && array6.Length - count4 >= 0)
			{
				num184 = Mathf.Round(array6[^1].y) / array6[^count4].y;
			}
			else
			{
				if (array6.Length == 0)
				{
					Debug.LogError("EasyRoads3Dv3 Error: " + base.gameObject.name + " mesh could not be created, no UV data available");
					return;
				}
				flag47 = true;
			}
			if (!flag18 && (num182 != 0f || num183 != 0f))
			{
				if (totalDistance > 5f)
				{
					num184 = array6[^1].y / array6[^count4].y;
					for (int num185 = 0; num185 < array6.Length - 1; num185 += count4)
					{
						for (int num186 = 0; num186 < count4; num186++)
						{
							if (isPlanar[num185 + num186])
							{
								continue;
							}
							if (!planarUVs)
							{
								if (num186 == 0)
								{
									array6[num185 + num186].y = num182 + array6[num185].y * num184;
								}
								else
								{
									array6[num185 + num186].y = array6[num185].y;
								}
							}
							else
							{
								array6[num185 + num186].y = array6[num185 + num186].y * num184;
							}
						}
					}
				}
			}
			else if (!flag18 && !flag47 && totalDistance > 5f && baseScript.clampUVs)
			{
				for (int num187 = 0; num187 < array6.Length - 1; num187 += count4)
				{
					for (int num188 = 0; num188 < count4; num188++)
					{
						if (isPlanar[num187 + num188])
						{
							continue;
						}
						if (!planarUVs)
						{
							if (num188 == 0)
							{
								array6[num187 + num188].y = array6[num187].y * num184;
							}
							else
							{
								array6[num187 + num188].y = array6[num187].y;
							}
						}
						else
						{
							array6[num187 + num188].y = array6[num187 + num188].y * num184;
						}
					}
				}
			}
			List<int> list38 = new List<int>();
			List<int> list39 = new List<int>();
			if (startPrefabScript != null && (!startPrefabScript.isSnapConnector || startPrefabScript.isExitRoadConnector))
			{
				if (startPrefabScript.meshVecs.Length == 0)
				{
				}
				int num189 = vecs.Count - 1;
				int num190 = count4;
				bool flag48 = false;
				if (ERCrossingPrefabs.OOCQODQDQD(vecs[num190], vecs[0], vecs[num190 * 2]))
				{
					flag48 = true;
				}
				List<int> connectionVecInts = startPrefabScript.crossingElements[startConnectionSegment].connectionVecInts;
				List<int> fullConnectionVecInts = startPrefabScript.crossingElements[startConnectionSegment].fullConnectionVecInts;
				List<Vector3> list40 = new List<Vector3>();
				List<Vector3> list41 = new List<Vector3>();
				List<int> list42 = new List<int>();
				for (int num191 = 0; num191 < count4; num191++)
				{
					Vector3 vector13 = Vector3.up;
					if (num191 + array2[num191] * count4 < 0)
					{
						if (Application.isPlaying)
						{
							throw new InvalidOperationException(base.gameObject.name + ": The angle with the crossing is too sharp " + startPrefabScript);
						}
						Debug.LogError(base.gameObject.name + ": The angle with the crossing is too sharp " + startPrefabScript);
						flag17 = false;
						break;
					}
					bool flag49 = false;
					if (startPrefabScript.isIConnector && endPrefabScript != null && endPrefabScript.isCustomPrefab)
					{
						flag49 = true;
					}
					if (!startPrefabScript.isCustomPrefab && !flag49)
					{
						int num192 = connectionVecInts.Count - roadShapeIntsStart[num191 - list4[num191]] - 1;
						if (num192 >= 0 && num192 < connectionVecInts.Count && startPrefabScript.tmpFullMeshVecs.Length > connectionVecInts[num192])
						{
							vector13 = startPrefabScript.transform.TransformPoint(startPrefabScript.tmpFullMeshVecs[connectionVecInts[num192]]);
						}
					}
					else
					{
						vector13 = startPrefabScript.transform.TransformPoint(startPrefabScript.tmpMeshVecs[connectionVecInts[connectionVecInts.Count - roadShapeIntsStart[num191 - list4[num191]] - 1]]);
					}
					if (fullConnectionVecInts.Count - num191 - 1 >= 0)
					{
						list39.Add(fullConnectionVecInts[fullConnectionVecInts.Count - num191 - 1]);
					}
					else
					{
						flag15 = false;
					}
					if (vector13 != Vector3.up)
					{
						vecs[num191 + array2[num191] * count4] = vector13;
					}
					list38.Add(num191 + array2[num191] * count4);
					if (!startPrefabScript.crossingElements[startConnectionSegment].rotationPriority)
					{
						float num193 = roadWidth / Mathf.Tan(startAngle * (MathF.PI / 180f));
						float num194 = (flag48 ? (10f + (1f - nodeDistance[num191 - list4[num191]]) * num193 * 2f) : (10f + nodeDistance[num191 - list4[num191]] * num193 * 2f));
						float num195 = 0f;
						int num196 = 1;
						Vector3 a6;
						Vector3 vector14 = (a6 = vecs[num191 + array2[num191] * count4]);
						while (num195 < num194)
						{
							Vector3 vector15 = vecs[num191 + (array2[num191] + num196) * count4];
							num195 += Vector3.Distance(a6, vector15);
							Vector3 normalized5 = (vector15 - vector14).normalized;
							Vector3 vector16 = Vector3.Lerp(-startDir, normalized5, num195 / num194);
							Vector3 vector17 = vector14 + vector16 * num195;
							a6 = vector15;
							if (num191 == num48)
							{
								Vector3 item2 = vecs[num191 + (array2[num191] + num196) * count4];
								item2.y -= y;
								list40.Add(item2);
								list42.Add(array2[num191] + num196);
							}
							if (num191 == num49)
							{
								Vector3 item3 = vecs[num191 + (array2[num191] + num196) * count4];
								item3.y -= y2;
								list41.Add(item3);
							}
							num196++;
							if (num191 + (array2[num191] + num196) * count4 > vecs.Count - 1)
							{
								break;
							}
						}
					}
					if (num182 == 0f && num183 == 0f)
					{
						if (!isPlanar[num191 + array2[num191] * count4])
						{
							float num197 = Vector3.Distance(vecs[num191 + array2[num191] * count4], vecs[num191 + count4 + array2[num191] * count4]);
							float y3 = array6[num191 + count4 + array2[num191] * count4].y - num197 / num40;
							array6[num191 + array2[num191] * count4].y = y3;
							array6[num191 + array2[num191] * count4].y = 0f;
						}
						else
						{
							vector13 = vecs[num191 + array2[num191] * count4];
							array6[num191 + array2[num191] * count4] = new Vector2(vector13.x * uvTiling, vector13.z * uvTiling);
						}
					}
				}
				int count15 = list40.Count;
				if (list41.Count < list40.Count)
				{
					count15 = list41.Count;
				}
				for (int num198 = 0; num198 < count15; num198++)
				{
					soSplinePoints[list42[num198]] = Vector3.Lerp(list40[num198], list41[num198], leftToCenterPerc);
					soSplinePointsLeft[list42[num198]] = list40[num198];
					soSplinePointsRight[list42[num198]] = list41[num198];
					soSplinePointsLeftClamped[list42[num198]] = list40[num198];
					soSplinePointsRightClamped[list42[num198]] = list41[num198];
				}
				List<Vector3> list43 = soSplinePointsLeft;
				List<Vector3> list44 = soSplinePointsLeftClamped;
				List<Vector3> list45 = vecs;
				int num199 = num48;
				_ = array2[0];
				Vector3 value = (list44[0] = list45[num199 + 0]);
				list43[0] = value;
				if (roadShape[num20].y != 0f)
				{
					Vector3 vector19 = soSplinePointsLeft[0];
					vector19.y -= roadShape[num20].y;
					List<Vector3> list46 = soSplinePointsLeft;
					value = (soSplinePointsLeftClamped[0] = vector19);
					list46[0] = value;
				}
				if (num49 + array2[num49] * count4 >= 0)
				{
					List<Vector3> list47 = soSplinePointsRight;
					value = (soSplinePointsRightClamped[0] = vecs[num49 + array2[num49] * count4]);
					list47[0] = value;
					if (roadShape[num21].y != 0f)
					{
						Vector3 vector22 = soSplinePointsRight[0];
						vector22.y -= roadShape[num21].y;
						List<Vector3> list48 = soSplinePointsRight;
						value = (soSplinePointsRightClamped[0] = vector22);
						list48[0] = value;
					}
					soSplinePoints[0] = Vector3.Lerp(soSplinePointsLeft[0], soSplinePointsRight[0], leftToCenterPerc);
				}
			}
			List<int> list49 = new List<int>();
			List<int> list50 = new List<int>();
			if (endPrefabScript != null && (!endPrefabScript.isSnapConnector || endPrefabScript.isExitRoadConnector))
			{
				if (endPrefabScript.meshVecs.Length == 0)
				{
					endPrefabScript.OCODCDCDQQ();
				}
				int num200 = vecs.Count - 1;
				int num201 = count4;
				bool flag50 = false;
				if (ERCrossingPrefabs.OOCQODQDQD(vecs[num200], vecs[num200 - num201], vecs[num200 - num201 * 2]))
				{
					flag50 = true;
				}
				int num202 = vecs.Count - count4;
				List<int> connectionVecInts2 = endPrefabScript.crossingElements[endConnectionSegment].connectionVecInts;
				List<int> fullConnectionVecInts2 = endPrefabScript.crossingElements[endConnectionSegment].fullConnectionVecInts;
				List<Vector3> list51 = new List<Vector3>();
				List<Vector3> list52 = new List<Vector3>();
				List<int> list53 = new List<int>();
				for (int num203 = 0; num203 < count4; num203++)
				{
					try
					{
						if (!endPrefabScript.isCustomPrefab && !endPrefabScript.isIConnector)
						{
							vecs[num202 + num203] = endPrefabScript.transform.TransformPoint(endPrefabScript.tmpFullMeshVecs[connectionVecInts2[roadShapeIntsEnd[num203 - list4[num203]]]]);
						}
						else
						{
							vecs[num202 + num203] = endPrefabScript.transform.TransformPoint(endPrefabScript.tmpMeshVecs[connectionVecInts2[roadShapeIntsEnd[num203 - list4[num203]]]]);
						}
						list49.Add(num202 + num203);
						if (fullConnectionVecInts2.Count > num203)
						{
							list50.Add(fullConnectionVecInts2[num203]);
						}
						else
						{
							flag16 = false;
						}
						if (!endPrefabScript.crossingElements[endConnectionSegment].rotationPriority)
						{
							float num204 = roadWidth / Mathf.Tan(endAngle * (MathF.PI / 180f));
							float num205 = (flag50 ? (10f + (1f - nodeDistance[num203 - list4[num203]]) * num204 * 2f) : (3f + nodeDistance[num203 - list4[num203]] * num204 * 2f));
							float num206 = 0f;
							int num207 = 0;
							Vector3 a7;
							Vector3 vector24 = (a7 = vecs[num202 + num203 - num207 * count4]);
							num207 = 1;
							while (num206 < num205 && num202 + num203 - num207 * count4 >= 0)
							{
								Vector3 vector25 = vecs[num202 + num203 - num207 * count4];
								num206 += Vector3.Distance(a7, vector25);
								Vector3 normalized6 = (vector25 - vector24).normalized;
								Vector3 vector26 = Vector3.Lerp(-endDir, normalized6, num206 / num205);
								Vector3 vector27 = vector24 + vector26 * num206;
								a7 = vector25;
								if (num203 == num48)
								{
									Vector3 item4 = vecs[num202 + num203 - num207 * count4];
									item4.y -= y;
									list51.Add(item4);
									list53.Add(splinePoints.Count - 1 - num207);
								}
								if (num203 == num49)
								{
									Vector3 item5 = vecs[num202 + num203 - num207 * count4];
									item5.y -= y2;
									list52.Add(item5);
								}
								num207++;
								if (num202 + num203 - num207 * count4 > vecs.Count - 1)
								{
									break;
								}
							}
						}
						if (num182 == 0f && num183 == 0f)
						{
							if (!isPlanar[num202 + num203])
							{
								float num208 = Vector3.Distance(vecs[num202 + num203], vecs[num202 + num203 - count4]);
								float y4 = array6[num202 + num203 - count4].y + num208 / num40;
								array6[num202 + num203].y = y4;
							}
							else
							{
								Vector3 vector28 = vecs[num202 + num203];
								array6[num202 + num203] = new Vector2(vector28.x * uvTiling, vector28.z * uvTiling);
							}
						}
					}
					catch
					{
						Debug.Log("EasyRoads3Dv3 Error: Connection Mesh error, please report this error");
					}
				}
				if (endPrefabScript.isIConnector)
				{
					num184 = 1f / array6[^1].y * Mathf.Round(array6[^1].y);
					num184 = Mathf.Round(array6[^1].y) / array6[^count4].y;
					if (totalDistance > 5f && baseScript.clampUVs)
					{
						for (int num209 = 0; num209 < array6.Length; num209 += count4)
						{
							for (int num210 = 0; num210 < count4; num210++)
							{
								if (isPlanar[num209 + num210])
								{
									continue;
								}
								if (!planarUVs)
								{
									if (num210 == 0)
									{
										array6[num209 + num210].y = array6[num209].y * num184;
									}
									else
									{
										array6[num209 + num210].y = array6[num209].y;
									}
								}
								else
								{
									array6[num209 + num210].y = array6[num209 + num210].y * num184;
								}
							}
						}
					}
				}
				if (leftToCenterPerc == 0f)
				{
					leftToCenterPerc = OODCDDQOQC.GetleftToCenterPerc(roadShape, num20, num21);
				}
				int count16 = list51.Count;
				if (list52.Count < list51.Count)
				{
					count16 = list52.Count;
				}
				for (int num211 = 0; num211 < count16; num211++)
				{
					soSplinePoints[list53[num211]] = Vector3.Lerp(list51[num211], list52[num211], leftToCenterPerc);
					soSplinePointsLeft[list53[num211]] = list51[num211];
					soSplinePointsRight[list53[num211]] = list52[num211];
					soSplinePointsLeftClamped[list53[num211]] = list51[num211];
					soSplinePointsRightClamped[list53[num211]] = list52[num211];
				}
				soSplinePointsLeft[soSplinePointsLeft.Count - 1] = vecs[num202 + num48];
				soSplinePointsLeftClamped[soSplinePointsLeft.Count - 1] = vecs[num202 + num48];
				soSplinePointsRight[soSplinePointsRight.Count - 1] = vecs[num202 + num49];
				soSplinePointsRightClamped[soSplinePointsRight.Count - 1] = vecs[num202 + num49];
				if (roadShape[num20].y != 0f)
				{
					Vector3 vector29 = soSplinePointsLeft[soSplinePointsLeft.Count - 1];
					vector29.y -= roadShape[num20].y;
					List<Vector3> list54 = soSplinePointsLeft;
					int index = soSplinePointsLeft.Count - 1;
					Vector3 value = (soSplinePointsLeftClamped[soSplinePointsLeft.Count - 1] = vector29);
					list54[index] = value;
				}
				if (roadShape[num21].y != 0f)
				{
					Vector3 vector31 = soSplinePointsRight[soSplinePointsRight.Count - 1];
					vector31.y -= roadShape[num21].y;
					List<Vector3> list55 = soSplinePointsRight;
					int index2 = soSplinePointsRight.Count - 1;
					Vector3 value = (soSplinePointsRightClamped[soSplinePointsRight.Count - 1] = vector31);
					list55[index2] = value;
				}
				soSplinePoints[soSplinePoints.Count - 1] = Vector3.Lerp(soSplinePointsLeft[soSplinePointsLeft.Count - 1], soSplinePointsRight[soSplinePointsRight.Count - 1], leftToCenterPerc);
			}
			Color[] array7 = new Color[vecs.Count];
			for (int num212 = 0; num212 < array7.Length; num212++)
			{
				array7[num212] = Color.white;
			}
			if (closedTrack)
			{
				for (int num213 = 0; num213 < count4; num213++)
				{
					vecs[vecs.Count - count4 + num213] = vecs[num213];
				}
			}
			else
			{
				if ((double)fadeInDistance > 0.5)
				{
					float num214 = 0f;
					float a8 = 0f;
					int num215 = 0;
					while (num214 < fadeInDistance)
					{
						for (int num216 = 0; num216 < count4; num216++)
						{
							array7[num215 * count4 + num216].a = a8;
						}
						if (vecs.Count > (num215 + 2) * count4)
						{
							num214 += faceDistance;
							a8 = num214 / fadeInDistance;
							a8 *= a8;
							num215++;
							continue;
						}
						break;
					}
				}
				if ((double)fadeOutDistance > 0.5)
				{
					if (array7 == null)
					{
					}
					float num217 = 0f;
					float a9 = 0f;
					int num218 = 0;
					int count17 = vecs.Count;
					while (num217 < fadeOutDistance)
					{
						for (int num219 = 0; num219 < count4; num219++)
						{
							array7[count17 - 1 - num218 * count4 - num219].a = a9;
						}
						if (vecs.Count > (num218 + 2) * count4)
						{
							num217 += faceDistance;
							a9 = num217 / fadeOutDistance;
							a9 *= a9;
							num218++;
							continue;
						}
						break;
					}
				}
			}
			if (tCrossingConnected)
			{
				float num220 = totalDistance;
				totalDistance = 0f;
				for (int num221 = 1; num221 < soSplinePoints.Count; num221++)
				{
					totalDistance += Vector3.Distance(soSplinePoints[num221 - 1], soSplinePoints[num221]);
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
			meshUVs = new List<Vector2>(array6);
			meshUVs2.Clear();
			meshUVs2 = new List<Vector2>(collection4);
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
				int num222 = 0;
				Material[] sharedMaterials = base.gameObject.GetComponent<MeshRenderer>().sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (roadMaterials.Length > num222 && material != roadMaterials[num222])
					{
						roadMaterials[num222] = material;
					}
					num222++;
				}
			}
			Material[] array8 = new List<Material>(roadMaterials).ToArray();
			if (!isSideObject)
			{
				bool hasExits = false;
				OCDCDDDQOC.OQCQOQQOOQ(baseScript, this, exitRoads, markersExt, ref soSplinePointsLeft, ref soSplinePointsRight, ref hasExits, leftIndents, rightIndents, leftSurrounding, rightSurrounding, ref surfaceVecs);
				if (roadMaterials == null)
				{
					roadMaterials = new List<Material>(base.gameObject.GetComponent<MeshRenderer>().sharedMaterials).ToArray();
				}
				else if (roadMaterials.Length != 0 && roadMaterials[0] == null)
				{
					roadMaterials = new List<Material>(base.gameObject.GetComponent<MeshRenderer>().sharedMaterials).ToArray();
				}
				if (hasExits)
				{
					List<Color> list56 = new List<Color>(array7);
					array7 = list56.ToArray();
				}
			}
			if (uv4Type == 1 && (double)Mathf.Abs(num58 - meshUVs2[meshUVs2.Count - 1].y) > 0.01)
			{
				float num224 = num58 / meshUVs2[meshUVs2.Count - 1].y;
				for (int num225 = 0; num225 < meshUVs2.Count; num225++)
				{
					meshUVs2[num225] = new Vector2(meshUVs2[num225].x, meshUVs2[num225].y * num224);
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
					mesh.colors = colors.ToArray();
				}
				else if (array7.Length == vecs.Count)
				{
					mesh.colors = array7;
				}
				else
				{
					mesh.colors = new Color[vecs.Count];
					Debug.Log("Road: " + base.gameObject.name + " , colors array is out of bounds ");
				}
				mesh.tangents = new Vector4[vecs.Count];
				int num226 = 0;
				for (int num227 = 0; num227 < tris.Count; num227++)
				{
					if (tris[num227].Count > 0)
					{
						num226++;
					}
				}
				mesh.subMeshCount = num226;
				trisStats = 0;
				for (int num228 = 0; num228 < tris.Count; num228++)
				{
					if (num228 >= num226)
					{
						continue;
					}
					for (int num229 = 0; num229 < tris[num228].Count; num229++)
					{
						if (tris[num228][num229] > vecs.Count)
						{
							Debug.Log("tri out of bounds:" + tris[num228][num229] + " > " + (vecs.Count - 1));
						}
					}
					mesh.SetTriangles(tris[num228].ToArray(), num228);
					trisStats += tris[num228].Count;
				}
				mesh.RecalculateNormals();
				mesh.RecalculateBounds();
				OCOQOCQDDC(mesh);
				if (mesh.name == "")
				{
					mesh.name = "ER Road Mesh";
				}
				mesh.RecalculateTangents();
				if (closedTrack)
				{
					int num230 = vecs.Count - 1;
					int count18 = roadShape.Count;
					for (int num231 = 0; num231 < count18; num231++)
					{
						mesh.normals[num231] = (mesh.normals[num230 - count18 + num231] = Vector3.Lerp(mesh.normals[num231], mesh.normals[num230 - count18 + num231], 0.5f));
					}
				}
				if (!closedTrack && ((bool)startPrefabScript || (bool)endPrefabScript))
				{
					mesh.normals = AdjustNormals(mesh.normals);
				}
				if ((bool)startPrefabScript && flag8 && flag15 && startPrefabScript.averageNormals)
				{
					AdjustPrefabNormals(list38, list39, mesh.normals, startPrefabScript.gameObject, mesh.vertices);
				}
				if ((bool)endPrefabScript && flag9 && flag16 && endPrefabScript.averageNormals)
				{
					AdjustPrefabNormals(list49, list50, mesh.normals, endPrefabScript.gameObject, mesh.vertices);
				}
				vertsStats = vecs.Count;
				trisStats /= 3;
				if (hasMeshCollider && flag17)
				{
					base.gameObject.GetComponent<MeshCollider>().sharedMesh = null;
					if (totalDistance > 1f)
					{
						base.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
					}
				}
				else if (hasMeshCollider)
				{
					base.gameObject.GetComponent<MeshCollider>().sharedMesh = null;
				}
				if (array8.Length != num226)
				{
					List<Material> list57 = new List<Material>();
					for (int num232 = 0; num232 < num226; num232++)
					{
						if (array8.Length > num232)
						{
							list57.Add(array8[num232]);
						}
					}
					array8 = list57.ToArray();
				}
				base.gameObject.GetComponent<MeshRenderer>().sharedMaterials = array8;
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
				Debug.Log("The road mesh exceeds Unity’s vertices limit of 65.000, updating the mesh is aborted: " + base.gameObject.name);
			}
			Vector3 zero8 = Vector3.zero;
			Vector3 zero9 = Vector3.zero;
			int num233 = 0;
			int num234 = 0;
			bool flag51 = false;
			bool flag52 = false;
			ERSOSection eRSOSection4 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
			bool flag53 = true;
			bool flag54 = true;
			int num235 = 0;
			bool flag55 = false;
			bool flag56 = false;
			ERSOSection eRSOSection5 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
			Vector2 uv = Vector3.zero;
			GameObject go = null;
			GameObject go2 = null;
			ERSOSection eRSOSection6 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
			int num236 = 0;
			bool flag57 = false;
			bool flag58 = false;
			ERSOSection eRSOSection7 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
			int num237 = 0;
			bool flag59 = false;
			bool flag60 = false;
			bool flag61 = false;
			bool flag62 = false;
			float num238 = -100000f;
			float num239 = 100000f;
			float num240 = -100000f;
			float num241 = 100000f;
			float num242 = 0f;
			float num243 = 0f;
			float num244 = 10f;
			bool flag63 = false;
			if (surfaceMesh != null)
			{
				flag63 = surfaceMesh.activeSelf;
				surfaceMesh.SetActive(value: false);
			}
			bool flag64 = false;
			bool flag65 = false;
			int num245 = 0;
			int num246 = -1;
			int num247 = -1;
			int num248 = -1;
			bool flag66 = false;
			if (soSectionList2.Count > 0)
			{
				flag66 = true;
			}
			if (flag66)
			{
				num246 = soSectionList2[0].startSplinePointGeo;
				num247 = soSectionList2[0].endSplinePointGeo + 1;
				if (num246 == 0 && !soSectionList2[0].acceptBarriers)
				{
					flag64 = true;
				}
			}
			float num249 = 0f;
			float num250 = 0f;
			if (list21.Count > 0)
			{
				if ((!oneWayRoad && baseScript.rightHandDriving == 0) || oneWayDirection == ERLaneDirection.Left)
				{
					num250 = 180f;
				}
				else if ((!oneWayRoad && baseScript.rightHandDriving == 1) || oneWayDirection == ERLaneDirection.Left)
				{
					num249 = 180f;
				}
			}
			bool flag67 = false;
			bool flag68 = false;
			int num251 = 0;
			int num252 = 0;
			float num253 = 0f;
			int num254 = splinePoints.Count - 2;
			num45 = 0;
			float num255 = tmpMarkersExt[0].slopeAngle;
			float num256 = num255;
			int count19 = tmpMarkersExt.Count;
			int count20 = splinePoints.Count;
			int num257 = 0;
			for (int num258 = 1; num258 < count20; num258++)
			{
				if (num45 + 1 < count19 && num258 == tmpMarkersExt[num45 + 1].startSplinePoint - 1)
				{
					if (flag58 && tmpMarkersExt[num45 + 1].slopeAngle > num255)
					{
						num255 = tmpMarkersExt[num45 + 1].slopeAngle;
					}
					if (flag60 && tmpMarkersExt[num45 + 1].slopeAngle > num256)
					{
						num256 = tmpMarkersExt[num45 + 1].slopeAngle;
					}
					num45++;
				}
				if (flag66)
				{
					if (num258 == num246)
					{
						if (!soSectionList2[num245].acceptBarriers)
						{
							flag64 = true;
						}
					}
					else if (num258 == num247 + 1)
					{
						flag65 = flag64;
						flag64 = false;
						num248 = num247;
						if (soSectionList2.Count > num245 + 1)
						{
							flag64 = false;
							num245++;
							num246 = soSectionList2[num245].startSplinePointGeo;
							num247 = soSectionList2[num245].endSplinePointGeo + 1;
						}
					}
				}
				zero8 = leftIndentVecsSV[num258];
				baseScript.OQCCDQOQOO(ref zero8);
				zero9 = rightIndentVecsSV[num258];
				baseScript.OQCCDQOQOO(ref zero9);
				if (flag61)
				{
					flag61 = false;
					go = null;
					if (OQQOCDQCQD.RaycastRoadsSurfaces(baseScript.sLayer, leftIndentVecsSV[num258], ref uv, ref go, checkHeightFlag: true) && go == null)
					{
						flag61 = true;
					}
				}
				if (!flag58 && list22.Count > 0)
				{
					if (OQQOCDQCQD.RaycastRoadsSurfaces(baseScript.sLayer, leftIndentVecsSV[num258], ref uv, ref go, checkHeightFlag: true) && go == null)
					{
						flag61 = true;
					}
					if ((leftIndentVecsSV[num258].y - zero8.y > num77 || flag61) && !bridgeElement[num258])
					{
						float num259 = distances[num258];
						bool flag69 = false;
						for (int num260 = num258; num260 > 0; num260--)
						{
							if (bridgeElement[num260])
							{
								flag69 = true;
								break;
							}
							if (num259 - distances[num260] > 10f)
							{
								break;
							}
						}
						if (!flag69)
						{
							while (soSectionList6.Count > num236)
							{
								if (Vector3.Distance(soSectionList6[num236].startSplinePointOrig, splinePoints[num258]) < 10f)
								{
									eRSOSection6 = soSectionList6[num236];
									num236++;
									flag57 = true;
									break;
								}
								if (distances.Count > num258 && Mathf.Abs(soSectionList6[num236].startDistance - distances[num258]) < 10f)
								{
									eRSOSection6 = soSectionList6[num236];
									num236++;
									flag57 = true;
									break;
								}
								if (distances.Count > num258 && soSectionList6[num236].startDistance < distances[num258])
								{
									soSectionList6.RemoveAt(num236);
									continue;
								}
								break;
							}
							eRSOSection6.startSplinePoint = num258;
							eRSOSection6.startSplinePointOrig = splinePoints[num258];
							if (num258 == 1 && startPrefabScript != null)
							{
								Vector3 pos10 = leftIndentVecsSV[0];
								baseScript.OQCCDQOQOO(ref pos10);
								if (leftIndentVecsSV[num258].y - pos10.y > num77)
								{
									eRSOSection6.startSplinePoint = 0;
									eRSOSection6.startSplinePointOrig = splinePoints[0];
								}
							}
							flag58 = true;
							eRSOSection6.roadSide = ERRoadSide.Left;
							flag67 = !eRSOSection6.acceptBarriers;
						}
					}
				}
				else if (flag58)
				{
					if (list23[num258] < num239)
					{
						num239 = list23[num258];
					}
					else if (list23[num258] > num238)
					{
						num238 = list23[num258];
					}
					if (num258 > 0)
					{
						num242 += distances[num258] - distances[num258 - 1];
					}
					if ((leftIndentVecsSV[num258].y - zero8.y < num77 && !flag61) || bridgeElement[num258])
					{
						flag27 = false;
						if (bridgeElement[num258] && num242 < num244)
						{
							flag58 = false;
							flag27 = true;
							num242 = 0f;
							if (soSectionList6.Count > num236)
							{
								soSectionList6.RemoveAt(num236);
								num236--;
							}
						}
						bool flag70 = OCQODDCQDD.OQQDQDQCDO(list22, eRSOSection6.so);
						if (!flag57 || eRSOSection6.soid == 0.0 || !flag70)
						{
							eRSOSection6.so = list22[0];
							eRSOSection6.soid = list22[0].id;
							eRSOSection6.acceptBarriers = list22[0].acceptBarriers;
							flag67 = !eRSOSection6.acceptBarriers;
						}
						if (!eRSOSection6.forceSo && (eRSOSection6.so.heightThreshold > num238 || eRSOSection6.so.heightMaxThreshold < num238 || eRSOSection6.so.maxSlope < num255))
						{
							int num261 = -1;
							int num262 = -1;
							bool flag71 = false;
							for (int num263 = 0; num263 < list22.Count; num263++)
							{
								if (list22[num263].heightThreshold <= num238 && list22[num263].heightMaxThreshold >= num238 && list22[num263].maxSlope > num255)
								{
									num261 = num263;
									eRSOSection6.so = list22[num263];
									eRSOSection6.soid = list22[num263].id;
									eRSOSection6.acceptBarriers = list22[num263].acceptBarriers;
									flag67 = !eRSOSection6.acceptBarriers;
									break;
								}
								if (list22[num263].heightMaxThreshold >= num238 && ((num262 >= 0 && list22[num263].heightMaxThreshold < list22[num262].heightMaxThreshold) || num262 == -1) && list22[num263].maxSlope > num255 && !list22[num263].strictRules)
								{
									num262 = num263;
									flag71 = true;
								}
								else if (list22[num263].heightMaxThreshold >= num238 && ((num262 >= 0 && list22[num263].heightMaxThreshold < list22[num262].heightMaxThreshold) || num262 == -1) && !flag71 && !list22[num263].strictRules)
								{
									num262 = num263;
								}
								else if (list22[num263].maxSlope > num255 && !flag71 && !list22[num263].strictRules)
								{
									num262 = num263;
								}
							}
							if (num261 == -1 && num262 >= 0)
							{
								eRSOSection6.so = list22[num262];
								eRSOSection6.soid = list22[num262].id;
								eRSOSection6.acceptBarriers = list22[num262].acceptBarriers;
								flag67 = !eRSOSection6.acceptBarriers;
							}
							else if (num261 == -1 && eRSOSection6.so != null && eRSOSection6.so.strictRules)
							{
								flag27 = true;
								flag58 = false;
								if (flag57 && soSectionList6.Count > num236 - 1)
								{
									soSectionList6.RemoveAt(num236 - 1);
								}
							}
						}
						if (eRSOSection6.so == null)
						{
							eRSOSection6.so = list22[0];
							eRSOSection6.soid = list22[0].id;
						}
						float num264 = 10f;
						float num265 = 0f;
						if (!bridgeElement[num258] && !flag27)
						{
							flag27 = false;
							for (int num266 = num258; num266 < count20 - 1; num266++)
							{
								num265 += Vector3.Distance(splinePoints[num266], splinePoints[num266 + 1]);
								Vector3 pos11 = leftIndentVecsSV[num266];
								baseScript.OQCCDQOQOO(ref pos11);
								if (leftIndentVecsSV[num266].y - pos11.y > num77)
								{
									flag27 = true;
									break;
								}
								if (num265 > num264)
								{
									break;
								}
							}
						}
						if (!flag27)
						{
							int startSplinePoint2 = eRSOSection6.startSplinePoint;
							float heightMaxStartThreshold2 = eRSOSection6.so.heightMaxStartThreshold;
							float num267 = 0f;
							bool flag72 = false;
							for (int num268 = startSplinePoint2; num268 > 0; num268--)
							{
								Vector3 pos11 = leftIndentVecsSV[num268];
								baseScript.OQCCDQOQOO(ref pos11);
								if (leftIndentVecsSV[num268].y - pos11.y < heightMaxStartThreshold2 || bridgeElement[num268])
								{
									eRSOSection6.startSplinePoint = num268;
									flag72 = true;
									eRSOSection6.startFraction = 0f;
									break;
								}
							}
							if (!flag72)
							{
								eRSOSection6.startSplinePoint = 0;
								eRSOSection6.startFraction = 0f;
							}
							int num269 = num258 - 1;
							if (!bridgeElement[num258])
							{
								num265 = eRSOSection6.so.heightMaxStartThreshold;
								flag72 = false;
								for (int num270 = num269; num270 < count20; num270++)
								{
									Vector3 pos11 = leftIndentVecsSV[num270];
									baseScript.OQCCDQOQOO(ref pos11);
									if (leftIndentVecsSV[num270].y - pos11.y < heightMaxStartThreshold2)
									{
										eRSOSection6.endSplinePoint = num270;
										flag72 = true;
										eRSOSection6.endFraction = 0f;
										break;
									}
								}
								if (!flag72)
								{
									eRSOSection6.endSplinePoint = count20 - 1;
									eRSOSection6.endFraction = 0f;
								}
							}
							else
							{
								eRSOSection6.endSplinePoint = num258;
								eRSOSection6.endFraction = 0f;
							}
							float num271 = OQQOCDQCQD.OCCOCQQCCQ(baseScript.activeTerrain, splinePoints[eRSOSection6.startSplinePoint], splinePoints[eRSOSection6.startSplinePoint + 1]);
							startSplinePoint2 = eRSOSection6.startSplinePoint;
							num265 = num271 + 1f;
							num267 = 0f;
							flag72 = false;
							int num272 = 0;
							for (int num273 = startSplinePoint2; num273 > 0; num273--)
							{
								num267 = Vector3.Distance(splinePoints[num273], splinePoints[num273 + 1]);
								float num274 = num265;
								num265 -= num267;
								if (num265 < 0f)
								{
									num272 = eRSOSection6.startSplinePoint - num273;
									eRSOSection6.startSplinePoint = num273 + 1;
									eRSOSection6.startFraction = num274 / num267;
									eRSOSection6.startSplinePoint = num273;
									flag72 = true;
									break;
								}
							}
							if (!flag72)
							{
								num272 = eRSOSection6.startSplinePoint;
								eRSOSection6.startSplinePoint = 0;
								eRSOSection6.startFraction = 0f;
							}
							int num275 = 0;
							if (!bridgeElement[num258])
							{
								num271 = OQQOCDQCQD.OCCOCQQCCQ(baseScript.activeTerrain, splinePoints[eRSOSection6.endSplinePoint], splinePoints[eRSOSection6.endSplinePoint - 1]);
								num269 = eRSOSection6.endSplinePoint;
								num265 = num271 + 1f;
								num267 = 0f;
								flag72 = false;
								for (int num276 = num269; num276 < count20 - 1; num276++)
								{
									num267 = Vector3.Distance(splinePoints[num276], splinePoints[num276 + 1]);
									float num274 = num265;
									num265 -= num267;
									if (num265 < 0f)
									{
										num275 = num276 - eRSOSection6.endSplinePoint;
										eRSOSection6.endFraction = num274 / num267;
										eRSOSection6.endSplinePoint = num276 + 1;
										flag72 = true;
										break;
									}
								}
								if (!flag72)
								{
									num275 = count20 - 1 - eRSOSection6.endSplinePoint;
									eRSOSection6.endSplinePoint = count20 - 1;
									eRSOSection6.endFraction = 0f;
								}
							}
							if (!flag57)
							{
								if (num236 < soSectionList6.Count)
								{
									soSectionList6.Insert(num236, eRSOSection6);
								}
								else
								{
									soSectionList6.Add(eRSOSection6);
								}
								num236++;
							}
							else
							{
								soSectionList6[num236 - 1] = eRSOSection6;
							}
							flag57 = false;
							if (eRSOSection6.active)
							{
								float num277 = 0f;
								for (int num278 = eRSOSection6.startSplinePoint + num272; num278 < eRSOSection6.endSplinePoint - num275; num278++)
								{
									int num279 = 1;
									if (startPrefabScript != null)
									{
										num279 = -1;
									}
									if (num278 > num279 && num278 < count20 - 2)
									{
										Vector3 pos11 = leftIndentVecsSV[num278];
										pos11 = soSplinePointsLeft[num278];
										num277 = pos11.y;
										baseScript.OQCCDQOQOO(ref pos11);
										if (num277 > pos11.y)
										{
											doLeftSurrounding[num278] = false;
											surfaceVecs[num278 * 5 + 1] = pos11;
											List<Vector3> list58 = leftIndentVecsSV;
											int index3 = num278;
											Vector3 value = (leftSurroundingVecs[num278] = pos11);
											list58[index3] = value;
										}
									}
								}
							}
							if (flag67)
							{
								num251 = eRSOSection6.endSplinePoint + 1;
								if (num233 > 0)
								{
									ERSOSection target = soSectionList3[num233 - 1];
									soSectionList3[num233 - 1] = ERSOSection.OQQCDOOODQ(target, eRSOSection6);
								}
							}
							else
							{
								num251 = 0;
							}
							eRSOSection6 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
							num238 = -100000f;
							num239 = 100000f;
							num242 = 0f;
							flag58 = (flag67 = false);
							num255 = 0f;
						}
					}
				}
				if (flag62)
				{
					flag62 = false;
					go2 = null;
					if (OQQOCDQCQD.RaycastRoadsSurfaces(baseScript.sLayer, rightIndentVecsSV[num258], ref uv, ref go2, checkHeightFlag: true) && go2 == null)
					{
						flag62 = true;
					}
				}
				if (!flag60 && list22.Count > 0)
				{
					if (OQQOCDQCQD.RaycastRoadsSurfaces(baseScript.sLayer, rightIndentVecsSV[num258], ref uv, ref go2, checkHeightFlag: true) && go2 == null)
					{
						flag62 = true;
					}
					if ((rightIndentVecsSV[num258].y - zero9.y > num77 || flag62) && !bridgeElement[num258])
					{
						float num280 = distances[num258];
						bool flag73 = false;
						for (int num281 = num258; num281 > 0; num281--)
						{
							if (bridgeElement[num281])
							{
								flag73 = true;
								break;
							}
							if (num280 - distances[num281] > 10f)
							{
								break;
							}
						}
						if (!flag73)
						{
							while (soSectionList7.Count > num237)
							{
								if (Vector3.Distance(soSectionList7[num237].startSplinePointOrig, splinePoints[num258]) < 10f)
								{
									eRSOSection7 = soSectionList7[num237];
									num237++;
									flag59 = true;
									break;
								}
								if (distances.Count > num258 && Mathf.Abs(soSectionList7[num237].startDistance - distances[num258]) < 10f)
								{
									eRSOSection7 = soSectionList7[num237];
									num237++;
									flag59 = true;
									break;
								}
								if (distances.Count > num258 && soSectionList7[num237].startDistance < distances[num258])
								{
									soSectionList7.RemoveAt(num237);
									continue;
								}
								break;
							}
							eRSOSection7.startSplinePoint = num258;
							eRSOSection7.startSplinePointOrig = splinePoints[num258];
							if (num258 == 1 && startPrefabScript != null)
							{
								Vector3 pos12 = rightIndentVecsSV[0];
								baseScript.OQCCDQOQOO(ref pos12);
								if (rightIndentVecsSV[num258].y - pos12.y > num77)
								{
									eRSOSection7.startSplinePoint = 0;
									eRSOSection7.startSplinePointOrig = splinePoints[0];
								}
							}
							flag60 = true;
							eRSOSection7.roadSide = ERRoadSide.Right;
							flag68 = !eRSOSection7.acceptBarriers;
						}
					}
				}
				else if (flag60)
				{
					if (list24[num258] < num241)
					{
						num241 = list24[num258];
					}
					else if (list24[num258] > num240)
					{
						num240 = list24[num258];
					}
					if (num258 > 0)
					{
						num243 += distances[num258] - distances[num258 - 1];
					}
					if ((rightIndentVecsSV[num258].y - zero9.y < num77 && !flag62) || bridgeElement[num258])
					{
						flag27 = false;
						if (bridgeElement[num258] && num243 < num244)
						{
							flag60 = false;
							flag27 = true;
							num243 = 0f;
							if (soSectionList7.Count > num237)
							{
								soSectionList7.RemoveAt(num237);
								num237--;
							}
						}
						bool flag74 = OCQODDCQDD.OQQDQDQCDO(list22, eRSOSection7.so);
						if (!flag59 || eRSOSection7.soid == 0.0 || !flag74)
						{
							eRSOSection7.so = list22[0];
							eRSOSection7.soid = list22[0].id;
							eRSOSection7.acceptBarriers = list22[0].acceptBarriers;
							flag68 = !eRSOSection7.acceptBarriers;
						}
						if ((!eRSOSection7.forceSo && (eRSOSection7.so.heightThreshold > num240 || eRSOSection7.so.heightMaxThreshold < num240)) || eRSOSection7.so.maxSlope < num256)
						{
							int num282 = -1;
							int num283 = -1;
							bool flag75 = false;
							for (int num284 = 0; num284 < list22.Count; num284++)
							{
								if (list22[num284].heightThreshold <= num240 && list22[num284].heightMaxThreshold >= num240 && list22[num284].maxSlope > num256)
								{
									num282 = num284;
									eRSOSection7.so = list22[num284];
									eRSOSection7.soid = list22[num284].id;
									eRSOSection7.acceptBarriers = list22[num284].acceptBarriers;
									flag68 = !eRSOSection7.acceptBarriers;
									break;
								}
								if (list22[num284].heightMaxThreshold >= num240 && ((num283 >= 0 && list22[num284].heightMaxThreshold < list22[num283].heightMaxThreshold) || num283 == -1) && list22[num284].maxSlope > num256 && !list22[num284].strictRules)
								{
									num283 = num284;
									flag75 = true;
								}
								else if (list22[num284].heightMaxThreshold >= num240 && ((num283 >= 0 && list22[num284].heightMaxThreshold < list22[num283].heightMaxThreshold) || num283 == -1) && !flag75 && !list22[num284].strictRules)
								{
									num283 = num284;
								}
								else if (list22[num284].maxSlope > num256 && !flag75 && !list22[num284].strictRules)
								{
									num283 = num284;
								}
							}
							if (num282 == -1 && num283 >= 0)
							{
								eRSOSection7.so = list22[num283];
								eRSOSection7.soid = list22[num283].id;
								eRSOSection7.acceptBarriers = list22[num283].acceptBarriers;
								flag68 = !eRSOSection7.acceptBarriers;
							}
							else if (num282 == -1 && eRSOSection7.so != null && eRSOSection7.so.strictRules)
							{
								flag27 = true;
								flag60 = false;
								if (flag59)
								{
									soSectionList7.RemoveAt(num237 - 1);
								}
							}
						}
						if (eRSOSection7.so == null)
						{
							eRSOSection7.so = list22[0];
							eRSOSection7.soid = list22[0].id;
						}
						float num285 = 10f;
						float num286 = 0f;
						if (!bridgeElement[num258])
						{
							flag27 = false;
							for (int num287 = num258; num287 < count20 - 1; num287++)
							{
								num286 += Vector3.Distance(splinePoints[num287], splinePoints[num287 + 1]);
								Vector3 pos13 = rightIndentVecsSV[num287];
								baseScript.OQCCDQOQOO(ref pos13);
								if (rightIndentVecsSV[num287].y - pos13.y > num77)
								{
									flag27 = true;
									break;
								}
								if (num286 > num285)
								{
									break;
								}
							}
						}
						if (!flag27)
						{
							int startSplinePoint3 = eRSOSection7.startSplinePoint;
							float heightMaxStartThreshold3 = eRSOSection7.so.heightMaxStartThreshold;
							float num288 = 0f;
							bool flag76 = false;
							for (int num289 = startSplinePoint3; num289 > 0; num289--)
							{
								Vector3 pos13 = rightIndentVecsSV[num289];
								baseScript.OQCCDQOQOO(ref pos13);
								if (rightIndentVecsSV[num289].y - pos13.y < heightMaxStartThreshold3 || bridgeElement[num289])
								{
									eRSOSection7.startSplinePoint = num289;
									if (bridgeElement[num289])
									{
										ERSOSection eRSOSection8 = eRSOSection7;
										eRSOSection8.startSplinePoint++;
									}
									if (!bridgeElement[num289] || !(Vector3.Distance(splinePoints[num258], splinePoints[num289]) < 10f))
									{
										flag76 = true;
										eRSOSection7.startFraction = 0f;
										break;
									}
									flag60 = false;
								}
							}
							if (!flag76)
							{
								eRSOSection7.startSplinePoint = 0;
								eRSOSection7.startFraction = 0f;
							}
							int num290 = num258 - 1;
							if (!bridgeElement[num258])
							{
								num286 = eRSOSection7.so.heightMaxStartThreshold;
								flag76 = false;
								for (int num291 = num290; num291 < count20; num291++)
								{
									Vector3 pos13 = rightIndentVecsSV[num291];
									baseScript.OQCCDQOQOO(ref pos13);
									if (rightIndentVecsSV[num291].y - pos13.y < heightMaxStartThreshold3)
									{
										eRSOSection7.endSplinePoint = num291;
										flag76 = true;
										eRSOSection7.endFraction = 0f;
										break;
									}
								}
								if (!flag76)
								{
									eRSOSection7.endSplinePoint = count20 - 1;
									eRSOSection7.endFraction = 0f;
								}
							}
							else
							{
								eRSOSection7.endSplinePoint = num258 - 1;
								eRSOSection7.endFraction = 0f;
							}
							float num292 = OQQOCDQCQD.OCCOCQQCCQ(baseScript.activeTerrain, splinePoints[eRSOSection7.startSplinePoint], splinePoints[eRSOSection7.startSplinePoint + 1]);
							startSplinePoint3 = eRSOSection7.startSplinePoint;
							num286 = num292 + 1f;
							num288 = 0f;
							flag76 = false;
							int num293 = 0;
							for (int num294 = startSplinePoint3; num294 > 0; num294--)
							{
								num288 = Vector3.Distance(splinePoints[num294], splinePoints[num294 + 1]);
								float num295 = num286;
								num286 -= num288;
								if (num286 < 0f)
								{
									num293 = eRSOSection7.startSplinePoint - num294;
									eRSOSection7.startSplinePoint = num294 + 1;
									eRSOSection7.startFraction = num295 / num288;
									eRSOSection7.startSplinePoint = num294;
									flag76 = true;
									break;
								}
							}
							if (!flag76)
							{
								num293 = eRSOSection7.startSplinePoint;
								eRSOSection7.startSplinePoint = 0;
								eRSOSection7.startFraction = 0f;
							}
							int num296 = 0;
							if (!bridgeElement[num258])
							{
								num292 = OQQOCDQCQD.OCCOCQQCCQ(baseScript.activeTerrain, splinePoints[eRSOSection7.endSplinePoint], splinePoints[eRSOSection7.endSplinePoint - 1]);
								num290 = eRSOSection7.endSplinePoint;
								num286 = num292 + 1f;
								num288 = 0f;
								flag76 = false;
								for (int num297 = num290; num297 < count20 - 1; num297++)
								{
									num288 = Vector3.Distance(splinePoints[num297], splinePoints[num297 + 1]);
									float num295 = num286;
									num286 -= num288;
									if (num286 < 0f)
									{
										num296 = num297 - eRSOSection7.endSplinePoint;
										eRSOSection7.endFraction = num295 / num288;
										eRSOSection7.endSplinePoint = num297 + 1;
										flag76 = true;
										break;
									}
								}
								if (!flag76)
								{
									num296 = count20 - 1 - eRSOSection7.endSplinePoint;
									eRSOSection7.endSplinePoint = count20 - 1;
									eRSOSection7.endFraction = 0f;
								}
							}
							if (!flag59)
							{
								if (num237 < soSectionList7.Count)
								{
									soSectionList7.Insert(num237, eRSOSection7);
								}
								else
								{
									soSectionList7.Add(eRSOSection7);
								}
								num237++;
							}
							else
							{
								soSectionList7[num237 - 1] = eRSOSection7;
							}
							flag59 = false;
							if (eRSOSection7.active)
							{
								float num298 = 0f;
								for (int num299 = eRSOSection7.startSplinePoint + num293; num299 < eRSOSection7.endSplinePoint - num296; num299++)
								{
									int num300 = 1;
									if (startPrefabScript != null)
									{
										num300 = -1;
									}
									if (num299 > num300 && num299 < count20 - 2)
									{
										Vector3 pos13 = rightIndentVecsSV[num299];
										pos13 = soSplinePointsRight[num299];
										num298 = pos13.y;
										baseScript.OQCCDQOQOO(ref pos13);
										if (num298 > pos13.y)
										{
											surfaceVecs[num299 * 5 + 3] = pos13;
											doRightSurrounding[num299] = false;
											List<Vector3> list59 = rightIndentVecsSV;
											int index4 = num299;
											Vector3 value = (rightSurroundingVecs[num299] = pos13);
											list59[index4] = value;
										}
									}
								}
							}
							if (flag68)
							{
								num252 = eRSOSection7.endSplinePoint + 1;
								if (num234 > 0)
								{
									ERSOSection target2 = soSectionList4[num234 - 1];
									soSectionList4[num234 - 1] = ERSOSection.OQQCDOOODQ(target2, eRSOSection7);
								}
							}
							else
							{
								num252 = 0;
							}
							eRSOSection7 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
							num240 = -100000f;
							num241 = 100000f;
							num243 = 0f;
							flag60 = (flag68 = false);
							num256 = 0f;
						}
					}
				}
				if (!flag23 && list20.Count > 0)
				{
					if (bendAngles.Count > num258 && (bendAngles[num258] >= num72 || leftIndentVecsSV[num258].y - zero8.y > num74) && !flag64 && !flag67 && num258 >= num251)
					{
						num257 = num258 + 1;
						if (num257 >= count20)
						{
							num257 = count20 - 1;
						}
						if ((bendAngles.Count <= num258 + 1 || !(bendAngles[num258] >= num72) || !(bendAngles[num258 + 1] < num72) || !(distances[num258 + 1] - distances[num258] < 10f)) && (OQQOCDQCQD.OOCQODQDQD(splinePoints[num258], splinePoints[num258 - 1], splinePoints[num257]) || leftIndentVecsSV[num258].y - zero8.y > num74))
						{
							bool flag77 = false;
							flag53 = true;
							if (num233 > 0 && soSectionList3[num233 - 1].endSplinePoint >= num258 - 2)
							{
								flag51 = true;
								eRSOSection2 = soSectionList3[num233 - 1];
								flag23 = true;
								flag77 = true;
								flag53 = false;
							}
							if (!flag77)
							{
								while (soSectionList3.Count > num233)
								{
									if (Vector3.Distance(soSectionList3[num233].startSplinePointOrig, splinePoints[num258]) < 10f)
									{
										eRSOSection2 = soSectionList3[num233];
										num233++;
										flag51 = true;
										break;
									}
									if (Mathf.Abs(soSectionList3[num233].startDistance - distances[num258]) < 10f)
									{
										eRSOSection2 = soSectionList3[num233];
										num233++;
										flag51 = true;
										break;
									}
									if (soSectionList3[num233].startDistance < distances[num258])
									{
										soSectionList3.RemoveAt(num233);
										continue;
									}
									break;
								}
								eRSOSection2.startSplinePoint = num258;
								eRSOSection2.startSplinePointOrig = splinePoints[num258];
								flag23 = true;
								eRSOSection2.roadSide = ERRoadSide.Left;
							}
						}
					}
				}
				else if (flag23)
				{
					float num301 = 1f;
					if (num72 >= 15f)
					{
						num301 = ((!(num72 < 25f)) ? 3f : 2f);
					}
					if ((bendAngles[num258] < num72 - num301 && leftIndentVecsSV[num258].y - zero8.y < num74) || flag64 || flag67)
					{
						flag27 = true;
						if (flag64 && Vector3.Distance(splinePoints[eRSOSection2.startSplinePoint], splinePoints[num258]) < 1000f)
						{
							flag23 = false;
							if (flag51)
							{
								num233--;
							}
							flag27 = false;
						}
						else
						{
							bool flag78 = OCQODDCQDD.OQQDQDQCDO(list20, eRSOSection2.so);
							if (!flag51 || eRSOSection2.soid == 0.0 || !flag78)
							{
								eRSOSection2.so = list20[0];
								eRSOSection2.soid = list20[0].id;
							}
						}
						if (eRSOSection2.so == null)
						{
							eRSOSection2.so = list20[0];
							eRSOSection2.soid = list20[0].id;
						}
						float num302 = 10f + 2f * eRSOSection2.so.heightMaxStartThreshold;
						float num303 = 0f;
						if (!flag64 && flag27)
						{
							num303 = 0f;
							flag27 = false;
							for (int num304 = num258; num304 < count20 - 1; num304++)
							{
								num303 += Vector3.Distance(splinePoints[num304], splinePoints[num304 + 1]);
								if (bendAngles[num304] >= num72 - num301)
								{
									if (OQQOCDQCQD.OOCQODQDQD(splinePoints[num304], splinePoints[num304 - 1], splinePoints[num304 + 1]))
									{
										if (eRSOSection2.roadSide == ERRoadSide.Left)
										{
											flag27 = true;
											break;
										}
									}
									else if (eRSOSection2.roadSide == ERRoadSide.Right)
									{
										flag27 = true;
										break;
									}
								}
								if (num303 > num302)
								{
									break;
								}
							}
						}
						if (!flag27)
						{
							int startSplinePoint4 = eRSOSection2.startSplinePoint;
							num303 = eRSOSection2.so.heightMaxStartThreshold;
							float num305 = 0f;
							bool flag79 = false;
							float num306 = Vector3.Distance(splinePoints[startSplinePoint4], splinePoints[num258]);
							if (num306 < 3f * eRSOSection2.so.middleZDistance)
							{
								num306 = 3f * eRSOSection2.so.middleZDistance;
								if (num303 < num306)
								{
									num303 = num306;
								}
							}
							if (!flag65 && flag53 && (num303 != 0f || bendAngles[startSplinePoint4 - 1] >= num72 - num301) && eRSOSection2.startSplinePoint > num251)
							{
								for (int num307 = startSplinePoint4; num307 > 0; num307--)
								{
									num305 = Vector3.Distance(splinePoints[num307], splinePoints[num307 + 1]);
									float num308 = num303;
									num303 -= num305;
									if ((num303 < 0f && bendAngles[num307] < num72 - num301) || num307 < num248)
									{
										eRSOSection2.startSplinePoint = num307 + 1;
										eRSOSection2.startFraction = num308 / num305;
										eRSOSection2.startSplinePoint = num307;
										flag79 = true;
										break;
									}
								}
								if (!flag79)
								{
									eRSOSection2.startSplinePoint = 0;
									eRSOSection2.startFraction = 0f;
								}
							}
							else if (flag65)
							{
								eRSOSection4.startFraction = 0f;
								ERSOSection eRSOSection8 = eRSOSection4;
								eRSOSection8.startSplinePoint++;
							}
							int num309 = num258 - 1;
							num303 = eRSOSection2.so.heightMaxStartThreshold;
							if (flag64)
							{
								num303 = 0f;
							}
							num305 = 0f;
							flag79 = false;
							if (num303 != 0f)
							{
								for (int num310 = num309; num310 < count20 - 1; num310++)
								{
									num305 = Vector3.Distance(splinePoints[num310], splinePoints[num310 + 1]);
									float num308 = num303;
									num303 -= num305;
									if (num303 < 0f)
									{
										eRSOSection2.endFraction = num308 / num305;
										eRSOSection2.endSplinePoint = num310 + 1;
										flag79 = true;
										break;
									}
								}
								if (!flag79)
								{
									eRSOSection2.endSplinePoint = count20 - 1;
									eRSOSection2.endFraction = 0f;
								}
							}
							else
							{
								eRSOSection2.endSplinePoint = num258;
								eRSOSection2.endFraction = 0f;
							}
							if (!flag51)
							{
								if (num233 < soSectionList3.Count)
								{
									soSectionList3.Insert(num233, eRSOSection2);
								}
								else
								{
									soSectionList3.Add(eRSOSection2);
								}
								num233++;
							}
							else if (num233 == 0)
							{
								soSectionList3[0] = eRSOSection2;
							}
							else
							{
								soSectionList3[num233 - 1] = eRSOSection2;
							}
							flag51 = false;
							eRSOSection2 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
							flag23 = false;
						}
					}
				}
				if (!flag24 && list20.Count > 0)
				{
					if (bendAngles.Count > num258 && (bendAngles[num258] > num72 || rightIndentVecsSV[num258].y - zero9.y > num74) && !flag64 && !flag68 && num258 >= num252)
					{
						num257 = num258 + 1;
						if (num257 >= count20)
						{
							num257 = count20 - 1;
						}
						if ((bendAngles.Count <= num258 + 1 || !(bendAngles[num258] >= num72) || !(bendAngles[num258 + 1] < num72) || !(distances[num258 + 1] - distances[num258] < 10f)) && (!OQQOCDQCQD.OOCQODQDQD(splinePoints[num258], splinePoints[num258 - 1], splinePoints[num257]) || rightIndentVecsSV[num258].y - zero9.y > num74))
						{
							bool flag80 = false;
							flag54 = true;
							if (num234 > 0 && soSectionList4[num234 - 1].endSplinePoint >= num258 - 2)
							{
								flag52 = true;
								eRSOSection4 = soSectionList4[num234 - 1];
								flag24 = true;
								flag80 = true;
								flag54 = false;
							}
							if (!flag80)
							{
								while (soSectionList4.Count > num234)
								{
									if (Vector3.Distance(soSectionList4[num234].startSplinePointOrig, splinePoints[num258]) < 10f)
									{
										eRSOSection4 = soSectionList4[num234];
										num234++;
										flag52 = true;
										break;
									}
									if (Mathf.Abs(soSectionList4[num234].startDistance - distances[num258]) < 10f)
									{
										eRSOSection4 = soSectionList4[num234];
										num234++;
										flag52 = true;
										break;
									}
									if (soSectionList4[num234].startDistance < distances[num258])
									{
										soSectionList4.RemoveAt(num234);
										continue;
									}
									break;
								}
								eRSOSection4.startSplinePoint = num258;
								eRSOSection4.startSplinePointOrig = splinePoints[num258];
								flag24 = true;
								eRSOSection4.roadSide = ERRoadSide.Right;
							}
						}
					}
				}
				else if (flag24)
				{
					float num311 = 1f;
					if (num72 >= 15f)
					{
						num311 = ((!(num72 < 25f)) ? 3f : 2f);
					}
					if ((bendAngles[num258] < num72 - num311 && rightIndentVecsSV[num258].y - zero9.y < num74) || flag64 || flag68)
					{
						flag27 = true;
						if (flag64 && Vector3.Distance(splinePoints[eRSOSection4.startSplinePoint], splinePoints[num258]) < 1000f)
						{
							flag24 = false;
							if (flag52)
							{
								num234--;
							}
							flag27 = false;
						}
						else
						{
							bool flag81 = OCQODDCQDD.OQQDQDQCDO(list20, eRSOSection4.so);
							if (!flag52 || eRSOSection4.soid == 0.0 || !flag81)
							{
								eRSOSection4.so = list20[0];
								eRSOSection4.soid = list20[0].id;
							}
						}
						if (eRSOSection4.so == null)
						{
							eRSOSection4.so = list20[0];
							eRSOSection4.soid = list20[0].id;
						}
						float num312 = 10f + 2f * eRSOSection4.so.heightMaxStartThreshold;
						float num313 = 0f;
						if (!flag64 && flag27)
						{
							flag27 = false;
							for (int num314 = num258; num314 < count20 - 1; num314++)
							{
								num313 += Vector3.Distance(splinePoints[num314], splinePoints[num314 + 1]);
								if (bendAngles[num314] > num72 - num311)
								{
									if (OQQOCDQCQD.OOCQODQDQD(splinePoints[num314], splinePoints[num314 - 1], splinePoints[num314 + 1]))
									{
										if (eRSOSection4.roadSide == ERRoadSide.Left)
										{
											flag27 = true;
											break;
										}
									}
									else if (eRSOSection4.roadSide == ERRoadSide.Right)
									{
										flag27 = true;
										break;
									}
								}
								if (num313 > num312)
								{
									break;
								}
							}
						}
						if (!flag27)
						{
							int startSplinePoint5 = eRSOSection4.startSplinePoint;
							num313 = eRSOSection4.so.heightMaxStartThreshold;
							float num315 = 0f;
							bool flag82 = false;
							float num316 = Vector3.Distance(splinePoints[startSplinePoint5], splinePoints[num258]);
							if (num316 < 3f * eRSOSection4.so.middleZDistance)
							{
								num316 = 3f * eRSOSection4.so.middleZDistance;
								if (num313 < num316)
								{
									num313 = num316;
								}
							}
							if (!flag65 && flag54 && (num313 != 0f || bendAngles[startSplinePoint5 - 1] >= num72 - num311) && eRSOSection4.startSplinePoint > num252)
							{
								for (int num317 = startSplinePoint5; num317 > 0; num317--)
								{
									num315 = Vector3.Distance(splinePoints[num317], splinePoints[num317 + 1]);
									float num318 = num313;
									num313 -= num315;
									if ((num313 < 0f && bendAngles[num317] < num72 - num311) || num317 < num248)
									{
										eRSOSection4.startSplinePoint = num317 + 1;
										eRSOSection4.startFraction = num318 / num315;
										eRSOSection4.startSplinePoint = num317;
										flag82 = true;
										break;
									}
								}
								if (!flag82)
								{
									eRSOSection4.startSplinePoint = 0;
									eRSOSection4.startFraction = 0f;
								}
							}
							else if (flag65)
							{
								eRSOSection4.startFraction = 0f;
								ERSOSection eRSOSection8 = eRSOSection4;
								eRSOSection8.startSplinePoint++;
							}
							int num319 = num258 - 1;
							num313 = eRSOSection4.so.heightMaxStartThreshold;
							if (flag64)
							{
								num313 = 0f;
							}
							num315 = 0f;
							flag82 = false;
							if (num313 != 0f)
							{
								for (int num320 = num319; num320 < count20 - 1; num320++)
								{
									num315 = Vector3.Distance(splinePoints[num320], splinePoints[num320 + 1]);
									float num318 = num313;
									num313 -= num315;
									if (num313 < 0f)
									{
										eRSOSection4.endFraction = num318 / num315;
										eRSOSection4.endSplinePoint = num320 + 1;
										flag82 = true;
										break;
									}
								}
								if (!flag82)
								{
									eRSOSection4.endSplinePoint = count20 - 1;
									eRSOSection4.endFraction = 0f;
								}
							}
							else
							{
								eRSOSection4.endSplinePoint = num258;
								eRSOSection4.endFraction = 0f;
							}
							if (flag64)
							{
							}
							if (!flag52)
							{
								if (num234 < soSectionList4.Count)
								{
									soSectionList4.Insert(num234, eRSOSection4);
								}
								else
								{
									soSectionList4.Add(eRSOSection4);
								}
								num234++;
							}
							else if (num234 == 0)
							{
								soSectionList4[0] = eRSOSection4;
							}
							else
							{
								soSectionList4[num234 - 1] = eRSOSection4;
							}
							flag52 = false;
							eRSOSection4 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
							flag24 = false;
						}
					}
				}
				if (!flag56 && list21.Count > 0)
				{
					if (bendAngles.Count <= num258 || !(bendAngles[num258] > num73) || bridgeElement[num258] || num258 >= num254)
					{
						continue;
					}
					while (soSectionList5.Count > num235)
					{
						if (Vector3.Distance(soSectionList5[num235].startSplinePointOrig, splinePoints[num258]) < 10f)
						{
							eRSOSection5 = soSectionList5[num235];
							num235++;
							flag55 = true;
							break;
						}
						if (Mathf.Abs(soSectionList5[num235].startDistance - distances[num258]) < 10f)
						{
							eRSOSection5 = soSectionList5[num235];
							num235++;
							flag55 = true;
							break;
						}
						if (soSectionList5[num235].startDistance < distances[num258])
						{
							soSectionList5.RemoveAt(num235);
							continue;
						}
						break;
					}
					eRSOSection5.startSplinePoint = num258;
					eRSOSection5.startSplinePointOrig = splinePoints[num258];
					if (!flag55)
					{
						eRSOSection5.so = list21[0];
						eRSOSection5.soid = list21[0].id;
					}
					if (OQQOCDQCQD.OOCQODQDQD(splinePoints[num258], splinePoints[num258 - 1], splinePoints[num258 + 1]))
					{
						if (flag67)
						{
							continue;
						}
						if (flag58 && eRSOSection5.so.activeOnBridges && !eRSOSection5.forceSo)
						{
							foreach (SideObject item7 in list21)
							{
								if (!item7.activeOnBridges)
								{
									eRSOSection5.so = item7;
									eRSOSection5.soid = item7.id;
								}
							}
						}
						flag56 = true;
						eRSOSection5.roadSide = ERRoadSide.Left;
						if (flag58 && eRSOSection5.so.activeOnBridges)
						{
							eRSOSection5.active = false;
						}
					}
					else
					{
						if (flag68)
						{
							continue;
						}
						if (flag60 && eRSOSection5.so.activeOnBridges && !eRSOSection5.forceSo)
						{
							foreach (SideObject item8 in list21)
							{
								if (!item8.activeOnBridges)
								{
									eRSOSection5.so = item8;
									eRSOSection5.soid = item8.id;
								}
							}
						}
						flag56 = true;
						eRSOSection5.roadSide = ERRoadSide.Right;
						if (flag60 && eRSOSection5.so.activeOnBridges)
						{
							eRSOSection5.active = false;
						}
					}
				}
				else
				{
					if (!flag56 || (!(bendAngles[num258] < num73) && (!flag68 || eRSOSection5.roadSide != ERRoadSide.Right) && (!flag67 || eRSOSection5.roadSide != ERRoadSide.Left)))
					{
						continue;
					}
					bool flag83 = OCQODDCQDD.OQQDQDQCDO(list21, eRSOSection5.so);
					if (!flag55 || eRSOSection5.soid == 0.0 || !flag83)
					{
						eRSOSection5.so = list21[0];
						eRSOSection5.soid = list21[0].id;
					}
					float num321 = 10f + 2f * eRSOSection5.so.heightMaxStartThreshold;
					float num322 = 0f;
					flag27 = false;
					for (int num323 = num258; num323 < count20 - 1; num323++)
					{
						num322 += Vector3.Distance(splinePoints[num323], splinePoints[num323 + 1]);
						if (bendAngles[num323] > num73)
						{
							if (OQQOCDQCQD.OOCQODQDQD(splinePoints[num323], splinePoints[num323 - 1], splinePoints[num323 + 1]))
							{
								if (eRSOSection5.roadSide == ERRoadSide.Left)
								{
									flag27 = true;
									break;
								}
							}
							else if (eRSOSection5.roadSide == ERRoadSide.Right)
							{
								flag27 = true;
								break;
							}
						}
						if (num322 > num321)
						{
							break;
						}
					}
					if (flag27)
					{
						continue;
					}
					int startSplinePoint6 = eRSOSection5.startSplinePoint;
					num322 = eRSOSection5.so.heightMaxStartThreshold;
					float num324 = 0f;
					bool flag84 = false;
					if (num322 != 0f)
					{
						for (int num325 = startSplinePoint6; num325 > 0; num325--)
						{
							num324 = Vector3.Distance(splinePoints[num325], splinePoints[num325 + 1]);
							float num326 = num322;
							num322 -= num324;
							if (num322 < 0f)
							{
								eRSOSection5.startSplinePoint = num325 + 1;
								eRSOSection5.startFraction = num326 / num324;
								eRSOSection5.startSplinePoint = num325;
								flag84 = true;
								break;
							}
						}
						if (!flag84)
						{
							eRSOSection5.startSplinePoint = 0;
							eRSOSection5.startFraction = 0f;
						}
					}
					int num327 = num258 - 1;
					num322 = eRSOSection5.so.heightMaxStartThreshold;
					num324 = 0f;
					flag84 = false;
					if (num322 != 0f)
					{
						for (int num328 = num327; num328 < count20 - 1; num328++)
						{
							num324 = Vector3.Distance(splinePoints[num328], splinePoints[num328 + 1]);
							float num326 = num322;
							num322 -= num324;
							if (num322 < 0f)
							{
								eRSOSection5.endFraction = num326 / num324;
								eRSOSection5.endSplinePoint = num328 + 1;
								flag84 = true;
								break;
							}
						}
						if (!flag84)
						{
							eRSOSection5.endSplinePoint = count20 - 1;
							eRSOSection5.endFraction = 0f;
						}
					}
					else
					{
						eRSOSection5.endSplinePoint = num258;
						eRSOSection5.endFraction = 0f;
					}
					if (eRSOSection5.endSplinePoint >= count20)
					{
						eRSOSection5.endSplinePoint = count20 - 1;
					}
					if (!flag55)
					{
						if (num235 < soSectionList5.Count)
						{
							soSectionList5.Insert(num235, eRSOSection5);
						}
						else
						{
							soSectionList5.Add(eRSOSection5);
						}
						num235++;
					}
					else
					{
						soSectionList5[num235 - 1] = eRSOSection5;
					}
					flag55 = false;
					eRSOSection5 = new ERSOSection(Vector3.zero, Vector3.zero, -1, -1, 0f, 0f, 0f, 0f);
					flag56 = false;
				}
			}
			if (flag63)
			{
				surfaceMesh.SetActive(value: true);
			}
			if (flag23)
			{
				eRSOSection2.endSplinePoint = count20 - 1;
				eRSOSection2.endFraction = 0f;
				if (Vector3.Distance(splinePoints[eRSOSection2.startSplinePoint], splinePoints[eRSOSection2.endSplinePoint]) > 5f)
				{
					if (!flag29)
					{
						eRSOSection2.so = list20[0];
						eRSOSection2.soid = list20[0].id;
						soSectionList3.Add(eRSOSection2);
						num80++;
					}
					if (eRSOSection2.so == null)
					{
						eRSOSection2.so = list20[0];
						eRSOSection2.soid = list20[0].id;
					}
					eRSOSection2.soid = eRSOSection2.so.id;
					if (num80 >= soSectionList3.Count)
					{
						num80 = soSectionList3.Count - 1;
					}
					soSectionList3[num80] = eRSOSection2;
					if (num80 == 0)
					{
						num80++;
					}
				}
				else
				{
					num80--;
				}
			}
			if (flag24)
			{
				eRSOSection4.endSplinePoint = count20 - 1;
				eRSOSection4.endFraction = 0f;
				if (Vector3.Distance(splinePoints[eRSOSection4.startSplinePoint], splinePoints[eRSOSection4.endSplinePoint]) > 5f)
				{
					if (!flag52)
					{
						eRSOSection4.so = list20[0];
						eRSOSection4.soid = list20[0].id;
						soSectionList4.Add(eRSOSection4);
						num234++;
					}
					else
					{
						if (eRSOSection4.so == null)
						{
							eRSOSection4.so = list20[0];
							eRSOSection4.soid = list20[0].id;
						}
						eRSOSection4.soid = eRSOSection4.so.id;
						if (num234 >= soSectionList4.Count)
						{
							num234 = soSectionList4.Count - 1;
						}
						soSectionList4[num234] = eRSOSection4;
						if (num234 == 0)
						{
							num234++;
						}
					}
				}
				else
				{
					num234--;
				}
			}
			if (flag56)
			{
				eRSOSection5.endSplinePoint = count20 - 1;
				eRSOSection5.endFraction = 0f;
				if (Vector3.Distance(splinePoints[eRSOSection5.startSplinePoint], splinePoints[eRSOSection5.endSplinePoint]) > 5f)
				{
					if (!flag55)
					{
						eRSOSection5.so = list21[0];
						eRSOSection5.soid = list21[0].id;
						soSectionList5.Add(eRSOSection5);
						num235++;
					}
					else
					{
						if (eRSOSection5.so == null)
						{
							eRSOSection5.so = list21[0];
							eRSOSection5.soid = list21[0].id;
						}
						eRSOSection5.soid = eRSOSection5.so.id;
						if (num235 >= soSectionList5.Count)
						{
							num235 = soSectionList5.Count - 1;
						}
						soSectionList5[num235] = eRSOSection5;
						if (num235 == 0)
						{
							num235++;
						}
					}
				}
				else
				{
					num235--;
				}
			}
			if (flag58)
			{
				eRSOSection6.endSplinePoint = count20 - 1;
				eRSOSection6.endFraction = 0f;
				if (Vector3.Distance(splinePoints[eRSOSection6.startSplinePoint], splinePoints[eRSOSection6.endSplinePoint]) > 5f)
				{
					if (!flag57)
					{
						eRSOSection6.so = list22[0];
						eRSOSection6.soid = list22[0].id;
						soSectionList6.Add(eRSOSection6);
						num236++;
					}
					else
					{
						if (eRSOSection6.so == null)
						{
							eRSOSection6.so = list22[0];
							eRSOSection6.soid = list22[0].id;
						}
						eRSOSection6.soid = eRSOSection6.so.id;
						if (num236 >= soSectionList6.Count)
						{
							num236 = soSectionList6.Count - 1;
						}
						soSectionList6[num236] = eRSOSection6;
						if (num236 == 0)
						{
							num236++;
						}
					}
					for (int startSplinePoint7 = eRSOSection6.startSplinePoint; startSplinePoint7 <= eRSOSection6.endSplinePoint; startSplinePoint7++)
					{
						Vector3 vector35 = leftIndentVecsSV[startSplinePoint7];
						vector35 = soSplinePointsLeft[startSplinePoint7];
						baseScript.OQCCDQOQOO(ref vector35);
						doLeftSurrounding[startSplinePoint7] = false;
						surfaceVecs[startSplinePoint7 * 5 + 1] = vector35;
						List<Vector3> list60 = leftIndentVecsSV;
						int index5 = startSplinePoint7;
						Vector3 value = (leftSurroundingVecs[startSplinePoint7] = vector35);
						list60[index5] = value;
					}
				}
				else
				{
					num236--;
				}
			}
			if (flag60)
			{
				eRSOSection7.endSplinePoint = count20 - 1;
				eRSOSection7.endFraction = 0f;
				if (Vector3.Distance(splinePoints[eRSOSection7.startSplinePoint], splinePoints[eRSOSection7.endSplinePoint]) > 5f)
				{
					if (!flag59 || soSectionList7.Count == 0)
					{
						eRSOSection7.so = list22[0];
						eRSOSection7.soid = list22[0].id;
						soSectionList7.Add(eRSOSection7);
						num237++;
					}
					else
					{
						if (eRSOSection7.so == null)
						{
							eRSOSection7.so = list22[0];
							eRSOSection7.soid = list22[0].id;
						}
						eRSOSection7.soid = eRSOSection7.so.id;
						if (num237 >= soSectionList7.Count)
						{
							num237 = soSectionList7.Count - 1;
						}
						soSectionList7[num237] = eRSOSection7;
						if (num237 == 0)
						{
							num237++;
						}
					}
					for (int startSplinePoint8 = eRSOSection7.startSplinePoint; startSplinePoint8 <= eRSOSection7.endSplinePoint; startSplinePoint8++)
					{
						Vector3 vector37 = rightIndentVecsSV[startSplinePoint8];
						vector37 = soSplinePointsRight[startSplinePoint8];
						baseScript.OQCCDQOQOO(ref vector37);
						doRightSurrounding[startSplinePoint8] = false;
						surfaceVecs[startSplinePoint8 * 5 + 3] = vector37;
						List<Vector3> list61 = rightIndentVecsSV;
						int index6 = startSplinePoint8;
						Vector3 value = (rightSurroundingVecs[startSplinePoint8] = vector37);
						list61[index6] = value;
					}
				}
				else
				{
					num237--;
				}
			}
			if (num233 < 0)
			{
				num233 = 0;
			}
			for (int num329 = num233; num329 < soSectionList3.Count; num329++)
			{
				soSectionList3.RemoveAt(num329);
				num329--;
			}
			if (num234 < 0)
			{
				num234 = 0;
			}
			for (int num330 = num234; num330 < soSectionList4.Count; num330++)
			{
				soSectionList4.RemoveAt(num330);
				num330--;
			}
			if (num235 < 0)
			{
				num235 = 0;
			}
			for (int num331 = num235; num331 < soSectionList5.Count; num331++)
			{
				soSectionList5.RemoveAt(num331);
				num331--;
			}
			if (num236 < 0)
			{
				num236 = 0;
			}
			for (int num332 = num236; num332 < soSectionList6.Count; num332++)
			{
				soSectionList6.RemoveAt(num332);
				num332--;
			}
			if (num237 < 0)
			{
				num237 = 0;
			}
			for (int num333 = num237; num333 < soSectionList7.Count; num333++)
			{
				soSectionList7.RemoveAt(num333);
				num333--;
			}
			for (int num334 = 0; num334 < soSectionList1.Count; num334++)
			{
				int startSplinePoint9 = soSectionList1[num334].startSplinePoint;
				if (startSplinePoint9 > 0)
				{
					surfaceVecs[startSplinePoint9 * 5] = Vector3.Lerp(leftSurroundingVecs[startSplinePoint9 - 1], leftSurroundingVecs[startSplinePoint9], soSectionList1[num334].startFraction);
					surfaceVecs[startSplinePoint9 * 5 + 1] = Vector3.Lerp(leftIndentVecs[startSplinePoint9 - 1], leftIndentVecs[startSplinePoint9], soSectionList1[num334].startFraction);
					surfaceVecs[startSplinePoint9 * 5 + 2] = Vector3.Lerp(soSplinePoints[startSplinePoint9 - 1], soSplinePoints[startSplinePoint9], soSectionList1[num334].startFraction);
					surfaceVecs[startSplinePoint9 * 5 + 3] = Vector3.Lerp(rightIndentVecs[startSplinePoint9 - 1], rightIndentVecs[startSplinePoint9], soSectionList1[num334].startFraction);
					surfaceVecs[startSplinePoint9 * 5 + 4] = Vector3.Lerp(rightSurroundingVecs[startSplinePoint9 - 1], rightSurroundingVecs[startSplinePoint9], soSectionList1[num334].startFraction);
				}
				else
				{
					surfaceVecs[startSplinePoint9 * 5] = leftSurroundingVecs[0];
					surfaceVecs[startSplinePoint9 * 5 + 1] = leftIndentVecs[0];
					surfaceVecs[startSplinePoint9 * 5 + 2] = soSplinePoints[0];
					surfaceVecs[startSplinePoint9 * 5 + 3] = rightIndentVecs[0];
					surfaceVecs[startSplinePoint9 * 5 + 4] = rightSurroundingVecs[0];
				}
				List<Vector3> list62 = surfaceVecs;
				int index7 = startSplinePoint9 * 5;
				Vector3 value = (leftSurroundingVecs[startSplinePoint9] = surfaceVecs[startSplinePoint9 * 5 + 1]);
				list62[index7] = value;
				List<Vector3> list63 = surfaceVecs;
				int index8 = startSplinePoint9 * 5 + 4;
				value = (rightSurroundingVecs[startSplinePoint9] = surfaceVecs[startSplinePoint9 * 5 + 3]);
				list63[index8] = value;
				startSplinePoint9 = soSectionList1[num334].endSplinePoint;
				if (startSplinePoint9 < soSplinePoints.Count - 1)
				{
					surfaceVecs[startSplinePoint9 * 5] = Vector3.Lerp(leftSurroundingVecs[startSplinePoint9], leftSurroundingVecs[startSplinePoint9 + 1], soSectionList1[num334].endFraction);
					surfaceVecs[startSplinePoint9 * 5 + 1] = Vector3.Lerp(leftIndentVecs[startSplinePoint9], leftIndentVecs[startSplinePoint9 + 1], soSectionList1[num334].endFraction);
					surfaceVecs[startSplinePoint9 * 5 + 2] = Vector3.Lerp(soSplinePoints[startSplinePoint9], soSplinePoints[startSplinePoint9 + 1], soSectionList1[num334].endFraction);
					surfaceVecs[startSplinePoint9 * 5 + 3] = Vector3.Lerp(rightIndentVecs[startSplinePoint9], rightIndentVecs[startSplinePoint9 + 1], soSectionList1[num334].endFraction);
					surfaceVecs[startSplinePoint9 * 5 + 4] = Vector3.Lerp(rightSurroundingVecs[startSplinePoint9], rightSurroundingVecs[startSplinePoint9 + 1], soSectionList1[num334].endFraction);
				}
				else
				{
					startSplinePoint9 = soSplinePoints.Count - 1;
					surfaceVecs[startSplinePoint9 * 5] = leftSurroundingVecs[startSplinePoint9];
					surfaceVecs[startSplinePoint9 * 5 + 1] = leftIndentVecs[startSplinePoint9];
					surfaceVecs[startSplinePoint9 * 5 + 2] = soSplinePoints[startSplinePoint9];
					surfaceVecs[startSplinePoint9 * 5 + 3] = rightIndentVecs[startSplinePoint9];
					surfaceVecs[startSplinePoint9 * 5 + 4] = rightSurroundingVecs[startSplinePoint9];
				}
				List<Vector3> list64 = surfaceVecs;
				int index9 = startSplinePoint9 * 5;
				value = (leftSurroundingVecs[startSplinePoint9] = surfaceVecs[startSplinePoint9 * 5 + 1]);
				list64[index9] = value;
				List<Vector3> list65 = surfaceVecs;
				int index10 = startSplinePoint9 * 5 + 4;
				value = (rightSurroundingVecs[startSplinePoint9] = surfaceVecs[startSplinePoint9 * 5 + 3]);
				list65[index10] = value;
			}
			num35 = 0f;
			if ((bool)endPrefabScript && !flag11)
			{
				for (int num335 = 0; (!surfacesSafe || num335 < surfaceVecs.Count - 5) && surfaceVecs.Count - num335 - 6 >= 0; num335 += 5)
				{
					if (!surfacesSafe && terrainDeformation && endPrefabScript.doTerrainDeformation)
					{
						OQOCQDQODD.OQODQQCQDO(this, ref surfaceVecs, endPrefabScript, num335, ref surfacesSafe, num35, baseScript.minIndent, flag58, flag60);
					}
					num35 += Vector3.Distance(surfaceVecs[surfaceVecs.Count - 2 - num335], surfaceVecs[surfaceVecs.Count - 2 - num335 - 5]);
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
					if (Application.isEditor && !Application.isPlaying)
					{
						UnityEngine.Object.DestroyImmediate(endDecalPrefab);
					}
					else
					{
						UnityEngine.Object.Destroy(endDecalPrefab);
					}
				}
			}
			else
			{
				if (endDecalPrefab == null && endDecalID != -1)
				{
					QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType);
					if (roadTypeElByID != null)
					{
						endDecal = ERDecal.OOCQOOODDC(endDecalID, roadTypeElByID.decalPresets);
						if (endDecal != null && endDecal.decalPrefab != null)
						{
							OCODODODOC(endDecal, ref endDecalPrefab, "_ERDecal_End");
						}
					}
				}
				if (endDecalPrefab != null)
				{
					OODCQDCOOQ(1);
					OOCDOOOOQO(endDecalPrefab, soSplinePoints.Count - 1);
				}
			}
			if (startDecalPrefab == null && startDecalID != -1)
			{
				QDQDOOQQDQODD roadTypeElByID2 = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType);
				if (roadTypeElByID2 != null)
				{
					startDecal = ERDecal.OOCQOOODDC(startDecalID, roadTypeElByID2.decalPresets);
					if (startDecal != null && startDecal.decalPrefab != null)
					{
						OCODODODOC(startDecal, ref startDecalPrefab, "_ERDecal_Start");
					}
				}
			}
			if (startDecalPrefab != null)
			{
				OODCQDCOOQ(0);
				OOCDOOOOQO(startDecalPrefab, 0);
			}
			if (markersExt.Count > 2)
			{
				doSurroundingSurfaces = true;
			}
			if (doSurroundingSurfaces)
			{
				ODQQOOQDOC(surfaceVecs, list, splinePoints.Count, list2, firstDir, vector5, indent, surrounding, list31);
			}
			insertSplinePoints.Clear();
			insertSplinePoints.AddRange(splinePoints);
			for (int num336 = 0; num336 < markersExt.Count; num336++)
			{
				if (markersExt[num336].controlTypeTmp == 3)
				{
					markersExt[num336].controlType = 3;
					markersExt[num336].controlTypeTmp = 0;
				}
			}
			if (lastForward == Vector3.zero)
			{
				lastForward = (soSplinePoints[soSplinePoints.Count - 1] - soSplinePoints[soSplinePoints.Count - 2]).normalized;
			}
			if (startPrefabScript != null)
			{
				Vector3 value2 = leftSurroundingVecs[0];
				leftSurroundingVecs[0] = rightSurroundingVecs[0];
				rightSurroundingVecs[0] = value2;
			}
			foreach (ERSideWalkInstance leftSidewalk2 in leftSidewalks)
			{
				if (leftSidewalk2 != null && leftSidewalk2.swObject != null)
				{
					UnityEngine.Object.DestroyImmediate(leftSidewalk2.swObject);
				}
			}
			foreach (ERSideWalkInstance rightSidewalk2 in rightSidewalks)
			{
				if (rightSidewalk2 != null && rightSidewalk2.swObject != null)
				{
					UnityEngine.Object.DestroyImmediate(rightSidewalk2.swObject);
				}
			}
			OQDOQQDCCD(roadShapeValues);
			List<Vector3> list66 = new List<Vector3>();
			List<Vector3> list67 = new List<Vector3>();
			List<Vector3> list68 = new List<Vector3>();
			bool flag85 = false;
			int num337 = 0;
			int num338 = markersExt.Count - 1;
			if (startPrefabScript != null && startPrefabScript.isIConnector)
			{
				ERIConnector component = startPrefabScript.GetComponent<ERIConnector>();
				if (component != null)
				{
					if (startPrefabScript.crossingElements[0].connectedRoad == this && component.roadWidth1 > component.roadWidth2)
					{
						list66 = new List<Vector3>(component.roadSplinePoints2);
						list67 = new List<Vector3>(component.leftRoundingPoints2);
						list68 = new List<Vector3>(component.rightRoundingPoints2);
						flag85 = true;
						if (startPrefabScript.crossingElements[0].connectedMarker == 0)
						{
							num337 = 0;
						}
					}
					if (startPrefabScript.crossingElements[1].connectedRoad == this && component.roadWidth1 < component.roadWidth2)
					{
						list66 = new List<Vector3>(component.roadSplinePoints1);
						list67 = new List<Vector3>(component.leftRoundingPoints1);
						list68 = new List<Vector3>(component.rightRoundingPoints1);
						flag85 = true;
						if (startPrefabScript.crossingElements[1].connectedMarker == 0)
						{
							num337 = 0;
						}
					}
				}
				startXPositionIndex = 0;
				endXPositionIndex = 0;
				if (flag85 && list66.Count > 1)
				{
					if (num337 == 0)
					{
					}
					for (int num339 = 0; num339 < list66.Count; num339++)
					{
						Vector3 vector10 = ((num339 != 0) ? (list66[num339] - list66[num339 - 1]) : (list66[num339 + 1] - list66[0]));
						vector10 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
						if (num337 == 0)
						{
							markerInts.Insert(0, 0);
						}
					}
					if (num337 == 0)
					{
						startXPositionIndex = list66.Count;
						soSplinePoints.InsertRange(0, list66);
						soSplinePointsLeft.InsertRange(0, list67);
						soSplinePointsRight.InsertRange(0, list68);
						soSplinePointsLeftClamped.InsertRange(0, list67);
						soSplinePointsRightClamped.InsertRange(0, list68);
						float num340 = 0f;
						List<float> list69 = new List<float>();
						list69.Add(0f);
						for (int num341 = 0; num341 < list66.Count - 1; num341++)
						{
							num340 += Vector3.Distance(list66[num341], list66[num341 + 1]);
							list69.Add(num340);
						}
						float num342 = Vector3.Distance(list66[1], soSplinePoints[0]);
						num340 += num342;
						for (int num343 = 0; num343 < distances.Count; num343++)
						{
							distances[num343] += num340;
						}
						distances.InsertRange(0, list69);
						ERMarkerExt eRMarkerExt;
						for (int num344 = 1; num344 < markersExt.Count; num344++)
						{
							eRMarkerExt = markersExt[num344];
							eRMarkerExt.startSplinePoint += list66.Count;
						}
						eRMarkerExt = markersExt[0];
						eRMarkerExt.totalDistance += num340;
					}
				}
			}
			list66.Clear();
			list67.Clear();
			list68.Clear();
			flag85 = false;
			num337 = 0;
			num338 = markersExt.Count - 2;
			if (endPrefabScript != null && endPrefabScript.isIConnector)
			{
				ERIConnector component2 = endPrefabScript.GetComponent<ERIConnector>();
				if (component2 != null)
				{
					if (endPrefabScript.crossingElements[0].connectedRoad == this && component2.roadWidth1 > component2.roadWidth2)
					{
						list66 = new List<Vector3>(component2.roadSplinePoints2);
						list67 = new List<Vector3>(component2.leftRoundingPoints2);
						list68 = new List<Vector3>(component2.rightRoundingPoints2);
						flag85 = true;
						if (endPrefabScript.crossingElements[0].connectedMarker != 0)
						{
							num337 = 1;
						}
					}
					if (endPrefabScript.crossingElements[1].connectedRoad == this && component2.roadWidth1 < component2.roadWidth2)
					{
						list66 = new List<Vector3>(component2.roadSplinePoints1);
						list67 = new List<Vector3>(component2.leftRoundingPoints1);
						list68 = new List<Vector3>(component2.rightRoundingPoints1);
						flag85 = true;
						num337 = ((endPrefabScript.crossingElements[1].connectedMarker != 0) ? 1 : 0);
					}
				}
				if (flag85 && list66.Count > 1)
				{
					if (num337 == 1)
					{
						list66.Reverse();
						list67.Reverse();
						list68.Reverse();
					}
					if (num337 == 1)
					{
						markerInts[markerInts.Count - 1] = markerInts[markerInts.Count - 2];
					}
					for (int num345 = 0; num345 < list66.Count; num345++)
					{
						Vector3 vector10 = ((num345 != 0) ? (list66[num345] - list66[num345 - 1]) : (list66[num345 + 1] - list66[0]));
						vector10 = new Vector3(vector10.z, 0f, 0f - vector10.x).normalized;
						if (num337 == 0)
						{
							markerInts.Insert(0, 0);
						}
						else
						{
							markerInts.Add(num338);
						}
					}
					if (num337 == 0)
					{
						startXPositionIndex = list66.Count;
						soSplinePoints.InsertRange(0, list66);
						soSplinePointsLeft.InsertRange(0, list67);
						soSplinePointsRight.InsertRange(0, list68);
						soSplinePointsLeftClamped.InsertRange(0, list67);
						soSplinePointsRightClamped.InsertRange(0, list68);
						float num346 = 0f;
						List<float> list70 = new List<float>();
						list70.Add(0f);
						for (int num347 = 0; num347 < list66.Count - 1; num347++)
						{
							num346 += Vector3.Distance(list66[num347], list66[num347 + 1]);
							list70.Add(num346);
						}
						float num348 = Vector3.Distance(list66[list66.Count - 1], soSplinePoints[0]);
						num346 += num346;
						for (int num349 = 0; num349 < distances.Count; num349++)
						{
							distances[num349] += num346;
						}
						distances.InsertRange(0, list70);
						ERMarkerExt eRMarkerExt;
						for (int num350 = 1; num350 < markersExt.Count; num350++)
						{
							eRMarkerExt = markersExt[num350];
							eRMarkerExt.startSplinePoint += list66.Count;
						}
						eRMarkerExt = markersExt[0];
						eRMarkerExt.totalDistance += num346;
					}
					else
					{
						endXPositionIndex = list66.Count;
						soSplinePoints.AddRange(list66);
						soSplinePointsLeft.AddRange(list68);
						soSplinePointsRight.AddRange(list67);
						soSplinePointsLeftClamped.AddRange(list68);
						soSplinePointsRightClamped.AddRange(list67);
						float num351 = distances[distances.Count - 1];
						float num352 = Vector3.Distance(soSplinePoints[soSplinePoints.Count - 1], list66[0]);
						num351 += num352;
						distances.Add(num351);
						float num353 = 0f;
						float num354 = 0f;
						for (int num355 = 0; num355 < list66.Count - 1; num355++)
						{
							num354 = Vector3.Distance(list66[num355], list66[num355 + 1]);
							num351 += num354;
							num353 += 4f;
							distances.Add(num351);
						}
						ERMarkerExt eRMarkerExt = markersExt[markersExt.Count - 1];
						eRMarkerExt.startSplinePoint += list66.Count;
						eRMarkerExt = markersExt[markersExt.Count - 2];
						eRMarkerExt.totalDistance += num353;
					}
				}
			}
			if (road == null)
			{
				road = new ERRoad(this);
			}
			if (ERRoadNetwork.onRoadUpdate != null)
			{
				ERRoadNetwork.OnRoadUpdated(road);
			}
			roadUpdate = false;
			if (markersExt.Count > 2)
			{
			}
		}

		public void OOOOQOOCQO()
		{
			crosswalkDistances.Clear();
			List<Vector3> positions = new List<Vector3>();
			List<Vector3> perpPositions = new List<Vector3>();
			List<int> middleIndexes = new List<int>();
			List<float> list = new List<float>();
			List<Vector3> leftPoints = OCCQCCOOCO(ref positions, ref perpPositions, ref middleIndexes, ref list);
			List<Vector3> positions2 = new List<Vector3>();
			List<Vector3> perpPositions2 = new List<Vector3>();
			List<int> middleIndexes2 = new List<int>();
			List<float> list2 = new List<float>();
			List<Vector3> rightPoints = OQDQCQQDCD(ref positions2, ref perpPositions2, ref middleIndexes2, ref list2);
			_ = positions.Count;
			if (true)
			{
				ERSideWalkVecs.OQQDQDDQOC(this, crosswalkObjects, positions, perpPositions, positions2, perpPositions2, middleIndexes, middleIndexes2, leftPoints, rightPoints);
				int count = list.Count;
				if (list2.Count < count)
				{
					count = list2.Count;
				}
				for (int i = 0; i < count; i++)
				{
					crosswalkDistances.Add(Mathf.Lerp(list2[i], list[i], 0.5f));
				}
			}
		}

		private void OCQCQCCDOO(ref List<Vector3> vecs, ref List<Vector2> uvs, ref List<Vector2> uvs2, int cols, ref int addedRows, ref List<bool> isPlanar, ref List<Color> colors, ref float uv, ref float uv4)
		{
			uv -= Mathf.Floor(uv);
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			List<bool> list4 = new List<bool>();
			List<Color> list5 = new List<Color>();
			int num = vecs.Count - cols;
			for (int i = num; i < vecs.Count; i++)
			{
				list.Add(vecs[i]);
				Vector2 item = uvs[i];
				item.y = uv;
				list2.Add(item);
				list3.Add(uvs2[i]);
				list4.Add(isPlanar[i]);
				list5.Add(colors[i]);
			}
			vecs.AddRange(list);
			uvs.AddRange(list2);
			uvs2.AddRange(list3);
			isPlanar.AddRange(list4);
			colors.AddRange(list5);
			addedRows++;
		}

		public void OCOQOCQDDC(Mesh m)
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

		public void OCODODODOC(ERDecal decal, ref GameObject decalPrefab, string name)
		{
			decalPrefab = UnityEngine.Object.Instantiate(decal.decalPrefab);
			decalPrefab.name = decal.decalPrefab.name + name;
			decalPrefab.transform.parent = base.transform;
			decalPrefab.transform.localScale *= decal.scale;
			if (decalPrefab.GetComponent<MeshRenderer>() != null)
			{
				decalPrefab.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
		}

		public float ODDCOQCQDO(ERDecal decal, float roadWidth)
		{
			return 1f;
		}

		public void OQDDDDOCOD(string type)
		{
			List<GameObject> list = new List<GameObject>();
			foreach (Transform item in base.transform)
			{
				if (item.name.IndexOf("_ERDecal_" + type) != -1)
				{
					list.Add(item.gameObject);
				}
			}
			if (Application.isEditor && !Application.isPlaying)
			{
				foreach (GameObject item2 in list)
				{
					UnityEngine.Object.DestroyImmediate(item2);
				}
			}
			else
			{
				foreach (GameObject item3 in list)
				{
					UnityEngine.Object.Destroy(item3);
				}
			}
			if (startDecalPrefab == null && startDecalID != -1)
			{
				QDQDOOQQDQODD roadTypeElByID = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType);
				if (roadTypeElByID != null)
				{
					ERDecal eRDecal = ERDecal.OOCQOOODDC(startDecalID, roadTypeElByID.decalPresets);
					if (eRDecal != null && eRDecal.decalPrefab != null)
					{
						OCODODODOC(eRDecal, ref startDecalPrefab, "_ERDecal_Start");
					}
					OOCDOOOOQO(startDecalPrefab, 0);
				}
			}
			if (!(endDecalPrefab == null) || endDecalID == -1)
			{
				return;
			}
			QDQDOOQQDQODD roadTypeElByID2 = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType);
			if (roadTypeElByID2 == null)
			{
				return;
			}
			ERDecal eRDecal2 = ERDecal.OOCQOOODDC(endDecalID, roadTypeElByID2.decalPresets);
			if (eRDecal2 != null)
			{
				if (eRDecal2.decalPrefab != null)
				{
					OCODODODOC(eRDecal2, ref endDecalPrefab, "_ERDecal_End");
				}
				OOCDOOOOQO(endDecalPrefab, soSplinePoints.Count - 1);
			}
		}

		public void OOCDOOOOQO(GameObject decal, int index)
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
					eRDecal = ERDecal.OOCQOOODDC(num2, roadTypeElByID.decalPresets);
				}
			}
			Vector3 position = soSplinePoints[index];
			if (eRDecal != null)
			{
				position.y += eRDecal.heightOffset;
			}
			decal.transform.position = position;
			Vector3 vector = soSplinePointsLeft[index] - soSplinePointsRight[index];
			Vector3 vector2 = Vector3.zero;
			Vector3 zero = Vector3.zero;
			if (index == 0)
			{
				vector = new Vector3(0f - vector.z, 0f, vector.x).normalized;
				if (eRDecal.startOffset != 0f)
				{
					vector2 = (soSplinePoints[1] - soSplinePoints[0]).normalized;
				}
			}
			else
			{
				vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				if (eRDecal.startOffset != 0f)
				{
					vector2 = (soSplinePoints[index - 1] - soSplinePoints[index]).normalized;
				}
			}
			decal.transform.forward = vector;
			if (eRDecal.startOffset != 0f)
			{
				decal.transform.position += vector2 * eRDecal.startOffset;
			}
			position = Vector3.Lerp(soSplinePoints[index], soSplinePoints[index + num], 0.5f);
			if (!flag)
			{
				zero = markersExt[index2].position;
				if (eRDecal.startOffset != 0f)
				{
					zero += vector2 * eRDecal.startOffset;
					position = zero;
				}
				decal.transform.position = zero;
			}
			if (index != 0 && eRDecal.endRotation != 0f)
			{
				Vector3 eulerAngles = decal.transform.eulerAngles;
				eulerAngles.y += eRDecal.endRotation;
				decal.transform.eulerAngles = eulerAngles;
			}
			Vector3 vector3 = OQQOCDQCQD.OOCCQQCCQQ(position, this);
			Vector3 forward = decal.transform.forward;
			Vector3 vector4 = forward - Vector3.Dot(forward, vector3) * vector3;
			if (vector4 != Vector3.zero)
			{
				decal.transform.rotation = Quaternion.LookRotation(vector4, vector3);
			}
			if (eRDecal != null)
			{
				if (eRDecal.meshWidth == 0f)
				{
					eRDecal.OCCCOQCCOO();
				}
				float num3 = OODCQDCOOQ(index);
				decal.transform.localScale = num3 / eRDecal.meshWidth * new Vector3(1f, 1f, 1f) * eRDecal.scale;
			}
			if (!flag && eRDecal != null)
			{
				zero = decal.transform.position;
				zero.y += eRDecal.heightOffset;
				decal.transform.position = zero;
			}
		}

		public float OODCQDCOOQ(int startEnd)
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
			for (int j = 0; j < list.Count; j++)
			{
				if (list[0].x < 0f)
				{
					if (list[j].x < 0f)
					{
						num4++;
					}
				}
				else if (list[j].x > 0f)
				{
					num4++;
				}
			}
			int num5 = 0;
			int num6 = 0;
			for (int k = 0; k < list.Count; k++)
			{
				if (list[0].x < 0f)
				{
					if (list[k].x >= 0f && num5 == 0)
					{
						num5 = k - num2 - 1;
						num6 = k + num3 - 1;
						break;
					}
				}
				else if (list[k].x <= 0f && num5 == 0)
				{
					num6 = k - num3 - 1;
					num5 = k + num2 - 1;
					break;
				}
			}
			if (num5 >= 0 && num5 < list.Count && num6 >= 0 && num6 < list.Count)
			{
				return Vector3.Distance(list[num5], list[num6]);
			}
			return roadTypeElByID.roadWidth;
		}

		public Vector3[] AdjustNormals(Vector3[] normals)
		{
			int num = roadShapeCols;
			if (startPrefabScript != null)
			{
				for (int i = 0; i < roadShapeCols; i++)
				{
					normals[i] = normals[i + num];
				}
			}
			if (endPrefabScript != null)
			{
				for (int j = 0; j < roadShapeCols; j++)
				{
					normals[normals.Length - num - j - 1] = normals[normals.Length - j - 1 - num];
				}
			}
			return normals;
		}

		public void AdjustPrefabNormals(List<int> roadInts, List<int> prefabInts, Vector3[] normals, GameObject prefab, Vector3[] verts)
		{
			if (prefab.GetComponent<MeshFilter>() == null || !prefab.GetComponent<MeshFilter>().sharedMesh)
			{
				return;
			}
			Mesh sharedMesh = prefab.GetComponent<MeshFilter>().sharedMesh;
			Vector3[] normals2 = sharedMesh.normals;
			int num = normals2.Length;
			int num2 = normals.Length;
			int count = roadInts.Count;
			for (int i = 0; i < count; i++)
			{
				if (prefabInts[i] < num && roadInts[i] < num2)
				{
					normals2[prefabInts[i]] = prefab.transform.InverseTransformDirection(normals[roadInts[i]]);
				}
			}
			sharedMesh.normals = normals2;
		}

		public bool OOCQODQDQD(Vector3 pTarget, Vector3 pSource, Vector3 pCheck)
		{
			Vector3 normalized = (pTarget - pSource).normalized;
			Vector3 normalized2 = (pCheck - pSource).normalized;
			if (Vector3.Cross(normalized, normalized2).y < 0f)
			{
				return false;
			}
			return true;
		}

		public void OODQDQCCOQ(ref List<Vector3> surfaceVecs, ERCrossingPrefabs prefabScript, ref bool startSurfacesSafe, float distance, float minIndent)
		{
		}

		public void OQODQQCQDO(ref List<Vector3> surfaceVecs, ERCrossingPrefabs prefabScript, int el, ref bool surfacesSafe, float distance, float minIndent)
		{
		}

		public bool OCCDDQDDDO(Vector3 OCCDODCDCOIndent, Vector3 otherPrefabIndent, Vector3 v)
		{
			return false;
		}

		public void ODQQOOQDOC(List<Vector3> surfaceVecs, List<Vector2> uvs, int h, List<bool> doBridge, Vector3 firstDir, Vector3 lastDir, float indent, float surrounding, List<bool> tunnelSegments)
		{
			vgData.Clear();
			Vector3 a = Vector3.zero;
			bool flag = true;
			if (!baseScript.vegetationStudio || baseScript.vegetationStudioActive)
			{
			}
			if (surfaceMesh == null)
			{
				ERSurfaceScript componentInChildren = base.gameObject.GetComponentInChildren<ERSurfaceScript>();
				if (componentInChildren != null && componentInChildren.transform.parent.gameObject == base.gameObject)
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
				surfaceMesh.GetComponent<MeshRenderer>().material = baseScript.surfaceMaterial;
				surfaceMesh.transform.parent = base.transform;
				surfaceMesh.GetComponent<MeshRenderer>().enabled = !baseScript.hideSurfaces;
				surfaceMesh.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
				surfaceMesh.layer = baseScript.sLayer;
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
				mesh.MarkDynamic();
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
				if (Application.isEditor && !Application.isPlaying)
				{
					UnityEngine.Object.DestroyImmediate(surfaceMesh);
				}
				else
				{
					UnityEngine.Object.Destroy(surfaceMesh);
				}
				return;
			}
			surfaceMesh.hideFlags = HideFlags.HideInHierarchy;
			surfaceMesh.layer = baseScript.sLayer;
			int num = -1;
			int num2 = -1;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			int num3 = 0;
			float num4 = 0f;
			float num5 = 0f;
			if (soSectionList1.Count > 0)
			{
				num = soSectionList1[num3].startSplinePoint;
				num2 = soSectionList1[num3].endSplinePoint;
				zero = soSectionList1[num3].startPosition;
				zero2 = soSectionList1[num3].endPosition;
				num4 = soSectionList1[num3].hsStart;
				num5 = soSectionList1[num3].hsEnd;
			}
			int num6 = -1;
			int num7 = -1;
			int num8 = 0;
			if (soSectionList2.Count > 0)
			{
				num6 = soSectionList2[num8].startSplinePoint;
				num7 = soSectionList2[num8].endSplinePoint;
			}
			List<int> list = new List<int>();
			int num9 = 5;
			int num10 = 1;
			float num11 = 0f;
			int num12 = 0;
			bool flag2 = false;
			int num13 = 0;
			int num14 = 0;
			bool flag3 = false;
			for (int i = 0; i < h - 1; i += num10)
			{
				if (i == num && num3 < soSectionList1.Count)
				{
					doBridge[i] = true;
					if (i > 0)
					{
						doBridge[i - 1] = false;
					}
					surfaceVecs[i * 5] = surfaceVecs[i * 5 + 1];
					surfaceVecs[i * 5 + 4] = surfaceVecs[i * 5 + 3];
					float num15 = soSectionList1[num3].so.geoStartOffset;
					if (num15 < num4 * 1.5f)
					{
						num15 = num4 * 1.5f;
					}
					int num16 = i - 1;
					float num17 = 0f;
					while (num15 - num17 > 0f && num16 >= 0)
					{
						num17 += distances[num16 + 1] - distances[num16];
						float num18 = 1f - num17 / num15;
						if (num18 < 1f)
						{
							surfaceVecs[num16 * 5] = Vector3.Lerp(surfaceVecs[num16 * 5], surfaceVecs[num16 * 5 + 1], num18);
							surfaceVecs[num16 * 5 + 4] = Vector3.Lerp(surfaceVecs[num16 * 5 + 4], surfaceVecs[num16 * 5 + 3], num18);
						}
						num16--;
					}
				}
				else if (i == num2 && num3 < soSectionList1.Count)
				{
					surfaceVecs[i * 5] = surfaceVecs[i * 5 + 1];
					surfaceVecs[i * 5 + 4] = surfaceVecs[i * 5 + 3];
					float num19 = soSectionList1[num3].so.geoEndOffset;
					if (num19 < num5 * 1.5f)
					{
						num19 = num5 * 1.5f;
					}
					int num20 = i + 1;
					float num21 = 0f;
					while (num19 - num21 > 0f && num20 < h - 1)
					{
						num21 += distances[num20] - distances[num20 - 1];
						float num22 = num21 / num19;
						if (num22 < 1f)
						{
							surfaceVecs[num20 * 5] = Vector3.Lerp(surfaceVecs[num20 * 5], surfaceVecs[num20 * 5 + 1], num22);
							surfaceVecs[num20 * 5 + 4] = Vector3.Lerp(surfaceVecs[num20 * 5 + 4], surfaceVecs[num20 * 5 + 3], num22);
						}
						num20++;
					}
					num3++;
					if (soSectionList1.Count > num3)
					{
						num = soSectionList1[num3].startSplinePoint;
						num2 = soSectionList1[num3].endSplinePoint;
						zero = soSectionList1[num3].startPosition;
						zero2 = soSectionList1[num3].endPosition;
					}
				}
				if (i == num6 && num8 < soSectionList2.Count)
				{
					float num23 = 0f;
					if (i > 0)
					{
						num23 = distances[i] - distances[i - 1];
					}
					else if (distances.Count > 0)
					{
						num23 = distances[i + 1] - distances[i];
					}
					float num24 = 1f - (soSectionList2[num8].startDistanceGeo - soSectionList2[num8].hsStart) / num23;
					if (num24 < 1f)
					{
						surfaceVecs[i * 5] = Vector3.Lerp(surfaceVecs[(i - 1) * 5], surfaceVecs[i * 5], num24);
						surfaceVecs[i * 5 + 1] = Vector3.Lerp(surfaceVecs[(i - 1) * 5 + 1], surfaceVecs[i * 5 + 1], num24);
						surfaceVecs[i * 5 + 2] = Vector3.Lerp(surfaceVecs[(i - 1) * 5 + 2], surfaceVecs[i * 5 + 2], num24);
						surfaceVecs[i * 5 + 3] = Vector3.Lerp(surfaceVecs[(i - 1) * 5 + 3], surfaceVecs[i * 5 + 3], num24);
						surfaceVecs[i * 5 + 4] = Vector3.Lerp(surfaceVecs[(i - 1) * 5 + 4], surfaceVecs[i * 5 + 4], num24);
						if (leftSurroundingVecs.Count > i)
						{
							leftSurroundingVecs[i] = surfaceVecs[i * 5];
						}
						if (leftIndentVecsSV.Count > i)
						{
							leftIndentVecsSV[i] = surfaceVecs[i * 5 + 1];
						}
						if (rightSurroundingVecs.Count > i)
						{
							rightSurroundingVecs[i] = surfaceVecs[i * 5 + 4];
						}
						if (rightIndentVecsSV.Count > i)
						{
							rightIndentVecsSV[i] = surfaceVecs[i * 5 + 3];
						}
					}
				}
				else if (i == num7 && num8 < soSectionList2.Count)
				{
					float num25 = distances[i + 1] - distances[i];
					float num26 = (soSectionList2[num8].endDistanceGeo - soSectionList2[num8].hsEnd) / num25;
					if (num26 <= 1f)
					{
						surfaceVecs[i * 5] = Vector3.Lerp(surfaceVecs[i * 5], surfaceVecs[(i + 1) * 5], num26);
						surfaceVecs[i * 5 + 1] = Vector3.Lerp(surfaceVecs[i * 5 + 1], surfaceVecs[(i + 1) * 5 + 1], num26);
						surfaceVecs[i * 5 + 2] = Vector3.Lerp(surfaceVecs[i * 5 + 2], surfaceVecs[(i + 1) * 5 + 2], num26);
						surfaceVecs[i * 5 + 3] = Vector3.Lerp(surfaceVecs[i * 5 + 3], surfaceVecs[(i + 1) * 5 + 3], num26);
						surfaceVecs[i * 5 + 4] = Vector3.Lerp(surfaceVecs[i * 5 + 4], surfaceVecs[(i + 1) * 5 + 4], num26);
						if (leftSurroundingVecs.Count > i)
						{
							leftSurroundingVecs[i] = surfaceVecs[i * 5];
						}
						if (leftIndentVecsSV.Count > i)
						{
							leftIndentVecsSV[i] = surfaceVecs[i * 5 + 1];
						}
						if (rightSurroundingVecs.Count > i)
						{
							rightSurroundingVecs[i] = surfaceVecs[i * 5 + 4];
						}
						if (rightIndentVecsSV.Count > i)
						{
							rightIndentVecsSV[i] = surfaceVecs[i * 5 + 3];
						}
					}
					num8++;
					if (soSectionList2.Count > num8)
					{
						num6 = soSectionList2[num8].startSplinePoint;
						num7 = soSectionList2[num8].endSplinePoint;
					}
				}
				if (!doBridge[i])
				{
					num11 = ((i == 0) ? 0f : (doBridge[i + 1] ? 1f : ((!doBridge[i - 1]) ? 0f : 2f)));
					for (int j = 0; j < num9 - 1; j++)
					{
						int num27 = i * num9 + j;
						int num28 = i * num9 + j + 1;
						int num29 = (i + num10) * num9 + j;
						int num30 = (i + num10) * num9 + j + 1;
						if ((num11 == 2f && j == 3) || (num11 == 1f && j == 0))
						{
							if (surfaceVecs[num27] != surfaceVecs[num28])
							{
								list.Add(num27);
								list.Add(num29);
								list.Add(num28);
							}
							if (surfaceVecs[num28] != surfaceVecs[num30])
							{
								list.Add(num28);
								list.Add(num29);
								list.Add(num30);
							}
						}
						else if ((j == 0 && doLeftSurrounding[i + 1]) || (j >= num9 - 2 && doRightSurrounding[i + 1]) || (j > 0 && j < num9 - 2))
						{
							if (surfaceVecs[num30] != surfaceVecs[num28])
							{
								list.Add(num27);
								list.Add(num30);
								list.Add(num28);
							}
							if (surfaceVecs[num29] != surfaceVecs[num27])
							{
								list.Add(num29);
								list.Add(num30);
								list.Add(num27);
							}
						}
					}
				}
				if (!baseScript.vegetationStudio && !baseScript.vegetationStudioPro)
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
					flag3 = !doBridge[i];
					vgData.Add(new ERVSData(node, flag3, width, soSplinePointsLeft[i], soSplinePointsRight[i]));
					a = soSplinePoints[i];
				}
			}
			int count = surfaceVecs.Count;
			if (startPrefabScript == null && !doBridge[0] && !closedTrack)
			{
				float leftSurrounding = markersExt[0].leftSurrounding;
				float rightSurrounding = markersExt[0].rightSurrounding;
				InterpolateSurfaces(ref surfaceVecs, ref uvs, ref list, firstDir, count, 0, indent, leftSurrounding, rightSurrounding);
			}
			if (endPrefabScript == null && !doBridge[h - 2] && !closedTrack && !markersExt[markersExt.Count - 2].bridgeObject)
			{
				float leftSurrounding2 = markersExt[markersExt.Count - 1].leftSurrounding;
				float rightSurrounding2 = markersExt[markersExt.Count - 1].rightSurrounding;
				InterpolateSurfaces(ref surfaceVecs, ref uvs, ref list, lastDir, count, 1, indent, leftSurrounding2, rightSurrounding2);
			}
			surfaceMesh.GetComponent<MeshCollider>().sharedMesh = null;
			for (int k = 1; k < surfaceVecs.Count; k++)
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
			mesh.triangles = list.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			surfaceMesh.GetComponent<MeshCollider>().sharedMesh = null;
			if (totalDistance >= 0.1f)
			{
				surfaceMesh.GetComponent<MeshCollider>().sharedMesh = mesh;
			}
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
			if ((!baseScript.vegetationStudio && !baseScript.vegetationStudioPro) || !baseScript.vegetationStudioActive)
			{
				return;
			}
			Vector3 node2 = Vector3.Lerp(soSplinePointsLeft[h - 1], soSplinePointsRight[h - 1], 0.5f);
			float num31 = Vector3.Distance(soSplinePointsLeft[h - 1], soSplinePointsRight[h - 1]);
			vgData.Add(new ERVSData(node2, !doBridge[h - 1], num31, soSplinePointsLeft[h - 1], soSplinePointsRight[h - 1]));
			if (startPrefabScript != null && !doBridge[0])
			{
				Vector3 normalized = (soSplinePointsLeft[0] - soSplinePointsRight[0]).normalized;
				Vector3 leftPosition = startPrefabScript.transform.position + normalized * 0.5f * vgData[0].width;
				Vector3 rightPosition = startPrefabScript.transform.position + -normalized * 0.5f * vgData[0].width;
				vgData.Insert(0, new ERVSData(startPrefabScript.transform.position, active: true, vgData[0].width, leftPosition, rightPosition));
			}
			if (endPrefabScript != null && !doBridge[h - 1])
			{
				Vector3 normalized2 = (soSplinePointsLeft[h - 1] - soSplinePointsRight[h - 1]).normalized;
				Vector3 leftPosition2 = endPrefabScript.transform.position + normalized2 * 0.5f * num31;
				Vector3 rightPosition2 = endPrefabScript.transform.position + -normalized2 * 0.5f * num31;
				vgData.Add(new ERVSData(endPrefabScript.transform.position, active: true, num31, leftPosition2, rightPosition2));
			}
			object[] array = null;
			if (vegetationStudioMaskLineActive)
			{
				array = new object[7]
				{
					base.gameObject,
					vgData.ToArray(),
					vegetationStudioGrassPerimeter,
					vegetationStudioPlantPerimeter,
					vegetationStudioTreePerimeter,
					vegetationStudioObjectPerimeter,
					vegetationStudioLargeObjectPerimeter
				};
			}
			else if (vegetationStudioBiomeMaskActive)
			{
				array = new object[5]
				{
					base.gameObject,
					vgData.ToArray(),
					vegetationStudioBiomeMaskDistance,
					vegetationStudioBiomeMaskBlendDistance,
					vegetationStudioBiomeMaskNoiseScale
				};
			}
			if (vegetationStudioMaskLineActive && array != null)
			{
				if (baseScript.upMethod != null)
				{
					baseScript.upMethod.Invoke(null, array);
				}
			}
			else if (vegetationStudioBiomeMaskActive && array != null && baseScript.upBiomeMethod != null)
			{
				baseScript.upBiomeMethod.Invoke(null, array);
			}
		}

		public void InterpolateSurfaces(ref List<Vector3> surfaceVecs, ref List<Vector2> uvs, ref List<int> tris, Vector3 dir, int vecCount, int startEnd, float indent, float surroundingLeft, float surroundingRight)
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
			Vector3 pos = surfaceVecs[num] + dir * (indent + surroundingLeft);
			baseScript.OQCCDQOQOO(ref pos);
			surfaceVecs.Add(pos);
			pos = surfaceVecs[num + 1] + dir * (indent + surroundingLeft);
			baseScript.OQCCDQOQOO(ref pos);
			surfaceVecs.Add(pos);
			pos = surfaceVecs[num + 2] + dir * (indent + Mathf.Lerp(surroundingLeft, surroundingRight, 0.5f));
			baseScript.OQCCDQOQOO(ref pos);
			surfaceVecs.Add(pos);
			pos = surfaceVecs[num + 3] + dir * (indent + surroundingRight);
			baseScript.OQCCDQOQOO(ref pos);
			surfaceVecs.Add(pos);
			pos = surfaceVecs[num + 4] + dir * (indent + surroundingRight);
			baseScript.OQCCDQOQOO(ref pos);
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
						if (j == num2 - 2)
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
							tris.Add(count + i * num2 + j + 1);
							tris.Add(count + (i + num3) * num2 + j);
							tris.Add(count + i * num2 + j + 1);
							tris.Add(count + (i + num3) * num2 + j + 1);
							tris.Add(count + (i + num3) * num2 + j);
						}
					}
					else if (j == 0)
					{
						tris.Add(count + i * num2 + j);
						tris.Add(count + (i + num3) * num2 + j);
						tris.Add(count + i * num2 + j + 1);
						tris.Add(count + i * num2 + j + 1);
						tris.Add(count + (i + num3) * num2 + j);
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

		public void OQDOQQDCCD(List<List<Vector2>> roadShapeList = null)
		{
			if (!baseScript.aiTraffic)
			{
				return;
			}
			laneData.Clear();
			if (rt == null)
			{
				rt = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType, clone: true);
			}
			if (rt == null || !rt.roadShapeData.isset)
			{
				return;
			}
			List<Vector3> list = new List<Vector3>();
			float num = rt.roadWidth * 0.5f;
			for (int i = 0; i < rt.roadShapeData.lanes.Count; i++)
			{
				ERLaneData eRLaneData = ERLaneData.CreateInstance();
				list.Clear();
				for (int j = 0; j < soSplinePoints.Count; j++)
				{
					if (roadShapeList != null)
					{
					}
					Vector3 normalized = (soSplinePointsRight[j] - soSplinePoints[j]).normalized;
					Vector3 item = soSplinePoints[j] + normalized * rt.roadShapeData.lanes[i].position * num;
					list.Add(item);
				}
				if (!rt.oneWay)
				{
					if ((rt.roadShapeData.lanes[i].direction == ERLaneDirection.Left && baseScript.rightHandDriving == 1) || (rt.roadShapeData.lanes[i].direction == ERLaneDirection.Right && baseScript.rightHandDriving == 0))
					{
						list.Reverse();
					}
					oneWayRoad = false;
				}
				else
				{
					oneWayRoad = true;
					if (oneWayDirection == ERLaneDirection.Left)
					{
						list.Reverse();
					}
				}
				eRLaneData.points = list.ToArray();
				eRLaneData.direction = rt.roadShapeData.lanes[i].direction;
				eRLaneData.laneIndex = rt.roadShapeData.lanes[i].laneIndex;
				laneData.Add(eRLaneData);
			}
		}

		public Vector3 GetLaneDataCenterPosition(Vector3 hitPosition, out int index, out Vector3 forwardDirection)
		{
			List<Vector3> list = soSplinePoints;
			float num = 10000f;
			float num2 = 0f;
			index = -1;
			forwardDirection = Vector3.zero;
			for (int i = 0; i < soSplinePoints.Count; i++)
			{
				num2 = Vector3.Distance(soSplinePoints[i], hitPosition);
				if (num2 < num)
				{
					index = i;
					num = num2;
				}
			}
			Vector3 vector;
			if (index > 0)
			{
				vector = OQQOCDQCQD.OCOOQOQCDC(soSplinePoints[index - 1], soSplinePoints[index], hitPosition);
				forwardDirection = (soSplinePoints[index] - soSplinePoints[index - 1]).normalized;
			}
			else
			{
				vector = OQQOCDQCQD.OCOOQOQCDC(soSplinePoints[1], soSplinePoints[0], hitPosition);
				forwardDirection = (soSplinePoints[1] - soSplinePoints[0]).normalized;
			}
			Vector3 normalized = (vector - hitPosition).normalized;
			Vector3 result = hitPosition;
			if (rt == null)
			{
				rt = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType, clone: true);
			}
			if (rt != null && rt.roadShapeData.isset)
			{
				float num3 = rt.roadWidth * 0.5f;
				float num4 = 10000f;
				for (int j = 0; j < rt.roadShapeData.lanes.Count; j++)
				{
					float num5 = rt.roadShapeData.lanes[j].position * num3;
					Vector3 vector2 = vector + normalized * num5;
					float num6 = Vector3.Distance(hitPosition, vector2);
					if (num6 < num4)
					{
						result = vector2;
						num4 = num6;
					}
				}
			}
			return result;
		}

		public List<Vector3> OCCQQDQODQ(List<ERMarkerExt> markersExt, float faceDist, bool ignorePrefabAlignment, ref List<float> tValues, ref List<float> markerDistances, bool forceAutoRotate, ref List<float> rotationArray, ref List<float> bendAngles, ref List<float> randomLeftTerrainHeightOffset, ref List<float> randomRightTerrainHeightOffset)
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
				for (int j = 1; j < markersExt.Count - 2; j++)
				{
					if (markersExt[j].controlType == 3)
					{
						bool flag = true;
						if (!(markersExt[j].oldPosition != markersExt[j].position) && !(markersExt[j + 1].oldPosition != markersExt[j + 1].position) && !(markersExt[j + 2].oldPosition != markersExt[j + 2].position))
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
			for (int k = 0; k < tmpMarkersExt.Count; k++)
			{
				tmpNodes.Add(tmpMarkersExt[k].position);
				if (tmpMarkersExt[k].splineStrength == 0f)
				{
					tmpMarkersExt[k].splineStrength = 0.5f;
				}
				list2.Add(tmpMarkersExt[k].splineStrength);
			}
			if (tmpNodes.Count != list2.Count)
			{
				Debug.Log("array lengths " + tmpNodes.Count + " " + list2.Count);
			}
			float num = 0f;
			float num2 = 1f;
			bool flag4 = false;
			bool flag5 = false;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			bool flag6 = false;
			float num3 = 0f;
			float num4 = 0f;
			bool flag7 = true;
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
					Vector3 vector3 = tmpNodes[2];
					if (tmpNodes.Count >= 4)
					{
						vector3 = tmpNodes[3];
					}
					Vector3 v = OQQCQOQOOD(tmpNodes[0], tmpNodes[1], tmpNodes[2], vector3, 0.5f, 0.5f);
					startPrefabScript.OCODOODQQQ(tmpNodes[0], v, startConnectionSegment, this);
				}
				else
				{
					if ((startPrefabScript.isFlexConnector || startPrefabScript.isERCrossingExt) && !baseScript.ignoreFlexConnectorUpdate)
					{
						if (startPrefabScript.isERCrossingExt && startPrefabScript.crossingsScript == null)
						{
							startPrefabScript.crossingsScript = startPrefabScript.GetComponent<ERCrossings>();
						}
						if (endPrefabScript != null && (endPrefabScript.isFlexConnector || endPrefabScript.isERCrossingExt))
						{
							if (tmpNodes.Count > 2)
							{
								tmpNodes[tmpNodes.Count - 1] = endPrefabScript.crossingsScript.OCDCOCDODQ(endConnectionSegment, tmpNodes[tmpNodes.Count - 1], tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 3], update: false);
							}
							else
							{
								tmpNodes[tmpNodes.Count - 1] = endPrefabScript.crossingsScript.OCDCOCDODQ(endConnectionSegment, tmpNodes[tmpNodes.Count - 1], tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 2], update: false);
							}
							flag6 = true;
						}
						if (tmpNodes.Count > 2)
						{
							tmpNodes[0] = startPrefabScript.crossingsScript.OCDCOCDODQ(startConnectionSegment, tmpNodes[0], tmpNodes[1], tmpNodes[2], update: true);
						}
						else
						{
							tmpNodes[0] = startPrefabScript.crossingsScript.OCDCOCDODQ(startConnectionSegment, tmpNodes[0], tmpNodes[1], tmpNodes[1], update: true);
						}
					}
					if (startPrefabScript.isIConnector)
					{
						ERIConnector component = startPrefabScript.gameObject.GetComponent<ERIConnector>();
						if (startConnectionSegment == 0)
						{
							num3 = component.connectorLength1;
						}
						else
						{
							num3 = component.connectorLength2;
						}
						if (!ignorePrefabAlignment)
						{
							component.ODDDQDQOOD(this);
						}
						tmpNodes[0] = startPrefabScript.transform.position;
						Vector3 vector4 = startPrefabScript.transform.position;
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
								vector4 = ((startPrefabScript.crossingElements[index].connectedMarker != 0) ? connectedRoad.markersExt[connectedRoad.markersExt.Count - 2].position : connectedRoad.markersExt[1].position);
							}
						}
						if (component.road1XOffset != 0f || component.road2XOffset != 0f)
						{
							float num5;
							float num6;
							float road1XOffset;
							if (component.road1 == this)
							{
								num5 = component.roadWidth1;
								num6 = component.roadWidth2;
								road1XOffset = component.road1XOffset;
								float road2XOffset = component.road2XOffset;
								road1XOffset = component.xOffsetForRoad1;
							}
							else
							{
								num5 = component.roadWidth2;
								num6 = component.roadWidth1;
								road1XOffset = component.road2XOffset;
								float road2XOffset = component.road1XOffset;
								road1XOffset = component.xOffsetForRoad1;
							}
							float num7 = (num6 - num5) * 0.5f * road1XOffset;
							Vector3 vector5 = vector4 - tmpNodes[1];
							vector5 = new Vector3(vector5.z, 0f, 0f - vector5.x).normalized;
							if (num5 < num6)
							{
								tmpNodes[0] += vector5 * num7;
								vector4 += vector5 * num7;
							}
							else
							{
								vector4 += vector5 * num7;
							}
						}
						tmpNodes.Insert(0, vector4);
						num = ((!(component.road1 == this)) ? component.t2 : component.t1);
					}
					else
					{
						Vector3 zero = Vector3.zero;
						OQOCQDQODD.OCCQDCCQCD(this, ref tmpNodes, list2, startPrefabScript, startConnectionSegment, ref startDir, ref zero, 0);
						if (startPrefabScript.isFlexConnector)
						{
							tmpNodes[0] = startPrefabScript.transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].controlPointV3);
							flag4 = true;
							vector = (startPrefabScript.transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].centerPoint) - tmpNodes[0]).normalized;
						}
					}
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
					OCQOCCOQDD(ref endCP, tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 1], tmpNodes[2]);
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
				if ((endPrefabScript.isFlexConnector || endPrefabScript.isERCrossingExt) && !baseScript.ignoreFlexConnectorUpdate)
				{
					if (endPrefabScript.isERCrossingExt && endPrefabScript.crossingsScript == null)
					{
						endPrefabScript.crossingsScript = endPrefabScript.GetComponent<ERCrossings>();
					}
					if (!flag6)
					{
						if (tmpNodes.Count > 2)
						{
							tmpNodes[tmpNodes.Count - 1] = endPrefabScript.crossingsScript.OCDCOCDODQ(endConnectionSegment, tmpNodes[tmpNodes.Count - 1], tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 3], update: true);
						}
						else
						{
							tmpNodes[tmpNodes.Count - 1] = endPrefabScript.crossingsScript.OCDCOCDODQ(startConnectionSegment, tmpNodes[tmpNodes.Count - 1], tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 2], update: true);
						}
					}
					else if (endPrefabScript.isFlexConnector)
					{
						endPrefabScript.crossingsScript.OCOQDOOOQC(null);
					}
				}
				if ((!ignorePrefabAlignment && endPrefabScript.crossingElements[endConnectionSegment].rotationPriority) || flag3)
				{
					tmpNodes.Add(tmpNodes[tmpNodes.Count - 1]);
					list2.Add(list2[list2.Count - 1]);
					Vector3 p = tmpNodes[tmpNodes.Count - 3];
					if (tmpNodes.Count >= 4)
					{
						p = tmpNodes[tmpNodes.Count - 4];
					}
					Vector3 v2 = OQQCQOQOOD(p, tmpNodes[tmpNodes.Count - 3], tmpNodes[tmpNodes.Count - 2], tmpNodes[tmpNodes.Count - 1], 0.5f, 0.5f);
					endPrefabScript.OCODOODQQQ(tmpNodes[tmpNodes.Count - 1], v2, endConnectionSegment, this);
				}
				else if (endPrefabScript.isIConnector)
				{
					endPrefabScript.crossingElements[endConnectionSegment].connectedMarker = markersExt.Count - 1;
					ERIConnector component2 = endPrefabScript.gameObject.GetComponent<ERIConnector>();
					if (endConnectionSegment == 0)
					{
						num4 = component2.connectorLength1;
					}
					else
					{
						num4 = component2.connectorLength2;
					}
					if (!ignorePrefabAlignment)
					{
						component2.ODDDQDQOOD(this);
					}
					tmpNodes[tmpNodes.Count - 1] = endPrefabScript.transform.position;
					Vector3 vector6 = endPrefabScript.transform.position;
					int index2 = 1;
					if (endConnectionSegment == 1)
					{
						index2 = 0;
					}
					if (endPrefabScript.crossingElements[index2].connectedRoad != null)
					{
						ERModularRoad connectedRoad2 = endPrefabScript.crossingElements[index2].connectedRoad;
						if (connectedRoad2.markersExt.Count > 0)
						{
							vector6 = ((endPrefabScript.crossingElements[index2].connectedMarker != 0) ? connectedRoad2.markersExt[connectedRoad2.markersExt.Count - 2].position : connectedRoad2.markersExt[1].position);
						}
					}
					if (component2.road1XOffset != 0f || component2.road2XOffset != 0f)
					{
						float num8;
						float num9;
						float num10;
						float road1XOffset2;
						if (component2.road1 == this)
						{
							num8 = component2.roadWidth1;
							num9 = component2.roadWidth2;
							road1XOffset2 = component2.road1XOffset;
							num10 = component2.road2XOffset;
							road1XOffset2 = component2.xOffsetForRoad1;
						}
						else
						{
							num8 = component2.roadWidth2;
							num9 = component2.roadWidth1;
							road1XOffset2 = component2.road2XOffset;
							num10 = component2.road1XOffset;
							road1XOffset2 = component2.xOffsetForRoad1;
						}
						if (num10 > road1XOffset2)
						{
						}
						float num11 = (num9 - num8) * 0.5f * road1XOffset2;
						Vector3 vector7 = vector6 - tmpNodes[tmpNodes.Count - 2];
						vector7 = new Vector3(vector7.z, 0f, 0f - vector7.x).normalized;
						if (num8 < num9)
						{
							tmpNodes[tmpNodes.Count - 1] -= vector7 * num11;
							vector6 -= vector7 * num11;
						}
						else if (component2.road1 == this)
						{
							vector6 += vector7 * num11;
						}
						else
						{
							vector6 -= vector7 * num11;
						}
					}
					tmpNodes.Add(vector6);
					num2 = ((!(component2.road1 == this)) ? (1f - component2.t2) : (1f - component2.t1));
					if (num2 < 0f)
					{
						num2 = 0.2f;
					}
				}
				else
				{
					OQOCQDQODD.OCCQDCCQCD(this, ref tmpNodes, list2, endPrefabScript, endConnectionSegment, ref endDir, ref lastForward, 1);
					if (endPrefabScript.isFlexConnector)
					{
						tmpNodes[tmpNodes.Count - 1] = endPrefabScript.transform.TransformPoint(endPrefabScript.crossingElements[endConnectionSegment].controlPointV3);
						flag5 = true;
						vector2 = (endPrefabScript.transform.TransformPoint(endPrefabScript.crossingElements[endConnectionSegment].centerPoint) - tmpNodes[tmpNodes.Count - 1]).normalized;
					}
				}
				if (endPrefabScript.tStraightBending)
				{
					tCrossingConnected = true;
				}
			}
			if (tmpNodes.Count < 4)
			{
				if (baseScript.debugMode)
				{
					Debug.Log("EasyRoads3D: Road object spline points, node count is less than 4");
				}
				return null;
			}
			Vector3[] array = tmpNodes.ToArray();
			float num12 = 0f;
			Vector3 vector8 = array[1];
			Vector3 v3 = Vector3.zero;
			Vector3 circleDir = Vector3.zero;
			bool flag8 = false;
			totalDistance = 0f;
			int num13 = 0;
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
			float num14 = 0f;
			int num15 = 0;
			Vector3 b = vector8;
			b.y = 0f;
			Vector3 to = new Vector3(0f, 50f, 0f);
			float xzDistance = 0f;
			Vector3 vector10;
			Vector3 vector9 = (vector10 = Vector3.zero);
			float num16 = 0f;
			float num17 = 0f;
			Vector3 zero2 = Vector3.zero;
			bool flag9 = false;
			bool flag10 = false;
			float randomYDistanceStart = 0f;
			float randomYDistanceEnd = 0f;
			float randomYDistanceMiddle = 0f;
			Vector3 randomYDistanceV = Vector3.zero;
			float num18 = 0f;
			float currentRandomYDistance = 0f;
			float randomRotationStart = 0f;
			float randomRotationEnd = 0f;
			float randomRotationMiddle = 0f;
			Vector3 randomRotationV = Vector3.zero;
			float currentRandomRotation = 0f;
			float num19 = 0f;
			float currentRandomLeftTerrainHeightOffset = 0f;
			float randomLeftTerrainHeightDistanceStart = 0f;
			float randomLeftTerrainHeightDistanceMiddle = 0f;
			float randomLeftTerrainHeightDistanceEnd = 0f;
			float randomLeftTerrainHeightOffsetValue = 0f;
			float randomLeftTerrainHeightOffsetValuePrev = 0f;
			float currentRandomRightTerrainHeightOffset = 0f;
			float randomRightTerrainHeightDistanceStart = 0f;
			float randomRightTerrainHeightDistanceMiddle = 0f;
			float randomRightTerrainHeightDistanceEnd = 0f;
			float randomRightTerrainHeightOffsetValue = 0f;
			float randomRightTerrainHeightOffsetValuePrev = 0f;
			float num20 = faceDistance;
			if (array.Length == 4)
			{
				float num21 = Vector3.Distance(markersExt[0].position, markersExt[1].position);
				if (num21 < num20 * 1.5f && angleTreshold > faceDistance)
				{
					num20 = num21 * 0.5f;
					list.Add(markersExt[0].position);
					list.Add(Vector3.Lerp(markersExt[0].position, markersExt[1].position, 0.5f));
					list.Add(markersExt[1].position);
					markerDistances.Add(num21);
					return list;
				}
			}
			bool flag11 = false;
			float num22 = 0f;
			if (startPrefabScript != null && angleTreshold < faceDist)
			{
				Vector3 normalized2 = (array[1] - array[0]).normalized;
				Vector3 normalized3 = (array[1] - array[2]).normalized;
				num22 = Vector3.Angle(normalized2, normalized3);
				normalized2 = (array[2] - array[1]).normalized;
				normalized3 = (array[2] - array[3]).normalized;
				float num23 = Vector3.Angle(normalized2, normalized3);
				if (num23 < num22)
				{
					num22 = num23;
				}
				num22 -= 90f;
				if (!startPrefabScript.tStraightBending || !startPrefabScript.tCrossing || startConnectionSegment == 2 || startConnectionSegment == 3)
				{
					flag11 = true;
				}
				vector9 = (array[0] - array[1]).normalized;
			}
			float num24 = 0f;
			if (!(endPrefabScript != null) || angleTreshold < faceDist)
			{
			}
			float num25 = faceDist;
			int count = markersExt.Count;
			int num26 = 0;
			int num27 = 0;
			for (int l = 1; l < array.Length - 2; l++)
			{
				float totalDist = 0f;
				markersExt[l - 1].startSplinePoint = list.Count;
				markersExt[l - 1].startDistance = totalDistance;
				if (count > l && (markersExt[l - 1].rotation != 0f || markersExt[l].rotation != 0f) && angleTreshold < faceDist)
				{
					float num28 = Mathf.Abs(markersExt[l - 1].rotation - markersExt[l].rotation);
					if (num28 > 3f)
					{
						float num29 = Mathf.Abs(num28);
						if (num29 > 90f)
						{
							num29 = 180f - num29;
						}
						num25 = angleTreshold * (1f - num28 / 90f) * 1.5f;
					}
					else
					{
						num25 = faceDist;
					}
					if (num25 < 0.5f)
					{
						num25 = 0.5f;
					}
				}
				else
				{
					num25 = faceDist;
				}
				if (l > 1)
				{
					if (l > 2)
					{
						markersExt[l - 2].totalDistance = totalDistance - markersExt[l - 2].startDistance;
					}
					else
					{
						markersExt[l - 2].totalDistance = totalDistance;
					}
					if (markersExt[l - 2].totalDistance < 1000f)
					{
						markersExt[l - 2].totalDistanceString = markersExt[l - 2].totalDistance.ToString("N2") + " m";
					}
					else
					{
						markersExt[l - 2].totalDistanceString = (markersExt[l - 2].totalDistance / 1000f).ToString("N3") + " km";
					}
					Vector3 vector11 = new Vector3(0f, Mathf.Abs(markersExt[l - 2].position.y - markersExt[l - 1].position.y), xzDistance);
					float num30 = 90f - Vector3.Angle(vector11, to);
					if (num30 > 10f)
					{
						markersExt[l - 2].angleString = Mathf.Round(num30).ToString();
					}
					else
					{
						markersExt[l - 2].angleString = num30.ToString("N2");
					}
					markersExt[l - 2].slopeAngle = num30;
					float num31 = Mathf.Abs(markersExt[l - 2].position.y - markersExt[l - 1].position.y);
					float num32 = Vector3.Distance(new Vector3(markersExt[l - 2].position.x, 0f, markersExt[l - 2].position.z), new Vector3(markersExt[l - 1].position.x, 0f, markersExt[l - 1].position.z));
					markersExt[l - 2].gradeString = (num31 / num32 * 100f).ToString("N2");
					if (list.Count > 2)
					{
						vector9 = (list[list.Count - 1] - list[list.Count - 2]).normalized;
					}
				}
				list3.Clear();
				vecs.Clear();
				xzDistance = 0f;
				num18 = totalDistance + Vector3.Distance(array[l], array[l + 1]);
				if (l == 2 && tmpMarkersExt[l - 1].controlType == 3 && list.Count <= 2)
				{
					list.Insert(1, Vector3.Lerp(list[0], list[1], 0.5f));
					tValues.Insert(1, 0.5f);
					rotationArray.Insert(1, Mathf.Lerp(rotationArray[0], rotationArray[1], 0.5f));
					randomLeftTerrainHeightOffset.Insert(1, Mathf.Lerp(randomLeftTerrainHeightOffset[0], randomLeftTerrainHeightOffset[1], 0.5f));
					randomRightTerrainHeightOffset.Insert(1, Mathf.Lerp(randomRightTerrainHeightOffset[0], randomRightTerrainHeightOffset[1], 0.5f));
				}
				if (tmpMarkersExt[l - 1].controlType == 0)
				{
					float num33 = Vector3.Distance(array[l], array[l + 1]);
					float num34 = 0.2f / num33;
					if (num12 > 0f)
					{
						num12 -= 1f;
					}
					num12 = 0f;
					bool flag12 = false;
					if (l > 1 && (tmpMarkersExt[l - 2].controlType == 1 || tmpMarkersExt[l - 2].controlType == 2))
					{
						flag12 = true;
					}
					if (l == 1)
					{
						num12 = num;
					}
					float num35 = ((l != array.Length - 3) ? 1f : num2);
					float num36 = 0.5f;
					for (float num37 = num12; num37 < num35; num37 += num34)
					{
						flag8 = false;
						flag9 = false;
						if (num37 + num34 > 1f && l == array.Length - 3 && !closedTrack)
						{
							flag8 = true;
							flag9 = true;
							num37 = 1f;
						}
						Vector3 pos = OQQCQOQOOD(startCP, array[l], array[l + 1], endCP2, num37, list2[l]);
						if (num15 == 3)
						{
							vector8 = pos;
							b = vector8;
							b.y = 0f;
							num15 = 0;
						}
						num16 = Vector3.Distance(vector8, pos);
						num17 = Vector3.Distance(pos, array[l + 1]);
						num27 = vecs.Count;
						num26 = list.Count;
						if (l == 1 && num27 == 1 && startPrefabScript == null && num37 != 0f && angleTreshold < faceDist && num37 != 0f && vector9 == Vector3.zero)
						{
							vector9 = (array[1] - pos).normalized;
						}
						if (num27 > 0 || num26 > 0 || (vector9 != Vector3.zero && num37 != 0f))
						{
							zero2 = ((num27 > 0) ? vecs[vecs.Count - 1] : ((num26 <= 0) ? array[1] : list[list.Count - 1]));
							if (l == 1 && num27 == 1 && startPrefabScript != null && flag11)
							{
								vector9 = (array[0] - array[1]).normalized;
							}
							vector10 = (pos - zero2).normalized;
							if (vector9 != Vector3.zero)
							{
								num19 = Vector3.Angle(vector9, vector10);
								if (num19 > angleTreshold && num16 >= 1f && (double)num17 > 1.5)
								{
									flag8 = true;
									flag9 = true;
								}
							}
						}
						if (snapToTerrain)
						{
							baseScript.OQCCDQOQOO(ref pos);
						}
						if (num37 + num34 + 0.1f > num35 && num17 < 0.5f * num20 && !flag9 && !flag10)
						{
							pos = array[l + 1];
							flag8 = true;
							num37 = 1f;
						}
						if (num37 + num34 > num35)
						{
							pos = array[l + 1];
							flag8 = true;
							num37 = 1f;
						}
						if (!(Vector3.Distance(vector8, pos) > num25 || flag8) && (l != 1 || num37 != 0f))
						{
							continue;
						}
						num33 = Vector3.Distance(vector8, pos);
						totalDistance += num33;
						totalDist += num33;
						Vector3 vector12 = pos;
						vector12.y = 0f;
						xzDistance += Vector3.Distance(vector12, b);
						vector8 = pos;
						v3 = pos;
						b = vector12;
						flag10 = flag9;
						if (tmpMarkersExt[l - 1].randomMinYPosition != 0f || tmpMarkersExt[l - 1].randomMaxYPosition != 0f || tmpMarkersExt[l - 1].randomMinRotation != 0f || tmpMarkersExt[l - 1].randomMaxRotation != 0f || (rt != null && rt.maxTerrainHeightOffset != 0f))
						{
							RoadSmoothness(totalDistance, tmpMarkersExt[l - 1], num18, ref randomYDistanceStart, ref randomYDistanceEnd, ref randomYDistanceMiddle, ref randomYDistanceV, ref v3, ref currentRandomYDistance, ref randomRotationStart, ref randomRotationEnd, ref randomRotationMiddle, ref randomRotationV, ref currentRandomRotation, ref rotationArray, ref randomLeftTerrainHeightOffset, ref currentRandomLeftTerrainHeightOffset, ref randomLeftTerrainHeightDistanceStart, ref randomLeftTerrainHeightDistanceMiddle, ref randomLeftTerrainHeightDistanceEnd, ref randomLeftTerrainHeightOffsetValuePrev, ref randomLeftTerrainHeightOffsetValue, ref randomRightTerrainHeightOffset, ref currentRandomRightTerrainHeightOffset, ref randomRightTerrainHeightDistanceStart, ref randomRightTerrainHeightDistanceMiddle, ref randomRightTerrainHeightDistanceEnd, ref randomRightTerrainHeightOffsetValuePrev, ref randomRightTerrainHeightOffsetValue);
						}
						else
						{
							rotationArray.Add(0f);
							randomLeftTerrainHeightOffset.Add(0f);
							randomRightTerrainHeightOffset.Add(0f);
						}
						if (num33 > 5f)
						{
							bendAngles.Add(num19);
						}
						else
						{
							bendAngles.Add(num19 / num33 * 5f);
						}
						if (flag12)
						{
							if (bendAngles.Count > 1)
							{
								bendAngles[bendAngles.Count - 2] = bendAngles[bendAngles.Count - 1];
							}
							flag12 = false;
						}
						vecs.Add(v3);
						list3.Add(num37);
						if (flag8)
						{
							nodeSplinePoint.Add(num13);
						}
						num13++;
						vector9 = vector10;
					}
					num15 = 0;
				}
				else if (tmpMarkersExt[l - 1].controlType == 1 || tmpMarkersExt[l - 1].controlType == 2)
				{
					if (l == 1)
					{
						v3 = array[l];
					}
					Vector3 normalized4 = (array[l + 1] - array[l]).normalized;
					totalDist = Vector3.Distance(array[l + 1], array[l]);
					b = v3;
					b.y = 0f;
					Vector3 vector12 = array[l + 1];
					vector12.y = 0f;
					xzDistance += Vector3.Distance(vector12, b);
					float num33 = num25;
					if (l == 1)
					{
						num33 = 0f;
					}
					List<float> list4 = new List<float>();
					for (; num33 < totalDist - num25; num33 += num25)
					{
						currentRandomYDistance = 0f;
						Vector3 a = v3 + normalized4 * num33;
						if (Vector3.Distance(a, array[l + 1]) > 0.5f * num25)
						{
							Vector3 pos2 = v3 + normalized4 * num33;
							if (snapToTerrain)
							{
								baseScript.OQCCDQOQOO(ref pos2);
							}
							if (tmpMarkersExt[l - 1].randomMinYPosition != 0f || tmpMarkersExt[l - 1].randomMaxYPosition != 0f || tmpMarkersExt[l - 1].randomMinRotation != 0f || tmpMarkersExt[l - 1].randomMaxRotation != 0f)
							{
								RoadSmoothness(totalDistance + num33, tmpMarkersExt[l - 1], num18, ref randomYDistanceStart, ref randomYDistanceEnd, ref randomYDistanceMiddle, ref randomYDistanceV, ref pos2, ref currentRandomYDistance, ref randomRotationStart, ref randomRotationEnd, ref randomRotationMiddle, ref randomRotationV, ref currentRandomRotation, ref rotationArray, ref randomLeftTerrainHeightOffset, ref currentRandomLeftTerrainHeightOffset, ref randomLeftTerrainHeightDistanceStart, ref randomLeftTerrainHeightDistanceMiddle, ref randomLeftTerrainHeightDistanceEnd, ref randomLeftTerrainHeightOffsetValuePrev, ref randomLeftTerrainHeightOffsetValue, ref randomRightTerrainHeightOffset, ref currentRandomRightTerrainHeightOffset, ref randomRightTerrainHeightDistanceStart, ref randomRightTerrainHeightDistanceMiddle, ref randomRightTerrainHeightDistanceEnd, ref randomRightTerrainHeightOffsetValuePrev, ref randomRightTerrainHeightOffsetValue);
							}
							else
							{
								rotationArray.Add(0f);
								randomLeftTerrainHeightOffset.Add(0f);
								randomRightTerrainHeightOffset.Add(0f);
							}
							vecs.Add(pos2);
							list4.Add(currentRandomYDistance);
							bendAngles.Add(0f);
							num14 = num33 / totalDist;
							list3.Add(num14);
						}
					}
					if (!snapToTerrain && tmpMarkersExt[l - 1].controlType == 1)
					{
						for (int m = 0; m < list3.Count; m++)
						{
							Vector3 a = OQQCQOQOOD(array[l - 1], array[l], array[l + 1], array[l + 2], list3[m], 0.5f);
							Vector3 value = vecs[m];
							value.y = a.y + list4[m];
							vecs[m] = value;
						}
					}
					if (vecs.Count == 0)
					{
						vecs.Add(array[l + 1]);
						totalDist = Vector3.Distance(v3, array[l + 1]);
						list3.Add(1f);
						rotationArray.Add(0f);
						bendAngles.Add(0f);
						randomLeftTerrainHeightOffset.Add(0f);
						randomRightTerrainHeightOffset.Add(0f);
					}
					if (vecs.Count > 0 && vecs[vecs.Count - 1] != array[l + 1])
					{
						if (Vector3.Distance(vecs[vecs.Count - 1], array[l + 1]) < 0.5f * num25)
						{
							vecs[vecs.Count - 1] = array[l + 1];
							list3[list3.Count - 1] = 1f;
						}
						else
						{
							vecs.Add(array[l + 1]);
							totalDist += Vector3.Distance(vecs[vecs.Count - 1], array[l + 1]);
							list3.Add(1f);
							rotationArray.Add(0f);
							randomLeftTerrainHeightOffset.Add(0f);
							randomRightTerrainHeightOffset.Add(0f);
						}
					}
					num13 += vecs.Count;
					vector8 = (v3 = vecs[vecs.Count - 1]);
					totalDistance += totalDist;
					nodeSplinePoint.Add(num13);
					num15 = tmpMarkersExt[l - 1].controlType;
				}
				else if (tmpMarkersExt[l - 1].controlType == 3)
				{
					float radius = 0f;
					if (l - 1 < tmpMarkersExt.Count - 2 || closedTrack || endPrefabScript != null)
					{
						OQOCQDQODD.OCCDOCDDCQ(ref list, this, l, ref vecs, ref list3, ref totalDist, 0, ref xzDistance, getDistance: false, ref radius, ref bendAngles);
					}
					else
					{
						OQOCQDQODD.OQDOCDDCQD(ref list, this, l, ref vecs, ref list3, ref totalDist, 0, ref xzDistance, getDistance: false, ref bendAngles);
					}
					tmpMarkersExt[l - 1].radius = radius;
					float num38 = 0f;
					for (int n = 0; n < list3.Count; n++)
					{
						Vector3 pos3 = vecs[n];
						if (!snapToTerrain)
						{
							pos3.y = OQQCQOQOOD(array[l - 1], array[l], array[l + 1], array[l + 2], list3[n], 0.5f).y;
							vecs[n] = pos3;
						}
						else
						{
							baseScript.OQCCDQOQOO(ref pos3);
						}
						if (n > 0)
						{
							if (tmpMarkersExt[l - 1].randomMinYPosition != 0f || tmpMarkersExt[l - 1].randomMaxYPosition != 0f || tmpMarkersExt[l - 1].randomMinRotation != 0f || tmpMarkersExt[l - 1].randomMaxRotation != 0f || (rt != null && rt.maxTerrainHeightOffset != 0f))
							{
								num38 += Vector3.Distance(vecs[n - 1], vecs[n]);
								RoadSmoothness(totalDistance + num38, tmpMarkersExt[l - 1], num18, ref randomYDistanceStart, ref randomYDistanceEnd, ref randomYDistanceMiddle, ref randomYDistanceV, ref pos3, ref currentRandomYDistance, ref randomRotationStart, ref randomRotationEnd, ref randomRotationMiddle, ref randomRotationV, ref currentRandomRotation, ref rotationArray, ref randomLeftTerrainHeightOffset, ref currentRandomLeftTerrainHeightOffset, ref randomLeftTerrainHeightDistanceStart, ref randomLeftTerrainHeightDistanceMiddle, ref randomLeftTerrainHeightDistanceEnd, ref randomLeftTerrainHeightOffsetValuePrev, ref randomLeftTerrainHeightOffsetValue, ref randomRightTerrainHeightOffset, ref currentRandomRightTerrainHeightOffset, ref randomRightTerrainHeightDistanceStart, ref randomRightTerrainHeightDistanceMiddle, ref randomRightTerrainHeightDistanceEnd, ref randomRightTerrainHeightOffsetValuePrev, ref randomRightTerrainHeightOffsetValue);
							}
							else
							{
								rotationArray.Add(0f);
								randomLeftTerrainHeightOffset.Add(0f);
								randomRightTerrainHeightOffset.Add(0f);
							}
						}
						else
						{
							rotationArray.Add(0f);
							randomLeftTerrainHeightOffset.Add(0f);
							randomRightTerrainHeightOffset.Add(0f);
						}
						vecs[n] = pos3;
					}
					if (list3.Count > 0)
					{
						if (list3[list3.Count - 1] > 1f)
						{
							list3[list3.Count - 1] = 1f;
							vecs[vecs.Count - 1] = array[l + 1];
						}
						else if (vecs[vecs.Count - 1] != array[l + 1])
						{
							if (Vector3.Distance(vecs[vecs.Count - 1], array[l + 1]) < 0.5f * num25)
							{
								vecs[vecs.Count - 1] = array[l + 1];
								list3[list3.Count - 1] = 1f;
							}
							else
							{
								vecs.Add(array[l + 1]);
								totalDist += Vector3.Distance(vecs[vecs.Count - 1], array[l + 1]);
								list3.Add(1f);
								rotationArray.Add(0f);
								randomLeftTerrainHeightOffset.Add(0f);
								randomRightTerrainHeightOffset.Add(0f);
							}
						}
					}
					else
					{
						vecs.Add(array[l + 1]);
						totalDist += Vector3.Distance(array[l], array[l + 1]);
						list3.Add(1f);
						rotationArray.Add(0f);
						randomLeftTerrainHeightOffset.Add(0f);
						randomRightTerrainHeightOffset.Add(0f);
					}
					num13 += vecs.Count;
					v3 = vecs[vecs.Count - 1];
					if (vecs.Count >= 2)
					{
						circleDir = (vecs[vecs.Count - 2] - vecs[vecs.Count - 1]).normalized;
					}
					totalDistance += totalDist;
					nodeSplinePoint.Add(num13);
					b = v3;
					b.y = 0f;
					float num39 = 0f;
					if (list.Count > 0)
					{
						num39 = (float)list.Count - (float)markersExt[l - 2].startSplinePoint;
						float num40 = markerDistances[markerDistances.Count - 1];
						if (markerDistances.Count > 1)
						{
							num40 -= markerDistances[markerDistances.Count - 2];
						}
						Vector3 normalized5 = (list[list.Count - 1] - vecs[0]).normalized;
						Vector3 vector13 = list[list.Count - 1];
						float num41 = num40 / num39 * 1f;
						Vector3 b2 = list[list.Count - 1];
						float num42 = 0f;
						num26 = list.Count;
						for (int num43 = 1; (float)num43 <= num39; num43++)
						{
							if (num26 - 1 - num43 >= 0)
							{
								vector13 += normalized5 * num41;
								Vector3 vector14 = list[list.Count - 1 - num43];
								num42 += Vector3.Distance(vector14, b2);
								float f = num42 / num40;
								vector14.y = Mathf.Lerp(vector13.y, vector14.y, Mathf.Sqrt(f));
								list[list.Count - 1 - num43] = vector14;
								b2 = vector14;
							}
						}
					}
					num15 = 3;
				}
				else if (tmpMarkersExt[l - 1].controlType == 4)
				{
					vecs = tmpMarkersExt[l - 1].customPoints;
					totalDist = 0f;
					List<float> list5 = new List<float>();
					list5.Add(0f);
					for (int num44 = 1; num44 < vecs.Count; num44++)
					{
						totalDist += Vector3.Distance(vecs[num44 - 1], vecs[num44]);
						list5.Add(totalDist);
					}
					totalDistance += totalDist;
					list3.Add(0f);
					rotationArray.Add(0f);
					randomLeftTerrainHeightOffset.Add(0f);
					randomRightTerrainHeightOffset.Add(0f);
					for (int num45 = 0; num45 < vecs.Count; num45++)
					{
						list3.Add(list5[num45] / totalDist);
						rotationArray.Add(0f);
						randomRightTerrainHeightOffset.Add(0f);
					}
					num15 = 4;
				}
				if (tmpMarkersExt[l - 1].followTerrainContours)
				{
					OQOCQDQODD.ODODCDOCDC(baseScript, ref vecs, list3, terrainContoursOffset, ref lastHeightAdjustCP, num20, totalDist, tmpMarkersExt[l].followTerrainContours, list, ref testPoints, ref rotationArray);
				}
				list.AddRange(vecs);
				tValues.AddRange(list3);
				OQCCOOOODQ(tmpMarkersExt, l, array, circleDir, totalDist, ref startCP, 0, list);
				if (array.Length > l + 3)
				{
					OQOCDDOQDC(tmpMarkersExt, l, array, ref endCP2, 0);
				}
				markerDistances.Add(totalDistance);
				try
				{
					if (markersExt.Count > l)
					{
						markersExt[l].direction = (markersExt[l].direction1 = (list[list.Count - 1] - list[list.Count - 2]).normalized);
					}
					if (l > 1 && markersExt.Count > l && list.Count > markersExt[l - 1].startSplinePoint + 1 && markersExt[l - 1].controlType != 3)
					{
						Vector3 vector15 = list[markersExt[l - 1].startSplinePoint + 1];
						Vector3 vector16 = list[markersExt[l - 1].startSplinePoint];
						markersExt[l - 1].direction = (vector15 - vector16).normalized;
						if (l != markersExt.Count)
						{
							vector15.y = vector16.y;
						}
						markersExt[l - 1].direction1 = (vector15 - vector16).normalized;
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
				if (l == 1)
				{
					try
					{
						markersExt[l - 1].direction = (markersExt[l - 1].direction1 = (list[1] - list[0]).normalized);
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
				if (markersExt.Count > l)
				{
					markersExt[l].oldPosition = markersExt[l].position;
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
					Vector3 vector11 = new Vector3(0f, Mathf.Abs(markersExt[markersExt.Count - 2].position.y - markersExt[markersExt.Count - 1].position.y), xzDistance);
					float num30 = 90f - Vector3.Angle(vector11, to);
					if (num30 > 10f)
					{
						markersExt[markersExt.Count - 2].angleString = Mathf.Round(num30).ToString();
					}
					else
					{
						markersExt[markersExt.Count - 2].angleString = num30.ToString("N2");
					}
					markersExt[markersExt.Count - 2].slopeAngle = num30;
					float num46 = Mathf.Abs(markersExt[markersExt.Count - 2].position.y - markersExt[markersExt.Count - 1].position.y);
					float num47 = Vector3.Distance(new Vector3(markersExt[markersExt.Count - 2].position.x, 0f, markersExt[markersExt.Count - 2].position.z), new Vector3(markersExt[markersExt.Count - 1].position.x, 0f, markersExt[markersExt.Count - 1].position.z));
					markersExt[markersExt.Count - 2].gradeString = (num46 / num47 * 100f).ToString("N2");
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
					Vector3 vector11 = new Vector3(0f, Mathf.Abs(markersExt[markersExt.Count - 1].position.y - markersExt[0].position.y), xzDistance);
					float num30 = 90f - Vector3.Angle(vector11, to);
					if (num30 > 10f)
					{
						markersExt[markersExt.Count - 1].angleString = Mathf.Round(num30).ToString();
					}
					else
					{
						markersExt[markersExt.Count - 1].angleString = num30.ToString("N2");
					}
					markersExt[markersExt.Count - 1].slopeAngle = num30;
					float num48 = Mathf.Abs(markersExt[markersExt.Count - 2].position.y - markersExt[markersExt.Count - 1].position.y);
					float num49 = Vector3.Distance(new Vector3(markersExt[markersExt.Count - 2].position.x, 0f, markersExt[markersExt.Count - 2].position.z), new Vector3(markersExt[markersExt.Count - 1].position.x, 0f, markersExt[markersExt.Count - 1].position.z));
					markersExt[markersExt.Count - 1].gradeString = (num48 / num49 * 100f).ToString("N2");
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
			if (startPrefabScript != null && startPrefabScript.isERCrossingExt)
			{
				Vector3 b3 = startPrefabScript.transform.TransformPoint(startPrefabScript.crossingElements[startConnectionSegment].centerPoint);
				bool flag13 = false;
				int num50;
				for (num50 = 0; num50 < list.Count - 1; num50++)
				{
					float num51 = Vector3.Distance(list[num50], b3);
					float num52 = Vector3.Distance(list[num50], list[num50 + 1]);
					if (num51 < num52)
					{
						flag13 = true;
					}
					list.RemoveAt(num50);
					rotationArray.RemoveAt(num50);
					tValues.RemoveAt(num50);
					randomLeftTerrainHeightOffset.RemoveAt(num50);
					randomRightTerrainHeightOffset.RemoveAt(num50);
					if (flag13)
					{
						break;
					}
					num50--;
				}
			}
			if (endPrefabScript != null && endPrefabScript.isERCrossingExt)
			{
				Vector3 b4 = endPrefabScript.transform.TransformPoint(endPrefabScript.crossingElements[endConnectionSegment].centerPoint);
				bool flag14 = false;
				for (int num53 = list.Count - 1; num53 > 1; num53--)
				{
					float num54 = Vector3.Distance(list[num53], b4);
					float num55 = Vector3.Distance(list[num53], list[num53 - 1]);
					if (num54 < num55)
					{
						flag14 = true;
					}
					list.RemoveAt(num53);
					rotationArray.RemoveAt(num53);
					tValues.RemoveAt(num53);
					randomLeftTerrainHeightOffset.RemoveAt(num53);
					randomRightTerrainHeightOffset.RemoveAt(num53);
					if (flag14)
					{
						break;
					}
				}
			}
			if (flag4)
			{
				Vector3 vB = list[0] + vector * 10f;
				vB.y = list[0].y;
				float num56 = markersExt[0].totalDistance * 0.5f;
				if (num56 > 5f)
				{
					num56 = 5f;
				}
				float num57 = 0f;
				for (int num58 = 1; num58 < list.Count; num58++)
				{
					num57 += Vector3.Distance(list[num58 - 1], list[num58]);
					if (num57 > num56)
					{
						break;
					}
					Vector3 a2 = OQQOCDQCQD.OCOOQOQCDC(list[0], vB, list[num58]);
					a2 = Vector3.Lerp(a2, list[num58], num57 / num56);
					a2.y = list[num58].y;
					list[num58] = a2;
				}
			}
			if (flag5)
			{
				Vector3 vector17 = list[list.Count - 1];
				Vector3 vB2 = vector17 + vector2 * 10f;
				vB2.y = list[0].y;
				float num59 = markersExt[markersExt.Count - 2].totalDistance * 0.5f;
				if (num59 > 5f)
				{
					num59 = 5f;
				}
				float num60 = 0f;
				for (int num61 = list.Count - 2; num61 > 0; num61--)
				{
					num60 += Vector3.Distance(list[num61 + 1], list[num61]);
					if (num60 > num59)
					{
						break;
					}
					Vector3 a3 = OQQOCDQCQD.OCOOQOQCDC(vector17, vB2, list[num61]);
					a3 = Vector3.Lerp(a3, list[num61], num60 / num59);
					a3.y = list[num61].y;
					list[num61] = a3;
				}
			}
			markersExt[0].direction1 = new Vector3(markersExt[0].direction1.x, 0f, markersExt[0].direction1.z).normalized;
			markersExt[markersExt.Count - 1].direction1 = new Vector3(markersExt[markersExt.Count - 1].direction1.x, 0f, markersExt[markersExt.Count - 1].direction1.z).normalized;
			int count2 = list.Count;
			if (!closedTrack && faceDist < 6f && count2 > 4)
			{
				if (startPrefabScript == null)
				{
					Vector3 normalized6;
					if (faceDist >= 2f)
					{
						normalized6 = (list[1] - list[2]).normalized;
					}
					else
					{
						normalized6 = (list[2] - list[3]).normalized;
						list[1] = list[2] + normalized6 * Vector3.Distance(list[1], list[2]);
					}
					list[0] = list[1] + normalized6 * Vector3.Distance(list[0], list[1]);
				}
				if (endPrefabScript == null)
				{
					Vector3 normalized7;
					if (faceDist >= 2f)
					{
						normalized7 = (list[count2 - 2] - list[count2 - 3]).normalized;
					}
					else
					{
						normalized7 = (list[count2 - 3] - list[count2 - 4]).normalized;
						list[count2 - 2] = list[count2 - 3] + normalized7 * Vector3.Distance(list[count2 - 2], list[count2 - 3]);
					}
					list[count2 - 1] = list[count2 - 2] + normalized7 * Vector3.Distance(list[count2 - 1], list[count2 - 2]);
				}
			}
			return list;
		}

		public void OQCCOOOODQ(List<ERMarkerExt> tmpMarkers, int j, Vector3[] tr, Vector3 circleDir, float totalDist, ref Vector3 startCP, int startMarker, List<Vector3> p)
		{
			startCP = tr[j];
			if (tmpMarkersExt[startMarker + j - 1].controlType == 1 || tmpMarkersExt[startMarker + j - 1].controlType == 2)
			{
				Vector3 vector = tr[j] - tr[j + 1];
				vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				Vector3 vA = tr[j + 1] + vector * 1500f;
				Vector3 vB = tr[j + 1] + -vector * 1500f;
				Vector3 vector2 = OQQOCDQCQD.OCOOQOQCDC(vA, vB, tr[j + 2]);
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
				float num2 = Vector3.Distance(tmpMarkersExt[startMarker + j - 1].position, tmpMarkersExt[startMarker + j].position);
				Vector3 vector4 = circleDir;
				startCP = tmpMarkersExt[startMarker + j].position + vector4 * num2;
				vector4 = (p[p.Count - 2] - tr[j + 1]).normalized;
			}
		}

		public void OQOCDDOQDC(List<ERMarkerExt> tmpMarkersExt, int j, Vector3[] tr, ref Vector3 endCP, int startMarker)
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
				Vector3 vector = tr[j + 3] - tr[j + 2];
				vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
				Vector3 vA = tr[j + 2] + vector * 1500f;
				Vector3 vB = tr[j + 2] + -vector * 1500f;
				Vector3 vector2 = OQQOCDQCQD.OCOOQOQCDC(vA, vB, tr[j + 1]);
				Vector3 vector3 = tr[j + 1];
				vector3.y = vector2.y;
				float num = Vector3.Distance(vector3, vector2);
				vector = (vector2 - vector3).normalized;
				endCP = vector2 + vector * num;
				endCP.y = tr[j + 1].y;
			}
		}

		public void OCQOCCOQDD(ref Vector3 endCP, Vector3 curV3, Vector3 nextV3, Vector3 nextNextV3)
		{
			Vector3 vector = nextNextV3 - nextV3;
			vector = new Vector3(vector.z, 0f, 0f - vector.x).normalized;
			Vector3 vA = nextV3 + vector * 1500f;
			Vector3 vB = nextV3 + -vector * 1500f;
			Vector3 vector2 = OQQOCDQCQD.OCOOQOQCDC(vA, vB, curV3);
			Vector3 vector3 = curV3;
			vector3.y = vector2.y;
			float num = Vector3.Distance(vector3, vector2);
			vector = (vector2 - vector3).normalized;
			endCP = vector2 + vector * num;
			endCP.y = curV3.y;
		}

		public List<float> ODOCQDOCDD(List<float> tValues, List<float> markerDistances, List<ERMarkerExt> markers, int startMarker, int endMarker, ref List<float> ODCODQCCDQ, List<float> randomRotations)
		{
			List<float> list = new List<float>();
			List<Vector3> list2 = new List<Vector3>();
			List<float> list3 = new List<float>();
			List<float> list4 = new List<float>();
			markerInts.Clear();
			bridgeElement.Clear();
			for (int i = startMarker; i < endMarker; i++)
			{
				if (tmpMarkersExt[i].rotation == 0f && (tmpMarkersExt[i].slopeAngle > 8f || (i > 0 && tmpMarkersExt[i - 1].slopeAngle > 8f) || (i < endMarker - 1 && tmpMarkersExt[i + 1].slopeAngle > 8f)))
				{
					list.Add(0.001f);
				}
				else
				{
					list.Add(tmpMarkersExt[i].rotation);
				}
				list3.Add(tmpMarkersExt[i].rotationCenter);
			}
			list.Insert(0, list[0]);
			list.Add(list[list.Count - 1]);
			list3.Insert(0, list3[0]);
			list3.Add(list3[list3.Count - 1]);
			List<float> list5 = new List<float>();
			ODCODQCCDQ.Clear();
			int num = -1;
			int num2 = -1;
			int num3 = 0;
			if (soSectionList1.Count > 0)
			{
				num = soSectionList1[num3].startSplinePoint;
				num2 = soSectionList1[num3].endSplinePoint;
			}
			int num4 = -1;
			int num5 = -1;
			int num6 = 0;
			if (soSectionList2.Count > 0)
			{
				num4 = soSectionList2[num6].startSplinePoint;
				num5 = soSectionList2[num6].endSplinePoint;
			}
			int num7 = 0;
			int num8 = 1;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			while (num8 < list.Count - 2)
			{
				while (!flag)
				{
					flag2 = false;
					try
					{
						if (!flag)
						{
							flag2 = tmpMarkersExt[num8 - 1].bridgeObject;
							if (num7 > num && num7 <= num2)
							{
								flag2 = true;
							}
							if (num7 >= num4 && num7 < num5)
							{
								flag2 = true;
							}
							bridgeElement.Add(flag2);
						}
						else
						{
							flag2 = tmpMarkersExt[num8].bridgeObject;
							if (num7 > num && num7 <= num2)
							{
								flag2 = true;
							}
							if (num7 >= num4 && num7 < num5)
							{
								flag2 = true;
							}
							bridgeElement.Add(flag2);
						}
					}
					catch
					{
						Debug.Log(num8 + " " + tmpMarkersExt.Count);
					}
					if (num7 < tValues.Count)
					{
						float num9 = Mathf.Lerp(list[num8], list[num8 + 1], Mathf.SmoothStep(0f, 1f, tValues[num7]));
						float item = Mathf.Lerp(list3[num8], list3[num8 + 1], Mathf.SmoothStep(0f, 1f, tValues[num7]));
						if (flag2)
						{
							randomRotations[num7] = 0f;
						}
						if (randomRotations.Count > num7)
						{
							list5.Add(num9 + randomRotations[num7]);
						}
						else
						{
							list5.Add(num9);
						}
						ODCODQCCDQ.Add(item);
						if (num7 + 1 < tValues.Count)
						{
							if (tValues[num7 + 1] <= tValues[num7])
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
						num7++;
					}
					else
					{
						flag = true;
					}
					flag2 = false;
					try
					{
						if (!flag)
						{
							markerInts.Add(num8 - 1);
						}
						else
						{
							markerInts.Add(num8);
						}
					}
					catch
					{
						Debug.Log(num8 + " " + tmpMarkersExt.Count);
					}
					if (num7 == num2)
					{
						num3++;
						if (soSectionList1.Count > num3)
						{
							num = soSectionList1[num3].startSplinePoint;
							num2 = soSectionList1[num3].endSplinePoint;
						}
						else
						{
							num = -1;
							num2 = -1;
						}
					}
					if (num7 == num5)
					{
						num6++;
						if (soSectionList2.Count > num6)
						{
							num4 = soSectionList2[num6].startSplinePoint;
							num5 = soSectionList2[num6].endSplinePoint;
						}
						else
						{
							num4 = -1;
							num5 = -1;
						}
					}
				}
				flag = false;
				num8++;
				flag3 = flag2;
				if (list[num8] == 360f && list[num8 + 1] < 360f)
				{
					list[num8] = 0f;
				}
				else if (list[num8] == -360f && list[num8 + 1] > -360f)
				{
					list[num8] = 0f;
				}
			}
			return list5;
		}

		public void RoadSmoothness(float curDist, ERMarkerExt marker, float totalDistance, ref float randomYDistanceStart, ref float randomYDistanceEnd, ref float randomYDistanceMiddle, ref Vector3 randomYDistanceV3, ref Vector3 v, ref float currentRandomYDistance, ref float randomRotationStart, ref float randomRotationEnd, ref float randomRotationMiddle, ref Vector3 randomRotationV3, ref float currentRandomRotation, ref List<float> rotationArray, ref List<float> leftTerrainHeightOffset, ref float currentRandomLeftTerrainHeightOffset, ref float randomLeftTerrainHeightDistanceStart, ref float randomLeftTerrainHeightDistanceMiddle, ref float randomLeftTerrainHeightDistanceEnd, ref float randomLeftTerrainHeightOffsetValuePrev, ref float randomLeftTerrainHeightOffsetValue, ref List<float> rightTerrainHeightOffset, ref float currentRandomRightTerrainHeightOffset, ref float randomRightTerrainHeightDistanceStart, ref float randomRightTerrainHeightDistanceMiddle, ref float randomRightTerrainHeightDistanceEnd, ref float randomRightTerrainHeightOffsetValuePrev, ref float randomRightTerrainHeightOffsetValue)
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
					float num3 = UnityEngine.Random.Range(marker.minRandomRotationDistance, marker.maxRandomRotationDistance);
					randomRotationEnd += num3;
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
					float num4 = 0f;
					if (curDist < randomRotationMiddle)
					{
						num4 = (curDist - randomRotationStart) / (randomRotationMiddle - randomRotationStart);
						currentRandomRotation = Mathf.Lerp(0f, randomRotationV3.x, Mathf.SmoothStep(0f, 1f, num4));
					}
					else
					{
						num4 = (curDist - randomRotationMiddle) / (randomRotationEnd - randomRotationMiddle);
						currentRandomRotation = Mathf.Lerp(randomRotationV3.x, 0f, Mathf.SmoothStep(0f, 1f, num4));
					}
				}
			}
			rotationArray.Add(currentRandomRotation);
			currentRandomLeftTerrainHeightOffset = 0f;
			if (rt != null)
			{
				_ = rt.maxTerrainHeightOffset;
				if (rt.maxTerrainHeightOffset != 0f && (rt.minTerrainHeightDistance != 0f || rt.maxTerrainHeightDistance != 0f))
				{
					if (curDist >= randomLeftTerrainHeightDistanceEnd)
					{
						if (rt.maxTerrainHeightDistance == 0f)
						{
							rt.maxTerrainHeightDistance = 15f;
						}
						randomLeftTerrainHeightOffsetValuePrev = randomLeftTerrainHeightOffsetValue;
						randomLeftTerrainHeightDistanceStart = (randomLeftTerrainHeightDistanceEnd = curDist);
						float num5 = UnityEngine.Random.Range(rt.minTerrainHeightDistance, rt.maxTerrainHeightDistance);
						randomLeftTerrainHeightDistanceEnd += num5;
						randomLeftTerrainHeightDistanceMiddle = Mathf.Lerp(randomLeftTerrainHeightDistanceStart, randomLeftTerrainHeightDistanceEnd, 0.5f);
						randomLeftTerrainHeightOffsetValue = UnityEngine.Random.Range(0f, rt.maxTerrainHeightOffset);
						if (randomLeftTerrainHeightDistanceEnd > totalDistance)
						{
							randomLeftTerrainHeightDistanceEnd = totalDistance;
							if (randomLeftTerrainHeightDistanceEnd - randomLeftTerrainHeightDistanceStart < marker.minRandomRotationDistance)
							{
								randomLeftTerrainHeightOffsetValue = 0f;
							}
						}
						if (randomLeftTerrainHeightDistanceMiddle > totalDistance)
						{
							randomLeftTerrainHeightDistanceMiddle = Mathf.Lerp(randomLeftTerrainHeightDistanceStart, randomLeftTerrainHeightDistanceEnd, 0.5f);
						}
					}
					if (randomLeftTerrainHeightOffsetValue != 0f)
					{
						float num6 = 0f;
						if (curDist < randomLeftTerrainHeightDistanceEnd)
						{
							num6 = (curDist - randomLeftTerrainHeightDistanceStart) / (randomLeftTerrainHeightDistanceEnd - randomLeftTerrainHeightDistanceStart);
							currentRandomLeftTerrainHeightOffset = Mathf.Lerp(randomLeftTerrainHeightOffsetValuePrev, randomLeftTerrainHeightOffsetValue, Mathf.SmoothStep(0f, 1f, num6));
						}
					}
				}
			}
			leftTerrainHeightOffset.Add(currentRandomLeftTerrainHeightOffset);
			currentRandomRightTerrainHeightOffset = 0f;
			if (rt != null)
			{
				_ = rt.maxTerrainHeightOffset;
				if (rt.maxTerrainHeightOffset != 0f && (rt.minTerrainHeightDistance != 0f || rt.maxTerrainHeightDistance != 0f))
				{
					if (curDist >= randomRightTerrainHeightDistanceEnd)
					{
						if (rt.maxTerrainHeightDistance == 0f)
						{
							rt.maxTerrainHeightDistance = 25f;
						}
						randomRightTerrainHeightOffsetValuePrev = randomRightTerrainHeightOffsetValue;
						randomRightTerrainHeightDistanceStart = (randomRightTerrainHeightDistanceEnd = curDist);
						float num7 = UnityEngine.Random.Range(rt.minTerrainHeightDistance, rt.maxTerrainHeightDistance);
						randomRightTerrainHeightDistanceEnd += num7;
						randomRightTerrainHeightDistanceMiddle = Mathf.Lerp(randomRightTerrainHeightDistanceStart, randomRightTerrainHeightDistanceEnd, 0.5f);
						randomRightTerrainHeightOffsetValue = UnityEngine.Random.Range(0f, rt.maxTerrainHeightOffset);
						if (randomRightTerrainHeightDistanceEnd > totalDistance)
						{
							randomRightTerrainHeightDistanceEnd = totalDistance;
							if (randomRightTerrainHeightDistanceEnd - randomRightTerrainHeightDistanceStart < marker.minRandomRotationDistance)
							{
								randomRightTerrainHeightOffsetValue = 0f;
							}
						}
						if (randomRightTerrainHeightDistanceMiddle > totalDistance)
						{
							randomRightTerrainHeightDistanceMiddle = Mathf.Lerp(randomRightTerrainHeightDistanceStart, randomRightTerrainHeightDistanceEnd, 0.5f);
						}
					}
					if (randomRightTerrainHeightOffsetValue != 0f)
					{
						float num8 = 0f;
						if (curDist < randomRightTerrainHeightDistanceEnd)
						{
							num8 = (curDist - randomRightTerrainHeightDistanceStart) / (randomRightTerrainHeightDistanceEnd - randomRightTerrainHeightDistanceStart);
							currentRandomRightTerrainHeightOffset = Mathf.Lerp(randomRightTerrainHeightOffsetValuePrev, randomRightTerrainHeightOffsetValue, Mathf.SmoothStep(0f, 1f, num8));
						}
					}
				}
			}
			rightTerrainHeightOffset.Add(currentRandomRightTerrainHeightOffset);
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
			if (markerDistances.Count < endMarker)
			{
				for (int j = markerDistances.Count; j < endMarker; j++)
				{
					markerDistances.Add(0f);
				}
			}
			int count = roadShape.Count;
			for (int k = startMarker; k < endMarker; k++)
			{
				list4.Add(tmpMarkersExt[k].roadShapeDistanceMin);
				list5.Add(tmpMarkersExt[k].roadShapeDistanceMax);
				if (tmpMarkersExt[k].roadShape.Count != count)
				{
					tmpMarkersExt[k].roadShape = new List<Vector2>(roadShape);
				}
				for (int l = 0; l < roadShape.Count; l++)
				{
					Vector3 item = new Vector3(markerDistances[k - startMarker], tmpMarkersExt[k].roadShape[l].x, 0f);
					list2[l].Add(item);
					item = new Vector3(markerDistances[k - startMarker], tmpMarkersExt[k].roadShape[l].y, 0f);
					list3[l].Add(item);
					if (tmpMarkersExt[k].roadShape[l] != roadShape[l])
					{
						flag = true;
					}
				}
				tmpMarkersExt[k].roadShapeVecsGlobal.Clear();
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
						float t;
						if (tValues[num] < list4[num2])
						{
							t = 0f;
						}
						else if (tValues[num] < list5[num2])
						{
							t = tValues[num] - list4[num2];
							t /= list5[num2] - list4[num2];
						}
						else
						{
							t = 1f;
						}
						for (int num3 = 0; num3 < roadShape.Count; num3++)
						{
							Vector3 vector;
							Vector3 vector2;
							if (list2[num3][num2] != list2[num3][num2 + 1] || list3[num3][num2] != list3[num3][num2 + 1])
							{
								vector = OQQCQOQOOD(list2[num3][num2 - 1], list2[num3][num2], list2[num3][num2 + 1], list2[num3][num2 + 2], t, 0.5f);
								vector2 = OQQCQOQOOD(list3[num3][num2 - 1], list3[num3][num2], list3[num3][num2 + 1], list3[num3][num2 + 2], t, 0.5f);
							}
							else
							{
								vector = list2[num3][num2];
								vector2 = list3[num3][num2];
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
			float num3 = 0f;
			float num4 = 0f;
			if (leftSidewalkActive)
			{
				if (leftSidewalks.Count > 0 && leftSidewalks[0] != null && leftSidewalks[0].sidewalk != null)
				{
					num3 = leftSidewalks[0].sidewalk.sidewalkWidth;
				}
				else if (leftSidewalks.Count == 0 && defaultLeftSidewalkid != 0.0)
				{
					ERSideWalk sidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, defaultLeftSidewalkid);
					if (sidewalk != null)
					{
						num3 = sidewalk.sidewalkWidth;
					}
				}
			}
			if (rightSidewalkActive)
			{
				if (rightSidewalks.Count > 0 && rightSidewalks[0] != null && rightSidewalks[0].sidewalk != null)
				{
					num4 = rightSidewalks[0].sidewalk.sidewalkWidth;
				}
				else if (rightSidewalks.Count == 0 && defaultRightSidewalkid != 0.0)
				{
					ERSideWalk sidewalk2 = ERSideWalk.GetSidewalk(baseScript.sidewalks, defaultRightSidewalkid);
					if (sidewalk2 != null)
					{
						num4 = sidewalk2.sidewalkWidth;
					}
				}
			}
			float minIndent = indent;
			if (minIndent < baseScript.minIndent)
			{
				minIndent = baseScript.minIndent;
			}
			float minSurrounding = surrounding;
			if (float.IsNaN(minSurrounding))
			{
				minSurrounding = baseScript.minSurrounding;
			}
			for (int i = startMarker; i < endMarker; i++)
			{
				if (float.IsNaN(tmpMarkersExt[i].leftIndent))
				{
					tmpMarkersExt[i].leftIndent = minIndent;
				}
				if (float.IsNaN(tmpMarkersExt[i].rightIndent))
				{
					tmpMarkersExt[i].rightIndent = minIndent;
				}
				if (float.IsNaN(tmpMarkersExt[i].leftSurrounding))
				{
					tmpMarkersExt[i].leftSurrounding = minSurrounding;
				}
				if (float.IsNaN(tmpMarkersExt[i].rightSurrounding))
				{
					tmpMarkersExt[i].rightSurrounding = minSurrounding;
				}
				num = tmpMarkersExt[i].leftIndent + num3;
				num2 = tmpMarkersExt[i].rightIndent + num4;
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
			int num5 = 0;
			int j = 1;
			bool flag = false;
			for (; j < list2.Count - 2; j++)
			{
				while (!flag)
				{
					if (num5 < tValues.Count)
					{
						Vector3 vector = OQQCQOQOOD(list2[j - 1], list2[j], list2[j + 1], list2[j + 2], tValues[num5], 0.5f);
						leftIndents.Add(vector.y);
						vector = OQQCQOQOOD(list3[j - 1], list3[j], list3[j + 1], list3[j + 2], tValues[num5], 0.5f);
						rightIndents.Add(vector.y);
						vector = OQQCQOQOOD(list4[j - 1], list4[j], list4[j + 1], list4[j + 2], tValues[num5], 0.5f);
						if (list4[j].y < list4[j + 1].y)
						{
							if (vector.y < list4[j].y)
							{
								vector.y = list4[j].y;
							}
						}
						else if (vector.y < list4[j + 1].y)
						{
							vector.y = list4[j + 1].y;
						}
						leftSurrounding.Add(vector.y);
						vector = OQQCQOQOOD(list5[j - 1], list5[j], list5[j + 1], list5[j + 2], tValues[num5], 0.5f);
						if (list5[j].y < list5[j + 1].y)
						{
							if (vector.y < list5[j].y)
							{
								vector.y = list5[j].y;
							}
						}
						else if (vector.y < list5[j + 1].y)
						{
							vector.y = list5[j + 1].y;
						}
						rightSurrounding.Add(vector.y);
						if (num5 + 1 < tValues.Count)
						{
							if (tValues[num5 + 1] <= tValues[num5])
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
						num5++;
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

		public List<Vector3> OCCQCCOOCO(ref List<Vector3> positions, ref List<Vector3> perpPositions, ref List<int> middleIndexes, ref List<float> distances)
		{
			if (leftSidewalkActive)
			{
				List<Vector3> result = new List<Vector3>();
				if (leftSidewalks.Count == 0 && defaultLeftSidewalkid != 0.0)
				{
					ERSideWalk sidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, defaultLeftSidewalkid);
					if (sidewalk != null)
					{
						leftSidewalks.Add(new ERSideWalkInstance(sidewalk, 0f, 1f, soSplinePoints[0], soSplinePoints[soSplinePoints.Count - 1], this, " [Left]"));
					}
				}
				foreach (ERSideWalkInstance leftSidewalk in leftSidewalks)
				{
					foreach (ERSideWalk sidewalk3 in baseScript.sidewalks)
					{
						if (leftSidewalk.id == sidewalk3.id)
						{
							if (leftSidewalk.sidewalk != sidewalk3)
							{
								leftSidewalk.sidewalk = sidewalk3;
							}
							if (leftSidewalk.swObject != null && leftSidewalk.swObject.GetComponent<MeshRenderer>() == null)
							{
								leftSidewalk.swObject.AddComponent<MeshRenderer>();
							}
							if (leftSidewalk.swObject != null)
							{
								leftSidewalk.swObject.GetComponent<MeshRenderer>().sharedMaterial = leftSidewalk.sidewalk.material;
							}
							break;
						}
					}
					ERSideWalk sidewalk2 = leftSidewalk.sidewalk;
					if (leftSidewalk.swObject == null)
					{
						leftSidewalk.GetObject(this, " [Left]");
					}
					bool closedStart = true;
					if (startPrefabScript != null)
					{
						if (startPrefabScript.isFlexConnector && startPrefabScript.siblings[startConnectionSegment].rightSidewalkActive)
						{
							closedStart = false;
						}
						else if (startPrefabScript.isRoundabout && startPrefabScript.roundaboutScript.connections[startConnectionSegment].rightSidewalkActive)
						{
							closedStart = false;
						}
					}
					bool closedEnd = true;
					if (endPrefabScript != null)
					{
						if (endPrefabScript.isFlexConnector && endPrefabScript.siblings[endConnectionSegment].leftSidewalkActive)
						{
							closedEnd = false;
						}
						else if (endPrefabScript.isRoundabout && endPrefabScript.roundaboutScript.connections[endConnectionSegment].leftSidewalkActive)
						{
							closedStart = false;
						}
					}
					rt = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType, clone: true);
					if (rt != null)
					{
						result = ERSideWalkVecs.OCOCDCDDOD(this, sidewalk2, sidewalk2.shape, sidewalk2.doConnectionTri, sidewalk2.sidewalkUVs, soSplinePointsLeft, soSplinePointsRight, -1, leftSidewalk.swObject, 0f - rt.roadShapeData.leftSidewalkOffset, closedStart, closedEnd, ref positions, ref perpPositions, ref middleIndexes, ref distances);
					}
				}
				return result;
			}
			if (leftSidewalks.Count > 0)
			{
				leftSidewalks.Clear();
			}
			return null;
		}

		public List<Vector3> OQDQCQQDCD(ref List<Vector3> positions, ref List<Vector3> perpPositions, ref List<int> middleIndexes, ref List<float> distances)
		{
			if (rightSidewalkActive)
			{
				List<Vector3> result = null;
				if (rightSidewalks.Count == 0 && defaultRightSidewalkid != 0.0)
				{
					ERSideWalk sidewalk = ERSideWalk.GetSidewalk(baseScript.sidewalks, defaultRightSidewalkid);
					if (sidewalk != null)
					{
						rightSidewalks.Add(new ERSideWalkInstance(sidewalk, 0f, 1f, soSplinePoints[0], soSplinePoints[soSplinePoints.Count - 1], this, " [Right]"));
					}
				}
				foreach (ERSideWalkInstance rightSidewalk in rightSidewalks)
				{
					foreach (ERSideWalk sidewalk3 in baseScript.sidewalks)
					{
						if (rightSidewalk.id == sidewalk3.id)
						{
							if (rightSidewalk.sidewalk != sidewalk3)
							{
								rightSidewalk.sidewalk = sidewalk3;
							}
							if (rightSidewalk.swObject != null && rightSidewalk.swObject.GetComponent<MeshRenderer>() == null)
							{
								rightSidewalk.swObject.AddComponent<MeshRenderer>();
							}
							if (rightSidewalk.swObject != null)
							{
								rightSidewalk.swObject.GetComponent<MeshRenderer>().sharedMaterial = rightSidewalk.sidewalk.material;
							}
							break;
						}
					}
					ERSideWalk sidewalk2 = rightSidewalk.sidewalk;
					if (rightSidewalk.swObject == null)
					{
						rightSidewalk.GetObject(this, " [Right]");
					}
					bool closedStart = true;
					if (startPrefabScript != null)
					{
						if (startPrefabScript.isFlexConnector && startPrefabScript.siblings[startConnectionSegment].leftSidewalkActive)
						{
							closedStart = false;
						}
						else if (startPrefabScript.isRoundabout && startPrefabScript.roundaboutScript.connections[startConnectionSegment].leftSidewalkActive)
						{
							closedStart = false;
						}
					}
					bool closedEnd = true;
					if (endPrefabScript != null)
					{
						if (endPrefabScript.isFlexConnector && endPrefabScript.siblings[endConnectionSegment].rightSidewalkActive)
						{
							closedEnd = false;
						}
						else if (endPrefabScript.isRoundabout && endPrefabScript.roundaboutScript.connections[endConnectionSegment].rightSidewalkActive)
						{
							closedEnd = false;
						}
					}
					rt = QDQDOOQQDQODD.GetRoadTypeElByID(baseScript.roadTypes, roadType, clone: true);
					if (rt != null)
					{
						result = ERSideWalkVecs.OCOCDCDDOD(this, sidewalk2, sidewalk2.shape, sidewalk2.doConnectionTri, sidewalk2.sidewalkUVs, soSplinePointsRight, soSplinePointsLeft, 1, rightSidewalk.swObject, 0f - rt.roadShapeData.rightSidewalkOffset, closedStart, closedEnd, ref positions, ref perpPositions, ref middleIndexes, ref distances);
					}
				}
				return result;
			}
			if (rightSidewalks.Count > 0)
			{
				rightSidewalks.Clear();
			}
			return null;
		}

		public bool OQQCODOQCC(SideObject obj, bool flag, bool doCheck = true)
		{
			foreach (ERSORoadExt item in soDataExt)
			{
				if (!(item != null) || !(item.sideObject == obj))
				{
					continue;
				}
				if (item.active == flag)
				{
					break;
				}
				item.active = flag;
				OCQODDCQDD.OODOQDDOCQ(baseScript, this, obj);
				if (flag)
				{
					OCQODDCQDD.OQDCQDCQDD(this, obj, item.markerActive);
					OCQODDCQDD.OOOQQQOOQC(baseScript, this, obj, updateSideObjectsOnOtherRoadObjects: false);
					if (!obj.dualSided)
					{
					}
				}
				else
				{
					bool terrainSurfaceFlag = false;
					OCQODDCQDD.ODDODQOOCC(this, obj, ref terrainSurfaceFlag);
				}
				return true;
			}
			if (doCheck && soDataExt.Count != baseScript.QOQDQOOQDDQOOQ.Count)
			{
				OCDOODOQDC.AssignSideObjects(baseScript, this);
				if (OQQCODOQCC(obj, flag, doCheck: false))
				{
					return true;
				}
			}
			return false;
		}

		public bool OQOOCDDQCQ(SideObject obj, int marker, bool flag, ERRoadSide roadSide)
		{
			if (marker >= 0 && marker < markersExt.Count)
			{
				SideObjectSide sideObjectSide = SideObjectSide.DefaultSide;
				if (roadSide != ERRoadSide.Both)
				{
					sideObjectSide = (((obj.relativeTo != 1 || roadSide != ERRoadSide.Left) && (obj.relativeTo != 2 || roadSide != ERRoadSide.Right)) ? SideObjectSide.OtherSide : SideObjectSide.DefaultSide);
				}
				bool flag2 = false;
				foreach (ERSOMarkerExt soDatum in markersExt[marker].soData)
				{
					if (!(soDatum != null) || !(soDatum.sideObject == obj))
					{
						continue;
					}
					if (sideObjectSide == SideObjectSide.DefaultSide)
					{
						if (soDatum.active != flag)
						{
							soDatum.active = flag;
							if (soDatum.otherSide != null && roadSide == ERRoadSide.Both)
							{
								soDatum.otherSide.active = flag;
							}
							OCQODDCQDD.OODOQDDOCQ(baseScript, this, obj);
							OCQODDCQDD.OOOQQQOOQC(baseScript, this, obj, updateSideObjectsOnOtherRoadObjects: true);
						}
					}
					else if (soDatum.otherSide != null && soDatum.otherSide.active != flag)
					{
						soDatum.otherSide.active = flag;
						OCQODDCQDD.OODOQDDOCQ(baseScript, this, obj);
						OCQODDCQDD.OOOQQQOOQC(baseScript, this, obj, updateSideObjectsOnOtherRoadObjects: true);
					}
					flag2 = true;
				}
				if (!flag2 && OQQCODOQCC(obj, flag: true))
				{
					OQOOCDDQCQ(obj, marker, flag, roadSide);
				}
			}
			if (obj.bridgeObject)
			{
				markersExt[marker].bridgeObject = flag;
				if (!terrainDeformation)
				{
					markersExt[marker].bridgeObject = false;
				}
				return true;
			}
			return false;
		}

		public bool GetSideObjectActiveState(SideObject obj)
		{
			foreach (ERSORoadExt item in soDataExt)
			{
				if (item != null && item.sideObject == obj)
				{
					return item.active;
				}
			}
			return false;
		}

		public bool GetSideObjectMarkerActiveState(SideObject obj, int marker)
		{
			if (marker >= 0 && marker < markersExt.Count)
			{
				bool flag = false;
				bool flag2 = false;
				foreach (ERSOMarkerExt soDatum in markersExt[marker].soData)
				{
					if (soDatum != null)
					{
						if (soDatum.sideObject == obj)
						{
							flag = true;
						}
						return soDatum.active;
					}
				}
				return false;
			}
			return false;
		}

		public ERRoadSide GetSideObjectMarkerActiveStateSides(SideObject obj, int marker)
		{
			if (marker >= 0 && marker < markersExt.Count)
			{
				if (obj.relativeTo == 0)
				{
					Debug.LogWarning("EasyRoads3Dv3: This side object is aligned relative to the center of the road");
					return ERRoadSide.none;
				}
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				foreach (ERSOMarkerExt soDatum in markersExt[marker].soData)
				{
					if (!(soDatum != null) || !(soDatum.sideObject == obj))
					{
						continue;
					}
					if (obj.relativeTo == 1)
					{
						flag3 = soDatum.active;
						if (soDatum.otherSide != null)
						{
							flag4 = soDatum.otherSide.active;
						}
					}
					else
					{
						flag4 = soDatum.active;
						if (soDatum.otherSide != null)
						{
							flag3 = soDatum.otherSide.active;
						}
					}
					break;
				}
				if (flag3 && flag4)
				{
					return ERRoadSide.Both;
				}
				if (flag3)
				{
					return ERRoadSide.Left;
				}
				if (flag4)
				{
					return ERRoadSide.Right;
				}
				return ERRoadSide.none;
			}
			return ERRoadSide.none;
		}

		public bool ERSetSideObjectOffset(SideObject obj, int marker, OffsetPosition position, float value, ERRoadSide roadSide = ERRoadSide.Both, bool refresh = true)
		{
			bool result = false;
			SideObjectSide sideObjectSide = SideObjectSide.DefaultSide;
			if (roadSide != ERRoadSide.Both)
			{
				sideObjectSide = (((obj.relativeTo != 1 || roadSide != ERRoadSide.Left) && (obj.relativeTo != 2 || roadSide != ERRoadSide.Right)) ? SideObjectSide.OtherSide : SideObjectSide.DefaultSide);
			}
			if (marker >= 0 && marker < markersExt.Count)
			{
				float num = markersExt[marker].totalDistance;
				foreach (ERSOMarkerExt soDatum in markersExt[marker].soData)
				{
					int num2 = 0;
					if (!(soDatum != null))
					{
						continue;
					}
					if (soDatum.sideObject == obj)
					{
						if (position == OffsetPosition.Start)
						{
							if (roadSide == ERRoadSide.Both || sideObjectSide == SideObjectSide.DefaultSide)
							{
								if (OCQODDCQDD.OCQOODCQDO(this, marker, num2) && value > 0f && soDatum.endOffset < 0f && num + soDatum.endOffset < value)
								{
									value = num + soDatum.endOffset - 5f;
								}
								soDatum.startOffset = value;
							}
							if ((soDatum.otherSide != null && roadSide == ERRoadSide.Both) || sideObjectSide == SideObjectSide.OtherSide)
							{
								if (OCQODDCQDD.OCCOCQQOCQ(this, marker, num2) && value > 0f && soDatum.otherSide.endOffset < 0f && num + soDatum.otherSide.endOffset < value)
								{
									value = num + soDatum.otherSide.endOffset - 5f;
								}
								soDatum.otherSide.startOffset = value;
							}
						}
						else
						{
							if (roadSide == ERRoadSide.Both || sideObjectSide == SideObjectSide.DefaultSide)
							{
								if (OCQODDCQDD.OQQOODOODQ(this, marker, num2) && value < 0f && soDatum.startOffset > 0f && num + soDatum.endOffset < Mathf.Abs(value))
								{
									value = (num - soDatum.startOffset - 5f) * -1f;
								}
								soDatum.endOffset = value;
							}
							if ((soDatum.otherSide != null && roadSide == ERRoadSide.Both) || sideObjectSide == SideObjectSide.OtherSide)
							{
								if (OCQODDCQDD.ODOOOOCDOQ(this, marker, num2) && value < 0f && soDatum.otherSide.startOffset > 0f && num + soDatum.otherSide.endOffset < Mathf.Abs(value))
								{
									value = (num - soDatum.otherSide.startOffset - 5f) * -1f;
								}
								soDatum.otherSide.endOffset = value;
							}
						}
						if (refresh)
						{
							OCQODDCQDD.OODOQDDOCQ(baseScript, this, obj);
							OCQODDCQDD.OOOQQQOOQC(baseScript, this, obj, updateSideObjectsOnOtherRoadObjects: true);
						}
						result = true;
						break;
					}
					num2++;
				}
			}
			return result;
		}

		public float ERGetSideObjectOffset(SideObject obj, int marker, OffsetPosition position, ERRoadSide roadSide)
		{
			if (marker >= 0 && marker < markersExt.Count)
			{
				bool flag = false;
				if (!obj.dualSided)
				{
					flag = true;
				}
				bool flag2 = false;
				bool flag3 = false;
				float result = 0f;
				float result2 = 0f;
				float result3 = 0f;
				float result4 = 0f;
				foreach (ERSOMarkerExt soDatum in markersExt[marker].soData)
				{
					if (!(soDatum != null) || !(soDatum.sideObject == obj))
					{
						continue;
					}
					if (flag)
					{
						if (position == OffsetPosition.Start)
						{
							return soDatum.startOffset;
						}
						return soDatum.endOffset;
					}
					if (obj.relativeTo == 1)
					{
						result = soDatum.startOffset;
						result3 = soDatum.endOffset;
						if (soDatum.otherSide != null)
						{
							result2 = soDatum.otherSide.startOffset;
							result4 = soDatum.otherSide.endOffset;
						}
					}
					else
					{
						result2 = soDatum.startOffset;
						result4 = soDatum.endOffset;
						if (soDatum.otherSide != null)
						{
							result = soDatum.otherSide.startOffset;
							result3 = soDatum.otherSide.endOffset;
						}
					}
					break;
				}
				switch (roadSide)
				{
				case ERRoadSide.Left:
					if (position == OffsetPosition.Start)
					{
						return result;
					}
					return result3;
				case ERRoadSide.Right:
					if (position == OffsetPosition.Start)
					{
						return result2;
					}
					return result4;
				}
			}
			return 0f;
		}

		public bool ERSetSideObjectXPosition(SideObject obj, int marker, SideObjectSide side, float value, ERRoadSide roadSide, bool refresh)
		{
			bool result = false;
			if (roadSide != ERRoadSide.Both)
			{
				side = (((obj.relativeTo != 1 || roadSide != ERRoadSide.Left) && (obj.relativeTo != 2 || roadSide != ERRoadSide.Right)) ? SideObjectSide.OtherSide : SideObjectSide.DefaultSide);
			}
			if (marker >= 0 && marker < markersExt.Count)
			{
				foreach (ERSOMarkerExt soDatum in markersExt[marker].soData)
				{
					if (soDatum != null && soDatum.sideObject == obj)
					{
						if (roadSide == ERRoadSide.Both || side == SideObjectSide.DefaultSide)
						{
							soDatum.xPosition = value;
						}
						if ((soDatum.otherSide != null && roadSide == ERRoadSide.Both) || side == SideObjectSide.OtherSide)
						{
							soDatum.otherSide.xPosition = value;
						}
						if (refresh)
						{
							OCQODDCQDD.OODOQDDOCQ(baseScript, this, obj);
							OCQODDCQDD.OOOQQQOOQC(baseScript, this, obj, updateSideObjectsOnOtherRoadObjects: true);
						}
						result = true;
						break;
					}
				}
			}
			return result;
		}

		public float ERGetSideObjectXPosition(SideObject obj, int marker, ERRoadSide roadSide)
		{
			bool flag = false;
			if (!obj.dualSided)
			{
				flag = true;
			}
			if (marker >= 0 && marker < markersExt.Count)
			{
				foreach (ERSOMarkerExt soDatum in markersExt[marker].soData)
				{
					if (!(soDatum != null) || !(soDatum.sideObject == obj))
					{
						continue;
					}
					if (flag)
					{
						return soDatum.xPosition;
					}
					if (obj.relativeTo == 1)
					{
						if (roadSide == ERRoadSide.Left || soDatum.otherSide == null)
						{
							return soDatum.xPosition;
						}
						return soDatum.otherSide.xPosition;
					}
					if (roadSide == ERRoadSide.Right || soDatum.otherSide == null)
					{
						return soDatum.xPosition;
					}
					return soDatum.otherSide.xPosition;
				}
			}
			return 0f;
		}

		public bool OQOOCDDQCQ(SideObject obj, int[] markers, bool flag)
		{
			bool flag2 = false;
			bool result = false;
			bool flag3 = false;
			bool flag4 = false;
			foreach (int num in markers)
			{
				if (num >= 0 && num < markersExt.Count)
				{
					foreach (ERSOMarkerExt soDatum in markersExt[num].soData)
					{
						if (soDatum != null && soDatum.sideObject == obj)
						{
							if (soDatum.active != flag)
							{
								soDatum.active = flag;
								flag2 = true;
							}
							flag3 = true;
							break;
						}
					}
					flag4 = true;
				}
				if (obj.bridgeObject)
				{
					markersExt[num].bridgeObject = flag;
					if (!terrainDeformation)
					{
						markersExt[num].bridgeObject = false;
					}
					result = true;
				}
			}
			if (!flag3 && flag4 && OQQCODOQCC(obj, flag: true))
			{
				OQOOCDDQCQ(obj, markers, flag);
			}
			if (flag2)
			{
				OCQODDCQDD.OODOQDDOCQ(baseScript, this, obj);
				OCQODDCQDD.OOOQQQOOQC(baseScript, this, obj, updateSideObjectsOnOtherRoadObjects: true);
			}
			return result;
		}

		public bool IsSOAutoGenerated(SideObject so, int leftRight, int startEnd)
		{
			if (so.retainingWall && !so.bridgeObject)
			{
				if (leftRight == 0)
				{
					if (startEnd == 0)
					{
						if (soSectionList6.Count > 0 && soSectionList6[0].soid == so.id && soSectionList6[0].startSplinePoint == 0)
						{
							return true;
						}
						return false;
					}
					if (soSectionList6.Count > 0 && soSectionList6[soSectionList6.Count - 1].soid == so.id && soSectionList6[soSectionList6.Count - 1].endSplinePoint == soSplinePoints.Count - 1)
					{
						return true;
					}
					return false;
				}
				if (startEnd == 0)
				{
					if (soSectionList7.Count > 0 && soSectionList7[0].soid == so.id && soSectionList7[0].startSplinePoint == 0)
					{
						return true;
					}
					return false;
				}
				if (soSectionList7.Count > 0 && soSectionList7[soSectionList7.Count - 1].soid == so.id && soSectionList7[soSectionList7.Count - 1].endSplinePoint == soSplinePoints.Count - 1)
				{
					return true;
				}
				return false;
			}
			if (so.bridgeObject)
			{
				if (startEnd == 0)
				{
					if (soSectionList2.Count > 0 && soSectionList2[0].soid == so.id && soSectionList2[0].startSplinePoint <= 1)
					{
						return true;
					}
					return false;
				}
				if (soSectionList2.Count > 0 && soSectionList2[soSectionList2.Count - 1].soid == so.id && soSectionList2[soSectionList2.Count - 1].endSplinePoint == soSplinePoints.Count - 1)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public List<Vector3> OOCCCOOOQC(bool flag)
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

		public void ODDDQOCQDQ()
		{
			List<float> list = new List<float>();
			markerDistances = OOOODCCQOO(flyOverPoints);
		}

		public List<float> OOOODCCQOO(Vector3[] tr)
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
					Vector3 vector2 = OQQCQOQOOD(tr[i - 1], tr[i], tr[i + 1], tr[i + 2], num5, 0.5f);
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

		public Vector3 OOOCQODCOC(float offset)
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
			return OQQCQOQOOD(flyOverPoints[num2 - 1], flyOverPoints[num2], flyOverPoints[num2 + 1], flyOverPoints[num2 + 2], t, 0.5f);
		}

		public static Vector3 OQQCQOQOOD(Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3, float t, float tension)
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

		public Vector3 OCDCCQCCDQ(int startend, ERCrossingPrefabs prefab)
		{
			Vector3 position;
			Vector3 position2;
			Vector3 vector;
			if (startend == 0)
			{
				position = markersExt[0].position;
				position2 = markersExt[1].position;
				vector = ((markersExt.Count <= 2) ? position2 : markersExt[2].position);
			}
			else
			{
				position = markersExt[markersExt.Count - 1].position;
				position2 = markersExt[markersExt.Count - 2].position;
				vector = ((markersExt.Count <= 2) ? position2 : markersExt[markersExt.Count - 3].position);
			}
			Vector3 vector2 = prefab.transform.InverseTransformPoint(position2);
			vector2.y = 0f;
			vector2 = prefab.transform.position;
			Vector3 angleControlPoint = ERConnectionSibling.GetAngleControlPoint(vector2, position, position2, vector);
			return prefab.transform.InverseTransformPoint(angleControlPoint);
		}

		public void OCCOCQCQCO()
		{
			foreach (ERSideWalkInstance leftSidewalk in leftSidewalks)
			{
				if (leftSidewalk.swObject != null)
				{
					UnityEngine.Object.DestroyImmediate(leftSidewalk.swObject);
				}
			}
			foreach (ERSideWalkInstance rightSidewalk in rightSidewalks)
			{
				if (rightSidewalk.swObject != null)
				{
					UnityEngine.Object.DestroyImmediate(rightSidewalk.swObject);
				}
			}
		}

		public void OOQQCDOODC()
		{
			ERSideWalkInstanceScript[] componentsInChildren = base.gameObject.GetComponentsInChildren<ERSideWalkInstanceScript>();
			ERSideWalkInstanceScript[] array = componentsInChildren;
			foreach (ERSideWalkInstanceScript eRSideWalkInstanceScript in array)
			{
				bool flag = false;
				foreach (ERSideWalkInstance leftSidewalk in leftSidewalks)
				{
					if (eRSideWalkInstanceScript.instance == leftSidewalk)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				using (List<ERSideWalkInstance>.Enumerator enumerator2 = rightSidewalks.GetEnumerator())
				{
					if (enumerator2.MoveNext())
					{
						ERSideWalkInstance current2 = enumerator2.Current;
						flag = true;
					}
				}
				if (!flag)
				{
					UnityEngine.Object.DestroyImmediate(eRSideWalkInstanceScript.gameObject);
					Debug.Log("Delete");
				}
			}
		}

		public void CleanUpAllSidewalks()
		{
			ERSideWalkInstanceScript[] componentsInChildren = base.gameObject.GetComponentsInChildren<ERSideWalkInstanceScript>();
			ERSideWalkInstanceScript[] array = componentsInChildren;
			foreach (ERSideWalkInstanceScript eRSideWalkInstanceScript in array)
			{
				UnityEngine.Object.DestroyImmediate(eRSideWalkInstanceScript.gameObject);
			}
			int num = base.transform.childCount - 1;
			for (int num2 = num; num2 >= 0; num2--)
			{
				if (base.transform.GetChild(num2).name.IndexOf("_ERCrosswalk") >= 0)
				{
					UnityEngine.Object.DestroyImmediate(base.transform.GetChild(num2).gameObject);
				}
			}
			crosswalkObjects.Clear();
		}

		public void RemoveSidewalks(ERRoadSide side)
		{
			switch (side)
			{
			case ERRoadSide.Left:
			{
				foreach (ERSideWalkInstance leftSidewalk in leftSidewalks)
				{
					if (leftSidewalk.swObject != null)
					{
						UnityEngine.Object.DestroyImmediate(leftSidewalk.swObject);
					}
				}
				break;
			}
			case ERRoadSide.Right:
			{
				foreach (ERSideWalkInstance rightSidewalk in rightSidewalks)
				{
					if (rightSidewalk.swObject != null)
					{
						UnityEngine.Object.DestroyImmediate(rightSidewalk.swObject);
					}
				}
				break;
			}
			}
		}

		public int GetRoadMarkerSection(int index)
		{
			for (int i = 0; i < markersExt.Count; i++)
			{
				if (markersExt[i].startSplinePoint > index)
				{
					return i - 1;
				}
			}
			return -1;
		}

		public void OOOODOCQCQ(bool lineMask, bool biomeMask)
		{
			if (baseScript != null)
			{
				if (!lineMask && baseScript.rmMethod != null)
				{
					object[] parameters = new object[1] { base.gameObject };
					baseScript.rmMethod.Invoke(null, parameters);
				}
				if (!biomeMask && baseScript.rmBiomeMethod != null)
				{
					object[] parameters2 = new object[1] { base.gameObject };
					baseScript.rmBiomeMethod.Invoke(null, parameters2);
				}
			}
		}

		public void SetMarkerShape(List<Vector2> conVecs, Vector3 scale, ERCrossingPrefabs prefab, int connectionIndex)
		{
			for (int i = 0; i < conVecs.Count; i++)
			{
				conVecs[i] = new Vector2(conVecs[i].x * scale.x, conVecs[i].y * scale.y);
			}
			conVecs.Reverse();
			if (startPrefabScript == prefab && startConnectionSegment == connectionIndex)
			{
				markersExt[0].roadShape = conVecs;
			}
			else if (endPrefabScript == prefab && endConnectionSegment == connectionIndex)
			{
				markersExt[markersExt.Count - 1].roadShape = conVecs;
			}
		}

		public void OCQDQQDDOC(ERIndentAlignment value, int marker, ERRoadSide type)
		{
			if (marker < 0 || marker >= markersExt.Count)
			{
				return;
			}
			if (type == ERRoadSide.Left || type == ERRoadSide.Both)
			{
				switch (value)
				{
				case ERIndentAlignment.Road:
					markersExt[marker].leftIndentAlignment = 0;
					break;
				case ERIndentAlignment.Terrain:
					markersExt[marker].leftIndentAlignment = 1;
					break;
				case ERIndentAlignment.Surrounding:
					markersExt[marker].leftIndentAlignment = 2;
					break;
				}
			}
			if (type == ERRoadSide.Right || type == ERRoadSide.Both)
			{
				switch (value)
				{
				case ERIndentAlignment.Road:
					markersExt[marker].rightIndentAlignment = 0;
					break;
				case ERIndentAlignment.Terrain:
					markersExt[marker].rightIndentAlignment = 1;
					break;
				case ERIndentAlignment.Surrounding:
					markersExt[marker].rightIndentAlignment = 2;
					break;
				}
			}
		}

		public ERIndentAlignment ERGetIndentAlignment(int marker, ERRoadSide type)
		{
			if (marker >= 0 && marker < markersExt.Count)
			{
				if (type == ERRoadSide.Left || type == ERRoadSide.Both)
				{
					if (markersExt[marker].leftIndentAlignment == 0)
					{
						return ERIndentAlignment.Road;
					}
					if (markersExt[marker].leftIndentAlignment == 1)
					{
						return ERIndentAlignment.Terrain;
					}
					if (markersExt[marker].leftIndentAlignment == 2)
					{
						return ERIndentAlignment.Surrounding;
					}
				}
				if (type == ERRoadSide.Right || type == ERRoadSide.Both)
				{
					if (markersExt[marker].rightIndentAlignment == 0)
					{
						return ERIndentAlignment.Road;
					}
					if (markersExt[marker].rightIndentAlignment == 1)
					{
						return ERIndentAlignment.Terrain;
					}
					if (markersExt[marker].rightIndentAlignment == 2)
					{
						return ERIndentAlignment.Surrounding;
					}
				}
			}
			return ERIndentAlignment.Road;
		}

		public void FlipRoadUVs(bool update)
		{
			if (update)
			{
				flipRoadUVs = !flipRoadUVs;
			}
			roadMaterials = base.gameObject.GetComponent<MeshRenderer>().sharedMaterials;
			int num = 0;
			for (int i = 0; i < roadMaterials.Length; i++)
			{
				if (roadMaterials[i] == roadMaterial)
				{
					num = i;
					break;
				}
			}
			if (roadMaterials.Length > 1)
			{
				for (int j = 0; j < roadShapeUVs.Count; j++)
				{
					if (roadShapeMaterialInts[j] == num)
					{
						roadShapeUVs[j] = 1f - roadShapeUVs[j];
						roadShapeUVs2[j] = 1f - roadShapeUVs2[j];
					}
				}
			}
			else
			{
				OQOCQDQODD.OQOCODDQDO(ref roadShapeUVs, ref roadShapeUVs2);
			}
		}

		public bool OOCCQOQCOO(Vector3 snapPos)
		{
			float num = Vector3.Distance(snapPos, markersExt[0].position);
			float num2 = Vector3.Distance(snapPos, markersExt[markersExt.Count - 1].position);
			if (num < num2 && num < roadWidth + 5f)
			{
				return true;
			}
			if (num > num2 && num2 < roadWidth + 5f)
			{
				return true;
			}
			return false;
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
