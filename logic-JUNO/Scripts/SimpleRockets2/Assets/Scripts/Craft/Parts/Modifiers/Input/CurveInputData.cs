using System;
using System.Xml.Linq;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Data;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Input
{
	[Serializable]
	[DesignerPartModifier("Curve Input", PanelOrder = 2600)]
	public class CurveInputData : PartModifierData<CurveInputScript>
	{
		private const string _curveXmlName = "";

		[SerializeField]
		[DesignerPropertySpinner(-1000000f, 1000000f, 0.25f, Label = "Amplitude", NeverSerialize = true, Order = 20, Tooltip = "The amplitude of the curve.")]
		private float _amplitude = 1f;

		private UserCurve _curve;

		[SerializeField]
		[DesignerPropertySpinner(0f, 1000000f, 0.25f, Label = "Frequency", NeverSerialize = true, Order = 10, Tooltip = "The frequency of the curve.")]
		private float _frequency = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Ignore Part Activation State", Order = 80, Tooltip = "If true, the part does not need to be active in order for the curve to be updated.")]
		private bool _ignorePartActivationState;

		[SerializeField]
		[DesignerPropertyTextInput(Label = "Keyframes", NeverSerialize = true, Order = 0, Tooltip = "Keyframes should be separated by the '|' character, with each keyframe having values separated by the ',' character. A keyframe should define a time value and an output value. Optionally, the keyframe may specify a third value the defines the incoming and outgoing tangents, or a third and fourth value that define the incoming and outgoing tangents respectively. Example: 0.0,0.0|0.5,1.0|1.0,0.0")]
		private string _keyframes = string.Empty;

		[SerializeField]
		[DesignerPropertySpinner(-1000000f, 1000000f, 0.05f, Label = "Offset", Order = 30, Tooltip = "The initial time offset value used when when the curve is created.")]
		private float _offset;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Style", NeverSerialize = true, Order = 40, TextFormat = DesignerPropertySpinnerTextFormat.Auto, Tooltip = "The style of the curve.")]
		private UserCurve.CurveStyle _style = UserCurve.CurveStyle.Smooth;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Update In Warp", Order = 70, Tooltip = "If enabled, the curve will continue to update in warp mode. If disabled, the current time of the curve will remain unchanged while warp mode is active.")]
		private bool _updateInWarp;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Use Unscaled Time", Order = 60, Tooltip = "If enabled, unscaled time will be used when updating the curve every frame. This is the time delta between this frame and the last frame, ignoring the effects of fast forward, slow motion, and warp mode.")]
		private bool _useUnscaledTime;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Wrap Mode", NeverSerialize = true, Order = 50, TextFormat = DesignerPropertySpinnerTextFormat.Auto, Tooltip = "Determines how the curve is evaluated when the time value extends beyond the extents of the curve.")]
		private UserCurve.CurveWrapMode _wrapMode = UserCurve.CurveWrapMode.Clamp;

		public float Amplitude
		{
			get
			{
				return _amplitude;
			}
			set
			{
				_amplitude = value;
				if (_curve != null)
				{
					_curve.Amplitude = value;
				}
			}
		}

		public UserCurve Curve => _curve;

		public float Frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				_frequency = value;
				if (_curve != null)
				{
					_curve.Frequency = value;
				}
			}
		}

		public bool IgnorePartActivationState => _ignorePartActivationState;

		public string Keyframes
		{
			get
			{
				return _keyframes;
			}
			set
			{
				_keyframes = value;
				if (_curve != null)
				{
					_curve.SetKeyframes(value);
				}
			}
		}

		public float Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				_offset = value;
				if (_curve != null)
				{
					_curve.CurrentTime = value;
				}
			}
		}

		public UserCurve.CurveStyle Style
		{
			get
			{
				return _style;
			}
			set
			{
				_style = value;
				if (_curve != null)
				{
					_curve.Style = value;
				}
			}
		}

		public bool UpdateInWarp
		{
			get
			{
				return _updateInWarp;
			}
			set
			{
				_updateInWarp = value;
			}
		}

		public bool UseUnscaledTime
		{
			get
			{
				return _useUnscaledTime;
			}
			set
			{
				_useUnscaledTime = value;
			}
		}

		public UserCurve.CurveWrapMode WrapMode
		{
			get
			{
				return _wrapMode;
			}
			set
			{
				_wrapMode = value;
				if (_curve != null)
				{
					_curve.WrapMode = value;
				}
			}
		}

		public override XElement GenerateStateXml(bool optimizeXml = true)
		{
			XElement xElement = base.GenerateStateXml(optimizeXml);
			if (_curve != null)
			{
				_curve.GenerateXml(xElement);
			}
			return xElement;
		}

		public override void RestoreFromState(XElement stateElement, bool restoreAll)
		{
			base.RestoreFromState(stateElement, restoreAll);
			_curve = UserCurve.RestoreFromXml(stateElement, "", UserCurve.CurveWrapMode.Clamp);
			if (_curve != null)
			{
				_keyframes = _curve.GetKeyframesAsString();
				_style = _curve.Style;
				_frequency = _curve.Frequency;
				_amplitude = _curve.Amplitude;
				_wrapMode = _curve.WrapMode;
				_curve.CurrentTime = _offset;
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnPropertyChanged(() => _keyframes, delegate
			{
				_curve.SetKeyframes(_keyframes);
			});
			d.OnPropertyChanged(() => _frequency, delegate(float newVal, float oldVal)
			{
				_curve.Frequency = newVal;
			});
			d.OnPropertyChanged(() => _amplitude, delegate(float newVal, float oldVal)
			{
				_curve.Amplitude = newVal;
			});
			d.OnPropertyChanged(() => _style, delegate(UserCurve.CurveStyle newVal, UserCurve.CurveStyle oldVal)
			{
				_curve.Style = newVal;
			});
			d.OnPropertyChanged(() => _wrapMode, delegate(UserCurve.CurveWrapMode newVal, UserCurve.CurveWrapMode oldVal)
			{
				_curve.WrapMode = newVal;
			});
		}
	}
}
