using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Transparency")]
	public class TransparencyData : PartModifierData
	{
		private bool _alwaysFindConnected;

		private AttachPointData _backAttach;

		private AttachPointData _frontAttach;

		private IFuselageData _fuselage;

		private bool _hasDetectedConnected;

		private bool _hideBack;

		private bool _hideFront;

		private bool _hideInside;

		private TransparencyData _nextGlass;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Opacity")]
		private float _opacity = 0.1f;

		private TransparencyData _prevGlass;

		public AttachPointData BackAttach
		{
			get
			{
				if (_backAttach == null && Fuselage != null)
				{
					_backAttach = Fuselage.RearAttachPoint;
				}
				return _backAttach;
			}
		}

		public TransparencyData ConnectedBack
		{
			get
			{
				DetectConnected(force: false);
				return _prevGlass;
			}
		}

		public bool ConnectedBackToFront { get; set; }

		public TransparencyData ConnectedFront
		{
			get
			{
				DetectConnected(force: false);
				return _nextGlass;
			}
		}

		public bool ConnectedFrontToFront { get; set; }

		public AttachPointData FrontAttach
		{
			get
			{
				if (_frontAttach == null && Fuselage != null)
				{
					_frontAttach = Fuselage.FrontAttachPoint;
				}
				return _frontAttach;
			}
		}

		public IFuselageData Fuselage
		{
			get
			{
				if (_fuselage == null)
				{
					foreach (PartModifierData modifier in base.Part.Modifiers)
					{
						if (modifier is IFuselageData fuselage)
						{
							_fuselage = fuselage;
							break;
						}
					}
				}
				return _fuselage;
			}
		}

		public bool IsTransparent => Fuselage?.IsTransparent ?? true;

		public bool ProcessFaceConnectivity
		{
			get
			{
				if (!(Fuselage is JFuselageData))
				{
					return IsTransparent;
				}
				return true;
			}
		}

		public bool HideBack
		{
			get
			{
				return _hideBack;
			}
			set
			{
				_hideBack = value;
			}
		}

		public bool HideFront
		{
			get
			{
				return _hideFront;
			}
			set
			{
				_hideFront = value;
			}
		}

		public bool HideInside
		{
			get
			{
				return _hideInside;
			}
			set
			{
				_hideInside = value || Game.Instance.Device.IsAndroidVRBuild;
			}
		}

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

		public bool OverrideHide { get; set; }

		public TransparencyScript Script { get; private set; }

		public event Action OnOpacityChanged;

		public TransparencyData(XElement element)
			: base(element)
		{
			_alwaysFindConnected = element.GetBoolAttribute("alwaysFindConnected");
		}

		public void DetectConnected(bool force)
		{
			if (!force && _hasDetectedConnected)
			{
				return;
			}
			_hasDetectedConnected = true;
			_nextGlass = null;
			_prevGlass = null;
			PartData part = base.Part;
			List<PartConnection> partConnections;
			if (FrontAttach != null)
			{
				partConnections = FrontAttach.PartConnections;
				for (int i = 0; i < partConnections.Count; i++)
				{
					TransparencyData modifier = partConnections[i].GetOtherPart(part).GetModifier<TransparencyData>();
					if (modifier != null && (modifier.IsTransparent || (modifier._alwaysFindConnected && _alwaysFindConnected)))
					{
						_nextGlass = modifier;
						ConnectedFrontToFront = partConnections[i].GetOtherAttachPoint(FrontAttach) == modifier.FrontAttach;
					}
				}
			}
			partConnections = BackAttach.PartConnections;
			for (int j = 0; j < partConnections.Count; j++)
			{
				TransparencyData modifier2 = partConnections[j].GetOtherPart(part).GetModifier<TransparencyData>();
				if (modifier2 != null && (modifier2.IsTransparent || (modifier2._alwaysFindConnected && _alwaysFindConnected)))
				{
					_prevGlass = modifier2;
					ConnectedBackToFront = partConnections[j].GetOtherAttachPoint(BackAttach) == modifier2.FrontAttach;
				}
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("opacity", Opacity);
			xElement.SetAttributeValue("hideFront", HideFront);
			xElement.SetAttributeValue("hideBack", HideBack);
			xElement.SetAttributeValue("overrideHide", OverrideHide);
			xElement.SetAttributeValue("hideInside", HideInside);
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_opacity")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<TransparencyScript>();
			Script.Modifier = this;
			return Script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_opacity")
			{
				Script.UpdateMaterialParameters();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_opacity = stateElement.GetFloatAttribute("opacity", 0.1f);
			if (_opacity < -0.5f)
			{
				_opacity = -0.5f;
			}
			HideFront = stateElement.GetBoolAttribute("hideFront");
			HideBack = stateElement.GetBoolAttribute("hideBack");
			OverrideHide = stateElement.GetBoolAttribute("overrideHide");
			HideInside = stateElement.GetBoolAttribute("hideInside");
		}
	}
}
