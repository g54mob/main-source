using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.Flight.Cameras;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Camera")]
	public class CameraVantageData : PartModifierData, IModifierWithOutputs
	{
		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Auto Center", Order = 4)]
		private bool _autoCenterCamera;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Auto Orient", Order = 2)]
		private bool _autoOrient;

		private int? _cockpitCameraPriority;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Gun Reticle", Order = 6)]
		private bool _enableGunReticle;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Missile Locking", Order = 7)]
		private bool _enableMissileLocking;

		private bool _hidePartDefaultValue;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Look At Cockpit", Order = 3)]
		private bool _lookAtCockpit;

		[DesignerPropertyTextInput(Label = "Camera Name", Order = 1)]
		private string _name;

		private Vector3 _offset;

		[DesignerPropertySpinner(-10.0, 10.0, 0.05, Label = "Up Offset", PreserveState = false, Order = 10)]
		private float _upOffset;

		[DesignerPropertyToggleButton(new string[] { }, Label = "View Mode", Order = 7, SilenceEnumCountMismatch = true)]
		private ViewMode _viewMode;

		public bool AutoCenterCamera
		{
			get
			{
				return _autoCenterCamera;
			}
			set
			{
				_autoCenterCamera = value;
			}
		}

		public bool AutoOrient
		{
			get
			{
				return _autoOrient;
			}
			set
			{
				_autoOrient = value;
			}
		}

		public bool AutoZoomOnCockpit { get; set; }

		public bool CockpitAudio { get; set; }

		public int CockpitCameraPriority
		{
			get
			{
				if (ViewMode != ViewMode.FirstPerson)
				{
					return -1;
				}
				if (_cockpitCameraPriority.HasValue)
				{
					return _cockpitCameraPriority.Value;
				}
				int num = 15;
				if (EnableGunReticle)
				{
					num -= 4;
				}
				if (EnableMissileLocking)
				{
					num -= 5;
				}
				return num;
			}
		}

		public bool EnableGunReticle
		{
			get
			{
				return _enableGunReticle;
			}
			set
			{
				_enableGunReticle = value;
			}
		}

		public bool EnableMissileLocking
		{
			get
			{
				return _enableMissileLocking;
			}
			set
			{
				_enableMissileLocking = value;
			}
		}

		public bool HidePart { get; set; }

		public bool LookAtCockpit
		{
			get
			{
				return _lookAtCockpit;
			}
			set
			{
				_lookAtCockpit = value;
			}
		}

		public Vector2 LookBackTranslation { get; set; }

		public Type ModifierScriptType => typeof(CameraVantageScript);

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public Vector3 Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				_offset = value;
			}
		}

		public List<ViewMode> SupportedViewModes { get; set; }

		public float UpOffset
		{
			get
			{
				return _upOffset;
			}
			set
			{
				_upOffset = value;
			}
		}

		public ViewMode ViewMode
		{
			get
			{
				return _viewMode;
			}
			set
			{
				_viewMode = value;
			}
		}

		public CameraVantageData(XElement element)
			: base(element)
		{
			Name = string.Empty;
			AutoOrient = true;
			LookAtCockpit = false;
			AutoZoomOnCockpit = false;
			EnableGunReticle = false;
			EnableMissileLocking = false;
			HidePart = (_hidePartDefaultValue = (bool?)element.Attribute("hidePart") == true);
			_offset = element.GetVector3Attribute("offset", Vector3.zero);
			SupportedViewModes = (from x in (((string)element.Attribute("supportedViewModes")) ?? string.Empty).Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
				select (ViewMode)Enum.Parse(typeof(ViewMode), x.Trim())).ToList();
			ViewMode = ((SupportedViewModes.Count <= 0) ? ViewMode.FirstPerson : SupportedViewModes[0]);
		}

		public CameraVantageData()
			: base(null)
		{
			Name = string.Empty;
			AutoOrient = true;
			LookAtCockpit = false;
			AutoZoomOnCockpit = false;
			EnableGunReticle = false;
			EnableMissileLocking = false;
			SupportedViewModes = new List<ViewMode>
			{
				ViewMode.None,
				ViewMode.FirstPerson,
				ViewMode.Chase,
				ViewMode.Orbit,
				ViewMode.RadioControl,
				ViewMode.FlyBy,
				ViewMode.CustomVantage
			};
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("viewMode", ViewMode.ToString()), new XAttribute("autoOrient", AutoOrient.ToString().ToLower()), new XAttribute("lookAtCockpit", LookAtCockpit.ToString().ToLower()), new XAttribute("autoZoomOnCockpit", AutoZoomOnCockpit.ToString().ToLower()), new XAttribute("autoCenterCamera", AutoCenterCamera.ToString().ToLower()), (LookBackTranslation == Vector2.zero) ? null : new XAttribute("lookBackTranslation", LookBackTranslation.ToXAttributeValue()), (!EnableGunReticle) ? null : new XAttribute("gunReticle", EnableGunReticle), (!EnableMissileLocking) ? null : new XAttribute("missileLocking", EnableMissileLocking), (!_cockpitCameraPriority.HasValue) ? null : new XAttribute("cockpitCameraPriority", _cockpitCameraPriority), string.IsNullOrWhiteSpace(Name) ? null : new XAttribute("name", Name), (HidePart == _hidePartDefaultValue) ? null : new XAttribute("hidePart", HidePart), (UpOffset == 0.5f) ? null : new XAttribute("upOffset", UpOffset));
			return xElement;
		}

		public override void GetGenericDesignerPropertyTextSpinnerValues(ITextSpinnerProperty textSpinnerProperty, List<string> values)
		{
			if (textSpinnerProperty.Member.Name == "_viewMode")
			{
				Debug.Log("GetGenericDesignerPropertyTextSpinnerValues");
				values.Clear();
				values.AddRange(SupportedViewModes.Select((ViewMode x) => x.ToString()));
			}
			else
			{
				base.GetGenericDesignerPropertyTextSpinnerValues(textSpinnerProperty, values);
			}
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			switch (property.Member.Name)
			{
			case "_viewMode":
				return () => SupportedViewModes.Count > 1;
			case "_autoOrient":
			case "_lookAtCockpit":
			case "_upOffset":
				return () => ViewMode == ViewMode.FirstPerson;
			case "_autoCenterCamera":
			case "_enableGunReticle":
			case "_enableMissileLocking":
				return () => ViewMode == ViewMode.FirstPerson && !_lookAtCockpit;
			default:
				return base.GetGenericDesignerPropertyVisibilityCallback(property);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			CameraVantageScript cameraVantageScript = parentGameObject.AddComponent<CameraVantageScript>();
			cameraVantageScript.Initialize(this, HidePart);
			return cameraVantageScript;
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			ToggleButtonProperty property = genericPartPropertiesScript.GetProperty<ToggleButtonProperty>("_viewMode");
			property.EnumNames.Clear();
			property.EnumNames.AddRange(SupportedViewModes.Select((ViewMode x) => x.ToString()));
			property.ButtonAttribute.Values.Clear();
			property.ButtonAttribute.Values.AddRange(property.EnumNames);
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_lookAtCockpit" && !_lookAtCockpit)
			{
				AutoZoomOnCockpit = false;
				AutoCenterCamera = true;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			ViewMode = (ViewMode)Enum.Parse(typeof(ViewMode), stateElement.GetStringAttribute("viewMode", ViewMode.FirstPerson.ToString()));
			AutoOrient = stateElement.GetBoolAttribute("autoOrient", AutoOrient);
			LookAtCockpit = stateElement.GetBoolAttribute("lookAtCockpit", LookAtCockpit);
			AutoZoomOnCockpit = stateElement.GetBoolAttribute("autoZoomOnCockpit", AutoZoomOnCockpit);
			AutoCenterCamera = stateElement.GetBoolAttribute("autoCenterCamera", AutoCenterCamera);
			LookBackTranslation = stateElement.GetVector2Attribute("lookBackTranslation", Vector2.zero);
			EnableGunReticle = stateElement.GetBoolAttribute("gunReticle");
			EnableMissileLocking = stateElement.GetBoolAttribute("missileLocking");
			Name = ((string)stateElement.Attribute("name")) ?? string.Empty;
			HidePart = stateElement.GetBoolAttribute("hidePart", _hidePartDefaultValue);
			UpOffset = stateElement.GetFloatAttribute("upOffset", 0.5f);
		}
	}
}
