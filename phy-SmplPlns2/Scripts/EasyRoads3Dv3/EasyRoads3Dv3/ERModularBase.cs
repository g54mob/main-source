using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[HelpURL("https://www.easyroads3d.com/v3/manualv3.html")]
	[AddComponentMenu("")]
	public class ERModularBase : MonoBehaviour
	{
		public delegate void RoadUpdate(ERRoad road);

		public delegate void OnBuildMode();

		public delegate void SideObjectUpdate(ERSideObjectInstance soInstance);

		private sealed class ussst : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string url;

			public int target;

			public ERModularBase _003C_003E4__this;

			private UnityWebRequest _003Cwww_003E5__1;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public ussst(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = _003C_003E1__state;
				if (num != -3 && num != 1)
				{
					return;
				}
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					default:
						return false;
					case 0:
						_003C_003E1__state = -1;
						_003Cwww_003E5__1 = UnityWebRequestTexture.GetTexture(url);
						_003C_003E1__state = -3;
						_003C_003E2__current = _003Cwww_003E5__1.SendWebRequest();
						_003C_003E1__state = 1;
						return true;
					case 1:
						_003C_003E1__state = -3;
						if (_003Cwww_003E5__1.isNetworkError || _003Cwww_003E5__1.isHttpError)
						{
							UnityEngine.Debug.Log(_003Cwww_003E5__1.error);
						}
						else
						{
							_003C_003E4__this.tex = DownloadHandlerTexture.GetContent(_003Cwww_003E5__1);
							if (target == 1)
							{
								_003C_003E4__this.infoTexture = _003C_003E4__this.tex;
							}
							else if (target == 2)
							{
								_003C_003E4__this.infoTexture2 = _003C_003E4__this.tex;
							}
							_003C_003E4__this.infoTextures.Add(_003C_003E4__this.tex);
						}
						_003C_003Em__Finally1();
						_003Cwww_003E5__1 = null;
						return false;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
				_003C_003E1__state = -1;
				if (_003Cwww_003E5__1 != null)
				{
					((IDisposable)_003Cwww_003E5__1).Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private sealed class vssss : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ERRoadNetwork roadNetwork;

			public ERModularBase _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public vssss(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					roadNetwork.BuildRoadNetwork();
					UnityEngine.Debug.Log("done");
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					return false;
				}
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
		}

		[HideInInspector]
		public string projectid = "";

		[HideInInspector]
		public string resourcesFolderName = "Resources";

		public string resourcesFullFolderName = "";

		[HideInInspector]
		public bool runtimeAIFlag = true;

		public bool runtimeRoadNetworkFlag = true;

		[HideInInspector]
		public int updateInt = 11;

		[HideInInspector]
		public bool newSplatMapRestoreCode = false;

		[HideInInspector]
		public static string version = "buildVersion";

		[HideInInspector]
		public static bool isHDRP = false;

		[HideInInspector]
		public static bool isURP = false;

		[HideInInspector]
		public int toolbarInt = 0;

		[HideInInspector]
		public int oldToolbarInt = 0;

		[HideInInspector]
		public int roadToolbarInt = 0;

		[HideInInspector]
		public int markerToolbarInt = 0;

		public Texture[] menuTexs;

		public GUIContent[] menuGUIContents;

		[HideInInspector]
		public Texture[] subMenuTexs;

		[HideInInspector]
		public GameObject cprefab;

		[HideInInspector]
		public Texture nodeHandleTexture;

		[HideInInspector]
		public Texture lockedTexture;

		[HideInInspector]
		public Texture unLockedTexture;

		[HideInInspector]
		public Texture favOffTexture;

		[HideInInspector]
		public Texture favOffFreeTexture;

		[HideInInspector]
		public Texture favOnTexture;

		[HideInInspector]
		public Texture selRoadTexture;

		[HideInInspector]
		public Texture headerTexture;

		[HideInInspector]
		public Texture sceneGUITex;

		[HideInInspector]
		public Texture soIcon;

		[HideInInspector]
		public Texture closeIcon;

		[HideInInspector]
		public Texture refreshIcon;

		[HideInInspector]
		public Texture refreshIconOff;

		[HideInInspector]
		public Transform roadObjectsParent;

		[HideInInspector]
		public Transform connectionObjectsParent;

		[HideInInspector]
		public GameObject OCDCCCQCCQ;

		public List<QDQDOOQQDQODD> roadTypes = new List<QDQDOOQQDQODD>();

		[HideInInspector]
		public int selectedRoadType = 0;

		[HideInInspector]
		public int selectedNewRoadType = 0;

		[HideInInspector]
		public List<QDQDOOQQDQODD> inspRoadTypes = new List<QDQDOOQQDQODD>();

		[HideInInspector]
		public List<int> inspRoadTypeInts = new List<int>();

		[HideInInspector]
		public bool roadTypesSoFoldOutActive = true;

		[HideInInspector]
		public List<ERDecal> decalPresets = new List<ERDecal>();

		[HideInInspector]
		public bool roadTypesDecalsFoldOutActive = true;

		[HideInInspector]
		public float roadWidth = 5f;

		[HideInInspector]
		public Material roadMaterial;

		[HideInInspector]
		public Material crossingMaterial;

		[HideInInspector]
		public Material roundAboutMaterial;

		[HideInInspector]
		public Material roundAboutConnectionMaterial;

		[HideInInspector]
		public Material roundAboutRoadMaterial;

		[HideInInspector]
		public Material sidewalkMaterial;

		[HideInInspector]
		public Material targetMaterial;

		[HideInInspector]
		public Terrain sourceTerrain;

		[HideInInspector]
		public string[] roadMaterials;

		[HideInInspector]
		public string[] connectionMaterials;

		[HideInInspector]
		public int selectedMaterial = 0;

		[HideInInspector]
		public int selectedConnectionMaterial = 0;

		[HideInInspector]
		public List<ERMaterial> materials = new List<ERMaterial>();

		[HideInInspector]
		public int selectedRoadRoadType = 0;

		[HideInInspector]
		public bool roadOptions = true;

		[HideInInspector]
		public bool sidewalkOptions = false;

		[HideInInspector]
		public bool markerOptions = true;

		[HideInInspector]
		public bool showRoadSideObjects = false;

		[HideInInspector]
		public bool markerSOOptions = true;

		[HideInInspector]
		public bool roadTerrainOptions = true;

		[HideInInspector]
		public bool camFlyOver = true;

		[HideInInspector]
		public bool advancedRoadOptions = true;

		[HideInInspector]
		public bool advancedMarkerOptions = true;

		[HideInInspector]
		public int selectedRoadMaterial = 0;

		[HideInInspector]
		public int roadTextureInfoIndex = 0;

		[HideInInspector]
		public Texture2D selectedRoadTexture;

		[HideInInspector]
		public float selectedRoadWidth = 0f;

		[HideInInspector]
		public float selectedRoadLeftOffset = 0f;

		[HideInInspector]
		public float selectedRoadRightOffset = 0f;

		[HideInInspector]
		public float selectedRoadLeftInnerOffset = 0f;

		[HideInInspector]
		public float selectedRoadRightInnerOffset = 0f;

		[HideInInspector]
		public int selectedCrossingMaterial = 0;

		[HideInInspector]
		public int crossingTextureInfoIndex = 0;

		[HideInInspector]
		public int handleSelection = 0;

		[HideInInspector]
		public int positionHandleSelection = 0;

		[HideInInspector]
		public bool markerDirXZ = false;

		[HideInInspector]
		public int markerDirXZInt = 0;

		[HideInInspector]
		public GameObject defaultCrossing;

		[HideInInspector]
		public GameObject defaultTCrossing;

		[HideInInspector]
		public GameObject defaultCulDeSac;

		[HideInInspector]
		public GameObject defaultRoundabout;

		[HideInInspector]
		public Texture2D tex;

		[HideInInspector]
		public Texture2D infoTexture = null;

		[HideInInspector]
		public Texture2D infoTexture2 = null;

		[HideInInspector]
		public List<Texture2D> infoTextures = new List<Texture2D>();

		[HideInInspector]
		public Texture2D plusSignTexture = null;

		[HideInInspector]
		public Texture2D minSignTexture = null;

		[HideInInspector]
		public Texture2D signPostHeaderBG = null;

		[HideInInspector]
		public Texture2D signPostListBG = null;

		[HideInInspector]
		public Texture2D signPostListSelBG = null;

		[HideInInspector]
		public int editorSkin = 0;

		[HideInInspector]
		public bool showAllPrefabs = true;

		[HideInInspector]
		public bool standardPrefabsFlag;

		[HideInInspector]
		public bool sceneSettingsFoldOut;

		[HideInInspector]
		public bool sceneRoadsFoldOut;

		[HideInInspector]
		public bool scenePrefabsFoldOut;

		[HideInInspector]
		public bool sidewalksFoldOut;

		[HideInInspector]
		public bool terrainManagementFoldOut;

		[HideInInspector]
		public bool importRoadDataFoldOut;

		[HideInInspector]
		public bool lodGroupsFoldOut;

		[HideInInspector]
		public bool defaultMaterialsFoldOut;

		[HideInInspector]
		public bool aiTrafficFoldout;

		[HideInInspector]
		public bool projectSettingsFoldout;

		[HideInInspector]
		public bool kmlFlag = false;

		[HideInInspector]
		public bool osmFlag = false;

		[HideInInspector]
		public bool useOSMHeights = false;

		[HideInInspector]
		public float heightRatio = 1f;

		[HideInInspector]
		public bool dynamicPrefabsFoldOut = true;

		[HideInInspector]
		public bool customPrefabsFoldOut = true;

		[HideInInspector]
		public List<ERConnectionGUIStatus> dynamicFavList = new List<ERConnectionGUIStatus>();

		[HideInInspector]
		public List<ERConnectionGUIStatus> customFavList = new List<ERConnectionGUIStatus>();

		[HideInInspector]
		public float prefabsDisplayType = 0f;

		[HideInInspector]
		public bool ignoreTerrainAlerts = false;

		[HideInInspector]
		public double osmTerrainTopLon;

		[HideInInspector]
		public double osmTerrainBottomLon;

		[HideInInspector]
		public double osmTerrainLeftLat;

		[HideInInspector]
		public double osmTerrainRightLat;

		[HideInInspector]
		public bool terrainCheckDone = false;

		public float terrainMinIndent = 0.5f;

		[HideInInspector]
		public float terrainCellSize = 1f;

		public float minIndent = 0.5f;

		public float minSurrounding = 0.5f;

		public bool ignoreMinIndents = false;

		[HideInInspector]
		public float surroundingHeightFactor = 0.5f;

		[HideInInspector]
		public float terrainCellAngleThreshold = 90f;

		[HideInInspector]
		public float terrainCellHeightThreshold = 25f;

		[HideInInspector]
		public float maxIndentSurrounding = 50f;

		[HideInInspector]
		public float terrainY = 0f;

		[HideInInspector]
		public float terrainDetailSplatX = 0f;

		[HideInInspector]
		public float terrainDetailSplatY = 0f;

		[HideInInspector]
		public Vector3 detailOffsetVec;

		public float raise = 0.02f;

		[HideInInspector]
		public Vector3 baseVector = Vector3.zero;

		[HideInInspector]
		public bool mirrorCrossings = true;

		[HideInInspector]
		public string[] terrainNames;

		[HideInInspector]
		public Terrain[] terrainObjects;

		[HideInInspector]
		public string[] terrainSplatTextures;

		[HideInInspector]
		public Terrain activeTerrain;

		[HideInInspector]
		public float activeTerrainY;

		[HideInInspector]
		public int selectedTerrain = 0;

		[HideInInspector]
		public bool selectedRoadsOnly = false;

		[HideInInspector]
		public bool terrainDone;

		[HideInInspector]
		public bool enableBackWithoutRestore = false;

		[HideInInspector]
		public float detailDistance = 3f;

		[HideInInspector]
		public float treeDistance = 5f;

		[HideInInspector]
		public bool doHeightmap = true;

		[HideInInspector]
		public bool doTrees = true;

		[HideInInspector]
		public bool soTrees = true;

		[HideInInspector]
		public bool doDetail = true;

		[HideInInspector]
		public Rect terrainRect = default(Rect);

		[HideInInspector]
		public List<GameObject> tunnelObjects = new List<GameObject>();

		[HideInInspector]
		public List<GameObject> surfaceObjects = new List<GameObject>();

		[HideInInspector]
		public float preserveTerrainFloat = 1f;

		[HideInInspector]
		public float terrainSmoothIndentDistance = 1f;

		[HideInInspector]
		public float terrainSmoothSurroundingDistance = 1f;

		[HideInInspector]
		public int indentSmoothStep = 0;

		[HideInInspector]
		public int surroundingSmoothStep = 0;

		public float terrainRaycastHeight = 100f;

		[HideInInspector]
		public bool doTangents = true;

		[HideInInspector]
		public bool doLightmapUVs = false;

		[HideInInspector]
		public bool doLODGroups = false;

		[HideInInspector]
		public bool doSplatmaps = false;

		[HideInInspector]
		public int sLayer = 31;

		[HideInInspector]
		public List<Vector3> terrainHits = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> osmCrossingPoints = new List<Vector3>();

		[HideInInspector]
		public List<CrossingCornerClass> cornerPresets = new List<CrossingCornerClass>();

		[HideInInspector]
		public List<SidewalkPresetClass> sidewalkPresets = new List<SidewalkPresetClass>();

		public List<ERSideWalk> sidewalks = new List<ERSideWalk>();

		[HideInInspector]
		public int selectedSidewalk = 0;

		[HideInInspector]
		public int selectedRoadTypeSidewalk = 0;

		[HideInInspector]
		public int osmMotorway = 0;

		[HideInInspector]
		public int osmMotorwayLink = 0;

		[HideInInspector]
		public int osmTrunk = 0;

		[HideInInspector]
		public int osmPrimary = 0;

		[HideInInspector]
		public int osmSecondary = 0;

		[HideInInspector]
		public int osmTertiary = 0;

		[HideInInspector]
		public int osmUnclassified = 0;

		[HideInInspector]
		public int osmResidential = 0;

		[HideInInspector]
		public int osmService = 0;

		[HideInInspector]
		public int osmTrack = 0;

		[HideInInspector]
		public int osmPath = 0;

		[HideInInspector]
		public int osmWalkway = 0;

		[HideInInspector]
		public int osmRaceway = 0;

		[HideInInspector]
		public int osmHighwayStringInt = 0;

		[HideInInspector]
		public bool osmMotorwayFlag = true;

		[HideInInspector]
		public bool osmMotorwayLinkFlag = true;

		[HideInInspector]
		public bool osmTrunkFlag = true;

		[HideInInspector]
		public bool osmPrimaryFlag = true;

		[HideInInspector]
		public bool osmSecondaryFlag = true;

		[HideInInspector]
		public bool osmTertiaryFlag = true;

		[HideInInspector]
		public bool osmUnclassifiedFlag = true;

		[HideInInspector]
		public bool osmResidentialFlag = true;

		[HideInInspector]
		public bool osmServiceFlag = true;

		[HideInInspector]
		public bool osmTrackFlag = true;

		[HideInInspector]
		public bool osmPathFlag = true;

		[HideInInspector]
		public bool osmWalkwayFlag = false;

		[HideInInspector]
		public bool osmRacewayFlag = true;

		[HideInInspector]
		public string osmHighwayString = "";

		[HideInInspector]
		public bool osmInsertFlexConnectors = false;

		[HideInInspector]
		public List<ERRoad> osmRoadObjects = new List<ERRoad>();

		[HideInInspector]
		public List<ERConnection> osmConnectionObjects = new List<ERConnection>();

		[HideInInspector]
		public int kmlRoadType = 0;

		[HideInInspector]
		public float roadDataScale = 1f;

		[HideInInspector]
		public bool lodGroups = false;

		[HideInInspector]
		public int LODLevels = 4;

		[HideInInspector]
		public List<float> LODLevelValues = new List<float>();

		[HideInInspector]
		public List<float> LODLevelResolution = new List<float>();

		[HideInInspector]
		public bool embedRoadShape = false;

		[HideInInspector]
		public bool hideSurfaces = false;

		[HideInInspector]
		public bool showSurfaces = false;

		[HideInInspector]
		public bool useLightProbes = false;

		[HideInInspector]
		public bool hideLockedObjects = false;

		[HideInInspector]
		public bool OQOQCDQOCC = false;

		[HideInInspector]
		public bool isInBuildMode = false;

		[HideInInspector]
		public bool progressFlag = false;

		[HideInInspector]
		public int progressTerrain = 1;

		[HideInInspector]
		public float progressStatus = 1f;

		[HideInInspector]
		public float progressMax = 1f;

		public List<ERModularRoad> roadSoObjects = new List<ERModularRoad>();

		[SerializeField]
		public List<SideObject> QOQDQOOQDDQOOQ = new List<SideObject>();

		[HideInInspector]
		public string[] sideObjectNames = new string[0];

		[HideInInspector]
		public int selSideObject = 0;

		[HideInInspector]
		public int selSubSideObject = 0;

		[HideInInspector]
		public string soID = "";

		[HideInInspector]
		public string sideObjectName = "";

		[SerializeField]
		[HideInInspector]
		public int sideObjectType = 0;

		[HideInInspector]
		public GameObject sideObjectSource;

		[HideInInspector]
		public GameObject soEndObject;

		[HideInInspector]
		public int sideObjectTerrainVegetationInt = 0;

		[HideInInspector]
		public int prefabChildHandling = 0;

		[HideInInspector]
		public float sideObjectDistance = 1f;

		[HideInInspector]
		public int soYAxisRotation = 0;

		[HideInInspector]
		public float soSidewaysDistance = 0f;

		[HideInInspector]
		public int soSidewaysDistanceHandling = 0;

		[HideInInspector]
		public float soDensity = 1f;

		[HideInInspector]
		public float soOffset = 0f;

		[HideInInspector]
		public int soTerrainAligment = 0;

		[HideInInspector]
		public bool soCombine = false;

		[HideInInspector]
		public bool soWeld = false;

		[HideInInspector]
		public int soControllerType = 0;

		[HideInInspector]
		public Material soMaterial;

		[HideInInspector]
		public float soXPosition = 0f;

		[HideInInspector]
		public float soYPosition = 0f;

		[HideInInspector]
		public bool soMarkerActive = true;

		[HideInInspector]
		public bool enableSOHandles = false;

		[HideInInspector]
		public bool enableShapeNodeHandles = false;

		[HideInInspector]
		public bool enableSOShapeNodeHandles = false;

		[HideInInspector]
		public bool displayCriticalPoints = true;

		[HideInInspector]
		public bool highlightRoad = true;

		[HideInInspector]
		public bool highlightMarkerSection = true;

		[HideInInspector]
		public bool highlightIndents = true;

		[HideInInspector]
		public bool highlightSurroundings = true;

		[HideInInspector]
		public bool tempHighlights = false;

		[HideInInspector]
		public bool tempHighlightRoad = false;

		[HideInInspector]
		public bool tempHighlightIndents = false;

		[HideInInspector]
		public bool tempHighlightSurroundings = false;

		[HideInInspector]
		public bool highlightSideObject = true;

		[HideInInspector]
		public Color highlightRoadColor = new Color(0.39f, 0.53f, 0.9f, 0.1f);

		[HideInInspector]
		public Color highlightMarkerColor = new Color(0.6f, 0.15f, 0.15f, 0.25f);

		[HideInInspector]
		public Color highlightIndentColor = new Color(1f, 1f, 1f, 0.1f);

		[HideInInspector]
		public Color highlightSurroundingColor = new Color(1f, 1f, 1f, 0.05f);

		[HideInInspector]
		public bool highlightSurfacesDrag = false;

		[HideInInspector]
		public bool onlyShowSelectedRoad = false;

		[HideInInspector]
		public List<GameObject> soDeformationObjects = new List<GameObject>();

		[HideInInspector]
		public List<GameObject> soSplatmapObjects = new List<GameObject>();

		[HideInInspector]
		public bool buildSOinEditMode = true;

		[HideInInspector]
		public bool tangentsInEditMode = true;

		[HideInInspector]
		public bool calculateSmoothNormals = true;

		[HideInInspector]
		public bool importSideObjectsAlert = false;

		[HideInInspector]
		public bool importRoadPresetsAlert = false;

		[HideInInspector]
		public bool importCrossingPresetsAlert = false;

		[HideInInspector]
		public bool importSidewalkPresetsAlert = false;

		[HideInInspector]
		public bool updateSideObjectsAlert = false;

		[HideInInspector]
		public bool updateRoadPresetsAlert = false;

		[HideInInspector]
		public bool updateCrossingPresetsAlert = false;

		[HideInInspector]
		public bool updateSidewalkPresetsAlert = false;

		[HideInInspector]
		public float waypointDistance = 10f;

		[HideInInspector]
		public List<ERModularRoad> RoadObjectsSoUpdates = new List<ERModularRoad>();

		[HideInInspector]
		public List<ERCrossingPrefabs> connectionObjects = new List<ERCrossingPrefabs>();

		[HideInInspector]
		public List<ERCrossingPrefabs> connectionSWObjects = new List<ERCrossingPrefabs>();

		[HideInInspector]
		public string assetsFolderID = "";

		[HideInInspector]
		public GameObject meshSurface;

		[HideInInspector]
		public Collider meshTerrainCollider;

		public float markerScale = 1f;

		public float markerDistance = 400f;

		public float minMarkerDistance = 100f;

		public float maxMarkerDistance = 500f;

		[HideInInspector]
		public bool debugFlag = false;

		[HideInInspector]
		public List<Vector3> leftTHandles = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> rightTHandles = new List<Vector3>();

		[HideInInspector]
		public float roadNetworkY = 0f;

		[HideInInspector]
		public Vector3 zoomStart;

		[HideInInspector]
		public Vector3 zoomEnd;

		[HideInInspector]
		public Vector3 lookAtStart;

		[HideInInspector]
		public Vector3 lookAtEnd;

		[HideInInspector]
		public Quaternion zoomRot;

		[HideInInspector]
		public float zoomStartTime = 0f;

		[HideInInspector]
		public bool hideSurfaceHandles = false;

		[HideInInspector]
		public bool tempHideSurfaceHandles = true;

		[HideInInspector]
		public bool dirtyBool = false;

		[HideInInspector]
		public bool dirtyOnSceneBool = false;

		[HideInInspector]
		public bool forceRoadNetworkSelect = false;

		[HideInInspector]
		public bool OQDDOCDODD = true;

		[HideInInspector]
		public ERCrossingPrefabs OCDCCCQCCQScript = null;

		[HideInInspector]
		public ERCrossings OQOOOCQQODCrossingsScript;

		[HideInInspector]
		public ERCrossingPrefabs OQOOOCQQODScript;

		[HideInInspector]
		public int OCDCCCQCCQElement = -1;

		[HideInInspector]
		public int ODQDDDOQDQ = -1;

		[HideInInspector]
		public ERModularRoad OOOCDDCQCD;

		[HideInInspector]
		public ERModularRoad OOOOQQOQDQ;

		[HideInInspector]
		public ERModularRoad OCQODOCCCD;

		[HideInInspector]
		public int OODOOQQDQD = -1;

		[HideInInspector]
		public int selectedRoadSOMarker = -1;

		[HideInInspector]
		public int selectedMarkerNode = -1;

		[HideInInspector]
		public List<int> selectedMarkerNodes = new List<int>();

		[HideInInspector]
		public int selectedMarkerSONode = -1;

		[HideInInspector]
		public List<int> selectedMarkerSONodes = new List<int>();

		[HideInInspector]
		public List<SelectedObject> selectedObjects = new List<SelectedObject>();

		[HideInInspector]
		public int selectedExitRoad = -1;

		[HideInInspector]
		public bool newRoadFlag = false;

		[HideInInspector]
		public bool roadTypeUpdateFlag = false;

		[HideInInspector]
		public bool roadUpdateDragFlag = false;

		[HideInInspector]
		public bool mouseDragFlag = false;

		[HideInInspector]
		public List<ERModularRoad> roadScripts = new List<ERModularRoad>();

		[HideInInspector]
		public List<ERCrossingPrefabs> prefabScripts = new List<ERCrossingPrefabs>();

		[HideInInspector]
		public bool globalGridActive = false;

		[HideInInspector]
		public bool gridGUIActive = false;

		[HideInInspector]
		public Color globalGridColor = new Color(0.35f, 0.5f, 0.9f, 0.9f);

		[HideInInspector]
		public float globalGridSize = 50f;

		[HideInInspector]
		public float globalGridRadius = 1000f;

		[HideInInspector]
		public float globalGridRotation = 0f;

		[HideInInspector]
		public Vector2 gridOffset;

		[HideInInspector]
		public Vector3 ggTL;

		[HideInInspector]
		public Vector3 ggBL;

		[HideInInspector]
		public Vector3 ggBR;

		[HideInInspector]
		public bool localGridActive = false;

		[HideInInspector]
		public List<ERLocalGrid> localGrids = new List<ERLocalGrid>();

		[HideInInspector]
		public int selectedLocalGrid = 0;

		[HideInInspector]
		public MethodInfo crMethod;

		[HideInInspector]
		public MethodInfo upMethod;

		[HideInInspector]
		public MethodInfo hmMethod;

		[HideInInspector]
		public MethodInfo rmMethod;

		[HideInInspector]
		public MethodInfo crBiomeMethod;

		[HideInInspector]
		public MethodInfo upBiomeMethod;

		[HideInInspector]
		public MethodInfo rmBiomeMethod;

		[HideInInspector]
		public static MethodInfo dpcMethod;

		public static MethodInfo dprlMethod;

		[HideInInspector]
		public MethodInfo thMethodGet;

		[HideInInspector]
		public MethodInfo thMethodSet;

		[HideInInspector]
		public bool fbxExport = false;

		[HideInInspector]
		public MethodInfo fbxMethod;

		[HideInInspector]
		public ERSideWalk sw;

		[HideInInspector]
		public bool roadUpdated = false;

		[HideInInspector]
		public bool clampUVs = true;

		[HideInInspector]
		public int soCategoryInt = 0;

		[HideInInspector]
		public int soRoadCategoryInt = 0;

		public float minRoadWidth = 1f;

		public float maxRoadWidth = 75f;

		public float maxCurbHeight = 0.5f;

		public float maxRoundAboutWidth = 60f;

		public float maxRoundAboutRadius = 80f;

		public float minCornerRadius = 0.5f;

		public float maxCornerRadius = 5f;

		[HideInInspector]
		public float flexConnectorRadiusMultiplier = 1f;

		[HideInInspector]
		public GameObject SoTestObject;

		[HideInInspector]
		public bool lockRoadNetwork = false;

		[HideInInspector]
		public bool showNotifications = true;

		[HideInInspector]
		public bool multipleTerrainsWarning = false;

		[HideInInspector]
		public Texture2D[] ODOCDOQDQO = new Texture2D[0];

		[HideInInspector]
		public Texture2D[] OOOCOODCOQ = new Texture2D[0];

		[HideInInspector]
		public int textureCounter = 0;

		[HideInInspector]
		public static bool AssembliesSet = false;

		[HideInInspector]
		public bool vegetationStudio = false;

		[HideInInspector]
		public bool vegetationStudioPro = false;

		[HideInInspector]
		public bool vegetationStudioActive = false;

		[HideInInspector]
		public bool vegetationStudioMaskLineActive = true;

		[HideInInspector]
		public float vegetationStudioGrassPerimeter = 1f;

		[HideInInspector]
		public float vegetationStudioPlantPerimeter = 3f;

		[HideInInspector]
		public float vegetationStudioTreePerimeter = 4f;

		[HideInInspector]
		public float vegetationStudioObjectPerimeter = 3f;

		[HideInInspector]
		public float vegetationStudioLargeObjectPerimeter = 4f;

		[HideInInspector]
		public float vegetationStudioGrassPerimeterMax = 1f;

		[HideInInspector]
		public float vegetationStudioPlantPerimeterMax = 3f;

		[HideInInspector]
		public float vegetationStudioTreePerimeterMax = 4f;

		[HideInInspector]
		public float vegetationStudioObjectPerimeterMax = 3f;

		[HideInInspector]
		public float vegetationStudioLargeObjectPerimeterMax = 4f;

		[HideInInspector]
		public bool vegetationStudioBiomeMaskActive = false;

		[HideInInspector]
		public float vegetationStudioBiomeMaskDistance = 0f;

		[HideInInspector]
		public float vegetationStudioBiomeMaskBlendDistance = 0f;

		[HideInInspector]
		public float vegetationStudioBiomeMaskNoiseScale = 0f;

		[HideInInspector]
		public bool aiTraffic = false;

		[HideInInspector]
		public bool aiMatchingLanesOnly = true;

		[HideInInspector]
		public bool aiconnectNonMatchinglaneCounts = true;

		[HideInInspector]
		public bool aiIgnoreConnections = true;

		[HideInInspector]
		public bool displayLaneData = false;

		[HideInInspector]
		public float laneDataDisplayDistance = 100f;

		[HideInInspector]
		public int rightHandDriving = 1;

		[HideInInspector]
		public Color leftLaneHandleColour = new Color(0.1f, 0.1f, 0.1f, 0.75f);

		[HideInInspector]
		public Color rightLaneHandleColour = new Color(1f, 1f, 1f, 0.75f);

		[HideInInspector]
		public Color laneHandleSelectedColour = new Color(1f, 1f, 0f, 0.5f);

		[HideInInspector]
		public float roadUvThreshold = 1750f;

		[HideInInspector]
		public int updateQueue = 0;

		[HideInInspector]
		public static bool checkPresets = false;

		public bool scanPresetsFlag = false;

		[HideInInspector]
		public bool scanRPFlag = true;

		[HideInInspector]
		public bool logChange = false;

		public bool debugMode = false;

		[HideInInspector]
		public bool RoadNetworkInitFlag = false;

		public static RoadUpdate onRoadUpdate;

		public static OnBuildMode onBuildModeEnter;

		public static SideObjectUpdate onSideObjectUpdate;

		[HideInInspector]
		public List<GameObject> excludeFromSelection = new List<GameObject>();

		[HideInInspector]
		public GameObject addExcludeFromSelection;

		[HideInInspector]
		public Color shapeUVColor = Color.black;

		[HideInInspector]
		public Color startCapColor = new Color(0.35f, 0.5f, 0.9f, 1f);

		[HideInInspector]
		public Color endCapColor = new Color(0.35f, 0.5f, 0.9f, 1f);

		[HideInInspector]
		public Material soSectionMaterial;

		[HideInInspector]
		public bool v32b4Flag = false;

		[HideInInspector]
		public bool ctrlKey = false;

		[HideInInspector]
		public ERSideObjectSection soSectionInstance = null;

		[HideInInspector]
		public bool ignoreFlexConnectorUpdate = false;

		[HideInInspector]
		public bool surfaceChangeFlag = false;

		[HideInInspector]
		public float waterLevel = 0f;

		[HideInInspector]
		public float cornerRadiusMainRoad = 3f;

		[HideInInspector]
		public int cornerSementsMainRoad = 6;

		[HideInInspector]
		public float cornerRadiusSecondaryRoad = 3f;

		[HideInInspector]
		public float cornerRadiusSecondaryCurvature = 0.5f;

		[HideInInspector]
		public int cornerSementsSecondaryRoad = 6;

		[HideInInspector]
		public Material surfaceMaterial;

		[HideInInspector]
		public static float minSnapAngle = 35f;

		[HideInInspector]
		public static float maxSnapAngle = 145f;

		[HideInInspector]
		public List<ERPostInstances> postInstances = new List<ERPostInstances>();

		[HideInInspector]
		public bool synchSideObjects = true;

		[HideInInspector]
		public bool onSaleFlag = false;

		[HideInInspector]
		public string onSalePrice = "";

		[HideInInspector]
		public string onSalePercentage = "";

		[HideInInspector]
		public string onSaleString = "";

		[HideInInspector]
		public string onSaleDate = "";

		public void OnBuildModeEnter()
		{
			if (onBuildModeEnter != null)
			{
				onBuildModeEnter();
			}
		}

		public void OnRoadUpdate(ERRoad road)
		{
			if (onRoadUpdate != null)
			{
				onRoadUpdate(road);
			}
		}

		public void OnSideObjectUpdate(ERSideObjectInstance soInstance)
		{
			if (onSideObjectUpdate != null)
			{
				onSideObjectUpdate(soInstance);
			}
		}

		public void RoadNetworkInit()
		{
			importSideObjectsAlert = false;
			importRoadPresetsAlert = false;
			importCrossingPresetsAlert = false;
			importSidewalkPresetsAlert = false;
			rightHandDriving = 1;
			RoadNetworkInitFlag = true;
			terrainCellAngleThreshold = 90f;
			minIndent = 0f;
			toolbarInt = 0;
			sceneSettingsFoldOut = false;
			sceneRoadsFoldOut = false;
			scenePrefabsFoldOut = false;
			sidewalksFoldOut = false;
			terrainManagementFoldOut = false;
			importRoadDataFoldOut = false;
			lodGroupsFoldOut = false;
			defaultMaterialsFoldOut = false;
			aiTrafficFoldout = false;
			projectSettingsFoldout = false;
			markerDirXZ = true;
			markerDirXZInt = 2;
		}

		public void UpdateQueue()
		{
			int minInclusive = 1;
			int maxExclusive = 999999999;
			updateQueue = UnityEngine.Random.Range(minInclusive, maxExclusive);
		}

		public void SetRoadTypeList()
		{
			OOOOQQOQDQ = OOOCDDCQCD;
			roadTypeUpdateFlag = true;
			if (OOOCDDCQCD != null)
			{
				bool flag = true;
				if (OOOCDDCQCD.startPrefabScript != null && !OOOCDDCQCD.startPrefabScript.isFlexConnector && !OOOCDDCQCD.startPrefabScript.isIConnector)
				{
					flag = false;
				}
				bool flag2 = true;
				if (OOOCDDCQCD.endPrefabScript != null && !OOOCDDCQCD.endPrefabScript.isFlexConnector && !OOOCDDCQCD.endPrefabScript.isIConnector)
				{
					flag2 = false;
				}
				if (!flag || !flag2)
				{
					inspRoadTypes.Clear();
					inspRoadTypeInts.Clear();
					for (int i = 0; i < roadTypes.Count; i++)
					{
						if (ODDOQDDQCQ.ODCQDDQCCD(roadTypes[i].roadShape) == OOOCDDCQCD.roadShapeMatchCount)
						{
							inspRoadTypes.Add(roadTypes[i]);
							inspRoadTypeInts.Add(i);
							if (roadTypes[i].id == OOOCDDCQCD.roadType)
							{
								selectedRoadRoadType = inspRoadTypes.Count;
							}
						}
					}
					if (OOOCDDCQCD.startPrefabScript != null && OOOCDDCQCD.startPrefabScript.crossingElements.Count > OOOCDDCQCD.startConnectionSegment && OOOCDDCQCD.startConnectionSegment >= 0 && OOOCDDCQCD.startPrefabScript.crossingElements[OOOCDDCQCD.startConnectionSegment].roadShapeMatchCount != 2 && !flag)
					{
						roadTypeUpdateFlag = false;
					}
					if (OOOCDDCQCD.endPrefabScript != null && OOOCDDCQCD.endPrefabScript.crossingElements.Count > OOOCDDCQCD.endConnectionSegment && OOOCDDCQCD.endConnectionSegment >= 0 && OOOCDDCQCD.endPrefabScript.crossingElements[OOOCDDCQCD.endConnectionSegment].roadShapeMatchCount != 2 && !flag2)
					{
						roadTypeUpdateFlag = false;
					}
				}
				else
				{
					inspRoadTypes = new List<QDQDOOQQDQODD>(roadTypes);
					inspRoadTypeInts.Clear();
					for (int j = 0; j < roadTypes.Count; j++)
					{
						inspRoadTypeInts.Add(j);
						if (roadTypes[j].id == OOOCDDCQCD.roadType)
						{
							selectedRoadRoadType = j + 1;
						}
					}
				}
			}
			if (roadTypeUpdateFlag || !(OOOCDDCQCD != null))
			{
				return;
			}
			inspRoadTypes.Clear();
			inspRoadTypeInts.Clear();
			if (OOOCDDCQCD.roadType == 0.0)
			{
				return;
			}
			for (int k = 0; k < roadTypes.Count; k++)
			{
				if (roadTypes[k].id == OOOCDDCQCD.roadType)
				{
					inspRoadTypes.Add(roadTypes[k]);
					inspRoadTypeInts.Add(k);
					selectedRoadRoadType = 1;
				}
			}
		}

		public void UpdateRoadTypeStatus()
		{
			roadTypeUpdateFlag = true;
			if (OOOCDDCQCD != null)
			{
				if (OOOCDDCQCD.startPrefabScript != null && OOOCDDCQCD.startPrefabScript.crossingElements[OOOCDDCQCD.startConnectionSegment].roadShapeMatchCount == 2)
				{
					roadTypeUpdateFlag = false;
				}
				if (OOOCDDCQCD.endPrefabScript != null && OOOCDDCQCD.endPrefabScript.crossingElements[OOOCDDCQCD.endConnectionSegment].roadShapeMatchCount == 2)
				{
					roadTypeUpdateFlag = false;
				}
			}
		}

		public void OQDQCDOQOD()
		{
			int num = 0;
			foreach (QDOODOQQDQODD crossingElement in OQOOOCQQODScript.crossingElements)
			{
				if (crossingElement.connectedRoad != null)
				{
					if (crossingElement.connectedMarker == 0 && crossingElement.connectedRoad.startPrefabScript == null)
					{
						crossingElement.connectedRoad.startPrefabScript = OQOOOCQQODScript;
						crossingElement.connectedRoad.startConnectionSegment = num;
					}
					else if (crossingElement.connectedMarker != 0 && crossingElement.connectedRoad.endPrefabScript == null)
					{
						crossingElement.connectedRoad.endPrefabScript = OQOOOCQQODScript;
						crossingElement.connectedRoad.endConnectionSegment = num;
					}
				}
				num++;
			}
		}

		public string GetConnectionName(string name)
		{
			ERCrossingPrefabs[] array = UnityEngine.Object.FindObjectsOfType<ERCrossingPrefabs>();
			int num = 0;
			List<string> list = new List<string>();
			ERCrossingPrefabs[] array2 = array;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array2)
			{
				if (eRCrossingPrefabs.gameObject.name.Contains(name))
				{
					list.Add(eRCrossingPrefabs.gameObject.name);
					num++;
				}
			}
			num++;
			bool flag = false;
			string text = name;
			while (!flag)
			{
				flag = true;
				text = name + " (" + num + ")";
				if (list.Contains(text))
				{
					flag = false;
					num++;
				}
			}
			name = text;
			return name;
		}

		public void OOCQCCDDDC()
		{
			AssembliesSet = true;
			vegetationStudio = false;
			vegetationStudioPro = false;
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				try
				{
					Type[] types = assembly.GetTypes();
					foreach (Type type in types)
					{
						if (type.Name == "ERVegetationStudio" && type.GetMethod("VegetationStudio") != null)
						{
							vegetationStudio = (bool)type.GetMethod("VegetationStudio").Invoke(null, null);
							if (vegetationStudio)
							{
								crMethod = type.GetMethod("CreateVegetationMaskLine");
								upMethod = type.GetMethod("UpdateVegetationMaskLine");
								hmMethod = type.GetMethod("UpdateHeightmap");
								rmMethod = type.GetMethod("RemoveVegetationMaskLine");
							}
						}
						if (type.GetMethod("VegetationStudioPro") != null)
						{
							vegetationStudioPro = (bool)type.GetMethod("VegetationStudioPro").Invoke(null, null);
							if (vegetationStudioPro)
							{
								crMethod = type.GetMethod("CreateVegetationMaskLine");
								upMethod = type.GetMethod("UpdateVegetationMaskLine");
								hmMethod = type.GetMethod("UpdateHeightmap");
								rmMethod = type.GetMethod("RemoveVegetationMaskLine");
								crBiomeMethod = type.GetMethod("CreateBiomeArea");
								upBiomeMethod = type.GetMethod("UpdateBiomeArea");
								rmBiomeMethod = type.GetMethod("RemoveBiomeArea");
							}
						}
						if (type.Name == "ERDecalProjector")
						{
							dpcMethod = type.GetMethod("Create");
							dprlMethod = type.GetMethod("GetRenderingLayerNames");
						}
						if (type.Name == "TerrainData")
						{
							thMethodGet = type.GetMethod("GetHoles");
							thMethodSet = type.GetMethod("SetHoles");
						}
						if (type.Name == "ModelExporter" && type.Namespace == "UnityEditor.Formats.Fbx.Exporter")
						{
							fbxMethod = type.GetMethod("ExportObject");
						}
					}
				}
				catch
				{
				}
			}
		}

		public void OQCCDDOCQC()
		{
			try
			{
				if (doHeightmap && (vegetationStudio || vegetationStudioPro) && vegetationStudioActive && hmMethod != null)
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

		public void OCDQCDDCCD()
		{
		}

		public void OQCQDOODCO(GameObject go, Vector3 pos)
		{
			pos.y += 1f;
			GameObject gameObject = UnityEngine.Object.Instantiate(go);
			gameObject.name = "crossing";
			gameObject.transform.position = pos;
		}

		public void OCDODCCOOD()
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
				GameObject gameObject2 = new GameObject("Road Objects");
				gameObject2.transform.parent = base.transform;
				roadObjectsParent = gameObject2.transform;
				gameObject2.transform.position = Vector3.zero;
			}
			OQOQCDQOCC = Application.isPlaying;
		}

		public ERCrossingPrefabs OOCOQDCODD(GameObject prefab, ERModularRoad OOOCDDCQCD, int OODOOQQDQD, int connectionSegment)
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
				eRCrossings.ODODCODQCQ(prefab.GetComponent<ERCrossings>(), refreshFlag: false);
				List<ERModularRoad> updatedRoads = new List<ERModularRoad>();
				foreach (QDQDOOQQDQODD roadType in roadTypes)
				{
					eRCrossings.UpdateToRoadType(roadType, ref updatedRoads);
				}
				if (connectionSegment == 2 && eRCrossingPrefabs.tCrossing && eRCrossings.tCrossingLeftRight == 1)
				{
					connectionSegment = 3;
				}
				else if (connectionSegment == 3 && eRCrossingPrefabs.tCrossing && eRCrossings.tCrossingLeftRight == 0)
				{
					connectionSegment = 2;
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
				gameObject.GetComponent<MeshRenderer>().lightProbeUsage = LightProbeUsage.BlendProbes;
				gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			if (!eRCrossingPrefabs.isCustomPrefab)
			{
				OQDDDQDODC(gameObject, prefab);
			}
			if (eRCrossingPrefabs.fullMeshVecs.Length == 0)
			{
				OCQDOOQQDC(eRCrossingPrefabs);
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
				gameObject.GetComponent<ERCrossings>().OCQCCOOODO();
			}
			if (connectionSegment != -1 || eRCrossingPrefabs.crossingElements.Count > 1)
			{
			}
			if (connectionSegment == -1)
			{
				connectionSegment = OQQOOOQDOD(OOOCDDCQCD, eRCrossingPrefabs, OODOOQQDQD, 0, swapFlag: false);
			}
			if ((bool)prefab.GetComponent<ERCrossings>())
			{
				Vector3 v = OOOCDDCQCD.soSplinePoints[0];
				Vector3 v2 = OOOCDDCQCD.soSplinePoints[1];
				if (OODOOQQDQD != 0)
				{
					v = OOOCDDCQCD.soSplinePoints[OOOCDDCQCD.soSplinePoints.Count - 1];
					v2 = OOOCDDCQCD.soSplinePoints[OOOCDDCQCD.soSplinePoints.Count - 2];
				}
				eRCrossingPrefabs.OCODOODQQQ(v, v2, connectionSegment, OOOCDDCQCD);
				OQQOCDQCQDExt.OOCQOCCCDQ(eRCrossingPrefabs, OOOCDDCQCD, OODOOQQDQD, connectionSegment);
			}
			OOOCDDCQCD.nodeWithinRange = OODOOQQDQD;
			if (OODOOQQDQD == 0)
			{
				OQOCQDQODD.ODCQDDOQOQ(OOOCDDCQCD, OOOCDDCQCD.markersExt[OODOOQQDQD].position, eRCrossingPrefabs, connectionSegment, reverse: true, uvReverse: false, forceAutoRotate: true);
			}
			else
			{
				OQOCQDQODD.ODCQDDOQOQ(OOOCDDCQCD, OOOCDDCQCD.markersExt[OODOOQQDQD].position, eRCrossingPrefabs, connectionSegment, reverse: false, uvReverse: false, forceAutoRotate: true);
			}
			eRCrossingPrefabs.isSceneObject = true;
			eRCrossingPrefabs.baseScript = this;
			eRCrossingPrefabs.surroundingDistance = 0f;
			eRCrossingPrefabs.ODCQOCQODQ(forceFlag: false);
			eRCrossingPrefabs.prefabId = prefab.GetComponent<ERCrossingPrefabs>().prefabId;
			eRCrossingPrefabs.averageNormals = prefab.GetComponent<ERCrossingPrefabs>().averageNormals;
			gameObject.name = GetConnectionName(prefab.name);
			ERSurfaceScript componentInChildren = gameObject.GetComponentInChildren<ERSurfaceScript>();
			if (componentInChildren != null)
			{
				componentInChildren.gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			if (prefab != null && gameObject != null)
			{
				gameObject.tag = prefab.tag;
				gameObject.layer = prefab.layer;
				gameObject.isStatic = prefab.isStatic;
			}
			return eRCrossingPrefabs;
		}

		public ERCrossingPrefabs AttachConnector(ERModularRoad OOOCDDCQCD, int OODOOQQDQD)
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
				gameObject.GetComponent<MeshRenderer>().lightProbeUsage = LightProbeUsage.BlendProbes;
				gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			int num = 0;
			OOOCDDCQCD.nodeWithinRange = OODOOQQDQD;
			if (OODOOQQDQD == 0)
			{
			}
			if (OODOOQQDQD == 0)
			{
				OOOCDDCQCD.startPrefabScript = eRCrossingPrefabs;
				OOOCDDCQCD.startConnectionSegment = 0;
			}
			else if (OODOOQQDQD == OOOCDDCQCD.markersExt.Count - 1)
			{
				OOOCDDCQCD.endPrefabScript = eRCrossingPrefabs;
				OOOCDDCQCD.endConnectionSegment = 0;
			}
			eRCrossingPrefabs.crossingElements.Add(new QDOODOQQDQODD());
			eRCrossingPrefabs.crossingElements.Add(new QDOODOQQDQODD());
			eRCrossingPrefabs.crossingElements[0].connectedRoad = OOOCDDCQCD;
			eRCrossingPrefabs.crossingElements[0].connectedMarker = OODOOQQDQD;
			eRCrossingPrefabs.crossingElements[0].connectedRoadGO = gameObject;
			gameObject.transform.position = OOOCDDCQCD.markersExt[OODOOQQDQD].position;
			eRCrossingPrefabs.baseScript = this;
			eRCrossingPrefabs.surroundingDistance = 0f;
			eRCrossingPrefabs.isIConnector = true;
			eRCrossingPrefabs.iConnectorScript = iConnectorScript;
			gameObject.name = GetConnectionName(gameObject.name);
			ERSurfaceScript componentInChildren = gameObject.GetComponentInChildren<ERSurfaceScript>();
			if (componentInChildren != null)
			{
				componentInChildren.gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			return eRCrossingPrefabs;
		}

		public void OOOQOCQCQD(ERModularRoad OOOCDDCQCD, int selectedMarker)
		{
			if (selectedMarker == 0)
			{
				if (OOOCDDCQCD.startPrefabScript != null)
				{
					int num = OQQOOOQDOD(OOOCDDCQCD, OOOCDDCQCD.startPrefabScript, selectedMarker, OOOCDDCQCD.startConnectionSegment + 1, swapFlag: true);
					if (num != -1 && num != OOOCDDCQCD.startConnectionSegment)
					{
						OQOCQDQODD.ODCQDDOQOQ(OOOCDDCQCD, OOOCDDCQCD.markersExt[selectedMarker].position, OOOCDDCQCD.startPrefabScript, num, reverse: true, uvReverse: false, forceAutoRotate: true);
					}
				}
			}
			else if (selectedMarker == OOOCDDCQCD.markersExt.Count - 1 && OOOCDDCQCD.endPrefabScript != null)
			{
				int num2 = OQQOOOQDOD(OOOCDDCQCD, OOOCDDCQCD.endPrefabScript, selectedMarker, OOOCDDCQCD.endConnectionSegment + 1, swapFlag: true);
				if (num2 != -1 && num2 != OOOCDDCQCD.endConnectionSegment)
				{
					OQOCQDQODD.ODCQDDOQOQ(OOOCDDCQCD, OOOCDDCQCD.markersExt[selectedMarker].position, OOOCDDCQCD.endPrefabScript, num2, reverse: false, uvReverse: false, forceAutoRotate: true);
				}
			}
		}

		public int OQQOOOQDOD(ERModularRoad OOOCDDCQCD, ERCrossingPrefabs prefabScript, int OODOOQQDQD, int startConnection, bool swapFlag)
		{
			int num = -1;
			List<Vector2> list = new List<Vector2>(OOOCDDCQCD.roadShape);
			if (OODOOQQDQD != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					Vector2 value = list[i];
					value.x *= -1f;
					list[i] = value;
				}
			}
			string text = OOOCDDCQCD.roadShapeString;
			if (OODOOQQDQD != 0)
			{
				text = OOOCDDCQCD.roadShapeReversedString;
			}
			List<string> list2 = new List<string>();
			for (int j = startConnection; j < prefabScript.crossingElements.Count; j++)
			{
				if (text == prefabScript.crossingElements[j].roadShapeVecsString && prefabScript.crossingElements[j].connectionVecInts.Count > 0)
				{
					num = j;
					break;
				}
				list2.Add(prefabScript.crossingElements[j].roadShapeVecsString);
			}
			if (swapFlag && num == -1)
			{
				num = ((OODOOQQDQD != 0) ? OQQOOOQDOD(OOOCDDCQCD, OOOCDDCQCD.endPrefabScript, OODOOQQDQD, 0, swapFlag: true) : OQQOOOQDOD(OOOCDDCQCD, OOOCDDCQCD.startPrefabScript, OODOOQQDQD, 0, swapFlag: true));
			}
			if (swapFlag)
			{
				return num;
			}
			if (num == -1)
			{
				num = ODCDQCDDCQ(text, list2, prefabScript.crossingElements);
			}
			if (num == -1)
			{
				num = ((OODOOQQDQD == 0 && prefabScript.isCustomPrefab && prefabScript.crossingElements.Count == 2) ? 1 : 0);
			}
			return num;
		}

		public int ODCDQCDDCQ(string roadShapeString, List<string> strings, List<QDOODOQQDQODD> crossingElements)
		{
			int result = -1;
			string[] array = roadShapeString.Split(new char[1] { ';' });
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
				array = strings[j].Split(new char[1] { ';' });
				for (int k = 0; k < array.Length; k++)
				{
					string[] array3 = array[k].Split(new string[1] { ", " }, StringSplitOptions.None);
					if (array3[0] != "")
					{
						list3.Add(float.Parse(array3[0]));
						list4.Add(float.Parse(array3[1]));
					}
				}
				float num = 1000f;
				if (list.Count == list3.Count)
				{
					num = 0f;
					for (int l = 0; l < list.Count; l++)
					{
						num += Math.Abs(list[l] - list3[l]);
						num += Math.Abs(list2[l] - list4[l]);
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

		public GameObject OOQDOCCDCC(GameObject prefab, Vector3 hitPos, ref GameObject newPrefab, ref ERCrossingPrefabs prefabScript, ref ERCrossings crossingsScript)
		{
			ERConnectionParent eRConnectionParent = (ERConnectionParent)UnityEngine.Object.FindObjectOfType(typeof(ERConnectionParent));
			if (prefab == null)
			{
				UnityEngine.Debug.Log("This is an empty prefab");
				return null;
			}
			if ((bool)prefab.GetComponent<ERCrossings>())
			{
				bool isERCrossingExt = prefab.GetComponent<ERCrossingPrefabs>().isERCrossingExt;
				newPrefab = new GameObject(prefab.name);
				if (eRConnectionParent != null)
				{
					newPrefab.transform.parent = eRConnectionParent.transform;
				}
				newPrefab.transform.position = hitPos;
				prefabScript = newPrefab.AddComponent<ERCrossingPrefabs>();
				crossingsScript = newPrefab.AddComponent<ERCrossings>();
				crossingsScript.prefabScript = prefabScript;
				crossingsScript.ODODCODQCQ(prefab.GetComponent<ERCrossings>(), refreshFlag: false);
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
					newPrefab.GetComponent<ERRoundabouts>().OOODQQDOOD();
					newPrefab.GetComponent<ERRoundabouts>().OCODQOOOCQ();
					newPrefab.GetComponent<ERRoundabouts>().OCOCDCDDOD();
					List<ERModularRoad> list = new List<ERModularRoad>();
					foreach (QDQDOOQQDQODD roadType2 in roadTypes)
					{
						newPrefab.GetComponent<ERRoundabouts>().UpdateToRoadType(roadType2);
					}
				}
				else
				{
					if (prefab.GetComponent<MeshFilter>().sharedMesh == null)
					{
						UnityEngine.Debug.LogError("EasyRoads3Dv3 Error: No mesh is assigned to custom prefab: " + prefab.name);
						return newPrefab;
					}
					newPrefab.GetComponent<MeshFilter>().sharedMesh = UnityEngine.Object.Instantiate(prefab.GetComponent<MeshFilter>().sharedMesh);
					if ((bool)newPrefab.GetComponent<MeshCollider>())
					{
						newPrefab.GetComponent<MeshCollider>().sharedMesh = newPrefab.GetComponent<MeshFilter>().sharedMesh;
						newPrefab.GetComponent<MeshCollider>().sharedMesh.name = newPrefab.GetComponent<MeshFilter>().sharedMesh.name;
					}
					if ((bool)newPrefab.GetComponent<MeshFilter>() && (bool)newPrefab.GetComponent<MeshFilter>().sharedMesh && newPrefab.GetComponent<MeshFilter>().sharedMesh.isReadable)
					{
						newPrefab.GetComponent<MeshFilter>().sharedMesh.RecalculateBounds();
					}
				}
			}
			if ((bool)newPrefab.GetComponent<MeshRenderer>())
			{
				newPrefab.GetComponent<MeshRenderer>().lightProbeUsage = LightProbeUsage.BlendProbes;
				newPrefab.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			if (!prefabScript.isCustomPrefab)
			{
				OQDDDQDODC(newPrefab, prefab);
			}
			if (prefabScript.fullMeshVecs.Length == 0)
			{
				OCQDOOQQDC(prefabScript);
			}
			prefabScript.baseScript = this;
			prefabScript.surroundingDistance = 0f;
			prefabScript.ODCQOCQODQ(forceFlag: false);
			prefabScript.prefabId = prefab.GetComponent<ERCrossingPrefabs>().prefabId;
			prefabScript.averageNormals = prefab.GetComponent<ERCrossingPrefabs>().averageNormals;
			newPrefab.name = GetConnectionName(newPrefab.name);
			ERSurfaceScript componentInChildren = newPrefab.GetComponentInChildren<ERSurfaceScript>();
			if (componentInChildren != null)
			{
				componentInChildren.gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			if (prefab != null)
			{
				newPrefab.tag = prefab.tag;
				newPrefab.layer = prefab.layer;
				newPrefab.isStatic = prefab.isStatic;
			}
			return newPrefab;
		}

		public void OCQDOOQQDC(ERCrossingPrefabs prefabScript)
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

		public void OQDDDQDODC(GameObject newPrefab, GameObject prefab)
		{
			List<GameObject> list = new List<GameObject>();
			foreach (Transform item in newPrefab.transform)
			{
				if (item.name != "surface")
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
			foreach (Transform item4 in prefab.transform)
			{
				if (item4.name != "surface")
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(item4.gameObject);
					gameObject.name = item4.name;
					gameObject.transform.parent = newPrefab.transform;
					gameObject.transform.localPosition = item4.transform.localPosition;
					gameObject.transform.localScale = item4.transform.localScale;
					gameObject.transform.localEulerAngles = item4.transform.localEulerAngles;
					gameObject.tag = item4.gameObject.tag;
					gameObject.layer = item4.gameObject.layer;
				}
			}
		}

		public void AddCildrenToPrefabExt(ERCrossingPrefabs scr, GameObject instancePrefab, GameObject prefab, bool reset = false)
		{
			List<ERChildObject> list = new List<ERChildObject>(scr.childObjects);
			bool flag = false;
			if (reset)
			{
				list.Clear();
				for (int i = 0; i < scr.transform.childCount; i++)
				{
					if (scr.transform.GetChild(i).GetComponent<ERSurfaceScript>() == null)
					{
						UnityEngine.Object.DestroyImmediate(scr.transform.GetChild(i).gameObject);
						i--;
					}
				}
			}
			List<GameObject> list2 = new List<GameObject>();
			foreach (Transform item2 in instancePrefab.transform)
			{
				flag = false;
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].goInstance == item2.gameObject)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list2.Add(item2.gameObject);
				}
				if (reset)
				{
					UnityEngine.Object.DestroyImmediate(item2.gameObject);
				}
			}
			foreach (GameObject item3 in list2)
			{
				UnityEngine.Object.DestroyImmediate(item3);
			}
			GameObject gameObject = null;
			foreach (Transform item4 in prefab.transform)
			{
				flag = false;
				gameObject = null;
				for (int k = 0; k < list.Count; k++)
				{
					if (list[k].goSource == item4.gameObject)
					{
						flag = true;
						gameObject = list[k].goInstance;
						list.RemoveAt(k);
						break;
					}
				}
				if (gameObject == null)
				{
					gameObject = UnityEngine.Object.Instantiate(item4.gameObject);
					ERChildObject item = new ERChildObject(item4.gameObject, gameObject);
					scr.childObjects.Add(item);
				}
				if (gameObject != null)
				{
					gameObject.name = item4.name;
					gameObject.transform.parent = instancePrefab.transform;
					gameObject.transform.localPosition = item4.transform.localPosition;
					gameObject.transform.localScale = item4.transform.localScale;
					gameObject.transform.localEulerAngles = item4.transform.localEulerAngles;
					gameObject.tag = item4.gameObject.tag;
					gameObject.layer = item4.gameObject.layer;
				}
			}
			for (int l = 0; l < list.Count; l++)
			{
				for (int m = 0; m < scr.childObjects.Count; m++)
				{
					if (scr.childObjects[m].goInstance == list[l].goInstance)
					{
						scr.childObjects.RemoveAt(m);
					}
				}
				UnityEngine.Object.DestroyImmediate(list[l].goInstance);
			}
		}

		public void OCDODCCCOC()
		{
			ERModularRoad[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
			ERModularRoad[] array2 = array;
			foreach (ERModularRoad eRModularRoad in array2)
			{
				try
				{
					if (eRModularRoad.startPrefabScript != null && eRModularRoad.startPrefabScript.crossingElements.Count > eRModularRoad.startConnectionSegment)
					{
						eRModularRoad.startPrefabScript.crossingElements[eRModularRoad.startConnectionSegment].connectedRoad = eRModularRoad;
						eRModularRoad.startPrefabScript.crossingElements[eRModularRoad.startConnectionSegment].connectedMarker = 0;
					}
				}
				catch
				{
					UnityEngine.Debug.Log("EasyRoads3Dv3 Error: Road: " + eRModularRoad.name + " Connection at start: " + eRModularRoad.startPrefabScript.name + " connection index " + eRModularRoad.startConnectionSegment);
				}
				try
				{
					if (eRModularRoad.endPrefabScript != null && eRModularRoad.endPrefabScript.crossingElements.Count > eRModularRoad.endConnectionSegment)
					{
						eRModularRoad.endPrefabScript.crossingElements[eRModularRoad.endConnectionSegment].connectedRoad = eRModularRoad;
						eRModularRoad.endPrefabScript.crossingElements[eRModularRoad.endConnectionSegment].connectedMarker = eRModularRoad.markersExt.Count - 1;
					}
				}
				catch
				{
					UnityEngine.Debug.Log("EasyRoads3Dv3 Error: Road: " + eRModularRoad.name + " Connection at end: " + eRModularRoad.endPrefabScript.name + " connection index " + eRModularRoad.endConnectionSegment);
				}
			}
		}

		public List<ERTerrain> ODCQDDDDDO(ref bool multTerrainResFlag)
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
			int num4 = 0;
			float num5 = 0f;
			Terrain[] array2 = array;
			foreach (Terrain terrain in array2)
			{
				if (!(terrain.terrainData != null))
				{
					continue;
				}
				if (terrain.gameObject.GetComponent<ERTerrain>() == null)
				{
					terrain.gameObject.AddComponent<ERTerrain>();
					list3.Add(terrain.gameObject.GetComponent<ERTerrain>());
					terrain.gameObject.GetComponent<ERTerrain>().terrainData = terrain.terrainData;
				}
				else if (terrain.gameObject.GetComponent<ERTerrain>().terrainData != terrain.terrainData)
				{
					terrain.gameObject.GetComponent<ERTerrain>().terrainData = terrain.terrainData;
					list3.Add(terrain.gameObject.GetComponent<ERTerrain>());
				}
				if (!(terrain.gameObject.GetComponent<ERTerrain>() != null) || terrain.gameObject.GetComponent<ERTerrain>().ignore)
				{
					continue;
				}
				list.Add(terrain.name);
				list2.Add(terrain);
				float num6 = terrain.terrainData.size.x / ((float)terrain.terrainData.heightmapResolution * 1f - 1f);
				if (num4 != terrain.terrainData.heightmapResolution || num6 != num5)
				{
					if (num4 != 0 && num6 != num5)
					{
						multTerrainResFlag = true;
					}
					num4 = terrain.terrainData.heightmapResolution;
					num5 = num6;
				}
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
			terrainNames = list.ToArray();
			terrainObjects = list2.ToArray();
			num = (terrainCellSize = num * 1.25f) * 1.5f;
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
			if (array.Length != 0 && array[0] != null && array[0].terrainData != null)
			{
				List<string> list4 = new List<string>();
				TerrainLayer[] terrainLayers = array[0].terrainData.terrainLayers;
				foreach (TerrainLayer terrainLayer in terrainLayers)
				{
					Texture2D texture2D = null;
					if (terrainLayer != null)
					{
						texture2D = terrainLayer.diffuseTexture;
					}
					if (texture2D != null)
					{
						list4.Add("Splat " + (list4.Count + 1) + " - " + terrainLayer.name);
					}
					else
					{
						list4.Add("Splat " + (list4.Count + 1) + " - Empty");
					}
				}
				terrainSplatTextures = list4.ToArray();
			}
			if (!terrainCheckDone)
			{
				if (minIndent > 15f && terrainMinIndent > 15f)
				{
					UnityEngine.Debug.Log("EasyRoads3Dv3 Warning: low resolution terrain object(s) detected in the scene. This will affect the results of adapting the terrain to the road shape.");
				}
				else if (minIndent > 5f && terrainMinIndent > 5f)
				{
					UnityEngine.Debug.Log("EasyRoads3Dv3 Warning: lower resolution terrain object(s) detected in the scene. This may affect the results of adapting the terrain to the road shape.");
				}
				terrainCheckDone = true;
			}
			return list3;
		}

		public void ODDQCCOCCQ()
		{
			QDQDOOQQOOQDD.ODDQCCOCCQ(this, terrainObjects[selectedTerrain]);
		}

		public void ODOCCDODCQ(bool restoreTerrain)
		{
			ERTerrain[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERTerrain)) as ERTerrain[];
			if (restoreTerrain)
			{
				ERTerrain[] array2 = array;
				foreach (ERTerrain eRTerrain in array2)
				{
					if (eRTerrain.terrainDone)
					{
						Terrain component = eRTerrain.gameObject.GetComponent<Terrain>();
						if (component == null)
						{
							component = eRTerrain.transform.parent.GetComponent<Terrain>();
						}
						if (component != null)
						{
							QDQDOOQQOOQDD.OCCCQDQQCO(this, eRTerrain, eRTerrain.gameObject.GetComponent<Terrain>());
						}
						else
						{
							UnityEngine.Debug.Log("EasyRoads3D Warning: Terrain object not found on: '" + eRTerrain.gameObject.name + "' was the ER Terrain component moved from the original Terrain object?");
						}
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
					bool flag = !hideSurfaces;
					flag = true;
					if (surfaceObject.GetComponent<MeshCollider>() != null)
					{
						surfaceObject.GetComponent<MeshCollider>().enabled = flag;
					}
				}
				else
				{
					UnityEngine.Debug.LogWarning("Missing surface detected [" + num + "]: Are all objects correctly restored?");
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
			if (soTrees)
			{
				ERSideObjectInstance[] array5 = array4;
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
				ERTerrain[] array6 = array3;
				foreach (ERTerrain eRTerrain2 in array6)
				{
					try
					{
						TerrainData terrainData = eRTerrain2.gameObject.GetComponent<Terrain>().terrainData;
						List<TreeInstance> list2 = new List<TreeInstance>(terrainData.treeInstances);
						foreach (ERTreeInstance addedTree in eRTerrain2.addedTrees)
						{
							for (int m = 0; m < list2.Count; m++)
							{
								if (addedTree.position.x == list2[m].position.x && addedTree.position.z == list2[m].position.z)
								{
									list2.RemoveAt(m);
									break;
								}
							}
						}
						eRTerrain2.addedTrees.Clear();
						terrainData.treeInstances = list2.ToArray();
					}
					catch
					{
						UnityEngine.Debug.LogError("EasyRoads3Dv3: Removing trees added from side objects from terrain " + eRTerrain2.gameObject.name + " failed, please report with details!");
					}
				}
			}
			if (doLightmapUVs)
			{
				ERCrossings[] array7 = UnityEngine.Object.FindObjectsOfType(typeof(ERCrossings)) as ERCrossings[];
				ERCrossings[] array8 = array7;
				foreach (ERCrossings eRCrossings in array8)
				{
					try
					{
						eRCrossings.OQDCCQOCCQ(sidewalkSceneHandleFlag: false, rebuildRoads: true);
					}
					catch
					{
						UnityEngine.Debug.Log("Refresh failed: " + eRCrossings.gameObject.name);
					}
				}
				ERRoundabouts[] array9 = UnityEngine.Object.FindObjectsOfType(typeof(ERRoundabouts)) as ERRoundabouts[];
				ERRoundabouts[] array10 = array9;
				foreach (ERRoundabouts eRRoundabouts in array10)
				{
					try
					{
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
						UnityEngine.Debug.Log("Refresh failed: " + eRRoundabouts.gameObject.name);
					}
				}
			}
			roadSoObjects.Clear();
			ERSideObjectInstance[] array11 = array4;
			foreach (ERSideObjectInstance eRSideObjectInstance2 in array11)
			{
				try
				{
					if (!(eRSideObjectInstance2.so != null) || eRSideObjectInstance2.so.terrainTree != 0)
					{
						continue;
					}
					ERModularRoad component2 = eRSideObjectInstance2.transform.parent.GetComponent<ERModularRoad>();
					bool flag2 = true;
					if (selectedRoadsOnly)
					{
						flag2 = false;
						for (int num4 = 0; num4 < selectedObjects.Count; num4++)
						{
							if (selectedObjects[num4].roadScr == component2)
							{
								flag2 = true;
								break;
							}
						}
					}
					if (!(component2 != null && flag2))
					{
						continue;
					}
					bool flag3 = false;
					for (int num5 = 0; num5 < component2.soDataExt.Count; num5++)
					{
						if (component2.soDataExt[num5].sideObject.id == eRSideObjectInstance2.so.id && component2.soDataExt[num5].active)
						{
							flag3 = true;
							break;
						}
					}
					if (flag3 && flag2)
					{
						OCQODDCQDD.OODOQDDOCQ(this, component2, eRSideObjectInstance2.so);
						if (buildSOinEditMode || component2.isSideObject)
						{
							OCQODDCQDD.OOOQQQOOQC(this, component2, eRSideObjectInstance2.so, updateSideObjectsOnOtherRoadObjects: false);
							if (!roadSoObjects.Contains(component2))
							{
								roadSoObjects.Add(component2);
							}
						}
					}
					component2.sosCleared = false;
				}
				catch
				{
					string text = "[none]";
					if (eRSideObjectInstance2 != null)
					{
						if (eRSideObjectInstance2.transform.parent != null)
						{
							text = eRSideObjectInstance2.transform.parent.name;
						}
						UnityEngine.Debug.LogError("EasyRoads3Dv3: Rebuilding side object " + eRSideObjectInstance2.gameObject.name + " on object " + text + " failed, please report with details!");
					}
				}
			}
			OCDOODOQDC.OCODQOQCQO(this, roadNetworkRefresh: true);
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
				ERTerrain[] array12 = array3;
				foreach (ERTerrain eRTerrain3 in array12)
				{
					try
					{
						if (eRTerrain3.splatData.Count > 0)
						{
							TerrainData terrainData2 = eRTerrain3.gameObject.GetComponent<Terrain>().terrainData;
							float[,,] alphamaps = terrainData2.GetAlphamaps(0, 0, terrainData2.alphamapWidth, terrainData2.alphamapHeight);
							foreach (ERSplatmap splatDatum in eRTerrain3.splatData)
							{
								if (!newSplatMapRestoreCode)
								{
									UnityEngine.Debug.Log("Old Restore Terrain");
									if (splatDatum.index <= 4)
									{
										if (terrainData2.alphamapLayers > 0)
										{
											alphamaps[splatDatum.x, splatDatum.y, 0] = splatDatum.tValue1;
										}
										if (terrainData2.alphamapLayers > 1)
										{
											alphamaps[splatDatum.x, splatDatum.y, 1] = splatDatum.tValue2;
										}
										if (terrainData2.alphamapLayers > 2)
										{
											alphamaps[splatDatum.x, splatDatum.y, 2] = splatDatum.tValue3;
										}
										if (terrainData2.alphamapLayers > 3)
										{
											alphamaps[splatDatum.x, splatDatum.y, 3] = splatDatum.tValue4;
										}
									}
									else if (splatDatum.index <= 8)
									{
										if (terrainData2.alphamapLayers > 4)
										{
											alphamaps[splatDatum.x, splatDatum.y, 4] = splatDatum.tValue1;
										}
										if (terrainData2.alphamapLayers > 5)
										{
											alphamaps[splatDatum.x, splatDatum.y, 5] = splatDatum.tValue2;
										}
										if (terrainData2.alphamapLayers > 6)
										{
											alphamaps[splatDatum.x, splatDatum.y, 6] = splatDatum.tValue3;
										}
										if (terrainData2.alphamapLayers > 7)
										{
											alphamaps[splatDatum.x, splatDatum.y, 7] = splatDatum.tValue4;
										}
									}
									else if (splatDatum.index <= 12)
									{
										if (terrainData2.alphamapLayers > 8)
										{
											alphamaps[splatDatum.x, splatDatum.y, 8] = splatDatum.tValue1;
										}
										if (terrainData2.alphamapLayers > 9)
										{
											alphamaps[splatDatum.x, splatDatum.y, 9] = splatDatum.tValue2;
										}
										if (terrainData2.alphamapLayers > 10)
										{
											alphamaps[splatDatum.x, splatDatum.y, 10] = splatDatum.tValue3;
										}
										if (terrainData2.alphamapLayers > 11)
										{
											alphamaps[splatDatum.x, splatDatum.y, 11] = splatDatum.tValue4;
										}
									}
								}
								else
								{
									if (terrainData2.alphamapLayers > 0)
									{
										alphamaps[splatDatum.x, splatDatum.y, 0] = splatDatum.tValue1;
									}
									if (terrainData2.alphamapLayers > 1)
									{
										alphamaps[splatDatum.x, splatDatum.y, 1] = splatDatum.tValue2;
									}
									if (terrainData2.alphamapLayers > 2)
									{
										alphamaps[splatDatum.x, splatDatum.y, 2] = splatDatum.tValue3;
									}
									if (terrainData2.alphamapLayers > 3)
									{
										alphamaps[splatDatum.x, splatDatum.y, 3] = splatDatum.tValue4;
									}
									if (terrainData2.alphamapLayers > 4)
									{
										alphamaps[splatDatum.x, splatDatum.y, 4] = splatDatum.tValue5;
									}
									if (terrainData2.alphamapLayers > 5)
									{
										alphamaps[splatDatum.x, splatDatum.y, 5] = splatDatum.tValue6;
									}
									if (terrainData2.alphamapLayers > 6)
									{
										alphamaps[splatDatum.x, splatDatum.y, 6] = splatDatum.tValue7;
									}
									if (terrainData2.alphamapLayers > 7)
									{
										alphamaps[splatDatum.x, splatDatum.y, 7] = splatDatum.tValue8;
									}
									if (terrainData2.alphamapLayers > 8)
									{
										alphamaps[splatDatum.x, splatDatum.y, 8] = splatDatum.tValue9;
									}
									if (terrainData2.alphamapLayers > 9)
									{
										alphamaps[splatDatum.x, splatDatum.y, 9] = splatDatum.tValue10;
									}
									if (terrainData2.alphamapLayers > 10)
									{
										alphamaps[splatDatum.x, splatDatum.y, 10] = splatDatum.tValue11;
									}
									if (terrainData2.alphamapLayers > 11)
									{
										alphamaps[splatDatum.x, splatDatum.y, 11] = splatDatum.tValue12;
									}
								}
							}
							terrainData2.SetAlphamaps(0, 0, alphamaps);
						}
					}
					catch
					{
						UnityEngine.Debug.LogError("EasyRoads3Dv3: Restoring the splatmap for terrain " + eRTerrain3.gameObject.name + " failed, please report with details!");
					}
					eRTerrain3.splatmapFlag = false;
				}
			}
			if (lodGroups)
			{
				ERModularRoad[] array13 = UnityEngine.Object.FindObjectsOfType(typeof(ERModularRoad)) as ERModularRoad[];
				ERModularRoad[] array14 = array13;
				foreach (ERModularRoad eRModularRoad in array14)
				{
					bool flag4 = true;
					if (selectedRoadsOnly)
					{
						flag4 = false;
						for (int num8 = 0; num8 < selectedObjects.Count; num8++)
						{
							if (selectedObjects[num8].roadScr == eRModularRoad)
							{
								flag4 = true;
								break;
							}
						}
					}
					if (!flag4)
					{
						continue;
					}
					if ((bool)eRModularRoad.gameObject.GetComponent<LODGroup>())
					{
						UnityEngine.Object.DestroyImmediate(eRModularRoad.gameObject.GetComponent<LODGroup>());
					}
					for (int num9 = 0; num9 < LODLevels; num9++)
					{
						Transform transform2 = eRModularRoad.transform.Find("LOD " + num9);
						if ((bool)transform2)
						{
							if (Application.isEditor && !Application.isPlaying)
							{
								UnityEngine.Object.DestroyImmediate(transform2.gameObject);
							}
							else
							{
								UnityEngine.Object.Destroy(transform2.gameObject);
							}
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
				if (doHeightmap && vegetationStudio && vegetationStudioActive && hmMethod != null)
				{
					Bounds bounds = default(Bounds);
					object[] parameters = new object[1] { bounds };
					hmMethod.Invoke(null, parameters);
				}
			}
			catch
			{
			}
			ERTerrain[] array15 = array3;
			foreach (ERTerrain eRTerrain4 in array15)
			{
				eRTerrain4.splatData.Clear();
				eRTerrain4.terrainChanges.Clear();
				eRTerrain4.addedTrees.Clear();
				eRTerrain4.terrainTrees.Clear();
				eRTerrain4.detailInstances.Clear();
				eRTerrain4.holes.Clear();
			}
			surfaceObjects.Clear();
			tunnelObjects.Clear();
			isInBuildMode = false;
			OQCCDDOCQC();
			ERRoadNetwork.OnEditModeEnter();
		}

		public void OQQOQQCOOQ(Vector3 pos)
		{
			if (meshSurface == null)
			{
				if (pos.x < terrainRect.x || pos.x > terrainRect.x + terrainRect.width || pos.z < terrainRect.y || pos.z > terrainRect.y + terrainRect.height || activeTerrain == null)
				{
					ODCCODCDCC(ref pos, setSelected: false);
				}
			}
			else
			{
				activeTerrain = null;
			}
		}

		public void OQCCDQOQOO(ref Vector3 pos)
		{
			if (meshSurface == null)
			{
				if (pos.x < terrainRect.x || pos.x > terrainRect.x + terrainRect.width || pos.z < terrainRect.y || pos.z > terrainRect.y + terrainRect.height || activeTerrain == null)
				{
					ODCCODCDCC(ref pos, setSelected: false);
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

		public Vector3 OOQDDODCDO(Vector3 pos)
		{
			if (pos.x < terrainRect.x || pos.x > terrainRect.x + terrainRect.width || pos.z < terrainRect.y || pos.z > terrainRect.y + terrainRect.height)
			{
				ODCCODCDCC(ref pos, setSelected: false);
			}
			ODCCODCDCC(ref pos, setSelected: false);
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
					ODCCODCDCC(ref pos, setSelected: false);
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

		public Terrain ODCCODCDCC(ref Vector3 pos, bool setSelected)
		{
			if (terrainObjects == null)
			{
				bool multTerrainResFlag = false;
				ODCQDDDDDO(ref multTerrainResFlag);
				if (terrainObjects == null)
				{
					UnityEngine.Debug.LogWarning("No terrain found, EasyRoads3Dv3 requires at least one terrain object!");
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

		public void OQODDOQQCQ()
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

		public void ClearSideObjectsQueue()
		{
			RoadObjectsSoUpdates.Clear();
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
					OCQODDCQDD.OOODQOOOCO(this, RoadObjectsSoUpdates[i], isSideObjectFlag: false);
					ODDOQDDQCQ.GenerateLaneDirectionMarkings(RoadObjectsSoUpdates[i]);
					RoadObjectsSoUpdates[i].OOOOQOOCQO();
				}
			}
			RoadObjectsSoUpdates.Clear();
		}

		public void ERODOQCOOOCC()
		{
			if (OCDCCCQCCQScript == null || (!OCDCCCQCCQScript.isFlexConnector && !OCDCCCQCCQScript.isIConnector))
			{
				surfaceChangeFlag = true;
			}
		}

		public void OOCOOCQOQO()
		{
			bool flag = !hideSurfaces;
			Material material = surfaceMaterial;
			if (material != null)
			{
				if (material.HasProperty("_Show"))
				{
					if (hideSurfaces)
					{
						material.SetFloat("_Show", 0f);
					}
					else
					{
						material.SetFloat("_Show", 1f);
					}
				}
				else
				{
					UnityEngine.Debug.Log("EasyRoads3Dv3 Warning: The surface material appears to be a custom material. Changing the visisbility of the surfaces cannot be completed");
				}
			}
			else
			{
				UnityEngine.Debug.LogError("EasyRoads3Dv3 Error: The surface material could not be found");
			}
			flag = true;
			ERSurfaceScript[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERSurfaceScript)) as ERSurfaceScript[];
			ERSurfaceScript[] array2 = array;
			foreach (ERSurfaceScript eRSurfaceScript in array2)
			{
				eRSurfaceScript.gameObject.GetComponent<MeshRenderer>().enabled = flag;
				eRSurfaceScript.gameObject.GetComponent<MeshCollider>().enabled = flag;
			}
		}

		public void OQQDCOQOOQ()
		{
			ERSurfaceScript[] array = UnityEngine.Object.FindObjectsOfType(typeof(ERSurfaceScript)) as ERSurfaceScript[];
			ERSurfaceScript[] array2 = array;
			foreach (ERSurfaceScript eRSurfaceScript in array2)
			{
				if ((bool)eRSurfaceScript.transform.parent.gameObject.GetComponent<MeshRenderer>())
				{
					eRSurfaceScript.transform.parent.gameObject.GetComponent<MeshRenderer>().lightProbeUsage = LightProbeUsage.BlendProbes;
					eRSurfaceScript.transform.parent.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
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
				eRRoadType.vertexColor = roadType.vertexColor;
				eRRoadType.isSideObject = roadType.isSideObject;
				eRRoadType.soDataExt = new List<ERSORoadExt>();
				for (int i = 0; i < roadType.soDataExt.Count; i++)
				{
					if (roadType.soDataExt[i] != null)
					{
						eRRoadType.soDataExt.Add(ERSORoadExt.CreateInstance(roadType.soDataExt[i].sideObject));
						if (roadType.soDataExt[i].active)
						{
							eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].active = true;
						}
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].markerActive = roadType.soDataExt[i].markerActive;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].autoGenerate = roadType.soDataExt[i].autoGenerate;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].xPosition = roadType.soDataExt[i].xPosition;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].randomMinXPosition = roadType.soDataExt[i].randomMinXPosition;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].randomMaxXPosition = roadType.soDataExt[i].randomMaxXPosition;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].yPosition = roadType.soDataExt[i].yPosition;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].randomMinYPosition = roadType.soDataExt[i].randomMinYPosition;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].randomMaxYPosition = roadType.soDataExt[i].randomMaxYPosition;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].minRandomXPositionDistance = roadType.soDataExt[i].minRandomXPositionDistance;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].maxRandomXPositionDistance = roadType.soDataExt[i].maxRandomXPositionDistance;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].minRandomYPositionDistance = roadType.soDataExt[i].minRandomYPositionDistance;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].maxRandomYPositionDistance = roadType.soDataExt[i].maxRandomYPositionDistance;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].randomMinRotation = roadType.soDataExt[i].randomMinRotation;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].randomMaxRotation = roadType.soDataExt[i].randomMaxRotation;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].minRandomRotationDistance = roadType.soDataExt[i].minRandomRotationDistance;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].maxRandomRotationDistance = roadType.soDataExt[i].maxRandomRotationDistance;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].lockRandomRotations = roadType.soDataExt[i].lockRandomRotations;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].distanceChange = roadType.soDataExt[i].distanceChange;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].xPosChange = roadType.soDataExt[i].xPosChange;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].yPosChange = roadType.soDataExt[i].yPosChange;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].rotationAngleChange = roadType.soDataExt[i].rotationAngleChange;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].rotationDistanceChange = roadType.soDataExt[i].rotationDistanceChange;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].randomXPositionChange = roadType.soDataExt[i].randomXPositionChange;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].xPositionDistanceChange = roadType.soDataExt[i].xPositionDistanceChange;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].yPositionDistanceChange = roadType.soDataExt[i].yPositionDistanceChange;
						eRRoadType.soDataExt[eRRoadType.soDataExt.Count - 1].randomXPositionChange = roadType.soDataExt[i].randomXPositionChange;
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

		public SideObject ODQDQODQCD(string name)
		{
			foreach (SideObject item in QOQDQOOQDDQOOQ)
			{
				if (item != null && item.name == name)
				{
					return item;
				}
			}
			return null;
		}

		public GameObject[] FindAvailableRoadMarkerHandles()
		{
			List<GameObject> list = new List<GameObject>();
			ERModularRoad[] array = UnityEngine.Object.FindObjectsOfType<ERModularRoad>();
			ERModularRoad[] array2 = array;
			foreach (ERModularRoad eRModularRoad in array2)
			{
				if (eRModularRoad.markersExt.Count > 0)
				{
					if (eRModularRoad.startPrefabScript == null && eRModularRoad.markersExt[0].handleObject != null)
					{
						list.Add(eRModularRoad.markersExt[0].handleObject);
					}
					if (eRModularRoad.endPrefabScript == null && eRModularRoad.markersExt[eRModularRoad.markersExt.Count - 1].handleObject != null)
					{
						list.Add(eRModularRoad.markersExt[eRModularRoad.markersExt.Count - 1].handleObject);
					}
				}
			}
			return list.ToArray();
		}

		public GameObject[] OCODOCQDCO()
		{
			List<GameObject> list = new List<GameObject>();
			ERCrossingPrefabs[] array = UnityEngine.Object.FindObjectsOfType<ERCrossingPrefabs>();
			ERCrossingPrefabs[] array2 = array;
			foreach (ERCrossingPrefabs eRCrossingPrefabs in array2)
			{
				if (eRCrossingPrefabs.isIConnector)
				{
					continue;
				}
				foreach (QDOODOQQDQODD crossingElement in eRCrossingPrefabs.crossingElements)
				{
					if (crossingElement.connectedRoad == null)
					{
						list.Add(crossingElement.connectionHandleObject);
					}
				}
			}
			return list.ToArray();
		}

		public bool SideObjectIsDualSided(SideObject obj)
		{
			if (obj != null)
			{
				if (obj.relativeTo != 0 && obj.dualSided)
				{
					return true;
				}
				return false;
			}
			UnityEngine.Debug.LogWarning("EasyRoads3Dv3: nullReferenceException. This side object is aligned relative to the center of the road");
			return false;
		}

		public ERSideWalk OOCCDQDQDO(string name)
		{
			foreach (ERSideWalk sidewalk in sidewalks)
			{
				if (sidewalk.name == name)
				{
					return sidewalk;
				}
			}
			return null;
		}

		public void InitLoadImage(string url, int target)
		{
			if (target == 1)
			{
				infoTextures.Clear();
			}
			StartCoroutine(_4ssst(url, target));
		}

		[IteratorStateMachine(typeof(_003CLoadImage_003Ed__493))]
		private IEnumerator _4ssst(string tssss, int ussss)
		{
			return new ussst(0)
			{
				_003C_003E4__this = this,
				url = tssss,
				target = ussss
			};
		}

		[IteratorStateMachine(typeof(_003CBuildTerrainRoutine_003Ed__494))]
		public IEnumerator BuildTerrainRoutine(ERRoadNetwork roadNetwork)
		{
			return new vssss(0)
			{
				_003C_003E4__this = this,
				roadNetwork = roadNetwork
			};
		}

		public float OQDDDQOOQO(Vector3 fwd, Vector3 targetDir, Vector3 up)
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
