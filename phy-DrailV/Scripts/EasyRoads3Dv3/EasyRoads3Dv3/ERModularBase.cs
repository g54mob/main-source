using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERModularBase : MonoBehaviour
	{
		private sealed class ᙃ : IEnumerator<object>, IEnumerator, IDisposable
		{
			private object ᙄ;

			private int ᙅ;

			public ERModularBase _003C_003E4__this;

			public string url;

			public WWW _003Cwww_003E5__1;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return ᙄ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ᙄ;
				}
			}

			private bool MoveNext()
			{
				switch (ᙅ)
				{
				case 0:
					ᙅ = -1;
					_003C_003E4__this.tex = new Texture2D(750, 200, TextureFormat.DXT1, mipChain: false);
					_003Cwww_003E5__1 = new WWW(url);
					ᙄ = _003Cwww_003E5__1;
					ᙅ = 1;
					return true;
				case 1:
					ᙅ = -1;
					_003C_003E4__this.infoTexture = _003Cwww_003E5__1.texture;
					break;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public ᙃ(int _003C_003E1__state)
			{
				ᙅ = _003C_003E1__state;
			}
		}

		public int updateInt = 10;

		public bool newSplatMapRestoreCode = false;

		public int toolbarInt = 0;

		public int roadToolbarInt = 0;

		public int markerToolbarInt = 0;

		public Texture[] menuTexs;

		public Texture[] subMenuTexs;

		public GameObject cprefab;

		public Texture nodeHandleTexture;

		public Texture lockedTexture;

		public Texture unLockedTexture;

		public Texture selRoadTexture;

		public Texture headerTexture;

		public Texture sceneGUITex;

		public Transform roadObjectsParent;

		public Transform connectionObjectsParent;

		public GameObject OQDOOOQODC;

		public List<QDQDOOQQDQODD> roadTypes = new List<QDQDOOQQDQODD>();

		public int selectedRoadType = 0;

		public int selectedNewRoadType = 0;

		public List<QDQDOOQQDQODD> inspRoadTypes = new List<QDQDOOQQDQODD>();

		public List<int> inspRoadTypeInts = new List<int>();

		public List<ERDecal> decalPresets = new List<ERDecal>();

		public float roadWidth = 5f;

		public Material roadMaterial;

		public Material crossingMaterial;

		public Material roundAboutMaterial;

		public Material roundAboutConnectionMaterial;

		public Material roundAboutRoadMaterial;

		public Material sidewalkMaterial;

		public Material targetMaterial;

		public Terrain sourceTerrain;

		public string[] roadMaterials;

		public string[] connectionMaterials;

		public int selectedMaterial = 0;

		public int selectedConnectionMaterial = 0;

		public List<ERMaterial> materials = new List<ERMaterial>();

		public int selectedRoadRoadType = 0;

		public bool roadOptions = true;

		public bool markerOptions = true;

		public bool showRoadSideObjects = false;

		public bool markerSOOptions = true;

		public bool roadTerrainOptions = true;

		public bool camFlyOver = true;

		public int selectedRoadMaterial = 0;

		public int roadTextureInfoIndex = 0;

		public Texture2D selectedRoadTexture;

		public float selectedRoadWidth = 0f;

		public float selectedRoadLeftOffset = 0f;

		public float selectedRoadRightOffset = 0f;

		public float selectedRoadLeftInnerOffset = 0f;

		public float selectedRoadRightInnerOffset = 0f;

		public int selectedCrossingMaterial = 0;

		public int crossingTextureInfoIndex = 0;

		public int handleSelection = 0;

		public int positionHandleSelection = 0;

		public bool markerDirXZ = false;

		public GameObject defaultCrossing;

		public GameObject defaultTCrossing;

		public GameObject defaultCulDeSac;

		public GameObject defaultRoundabout;

		public Texture2D tex;

		public Texture2D infoTexture = null;

		public bool showAllPrefabs = true;

		public bool standardPrefabsFlag;

		public bool sceneSettingsFoldOut;

		public bool sceneRoadsFoldOut;

		public bool scenePrefabsFoldOut;

		public bool sidewalksFoldOut;

		public bool terrainManagementFoldOut;

		public bool importRoadDataFoldOut;

		public bool lodGroupsFoldOut;

		public bool defaultMaterialsFoldOut;

		public bool kmlFlag = false;

		public bool osmFlag = false;

		public bool useOSMHeights = false;

		public float heightRatio = 1f;

		public bool dynamicPrefabsFoldOut = true;

		public bool customPrefabsFoldOut = true;

		public float prefabsDisplayType = 0f;

		public float osmTerrainTopLon;

		public float osmTerrainBottomLon;

		public float osmTerrainLeftLat;

		public float osmTerrainRightLat;

		public float terrainMinIndent = 0.5f;

		public float minIndent = 0.5f;

		public float minSurrounding = 0.5f;

		public float maxIndentSurrounding = 50f;

		public float terrainY = 0f;

		public float terrainDetailSplatX = 0f;

		public float terrainDetailSplatY = 0f;

		public Vector3 detailOffsetVec;

		public float raise = 0.02f;

		public Vector3 baseVector = Vector3.zero;

		public bool mirrorCrossings = true;

		public string[] terrainNames;

		public Terrain[] terrainObjects;

		public string[] terrainSplatTextures;

		public Terrain activeTerrain;

		public float activeTerrainY;

		public int selectedTerrain = 0;

		public bool selectedRoadsOnly = false;

		public bool terrainDone;

		public bool enableBackWithoutRestore = false;

		public float detailDistance = 3f;

		public float treeDistance = 5f;

		public bool doHeightmap = true;

		public bool doTrees = true;

		public bool soTrees = true;

		public bool doDetail = true;

		public Rect terrainRect = default(Rect);

		public List<GameObject> surfaceObjects = new List<GameObject>();

		public float preserveTerrainFloat = 1f;

		public float terrainSmoothIndentDistance = 1f;

		public float terrainSmoothSurroundingDistance = 1f;

		public int indentSmoothStep = 0;

		public int surroundingSmoothStep = 0;

		public bool doTangents = true;

		public bool doLightmapUVs = false;

		public bool doLODGroups = false;

		public bool doSplatmaps = false;

		public List<Vector3> terrainHits = new List<Vector3>();

		public List<Vector3> osmCrossingPoints = new List<Vector3>();

		public List<CrossingCornerClass> cornerPresets = new List<CrossingCornerClass>();

		public List<SidewalkPresetClass> sidewalkPresets = new List<SidewalkPresetClass>();

		public List<ERSideWalk> sidewalks = new List<ERSideWalk>();

		public int selectedSidewalk = 0;

		public int selectedRoadTypeSidewalk = 0;

		public int osmMotorway = 0;

		public int osmMotorwayLink = 0;

		public int osmTrunk = 0;

		public int osmPrimary = 0;

		public int osmSecondary = 0;

		public int osmTertiary = 0;

		public int osmUnclassified = 0;

		public int osmResidential = 0;

		public int osmService = 0;

		public int osmTrack = 0;

		public int osmPath = 0;

		public bool osmMotorwayFlag = true;

		public bool osmMotorwayLinkFlag = true;

		public bool osmTrunkFlag = true;

		public bool osmPrimaryFlag = true;

		public bool osmSecondaryFlag = true;

		public bool osmTertiaryFlag = true;

		public bool osmUnclassifiedFlag = true;

		public bool osmResidentialFlag = true;

		public bool osmServiceFlag = true;

		public bool osmTrackFlag = true;

		public bool osmPathFlag = true;

		public bool lodGroups = false;

		public int LODLevels = 4;

		public List<float> LODLevelValues = new List<float>();

		public List<float> LODLevelResolution = new List<float>();

		public bool embedRoadShape = false;

		public bool hideSurfaces = false;

		public bool useLightProbes = false;

		public bool hideLockedObjects = false;

		public bool OOQQQQOCQD = false;

		public bool isInBuildMode = false;

		public bool progressFlag = false;

		public int progressTerrain = 1;

		public float progressStatus = 1f;

		public float progressMax = 1f;

		[SerializeField]
		public List<SideObject> QOQDQOOQDDQOOQ = new List<SideObject>();

		public string[] sideObjectNames = new string[0];

		public int selSideObject = 0;

		public int selSubSideObject = 0;

		public string soID = "";

		public string sideObjectName = "";

		[SerializeField]
		public int sideObjectType = 0;

		public GameObject sideObjectSource;

		public GameObject soEndObject;

		public int sideObjectTerrainVegetationInt = 0;

		public int prefabChildHandling = 0;

		public float sideObjectDistance = 1f;

		public int soYAxisRotation = 0;

		public float soSidewaysDistance = 0f;

		public int soSidewaysDistanceHandling = 0;

		public float soDensity = 1f;

		public float soOffset = 0f;

		public int soTerrainAligment = 0;

		public bool soCombine = false;

		public bool soWeld = false;

		public int soControllerType = 0;

		public Material soMaterial;

		public float soXPosition = 0f;

		public float soYPosition = 0f;

		public bool soMarkerActive = true;

		public bool enableSOHandles = false;

		public bool enableShapeNodeHandles = false;

		public bool enableSOShapeNodeHandles = false;

		public bool displayCriticalPoints = true;

		public bool highlightRoad = true;

		public bool highlightIndents = true;

		public bool highlightSurroundings = true;

		public bool highlightSideObject = true;

		public bool onlyShowSelectedRoad = false;

		public List<GameObject> soDeformationObjects = new List<GameObject>();

		public List<GameObject> soSplatmapObjects = new List<GameObject>();

		public bool buildSOinEditMode = true;

		public bool tangentsInEditMode = true;

		public bool calculateSmoothNormals = true;

		public bool importSideObjectsAlert = false;

		public bool importRoadPresetsAlert = false;

		public bool importCrossingPresetsAlert = false;

		public bool importSidewalkPresetsAlert = false;

		public bool updateSideObjectsAlert = false;

		public bool updateRoadPresetsAlert = false;

		public bool updateCrossingPresetsAlert = false;

		public bool updateSidewalkPresetsAlert = false;

		public float waypointDistance = 10f;

		public List<ERModularRoad> RoadObjectsSoUpdates = new List<ERModularRoad>();

		public string assetsFolderID = "";

		public GameObject meshSurface;

		public Collider meshTerrainCollider;

		public float markerScale = 1f;

		public float markerDistance = 400f;

		public float minMarkerDistance = 100f;

		public float maxMarkerDistance = 500f;

		public bool debugFlag = false;

		public float roadNetworkY = 0f;

		public bool ignoreMinIndents = false;

		public Vector3 zoomStart;

		public Vector3 zoomEnd;

		public Vector3 lookAtStart;

		public Vector3 lookAtEnd;

		public Quaternion zoomRot;

		public float zoomStartTime = 0f;

		public bool hideSurfaceHandles = false;

		public bool dirtyBool = false;

		public bool dirtyOnSceneBool = false;

		public bool ODDOOCDODO = true;

		public ERCrossingPrefabs OQDOOOQODCScript = null;

		public ERCrossings ODOCQODOCCCrossingsScript;

		public ERCrossingPrefabs ODOCQODOCCScript;

		public int OQDOOOQODCElement = -1;

		public int ODQQQDDQDQ = -1;

		public ERModularRoad OCCCQDQOCQ;

		public ERModularRoad ODQDOODCOQ;

		public int OOOQQDCQOD = -1;

		public int selectedRoadSOMarker = -1;

		public int selectedMarkerNode = -1;

		public List<int> selectedMarkerNodes = new List<int>();

		public int selectedMarkerSONode = -1;

		public List<int> selectedMarkerSONodes = new List<int>();

		public List<SelectedObject> selectedObjects = new List<SelectedObject>();

		public bool newRoadFlag = false;

		public bool roadTypeUpdateFlag = false;

		public List<ERModularRoad> roadScripts = new List<ERModularRoad>();

		public List<ERCrossingPrefabs> prefabScripts = new List<ERCrossingPrefabs>();

		public bool globalGridActive = false;

		public bool gridGUIActive = false;

		public Color globalGridColor = new Color(0.35f, 0.5f, 0.9f, 0.9f);

		public float globalGridSize = 10f;

		public float globalGridRotation = 0f;

		public Vector3 ggTL;

		public Vector3 ggBL;

		public Vector3 ggBR;

		public bool localGridActive = false;

		public List<ERLocalGrid> localGrids = new List<ERLocalGrid>();

		public int selectedLocalGrid = 0;

		public MethodInfo crMethod;

		public MethodInfo upMethod;

		public MethodInfo hmMethod;

		public bool roadUpdated = false;

		public bool clampUVs = true;

		public int soCategoryInt = 0;

		public int soRoadCategoryInt = 0;

		public float minRoadWidth = 1f;

		public float maxRoadWidth = 75f;

		public float maxCurbHeight = 0.5f;

		public float minCornerRadius = 0.5f;

		public float maxCornerRadius = 5f;

		public GameObject SoTestObject;

		public bool lockRoadNetwork = false;

		public bool showNotifications = true;

		public bool vegetationStudio = false;

		public bool vegetationStudioActive = false;

		public float vegetationStudioGrassPerimeter = 2f;

		public float vegetationStudioPlantPerimeter = 3f;

		public float vegetationStudioTreePerimeter = 4f;

		public float vegetationStudioObjectPerimeter = 3f;

		public float vegetationStudioLargeObjectPerimeter = 4f;

		public void SetRoadTypeList()
		{
			ODQDOODCOQ = OCCCQDQOCQ;
			roadTypeUpdateFlag = true;
			if (OCCCQDQOCQ != null)
			{
				if (OCCCQDQOCQ.startPrefabScript != null || OCCCQDQOCQ.endPrefabScript != null)
				{
					inspRoadTypes.Clear();
					inspRoadTypeInts.Clear();
					for (int i = 0; i < roadTypes.Count; i++)
					{
						if (OCQQDQQCQQ.OQDDCCCQCC(roadTypes[i].roadShape) == OCCCQDQOCQ.roadShapeMatchCount)
						{
							inspRoadTypes.Add(roadTypes[i]);
							inspRoadTypeInts.Add(i);
							if (roadTypes[i].id == OCCCQDQOCQ.roadType)
							{
								selectedRoadRoadType = inspRoadTypes.Count;
							}
						}
					}
					if (OCCCQDQOCQ.startPrefabScript != null && OCCCQDQOCQ.startPrefabScript.crossingElements[OCCCQDQOCQ.startConnectionSegment].roadShapeMatchCount != 2 && !OCCCQDQOCQ.startPrefabScript.isIConnector)
					{
						roadTypeUpdateFlag = false;
					}
					if (OCCCQDQOCQ.endPrefabScript != null && OCCCQDQOCQ.endPrefabScript.crossingElements[OCCCQDQOCQ.endConnectionSegment].roadShapeMatchCount != 2 && !OCCCQDQOCQ.endPrefabScript.isIConnector)
					{
						roadTypeUpdateFlag = false;
					}
				}
				else
				{
					inspRoadTypes = new List<QDQDOOQQDQODD>(roadTypes);
					inspRoadTypeInts.Clear();
					for (int i = 0; i < roadTypes.Count; i++)
					{
						inspRoadTypeInts.Add(i);
						if (roadTypes[i].id == OCCCQDQOCQ.roadType)
						{
							selectedRoadRoadType = i + 1;
						}
					}
				}
			}
			if (roadTypeUpdateFlag || !(OCCCQDQOCQ != null))
			{
				return;
			}
			inspRoadTypes.Clear();
			inspRoadTypeInts.Clear();
			if (OCCCQDQOCQ.roadType == 0.0)
			{
				return;
			}
			for (int i = 0; i < roadTypes.Count; i++)
			{
				if (roadTypes[i].id == OCCCQDQOCQ.roadType)
				{
					inspRoadTypes.Add(roadTypes[i]);
					inspRoadTypeInts.Add(i);
					selectedRoadRoadType = 1;
				}
			}
		}

		public void UpdateRoadTypeStatus()
		{
			roadTypeUpdateFlag = true;
			if (OCCCQDQOCQ != null)
			{
				if (OCCCQDQOCQ.startPrefabScript != null && OCCCQDQOCQ.startPrefabScript.crossingElements[OCCCQDQOCQ.startConnectionSegment].roadShapeMatchCount == 2)
				{
					roadTypeUpdateFlag = false;
				}
				if (OCCCQDQOCQ.endPrefabScript != null && OCCCQDQOCQ.endPrefabScript.crossingElements[OCCCQDQOCQ.endConnectionSegment].roadShapeMatchCount == 2)
				{
					roadTypeUpdateFlag = false;
				}
			}
		}

		public void OQOCQOCQQC()
		{
			if (roadMaterial == null)
			{
				roadMaterial = Resources.Load("Materials/roads/road material") as Material;
			}
			if (crossingMaterial == null)
			{
				crossingMaterial = Resources.Load("Materials/roads/road material") as Material;
			}
			if (roundAboutMaterial == null)
			{
				roundAboutMaterial = Resources.Load("Materials/roundabouts/roundabout 2 lane") as Material;
			}
			if (roundAboutConnectionMaterial == null)
			{
				roundAboutConnectionMaterial = Resources.Load("Materials/roundabouts/roundaboutconnect 1") as Material;
			}
			if (roundAboutRoadMaterial == null)
			{
				roundAboutRoadMaterial = Resources.Load("Materials/roads/road material") as Material;
			}
		}

		public void OCQCDODOOO(GameObject go, Vector3 pos)
		{
			pos.y += 1f;
			GameObject gameObject = UnityEngine.Object.Instantiate(go);
			gameObject.name = "crossing";
			gameObject.transform.position = pos;
		}

		public void OOQODQOQDD()
		{
			foreach (Transform item in base.transform)
			{
				if (item.name == "Connection Objects")
				{
					connectionObjectsParent = item;
				}
				else if (item.name == "Road Objects")
				{
					roadObjectsParent = item;
				}
			}
			if (connectionObjectsParent == null)
			{
				GameObject gameObject = new GameObject("Connection Objects");
				gameObject.transform.parent = base.transform;
				connectionObjectsParent = gameObject.transform;
				gameObject.transform.position = Vector3.zero;
			}
			if (roadObjectsParent == null)
			{
				GameObject gameObject = new GameObject("Road Objects");
				gameObject.transform.parent = base.transform;
				roadObjectsParent = gameObject.transform;
				gameObject.transform.position = Vector3.zero;
			}
			OOQQQQOCQD = Application.isPlaying;
		}

		public ERCrossingPrefabs OOQQQOCCQD(GameObject prefab, ERModularRoad OCCCQDQOCQ, int OOOQQDCQOD, int connectionSegment)
		{
			GameObject gameObject = null;
			ERConnectionParent eRConnectionParent = (ERConnectionParent)UnityEngine.Object.FindObjectOfType(typeof(ERConnectionParent));
			ERCrossingPrefabs eRCrossingPrefabs = null;
			ERCrossings eRCrossings = null;
			if ((bool)prefab.GetComponent<ERRoundabouts>())
			{
				eRCrossingPrefabs.GetComponent<ERRoundabouts>().isSceneObject = true;
			}
			else if ((bool)prefab.GetComponent<ERCrossings>())
			{
				gameObject = new GameObject(prefab.name);
				if (eRConnectionParent != null)
				{
					gameObject.transform.parent = eRConnectionParent.transform;
				}
				eRCrossingPrefabs = gameObject.AddComponent<ERCrossingPrefabs>();
				eRCrossings = gameObject.AddComponent<ERCrossings>();
				eRCrossings.prefabScript = eRCrossingPrefabs;
				eRCrossings.OOOQQCCQQC(prefab.GetComponent<ERCrossings>());
				List<ERModularRoad> updatedRoads = new List<ERModularRoad>();
				foreach (QDQDOOQQDQODD roadType in roadTypes)
				{
					eRCrossings.UpdateToRoadType(roadType, ref updatedRoads);
				}
				eRCrossings.isSceneObject = true;
			}
			else
			{
				gameObject = UnityEngine.Object.Instantiate(prefab);
				eRCrossingPrefabs = gameObject.GetComponent<ERCrossingPrefabs>();
				gameObject.name = prefab.name;
				eRCrossingPrefabs.transform.parent = eRConnectionParent.transform;
				if ((bool)gameObject.GetComponent<MeshFilter>() && (bool)gameObject.GetComponent<MeshFilter>().sharedMesh)
				{
					gameObject.GetComponent<MeshFilter>().sharedMesh = UnityEngine.Object.Instantiate(prefab.GetComponent<MeshFilter>().sharedMesh);
					if ((bool)gameObject.GetComponent<MeshCollider>())
					{
						gameObject.GetComponent<MeshCollider>().sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
						gameObject.GetComponent<MeshCollider>().sharedMesh.name = gameObject.GetComponent<MeshFilter>().sharedMesh.name;
					}
					gameObject.GetComponent<MeshFilter>().sharedMesh.RecalculateBounds();
				}
			}
			if ((bool)gameObject.GetComponent<MeshRenderer>())
			{
				gameObject.GetComponent<MeshRenderer>().useLightProbes = useLightProbes;
				gameObject.GetComponent<MeshRenderer>().castShadows = false;
			}
			if (!eRCrossingPrefabs.isCustomPrefab)
			{
				OQDQQDCCCC(gameObject, prefab);
			}
			if (eRCrossingPrefabs.fullMeshVecs.Length == 0)
			{
				ODDQOOQODD(eRCrossingPrefabs);
			}
			if (connectionSegment == -1)
			{
				for (int i = 0; i < eRCrossingPrefabs.crossingElements.Count; i++)
				{
					if (eRCrossingPrefabs.crossingElements[i].rotationPriority)
					{
						connectionSegment = i;
						break;
					}
				}
			}
			if ((bool)gameObject.GetComponent<ERCrossings>())
			{
				gameObject.GetComponent<ERCrossings>().ODCQOCQDOO();
			}
			if (connectionSegment != -1 || eRCrossingPrefabs.crossingElements.Count > 1)
			{
			}
			if (connectionSegment == -1)
			{
				connectionSegment = OQDQDCQQOC(OCCCQDQOCQ, eRCrossingPrefabs, OOOQQDCQOD, 0, swapFlag: false);
			}
			if ((bool)prefab.GetComponent<ERCrossings>())
			{
				Vector3 v = OCCCQDQOCQ.soSplinePoints[0];
				Vector3 v2 = OCCCQDQOCQ.soSplinePoints[1];
				if (OOOQQDCQOD != 0)
				{
					v = OCCCQDQOCQ.soSplinePoints[OCCCQDQOCQ.soSplinePoints.Count - 1];
					v2 = OCCCQDQOCQ.soSplinePoints[OCCCQDQOCQ.soSplinePoints.Count - 2];
				}
				eRCrossingPrefabs.ODOOOQODQC(v, v2, connectionSegment, OCCCQDQOCQ);
				OCQCDQCQOQExt.OCDQQOQOQO(eRCrossingPrefabs, OCCCQDQOCQ, OOOQQDCQOD, connectionSegment);
			}
			OCCCQDQOCQ.nodeWithinRange = OOOQQDCQOD;
			if (OOOQQDCQOD == 0)
			{
				ODQCQOODDO.OCOQODCDCQ(OCCCQDQOCQ, OCCCQDQOCQ.markersExt[OOOQQDCQOD].position, eRCrossingPrefabs, connectionSegment, reverse: true, uvReverse: false, forceAutoRotate: true);
			}
			else
			{
				ODQCQOODDO.OCOQODCDCQ(OCCCQDQOCQ, OCCCQDQOCQ.markersExt[OOOQQDCQOD].position, eRCrossingPrefabs, connectionSegment, reverse: false, uvReverse: false, forceAutoRotate: true);
			}
			eRCrossingPrefabs.isSceneObject = true;
			eRCrossingPrefabs.baseScript = this;
			eRCrossingPrefabs.surroundingDistance = 0f;
			eRCrossingPrefabs.OCCQOOCCCQ(forceFlag: false);
			eRCrossingPrefabs.prefabId = prefab.GetComponent<ERCrossingPrefabs>().prefabId;
			return eRCrossingPrefabs;
		}

		public ERCrossingPrefabs AttachConnector(ERModularRoad OCCCQDQOCQ, int OOOQQDCQOD)
		{
			GameObject gameObject = new GameObject("I Connector");
			ERConnectionParent eRConnectionParent = (ERConnectionParent)UnityEngine.Object.FindObjectOfType(typeof(ERConnectionParent));
			if (eRConnectionParent != null)
			{
				gameObject.transform.parent = eRConnectionParent.transform;
			}
			ERCrossingPrefabs eRCrossingPrefabs = gameObject.AddComponent<ERCrossingPrefabs>();
			ERIConnector iConnectorScript = gameObject.AddComponent<ERIConnector>();
			gameObject.AddComponent<MeshRenderer>();
			if ((bool)gameObject.GetComponent<MeshRenderer>())
			{
				gameObject.GetComponent<MeshRenderer>().useLightProbes = useLightProbes;
				gameObject.GetComponent<MeshRenderer>().castShadows = false;
			}
			int num = 0;
			OCCCQDQOCQ.nodeWithinRange = OOOQQDCQOD;
			if (OOOQQDCQOD == 0)
			{
			}
			if (OOOQQDCQOD == 0)
			{
				OCCCQDQOCQ.startPrefabScript = eRCrossingPrefabs;
				OCCCQDQOCQ.startConnectionSegment = 0;
			}
			else if (OOOQQDCQOD == OCCCQDQOCQ.markersExt.Count - 1)
			{
				OCCCQDQOCQ.endPrefabScript = eRCrossingPrefabs;
				OCCCQDQOCQ.endConnectionSegment = 0;
			}
			eRCrossingPrefabs.crossingElements.Add(new QDOODOQQDQODD());
			eRCrossingPrefabs.crossingElements.Add(new QDOODOQQDQODD());
			eRCrossingPrefabs.crossingElements[0].connectedRoad = OCCCQDQOCQ;
			eRCrossingPrefabs.crossingElements[0].connectedMarker = OOOQQDCQOD;
			eRCrossingPrefabs.crossingElements[0].connectedRoadGO = gameObject;
			gameObject.transform.position = OCCCQDQOCQ.markersExt[OOOQQDCQOD].position;
			eRCrossingPrefabs.baseScript = this;
			eRCrossingPrefabs.surroundingDistance = 0f;
			eRCrossingPrefabs.isIConnector = true;
			eRCrossingPrefabs.iConnectorScript = iConnectorScript;
			return eRCrossingPrefabs;
		}

		public void ODDQCODCDQ(ERModularRoad OCCCQDQOCQ, int selectedMarker)
		{
			if (selectedMarker == 0)
			{
				if (OCCCQDQOCQ.startPrefabScript != null)
				{
					int num = OQDQDCQQOC(OCCCQDQOCQ, OCCCQDQOCQ.startPrefabScript, selectedMarker, OCCCQDQOCQ.startConnectionSegment + 1, swapFlag: true);
					if (num != -1 && num != OCCCQDQOCQ.startConnectionSegment)
					{
						ODQCQOODDO.OCOQODCDCQ(OCCCQDQOCQ, OCCCQDQOCQ.markersExt[selectedMarker].position, OCCCQDQOCQ.startPrefabScript, num, reverse: true, uvReverse: false, forceAutoRotate: true);
					}
				}
			}
			else if (selectedMarker == OCCCQDQOCQ.markersExt.Count - 1 && OCCCQDQOCQ.endPrefabScript != null)
			{
				int num = OQDQDCQQOC(OCCCQDQOCQ, OCCCQDQOCQ.endPrefabScript, selectedMarker, OCCCQDQOCQ.endConnectionSegment + 1, swapFlag: true);
				if (num != -1 && num != OCCCQDQOCQ.endConnectionSegment)
				{
					ODQCQOODDO.OCOQODCDCQ(OCCCQDQOCQ, OCCCQDQOCQ.markersExt[selectedMarker].position, OCCCQDQOCQ.endPrefabScript, num, reverse: false, uvReverse: false, forceAutoRotate: true);
				}
			}
		}

		public int OQDQDCQQOC(ERModularRoad OCCCQDQOCQ, ERCrossingPrefabs prefabScript, int OOOQQDCQOD, int startConnection, bool swapFlag)
		{
			int num = -1;
			List<Vector2> list = new List<Vector2>(OCCCQDQOCQ.roadShape);
			if (OOOQQDCQOD != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					Vector2 value = list[i];
					value.x *= -1f;
					list[i] = value;
				}
			}
			string text = OCCCQDQOCQ.roadShapeString;
			if (OOOQQDCQOD != 0)
			{
				text = OCCCQDQOCQ.roadShapeReversedString;
			}
			List<string> list2 = new List<string>();
			for (int i = startConnection; i < prefabScript.crossingElements.Count; i++)
			{
				if (text == prefabScript.crossingElements[i].roadShapeVecsString && prefabScript.crossingElements[i].connectionVecInts.Count > 0)
				{
					num = i;
					break;
				}
				list2.Add(prefabScript.crossingElements[i].roadShapeVecsString);
			}
			if (swapFlag && num == -1)
			{
				num = ((OOOQQDCQOD != 0) ? OQDQDCQQOC(OCCCQDQOCQ, OCCCQDQOCQ.endPrefabScript, OOOQQDCQOD, 0, swapFlag: true) : OQDQDCQQOC(OCCCQDQOCQ, OCCCQDQOCQ.startPrefabScript, OOOQQDCQOD, 0, swapFlag: true));
			}
			if (swapFlag)
			{
				return num;
			}
			if (num == -1)
			{
				num = OODQDCCCOO(text, list2, prefabScript.crossingElements);
			}
			if (num == -1)
			{
				num = ((OOOQQDCQOD == 0 && prefabScript.isCustomPrefab && prefabScript.crossingElements.Count == 2) ? 1 : 0);
			}
			return num;
		}

		public int OODQDCCCOO(string roadShapeString, List<string> strings, List<QDOODOQQDQODD> crossingElements)
		{
			int result = -1;
			string[] array = roadShapeString.Split(';');
			List<float> list = new List<float>();
			List<float> list2 = new List<float>();
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new string[1] { ", " }, StringSplitOptions.None);
				if (array2[0] != "")
				{
					list.Add(float.Parse(array2[0]));
					list2.Add(float.Parse(array2[1]));
				}
			}
			for (int j = 0; j < strings.Count; j++)
			{
				if (crossingElements[j].connectionVecInts.Count <= 0)
				{
					continue;
				}
				List<float> list3 = new List<float>();
				List<float> list4 = new List<float>();
				array = strings[j].Split(';');
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(new string[1] { ", " }, StringSplitOptions.None);
					if (array2[0] != "")
					{
						list3.Add(float.Parse(array2[0]));
						list4.Add(float.Parse(array2[1]));
					}
				}
				float num = 1000f;
				if (list.Count == list3.Count)
				{
					num = 0f;
					for (int i = 0; i < list.Count; i++)
					{
						num += Math.Abs(list[i] - list3[i]);
						num += Math.Abs(list2[i] - list4[i]);
					}
				}
				if ((double)num < 0.5)
				{
					result = j;
					break;
				}
			}
			return result;
		}

		public GameObject OQDCOCDDQD(GameObject prefab, Vector3 hitPos, ref GameObject newPrefab, ref ERCrossingPrefabs prefabScript, ref ERCrossings crossingsScript)
		{
			ERConnectionParent eRConnectionParent = (ERConnectionParent)UnityEngine.Object.FindObjectOfType(typeof(ERConnectionParent));
			if (prefab == null)
			{
				Debug.Log("This is an empty prefab");
				return null;
			}
			if ((bool)prefab.GetComponent<ERCrossings>())
			{
				newPrefab = new GameObject(prefab.name);
				if (eRConnectionParent != null)
				{
					newPrefab.transform.parent = eRConnectionParent.transform;
				}
				newPrefab.transform.position = hitPos;
				prefabScript = newPrefab.AddComponent<ERCrossingPrefabs>();
				crossingsScript = newPrefab.AddComponent<ERCrossings>();
				crossingsScript.prefabScript = prefabScript;
				crossingsScript.OOOQQCCQQC(prefab.GetComponent<ERCrossings>());
				List<ERModularRoad> updatedRoads = new List<ERModularRoad>();
				foreach (QDQDOOQQDQODD roadType in roadTypes)
				{
					crossingsScript.UpdateToRoadType(roadType, ref updatedRoads);
				}
			}
			else
			{
				newPrefab = UnityEngine.Object.Instantiate(prefab);
				newPrefab.name = prefab.name;
				prefabScript = newPrefab.GetComponent<ERCrossingPrefabs>();
				newPrefab.transform.position = hitPos;
				newPrefab.transform.parent = eRConnectionParent.transform;
				if ((bool)newPrefab.GetComponent<ERRoundabouts>())
				{
					if ((bool)newPrefab.GetComponent<MeshFilter>())
					{
						newPrefab.GetComponent<MeshFilter>().sharedMesh = null;
					}
					if ((bool)newPrefab.GetComponent<MeshCollider>())
					{
						newPrefab.GetComponent<MeshCollider>().sharedMesh = null;
					}
					newPrefab.GetComponent<ERRoundabouts>().baseScript = this;
					newPrefab.GetComponent<ERRoundabouts>().OCCQCOQODO();
					newPrefab.GetComponent<ERRoundabouts>().OOCDCDDOQQ();
					newPrefab.GetComponent<ERRoundabouts>().OODOQQQCDD();
					List<ERModularRoad> updatedRoads = new List<ERModularRoad>();
					foreach (QDQDOOQQDQODD roadType2 in roadTypes)
					{
						newPrefab.GetComponent<ERRoundabouts>().UpdateToRoadType(roadType2);
					}
				}
				else
				{
					if (prefab.GetComponent<MeshFilter>().sharedMesh == null)
					{
						Debug.LogError("EasyRoads3Dv3 Error: No mesh is assigned to custom prefab: " + prefab.name);
						return newPrefab;
					}
					newPrefab.GetComponent<MeshFilter>().sharedMesh = UnityEngine.Object.Instantiate(prefab.GetComponent<MeshFilter>().sharedMesh);
					if ((bool)newPrefab.GetComponent<MeshCollider>())
					{
						newPrefab.GetComponent<MeshCollider>().sharedMesh = newPrefab.GetComponent<MeshFilter>().sharedMesh;
						newPrefab.GetComponent<MeshCollider>().sharedMesh.name = newPrefab.GetComponent<MeshFilter>().sharedMesh.name;
					}
					if ((bool)newPrefab.GetComponent<MeshFilter>() && (bool)newPrefab.GetComponent<MeshFilter>().sharedMesh)
					{
						newPrefab.GetComponent<MeshFilter>().sharedMesh.RecalculateBounds();
					}
				}
			}
			if ((bool)newPrefab.GetComponent<MeshRenderer>())
			{
				newPrefab.GetComponent<MeshRenderer>().useLightProbes = useLightProbes;
				newPrefab.GetComponent<MeshRenderer>().castShadows = false;
			}
			if (!prefabScript.isCustomPrefab)
			{
				OQDQQDCCCC(newPrefab, prefab);
			}
			if (prefabScript.fullMeshVecs.Length == 0)
			{
				ODDQOOQODD(prefabScript);
			}
			prefabScript.baseScript = this;
			prefabScript.surroundingDistance = 0f;
			prefabScript.OCCQOOCCCQ(forceFlag: false);
			prefabScript.prefabId = prefab.GetComponent<ERCrossingPrefabs>().prefabId;
			return newPrefab;
		}

		public void ODDQOOQODD(ERCrossingPrefabs prefabScript)
		{
			prefabScript.fullMeshVecs = new Vector3[prefabScript.meshVecs.Length];
			Array.Copy(prefabScript.meshVecs, prefabScript.fullMeshVecs, prefabScript.meshVecs.Length);
			prefabScript.tmpFullMeshVecs = new Vector3[prefabScript.tmpMeshVecs.Length];
			Array.Copy(prefabScript.tmpMeshVecs, prefabScript.tmpFullMeshVecs, prefabScript.tmpMeshVecs.Length);
			for (int i = 0; i < prefabScript.crossingElements.Count; i++)
			{
				prefabScript.crossingElements[i].fullConnectionVecInts = new List<int>(prefabScript.crossingElements[i].connectionVecInts);
			}
		}

		public void OQDQQDCCCC(GameObject newPrefab, GameObject prefab)
		{
			List<GameObject> list = new List<GameObject>();
			foreach (Transform item in newPrefab.transform)
			{
				if (item.name != "surface")
				{
					list.Add(item.gameObject);
				}
			}
			foreach (GameObject item2 in list)
			{
				UnityEngine.Object.DestroyImmediate(item2);
			}
			foreach (Transform item3 in prefab.transform)
			{
				if (item3.name != "surface")
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(item3.gameObject);
					gameObject.name = item3.name;
					gameObject.transform.parent = newPrefab.transform;
					gameObject.transform.localPosition = item3.transform.localPosition;
					gameObject.transform.localScale = item3.transform.localScale;
					gameObject.transform.localEulerAngles = item3.transform.localEulerAngles;
				}
			}
		}

		public void ODQQQQQCOQ()
		{
			ERModularRoad[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
			ERModularRoad[] array2 = array;
			foreach (ERModularRoad eRModularRoad in array2)
			{
				if (eRModularRoad.startPrefabScript != null)
				{
					eRModularRoad.startPrefabScript.crossingElements[eRModularRoad.startConnectionSegment].connectedRoad = eRModularRoad;
					eRModularRoad.startPrefabScript.crossingElements[eRModularRoad.startConnectionSegment].connectedMarker = 0;
				}
				if (eRModularRoad.endPrefabScript != null)
				{
					eRModularRoad.endPrefabScript.crossingElements[eRModularRoad.endConnectionSegment].connectedRoad = eRModularRoad;
					eRModularRoad.endPrefabScript.crossingElements[eRModularRoad.endConnectionSegment].connectedMarker = eRModularRoad.markersExt.Count - 1;
				}
			}
		}

		public List<ERTerrain> OOQOOCQDCQ()
		{
			List<string> list = new List<string>();
			List<Terrain> list2 = new List<Terrain>();
			list.Add("All Terrains");
			list2.Add(null);
			List<ERTerrain> list3 = new List<ERTerrain>();
			float num = 0f;
			float num2 = (terrainDetailSplatX = 100f);
			float num3 = (terrainDetailSplatY = 100f);
			Terrain[] array = UnityEngine.Object.FindObjectsOfType(typeof(Terrain)) as Terrain[];
			Terrain[] array2 = array;
			foreach (Terrain terrain in array2)
			{
				if (terrain.terrainData != null)
				{
					if (terrain.gameObject.GetComponent<ERTerrain>() == null)
					{
						terrain.gameObject.AddComponent<ERTerrain>();
						list3.Add(terrain.gameObject.GetComponent<ERTerrain>());
					}
					else if (terrain.gameObject.GetComponent<ERTerrain>().terrainData != terrain.terrainData)
					{
						terrain.gameObject.GetComponent<ERTerrain>().terrainData = terrain.terrainData;
						list3.Add(terrain.gameObject.GetComponent<ERTerrain>());
					}
					list.Add(terrain.name);
					list2.Add(terrain);
					if (terrain.terrainData.heightmapScale.x > num)
					{
						num = terrain.terrainData.heightmapScale.x;
					}
					if (terrain.terrainData.heightmapScale.z > num)
					{
						num = terrain.terrainData.heightmapScale.z;
					}
					num2 = terrain.terrainData.size.x / ((float)terrain.terrainData.detailResolution * 1f);
					num3 = terrain.terrainData.size.z / ((float)terrain.terrainData.detailResolution * 1f);
					if (num2 < terrainDetailSplatX)
					{
						terrainDetailSplatX = num2;
					}
					if (num3 < terrainDetailSplatY)
					{
						terrainDetailSplatY = num3;
					}
				}
			}
			terrainNames = list.ToArray();
			terrainObjects = list2.ToArray();
			num *= 1.5f;
			if (!ignoreMinIndents)
			{
				terrainMinIndent = num;
				if (num > minIndent)
				{
					minIndent = num;
				}
			}
			else
			{
				minIndent = 0f;
			}
			terrainDetailSplatX *= 0.5f;
			terrainDetailSplatY *= 0.5f;
			detailOffsetVec = new Vector3(terrainDetailSplatX, 0f, terrainDetailSplatY);
			if (array.Length > 0)
			{
				List<string> list4 = new List<string>();
				SplatPrototype[] splatPrototypes = array[0].terrainData.splatPrototypes;
				foreach (SplatPrototype splatPrototype in splatPrototypes)
				{
					if (splatPrototype.texture != null)
					{
						list4.Add("Splat " + (list4.Count + 1) + " - " + splatPrototype.texture.name);
					}
					else
					{
						list4.Add("Splat " + (list4.Count + 1) + " - Empty");
					}
				}
				terrainSplatTextures = list4.ToArray();
			}
			return list3;
		}

		public void OQOCCDODCO()
		{
			QDQDOOQQOOQDD.OQOCCDODCO(this, terrainObjects[selectedTerrain]);
		}

		public void OOQQOOQODO(bool restoreTerrain)
		{
			ERTerrain[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERTerrain)) as ERTerrain[];
			if (restoreTerrain)
			{
				ERTerrain[] array2 = array;
				foreach (ERTerrain eRTerrain in array2)
				{
					if (eRTerrain.terrainDone)
					{
						QDQDOOQQOOQDD.OQDQDDDOOQ(this, eRTerrain, eRTerrain.gameObject.GetComponent<Terrain>());
					}
				}
			}
			if (this != null)
			{
				baseVector = Vector3.zero;
				Transform transform = base.transform.Find("Connection Objects");
				transform.position = baseVector;
				transform = base.transform.Find("Road Objects");
				transform.position = baseVector;
			}
			int num = 0;
			List<int> list = new List<int>();
			foreach (GameObject surfaceObject in surfaceObjects)
			{
				num++;
				if (surfaceObject != null)
				{
					surfaceObject.SetActive(value: true);
					surfaceObject.GetComponent<MeshCollider>().enabled = !hideSurfaces;
				}
				else
				{
					Debug.LogWarning("Missing surface detected [" + num + "]: Are all objects correctly restored?");
					list.Add(num - 1);
				}
			}
			if (list.Count > 0)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (surfaceObjects.Count > list[j])
					{
						surfaceObjects.RemoveAt(list[j]);
						j--;
					}
				}
			}
			ERTerrain[] array3 = UnityEngine.Object.FindObjectsOfType(typeof(ERTerrain)) as ERTerrain[];
			ERSideObjectInstance[] array4 = ((!(this != null)) ? (UnityEngine.Object.FindObjectsOfType(typeof(ERSideObjectInstance)) as ERSideObjectInstance[]) : base.gameObject.GetComponentsInChildren<ERSideObjectInstance>());
			ERSideObjectInstance[] array5;
			if (soTrees)
			{
				array5 = array4;
				foreach (ERSideObjectInstance eRSideObjectInstance in array5)
				{
					if (!(eRSideObjectInstance.so != null) || eRSideObjectInstance.so.terrainTree == 0 || !buildSOinEditMode)
					{
						continue;
					}
					foreach (GameObject child in eRSideObjectInstance.childs)
					{
						if (child != null)
						{
							child.SetActive(value: true);
						}
					}
				}
				ERTerrain[] array2 = array3;
				foreach (ERTerrain eRTerrain2 in array2)
				{
					try
					{
						TerrainData terrainData = eRTerrain2.gameObject.GetComponent<Terrain>().terrainData;
						List<TreeInstance> list2 = new List<TreeInstance>(terrainData.treeInstances);
						foreach (ERTreeInstance addedTree in eRTerrain2.addedTrees)
						{
							for (int j = 0; j < list2.Count; j++)
							{
								if (addedTree.position.x == list2[j].position.x && addedTree.position.z == list2[j].position.z)
								{
									list2.RemoveAt(j);
									break;
								}
							}
						}
						eRTerrain2.addedTrees.Clear();
						terrainData.treeInstances = list2.ToArray();
					}
					catch
					{
						Debug.LogError("EasyRoads3Dv3: Removing trees added from side objects from terrain " + eRTerrain2.gameObject.name + " failed, please report with details!");
					}
				}
			}
			isInBuildMode = false;
			if (doLightmapUVs)
			{
				ERCrossings[] array6 = UnityEngine.Object.FindObjectsOfType(typeof(ERCrossings)) as ERCrossings[];
				ERCrossings[] array7 = array6;
				foreach (ERCrossings eRCrossings in array7)
				{
					try
					{
						eRCrossings.OODDODOQCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
					}
					catch
					{
						Debug.Log("Refresh failed: " + eRCrossings.gameObject.name);
					}
				}
				ERRoundabouts[] array8 = UnityEngine.Object.FindObjectsOfType(typeof(ERRoundabouts)) as ERRoundabouts[];
				ERRoundabouts[] array9 = array8;
				foreach (ERRoundabouts eRRoundabouts in array9)
				{
					try
					{
						eRRoundabouts.OCCQCOQODO();
						eRRoundabouts.OOCDCDDOQQ();
						if (eRRoundabouts.leftFlag && eRRoundabouts.rightFlag)
						{
							eRRoundabouts.OODOQQQCDD();
							if (eRRoundabouts.connections.Count > 0)
							{
								eRRoundabouts.OQCDOOOQDQ();
							}
						}
					}
					catch
					{
						Debug.Log("Refresh failed: " + eRRoundabouts.gameObject.name);
					}
				}
			}
			array5 = array4;
			foreach (ERSideObjectInstance eRSideObjectInstance in array5)
			{
				try
				{
					if (!(eRSideObjectInstance.so != null) || eRSideObjectInstance.so.terrainTree != 0)
					{
						continue;
					}
					ERModularRoad component = eRSideObjectInstance.transform.parent.GetComponent<ERModularRoad>();
					bool flag = true;
					if (selectedRoadsOnly)
					{
						flag = false;
						for (int j = 0; j < selectedObjects.Count; j++)
						{
							if (selectedObjects[j].roadScr == component)
							{
								flag = true;
								break;
							}
						}
					}
					if (!(component != null) || !flag)
					{
						continue;
					}
					bool flag2 = false;
					for (int k = 0; k < component.soDataExt.Count; k++)
					{
						if (component.soDataExt[k].sideObject.id == eRSideObjectInstance.so.id && component.soDataExt[k].active)
						{
							flag2 = true;
							break;
						}
					}
					if (flag2 && flag)
					{
						OCQQCCQCCO.ODDQCOQQDD(this, component, eRSideObjectInstance.so);
						if (buildSOinEditMode || component.isSideObject)
						{
							OCQQCCQCCO.OQOCCQOQQO(this, component, eRSideObjectInstance.so);
						}
					}
					component.sosCleared = false;
				}
				catch
				{
					string text = "[none]";
					if (eRSideObjectInstance != null)
					{
						if (eRSideObjectInstance.transform.parent != null)
						{
							text = eRSideObjectInstance.transform.parent.name;
						}
						Debug.LogError("EasyRoads3Dv3: Rebuilding side object " + eRSideObjectInstance.gameObject.name + " on object " + text + " failed, please report with details!");
					}
				}
			}
			if (soDeformationObjects.Count > 0)
			{
				foreach (GameObject soDeformationObject in soDeformationObjects)
				{
					if (soDeformationObject != null)
					{
						soDeformationObject.SetActive(value: true);
						if ((bool)soDeformationObject.GetComponent<MeshCollider>())
						{
							soDeformationObject.GetComponent<MeshCollider>().enabled = true;
						}
					}
				}
				soDeformationObjects.Clear();
			}
			if (doSplatmaps && restoreTerrain)
			{
				ERTerrain[] array2 = array3;
				foreach (ERTerrain eRTerrain2 in array2)
				{
					try
					{
						if (eRTerrain2.splatData.Count > 0)
						{
							TerrainData terrainData = eRTerrain2.gameObject.GetComponent<Terrain>().terrainData;
							float[,,] alphamaps = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
							foreach (ERSplatmap splatDatum in eRTerrain2.splatData)
							{
								if (!newSplatMapRestoreCode)
								{
									if (splatDatum.index <= 4)
									{
										if (terrainData.alphamapLayers > 0)
										{
											alphamaps[splatDatum.x, splatDatum.y, 0] = splatDatum.tValue1;
										}
										if (terrainData.alphamapLayers > 1)
										{
											alphamaps[splatDatum.x, splatDatum.y, 1] = splatDatum.tValue2;
										}
										if (terrainData.alphamapLayers > 2)
										{
											alphamaps[splatDatum.x, splatDatum.y, 2] = splatDatum.tValue3;
										}
										if (terrainData.alphamapLayers > 3)
										{
											alphamaps[splatDatum.x, splatDatum.y, 3] = splatDatum.tValue4;
										}
									}
									else if (splatDatum.index <= 8)
									{
										if (terrainData.alphamapLayers > 4)
										{
											alphamaps[splatDatum.x, splatDatum.y, 4] = splatDatum.tValue1;
										}
										if (terrainData.alphamapLayers > 5)
										{
											alphamaps[splatDatum.x, splatDatum.y, 5] = splatDatum.tValue2;
										}
										if (terrainData.alphamapLayers > 6)
										{
											alphamaps[splatDatum.x, splatDatum.y, 6] = splatDatum.tValue3;
										}
										if (terrainData.alphamapLayers > 7)
										{
											alphamaps[splatDatum.x, splatDatum.y, 7] = splatDatum.tValue4;
										}
									}
								}
								else
								{
									if (terrainData.alphamapLayers > 0)
									{
										alphamaps[splatDatum.x, splatDatum.y, 0] = splatDatum.tValue1;
									}
									if (terrainData.alphamapLayers > 1)
									{
										alphamaps[splatDatum.x, splatDatum.y, 1] = splatDatum.tValue2;
									}
									if (terrainData.alphamapLayers > 2)
									{
										alphamaps[splatDatum.x, splatDatum.y, 2] = splatDatum.tValue3;
									}
									if (terrainData.alphamapLayers > 3)
									{
										alphamaps[splatDatum.x, splatDatum.y, 3] = splatDatum.tValue4;
									}
									if (terrainData.alphamapLayers > 4)
									{
										alphamaps[splatDatum.x, splatDatum.y, 4] = splatDatum.tValue5;
									}
									if (terrainData.alphamapLayers > 5)
									{
										alphamaps[splatDatum.x, splatDatum.y, 5] = splatDatum.tValue6;
									}
									if (terrainData.alphamapLayers > 6)
									{
										alphamaps[splatDatum.x, splatDatum.y, 6] = splatDatum.tValue7;
									}
									if (terrainData.alphamapLayers > 7)
									{
										alphamaps[splatDatum.x, splatDatum.y, 7] = splatDatum.tValue8;
									}
								}
							}
							terrainData.SetAlphamaps(0, 0, alphamaps);
						}
					}
					catch
					{
						Debug.LogError("EasyRoads3Dv3: Restoring the splatmap for terrain " + eRTerrain2.gameObject.name + " failed, please report with details!");
					}
					eRTerrain2.splatmapFlag = false;
				}
			}
			if (lodGroups)
			{
				ERModularRoad[] array10 = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
				ERModularRoad[] array11 = array10;
				foreach (ERModularRoad eRModularRoad in array11)
				{
					bool flag = true;
					if (selectedRoadsOnly)
					{
						flag = false;
						for (int j = 0; j < selectedObjects.Count; j++)
						{
							if (selectedObjects[j].roadScr == eRModularRoad)
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
					if ((bool)eRModularRoad.gameObject.GetComponent<LODGroup>())
					{
						UnityEngine.Object.DestroyImmediate(eRModularRoad.gameObject.GetComponent<LODGroup>());
					}
					for (int j = 0; j < LODLevels; j++)
					{
						Transform transform2 = eRModularRoad.transform.Find("LOD " + j);
						if ((bool)transform2)
						{
							UnityEngine.Object.DestroyImmediate(transform2.gameObject);
						}
					}
					if ((bool)eRModularRoad.GetComponent<MeshRenderer>())
					{
						eRModularRoad.GetComponent<MeshRenderer>().enabled = true;
					}
					if ((bool)eRModularRoad.GetComponent<MeshCollider>())
					{
						eRModularRoad.GetComponent<MeshCollider>().enabled = true;
					}
				}
			}
			try
			{
				if (doHeightmap && vegetationStudio && vegetationStudioActive && (object)hmMethod != null)
				{
					Bounds bounds = default(Bounds);
					object[] parameters = new object[1] { bounds };
					hmMethod.Invoke(null, parameters);
				}
			}
			catch
			{
			}
		}

		public void OQOQCOQOOQ(Vector3 pos)
		{
			if (meshSurface == null)
			{
				if (pos.x < terrainRect.x || pos.x > terrainRect.x + terrainRect.width || pos.z < terrainRect.y || pos.z > terrainRect.y + terrainRect.height || activeTerrain == null)
				{
					OQQOODOQDQ(ref pos, setSelected: false);
				}
			}
			else
			{
				activeTerrain = null;
			}
		}

		public void OCCDCQCOQC(ref Vector3 pos)
		{
			if (meshSurface == null)
			{
				if (pos.x < terrainRect.x || pos.x > terrainRect.x + terrainRect.width || pos.z < terrainRect.y || pos.z > terrainRect.y + terrainRect.height || activeTerrain == null)
				{
					OQQOODOQDQ(ref pos, setSelected: false);
				}
				if (activeTerrain != null)
				{
					pos.y = activeTerrainY + activeTerrain.SampleHeight(pos);
				}
				return;
			}
			Ray ray = default(Ray);
			Vector3 vector = pos;
			vector.y += 1f;
			ray.origin = pos;
			ray.direction = Vector3.down;
			if (meshTerrainCollider != null && meshTerrainCollider.Raycast(ray, out var hitInfo, 10f))
			{
				pos.y = hitInfo.point.y;
			}
		}

		public Vector3 ODQQCDQCQO(Vector3 pos)
		{
			if (pos.x < terrainRect.x || pos.x > terrainRect.x + terrainRect.width || pos.z < terrainRect.y || pos.z > terrainRect.y + terrainRect.height)
			{
				OQQOODOQDQ(ref pos, setSelected: false);
			}
			OQQOODOQDQ(ref pos, setSelected: false);
			if (activeTerrain != null)
			{
				float x = (pos.x - terrainRect.x) / activeTerrain.terrainData.size.x;
				float y = (pos.z - terrainRect.y) / activeTerrain.terrainData.size.z;
				return activeTerrain.terrainData.GetInterpolatedNormal(x, y);
			}
			return Vector3.up;
		}

		public Vector2 GetTerrainUV(Vector3 pos)
		{
			Vector2 zero = Vector2.zero;
			if (meshSurface == null)
			{
				if (pos.x < terrainRect.x || pos.x > terrainRect.x + terrainRect.width || pos.z < terrainRect.y || pos.z > terrainRect.y + terrainRect.height || activeTerrain == null)
				{
					OQQOODOQDQ(ref pos, setSelected: false);
				}
				zero.x = (pos.x - terrainRect.x) / terrainRect.width;
				zero.y = (pos.z - terrainRect.y) / terrainRect.height;
			}
			else
			{
				zero = Vector2.zero;
			}
			return zero;
		}

		public Terrain OQQOODOQDQ(ref Vector3 pos, bool setSelected)
		{
			if (terrainObjects == null)
			{
				OOQOOCQDCQ();
				if (terrainObjects == null)
				{
					Debug.LogWarning("No terrain found, EasyRoads3Dv3 requires at least one terrain object!");
				}
			}
			int num = 0;
			Terrain[] array = terrainObjects;
			foreach (Terrain terrain in array)
			{
				if (terrain != null && pos.x > terrain.transform.position.x && pos.x < terrain.transform.position.x + terrain.terrainData.size.x && pos.z > terrain.transform.position.z && pos.z < terrain.transform.position.z + terrain.terrainData.size.z)
				{
					if (setSelected)
					{
						if (selectedTerrain == num)
						{
							selectedTerrain = 0;
							return null;
						}
						selectedTerrain = num;
						return terrain;
					}
					terrainRect.x = terrain.transform.position.x;
					terrainRect.width = terrain.terrainData.size.x;
					terrainRect.y = terrain.transform.position.z;
					terrainRect.height = terrain.terrainData.size.z;
					activeTerrain = terrain;
					activeTerrainY = (terrainY = activeTerrain.transform.position.y);
				}
				num++;
			}
			return null;
		}

		public void OCCOCCOCCC()
		{
			LODLevels = 4;
			LODLevelValues.Clear();
			LODLevelValues.Add(0.6f);
			LODLevelValues.Add(0.4f);
			LODLevelValues.Add(0.2f);
			LODLevelValues.Add(0f);
			LODLevelResolution.Clear();
			LODLevelResolution.Add(0.9f);
			LODLevelResolution.Add(0.8f);
			LODLevelResolution.Add(0.6f);
			LODLevelResolution.Add(0.4f);
		}

		public void UpdateLODLevels(int levels)
		{
			if (levels < LODLevelValues.Count)
			{
				while (levels < LODLevelValues.Count)
				{
					LODLevelValues.RemoveAt(LODLevelValues.Count - 1);
					LODLevelResolution.RemoveAt(LODLevelResolution.Count - 1);
				}
			}
			else
			{
				while (levels > LODLevelValues.Count)
				{
					LODLevelValues.Add(0f);
					LODLevelResolution.Add(0f);
				}
			}
		}

		public void UpdateSideObjectsInScene()
		{
			if (RoadObjectsSoUpdates.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < RoadObjectsSoUpdates.Count; i++)
			{
				if (RoadObjectsSoUpdates[i] != null)
				{
					OCQQCCQCCO.OQOCCODQOC(this, RoadObjectsSoUpdates[i], isSideObjectFlag: false);
				}
			}
			RoadObjectsSoUpdates.Clear();
		}

		public void ODCQOCQDOD()
		{
			ERSurfaceScript[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERSurfaceScript)) as ERSurfaceScript[];
			ERSurfaceScript[] array2 = array;
			foreach (ERSurfaceScript eRSurfaceScript in array2)
			{
				eRSurfaceScript.gameObject.GetComponent<MeshRenderer>().enabled = !hideSurfaces;
				eRSurfaceScript.gameObject.GetComponent<MeshCollider>().enabled = !hideSurfaces;
			}
		}

		public void ODCCCCDOOC()
		{
			ERSurfaceScript[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERSurfaceScript)) as ERSurfaceScript[];
			ERSurfaceScript[] array2 = array;
			foreach (ERSurfaceScript eRSurfaceScript in array2)
			{
				if ((bool)eRSurfaceScript.transform.parent.gameObject.GetComponent<MeshRenderer>())
				{
					eRSurfaceScript.transform.parent.gameObject.GetComponent<MeshRenderer>().useLightProbes = useLightProbes;
					eRSurfaceScript.transform.parent.gameObject.GetComponent<MeshRenderer>().castShadows = false;
				}
			}
		}

		public ERRoadType[] GetRoadTypes()
		{
			List<ERRoadType> list = new List<ERRoadType>();
			foreach (QDQDOOQQDQODD roadType in roadTypes)
			{
				ERRoadType eRRoadType = new ERRoadType();
				eRRoadType.id = roadType.id;
				eRRoadType.roadTypeName = roadType.roadTypeName;
				eRRoadType.roadWidth = roadType.roadWidth;
				eRRoadType.roadShape = new List<Vector2>(roadType.roadShape);
				eRRoadType.doConnectionTri = new List<bool>(roadType.doConnectionTri);
				eRRoadType.roadShapeUVs = new List<float>(roadType.roadShapeUVs);
				eRRoadType.hardEdge = new List<bool>(roadType.hardEdge);
				eRRoadType.sidewalks = roadType.sidewalks;
				eRRoadType.sidewalkHeight = roadType.sidewalkHeight;
				eRRoadType.sidewalkWidth = roadType.sidewalkWidth;
				eRRoadType.roadMaterial = roadType.roadMaterial;
				eRRoadType.connectionMaterial = roadType.connectionMaterial;
				eRRoadType.terrainDeformation = roadType.terrainDeformation;
				eRRoadType.faceDistance = roadType.faceDistance;
				eRRoadType.isSideObject = roadType.isSideObject;
				eRRoadType.soDataExt = new List<ERSORoadExt>();
				for (int i = 0; i < roadType.soDataExt.Count; i++)
				{
					if (roadType.soDataExt[i] != null && roadType.soDataExt[i].sideObject != null)
					{
						eRRoadType.soDataExt.Add(ERSORoadExt.CreateInstance(roadType.soDataExt[i].sideObject));
						if (roadType.soDataExt[i].active)
						{
							eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].active = true;
						}
					}
				}
				list.Add(eRRoadType);
			}
			return list.ToArray();
		}

		public ERRoadType GetRoadTypeByName(string name)
		{
			List<ERRoadType> list = new List<ERRoadType>();
			foreach (QDQDOOQQDQODD roadType in roadTypes)
			{
				if (!(roadType.roadTypeName == name))
				{
					continue;
				}
				ERRoadType eRRoadType = new ERRoadType();
				eRRoadType.id = roadType.id;
				eRRoadType.roadTypeName = roadType.roadTypeName;
				eRRoadType.roadWidth = roadType.roadWidth;
				eRRoadType.roadShape = new List<Vector2>(roadType.roadShape);
				eRRoadType.doConnectionTri = new List<bool>(roadType.doConnectionTri);
				eRRoadType.roadShapeUVs = new List<float>(roadType.roadShapeUVs);
				eRRoadType.hardEdge = new List<bool>(roadType.hardEdge);
				eRRoadType.sidewalks = roadType.sidewalks;
				eRRoadType.sidewalkHeight = roadType.sidewalkHeight;
				eRRoadType.sidewalkWidth = roadType.sidewalkWidth;
				eRRoadType.roadMaterial = roadType.roadMaterial;
				eRRoadType.connectionMaterial = roadType.connectionMaterial;
				eRRoadType.terrainDeformation = roadType.terrainDeformation;
				eRRoadType.faceDistance = roadType.faceDistance;
				eRRoadType.isSideObject = roadType.isSideObject;
				eRRoadType.soDataExt = new List<ERSORoadExt>();
				for (int i = 0; i < roadType.soDataExt.Count; i++)
				{
					eRRoadType.soDataExt.Add(ERSORoadExt.CreateInstance(roadType.soDataExt[i].sideObject));
					if (roadType.soDataExt[i].active)
					{
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].active = true;
					}
				}
				return eRRoadType;
			}
			return null;
		}

		public string GetNewRoadName(double id)
		{
			string roadNameByID = GetRoadNameByID(id);
			if (roadNameByID == "new road")
			{
				Transform transform = base.transform.Find("Road Objects");
				if (transform != null)
				{
					return "new road " + (transform.childCount + 1);
				}
				return "new road";
			}
			ERModularRoad[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
			int num = 1;
			ERModularRoad[] array2 = array;
			foreach (ERModularRoad eRModularRoad in array2)
			{
				if (eRModularRoad.roadType == id)
				{
					num++;
				}
			}
			if (num < 1000)
			{
				return roadNameByID + " 00" + num;
			}
			if (num < 100)
			{
				return roadNameByID + " 0" + num;
			}
			return roadNameByID + " " + num;
		}

		public string GetRoadNameByID(double id)
		{
			foreach (QDQDOOQQDQODD roadType in roadTypes)
			{
				if (roadType.id == id)
				{
					return roadType.roadTypeName;
				}
			}
			return "new road";
		}

		public void InitLoadImage(string url)
		{
			StartCoroutine(LoadImage(url));
		}

		private IEnumerator LoadImage(string url)
		{
			ᙃ ᙃ2 = new ᙃ(0);
			ᙃ2._003C_003E4__this = this;
			ᙃ2.url = url;
			return ᙃ2;
		}

		public float OCQDCQCOQQ(Vector3 fwd, Vector3 targetDir, Vector3 up)
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
	}
}
