using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneUIObject : MonoBehaviour, IDiscoverable, IUpdateCameraView
{
	public delegate void ObjectVisibleDelegate(GameObject datas);

	public delegate void BlinkEndDelegate();

	private const float _horizontalOffset = 1f;

	private const float LABEL_JUST_SHOWN_TIME = 0.7f;

	public const bool DISALLOW_INFO_TEXT = false;

	public GameObject[] UIObjects;

	public List<Material> UIObjectsMats = new List<Material>();

	public GameObject[] UIObjectsSchematic;

	public List<Material> UIObjectsSchematicMats = new List<Material>();

	public bool Visible;

	private bool visible;

	public bool Deactivated;

	public bool DisableSoundNotification;

	public float DroneDistance = 5f;

	private DroneManager droneManager;

	private float uiAlpha = 1f;

	private string _displayTitle;

	private List<string> _displayCommands = new List<string>();

	private HelpTextTypeEnum _helpTextType;

	private TextMesh _itemLabel;

	private Text itemLabelText;

	private Image itemLabelImage;

	private GameObject textUIGameObject;

	private Vector3 _infoLabelDelta = Vector3.zero;

	private float _labelJustShownTimer;

	private List<string> _commandsAlreadyUsed = new List<string>();

	private string forcedEnabledObjectName = string.Empty;

	private Color[] preBlinkColorsSV;

	private Color[] preBlinkColorsDV;

	private ColorBlinkManager[] blinkManagerArraySV;

	private ColorBlinkManager[] blinkManagerArrayDV;

	private AudioSource asRItemDetected;

	private AudioSource asSItemDetected;

	private bool _showingHelpText;

	public static bool DisableHelpText { get; set; }

	public List<Room> roomLst { get; set; }

	public GameObject parentObject { get; set; }

	public bool hiddenOnSchematic { get; private set; }

	private bool _allowDisplayOfHelpText { get; set; }

	public List<string> DisplayCommands
	{
		get
		{
			return _displayCommands;
		}
	}

	public HelpTextTypeEnum HelpTextType
	{
		get
		{
			return _helpTextType;
		}
	}

	public DateTime timeExpires { get; private set; }

	public bool hasBeenDiscovered { get; private set; }

	public bool hasBlinkedOnSchematic { get; private set; }

	public event ObjectVisibleDelegate objectBecameVisible;

	public event BlinkEndDelegate blinkingStoppedOnViewChange;

	public event BlinkEndDelegate blinkingCompleted;

	private void Awake()
	{
		if (HelpTextManager.Instance == null)
		{
			HelpTextManager.Instance = new HelpTextManager();
		}
		HelpTextManager.Instance.AddDroneUiObject(this);
		ResourceManager.OneTimeDungeonResourceLoad();
		GameObject gameObject = UnityEngine.Object.Instantiate(ResourceManager.ItemLabelPrefab);
		textUIGameObject = UnityEngine.Object.Instantiate(ResourceManager.HintLabelPrefab);
		_itemLabel = gameObject.GetComponent<TextMesh>();
		Transform transform = textUIGameObject.transform;
		transform = transform.FindChild("Text");
		itemLabelText = transform.gameObject.GetComponent<Text>();
		itemLabelText.transform.position = new Vector3(itemLabelText.transform.position.x, itemLabelText.transform.position.y, -5f);
		transform = textUIGameObject.transform.FindChild("Panel");
		itemLabelImage = transform.gameObject.GetComponent<Image>();
		textUIGameObject.SetActive(false);
		_itemLabel.gameObject.SetActive(false);
		_itemLabel.gameObject.SetActive(false);
		if (UIObjects != null && UIObjects.Length > 0)
		{
			Vector3 vector = UIObjects[0].transform.position + UIObjects[0].transform.right * 1f;
			_itemLabel.transform.position = new Vector3(vector.x, vector.y, -0.1f);
			textUIGameObject.transform.position = new Vector3(vector.x + 3.15f, vector.y + 1.2f, -0.1f);
		}
		UpdateInfoLabelText();
	}

	private void Start()
	{
		setVisible();
		droneManager = DroneManager.Instance;
		HideOtherViewOverlays();
		if (!GlobalSettings.IsGameEditor)
		{
			AddSoundSources();
		}
	}

	private void OnDestroy()
	{
		RemoveSoundSources();
		parentObject = null;
		if (UIObjects != null)
		{
			int num = UIObjects.Length;
			for (int i = 0; i < num; i++)
			{
				UIObjects[i] = null;
			}
			UIObjects = null;
		}
		if (UIObjectsSchematic != null)
		{
			int num2 = UIObjectsSchematic.Length;
			for (int j = 0; j < num2; j++)
			{
				UIObjectsSchematic[j] = null;
			}
			UIObjectsSchematic = null;
		}
		UnityEngine.Object.Destroy(asRItemDetected);
		UnityEngine.Object.Destroy(asSItemDetected);
		foreach (Material uIObjectsMat in UIObjectsMats)
		{
			if ((bool)uIObjectsMat)
			{
				UnityEngine.Object.DestroyImmediate(uIObjectsMat);
			}
		}
		foreach (Material uIObjectsSchematicMat in UIObjectsSchematicMats)
		{
			if ((bool)uIObjectsSchematicMat)
			{
				UnityEngine.Object.DestroyImmediate(uIObjectsSchematicMat);
			}
		}
	}

	private void HideHelpText()
	{
		if (textUIGameObject != null)
		{
			textUIGameObject.SetActive(false);
		}
		if (_itemLabel != null && _itemLabel.gameObject != null)
		{
			_itemLabel.gameObject.SetActive(false);
		}
		if (textUIGameObject == null || _itemLabel == null || _itemLabel.gameObject == null)
		{
			Debug.LogWarning("HideHelpText called with a null game object! - " + HelpTextType);
		}
		_showingHelpText = false;
		HelpTextManager.Instance.FlagTypeInactive(HelpTextType);
	}

	private void Update()
	{
		if (Deactivated || droneManager == null)
		{
			return;
		}
		Drone currentDrone = droneManager.CurrentDrone;
		if (currentDrone == null || GlobalSettings.IsGamePaused)
		{
			return;
		}
		bool showingHelpText = _showingHelpText;
		if (_labelJustShownTimer > 0f)
		{
			_labelJustShownTimer -= Time.deltaTime;
		}
		if (_showingHelpText && HelpTextManager.Instance != null && !HelpTextManager.Instance.HelpTextShouldDisplay(HelpTextType))
		{
			HideHelpText();
		}
		if (!Visible || _showingHelpText || (_allowDisplayOfHelpText && HelpTextManager.Instance != null && HelpTextManager.Instance.CanMakeHelpTextActive(HelpTextType)))
		{
			bool flag = false;
			bool flag2 = false;
			Vector3 position = base.transform.position;
			Vector3 position2 = currentDrone.transform.position;
			position.z = 0f;
			position2.z = 0f;
			float num = 9999f;
			num = Vector3.Distance(position2, position);
			if (num < DroneDistance && (roomLst == null || roomLst.Count == 0 || ContainsLoop(roomLst, currentDrone.CurrentRoom)))
			{
				flag = true;
				if (!DisableHelpText)
				{
					flag2 = true;
				}
			}
			else if (!Visible)
			{
				List<Drone> dronesList = droneManager.dronesList;
				int count = dronesList.Count;
				for (int i = 0; i < count; i++)
				{
					Drone drone = dronesList[i];
					if (drone != currentDrone && drone.IsVisible && !drone.IsDead)
					{
						position2 = drone.transform.position;
						position2.z = 0f;
						num = Vector3.Distance(position2, position);
						if (num < DroneDistance && (roomLst == null || roomLst.Count == 0 || ContainsLoop(roomLst, drone.CurrentRoom)))
						{
							flag = true;
							break;
						}
					}
				}
			}
			if (_showingHelpText && (DisableHelpText || (!flag2 && _labelJustShownTimer <= 0f)))
			{
				HideHelpText();
			}
			else if (flag2 && !_showingHelpText && _allowDisplayOfHelpText && HelpTextManager.Instance.CanMakeHelpTextActive(HelpTextType) && GlobalSettings.MissionTime > 1f)
			{
				_labelJustShownTimer = 0.7f;
				if (textUIGameObject != null)
				{
					textUIGameObject.SetActive(true);
				}
				if (_itemLabel != null && _itemLabel.gameObject != null)
				{
					_itemLabel.gameObject.SetActive(true);
				}
				if (textUIGameObject == null || _itemLabel == null || _itemLabel.gameObject == null)
				{
					Debug.LogWarning("DroneUIObject showing help text with a null game object! - " + HelpTextType);
				}
				_showingHelpText = true;
				HelpTextManager.Instance.FlagTypeActive(HelpTextType);
			}
			if (!Visible && flag)
			{
				if (!Visible && this.objectBecameVisible != null)
				{
					this.objectBecameVisible(parentObject);
				}
				MakeVisible();
				if (GlobalSettings.cameraMode == CameraMode.Drone || !hiddenOnSchematic)
				{
					setVisible();
				}
				if (!hiddenOnSchematic && GameplayManager.Instance != null && !GameplayManager.Instance.showSchematicToggleItems)
				{
					HideOnSchematic();
				}
				if (!Deactivated && !DisableSoundNotification)
				{
					if (GlobalSettings.cameraMode == CameraMode.Drone)
					{
						asRItemDetected.Play();
					}
					else
					{
						asSItemDetected.Play();
					}
				}
			}
		}
		if (Visible != visible || showingHelpText != _showingHelpText)
		{
			setVisible();
		}
		if (!visible)
		{
			return;
		}
		if (blinkManagerArrayDV != null)
		{
			int num2 = blinkManagerArrayDV.Length;
			for (int j = 0; j < num2; j++)
			{
				if (blinkManagerArrayDV == null)
				{
					continue;
				}
				ColorBlinkManager colorBlinkManager = blinkManagerArrayDV[j];
				if (colorBlinkManager == null || !colorBlinkManager.IsActive)
				{
					continue;
				}
				int num3 = (int)colorBlinkManager.tag;
				Color color = colorBlinkManager.Update(Time.deltaTime);
				if (colorBlinkManager != null && colorBlinkManager.IsActive)
				{
					Text component = UIObjects[num3].GetComponent<Text>();
					if (component == null)
					{
						UIObjectsMats.Add(UIObjects[num3].GetComponent<Renderer>().material);
						UIObjectsMats[UIObjectsMats.Count - 1].color = color;
					}
					else
					{
						component.color = color;
					}
				}
			}
		}
		if (blinkManagerArraySV == null)
		{
			return;
		}
		int num4 = blinkManagerArraySV.Length;
		for (int k = 0; k < num4; k++)
		{
			ColorBlinkManager colorBlinkManager2 = blinkManagerArraySV[k];
			if (colorBlinkManager2 == null || !colorBlinkManager2.IsActive)
			{
				continue;
			}
			int num5 = (int)colorBlinkManager2.tag;
			Color color2 = colorBlinkManager2.Update(Time.deltaTime);
			if (colorBlinkManager2 != null && colorBlinkManager2.IsActive)
			{
				Text component2 = UIObjectsSchematic[num5].GetComponent<Text>();
				if (component2 == null)
				{
					UIObjectsSchematicMats.Add(UIObjectsSchematic[num5].GetComponent<Renderer>().material);
					UIObjectsSchematicMats[UIObjectsSchematicMats.Count - 1].color = color2;
				}
				else
				{
					component2.color = color2;
				}
			}
		}
	}

	public void MakeVisible()
	{
		if (!Visible)
		{
			if (GlobalSettings.cameraMode == CameraMode.Drone && UIObjects.Length > 0)
			{
				preBlinkColorsDV = new Color[UIObjects.Length];
				blinkManagerArrayDV = new ColorBlinkManager[UIObjects.Length];
				int num = UIObjects.Length;
				for (int i = 0; i < num; i++)
				{
					Text component = UIObjects[i].GetComponent<Text>();
					Color color = Color.black;
					if (parentObject != null && parentObject.GetComponent(typeof(IOverlayCommunication)) != null)
					{
						color = ((IOverlayCommunication)parentObject.GetComponent(typeof(IOverlayCommunication))).GetBlinkColor(UIObjects[i].name);
					}
					if (color == Color.black)
					{
						color = ((!(component == null)) ? component.color : UIObjects[i].GetComponent<Renderer>().material.color);
					}
					preBlinkColorsDV[i] = color;
					Color startColor = preBlinkColorsDV[i];
					startColor.a = 0f;
					blinkManagerArrayDV[i] = new ColorBlinkManager();
					blinkManagerArrayDV[i].OnBlinkDoneWithSender += BlinkDoneDV;
					blinkManagerArrayDV[i].tag = i;
					blinkManagerArrayDV[i].Start(startColor, preBlinkColorsDV[i], 0.2f, 3);
				}
			}
			MarkAsDiscovered();
		}
		Visible = true;
	}

	public void SourceBlinkColorChanged(Color newColor, string ignore)
	{
		if (UIObjects.Length <= 0 || preBlinkColorsDV == null || blinkManagerArrayDV == null)
		{
			return;
		}
		int num = UIObjectsSchematic.Length;
		for (int i = 0; i < num; i++)
		{
			if (UIObjectsSchematic[i].name != ignore)
			{
				preBlinkColorsDV[i] = newColor;
				Color startColor = preBlinkColorsDV[i];
				startColor.a = 0f;
				blinkManagerArrayDV[i] = new ColorBlinkManager();
				blinkManagerArrayDV[i].OnBlinkDoneWithSender += BlinkDoneDV;
				blinkManagerArrayDV[i].tag = i;
				blinkManagerArrayDV[i].Start(startColor, preBlinkColorsDV[i], 0.2f, 3);
			}
		}
	}

	private void BlinkDoneDV(object sender)
	{
		if (sender == null)
		{
			return;
		}
		ColorBlinkManager colorBlinkManager = (ColorBlinkManager)sender;
		colorBlinkManager.OnBlinkDoneWithSender -= BlinkDoneDV;
		int num = (int)colorBlinkManager.tag;
		Text component = UIObjects[num].GetComponent<Text>();
		Color color = Color.black;
		if (parentObject != null && parentObject.GetComponent(typeof(IOverlayCommunication)) != null)
		{
			color = ((IOverlayCommunication)parentObject.GetComponent(typeof(IOverlayCommunication))).GetBlinkColor(UIObjects[num].name);
		}
		if (color == Color.black)
		{
			color = preBlinkColorsDV[num];
		}
		if (component == null)
		{
			UIObjects[num].GetComponent<Renderer>().material.color = color;
		}
		else
		{
			component.color = color;
		}
		if (blinkManagerArrayDV == null)
		{
			return;
		}
		blinkManagerArrayDV[num] = null;
		int num2 = blinkManagerArrayDV.Length;
		bool flag = true;
		for (int i = 0; i < num2; i++)
		{
			if (blinkManagerArrayDV[i] != null)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			blinkManagerArrayDV = null;
			if (this.blinkingCompleted != null)
			{
				this.blinkingCompleted();
			}
		}
	}

	private void BlinkDoneSV(object sender)
	{
		if (sender == null)
		{
			return;
		}
		ColorBlinkManager colorBlinkManager = (ColorBlinkManager)sender;
		colorBlinkManager.OnBlinkDoneWithSender -= BlinkDoneSV;
		int num = (int)colorBlinkManager.tag;
		Text component = UIObjectsSchematic[num].GetComponent<Text>();
		Color color = Color.black;
		if (parentObject != null && parentObject.GetComponent(typeof(IOverlayCommunication)) != null)
		{
			color = ((IOverlayCommunication)parentObject.GetComponent(typeof(IOverlayCommunication))).GetBlinkColor(UIObjectsSchematic[num].name);
		}
		if (color == Color.black)
		{
			color = preBlinkColorsSV[num];
		}
		if (component == null)
		{
			UIObjectsSchematic[num].GetComponent<Renderer>().material.color = color;
		}
		else
		{
			component.color = color;
		}
		if (blinkManagerArraySV == null)
		{
			return;
		}
		blinkManagerArraySV[num] = null;
		int num2 = blinkManagerArraySV.Length;
		bool flag = true;
		for (int i = 0; i < num2; i++)
		{
			if (blinkManagerArraySV[i] != null)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			blinkManagerArraySV = null;
			if (this.blinkingCompleted != null)
			{
				this.blinkingCompleted();
			}
		}
	}

	private bool ContainsLoop(List<Room> roomList, Room testRoom)
	{
		int count = roomLst.Count;
		for (int i = 0; i < count; i++)
		{
			if (roomList[i] == testRoom)
			{
				return true;
			}
		}
		return false;
	}

	public void ShowOneObjectByName(string name)
	{
		int num = UIObjects.Length;
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = UIObjects[i];
			string text = gameObject.name;
			if (text.Length > 0 && text.Length == name.Length && text[0] == name[0] && text == name)
			{
				Text component = gameObject.GetComponent<Text>();
				if (component == null)
				{
					gameObject.GetComponent<Renderer>().enabled = true;
				}
				else
				{
					component.enabled = true;
				}
			}
		}
		num = UIObjectsSchematic.Length;
		for (int j = 0; j < num; j++)
		{
			GameObject gameObject2 = UIObjectsSchematic[j];
			string text2 = gameObject2.name;
			if (text2.Length > 0 && text2.Length == name.Length && text2[0] == name[0] && text2 == name)
			{
				Text component2 = gameObject2.GetComponent<Text>();
				if (component2 == null)
				{
					gameObject2.GetComponent<Renderer>().enabled = true;
				}
				else
				{
					component2.enabled = true;
				}
			}
		}
		forcedEnabledObjectName = name;
	}

	private void setVisible()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone || UIObjectsSchematic == null || UIObjectsSchematic.Length == 0)
		{
			if (_showingHelpText && GlobalSettings.cameraMode == CameraMode.Drone && GlobalSettings.MissionStarted)
			{
				itemLabelText.enabled = true;
				itemLabelImage.enabled = true;
			}
			else
			{
				itemLabelText.enabled = false;
				itemLabelImage.enabled = false;
			}
			int num = UIObjects.Length;
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = UIObjects[i];
				Text component = gameObject.GetComponent<Text>();
				if (component == null)
				{
					Renderer component2 = gameObject.GetComponent<Renderer>();
					component2.enabled = Visible;
					if (Visible && component2.material != null)
					{
						Color color = component2.material.color;
						color.a = uiAlpha;
						component2.material.color = color;
					}
				}
				else
				{
					component.enabled = Visible;
					if (Visible)
					{
						Color color2 = component.color;
						color2.a = uiAlpha;
						component.color = color2;
					}
				}
			}
		}
		else if (!hiddenOnSchematic)
		{
			int num2 = UIObjectsSchematic.Length;
			for (int j = 0; j < num2; j++)
			{
				GameObject gameObject2 = UIObjectsSchematic[j];
				Text component3 = gameObject2.GetComponent<Text>();
				if (component3 == null)
				{
					Renderer component4 = gameObject2.GetComponent<Renderer>();
					component4.enabled = Visible;
					if (Visible && component4.material != null)
					{
						Color color3 = component4.material.color;
						color3.a = uiAlpha;
						component4.material.color = color3;
					}
				}
				else
				{
					component3.enabled = Visible;
					if (Visible)
					{
						Color color4 = component3.color;
						color4.a = uiAlpha;
						component3.color = color4;
					}
				}
			}
		}
		visible = Visible;
	}

	public void UpdateCameraView()
	{
		HideOtherViewOverlays();
		if (!Deactivated)
		{
			setVisible();
		}
		if (forcedEnabledObjectName != string.Empty)
		{
			ShowOneObjectByName(forcedEnabledObjectName);
		}
		if (!visible)
		{
			return;
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (blinkManagerArraySV != null)
			{
				int num = blinkManagerArraySV.Length;
				for (int i = 0; i < num; i++)
				{
					BlinkDoneSV(blinkManagerArraySV[i]);
				}
			}
			if (blinkManagerArrayDV != null)
			{
				int num2 = blinkManagerArrayDV.Length;
				for (int j = 0; j < num2; j++)
				{
					BlinkDoneDV(blinkManagerArrayDV[j]);
				}
			}
			if (this.blinkingStoppedOnViewChange != null)
			{
				this.blinkingStoppedOnViewChange();
			}
		}
		else
		{
			if (GlobalSettings.cameraMode != CameraMode.Schematic)
			{
				return;
			}
			if (blinkManagerArrayDV != null)
			{
				int num3 = blinkManagerArrayDV.Length;
				for (int k = 0; k < num3; k++)
				{
					if (blinkManagerArrayDV == null)
					{
						break;
					}
					BlinkDoneDV(blinkManagerArrayDV[k]);
				}
			}
			if (blinkManagerArraySV != null)
			{
				int num4 = blinkManagerArraySV.Length;
				for (int l = 0; l < num4; l++)
				{
					BlinkDoneSV(blinkManagerArraySV[l]);
				}
			}
			if (this.blinkingStoppedOnViewChange != null)
			{
				this.blinkingStoppedOnViewChange();
			}
			if (hasBeenDiscovered && !hasBlinkedOnSchematic)
			{
				BlinkOnSchematic();
			}
		}
	}

	public void SetOverlayAlpha(float newAlpha)
	{
		uiAlpha = newAlpha;
		UpdateCameraView();
	}

	public void Deactivate()
	{
		Deactivated = true;
		base.enabled = false;
		Visible = false;
		if (UIObjectsSchematic != null)
		{
			GameObject[] uIObjectsSchematic = UIObjectsSchematic;
			foreach (GameObject gameObject in uIObjectsSchematic)
			{
				Text component = gameObject.GetComponent<Text>();
				if (component == null)
				{
					gameObject.GetComponent<Renderer>().enabled = Visible;
				}
				else
				{
					component.enabled = Visible;
				}
			}
		}
		if (UIObjects == null)
		{
			return;
		}
		GameObject[] uIObjects = UIObjects;
		foreach (GameObject gameObject2 in uIObjects)
		{
			Text component2 = gameObject2.GetComponent<Text>();
			if (component2 == null)
			{
				gameObject2.GetComponent<Renderer>().enabled = Visible;
			}
			else
			{
				component2.enabled = Visible;
			}
		}
	}

	public void HideOnSchematic()
	{
		hiddenOnSchematic = true;
		GameObject[] uIObjectsSchematic = UIObjectsSchematic;
		foreach (GameObject gameObject in uIObjectsSchematic)
		{
			Text component = gameObject.GetComponent<Text>();
			if (component == null)
			{
				gameObject.GetComponent<Renderer>().enabled = false;
			}
			else
			{
				component.enabled = false;
			}
		}
	}

	public void RevealOnSchematic()
	{
		hiddenOnSchematic = false;
		if (Deactivated)
		{
			return;
		}
		GameObject[] uIObjectsSchematic = UIObjectsSchematic;
		foreach (GameObject gameObject in uIObjectsSchematic)
		{
			Text component = gameObject.GetComponent<Text>();
			if (component == null)
			{
				gameObject.GetComponent<Renderer>().enabled = Visible;
			}
			else
			{
				component.enabled = Visible;
			}
		}
	}

	private void HideOtherViewOverlays()
	{
		if (UIObjectsSchematic == null || UIObjectsSchematic.Length <= 0)
		{
			return;
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			GameObject[] uIObjectsSchematic = UIObjectsSchematic;
			foreach (GameObject gameObject in uIObjectsSchematic)
			{
				Text component = gameObject.GetComponent<Text>();
				if (component == null)
				{
					gameObject.GetComponent<Renderer>().enabled = false;
				}
				else
				{
					component.enabled = false;
				}
			}
			return;
		}
		itemLabelText.enabled = false;
		itemLabelImage.enabled = false;
		GameObject[] uIObjects = UIObjects;
		foreach (GameObject gameObject2 in uIObjects)
		{
			Text component2 = gameObject2.GetComponent<Text>();
			if (component2 == null)
			{
				gameObject2.GetComponent<Renderer>().enabled = false;
			}
			else
			{
				component2.enabled = false;
			}
		}
	}

	public void InitHelpTextInfo(string text, HelpTextTypeEnum helpTextType, bool enable)
	{
		_displayTitle = text;
		_helpTextType = helpTextType;
		_allowDisplayOfHelpText = enable;
		UpdateInfoLabelText();
	}

	public void AddInfoCommand(string commandText)
	{
		if (!_displayCommands.Contains(commandText))
		{
			_displayCommands.Add(commandText);
			UpdateInfoLabelText();
		}
	}

	public void MarkCommandAsUsed(string command)
	{
		if (!_commandsAlreadyUsed.Contains(command))
		{
			_commandsAlreadyUsed.Add(command);
			UpdateInfoLabelText();
		}
		if (_showingHelpText && !HelpTextManager.Instance.HelpTextShouldDisplay(HelpTextType))
		{
			HideHelpText();
		}
	}

	private void UpdateInfoLabelText()
	{
		if (!(_itemLabel != null))
		{
			return;
		}
		if (_allowDisplayOfHelpText)
		{
			string text = _displayTitle.ToUpper();
			if (_displayCommands.Count > 0)
			{
				text += "\nRecommended Command";
				if (_displayCommands.Count > 1)
				{
					text += "s";
				}
				int count = _displayCommands.Count;
				for (int i = 0; i < count; i++)
				{
					string text2 = _displayCommands[i];
					text = (_commandsAlreadyUsed.Contains(text2) ? (text + "\n( " + text2 + " )") : (text + "\n'" + text2 + "'"));
				}
			}
			_itemLabel.text = text;
			itemLabelText.text = text;
		}
		else if (!string.IsNullOrEmpty(_itemLabel.text))
		{
			_itemLabel.text = string.Empty;
			itemLabelText.text = string.Empty;
		}
	}

	public void AdjustInfoLabelPos(float xDelta, float yDelta)
	{
		_infoLabelDelta = Vector3.zero;
		_infoLabelDelta.x = xDelta;
		_infoLabelDelta.y = yDelta;
		_itemLabel.transform.position = new Vector3(_itemLabel.transform.position.x + _infoLabelDelta.x, _itemLabel.transform.position.y + _infoLabelDelta.y, _itemLabel.transform.position.z);
		textUIGameObject.transform.position = new Vector3(textUIGameObject.transform.position.x + _infoLabelDelta.x, textUIGameObject.transform.position.y + _infoLabelDelta.y, textUIGameObject.transform.position.z);
	}

	public void RefreshInfoLabelPos()
	{
		if (!(_itemLabel == null))
		{
			if (UIObjects != null && UIObjects.Length > 0)
			{
				Vector3 vector = UIObjects[0].transform.position + UIObjects[0].transform.right * 1f;
			}
			_itemLabel.transform.position = new Vector3(_itemLabel.transform.position.x + _infoLabelDelta.x, _itemLabel.transform.position.y + _infoLabelDelta.y, _itemLabel.transform.position.z + _infoLabelDelta.z);
			textUIGameObject.transform.position = new Vector3(textUIGameObject.transform.position.x + _infoLabelDelta.x, textUIGameObject.transform.position.y + _infoLabelDelta.y, textUIGameObject.transform.position.z + _infoLabelDelta.z);
		}
	}

	public void OverrideInfoLabelPos(Vector3 pos)
	{
		_itemLabel.transform.position = pos;
		textUIGameObject.transform.position = pos;
	}

	public void AllowHelpTextToBeShown()
	{
		_allowDisplayOfHelpText = true;
		UpdateInfoLabelText();
	}

	private void AddSoundSources()
	{
		asRItemDetected = base.gameObject.AddComponent<AudioSource>();
		asRItemDetected.clip = GameAudio.GetClip(GameAudio.SoundEnum.ItemDetected);
		asRItemDetected.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.ItemDetected, GameAudio.InterfaceVolume);
		asRItemDetected.spatialBlend = 1f;
		asRItemDetected.playOnAwake = false;
		if (DroneManager.Instance != null)
		{
			asSItemDetected = DroneManager.Instance.SchematicCamera.gameObject.AddComponent<AudioSource>();
			asSItemDetected.clip = asRItemDetected.clip;
			asRItemDetected.volume = asRItemDetected.volume;
			asSItemDetected.playOnAwake = false;
		}
	}

	private void RemoveSoundSources()
	{
		GameAudio.RemoveClip(GameAudio.SoundEnum.ItemDetected);
	}

	private void MarkAsDiscovered()
	{
		hasBeenDiscovered = true;
		timeExpires = DateTime.Now.AddSeconds(5.0);
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			BlinkOnSchematic();
		}
	}

	private void BlinkOnSchematic()
	{
		hasBlinkedOnSchematic = true;
		if (DateTime.Compare(DateTime.Now, timeExpires) > 0 || UIObjectsSchematic.Length <= 0)
		{
			return;
		}
		preBlinkColorsSV = new Color[UIObjectsSchematic.Length];
		blinkManagerArraySV = new ColorBlinkManager[UIObjectsSchematic.Length];
		int num = UIObjectsSchematic.Length;
		for (int i = 0; i < num; i++)
		{
			Text component = UIObjectsSchematic[i].GetComponent<Text>();
			Color color = Color.black;
			if (parentObject != null && parentObject.GetComponent(typeof(IOverlayCommunication)) != null)
			{
				color = ((IOverlayCommunication)parentObject.GetComponent(typeof(IOverlayCommunication))).GetBlinkColor(UIObjectsSchematic[i].name);
			}
			if (color == Color.black)
			{
				color = ((!(component == null)) ? component.color : UIObjectsSchematic[i].GetComponent<Renderer>().material.color);
			}
			preBlinkColorsSV[i] = color;
			Color startColor = preBlinkColorsSV[i];
			startColor.a = 0f;
			blinkManagerArraySV[i] = new ColorBlinkManager();
			blinkManagerArraySV[i].OnBlinkDoneWithSender += BlinkDoneSV;
			blinkManagerArraySV[i].tag = i;
			blinkManagerArraySV[i].Start(startColor, preBlinkColorsSV[i], 0.2f, 3);
		}
	}

	public void SetTextureOnObject(int dvIndex, Texture2D dvTexture, int svIndex, Texture2D svTexture)
	{
		if (UIObjects.Length > dvIndex)
		{
			UIObjects[dvIndex].GetComponent<Renderer>().material.mainTexture = dvTexture;
		}
		if (UIObjectsSchematic.Length > svIndex)
		{
			UIObjectsSchematic[svIndex].GetComponent<Renderer>().material.mainTexture = svTexture;
		}
	}
}
