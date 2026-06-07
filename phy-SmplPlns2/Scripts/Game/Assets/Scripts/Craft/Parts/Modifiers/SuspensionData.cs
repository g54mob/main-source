using System;
using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Suspension")]
	public class SuspensionData : PartModifierData, IModifierWithOutputs
	{
		private const float DefaultDamper = 1f;

		private const float DefaultSpring = 1f;

		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Damper", Order = 10)]
		private float _damper = 1f;

		[DesignerPropertySlider(0.5f, 2f, 151, Label = "Radius", Order = 2)]
		private float _radius = 1f;

		[DesignerPropertySlider(0.25f, 2.5f, 226, Label = "Size", Order = 1)]
		private float _size = 1f;

		[DesignerPropertySlider(0.1f, 2.5f, 25, Label = "Spring Strength", Order = 5)]
		private float _spring = 1f;

		public int AttachPointIndex { get; set; }

		public float Damper => _damper;

		public Type ModifierScriptType => typeof(SuspensionScript);

		public float Radius => _radius;

		public float Spring => _spring;

		public SuspensionData(XElement element)
			: base(element)
		{
			AttachPointIndex = element.GetIntAttribute("attachPoint");
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("damper", _damper), new XAttribute("spring", _spring));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_damper":
			case "_spring":
			case "_size":
			case "_radius":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("Suspension");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			SuspensionScript suspensionScript = gameObject.AddComponent<SuspensionScript>();
			suspensionScript.Suspension = this;
			return suspensionScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_size" || propertyName == "_radius")
			{
				PartScaleHelper.ApplyScaleWithAnchor(base.Part, _size, _radius);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_size = base.Part.PartScale?.y ?? 1f;
			_radius = ((_size > 0f) ? ((base.Part.PartScale?.x ?? _size) / _size) : 1f);
			_spring = stateElement.GetFloatAttribute("spring", 1f);
			if (_spring < 0f)
			{
				_spring = 0.01f;
			}
			_damper = stateElement.GetFloatAttribute("damper", 1f);
			if (_damper < 0f)
			{
				_damper = 0f;
			}
		}
	}
}
