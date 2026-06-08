using System.Collections.Generic;
using UnityEngine;

public class GalaxyNode : MonoBehaviour
{
	public delegate void KeyPressedDelegate(StarSystemInfo info);

	public static GameObject selectionIcon;

	public KeyPressedDelegate shortcutPressed;

	public List<GameObject> ChildVisualNodes = new List<GameObject>();

	public UITextIconLabel distanceUI;

	public UITextLabel keyUI;

	public Material InRangeMaterial;

	public Material TooFarMaterial;

	public Material VisitedMaterial;

	public Color StarGateColorNotVisited = Color.white;

	public Color StarGateColorVisited = Color.white;

	public Color InRangeColor = Color.white;

	public Color TooFarRangeColor = Color.white;

	public Color VisitedColor = Color.white;

	public StarSystemInfo Info;

	private Vector3 initialScale;

	private bool _mouseIsOverMe;

	private GUIStyle _guiStyleFore;

	private GUIStyle _guiStyleBack;

	private string _currentToolTipText1;

	private string _currentToolTipText2;

	private GameObject ringObject;

	private GameObject indicatorObject;

	private GameObject UIOverlay;

	private GameObject DistanceObject;

	private int lastKnownDistance;

	private KeyCode shortcutKey;

	public bool IsVisible
	{
		get
		{
			return IsScanned && UIOverlay.GetComponent<Renderer>().enabled;
		}
		set
		{
			if (!value)
			{
				OnMouseExit();
			}
			else
			{
				if (lastKnownDistance != 0)
				{
					DistanceObject.SetActive(true);
				}
				distanceUI.gameObject.SetActive(true);
				distanceUI.label.enabled = true;
				distanceUI.icon.enabled = true;
			}
			ChildVisualNodes.ForEach(delegate(GameObject x)
			{
				x.GetComponent<Renderer>().enabled = value;
			});
			UIOverlay.GetComponent<Renderer>().enabled = value;
			ringObject.GetComponent<Renderer>().enabled = value;
			if (selectionIcon.activeSelf != value)
			{
				selectionIcon.SetActive(value);
			}
		}
	}

	public bool IsSelected { get; private set; }

	public List<DungeonNode> DungeonNodes { get; set; }

	public bool IsScanned { get; private set; }

	public bool inRange { get; private set; }

	public static void ReleaseStaticReferences()
	{
		selectionIcon = null;
	}

	private void Awake()
	{
		ChildVisualNodes.ForEach(delegate(GameObject x)
		{
			x.GetComponent<Renderer>().material = TooFarMaterial;
		});
		initialScale = base.transform.localScale;
		Transform transform = base.transform.Find("UIOverlay");
		if (transform != null)
		{
			UIOverlay = transform.gameObject;
			UIOverlay.GetComponent<Renderer>().material.color = TooFarRangeColor;
			keyUI.label.color = TooFarRangeColor;
		}
		transform = base.transform.FindChild("DistanceCanvas");
		if (transform != null)
		{
			DistanceObject = transform.gameObject;
			DistanceObject.SetActive(false);
		}
		if (selectionIcon == null && ResourceManager.SelectionIconPrefab != null)
		{
			selectionIcon = (GameObject)Object.Instantiate(ResourceManager.SelectionIconPrefab, ResourceManager.SelectionIconPrefab.transform.position, ResourceManager.SelectionIconPrefab.transform.rotation);
			selectionIcon.SetActive(false);
			selectionIcon.GetComponent<Renderer>().enabled = true;
			Vector3 position = selectionIcon.transform.position;
			position.z = -1f;
			selectionIcon.transform.position = position;
		}
		ringObject = base.transform.Find("Outline").gameObject;
		indicatorObject = base.transform.Find("Indicator").gameObject;
	}

	private void Start()
	{
		_currentToolTipText1 = string.Empty;
		_currentToolTipText2 = string.Empty;
		_guiStyleFore = new GUIStyle();
		_guiStyleFore.normal.textColor = Color.white;
		_guiStyleFore.fontSize = 15;
		_guiStyleFore.alignment = TextAnchor.UpperLeft;
		_guiStyleFore.wordWrap = true;
		_guiStyleBack = new GUIStyle();
		_guiStyleBack.normal.textColor = Color.black;
		_guiStyleBack.fontSize = 15;
		_guiStyleBack.alignment = TextAnchor.UpperLeft;
		_guiStyleBack.wordWrap = true;
		if (!GlobalSettings.GenerateGalaxyMapFromImage)
		{
			Scan();
			selectionIcon.SetActive(false);
		}
	}

