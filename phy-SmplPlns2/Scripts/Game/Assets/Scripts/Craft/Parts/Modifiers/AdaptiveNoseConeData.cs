using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Nosecone")]
	public class AdaptiveNoseConeData : PartModifierData
	{
		[DesignerPropertySpinner(1f, 5f, 1f, Label = "Height", PreserveState = false)]
		private float _height;

		[DesignerPropertySpinner(0.5, 5.0, 0.5, Label = "Length", PreserveState = false)]
		private float _length;

		private AdaptiveNoseConeScript _script;

		[DesignerPropertySpinner(1f, 5f, 1f, Label = "Width", PreserveState = false)]
		private float _width;

		public override float Mass => base.Mass;

		public Vector3 Scale { get; set; }

		public AdaptiveNoseConeData(XElement element)
			: base(element)
		{
			Scale = Vector3.one;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("scale", Scale.ToXAttributeValue()));
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = parentGameObject.transform.Find("ScaleRoot").gameObject;
			_script = gameObject.AddComponent<AdaptiveNoseConeScript>();
			_script.AdaptiveNoseCone = this;
			_script.OnModifierInitialized();
			_script.SetScale(_script.AdaptiveNoseCone.Scale);
			return _script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			Vector3 scale = new Vector3(_width, _height, _length);
			_script.SetScale(scale);
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			Scale = stateElement.GetVector3Attribute("scale", Vector3.one);
			_width = Scale.x;
			_height = Scale.y;
			_length = Scale.z;
		}

		protected override float CalculateMass()
		{
			return (Scale.x * Scale.y + Scale.x * Scale.z + Scale.y * Scale.z) * 7.5f / 3f * 0.01f;
		}
	}
}
