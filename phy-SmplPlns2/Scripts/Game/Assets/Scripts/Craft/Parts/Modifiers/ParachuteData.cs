using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Parachute")]
	public class ParachuteData : PartModifierData
	{
		public class ParachuteStyles
		{
			public const string Checkered = "Checkered";

			public const string HorizontalStriped = "H. Striped";

			public const string Striped = "V. Striped";
		}

		[DesignerPropertyToggleButton(new string[] { "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 1, AllowFunkyInput = true)]
		private string _designerActivationGroup = "1";

		[DesignerPropertySlider(0.5f, 3f, 26, Label = "Size", Order = 10)]
		private float _size = 1f;

		[DesignerPropertyToggleButton(new string[] { "V. Striped", "H. Striped", "Checkered" }, Label = "Style", Order = 3)]
		private string _style = "V. Striped";

		public string ActivationGroup { get; private set; }

		public float Drag { get; private set; }

		public float Scale => _size;

		public string Style => _style;

		public ParachuteData(XElement element)
			: base(element)
		{
			ActivationGroup = ((string)element.Attribute("activationGroup")) ?? "1";
			_designerActivationGroup = ActivationGroup.ToString();
			Drag = 20f;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", ActivationGroup.ToString()));
			xElement.Add(new XAttribute("size", _size));
			xElement.Add(new XAttribute("style", _style));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_size")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("Parachute");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			ParachuteScript parachuteScript = gameObject.AddComponent<ParachuteScript>();
			parachuteScript.Parachute = this;
			parachuteScript.Initialize();
			return parachuteScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_designerActivationGroup")
			{
				if (value != _designerActivationGroup)
				{
					Debug.LogError("What? Uh oh...");
				}
				ActivationGroup = value;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			if (stateElement != null)
			{
				base.RestoreFromState(stateElement);
				ActivationGroup = ((string)stateElement.Attribute("activationGroup")) ?? "1";
				_designerActivationGroup = ActivationGroup.ToString();
				_size = stateElement.GetFloatAttribute("size", 1f);
				_style = stateElement.GetStringAttribute("style", "V. Striped");
				_size = Mathf.Clamp(_size, 0.1f, 5f);
			}
		}
	}
}
