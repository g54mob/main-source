using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Craft.Wings;
using Assets.Scripts.Craft.Wings.Runtime;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Math;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Wing")]
	public class JWingData : PartModifierData
	{
		private const int CurrentVersion = 3;

		private Vector3 _com;

		[SerializeField]
		private int _defaultChordSamples;

		[SerializeField]
		private int _defaultColliderSamples;

		[DesignerPropertyButton(Label = "Edit Shape", Style = ButtonStyle.Primary, Order = 0)]
		private bool _editShape;

		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Flip Airfoil", Order = 10)]
		private bool _flipped;

		[SerializeField]
		private bool _disableWingtipVortices;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Fuel", Order = 1)]
		private float _fuelFraction;

		[SerializeField]
		private List<InputWingSlice> _inputSlices;

		private float _mass;

		private MassPropertiesOutput _massProperties;

		[SerializeField]
		private int? _physicsSamples = 8;

		[SerializeField]
		private WingTipStyle _wingTip;

		[SerializeField]
		private float _liftScale;

		[SerializeField]
		private float _viscousDragScale;

		[SerializeField]
		private float _zeroLiftDragScale;

		public bool DisableWingtipVortices => _disableWingtipVortices;

		public override Vector3 CoM => _com;

		public List<ControlSurfacePartData> ControlSurfacesInformational { get; } = new List<ControlSurfacePartData>();

		public bool Flipped
		{
			get
			{
				return _flipped;
			}
			set
			{
				_flipped = value;
			}
		}

		public float FuelFraction
		{
			get
			{
				return _fuelFraction;
			}
			set
			{
				_fuelFraction = value;
			}
		}

		public float LiftScale => _liftScale;

		public override float Mass => _mass;

		public int? PhysicsSamples
		{
			get
			{
				return _physicsSamples;
			}
			set
			{
				_physicsSamples = value;
			}
		}

		public float TotalFuelVolume { get; private set; }

		public float ViscousDragScale => _viscousDragScale;

		public float WingArea
		{
			get
			{
				float num = 0f;
				for (int i = 0; i + 1 < _inputSlices.Count; i++)
				{
					InputWingSlice inputWingSlice = _inputSlices[i];
					InputWingSlice inputWingSlice2 = _inputSlices[i + 1];
					num += (inputWingSlice.Scale + inputWingSlice2.Scale) * 0.5f * (inputWingSlice2.Position - inputWingSlice.Position);
				}
				return num;
			}
		}

		public List<InputWingSlice> WingSlices => _inputSlices;

		public float WingSpan
		{
			get
			{
				List<InputWingSlice> inputSlices = _inputSlices;
				return inputSlices[inputSlices.Count - 1].Position;
			}
		}

		public WingTipStyle WingTipStyle
		{
			get
			{
				return _wingTip;
			}
			set
			{
				_wingTip = value;
			}
		}

		public float ZeroLiftDragScale => _zeroLiftDragScale;

		public event Action WingDataChanged;

		public JWingData(XElement element)
			: base(element)
		{
		}

		public static void UpgradeControlSurfaces(XElement aircraftXml)
		{
			XElement xElement = aircraftXml.Element("Assembly");
			XElement xElement2 = xElement.Element("Parts");
			int val = 0;
			List<XElement> list = new List<XElement>();
			foreach (XElement item in xElement2.Elements("Part"))
			{
				val = Math.Max(val, (int)item.Attribute("id"));
				if (item.Attribute("partType").Value == "JWing-1")
				{
					list.Add(item);
				}
			}
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			XElement xElement3 = xElement.Element("Connections");
			foreach (XElement item2 in list)
			{
				int num = (int)item2.Attribute("id");
				List<int> list2 = new List<int>();
				while (true)
				{
					XElement xElement4 = item2.Element("JWing.State").Element("ControlSurface");
					if (xElement4 == null)
					{
						break;
					}
					xElement4.Remove();
					int num2 = ++val;
					string text = xElement4.Attribute("style")?.Value switch
					{
						"StandardFlap" => "ControlSurface-Flap-1", 
						"FowlerFlap" => "ControlSurface-Flap-2", 
						"BrakeFlap" => "ControlSurface-Flap-3", 
						_ => null, 
					};
					if (text == null)
					{
						continue;
					}
					string text2;
					try
					{
						text2 = item2.Attribute("materials").Value.Split(",")[1];
					}
					catch
					{
						text2 = "2";
					}
					XElement xElement5 = new XElement("Part", new XAttribute("id", num2), new XAttribute("partType", text), item2.Attribute("position"), item2.Attribute("rotation"), new XAttribute("materials", text2 + "," + text2), new XElement(xElement4)
					{
						Name = "ControlSurfacePart.State"
					});
					bool boolAttribute = item2.Element("JWing.State").GetBoolAttribute("flipped");
					foreach (XElement item3 in xElement4.Elements("Input"))
					{
						bool boolAttribute2 = item3.GetBoolAttribute("invert");
						boolAttribute2 ^= boolAttribute && item3.GetBoolAttribute("invertOnMirror");
						xElement5.Add(new XElement("InputController.State", new XAttribute("input", item3.GetStringAttribute("axis")), new XAttribute("invert", boolAttribute2)));
					}
					while (true)
					{
						XElement xElement6 = xElement4.Element("Input");
						if (xElement6 == null)
						{
							break;
						}
						xElement6.Remove();
					}
					xElement2.Add(xElement5);
					xElement3.Add(new XElement("Connection", new XAttribute("partA", num), new XAttribute("partB", num2), new XAttribute("attachPointsA", 1), new XAttribute("attachPointsB", 0)));
					list2.Add(num2);
				}
				if (list2.Count > 0)
				{
					dictionary.Add(num, list2);
				}
			}
			XElement xElement7 = xElement.Element("Bodies");
			if (xElement7 == null)
			{
				return;
			}
			List<int> list3 = new List<int>();
			foreach (XElement item4 in xElement7.Elements("Body"))
			{
				string text3 = (string)item4.Attribute("partIds");
				list3.Clear();
				string[] array = text3.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					if (int.TryParse(array[i], out var result) && dictionary.TryGetValue(result, out var value))
					{
						list3.AddRange(value);
					}
				}
				if (list3.Count <= 0)
				{
					continue;
				}
				StringBuilder stringBuilder = new StringBuilder(text3);
				foreach (int item5 in list3)
				{
					stringBuilder.Append(',');
					stringBuilder.Append(item5);
				}
				item4.SetAttributeValue("partIds", stringBuilder.ToString());
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement root = base.GenerateStateXml();
			if (_physicsSamples.HasValue)
			{
				root.SetAttributeValue("physicsSamples", _physicsSamples.Value);
			}
			root.SetAttributeValue("chordSamples", _defaultChordSamples);
			root.SetAttributeValue("colliderSamples", _defaultColliderSamples);
			root.SetAttributeValue("flipped", _flipped);
			root.SetAttributeValue("fuelFraction", _fuelFraction);
			root.SetAttributeValue("version", 3);
			root.SetAttributeValue("disableWingtipVortices", _disableWingtipVortices);
			SetIfSet("liftScale", _liftScale);
			SetIfSet("zeroLiftDragScale", _zeroLiftDragScale);
			SetIfSet("viscousDragScale", _viscousDragScale);
			foreach (InputWingSlice inputSlice in _inputSlices)
			{
				XElement xElement = new XElement("Slice");
				inputSlice.SaveToXml(xElement);
				root.Add(xElement);
			}
			if (_wingTip != null)
			{
				XElement xElement2 = new XElement("Wingtip");
				_wingTip.SaveToXML(xElement2);
				root.Add(xElement2);
			}
			return root;
			void SetIfSet(string name, float value, float def = 1f)
			{
				if (value != def)
				{
					root.SetAttributeValue(name, value);
				}
			}
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_fuelFraction")
			{
				return $"{sliderValue:0%} ({(sliderValue * TotalFuelVolume).Format(UnitType.Volume)})";
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			JWingScript jWingScript = parentGameObject.AddComponent<JWingScript>();
			jWingScript.Init(this, partCreationInfo.EnableWingScript && partCreationInfo.CreateRigidBody);
			return jWingScript;
		}

		public override void OnGenericDesignerPropertyButtonClicked(IConfigurableProperty property)
		{
			base.OnGenericDesignerPropertyButtonClicked(property);
			if (property.Member.Name == "_editShape")
			{
				_ = Designer.Instance.DesignerScript.DesignerUI;
				Designer.Instance.Tools.SelectJWingAdjustmentTool();
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_fuelFraction")
			{
				UpdateFuelDesigner(raiseChangeEvent: true);
			}
			else if (propertyName == "_flipped")
			{
				UpdateMeshes();
			}
		}

		public void OnWingMeshRebuilt(in WingBuildOutput output)
		{
			_massProperties = output.MassPropertiesOutput[0];
			_mass = _massProperties.Mass * 0.01f;
			_com = _massProperties.CentreOfMass;
			base.Part.CenterOfMass = _com;
			TotalFuelVolume = output.MassPropertiesOutput[0].FuelVolume * 1000f;
			UpdateFuelDesigner(raiseChangeEvent: false);
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			int intAttribute = stateElement.GetIntAttribute("version", 1);
			_physicsSamples = stateElement.GetIntAttributeOrNull("physicsSamples");
			_defaultChordSamples = stateElement.GetIntAttribute("chordSamples", 10);
			_defaultColliderSamples = stateElement.GetIntAttribute("colliderSamples", 5);
			_fuelFraction = stateElement.GetFloatAttribute("fuelFraction");
			_flipped = stateElement.GetBoolAttribute("flipped");
			_inputSlices = new List<InputWingSlice>(from x in stateElement.Elements("Slice")
				select new InputWingSlice(x, _defaultChordSamples, _defaultColliderSamples));
			_disableWingtipVortices = stateElement.GetBoolAttribute("disableWingtipVortices");
			_liftScale = stateElement.GetFloatAttribute("liftScale", 1f);
			_zeroLiftDragScale = stateElement.GetFloatAttribute("zeroLiftDragScale", 1f);
			_viscousDragScale = stateElement.GetFloatAttribute("viscousDragScale", 1f);
			if (intAttribute < 2 && _physicsSamples == 8)
			{
				_physicsSamples = null;
			}
			else if (intAttribute == 2 && _physicsSamples == 24)
			{
				_physicsSamples = null;
			}
			XElement xElement = stateElement.Element("Wingtip");
			if (xElement != null)
			{
				try
				{
					_wingTip = WingTipRegistry.Resolve(xElement);
					return;
				}
				catch (Exception arg)
				{
					Debug.LogError($"Error loading wingtip xml: {arg}");
					_wingTip = null;
					return;
				}
			}
			_wingTip = null;
		}

		public void SynchronizeSymmetricParts()
		{
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				base.Part.PartScript.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(base.Part, value);
				foreach (PartConnection partConnection in base.Part.PartConnections)
				{
					partConnection.GetOtherPart(base.Part).GetModifier<ControlSurfacePartData>()?.SynchronizeSymmetricParts(updateMeshes: false);
				}
				bool flipped = ((value.Count == 1) ? (!_flipped) : _flipped);
				foreach (PartData item in value)
				{
					JWingData modifier = item.GetModifier<JWingData>();
					if (modifier == null)
					{
						Debug.LogError($"Wing modifier not found on symmetric part {item.Id}");
						continue;
					}
					modifier._physicsSamples = PhysicsSamples;
					modifier._defaultChordSamples = _defaultChordSamples;
					modifier._defaultColliderSamples = _defaultColliderSamples;
					modifier._fuelFraction = _fuelFraction;
					modifier._flipped = flipped;
					modifier._wingTip = _wingTip;
					modifier._inputSlices.Clear();
					foreach (InputWingSlice inputSlice in _inputSlices)
					{
						modifier._inputSlices.Add(inputSlice.Clone());
					}
					modifier.UpdateMeshes(updateSymmetricParts: false);
				}
			}
		}

		public void UpdateFuelDesigner(bool raiseChangeEvent)
		{
			FuelTankData modifier = base.Part.GetModifier<FuelTankData>();
			if (modifier != null)
			{
				float capacity = (modifier.Fuel = FuelFraction * TotalFuelVolume);
				modifier.Capacity = capacity;
				if (raiseChangeEvent)
				{
					Designer.Instance.OnAircraftStructureChanged();
				}
			}
		}

		public void UpdateMeshes(bool updateSymmetricParts = true)
		{
			this.WingDataChanged?.Invoke();
			if (updateSymmetricParts)
			{
				SynchronizeSymmetricParts();
			}
		}

		protected override float CalculateMass()
		{
			return _mass;
		}
	}
}
