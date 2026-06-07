using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Piston")]
	public class PistonData : PartModifierData
	{
		private const float DefaultRange = 0.5f;

		private const float DefaultSpeed = 0.5f;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Cycle", Order = 15)]
		private bool _cycle;

		[DesignerPropertyLabel]
		private string _errorMessage = string.Empty;

		[DesignerPropertyToggleButton(new string[] { "Pull", "Push" }, Label = "Direction", Order = 20)]
		private bool _extend = true;

		[DesignerPropertySlider(0.5f, 2f, 151, Label = "Radius", Order = 2)]
		private float _radius = 1f;

		[DesignerPropertySlider(0.05f, 0.75f, 15, Label = "Range", Order = 10)]
		private float _range = 0.5f;

		[DesignerPropertySlider(0.25f, 2.5f, 226, Label = "Size", Order = 1)]
		private float _size = 1f;

		[DesignerPropertySlider(0.1f, 1f, 10, Label = "Speed", Order = 5)]
		private float _speed = 0.5f;

		public int AttachPointIndex { get; set; }

		public bool Cycle => _cycle;

		public bool Extend => _extend;

		public float MaxRange { get; set; }

		public float MaxSpeed { get; set; }

		public bool PreventBreaking { get; set; }

		public float Radius => _radius;

		public float Range => _range;

		public float Speed => _speed;

		public PistonData(XElement element)
			: base(element)
		{
			AttachPointIndex = element.GetIntAttribute("attachPoint");
			MaxSpeed = element.GetFloatAttribute("maxSpeed", 1f);
			MaxRange = element.GetFloatAttribute("maxRange", 0.5f);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("preventBreaking", PreventBreaking.ToString().ToLower()));
			xElement.Add(new XAttribute("cycle", _cycle.ToString().ToLower()));
			xElement.Add(new XAttribute("extend", _extend.ToString().ToLower()));
			xElement.Add(new XAttribute("range", _range.ToString()));
			xElement.Add(new XAttribute("speed", _speed.ToString()));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_speed":
			case "_range":
			case "_size":
			case "_radius":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("Piston");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			PistonScript pistonScript = gameObject.AddComponent<PistonScript>();
			pistonScript.Piston = this;
			return pistonScript;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			string empty = string.Empty;
			if (base.Part.AttachPoints[AttachPointIndex].IsAvailable)
			{
				genericPartProperties.SetPropertyStatus("_extend", IGenericPartProperties.PropertyStatus.Visible);
				genericPartProperties.SetPropertyStatus("_range", IGenericPartProperties.PropertyStatus.Visible);
				empty = string.Empty;
			}
			else if (Extend)
			{
				genericPartProperties.SetPropertyStatus("_extend", IGenericPartProperties.PropertyStatus.Hidden);
				genericPartProperties.SetPropertyStatus("_range", IGenericPartProperties.PropertyStatus.Visible);
				empty = "Direction cannot be changed while a part is connected to the moving end of the piston.";
			}
			else
			{
				genericPartProperties.SetPropertyStatus("_extend", IGenericPartProperties.PropertyStatus.Hidden);
				genericPartProperties.SetPropertyStatus("_range", IGenericPartProperties.PropertyStatus.Hidden);
				empty = "Range and Direction cannot be changed while a part is connected to the moving end of the piston.";
			}
			if (_errorMessage != empty)
			{
				_errorMessage = empty;
				genericPartProperties.RefreshUI();
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_size":
			case "_radius":
				PartScaleHelper.ApplyScaleWithAnchor(base.Part, _size, _radius);
				break;
			case "_range":
			case "_extend":
				UpdateAttachPoint();
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_size = base.Part.PartScale?.y ?? 1f;
			_radius = ((_size > 0f) ? ((base.Part.PartScale?.x ?? _size) / _size) : 1f);
			PreventBreaking = stateElement.GetBoolAttribute("preventBreaking");
			_extend = stateElement.GetBoolAttribute("extend", defaultValue: true);
			_range = stateElement.GetFloatAttribute("range", 0.5f);
			_speed = stateElement.GetFloatAttribute("speed", 0.5f);
			_cycle = stateElement.GetBoolAttribute("cycle");
			if (_range < 0f)
			{
				_range = 0.01f;
			}
			UpdateAttachPoint();
		}

		private void UpdateAttachPoint()
		{
			if (AttachPointIndex < base.Part.AttachPoints.Count)
			{
				AttachPointData attachPointData = base.Part.AttachPoints[AttachPointIndex];
				if (_extend)
				{
					attachPointData.Position = new Vector3(0f, 0.25f, 0f);
				}
				else
				{
					attachPointData.Position = new Vector3(0f, 0.25f + Range, 0f);
				}
				if (base.Part.PartScript != null && attachPointData.AttachPointScript != null)
				{
					attachPointData.AttachPointScript.transform.localPosition = attachPointData.Position;
				}
			}
		}
	}
}
