using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Input.Attributes;
using Rewired;
using UnityEngine;

namespace Assets.Scripts.Input
{
	public class GameInputs
	{
		private static GameInputs _instance;

		private Dictionary<string, List<string>> _categoryActionMap;

		private Dictionary<string, IGameInput> _inputLookupByName;

		public static GameInputs Instance
		{
			get
			{
				if (_instance == null)
				{
					Initialize();
				}
				return _instance;
			}
		}

		[InputCategory("Craft")]
		public IGameInput Activate1 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Activate2 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Activate3 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Activate4 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Activate5 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Activate6 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Activate7 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Activate8 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput ActivateCameraLook { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Brake { get; private set; }

		[InputCategory("Craft")]
		[InputCategory("Character")]
		public IGameInput CameraLookBack { get; private set; }

		[InputCategory("Craft")]
		[InputCategory("Character")]
		public IGameInput CameraLookLeftRight { get; private set; }

		[InputCategory("Craft")]
		[InputCategory("Character")]
		public IGameInput CameraLookUpDown { get; private set; }

		[InputCategory("Craft")]
		[InputCategory("Character")]
		public IGameInput CameraLookZoom { get; private set; }

		[InputCategory("Craft")]
		[InputCategory("Character")]
		public IGameInput CameraRecenter { get; private set; }

		[InputCategory("Craft")]
		public IGameInput ChaseView { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ClearConcealedPartsList { get; private set; }

		[InputCategory("Craft")]
		public IGameInput CockpitView { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ConcealPart { get; private set; }

		[InputCategory("Character")]
		public IGameInput Crouch { get; private set; }

		[InputCategory("Craft")]
		public IGameInput CustomCamera1 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput CustomCamera2 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput CustomCamera3 { get; private set; }

		[InputCategory("Craft")]
		public IGameInput CustomCamera4 { get; private set; }

		[InputCategory("Designer")]
		public IGameInput CycleConcealmentType { get; private set; }

		[InputCategory("Craft")]
		public IGameInput CycleTargetingMode { get; private set; }

		[InputCategory("Craft")]
		public IGameInput DamageVisualizer { get; private set; }

		[InputCategory("Character")]
		public IGameInput Dance { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DeletePart { get; private set; }

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
		public IGameInput DesignerManipulatePartNegative { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerManipulatePartNextMode { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerManipulatePartPositive { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerManipulatePartPreviousMode { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerPartSelectAndFocus { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerPitch { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerRoll { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerSinglePartModifier { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerToggleMenu { get; private set; }

		[InputCategory("Designer")]
		public IGameInput DesignerYaw { get; private set; }

		[InputCategory("Other")]
		public IGameInput DeveloperConsole { get; private set; }

		[InputCategory("World")]
		public IGameInput EnterExitCraft { get; private set; }

		[InputCategory("Craft")]
		public IGameInput FireGuns { get; private set; }

		[InputCategory("Craft")]
		public IGameInput FireWeapons { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Flaps { get; private set; }

		[InputCategory("Craft")]
		public IGameInput FlapsReset { get; private set; }

		[InputCategory("World")]
		public IGameInput FlightToggleMenu { get; private set; }

		[InputCategory("Craft")]
		public IGameInput FlybyView { get; private set; }

		[InputCategory("World")]
		public IGameInput Interact { get; private set; }

		[InputCategory("Designer")]
		public IGameInput InvertConcealedParts { get; private set; }

		[InputCategory("Character")]
		public IGameInput Jump { get; private set; }

		[InputCategory("Craft")]
		public IGameInput LandingGear { get; private set; }

		[InputCategory("Craft")]
		public IGameInput LaunchCountermeasures { get; private set; }

		[InputCategory("Other")]
		public IGameInput LoadClipboardAircraft { get; private set; }

		[InputCategory("Craft")]
		public IGameInput MaxThrottle { get; private set; }

		public bool MouseWheelAlwaysZooms { get; private set; }

		[InputCategory("Designer")]
		public IGameInput MoveTool { get; private set; }

		[InputCategory("Character")]
		public IGameInput MoveX { get; private set; }

		[InputCategory("Character")]
		public IGameInput MoveY { get; private set; }

		[InputCategory("Craft")]
		public IGameInput NextTarget { get; private set; }

		[InputCategory("Craft")]
		[InputCategory("Character")]
		public IGameInput NextView { get; private set; }

		[InputCategory("Craft")]
		public IGameInput NextWeapon { get; private set; }

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

		[InputCategory("Craft")]
		public IGameInput OrbitView { get; private set; }

		[InputCategory("World")]
		public IGameInput Pause { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Pitch { get; private set; }

		[InputCategory("Craft")]
		public IGameInput PreviousTarget { get; private set; }

		[InputCategory("Craft")]
		public IGameInput PreviousView { get; private set; }

		[InputCategory("Craft")]
		public IGameInput PreviousWeapon { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ReattachSelectedPart { get; private set; }

		[InputCategory("Designer")]
		public IGameInput Redo { get; private set; }

		[InputCategory("World")]
		public IGameInput RepositionAndUprightCraft { get; private set; }

		[InputCategory("World")]
		public IGameInput Restart { get; private set; }

		[InputCategory("World")]
		public IGameInput RestartHere { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Roll { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotateNegativeX { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotateNegativeY { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotateNegativeZ { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotatePositiveX { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotatePositiveY { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotatePositiveZ { get; private set; }

		[InputCategory("Designer")]
		public IGameInput RotateTool { get; private set; }

		[InputCategory("Character")]
		public IGameInput Run { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SaveAircraft { get; private set; }

		[InputCategory("World")]
		public IGameInput ScreenshotMode { get; private set; }

		[InputCategory("Craft")]
		public IGameInput SelfDestruct { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SymmetryInitialStateToggle { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SymmetryMultiPartToggle { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SymmetryPanelToggle { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SymmetrySinglePartToggle { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SymmetryUnlinkedMultiPart { get; private set; }

		[InputCategory("Designer")]
		public IGameInput SymmetryUnlinkedSinglePart { get; private set; }

		[InputCategory("Craft")]
		public IGameInput TargetingPodSlewLeftRight { get; private set; }

		[InputCategory("Craft")]
		public IGameInput TargetingPodSlewUpDown { get; private set; }

		[InputCategory("Craft")]
		public IGameInput TargetingPodZoom { get; private set; }

		[InputCategory("World")]
		public IGameInput TeleportDown { get; private set; }

		[InputCategory("World")]
		public IGameInput TeleportUp { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Throttle { get; private set; }

		[InputCategory("Craft")]
		public IGameInput ToggleActivationPanel { get; private set; }

		[InputCategory("Craft")]
		public IGameInput ToggleAutopilot { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ToggleBlueprintsPanel { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ToggleCenterBalls { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ToggleCuttingVisibility { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ToggleDecalVisibility { get; private set; }

		[InputCategory("World")]
		public IGameInput ToggleFastForward { get; private set; }

		[InputCategory("Craft")]
		public IGameInput ToggleGhost { get; private set; }

		[InputCategory("Craft")]
		public IGameInput ToggleMouseJoystick { get; private set; }

		[InputCategory("Character")]
		public IGameInput ToggleMouseLook { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ToggleOrtho { get; private set; }

		[InputCategory("Designer")]
		public IGameInput TogglePaintPanel { get; private set; }

		[InputCategory("Craft")]
		public IGameInput ToggleParkingBrake { get; private set; }

		[InputCategory("Designer")]
		public IGameInput TogglePartPropertiesPanel { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ToggleSearchPartsPanel { get; private set; }

		[InputCategory("World")]
		public IGameInput ToggleSlowMotion { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ToggleTransformPartPanel { get; private set; }

		[InputCategory("World")]
		public IGameInput ToggleWindSettings { get; private set; }

		[InputCategory("Designer")]
		public IGameInput TranslateTool { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Trim { get; private set; }

		[InputCategory("Craft")]
		public IGameInput TrimReset { get; private set; }

		[InputCategory("Other")]
		public IGameInput UICancel { get; private set; }

		[InputCategory("Other")]
		public IGameInput UIHorizontal { get; private set; }

		[InputCategory("Other")]
		public IGameInput UISubmit { get; private set; }

		[InputCategory("Other")]
		public IGameInput UIVertical { get; private set; }

		[InputCategory("Designer")]
		public IGameInput Undo { get; private set; }

		[InputCategory("Designer")]
		public IGameInput ViewTool { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Vtol { get; private set; }

		[InputCategory("Craft")]
		public IGameInput Yaw { get; private set; }

		[InputCategory("Craft")]
		public IGameInput ZeroThrottle { get; private set; }

		private GameInputs()
		{
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

		private static void Initialize()
		{
			_instance = new GameInputs();
			Dictionary<string, IGameInput> dictionary = new Dictionary<string, IGameInput>();
			_instance._inputLookupByName = dictionary;
			Dictionary<string, List<string>> dictionary2 = new Dictionary<string, List<string>>();
			_instance._categoryActionMap = dictionary2;
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
				propertyInfo.SetValue(_instance, value, null);
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
				item.SetValue(_instance, new DummyInput(item.Name), null);
			}
			ReInput.ControllerConnectedEvent += _instance.OnControllerConnect;
			ReInput.ControllerDisconnectedEvent += _instance.OnControllerDisconnect;
			InputWrapper.OnControlsChanged += _instance.OnControlsChanged;
		}

		private void DoMouseWheelZoomHackyFixThingy()
		{
			Player player = InputWrapper.Player;
			if (!player.controllers.maps.ElementMapsWithAction(ControllerType.Mouse, CameraLookZoom.Id, skipDisabledMaps: false).Any())
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

		private void InitializeCustomModifier(IGameInput modifierInput, params IGameInput[] modifierActivatedInputs)
		{
			Player player = InputWrapper.Player;
			bool flag = player.controllers.maps.GetFirstElementMapWithAction(modifierInput.Id, skipDisabledMaps: true) != null;
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
										if (!modifierActivatedInputs.Contains(gameInput2))
										{
											gameInput2.SetCustomModifier(() => !modifierInput.GetButtonIfEnabled());
										}
									}
									else
									{
										gameInput2.SetCustomModifier(() => true);
									}
								}
							}
						}
						if (flag)
						{
							if (list2.Count != 0)
							{
								gameInput.SetCustomModifier(() => modifierInput.GetButtonIfEnabled());
							}
						}
						else if (list2.Count > 0)
						{
							gameInput.SetCustomModifier(() => false);
						}
					}
				}
			}
		}

		private void OnControllerConnect(ControllerStatusChangedEventArgs obj)
		{
			OnControlsChanged(this, new EventArgs());
		}

		private void OnControllerDisconnect(ControllerStatusChangedEventArgs obj)
		{
			OnControlsChanged(this, new EventArgs());
		}

		private void OnControlsChanged(object sender, EventArgs e)
		{
			ResetCustomModifiers();
			InitializeCustomModifier(ActivateCameraLook, CameraLookLeftRight, CameraLookUpDown, CameraLookBack, CameraLookZoom);
			DoMouseWheelZoomHackyFixThingy();
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