	private void OnDestroy()
	{
		InRangeMaterial = null;
		TooFarMaterial = null;
		VisitedMaterial = null;
		ringObject = null;
		indicatorObject = null;
		UIOverlay = null;
		DistanceObject = null;
	}

	public void Refresh()
	{
		if (IsScanned && Info.HasStargate)
		{
			indicatorObject.GetComponent<Renderer>().enabled = true;
			indicatorObject.GetComponent<Renderer>().material.color = StarGateColorNotVisited;
			if (Info.IsStargateVisited)
			{
				indicatorObject.GetComponent<Renderer>().material.color = StarGateColorVisited;
			}
		}
		else
		{
			indicatorObject.GetComponent<Renderer>().enabled = false;
		}
	}

	private void Update()
	{
		if (GalaxyMapManager.Instance.CurrentMapState == GalaxyMapState.StarSystems && IsScanned && !DialogUI.Instance.IsShowing && !HelpManual.Instance.IsVisible && !GalaxyMapManager.Instance.isShowingLogSelectionPanel && !LogUI.Instance.IsShowing && shortcutKey != KeyCode.None && Input.GetKeyDown(shortcutKey) && (ModificationUI.Instance == null || !ModificationUI.Instance.IsShowing) && (BoardingConfigShipUpgradeUi.Instance == null || !BoardingConfigShipUpgradeUi.Instance.IsVisible) && (MenuPanelUI.Instance == null || !MenuPanelUI.Instance.gameObject.activeSelf) && (ObjectivesUI.Instance == null || !ObjectivesUI.Instance.IsShowing) && shortcutPressed != null)
		{
			shortcutPressed(Info);
		}
		if (IsScanned && !DistanceObject.activeSelf)
		{
			DistanceObject.SetActive(true);
		}
	}

	private void OnMouseEnter()
	{
		if (GlobalSettings.cheatMode && IsVisible && !GlobalSettings.IsGamePaused)
		{
			_currentToolTipText1 = Info.Name;
			_currentToolTipText2 = string.Format("Objects: {0}\nDistance: {1} day(s)", Info.TotalObjects, GalaxyMapManager.CalculateStarSystemDistanceInDays(Info.Coordinates, GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Coordinates));
			_mouseIsOverMe = true;
			base.transform.localScale = initialScale * 2f;
		}
	}

	private void OnMouseExit()
	{
		if (GlobalSettings.cheatMode && IsVisible && !GlobalSettings.IsGamePaused)
		{
			_currentToolTipText1 = string.Empty;
			_currentToolTipText2 = string.Empty;
			_mouseIsOverMe = false;
			if (!IsSelected)
			{
				base.transform.localScale = initialScale;
			}
		}
	}

	private void OnMouseUp()
	{
		if (GlobalSettings.cheatMode && IsVisible && !GlobalSettings.IsGamePaused && _mouseIsOverMe && Info.OnStarSystemEvent != null)
		{
			Info.OnStarSystemEvent(StarSystemEventType.Clicked, Info);
		}
	}

	private void OnGUI()
	{
		if (!_mouseIsOverMe || GlobalSettings.IsGamePaused || LogUI.Instance.IsShowing || (!(DialogUI.Instance == null) && DialogUI.Instance.IsShowing) || TradeUI.Instance.IsShowing)
		{
			return;
		}
		float x = Event.current.mousePosition.x;
		float y = Event.current.mousePosition.y;
		Rect position = new Rect(x + 10f, y + 5f, 130f, 60f);
		if (GlobalSettings.cheatMode)
		{
			position.width += 100f;
			position.height += 160f;
		}
		if (position.x + position.width > (float)Screen.width)
		{
			position.x -= position.x + position.width - (float)Screen.width;
		}
		if (position.y + position.height > (float)Screen.height)
		{
			position.y -= position.y + position.height - (float)Screen.height;
		}
		GUI.DrawTexture(position, ResourceManager.SemiTransparantBackground50);
		position.x += 5f;
		position.y += 5f;
		position.width -= 10f;
		position.height -= 25f;
		_guiStyleBack.fontSize = 15;
		_guiStyleFore.fontSize = 15;
		_guiStyleFore.normal.textColor = Color.white;
		GUI.Label(position, _currentToolTipText1, _guiStyleBack);
		GUI.Label(position, _currentToolTipText1, _guiStyleFore);
		position.y += 20f;
		_guiStyleBack.fontSize = 12;
		_guiStyleFore.fontSize = 12;
		_guiStyleFore.normal.textColor = Color.white;
		GUI.Label(position, _currentToolTipText2, _guiStyleBack);
		GUI.Label(position, _currentToolTipText2, _guiStyleFore);
		if (!GlobalSettings.cheatMode)
		{
			return;
		}
		_guiStyleFore.fontSize = 10;
		position.y += 50f;
		GUI.Label(position, "===============", _guiStyleFore);
		position.y += 10f;
		GUI.Label(position, string.Format("Internal ID: {0}", Info.InternalId), _guiStyleFore);
		position.y += 10f;
		GUI.Label(position, string.Format("Image Coords: {0}", Info.TrueImageCoords), _guiStyleFore);
		position.y += 10f;
		GUI.Label(position, string.Format("Has Stargate: {0}", Info.HasStargate), _guiStyleFore);
		if (Info.HasStargate)
		{
			position.y += 10f;
			if (Info.StargateConnection != null)
			{
				GUI.Label(position, string.Format(" - Stargate Destination: {0}", Info.IsChildGate ? Info.StargateConnection.parentNode.name : Info.StargateConnection.childNode.name), _guiStyleFore);
			}
			else
			{
				GUI.Label(position, string.Format(" - Jump to system, first, to see stargate info"), _guiStyleFore);
			}
		}
		position.y += 10f;
		GUI.Label(position, string.Format("# Derelicts: {0}", Info.NumberOfDungeons), _guiStyleFore);
		position.y += 10f;
		GUI.Label(position, string.Format("# Outposts: {0}", Info.NumberOfOutposts), _guiStyleFore);
		position.y += 10f;
		GUI.Label(position, string.Format("# Trading Posts: {0}", Info.NumberOfTradingPosts), _guiStyleFore);
		position.y += 10f;
		GUI.Label(position, string.Format("Difficulty: {0:N4} - {1:N4}", Info.DifficultyMin, Info.DifficultyMax), _guiStyleFore);
	}

