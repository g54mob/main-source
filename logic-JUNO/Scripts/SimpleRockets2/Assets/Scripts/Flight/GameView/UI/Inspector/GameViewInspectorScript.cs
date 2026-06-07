using System;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Math;
using ModApi.Services.Purchasing;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.UI.Inspector
{
	public class GameViewInspectorScript : MonoBehaviour
	{
		private IFlightScene _flightScene;

		private IGameView _gameView;

		private IInspectorPanel _inspectorPanel;

		private GameViewInspectorViewModel _viewModel;

		private bool _visible;

		public CraftNode PlayerCraft => _flightScene.CraftNode as CraftNode;

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				Game.Instance.Settings.Game.Flight.ShowFlightViewInspector.UpdateAndCommit(value);
				_visible = value;
			}
		}

		private CommandPodData ActiveCommandPodData => (_flightScene.CraftNode.CraftScript.ActiveCommandPod as CommandPodScript).Data;

		public static GameViewInspectorScript Create()
		{
			GameObject obj = new GameObject("GameViewInspector");
			obj.transform.SetParent(Game.Instance.FlightScene.FlightSceneUI.Transform, worldPositionStays: false);
			return obj.AddComponent<GameViewInspectorScript>();
		}

		public void ShowMessage(string message)
		{
			_flightScene.FlightSceneUI.ShowMessage(message);
		}

		protected virtual void Start()
		{
			_flightScene = Game.Instance.FlightScene;
			_gameView = _flightScene.ViewManager.GameView;
			InspectorModel inspectorModel = new InspectorModel("FlightView", "Flight Info");
			_viewModel = new GameViewInspectorViewModel();
			GroupModel groupModel = new GroupModel("Fuel");
			groupModel.Add(new TextModel("Battery", () => Units.GetPercentageString(_viewModel.FuelBatteryPercentage)));
			groupModel.Add(new TextModel("Mono", () => Units.GetPercentageString(_viewModel.FuelMonoPercentage)));
			groupModel.Add(new TextModel("Active Stage", () => Units.GetPercentageString(_viewModel.FuelActiveStagePercentage)));
			groupModel.Add(new TextModel("All Stages", () => Units.GetPercentageString(_viewModel.FuelAllStagesPercentage)));
			inspectorModel.AddGroup(groupModel);
			GroupModel groupModel2 = new GroupModel("Docking");
			TextModel statusModel = new TextModel("Status", () => _viewModel.DockingStatus);
			statusModel.UpdateAction = delegate
			{
				statusModel.Label = _viewModel.DockingStatusLabel;
			};
			groupModel2.Add(statusModel);
			_viewModel.SelectDockingPortButton = new TextButtonModel("SELECT PORT", delegate
			{
				OnSelectActiveDockingPort();
			});
			groupModel2.Add(_viewModel.SelectDockingPortButton);
			inspectorModel.AddGroup(groupModel2);
			_viewModel.DockingGroup = groupModel2;
			GroupModel groupModel3 = new GroupModel("Velocity");
			groupModel3.Collapsed = true;
			groupModel3.Add(new TextModel("Orbital", () => Units.GetVelocityString(_viewModel.OrbitVelocity)));
			groupModel3.Add(new TextModel("Surface", () => Units.GetVelocityString(_viewModel.SurfaceVelocity)));
			groupModel3.Add(new TextModel("Mach Number", () => _viewModel.MachNumber.ToString("n2")));
			groupModel3.Add(new TextModel("Lateral", () => Units.GetVelocityString(_viewModel.LateralSurfaceVelocity)));
			groupModel3.Add(new TextModel("Vertical", () => Units.GetVelocityString(_viewModel.VerticalSurfaceVelocity)));
			groupModel3.Add(new TextModel("Acceleration", () => Units.GetAccelerationString(_viewModel.Acceleration)));
			groupModel3.Add(new TextModel("Angular", () => Units.GetAngularVelocityString(_viewModel.AngularVelocity)));
			inspectorModel.AddGroup(groupModel3);
			GroupModel groupModel4 = new GroupModel("Performance");
			groupModel4.Collapsed = true;
			groupModel4.Add(new TextModel("Engine Thrust", () => Units.GetForceString(_viewModel.EngineThrust * 0.01f)));
			groupModel4.Add(new TextModel("TWR", () => _viewModel.ThrustToWeightRatio.ToString("n2")));
			groupModel4.Add(new TextModel("Stage Isp", () => Units.GetIspString(_viewModel.CurrentIsp)));
			groupModel4.Add(new TextModel("Stage Burn Time", () => Units.GetRelativeTimeString(_viewModel.RemainingBurnTime)));
			groupModel4.Add(new TextModel("Stage Delta-V", () => Units.GetVelocityString(_viewModel.DeltaVStage)));
			groupModel4.Add(new TextModel("Craft Mass", () => Units.GetMassString(_viewModel.CraftMass * 0.01f)));
			groupModel3.Add(new TextModel("Drag Loss", () => Units.GetAccelerationString(_viewModel.Drag)));
			groupModel4.Add(new TextModel("Air Density", () => Units.GetDensityString(_viewModel.AirDensity)));
			groupModel4.Add(new TextModel("Ambient Temperature", () => Units.GetTemperatureString(_viewModel.AirTemperature)));
			_viewModel.PerformanceGroup = groupModel4;
			inspectorModel.AddGroup(groupModel4);
			GroupModel groupModel5 = new GroupModel("Trajectory");
			groupModel5.Collapsed = true;
			groupModel5.Add(new TextModel("Location", () => Units.GetCoordinatesString(_viewModel.Coordinates)));
			groupModel5.Add(new TextModel("Planet", () => _viewModel.PlanetNode?.Name ?? "N/A"));
			groupModel5.Add(new TextModel("Apoapsis", () => Units.GetDistanceString(_viewModel.ApoapsisAltitude)));
			groupModel5.Add(new TextModel("Periapsis", () => Units.GetDistanceString(_viewModel.PeriapsisAltitude)));
			groupModel5.Add(new TextModel("Time to Apo.", () => Units.GetRelativeTimeString(_viewModel.ApoapsisTime)));
			groupModel5.Add(new TextModel("Time to Per.", () => Units.GetRelativeTimeString(_viewModel.PeriapsisTime)));
			groupModel5.Add(new TextModel("Gravity", () => Units.GetAccelerationString(_viewModel.Gravity)));
			inspectorModel.AddGroup(groupModel5);
			inspectorModel.AddGroup(CreateAutoPilotGroup());
			GroupModel groupModel6 = new GroupModel("Options");
			groupModel6.Collapsed = true;
			groupModel6.Add(new ToggleModel("Wing Vectors", () => WingScript.ShowLiftVectorGlobal, delegate(bool x)
			{
				WingScript.ShowLiftVectorGlobal = x;
			}));
			groupModel6.Add(new ToggleModel("EVA Follow Camera", () => Game.Instance.Settings.Game.Flight.AstronautFollowCamera.Value, delegate(bool x)
			{
				Game.Instance.Settings.Game.Flight.AstronautFollowCamera.UpdateAndCommit(x);
			}));
			Game.Instance.Settings.Game.Flight.DragScale.UpdateAndCommit(1f);
			Game.Instance.Settings.Game.Flight.GravityScale.UpdateAndCommit(1f);
			if (!Game.IsCareer || Game.Instance.GameState.Validator.IsItemAvailable("Cheats.FlightCheats"))
			{
				IInAppPurchaseFeature cheatsFeature = Game.Instance.InAppPurchases.Features.InFlightCheats;
				if (cheatsFeature.Unlocked)
				{
					groupModel6.Add(new ToggleModel("Infinite Fuel", () => Game.InfiniteFuelEnabled, delegate(bool x)
					{
						Game.InfiniteFuelEnabled = x;
					}));
					groupModel6.Add(new TextButtonModel("Teleport", delegate
					{
						Game.Instance.FlightScene.TeleportPlayer();
					}));
					groupModel6.Add(new TextButtonModel("Set Speed", delegate
					{
						Game.Instance.FlightScene.SetPlayerSpeed();
					}));
					groupModel6.Add(new SliderModel("Physical Damage", () => Game.Instance.Settings.Game.Flight.ImpactDamageScale.Value, delegate(float x)
					{
						Game.Instance.Settings.Game.Flight.ImpactDamageScale.UpdateAndCommit(x);
					}, 0f, 2f));
					groupModel6.Add(new SliderModel("Heat Damage", () => Game.Instance.Settings.Game.Flight.HeatDamageScale.Value, delegate(float x)
					{
						Game.Instance.Settings.Game.Flight.HeatDamageScale.UpdateAndCommit(x);
					}, 0f, 2f));
					groupModel6.Add(new SliderModel("Drag Scale", () => Game.Instance.Settings.Game.Flight.DragScale.Value, delegate(float x)
					{
						Game.Instance.Settings.Game.Flight.DragScale.UpdateAndCommit(x);
					}, 0f, 2f));
					groupModel6.Add(new SliderModel("Gravity Scale", () => Game.Instance.Settings.Game.Flight.GravityScale.Value, delegate(float x)
					{
						Game.Instance.Settings.Game.Flight.GravityScale.UpdateAndCommit(x);
					}, 0f, 10f));
				}
				else
				{
					groupModel6.Add(new TextButtonModel("Upgrade to Unlock Cheats", delegate
					{
						Game.Instance.InAppPurchases.CreatePurchaseDialog(cheatsFeature.ProductId);
					}));
				}
			}
			else
			{
				Game.InfiniteFuelEnabled = false;
			}
			inspectorModel.AddGroup(groupModel6);
			InspectorPanelCreationInfo inspectorPanelCreationInfo = new InspectorPanelCreationInfo();
			inspectorPanelCreationInfo.StartPosition = InspectorPanelCreationInfo.InspectorStartPosition.UpperRight;
			inspectorPanelCreationInfo.StartOffset = new Vector2(-170f, -90f);
			inspectorPanelCreationInfo.Resizable = !Device.IsMobileBuild;
			_inspectorPanel = Game.Instance.UserInterface.CreateInspectorPanel(inspectorModel, inspectorPanelCreationInfo);
			_inspectorPanel.CloseButtonClicked += delegate
			{
				Visible = false;
			};
		}

		protected virtual void Update()
		{
			_inspectorPanel.Visible = Visible && (_gameView.RenderView || _inspectorPanel.IsPinned);
			if (_inspectorPanel.Visible)
			{
				_viewModel.Update(PlayerCraft);
			}
		}

		private static void CreatePidOptionModels(string name, GroupModel model, Func<float> max, bool wholeNumbers, out SliderModel proportional, out SliderModel integral, out SliderModel deriv, Func<Vector3> getter, Action<Vector3> setter, Func<bool> determineVisibility)
		{
			proportional = new SliderModel("Proportional", () => getter().x / max(), delegate(float x)
			{
				Vector3 vector = getter();
				setter(new Vector3(x * max(), vector.y, vector.z));
			}, 0f, 1f, wholeNumbers: false, allowManualInput: false);
			proportional.ValueFormatter = (float x) => getter().x.ToString("0.#");
			proportional.DetermineVisibility = determineVisibility;
			proportional.Tooltip = "The primary value which dictates how strongly the auto-pilot reacts to errors.  Craft with large control lag will need proportional reduced considerably below the craft's maximum rate to get oscillation to an acceptable level.";
			integral = new SliderModel("Integral", () => getter().y / max(), delegate(float x)
			{
				Vector3 vector = getter();
				setter(new Vector3(vector.x, x * max(), vector.z));
			}, 0f, 1f, wholeNumbers: false, allowManualInput: false);
			integral.ValueFormatter = (float x) => getter().y.ToString("0.#");
			integral.DetermineVisibility = determineVisibility;
			integral.Tooltip = "Attempts to compensate for cases where the proportional is not sufficient to maintain the target. Not typically recommended for roll.";
			deriv = new SliderModel("Derivative", () => getter().z / max(), delegate(float x)
			{
				Vector3 vector = getter();
				setter(new Vector3(vector.x, vector.y, x * max()));
			}, 0f, 1f, wholeNumbers: false, allowManualInput: false);
			deriv.ValueFormatter = (float x) => getter().z.ToString("0.#");
			deriv.DetermineVisibility = determineVisibility;
			deriv.Tooltip = "Used to reduce overshooting/oscillations, although excessive amounts will introduce oscillation. Highly maneuverable crafts will not tolerate much if any derivative without introducing oscillation.";
			model.Add(proportional);
			model.Add(integral);
			model.Add(deriv);
		}

		private GroupModel CreateAutoPilotGroup()
		{
			GroupModel groupModel = new GroupModel("Auto-pilot");
			groupModel.Collapsed = true;
			if (Debug.isDebugBuild)
			{
				groupModel.Add(new TextModel("Pitch Pid", () => ActiveCommandPodData.Script.AutoPilot.PidGainsPitch.ToString()));
				groupModel.Add(new TextModel("Roll Pid", () => ActiveCommandPodData.Script.AutoPilot.PidGainsRoll.ToString()));
			}
			groupModel.Add(new TextModel(string.Empty, () => (ActiveCommandPodData.CraftConfiguration.Type != CrafConfigurationType.Plane) ? "PIDs" : "Pitch"));
			SliderModel proportional = null;
			SliderModel integral = null;
			SliderModel deriv = null;
			SliderModel sliderModel = new SliderModel("Range", () => ActiveCommandPodData.Script.AutoPilot.MaxPitchPidRange, delegate(float x)
			{
				ActiveCommandPodData.Script.AutoPilot.MaxPitchPidRange = (int)x;
			}, 1f, 200f, wholeNumbers: true, allowManualInput: false);
			sliderModel.Tooltip = "Adjusts the range of the PID sliders in the UI...does not impact flight performance.";
			sliderModel.ValueFormatter = (float x) => ActiveCommandPodData.Script.AutoPilot.MaxPitchPidRange.ToString();
			groupModel.Add(sliderModel);
			CreatePidOptionModels("Pitch", groupModel, () => ActiveCommandPodData.Script.AutoPilot.MaxPitchPidRange, wholeNumbers: true, out proportional, out integral, out deriv, () => ActiveCommandPodData.PidGainPitch, delegate(Vector3 x)
			{
				ActiveCommandPodData.PidGainPitch = x;
			}, () => true);
			groupModel.Add(new TextModel(string.Empty, () => "Roll", null, null, () => ActiveCommandPodData.CraftConfiguration.Type == CrafConfigurationType.Plane));
			SliderModel proportional2 = null;
			SliderModel integral2 = null;
			SliderModel deriv2 = null;
			SliderModel sliderModel2 = new SliderModel("Max", () => ActiveCommandPodData.Script.AutoPilot.MaxRollPidRange, delegate(float x)
			{
				ActiveCommandPodData.Script.AutoPilot.MaxRollPidRange = (int)x;
			}, 1f, 200f, wholeNumbers: true, allowManualInput: false);
			sliderModel2.ValueFormatter = (float x) => ActiveCommandPodData.Script.AutoPilot.MaxRollPidRange.ToString();
			sliderModel2.DetermineVisibility = () => ActiveCommandPodData.CraftConfiguration.Type == CrafConfigurationType.Plane;
			sliderModel2.Tooltip = "Adjusts the range of the PID sliders in the UI...does not impact flight performance.";
			groupModel.Add(sliderModel2);
			CreatePidOptionModels("Roll", groupModel, () => ActiveCommandPodData.Script.AutoPilot.MaxRollPidRange, wholeNumbers: true, out proportional2, out integral2, out deriv2, () => ActiveCommandPodData.PidGainRoll, delegate(Vector3 x)
			{
				ActiveCommandPodData.PidGainRoll = x;
			}, () => ActiveCommandPodData.CraftConfiguration.Type == CrafConfigurationType.Plane);
			if (Debug.isDebugBuild)
			{
				groupModel.Add(new TextModel(string.Empty, () => "Grav", null, null, () => ActiveCommandPodData.CraftConfiguration.Type == CrafConfigurationType.Plane));
				CreatePidOptionModels("Grav", groupModel, () => 10f, wholeNumbers: false, out var _, out var _, out var _, () => ActiveCommandPodData.Script.AutoPilot.PidGainsGrav, delegate(Vector3 x)
				{
					ActiveCommandPodData.Script.AutoPilot.PidGainsGrav = x;
				}, () => ActiveCommandPodData.CraftConfiguration.Type == CrafConfigurationType.Plane);
			}
			return groupModel;
		}

		private void OnNextDockingPortClicked()
		{
			SelectPart<DockingPortData>(searchAscending: true, _gameView.SelectedPart?.Data.Id, allowWrapAround: true);
		}

		private void OnPrevDockingPortClicked()
		{
			SelectPart<DockingPortData>(searchAscending: false, _gameView.SelectedPart?.Data.Id, allowWrapAround: true);
		}

		private void OnSelectActiveDockingPort()
		{
			if (_viewModel.ActiveDockingPort != null)
			{
				_gameView.SelectedPart = _viewModel.ActiveDockingPort.PartScript;
			}
		}

		private void SelectPart<T>(bool searchAscending, int? selectedId, bool allowWrapAround) where T : PartModifierData
		{
			int num = (searchAscending ? (-1) : 1000000);
			if (selectedId.HasValue)
			{
				num = selectedId.Value;
			}
			int num2 = 1000000;
			IPartScript partScript = null;
			foreach (PartData part in PlayerCraft.CraftScript.Data.Assembly.Parts)
			{
				if ((part.Id > num && searchAscending) || (part.Id < num && !searchAscending))
				{
					int num3 = Mathf.Abs(part.Id - num);
					if (num3 < num2 && part.GetModifier<T>() != null)
					{
						partScript = part.PartScript;
						num2 = num3;
					}
				}
			}
			if (partScript != null)
			{
				_gameView.SelectedPart = partScript;
			}
			else if (allowWrapAround)
			{
				SelectPart<T>(searchAscending, null, allowWrapAround: false);
			}
		}
	}
}
