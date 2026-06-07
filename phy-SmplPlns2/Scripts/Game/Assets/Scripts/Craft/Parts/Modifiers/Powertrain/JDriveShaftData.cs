using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	[PartModifierDesignerHeader("Drive Shaft")]
	public class JDriveShaftData : PartModifierData
	{
		[DesignerPropertyToggleButton(new string[] { }, Label = "Boot A", Order = 10, Tooltip = "Show the CV boot")]
		private bool _bootA = true;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Boot B", Order = 20, Tooltip = "Show the CV boot")]
		private bool _bootB = true;

		[DesignerPropertySlider(0.5f, 2f, 31, Label = "Radius", Order = 1)]
		private float _radius = 1f;

		private bool _visual = true;

		public override bool AllowTransformation
		{
			get
			{
				if (_visual)
				{
					return base.Part.PartConnections.Count == 0;
				}
				return true;
			}
		}

		public bool BootA => _bootA;

		public bool BootB => _bootB;

		public override bool IsGenericDesignerPropertiesVisible => _visual;

		public bool IsVisual => _visual;

		public Vector3 LocalAttachEnd { get; internal set; }

		public Vector3 LocalAttachStart { get; internal set; }

		public float Radius => _radius;

		public JDriveShaftScript Script { get; private set; }

		public JDriveShaftData(XElement partType)
			: base(partType)
		{
			_visual = partType.GetBoolAttribute("visual", _visual);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			if (_visual)
			{
				Script?.OnSaveState();
				xElement.SetAttributeValue("radius", _radius);
				xElement.SetAttributeValue("bootA", _bootA);
				xElement.SetAttributeValue("bootB", _bootB);
				xElement.SetAttributeValue("start", LocalAttachStart);
				xElement.SetAttributeValue("end", LocalAttachEnd);
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_radius")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			return () => _visual;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.GetComponent<JDriveShaftScript>();
			if (Script == null)
			{
				Script = parentGameObject.AddComponent<JDriveShaftScript>();
			}
			Script.Initialize(this);
			return Script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			Script.UpdateBootVisuals();
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			if (_visual)
			{
				_radius = stateElement.GetFloatAttribute("radius", _radius);
				_bootA = stateElement.GetBoolAttribute("bootA", _bootA);
				_bootB = stateElement.GetBoolAttribute("bootB", _bootB);
				LocalAttachStart = stateElement.GetVector3Attribute("start", base.Part.AttachPoints[0].Position);
				LocalAttachEnd = stateElement.GetVector3Attribute("end", base.Part.AttachPoints[1].Position);
			}
		}
	}
}
