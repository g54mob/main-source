using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Attitude Ball")]
	public class AttitudeBallData : PartModifierData
	{
		[Flags]
		public enum BallType
		{
			None = 0,
			Roll = 1,
			Pitch = 2,
			Heading = 4,
			Attitude = 3,
			LevelCompass = 5,
			AllAxis = 7
		}

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2f, 31, Label = "Scale")]
		private float _scale = 1f;

		public string MeshPath { get; private set; }

		public BallType RotationType { get; private set; }

		public float Scale => _scale;

		public event Action<float> OnScaleChanged;

		public AttitudeBallData(XElement element)
			: base(element)
		{
			MeshPath = (string)element.Attribute("meshPath");
			if (Enum.TryParse<BallType>((string)element.Attribute("rotationType"), out var result))
			{
				RotationType = result;
			}
			else
			{
				RotationType = BallType.Attitude;
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("scale", _scale.ToString());
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			AttitudeBallBehaviour attitudeBallBehaviour = parentGameObject.AddComponent<AttitudeBallBehaviour>();
			attitudeBallBehaviour.Modifier = this;
			return attitudeBallBehaviour;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_scale")
			{
				this.OnScaleChanged?.Invoke(_scale);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_scale = ((float?)stateElement.Attribute("scale")) ?? 1f;
		}
	}
}
