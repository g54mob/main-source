using System;
using System.Xml.Linq;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Data;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Lights
{
	[Serializable]
	[DesignerPartModifier("Beacon Light")]
	public class BeaconLightData : PartModifierData<BeaconLightScript>
	{
		public enum BlinkStyleType
		{
			Steady = 0,
			Custom = 1,
			Blink = 2,
			LongBlink = 3,
			ShortBlink = 4,
			DoubleBlink = 5,
			Pulse = 6
		}

		private const string _blinkCurveInputXmlName = "blinkCurve";

		private UserCurve _blinkCurve;

		[SerializeField]
		[DesignerPropertySpinner(0f, 1000000f, 0.25f, Label = "Blink Frequency", Order = 40, Tooltip = "The frequency of the blinking.")]
		private float _blinkFrequency = 1f;

		[SerializeField]
		[DesignerPropertySpinner(-1000000f, 1000000f, 0.05f, Label = "Blink Offset", Order = 50, Tooltip = "The initial time offset value used when evaluating the current blink state of the light.")]
		private float _blinkOffset;

		[SerializeField]
		[DesignerPropertySpinner(new object[]
		{
			BlinkStyleType.Steady,
			BlinkStyleType.Blink,
			BlinkStyleType.LongBlink,
			BlinkStyleType.ShortBlink,
			BlinkStyleType.DoubleBlink,
			BlinkStyleType.Pulse
		}, Label = "Blink Style", TextFormat = DesignerPropertySpinnerTextFormat.Auto, Order = 30, Tooltip = "The blinking style of the light.")]
		private BlinkStyleType _blinkStyle;

		private UserCurve _customCurveInput;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Hide Base", Order = 10, Tooltip = "Toggles the base on/off where the light is mounted to the attached surface.")]
		private bool _hideBase;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _intensity = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _powerConsumptionScale = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 15, Tooltip = "Changes the overall size of the beacon.", TechTreeIdForMaxValue = "MaxSize.Beacon")]
		private float _scale = 1f;

		public UserCurve BlinkCurve => _blinkCurve;

		public float BlinkFrequency
		{
			get
			{
				return _blinkFrequency;
			}
			set
			{
				_blinkFrequency = value;
				if (_blinkCurve != null)
				{
					_blinkCurve.Frequency = value;
				}
			}
		}

		public float BlinkOffset
		{
			get
			{
				return _blinkOffset;
			}
			set
			{
				_blinkOffset = value;
				if (_blinkCurve != null)
				{
					_blinkCurve.CurrentTime = value;
				}
			}
		}

		public BlinkStyleType BlinkStyle
		{
			get
			{
				return _blinkStyle;
			}
			set
			{
				if (_blinkStyle != value)
				{
					_blinkStyle = value;
					UpdateBlinkCurve();
				}
			}
		}

		public bool HideBase
		{
			get
			{
				return _hideBase;
			}
			set
			{
				_hideBase = value;
			}
		}

		public float Intensity
		{
			get
			{
				return _intensity;
			}
			set
			{
				_intensity = value;
			}
		}

		public override float MassDry
		{
			get
			{
				if (!(base.Part.PartType.Id != "BeaconLight1"))
				{
					return Scale * (HideBase ? 1f : 2f) * 0.01f;
				}
				return 0f;
			}
		}

		public float PowerConsumptionScale => _powerConsumptionScale * base.Mass * 100f;

		public override long Price => (long)(5000f * base.Mass);

		public override float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
			}
		}

		public override string ScaleCareerID => "MaxSize.Beacon";

		public override XElement GenerateStateXml(bool optimizeXml = true)
		{
			XElement xElement = base.GenerateStateXml(optimizeXml);
			if (_blinkStyle == BlinkStyleType.Custom && _blinkCurve != null)
			{
				_blinkCurve.GenerateXml(xElement);
			}
			return xElement;
		}

		public override void RestoreFromState(XElement stateElement, bool restoreAll)
		{
			base.RestoreFromState(stateElement, restoreAll);
			if (_blinkStyle == BlinkStyleType.Custom)
			{
				_blinkCurve = (_customCurveInput = UserCurve.RestoreFromXml(stateElement, "blinkCurve", UserCurve.CurveWrapMode.Loop));
				if (_blinkCurve != null)
				{
					_blinkFrequency = _blinkCurve.Frequency;
				}
			}
			else
			{
				UpdateBlinkCurve();
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			bool isLightPart = base.Part.PartType.Id == "BeaconLight1";
			d.OnVisibilityRequested(() => _hideBase, (bool x) => isLightPart);
			d.OnVisibilityRequested(() => _scale, (bool x) => isLightPart);
			d.OnVisibilityRequested(() => _blinkFrequency, (bool x) => _blinkStyle != BlinkStyleType.Steady);
			d.OnVisibilityRequested(() => _blinkOffset, (bool x) => _blinkStyle != BlinkStyleType.Steady);
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _hideBase, delegate(bool value, bool prev)
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(BeaconLightData x)
				{
					x._hideBase = value;
					x.Script.InitializeLight();
				});
			});
			d.OnPropertyChanged(() => _blinkStyle, delegate
			{
				UpdateBlinkCurve();
			});
			d.OnPropertyChanged(() => _blinkFrequency, delegate
			{
				UpdateBlinkCurve();
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				d.Manager.RefreshUI();
				base.Script.UpdateScale();
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnActivated(delegate
			{
				base.Script.ActivationOverrideState = true;
			});
			d.OnDeactivated(delegate
			{
				base.Script.ActivationOverrideState = null;
			});
		}

		private void UpdateBlinkCurve()
		{
			if (_blinkStyle == BlinkStyleType.Steady)
			{
				_blinkCurve = new UserCurve("blinkCurve", UserCurve.CurveStyle.Constant, UserCurve.CurveWrapMode.Loop, new Keyframe(0f, 1f));
			}
			else if (_blinkStyle == BlinkStyleType.Blink)
			{
				_blinkCurve = new UserCurve("blinkCurve", UserCurve.CurveStyle.Constant, UserCurve.CurveWrapMode.Loop, new Keyframe(0f, 1f), new Keyframe(1f, 0f), new Keyframe(2f, 1f));
			}
			else if (_blinkStyle == BlinkStyleType.LongBlink)
			{
				_blinkCurve = new UserCurve("blinkCurve", UserCurve.CurveStyle.Constant, UserCurve.CurveWrapMode.Loop, new Keyframe(0f, 1f), new Keyframe(1.8f, 0f), new Keyframe(2f, 1f));
			}
			else if (_blinkStyle == BlinkStyleType.ShortBlink)
			{
				_blinkCurve = new UserCurve("blinkCurve", UserCurve.CurveStyle.Constant, UserCurve.CurveWrapMode.Loop, new Keyframe(0f, 1f), new Keyframe(0.1f, 0f), new Keyframe(1f, 1f));
			}
			else if (_blinkStyle == BlinkStyleType.DoubleBlink)
			{
				_blinkCurve = new UserCurve("blinkCurve", UserCurve.CurveStyle.Constant, UserCurve.CurveWrapMode.Loop, new Keyframe(0f, 1f), new Keyframe(0.1f, 0f), new Keyframe(0.2f, 1f), new Keyframe(0.3f, 0f), new Keyframe(1f, 1f));
			}
			else if (_blinkStyle == BlinkStyleType.Pulse)
			{
				_blinkCurve = new UserCurve("blinkCurve", UserCurve.CurveStyle.Smooth, UserCurve.CurveWrapMode.Loop, new Keyframe(0f, 0f), new Keyframe(1f, 1f), new Keyframe(2f, 0f));
			}
			else
			{
				_blinkCurve = _customCurveInput;
			}
			if (_blinkCurve != null)
			{
				_blinkCurve.CurrentTime = _blinkOffset;
				_blinkCurve.Frequency = _blinkFrequency;
			}
		}
	}
}
