using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Wing")]
	public class WingData : PartModifierData, IModifierWithOutputs
	{
		private const float MaxThickness = 5f;

		[DesignerPropertyButton(Label = "Add Control Surface", Style = ButtonStyle.Primary, Order = 999)]
		private bool _addControlSurface;

		[DesignerPropertyToggleButton(new string[] { "Symmetric", "Semi-Symmetric", "Flat Bottom" }, Label = "Airfoil", Order = 4)]
		private string _airfoil;

		[DesignerPropertySlider(0f, 5f, 51, Label = "Base Thickness", Order = 5)]
		private float _baseThickness;

		[DesignerPropertyClass(Label = "Control Surface", Order = 10)]
		private List<ControlSurfaceData> _controlSurfaces = new List<ControlSurfaceData>();

		[DesignerPropertyButton(Label = "Edit Dihedral", Style = ButtonStyle.Default, Order = 2)]
		private bool _editDihedral;

		[DesignerPropertyButton(Label = "Edit Wing Shape", Style = ButtonStyle.Primary, Order = 1)]
		private bool _editWingShape;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Fuel", Order = 5)]
		private float _fuelPercentage;

		private WingScript _script;

		[DesignerPropertySlider(0f, 5f, 51, Label = "Tip Thickness", Order = 5)]
		private float _tipThickness;

		private WingDesignerHelper _wingDesignerHelper;

		public string Airfoil
		{
			get
			{
				return _airfoil;
			}
			set
			{
				_airfoil = value;
			}
		}

		public bool AllowControlSurfaces { get; set; }

		public float AngleOfAttack { get; set; }

		public float BaseChord => RootLeadingOffset + RootTrailingOffset;

		public float BaseThickness
		{
			get
			{
				return _baseThickness;
			}
			set
			{
				_baseThickness = value;
			}
		}

		public List<ControlSurfaceData> ControlSurfaces => _controlSurfaces;

		public float Density { get; private set; }

		public float FuelPercentage
		{
			get
			{
				return _fuelPercentage;
			}
			set
			{
				_fuelPercentage = value;
			}
		}

		public float HingeDistanceFromTrailingEdge { get; set; }

		public bool Inverted { get; set; }

		public float LiftScale { get; set; }

		public override float Mass => base.Mass;

		public float MinSectionLength { get; set; }

		public Type ModifierScriptType => typeof(WingScript);

		public override float PerformanceCost
		{
			get
			{
				float num = 1.5f;
				if (WingPhysicsEnabled)
				{
					num += (float)PhysicsSimulationSectionCount * 1.26f + (float)ControlSurfaces.Count * 1.1f;
				}
				return num;
			}
		}

		public int PhysicsSimulationSectionCount
		{
			get
			{
				int num = SimulationSectionCount;
				if (ControlSurfaces.Count == 0)
				{
					num = ((!AllowControlSurfaces) ? 1 : (num / 2));
				}
				if (num < 1)
				{
					num = 1;
				}
				return num;
			}
		}

		public float RootLeadingOffset { get; set; }

		public float RootTrailingOffset { get; set; }

		public int SimulationSectionCount => Mathf.Clamp((int)(WingSpan / MinSectionLength), 1, 15);

		public float TipChord => TipLeadingOffset + TipTrailingOffset;

		public float TipLeadingOffset { get; set; }

		public Vector3 TipPosition { get; set; }

		public float TipThickness
		{
			get
			{
				return _tipThickness;
			}
			set
			{
				_tipThickness = value;
			}
		}

		public float TipTrailingOffset { get; set; }

		public override bool UsedInPropMode => true;

		public float WingArea => (BaseChord + TipChord) / 2f * WingSpan;

		public bool WingPhysicsEnabled { get; set; }

		public float WingSpan => Mathf.Sqrt(TipPosition.x * TipPosition.x + TipPosition.y * TipPosition.y);

		public WingData(XElement element)
			: base(element)
		{
			Density = float.Parse(element.Attribute("density").Value);
			MinSectionLength = element.GetFloatAttribute("minSectionLength", 0.25f);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("angleOfAttack", AngleOfAttack.ToString()), new XAttribute("airfoil", Airfoil.ToString()), new XAttribute("inverted", Inverted.ToString().ToLower()), new XAttribute("wingPhysicsEnabled", WingPhysicsEnabled.ToString().ToLower()), new XAttribute("rootLeadingOffset", RootLeadingOffset.ToString()), new XAttribute("rootTrailingOffset", RootTrailingOffset.ToString()), new XAttribute("tipLeadingOffset", TipLeadingOffset.ToString()), new XAttribute("tipTrailingOffset", TipTrailingOffset.ToString()), new XAttribute("tipPosition", TipPosition.ToXAttributeValue()), new XAttribute("hingeDistance", HingeDistanceFromTrailingEdge.ToString()), new XAttribute("allowControlSurfaces", AllowControlSurfaces.ToString().ToLower()), new XAttribute("fuelPercentage", FuelPercentage.ToString()), new XAttribute("baseThickness", BaseThickness.ToString()), new XAttribute("tipThickness", TipThickness.ToString()));
			if (LiftScale != 1f)
			{
				xElement.Add(new XAttribute("liftScale", LiftScale));
			}
			foreach (ControlSurfaceData controlSurface in ControlSurfaces)
			{
				xElement.Add(controlSurface.GenerateXml());
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_fuelPercentage":
				return Utilities.GetFuelPercentageString(_script.MaxFuelCapacity, sliderValue);
			case "_baseThickness":
			case "_tipThickness":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("Wing");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			_script = gameObject.AddComponent<WingScript>();
			_script.Wing = this;
			_script.Initialize(parentGameObject.GetComponent<PartScript>(), partCreationInfo.CreateRigidBody);
			return _script;
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			_wingDesignerHelper = new WingDesignerHelper(_script, genericPartPropertiesScript);
		}

		public override void OnGenericDesignerPropertyButtonClicked(IConfigurableProperty property)
		{
			base.OnGenericDesignerPropertyButtonClicked(property);
			if (property.Member.Name == "_addControlSurface")
			{
				_wingDesignerHelper.AddControlSurface();
			}
			else if (property.Member.Name == "_editWingShape")
			{
				_wingDesignerHelper.EditWingShape();
			}
			else if (property.Member.Name == "_editDihedral")
			{
				_wingDesignerHelper.EditDihedral();
			}
			else if (property.Member.Name == "_editControlSurfaceShape")
			{
				_wingDesignerHelper.EditControlSurface(property.ParentProperty.ChildIndex);
			}
			else if (property.Member.Name == "_deleteControlSurface")
			{
				_wingDesignerHelper.DeleteControlSurface(property.ParentProperty.ChildIndex);
				property.ParentProperty.ParentProperty?.RefreshUI();
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_baseThickness":
			case "_tipThickness":
				_script.UpdateWingShape();
				break;
			case "_fuelPercentage":
				_script.UpdateFuel();
				Designer.Instance.OnAircraftStructureChanged();
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			foreach (XElement item in stateElement.Elements("ControlSurface"))
			{
				ControlSurfaces.Add(new ControlSurfaceData(item));
			}
			AngleOfAttack = float.Parse(stateElement.Attribute("angleOfAttack").Value);
			RootLeadingOffset = float.Parse(stateElement.Attribute("rootLeadingOffset").Value);
			RootTrailingOffset = float.Parse(stateElement.Attribute("rootTrailingOffset").Value);
			TipLeadingOffset = float.Parse(stateElement.Attribute("tipLeadingOffset").Value);
			TipTrailingOffset = float.Parse(stateElement.Attribute("tipTrailingOffset").Value);
			BaseThickness = stateElement.GetFloatAttribute("baseThickness", 1f);
			TipThickness = stateElement.GetFloatAttribute("tipThickness", 1f);
			TipPosition = stateElement.GetVector3Attribute("tipPosition");
			HingeDistanceFromTrailingEdge = float.Parse(stateElement.Attribute("hingeDistance").Value);
			FuelPercentage = stateElement.GetFloatAttribute("fuelPercentage");
			AllowControlSurfaces = stateElement.GetBoolAttribute("allowControlSurfaces", defaultValue: true);
			Airfoil = stateElement.GetStringAttribute("airfoil", "Symmetric");
			WingPhysicsEnabled = stateElement.GetBoolAttribute("wingPhysicsEnabled", defaultValue: true);
			Inverted = bool.Parse(stateElement.Attribute("inverted").Value);
			LiftScale = stateElement.GetFloatAttribute("liftScale", 1f);
			if (!WingPhysicsEnabled)
			{
				base.Part.DragTypeDefault = PartDragType.Standard;
			}
		}

		protected override float CalculateMass()
		{
			return WingArea * Density * 0.01f;
		}
	}
}
