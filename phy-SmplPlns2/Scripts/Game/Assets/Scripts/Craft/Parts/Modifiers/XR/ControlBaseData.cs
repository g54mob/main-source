using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.Input;
using Jundroo.Common.Extensions;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.XR
{
	[PartModifierDesignerHeader("Control Base")]
	public class ControlBaseData : PartModifierData
	{
		public enum ControlMode
		{
			Joint = 0,
			Transform = 1
		}

		private class ControlBasePreset
		{
			public ControlBaseScript.ControlAxis[] MovementAxes { get; set; }

			public string Name { get; set; }

			public ControlBaseScript.ControlAxis[] RotationAxes { get; set; }
		}

		private const string _CustomPresetName = "Custom";

		private static List<string> _aircraftControlSpinnerValues = new List<string>
		{
			GameInputs.Instance.Pitch.Id,
			GameInputs.Instance.Roll.Id,
			GameInputs.Instance.Yaw.Id,
			GameInputs.Instance.Throttle.Id,
			GameInputs.Instance.Vtol.Id,
			GameInputs.Instance.Trim.Id,
			GameInputs.Instance.Flaps.Id
		};

		private static Dictionary<string, List<ControlBasePreset>> _presets = new Dictionary<string, List<ControlBasePreset>>();

		private ControlBasePreset _customPreset;

		[DesignerPropertyToggleButton(new string[] { "Off", "On" }, Label = "Haptics", Order = 9)]
		private bool _haptics = true;

		[DesignerPropertyClass(Label = "Movement Axis", Order = 20)]
		private ControlBaseScript.ControlAxis[] _movementAxes = new ControlBaseScript.ControlAxis[0];

		[DesignerPropertyTextSpinner(new string[] { }, ExtraWidth = 65, ShrinkText = true, WrapText = true, Label = "Preset", Order = 10)]
		private ControlBasePreset _preset;

		private XElement _presetsXml;

		private bool _queuePartPropertiesRefresh;

		[DesignerPropertyClass(Label = "Rotation Axis", Order = 30)]
		private ControlBaseScript.ControlAxis[] _rotationAxes = new ControlBaseScript.ControlAxis[0];

		public int AttachPointId { get; private set; }

		public bool Haptics
		{
			get
			{
				return _haptics;
			}
			set
			{
				_haptics = value;
			}
		}

		public bool IgnoreAircraftCollisions { get; set; } = true;

		public ControlMode Mode { get; private set; }

		public ControlBaseScript.ControlAxis[] MovementAxes => _movementAxes;

		public JointDrive PositionDrive { get; set; }

		public ControlBaseScript.ControlAxis[] RotationAxes => _rotationAxes;

		public JointDrive SlerpDrive { get; set; }

		public string TargetTransformPath { get; private set; }

		public ControlBaseData(XElement xml)
			: base(xml)
		{
			if (!Enum.TryParse<ControlMode>(((string)xml.Attribute("mode")) ?? string.Empty, out var result))
			{
				result = ControlMode.Joint;
			}
			Mode = result;
			switch (result)
			{
			case ControlMode.Joint:
				AttachPointId = ((int?)xml.Attribute("attachPointId")) ?? 1;
				break;
			case ControlMode.Transform:
				TargetTransformPath = (string)xml.Attribute("targetTransformPath");
				break;
			default:
				Debug.LogError($"Unknown control mode: {result} on part {base.Part.Id}");
				break;
			}
			_presetsXml = xml.Element("Presets");
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			if (Mode == ControlMode.Joint)
			{
				xElement.SetAttributeValue("slerpMaximumForce", SlerpDrive.maximumForce);
				xElement.SetAttributeValue("slerpSpring", SlerpDrive.positionSpring);
				xElement.SetAttributeValue("slerpDamper", SlerpDrive.positionDamper);
				xElement.SetAttributeValue("positionMaximumForce", PositionDrive.maximumForce);
				xElement.SetAttributeValue("positionSpring", PositionDrive.positionSpring);
				xElement.SetAttributeValue("positionDamper", PositionDrive.positionDamper);
				xElement.SetAttributeValue("v", 2);
			}
			xElement.SetAttributeValue("haptics", Haptics);
			xElement.SetAttributeValue("ignoreAircraftCollisions", IgnoreAircraftCollisions);
			for (int i = 0; i < MovementAxes.Length; i++)
			{
				ControlBaseScript.ControlAxis controlAxis = MovementAxes[i];
				xElement.Add(new XElement("PositionAxis", new XAttribute("axis", controlAxis.Axis.ToXAttributeValue()), new XAttribute("input", controlAxis.InputName), new XAttribute("scale", controlAxis.Multiplier), new XAttribute("min", controlAxis.MinValue), new XAttribute("max", controlAxis.MaxValue)));
			}
			for (int j = 0; j < RotationAxes.Length; j++)
			{
				ControlBaseScript.ControlAxis controlAxis2 = RotationAxes[j];
				xElement.Add(new XElement("RotationAxis", new XAttribute("axis", controlAxis2.Axis.ToXAttributeValue()), new XAttribute("input", controlAxis2.InputName), new XAttribute("scale", controlAxis2.Multiplier), new XAttribute("min", controlAxis2.MinValue), new XAttribute("max", controlAxis2.MaxValue), new XAttribute("rotationMaxDistance", controlAxis2.RotationMaxDistance)));
			}
			return xElement;
		}

		public override void GetGenericDesignerPropertyTextSpinnerValues(ITextSpinnerProperty textSpinnerProperty, List<string> values)
		{
			if (textSpinnerProperty.Member.Name == "_preset")
			{
				values.Clear();
				if (_presets.TryGetValue(base.Part.PartType.PartTypeId, out var value))
				{
					values.AddRange(value.Select((ControlBasePreset x) => x.Name));
				}
				values.Add("Custom");
			}
			else if (textSpinnerProperty.Member.Name == "_input")
			{
				values.Clear();
				values.AddRange(_aircraftControlSpinnerValues);
			}
			else
			{
				base.GetGenericDesignerPropertyTextSpinnerValues(textSpinnerProperty, values);
			}
		}

		public override PartPropertyValueConverter GetGenericDesignerPropertyValueConverter(IConfigurableProperty property)
		{
			if (property.Member.Name == "_preset")
			{
				return new PartPropertyValueConverter<ControlBasePreset, string>((ControlBasePreset x) => x.Name, (string x) => _presets[base.Part.PartType.PartTypeId].FirstOrDefault((ControlBasePreset p) => p.Name == x) ?? _customPreset);
			}
			if (property.Member.Name == "_axis")
			{
				return new PartPropertyValueConverter<Vector3, string>(delegate(Vector3 v)
				{
					if (v == Vector3.right)
					{
						return "X";
					}
					if (v == Vector3.left)
					{
						return "-X";
					}
					if (v == Vector3.up)
					{
						return "Y";
					}
					if (v == Vector3.down)
					{
						return "-Y";
					}
					if (v == Vector3.forward)
					{
						return "Z";
					}
					return (v == Vector3.back) ? "-Z" : $"{v.x},{v.y},{v.z}";
				}, (string v) => v switch
				{
					"X" => Vector3.right, 
					"-X" => Vector3.left, 
					"Y" => Vector3.up, 
					"-Y" => Vector3.down, 
					"Z" => Vector3.forward, 
					"-Z" => Vector3.back, 
					_ => v.ParseVector3(), 
				});
			}
			return base.GetGenericDesignerPropertyValueConverter(property);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			ControlBaseScript controlBaseScript = parentGameObject.AddComponent<ControlBaseScript>();
			controlBaseScript.Initialize(this);
			return controlBaseScript;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
			if (_queuePartPropertiesRefresh)
			{
				_queuePartPropertiesRefresh = false;
				genericPartProperties.RefreshUI();
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName != "_preset" && _preset.Name != "Custom")
			{
				UpdateCustomPreset();
				_preset = _customPreset;
				_queuePartPropertiesRefresh = true;
			}
		}

		public override void OnGenericDesignerPropertyChanging(string propertyName, string newValue)
		{
			if (!(propertyName == "_preset"))
			{
				return;
			}
			if (_preset.Name == "Custom")
			{
				UpdateCustomPreset();
			}
			else if (_customPreset == null && newValue == "Custom")
			{
				UpdateCustomPreset();
			}
			if (newValue == "Custom")
			{
				ApplyPreset(_customPreset);
			}
			else
			{
				ControlBasePreset controlBasePreset = _presets[base.Part.PartType.PartTypeId].FirstOrDefault((ControlBasePreset x) => x.Name == newValue);
				ApplyPreset(controlBasePreset ?? _customPreset);
			}
			_queuePartPropertiesRefresh = true;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			if (!_presets.ContainsKey(base.Part.PartType.PartTypeId))
			{
				RegisterPresets(base.Part.PartType.PartTypeId, _presetsXml);
			}
			int intAttribute = stateElement.GetIntAttribute("v", 1);
			IgnoreAircraftCollisions = stateElement.GetBoolAttribute("ignoreAircraftCollisions", defaultValue: true);
			Haptics = stateElement.GetBoolAttribute("haptics", defaultValue: true);
			if (Mode == ControlMode.Joint)
			{
				SlerpDrive = new JointDrive
				{
					maximumForce = (((float?)stateElement.Attribute("slerpMaximumForce")) ?? 40000f),
					positionSpring = (((float?)stateElement.Attribute("slerpSpring")) ?? 400000f),
					positionDamper = (((float?)stateElement.Attribute("slerpDamper")) ?? 40f)
				};
				PositionDrive = new JointDrive
				{
					maximumForce = (((float?)stateElement.Attribute("positionMaximumForce")) ?? 30000f),
					positionSpring = (((float?)stateElement.Attribute("positionSpring")) ?? 5000f),
					positionDamper = (((float?)stateElement.Attribute("positionDamper")) ?? 20f)
				};
			}
			bool flag = intAttribute < 2 && Mode == ControlMode.Joint;
			Quaternion quaternion = default(Quaternion);
			if (flag)
			{
				quaternion = Quaternion.Inverse(Quaternion.Euler(base.Part.Rotation));
				quaternion *= quaternion;
			}
			List<ControlBaseScript.ControlAxis> list = new List<ControlBaseScript.ControlAxis>(3);
			foreach (XElement item in stateElement.Elements("PositionAxis"))
			{
				ControlBaseScript.ControlAxis controlAxis = ParseMotionAxis(item);
				if (controlAxis != null)
				{
					list.Add(controlAxis);
				}
			}
			if (list.Count != 0)
			{
				_movementAxes = list.ToArray();
				list.Clear();
			}
			else if (MovementAxes.Length != 0)
			{
				_movementAxes = new ControlBaseScript.ControlAxis[0];
			}
			foreach (XElement item2 in stateElement.Elements("RotationAxis"))
			{
				ControlBaseScript.ControlAxis controlAxis2 = ParseMotionAxis(item2);
				if (controlAxis2 != null)
				{
					if (flag)
					{
						controlAxis2.Axis = quaternion * controlAxis2.Axis;
					}
					list.Add(controlAxis2);
				}
			}
			if (list.Count != 0)
			{
				_rotationAxes = list.ToArray();
			}
			else if (RotationAxes.Length != 0)
			{
				_rotationAxes = new ControlBaseScript.ControlAxis[0];
			}
			if (base.Part.LoadContext == CraftLoadContext.Designer)
			{
				_preset = FindPresetMatch();
			}
			static ControlBaseScript.ControlAxis ParseMotionAxis(XElement el)
			{
				string text = (string)el.Attribute("input");
				if (string.IsNullOrWhiteSpace(text))
				{
					return null;
				}
				GameInputs.Instance.FindById(text);
				Vector3 vector3Attribute = el.GetVector3Attribute("axis", Vector3.zero);
				if (vector3Attribute == Vector3.zero)
				{
					return null;
				}
				float lhs = ((float?)el.Attribute("min")) ?? (-1f);
				float rhs = ((float?)el.Attribute("max")) ?? 1f;
				if (lhs > rhs)
				{
					Utilities.Swap(ref lhs, ref rhs);
				}
				return new ControlBaseScript.ControlAxis
				{
					Axis = vector3Attribute,
					InputName = text,
					Multiplier = (((float?)el.Attribute("scale")) ?? 1f),
					MinValue = lhs,
					MaxValue = rhs,
					RotationMaxDistance = (((float?)el.Attribute("rotationMaxDistance")) ?? 0.08f)
				};
			}
		}

		private static ControlBaseScript.ControlAxis Clone(ControlBaseScript.ControlAxis source)
		{
			return new ControlBaseScript.ControlAxis
			{
				Axis = source.Axis,
				InputName = source.InputName,
				MinValue = source.MinValue,
				MaxValue = source.MaxValue,
				Multiplier = source.Multiplier,
				RotationMaxDistance = source.RotationMaxDistance
			};
		}

		private static ControlBaseScript.ControlAxis[] Clone(ControlBaseScript.ControlAxis[] source)
		{
			ControlBaseScript.ControlAxis[] array = new ControlBaseScript.ControlAxis[source.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Clone(source[i]);
			}
			return array;
		}

		private static bool IsMatch(ControlBaseScript.ControlAxis a, ControlBaseScript.ControlAxis b)
		{
			if (a.Axis == b.Axis && a.InputName == b.InputName && a.MinValue == b.MinValue && a.MaxValue == b.MaxValue && a.Multiplier == b.Multiplier)
			{
				return a.RotationMaxDistance == b.RotationMaxDistance;
			}
			return false;
		}

		private static bool IsMatch(ControlBaseScript.ControlAxis[] a, ControlBaseScript.ControlAxis[] b)
		{
			bool flag = a.Length == b.Length;
			if (flag)
			{
				for (int i = 0; i < a.Length; i++)
				{
					flag &= IsMatch(a[i], b[i]);
				}
			}
			return flag;
		}

		private static void RegisterPresets(string partTypeId, XElement presetsXml)
		{
			_presets[partTypeId] = new List<ControlBasePreset>((presetsXml?.Elements() ?? new XElement[0]).Select((XElement presetXml) => new ControlBasePreset
			{
				Name = (string)presetXml.Attribute("name"),
				MovementAxes = (from x in presetXml.Elements("PositionAxis")
					select ParseAxisPreset(x)).ToArray(),
				RotationAxes = (from x in presetXml.Elements("RotationAxis")
					select ParseAxisPreset(x)).ToArray()
			}));
			static ControlBaseScript.ControlAxis ParseAxisPreset(XElement axisPresetXml)
			{
				return new ControlBaseScript.ControlAxis
				{
					Axis = axisPresetXml.GetVector3Attribute("axis", Vector3.zero),
					InputName = (string)axisPresetXml.Attribute("input"),
					Multiplier = (((float?)axisPresetXml.Attribute("scale")) ?? 1f),
					MinValue = (((float?)axisPresetXml.Attribute("min")) ?? (-1f)),
					MaxValue = (((float?)axisPresetXml.Attribute("max")) ?? 1f),
					RotationMaxDistance = (((float?)axisPresetXml.Attribute("rotationMaxDistance")) ?? 0.08f)
				};
			}
		}

		private void ApplyPreset(ControlBasePreset preset)
		{
			_movementAxes = Clone(preset.MovementAxes);
			_rotationAxes = Clone(preset.RotationAxes);
		}

		private ControlBasePreset FindPresetMatch()
		{
			foreach (ControlBasePreset item in _presets[base.Part.PartType.PartTypeId])
			{
				if (IsMatch(MovementAxes, item.MovementAxes) && IsMatch(RotationAxes, item.RotationAxes))
				{
					return item;
				}
			}
			UpdateCustomPreset();
			return _customPreset;
		}

		private void UpdateCustomPreset()
		{
			_customPreset = new ControlBasePreset
			{
				Name = "Custom",
				MovementAxes = Clone(MovementAxes),
				RotationAxes = Clone(RotationAxes)
			};
		}
	}
}
