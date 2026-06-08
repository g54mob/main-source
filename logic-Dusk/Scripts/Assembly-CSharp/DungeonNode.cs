using UnityEngine;
using UnityEngine.UI;

public class DungeonNode : MonoBehaviour
{
	public delegate void KeyPressedDelegate(DungeonInfo info);

	public static GameObject selectionIcon;

	private static GameObject infinateLineUp;

	private static GameObject infinateLineDown;

	private static GameObject infinateLineLeft;

	private static GameObject infinateLineRight;

	public KeyPressedDelegate shortcutPressed;

	public UITextIconLabel distanceUI;

	public UITextLabel keyUI;

	public Material InRangeMaterial;

	public Material TooFarMaterial;

	public Material VisitedMaterial;

	public Material MissingEquipmentMaterial;

	public Color InRangeColor = Color.white;

	public Color TooFarRangeColor = Color.white;

	public Color VisitedColor = Color.white;

	public Color MissingEquipmentColor = Color.white;

	public DungeonInfo Info;

	public Sprite[] backgroundSprites;

	private GUIStyle _guiStyleFore;

	private GUIStyle _guiStyleBack;

	private string _currentToolTipText;

	private string _currentToolTipTextForDistance;

	private bool _mouseIsOverMe;

	private Vector3 initialScale;

	public GameObject selectionIconPrefab;

	private GameObject orbitLine;

	private GameObject UIOverlay;

	private Material UIOverlayMat;

	private GameObject DistanceObject;

	private Image background;

	private bool fixLinePosition;

	private KeyCode shortcutKey;

	private string orbitLineKey = string.Empty;

	private float orbitRot = -1f;

	public bool IsVisible
	{
		get
		{
			if (UIOverlay != null)
			{
				return UIOverlay.GetComponent<Renderer>().enabled;
			}
			return GetComponent<Renderer>().enabled;
		}
		set
		{
			if (!value)
			{
				OnMouseExit();
			}
			if (UIOverlay != null)
			{
				UIOverlay.GetComponent<Renderer>().enabled = value;
			}
			if (value)
			{
				if (orbitLine == null)
				{
					orbitLine = GameObjectPool.Instance.PopObject(orbitLineKey);
				}
				if (orbitLine != null)
				{
					Vector3 position = base.transform.position;
					position.z += 0.1f;
					orbitLine.transform.position = position;
					if (orbitRot == -1f)
					{
						if (Info != null && GameSaveFile.Get("GAME_VER", 0f) > 0.283f)
						{
							orbitRot = Random.Range(Info.Parent.OrbitLineRotation - 10f, Info.Parent.OrbitLineRotation + 10f);
						}
						else
						{
							orbitRot = Random.Range(0, 360);
						}
					}
					orbitLine.transform.rotation = Quaternion.identity;
					orbitLine.transform.Rotate(Vector3.forward, orbitRot);
				}
			}
			else
			{
				GameObjectPool.Instance.PushObject(orbitLine);
				orbitLine = null;
			}
			if (orbitLine != null && orbitLine.transform.position.x > 99999f)
			{
				fixLinePosition = true;
			}
			if (selectionIcon.activeSelf != value)
			{
				selectionIcon.SetActive(value);
				Color white = Color.white;
				if (!GalaxyMapManager.Instance.isViewOnlyStarSystemView)
				{
					white.a = 0.25f;
				}
				else
				{
					white.a = 1f;
				}
				((LineRenderer)infinateLineUp.GetComponent<Renderer>()).SetColors(white, white);
				((LineRenderer)infinateLineDown.GetComponent<Renderer>()).SetColors(white, white);
				((LineRenderer)infinateLineLeft.GetComponent<Renderer>()).SetColors(white, white);
				((LineRenderer)infinateLineRight.GetComponent<Renderer>()).SetColors(white, white);
			}
		}
	}

	public bool inRange { get; private set; }

	public static void HideSelectionIcon()
	{
		if (selectionIcon != null)
		{
			selectionIcon.GetComponent<Renderer>().enabled = false;
		}
	}

	public static void ShowSelectionIcon()
	{
		if (selectionIcon != null)
		{
			selectionIcon.GetComponent<Renderer>().enabled = true;
		}
	}

	public static void ReleaseStaticReferences()
	{
		selectionIcon = null;
		infinateLineUp = null;
		infinateLineDown = null;
		infinateLineLeft = null;
		infinateLineRight = null;
	}

