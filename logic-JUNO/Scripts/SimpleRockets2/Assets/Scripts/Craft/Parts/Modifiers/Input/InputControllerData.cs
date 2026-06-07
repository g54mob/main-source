using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Assets.Scripts.Craft.FlightData;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Data;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Input
{
	[Serializable]
	[DesignerPartModifier("Input Controller", PanelOrder = 2500)]
	public class InputControllerData : PartModifierData<InputControllerScript>
	{
		public delegate void PropertyChangedHandler(InputControllerData source);

		private const string _outputCurveXmlName = "outputCurve";

		private static readonly IReadOnlyList<string> _AllInputNames;

		private static readonly IEnumerable<int> _EmptyEnumerableInt;

		[SerializeField]
		[DesignerPropertySpinner(0, 10, 1, Label = "Activation Group", Order = 20, Tooltip = "The activation group that must be enabled for the input to function.")]
		private int _activationGroup;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _currentValue;

		[SerializeField]
		[PartModifierProperty(true, false)]
		[Tooltip("These should be comma separated. They specify the list of selectable input options in the part properties panel.")]
		private string _designerInputOptions = string.Empty;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Ignore Part Activation State", Order = 90, IsHidden = true, Tooltip = "If true, the part does not need to be active in order for the input controller to be active.")]
		private bool _ignorePartActivationState;

		[SerializeField]
		[DesignerPropertySpinner(Order = 10, TextFormat = DesignerPropertySpinnerTextFormat.InputAuto, AllowManualInput = true, ValidateManualInput = false, Tooltip = "The input axis driving this input controller.")]
		private string _input = "Slider1";

		[SerializeField]
		[PartModifierProperty(true, false, PreserveState = false, NeverSerialize = true)]
		private InputControllerInputRange _inputAxisRange;

		[SerializeField]
		[DesignerPropertyTextInput(Label = "Input Axis Range", Order = 110, IsHidden = true, NeverSerialize = true, PreserveState = false, Tooltip = "A set of one, two, or three comma separated numbers defining the range of input axis values and how they are remapped into the -1 to 1 range. \n\n{max} - Input axis values <= 0 are remapped to zero. Values >= {max} are remapped to 1. Values between 0 and {max} are lerped between 0 and 1. \n\n{min},{max} - Input axis values <= {min} are remapped to -1. Values >= {max} are remapped to 1. Values between {min} and {max} are lerped between -1 and 1. \n\n{min},{zero},{max} - Input axis values <= {min} are remapped to -1. Values >= {max} are remapped to 1. Values between {min} and {zero} are lerped between -1 and 0. Values between {zero} and {max} are lerped between 0 and 1. If {min} and {zero} are equal, inputs <= {min} are remapped to 0. If {zero} and {max} are equal, inputs >= {max} are remapped to 0.")]
		private string _inputAxisRangeDesigner;

		[SerializeField]
		[DesignerPropertyToggleButton(Order = 70, Tooltip = "If enabled, output of the input controller will be inverted.")]
		private bool _invert;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Invert on Mirror", Order = 80, Tooltip = "If enabled, then the Invert setting will be flipped when the part is mirrored to the other side.")]
		private bool _invertOnMirror;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Invert Type", IsHidden = true, Order = 60, Tooltip = "Axis: The input axis is inverted prior to remapping the input to the min/max values. \nOutput: The output value is inverted after remapping the input to the min/max values.")]
		private InvertType _invertType = InvertType.Output;

		[SerializeField]
		[DesignerPropertySpinner(-2.1474836E+09f, 2.1474836E+09f, 0.05f, Label = "Max Value", Order = 50, IsHidden = true, Tooltip = "The maximum output value of the controller when the input axis is 1.")]
		private float _max = 1f;

		[SerializeField]
		[DesignerPropertySpinner(-2.1474836E+09f, 2.1474836E+09f, 0.05f, Label = "Min Value", Order = 40, IsHidden = true, Tooltip = "The minimum output value of the controller when the input axis is -1.")]
		private float _min = -1f;

		private UserCurve _outputCurve;

		[SerializeField]
		[DesignerPropertySpinner(-1000000f, 1000000f, 0.25f, Label = "Amplitude", NeverSerialize = true, IsHidden = true, Order = 220, Tooltip = "The amplitude of the output curve.")]
		private float _outputCurveAmplitude = 1f;

		[SerializeField]
		[DesignerPropertySpinner(0f, 1000000f, 0.25f, Label = "Frequency", NeverSerialize = true, IsHidden = true, Order = 210, Tooltip = "The frequency of the output curve.")]
		private float _outputCurveFrequency = 1f;

		[SerializeField]
		[DesignerPropertyTextInput(Label = "Keyframes", NeverSerialize = true, IsHidden = true, Order = 201, Tooltip = "Keyframes should be separated by the '|' character, with each keyframe having values separated by the ',' character. A keyframe should define a time value and an output value. Optionally, the keyframe may specify a third value the definesthe incoming and outgoing tangents, or a third and fourth value that define the incoming and outgoing tangents respectively. Example: 0.0,0.0|0.5,1.0|1.0,0.0")]
		private string _outputCurveKeyframes = string.Empty;

		[DesignerPropertyLabel(Label = "Output Curve", NeverSerialize = true, IsHidden = true, Order = 200)]
		private string _outputCurveLabel = string.Empty;

		[SerializeField]
		[DesignerPropertySpinner(-1000000f, 1000000f, 0.05f, Label = "Offset", IsHidden = true, Order = 230, Tooltip = "The offset value used when evaluating the output curve.")]
		private float _outputCurveOffset;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Style", NeverSerialize = true, IsHidden = true, Order = 240, TextFormat = DesignerPropertySpinnerTextFormat.Auto, Tooltip = "The style of the output curve.")]
		private UserCurve.CurveStyle _outputCurveStyle = UserCurve.CurveStyle.Smooth;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Wrap Mode", NeverSerialize = true, IsHidden = true, Order = 250, TextFormat = DesignerPropertySpinnerTextFormat.Auto, Tooltip = "Determines how the curve is evaluated when the axis value extends beyond the extents of the curve.")]
		private UserCurve.CurveWrapMode _outputCurveWrapMode = UserCurve.CurveWrapMode.Clamp;

		[SerializeField]
		[HideInInspector]
		[PartModifierProperty(true, false)]
		private string _overrideInput = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveState = false)]
		private bool _showActivationGroup;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveState = false)]
		private bool _showInputAxis = true;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveState = false)]
		private bool _showInvert = true;

		[SerializeField]
		[DesignerPropertySpinner(TextFormat = DesignerPropertySpinnerTextFormat.Auto, IsHidden = true, Order = 30, Tooltip = "Standard - A positive axis will be multiplied by the max value. A negative axis will be multiplied by the min value. \n\nLerp Full Axis - The output value will be linearly interpolated between the min and max values assuming an input axis of -1 to 1. \n\nLerp Positive Axis - The output value will be linearly interpolated between the min and max values assuming an input axis of 0 to 1. \n\nLerp Negative Axis - The output value will be linearly interpolated between the min and max values assuming an input axis of -1 to 0. \n\nCurve - The output will be evaluated on a user defined curve with the input axis acting as the time input.")]
		private InputControllerType _type;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Zero on Deactivate", Order = 100, IsHidden = true, Tooltip = "If disabled, the input will not return to zero when deactivated.")]
		private bool _zeroOnDeactivate = true;

		public int ActivationGroup => _activationGroup;

		public float CurrentValue
		{
			get
			{
				return _currentValue;
			}
			set
			{
				_currentValue = value;
			}
		}

		public bool IgnorePartActivationState => _ignorePartActivationState;

		public string Input
		{
			get
			{
				return _input;
			}
			set
			{
				_input = value;
			}
		}

		public InputControllerInputRange InputAxisRange => _inputAxisRange;

		public bool Invert
		{
			get
			{
				return _invert;
			}
			set
			{
				_invert = value;
				this.InvertChanged?.Invoke(this);
			}
		}

		public bool InvertOnMirror
		{
			get
			{
				return _invertOnMirror;
			}
			set
			{
				_invertOnMirror = value;
			}
		}

		public InvertType InvertType => _invertType;

		public float MaxValue => _max;

		public float MinValue => _min;

		public UserCurve OutputCurve => _outputCurve;

		public float OutputCurveAmplitude
		{
			get
			{
				return _outputCurveAmplitude;
			}
			set
			{
				_outputCurveAmplitude = value;
				if (_outputCurve != null)
				{
					_outputCurve.Amplitude = value;
				}
			}
		}

		public float OutputCurveFrequency
		{
			get
			{
				return _outputCurveFrequency;
			}
			set
			{
				_outputCurveFrequency = value;
				if (_outputCurve != null)
				{
					_outputCurve.Frequency = value;
				}
			}
		}

		public float OutputCurveOffset
		{
			get
			{
				return _outputCurveOffset;
			}
			set
			{
				_outputCurveOffset = value;
			}
		}

		public UserCurve.CurveStyle OutputCurveStyle
		{
			get
			{
				return _outputCurveStyle;
			}
			set
			{
				_outputCurveStyle = value;
				if (_outputCurve != null)
				{
					_outputCurve.Style = value;
				}
			}
		}

		public UserCurve.CurveWrapMode OutputCurveWrapMode
		{
			get
			{
				return _outputCurveWrapMode;
			}
			set
			{
				_outputCurveWrapMode = value;
				if (_outputCurve != null)
				{
					_outputCurve.WrapMode = value;
				}
			}
		}

		public string OverrideInput => _overrideInput;

		public InputControllerType Type => _type;

		public bool ZeroOnDeactivate => _zeroOnDeactivate;

		public event PropertyChangedHandler InvertChanged;

		static InputControllerData()
		{
			_EmptyEnumerableInt = Enumerable.Empty<int>();
			List<string> list = new List<string>();
			PropertyInfo[] properties = typeof(CraftControls).GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				Type propertyType = propertyInfo.PropertyType;
				if (propertyType == typeof(float) || propertyType == typeof(bool) || propertyType == typeof(double))
				{
					list.Add(propertyInfo.Name);
				}
			}
			for (int j = 1; j <= 10; j++)
			{
				list.Add($"AG{j}");
			}
			properties = typeof(CraftFlightData).GetProperties();
			foreach (PropertyInfo propertyInfo2 in properties)
			{
				Type propertyType2 = propertyInfo2.PropertyType;
				if (propertyType2 == typeof(float) || propertyType2 == typeof(bool) || propertyType2 == typeof(double))
				{
					list.Add("FD." + propertyInfo2.Name);
				}
			}
			_AllInputNames = list;
		}

		public override XElement GenerateStateXml(bool optimizeXml = true)
		{
			XElement xElement = base.GenerateStateXml(optimizeXml);
			if (_inputAxisRange != null && _inputAxisRange.HasValues())
			{
				xElement.Add(_inputAxisRange.SaveXml("inputRange"));
			}
			if (_type == InputControllerType.Curve && _outputCurve != null)
			{
				_outputCurve.GenerateXml(xElement);
			}
			return xElement;
		}

		public override IEnumerable<int> GetAssociatedActivationGroups()
		{
			if (_activationGroup > 0)
			{
				yield return _activationGroup;
			}
			if (Game.InFlightScene)
			{
				if (base.Script.PrimaryInput is InputControllerInput { ActivationGroupId: not null, ActivationGroupId: var activationGroupId })
				{
					yield return activationGroupId.Value;
				}
				if (base.Script.OverrideInput is InputControllerInput { ActivationGroupId: not null, ActivationGroupId: var activationGroupId2 })
				{
					yield return activationGroupId2.Value;
				}
			}
			else
			{
				if (_input.StartsWith("AG", StringComparison.Ordinal) && int.TryParse(_input.Substring(2), out var result) && result > 0)
				{
					yield return result;
				}
				if (_overrideInput.StartsWith("AG", StringComparison.Ordinal) && int.TryParse(_overrideInput.Substring(2), out var result2) && result2 > 0)
				{
					yield return result2;
				}
			}
		}

		public override void RestoreFromState(XElement stateElement, bool restoreAll)
		{
			base.RestoreFromState(stateElement, restoreAll);
			_showActivationGroup |= _activationGroup != 0;
			_inputAxisRange = InputControllerInputRange.Create(stateElement.Attribute("inputRange"));
			if (_type == InputControllerType.Curve)
			{
				_outputCurve = UserCurve.RestoreFromXml(stateElement, "outputCurve", UserCurve.CurveWrapMode.Clamp);
				if (_outputCurve != null)
				{
					_outputCurveKeyframes = _outputCurve.GetKeyframesAsString();
					_outputCurveStyle = _outputCurve.Style;
					_outputCurveFrequency = _outputCurve.Frequency;
					_outputCurveAmplitude = _outputCurve.Amplitude;
					_outputCurveWrapMode = _outputCurve.WrapMode;
				}
			}
			else
			{
				_outputCurve = null;
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			Func<bool, bool> visibilityTest = (bool x) => _type == InputControllerType.Curve;
			Func<bool, bool> visibilityTest2 = (bool x) => _type != InputControllerType.Curve;
			d.OnHeaderLabelRequested(() => GetHeaderLabel());
			d.OnVisibilityRequested(() => _activationGroup, (bool x) => _showActivationGroup || x);
			d.OnVisibilityRequested(() => _input, (bool x) => _showInputAxis || x);
			d.OnVisibilityRequested(() => _invert, (bool x) => _showInvert || x);
			d.OnVisibilityRequested(() => _invertOnMirror, (bool x) => _showInvert || x);
			d.OnVisibilityRequested(() => _min, visibilityTest2);
			d.OnVisibilityRequested(() => _max, visibilityTest2);
			d.OnVisibilityRequested(() => _outputCurveLabel, visibilityTest);
			d.OnVisibilityRequested(() => _outputCurveKeyframes, visibilityTest);
			d.OnVisibilityRequested(() => _outputCurveFrequency, visibilityTest);
			d.OnVisibilityRequested(() => _outputCurveAmplitude, visibilityTest);
			d.OnVisibilityRequested(() => _outputCurveStyle, visibilityTest);
			d.OnVisibilityRequested(() => _outputCurveWrapMode, visibilityTest);
			d.OnVisibilityRequested(() => _outputCurveOffset, visibilityTest);
			d.OnValueLabelRequested(() => _activationGroup, (int x) => (x != 0) ? x.ToString() : "None");
			d.OnSpinnerValuesRequested(() => _input, UpdateDesignerInputs);
			d.OnPropertyActivated(() => _inputAxisRangeDesigner, delegate
			{
				_inputAxisRangeDesigner = (string)_inputAxisRange?.SaveXml("x");
			});
			d.OnPropertyChanged(() => _inputAxisRangeDesigner, delegate(string newVal, string oldVal)
			{
				UpdateInputAxisRange(newVal);
			});
			d.OnPropertyChanged(() => _invert, delegate
			{
				this.InvertChanged?.Invoke(this);
			});
			d.OnPropertyChanged(() => _type, delegate(InputControllerType newVal, InputControllerType oldVal)
			{
				if (newVal == InputControllerType.Curve && _outputCurve == null)
				{
					_outputCurve = new UserCurve("InputController", _outputCurveStyle, _outputCurveWrapMode, null);
					_outputCurve.SetKeyframes(_outputCurveKeyframes);
				}
			});
			d.OnPropertyChanged(() => _outputCurveKeyframes, delegate
			{
				UpdateOutputCurveKeyframes();
			});
			d.OnPropertyChanged(() => _outputCurveFrequency, delegate(float newVal, float oldVal)
			{
				_outputCurve.Frequency = newVal;
			});
			d.OnPropertyChanged(() => _outputCurveAmplitude, delegate(float newVal, float oldVal)
			{
				_outputCurve.Amplitude = newVal;
			});
			d.OnPropertyChanged(() => _outputCurveStyle, delegate(UserCurve.CurveStyle newVal, UserCurve.CurveStyle oldVal)
			{
				_outputCurve.Style = newVal;
			});
			d.OnPropertyChanged(() => _outputCurveWrapMode, delegate(UserCurve.CurveWrapMode newVal, UserCurve.CurveWrapMode oldVal)
			{
				_outputCurve.WrapMode = newVal;
			});
		}

		protected override void OnDisposed()
		{
			base.OnDisposed();
			this.InvertChanged = null;
		}

		private string GetHeaderLabel()
		{
			if (string.IsNullOrWhiteSpace(base.InputId))
			{
				return null;
			}
			return Regex.Replace(base.InputId, "([A-Z]+|[0-9|\\.]+)", " $1").TrimStart() + " Input";
		}

		private void UpdateDesignerInputs(List<string> inputs)
		{
			inputs.Clear();
			bool value = Game.Instance.Settings.Game.Designer.ShowHiddenPartProperties.Value;
			if (!value && string.IsNullOrWhiteSpace(_designerInputOptions))
			{
				UpdateDesignerInputs(inputs, (CraftControls x) => x.Pitch, (CraftControls x) => x.Roll, (CraftControls x) => x.Yaw, (CraftControls x) => x.Slider1, (CraftControls x) => x.Slider2, (CraftControls x) => x.Slider3, (CraftControls x) => x.Slider4, (CraftControls x) => x.Throttle, (CraftControls x) => x.Brake);
			}
			else if (value || _designerInputOptions.ToLower() == "all")
			{
				inputs.AddRange(_AllInputNames);
			}
			else
			{
				inputs.AddRange(from x in _designerInputOptions.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
					select x.Trim());
			}
		}

		private void UpdateDesignerInputs(List<string> inputs, params Expression<Func<CraftControls, object>>[] controlSelectors)
		{
			for (int i = 0; i < controlSelectors.Length; i++)
			{
				if (!(controlSelectors[i].Body is UnaryExpression unaryExpression))
				{
					Debug.LogError("Invalid control selector expression.");
				}
				else if (!(unaryExpression.Operand is MemberExpression memberExpression))
				{
					Debug.LogError("Invalid control selector expression.");
				}
				else if (memberExpression.Member as PropertyInfo == null)
				{
					Debug.LogError("Invalid control selector expression.");
				}
				else
				{
					inputs.Add((memberExpression.Member as PropertyInfo).Name);
				}
			}
		}

		private void UpdateInputAxisRange(string value)
		{
			try
			{
				_inputAxisRange = InputControllerInputRange.Create(value);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				_inputAxisRange = null;
			}
			if (_inputAxisRange == null)
			{
				_inputAxisRangeDesigner = null;
				base.DesignerPartProperties.Manager.RefreshUI();
			}
		}

		private void UpdateOutputCurveKeyframes()
		{
			if (_outputCurve == null)
			{
				_outputCurve = new UserCurve("outputCurve", _outputCurveStyle, _outputCurveWrapMode);
				_outputCurve.Frequency = _outputCurveFrequency;
				_outputCurve.Amplitude = _outputCurveAmplitude;
			}
			_outputCurve.SetKeyframes(_outputCurveKeyframes);
		}
	}
}
