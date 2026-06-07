using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.Paint;
using Jundroo.Common.DataTypes;
using Jundroo.Common.Extensions;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class ThemeData
	{
		public const float MaxEmission = 5f;

		public const int MaxPartMaterials = 50;

		private EnumDictionary<PaintStyle, PartMaterial> _styleSpecificReservedMaterials;

		public IReadOnlyList<PartMaterial> AllMaterials { get; }

		public bool Hidden { get; set; }

		public List<PartMaterial> Materials { get; }

		public string Name { get; set; }

		public Color PartDamageColor { get; set; }

		public int[] PartMaterialReassignments { get; }

		public List<PartMaterial> ReservedMaterials { get; }

		public ThemeData(XElement element, int xmlVersion)
		{
			Materials = new List<PartMaterial>(24);
			ReservedMaterials = new List<PartMaterial>(6);
			Name = element.Attribute("name").Value;
			Hidden = element.GetBoolAttribute("hidden");
			PartDamageColor = element.GetHtmlColorAttribute("damageColor", Color.red);
			int num = 0;
			int num2 = -1;
			int num3 = 50 - ReservedMaterials.Capacity;
			foreach (XElement item in element.Elements("Material"))
			{
				if (Materials.Count > num3)
				{
					Debug.LogError(string.Format("Too many materials in theme '{0}'. Max theme materials: {1}", Name ?? "(null)", num3));
					break;
				}
				PartMaterial partMaterial = new PartMaterial();
				partMaterial.IsReserved = (bool?)item.Attribute("hidden") == true;
				partMaterial.Id = (partMaterial.IsReserved ? num2-- : num++);
				partMaterial.Name = item.GetStringAttribute("name");
				partMaterial.Style = item.GetEnumAttribute("style", PaintStyle.SolidColor);
				partMaterial.ColorData = item.GetArrayElements("Color", 4, (XElement x) => new PaintColorData(x), (PaintColorData x) => new PaintColorData());
				partMaterial.TextureBlend = item.GetFloatAttribute("textureBlend", 0.7f);
				partMaterial.TextureOffset = item.GetVector3Attribute("textureOffset", Vector3.zero);
				partMaterial.TextureRotation = item.GetVector3Attribute("textureRotation", Vector3.zero);
				partMaterial.TextureScale = item.GetVector3Attribute("textureScale", Vector3.one);
				partMaterial.TextureWrapMode = item.GetEnumArrayAttribute<PaintTextureWrapMode>("textureWrapMode", 3);
				string stringAttribute = item.GetStringAttribute("texture");
				if (stringAttribute != null)
				{
					partMaterial.Texture = Game.Instance.PaintTextureManager.GetTextureData(partMaterial.Style, stringAttribute);
					if (partMaterial.Texture == null)
					{
						Debug.LogError($"Unable to find part material texture with ID '{stringAttribute}' and style '{partMaterial.Style}'");
					}
					string stringAttribute2 = item.GetStringAttribute("texturePreset");
					if (partMaterial.Texture != null && !string.IsNullOrEmpty(stringAttribute2))
					{
						partMaterial.TexturePresetId = stringAttribute2;
						if (partMaterial.Texture.FindPreset(partMaterial.TexturePresetId) == null)
						{
							Debug.LogError($"Unable to find part material texture preset with ID '{stringAttribute2}' for texture '{stringAttribute}' and style '{partMaterial.Style}'");
							IReadOnlyList<IPaintTexturePreset> presets = partMaterial.Texture.Presets;
							partMaterial.TexturePresetId = presets?[presets.Count - 1]?.Id ?? null;
						}
					}
				}
				else
				{
					partMaterial.ColorData[0].Color = item.GetColorAttribute("color", Color.white, ColorStringFormat.HexRGBA);
				}
				if (item.Attribute("s") != null)
				{
					partMaterial.Metallic = item.GetFloatAttribute("m");
					partMaterial.Smoothness = item.GetFloatAttribute("s");
					if (xmlVersion < 4)
					{
						if (Mathf.Approximately(partMaterial.Smoothness, 0.93f))
						{
							partMaterial.Smoothness = 0.83f;
						}
						else if (Mathf.Approximately(partMaterial.Smoothness, 0.65f))
						{
							partMaterial.Smoothness = 0.7f;
						}
					}
				}
				else
				{
					string finishName = PaintFinishes.GetFinishName(float.Parse(item.Attribute("r").Value));
					partMaterial.Metallic = PaintFinishes.GetMetallicValue(finishName);
					partMaterial.Smoothness = PaintFinishes.GetSmoothnessValue(finishName);
				}
				float floatAttribute = item.GetFloatAttribute("e");
				partMaterial.EmissionDay = item.GetFloatAttribute("ed", floatAttribute);
				partMaterial.EmissionNight = item.GetFloatAttribute("en", floatAttribute);
				if (Application.isMobilePlatform && partMaterial.Smoothness >= 0.1f)
				{
					partMaterial.SmoothnessModifier = -0.1f;
				}
				if (partMaterial.IsReserved)
				{
					ReservedMaterials.Add(partMaterial);
				}
				else
				{
					Materials.Add(partMaterial);
				}
			}
			ThemeData themeData = Game.Instance.AircraftThemes?.CustomTheme;
			if (Name?.ToLower() == "custom" && themeData != null)
			{
				if (Materials.Count != 0 || ReservedMaterials.Count != 0)
				{
					if (xmlVersion <= 6)
					{
						if (ReservedMaterials.Count != 0)
						{
							Debug.LogWarning($"Upgrading XML version {xmlVersion} craft, but it already has reserved materials.");
						}
						else
						{
							for (int num4 = 15; num4 <= 18; num4++)
							{
								if (num4 >= Materials.Count)
								{
									ReservedMaterials.Add(themeData.ReservedMaterials[num4 - 15].Clone());
								}
								else
								{
									ReservedMaterials.Add(Materials[num4].Clone());
								}
							}
							int num5 = Mathf.Min(4, Materials.Count - 15);
							Materials.RemoveRange(15, num5);
							PartMaterialReassignments = new int[Materials.Count + 4];
							for (int num6 = 0; num6 < PartMaterialReassignments.Length; num6++)
							{
								if (num6 < 15)
								{
									PartMaterialReassignments[num6] = num6;
								}
								else if (num6 >= 15 && num6 < 15 + num5)
								{
									PartMaterialReassignments[num6] = -(num6 - 14);
								}
								else
								{
									PartMaterialReassignments[num6] = num6 - num5;
								}
							}
						}
					}
					else if (xmlVersion == 7 && ReservedMaterials.Count == 0)
					{
						int num7 = Materials.Count - 4;
						for (int num8 = 0; num8 < 4; num8++)
						{
							ReservedMaterials.Add(Materials[num7]);
							Materials.RemoveAt(num7);
						}
						PartMaterialReassignments = new int[Materials.Count + 4];
						for (int num9 = 0; num9 < PartMaterialReassignments.Length; num9++)
						{
							PartMaterialReassignments[num9] = ((num9 < num7) ? num9 : (-num9 + Materials.Count - 1));
						}
					}
				}
				for (int num10 = ReservedMaterials.Count; num10 < themeData.ReservedMaterials.Count; num10++)
				{
					ReservedMaterials.Add(themeData.ReservedMaterials[num10].Clone());
				}
				for (int num11 = Materials.Count; num11 < themeData.Materials.Count; num11++)
				{
					Materials.Add(themeData.Materials[num11].Clone());
				}
			}
			_styleSpecificReservedMaterials = new EnumDictionary<PaintStyle, PartMaterial>();
			_styleSpecificReservedMaterials[PaintStyle.AlbedoTexture] = new PartMaterial
			{
				Id = num2--,
				IsReserved = true,
				Style = PaintStyle.AlbedoTexture,
				ColorData = new PaintColorData[4].Fill(),
				Metallic = 0f,
				Smoothness = 0f,
				EmissionDay = 0f,
				EmissionNight = 0f,
				TextureWrapMode = new PaintTextureWrapMode[3]
			};
			_styleSpecificReservedMaterials[PaintStyle.AlbedoTextureSupersampledWithMipmapBias] = new PartMaterial
			{
				Id = num2--,
				IsReserved = true,
				Style = PaintStyle.AlbedoTextureSupersampledWithMipmapBias,
				ColorData = new PaintColorData[4].Fill(),
				Metallic = 0f,
				Smoothness = 0f,
				EmissionDay = 0f,
				EmissionNight = 0f,
				TextureWrapMode = new PaintTextureWrapMode[3]
			};
			List<PartMaterial> list = new List<PartMaterial>(Materials.Count + ReservedMaterials.Count);
			list.AddRange(Materials);
			list.AddRange(ReservedMaterials);
			list.AddRange(_styleSpecificReservedMaterials.Values.Where((PartMaterial x) => x != null));
			AllMaterials = list;
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Theme", new XAttribute("name", Name));
			if (PartDamageColor != Color.red)
			{
				xElement.SetAttribute("damageColor", PartDamageColor, ColorStringFormat.HexRGB);
			}
			Action<XElement, PartMaterial, bool> action = delegate(XElement parent, PartMaterial material, bool isReserved)
			{
				XElement xElement2 = new XElement("Material");
				xElement2.SetAttributeValue("style", material.Style);
				xElement2.SetAttributeValue("name", material.Name);
				if (material.Style == PaintStyle.SolidColor)
				{
					xElement2.SetAttribute("color", material.ColorData[0].Color, ColorStringFormat.HexRGBA);
				}
				else
				{
					int num = material.Texture?.ColorCount ?? 4;
					for (int i = 0; i < num; i++)
					{
						xElement2.Add(material.ColorData[i].SaveToXml(new XElement("Color")));
					}
					xElement2.SetAttributeValue("texture", material.Texture?.Id);
					xElement2.SetAttributeValue("texturePreset", material.TexturePresetId);
					xElement2.SetAttributeValue("textureBlend", material.TextureBlend);
					xElement2.SetAttribute("textureOffset", material.TextureOffset);
					xElement2.SetAttribute("textureRotation", material.TextureRotation);
					xElement2.SetAttribute("textureScale", material.TextureScale);
					if (material.Style == PaintStyle.SinglePlaneTextureColorMask)
					{
						SetEnumArrayAttribute(xElement2, "textureWrapMode", material.TextureWrapMode, 3, singleValueIfEqual: true);
					}
				}
				xElement2.SetAttributeValue("s", material.Smoothness);
				xElement2.SetAttributeValue("m", material.Metallic);
				xElement2.SetAttributeValue("ed", material.EmissionDay);
				xElement2.SetAttributeValue("en", material.EmissionNight);
				if (isReserved)
				{
					xElement2.SetAttributeValue("hidden", "true");
				}
				parent.Add(xElement2);
			};
			foreach (PartMaterial reservedMaterial in ReservedMaterials)
			{
				action(xElement, reservedMaterial, arg3: true);
			}
			foreach (PartMaterial material in Materials)
			{
				action(xElement, material, arg3: false);
			}
			return xElement;
		}

		public PartMaterial GetMaterial(int materialId)
		{
			return AllMaterials[GetMaterialIndex(materialId)];
		}

		public int GetMaterialIndex(int materialId)
		{
			int num = materialId;
			if (num < 0)
			{
				num = Materials.Count - 1 - materialId;
			}
			if (num < AllMaterials.Count)
			{
				return num;
			}
			Debug.Log("Material ID does not exist: " + materialId);
			return 0;
		}

		public PartMaterial GetReservedMaterial(PaintStyle style)
		{
			return _styleSpecificReservedMaterials[style] ?? throw new NotSupportedException($"Paint style '{style}' does not have a specific reserved texture.");
		}

		private void SetEnumArrayAttribute<T>(XElement element, string attributeName, T[] array, int elementCount, bool singleValueIfEqual) where T : struct, Enum
		{
			elementCount = Math.Min(elementCount, array.Length);
			if (singleValueIfEqual)
			{
				bool flag = true;
				for (int i = 1; i < elementCount; i++)
				{
					flag &= EqualityComparer<T>.Default.Equals(array[i], array[i - 1]);
				}
				if (flag)
				{
					element.SetAttributeValue(attributeName, array[0]);
					return;
				}
			}
			element.SetAttributeValue(attributeName, string.Join(",", array));
		}
	}
}
