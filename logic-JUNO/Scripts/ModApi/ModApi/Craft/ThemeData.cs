using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Craft
{
	public class ThemeData
	{
		public const int MaxThemeMaterials = 50;

		private List<PartMaterial> _materials;

		public bool Hidden { get; private set; }

		public Guid Id { get; set; }

		public int MaterialCount => _materials.Count;

		public string Name { get; private set; }

		public ITheme Theme { get; set; }

		public ThemeData(XElement element, int xmlVersion)
		{
			_materials = new List<PartMaterial>();
			Name = element.Attribute("name").Value;
			Hidden = Utilities.GetBoolAttribute(element, "hidden", defaultValue: false);
			Guid? guid = Utilities.GetGuidAttribute(element, "id", null);
			if (!guid.HasValue)
			{
				Debug.LogWarningFormat("Theme '{0}' does not have a valid ID, so a new one is being generated.", Name);
				guid = Guid.NewGuid();
			}
			Id = guid.Value;
			List<XElement> list = element.Elements("Material").ToList();
			int num = 0;
			int num2 = list.Count();
			int num3 = Mathf.Max(20, num2);
			for (int i = 0; i < num3; i++)
			{
				PartMaterial partMaterial = new PartMaterial
				{
					Id = num++
				};
				if (i < num2)
				{
					XElement xElement = list[i];
					partMaterial.Name = xElement.Attribute("name")?.Value ?? string.Empty;
					partMaterial.Color = Utilities.HexToColor(xElement.Attribute("color").Value);
					partMaterial.Metallic = (float)xElement.Attribute("m");
					partMaterial.Smoothness = (float)xElement.Attribute("s");
					partMaterial.DetailStrength = ((float?)xElement.Attribute("d")) ?? 1f;
					partMaterial.EmissionStrength = ((float?)xElement.Attribute("e")).GetValueOrDefault();
					partMaterial.TransparencyStrength = ((float?)xElement.Attribute("t")).GetValueOrDefault();
				}
				else if (true)
				{
					AddMissingMaterialDefaults(partMaterial, i);
				}
				else
				{
					partMaterial.Name = string.Empty;
					partMaterial.Color = Color.white;
					partMaterial.Metallic = 0.1f;
					partMaterial.Smoothness = 0.08f;
					partMaterial.DetailStrength = 1f;
					partMaterial.EmissionStrength = 0f;
					partMaterial.TransparencyStrength = 0f;
				}
				if (Application.isMobilePlatform && partMaterial.Smoothness >= 0.1f)
				{
					partMaterial.SmoothnessModifier = -0.1f;
				}
				if (_materials.Count >= 50)
				{
					Debug.LogWarning("Do you really need that many colors in a theme?");
					break;
				}
				_materials.Add(partMaterial);
			}
		}

		public ThemeData Duplicate()
		{
			return new ThemeData(GenerateXml(optimizeXml: true), 15)
			{
				Theme = Theme
			};
		}

		public XElement GenerateXml(bool optimizeXml)
		{
			XElement xElement = new XElement("Theme", new XAttribute("name", Name));
			xElement.Add(new XAttribute("id", Id));
			foreach (PartMaterial material in _materials)
			{
				XElement xElement2 = new XElement("Material");
				xElement2.SetAttributeValue("name", material.Name);
				xElement2.SetAttributeValue("color", Utilities.ColorToHex(material.Color));
				xElement2.SetAttributeValue("m", material.Metallic);
				xElement2.SetAttributeValue("s", material.Smoothness);
				if (material.DetailStrength != 1f || !optimizeXml)
				{
					xElement2.SetAttributeValue("d", material.DetailStrength);
				}
				if (material.EmissionStrength != 0f || !optimizeXml)
				{
					xElement2.SetAttributeValue("e", material.EmissionStrength);
				}
				if (material.TransparencyStrength != 0f)
				{
					xElement2.SetAttributeValue("t", material.TransparencyStrength);
				}
				xElement.Add(xElement2);
			}
			return xElement;
		}

		public PartMaterial GetMaterial(int materialId)
		{
			if (materialId < 0)
			{
				materialId = _materials.Count + System.Math.Max(materialId, -_materials.Count);
			}
			while (materialId >= _materials.Count)
			{
				if (_materials.Count >= 50)
				{
					Debug.LogError("The maximum number of colors in a theme has been reached.");
					return null;
				}
				_materials.Add(CreateDefaultMaterial(materialId));
			}
			return _materials[materialId];
		}

		public void UpdateFromTheme(ThemeData newTheme, bool materialsOnly = false)
		{
			if (!materialsOnly)
			{
				Name = newTheme.Name;
				Id = newTheme.Id;
				Hidden = newTheme.Hidden;
			}
			_materials.Clear();
			foreach (PartMaterial material in newTheme._materials)
			{
				_materials.Add(material);
			}
		}

		public void UpdateMaterial(int materialId, Color color, float smoothness, float metallicness, float detailStrength, float emissionStrength)
		{
			PartMaterial material = GetMaterial(materialId);
			if (material == null)
			{
				Debug.LogErrorFormat("Could not update the theme material with id '{0}' because it could not be found.", materialId);
				return;
			}
			material.Color = color;
			material.Smoothness = smoothness;
			material.Metallic = metallicness;
			material.DetailStrength = detailStrength;
			material.EmissionStrength = emissionStrength;
		}

		private void AddMissingMaterialDefaults(PartMaterial partMaterial, int index)
		{
			partMaterial.Name = string.Empty;
			switch (index)
			{
			case 15:
				partMaterial.Color = Utilities.HexToColor("FFFFFF");
				partMaterial.Smoothness = 0f;
				partMaterial.Metallic = 0f;
				partMaterial.DetailStrength = 0.2f;
				partMaterial.EmissionStrength = 0f;
				partMaterial.TransparencyStrength = 0f;
				break;
			case 16:
				partMaterial.Color = Utilities.HexToColor("178BFF");
				partMaterial.Smoothness = 0.44f;
				partMaterial.Metallic = 0f;
				partMaterial.DetailStrength = 0.2f;
				partMaterial.EmissionStrength = 0f;
				partMaterial.TransparencyStrength = 0f;
				break;
			case 17:
				partMaterial.Color = Utilities.HexToColor("7F7F7F");
				partMaterial.Smoothness = 0.37f;
				partMaterial.Metallic = 0.65f;
				partMaterial.DetailStrength = 1f;
				partMaterial.EmissionStrength = 0f;
				partMaterial.TransparencyStrength = 0f;
				break;
			case 18:
				partMaterial.Color = Utilities.HexToColor("454545");
				partMaterial.Smoothness = 0.57f;
				partMaterial.Metallic = 1f;
				partMaterial.DetailStrength = 1f;
				partMaterial.EmissionStrength = 0f;
				partMaterial.TransparencyStrength = 0f;
				break;
			case 19:
				partMaterial.Color = Utilities.HexToColor("8B8B8B");
				partMaterial.Smoothness = 1f;
				partMaterial.Metallic = 1f;
				partMaterial.DetailStrength = 1f;
				partMaterial.EmissionStrength = 0f;
				partMaterial.TransparencyStrength = 0f;
				break;
			}
		}

		private PartMaterial CreateDefaultMaterial(int id)
		{
			return new PartMaterial
			{
				Id = id,
				Name = string.Empty,
				Color = new Color(1f, 1f, 1f, 1f),
				Metallic = 0.3f,
				Smoothness = 0.6f,
				SmoothnessModifier = 0f,
				DetailStrength = 1f,
				EmissionStrength = 0f,
				TransparencyStrength = 0f
			};
		}
	}
}