	private void Awake()
	{
		initialScale = base.transform.localScale;
		Transform transform = base.transform.Find("UIOverlay");
		if (transform != null)
		{
			UIOverlay = transform.gameObject;
			UIOverlayMat = UIOverlay.GetComponent<Renderer>().material;
			UIOverlayMat.color = InRangeColor;
			keyUI.label.color = InRangeColor;
		}
		transform = base.transform.FindChild("DistanceCanvas");
		if (transform != null)
		{
			DistanceObject = transform.gameObject;
			DistanceObject.SetActive(true);
			transform = DistanceObject.transform.FindChild("background");
			if (transform != null)
			{
				background = transform.gameObject.GetComponent<Image>();
			}
		}
		if (selectionIcon == null)
		{
			selectionIcon = (GameObject)Object.Instantiate(selectionIconPrefab, selectionIconPrefab.transform.position, selectionIconPrefab.transform.rotation);
			infinateLineUp = selectionIcon.transform.FindChild("YUp").gameObject;
			infinateLineDown = selectionIcon.transform.FindChild("YDown").gameObject;
			infinateLineLeft = selectionIcon.transform.FindChild("XLeft").gameObject;
			infinateLineRight = selectionIcon.transform.FindChild("XRight").gameObject;
			Vector3 position = selectionIcon.transform.position;
			position.z = -1f;
			Vector3 localScale = selectionIcon.transform.localScale;
			localScale *= 2f;
			selectionIcon.transform.position = position;
			selectionIcon.transform.localScale = localScale;
			selectionIcon.SetActive(false);
		}
	}

	private void Start()
	{
		_currentToolTipText = string.Empty;
		_guiStyleFore = new GUIStyle();
		_guiStyleFore.normal.textColor = Color.white;
		_guiStyleFore.alignment = TextAnchor.UpperLeft;
		_guiStyleFore.wordWrap = true;
		_guiStyleBack = new GUIStyle();
		_guiStyleBack.normal.textColor = Color.black;
		_guiStyleBack.alignment = TextAnchor.UpperLeft;
		_guiStyleBack.wordWrap = true;
		if (Info != null && Info.DungeonType == DungeonTypeEnum.Outpost && Info.BackgroundImageID >= 0 && Info.BackgroundImageID < backgroundSprites.Length)
		{
			background.overrideSprite = backgroundSprites[Info.BackgroundImageID];
		}
		switch (Random.Range(0, 3))
		{
		case 0:
			orbitLineKey = "OrbitLines1";
			break;
		case 1:
			orbitLineKey = "OrbitLines2";
			break;
		case 2:
			orbitLineKey = "OrbitLines3";
			break;
		}
		if (IsVisible)
		{
			IsVisible = true;
		}
	}

	private void OnDestroy()
	{
		InRangeMaterial = null;
		TooFarMaterial = null;
		VisitedMaterial = null;
		MissingEquipmentMaterial = null;
		selectionIconPrefab = null;
		GameObjectPool.Instance.PushObject(orbitLine);
		orbitLine = null;
		UIOverlay = null;
		Object.DestroyImmediate(UIOverlayMat);
		DistanceObject = null;
		background = null;
		if (backgroundSprites != null)
		{
			int num = backgroundSprites.Length;
			for (int i = 0; i < num; i++)
			{
				backgroundSprites[i] = null;
			}
			backgroundSprites = null;
		}
	}

	private void Update()
	{
		if (GalaxyMapManager.PreparingToBoard)
		{
			_mouseIsOverMe = false;
		}
		else if (GalaxyMapManager.Instance != null && GalaxyMapManager.Instance.CurrentMapState == GalaxyMapState.Dungeons && !DialogUI.Instance.IsShowing && !GalaxyMapManager.Instance.isShowingLogSelectionPanel && !HelpManual.Instance.IsVisible && !LogUI.Instance.IsShowing && shortcutKey != KeyCode.None && Input.GetKeyDown(shortcutKey) && (BoardingConfigUi.Instance == null || !BoardingConfigUi.Instance.IsVisible) && (ModificationUI.Instance == null || !ModificationUI.Instance.IsShowing) && (BoardingConfigShipUpgradeUi.Instance == null || !BoardingConfigShipUpgradeUi.Instance.IsVisible) && (TradeUI.Instance == null || !TradeUI.Instance.IsShowing) && (MenuPanelUI.Instance == null || !MenuPanelUI.Instance.gameObject.activeSelf) && (ObjectivesUI.Instance == null || !ObjectivesUI.Instance.IsShowing) && shortcutPressed != null)
		{
			shortcutPressed(Info);
		}
		if (fixLinePosition)
		{
			Vector3 position = base.transform.position;
			position.z += 0.1f;
			orbitLine.transform.position = position;
			fixLinePosition = false;
		}
	}

