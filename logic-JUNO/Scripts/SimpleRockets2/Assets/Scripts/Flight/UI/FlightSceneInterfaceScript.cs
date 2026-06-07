using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Levels;
using Assets.Scripts.Levels.LevelScripts.FlightTutorial;
using Assets.Scripts.Ui;
using ModApi.Flight;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Ioc;
using ModApi.Levels;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI
{
	public class FlightSceneInterfaceScript : MonoBehaviour, IFlightSceneUI
	{
		private FlightSceneUiController _controller;

		[SerializeField]
		private GameObject _controllerGameObject;

		private FlightLog _flightLog;

		private FlightLogScript _flightLogUI;

		private FlightTutorialPanelScript _flightTutorialPanel;

		[SerializeField]
		private InputHandlerScript _inputHandler;

		[SerializeField]
		private NavSphereScript _navSphere;

		[SerializeField]
		private NavSphereInterfaceScript _navSphereInterfaceScript;

		public MoveCrewRequest ActiveMoveCrewRequest { get; private set; }

		public Canvas Canvas { get; private set; }

		public IContextMenu ContextMenu => UiController.ContextMenu;

		public Image Crosshairs { get; private set; }

		public IFlightLog FlightLog => _flightLog;

		public IFlightLogUI FlightLogUI => _flightLogUI;

		public IFlightScene FlightScene => FlightSceneScript.Instance;

		public IFlightTutorialPanel FlightTutorialPanel
		{
			get
			{
				if (_flightTutorialPanel == null)
				{
					GameObject gameObject = UiUtilities.CreateUiGameObject("TutorialPanel", FlightScene.FlightSceneUI.Transform);
					_flightTutorialPanel = gameObject.AddComponent<FlightTutorialPanelScript>();
					Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Flight/FlightTutorialPanel", _flightTutorialPanel, delegate(IXmlLayoutController x)
					{
						_flightTutorialPanel.OnLayoutRebuilt((XmlLayout)x.XmlLayout);
					});
				}
				return _flightTutorialPanel;
			}
		}

		public INavSphere NavSphere => _navSphere;

		public bool NavSphereHeadingVisible
		{
			set
			{
				_navSphereInterfaceScript.HeadingVisible = value;
			}
		}

		public bool NavSphereVisible => _navSphereInterfaceScript.Visible;

		public RectTransform Transform { get; private set; }

		public FlightSceneUiController UiController => _controller;

		public bool Visible
		{
			get
			{
				return _controller.gameObject.activeInHierarchy;
			}
			set
			{
				if (Game.Instance.LevelManager?.CurrentLevel?.UI != null)
				{
					Game.Instance.LevelManager.CurrentLevel.UI.Visible = value;
				}
				Game.Instance.UserInterface.InspectorPanelsVisible = value;
				_controller.gameObject.SetActive(value);
				Crosshairs.gameObject.SetActive(value);
				RestoreNavSphereVisibility();
			}
		}

		public void AddInputResponder(IInputResponder fullScreenInputResponderScript)
		{
			_inputHandler.AddInputResponder(fullScreenInputResponderScript);
		}

		public void AddMoveCrewRequest(EvaScript eva)
		{
			if (ActiveMoveCrewRequest == null)
			{
				ActiveMoveCrewRequest = new MoveCrewRequest(eva);
				ActiveMoveCrewRequest.CrewMoveEnded += OnCrewMoveEnded;
				ShowMessage("Moving crew " + eva.Data.CrewName);
			}
			else
			{
				ActiveMoveCrewRequest.AddCrew(eva);
				ShowMessage("Added " + eva.Data.CrewName + " to crew movement");
			}
		}

		public void CancelMoveCrewRequest(EvaScript crew)
		{
			if (ActiveMoveCrewRequest != null)
			{
				ActiveMoveCrewRequest.RemoveCrew(crew);
				if (ActiveMoveCrewRequest.Crew.Count == 0)
				{
					ActiveMoveCrewRequest.EndCrewMove("Crew Move Canceled");
				}
				else
				{
					ShowMessage("Removed " + crew.Data.CrewName + " from crew movement");
				}
			}
		}

		public void OnBenchmarkButtonClicked()
		{
			ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.MessageText = "Enter a comment for the benchmark.";
			inputDialogScript.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				d.Close();
				d.gameObject.SetActive(value: false);
				Game.Instance.DevConsole.CloseConsole();
				FlightSceneBenchmarkScript.RunBenchmarkScriptDefault(d.InputText);
			};
		}

		public void OverrideInputResponderCapture(IInputResponder inputResponder)
		{
			_inputHandler.StartInputCapture(inputResponder);
		}

		public void RestoreNavSphereVisibility()
		{
			bool activeInHierarchy = _controller.gameObject.activeInHierarchy;
			activeInHierarchy = ((!FlightScene.ViewManager.GameView.RenderView) ? (activeInHierarchy && Game.Instance.Settings.Game.Flight.ShowNavSphereInMapView.Value) : (activeInHierarchy && Game.Instance.Settings.Game.Flight.ShowNavSphere.Value));
			SetNavSphereVisibility(activeInHierarchy, updateSettings: false);
		}

		public void SetCurrentTarget(IOrbitNode targetCraftNode)
		{
			IIocContainer iocContainer = Game.Instance.FlightScene.IocContainer;
			IMapViewContext context = (Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript).Context;
			ITargetableItem navigationTarget = iocContainer.Resolve<IItemRegistry>(context).FindTargetableItem(targetCraftNode);
			iocContainer.Resolve<INavigationTargetProvider>(context).SetNavigationTarget(navigationTarget);
		}

		public void SetNavSphereVisibility(bool visible, bool updateSettings)
		{
			_navSphereInterfaceScript.Visible = visible;
			if (updateSettings)
			{
				if (FlightScene.ViewManager.GameView.RenderView)
				{
					Game.Instance.Settings.Game.Flight.ShowNavSphere.UpdateAndCommit(visible);
				}
				else
				{
					Game.Instance.Settings.Game.Flight.ShowNavSphereInMapView.UpdateAndCommit(visible);
				}
			}
		}

		public void ShowDamageMessage(string message, bool devlog = false, float duration = 5f)
		{
			_controller.ShowDamageMessage(message, duration);
		}

		public void ShowMessage(string message, bool devlog = false, float duration = 5f)
		{
			_controller.ShowMessage(message, duration, devlog);
		}

		public void ShowRewardMessage(string text, long money, int techPoints, RewardMessageSoundType sound)
		{
			_controller.ShowRewardMessage(text, money, techPoints, sound);
		}

		protected virtual void Awake()
		{
			Transform = GetComponent<RectTransform>();
			XmlLayout xmlLayout = _controllerGameObject.AddComponent<XmlLayout>();
			_controller = _controllerGameObject.AddComponent<FlightSceneUiController>();
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Flight/FlightSceneUi", xmlLayout);
			ILevel currentLevel = Game.Instance.LevelManager.CurrentLevel;
			if (currentLevel != null)
			{
				LevelFlightUIController.CreateUI(Transform, currentLevel);
			}
			_flightLog = new FlightLog(this);
			_flightLogUI = FlightLogScript.Create(Transform, FlightLog);
			Crosshairs = base.transform.Find("Crosshairs").GetComponent<Image>();
		}

		protected virtual void Start()
		{
			Canvas = GetComponent<Canvas>();
			_navSphere.Initialize(FlightSceneScript.Instance.CraftNode, FlightSceneScript.Instance.ViewManager.GameView.ReferenceFrame);
			RestoreNavSphereVisibility();
			ConfigureInputResponders();
		}

		protected virtual void Update()
		{
			_flightLog.Update(Time.deltaTime);
			if (ActiveMoveCrewRequest != null && ActiveMoveCrewRequest.CrewCompartment == null && ActiveMoveCrewRequest.TimeSinceAccessibleCompartmentsUpdated > 1.0)
			{
				ActiveMoveCrewRequest.UpdateAccessibleCompartments();
			}
		}

		private void ConfigureInputResponders()
		{
			AddInputResponder(_navSphereInterfaceScript.InputResponder);
			AddInputResponder(FlightSceneScript.Instance.ViewManager.GameView.GameViewInterface.InputResponder);
		}

		private void OnCrewMoveEnded(string endMessage)
		{
			ShowMessage(endMessage);
			ActiveMoveCrewRequest.CrewMoveEnded -= OnCrewMoveEnded;
			ActiveMoveCrewRequest = null;
		}

		private void OnMapButtonClicked()
		{
			FlightSceneScript.Instance.ViewManager.ToggleMapView();
		}
	}
}
