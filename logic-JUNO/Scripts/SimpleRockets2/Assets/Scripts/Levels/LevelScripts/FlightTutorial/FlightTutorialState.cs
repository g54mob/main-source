using System;
using System.Collections.Generic;
using Assets.Packages.SocialPlatforms;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Levels.Requirements;
using Assets.Scripts.Menu.Tutorial;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight;
using ModApi.Flight.UI;
using ModApi.Input;
using ModApi.Levels.Requirements;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Levels.LevelScripts.FlightTutorial
{
	public class FlightTutorialState
	{
		private List<string> _buttonsClicked = new List<string>();

		private bool _pauseIfFailed;

		private string _stepText;

		private Dictionary<string, float> _timers = new Dictionary<string, float>();

		public bool ClearInstructionText { get; set; } = true;

		public MapViewScript MapView => FlightScene.ViewManager.MapViewManager.MapView as MapViewScript;

		public int MaxAllowableStage { get; private set; }

		public Action<string> OnPlayerLose { get; }

		public bool PauseImmediatelyAfterFailing { get; set; } = true;

		public int Step { get; private set; }

		public FlightTutorialPanelScript TutorialPanel { get; set; }

		private CraftControls Controls => Craft.CraftNode.Controls;

		private ICraftScript Craft { get; }

		private double CraftAltitude => Craft.CraftNode.Altitude;

		private IFlightScene FlightScene => Game.Instance.FlightScene;

		private IFlightSceneUI FlightSceneUI => FlightScene.FlightSceneUI;

		private bool MapViewVisible => !FlightScene.ViewManager.GameView.RenderView;

		private INavSphere NavSphere => FlightSceneUI.NavSphere;

		public FlightTutorialState(ICraftScript craft, Action<string> onPlayerLose)
		{
			Craft = craft;
			OnPlayerLose = onPlayerLose;
		}

		public void CompleteStep()
		{
			Step++;
			if (_pauseIfFailed)
			{
				Unpause();
			}
		}

		public FlightTutorialState DeselectPart()
		{
			Game.Instance.FlightScene.ViewManager.GameView.SelectedPart = null;
			return this;
		}

		public FlightTutorialState EnsureActivationGroupActive(int group)
		{
			return Ensure(() => Craft.PrimaryCommandPod.GetActivationGroupState(group), delegate
			{
				string name = $"ActivationPanel.AG{group}";
				TutorialPanel.HighlightUiElement(name, new Vector2(2f, 2f));
				return $"Press the '{group}. {Craft.PrimaryCommandPod.ActivationGroupNames[group - 1]}' button to enable it.";
			});
		}

		public FlightTutorialState EnsureActivationPanelOpen()
		{
			GameObject activationPanel = TutorialPanelBaseScript.FindFlightUiGameObject("ActivationPanel", includeInactive: true);
			return Ensure(() => activationPanel.activeInHierarchy, delegate
			{
				TutorialPanel.HighlightUiElement("NavPanel.ToggleActivationPanel", new Vector2(5f, 5f), highlightEvenIfInactive: true);
				return "Click on the Activation Panel icon on the right to open the Activation Panel.";
			});
		}

		public FlightTutorialState EnsureAnalogSticksVisible()
		{
			return this?.Ensure(delegate
			{
				FlightSceneInterfaceScript flightSceneInterfaceScript = Game.Instance.FlightScene.FlightSceneUI as FlightSceneInterfaceScript;
				return !Device.IsMobileBuild || flightSceneInterfaceScript.UiController.AnalogControlsVisible;
			}, delegate
			{
				TutorialPanel.HighlightUiElement("NavPanel.ToggleAnalogSticks", new Vector2(5f, 5f));
				return "Click on the highlighted button to show the analog sticks.";
			});
		}

		public FlightTutorialState EnsureApoapsisAltitude(double altitude)
		{
			double apoapsis = Craft.CraftNode.Orbit.ApoapsisDistance - Craft.CraftNode.Parent.PlanetData.Radius;
			return Ensure(() => apoapsis > altitude, () => $"Wait until your apoapsis is {Units.GetDistanceString((float)altitude)}");
		}

		public void EnsureBegin()
		{
			MapView.PlayerCraft.ManeuverNodeManager.ManeuverNodeCreationEnabled = false;
			_stepText = string.Empty;
			_pauseIfFailed = false;
			if (ClearInstructionText)
			{
				ShowMessage(string.Empty);
			}
			TutorialPanel.DisableHighlight();
			TutorialPanel.DisableButton();
		}

		public FlightTutorialState EnsureBrake(float value)
		{
			return EnsureAnalogInput(overrideString: (!Device.IsMobileBuild) ? ((value > 0f) ? "Press and hold '|Brake;+|' to engage the brakes." : "Release '|Brake;+|' to disengage the brakes.") : ((value > 0f) ? "Pull the left stick down to engage the brakes." : "Release the left stick to disengage the brakes."), value: value, currentValue: Controls.Brake, inputName: "Brake", analogStickName: "AnalogStick.Left", vertical: true);
		}

		public FlightTutorialState EnsureButtonClicked(string buttonId)
		{
			return Ensure(() => _buttonsClicked.Contains(buttonId), delegate
			{
				TutorialPanel.EnableButton(delegate
				{
					_buttonsClicked.Add(buttonId);
				});
				return string.Empty;
			});
		}

		public FlightTutorialState EnsureDocked(DockingRequirement dockRequirement)
		{
			return this?.Ensure(() => dockRequirement.Status == LevelRequirementStatus.Pass, delegate
			{
				if (dockRequirement.DockAmount > 0f)
				{
					return "Great! Now just wait for the docking ports to connect.";
				}
				if (Device.IsMobileBuild)
				{
					return "Use the left analog stick to move forward and backward. The right stick moves the craft up/down and left/right.";
				}
				if (SocialExt.IsSteamDeckOrBigPicture)
				{
					IGameInputs inputs = Game.Instance.Inputs;
					if (inputs.SwapRollYaw.IsBound)
					{
						bool flag = inputs.Yaw.GetControllerBindingText() != null;
						bool flag2 = inputs.Roll.GetControllerBindingText() != null;
						if (!flag || !flag2)
						{
							if (flag)
							{
								return "Press '|Pitch;+|', '|Pitch;-|', '|Yaw;-|', '|Yaw;+|' to move the craft up, down, left, and right. Press '|SwapRollYaw;+|' to swap Roll and Yaw inputs, then press '|Yaw;+|' and '|Yaw;-|' move the craft forward and backward.";
							}
							if (flag2)
							{
								return "Press '|Roll;+|' and '|Roll;-|' to move the craft forward and backward. Press '|Pitch;+|' and '|Pitch;-|' move the craft up and down. Press '|SwapRollYaw;+|' to swap Roll and Yaw inputs, then press '|Roll;-|' and '|Roll;+|' move the craft left and right.";
							}
						}
					}
				}
				return "Press '|Roll;+|' and '|Roll;-|' to move the craft forward and backward. Press '|Yaw;-|', '|Yaw;+|', '|Pitch;+|', and '|Pitch;-|' move the craft left, right, up, and down.";
			});
		}

		public FlightTutorialState EnsureFastForward()
		{
			return Ensure(() => FlightScene.TimeManager.CurrentMode.TimeMultiplier > 1.0 && !FlightScene.TimeManager.CurrentMode.WarpMode, delegate
			{
				TutorialPanel.HighlightUiElement("TimePanel.FastForward", new Vector2(0f, 0f), highlightEvenIfInactive: true);
				return "Select Fast Forward (in the top right) to speed things up";
			});
		}

		public FlightTutorialState EnsureGameView()
		{
			return EnsureMapView(visible: false);
		}

		public FlightTutorialState EnsureGravityTurn(int pitch, bool reduceThrottle, string message)
		{
			float throttle = 1f;
			string stepText = "The atmosphere is thinner at this altitude, so we can throttle back up to 100%";
			if (reduceThrottle)
			{
				throttle = 0.8f;
				stepText = "Turn the throttle down so we don't lose too much speed from high drag forces";
			}
			return this?.SetStepText(message)?.EnsureGameView()?.EnsureNavSphereSettings(90, pitch)?.SetStepText(stepText)?.EnsureThrottle(throttle);
		}

		public FlightTutorialState EnsureHeadingLock(bool locked = true)
		{
			return this?.EnsureNavSpherePanelVisible()?.Ensure(() => Controls.TargetHeading.HasValue == locked, delegate
			{
				TutorialPanel.HighlightUiElement("NavSpherePanel.LockNavSphere", new Vector2(5f, 5f));
				return "Click the Lock Heading button to " + (locked ? "enable" : "disable") + " Heading Lock.";
			});
		}

		public FlightTutorialState EnsureLockedOnIndicator(NavSphereIndicatorType indicator, bool locked, string text)
		{
			return this?.EnsureNavSpherePanelVisible()?.Ensure(() => NavSphere.LockedIndicator == indicator == locked, delegate
			{
				TutorialPanel.HighlightUiElement("NavSpherePanel.Lock" + indicator, new Vector2(5f, 5f));
				return text;
			});
		}

		public FlightTutorialState EnsureLockedOnPrograde(bool locked = true)
		{
			string text = (locked ? "Click the Lock Velocity Prograde button on the right to lock your heading on your prograde." : "Click the Lock Velocity Prograde button on the right to unlock your heading from prograde.");
			return EnsureLockedOnIndicator(NavSphereIndicatorType.VelocityPrograde, locked, text);
		}

		public FlightTutorialState EnsureLowTimeWarp(double minTimeToApoapsis)
		{
			if (Craft.CraftNode.Orbit.GetTimeToApoapsis() > minTimeToApoapsis)
			{
				return EnsureWarpMode();
			}
			return this;
		}

		public FlightTutorialState EnsureMapView(bool visible = true)
		{
			return Ensure(() => MapViewVisible == visible, delegate
			{
				if (Device.IsMobileBuild)
				{
					TutorialPanel.HighlightUiElement("ToggleMapView", new Vector2(2f, 2f));
					if (visible)
					{
						return "Tap the Toggle Map View button in the upper left to enter Map View";
					}
					return "Tap the Toggle Map View button in the upper left to exit Map View";
				}
				return visible ? "Press the '|ToggleMapView|' key to enter Map View" : "Press the '|ToggleMapView|' key to exit Map View";
			});
		}

		public FlightTutorialState EnsureMapViewZoom(float zoom, float epsilon)
		{
			MapViewScript mapView = MapView;
			bool focusedOnPlayer = mapView.MapCameraScript.Target == mapView.PlayerCraft;
			float delta = zoom - mapView.MapCameraScript.ZoomDistance;
			return Ensure(() => focusedOnPlayer && Mathf.Abs(delta) < epsilon, delegate
			{
				if (focusedOnPlayer)
				{
					if (delta > 0f)
					{
						return $"Zoom out a little farther";
					}
					return $"Zoom in closer on your craft";
				}
				if (TutorialPanel.HighlightUiElement(MapView.MapViewUi.MapViewInspector.SelectedModel.SelectPlayerButton, new Vector2(10f, 10f), highlightEvenIfInactive: false))
				{
					return "Click the Select Player button to focus on the player";
				}
				TutorialPanel.HighlightUiElement("NavPanel.ToggleInspector", new Vector2(5f, 5f));
				return "Click the button on the right to show the Map View Inspector window";
			});
		}

		public FlightTutorialState EnsureMinimumAltitude(float minimumAltitude)
		{
			return Ensure(() => CraftAltitude >= (double)minimumAltitude);
		}

		public FlightTutorialState EnsureNavballState(NavBallStateType target)
		{
			NavBallStateType current = (FlightSceneUI as FlightSceneInterfaceScript).UiController.NavBallState;
			return Ensure(() => current == target, delegate
			{
				if (target == NavBallStateType.Hidden)
				{
					TutorialPanel.HighlightUiElement("Flight.Nav.Close", new Vector2(2f, 2f));
					return $"Close the nav ball";
				}
				if (current == NavBallStateType.Hidden)
				{
					TutorialPanel.HighlightUiElement("Flight.Nav.Open", new Vector2(2f, 2f));
					return $"Open the nav ball";
				}
				TutorialPanel.HighlightUiElement("Flight.Nav.MapToggle", new Vector2(2f, 2f));
				return (target == NavBallStateType.Map) ? $"Switch to map mode." : $"Switch to nav mode.";
			});
		}

		public FlightTutorialState EnsureNavSphereHeading(int heading, int epsilon = 1)
		{
			return Ensure(() => Mathf.Abs(NavSphere.Heading - (float)heading) < (float)epsilon, () => $"Click and drag anywhere on the orange nav circle until your heading is set to {heading}°.");
		}

		public FlightTutorialState EnsureNavSphereHeadingEast(int epsilon = 1)
		{
			return Ensure(delegate
			{
				if (NavSphere.Pitch <= 88f)
				{
					return Mathf.Abs(NavSphere.Heading - 90f) < (float)epsilon;
				}
				return !(NavSphere.Pitch >= 92f) || Mathf.Abs(NavSphere.Heading + 90f) < (float)epsilon;
			}, () => $"Click and drag anywhere on the orange nav circle until your heading is set to 90° (East)");
		}

		public FlightTutorialState EnsureNavSpherePanelVisible()
		{
			return Ensure(() => TutorialPanelBaseScript.FindFlightUiGameObject("NavSpherePanel")?.activeInHierarchy ?? false, delegate
			{
				TutorialPanel.HighlightUiElement("NavPanel.ToggleNavSpherePanel", new Vector2(5f, 5f));
				return "Click the button on the right side of the screen to show the Nav Sphere Panel";
			});
		}

		public FlightTutorialState EnsureNavSpherePitch(int pitch, int epsilon = 1)
		{
			NavSphereScript navSphere = (NavSphereScript)NavSphere;
			navSphere.EnableTutorialIndicator(enabled: false, 0f);
			return Ensure(() => Mathf.Abs(NavSphere.Pitch - (float)pitch) < (float)epsilon, delegate
			{
				navSphere.EnableTutorialIndicator(enabled: true, pitch);
				return $"Click and drag anywhere on the blue nav circle until your pitch is set to {pitch}°.\nJust line up the blue triangle with the flashing yellow triangle.";
			});
		}

		public FlightTutorialState EnsureNavSphereSettings(int heading, int pitch)
		{
			return this?.EnsureNavSphereVisible(visible: true)?.EnsureHeadingLock()?.EnsureNavSpherePitch(pitch)?.EnsureNavSphereHeadingEast();
		}

		public FlightTutorialState EnsureNavSphereVisible(bool visible)
		{
			return this?.EnsureNavSpherePanelVisible()?.Ensure(() => Game.Instance.FlightScene.FlightSceneUI.NavSphereVisible == visible, delegate
			{
				TutorialPanel.HighlightUiElement("NavSpherePanel.ToggleNavSphere", new Vector2(5f, 5f));
				return visible ? "Click highlighted button to show the Nav Sphere" : "Click highlighted button to hide the Nav Sphere";
			});
		}

		public FlightTutorialState EnsureNoFuel()
		{
			return Ensure(() => Craft.FlightData.RemainingFuelInStage < 0.0001f);
		}

		public FlightTutorialState EnsureNotPaused()
		{
			_pauseIfFailed = false;
			return Ensure(() => !FlightScene.TimeManager.Paused, delegate
			{
				if (Device.IsMobileBuild)
				{
					TutorialPanel.HighlightUiElement("TimePanel.Play", new Vector2(0f, 0f));
					return "Tap the Play button in the top right to un-pause the game and continue";
				}
				return "Press the '|Pause|' key to un-pause the game and continue";
			});
		}

		public FlightTutorialState EnsureNotTimeWarp()
		{
			return Ensure(() => !FlightScene.TimeManager.CurrentMode.WarpMode);
		}

		public FlightTutorialState EnsurePartIsSelected(IPartScript partScript)
		{
			return this?.Ensure(delegate
			{
				if (Game.Instance.FlightScene.ViewManager.GameView.SelectedPart == partScript)
				{
					partScript.PartMaterialScript.IsHighlighted = false;
					return true;
				}
				return false;
			}, delegate
			{
				partScript.PartMaterialScript.IsHighlighted = true;
				return "Click on the highlighted docking port to select it.";
			});
		}

		public FlightTutorialState EnsurePartIsTargeted(IPartScript partScript)
		{
			return this?.Ensure(() => (Game.Instance.FlightScene.FlightSceneUI.NavSphere.Target == (INavSphereTarget)partScript) ? true : false, delegate
			{
				TutorialPanel.HighlightUiElement("PartInspectorPanel.TargetPart", new Vector2(5f, 5f));
				return "Click the Target Part button to target the docking port.";
			});
		}

		public FlightTutorialState EnsurePeriapsisAltitude(double altitude)
		{
			double periapsis = Craft.CraftNode.Orbit.PeriapsisDistance - Craft.CraftNode.Parent.PlanetData.Radius;
			return Ensure(() => periapsis > altitude, () => $"Wait until your periapsis is {Units.GetDistanceString((float)altitude)}");
		}

		public FlightTutorialState EnsurePitch(float value)
		{
			return EnsureAnalogInput(value, Controls.Pitch, "Pitch", "AnalogStick.Right", vertical: true);
		}

		public FlightTutorialState EnsureRoll(float value)
		{
			return EnsureAnalogInput(value, Controls.Roll, "Roll", "AnalogStick.Right", vertical: false);
		}

		public FlightTutorialState EnsureSliderVisible(string sliderName)
		{
			InputSliderPanelController sliderPanel = (FlightSceneUI as FlightSceneInterfaceScript).UiController.SliderPanel;
			return Ensure(() => sliderPanel.IsSliderVisible(sliderName), delegate
			{
				if (TutorialPanel.HighlightUiElement("InputSliderPanel.Add" + sliderName, new Vector2(2f, 2f)))
				{
					return string.Format("Click '" + sliderName + "' button to show the input slider");
				}
				TutorialPanel.HighlightUiElement("InputSliderPanel", new Vector2(2f, 2f));
				return $"Open the Add Slider panel in the bottom left";
			});
		}

		public FlightTutorialState EnsureStage(int stage, string failMessage, bool autoActivate = true)
		{
			MaxAllowableStage = Mathf.Max(stage, MaxAllowableStage);
			return Ensure(() => Craft.PrimaryCommandPod.CurrentStage >= stage, delegate
			{
				if (failMessage == null)
				{
					failMessage = string.Empty;
				}
				if (Device.IsMobileBuild)
				{
					TutorialPanel.HighlightUiElement("Staging.ActivateStage", new Vector2(0f, 0f));
					failMessage = failMessage.Replace("%ActivateInstruction%", "Tap the Activate Stage button in the bottom right");
				}
				else
				{
					failMessage = failMessage.Replace("%ActivateInstruction%", "Press '|ActivateStage|'");
				}
				if (autoActivate && CheckTimerPastTime($"Stage-{stage}", 7f))
				{
					Debug.LogFormat("Player took too long to activate the stage {0}.", stage);
					Craft.PrimaryCommandPod.ActivateStage();
					FlightSceneUI.ShowMessage("I went ahead and activated that stage for ya. You're welcome :)");
				}
				return failMessage;
			});
		}

		public FlightTutorialState EnsureTargetLock()
		{
			return this?.EnsureNavSpherePanelVisible()?.Ensure(() => NavSphere.LockedIndicator == NavSphereIndicatorType.Target, delegate
			{
				TutorialPanel.HighlightUiElement("NavSpherePanel.LockTarget", new Vector2(5f, 5f));
				return "Click the Lock Target button to lock the heading onto the target docking port.";
			});
		}

		public FlightTutorialState EnsureThrottle(float throttle, float epsilon = 0.02f)
		{
			float delta = throttle - Controls.Throttle;
			return Ensure(() => Mathf.Abs(delta) <= epsilon, delegate
			{
				if (Device.IsMobileBuild)
				{
					TutorialPanel.HighlightUiElement("Throttle.SliderPanel", new Vector2(8f, 10f), highlightEvenIfInactive: true);
					if (delta > 0f)
					{
						return $"Use the throttle slider on the left to increase throttle up to {Units.GetPercentageString(throttle)}";
					}
					return $"Use the throttle slider on the left to decrease throttle down to {Units.GetPercentageString(throttle)}";
				}
				TutorialPanel.HighlightUiElement("InstrumentPanel.Throttle", Vector2.zero, highlightEvenIfInactive: true);
				if (throttle == 0f)
				{
					if (SocialExt.IsSteamDeckOrBigPicture)
					{
						return $"Press and hold '|Throttle;-|' to kill your throttle completely";
					}
					return $"Press the '|KillThrottle|' key to kill your throttle immediately";
				}
				return (delta > 0f) ? $"Press and hold '|Throttle;+|' to throttle up to {Units.GetPercentageString(throttle)}" : $"Press and hold '|Throttle;-|' to throttle down to {Units.GetPercentageString(throttle)}";
			});
		}

		public FlightTutorialState EnsureTimeToApoapsis(double seconds, string failMessage)
		{
			double timeToApoapsis = Craft.CraftNode.Orbit.GetTimeToApoapsis();
			if (string.IsNullOrEmpty(failMessage))
			{
				failMessage = $"Time to apoapsis: {timeToApoapsis:n0} seconds";
			}
			return Ensure(() => timeToApoapsis < seconds, () => failMessage);
		}

		public FlightTutorialState EnsureTranslationModeEnabled()
		{
			return this?.Ensure(() => Game.Instance.FlightScene.CraftNode.CraftScript.PrimaryCommandPod.Controls.TranslationModeEnabled, delegate
			{
				TutorialPanel.HighlightUiElement("NavPanel.ToggleTranslationMode", new Vector2(5f, 5f));
				return "Click on the highlighted button to enable Translation Mode.";
			});
		}

		public FlightTutorialState EnsureWarpMode()
		{
			return Ensure(() => FlightScene.TimeManager.CurrentMode.TimeMultiplier <= 25.0 && FlightScene.TimeManager.CurrentMode.WarpMode, delegate
			{
				if (FlightScene.TimeManager.CurrentMode.TimeMultiplier > 25.0)
				{
					PauseGame();
				}
				TutorialPanel.HighlightUiElement("TimePanel.Warp", new Vector2(0f, 0f), highlightEvenIfInactive: true);
				return "Select Time Warp (in the top right) to REALLY speed things up";
			});
		}

		public FlightTutorialState EnsureYaw(float value)
		{
			return EnsureAnalogInput(value, Controls.Yaw, "Yaw", "AnalogStick.Left", vertical: false);
		}

		public void Fail()
		{
			Ensure(() => false);
		}

		public void PauseIfNecessary()
		{
			if (_pauseIfFailed)
			{
				PauseGame();
			}
		}

		public FlightTutorialState SetPauseIfFailed(bool value)
		{
			_pauseIfFailed = value;
			return this;
		}

		public FlightTutorialState SetStepLimits(int loseAltitude, int skipAltitude)
		{
			if (CraftAltitude > (double)skipAltitude && skipAltitude != 0)
			{
				Debug.LogFormat("Skipping step: {0}. Altitude {1} < {2}", Step, CraftAltitude, skipAltitude);
				CompleteStep();
				return null;
			}
			if (CraftAltitude < (double)loseAltitude && loseAltitude != 0)
			{
				Debug.LogFormat("Losing at step: {0}. Altitude {1} < {2}", Step, CraftAltitude, loseAltitude);
				OnPlayerLose?.Invoke("Your altitude dropped too low. Please, try again. You can do it!");
				return null;
			}
			return this;
		}

		public FlightTutorialState SetStepText(string stepText)
		{
			_stepText = UiUtilities.ProcessStringWithInputs(stepText);
			return this;
		}

		public void ShowMessage(string message, params object[] args)
		{
			TutorialPanel.InstructionText = string.Format(UiUtilities.ProcessStringWithInputs(message), args);
		}

		public void Unpause()
		{
			FlightScene.TimeManager.RequestPauseChange(paused: false, userInitiated: false);
		}

		public FlightTutorialState WaitForTimer(string name, float time)
		{
			return Ensure(() => CheckTimerPastTime(name, time));
		}

		private bool CheckTimerPastTime(string name, float time)
		{
			if (!_timers.ContainsKey(name))
			{
				_timers[name] = 0f;
			}
			if (_timers[name] < time)
			{
				_timers[name] += Time.deltaTime;
				return false;
			}
			return true;
		}

		private FlightTutorialState Ensure(Func<bool> condition, Func<string> failMessage = null)
		{
			if (condition())
			{
				ShowMessage(string.Empty);
				TutorialPanel.DisableHighlight();
				return this;
			}
			if (PauseImmediatelyAfterFailing)
			{
				PauseIfNecessary();
			}
			if (_stepText != null)
			{
				TutorialPanel.StepText = _stepText;
			}
			string message = ((failMessage != null) ? failMessage() : string.Empty);
			ShowMessage(message);
			return null;
		}

		private FlightTutorialState EnsureAnalogInput(float value, float currentValue, string inputName, string analogStickName, bool vertical, string overrideString = null, float epsilon = 0.02f)
		{
			float delta = value - currentValue;
			return Ensure(() => Mathf.Abs(delta) <= epsilon, delegate
			{
				if (Device.IsMobileBuild)
				{
					if (TutorialPanel.HighlightUiElement(analogStickName, vertical ? new Vector2(-80f, 60f) : new Vector2(60f, -80f)))
					{
						if (delta > 0f)
						{
							return overrideString ?? ("Slide the thumb stick " + (vertical ? "up" : "right") + " and increase " + inputName + " to " + Units.GetPercentageString(value) + ".\nCurrent " + inputName + ": " + Units.GetPercentageString(currentValue));
						}
						return overrideString ?? ("Slide the thumb stick " + (vertical ? "down" : "left") + " and decrease " + inputName + " to " + Units.GetPercentageString(value) + ".\nCurrent " + inputName + ": " + Units.GetPercentageString(currentValue));
					}
					TutorialPanel.HighlightUiElement("NavPanel.ToggleAnalogSticks", new Vector2(8f, 8f), highlightEvenIfInactive: true);
					return "Click the joystick button to display the analog sticks.";
				}
				string text = inputName;
				if (SocialExt.IsSteamDeckOrBigPicture)
				{
					IGameInputs inputs = Game.Instance.Inputs;
					bool isBound = inputs.SwapRollYaw.IsBound;
					bool flag = inputs.Yaw.GetControllerBindingText() != null;
					bool flag2 = inputs.Roll.GetControllerBindingText() != null;
					bool swapRollYaw = FlightSceneScript.Instance.FlightControls.SwapRollYaw;
					if (inputName == "Yaw" && isBound)
					{
						if (flag)
						{
							if (swapRollYaw)
							{
								return overrideString ?? "Press '|SwapRollYaw;|' to swap the 'Roll' and the 'Yaw' inputs.";
							}
						}
						else if (flag2)
						{
							if (!swapRollYaw)
							{
								return overrideString ?? "Press '|SwapRollYaw;|' to swap the 'Roll' and the 'Yaw' inputs.";
							}
							text = "Roll";
						}
					}
					else if (inputName == "Roll" && isBound)
					{
						if (flag2)
						{
							if (swapRollYaw)
							{
								return overrideString ?? "Press '|SwapRollYaw;|' to swap the 'Roll' and the 'Yaw' inputs.";
							}
						}
						else if (flag)
						{
							if (!swapRollYaw)
							{
								return overrideString ?? "Press '|SwapRollYaw;|' to swap the 'Roll' and the 'Yaw' inputs.";
							}
							text = "Yaw";
						}
					}
				}
				return (delta > 0f) ? (overrideString ?? ("Press and hold '|" + text + ";+|' to increase " + inputName + " to " + Units.GetPercentageString(value) + ".\nCurrent " + inputName + ": " + Units.GetPercentageString(currentValue))) : (overrideString ?? ("Press and hold '|" + text + ";-|' to decrease " + inputName + " to " + Units.GetPercentageString(value) + ".\nCurrent " + inputName + ": " + Units.GetPercentageString(currentValue)));
			});
		}

		private void PauseGame()
		{
			if (FlightScene.TimeManager.CurrentMode.TimeMultiplier != 0.0)
			{
				FlightScene.TimeManager.RequestPauseChange(paused: true, userInitiated: false);
			}
		}
	}
}
