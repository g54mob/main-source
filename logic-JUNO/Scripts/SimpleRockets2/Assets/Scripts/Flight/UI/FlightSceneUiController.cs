using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.ScaledSpace;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Flight.UI.Navball;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.State;
using Assets.Scripts.Terrain.Rendering;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Settings;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using Assets.Scripts.Ui.Sharing.Upload;
using Assets.Scripts.Ui.Sharing.Upload.BugReport;
using Assets.Scripts.Ui.Sharing.Upload.Sandbox;
using ModApi;
using ModApi.Audio;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.UI;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Services.Purchasing;
using ModApi.Settings;
using ModApi.State;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI
{
	public class FlightSceneUiController : XmlLayoutController
	{
		public class InspectorPanelWrapper
		{
			public IInspectorPanel InspectorPanel { get; set; }

			public int PanelIndex { get; }

			public IPartScript PartScript { get; set; }

			public InspectorPanelWrapper(IInspectorPanel inspectorPanel, IPartScript partScript, int panelIndex)
			{
				InspectorPanel = inspectorPanel;
				PartScript = partScript;
				PanelIndex = panelIndex;
			}
		}

		public class RewardMessage
		{
			public long CurrentMoney { get; set; }

			public int CurrentTechPoints { get; set; }

			public long RewardMoney { get; set; }

			public int RewardTechPoints { get; set; }

			public RewardMessageSoundType Sound { get; set; }

			public string Text { get; set; }
		}

		private long _altitude = -1L;

		private bool _altitudeAboveGroundLevel = true;

		private TextMeshProUGUI _altitudeText;

		private TextMeshProUGUI _altitudeTypeText;

		private int _analogControlsState = -1;

		private Image _batteryFill;

		private string _colorIndicator;

		private CraftNode _craftNode;

		private PlanetCubemapsRequest _cubemapsRequest;

		private FlightControls _flightControls;

		private XmlElement _flightMessagePanel;

		private int _fuel = -1;

		private Image _fuelFill;

		private TextMeshProUGUI _fuelText;

		private GameViewScript _gameView;

		private bool _mapNorthUp = true;

		private ScaledSpacePlanetScript _mapPlanet;

		private int _mapZoomLevel = -1;

		private TextMeshProUGUI _mapZoomText;

		private XmlElement _menu;

		private TextMeshProUGUI _messageDamageText;

		private float _messageDamageTimer;

		private TextMeshProUGUI _messageText;

		private float _messageTimer;

		private Image _mobileThrottleFill;

		private XmlElement _mobileThrottlePanel;

		private TextMeshProUGUI _mobileThrottleText;

		private Image _monoFill;

		private RectTransform _navballArrow;

		private Color _navballColourDefaultBottom;

		private Color _navballColourDefaultTop;

		private XmlElement _navballContainer;

		private NavballRendererControllerScript _navballControlller;

		private RectTransform _navballNorth;

		private bool _navballOpen;

		private INavSphere _navSphere;

		private bool _navSphereTargetSet;

		private List<FlightPanelController> _panels = new List<FlightPanelController>();

		private List<InspectorPanelWrapper> _partInspectorPanels = new List<InspectorPanelWrapper>();

		private Queue<RewardMessage> _rewardMessages = new Queue<RewardMessage>();

		private bool _skipReward;

		private TextMeshProUGUI _speedText;

		private TextMeshProUGUI _speedTypeText;

		private FlightPanelController _stagingPanel;

		private TargetBox _targetBox;

		private int _throttle = -1;

		private Image _throttleFill;

		private TextMeshProUGUI _throttleText;

		private long _velocity = -1L;

		private NavSphereVelocityMode? _velocityMode;

		public AnalogControlScript AnalogControlLeft { get; private set; }

		public AnalogControlScript AnalogControlRight { get; private set; }

		public bool AnalogControlsVisible
		{
			get
			{
				return AnalogControlLeft?.Visible ?? false;
			}
			set
			{
				if (AnalogControlLeft != null)
				{
					AnalogControlLeft.Visible = value;
					AnalogControlRight.Visible = value;
					if (value)
					{
						UpdateAnalogControls(forceUpdate: true);
					}
				}
			}
		}

		public ContextMenuController ContextMenu { get; private set; }

		public CraftNode CraftNode => _craftNode;

		public EvaPanelController EvaPanel { get; private set; }

		public NavBallStateType NavBallState
		{
			get
			{
				if (_navballOpen)
				{
					if (!_navballControlller.MapEnabled)
					{
						return NavBallStateType.Nav;
					}
					return NavBallStateType.Map;
				}
				return NavBallStateType.Hidden;
			}
		}

		public bool ScoochAnalogControlsUp
		{
			set
			{
				XmlElement elementById = base.xmlLayout.GetElementById("analog-stick-container");
				if (value)
				{
					elementById.AddClass("scooch-analog-controls");
				}
				else
				{
					elementById.RemoveClass("scooch-analog-controls");
				}
			}
		}

		public InputSliderPanelController SliderPanel { get; private set; }

		public void ClosePartInspectorPanel(IPartScript partScript)
		{
			InspectorPanelWrapper partInspectorPanel = GetPartInspectorPanel(partScript);
			if (partInspectorPanel != null)
			{
				ClosePartInspectorPanel(partInspectorPanel);
			}
		}

		public InspectorPanelWrapper CreatePartInspectorPanel(IPartScript partScript)
		{
			InspectorModel inspectorModel = partScript.GenerateInspectorModel();
			int panelIndex;
			for (panelIndex = 0; _partInspectorPanels.Exists((InspectorPanelWrapper x) => x.PanelIndex == panelIndex); panelIndex++)
			{
			}
			inspectorModel.UserPrefsId += panelIndex;
			InspectorPanelCreationInfo inspectorPanelCreationInfo = new InspectorPanelCreationInfo();
			inspectorPanelCreationInfo.StartPosition = InspectorPanelCreationInfo.InspectorStartPosition.UpperLeft;
			inspectorPanelCreationInfo.Resizable = !Device.IsMobileBuild;
			IInspectorPanel inspectorPanel = Game.Instance.UserInterface.CreateInspectorPanel(inspectorModel, inspectorPanelCreationInfo);
			InspectorPanelWrapper wrapper = new InspectorPanelWrapper(inspectorPanel, partScript, panelIndex);
			_partInspectorPanels.Add(wrapper);
			inspectorPanel.Closed += delegate
			{
				_partInspectorPanels.Remove(wrapper);
			};
			inspectorPanel.Unpinned += delegate
			{
				ClosePartInspectorPanel(wrapper);
			};
			return wrapper;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_colorIndicator = "#" + ColorUtility.ToHtmlStringRGB(base.xmlLayout.GetElementById<Image>("indicator-color").color);
			_speedText = base.xmlLayout.GetElementById<TextMeshProUGUI>("craft-speed");
			_speedText = base.xmlLayout.GetElementById<TextMeshProUGUI>("craft-speed");
			_speedTypeText = base.xmlLayout.GetElementById<TextMeshProUGUI>("craft-speed-type");
			_altitudeText = base.xmlLayout.GetElementById<TextMeshProUGUI>("craft-altitude");
			_altitudeTypeText = base.xmlLayout.GetElementById<TextMeshProUGUI>("craft-altitude-type");
			_flightMessagePanel = base.xmlLayout.GetElementById("flight-message-panel");
			_messageText = base.xmlLayout.GetElementById<TextMeshProUGUI>("message");
			_messageDamageText = base.xmlLayout.GetElementById<TextMeshProUGUI>("message-damage");
			_throttleText = base.xmlLayout.GetElementById<TextMeshProUGUI>("throttle-text");
			_fuelText = base.xmlLayout.GetElementById<TextMeshProUGUI>("fuel-text");
			_mobileThrottleText = base.xmlLayout.GetElementById<TextMeshProUGUI>("mobile-throttle-text");
			_throttleFill = base.xmlLayout.GetElementById<Image>("throttle-fill");
			_fuelFill = base.xmlLayout.GetElementById<Image>("fuel-fill");
			_batteryFill = base.xmlLayout.GetElementById<Image>("battery-fill");
			_monoFill = base.xmlLayout.GetElementById<Image>("mono-fill");
			_mobileThrottleFill = base.xmlLayout.GetElementById<Image>("mobile-throttle-fill");
			ContextMenu = base.xmlLayout.GetElementById("context-menu").GetComponentInChildren<ContextMenuController>();
			UpdateAltitudeTypeText();
			_navballContainer = base.xmlLayout.GetElementById<XmlElement>("navball-container");
			_navballOpen = _navballContainer.HasClass("navball-open");
			XmlElement elementById = base.xmlLayout.GetElementById<XmlElement>("navball-renderer");
			_navballControlller = elementById.gameObject.GetComponent<NavballRendererControllerScript>();
			ColorDictionary namedColors = base.xmlLayout.namedColors;
			_mapZoomText = base.xmlLayout.GetElementById<TextMeshProUGUI>("map-zoom-level");
			_navballArrow = base.xmlLayout.GetElementById<RectTransform>("player-position-arrow");
			_navballNorth = base.xmlLayout.GetElementById<RectTransform>("map-north-up");
			UpdateMapZoomText();
			if (namedColors.ContainsKey("NavballTop"))
			{
				_navballControlller.TopColor = namedColors["NavballTop"];
			}
			_navballColourDefaultTop = _navballControlller.TopColor;
			_navballColourDefaultBottom = _navballControlller.BottomColor;
			if (namedColors.ContainsKey("NavballBottom"))
			{
				_navballControlller.BottomColor = namedColors["NavballBottom"];
			}
			XmlElement elementById2 = base.xmlLayout.GetElementById("analog-control-left");
			XmlElement elementById3 = base.xmlLayout.GetElementById("analog-control-right");
			if (elementById2 != null && elementById3 != null)
			{
				AnalogControlLeft = elementById2.gameObject.AddComponent<AnalogControlScript>();
				AnalogControlRight = elementById3.gameObject.AddComponent<AnalogControlScript>();
				AnalogControlLeft.Initialize(elementById2);
				AnalogControlRight.Initialize(elementById3);
				AnalogControlsVisible = false;
			}
			XmlElement elementById4 = base.xmlLayout.GetElementById("target-panel");
			_targetBox = new TargetBox(elementById4, this);
			XmlElement elementById5 = base.xmlLayout.GetElementById("benchmark-button");
			XmlElement elementById6 = base.xmlLayout.GetElementById("share-sandbox-button");
			_menu = base.xmlLayout.GetElementById("menu");
			XmlElement elementById7 = base.xmlLayout.GetElementById("throttle-input");
			if (elementById7 != null)
			{
				RectTransform component = base.xmlLayout.GetElementById("throttle-rect").GetComponent<RectTransform>();
				elementById7.gameObject.AddComponent<ThrottleInputScript>().Initialize(component);
			}
			UpdateAltitudeTypeText();
			if (!Application.isPlaying)
			{
				return;
			}
			_panels.Clear();
			_stagingPanel = AddPanel("staging-panel");
			AddPanel("activation-panel");
			AddPanel("time-panel");
			AddPanel("fuel-transfer-panel");
			SliderPanel = AddPanel("input-slider-panel") as InputSliderPanelController;
			AddPanel("nav-panel");
			AddPanel("view-panel");
			EvaPanel = AddPanel("eva-panel") as EvaPanelController;
			EvaPanel.ActiveChanged += OnEvaPanelActiveChanged;
			EvaPanel.PanelItemsVisibleChanged += OnEvaPanelItemsVisibleChanged;
			_mobileThrottlePanel = base.xmlLayout.GetElementById("mobile-throttle-panel");
			GameStateType type = Game.Instance.GameState.Type;
			bool flag = type == GameStateType.Default;
			elementById5.SetActive(flag && FlightSceneBenchmarkScript.IsBenchmarkAllowed);
			elementById6.SetActive(flag);
			if (!FlightSceneScript.Instance.FlightLog.IsNewLaunch || !flag)
			{
				base.xmlLayout.GetElementById("relaunch-button")?.SetActive(active: false);
			}
			if (type == GameStateType.Level)
			{
				XmlElement elementById8 = base.xmlLayout.GetElementById("flight-scene-menu-career-button");
				if (elementById8 != null)
				{
					elementById8.SetActive(active: false);
				}
			}
			if (!Device.IsDebugBuild)
			{
				base.xmlLayout.GetElementById("switch-location-button")?.SetActive(active: false);
			}
			SetCraftNode(null);
			_messageText.gameObject.SetActive(value: false);
			_messageDamageText.gameObject.SetActive(value: false);
		}

		public void OnExitButtonClicked()
		{
			GameStateType type = Game.Instance.GameState.Type;
			if (type == GameStateType.PlanetStudio || type == GameStateType.Level)
			{
				RetryFlightDialogScript.Create(Game.Instance.FlightScene.FlightSceneUI.Transform);
			}
			else
			{
				EndFlightDialogScript.Create(Game.Instance.FlightScene.FlightSceneUI.Transform);
			}
		}

		public void RegeneratePartInspectorPanel(IPartScript partScript, bool createIfClosed = true)
		{
			Vector2 position = Vector2.zero;
			bool isPinned = false;
			InspectorPanelWrapper partInspectorPanel = GetPartInspectorPanel(partScript);
			bool flag = partInspectorPanel != null;
			if (createIfClosed || flag)
			{
				if (flag)
				{
					position = partInspectorPanel.InspectorPanel.Position;
					isPinned = partInspectorPanel.InspectorPanel.IsPinned;
					ClosePartInspectorPanel(partInspectorPanel);
				}
				InspectorPanelWrapper inspectorPanelWrapper = CreatePartInspectorPanel(partScript);
				if (flag)
				{
					inspectorPanelWrapper.InspectorPanel.Position = position;
					inspectorPanelWrapper.InspectorPanel.IsPinned = isPinned;
				}
			}
		}

		public void RemovePanel(FlightPanelController panel)
		{
			_panels.Remove(panel);
		}

		public void SetDisplayAltitudeTypeAGL(bool aboveGroundLevel)
		{
			if (aboveGroundLevel != _altitudeAboveGroundLevel)
			{
				_altitudeAboveGroundLevel = aboveGroundLevel;
				UpdateAltitudeTypeText();
			}
		}

		public void ShowDamageMessage(string message, float duration = 5f, bool devlog = false)
		{
			_messageDamageTimer = duration;
			_messageDamageText.text = message;
			_messageDamageText.gameObject.SetActive(value: true);
			if (devlog)
			{
				Debug.Log(message);
			}
		}

		public void ShowMessage(string message, float duration = 5f, bool devlog = false)
		{
			_messageTimer = duration;
			_messageText.text = message;
			_messageText.gameObject.SetActive(value: true);
			if (devlog)
			{
				Debug.Log(message);
			}
		}

		public void ShowRewardMessage(string text, long money, int techPoints, RewardMessageSoundType sound)
		{
			Assets.Scripts.Flight.FlightLog flightLog = FlightSceneScript.Instance.FlightLog;
			flightLog.TechPoints += techPoints;
			flightLog.Money += money;
			CareerState career = Game.Instance.GameState.Career;
			RewardMessage item = new RewardMessage
			{
				Text = text,
				CurrentMoney = career.Money,
				CurrentTechPoints = career.TechTree.ResearchPoints,
				RewardMoney = money,
				RewardTechPoints = techPoints,
				Sound = sound
			};
			_rewardMessages.Enqueue(item);
		}

		public void ToggleMenu()
		{
			if (!_menu.gameObject.activeSelf)
			{
				_menu.Show();
				Canvas component = _menu.GetComponent<Canvas>();
				if (component != null)
				{
					component.sortingOrder = 2;
					component.overrideSorting = true;
				}
				FlightSceneScript.Instance.TimeManager.RequestPauseChange(paused: true, userInitiated: false);
			}
			else
			{
				_menu.Hide();
				FlightSceneScript.Instance.TimeManager.RequestPauseChange(paused: false, userInitiated: false);
			}
		}

		protected virtual void LateUpdate()
		{
			foreach (FlightPanelController panel in _panels)
			{
				if (panel.Active)
				{
					panel.LateUpdatePanel(_craftNode);
				}
			}
			if (_gameView.RenderView)
			{
				_targetBox?.Update(_navSphere.Target);
			}
			else
			{
				_targetBox.Hide();
			}
		}

		protected virtual void Start()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			ViewManagerScript viewManager = FlightSceneScript.Instance.ViewManager;
			_navSphere = instance.FlightSceneUI.NavSphere;
			_gameView = viewManager.GameView;
			_gameView.SelectedPartChanged += OnSelectedPartChanged;
			_flightControls = instance.FlightControls;
			instance.ActiveCommandPodChanged += OnActiveCommandPodChanged;
			instance.ActiveCommandPodStateChanged += OnActiveCommandPodStateChanged;
			instance.CraftChanged += OnCraftChanged;
			foreach (FlightPanelController panel in _panels)
			{
				panel.StartPanel();
			}
			if (Game.IsCareer)
			{
				StartCoroutine(ProcessRewards());
			}
		}

		protected virtual void Update()
		{
			if (!Game.Instance.UserInterface.AnyDialogsOpen && (UnityEngine.Input.GetKeyDown(KeyCode.Escape) || Game.Instance.Inputs.FlightOpenMenu.GetButtonDownIfEnabled()))
			{
				ToggleMenu();
			}
			if (_messageTimer > 0f)
			{
				_messageTimer -= Time.unscaledDeltaTime;
				if (_messageTimer < 0f)
				{
					_messageText.gameObject.SetActive(value: false);
					_messageText.text = string.Empty;
				}
			}
			if (_messageDamageTimer > 0f)
			{
				_messageDamageTimer -= Time.unscaledDeltaTime;
				if (_messageDamageTimer < 0f)
				{
					_messageDamageText.gameObject.SetActive(value: false);
					_messageDamageText.text = string.Empty;
				}
			}
			if (_craftNode != null)
			{
				ICraftScript craftScript = _craftNode.CraftScript;
				long num = 0L;
				num = ((!_altitudeAboveGroundLevel) ? ((long)craftScript.FlightData.AltitudeAboveSeaLevel) : ((long)craftScript.FlightData.AltitudeAboveGroundLevel));
				if (_altitude != num)
				{
					_altitude = num;
					if (num >= 1000000000000L)
					{
						float num2 = (float)num / 1E+09f;
						_altitudeText.text = $"{num2:#,##0.0}<size=60%>GM</size>";
					}
					else if (num >= 1000000000)
					{
						float num3 = (float)num / 1000000f;
						_altitudeText.text = $"{num3:#,##0.0}<size=60%>MM</size>";
					}
					else if (num >= 100000)
					{
						float num4 = (float)num / 1000f;
						_altitudeText.text = $"{num4:#,##0.0}<size=60%>KM</size>";
					}
					else
					{
						_altitudeText.text = $"{num:n0}<size=60%>M</size>";
					}
				}
				long num5 = (long)_navSphere.VelocityMagnitude;
				if (_velocity != num5)
				{
					_velocity = num5;
					if (num5 >= 1000000000)
					{
						float num6 = (float)num5 / 1000000f;
						_speedText.text = $"{num6:#,##0.0}<size=60%>MM/S</size>";
					}
					else if (num5 >= 100000)
					{
						float num7 = (float)num5 / 1000f;
						_speedText.text = $"{num7:#,##0.0}<size=60%>KM/S</size>";
					}
					else
					{
						_speedText.text = $"{num5:n0}<size=60%>M/S</size>";
					}
				}
				if (_navballOpen && _navballControlller != null)
				{
					ScaledSpacePlanetScript currentScaledSpacePlanet = TerrainRendererManagerScript.Instance.CurrentScaledSpacePlanet;
					IPlanetData planetData = currentScaledSpacePlanet.PlanetNode.PlanetData;
					_navballControlller.TopColor = planetData.PlanetarySystemDefinedData.NavballTopColorOverride ?? _navballColourDefaultTop;
					_navballControlller.BottomColor = planetData.PlanetarySystemDefinedData.NavballBottomColorOverride ?? _navballColourDefaultBottom;
					if (currentScaledSpacePlanet != _mapPlanet)
					{
						_cubemapsRequest?.Cancel();
						if (currentScaledSpacePlanet.Renderer is ScaledSpaceSunRenderer)
						{
							if (_navballControlller.MapEnabled)
							{
								OnToggleMapClicked();
							}
							_cubemapsRequest = null;
							if (!_navballContainer.HasClass("map-disabled"))
							{
								_navballContainer.AddClass("map-disabled");
							}
						}
						else
						{
							TerrainQualitySettings.CubemapQualitySettings cubemapSettings = Game.Instance.QualitySettings.Terrain.CubemapSettings;
							_cubemapsRequest = planetData.RequestCubemaps("UI Map", cubemapSettings.NavMapSize, delegate(PlanetCubemapsRequest r)
							{
								_navballControlller.SetCubemap(r.CubemapColor);
							});
							if (_navballContainer.HasClass("map-disabled"))
							{
								_navballContainer.RemoveClass("map-disabled");
							}
						}
						_mapPlanet = currentScaledSpacePlanet;
					}
					if (_navballControlller.MapEnabled)
					{
						Quaternion quaternion = Quaternion.LookRotation(Quaternion.Inverse(craftScript.CraftNode.Parent.Rotation.ToQuaternion()) * craftScript.FlightData.PositionNormalized.ToVector3());
						float num8 = (float)craftScript.FlightData.Heading;
						if (_mapNorthUp)
						{
							_navballControlller.MapRotation = quaternion;
							_navballArrow.localEulerAngles = Vector3.back * num8;
							_navballNorth.localRotation = Quaternion.identity;
						}
						else
						{
							_navballControlller.MapRotation = quaternion * Quaternion.AngleAxis(num8, Vector3.forward);
							_navballArrow.localRotation = Quaternion.identity;
							_navballNorth.localEulerAngles = Vector3.forward * num8;
						}
					}
				}
				else if (_cubemapsRequest != null)
				{
					_cubemapsRequest?.Cancel();
					_cubemapsRequest = null;
				}
				if (_mobileThrottleFill != null)
				{
					_mobileThrottleFill.fillAmount = CraftNode.Controls.Throttle;
				}
				_throttleFill.fillAmount = Mathf.Clamp01(CraftNode.Controls.Throttle);
				_fuelFill.fillAmount = Mathf.Lerp(_fuelFill.fillAmount, craftScript.FlightData.RemainingFuelInStage, Time.unscaledDeltaTime * 5f);
				_batteryFill.fillAmount = craftScript.FlightData.RemainingBattery;
				_monoFill.fillAmount = craftScript.FlightData.RemainingMonopropellant;
				int num9 = Utilities.RoundPercentage(CraftNode.Controls.Throttle);
				if (_throttle != num9)
				{
					_throttle = num9;
					_throttleText.text = $"{num9}<size=75%>%</size>";
				}
				if (_fuelText != null)
				{
					int num10 = Utilities.RoundPercentage(craftScript.FlightData.RemainingFuelInStage);
					if (_fuel != num10)
					{
						_fuel = num10;
						_fuelText.text = $"{num10}<size=75%>%</size>";
					}
				}
				if (_mobileThrottleText != null)
				{
					_mobileThrottleText.text = _throttleText.text;
				}
				bool flag = _navSphere.Target != null;
				if (_velocityMode != FlightSceneScript.Instance.FlightSceneUI.NavSphere.VelocityMode || _navSphereTargetSet != flag)
				{
					_navSphereTargetSet = flag;
					_velocityMode = FlightSceneScript.Instance.FlightSceneUI.NavSphere.VelocityMode;
					TextMeshProUGUI speedTypeText = _speedTypeText;
					speedTypeText.text = _velocityMode switch
					{
						NavSphereVelocityMode.Orbit => "S <b><color=" + _colorIndicator + ">ORBT</color></b>" + (flag ? " T" : string.Empty), 
						NavSphereVelocityMode.Surface => "<b><color=" + _colorIndicator + ">SURF</color></b> O" + (flag ? " T" : string.Empty), 
						NavSphereVelocityMode.Target => "S O <b><color=" + _colorIndicator + ">TRGT</color></b>", 
						_ => "S O" + (flag ? " T" : string.Empty), 
					};
				}
				foreach (FlightPanelController panel in _panels)
				{
					if (panel.Active)
					{
						panel.UpdatePanel(_craftNode);
					}
				}
				UpdateAnalogControls(forceUpdate: false);
			}
			else
			{
				SetCraftNode((CraftNode)FlightSceneScript.Instance.CraftNode);
			}
		}

		private FlightPanelController AddPanel(string name)
		{
			XmlElement elementById = base.xmlLayout.GetElementById(name);
			FlightPanelController componentInChildren = elementById.GetComponentInChildren<FlightPanelController>();
			AddPanel(componentInChildren);
			if (elementById.HasClass("hide-on-start") && Application.isPlaying)
			{
				elementById.gameObject.SetActive(value: false);
			}
			return componentInChildren;
		}

		private void AddPanel(FlightPanelController panel)
		{
			_panels.Add(panel);
			panel.Initialize(this);
		}

		private void ClosePartInspectorPanel(InspectorPanelWrapper panel)
		{
			if (panel.PartScript.PartMaterialScript.IsSelected)
			{
				panel.PartScript.PartMaterialScript.IsSelected = false;
			}
			panel.InspectorPanel.Close();
		}

		private void DecreaseMapZoom()
		{
			if (_mapZoomLevel > -1)
			{
				_mapZoomLevel--;
			}
			_navballControlller.MapZoom = ((_mapZoomLevel == -1) ? 1f : (1f + (float)(1 << _mapZoomLevel) / 4f));
			UpdateMapZoomText();
		}

		private InspectorPanelWrapper GetPartInspectorPanel(IPartScript partScript)
		{
			InspectorPanelWrapper result = null;
			foreach (InspectorPanelWrapper partInspectorPanel in _partInspectorPanels)
			{
				if (partInspectorPanel.PartScript == partScript)
				{
					result = partInspectorPanel;
					break;
				}
			}
			return result;
		}

		private void IncreaseMapZoom()
		{
			if (_mapZoomLevel < 4)
			{
				_mapZoomLevel++;
			}
			_navballControlller.MapZoom = ((_mapZoomLevel == -1) ? 1f : (1f + (float)(1 << _mapZoomLevel) / 4f));
			UpdateMapZoomText();
		}

		private void OnActiveCommandPodChanged(ICraftNode craftNode)
		{
			SetCraftNode((CraftNode)craftNode);
		}

		private void OnActiveCommandPodStateChanged(ICraftNode craftNode)
		{
			SetCraftNode((CraftNode)craftNode);
		}

		private void OnAltitudeTypeClicked()
		{
			SetDisplayAltitudeTypeAGL(!_altitudeAboveGroundLevel);
		}

		private void OnCareerButtonClicked()
		{
			Game.Instance.FlightScene.TimeManager.RequestPauseChange(paused: true, userInitiated: false);
			(Game.Instance.UserInterface as UserInterface).CreateCareerDialog(allowChanges: false);
		}

		private void OnCraftChanged(ICraftNode craftNode)
		{
			SetCraftNode((CraftNode)craftNode);
		}

		private void OnCraftStructureChanged()
		{
			foreach (FlightPanelController panel in _panels)
			{
				panel.CraftStructureChanged(_craftNode);
			}
		}

		private void OnEvaPanelActiveChanged(object sender, EventArgs e)
		{
			bool active = EvaPanel.Active;
			_mobileThrottlePanel?.SetActive(!active);
			_stagingPanel.Active = !active;
		}

		private void OnEvaPanelItemsVisibleChanged()
		{
			_mobileThrottlePanel?.SetActive(EvaPanel.EvaControlScheme == EvaControlSchemeType.FlightNormal || EvaPanel.EvaControlScheme == EvaControlSchemeType.EvaInChair);
			_stagingPanel.Active = EvaPanel.EvaControlScheme == EvaControlSchemeType.FlightNormal || EvaPanel.EvaControlScheme == EvaControlSchemeType.EvaInChair;
		}

		private void OnNavballRotationUpdate(Quaternion rotation)
		{
			_navballControlller.NavRotation = rotation;
		}

		private void OnNavballVectorUpdate(int index, Vector3? vector)
		{
			_navballControlller.SetEnabled(index, vector.HasValue);
			if (vector.HasValue)
			{
				_navballControlller.FlightVectors[index] = vector.Value;
			}
		}

		private void OnPhotoLibraryButtonClicked()
		{
			Game.Instance.FlightScene.TimeManager.RequestPauseChange(paused: true, userInitiated: false);
			PhotoLibraryDialogScript.Create(Game.Instance.UserInterface.Transform);
		}

		private void OnQuickLoadButtonClicked()
		{
			FlightSceneScript.Instance.QuickLoad();
		}

		private void OnQuickSaveButtonClicked()
		{
			FlightSceneScript.Instance.QuickSave();
		}

		private void OnRelaunchButtonClicked()
		{
			LaunchLocationsViewModel launchLocationsViewModel = new LaunchLocationsViewModel();
			launchLocationsViewModel.LaunchLocationSelected = (Action<LaunchLocation>)Delegate.Combine(launchLocationsViewModel.LaunchLocationSelected, (Action<LaunchLocation>)delegate(LaunchLocation l)
			{
				FlightSceneScript.Instance.Relaunch(l);
			});
			launchLocationsViewModel.Title = "RELAUNCH CRAFT";
			launchLocationsViewModel.PrimaryButtonText = "RELAUNCH";
			ShowListView(launchLocationsViewModel);
		}

		private void OnReportBugButtonClicked()
		{
			UploadBugReportViewModel viewModel = new UploadBugReportViewModel();
			UploadContentDialogScript.Create(Game.Instance.UserInterface.Transform, viewModel);
		}

		private void OnRewardMessageClicked()
		{
			_skipReward = true;
		}

		private void OnRunBenchmarkButtonClicked()
		{
			((FlightSceneInterfaceScript)Game.Instance.FlightScene.FlightSceneUI).OnBenchmarkButtonClicked();
			ToggleMenu();
		}

		private void OnSaveLocationButtonClicked()
		{
			FlightSceneScript.Instance.SaveLaunchLocationPrompt();
		}

		private void OnSelectedPartChanged(IPartScript partScript)
		{
			foreach (InspectorPanelWrapper partInspectorPanel in _partInspectorPanels)
			{
				if (!partInspectorPanel.InspectorPanel.IsPinned)
				{
					ClosePartInspectorPanel(partInspectorPanel);
					break;
				}
			}
			if (partScript != null && GetPartInspectorPanel(partScript) == null)
			{
				CreatePartInspectorPanel(partScript);
			}
		}

		private void OnSettingsButtonClicked()
		{
			SettingsDialogScript.Create();
		}

		private void OnShareSandboxButtonClicked()
		{
			IInAppPurchaseFeatures<IInAppPurchaseFeature> features = Game.Instance.InAppPurchases.Features;
			if (Game.Instance.GameState.Mode == GameStateMode.Sandbox)
			{
				if (!features.IsFeatureUnlocked(features.SandboxBundle, "unlock support for uploading sandboxes."))
				{
					return;
				}
			}
			else if (Game.Instance.GameState.Mode == GameStateMode.Career && !features.IsFeatureUnlocked(features.CareerBundle, "unlock support for uploading career sandboxes."))
			{
				return;
			}
			UploadSandboxViewModel viewModel = new UploadSandboxViewModel();
			UploadContentDialogScript.Create(Game.Instance.UserInterface.Transform, viewModel);
		}

		private void OnSpeedTypeClicked()
		{
			if (_navSphere.VelocityMode == NavSphereVelocityMode.Surface)
			{
				_navSphere.VelocityMode = NavSphereVelocityMode.Orbit;
			}
			else if (_navSphere.VelocityMode == NavSphereVelocityMode.Orbit && _navSphere.Target != null)
			{
				_navSphere.VelocityMode = NavSphereVelocityMode.Target;
			}
			else
			{
				_navSphere.VelocityMode = NavSphereVelocityMode.Surface;
			}
		}

		private void OnSwitchLocationButtonClicked()
		{
			LaunchLocationsViewModel launchLocationsViewModel = new LaunchLocationsViewModel();
			launchLocationsViewModel.LaunchLocationSelected = (Action<LaunchLocation>)Delegate.Combine(launchLocationsViewModel.LaunchLocationSelected, (Action<LaunchLocation>)delegate(LaunchLocation l)
			{
				FlightSceneScript.Instance.SwitchLocation(l);
			});
			launchLocationsViewModel.Title = "SWITCH LOCATION";
			launchLocationsViewModel.PrimaryButtonText = "SWITCH";
			ShowListView(launchLocationsViewModel);
		}

		private void OnToggleFpsClicked()
		{
			Game.Instance.UserInterface.ToggleFps();
		}

		private void OnToggleMapClicked()
		{
			bool flag = !_navballControlller.MapEnabled;
			_navballControlller.MapEnabled = flag;
			if (flag)
			{
				_navballContainer.AddClass("map-active");
			}
			else
			{
				_navballContainer.RemoveClass("map-active");
			}
		}

		private void OnToggleNavballClicked()
		{
			_navballOpen = !_navballOpen;
			if (_navballOpen)
			{
				_navballContainer.AddClass("navball-open");
				if (_navballControlller.MapEnabled)
				{
					_navballContainer.AddClass("map-active");
				}
			}
			else
			{
				_navballContainer.RemoveClass("navball-open");
				if (_navballControlller.MapEnabled)
				{
					_navballContainer.RemoveClass("map-active");
				}
			}
		}

		private void OnToggleNorthUpClicked()
		{
			_mapNorthUp = !_mapNorthUp;
		}

		private IEnumerator ProcessRewards()
		{
			while (true)
			{
				yield return new WaitForEndOfFrame();
				if (_rewardMessages.Count <= 0)
				{
					continue;
				}
				RewardMessage m = _rewardMessages.Dequeue();
				XmlElement panel = base.xmlLayout.GetElementById("career-notification");
				panel.Show();
				_flightMessagePanel.AddClass("scooch");
				ShowRewardMessageImmediate(m);
				float time = 10f;
				while (time > 0f)
				{
					if (_skipReward)
					{
						_skipReward = false;
						time = 0f;
					}
					time -= Time.unscaledDeltaTime;
					yield return new WaitForEndOfFrame();
				}
				panel.Hide();
				yield return new WaitForSecondsRealtime(0.5f);
				_flightMessagePanel.RemoveClass("scooch");
			}
		}

		private void SetCraftNode(CraftNode craftNode)
		{
			if (_craftNode != null)
			{
				_craftNode.CraftScript.CraftStructureChanged -= OnCraftStructureChanged;
				_craftNode.CraftScript.NavballRotationUpdate -= OnNavballRotationUpdate;
				_craftNode.CraftScript.NavballVectorUpdate -= OnNavballVectorUpdate;
			}
			_craftNode = craftNode;
			foreach (FlightPanelController panel in _panels)
			{
				panel.CraftNodeChanged(craftNode);
			}
			if (_craftNode != null)
			{
				UpdateAnalogControls(forceUpdate: true);
				_craftNode.CraftScript.CraftStructureChanged += OnCraftStructureChanged;
				_craftNode.CraftScript.NavballRotationUpdate += OnNavballRotationUpdate;
				_craftNode.CraftScript.NavballVectorUpdate += OnNavballVectorUpdate;
			}
		}

		private void ShowListView(ListViewModel viewModel)
		{
			Game.Instance.UserInterface.CreateListView(viewModel);
		}

		private void ShowRewardMessageImmediate(RewardMessage m)
		{
			string text = "#00B7ED";
			base.xmlLayout.GetElementById<TextMeshProUGUI>("career-notification-text").text = m.Text.Replace("[highlight]", "<color=" + text + ">").Replace("[/highlight]", "</color>");
			TextMeshProUGUI elementById = base.xmlLayout.GetElementById<TextMeshProUGUI>("career-notification-rewards");
			string text2 = "<color=" + text + "><size=125%>";
			string text3 = "</size></color>";
			string text4 = string.Empty;
			if (m.RewardMoney > 0)
			{
				text4 = text4 + Units.GetMoneyString(m.CurrentMoney) + " + " + text2 + Units.GetMoneyString(m.RewardMoney) + text3;
			}
			if (m.RewardTechPoints > 0)
			{
				if (text4 != string.Empty)
				{
					text4 += "       ";
				}
				text4 += $"{m.CurrentTechPoints}<size=90%>TP</size> + {text2}{m.RewardTechPoints}<size=90%>TP</size>{text3}";
			}
			if (!string.IsNullOrWhiteSpace(text4))
			{
				elementById.gameObject.SetActive(value: true);
				elementById.text = text4;
				if (m.Sound == RewardMessageSoundType.Milestone)
				{
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Career.CompleteMilestone);
				}
				else if (m.Sound == RewardMessageSoundType.Landmark)
				{
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Career.CompleteLandmark);
				}
			}
			else
			{
				elementById.gameObject.SetActive(value: false);
			}
		}

		private void UpdateAltitudeTypeText()
		{
			if (_altitudeAboveGroundLevel)
			{
				_altitudeTypeText.text = "<b><color=#00B7ED>AGL</b></color> ASL";
			}
			else
			{
				_altitudeTypeText.text = "AGL <b><color=#00B7ED>ASL</b></color>";
			}
		}

		private void UpdateAnalogControls(bool forceUpdate)
		{
			if (!(AnalogControlLeft != null))
			{
				return;
			}
			bool translationModeEnabled = _craftNode.Controls.TranslationModeEnabled;
			bool flag = _craftNode.CraftScript.ActiveCommandPod.IsEva && _craftNode.CraftScript.ActiveCommandPod.EvaScript.EvaControlScheme == EvaControlSchemeType.Eva;
			bool evaGrounded = EvaPanel.EvaGrounded;
			int num = (translationModeEnabled ? 1 : 0) + (flag ? 2 : 0) + (evaGrounded ? 4 : 0);
			if (!(_analogControlsState != num || forceUpdate))
			{
				return;
			}
			_flightControls.ResetAnalogControls();
			_analogControlsState = num;
			bool analogControlsVisible = AnalogControlsVisible;
			if (flag)
			{
				AnalogControlLeft.VerticalInputType = AnalogControlScript.AnalogInputType.EvaMoveFwdAft;
				AnalogControlLeft.HorizontalInputType = AnalogControlScript.AnalogInputType.EvaStrafe;
				AnalogControlRight.Visible = analogControlsVisible;
				if (translationModeEnabled)
				{
					AnalogControlRight.VerticalInputType = AnalogControlScript.AnalogInputType.EvaUpDown;
					AnalogControlRight.HorizontalInputType = AnalogControlScript.AnalogInputType.Yaw;
				}
				else
				{
					AnalogControlRight.VerticalInputType = AnalogControlScript.AnalogInputType.Pitch;
					AnalogControlRight.HorizontalInputType = AnalogControlScript.AnalogInputType.Roll;
				}
			}
			else
			{
				AnalogControlLeft.VerticalInputType = AnalogControlScript.AnalogInputType.Throttle;
				AnalogControlLeft.HorizontalInputType = AnalogControlScript.AnalogInputType.Yaw;
				AnalogControlRight.Visible = analogControlsVisible;
				AnalogControlRight.HorizontalInputType = AnalogControlScript.AnalogInputType.Roll;
				AnalogControlRight.VerticalInputType = AnalogControlScript.AnalogInputType.Pitch;
			}
		}

		private void UpdateMapZoomText()
		{
			_mapZoomText.text = $"{(int)(_navballControlller.MapZoom * 100f)}%";
		}
	}
}
