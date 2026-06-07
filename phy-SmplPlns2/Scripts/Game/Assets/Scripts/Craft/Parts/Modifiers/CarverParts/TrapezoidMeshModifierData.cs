using System;
using System.Xml.Linq;
using Assets.Scripts.Craft.Wings.Utilities;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.UI.PartProperties;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	public abstract class TrapezoidMeshModifierData : MeshModifierBaseData
	{
		[DesignerPropertySpinner(-5f, 5f, 0.05f, Label = "Bottom Offset", Order = 105)]
		private float _bottomOffset;

		[DesignerPropertySpinner(0f, 10f, 0.1f, Label = "Bottom Width", Order = 104)]
		private float _bottomWidth;

		[DesignerPropertySlider(Label = "Corner Radius", MinValue = 0f, MaxValue = 1f, NumberOfSteps = 51)]
		private float _cornerRadius;

		[DesignerPropertySpinner(0.01f, 10f, 0.1f, Label = "Depth", Header = "Dimensions", Order = 100)]
		private float _depth;

		[DesignerPropertyButton(Label = "Edit Shape", Order = 99, Style = ButtonStyle.Primary)]
		private bool _editBtn;

		[DesignerPropertySpinner(0.01f, 10f, 0.1f, Label = "Height", Order = 101)]
		private float _height;

		private float2 _lowerSpan;

		private bool _refreshUI;

		[DesignerPropertySpinner(-5f, 5f, 0.05f, Label = "Top Offset", Order = 103)]
		private float _topOffset;

		[DesignerPropertySpinner(0f, 10f, 0.1f, Label = "Top Width", Order = 102)]
		private float _topWidth;

		private float2 _upperSpan;

		public float CornerRadius
		{
			get
			{
				return _cornerRadius;
			}
			set
			{
				_cornerRadius = value;
				RaiseOnShapeChanged();
			}
		}

		public float Depth
		{
			get
			{
				return _depth;
			}
			set
			{
				_depth = value;
				RaiseOnShapeChanged();
			}
		}

		public float Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
				_refreshUI = true;
				RaiseOnShapeChanged();
			}
		}

		public float2 LowerSpan
		{
			get
			{
				return _lowerSpan;
			}
			set
			{
				_lowerSpan = value;
				UpdateDerivedFields();
				_refreshUI = true;
				RaiseOnShapeChanged();
			}
		}

		public float2 UpperSpan
		{
			get
			{
				return _upperSpan;
			}
			set
			{
				_upperSpan = value;
				UpdateDerivedFields();
				_refreshUI = true;
				RaiseOnShapeChanged();
			}
		}

		protected TrapezoidMeshModifierData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("cornerRadius", DataIO.ToString(_cornerRadius));
			xElement.SetAttributeValue("upperSpan", _upperSpan.ToXAttributeValue());
			xElement.SetAttributeValue("lowerSpan", _lowerSpan.ToXAttributeValue());
			xElement.SetAttributeValue("height", DataIO.ToString(_height));
			xElement.SetAttributeValue("depth", DataIO.ToString(_depth));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_cornerRadius")
			{
				return sliderValue.ToString("P0");
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public void MirrorData(bool raiseEvent = true)
		{
			_lowerSpan = -_lowerSpan.yx;
			_upperSpan = -_upperSpan.yx;
			UpdateDerivedFields();
			_refreshUI = true;
			if (raiseEvent)
			{
				RaiseOnShapeChanged();
			}
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
			if (_refreshUI)
			{
				_refreshUI = false;
				genericPartProperties.RefreshUI();
			}
		}

		public override void OnGenericDesignerPropertyButtonClicked(IConfigurableProperty property)
		{
			if (property.Member.Name == "_editBtn")
			{
				DesignerTools tools = Designer.Instance.Tools;
				tools.SelectTool(tools.TrapezoidShapeTool);
			}
			else
			{
				base.OnGenericDesignerPropertyButtonClicked(property);
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_cornerRadius":
			case "_depth":
			case "_height":
				RaiseOnShapeChanged();
				break;
			case "_bottomWidth":
			case "_bottomOffset":
				_bottomWidth = math.max(0f, _bottomWidth);
				_lowerSpan = new float2(_bottomOffset - _bottomWidth * 0.5f, _bottomOffset + _bottomWidth * 0.5f);
				RaiseOnShapeChanged();
				SyncSymmetricParts();
				break;
			case "_topWidth":
			case "_topOffset":
				_topWidth = math.max(0f, _topWidth);
				_upperSpan = new float2(_topOffset - _topWidth * 0.5f, _topOffset + _topWidth * 0.5f);
				RaiseOnShapeChanged();
				SyncSymmetricParts();
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_cornerRadius = stateElement.GetFloatAttribute("cornerRadius", 0.2f);
			_upperSpan = stateElement.Float2Attribute("upperSpan") ?? new float2(-0.2f, 0.2f);
			_lowerSpan = stateElement.Float2Attribute("lowerSpan") ?? new float2(-0.2f, 0.2f);
			_height = stateElement.GetFloatAttribute("height", 0.6f);
			_depth = stateElement.GetFloatAttribute("depth", 0.3f);
			if (stateElement.Attribute("width") != null)
			{
				float floatAttribute = stateElement.GetFloatAttribute("width", 0.3f);
				_lowerSpan = (_upperSpan = floatAttribute * new float2(-0.5f, 0.5f));
			}
			UpdateDerivedFields();
		}

		protected override void SyncSymmetricModifier(MeshModifierBaseData modifier)
		{
			if (modifier is TrapezoidMeshModifierData trapezoidMeshModifierData)
			{
				trapezoidMeshModifierData._height = _height;
				trapezoidMeshModifierData._lowerSpan = _lowerSpan;
				trapezoidMeshModifierData._upperSpan = _upperSpan;
				trapezoidMeshModifierData.MirrorData();
			}
		}

		private void UpdateDerivedFields()
		{
			_bottomWidth = _lowerSpan.y - _lowerSpan.x;
			_bottomOffset = (_lowerSpan.x + _lowerSpan.y) * 0.5f;
			_topWidth = _upperSpan.y - _upperSpan.x;
			_topOffset = (_upperSpan.x + _upperSpan.y) * 0.5f;
		}
	}
}
