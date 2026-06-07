using System;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Main Rotor")]
	public class HeliMainRotorData : BladedEngineData, IModifierWithOutputs
	{
		protected const string CenterOfMassOffsetYFieldName = "_centerOfMassOffsetY";

		protected const string CenterOfMassOffsetZFieldName = "_centerOfMassOffsetZ";

		private const string CenterOfMassOffsetAttributeName = "centerOfMassOffset";

		private const string CyclicPitchAttributeName = "cyclicPitchMaxDeflection";

		private const string CyclicRollAttributeName = "cyclicRollMaxDeflection";

		private const string RotorDampingAttributeName = "rotorDamping";

		private const string RotorDampingFieldName = "_rotorDamping";

		[DesignerPropertySlider(0f, 1f, 100, Label = "Collective Range", Order = 9)]
		private float _bladePitchScale;

		[DesignerPropertyToggleButton(new string[] { "Cropped", "Rounded", "Swept", "Tapered" }, Label = "Blade Style", Order = 5)]
		private string _bladeStyle;

		[DesignerPropertySlider(-10f, 10f, 101, Label = "Engine Mass Offset (y)", Order = 53)]
		private float _centerOfMassOffsetY;

		[DesignerPropertySlider(-10f, 10f, 101, Label = "Engine Mass Offset (z)", Order = 52)]
		private float _centerOfMassOffsetZ;

		[DesignerPropertySlider(0f, 25f, 26, Label = "Cyclic Pitch (deg)", Order = 50)]
		private float _cyclicPitchMaxDeflection;

		[DesignerPropertySlider(0f, 25f, 26, Label = "Cyclic Roll (deg)", Order = 51)]
		private float _cyclicRollMaxDeflection;

		private bool _originalComGizmoVisibility;

		[DesignerPropertyToggleButton(new string[] { "False", "True" }, Label = "Reverse Rotation", Order = 6)]
		private bool _reverseRotation;

		[DesignerPropertySlider(0f, 2f, 21, Label = "Vibration Damping", Order = 54)]
		private float _rotorDamping;

		public override string BladeStyle
		{
			get
			{
				return "HB-" + _bladeStyle;
			}
			set
			{
				_bladeStyle = value.Replace("HB-", string.Empty);
			}
		}

		public Vector3 CenterOfMassOffset { get; set; }

		public float CyclicPitchMaxDeflection => _cyclicPitchMaxDeflection;

		public float CyclicRollMaxDeflection => _cyclicRollMaxDeflection;

		public override float MaxDiameter => 32f;

		public override float MinDiameter => 5f;

		public override Type ModifierScriptType => typeof(HeliMainRotorScript);

		public override float PerformanceCost => (float)Mathf.Max(0, base.BladeCount - 2) * 16f;

		public override float PropellerPitchScale
		{
			get
			{
				return _bladePitchScale;
			}
			set
			{
				_bladePitchScale = value;
			}
		}

		public override bool ReverseRotation
		{
			get
			{
				return _reverseRotation;
			}
			set
			{
				_reverseRotation = value;
			}
		}

		public float RotorVibrationStrength { get; set; }

		public event PropertyChanged<HeliMainRotorData> CenterOfMassOffsetChanged;

		public HeliMainRotorData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("cyclicRollMaxDeflection", CyclicRollMaxDeflection.ToString()));
			xElement.Add(new XAttribute("cyclicPitchMaxDeflection", CyclicPitchMaxDeflection.ToString()));
			xElement.Add(new XAttribute("centerOfMassOffset", CenterOfMassOffset.ToString()));
			xElement.Add(new XAttribute("rotorDamping", _rotorDamping.ToString()));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_centerOfMassOffsetY":
			case "_centerOfMassOffsetZ":
				return $"{sliderValue:0.0}m";
			case "_rotorDamping":
				return $"{sliderValue * 100f:0}%";
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			return property.Member.Name switch
			{
				"_bladePitch" => () => true, 
				"_bladePitchScale" => () => true, 
				"_pitchControlType" => () => false, 
				_ => base.GetGenericDesignerPropertyVisibilityCallback(property), 
			};
		}

		public override void OnGenericDesignerPropertiesClosed()
		{
			base.OnGenericDesignerPropertiesClosed();
			UpdateComGizmo(visible: false);
		}

		public override void OnGenericDesignerPropertiesPartDeselected()
		{
			base.OnGenericDesignerPropertiesPartDeselected();
			UpdateComGizmo(visible: false);
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			ISliderProperty property = genericPartPropertiesScript.GetProperty<ISliderProperty>("_diameter");
			property.SliderAttribute.MinValue = MinDiameter;
			property.SliderAttribute.MaxValue = MaxDiameter;
			property.Value = (base.Diameter - MinDiameter) / (MaxDiameter - MinDiameter);
			_originalComGizmoVisibility = Designer.Instance.ShowCenterOfMassGizmo;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_centerOfMassOffsetY" || propertyName == "_centerOfMassOffsetZ")
			{
				OnComOffsetsChanged();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_cyclicPitchMaxDeflection = stateElement.GetFloatAttribute("cyclicPitchMaxDeflection", 15f);
			_cyclicRollMaxDeflection = stateElement.GetFloatAttribute("cyclicRollMaxDeflection", 15f);
			CenterOfMassOffset = stateElement.GetVector3Attribute("centerOfMassOffset", Vector3.zero);
			_rotorDamping = stateElement.GetFloatAttribute("rotorDamping", 1f);
			_centerOfMassOffsetY = CenterOfMassOffset.y;
			_centerOfMassOffsetZ = CenterOfMassOffset.z;
			float num = 10000f - (_rotorDamping - 1f) * 10000f;
			RotorVibrationStrength = base.Diameter * num;
		}

		protected override BladedEngineScript AddBladedEngineModifier(GameObject gameObject)
		{
			return gameObject.AddComponent<HeliMainRotorScript>();
		}

		private void OnComOffsetsChanged()
		{
			CenterOfMassOffset = new Vector3(CenterOfMassOffset.x, _centerOfMassOffsetY, _centerOfMassOffsetZ);
			this.CenterOfMassOffsetChanged?.Invoke(this);
			UpdateComGizmo(visible: true);
		}

		private void UpdateComGizmo(bool visible)
		{
			if (base.Part?.PartScript != null)
			{
				Designer instance = Designer.Instance;
				instance.ShowCenterOfMassGizmo = (visible ? visible : _originalComGizmoVisibility);
				instance.UpdatePartCenterGizmo(visible, base.Part.PartScript.transform.TransformPoint(base.Part.CenterOfMass));
			}
		}
	}
}