	private void OnMouseEnter()
	{
		if (GlobalSettings.cheatMode && IsVisible && !GlobalSettings.IsGamePaused && !GalaxyMapManager.PreparingToBoard)
		{
			_currentToolTipText = string.Format("{0}", Info.Name);
			_currentToolTipTextForDistance = string.Format("\nDistance: {0} day(s)", GalaxyMapManager.CalculateDungeonDistanceInDays(Info.Coordinates, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Coordinates));
			_mouseIsOverMe = true;
		}
	}

	private void OnMouseExit()
	{
		if (GlobalSettings.cheatMode && IsVisible && !GlobalSettings.IsGamePaused && !GalaxyMapManager.PreparingToBoard)
		{
			_currentToolTipText = string.Empty;
			_mouseIsOverMe = false;
		}
	}

	private void OnMouseUp()
	{
		if (GlobalSettings.cheatMode && IsVisible && !GlobalSettings.IsGamePaused && !GalaxyMapManager.PreparingToBoard && _mouseIsOverMe && Info.OnDungeonEvent != null)
		{
			Info.OnDungeonEvent(DungeonEventType.Clicked, Info);
		}
	}

	public void SetSelected(bool selected)
	{
		if (selected)
		{
			if (Info != null)
			{
				selectionIcon.transform.position = new Vector3(Info.Coordinates.x, Info.Coordinates.y, selectionIcon.transform.position.z);
			}
			else
			{
				selectionIcon.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, selectionIcon.transform.position.z);
			}
			base.transform.localScale = initialScale * 2f;
			distanceUI.icon.enabled = true;
			if (keyUI.gameObject.activeSelf)
			{
				keyUI.gameObject.SetActive(false);
			}
		}
		else
		{
			base.transform.localScale = initialScale;
			distanceUI.icon.enabled = false;
			if (!keyUI.gameObject.activeSelf)
			{
				keyUI.gameObject.SetActive(true);
			}
		}
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
		if (!(UIOverlay != null))
		{
			return;
		}
		if (!Info.HaveVisited)
		{
			if (inRange)
			{
				UIOverlayMat.color = InRangeColor;
				keyUI.label.color = InRangeColor;
			}
			else
			{
				UIOverlayMat.color = TooFarRangeColor;
				keyUI.label.color = TooFarRangeColor;
			}
		}
		else
		{
			UIOverlayMat.color = VisitedColor;
			keyUI.label.color = VisitedColor;
		}
	}

	public void SetDistanceFromSelected(int distance, bool isDistanceToDocked)
	{
		if (distance >= 0)
		{
			if (DistanceObject != null)
			{
				if (distance == 0)
				{
					if (distanceUI.gameObject.activeSelf)
					{
						distanceUI.gameObject.SetActive(false);
					}
				}
				else
				{
					if (!distanceUI.gameObject.activeSelf)
					{
						distanceUI.gameObject.SetActive(true);
					}
					distanceUI.label.text = distance.ToString();
				}
			}
			if (isDistanceToDocked)
			{
				distanceUI.label.color = GalaxyMapManager.Instance.SysDistanceToDockedColor;
			}
			else
			{
				distanceUI.label.color = GalaxyMapManager.Instance.SysDistanceToSelectedColor;
			}
		}
		else if (distanceUI.gameObject.activeSelf)
		{
			distanceUI.gameObject.SetActive(false);
		}
	}

	public void SetHasEquipment(bool hasEquipment)
	{
		Info.HasRequiredEquipment = hasEquipment;
		if (inRange && MissingEquipmentMaterial != null && UIOverlay != null && !Info.HaveVisited)
		{
			if (!Info.HasRequiredEquipment)
			{
				UIOverlayMat.color = MissingEquipmentColor;
				keyUI.label.color = MissingEquipmentColor;
			}
			else
			{
				SetInRange(true);
			}
		}
	}

	private void OnGUI()
	{
		if (!_mouseIsOverMe || GlobalSettings.IsGamePaused || LogUI.Instance.IsShowing || GalaxyMapManager.PreparingToBoard || GalaxyMapManager.ShowingUI || ObjectiveManual.IsVisible || ModificationUI.Instance.IsShowing || (!(DialogUI.Instance == null) && DialogUI.Instance.IsShowing) || TradeUI.Instance.IsShowing)
		{
			return;
		}
		_guiStyleFore.fontSize = 12;
		float x = Event.current.mousePosition.x;
		float y = Event.current.mousePosition.y;
		Rect position = new Rect(x + 15f, y + 10f, 200f, 60f);
		if (GlobalSettings.cheatMode)
		{
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
		GUI.Label(position, _currentToolTipText, _guiStyleBack);
		GUI.Label(position, _currentToolTipText, _guiStyleFore);
		if (inRange)
		{
			if (Info.HasRequiredEquipment)
			{
				_guiStyleFore.normal.textColor = Color.green;
			}
			else
			{
				_guiStyleFore.normal.textColor = GlobalSettings.Constants.ORANGE;
			}
		}
		else
		{
			_guiStyleFore.normal.textColor = Color.red;
		}
		GUI.Label(position, _currentToolTipTextForDistance, _guiStyleBack);
		GUI.Label(position, _currentToolTipTextForDistance, _guiStyleFore);
		if (GlobalSettings.cheatMode)
		{
			_guiStyleFore.fontSize = 10;
			_guiStyleFore.normal.textColor = Color.white;
			position.y += 40f;
			GUI.Label(position, "=======", _guiStyleFore);
			position.y += 10f;
			GUI.Label(position, string.Format("Difficulty: {0:N2}", Info.DifficultyFactor), _guiStyleFore);
			position.y += 10f;
			GUI.Label(position, string.Format("Infestation Types: {0}", Info.InfestationTypeCountValue), _guiStyleFore);
			position.y += 10f;
			GUI.Label(position, string.Format("Hull Type: {0}", Info.HullIntegrity), _guiStyleFore);
			position.y += 30f;
			GUI.Label(position, string.Format("Difficulty List", Info.InfestationTypeCountValue), _guiStyleFore);
			position.y += 10f;
			if (Info.CalculatedDifficultyValues != null)
			{
				GUI.Label(position, string.Format(" - Infestation:\t\t{0:N2}\t(wt: {1:N2})", Info.CalculatedDifficultyValues.InfestationTypeValue, 0.75f), _guiStyleFore);
				position.y += 10f;
				GUI.Label(position, string.Format(" - Enemy Ratio:\t{0:N2}\t(wt: {1:N2})", Info.CalculatedDifficultyValues.EnemyRatioValue, 0.75f), _guiStyleFore);
				position.y += 10f;
				GUI.Label(position, string.Format(" - Vent Ratio:\t\t{0:N2}\t(wt: {1:N2})", Info.CalculatedDifficultyValues.VentValue, 0.1f), _guiStyleFore);
				position.y += 10f;
				GUI.Label(position, string.Format(" - Hull:\t\t\t\t{0:N2}\t(wt: {1:N2})", Info.CalculatedDifficultyValues.HullIntegrityValue, 1f), _guiStyleFore);
				position.y += 10f;
				GUI.Label(position, string.Format(" - Transporter:\t{0:N2}\t(wt: {1:N2})", Info.CalculatedDifficultyValues.TransporterValue, 0.5f), _guiStyleFore);
				position.y += 10f;
				GUI.Label(position, string.Format(" - Asteroid:\t\t{0:N2}\t(wt: {1:N2})", Info.CalculatedDifficultyValues.AsteroidValue, 1f), _guiStyleFore);
				position.y += 10f;
				GUI.Label(position, string.Format(" - Door Fail:\t\t{0:N2}\t(wt: {1:N2})", Info.CalculatedDifficultyValues.EventDoorValue, 0.25f), _guiStyleFore);
				position.y += 10f;
				GUI.Label(position, string.Format(" - Door Close:\t\t{0:N2}\t(wt: {1:N2})", Info.CalculatedDifficultyValues.EventCloseValue, 0.25f), _guiStyleFore);
				position.y += 10f;
				GUI.Label(position, string.Format(" - Door Chew:\t\t{0:N2}\t(wt: {1:N2})", Info.CalculatedDifficultyValues.EventSwarmChewValue, 0.3f), _guiStyleFore);
			}
			else
			{
				GUI.Label(position, "Unable to access CalculatedDifficultyValues - null", _guiStyleFore);
			}
		}
		_guiStyleFore.normal.textColor = Color.white;
	}
}
