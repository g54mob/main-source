using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Paint
{
	[Serializable]
	public class PaintTextureData
	{
		private List<PaintTexturePreset> _presets;

		private Dictionary<string, PaintTexturePreset> _presetsById;

		public static string CustomPresetId => "custom";

		public bool Available => Loaded;

		[field: SerializeField]
		public string Category { get; }

		[field: SerializeField]
		public int ColorCount { get; }

		[field: SerializeField]
		public string DisplayName { get; }

		[field: SerializeField]
		public string Id { get; }

		public bool Loaded { get; set; }

		[field: SerializeField]
		public string LocationPath { get; }

		[field: SerializeField]
		public PaintTextureLocationType LocationType { get; }

		public bool NeedsProcessed { get; set; }

		public PaintTextureMaskNormalizationFlags NormalizationFlags { get; }

		[field: SerializeField]
		public PaintStyle PaintStyle { get; }

		public IReadOnlyList<IPaintTexturePreset> Presets => _presets;

		public Vector3 Scale { get; }

		[field: SerializeField]
		public int TextureIndex { get; }

		public PaintTextureData(XElement xml, int textureIndex, string rootPath, PaintTextureLocationType locationType, PaintStyle style, IReadOnlyDictionary<string, PaintTexturePreset> sharedPresets)
		{
			TextureIndex = textureIndex;
			LocationType = locationType;
			PaintStyle = style;
			Id = (string)xml.Attribute("id");
			if (string.IsNullOrEmpty(Id))
			{
				string text = (((string)xml.Attribute("path")) ?? string.Empty).Replace('\\', '/').TrimEnd('/');
				int num = text.LastIndexOf('/');
				string text3;
				if (num >= 0)
				{
					string text2 = text;
					int num2 = num + 1;
					text3 = text2.Substring(num2, text2.Length - num2);
				}
				else
				{
					text3 = text;
				}
				Id = text3;
				int num3 = Id.LastIndexOf('.');
				if (num3 >= 0)
				{
					Id = Id.Substring(0, num3);
				}
			}
			if (locationType == PaintTextureLocationType.LocalFileSystem)
			{
				Id = "Custom_" + Id;
			}
			DisplayName = (string)xml.Attribute("displayName");
			LocationPath = Path.Combine(rootPath, (string)xml.Attribute("path"));
			ColorCount = (int)xml.Attribute("colorCount");
			Category = xml.GetStringAttribute("category", "Default");
			float[] floatArrayAttribute = xml.GetFloatArrayAttribute("scale", 3, null);
			Scale = new Vector3((floatArrayAttribute[0] == 0f) ? 1f : floatArrayAttribute[0], (floatArrayAttribute[1] == 0f) ? 1f : floatArrayAttribute[1], (floatArrayAttribute[2] == 0f) ? 1f : floatArrayAttribute[2]);
			NormalizationFlags = (PaintTextureMaskNormalizationFlags)((xml.GetBoolAttribute("normalizeMaskColors", defaultValue: true) ? 1 : 0) | (xml.GetBoolAttribute("normalizeMaskProperties", defaultValue: true) ? 2 : 0));
			_presets = (from x in xml.Elements("Preset")
				select PaintTexturePreset.LoadFromXml(x, sharedPresets) into x
				where x != null
				select x).ToList();
			_presets.Add(new PaintTexturePreset
			{
				Id = CustomPresetId,
				DisplayName = "Custom",
				Colors = new PaintColorData[4]
				{
					new PaintColorData
					{
						Color = new Color32(160, 160, 160, byte.MaxValue)
					},
					new PaintColorData
					{
						Color = new Color32(128, 128, 128, byte.MaxValue)
					},
					new PaintColorData
					{
						Color = new Color32(96, 96, 96, byte.MaxValue)
					},
					new PaintColorData
					{
						Color = new Color32(64, 64, 64, byte.MaxValue)
					}
				},
				Offset = Vector3.zero,
				Rotation = Vector3.zero,
				Scale = Vector3.one
			});
			_presetsById = new Dictionary<string, PaintTexturePreset>();
			foreach (PaintTexturePreset preset in _presets)
			{
				_presetsById.Add(preset.Id, preset);
			}
		}

		public IPaintTexturePreset FindPreset(string presetId)
		{
			if (!_presetsById.TryGetValue(presetId, out var value))
			{
				return null;
			}
			return value;
		}

		public override string ToString()
		{
			return "Paint Texture '" + DisplayName + "', Id: " + Id + ", " + $"Index: {TextureIndex}, " + $"Style: {PaintStyle}, " + $"Location: {LocationType}, " + "Path: " + LocationPath + ", " + $"ColorCount: {ColorCount}, " + $"Scale: {Scale}, " + $"Normalization Flags: {NormalizationFlags}, " + "Presets: " + System.Environment.NewLine + string.Join(System.Environment.NewLine + "  ", Presets);
		}
	}
}
