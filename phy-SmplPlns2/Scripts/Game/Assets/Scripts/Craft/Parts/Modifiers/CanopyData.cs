using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Canopy")]
	public class CanopyData : PartModifierData
	{
		[DesignerPropertyToggleButton(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 40)]
		private int _animationActivationGroup = 1;

		[SerializeField]
		private float _animationSpeed = 1f;

		private string _canopyName;

		[SerializeField]
		private float _dragWhenOpen;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Opacity", Order = 20)]
		private float _opacity = 0.1f;

		[DesignerPropertyToggleButton(new string[] { "Hidden", "Visible" }, Label = "Interior Glass", Order = 30)]
		private bool _showInside = true;

		public int AnimationActivationGroup => _animationActivationGroup;

		public string AnimationPath { get; }

		public float AnimationSpeed => _animationSpeed;

		public float DragWhenOpen => _dragWhenOpen;

		public bool HasAnimation { get; }

		public int InsideSubmesh { get; private set; }

		public string MeshPath { get; private set; }

		public float Opacity
		{
			get
			{
				return _opacity;
			}
			set
			{
				_opacity = value;
				this.OnOpacityChanged?.Invoke();
			}
		}

		public int OutsideSubmesh { get; private set; }

		public bool ShowInside
		{
			get
			{
				if (_showInside)
				{
					return !Game.Instance.Device.IsAndroidVRBuild;
				}
				return false;
			}
		}

		public event Action OnOpacityChanged;

		public event Action OnShowInsideChanged;

		public CanopyData(XElement element)
			: base(element)
		{
			MeshPath = ((string)element.Attribute("meshPath")) ?? "GlassMesh";
			AnimationPath = (string)element.Attribute("animationPath");
			InsideSubmesh = ((int?)element.Attribute("insideSubmesh")).GetValueOrDefault();
			OutsideSubmesh = ((int?)element.Attribute("outsideSubmesh")) ?? 1;
			_canopyName = (string)element.Attribute("name");
			_dragWhenOpen = ((float?)element.Attribute("dragWhenOpen")).GetValueOrDefault();
			HasAnimation = !string.IsNullOrWhiteSpace(AnimationPath);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("opacity", Opacity);
			xElement.SetAttributeValue("showInside", _showInside);
			if (HasAnimation)
			{
				xElement.SetAttributeValue("activationGroup", _animationActivationGroup);
				xElement.SetAttributeValue("animationSpeed", _animationSpeed);
				xElement.SetAttributeValue("dragWhenOpen", _dragWhenOpen);
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			if (propertyName == "_animationActivationGroup")
			{
				if (!(value == "0"))
				{
					return value;
				}
				return "Disabled";
			}
			return base.GetGenericDesignerPropertyToggleButtonValueLabel(propertyName, value);
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			if (property.Member.Name == "_animationActivationGroup")
			{
				return () => HasAnimation;
			}
			return base.GetGenericDesignerPropertyVisibilityCallback(property);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			CanopyScript canopyScript = parentGameObject.AddComponent<CanopyScript>();
			canopyScript.Modifier = this;
			return canopyScript;
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			if (!string.IsNullOrEmpty(_canopyName))
			{
				genericPartPropertiesScript.SetModifierHeaderText(_canopyName);
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_opacity")
			{
				this.OnOpacityChanged?.Invoke();
			}
			else if (propertyName == "_showInside")
			{
				this.OnShowInsideChanged?.Invoke();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_opacity = stateElement.GetFloatAttribute("opacity", 0.1f);
			_showInside = stateElement.GetBoolAttribute("showInside");
			if (HasAnimation)
			{
				_animationActivationGroup = stateElement.GetIntAttribute("activationGroup", 1);
				_animationSpeed = stateElement.GetFloatAttribute("animationSpeed", 1f);
				_dragWhenOpen = stateElement.GetFloatAttribute("dragWhenOpen", _dragWhenOpen);
			}
		}
	}
}
