using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Input.Attributes;
using ModApi.Input;
using Rewired;
using UnityEngine;

namespace Assets.Scripts.Input
{
	public class GameInputs : IGameInputs
	{
		private Dictionary<string, List<string>> _categoryActionMap;

		private Dictionary<string, IGameInput> _inputLookupByName;

		[InputCategory("PlanetStudio")]
		public IGameInput AccelerateMovementModifier { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput ActivateCameraLook { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivateStage { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivationGroup1 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivationGroup10 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivationGroup2 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivationGroup3 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivationGroup4 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivationGroup5 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivationGroup6 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivationGroup7 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivationGroup8 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ActivationGroup9 { get; private set; }

		public IReadOnlyList<IGameInput> AllInputs => _inputLookupByName.Values.ToList();

		[InputCategory("FlightCraft")]
		public IGameInput Brake { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		[InputCategory("PlanetStudio")]
		public IGameInput CameraLookLeftRight { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		[InputCategory("PlanetStudio")]
		public IGameInput CameraLookUpDown { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput CameraLookZoom { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput CameraRollLeftRight { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput CameraSwapLeftRightRoll { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput CameraSwapUpDownZoom { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput CommandPodNext { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput CommandPodPrevious { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput DecelerateMovementModifier { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput DecreaseRotationalSpeed { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput DecreaseSpeed { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DeleteSelectedPart { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerCameraInOut { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerCameraLeftRight { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerCameraRotateLeftRight { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerCameraRotateUpDown { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerCameraSwitchMode { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerCameraTranslateInOut { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerCameraTranslateLeftRight { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerCameraTranslateUpDown { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerCameraUpDown { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerCameraZoom { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerDeselectPart { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerFlyoutNext { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerFlyoutPrevious { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerManipulatePartNegative { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerManipulatePartNextMode { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerManipulatePartPositive { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerManipulatePartPreviousMode { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerToggleMenu { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerTogglePartProperties { get; private set; }

		[InputCategory("Other")]
		public IGameInput DeveloperConsole { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaEnableJetpackMovement { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaJump { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaMoveFwdAft { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaMoveUpDown { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaMoveUpDownNoModifier { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaPitch { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaPitchNoModifier { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaRoll { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaRollNoModifier { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput EvaShootTether { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaStrafe { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput EvaTetherLength { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaToggleWalk { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput EvaTurn { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput FlightOpenMenu { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput FullThrottle { get; private set; }

		[InputCategory("Designer")]
		public IGameInput GroupParts { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput IncreaseRotationalSpeed { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput IncreaseSpeed { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput KillThrottle { get; private set; }

		[InputCategory("Other")]
		public IGameInput LoadContentFromClipboardUrl { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput LockHeading { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput LockPrograde { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput LockRetrograde { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput LockTarget { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput MapSetTargetModifier { get; private set; }

		[InputCategory("Designer")]
		public IGameInput MirrorSelectedPart { get; private set; }

		public bool MouseWheelAlwaysZooms { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput MoveCameraBackward { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput MoveCameraDown { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput MoveCameraForward { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput MoveCameraLeft { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput MoveCameraRight { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput MoveCameraUp { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput NextCameraMode { get; private set; }

		[InputCategory("Designer")]
		public IGameInput NudgePartNegativeX { get; private set; }

		[InputCategory("Designer")]
		public IGameInput NudgePartNegativeY { get; private set; }

		[InputCategory("Designer")]
		public IGameInput NudgePartNegativeZ { get; private set; }

		[InputCategory("Designer")]
		public IGameInput NudgePartPositiveX { get; private set; }

		[InputCategory("Designer")]
		public IGameInput NudgePartPositiveY { get; private set; }

		[InputCategory("Designer")]
		public IGameInput NudgePartPositiveZ { get; private set; }

		[InputCategory("Other")]
		public IGameInput OpenPhotoLibrary { get; private set; }

		[InputCategory("Designer")]
		public IGameInput OpenSymmetryTool { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput Pause { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput Pitch { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput PlanetStudioMovementModeNext { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput PlanetStudioMovementModePrevious { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput PlanetStudioOpenMenu { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput PlanetStudioRebuildPlanet { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput PlanetStudioRecenterCamera { get; private set; }

		[InputCategory("Designer")]
		public IGameInput PreventPartSelection { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput PreviousCameraMode { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput QuickLoad { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput QuickSave { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ReattachSelectedPart { get; private set; }

		[InputCategory("Designer")]
		[InputCategory("PlanetStudio")]
		public IGameInput Redo { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput ResetSunTiltAngle { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput Roll { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput RollCameraLeft { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput RollCameraRight { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput RotateCameraDown { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput RotateCameraLeft { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput RotateCameraRight { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput RotateCameraUp { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotateNegativeX { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotateNegativeY { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotateNegativeZ { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput RotatePlanetLeft { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput RotatePlanetRight { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotatePositiveX { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotatePositiveY { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotatePositiveZ { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput RotateWithPlanetLeft { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput RotateWithPlanetRight { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SaveDesign { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput SaveLaunchLocation { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SelectFuselageShapeTool { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SelectMovePartTool { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SelectNudgeTool { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SelectPaintTool { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SelectRotateTool { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput Slider1 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput Slider2 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput Slider3 { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput Slider4 { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput SnapToGround { get; private set; }

		[InputCategory("FlightEva")]
		public IGameInput SwapEvaStrafeTurn { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput SwapRollYaw { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SymmetryModeNext { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SymmetryModePrevious { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput Throttle { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput TiltSunDown { get; private set; }

		[InputCategory("PlanetStudio")]
		public IGameInput TiltSunUp { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput TimeWarpDecrease { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput TimeWarpIncrease { get; private set; }

		[InputCategory("Other")]
		public IGameInput ToggleHideUI { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput ToggleMapView { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput ToggleMouseJoystick { get; private set; }

		[InputCategory("Other")]
		public IGameInput ToggleMusic { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput ToggleNavSphere { get; private set; }

		[InputCategory("Designer")]
		public IGameInput TogglePartConnectionsPanel { get; private set; }

		[InputCategory("Designer")]
		public IGameInput TogglePerformanceAnalyzer { get; private set; }

		[InputCategory("FlightCommon")]
		[InputCategory("FlightCraft")]
		[InputCategory("FlightEva")]
		public IGameInput ToggleTranslationMode { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ToolModifier { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput TranslateForwardBackward { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput TranslateLeftRight { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput TranslateUpDown { get; private set; }

		[InputCategory("Default")]
		public IGameInput UICancel { get; private set; }

		[InputCategory("Default")]
		public IGameInput UIHorizontal { get; private set; }

		[InputCategory("Default")]
		public IGameInput UISubmit { get; private set; }

		[InputCategory("Default")]
		public IGameInput UIVertical { get; private set; }

		[InputCategory("Designer")]
		[InputCategory("PlanetStudio")]
		public IGameInput Undo { get; private set; }

		[InputCategory("FlightCraft")]
		public IGameInput Yaw { get; private set; }

		private GameInputs()
		{
		}

		public static IGameInputs Create()
		{
			return Initialize();
		}

		public IGameInput FindById(string id)
		{
			id = id.ToLower();
			if (_inputLookupByName.ContainsKey(id))
			{
				return _inputLookupByName[id];
			}
			return null;
		}

		public bool IsActionInMapCategory(string mapCategoryName, string actionName)
		{
			if (_categoryActionMap.TryGetValue(mapCategoryName, out var value))
			{
				return value.Contains(actionName);
			}
			return false;
		}

		private static GameInputs Initialize()
		{
			GameInputs gameInputs = new GameInputs();
			Dictionary<string, IGameInput> dictionary = (gameInputs._inputLookupByName = new Dictionary<string, IGameInput>());
			Dictionary<string, List<string>> dictionary2 = (gameInputs._categoryActionMap = new Dictionary<string, List<string>>());
			List<string> allActionIds = InputWrapper.GetAllActionIds();
			List<PropertyInfo> list = (from x in typeof(GameInputs).GetProperties()
				where x.PropertyType == typeof(IGameInput)
				select x).ToList();
			foreach (string action in allActionIds)
			{
				PropertyInfo propertyInfo = list.FirstOrDefault((PropertyInfo x) => x.Name.ToLower() == action.ToLower());
				if (propertyInfo == null)
				{
					Debug.LogWarningFormat("The action '{0}' is defined, but an associated input property could not be found.", action);
					continue;
				}
				GameInput value = new GameInput(action);
				propertyInfo.SetValue(gameInputs, value, null);
				list.Remove(propertyInfo);
				dictionary.Add(action.ToLower(), value);
				object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(InputCategoryAttribute), inherit: false);
				for (int num = 0; num < customAttributes.Length; num++)
				{
					InputCategoryAttribute inputCategoryAttribute = (InputCategoryAttribute)customAttributes[num];
					if (!dictionary2.TryGetValue(inputCategoryAttribute.Category, out var value2))
					{
						value2 = new List<string>();
						dictionary2.Add(inputCategoryAttribute.Category, value2);
					}
					value2.Add(action);
				}
			}
			foreach (PropertyInfo item in list)
			{
				Debug.LogWarningFormat("An input property is defined for '{0}' but no action by that name could be found.", item.Name);
				item.SetValue(gameInputs, new DummyInput(item.Name), null);
			}
			InputWrapper.ControlMapsChanged += gameInputs.OnControlMapsChanged;
			return gameInputs;
		}

		private void DoMouseWheelZoomHackyFixThingy()
		{
			Player player = InputWrapper.Player;
			if (player.controllers.maps.ElementMapsWithAction(ControllerType.Mouse, CameraLookZoom.Id, skipDisabledMaps: false).Count() == 0)
			{
				MouseWheelAlwaysZooms = false;
				return;
			}
			int num = 0;
			int num2 = 0;
			foreach (ControllerMap allMap in player.controllers.maps.GetAllMaps(ControllerType.Mouse))
			{
				foreach (string item in (from x in allMap.AllMaps
					select (x.elementIdentifierName ?? string.Empty).ToLower().Replace(" ", string.Empty) into x
					where x.Contains("mousewheel")
					select x).ToList())
				{
					switch (item)
					{
					case "mousewheel":
						num++;
						num2++;
						break;
					case "mousewheel+":
						num++;
						break;
					case "mousewheel-":
						num2++;
						break;
					}
				}
			}
			MouseWheelAlwaysZooms = num <= 1 && num2 <= 1;
		}

		private void IdentifyUnboundActions()
		{
			foreach (GameInput value in _inputLookupByName.Values)
			{
				ActionElementMap firstButtonMapWithAction = InputWrapper.Player.controllers.maps.GetFirstButtonMapWithAction(value.ActionId, skipDisabledMaps: false);
				value.IsBound = firstButtonMapWithAction != null;
			}
		}

		private void InitializeCustomModifier(IGameInput modifierInput, params IGameInput[] modifierActivatedInputs)
		{
			InitializeCustomModifier(modifierInput, () => modifierInput.GetButtonIfEnabled(), () => !modifierInput.GetButtonIfEnabled(), modifierActivatedInputs);
		}

		private void InitializeCustomModifier(IGameInput modifierInput, Func<bool> activatedInputModifierCheck, Func<bool> conflictedInputModifierCheck, params IGameInput[] modifierActivatedInputs)
		{
			Player player = InputWrapper.Player;
			ActionElementMap firstElementMapWithAction = player.controllers.maps.GetFirstElementMapWithAction(modifierInput.Id, skipDisabledMaps: true);
			bool flag = firstElementMapWithAction != null && firstElementMapWithAction.elementIdentifierId != -1;
			List<ControllerMap> list = (from m in player.controllers.maps.GetAllMaps()
				where m.enabled
				select m).ToList();
			for (int num = 0; num < modifierActivatedInputs.Length; num++)
			{
				GameInput gameInput = (GameInput)modifierActivatedInputs[num];
				foreach (ControllerMap item in list)
				{
					foreach (ActionElementMap item2 in item.ElementMapsWithAction(gameInput.Id))
					{
						List<ElementAssignmentConflictInfo> list2 = ReInput.controllers.conflictChecking.ElementAssignmentConflicts(player.id, item.controllerType, item.controllerId, item, item2, skipDisabledMaps: true, forceCheckAllCategories: false, includeSystemPlayer: true).ToList();
						if (flag)
						{
							foreach (ElementAssignmentConflictInfo conflict in list2)
							{
								foreach (ControllerMap item3 in list.Where((ControllerMap m) => m.controllerType == conflict.controllerType && m.controllerId == conflict.controllerId))
								{
									ActionElementMap elementMap = item3.GetElementMap(conflict.elementMapId);
									if (elementMap == null)
									{
										continue;
									}
									InputAction action = ReInput.mapping.GetAction(elementMap.actionId);
									GameInput gameInput2 = (GameInput)FindById(action.name);
									if (gameInput2 != modifierInput)
									{
										gameInput2.SetCustomModifier(conflictedInputModifierCheck);
										continue;
									}
									gameInput2.SetCustomModifier(() => true);
								}
							}
						}
						if (flag)
						{
							gameInput.SetCustomModifier(activatedInputModifierCheck);
						}
						else
						{
							if (list2.Count <= 0)
							{
								continue;
							}
							int num2 = 0;
							foreach (ElementAssignmentConflictInfo conflict2 in list2)
							{
								foreach (ControllerMap item4 in list.Where((ControllerMap m) => m.controllerType == conflict2.controllerType && m.controllerId == conflict2.controllerId))
								{
									if (item4.GetElementMap(conflict2.elementMapId) != null)
									{
										num2++;
									}
								}
							}
							if (num2 > 0)
							{
								gameInput.SetCustomModifier(() => false);
							}
						}
					}
				}
			}
		}

		private void InitializeCustomToggleModifier(IGameInput modifierInput, params IGameInput[] modifierActivatedInputs)
		{
			InitializeCustomModifier(modifierInput, () => modifierInput.Enabled, () => !modifierInput.Enabled, modifierActivatedInputs);
		}

		private void OnControlMapsChanged(object sender, EventArgs e)
		{
			ResetCustomModifiers();
			InitializeCustomToggleModifier(ActivateCameraLook, CameraLookLeftRight, CameraLookUpDown, CameraLookZoom);
			DoMouseWheelZoomHackyFixThingy();
			IdentifyUnboundActions();
		}

		private void ResetCustomModifiers()
		{
			foreach (GameInput value in _inputLookupByName.Values)
			{
				value.ResetCustomModifier();
			}
		}
	}
}
