using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	public abstract class ScalableMeshModifierBaseData : MeshModifierBaseData
	{
		[DesignerPropertySpinner(0.01f, 10f, 0.1f, Label = "Depth")]
		private float _depth;

		[DesignerPropertySpinner(0.01f, 10f, 0.1f, Label = "Height")]
		private float _height;

		[DesignerPropertySpinner(0.01f, 10f, 0.1f, Label = "Width")]
		private float _width;

		public float3 Scale
		{
			get
			{
				float3 float5 = new float3(_width, _height, _depth);
				return math.select(float5, 0.1f, float5 <= 0f);
			}
			set
			{
				_width = value.x;
				_height = value.y;
				_depth = value.z;
				this.OnScaleChanged?.Invoke();
			}
		}

		public event Action OnScaleChanged;

		public ScalableMeshModifierBaseData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("width", DataIO.ToString(_width));
			xElement.SetAttributeValue("height", DataIO.ToString(_height));
			xElement.SetAttributeValue("depth", DataIO.ToString(_depth));
			return xElement;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_width":
			case "_height":
			case "_depth":
				this.OnScaleChanged?.Invoke();
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_width = stateElement.GetFloatAttribute("width", 0.3f);
			_height = stateElement.GetFloatAttribute("height", 0.6f);
			_depth = stateElement.GetFloatAttribute("depth", 0.4f);
		}
	}
}