	public void Scan()
	{
		IsScanned = true;
		IsVisible = true;
		if (!DistanceObject.activeSelf)
		{
			DistanceObject.SetActive(true);
		}
		if (!distanceUI.gameObject.activeSelf)
		{
			distanceUI.gameObject.SetActive(true);
		}
		distanceUI.label.enabled = true;
		distanceUI.icon.enabled = true;
		Refresh();
	}

	public void Hide()
	{
		IsScanned = false;
		IsVisible = false;
	}

	public void SetSelected(bool selected)
	{
		IsSelected = selected;
		if (selected || Mothership.CurrentStarSystem.galaxyNode == this)
		{
			selectionIcon.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, selectionIcon.transform.position.z);
			base.transform.localScale = initialScale * 2f;
			distanceUI.icon.enabled = true;
			if (selected)
			{
				keyUI.gameObject.SetActive(false);
			}
			else
			{
				keyUI.gameObject.SetActive(true);
				keyUI.gameObject.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
			}
		}
		else
		{
			if (base.gameObject != null && base.transform != null)
			{
				base.transform.localScale = initialScale;
			}
			distanceUI.icon.enabled = false;
			keyUI.gameObject.SetActive(true);
			keyUI.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
		}
		Refresh();
	}

	public void SetShortcutKey(KeyCode key)
	{
		if (keyUI != null)
		{
			keyUI.label.text = "[" + key.ToString() + "]";
		}
		shortcutKey = key;
	}

	public void SetInRange(bool inRange)
	{
		SetInRange(inRange, 0);
	}

	public void SetInRange(bool inRange, int distance)
	{
		this.inRange = inRange;
		if (!GalaxySaveFile.Get<bool>(Info.GroupKey, "VISITED"))
		{
			if (inRange)
			{
				UIOverlay.GetComponent<Renderer>().material.color = InRangeColor;
				keyUI.label.color = InRangeColor;
				ChildVisualNodes.ForEach(delegate(GameObject x)
				{
					x.GetComponent<Renderer>().material = InRangeMaterial;
				});
			}
			else
			{
				UIOverlay.GetComponent<Renderer>().material.color = TooFarRangeColor;
				keyUI.label.color = TooFarRangeColor;
				ChildVisualNodes.ForEach(delegate(GameObject x)
				{
					x.GetComponent<Renderer>().material = TooFarMaterial;
				});
			}
		}
		else
		{
			UIOverlay.GetComponent<Renderer>().material.color = VisitedColor;
			keyUI.label.color = VisitedColor;
			ChildVisualNodes.ForEach(delegate(GameObject x)
			{
				x.GetComponent<Renderer>().material = VisitedMaterial;
			});
		}
		if (DistanceObject != null)
		{
			lastKnownDistance = distance;
			int num = distance / 15 + 1;
			distanceUI.label.text = num.ToString();
			if (distance == 0 || !IsVisible)
			{
				distanceUI.gameObject.SetActive(false);
			}
			else
			{
				distanceUI.gameObject.SetActive(true);
			}
		}
	}
}
