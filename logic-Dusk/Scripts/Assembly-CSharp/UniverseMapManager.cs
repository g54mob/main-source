using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class UniverseMapManager
{
	private class BoxLineRenderStruct
	{
		public GameObject obj;

		public LineRenderer topLine;

		public LineRenderer bottomLine;

		public LineRenderer leftLine;

		public LineRenderer rightLine;

		public TextMesh textMesh;

		public float sizeFactor = 1f;

		public Vector3 topPos1 = Vector3.zero;

		public Vector3 topPos2 = Vector3.zero;

		public Vector3 bottomPos1 = Vector3.zero;

		public Vector3 bottomPos2 = Vector3.zero;

		public Vector3 leftPos1 = Vector3.zero;

		public Vector3 leftPos2 = Vector3.zero;

		public Vector3 rightPos1 = Vector3.zero;

		public Vector3 rightPos2 = Vector3.zero;
	}

	public delegate void NodePlaced(UniverseNode node);

	public const float ALPHA_EDGE_DIM_FACTOR = 0.95f;

	private const float ALPHA_SELECTION_LINES = 0.25f;

	private const float DELAY_CAMERA_MOVE_FIRST = 0.5f;

	private const float DELAY_CAMERA_MOVE_SUBSEQUENT = 0.05f;

	private const float DELAY_CAMERA_ZOOM_FIRST = 0.5f;

	private const float DELAY_CAMERA_ZOOM_SUBSEQUENT = 0.001f;

	public static int SeedFleet = -1;

	public NodePlaced StartingNodePlaced;

	public NodePlaced TerminatingNodePlaced;

	private UniverseConstelation _currentConstelation;

	private UniverseConstelation HighlightedConstelation;

	private Texture2D CurrentConstelationThumbnail;

	public int NumberOfGalaxyNodes = 1000;

	public int BreakDownDepth = 3;

	public int BreakDownChanceOf = 2;

	public int DistanceBetweenShortConnections = 50;

	public int DistanceBetweenLongConnections = 500;

	public int biasFactor = 10;

	public int maxShortConnections = 5;

	public int maxLongConnections = 1;

	public int reduceLongConnectionsFactor = 4;

	private List<UniverseNode> placedNodes = new List<UniverseNode>();

	private List<UniverseNode> lastPlacedNodes = new List<UniverseNode>();

	private List<UniverseNode> galaxyNodeList = new List<UniverseNode>();

	private List<UniverseConstelation> constelationList = new List<UniverseConstelation>();

	private bool initializeForWorkspace;

	private bool isCameraMoving;

	private bool isCameraZooming;

	private float timerCameraMove;

	private float timerCameraZoom;

	private bool guarenteeEasyGalaxies;

	private List<string> easyGalaxyList;

	private UniverseNode _selectedViewNode;

	private UniverseNode _selectedTravelNode;

	private KeyValuePair<UniverseNode, UniverseNode> gateNodes;

	private List<KeyValuePair<UniverseNode, List<UniverseNode>>> canTravelToNodes;

	private List<UniverseNode> disconnectedNodes;

	private List<BoxLineRenderStruct> constellationGroupingList;

	private UniverseNode conditionalCurrentNode;

	private UniverseNode conditionalOtherNode;

	private UniverseConstelation mergeConstellation;

	private float delayNewNodeAlphaChangeStap;

	private float newNodeAlpha = 1f;

	private int newNodeAlphaDirection = -1;

	private UniverseNode snapStartNode;

	private UniverseNode snapEndNode;

	private bool isInSnapshotModeFirstPass;

	private bool ignoreKeyboardInputOnEditField;

	private Rect constelationToggleButtonRect = new Rect(450f, -235f, 200f, 20f);

	private Rect constelationWindowRect = new Rect(25f, 75f, 200f, Screen.height);

	private Rect constelationThumbWindowRect = new Rect(225f, 75f, 410f, 350f);

	private int selectedConstelationIndex = -1;

	private string editTextConstellation = string.Empty;

	public static UniverseMapManager Instance { get; private set; }

	public static GameObject universeNodePrefab { get; private set; }

	public static GameObject connectionLinePrefab { get; private set; }

	public static GameObject outlineBoxPrefab { get; private set; }

	public static GameObject selectionIcon { get; private set; }

	public static Material NodeMaterialNormal { get; private set; }

	public static Material NodeMaterialSelected { get; private set; }

	public static Material NodeMaterialMouseDown { get; private set; }

	public static Material NodeMaterialHighlighted { get; private set; }

	public static Material NodeMaterialHighlightedSelected { get; private set; }

	public static Material NodeMaterialNewNode { get; private set; }

	public static Material NodeMaterialNewSelectedNode { get; private set; }

	public static Material NodeMaterialNewHighlightedNode { get; private set; }

	public static Material NodeMaterialNewLineHighlighted { get; private set; }

	public static bool HasData { get; set; }

	public static bool ReturningFromReadOnlyGalaxy { get; set; }

	public UniverseConstelation CurrentConstelation
	{
		get
		{
			if (_currentConstelation == null)
			{
				return CurrentUniverseNode.constellation;
			}
			return _currentConstelation;
		}
		set
		{
			_currentConstelation = value;
		}
	}

	public UniverseNode CurrentUniverseNode { get; private set; }

	public bool AllLayersGenerated
	{
		get
		{
			return galaxyNodeList.Count == 0 || lastPlacedNodes.Count == 0;
		}
	}

	public int CountPlacedNodes
	{
		get
		{
			return placedNodes.Count;
		}
	}

	public int CountConstelation
	{
		get
		{
			if (constelationList != null)
			{
				return constelationList.Count;
			}
			return 0;
		}
	}

	public UniverseNode PreViewStartingNode { get; private set; }

	public int StargateJumpingFrom { get; private set; }

	public int DestinationGalaxyOverride { get; private set; }

	public bool IsJumpingToGalaxy { get; private set; }

	public bool IsReadOnlyGalaxy { get; private set; }

	public bool IsInTravelMode { get; private set; }

	public float cameraOrigSize { get; private set; }

	public Vector3 cameraOrigPos { get; private set; }

	public Vector3 cameraAdjPos { get; private set; }

	public Vector3 cameraPosDif
	{
		get
		{
			return cameraOrigPos - cameraAdjPos;
		}
	}

	public UniverseNode selectedViewNode
	{
		get
		{
			return _selectedViewNode;
		}
		private set
		{
			_selectedViewNode = value;
			if (value != null && value.gameObject != null && selectionIcon != null)
			{
				Vector3 position = value.gameObject.transform.position;
				position.z = selectionIcon.transform.position.z;
				selectionIcon.transform.position = position;
				SystemOverlayUI.Instance.RefreshUniverseNode(_selectedViewNode);
			}
		}
	}

	public UniverseNode selectedTravelNode
	{
		get
		{
			return _selectedTravelNode;
		}
		private set
		{
			_selectedTravelNode = value;
			if (value != null && value.gameObject != null && selectionIcon != null)
			{
				Vector3 position = value.gameObject.transform.position;
				position.z = selectionIcon.transform.position.z;
				selectionIcon.transform.position = position;
				SystemOverlayUI.Instance.RefreshUniverseNode(_selectedTravelNode);
			}
		}
	}

	public UniverseNode highlightedTravelNode { get; private set; }

	public bool IsInSnapshotMode { get; private set; }

	public bool isShowingConstellationSelectionPanel { get; private set; }

	public bool isEditingConstellationProperties { get; private set; }

	public bool IsReturningToPreviewSystem { get; set; }

	private UniverseMapManager()
	{
	}

	public UniverseMapManager(bool initializeForWorkspace, bool initializeDataOnly)
	{
		Instance = this;
		this.initializeForWorkspace = initializeForWorkspace;
		if (!initializeDataOnly)
		{
			if (universeNodePrefab == null)
			{
				universeNodePrefab = ResourceManager.LoadAsset<GameObject>("Prefabs/UniverseNodePrefab");
			}
			if (connectionLinePrefab == null)
			{
				connectionLinePrefab = ResourceManager.LoadAsset<GameObject>("Prefabs/Lines/ConnectionLinePrefab");
			}
			if (outlineBoxPrefab == null)
			{
				outlineBoxPrefab = ResourceManager.LoadAsset<GameObject>("Prefabs/Lines/OutlineBox");
			}
			if (NodeMaterialNormal == null)
			{
				NodeMaterialNormal = ResourceManager.LoadAsset<Material>("Materials/UniverseNodeNormal");
			}
			if (NodeMaterialSelected == null)
			{
				NodeMaterialSelected = ResourceManager.LoadAsset<Material>("Materials/UniverseNodeSelected");
			}
			if (NodeMaterialMouseDown == null)
			{
				NodeMaterialMouseDown = ResourceManager.LoadAsset<Material>("Materials/UniverseNodeMouseDown");
			}
			if (NodeMaterialHighlighted == null)
			{
				NodeMaterialHighlighted = ResourceManager.LoadAsset<Material>("Materials/UniverseNodeHighlighted");
			}
			if (NodeMaterialHighlightedSelected == null)
			{
				NodeMaterialHighlightedSelected = ResourceManager.LoadAsset<Material>("Materials/UniverseNodeHighlightedSelected");
			}
			if (NodeMaterialNewNode == null)
			{
				NodeMaterialNewNode = ResourceManager.LoadAsset<Material>("Materials/UniverseNodeNew");
			}
			if (NodeMaterialNewSelectedNode == null)
			{
				NodeMaterialNewSelectedNode = ResourceManager.LoadAsset<Material>("Materials/UniverseNodeNewSelected");
			}
			if (NodeMaterialNewHighlightedNode == null)
			{
				NodeMaterialNewHighlightedNode = ResourceManager.LoadAsset<Material>("Materials/UniverseNodeNewHighlighted");
			}
			if (NodeMaterialNewLineHighlighted == null)
			{
				NodeMaterialNewLineHighlighted = ResourceManager.LoadAsset<Material>("Materials/UniverseNewLineHighlighted");
			}
			Initialize();
		}
		if (!initializeForWorkspace)
		{
			if (!initializeDataOnly)
			{
			}
			if (string.IsNullOrEmpty(GameSaveFile.Get("UNIVERSE_ID", string.Empty)))
			{
				GameSaveFile.Save("UNIVERSE_ID", "DEFAULT");
			}
		}
	}

	public void Unload()
	{
		GalaxyProcessor.universeMapManager = null;
		universeNodePrefab = null;
		connectionLinePrefab = null;
		outlineBoxPrefab = null;
		selectionIcon = null;
		NodeMaterialNormal = null;
		NodeMaterialSelected = null;
		NodeMaterialMouseDown = null;
		NodeMaterialHighlighted = null;
		NodeMaterialHighlightedSelected = null;
		NodeMaterialNewNode = null;
		NodeMaterialNewSelectedNode = null;
		NodeMaterialNewHighlightedNode = null;
		NodeMaterialNewLineHighlighted = null;
		ResourceManager.UnloadAsset("Prefabs/UniverseNodePrefab");
		ResourceManager.UnloadAsset("Prefabs/Lines/ConnectionLinePrefab");
		ResourceManager.UnloadAsset("Prefabs/Lines/OutlineBox");
		ResourceManager.UnloadAsset("Materials/UniverseNodeNormal");
		ResourceManager.UnloadAsset("Materials/UniverseNodeSelected");
		ResourceManager.UnloadAsset("Materials/UniverseNodeMouseDown");
		ResourceManager.UnloadAsset("Materials/UniverseNodeHighlighted");
		ResourceManager.UnloadAsset("Materials/UniverseNodeHighlightedSelected");
		ResourceManager.UnloadAsset("Materials/UniverseNodeNew");
		ResourceManager.UnloadAsset("Materials/UniverseNodeNewSelected");
		ResourceManager.UnloadAsset("Materials/UniverseNodeNewHighlighted");
		ResourceManager.UnloadAsset("Materials/UniverseNewLineHighlighted");
	}

	public void RefreshCameraProperties()
	{
		cameraOrigPos = GalaxyMapManager.Instance.mainCamera.transform.position;
		cameraOrigSize = GalaxyMapManager.Instance.mainCamera.orthographicSize;
		cameraAdjPos = cameraOrigPos;
	}

	public void Initialize()
	{
		if (!initializeForWorkspace)
		{
			Color white = Color.white;
			selectionIcon = (GameObject)UnityEngine.Object.Instantiate(ResourceManager.SelectionIconPrefab, ResourceManager.SelectionIconPrefab.transform.position, ResourceManager.SelectionIconPrefab.transform.rotation);
			Transform transform = selectionIcon.transform.Find("XRight");
			white.a = 0.25f;
			if (transform != null)
			{
				LineRenderer component = transform.gameObject.GetComponent<LineRenderer>();
				component.SetColors(white, white);
			}
			transform = selectionIcon.transform.Find("XLeft");
			if (transform != null)
			{
				LineRenderer component2 = transform.gameObject.GetComponent<LineRenderer>();
				component2.SetColors(white, white);
			}
			transform = selectionIcon.transform.Find("YDown");
			if (transform != null)
			{
				LineRenderer component3 = transform.gameObject.GetComponent<LineRenderer>();
				component3.SetColors(white, white);
			}
			transform = selectionIcon.transform.Find("YUp");
			if (transform != null)
			{
				LineRenderer component4 = transform.gameObject.GetComponent<LineRenderer>();
				component4.SetColors(white, white);
			}
		}
	}

	public void UniverseReset()
	{
		int value = UniverseSaveFile.Get<int>("UNIVERSE_SEED");
		UniverseSaveFile.EraseFile();
		UniverseSaveFile.Save("UNIVERSE_SEED", value);
		if (GameSaveFile.Get("GAME_VER", 1.041f) <= 0.0302f)
		{
			UniverseSaveFile.Save(string.Format("EN_{0}", ShipInfestationType.PatrolBot), "P", "GSTATE");
			UniverseSaveFile.Save(string.Format("EN_{0}", ShipInfestationType.PatrolBot), "STATE", 1);
		}
		else
		{
			GameSaveFile.Save(string.Format("EN_{0}", ShipInfestationType.PatrolBot), "P", "GSTATE");
			GameSaveFile.Save(string.Format("EN_{0}", ShipInfestationType.PatrolBot), "STATE", 1);
		}
		UniverseSaveFile.DeleteAllSupportingDataFiles(false);
		HasData = false;
		foreach (UniverseNode placedNode in placedNodes)
		{
			placedNode.DestroyObjects();
		}
		placedNodes.Clear();
		lastPlacedNodes.Clear();
		galaxyNodeList.Clear();
		constelationList.Clear();
		if (GalaxyMapManager.Instance.CurrentMapState == GalaxyMapState.Universe)
		{
			SystemOverlayUI.Instance.SetConstelationStatus(false);
		}
		GenerateUniverse();
	}

	public List<UniverseNode> GetPlacedNodes()
	{
		return placedNodes;
	}

	public void ChooseStartingGalaxy()
	{
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
		}
		UniverseNode universeNode = null;
		List<string> list = null;
		if (DestinationGalaxyOverride == 0)
		{
			if (GalaxyMapManager.PreserveData)
			{
				int internalID = UniverseSaveFile.Get("CUR_GLXY", 0);
				if (internalID != 0)
				{
					universeNode = placedNodes.FirstOrDefault((UniverseNode x) => x != null && x.InternalID == internalID);
				}
			}
			if (universeNode == null)
			{
				bool flag = false;
				if (!GameSaveFile.Get("NC", false))
				{
					string text = UniverseSaveFile.Get("GHOP", string.Empty);
					if (!string.IsNullOrEmpty(text) && !text.Contains(','))
					{
						string[] array = text.Split('_');
						if (array.Length == 2)
						{
							int tempInternalID = 0;
							if (int.TryParse(array[1], out tempInternalID))
							{
								GalaxySaveFile.InitSetting(tempInternalID);
								if (GalaxySaveFile.GetStarSystemPathCount() <= 1)
								{
									universeNode = placedNodes.FirstOrDefault((UniverseNode x) => x != null && x.InternalID == tempInternalID);
									if (universeNode != null)
									{
										flag = true;
									}
								}
							}
						}
					}
				}
				if (universeNode == null)
				{
					List<string> allGroups = UniverseSaveFile.GetAllGroups("GX_");
					List<string> list2 = new List<string>();
					DataFile.Detach();
					if (!guarenteeEasyGalaxies)
					{
						string text2 = "~map";
						if (GameSaveFile.Get("UNIVERSE_ID", "DEFAULT") != "DEFAULT")
						{
							text2 += "_ch";
						}
						text2 += ".txt";
						foreach (string item2 in allGroups)
						{
							string text3 = UniverseSaveFile.Get(item2, "FILE", string.Empty);
							if (string.IsNullOrEmpty(text3))
							{
								continue;
							}
							DataFile.InitSetting(GameFileHelper.GetCurrentDataUniverseLocation(), string.Format("{0}.txt", text3));
							string text4 = DataFile.Get("DATA", string.Empty);
							DataFile.Detach();
							if (string.IsNullOrEmpty(text4))
							{
								continue;
							}
							string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
							dataGalaxyLocation = Path.Combine(dataGalaxyLocation, text4);
							DataFile.InitSetting(dataGalaxyLocation, text2);
							float num = DataFile.Get("DIFF_AVG", 1f);
							if (num <= 0.7f)
							{
								int num2 = DataFile.Get("NUM_DER", 0);
								int num3 = DataFile.Get("NUM_OUT", 0);
								if ((float)num2 > (float)num3 / 2f)
								{
									list2.Add(item2);
								}
							}
							DataFile.Detach();
						}
						if (list2.Count > 0)
						{
							list = new List<string>();
							list.AddRange(list2);
						}
						else
						{
							list = UniverseSaveFile.GetAllGroups("GX_");
						}
					}
					else
					{
						list = new List<string>();
						easyGalaxyList.Clear();
						easyGalaxyList.Add("Galaxy 13_sm");
						easyGalaxyList.Add("Galaxy 13_sm_f");
						easyGalaxyList.Add("Galaxy14_sm");
						easyGalaxyList.Add("Galaxy14_sm_f");
						easyGalaxyList.Add("Galaxy 15_sm");
						easyGalaxyList.Add("Galaxy 15_sm_f");
						easyGalaxyList.Add("Galaxy 16_sm");
						easyGalaxyList.Add("Galaxy 16_sm_f");
						foreach (string item3 in allGroups)
						{
							string text5 = UniverseSaveFile.Get(item3, "FILE", string.Empty);
							if (!string.IsNullOrEmpty(text5))
							{
								DataFile.InitSetting(GameFileHelper.GetCurrentDataUniverseLocation(), string.Format("{0}.txt", text5));
								string item = DataFile.Get("DATA", string.Empty);
								DataFile.Detach();
								if (easyGalaxyList.Contains(item))
								{
									list.Add(item3);
								}
							}
						}
						if (list.Count == 0)
						{
							Debug.LogError("Could not guarentee an easy starting galaxy!");
							list = UniverseSaveFile.GetAllGroups("GX_");
						}
					}
					if (list.Count > 1)
					{
						string lastSetting = UniverseSaveFile.GetLastSetting("GHOP");
						if (list.Contains(lastSetting))
						{
							list.Remove(lastSetting);
						}
						else
						{
							int num4 = 0;
							num4++;
						}
					}
					List<UniverseNode> list3 = new List<UniverseNode>();
					string galaxyGroupKey;
					foreach (string item4 in list)
					{
						galaxyGroupKey = item4;
						UniverseNode universeNode2 = placedNodes.FirstOrDefault((UniverseNode x) => x.GroupKey == galaxyGroupKey);
						if (universeNode2 != null)
						{
							list3.Add(universeNode2);
						}
					}
					if (!GameSaveFile.Get("NC", false))
					{
						int count = list3.Count;
						DataFile.Detach();
						for (int num5 = count - 1; num5 >= 0; num5--)
						{
							UniverseNode universeNode3 = list3[num5];
							string arg = UniverseSaveFile.Get(universeNode3.GroupKey, "FILE", string.Empty);
							DataFile.InitSetting(GameFileHelper.GetCurrentDataUniverseLocation(), string.Format("{0}.txt", arg));
							List<string> allGroups2 = DataFile.GetAllGroups("SYS_");
							DataFile.Detach();
							if (list3[num5].CountNodes >= allGroups2.Count)
							{
								list3.RemoveAt(num5);
							}
						}
					}
					if (GlobalSettings.gameMode == GameModeEnum.Normal)
					{
						int count2 = list3.Count;
						string text6 = string.Empty;
						for (int num6 = count2 - 1; num6 >= 0; num6--)
						{
							UniverseNode universeNode4 = list3[num6];
							if (text6 != string.Empty)
							{
								GalaxyProcessor.DeinitalizeGalaxy(text6);
							}
							text6 = UniverseSaveFile.Get(universeNode4.GroupKey, "NAME", string.Empty);
							GalaxyProcessor.InitalizeGalaxy(text6);
							GalaxySaveFile.InitSetting(universeNode4.InternalID);
							int seed = UnityEngine.Random.seed;
							UnityEngine.Random.seed = GalaxySaveFile.GetGalaxySeed(seed);
							int seed2 = UnityEngine.Random.seed;
							List<StarSystemInfo> collection = GalaxyProcessor.BuildStarSystems(seed2);
							GlobalSettings.GameState.StarSystems = new List<StarSystemInfo>(collection);
							List<StarSystemInfo> list4 = null;
							float minDifficulty = 0f;
							float maxDifficulty = 0.65f;
							if (GameSaveFile.Get("HARD", false))
							{
								minDifficulty = 0.45f;
								maxDifficulty = 1f;
							}
							int numberMatchesInOriginalRange = 0;
							float minDifficultyBestMatch = 0f;
							float maxDifficultyBestMatch = 0f;
							List<StarSystemInfo> list5 = GalaxyProcessor.FilterStarSystemByDifficulty(minDifficulty, maxDifficulty, 3, true, out numberMatchesInOriginalRange, out minDifficultyBestMatch, out maxDifficultyBestMatch);
							IEnumerable<StarSystemInfo> enumerable = null;
							if (list5 == null)
							{
								int numberMatchesInOriginalRange2 = 0;
								float minDifficultyBestMatch2 = 0f;
								float maxDifficultyBestMatch2 = 0f;
								list5 = GalaxyProcessor.FilterStarSystemByDifficulty(minDifficultyBestMatch, maxDifficultyBestMatch, 3, false, out numberMatchesInOriginalRange2, out minDifficultyBestMatch2, out maxDifficultyBestMatch2);
								if (list5 == null)
								{
									list3.RemoveAt(num6);
									continue;
								}
							}
							if (list5 != null)
							{
								enumerable = list5.Where(GalaxyProcessor.IsValidStartingStarSystem);
								if (enumerable == null)
								{
									list3.RemoveAt(num6);
									continue;
								}
							}
							list4 = enumerable.ToList();
							int bestHopCount = 0;
							List<StarSystemInfo> list6 = GalaxyProcessor.FilterStarSystemsByPotentialHops(3, list4, out bestHopCount);
							if (list6 != null && list6.Count > 0)
							{
								list4 = list6;
							}
							else
							{
								bool flag2 = false;
								if (bestHopCount > 1)
								{
									list6 = GalaxyProcessor.FilterStarSystemsByPotentialHops(bestHopCount, list4, out bestHopCount);
									if (list6 != null && list6.Count > 0)
									{
										list4 = list6;
										flag2 = true;
									}
								}
								if (!flag2)
								{
									list3.RemoveAt(num6);
									continue;
								}
							}
							if (!GalaxyProcessor.CanReachStargateInCurrentGalaxy(list4))
							{
								Debug.LogWarning(string.Format("Startup Galaxy: Removed '{0}' because couldn't reach the stargate from all otherwise valid star systems", text6));
								list3.RemoveAt(num6);
							}
						}
						if (text6 != string.Empty)
						{
							GalaxyProcessor.DeinitalizeGalaxy(text6);
						}
					}
					Debug.Log(string.Format("Number of starting galaxies from which to choose: {0}", list3.Count));
					int num7 = UnityEngine.Random.Range(0, list3.Count);
					if (list3.Count > num7)
					{
						universeNode = list3[num7];
					}
					else
					{
						num7 = UnityEngine.Random.Range(0, placedNodes.Count);
						universeNode = placedNodes[num7];
						Debug.LogError(string.Format("Startup Galaxy: There were no galaxies left after all filters run - choosing a galaxy at random from ANY galaxy in the universe"));
					}
				}
			}
		}
		else
		{
			universeNode = placedNodes.FirstOrDefault((UniverseNode x) => x != null && x.InternalID == DestinationGalaxyOverride);
			if (universeNode == null)
			{
				Debug.LogError("DestinationGalaxyOverride provided, but couldn't find that node in our placed nodes!");
			}
		}
		if (CurrentUniverseNode != null)
		{
			CurrentUniverseNode.IsSelected = false;
		}
		if (!IsReadOnlyGalaxy)
		{
			UniverseSaveFile.Add("GHOP", universeNode.GroupKey);
			UniverseSaveFile.Save(universeNode.GroupKey, "FILE", string.Format("gd_{0}", universeNode.InternalID));
			UniverseSaveFile.Save("CUR_GLXY", universeNode.InternalID);
		}
		universeNode.IsSelected = true;
		CurrentUniverseNode = universeNode;
		if (CurrentUniverseNode.constellation != null)
		{
			UpdateConstelationDataStates();
		}
		GalaxySaveFile.InitSetting(universeNode.InternalID);
		string text7 = AssignGalaxyMapToNode(universeNode);
		if (!string.IsNullOrEmpty(text7))
		{
			GameSaveFile.Save("GALAXY_ID", text7);
		}
		Debug.Log(string.Format("Map Choosen: {0}, Galaxy Name: {1}, Galaxy ID: {2}", text7, universeNode.name, universeNode.InternalID));
	}

	public void BeginTravelMode(UniverseNode gateNode, UniverseNode gateNodeOtherSide)
	{
		IsInTravelMode = true;
		SystemOverlayUI.Instance.SwitchToUniverseInTravelMode();
		selectionIcon.SetActive(true);
		bool flag = false;
		if (gateNodeOtherSide != null && gateNodeOtherSide.IsVisitedConditional)
		{
			conditionalOtherNode = gateNodeOtherSide;
			UniverseNode.ConnectionEdge edgeToOtherNode = gateNodeOtherSide.GetEdgeToOtherNode(gateNode);
			if (edgeToOtherNode != null && !edgeToOtherNode.IsEnabled)
			{
				edgeToOtherNode.IsEnabledConditional = true;
			}
		}
		else if (gateNode.IsVisitedConditional)
		{
			gateNodeOtherSide.IsVisitedConditionalFake = true;
			flag = true;
		}
		if (gateNode.IsVisitedConditional)
		{
			conditionalCurrentNode = gateNode;
			UniverseNode.ConnectionEdge edgeToOtherNode2 = gateNode.GetEdgeToOtherNode(gateNodeOtherSide);
			if (edgeToOtherNode2 != null && !edgeToOtherNode2.IsEnabled)
			{
				edgeToOtherNode2.IsEnabledConditional = true;
			}
		}
		else if (gateNodeOtherSide != null && gateNodeOtherSide.IsVisitedConditional)
		{
			gateNode.IsVisitedConditionalFake = true;
			flag = true;
		}
		if (conditionalCurrentNode == null && conditionalOtherNode == null)
		{
			if (gateNode.edgeToParent != null && gateNode.edgeToParent.EdgeConnectsToNode(gateNodeOtherSide))
			{
				if (!gateNode.edgeToParent.IsEnabled)
				{
					gateNode.edgeToParent.IsEnabledConditional = true;
					flag = true;
				}
			}
			else if (gateNodeOtherSide != null && gateNodeOtherSide.edgeToParent != null && gateNodeOtherSide.edgeToParent.EdgeConnectsToNode(gateNode) && !gateNodeOtherSide.edgeToParent.IsEnabled)
			{
				gateNodeOtherSide.edgeToParent.IsEnabledConditional = true;
				flag = true;
			}
		}
		if (flag)
		{
			Show();
		}
		ShowAllActiveConstelations();
		gateNodes = new KeyValuePair<UniverseNode, UniverseNode>(gateNode, gateNodeOtherSide);
		IEnumerable<UniverseNode> enumerable = placedNodes.Where((UniverseNode x) => x != null && x.IsVisible);
		if (enumerable != null)
		{
			List<UniverseNode> list = enumerable.ToList();
			canTravelToNodes = GetPathsFromNode(CurrentUniverseNode, list);
			IEnumerable<UniverseNode> enumerable2 = list.Where((UniverseNode x) => x != null && x != CurrentUniverseNode && !canTravelToNodes.Any((KeyValuePair<UniverseNode, List<UniverseNode>> y) => y.Key.InternalID == x.InternalID));
			if (enumerable2 != null)
			{
				disconnectedNodes = enumerable2.ToList();
				foreach (UniverseNode disconnectedNode in disconnectedNodes)
				{
					if (disconnectedNode.nodeObject != null)
					{
						disconnectedNode.nodeObject.Disable();
					}
					if (disconnectedNode.gameObject != null)
					{
						Color color = disconnectedNode.gameObject.GetComponent<Renderer>().material.color;
						color.a /= 2f;
						disconnectedNode.gameObject.GetComponent<Renderer>().material.color = color;
						disconnectedNode.nodeObject.keyUI.label.color = color;
					}
				}
			}
		}
		ClearConstelation();
		if (gateNodeOtherSide != null)
		{
			if (gateNode.constellation != null)
			{
				if (gateNodeOtherSide.constellation == null)
				{
					gateNodeOtherSide.constelationTemp = gateNode.constellation;
				}
				else if (gateNode.constellation != gateNodeOtherSide.constellation && mergeConstellation == null)
				{
					mergeConstellation = new UniverseConstelation();
				}
			}
			else if (gateNodeOtherSide.constellation == null)
			{
				if (mergeConstellation == null)
				{
					mergeConstellation = new UniverseConstelation();
				}
				foreach (KeyValuePair<UniverseNode, List<UniverseNode>> canTravelToNode in canTravelToNodes)
				{
					if (gateNode.constelationTemp == null && canTravelToNode.Key.constellation != null && canTravelToNode.Key.GetEdgeToOtherNode(gateNode) != null)
					{
						gateNode.constelationTemp = canTravelToNode.Key.constellation;
					}
					if (gateNodeOtherSide.constelationTemp == null && canTravelToNode.Key.constellation != null && canTravelToNode.Key.GetEdgeToOtherNode(gateNodeOtherSide) != null)
					{
						gateNodeOtherSide.constelationTemp = canTravelToNode.Key.constellation;
					}
					if (gateNode.constelationTemp != null && gateNodeOtherSide.constelationTemp != null)
					{
						break;
					}
				}
			}
			else
			{
				gateNode.constelationTemp = gateNodeOtherSide.constellation;
				CurrentConstelation = gateNodeOtherSide.constellation;
			}
		}
		List<UniverseConstelation> list2 = new List<UniverseConstelation>();
		foreach (KeyValuePair<UniverseNode, List<UniverseNode>> canTravelToNode2 in canTravelToNodes)
		{
			if (((gateNode.constellation != null && canTravelToNode2.Key.constellation != gateNode.constellation) || (gateNode.constelationTemp != null && canTravelToNode2.Key.constellation != gateNode.constelationTemp) || (gateNodeOtherSide != null && gateNodeOtherSide.constellation != null && canTravelToNode2.Key.constellation != gateNodeOtherSide.constellation) || (gateNodeOtherSide.constelationTemp != null && canTravelToNode2.Key.constellation != gateNodeOtherSide.constelationTemp)) && (canTravelToNode2.Key != gateNodeOtherSide || gateNodeOtherSide.constellation != null) && !list2.Contains(canTravelToNode2.Key.constellation))
			{
				mergeConstellation = new UniverseConstelation();
				CurrentConstelation = null;
				CurrentConstelationThumbnail = null;
				list2.Add(canTravelToNode2.Key.constellation);
				if (!list2.Contains(gateNode.constellation))
				{
					list2.Add(gateNode.constellation);
				}
			}
		}
		RefreshConstelation();
		if (list2.Count > 0)
		{
			int num = -1;
			foreach (UniverseConstelation item in list2)
			{
				Color color2 = Color.white;
				num++;
				switch (num)
				{
				case 0:
					color2 = Color.red;
					break;
				case 1:
					color2 = Color.green;
					break;
				case 2:
					color2 = Color.blue;
					break;
				case 3:
					color2 = Color.yellow;
					break;
				case 4:
					color2 = Color.cyan;
					break;
				case 5:
					color2 = Color.magenta;
					break;
				default:
					num = -1;
					break;
				}
				Rect extent = GetExtent(item);
				float num2 = 20f;
				float num3 = 20f;
				extent.x -= num2 / 2f;
				extent.y -= num3 / 2f;
				extent.width += num2;
				extent.height += num3;
				float num4 = 300f / GalaxyMapManager.Instance.mainCamera.orthographicSize;
				Vector3 position = extent.center;
				position.z = 0f;
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(outlineBoxPrefab, position, Quaternion.identity);
				Transform transform = gameObject.transform.Find("TopLine");
				Transform transform2 = gameObject.transform.Find("BottomLine");
				Transform transform3 = gameObject.transform.Find("LeftLine");
				Transform transform4 = gameObject.transform.Find("RightLine");
				Transform transform5 = gameObject.transform.Find("Name");
				BoxLineRenderStruct boxLineRenderStruct = new BoxLineRenderStruct();
				boxLineRenderStruct.obj = gameObject;
				boxLineRenderStruct.topLine = (LineRenderer)transform.gameObject.GetComponent<Renderer>();
				boxLineRenderStruct.bottomLine = (LineRenderer)transform2.gameObject.GetComponent<Renderer>();
				boxLineRenderStruct.leftLine = (LineRenderer)transform3.gameObject.GetComponent<Renderer>();
				boxLineRenderStruct.rightLine = (LineRenderer)transform4.gameObject.GetComponent<Renderer>();
				boxLineRenderStruct.textMesh = transform5.gameObject.GetComponent<TextMesh>();
				boxLineRenderStruct.sizeFactor = cameraOrigSize / GalaxyMapManager.Instance.mainCamera.orthographicSize;
				boxLineRenderStruct.topPos1 = new Vector3(extent.x, extent.y + extent.height, -1f);
				boxLineRenderStruct.topPos2 = new Vector3(extent.x + extent.width, extent.y + extent.height, -1f);
				boxLineRenderStruct.bottomPos1 = new Vector3(extent.x, extent.y, -1f);
				boxLineRenderStruct.bottomPos2 = new Vector3(extent.x + extent.width, extent.y, -1f);
				boxLineRenderStruct.leftPos1 = new Vector3(extent.x, extent.y, -1f);
				boxLineRenderStruct.leftPos2 = new Vector3(extent.x, extent.y + extent.height, -1f);
				boxLineRenderStruct.rightPos1 = new Vector3(extent.x + extent.width, extent.y, -1f);
				boxLineRenderStruct.rightPos2 = new Vector3(extent.x + extent.width, extent.y + extent.height, -1f);
				BoxLineRenderStruct boxLineRenderStruct2 = boxLineRenderStruct;
				boxLineRenderStruct2.topLine.SetColors(color2, color2);
				boxLineRenderStruct2.bottomLine.SetColors(color2, color2);
				boxLineRenderStruct2.leftLine.SetColors(color2, color2);
				boxLineRenderStruct2.rightLine.SetColors(color2, color2);
				boxLineRenderStruct2.textMesh.text = string.Format("{0}", item.name);
				boxLineRenderStruct2.textMesh.characterSize = 5.3f;
				boxLineRenderStruct2.textMesh.fontSize = 20;
				Vector3 bottomPos = boxLineRenderStruct2.bottomPos1;
				bottomPos.y -= 1f;
				boxLineRenderStruct2.textMesh.transform.position = bottomPos;
				if (transform != null && transform.gameObject != null)
				{
					boxLineRenderStruct2.topLine.SetPosition(0, boxLineRenderStruct2.topPos1);
					boxLineRenderStruct2.topLine.SetPosition(1, boxLineRenderStruct2.topPos2);
				}
				if (transform2 != null && transform2.gameObject != null)
				{
					boxLineRenderStruct2.bottomLine.SetPosition(0, boxLineRenderStruct2.bottomPos1);
					boxLineRenderStruct2.bottomLine.SetPosition(1, boxLineRenderStruct2.bottomPos2);
				}
				if (transform3 != null && transform3.gameObject != null)
				{
					boxLineRenderStruct2.leftLine.SetPosition(0, boxLineRenderStruct2.leftPos1);
					boxLineRenderStruct2.leftLine.SetPosition(1, boxLineRenderStruct2.leftPos2);
				}
				if (transform4 != null && transform4.gameObject != null)
				{
					boxLineRenderStruct2.rightLine.SetPosition(0, boxLineRenderStruct2.rightPos1);
					boxLineRenderStruct2.rightLine.SetPosition(1, boxLineRenderStruct2.rightPos2);
				}
				if (constellationGroupingList == null)
				{
					constellationGroupingList = new List<BoxLineRenderStruct>();
				}
				constellationGroupingList.Add(boxLineRenderStruct2);
			}
		}
		selectedTravelNode = CurrentUniverseNode;
		if (CurrentConstelation == null)
		{
			RefreshConstelation();
		}
	}

	public void EndTravelMode()
	{
		EndTravelMode(false);
	}

	public void EndTravelMode(bool wasCanceled)
	{
		if (wasCanceled)
		{
			if (selectedTravelNode != null && selectedTravelNode.nodeObject != null)
			{
				selectedTravelNode.nodeObject.Refresh();
			}
			if (highlightedTravelNode != null && highlightedTravelNode.nodeObject != null)
			{
				highlightedTravelNode.nodeObject.Refresh();
			}
			ClearPathToNode(highlightedTravelNode, false);
			ClearPathToNode(selectedTravelNode, false);
			ClearHighlightedPath();
			gateNodes.Key.ClearConditionalyEnabledEdges();
			if (gateNodes.Value != null)
			{
				gateNodes.Value.ClearConditionalyEnabledEdges();
			}
			if (gateNodes.Key != null && gateNodes.Key.constellation == null && gateNodes.Key.constelationTemp != null)
			{
				gateNodes.Key.constellation = gateNodes.Key.constelationTemp;
				gateNodes.Key.constelationTemp = null;
			}
			if (gateNodes.Value != null && gateNodes.Value.constellation == null && gateNodes.Value.constelationTemp != null)
			{
				gateNodes.Value.constellation = gateNodes.Value.constelationTemp;
				gateNodes.Value.constelationTemp = null;
			}
			selectionIcon.SetActive(false);
			if (CurrentUniverseNode.gameObject != null)
			{
				CurrentUniverseNode.gameObject.SetActive(false);
				CurrentUniverseNode.gameObject = null;
			}
		}
		else
		{
			MergeConstellation();
			bool flag = true;
			if (gateNodes.Key != null && gateNodes.Key != CurrentUniverseNode && gateNodes.Key != selectedTravelNode)
			{
				flag = false;
			}
			else if (gateNodes.Value != null && gateNodes.Value != CurrentUniverseNode && gateNodes.Value != selectedTravelNode)
			{
				flag = false;
			}
			if (flag)
			{
				GalaxyMapManager.Instance.ExternalConfirmJump();
			}
		}
		if (gateNodes.Key != null)
		{
			gateNodes.Key.constelationTemp = null;
		}
		if (gateNodes.Value != null)
		{
			gateNodes.Value.constelationTemp = null;
		}
		if (disconnectedNodes != null)
		{
			foreach (UniverseNode disconnectedNode in disconnectedNodes)
			{
				disconnectedNode.nodeObject.Enable();
				if (disconnectedNode.gameObject != null)
				{
					Color color = disconnectedNode.gameObject.GetComponent<Renderer>().material.color;
					color.a *= 2f;
					disconnectedNode.gameObject.GetComponent<Renderer>().material.color = color;
					disconnectedNode.nodeObject.keyUI.label.color = color;
				}
			}
			disconnectedNodes = null;
		}
		if (conditionalCurrentNode != null)
		{
			conditionalCurrentNode.IsVisited = false;
		}
		if (conditionalOtherNode != null)
		{
			conditionalOtherNode.IsVisited = false;
		}
		conditionalCurrentNode = null;
		conditionalOtherNode = null;
		CurrentUniverseNode.IsVisitedConditionalFake = false;
		foreach (UniverseNode placedNode in placedNodes)
		{
			if (placedNode.IsVisitedConditional)
			{
				placedNode.IsVisitedConditional = false;
			}
			if (placedNode.IsVisitedConditionalFake)
			{
				placedNode.IsVisitedConditionalFake = false;
			}
		}
		if (highlightedTravelNode != null && highlightedTravelNode != selectedTravelNode)
		{
			ClearPathToNode(highlightedTravelNode);
			HighlightPathToNode(selectedTravelNode);
		}
		CurrentConstelation = null;
		CurrentConstelationThumbnail = null;
		RefreshConstelation();
		canTravelToNodes = null;
		selectedTravelNode = null;
		highlightedTravelNode = null;
		mergeConstellation = null;
		if (constellationGroupingList != null && constellationGroupingList.Count > 0)
		{
			foreach (BoxLineRenderStruct constellationGrouping in constellationGroupingList)
			{
				UnityEngine.Object.Destroy(constellationGrouping.obj);
			}
			constellationGroupingList = null;
		}
		IsInTravelMode = false;
	}

	private void SolidifyConditionalElementsBeforeJump(UniverseNode endNode)
	{
		IEnumerable<UniverseNode> source = placedNodes.Where((UniverseNode x) => x != null && x.IsVisible && x.edgeToParent != null && x.edgeToParent.IsEnabledConditional);
		KeyValuePair<UniverseNode, List<UniverseNode>> keyValuePair = canTravelToNodes.FirstOrDefault((KeyValuePair<UniverseNode, List<UniverseNode>> x) => x.Key != null && x.Key.InternalID == endNode.InternalID);
		if (source.Count() > 0)
		{
			List<UniverseNode> list = source.ToList();
			foreach (UniverseNode item in list)
			{
				if (keyValuePair.Value.Contains(item) || endNode == item || CurrentUniverseNode == item)
				{
					UniverseNode.ConnectionEdge conditionalEdge = item.GetConditionalEdge();
					UniverseNode otherNode = conditionalEdge.GetOtherNode(item);
					if (keyValuePair.Value.Contains(otherNode) || endNode == otherNode || CurrentUniverseNode == otherNode)
					{
						conditionalEdge.IsEnabled = true;
						conditionalEdge.IsEnabledConditional = false;
					}
				}
			}
		}
		source = placedNodes.Where((UniverseNode x) => x != null && x.IsVisible && x.edgeToParent != null && x.edgeToParent.IsEnabledConditional);
		if (source.Count() > 0)
		{
			List<UniverseNode> list2 = source.ToList();
			foreach (UniverseNode item2 in list2)
			{
				UniverseNode.ConnectionEdge conditionalEdge2 = item2.GetConditionalEdge();
				conditionalEdge2.IsEnabledConditional = false;
				if (!keyValuePair.Value.Contains(item2) && endNode != item2 && CurrentUniverseNode != item2)
				{
					item2.Hide();
					if (gateNodes.Value == item2)
					{
						gateNodes = new KeyValuePair<UniverseNode, UniverseNode>(gateNodes.Key, null);
					}
				}
				UniverseNode otherNode2 = conditionalEdge2.GetOtherNode(item2);
				if (!keyValuePair.Value.Contains(otherNode2) && endNode != otherNode2 && CurrentUniverseNode != otherNode2)
				{
					otherNode2.Hide();
					if (gateNodes.Value == otherNode2)
					{
						gateNodes = new KeyValuePair<UniverseNode, UniverseNode>(gateNodes.Key, null);
					}
				}
			}
			int num = 0;
			num++;
		}
		else
		{
			int num2 = 0;
			num2++;
		}
		if (gateNodes.Key != null && !gateNodes.Key.IsVisited)
		{
			gateNodes.Key.IsVisitedConditional = false;
		}
		if (gateNodes.Value != null && !gateNodes.Value.IsVisited)
		{
			gateNodes.Value.IsVisitedConditional = false;
		}
		if (gateNodes.Key != null)
		{
			gateNodes.Key.ClearConditionalyEnabledEdges();
		}
		if (gateNodes.Value != null)
		{
			gateNodes.Value.ClearConditionalyEnabledEdges();
		}
		IEnumerable<UniverseNode> enumerable = placedNodes.Where((UniverseNode x) => x != null && x.IsVisible);
		if (enumerable != null)
		{
			List<UniverseNode> possibleNodes = enumerable.ToList();
			canTravelToNodes = GetPathsFromNode(CurrentUniverseNode, possibleNodes);
			ClearConstelation();
			RefreshConstelation();
		}
	}

	private void MergeConstellation()
	{
		if (mergeConstellation != null)
		{
			GenerateUniverseID(mergeConstellation);
			AddConstelation(mergeConstellation);
			string newName = "Unknown";
			int num = 0;
			while (constelationList.FirstOrDefault((UniverseConstelation x) => x != null && x.name == newName) != null)
			{
				num++;
				newName = string.Format("Unknown {0}", num);
			}
			mergeConstellation.name = newName;
			foreach (KeyValuePair<UniverseNode, List<UniverseNode>> canTravelToNode in canTravelToNodes)
			{
				if (canTravelToNode.Key.constellation != null && canTravelToNode.Key.constellation.InternalID != mergeConstellation.InternalID)
				{
					RemoveConstelation(canTravelToNode.Key.constellation);
				}
				canTravelToNode.Key.constellation = mergeConstellation;
			}
			if (gateNodes.Key != null)
			{
				gateNodes.Key.constellation = mergeConstellation;
			}
			if (gateNodes.Value != null)
			{
				gateNodes.Value.constellation = mergeConstellation;
			}
			mergeConstellation = null;
		}
		else
		{
			if (gateNodes.Key != null && gateNodes.Key.constellation == null && gateNodes.Key.constelationTemp != null)
			{
				gateNodes.Key.constellation = gateNodes.Key.constelationTemp;
				gateNodes.Key.constelationTemp = null;
			}
			if (gateNodes.Value != null && gateNodes.Value.constellation == null && gateNodes.Value.constelationTemp != null)
			{
				gateNodes.Value.constellation = gateNodes.Value.constelationTemp;
				gateNodes.Value.constelationTemp = null;
			}
		}
	}

	public void ReturnToPreViewGalaxy()
	{
		if (PreViewStartingNode != null)
		{
			ReturningFromReadOnlyGalaxy = true;
			IsReadOnlyGalaxy = false;
			IsJumpingToGalaxy = false;
			IsReturningToPreviewSystem = true;
			Instance.BeginJumpToGalaxy(Instance.CurrentUniverseNode, Instance.PreViewStartingNode, false);
		}
	}

	public void BeginJumpToGalaxy(StarSystemInfo startingStarSystem)
	{
		UniverseNode startNode = (startingStarSystem.IsChildGate ? startingStarSystem.StargateConnection.childNode : startingStarSystem.StargateConnection.parentNode);
		UniverseNode endNode = (startingStarSystem.IsChildGate ? startingStarSystem.StargateConnection.parentNode : startingStarSystem.StargateConnection.childNode);
		BeginJumpToGalaxy(startNode, endNode);
	}

	public void BeginJumpToGalaxy(UniverseNode startNode, UniverseNode endNode)
	{
		BeginJumpToGalaxy(startNode, endNode, false);
	}

	public void BeginJumpToGalaxy(UniverseNode startNode, UniverseNode endNode, bool readOnly)
	{
		SystemOverlayUI.Instance.EnableCameraBlur();
		startNode.IsVisited = true;
		endNode.IsVisited = true;
		StargateJumpingFrom = startNode.InternalID;
		DestinationGalaxyOverride = endNode.InternalID;
		if (readOnly)
		{
			if (!IsReadOnlyGalaxy)
			{
				IsReadOnlyGalaxy = true;
				PreViewStartingNode = CurrentUniverseNode;
			}
			else if (endNode == PreViewStartingNode)
			{
				IsReadOnlyGalaxy = false;
				IsReturningToPreviewSystem = true;
				PreViewStartingNode = null;
			}
			else
			{
				IsReadOnlyGalaxy = true;
			}
		}
		else
		{
			if (!IsReadOnlyGalaxy && !ReturningFromReadOnlyGalaxy)
			{
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UniverseWarpOut);
			}
			IsReadOnlyGalaxy = false;
			PreViewStartingNode = null;
		}
		if (startNode.edgeToParent != null && startNode.edgeToParent.EdgeConnectsToNode(endNode))
		{
			startNode.edgeToParent.IsEnabled = true;
		}
		else if (endNode.edgeToParent != null && endNode.edgeToParent.EdgeConnectsToNode(startNode))
		{
			endNode.edgeToParent.IsEnabled = true;
		}
		StarField.ClearOnMapChange();
		GlobalSettings.RetrySameInitialState = false;
		GlobalSettings.IsGamePaused = false;
		ModalWindow.CloseModalWindow();
		GameplayManager.ResetGameState();
		IsJumpingToGalaxy = true;
		GalaxyMapManager.PreserveData = true;
		Application.LoadLevel(Application.loadedLevel);
	}

	public bool FindAndSetStarSystemByStargate()
	{
		StarSystemInfo starSystemInfo = GlobalSettings.GameState.StarSystems.FirstOrDefault((StarSystemInfo x) => x != null && x.HasStargate && ((!x.IsChildGate && x.StargateConnection.parentNode.InternalID == DestinationGalaxyOverride && x.StargateConnection.childNode.InternalID == StargateJumpingFrom) || (x.IsChildGate && x.StargateConnection.childNode.InternalID == DestinationGalaxyOverride && x.StargateConnection.parentNode.InternalID == StargateJumpingFrom)));
		if (starSystemInfo == null)
		{
			Debug.LogError(string.Format("Couldn't find a star system with the star gate between {0} and {1}", StargateJumpingFrom, DestinationGalaxyOverride));
			return false;
		}
		GlobalSettings.GameState.ThePlayer.CurrentStarSystem = starSystemInfo;
		if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id == 0)
		{
			int num = GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "ID", 0);
			if (num == 0)
			{
				num = GlobalSettings.GameState.NextSystemId++;
			}
			GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id = num;
		}
		if (!IsReadOnlyGalaxy)
		{
			GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.AgeInventoryItems(1);
			GalaxySaveFile.AppendStarSystemToPath(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id);
			if (!GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VIEWED", false))
			{
				UniverseSaveFile.Save("SYSJMP", UniverseSaveFile.Get("SYSJMP", 1) + 1);
			}
			GalaxySaveFile.Save(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VIEWED", true);
		}
		return true;
	}

	public void EndJumpToGalaxy()
	{
		if (!IsReadOnlyGalaxy)
		{
			StargateJumpingFrom = 0;
			DestinationGalaxyOverride = 0;
			IsJumpingToGalaxy = false;
			UpdateConstelationDataStates();
			SystemOverlayUI.Instance.DisableCameraBlur();
		}
	}

	public void HighlightPathToNode(UniverseNode destNode)
	{
		HighlightPathToNode(destNode, false);
	}

	public void HighlightPathToNode(UniverseNode destNode, bool selectedHighlight)
	{
		if (!IsInTravelMode)
		{
			return;
		}
		highlightedTravelNode = destNode;
		Material nodeMaterialHighlighted = NodeMaterialHighlighted;
		Material material = (selectedHighlight ? NodeMaterialHighlightedSelected : NodeMaterialHighlighted);
		KeyValuePair<UniverseNode, List<UniverseNode>> keyValuePair = canTravelToNodes.FirstOrDefault((KeyValuePair<UniverseNode, List<UniverseNode>> x) => x.Key.InternalID == destNode.InternalID);
		if (keyValuePair.Value == null)
		{
			return;
		}
		UniverseNode universeNode = keyValuePair.Key;
		foreach (UniverseNode item in keyValuePair.Value)
		{
			if (item != CurrentUniverseNode)
			{
				item.gameObject.GetComponent<Renderer>().material = nodeMaterialHighlighted;
				if (!selectedHighlight && selectedTravelNode.InternalID != item.InternalID)
				{
					item.gameObject.transform.localScale = item.nodeObject.initialScale * 2f;
					if (item.nodeObject.transform.localScale.x == 20f)
					{
						item.nodeObject.keyUI.gameObject.transform.localScale = new Vector3(0.0125f, 0.0125f, 0.0125f);
					}
					else if (item.nodeObject.transform.localScale.x == 10f)
					{
						item.nodeObject.keyUI.gameObject.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
					}
					else
					{
						item.nodeObject.keyUI.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
					}
				}
			}
			if (universeNode != null)
			{
				if (item.parent == universeNode)
				{
					if (item.edgeToParent.edgeLine != null)
					{
						item.edgeToParent.edgeLine.GetComponent<Renderer>().material = material;
						Color color = item.edgeToParent.edgeLine.GetComponent<Renderer>().material.color;
						color.a *= 0.95f;
						item.edgeToParent.edgeLine.GetComponent<Renderer>().material.color = color;
						((LineRenderer)item.edgeToParent.edgeLine.GetComponent<Renderer>()).SetWidth(6f, 6f);
					}
				}
				else if (universeNode.parent == item && universeNode.edgeToParent.edgeLine != null)
				{
					universeNode.edgeToParent.edgeLine.GetComponent<Renderer>().material = material;
					Color color2 = universeNode.edgeToParent.edgeLine.GetComponent<Renderer>().material.color;
					color2.a *= 0.95f;
					universeNode.edgeToParent.edgeLine.GetComponent<Renderer>().material.color = color2;
					((LineRenderer)universeNode.edgeToParent.edgeLine.GetComponent<Renderer>()).SetWidth(6f, 6f);
				}
			}
			universeNode = item;
		}
		keyValuePair.Key.gameObject.GetComponent<Renderer>().material = nodeMaterialHighlighted;
		if (!selectedHighlight && selectedTravelNode.InternalID != keyValuePair.Key.InternalID)
		{
			keyValuePair.Key.gameObject.transform.localScale = keyValuePair.Key.nodeObject.initialScale * 2f;
			if (keyValuePair.Key.nodeObject.transform.localScale.x == 20f)
			{
				keyValuePair.Key.nodeObject.keyUI.gameObject.transform.localScale = new Vector3(0.0125f, 0.0125f, 0.0125f);
			}
			else if (keyValuePair.Key.nodeObject.transform.localScale.x == 10f)
			{
				keyValuePair.Key.nodeObject.keyUI.gameObject.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
			}
			else
			{
				keyValuePair.Key.nodeObject.keyUI.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
			}
		}
	}

	public void ClearHighlightedPath()
	{
		if (IsInTravelMode)
		{
			UniverseNode nodeToClear = selectedTravelNode;
			if (canTravelToNodes != null)
			{
				KeyValuePair<UniverseNode, List<UniverseNode>> keyValuePair = canTravelToNodes.FirstOrDefault((KeyValuePair<UniverseNode, List<UniverseNode>> x) => x.Key.InternalID == nodeToClear.InternalID);
				if (keyValuePair.Value != null)
				{
					UniverseNode universeNode = keyValuePair.Key;
					foreach (UniverseNode item in keyValuePair.Value)
					{
						item.nodeObject.Refresh();
						if (universeNode != null)
						{
							if (item.parent == universeNode)
							{
								item.edgeToParent.edgeLine.GetComponent<Renderer>().material = NodeMaterialNormal;
								Color color = item.edgeToParent.edgeLine.GetComponent<Renderer>().material.color;
								color.a *= 0.95f;
								item.edgeToParent.edgeLine.GetComponent<Renderer>().material.color = color;
								((LineRenderer)item.edgeToParent.edgeLine.GetComponent<Renderer>()).SetWidth(1.5f, 1.5f);
							}
							else if (universeNode.parent == item)
							{
								universeNode.edgeToParent.edgeLine.GetComponent<Renderer>().material = NodeMaterialNormal;
								Color color2 = universeNode.edgeToParent.edgeLine.GetComponent<Renderer>().material.color;
								color2.a *= 0.95f;
								universeNode.edgeToParent.edgeLine.GetComponent<Renderer>().material.color = color2;
								((LineRenderer)universeNode.edgeToParent.edgeLine.GetComponent<Renderer>()).SetWidth(1.5f, 1.5f);
							}
						}
						universeNode = item;
					}
					keyValuePair.Key.nodeObject.Refresh();
				}
			}
		}
		highlightedTravelNode = null;
	}

	public void ClearPathToNode(UniverseNode destNode)
	{
		ClearPathToNode(destNode, true);
	}

	public void ClearPathToNode(UniverseNode destNode, bool snapbackHighlight)
	{
		ClearPathToNode(destNode, snapbackHighlight, false);
	}

	public void ClearPathToNode(UniverseNode destNode, bool snapbackHighlight, bool isMouseExitEvent)
	{
		if (!IsInTravelMode || destNode == null)
		{
			return;
		}
		KeyValuePair<UniverseNode, List<UniverseNode>> keyValuePair = canTravelToNodes.FirstOrDefault((KeyValuePair<UniverseNode, List<UniverseNode>> x) => x.Key.InternalID == destNode.InternalID);
		if (keyValuePair.Value != null)
		{
			UniverseNode universeNode = keyValuePair.Key;
			foreach (UniverseNode item in keyValuePair.Value)
			{
				if (item != selectedTravelNode)
				{
					item.nodeObject.Refresh();
				}
				if (universeNode != null)
				{
					if (item.parent == universeNode)
					{
						item.edgeToParent.edgeLine.GetComponent<Renderer>().material = NodeMaterialNormal;
						Color color = item.edgeToParent.edgeLine.GetComponent<Renderer>().material.color;
						color.a *= 0.95f;
						item.edgeToParent.edgeLine.GetComponent<Renderer>().material.color = color;
						((LineRenderer)item.edgeToParent.edgeLine.GetComponent<Renderer>()).SetWidth(1.5f, 1.5f);
					}
					else if (universeNode.parent == item)
					{
						universeNode.edgeToParent.edgeLine.GetComponent<Renderer>().material = NodeMaterialNormal;
						Color color2 = universeNode.edgeToParent.edgeLine.GetComponent<Renderer>().material.color;
						color2.a *= 0.95f;
						universeNode.edgeToParent.edgeLine.GetComponent<Renderer>().material.color = color2;
						((LineRenderer)universeNode.edgeToParent.edgeLine.GetComponent<Renderer>()).SetWidth(1.5f, 1.5f);
					}
				}
				universeNode = item;
			}
			if (keyValuePair.Key != selectedTravelNode)
			{
				keyValuePair.Key.nodeObject.Refresh();
			}
		}
		if (snapbackHighlight)
		{
			if (!isMouseExitEvent && selectedTravelNode == destNode)
			{
				selectedTravelNode = CurrentUniverseNode;
			}
			else
			{
				HighlightPathToNode(selectedTravelNode);
				selectedTravelNode.gameObject.transform.localScale = selectedTravelNode.nodeObject.initialScale * 4f;
				selectedTravelNode.nodeObject.Refresh();
			}
			SystemOverlayUI.Instance.SetStargateTravelAbility(selectedTravelNode != CurrentUniverseNode);
		}
		highlightedTravelNode = null;
	}

	public void SelectNode(UniverseNode destNode)
	{
		ClearHighlightedPath();
		selectedTravelNode.nodeObject.Refresh();
		ClearPathToNode(selectedTravelNode);
		selectedTravelNode = destNode;
		HighlightPathToNode(selectedTravelNode);
		SystemOverlayUI.Instance.SetStargateTravelAbility(selectedTravelNode != CurrentUniverseNode);
		if (destNode.InternalID != CurrentUniverseNode.InternalID)
		{
			selectedTravelNode.gameObject.transform.localScale = selectedTravelNode.nodeObject.initialScale * 4f;
			if (selectedTravelNode.nodeObject.transform.localScale.x == 20f)
			{
				selectedTravelNode.nodeObject.keyUI.gameObject.transform.localScale = new Vector3(0.0125f, 0.0125f, 0.0125f);
			}
			else if (selectedTravelNode.nodeObject.transform.localScale.x == 10f)
			{
				selectedTravelNode.nodeObject.keyUI.gameObject.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
			}
			else
			{
				selectedTravelNode.nodeObject.keyUI.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
			}
		}
		else
		{
			selectedTravelNode.nodeObject.Refresh();
		}
	}

	public void DeselectNode()
	{
		SelectNode(CurrentUniverseNode);
	}

	public void JumpToHighlightedNode(UniverseNode destNode)
	{
		if (!IsInTravelMode || destNode == CurrentUniverseNode)
		{
			return;
		}
		if (conditionalCurrentNode != null)
		{
			conditionalCurrentNode.IsVisitedConditional = false;
			conditionalCurrentNode.IsVisited = true;
		}
		if (conditionalOtherNode != null)
		{
			if (conditionalOtherNode != destNode)
			{
				KeyValuePair<UniverseNode, List<UniverseNode>> keyValuePair = canTravelToNodes.FirstOrDefault((KeyValuePair<UniverseNode, List<UniverseNode>> x) => x.Key != null && x.Key.InternalID == conditionalOtherNode.InternalID);
				if (keyValuePair.Value != null && keyValuePair.Value.FirstOrDefault((UniverseNode x) => x != null && x.InternalID == conditionalOtherNode.InternalID) != null && !conditionalOtherNode.IsVisited)
				{
					conditionalOtherNode.IsVisited = true;
					int num = GameSaveFile.Get("ST_CUR_GAL_VISITED", 0) + 1;
					GameSaveFile.Save("ST_CUR_GAL_VISITED", num);
					GameSaveFile.Save("ST_TTL_GAL_VISITED", GameSaveFile.Get("ST_TTL_GAL_VISITED", 0) + 1);
					if (num > GameSaveFile.Get("ST_BST_GAL_VISITED", 0))
					{
						GameSaveFile.Save("ST_BST_GAL_VISITED", num);
					}
				}
			}
			else if (!conditionalOtherNode.IsVisited)
			{
				conditionalOtherNode.IsVisited = true;
				int num2 = GameSaveFile.Get("ST_CUR_GAL_VISITED", 0) + 1;
				GameSaveFile.Save("ST_CUR_GAL_VISITED", num2);
				GameSaveFile.Save("ST_TTL_GAL_VISITED", GameSaveFile.Get("ST_TTL_GAL_VISITED", 0) + 1);
				if (num2 > GameSaveFile.Get("ST_BST_GAL_VISITED", 0))
				{
					GameSaveFile.Save("ST_BST_GAL_VISITED", num2);
				}
			}
			conditionalOtherNode.IsVisitedConditional = false;
		}
		conditionalCurrentNode = null;
		conditionalOtherNode = null;
		KeyValuePair<UniverseNode, List<UniverseNode>> keyValuePair2 = canTravelToNodes.FirstOrDefault((KeyValuePair<UniverseNode, List<UniverseNode>> x) => x.Key.InternalID == destNode.InternalID);
		BeginTakeSnapshotThenJump(keyValuePair2.Value[0], keyValuePair2.Key);
	}

	private void BeginTakeSnapshotThenJump(UniverseNode startNode, UniverseNode endNode)
	{
		IsInSnapshotMode = true;
		GalaxyMapManager.Instance.mainCamera.enabled = false;
		selectionIcon.SetActive(false);
		if (constellationGroupingList != null)
		{
			foreach (BoxLineRenderStruct constellationGrouping in constellationGroupingList)
			{
				constellationGrouping.topLine.GetComponent<Renderer>().enabled = false;
				constellationGrouping.bottomLine.GetComponent<Renderer>().enabled = false;
				constellationGrouping.leftLine.GetComponent<Renderer>().enabled = false;
				constellationGrouping.rightLine.GetComponent<Renderer>().enabled = false;
				constellationGrouping.textMesh.GetComponent<Renderer>().enabled = false;
			}
		}
		CenterCamera(true);
		ClearHighlightedPath();
		snapStartNode = startNode;
		snapEndNode = endNode;
	}

	private void EndTakeSnapshotThenJump()
	{
		IsInSnapshotMode = false;
		isInSnapshotModeFirstPass = false;
		GalaxyMapManager.Instance.mainCamera.enabled = true;
		BeginJumpToGalaxy(snapStartNode, snapEndNode);
		HighlightPathToNode(snapEndNode, true);
		EndTravelMode();
		snapStartNode = null;
		snapEndNode = null;
	}

	public void BuildListOfUniverseNodes()
	{
		for (int i = 0; i < NumberOfGalaxyNodes; i++)
		{
			UniverseNode universeNode = new UniverseNode();
			universeNode.name = NameGenerator.NextGalaxyName();
			universeNode.numberOfShort = UnityEngine.Random.Range(1, maxShortConnections + 1);
			UniverseNode universeNode2 = universeNode;
			GenerateNodeID(universeNode2);
			if (universeNode2.numberOfShort > 1 && UnityEngine.Random.Range(0f, 1f) <= (float)universeNode2.numberOfShort / (float)maxShortConnections && UnityEngine.Random.Range(0, reduceLongConnectionsFactor) == 0)
			{
				universeNode2.numberOfLong = UnityEngine.Random.Range(0, maxLongConnections + 1);
			}
			galaxyNodeList.Add(universeNode2);
		}
	}

	public Rect GetExtent()
	{
		return GetExtent(null);
	}

	public Rect GetExtent(UniverseConstelation constellation)
	{
		float num = float.MaxValue;
		float num2 = float.MinValue;
		float num3 = float.MaxValue;
		float num4 = float.MinValue;
		foreach (UniverseNode placedNode in placedNodes)
		{
			if (placedNode.IsVisible && (constellation == null || placedNode.constellation == constellation))
			{
				if (placedNode.pos.x < num)
				{
					num = placedNode.pos.x;
				}
				if (placedNode.pos.x > num2)
				{
					num2 = placedNode.pos.x;
				}
				if (placedNode.pos.y < num3)
				{
					num3 = placedNode.pos.y;
				}
				if (placedNode.pos.y > num4)
				{
					num4 = placedNode.pos.y;
				}
			}
		}
		return new Rect(num, num3, Mathf.Abs(num2 - num), Mathf.Abs(num4 - num3));
	}

	public void Show()
	{
		RefreshConstelation();
		if (CurrentUniverseNode.gameObject != null)
		{
			selectionIcon.SetActive(true);
			selectedViewNode = CurrentUniverseNode;
			Vector3 position = selectedViewNode.gameObject.transform.position;
			position.z = selectionIcon.transform.position.z;
			selectionIcon.transform.position = position;
			selectedViewNode.nodeObject.HideShortcut();
		}
		CenterCamera();
	}

	public void EnableAllEdges()
	{
		UniverseNode.usedKeys = new List<KeyCode>(GalaxyMapManager.Instance.invalidDungeonKeys);
		foreach (UniverseNode placedNode in placedNodes)
		{
			if (placedNode.edgeToParent != null)
			{
				placedNode.edgeToParent.IsEnabled = true;
				placedNode.Show();
			}
		}
	}

	public void Hide()
	{
		if (cameraOrigPos != Vector3.zero)
		{
			GalaxyMapManager.Instance.mainCamera.transform.position = cameraOrigPos;
		}
		if (cameraOrigSize != 0f)
		{
			GalaxyMapManager.Instance.mainCamera.orthographicSize = cameraOrigSize;
		}
		foreach (UniverseNode placedNode in placedNodes)
		{
			placedNode.Hide();
			if (placedNode.nodeObject != null)
			{
				UniverseNodeObject nodeObject = placedNode.nodeObject;
				nodeObject.shortcutPressed = (UniverseNodeObject.KeyPressedDelegate)Delegate.Remove(nodeObject.shortcutPressed, new UniverseNodeObject.KeyPressedDelegate(GalaxyKeyPressed));
			}
		}
		selectionIcon.SetActive(false);
		IsInTravelMode = false;
	}

	private void ShowAllActiveConstelations()
	{
		UniverseNode.usedKeys = new List<KeyCode>(GalaxyMapManager.Instance.invalidDungeonKeys);
		foreach (UniverseNode placedNode in placedNodes)
		{
			placedNode.Show();
		}
	}

	private void SelectConstelation(UniverseConstelation constelation)
	{
		CurrentConstelation = constelation;
		RefreshConstelation();
		ConstelationButtonPressed();
	}

	private void RefreshConstelation()
	{
		UniverseNode.usedKeys = new List<KeyCode>(GalaxyMapManager.Instance.invalidDungeonKeys);
		if (!IsInTravelMode || mergeConstellation == null)
		{
			if (CurrentConstelation != null)
			{
				foreach (UniverseNode placedNode in placedNodes)
				{
					if (placedNode.constellation == CurrentConstelation || (IsInTravelMode && placedNode.constelationTemp == CurrentConstelation))
					{
						placedNode.Show();
						UniverseNodeObject nodeObject = placedNode.nodeObject;
						nodeObject.shortcutPressed = (UniverseNodeObject.KeyPressedDelegate)Delegate.Remove(nodeObject.shortcutPressed, new UniverseNodeObject.KeyPressedDelegate(GalaxyKeyPressed));
						UniverseNodeObject nodeObject2 = placedNode.nodeObject;
						nodeObject2.shortcutPressed = (UniverseNodeObject.KeyPressedDelegate)Delegate.Combine(nodeObject2.shortcutPressed, new UniverseNodeObject.KeyPressedDelegate(GalaxyKeyPressed));
					}
					else
					{
						placedNode.Hide();
					}
				}
				HasData = true;
				if (constelationList != null)
				{
					selectedConstelationIndex = constelationList.IndexOf(CurrentConstelation);
				}
			}
			else
			{
				foreach (UniverseNode placedNode2 in placedNodes)
				{
					if (placedNode2.nodeObject != null)
					{
						UniverseNodeObject nodeObject3 = placedNode2.nodeObject;
						nodeObject3.shortcutPressed = (UniverseNodeObject.KeyPressedDelegate)Delegate.Remove(nodeObject3.shortcutPressed, new UniverseNodeObject.KeyPressedDelegate(GalaxyKeyPressed));
						UniverseNodeObject nodeObject4 = placedNode2.nodeObject;
						nodeObject4.shortcutPressed = (UniverseNodeObject.KeyPressedDelegate)Delegate.Combine(nodeObject4.shortcutPressed, new UniverseNodeObject.KeyPressedDelegate(GalaxyKeyPressed));
					}
				}
			}
		}
		else
		{
			int num = 0;
			foreach (KeyValuePair<UniverseNode, List<UniverseNode>> canTravelToNode in canTravelToNodes)
			{
				canTravelToNode.Key.Show();
				if (num == 1)
				{
					HasData = true;
				}
				num++;
			}
			foreach (UniverseNode placedNode3 in placedNodes)
			{
				if (placedNode3.nodeObject != null)
				{
					UniverseNodeObject nodeObject5 = placedNode3.nodeObject;
					nodeObject5.shortcutPressed = (UniverseNodeObject.KeyPressedDelegate)Delegate.Remove(nodeObject5.shortcutPressed, new UniverseNodeObject.KeyPressedDelegate(GalaxyKeyPressed));
					UniverseNodeObject nodeObject6 = placedNode3.nodeObject;
					nodeObject6.shortcutPressed = (UniverseNodeObject.KeyPressedDelegate)Delegate.Combine(nodeObject6.shortcutPressed, new UniverseNodeObject.KeyPressedDelegate(GalaxyKeyPressed));
				}
			}
			if (gateNodes.Key != null)
			{
				gateNodes.Key.Show();
			}
			if (gateNodes.Value != null)
			{
				gateNodes.Value.Show();
			}
		}
		CenterCamera(true);
	}

	private void GalaxyKeyPressed(UniverseNode node)
	{
		if (IsInTravelMode)
		{
			MoveToNodeTravelMode(node);
		}
		else
		{
			MoveToNodeViewMode(node);
		}
	}

	private void ClearConstelation()
	{
		foreach (UniverseNode placedNode in placedNodes)
		{
			placedNode.Hide();
		}
		CurrentConstelation = null;
		CurrentConstelationThumbnail = null;
		HasData = false;
	}

	private void UpdateConstelationDataStates()
	{
		if (CurrentConstelation != null && CurrentUniverseNode != null)
		{
			UniverseSaveFile.Save(CurrentConstelation.GroupKey, "GX_LAST", string.Format("{0}", CurrentUniverseNode.name));
			List<string> allGroups = UniverseSaveFile.GetAllGroups("GX_", "P", CurrentConstelation.GroupKey);
			UniverseSaveFile.Save(CurrentConstelation.GroupKey, "GX_CT", allGroups.Count);
		}
	}

	public void Update()
	{
		if (initializeForWorkspace)
		{
			return;
		}
		if (isCameraMoving)
		{
			timerCameraMove -= Time.deltaTime;
		}
		if ((!isCameraMoving || timerCameraMove <= 0f) && !IsInTravelMode && isShowingConstellationSelectionPanel && constelationList != null && constelationList.Count > 0)
		{
			if (Input.GetButtonDown("Up"))
			{
				selectedConstelationIndex--;
				if (selectedConstelationIndex < 0)
				{
					selectedConstelationIndex = 0;
				}
			}
			else if (Input.GetButtonDown("Down"))
			{
				selectedConstelationIndex++;
				if (selectedConstelationIndex >= constelationList.Count)
				{
					selectedConstelationIndex = constelationList.Count - 1;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				if (selectedConstelationIndex >= 0 && selectedConstelationIndex < constelationList.Count)
				{
					SelectConstelation(constelationList[selectedConstelationIndex]);
				}
			}
			else if (isShowingConstellationSelectionPanel)
			{
				if (!isEditingConstellationProperties)
				{
					if (Input.GetKeyDown(KeyCode.Escape))
					{
						ConstelationButtonPressed();
					}
					else if (Input.GetKeyDown(KeyCode.E))
					{
						EditConstelationButtonPressed();
						ignoreKeyboardInputOnEditField = true;
						Input.ResetInputAxes();
					}
					else if (HighlightedConstelation != CurrentConstelation && Input.GetKeyDown(KeyCode.V))
					{
						SelectConstelation(constelationList[selectedConstelationIndex]);
					}
				}
				else if (Input.GetKeyDown(KeyCode.S))
				{
					SaveConstelationButtonPressed();
				}
				else if (ignoreKeyboardInputOnEditField && !Input.GetKey(KeyCode.E))
				{
					ignoreKeyboardInputOnEditField = false;
				}
			}
		}
		if (IsInTravelMode)
		{
			if (!IsInSnapshotMode)
			{
				if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
				{
					if (Input.GetButtonDown("Up"))
					{
						MoveTravelPosition(new Vector2(0f, 1f));
					}
					else if (Input.GetButtonDown("Down"))
					{
						MoveTravelPosition(new Vector2(0f, -1f));
					}
					else if (Input.GetButtonDown("Left"))
					{
						MoveTravelPosition(new Vector2(-1f, 0f));
					}
					else if (Input.GetButtonDown("Right"))
					{
						MoveTravelPosition(new Vector2(1f, 0f));
					}
					if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
					{
						if (selectedTravelNode.InternalID != CurrentUniverseNode.InternalID)
						{
							JumpToHighlightedNode(selectedTravelNode);
						}
					}
					else if (Input.GetKeyDown(KeyCode.T))
					{
						if (selectedTravelNode != CurrentUniverseNode)
						{
							JumpToHighlightedNode(selectedTravelNode);
						}
						else
						{
							CommonAudioHelper.Instance.PlayErrorSound();
						}
					}
				}
				delayNewNodeAlphaChangeStap -= Time.deltaTime;
				if (delayNewNodeAlphaChangeStap <= 0f)
				{
					newNodeAlpha += 0.1f * (float)newNodeAlphaDirection;
					if (newNodeAlphaDirection == -1 && newNodeAlpha <= 0.25f)
					{
						newNodeAlphaDirection = 1;
						newNodeAlpha = 0.5f;
					}
					else if (newNodeAlphaDirection == 1 && newNodeAlpha > 1f)
					{
						newNodeAlphaDirection = -1;
						newNodeAlpha = 1f;
					}
					if (HasData && conditionalCurrentNode != null)
					{
						Color color = conditionalCurrentNode.gameObject.GetComponent<Renderer>().material.color;
						color.a = newNodeAlpha;
						conditionalCurrentNode.gameObject.GetComponent<Renderer>().material.color = color;
						color = conditionalCurrentNode.nodeObject.keyUI.label.color;
						color.a = newNodeAlpha;
						conditionalCurrentNode.nodeObject.keyUI.label.color = color;
						UniverseNode.ConnectionEdge connectionEdge = null;
						if (conditionalCurrentNode.edgeToParent != null)
						{
							connectionEdge = conditionalCurrentNode.edgeToParent;
						}
						else if (conditionalCurrentNode.parent != null && conditionalCurrentNode.parent.edgeToParent != null)
						{
							connectionEdge = conditionalCurrentNode.parent.edgeToParent;
						}
						if (connectionEdge != null && connectionEdge.edgeLine != null)
						{
							color = ((!connectionEdge.edgeLine.GetComponent<Renderer>().material.HasProperty("color")) ? Color.white : connectionEdge.edgeLine.GetComponent<Renderer>().material.color);
							color.a = newNodeAlpha * 0.95f;
							connectionEdge.edgeLine.GetComponent<Renderer>().material.color = color;
						}
						else
						{
							List<UniverseNode> allChildrenNodes = conditionalCurrentNode.GetAllChildrenNodes();
							foreach (UniverseNode item in allChildrenNodes)
							{
								if (item.edgeToParent != null && item.edgeToParent.edgeLine != null)
								{
									color = ((!item.edgeToParent.edgeLine.GetComponent<Renderer>().material.HasProperty("color")) ? Color.white : item.edgeToParent.edgeLine.GetComponent<Renderer>().material.color);
									color.a = newNodeAlpha * 0.95f;
									item.edgeToParent.edgeLine.GetComponent<Renderer>().material.color = color;
								}
							}
						}
					}
					if (conditionalOtherNode != null)
					{
						Color color2 = conditionalOtherNode.gameObject.GetComponent<Renderer>().material.color;
						color2.a = newNodeAlpha;
						conditionalOtherNode.gameObject.GetComponent<Renderer>().material.color = color2;
						color2 = conditionalOtherNode.nodeObject.keyUI.label.color;
						color2.a = newNodeAlpha;
						conditionalOtherNode.nodeObject.keyUI.label.color = color2;
						UniverseNode.ConnectionEdge connectionEdge2 = null;
						if (conditionalOtherNode.edgeToParent != null && conditionalOtherNode.edgeToParent.EdgeConnectsToNode(CurrentUniverseNode))
						{
							connectionEdge2 = conditionalOtherNode.edgeToParent;
						}
						else if (conditionalOtherNode.parent != null && conditionalOtherNode.parent.edgeToParent != null && conditionalOtherNode.parent.edgeToParent.EdgeConnectsToNode(CurrentUniverseNode))
						{
							connectionEdge2 = conditionalOtherNode.parent.edgeToParent;
						}
						if (connectionEdge2 != null && connectionEdge2.edgeLine != null)
						{
							color2 = ((!connectionEdge2.edgeLine.GetComponent<Renderer>().material.HasProperty("color")) ? Color.white : connectionEdge2.edgeLine.GetComponent<Renderer>().material.color);
							color2.a = newNodeAlpha * 0.95f;
							connectionEdge2.edgeLine.GetComponent<Renderer>().material.color = color2;
						}
						else
						{
							List<UniverseNode> allChildrenNodes2 = conditionalOtherNode.GetAllChildrenNodes();
							foreach (UniverseNode item2 in allChildrenNodes2)
							{
								if (item2.edgeToParent != null && item2.edgeToParent.edgeLine != null)
								{
									color2 = ((!item2.edgeToParent.edgeLine.GetComponent<Renderer>().material.HasProperty("color")) ? Color.white : item2.edgeToParent.edgeLine.GetComponent<Renderer>().material.color);
									color2.a = newNodeAlpha * 0.95f;
									item2.edgeToParent.edgeLine.GetComponent<Renderer>().material.color = color2;
								}
							}
						}
					}
					if (conditionalCurrentNode == null && conditionalOtherNode == null)
					{
						if (gateNodes.Key != null && gateNodes.Key.edgeToParent != null && gateNodes.Key.edgeToParent.IsEnabledConditional)
						{
							Color white = Color.white;
							UniverseNode.ConnectionEdge edgeToParent = gateNodes.Key.edgeToParent;
							white = ((!edgeToParent.edgeLine.GetComponent<Renderer>().material.HasProperty("color")) ? Color.white : edgeToParent.edgeLine.GetComponent<Renderer>().material.color);
							white.a = newNodeAlpha * 0.95f;
							edgeToParent.edgeLine.GetComponent<Renderer>().material.color = white;
						}
						else if (gateNodes.Value != null && gateNodes.Value.edgeToParent != null && gateNodes.Value.edgeToParent.IsEnabledConditional)
						{
							Color white2 = Color.white;
							UniverseNode.ConnectionEdge edgeToParent2 = gateNodes.Value.edgeToParent;
							white2 = ((!edgeToParent2.edgeLine.GetComponent<Renderer>().material.HasProperty("color")) ? Color.white : edgeToParent2.edgeLine.GetComponent<Renderer>().material.color);
							white2.a = newNodeAlpha * 0.95f;
							edgeToParent2.edgeLine.GetComponent<Renderer>().material.color = white2;
						}
					}
					delayNewNodeAlphaChangeStap = 0.1f;
				}
			}
			else if (isInSnapshotModeFirstPass)
			{
				EndTakeSnapshotThenJump();
			}
		}
		else if (CurrentUniverseNode.gameObject != null)
		{
			if (PreViewStartingNode != null)
			{
				PreViewStartingNode.nodeObject.GetComponent<Renderer>().material.color = Color.red;
				PreViewStartingNode.nodeObject.keyUI.label.color = Color.red;
			}
			if (Input.GetButtonDown("Up"))
			{
				MoveViewPosition(new Vector2(0f, 1f));
			}
			else if (Input.GetButtonDown("Down"))
			{
				MoveViewPosition(new Vector2(0f, -1f));
			}
			else if (Input.GetButtonDown("Left"))
			{
				MoveViewPosition(new Vector2(-1f, 0f));
			}
			else if (Input.GetButtonDown("Right"))
			{
				MoveViewPosition(new Vector2(1f, 0f));
			}
			else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				AttemptViewGalaxy(true);
			}
		}
		if (Input.GetKeyDown(KeyCode.Home))
		{
			CenterCamera(true);
			return;
		}
		if (isCameraZooming)
		{
			timerCameraZoom -= Time.deltaTime;
		}
		if (isCameraZooming && !(timerCameraZoom <= 0f))
		{
			return;
		}
		bool flag = false;
		if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Equals))
		{
			if (GalaxyMapManager.Instance.mainCamera.orthographicSize > 100f)
			{
				GalaxyMapManager.Instance.mainCamera.orthographicSize -= 10f;
			}
			else
			{
				GalaxyMapManager.Instance.mainCamera.orthographicSize = 100f;
			}
			flag = true;
		}
		else if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
		{
			if (GalaxyMapManager.Instance.mainCamera.orthographicSize < 1000f)
			{
				GalaxyMapManager.Instance.mainCamera.orthographicSize += 10f;
			}
			else
			{
				GalaxyMapManager.Instance.mainCamera.orthographicSize = 1000f;
			}
			flag = true;
		}
		if (flag)
		{
			if (!isCameraZooming)
			{
				timerCameraZoom = 0.5f;
			}
			else
			{
				timerCameraZoom = 0.001f;
			}
			isCameraZooming = true;
		}
		else
		{
			isCameraZooming = false;
		}
	}

	public void AttemptViewGalaxy()
	{
		AttemptViewGalaxy(false);
	}

	public void AttemptViewGalaxy(bool ignoreErrorSound)
	{
		if (selectedViewNode != CurrentUniverseNode)
		{
			BeginJumpToGalaxy(CurrentUniverseNode, selectedViewNode, true);
		}
		else if (!ignoreErrorSound)
		{
			CommonAudioHelper.Instance.PlayErrorSound();
		}
	}

	private void MoveTravelPosition(Vector2 dirVec)
	{
		if (selectedTravelNode == null)
		{
			return;
		}
		List<UniverseNode> list = null;
		List<UniverseNode> allConnectionNodes = selectedTravelNode.GetAllConnectionNodes();
		IEnumerable<UniverseNode> enumerable = allConnectionNodes.Where((UniverseNode x) => x != null && (x.InternalID == CurrentUniverseNode.InternalID || canTravelToNodes.FirstOrDefault((KeyValuePair<UniverseNode, List<UniverseNode>> y) => y.Key.InternalID == x.InternalID).Key != null));
		if (enumerable != null)
		{
			list = enumerable.ToList();
		}
		UniverseNode universeNode = null;
		Vector2 vector = Vector2.zero;
		foreach (UniverseNode item in list)
		{
			bool flag = false;
			Vector2 vector2 = item.gameObject.transform.position - selectedTravelNode.gameObject.transform.position;
			vector2.Normalize();
			if (dirVec.x == -1f && vector2.x < 0f && vector2.x < vector.x)
			{
				flag = true;
			}
			if (dirVec.x == 1f && vector2.x > 0f && vector2.x > vector.x)
			{
				flag = true;
			}
			if (dirVec.y == 1f && vector2.y > 0f && vector2.y > vector.y)
			{
				flag = true;
			}
			if (dirVec.y == -1f && vector2.y < 0f && vector2.y < vector.y)
			{
				flag = true;
			}
			if (flag)
			{
				universeNode = item;
				vector = vector2;
			}
		}
		if (universeNode != null)
		{
			MoveToNodeTravelMode(universeNode);
		}
	}

	private void MoveViewPosition(Vector2 dirVec)
	{
		if (selectedViewNode == null)
		{
			return;
		}
		List<UniverseNode> list = null;
		List<UniverseNode> allConnectionNodes = selectedViewNode.GetAllConnectionNodes();
		list = allConnectionNodes;
		UniverseNode universeNode = null;
		Vector2 vector = Vector2.zero;
		foreach (UniverseNode item in list)
		{
			if (item.gameObject != null)
			{
				bool flag = false;
				Vector2 vector2 = item.gameObject.transform.position - selectedViewNode.gameObject.transform.position;
				vector2.Normalize();
				if (dirVec.x == -1f && vector2.x < 0f && vector2.x < vector.x)
				{
					flag = true;
				}
				if (dirVec.x == 1f && vector2.x > 0f && vector2.x > vector.x)
				{
					flag = true;
				}
				if (dirVec.y == 1f && vector2.y > 0f && vector2.y > vector.y)
				{
					flag = true;
				}
				if (dirVec.y == -1f && vector2.y < 0f && vector2.y < vector.y)
				{
					flag = true;
				}
				if (flag)
				{
					universeNode = item;
					vector = vector2;
				}
			}
		}
		if (universeNode != null)
		{
			MoveToNodeViewMode(universeNode);
		}
	}

	private void MoveToNodeTravelMode(UniverseNode node)
	{
		selectedTravelNode.nodeObject.Refresh();
		ClearPathToNode(selectedTravelNode);
		node.gameObject.transform.localScale = node.nodeObject.initialScale * 2f;
		SelectNode(node);
		node.nodeObject.HideShortcut();
		GameAudio.Play2DSFX(GameAudio.SoundEnum.GalaxySelectNode);
	}

	private void MoveToNodeViewMode(UniverseNode node)
	{
		selectedViewNode.nodeObject.Refresh();
		selectedViewNode = node;
		node.gameObject.transform.localScale = node.nodeObject.initialScale * 2f;
		Vector3 position = node.gameObject.transform.position;
		position.z = selectionIcon.transform.position.z;
		selectionIcon.transform.position = position;
		node.nodeObject.HideShortcut();
		SystemOverlayUI.Instance.SetStargateTravelAbility(selectedViewNode != CurrentUniverseNode);
		GameAudio.Play2DSFX(GameAudio.SoundEnum.GalaxySelectNode);
	}

	public void Draw()
	{
		if (IsInTravelMode)
		{
			if (IsInSnapshotMode)
			{
				if (!isInSnapshotModeFirstPass)
				{
					RenderTexture.active = null;
				}
				isInSnapshotModeFirstPass = true;
			}
		}
		else if (constelationList != null && constelationList.Count > 0)
		{
			Vector2 vector = new Vector2(0f, 0f);
			constelationToggleButtonRect.x = (float)(-(Screen.height / 2)) - constelationToggleButtonRect.width / 2f;
			constelationToggleButtonRect.y = 0f;
			if (isShowingConstellationSelectionPanel)
			{
				constelationWindowRect.height = (float)Screen.height - constelationWindowRect.y * 2f;
				Rect viewRect = constelationWindowRect;
				viewRect.x += 2f;
				viewRect.y += 10f;
				viewRect.width -= 4f;
				viewRect.height -= 12f;
				GUI.BeginScrollView(constelationWindowRect, new Vector2(0f, 10f), viewRect);
				Rect rect = constelationWindowRect;
				rect.x += 2f;
				rect.y += 2f;
				rect.width -= 4f;
				rect.height -= 4f;
				Rect position = new Rect(viewRect.x + 4f, viewRect.y + 2f, viewRect.width - 8f, 20f);
				bool flag = false;
				bool flag2 = false;
				if (!isEditingConstellationProperties)
				{
					if (Event.current.type == EventType.MouseDown)
					{
						flag = true;
					}
					else if (Event.current.type == EventType.MouseUp)
					{
						flag2 = true;
					}
					if (flag && flag2)
					{
						flag = false;
					}
				}
				int num = 0;
				if (isEditingConstellationProperties)
				{
					GUI.enabled = false;
				}
				int count = constelationList.Count;
				for (int i = 0; i < count; i++)
				{
					UniverseConstelation universeConstelation = constelationList[i];
					if (!isEditingConstellationProperties && !flag && !flag2 && position.Contains(Event.current.mousePosition))
					{
						selectedConstelationIndex = num;
					}
					if (selectedConstelationIndex == num && HighlightedConstelation != universeConstelation)
					{
						HighlightedConstelation = universeConstelation;
						CurrentConstelationThumbnail = null;
					}
					if (CurrentConstelation != null && CurrentConstelation == universeConstelation)
					{
						GUI.color = Color.yellow;
					}
					else if (selectedConstelationIndex == num)
					{
						GUI.color = Color.white;
					}
					else
					{
						GUI.color = Color.gray;
					}
					if (GUI.Button(position, universeConstelation.name))
					{
						SelectConstelation(universeConstelation);
					}
					position.y += 20f;
					num++;
				}
				if (isEditingConstellationProperties)
				{
					GUI.enabled = true;
				}
				GUI.color = Color.white;
				GUI.EndScrollView();
			}
		}
		if (IsInSnapshotMode)
		{
		}
	}

	private void ConstelationButtonPressed()
	{
		isShowingConstellationSelectionPanel = !isShowingConstellationSelectionPanel;
		if (isShowingConstellationSelectionPanel)
		{
			selectedConstelationIndex = constelationList.IndexOf(CurrentConstelation);
		}
		else
		{
			SystemOverlayUI.Instance.RefreshGalaxyInfo();
		}
		SystemOverlayUI.Instance.RefreshUniverseInfo();
	}

	private void EditConstelationButtonPressed()
	{
		isEditingConstellationProperties = !isEditingConstellationProperties;
		if (isEditingConstellationProperties)
		{
			editTextConstellation = HighlightedConstelation.name;
		}
	}

	private void SaveConstelationButtonPressed()
	{
		isEditingConstellationProperties = false;
		if (!string.IsNullOrEmpty(editTextConstellation))
		{
			HighlightedConstelation.name = editTextConstellation;
		}
		SystemOverlayUI.Instance.RefreshGalaxyInfo();
	}

	private void CancelConstelationButtonPressed()
	{
		isEditingConstellationProperties = false;
	}

	public void Clear()
	{
		foreach (UniverseNode placedNode in placedNodes)
		{
			placedNode.DestroyObjects();
		}
		placedNodes.Clear();
		lastPlacedNodes.Clear();
		galaxyNodeList.Clear();
	}

	public void GenerateUniverseDataNodes()
	{
		int seed = UnityEngine.Random.seed;
		int num = -1;
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			num = UniverseSaveFile.Get("UNIVERSE_SEED", -1);
		}
		else if (GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge)
		{
			num = GameSaveFile.Get("CH_WKLY_SEED", -1);
		}
		else if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
		{
			num = GameSaveFile.Get("CH_DLY_SEED", -1);
		}
		UniverseSaveFile.Save("UNIVERSE_SEED", num);
		if (num == -1)
		{
			num = (int)DateTime.Now.Ticks;
			UniverseSaveFile.Save("UNIVERSE_SEED", num);
			int value = GameSaveFile.Get("ST_TTL_UN_VISITED", 0) + 1;
			GameSaveFile.Save("ST_TTL_UN_VISITED", value);
		}
		if (GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge)
		{
			GameSaveFile.Save("CH_WKLY_SEED", num);
		}
		else if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
		{
			GameSaveFile.Save("CH_DLY_SEED", num);
		}
		UnityEngine.Random.seed = num;
		if (GameSaveFile.Get("GAME_VER", 0f) > 0.302f)
		{
			do
			{
				SeedFleet = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			}
			while (SeedFleet == -1);
		}
		NameGenerator.ShuffleSystemNames();
		NameGenerator.ShuffleGalaxyNames();
		NameGenerator.ShuffleDerelictNames();
		NameGenerator.ShuffleOutpostNames();
		BuildListOfUniverseNodes();
		BuildFirstLayer(0f);
		BuildAllRemainingLayers();
		AssignGalaxyMapsToNodes();
	}

	private void AssignGalaxyMapsToNodes()
	{
		if (GameSaveFile.Get("GAME_VER", 0.25f) > 0.25f)
		{
			guarenteeEasyGalaxies = UniverseSaveFile.Get("ESY_GLXY", false);
			if (!guarenteeEasyGalaxies)
			{
				guarenteeEasyGalaxies = !GameSaveFile.Get("NC", false);
			}
			UniverseSaveFile.Save("ESY_GLXY", guarenteeEasyGalaxies);
		}
		List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		List<KeyValuePair<string, int>> list2 = new List<KeyValuePair<string, int>>();
		List<string> listOfGalaxyFolders = GalaxySaveFile.GetListOfGalaxyFolders(guarenteeEasyGalaxies);
		int count = listOfGalaxyFolders.Count;
		for (int i = 0; i < count; i++)
		{
			string text = listOfGalaxyFolders[i];
			if (i > 0)
			{
				GalaxyProcessor.DeinitalizeGalaxy(listOfGalaxyFolders[i - 1]);
			}
			GalaxyProcessor.InitalizeGalaxy(text);
			int countSystems = 0;
			List<StarSystemInfo> list3 = GalaxyProcessor.BuildStarSystems(-1, true, out countSystems);
			list2.Add(new KeyValuePair<string, int>(text, countSystems));
		}
		GalaxyProcessor.DeinitalizeGalaxy(listOfGalaxyFolders[count - 1]);
		List<KeyValuePair<UniverseNode, string>> list4 = new List<KeyValuePair<UniverseNode, string>>();
		int num = 0;
		if (guarenteeEasyGalaxies)
		{
			easyGalaxyList = new List<string>();
			easyGalaxyList.Add("Galaxy 13_sm");
			easyGalaxyList.Add("Galaxy 13_sm_f");
			easyGalaxyList.Add("Galaxy14_sm");
			easyGalaxyList.Add("Galaxy14_sm_f");
			easyGalaxyList.Add("Galaxy 15_sm");
			easyGalaxyList.Add("Galaxy 15_sm_f");
			easyGalaxyList.Add("Galaxy 16_sm");
			easyGalaxyList.Add("Galaxy 16_sm_f");
		}
		foreach (UniverseNode placedNode in placedNodes)
		{
			int sizeNeeded = placedNode.CountNodes + 1;
			IEnumerable<KeyValuePair<string, int>> enumerable = list2.Where((KeyValuePair<string, int> x) => x.Value >= sizeNeeded);
			if (enumerable != null && list2.Count() > 0)
			{
				List<KeyValuePair<string, int>> list5 = enumerable.ToList();
				int index = -1;
				if (guarenteeEasyGalaxies && num < 3)
				{
					int index2 = UnityEngine.Random.Range(0, easyGalaxyList.Count);
					string text2 = easyGalaxyList[index2];
					easyGalaxyList.RemoveAt(index2);
					int count2 = listOfGalaxyFolders.Count;
					for (int num2 = 0; num2 < count2; num2++)
					{
						if (listOfGalaxyFolders[num2] == text2)
						{
							index = num2;
							break;
						}
					}
					num++;
				}
				else
				{
					bool flag = true;
					do
					{
						flag = true;
						index = UnityEngine.Random.Range(0, listOfGalaxyFolders.Count);
						if (guarenteeEasyGalaxies && easyGalaxyList.Contains(listOfGalaxyFolders[index]))
						{
							flag = false;
						}
					}
					while (!flag);
				}
				string galaxyFolder = listOfGalaxyFolders[index];
				listOfGalaxyFolders.RemoveAt(index);
				list4.Add(new KeyValuePair<UniverseNode, string>(placedNode, galaxyFolder));
				KeyValuePair<string, int> item = list2.First((KeyValuePair<string, int> x) => x.Key == galaxyFolder);
				list.Add(new KeyValuePair<string, int>(placedNode.GroupKey, item.Value));
				list2.Remove(item);
				continue;
			}
			Debug.LogWarning("Entered a section of code that should only be triggered if, out of whatever galaxies remain, can't find one with enough systems for the number of stargates for this node, and going to try to fix by doing some swap magic.  This message is because I've never gotten the code to actually NEED this section of code - hopefully it won't crash ;)");
			KeyValuePair<string, int> keyValuePair = list2.OrderByDescending((KeyValuePair<string, int> x) => x).FirstOrDefault();
			List<KeyValuePair<UniverseNode, string>>.Enumerator enumerator2 = list4.GetEnumerator();
			bool flag2 = false;
			int num3 = 0;
			while (enumerator2.MoveNext())
			{
				List<KeyValuePair<string, int>>.Enumerator enumerator3 = list2.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					if (enumerator3.Current.Key == enumerator2.Current.Value)
					{
						if (enumerator3.Current.Value >= sizeNeeded && enumerator2.Current.Key.CountNodes >= keyValuePair.Value)
						{
							string value = enumerator2.Current.Value;
							string key = keyValuePair.Key;
							UniverseNode key2 = list4[num3].Key;
							list4.RemoveAt(num3);
							list4.Add(new KeyValuePair<UniverseNode, string>(placedNode, value));
							list4.Add(new KeyValuePair<UniverseNode, string>(key2, key));
						}
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					break;
				}
				num3++;
			}
			if (flag2)
			{
				int num4 = 0;
				num4++;
			}
			else
			{
				int num5 = 0;
				num5++;
			}
		}
		List<KeyValuePair<string, int>>.Enumerator enumerator4 = list.GetEnumerator();
		while (enumerator4.MoveNext())
		{
			Debug.Log(string.Format("***** Galaxy: {0}, Size: {1} (+1 for room for nursery)", enumerator4.Current.Key, enumerator4.Current.Value));
		}
		List<KeyValuePair<UniverseNode, string>>.Enumerator assignedListEnumerator2 = list4.GetEnumerator();
		while (assignedListEnumerator2.MoveNext())
		{
			UniverseNode universeNode = placedNodes.FirstOrDefault((UniverseNode x) => x.InternalID == assignedListEnumerator2.Current.Key.InternalID);
			UniverseSaveFile.Save(universeNode.GroupKey, "FILE", string.Format("gd_{0}", universeNode.InternalID));
			UniverseSaveFile.Save(universeNode.GroupKey, "NAME", assignedListEnumerator2.Current.Value);
			GalaxySaveFile.InitSetting(universeNode.InternalID);
			GalaxySaveFile.Save("DATA", assignedListEnumerator2.Current.Value);
		}
	}

	private string AssignGalaxyMapToNode(UniverseNode node)
	{
		string text = GalaxySaveFile.Get("DATA", string.Empty);
		if (string.IsNullOrEmpty(text))
		{
			List<string> listOfGalaxyFolders = GalaxySaveFile.GetListOfGalaxyFolders(guarenteeEasyGalaxies);
			List<string> list = new List<string>();
			List<string> allGroups = UniverseSaveFile.GetAllGroups("GX_");
			foreach (string item in allGroups)
			{
				string[] array = item.Split('_');
				int result = 0;
				if (array.Length == 2 && int.TryParse(array[1], out result))
				{
					GalaxySaveFile.InitSetting(result);
					string text2 = GalaxySaveFile.Get("DATA", string.Empty);
					if (!string.IsNullOrEmpty(text2) && !list.Contains(text2) && listOfGalaxyFolders.Contains(text2))
					{
						list.Add(text2);
					}
				}
			}
			GalaxySaveFile.InitSetting(node.InternalID);
			if (listOfGalaxyFolders.Count > 0)
			{
				int num = 0;
				int num2 = 0;
				int num3 = listOfGalaxyFolders.Count * 2;
				bool flag = false;
				bool flag2 = false;
				string text3 = string.Empty;
				while (true)
				{
					num = UnityEngine.Random.Range(0, listOfGalaxyFolders.Count);
					num2++;
					if (num2 < num3 && list.Count < listOfGalaxyFolders.Count && list.Contains(listOfGalaxyFolders[num]))
					{
						continue;
					}
					if (num2 >= num3)
					{
						if (!flag2)
						{
							Debug.LogWarning(string.Format("We failed to find a unique (not used) galaxy after {0} attempts.  The current galaxy ({1}) has been used before in this universe!", num2, listOfGalaxyFolders[num]));
						}
						else
						{
							Debug.LogWarning(string.Format("We found at least 1 unique (not used) galaxy, but none had enough systems to hold the {2} number of stargates needed after {0} attempts.  The current galaxy ({1}) has been used before in this universe!", num2, listOfGalaxyFolders[num], node.CountNodes));
						}
					}
					else
					{
						int countSystems = 0;
						if (text3 != string.Empty)
						{
							GalaxyProcessor.DeinitalizeGalaxy(text3);
						}
						GalaxyProcessor.InitalizeGalaxy(listOfGalaxyFolders[num]);
						text3 = listOfGalaxyFolders[num];
						List<StarSystemInfo> list2 = GalaxyProcessor.BuildStarSystems(-1, true, out countSystems);
						if (countSystems < node.CountNodes)
						{
							Debug.Log(string.Format("Not enough systems in galaxy '{0}' - needed {1} but only have {2}.  Attempting another galaxy. - node id: {3}", listOfGalaxyFolders[num], node.CountNodes, countSystems, node.GroupKey));
							flag2 = true;
						}
						else
						{
							Debug.Log(string.Format("**** Estimated Systems: {0}, Number of Nodes: {1} - node id: {2}", countSystems, node.CountNodes, node.GroupKey));
							flag = true;
						}
					}
					if (num2 >= num3 || flag)
					{
						break;
					}
				}
				GalaxySaveFile.Save("DATA", listOfGalaxyFolders[num]);
				if (text3 != string.Empty)
				{
					GalaxyProcessor.DeinitalizeGalaxy(text3);
				}
				return listOfGalaxyFolders[num];
			}
			Debug.LogError("The system does not have any installed Galaxy maps!");
			return string.Empty;
		}
		return text;
	}

	public void GenerateUniverse()
	{
		GenerateUniverseDataNodes();
		Hide();
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
		}
		if (initializeForWorkspace)
		{
			return;
		}
		List<string> allGroups = UniverseSaveFile.GetAllGroups("CNSTLN_");
		foreach (string item in allGroups)
		{
			string[] array = item.Split('_');
			if (array.Length == 2)
			{
				int result = 0;
				if (int.TryParse(array[1], out result))
				{
					UniverseConstelation universeConstelation = new UniverseConstelation();
					universeConstelation.InternalID = result;
					AddConstelation(universeConstelation);
				}
			}
		}
		List<string> allGroups2 = UniverseSaveFile.GetAllGroups("GX_", "VISITED", true);
		foreach (string item2 in allGroups2)
		{
			string[] array2 = item2.Split('_');
			if (array2.Length != 2)
			{
				continue;
			}
			int internalID = 0;
			int.TryParse(array2[1], out internalID);
			UniverseNode universeNode = placedNodes.FirstOrDefault((UniverseNode x) => x != null && x.InternalID == internalID);
			if (universeNode == null)
			{
				continue;
			}
			universeNode.IsVisited = true;
			if (constelationList == null || constelationList.Count <= 0)
			{
				continue;
			}
			string constelationGroupKey = UniverseSaveFile.Get(universeNode.GroupKey, "P", string.Empty);
			if (!string.IsNullOrEmpty(constelationGroupKey))
			{
				UniverseConstelation universeConstelation2 = constelationList.FirstOrDefault((UniverseConstelation x) => x != null && x.GroupKey == constelationGroupKey);
				if (universeConstelation2 != null)
				{
					universeNode.constellation = universeConstelation2;
				}
			}
		}
	}

	public void BuildFirstLayer(float zPos)
	{
		galaxyNodeList[0].pos = new Vector3(0f, 0f, zPos);
		if (StartingNodePlaced != null)
		{
			StartingNodePlaced(galaxyNodeList[0]);
		}
		lastPlacedNodes.Add(galaxyNodeList[0]);
		placedNodes.Add(galaxyNodeList[0]);
		if (!initializeForWorkspace)
		{
			galaxyNodeList[0].Hide();
		}
		else
		{
			galaxyNodeList[0].IsEnabled = true;
		}
		galaxyNodeList.RemoveAt(0);
	}

	public void BuildAllRemainingLayers()
	{
		do
		{
			List<UniverseNode> list = BuildNextLayer();
			lastPlacedNodes.Clear();
			lastPlacedNodes.AddRange(list);
			list.Clear();
		}
		while (galaxyNodeList.Count > 0 && lastPlacedNodes.Count > 0);
	}

	private string AuditNode(UniverseNode node, int depth, List<UniverseNode> traveledNodes)
	{
		if (traveledNodes.Contains(node))
		{
			return string.Empty;
		}
		string empty = string.Empty;
		traveledNodes.Add(node);
		empty += string.Format("{0}{1}({2}): {3} children\r\n", string.Empty.PadLeft(depth, '-'), node.name, node.InternalID, node.CountChildrenNodes);
		List<UniverseNode> allChildrenNodes = node.GetAllChildrenNodes();
		foreach (UniverseNode item in allChildrenNodes)
		{
			empty = (traveledNodes.Contains(item) ? (empty + string.Format("{0}{1}({2}) (already audited)\r\n", string.Empty.PadLeft(depth + 1, '-'), item.name, item.InternalID)) : (empty + AuditNode(item, depth + 1, traveledNodes)));
		}
		return empty;
	}

	public List<UniverseNode> BuildNextLayer()
	{
		List<UniverseNode> tempLastPlacedNodes = new List<UniverseNode>();
		int count = lastPlacedNodes.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			UniverseNode nextNode = lastPlacedNodes[num];
			lastPlacedNodes.RemoveAt(num);
			if (BreakDownDepth > 0 && nextNode.Depth > BreakDownDepth && UnityEngine.Random.Range(0, BreakDownChanceOf) == 0)
			{
				if (TerminatingNodePlaced != null)
				{
					TerminatingNodePlaced(nextNode);
				}
			}
			else
			{
				bool flag = true;
				float num2 = 0f;
				Vector3 zero = Vector3.zero;
				if (nextNode.parent != null)
				{
					Vector3 vector = nextNode.pos - nextNode.parent.pos;
					flag = false;
					num2 = 360 / (nextNode.NumberOfFreeShortConnections + nextNode.NumberOfFreeLongConnections + 1 + biasFactor);
					zero = vector;
					if (nextNode.NumberOfFreeShortConnections + nextNode.NumberOfFreeLongConnections > 2)
					{
						float angle = (0f - num2) * (float)((nextNode.NumberOfFreeShortConnections + nextNode.NumberOfFreeLongConnections) / 2);
						zero = zero.RotateZ(angle);
					}
				}
				else
				{
					float x = UnityEngine.Random.Range(-1f, 1f);
					float y = UnityEngine.Random.Range(-1f, 1f);
					zero = new Vector3(x, y, 0f);
					flag = false;
					num2 = 360f / (float)(nextNode.NumberOfFreeShortConnections + nextNode.NumberOfFreeLongConnections);
				}
				if (UnityEngine.Random.Range(0, 2) == 0)
				{
					BuildConnectionsOnSingleNode(ref nextNode, ref tempLastPlacedNodes, false, flag, ref zero, num2);
					BuildConnectionsOnSingleNode(ref nextNode, ref tempLastPlacedNodes, true, flag, ref zero, num2);
				}
				else
				{
					BuildConnectionsOnSingleNode(ref nextNode, ref tempLastPlacedNodes, true, flag, ref zero, num2);
					BuildConnectionsOnSingleNode(ref nextNode, ref tempLastPlacedNodes, false, flag, ref zero, num2);
				}
			}
		}
		lastPlacedNodes.Clear();
		lastPlacedNodes.AddRange(tempLastPlacedNodes);
		return tempLastPlacedNodes;
	}

	public void CenterCamera()
	{
		CenterCamera(false);
	}

	public void CenterCamera(bool zoom)
	{
		Rect extent = GetExtent();
		Vector3 position = extent.center;
		if (float.IsNaN(position.x) || float.IsNaN(position.y) || float.IsInfinity(position.x) || float.IsInfinity(position.y))
		{
			return;
		}
		if (zoom)
		{
			float num = extent.height / 2f;
			num += 20f;
			if (num < 200f)
			{
				num = 200f;
			}
			GalaxyMapManager.Instance.mainCamera.orthographicSize = num;
		}
		if (!initializeForWorkspace)
		{
			position.z = -100f;
			GalaxyMapManager.Instance.guiCamera.transform.position = position;
			cameraAdjPos = GalaxyMapManager.Instance.guiCamera.transform.position;
		}
		else
		{
			Camera.main.transform.position = position;
		}
	}

	private void BuildConnectionsOnSingleNode(ref UniverseNode nextNode, ref List<UniverseNode> tempLastPlacedNodes, bool isLong, bool useRandomPlacement, ref Vector3 definedDirVec, float definedPlacementRotationStep)
	{
		if (!isLong)
		{
			if (nextNode.NumberOfFreeShortConnections <= 0)
			{
				return;
			}
			int numberOfFreeShortConnections = nextNode.NumberOfFreeShortConnections;
			int num = 0;
			int count = galaxyNodeList.Count;
			List<int> list = new List<int>();
			for (int i = 0; i < count; i++)
			{
				if (galaxyNodeList[i].InternalID != nextNode.InternalID)
				{
					if (galaxyNodeList[i].NumberOfFreeShortConnections > 0)
					{
						Vector3 pos = nextNode.pos;
						Vector3 zero = Vector3.zero;
						if (useRandomPlacement)
						{
							float x = UnityEngine.Random.Range(-1f, 1f);
							float y = UnityEngine.Random.Range(-1f, 1f);
							zero = new Vector3(x, y, 0f);
						}
						else
						{
							zero = definedDirVec;
							definedDirVec = definedDirVec.RotateZ(definedPlacementRotationStep);
						}
						zero.Normalize();
						pos += zero * DistanceBetweenShortConnections;
						galaxyNodeList[i].pos = pos;
						nextNode.AddChildNodeShort(galaxyNodeList[i], GenerateEdgeID());
						if (!initializeForWorkspace)
						{
							galaxyNodeList[i].Hide();
						}
						else
						{
							galaxyNodeList[i].IsEnabled = true;
							galaxyNodeList[i].Show();
						}
						tempLastPlacedNodes.Add(galaxyNodeList[i]);
						placedNodes.Add(galaxyNodeList[i]);
						list.Add(i);
						num++;
						if (nextNode.NumberOfFreeShortConnections == 0)
						{
							break;
						}
					}
				}
				else
				{
					int num2 = 0;
					num2++;
				}
			}
			if (list.Count > 0)
			{
				int count2 = list.Count;
				for (int num3 = count2 - 1; num3 >= 0; num3--)
				{
					galaxyNodeList.RemoveAt(list[num3]);
				}
			}
			if (num < numberOfFreeShortConnections)
			{
				int num4 = 0;
				num4++;
			}
		}
		else
		{
			if (nextNode.NumberOfFreeLongConnections <= 0)
			{
				return;
			}
			int numberOfFreeLongConnections = nextNode.NumberOfFreeLongConnections;
			int num5 = 0;
			int count3 = galaxyNodeList.Count;
			List<int> list2 = new List<int>();
			for (int j = 0; j < count3; j++)
			{
				if (galaxyNodeList[j].InternalID != nextNode.InternalID && galaxyNodeList[j].NumberOfFreeLongConnections > 0)
				{
					if (StartingNodePlaced != null)
					{
						StartingNodePlaced(nextNode);
					}
					Vector3 pos2 = nextNode.pos;
					Vector3 zero2 = Vector3.zero;
					if (useRandomPlacement)
					{
						float x2 = UnityEngine.Random.Range(-1f, 1f);
						float y2 = UnityEngine.Random.Range(-1f, 1f);
						zero2 = new Vector3(x2, y2, 0f);
					}
					else
					{
						zero2 = definedDirVec;
						definedDirVec = definedDirVec.RotateZ(definedPlacementRotationStep);
					}
					zero2.Normalize();
					pos2 += zero2 * DistanceBetweenLongConnections;
					galaxyNodeList[j].pos = pos2;
					nextNode.AddChildNodeLong(galaxyNodeList[j], GenerateEdgeID());
					if (!initializeForWorkspace)
					{
						galaxyNodeList[j].Hide();
					}
					else
					{
						galaxyNodeList[j].IsEnabled = true;
						galaxyNodeList[j].Show();
					}
					tempLastPlacedNodes.Add(galaxyNodeList[j]);
					placedNodes.Add(galaxyNodeList[j]);
					list2.Add(j);
					num5++;
					if (nextNode.NumberOfFreeLongConnections == 0)
					{
						break;
					}
				}
			}
			if (list2.Count > 0)
			{
				int count4 = list2.Count;
				for (int num6 = count4 - 1; num6 >= 0; num6--)
				{
					galaxyNodeList.RemoveAt(list2[num6]);
				}
			}
			if (num5 < numberOfFreeLongConnections)
			{
				int num7 = 0;
				num7++;
			}
		}
	}

	private void GenerateUniverseID(UniverseConstelation constelation)
	{
		int internalID = 0;
		do
		{
			internalID = UnityEngine.Random.Range(1, int.MaxValue);
		}
		while (constelationList.FirstOrDefault((UniverseConstelation x) => x != null && x.InternalID == internalID) != null);
		constelation.InternalID = internalID;
	}

	private void GenerateNodeID(UniverseNode node)
	{
		int internalID = 0;
		do
		{
			internalID = UnityEngine.Random.Range(1, int.MaxValue);
		}
		while (placedNodes.FirstOrDefault((UniverseNode x) => x != null && x.InternalID == internalID) != null);
		node.InternalID = internalID;
	}

	private int GenerateEdgeID()
	{
		int internalID = 0;
		do
		{
			internalID = UnityEngine.Random.Range(1, int.MaxValue);
		}
		while (placedNodes.FirstOrDefault((UniverseNode x) => x != null && x.edgeToParent != null && x.edgeToParent.InternalID == internalID) != null);
		return internalID;
	}

	private List<KeyValuePair<UniverseNode, List<UniverseNode>>> GetPathsFromNode(UniverseNode startingNode, List<UniverseNode> possibleNodes)
	{
		List<KeyValuePair<UniverseNode, List<UniverseNode>>> list = new List<KeyValuePair<UniverseNode, List<UniverseNode>>>();
		foreach (UniverseNode possibleNode in possibleNodes)
		{
			if (possibleNode.InternalID != startingNode.InternalID)
			{
				List<UniverseNode> connectingNodes = null;
				if (GetPathBetweenNodes(startingNode, possibleNode, false, out connectingNodes))
				{
					KeyValuePair<UniverseNode, List<UniverseNode>> item = new KeyValuePair<UniverseNode, List<UniverseNode>>(possibleNode, connectingNodes);
					list.Add(item);
				}
				else if (GetPathBetweenNodes(startingNode, possibleNode, true, out connectingNodes))
				{
					KeyValuePair<UniverseNode, List<UniverseNode>> item2 = new KeyValuePair<UniverseNode, List<UniverseNode>>(possibleNode, connectingNodes);
					list.Add(item2);
				}
			}
		}
		return list;
	}

	private bool GetPathBetweenNodes(UniverseNode startingNode, UniverseNode endingNode, bool reverseDirection, out List<UniverseNode> connectingNodes)
	{
		return GetPathBetweenNodes(startingNode, endingNode, null, reverseDirection, out connectingNodes);
	}

	private bool GetPathBetweenNodes(UniverseNode startingNode, UniverseNode endingNode, UniverseNode deadNode, bool reverseDirection, out List<UniverseNode> connectingNodes)
	{
		connectingNodes = new List<UniverseNode>();
		if (!reverseDirection)
		{
			if (endingNode.parent != null && (endingNode.edgeToParent.IsEnabled || endingNode.edgeToParent.IsEnabledConditional))
			{
				connectingNodes = new List<UniverseNode>();
				connectingNodes.Add(endingNode.parent);
				if (endingNode.parent == startingNode)
				{
					return true;
				}
				List<UniverseNode> connectingNodes2 = null;
				if (GetPathBetweenNodes(startingNode, endingNode.parent, reverseDirection, out connectingNodes2))
				{
					connectingNodes.AddRange(connectingNodes2);
					return true;
				}
				if (GetPathBetweenNodes(startingNode, endingNode.parent, endingNode, true, out connectingNodes2))
				{
					connectingNodes.AddRange(connectingNodes2);
					return true;
				}
			}
		}
		else
		{
			List<UniverseNode> allChildrenNodes = endingNode.GetAllChildrenNodes();
			foreach (UniverseNode item in allChildrenNodes)
			{
				if (item.IsVisible && (deadNode == null || item != deadNode) && (item.edgeToParent.IsEnabled || item.edgeToParent.IsEnabledConditional))
				{
					connectingNodes = new List<UniverseNode>();
					connectingNodes.Add(item);
					if (item == startingNode)
					{
						return true;
					}
					List<UniverseNode> connectingNodes3 = null;
					if (GetPathBetweenNodes(startingNode, item, reverseDirection, out connectingNodes3))
					{
						connectingNodes.AddRange(connectingNodes3);
						return true;
					}
				}
			}
		}
		return false;
	}

	private void AddConstelation(UniverseConstelation constelation)
	{
		if (constelationList == null)
		{
			constelationList = new List<UniverseConstelation>();
		}
		if (!constelationList.Contains(constelation))
		{
			constelationList.Add(constelation);
		}
	}

	private void RemoveConstelation(UniverseConstelation constelation)
	{
		if (!constelationList.Contains(constelation))
		{
			return;
		}
		string text = UniverseSaveFile.Get(constelation.GroupKey, "THUMB", string.Empty);
		if (!string.IsNullOrEmpty(text))
		{
			string text2 = Path.Combine(Path.Combine(GameFileHelper.GetDataUniverseLocation(), UniverseSaveFile.CurrentUniversePath), string.Format("{0}.png", text));
			try
			{
				File.Delete(text2);
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("Error trying to delete constellation thumb in RemoveConstelation(): {0}\r\n\r\nError: {1}", text2, ex.Message));
			}
		}
		UniverseSaveFile.ClearGroup(constelation.GroupKey);
		constelationList.Remove(constelation);
	}
}
