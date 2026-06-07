using System;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[Serializable]
	public class ProceduralMissileSubPartData : PartModifierData
	{
		[DesignerPropertySlider(-180f, 180f, 73, Label = "Angle", Order = 50, Tooltip = "Changes the angle used to offset around the missile.")]
		private float _angle;

		[DesignerPropertySlider(0.25f, 4f, 376, Label = "Height", Order = 10, Tooltip = "Make it taller / shorter.")]
		private float _height = 1f;

		[DesignerPropertySlider(0.25f, 4f, 376, Label = "Length", Order = 20, Tooltip = "Make it longer / shorter")]
		private float _length = 1f;

		[DesignerPropertySlider(0f, 2f, 201, Label = "Radial Offset", Order = 70, Tooltip = "Move it away / closer to the surface of the missile.")]
		private float _radialOffset = 1f;

		private bool _refreshUI;

		[DesignerPropertySlider(0.25f, 2.5f, 251, Label = "Size", Order = 9, Tooltip = "Make it bigger / smaller.")]
		private float _size = 1f;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Style", Tooltip = "Changes the style.", Order = 1)]
		private string _style;

		[DesignerPropertyToggleButton(new string[] { "-2", "1", "2", "3", "4" }, Label = "Symmetry", Order = 60, Tooltip = "Changes how many are duplicatd around the missile.")]
		private int _symmetry = 4;

		[DesignerPropertySlider(0.25f, 2.5f, 251, Label = "Thickness", Order = 30, Tooltip = "Make it thinner / thicker.")]
		private float _thickness = 1f;

		public float Angle => _angle;

		public float Height => _height;

		public float Length => _length;

		public float MaxPosition { get; set; }

		public float MinPosition { get; set; }

		public MissilePartPrefabs.PartPrefabCategory MissilePartPrefabs { get; }

		public string PropertyEditorDesc { get; private set; }

		public float RadialOffset => _radialOffset;

		public ProceduralMissileSubPartScript Script { get; private set; }

		public float Size => _size;

		public MissilePartPrefabs.PartPrefab SubPartPrefab { get; private set; }

		public MissileSubPartType SubPartType { get; }

		public float SurfaceArea => Size * Length * Height * SubPartPrefab.areaMultiplier * (float)Mathf.Abs(Symmetry) * MissilePartPrefabs.baseSize.x * MissilePartPrefabs.baseSize.y;

		public int Symmetry => _symmetry;

		public float Thickness => _thickness;

		public ProceduralMissileSubPartData(XElement element)
			: base(element)
		{
			PropertyEditorDesc = element.GetStringAttribute("propertyEditorDesc");
			SubPartType = element.GetEnumAttribute("subPartType", MissileSubPartType.Fin);
			if (SubPartType == MissileSubPartType.Fin)
			{
				MissilePartPrefabs = Game.Instance.CraftResourceData.MissilePartPrefabs.fins;
			}
			else if (SubPartType == MissileSubPartType.Inlet)
			{
				MissilePartPrefabs = Game.Instance.CraftResourceData.MissilePartPrefabs.inlets;
			}
			else if (SubPartType == MissileSubPartType.GreebleMissile)
			{
				MissilePartPrefabs = Game.Instance.CraftResourceData.MissilePartPrefabs.greebleMissile;
			}
			else if (SubPartType == MissileSubPartType.GreebleFin)
			{
				MissilePartPrefabs = Game.Instance.CraftResourceData.MissilePartPrefabs.greebleFin;
			}
			else
			{
				if (SubPartType != MissileSubPartType.Wings)
				{
					throw new NotImplementedException();
				}
				MissilePartPrefabs = Game.Instance.CraftResourceData.MissilePartPrefabs.wings;
			}
			SubPartPrefab = MissilePartPrefabs.prefabs.First();
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("minPosition", MinPosition));
			xElement.Add(new XAttribute("maxPosition", MaxPosition));
			xElement.Add(new XAttribute("angle", _angle));
			xElement.Add(new XAttribute("offset", _radialOffset));
			xElement.Add(new XAttribute("height", _height));
			xElement.Add(new XAttribute("length", _length));
			xElement.Add(new XAttribute("size", _size));
			xElement.Add(new XAttribute("symmetry", _symmetry));
			xElement.Add(new XAttribute("thickness", _thickness));
			xElement.Add(new XAttribute("style", SubPartPrefab.Id));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_size":
			case "_radialOffset":
			case "_height":
			case "_length":
			case "_thickness":
				return Utilities.FormatPercentage(sliderValue);
			case "_angle":
				sliderValue = Mathf.RoundToInt(sliderValue);
				return sliderValue + "°";
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			if (propertyName == "_symmetry")
			{
				if (_symmetry != -2)
				{
					return $"{_symmetry}x";
				}
				return "Mirror";
			}
			if (propertyName == "_style")
			{
				return SubPartPrefab.name;
			}
			return base.GetGenericDesignerPropertyToggleButtonValueLabel(propertyName, value);
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			switch (property.Member.Name)
			{
			case "_length":
				return () => MissilePartPrefabs.options.maxLength > 0f;
			case "_thickness":
				return () => MissilePartPrefabs.options.maxThickness > 0f;
			case "_height":
				return () => MissilePartPrefabs.options.maxHeight > 0f;
			case "_size":
				return () => MissilePartPrefabs.options.maxSize > 0f;
			case "_radialOffset":
			case "_symmetry":
				return () => SubPartPrefab.attachmentType == Assets.Scripts.Craft.Parts.Modifiers.Weapons.MissilePartPrefabs.AttachmentType.Radial;
			default:
				return base.GetGenericDesignerPropertyVisibilityCallback(property);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<ProceduralMissileSubPartScript>();
			Script.Data = this;
			return Script;
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

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			if (!string.IsNullOrEmpty(PropertyEditorDesc))
			{
				genericPartPropertiesScript.SetModifierHeaderText(PropertyEditorDesc);
			}
			ToggleButtonProperty property = genericPartPropertiesScript.GetProperty<ToggleButtonProperty>("_style");
			property.ButtonAttribute.Values.Clear();
			property.ButtonAttribute.Values.AddRange(from x in MissilePartPrefabs.prefabs
				orderby x.Id
				select x.Id);
			ToggleButtonProperty property2 = genericPartPropertiesScript.GetProperty<ToggleButtonProperty>("_symmetry");
			property2.ButtonAttribute.Values.Clear();
			int[] symmetries = MissilePartPrefabs.options.symmetries;
			foreach (int num2 in symmetries)
			{
				property2.ButtonAttribute.Values.Add(num2.ToString());
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			_refreshUI = true;
			ProceduralMissileScript connectedMissile = Script.GetConnectedMissile();
			if (propertyName == "_style" || propertyName == "_symmetry")
			{
				if (propertyName == "_style")
				{
					SubPartPrefab = GetSubPartPrefab(_style);
				}
				Script.BuildSubParts(connectedMissile);
			}
			else
			{
				Script.AdjustSubPart(connectedMissile);
			}
			if (connectedMissile != null)
			{
				connectedMissile.Data.RefreshPerformance();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			MinPosition = stateElement.GetFloatAttribute("minPosition");
			MaxPosition = stateElement.GetFloatAttribute("maxPosition");
			_angle = stateElement.GetFloatAttribute("angle");
			_radialOffset = stateElement.GetFloatAttribute("offset", 1f);
			_height = stateElement.GetFloatAttribute("height", 1f);
			_length = stateElement.GetFloatAttribute("length", 1f);
			_size = stateElement.GetFloatAttribute("size", 1f);
			_symmetry = stateElement.GetIntAttribute("symmetry", _symmetry, suppressExceptions: true);
			if (_symmetry < 1)
			{
				_symmetry = -2;
			}
			else if (_symmetry > 6)
			{
				_symmetry = 6;
			}
			_thickness = stateElement.GetFloatAttribute("thickness", 1f);
			SubPartPrefab = GetSubPartPrefab(stateElement.GetStringAttribute("style"));
			_style = SubPartPrefab.Id;
		}

		protected override float CalculateMass()
		{
			return 0.25f * (float)Mathf.Abs(_symmetry) * SubPartPrefab.massMultiplier * Length * Height * Thickness * 0.01f;
		}

		private MissilePartPrefabs.PartPrefab GetSubPartPrefab(string subPartID)
		{
			MissilePartPrefabs.PartPrefab partPrefab = MissilePartPrefabs.prefabs.FirstOrDefault((MissilePartPrefabs.PartPrefab x) => x.Id == subPartID);
			if (partPrefab == null)
			{
				partPrefab = MissilePartPrefabs.prefabs.First();
			}
			return partPrefab;
		}
	}
}
