using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Map : Menu
{
	private LevelManager lm;

	private RectTransform elementsRt;

	private Dictionary<Tuple<int, int>, MapLine> lineMap;

	private GameObject trainIcon;

	private GameObject markerIcon;

	private float halfCanvasWidth;

	private RectTransform rt;

	[SerializeField]
	private GameObject clouds;

	private Image image;

	[Header("Map")]
	[SerializeField]
	private Tooltip tooltip;

	private MapNode selectedNode;

	private Vector2 lastMousePosition;

	private bool isDragging;

	private float scrollTarget;

	private float scrollCurrent;

	[SerializeField]
	private float mouseScrollSpeed = 0.1f;

	[SerializeField]
	private float keyboardScrollSpeed = 3f;

	[SerializeField]
	private float scrollLerpSpeed = 10f;

	[SerializeField]
	private float scrollMargin = 100f;

	[SerializeField]
	private float minScrollableRange = 50f;

	private float minScrollX;

	private float maxScrollX;

	private Action<int, InputAction.CallbackContext> mapHandler;

	private Action<int, InputAction.CallbackContext> interactHandler;

	private MapNode controllerSelectedNode;

	private float lastMoveTime;

	[SerializeField]
	private float controllerMoveCooldown = 0.5f;

	public bool openedViaFurnace;

	public int mapClosedFrame;

	[field: SerializeField]
	public Transform ElementsTf { get; private set; }

	protected new void Awake()
	{
		base.Awake();
		image = base.transform.Find("Background").GetComponent<Image>();
		rt = GetComponent<RectTransform>();
	}

	private void Start()
	{
		ZoneManager.Instance.OnNewZone += HandleNewZone;
		InputManager.Instance.OnInteract += OnInteract;
		InputManager.Instance.OnEnter += OnEnter;
	}

	private void OnEnter(int i, InputAction.CallbackContext ctx)
	{
		if (selectedNode != null && base.isActiveAndEnabled)
		{
			LevelManager.Instance.OnNodeClick(selectedNode);
		}
	}

	private void OnInteract(int playerIndex, InputAction.CallbackContext actionContext)
	{
		if (!PlayerManager.Instance.Players[playerIndex].IsGamepad && openedViaFurnace)
		{
			MenuManager.Instance.CloseAllMenus();
		}
	}

	private void HandleNewZone(Zone zone)
	{
		RefreshMap();
	}

	public void RefreshMap()
	{
		UndiscoverAllNodes();
		DiscoverNodes();
		ComputeScrollBounds();
	}

	private void OnEnable()
	{
	}

	public override void Init()
	{
		mapHandler = delegate
		{
			HandleMapInput();
		};
		InputManager.Instance.OnMapPressed += mapHandler;
		lm = LevelManager.Instance;
		halfCanvasWidth = GetComponent<RectTransform>().rect.size.x / 2f;
		elementsRt = ElementsTf.GetComponent<RectTransform>();
		trainIcon = UnityEngine.Object.Instantiate(lm.Config.TrainIconPrefab, ElementsTf);
		markerIcon = UnityEngine.Object.Instantiate(lm.Config.markerIconPrefab, ElementsTf);
		ResetMap();
		LevelManager.Instance.NextLevelSelected += delegate
		{
			MenuManager.Instance.CloseCurrentMenu();
		};
		interactHandler = HandleInteractInput;
	}

	public void ResetMap()
	{
		if (elementsRt.childCount > 0)
		{
			foreach (Transform item in elementsRt)
			{
				if (item.TryGetComponent<MapNode>(out var component))
				{
					component.DestroySelf();
				}
			}
		}
		if (lineMap != null)
		{
			foreach (MapLine value in lineMap.Values)
			{
				value.DestroySelf();
			}
		}
		lineMap = new Dictionary<Tuple<int, int>, MapLine>();
	}

	public void SetMarkerPositionToFirstLevel()
	{
		RectTransform component = ElementsTf.GetChild(0).GetComponent<RectTransform>();
		Vector3 vector = component.anchoredPosition + new Vector2(0f, component.rect.height);
		RectTransform component2 = markerIcon.GetComponent<RectTransform>();
		RectTransform component3 = trainIcon.GetComponent<RectTransform>();
		component2.anchoredPosition = vector;
		component3.anchoredPosition = vector;
	}

	private void ComputeScrollBounds()
	{
		IEnumerable<float> source = lm.Levels.Select((Level l) => l.MapPosition.x);
		minScrollX = 0f - source.Max() + scrollMargin;
		maxScrollX = 0f - source.Min() - scrollMargin;
	}

	private void HandleMapInput()
	{
		if (!GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		if (MenuManager.Instance.CurrentMenu != null)
		{
			Menu currentMenu = MenuManager.Instance.CurrentMenu;
			if ((object)currentMenu == null || currentMenu.MenuType != MenuType.Map)
			{
				return;
			}
		}
		Menu currentMenu2 = MenuManager.Instance.CurrentMenu;
		if ((object)currentMenu2 != null && currentMenu2.MenuType == MenuType.Map)
		{
			MenuManager.Instance.CloseCurrentMenu();
			return;
		}
		MenuManager.Instance.CloseAllMenus();
		MenuManager.Instance.OpenMenu(MenuType.Map);
	}

	private void Update()
	{
		HandleMouseDragScroll();
		HandleControllerNavigation();
		ScrollElements();
		if (Mouse.current.leftButton.wasPressedThisFrame)
		{
			DebugRaycastUnderMouse();
		}
	}

	private void DebugRaycastUnderMouse()
	{
		Vector2 position = Mouse.current.position.ReadValue();
		PointerEventData eventData = new PointerEventData(EventSystem.current)
		{
			position = position
		};
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, list);
		foreach (RaycastResult item in list)
		{
			Debug.Log("Hit: " + item.gameObject.name, item.gameObject);
		}
		if (list.Count == 0)
		{
			Debug.Log("No UI elements hit at mouse position");
		}
	}

	private void HandleInteractInput(int playerIndex, InputAction.CallbackContext ctx)
	{
		if (ctx.control.device is Gamepad && controllerSelectedNode != null)
		{
			LevelManager.Instance.OnNodeClick(controllerSelectedNode);
		}
	}

	public void ConstructLinesFromLevelDataList(List<LevelData> levelDataList)
	{
		foreach (LevelData levelData in levelDataList)
		{
			foreach (int item in levelData.connectivity)
			{
				ConstructLine(levelData.index, item);
			}
		}
		SetTrainAndMarkerIcons();
	}

	public void ConstructLinesFromLevelSaveData(List<LevelSaveData> savedLevels)
	{
		foreach (LevelSaveData savedLevel in savedLevels)
		{
			foreach (int item in savedLevel.Connectivity)
			{
				ConstructLine(savedLevel.Index, item);
			}
		}
		SetTrainAndMarkerIcons();
	}

	private void SetTrainAndMarkerIcons()
	{
		markerIcon.transform.SetSiblingIndex(markerIcon.transform.parent.childCount - 1);
		trainIcon.transform.SetSiblingIndex(trainIcon.transform.parent.childCount - 1);
		Vector3 vector = ElementsTf.GetChild(0).GetComponent<RectTransform>().anchoredPosition;
		markerIcon.GetComponent<RectTransform>().anchoredPosition = vector;
		trainIcon.GetComponent<RectTransform>().anchoredPosition = vector;
	}

	private void ConstructLine(int i, int j)
	{
		Vector2[] array = lm.Levels.Select((Level level) => level.MapPosition).ToArray();
		Vector2 vector = array[i];
		Vector2 vector2 = array[j];
		Tuple<int, int> key = new Tuple<int, int>(i, j);
		Vector2 vector3 = vector - vector2;
		MapLine component = UnityEngine.Object.Instantiate(lm.Config.MapLinePrefab, ElementsTf).GetComponent<MapLine>();
		component.transform.localPosition = (vector + vector2) / 2f;
		component.transform.up = vector3;
		float x = component.GetComponent<RectTransform>().sizeDelta.x;
		component.GetComponent<RectTransform>().sizeDelta = new Vector2(x, Mathf.Floor((vector3.magnitude - 10f) / 3f) * 3f);
		lineMap[key] = component;
	}

	public void DiscoverNodes()
	{
		foreach (Level item in MapHelper.GetLevelsWithinDistance(lm.CurrentLevel, lm.Config.DiscoveryDst))
		{
			lm.DiscoverLevel(item);
		}
	}

	public void UndiscoverAllNodes()
	{
		foreach (Level level in lm.Levels)
		{
			lm.UndiscoverLevel(level);
		}
	}

	public void OnPointerEnterNode(MapNode node)
	{
		if (!(node == null) && node.Level != null && node.Level.Discovered)
		{
			if (controllerSelectedNode != null)
			{
				controllerSelectedNode.Highlight(isActive: false);
				controllerSelectedNode = node;
			}
			tooltip.gameObject.SetActive(value: true);
			selectedNode = node;
			tooltip.SetMapNode(selectedNode);
			selectedNode.Highlight(isActive: true);
			if (selectedNode.Level != lm.CurrentLevel)
			{
				ColorRouteFromNode(node);
			}
		}
	}

	public void OnPointerExitLevel()
	{
		if (!(selectedNode == null))
		{
			tooltip.gameObject.SetActive(value: false);
			ColorNextLevels();
			selectedNode.Highlight(isActive: false);
			if (MapHelper.GetDistanceBetweenLevels(lm.CurrentLevel, selectedNode.Level) == 1)
			{
				GetLine(lm.CurrentLevel.Index, selectedNode.Level.Index).Image.material = lm.Config.DotsMat;
				selectedNode = null;
			}
		}
	}

	protected void UpdateTrainMarker()
	{
		trainIcon.SetActive(!lm.IsAtDestination);
		if (LevelManager.Instance.CurrentLevel.Index == 0)
		{
			SetMarkerPositionToFirstLevel();
		}
		else if (lm.LevelHistory.Count <= 1)
		{
			trainIcon.transform.localPosition = lm.Levels[0].MapPosition;
			markerIcon.transform.localPosition = lm.Levels[0].MapPosition + new Vector2(0f, 10f);
		}
		else
		{
			trainIcon.transform.localPosition = lm.PreviousLevel.MapPosition + (lm.CurrentLevel.MapPosition - lm.PreviousLevel.MapPosition) * LevelManager.Instance.CurrentLevelProgress01;
			markerIcon.transform.localPosition = trainIcon.transform.localPosition + new Vector3(0f, 10f);
		}
	}

	public MapLine GetLine(int index1, int index2)
	{
		Tuple<int, int> key = new Tuple<int, int>(index1, index2);
		if (!lineMap.ContainsKey(key))
		{
			return null;
		}
		return lineMap[key];
	}

	public void ColorRouteFromNode(MapNode startNode)
	{
		Level level = startNode.Level;
		List<MapLine> list = new List<MapLine>();
		List<MapNode> list2 = new List<MapNode>();
		if (level == lm.CurrentLevel)
		{
			return;
		}
		if (lm.CurrentLevel.Connectivity.Contains(level.Index))
		{
			MapLine line = GetLine(lm.CurrentLevel.Index, level.Index);
			line.Image.GetComponent<RectTransform>().LeanCancel();
			line.Image.color = Color.white;
			line.Image.material = lm.Config.DotsMovingMat;
			list.Add(line);
		}
		List<Level> levelsWithinDistance = MapHelper.GetLevelsWithinDistance(level, 10);
		foreach (Level item in levelsWithinDistance)
		{
			MapNode mapNode = lm.GetMapNode(item);
			if (!(mapNode == null))
			{
				mapNode.SetAlpha(1f);
				list2.Add(mapNode);
			}
		}
		List<MapLine> linesFromLevels = MapHelper.GetLinesFromLevels(levelsWithinDistance);
		list.AddRange(linesFromLevels);
		foreach (MapLine item2 in linesFromLevels)
		{
			if ((bool)item2)
			{
				item2.GetComponent<MapLine>().ColorFade(lm.Config.DotColor);
			}
		}
		FadeOutLinesExcluding(list);
		FadeOutNodesExcluding(list2);
		ColorHistory();
	}

	public void ColorNextLevels()
	{
		List<MapNode> list = new List<MapNode>();
		foreach (Level level in lm.Levels)
		{
			if (level.Discovered)
			{
				MapNode mapNode = lm.GetMapNode(level);
				list.Add(mapNode);
				mapNode.AlphaFade(1f);
				if (level.Difficulty.Name != "")
				{
					mapNode.ChangeColor(level.Difficulty.Color);
				}
				else
				{
					mapNode.ChangeColor(lm.Config.DotColor);
				}
			}
		}
		List<Level> levelsWithinDistance = MapHelper.GetLevelsWithinDistance(lm.CurrentLevel, 1);
		List<MapLine> list2 = new List<MapLine>();
		foreach (Level item in levelsWithinDistance)
		{
			if (item != lm.CurrentLevel)
			{
				MapLine line = GetLine(lm.CurrentLevel.Index, item.Index);
				line.ColorFade(lm.Config.DotColor);
				list2.Add(line);
			}
		}
		FadeOutNodesExcluding(list);
		FadeOutLinesExcluding(list2);
		ColorHistory();
	}

	private void ColorHistory()
	{
		List<MapLine> list = new List<MapLine>();
		for (int i = 0; i < lm.LevelHistory.Count - 1; i++)
		{
			int index = lm.LevelHistory[i];
			int index2 = lm.LevelHistory[i + 1];
			MapLine line = GetLine(index, index2);
			list.Add(line);
		}
		foreach (MapLine item in list)
		{
			if (!(item == null))
			{
				item.Image.GetComponent<RectTransform>().LeanCancel();
				item.Image.color = Color.white;
			}
		}
	}

	private void FadeOutNodesExcluding(List<MapNode> nodesExcluded)
	{
		foreach (MapNode item in lm.levelToMapNode.Values.Except(nodesExcluded))
		{
			item.AlphaFade(lm.Config.MissedAlpha);
		}
	}

	private void FadeOutLinesExcluding(List<MapLine> linesExcluded)
	{
		IEnumerable<MapLine> enumerable;
		if (linesExcluded != null)
		{
			enumerable = lineMap.Values.Except(linesExcluded);
		}
		else
		{
			IEnumerable<MapLine> values = lineMap.Values;
			enumerable = values;
		}
		foreach (MapLine item in enumerable)
		{
			Color dotColor = lm.Config.DotColor;
			dotColor.a = lm.Config.MissedAlpha;
			item.ColorFade(dotColor);
			item.Image.material = lm.Config.DotsMat;
		}
	}

	protected override void OnOpen()
	{
		InputManager.Instance.OnInteract += interactHandler;
		UpdateTrainMarker();
		ColorNextLevels();
		ScrollElements();
		AudioManager.Instance.PlayClipWithMixer(lm.Config.MapSound, AMG.SFX);
		WorldMap.Instance.OpenLocalMap();
		base.transform.position = CameraController.Instance.GetAvgPlayerPosition() + new Vector3(-2.4f, -1.35f);
		clouds.SetActive(value: false);
		image.color = ZoneManager.Instance.CurrentZone.Definition.BgColor;
		CenterOnCurrentLevel();
		ComputeScrollBounds();
		if (Gamepad.current != null)
		{
			controllerSelectedNode = lm.GetMapNode(lm.CurrentLevel);
			selectedNode = controllerSelectedNode;
			controllerSelectedNode.Highlight(isActive: true);
		}
		else
		{
			controllerSelectedNode = null;
			selectedNode = null;
		}
	}

	protected override void OnClose()
	{
		selectedNode?.Highlight(isActive: false);
		clouds.SetActive(value: true);
		tooltip.gameObject.SetActive(value: false);
		openedViaFurnace = false;
		InputManager.Instance.OnInteract -= interactHandler;
		mapClosedFrame = Time.frameCount;
		WorldMap.Instance.CloseWorldMap();
	}

	private void CenterOnCurrentLevel()
	{
		scrollTarget = 0f - lm.CurrentLevel.MapPosition.x;
		scrollTarget = Mathf.Clamp(scrollTarget, minScrollX, maxScrollX);
		scrollCurrent = scrollTarget;
	}

	private void ScrollElements()
	{
		if (Mathf.Abs(maxScrollX - minScrollX) <= minScrollableRange)
		{
			scrollCurrent = (scrollTarget = (minScrollX + maxScrollX) / 2f);
		}
		else
		{
			scrollTarget = Mathf.Clamp(scrollTarget, minScrollX, maxScrollX);
			scrollCurrent = Mathf.Lerp(scrollCurrent, scrollTarget, Time.unscaledDeltaTime * scrollLerpSpeed);
		}
		elementsRt.anchoredPosition = new Vector2(scrollCurrent, 0f);
	}

	private MapNode GetClosestNodeInDirection(MapNode fromNode, Vector2 direction)
	{
		direction.Normalize();
		MapNode result = null;
		float num = float.MaxValue;
		foreach (MapNode value in lm.levelToMapNode.Values)
		{
			if (!value.Level.Discovered || value == fromNode)
			{
				continue;
			}
			Vector2 vector = value.Level.MapPosition - fromNode.Level.MapPosition;
			if (Vector2.Dot(direction, vector.normalized) > 0.5f)
			{
				float sqrMagnitude = vector.sqrMagnitude;
				if (sqrMagnitude < num)
				{
					result = value;
					num = sqrMagnitude;
				}
			}
		}
		return result;
	}

	private void HandleMouseDragScroll()
	{
		if (Mouse.current.leftButton.isPressed)
		{
			Vector2 vector = Mouse.current.position.ReadValue();
			if (!isDragging)
			{
				lastMousePosition = vector;
				isDragging = true;
			}
			float num = (vector.x - lastMousePosition.x) * mouseScrollSpeed;
			scrollTarget += num;
			lastMousePosition = vector;
		}
		else
		{
			isDragging = false;
		}
	}

	private void HandleControllerNavigation()
	{
		Menu currentMenu = MenuManager.Instance.CurrentMenu;
		if ((object)currentMenu == null || currentMenu.MenuType != MenuType.Map || !GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		Vector2 move = InputManager.Instance.GetAnyIdentifiedMoveInput().Move;
		if (!(Time.unscaledTime - lastMoveTime > controllerMoveCooldown) || !(move.magnitude > 0.5f))
		{
			return;
		}
		lastMoveTime = Time.unscaledTime;
		if (controllerSelectedNode == null)
		{
			if (selectedNode == null)
			{
				controllerSelectedNode = lm.GetMapNode(lm.CurrentLevel);
				OnPointerEnterNode(controllerSelectedNode);
			}
			else
			{
				controllerSelectedNode = selectedNode;
			}
			return;
		}
		Vector2 direction = move;
		MapNode closestNodeInDirection = GetClosestNodeInDirection(controllerSelectedNode, direction);
		if (closestNodeInDirection != null)
		{
			OnPointerExitLevel();
			controllerSelectedNode = closestNodeInDirection;
			OnPointerEnterNode(controllerSelectedNode);
			CenterOnNode(controllerSelectedNode);
		}
	}

	private void CenterOnNode(MapNode node)
	{
		scrollTarget = 0f - node.Level.MapPosition.x;
		scrollTarget = Mathf.Clamp(scrollTarget, minScrollX, maxScrollX);
	}

	private void OnDestroy()
	{
		InputManager.Instance.OnMapPressed -= mapHandler;
	}
}
