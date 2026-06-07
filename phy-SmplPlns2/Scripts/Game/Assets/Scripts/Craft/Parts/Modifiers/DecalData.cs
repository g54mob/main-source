using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Decal")]
	public abstract class DecalData : PartModifierData, ICraftDecal
	{
		private static class Profile
		{
			public const string Prefix = "DecalData";

			public static readonly ProfilerMarker OnUpdate = new ProfilerMarker("DecalData.OnUpdate");
		}

		private Vector3 _craftPosition;

		private Quaternion _craftRotation;

		private List<int> _legacyPartIds;

		private PartTargetingMode? _legacyTargetMode;

		private float _opacity = 1f;

		private float _penetration;

		private bool _propertiesChanged;

		private bool _refreshProperties;

		private int _renderPriority;

		private DecalScript _script;

		private Vector3 _size;

		private Color _tintColor;

		public Vector3 CraftPosition
		{
			get
			{
				return _craftPosition;
			}
			set
			{
				if (!Utilities.CompareVector3s(_craftPosition, value, 0.001f))
				{
					_craftPosition = value;
					_propertiesChanged = true;
				}
			}
		}

		public Quaternion CraftRotation
		{
			get
			{
				return _craftRotation;
			}
			set
			{
				if (!Utilities.CompareQuaternions(_craftRotation, value, 0.001f))
				{
					_craftRotation = value;
					_propertiesChanged = true;
				}
			}
		}

		public Vector3 DecalRotation { get; private set; }

		[DesignerPropertySlider(MinValue = -180f, MaxValue = 180f, NumberOfSteps = 361, Label = "Rotation", Order = 24)]
		public float DecalRotationZ
		{
			get
			{
				return DecalRotation.z;
			}
			set
			{
				Vector3 decalRotation = DecalRotation;
				decalRotation.z = value;
				DecalRotation = decalRotation;
			}
		}

		public abstract CraftDecalType DecalType { get; }

		[DesignerPropertySpinner(0.1f, 50f, 0.1f, AllowManualEntry = true, Label = "Depth", Order = 25)]
		public float Depth
		{
			get
			{
				return _size.z;
			}
			set
			{
				_size.z = value;
			}
		}

		[DesignerPropertySpinner(0.01f, 50f, 0.1f, AllowManualEntry = true, Label = "Height", Order = 21)]
		public float Height
		{
			get
			{
				return _size.y;
			}
			set
			{
				_size.y = value;
			}
		}

		[DesignerPropertySlider(MinValue = 0f, MaxValue = 1f, NumberOfSteps = 101, Label = "Opacity", Order = 11)]
		public float Opacity
		{
			get
			{
				return _opacity;
			}
			set
			{
				if (_opacity != value)
				{
					_opacity = value;
					OnMaterialPropertiesChanged();
					_propertiesChanged = true;
				}
			}
		}

		public PartTargetingData PartTargeting { get; private set; }

		[DesignerPropertySlider(MinValue = 0f, MaxValue = 1f, NumberOfSteps = 101, Label = "Penetration", Order = 26)]
		public float Penetration
		{
			get
			{
				return _penetration;
			}
			set
			{
				_penetration = value;
			}
		}

		[DesignerPropertySpinner(-50f, 50f, 1f, AllowManualEntry = true, Label = "Render Priority", Order = 500, Tooltip = "Controls the order in which decals are rendered when they are overlapping")]
		public int RenderPriority
		{
			get
			{
				return _renderPriority;
			}
			set
			{
				value = ClampRenderPriority(value);
				if (_renderPriority != value)
				{
					_renderPriority = value;
					OnMaterialPropertiesChanged();
					_propertiesChanged = true;
				}
			}
		}

		public virtual Vector3 Size
		{
			get
			{
				return _size;
			}
			set
			{
				if (!Utilities.CompareVector3s(_size, value, 0.001f))
				{
					_size = value;
					_propertiesChanged = true;
				}
			}
		}

		[DesignerPropertyColor(Label = "Color", Order = 10)]
		public Color TintColor
		{
			get
			{
				return _tintColor;
			}
			set
			{
				if (_tintColor != value)
				{
					_tintColor = value;
					OnMaterialPropertiesChanged();
					_propertiesChanged = true;
				}
			}
		}

		[DesignerPropertySpinner(0.01f, 50f, 0.1f, AllowManualEntry = true, Label = "Width", Order = 20)]
		public float Width
		{
			get
			{
				return _size.x;
			}
			set
			{
				_size.x = value;
			}
		}

		public event EventHandler<EventArgs> DecalPropertiesChanged;

		public DecalData(XElement element)
			: base(element)
		{
			_size = Vector3.one;
			_tintColor = Color.white;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("penetration", _penetration);
			xElement.SetAttribute("position", _craftPosition);
			xElement.SetAttribute("rotation", _craftRotation);
			xElement.SetAttributeValue("decalRotation", DecalRotation);
			xElement.SetAttribute("size", _size);
			xElement.SetAttribute("color", _tintColor, ColorStringFormat.HexRGB);
			xElement.SetAttributeValue("opacity", _opacity);
			xElement.SetAttributeValue("priority", _renderPriority);
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "Opacity":
			case "Penetration":
				return Utilities.FormatPercentage(sliderValue);
			case "DecalRotationZ":
				return $"{(int)sliderValue}°";
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override object GetSymmetricValue(string propertyName, int symmetricPartCount, PartModifierData sourceModifier, object sourceValue)
		{
			if (symmetricPartCount == 2 && propertyName == "DecalRotationZ")
			{
				return 0f - (float)sourceValue;
			}
			return base.GetSymmetricValue(propertyName, symmetricPartCount, sourceModifier, sourceValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			if (aircraftScript.LoadContext == CraftLoadContext.Designer)
			{
				_script = CreateAndInitializeScript(parentGameObject);
			}
			else
			{
				Debug.LogError("Decal modifier is attempting to create a script outside of the designer.");
			}
			return _script;
		}

		public override void OnAssemblyLoaded(Assembly assembly, CraftLoadContext loadContext)
		{
			PartTargetingData modifier = base.Part.GetModifier<PartTargetingData>();
			if (_legacyTargetMode.HasValue)
			{
				modifier.TargetMode = _legacyTargetMode.Value;
				modifier.PartIDs = _legacyPartIds;
			}
			if (loadContext == CraftLoadContext.Designer || modifier.PartIDs == null)
			{
				return;
			}
			foreach (int partID in modifier.PartIDs)
			{
				assembly.GetPartById(partID).AssignDecal(this);
			}
		}

		public override void OnGenericDesignerPropertiesPartDeselected()
		{
			base.OnGenericDesignerPropertiesPartDeselected();
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
			if (_refreshProperties)
			{
				_refreshProperties = false;
				genericPartProperties.RefreshUI();
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			_script.OnDecalPropertiesUpdated();
			SetDirty();
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			PartTargeting = base.Part.GetModifier<PartTargetingData>();
			PartTargeting.SetHandler(_script);
		}

		public void OnStacked()
		{
			_script.OnDecalPropertiesUpdated();
			SetDirty();
			_refreshProperties = true;
		}

		public void OnUpdate(Transform transform)
		{
			using (Profile.OnUpdate.Auto())
			{
				CraftPosition = transform.position;
				CraftRotation = transform.rotation;
				if (_propertiesChanged)
				{
					this.DecalPropertiesChanged?.Invoke(this, EventArgs.Empty);
					_propertiesChanged = false;
				}
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			Penetration = stateElement.GetFloatAttribute("penetration", 0.25f);
			_craftPosition = stateElement.GetVector3Attribute("position");
			_craftRotation = stateElement.GetQuaternionAttribute("rotation");
			DecalRotation = stateElement.GetVector3Attribute("decalRotation");
			_size = stateElement.GetVector3Attribute("size", Vector3.one);
			_tintColor = stateElement.GetColorAttribute("color", Color.white, ColorStringFormat.HexRGB);
			_opacity = stateElement.GetFloatAttribute("opacity", 1f);
			_renderPriority = ClampRenderPriority(stateElement.GetIntAttribute("priority"));
			string stringAttribute = stateElement.GetStringAttribute("target");
			if (!string.IsNullOrEmpty(stringAttribute))
			{
				_legacyTargetMode = ((!(stringAttribute == "Single Part")) ? PartTargetingMode.MultipleParts : PartTargetingMode.SinglePart);
				_legacyPartIds = stateElement.GetIntListAttribute("partIds");
			}
			OnMaterialPropertiesChanged();
		}

		public void SetDirty()
		{
			_propertiesChanged = true;
		}

		protected abstract DecalScript CreateAndInitializeScript(GameObject gameObject);

		protected virtual void OnMaterialPropertiesChanged()
		{
		}

		private static int ClampRenderPriority(int value)
		{
			return Math.Clamp(value, -50, 50);
		}
	}
}
