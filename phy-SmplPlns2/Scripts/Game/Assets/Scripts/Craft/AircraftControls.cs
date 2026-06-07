using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Assets.Scripts.Craft.Events;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight;
using Assets.Scripts.Input;
using Jundroo.Common.Expressions;
using Jundroo.Common.Expressions.Exceptions;
using Jundroo.Common.Platform;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class AircraftControls
	{
		public delegate float ControlOverrideCallbackType();

		public class InputOverride
		{
			public bool Active { get; set; } = true;

			public float Value { get; set; }
		}

		private sealed class AileronValueAccessor
		{
			private readonly AircraftControls _controls;

			private readonly bool _flipped;

			public float Aileron
			{
				get
				{
					if (!_flipped)
					{
						return 0f - _controls.Roll;
					}
					return _controls.Roll;
				}
			}

			public float WingFlipped
			{
				get
				{
					if (!_flipped)
					{
						return -1f;
					}
					return 1f;
				}
			}

			public AileronValueAccessor(ControlSurfacePartScript csScript, AircraftControls controls)
			{
				_flipped = csScript?.ConnectedWing?.Data.Flipped == true;
				_controls = controls;
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<float> _003C_003E9__145_0;

			public static Func<float> _003C_003E9__145_21;

			public static Func<bool> _003C_003E9__146_22;

			public static Func<bool> _003C_003E9__146_24;

			public static Func<bool> _003C_003E9__146_20;

			internal float _003CGetAxisGetter_003Eb__145_0()
			{
				return 0f;
			}

			internal float _003CGetAxisGetter_003Eb__145_21()
			{
				return 0f;
			}

			internal bool _003CGetBoolGetter_003Eb__146_22()
			{
				return false;
			}

			internal bool _003CGetBoolGetter_003Eb__146_24()
			{
				return false;
			}

			internal bool _003CGetBoolGetter_003Eb__146_20()
			{
				return false;
			}

			internal float? _003C_002Ecctor_003Eb__185_0()
			{
				return null;
			}
		}

		private static readonly Func<float?> _disabledInputOverride = () => (float?)null;

		private bool[] _activationStates = new bool[8];

		private AircraftScript _aircraft;

		private Dictionary<string, Func<float?>> _inputOverrides = new Dictionary<string, Func<float?>>();

		private Dictionary<string, float?> _previousOverrideInputValues = new Dictionary<string, float?>();

		private Dictionary<string, List<InputOverride>> _rawInputOverrides = new Dictionary<string, List<InputOverride>>();

		public Action<ActivationGroupStateChangedEventArgs>[] ActivationGroupChanged { get; } = new Action<ActivationGroupStateChangedEventArgs>[9];

		public float Brake { get; set; }

		public bool CycleTargetingMode { get; set; }

		public bool FireGuns { get; set; }

		public bool FireWeapons { get; set; }

		public float Flaps { get; set; }

		public float FlapsIncrement { get; set; }

		public bool FlapsReset { get; set; }

		public bool HasInputOverrides
		{
			get
			{
				if (_inputOverrides != null)
				{
					return _inputOverrides.Count > 0;
				}
				return false;
			}
		}

		public bool LandingGearDown { get; set; }

		public bool LaunchCountermeasures { get; set; }

		public Vector2 MouseAxis { get; set; }

		public bool NextTarget { get; set; }

		public bool NextWeapon { get; set; }

		public bool ParkingBrake { get; set; }

		public float Pitch { get; set; }

		public bool PreviousTarget { get; set; }

		public bool PreviousWeapon { get; set; }

		public float Roll { get; set; }

		public bool ShowInputStatusMessages { get; set; }

		public bool TargetingModeSelectionEnabled { get; set; } = true;

		public float TargetingPodSlewLeftRight { get; private set; }

		public float TargetingPodSlewUpDown { get; private set; }

		public float TargetingPodZoom { get; private set; }

		public float Throttle { get; set; }

		public float ThrottleIncrement { get; set; }

		public bool ToggleActivationPanel { get; set; }

		public float Trim { get; set; }

		public float TrimIncrement { get; set; }

		public bool TrimReset { get; set; }

		public float Vtol { get; set; }

		public float VtolIncrement { get; set; }

		public float Yaw { get; set; }

		private bool Activate1 => _activationStates[0];

		private bool Activate2 => _activationStates[1];

		private bool Activate3 => _activationStates[2];

		private bool Activate4 => _activationStates[3];

		private bool Activate5 => _activationStates[4];

		private bool Activate6 => _activationStates[5];

		private bool Activate7 => _activationStates[6];

		private bool Activate8 => _activationStates[7];

		private float LandingGearLegacyFloat
		{
			get
			{
				if (!LandingGearDown)
				{
					return 1f;
				}
				return 0f;
			}
		}

		public event EventHandler<ActivationGroupStateChangedEventArgs> AnyActivationGroupChanged;

		public AircraftControls(AircraftScript aircraft)
		{
			_activationStates[7] = true;
			ShowInputStatusMessages = true;
			LandingGearDown = true;
			_aircraft = aircraft;
		}

		public void ActivateGroup(int groupIndex)
		{
			if (_aircraft.LoadContext != CraftLoadContext.Flight)
			{
				return;
			}
			_activationStates[groupIndex] = !_activationStates[groupIndex];
			int num = groupIndex + 1;
			if (ShowInputStatusMessages)
			{
				if (_activationStates[groupIndex])
				{
					FlightSceneScript.Instance.FlightUI.ShowMessage($"Group {num} Activated", 1.5f);
				}
				else
				{
					FlightSceneScript.Instance.FlightUI.ShowMessage($"Group {num} De-activated", 1.5f);
				}
			}
			try
			{
				ActivationGroupStateChangedEventArgs e = new ActivationGroupStateChangedEventArgs(num, _activationStates[groupIndex]);
				ActivationGroupChanged[num]?.Invoke(e);
				this.AnyActivationGroupChanged?.Invoke(this, e);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			_aircraft.TargetingSystem.OnActivationGroupStateChanged(groupIndex);
		}

		public void AddRawOverrideInput(string inputAxis, InputOverride input)
		{
			if (_rawInputOverrides.TryGetValue(inputAxis, out var value))
			{
				value.Add(input);
				return;
			}
			_rawInputOverrides.Add(inputAxis, new List<InputOverride> { input });
		}

		public void DisableAllControls()
		{
			foreach (string craftActionsId in InputWrapper.GetCraftActionsIds())
			{
				_inputOverrides[craftActionsId] = _disabledInputOverride;
			}
		}

		public bool GetActivationState(int activationGroup)
		{
			int num = activationGroup - 1;
			if (num >= 0 && num < _activationStates.Length)
			{
				return _activationStates[num];
			}
			return false;
		}

		public Func<bool> GetActivatorGetter(string id, PartScript contextPart, bool valueIfZero = false)
		{
			if (int.TryParse(id, out var ag) && ag >= 0)
			{
				if (ag == 0 || ag > _activationStates.Length)
				{
					return () => valueIfZero;
				}
				ag--;
				return () => _activationStates[ag];
			}
			return GetBoolGetter(id, contextPart);
		}

		public Func<float> GetAxisGetter(string axisName, float booleanInputMinValue = -1f, PartScript contextPart = null, bool returnNull = false)
		{
			if (string.IsNullOrWhiteSpace(axisName) || axisName == "Disabled")
			{
				return () => 0f;
			}
			string inputString = axisName;
			float min = booleanInputMinValue;
			float max = 1f;
			GameInputs instance = GameInputs.Instance;
			bool inverted = axisName.StartsWith("-");
			if (inverted)
			{
				axisName = axisName.Remove(0, 1);
				min = 1f;
				max = booleanInputMinValue;
			}
			if (axisName == instance.Trim.Id)
			{
				return () => (!inverted) ? Trim : (0f - Trim);
			}
			if (axisName == instance.Flaps.Id)
			{
				return () => (!inverted) ? Flaps : (0f - Flaps);
			}
			if (axisName == instance.Vtol.Id)
			{
				return () => (!inverted) ? Vtol : (0f - Vtol);
			}
			if (axisName == instance.Roll.Id)
			{
				return () => (!inverted) ? Roll : (0f - Roll);
			}
			if (axisName == "Aileron")
			{
				bool valueOrDefault = (contextPart?.GetModifier<ControlSurfacePartScript>())?.ConnectedWing?.Data.Flipped == true;
				if (!(inverted ^ valueOrDefault))
				{
					return () => 0f - Roll;
				}
				return () => Roll;
			}
			if (axisName == instance.Pitch.Id)
			{
				return () => (!inverted) ? Pitch : (0f - Pitch);
			}
			if (axisName == instance.Yaw.Id)
			{
				return () => (!inverted) ? Yaw : (0f - Yaw);
			}
			if (axisName == instance.Throttle.Id)
			{
				return () => (!inverted) ? Throttle : (1f - Throttle);
			}
			if (axisName == instance.Brake.Id)
			{
				return () => (!inverted) ? Brake : (0f - Brake);
			}
			if (axisName == instance.LandingGear.Id)
			{
				return () => (!LandingGearDown) ? max : min;
			}
			if (axisName == instance.FireGuns.Id)
			{
				return () => (!FireGuns) ? min : max;
			}
			if (axisName == instance.FireWeapons.Id)
			{
				return () => (!FireWeapons) ? min : max;
			}
			if (axisName == instance.LaunchCountermeasures.Id)
			{
				return () => (!LaunchCountermeasures) ? min : max;
			}
			if (axisName == instance.Activate1.Id)
			{
				return () => (!_activationStates[0]) ? min : max;
			}
			if (axisName == instance.Activate2.Id)
			{
				return () => (!_activationStates[1]) ? min : max;
			}
			if (axisName == instance.Activate3.Id)
			{
				return () => (!_activationStates[2]) ? min : max;
			}
			if (axisName == instance.Activate4.Id)
			{
				return () => (!_activationStates[3]) ? min : max;
			}
			if (axisName == instance.Activate5.Id)
			{
				return () => (!_activationStates[4]) ? min : max;
			}
			if (axisName == instance.Activate6.Id)
			{
				return () => (!_activationStates[5]) ? min : max;
			}
			if (axisName == instance.Activate7.Id)
			{
				return () => (!_activationStates[6]) ? min : max;
			}
			if (axisName == instance.Activate8.Id)
			{
				return () => (!_activationStates[7]) ? min : max;
			}
			if (axisName.ToLower().StartsWith("v>"))
			{
				string[] array = axisName.Split('>');
				float value = 0f;
				if (float.TryParse(array[1], out value))
				{
					return () => (!(_aircraft.AirSpeed * 2.23694f > value)) ? min : max;
				}
				return () => value;
			}
			if (axisName.ToLower().StartsWith("v<"))
			{
				string[] array2 = axisName.Split('<');
				float value2 = 0f;
				if (float.TryParse(array2[1], out value2))
				{
					return () => (!(_aircraft.AirSpeed * 2.23694f < value2)) ? min : max;
				}
				return () => value2;
			}
			if (contextPart != null)
			{
				try
				{
					Context context = ((contextPart.GetModifier<ControlSurfacePartScript>() != null) ? BuildPartContext(contextPart) : contextPart.ExpressionContext);
					return Parser.Process<float>(inputString, context);
				}
				catch (ExpressionCompileException ex)
				{
					if (!Device.IsDemoBuild)
					{
						Debug.LogWarning($"Invalid expression on part {contextPart.Part.Id}: Click for details\n{ex.Message}\nExpressions: {!Parser.Funk}");
					}
				}
				catch (ExpressionParseException ex2)
				{
					if (!Device.IsDemoBuild)
					{
						Debug.LogWarning($"Invalid syntax in expression on part {contextPart.Part.Id}: Click for details\n{ex2.Message}\nExpressions: {!Parser.Funk}");
					}
				}
			}
			object obj;
			if (!returnNull)
			{
				obj = _003C_003Ec._003C_003E9__145_21;
				if (obj == null)
				{
					return _003C_003Ec._003C_003E9__145_21 = () => 0f;
				}
			}
			else
			{
				obj = null;
			}
			return (Func<float>)obj;
		}

		public Func<bool> GetBoolGetter(string axisName, PartScript contextPart = null)
		{
			string inputString = axisName;
			GameInputs instance = GameInputs.Instance;
			bool inverted = axisName.StartsWith("-");
			if (inverted)
			{
				axisName = axisName.Remove(0, 1);
			}
			if (axisName == instance.Trim.Id)
			{
				return () => (Trim != 0f) ^ inverted;
			}
			if (axisName == instance.Flaps.Id)
			{
				return () => (Flaps != 0f) ^ inverted;
			}
			if (axisName == instance.Vtol.Id)
			{
				return () => (Vtol != 0f) ^ inverted;
			}
			if (axisName == instance.Roll.Id)
			{
				return () => (Roll != 0f) ^ inverted;
			}
			if (axisName == instance.Pitch.Id)
			{
				return () => (Pitch != 0f) ^ inverted;
			}
			if (axisName == instance.Yaw.Id)
			{
				return () => (Yaw != 0f) ^ inverted;
			}
			if (axisName == instance.Throttle.Id)
			{
				return () => (Throttle != 0f) ^ inverted;
			}
			if (axisName == instance.Brake.Id)
			{
				return () => (Brake != 0f) ^ inverted;
			}
			if (axisName == instance.LandingGear.Id)
			{
				return () => LandingGearDown ^ inverted;
			}
			if (axisName == instance.FireGuns.Id)
			{
				return () => FireGuns ^ inverted;
			}
			if (axisName == instance.FireWeapons.Id)
			{
				return () => FireWeapons ^ inverted;
			}
			if (axisName == instance.LaunchCountermeasures.Id)
			{
				return () => LaunchCountermeasures ^ inverted;
			}
			if (axisName == instance.Activate1.Id)
			{
				return () => _activationStates[0] ^ inverted;
			}
			if (axisName == instance.Activate2.Id)
			{
				return () => _activationStates[1] ^ inverted;
			}
			if (axisName == instance.Activate3.Id)
			{
				return () => _activationStates[2] ^ inverted;
			}
			if (axisName == instance.Activate4.Id)
			{
				return () => _activationStates[3] ^ inverted;
			}
			if (axisName == instance.Activate5.Id)
			{
				return () => _activationStates[4] ^ inverted;
			}
			if (axisName == instance.Activate6.Id)
			{
				return () => _activationStates[5] ^ inverted;
			}
			if (axisName == instance.Activate7.Id)
			{
				return () => _activationStates[6] ^ inverted;
			}
			if (axisName == instance.Activate8.Id)
			{
				return () => _activationStates[7] ^ inverted;
			}
			if (axisName.ToLower().StartsWith("v>"))
			{
				string[] array = axisName.Split('>');
				float value = 0f;
				if (float.TryParse(array[1], out value))
				{
					return () => (_aircraft.AirSpeed * 2.23694f > value) ^ inverted;
				}
				return () => false;
			}
			if (axisName.ToLower().StartsWith("v<"))
			{
				string[] array2 = axisName.Split('<');
				float value2 = 0f;
				if (float.TryParse(array2[1], out value2))
				{
					return () => (_aircraft.AirSpeed * 2.23694f < value2) ^ inverted;
				}
				return () => false;
			}
			if (contextPart != null)
			{
				try
				{
					return Parser.Process<bool>(inputString, contextPart.ExpressionContext);
				}
				catch (ExpressionCompileException ex)
				{
					if (!Device.IsDemoBuild)
					{
						Debug.LogWarning($"Invalid expression on part {contextPart.Part.Id}: Click for details\n{ex.Message}\nExpressions: {!Parser.Funk}");
					}
				}
				catch (ExpressionParseException ex2)
				{
					if (!Device.IsDemoBuild)
					{
						Debug.LogWarning($"Invalid syntax in expression on part {contextPart.Part.Id}: Click for details\n{ex2.Message}\nExpressions: {!Parser.Funk}");
					}
				}
			}
			return () => false;
		}

		public bool? GetButtonControlInput(IGameInput input)
		{
			bool? result = null;
			float? rawOverrideInput = GetRawOverrideInput(input.Id);
			if (rawOverrideInput.HasValue)
			{
				return rawOverrideInput > 0f;
			}
			if (_inputOverrides.ContainsKey(input.Id))
			{
				float? overrideInput = GetOverrideInput(input.Id);
				if (overrideInput.HasValue)
				{
					result = overrideInput.Value > 0f;
				}
			}
			else if (input.Enabled)
			{
				result = _aircraft.IsPrimaryLocalPlayer && input.GetButton();
			}
			return result;
		}

		public bool? GetButtonDownControlInput(IGameInput input)
		{
			bool? result = null;
			float? rawOverrideInput = GetRawOverrideInput(input.Id);
			if (rawOverrideInput.HasValue)
			{
				return rawOverrideInput > 0f;
			}
			if (_inputOverrides.ContainsKey(input.Id))
			{
				float? overrideInput = GetOverrideInput(input.Id);
				if (overrideInput.HasValue)
				{
					result = overrideInput.Value > 0f;
				}
			}
			else if (input.Enabled)
			{
				result = _aircraft.IsPrimaryLocalPlayer && input.GetButtonDown();
			}
			return result;
		}

		public bool? GetButtonDownControlInput(IGameInput input, out bool hasOverride)
		{
			bool? result = null;
			hasOverride = false;
			float? rawOverrideInput = GetRawOverrideInput(input.Id);
			if (rawOverrideInput.HasValue)
			{
				hasOverride = true;
				return rawOverrideInput > 0f;
			}
			if (_inputOverrides.ContainsKey(input.Id))
			{
				float? overrideInput = GetOverrideInput(input.Id);
				if (overrideInput.HasValue)
				{
					result = overrideInput.Value > 0f;
				}
				hasOverride = true;
			}
			else if (input.Enabled)
			{
				result = _aircraft.IsPrimaryLocalPlayer && input.GetButtonDown();
			}
			return result;
		}

		public float? GetControlInput(IGameInput input, bool overrideOnly = false)
		{
			float? result = GetRawOverrideInput(input.Id);
			if (result.HasValue)
			{
				return result;
			}
			if (_inputOverrides.ContainsKey(input.Id))
			{
				result = GetOverrideInput(input.Id);
			}
			if (input.Enabled && !result.HasValue && !overrideOnly)
			{
				result = (_aircraft.IsPrimaryLocalPlayer ? Mathf.Clamp(input.GetAxis(), -1f, 1f) : 0f);
			}
			return result;
		}

		public float? GetControlInput(IGameInput input, out bool hasOverride)
		{
			float? result = GetRawOverrideInput(input.Id);
			hasOverride = false;
			if (result.HasValue)
			{
				hasOverride = true;
				return result;
			}
			if (_inputOverrides.ContainsKey(input.Id))
			{
				result = GetOverrideInput(input.Id);
				hasOverride = true;
			}
			else if (input.Enabled)
			{
				result = (_aircraft.IsPrimaryLocalPlayer ? Mathf.Clamp(input.GetAxis(), -1f, 1f) : 0f);
			}
			return result;
		}

		public float? GetOverrideInput(string inputAxis)
		{
			float? num = null;
			float? num2 = _inputOverrides[inputAxis]();
			if (num2.HasValue)
			{
				float deltaTime = Time.deltaTime;
				float num3 = 3f;
				if (!_previousOverrideInputValues.ContainsKey(inputAxis))
				{
					_previousOverrideInputValues.Add(inputAxis, 0f);
				}
				float num4 = deltaTime * num3;
				float valueOrDefault = _previousOverrideInputValues[inputAxis].GetValueOrDefault();
				float value = num2.Value - valueOrDefault;
				num = valueOrDefault + Mathf.Clamp(value, 0f - num4, num4);
			}
			_previousOverrideInputValues[inputAxis] = num;
			return num;
		}

		public float? GetRawOverrideInput(string inputAxis)
		{
			if (!_rawInputOverrides.TryGetValue(inputAxis, out var value) || value.Count == 0)
			{
				return null;
			}
			float num = 0f;
			int num2 = 0;
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i].Active)
				{
					num += value[i].Value;
					num2++;
				}
			}
			if (num2 == 0)
			{
				return null;
			}
			return num / (float)num2;
		}

		public void RemoveInputOverrides()
		{
			_inputOverrides.Clear();
		}

		public void RemoveRawOverrideInput(string inputAxis, InputOverride input)
		{
			if (_rawInputOverrides.TryGetValue(inputAxis, out var value))
			{
				int num = value.IndexOf(input);
				if (num != -1)
				{
					value.RemoveAt(num);
				}
			}
		}

		public void SetInputOverride(IGameInput input, Func<float?> overrideFunction)
		{
			if (overrideFunction == null)
			{
				_inputOverrides.Remove(input.Id);
			}
			else
			{
				_inputOverrides[input.Id] = overrideFunction;
			}
		}

		public void SetLandingGearDown(bool value)
		{
			if (value == LandingGearDown)
			{
				return;
			}
			LandingGearDown = value;
			if (_aircraft.LoadContext == CraftLoadContext.Flight && ShowInputStatusMessages)
			{
				if (LandingGearDown)
				{
					FlightSceneScript.Instance.FlightUI.ShowMessage("Extending landing gear", 1f);
				}
				else
				{
					FlightSceneScript.Instance.FlightUI.ShowMessage("Retracting landing gear", 1f);
				}
			}
		}

		public void SetupContext(Context context)
		{
			Type type = GetType();
			GameInputs instance = GameInputs.Instance;
			AddProp(instance.Trim.Id, "Trim", context);
			AddProp(instance.Flaps.Id, "Flaps", context);
			AddProp(instance.Vtol.Id, "Vtol", context);
			AddProp(instance.Roll.Id, "Roll", context);
			AddProp(instance.Pitch.Id, "Pitch", context);
			AddProp(instance.Yaw.Id, "Yaw", context);
			AddProp(instance.Brake.Id, "Brake", context);
			AddProp(instance.Throttle.Id, "Throttle", context);
			AddProp("GearDown", "LandingGearDown", context);
			AddProp(instance.LandingGear.Id, "LandingGearLegacyFloat", context);
			AddProp(instance.FireGuns.Id, "FireGuns", context);
			AddProp(instance.FireWeapons.Id, "FireWeapons", context);
			AddProp(instance.LaunchCountermeasures.Id, "LaunchCountermeasures", context);
			AddProp("ParkingBrake", "ParkingBrake", context);
			for (int i = 1; i <= 8; i++)
			{
				string name = $"Activate{i}";
				context.AddVariable(name, type.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic).GetGetMethod(nonPublic: true), this);
			}
		}

		public void Update(float timeStep)
		{
			GameInputs instance = GameInputs.Instance;
			CraftLoadContext loadContext = _aircraft.LoadContext;
			bool flag = loadContext == CraftLoadContext.Designer;
			bool flag2 = loadContext == CraftLoadContext.Flight;
			bool flag3 = flag || (flag2 && _aircraft.IsPrimaryLocalPlayer);
			bool flag4 = flag || (flag2 && (_aircraft.NetworkAircraft?.IsOwner ?? true));
			IGameInput input = (flag ? instance.DesignerPitch : instance.Pitch);
			IGameInput input2 = (flag ? instance.DesignerRoll : instance.Roll);
			IGameInput input3 = (flag ? instance.DesignerYaw : instance.Yaw);
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			if (Game.Instance.UserInterface.AllowKeyboardInputs)
			{
				InputWrapper.UpdateLastInput(instance.Throttle);
				InputWrapper.UpdateLastInput(instance.Trim);
				InputWrapper.UpdateLastInput(instance.Flaps);
				InputWrapper.UpdateLastInput(instance.Vtol);
				flag5 = InputWrapper.LastInputWasNormalAxis(instance.Throttle);
				flag7 = InputWrapper.LastInputWasNormalAxis(instance.Trim);
				flag8 = InputWrapper.LastInputWasNormalAxis(instance.Flaps);
				flag6 = InputWrapper.LastInputWasNormalAxis(instance.Vtol);
				if (instance.Throttle.Enabled && !flag5)
				{
					ThrottleIncrement = (flag3 ? Mathf.Clamp(instance.Throttle.GetAxis(), -1f, 1f) : 0f);
				}
				if (instance.Trim.Enabled && !flag7)
				{
					TrimIncrement = (flag3 ? Mathf.Clamp(instance.Trim.GetAxis(), -1f, 1f) : 0f);
				}
				if (instance.Flaps.Enabled && !flag8)
				{
					FlapsIncrement = (flag3 ? Mathf.Clamp(instance.Flaps.GetAxis(), -1f, 1f) : 0f);
				}
				if (instance.Vtol.Enabled && !flag6)
				{
					VtolIncrement = (flag3 ? Mathf.Clamp(instance.Vtol.GetAxis(), -1f, 1f) : 0f);
				}
				float? controlInput = GetControlInput(instance.TargetingPodSlewLeftRight);
				if (controlInput.HasValue)
				{
					TargetingPodSlewLeftRight = controlInput.Value;
				}
				float? controlInput2 = GetControlInput(instance.TargetingPodSlewUpDown);
				if (controlInput2.HasValue)
				{
					TargetingPodSlewUpDown = controlInput2.Value;
				}
				float? controlInput3 = GetControlInput(instance.TargetingPodZoom);
				if (controlInput3.HasValue)
				{
					TargetingPodZoom = controlInput3.Value;
				}
			}
			else
			{
				flag5 = InputWrapper.LastInputWasNormalAxis(instance.Throttle);
				flag7 = InputWrapper.LastInputWasNormalAxis(instance.Trim);
				flag8 = InputWrapper.LastInputWasNormalAxis(instance.Flaps);
				flag6 = InputWrapper.LastInputWasNormalAxis(instance.Vtol);
			}
			if (PauseManager.Paused || !Game.Instance.UserInterface.AllowKeyboardInputs)
			{
				return;
			}
			if (GetButtonDownControlInput(instance.ToggleParkingBrake) == true)
			{
				ParkingBrake = !ParkingBrake;
				string message = "Parking brake " + (ParkingBrake ? "engaged" : "disengaged");
				FlightSceneScript.Instance.FlightUI.ShowMessage(message, 1f);
			}
			float? controlInput4 = GetControlInput(instance.Brake);
			if (controlInput4.HasValue)
			{
				Brake = (ParkingBrake ? 1f : controlInput4.Value);
				float valueOrDefault = (_aircraft.Powertrain.PrimaryPowertrain?.PrimaryTransmission?.ShiftGuardBrake).GetValueOrDefault();
				if (valueOrDefault > 0f && valueOrDefault > Brake)
				{
					Brake = valueOrDefault;
				}
			}
			if (GetControlInput(instance.ZeroThrottle) > 0f)
			{
				Throttle = 0f;
			}
			else if (GetControlInput(instance.MaxThrottle) > 0f)
			{
				Throttle = 1f;
			}
			if (Throttle <= 0f && ThrottleIncrement < 0f)
			{
				Brake = Mathf.Clamp(0f - ThrottleIncrement, 0f, 1f);
			}
			if (flag4)
			{
				UpdateActivationButtonState(0, instance.Activate1);
				UpdateActivationButtonState(1, instance.Activate2);
				UpdateActivationButtonState(2, instance.Activate3);
				UpdateActivationButtonState(3, instance.Activate4);
				UpdateActivationButtonState(4, instance.Activate5);
				UpdateActivationButtonState(5, instance.Activate6);
				UpdateActivationButtonState(6, instance.Activate7);
				UpdateActivationButtonState(7, instance.Activate8);
			}
			Vector2 mouseAxis = MouseAxis;
			bool hasOverride;
			float? controlInput5 = GetControlInput(input2, out hasOverride);
			if (controlInput5.HasValue)
			{
				Roll = controlInput5.Value;
				if (!hasOverride)
				{
					Roll = Mathf.Clamp(Roll + mouseAxis.x, -1f, 1f);
				}
			}
			bool hasOverride2;
			float? controlInput6 = GetControlInput(input, out hasOverride2);
			if (controlInput6.HasValue)
			{
				Pitch = controlInput6.Value;
				if (!hasOverride2)
				{
					Pitch = Mathf.Clamp(Pitch + mouseAxis.y, -1f, 1f);
				}
			}
			float? controlInput7 = GetControlInput(input3);
			if (controlInput7.HasValue)
			{
				Yaw = controlInput7.Value;
			}
			bool? buttonControlInput = GetButtonControlInput(instance.FireGuns);
			if (buttonControlInput.HasValue)
			{
				FireGuns = buttonControlInput.Value;
			}
			bool? buttonControlInput2 = GetButtonControlInput(instance.FireWeapons);
			if (buttonControlInput2.HasValue)
			{
				FireWeapons = buttonControlInput2.Value;
			}
			bool? buttonControlInput3 = GetButtonControlInput(instance.LaunchCountermeasures);
			if (buttonControlInput3.HasValue)
			{
				LaunchCountermeasures = buttonControlInput3.Value;
			}
			bool? buttonDownControlInput = GetButtonDownControlInput(instance.NextTarget);
			if (buttonDownControlInput.HasValue)
			{
				NextTarget = buttonDownControlInput.Value;
			}
			bool? buttonDownControlInput2 = GetButtonDownControlInput(instance.PreviousTarget);
			if (buttonDownControlInput2.HasValue)
			{
				PreviousTarget = buttonDownControlInput2.Value;
			}
			bool? buttonDownControlInput3 = GetButtonDownControlInput(instance.NextWeapon);
			if (buttonDownControlInput3.HasValue)
			{
				NextWeapon = buttonDownControlInput3.Value;
			}
			bool? buttonDownControlInput4 = GetButtonDownControlInput(instance.PreviousWeapon);
			if (buttonDownControlInput4.HasValue)
			{
				PreviousWeapon = buttonDownControlInput4.Value;
			}
			bool? buttonDownControlInput5 = GetButtonDownControlInput(instance.ToggleActivationPanel);
			if (buttonDownControlInput5.HasValue)
			{
				ToggleActivationPanel = buttonDownControlInput5.Value;
			}
			bool? buttonDownControlInput6 = GetButtonDownControlInput(instance.CycleTargetingMode);
			if (buttonDownControlInput6.HasValue)
			{
				CycleTargetingMode = buttonDownControlInput6.Value;
			}
			bool hasOverride3;
			bool? buttonDownControlInput7 = GetButtonDownControlInput(instance.LandingGear, out hasOverride3);
			if (buttonDownControlInput7.HasValue)
			{
				if (hasOverride3)
				{
					SetLandingGearDown(buttonDownControlInput7.Value);
				}
				else if (buttonDownControlInput7.Value)
				{
					SetLandingGearDown(!LandingGearDown);
				}
			}
			if (instance.Trim.Enabled)
			{
				float? controlInput8 = GetControlInput(instance.Trim, overrideOnly: true);
				if (controlInput8.HasValue)
				{
					Trim = controlInput8.Value;
				}
				else if (flag7)
				{
					Trim = (_aircraft.IsPrimaryLocalPlayer ? instance.Trim.GetAxis() : 0f);
				}
				else
				{
					Trim += timeStep * TrimIncrement;
				}
				Trim = Mathf.Clamp(Trim, -1f, 1f);
			}
			bool? buttonDownControlInput8 = GetButtonDownControlInput(instance.TrimReset);
			if (buttonDownControlInput8.HasValue)
			{
				TrimReset = buttonDownControlInput8.Value;
				if (TrimReset && Trim != 0f)
				{
					Trim = 0f;
					FlightSceneScript.Instance.FlightUI.ShowMessage("Trim reset", 1f);
				}
			}
			if (instance.Flaps.Enabled)
			{
				float? controlInput9 = GetControlInput(instance.Flaps, overrideOnly: true);
				if (controlInput9.HasValue)
				{
					Flaps = controlInput9.Value;
				}
				else if (flag8)
				{
					Flaps = (_aircraft.IsPrimaryLocalPlayer ? instance.Flaps.GetAxis() : 0f);
				}
				else
				{
					Flaps += timeStep * FlapsIncrement;
				}
				Flaps = Mathf.Clamp(Flaps, -1f, 1f);
			}
			bool? buttonDownControlInput9 = GetButtonDownControlInput(instance.FlapsReset);
			if (buttonDownControlInput9.HasValue)
			{
				FlapsReset = buttonDownControlInput9.Value;
				if (FlapsReset && Flaps != 0f)
				{
					Flaps = 0f;
					FlightSceneScript.Instance.FlightUI.ShowMessage("Flaps reset", 1f);
				}
			}
			if (instance.Vtol.Enabled || _inputOverrides.ContainsKey(instance.Vtol.Id))
			{
				float? controlInput10 = GetControlInput(instance.Vtol, overrideOnly: true);
				if (controlInput10.HasValue)
				{
					Vtol = controlInput10.Value;
				}
				else if (flag6)
				{
					Vtol = (_aircraft.IsPrimaryLocalPlayer ? instance.Vtol.GetAxis() : 0f);
				}
				else
				{
					Vtol += timeStep * VtolIncrement;
				}
				Vtol = Mathf.Clamp(Vtol, -1f, 1f);
			}
			if (instance.Throttle.Enabled || _inputOverrides.ContainsKey(instance.Throttle.Id))
			{
				float? controlInput11 = GetControlInput(instance.Throttle, overrideOnly: true);
				if (controlInput11.HasValue)
				{
					Throttle = controlInput11.Value;
				}
				else if (flag5)
				{
					Throttle = (_aircraft.IsPrimaryLocalPlayer ? instance.Throttle.GetAxis() : 0f);
				}
				else
				{
					Throttle += timeStep * ThrottleIncrement;
				}
				Throttle = Mathf.Clamp01(Throttle);
			}
		}

		private void AddProp(string id, string prop, Context context)
		{
			PropertyInfo property = GetType().GetProperty(prop, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (property == null)
			{
				Debug.LogWarning("Property not found: " + prop);
			}
			else
			{
				context.AddVariable(id, property.GetMethod, this);
			}
		}

		private Context BuildPartContext(PartScript contextPart)
		{
			Context expressionContext = contextPart.ExpressionContext;
			Context context = new Context(new Dictionary<string, (MethodInfo, object)>(expressionContext.Properties), new Dictionary<string, (MethodInfo, object)>(expressionContext.Functions), new Dictionary<string, object>(expressionContext.Constants), addDefaults: false);
			foreach (KeyValuePair<string, Func<Func<float>, (MethodInfo, object)>> specialFunction in expressionContext.SpecialFunctions)
			{
				context.AddSpecialFunction(specialFunction.Key, specialFunction.Value);
			}
			context.GetDeltaTime = expressionContext.GetDeltaTime;
			context.EnableMemory = expressionContext.EnableMemory;
			foreach (KeyValuePair<Type, TypeMetadata> instanceTypeMetadatum in expressionContext.InstanceTypeMetadata)
			{
				context.InstanceTypeMetadata.Add(instanceTypeMetadatum.Key, instanceTypeMetadatum.Value);
			}
			ControlSurfacePartScript modifier = contextPart.GetModifier<ControlSurfacePartScript>();
			if (modifier != null)
			{
				AileronValueAccessor instance = new AileronValueAccessor(modifier, this);
				Type typeFromHandle = typeof(AileronValueAccessor);
				context.AddVariable("Aileron", typeFromHandle.GetProperty("Aileron").GetGetMethod(nonPublic: true), instance);
				context.AddVariable("WingFlipped", typeFromHandle.GetProperty("WingFlipped").GetGetMethod(nonPublic: true), instance);
			}
			return context;
		}

		private float ClampInput(float value, float min, float max)
		{
			return Mathf.Clamp(value, min, max);
		}

		private float GetFloatFromBool(Func<bool> func)
		{
			if (!func())
			{
				return 0f;
			}
			return 1f;
		}

		private void UpdateActivationButtonState(int activationGroup, IGameInput input)
		{
			float? rawOverrideInput = GetRawOverrideInput(input.Id);
			if (rawOverrideInput.HasValue && rawOverrideInput.Value > 0f)
			{
				ActivateGroup(activationGroup);
			}
			if (input.GetButtonDownIfEnabled())
			{
				ActivateGroup(activationGroup);
			}
		}
	}
}
