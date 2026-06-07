using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Paint
{
	public class PaintTexturePreset : IPaintTexturePreset
	{
		private class EqualityByIdComparer : EqualityComparer<IPaintTexturePreset>
		{
			public override bool Equals(IPaintTexturePreset x, IPaintTexturePreset y)
			{
				return string.Equals(x?.Id, y?.Id, StringComparison.Ordinal);
			}

			public override int GetHashCode(IPaintTexturePreset obj)
			{
				return obj?.GetHashCode() ?? 0;
			}
		}

		public static IEqualityComparer<IPaintTexturePreset> EqualityComparerById { get; } = new EqualityByIdComparer();

		IReadOnlyList<IPaintColorData> IPaintTexturePreset.Colors => Colors;

		public PaintColorData[] Colors { get; set; }

		public string DisplayName { get; set; }

		public string Id { get; set; }

		public Vector3 Offset { get; set; }

		public Vector3 Rotation { get; set; }

		public Vector3 Scale { get; set; }

		public static PaintTexturePreset LoadFromXml(XElement xml)
		{
			return LoadFromXml(xml, null);
		}

		public static PaintTexturePreset LoadFromXml(XElement xml, IReadOnlyDictionary<string, PaintTexturePreset> sharedPresets)
		{
			string text = ((sharedPresets != null) ? xml.GetStringAttribute("refId") : null);
			if (!string.IsNullOrEmpty(text))
			{
				if (!sharedPresets.TryGetValue(text, out var value))
				{
					Debug.LogError($"Unable to find shared paint texture preset with refId '{text}'. Preset not loaded: {System.Environment.NewLine}{xml}");
					return null;
				}
				PaintTexturePreset paintTexturePreset = value.Clone();
				string stringAttribute = xml.GetStringAttribute("id");
				if (!string.IsNullOrEmpty(stringAttribute))
				{
					paintTexturePreset.Id = stringAttribute;
				}
				string stringAttribute2 = xml.GetStringAttribute("displayName");
				if (!string.IsNullOrEmpty(stringAttribute2))
				{
					paintTexturePreset.DisplayName = stringAttribute2;
				}
				return paintTexturePreset;
			}
			try
			{
				return new PaintTexturePreset
				{
					Id = xml.GetStringAttribute("id"),
					DisplayName = xml.GetStringAttribute("displayName"),
					Colors = xml.GetArrayElements("Color", 4, (XElement x) => new PaintColorData(x), (PaintColorData x) => new PaintColorData()),
					Offset = xml.GetVector3Attribute("offset", Vector3.zero),
					Rotation = xml.GetVector3Attribute("rotation", Vector3.zero),
					Scale = xml.GetVector3AttributeWithLastParsedValueFallback("scale", 1f)
				};
			}
			catch (Exception exception)
			{
				Debug.LogError($"Unable to load paint texture preset from XML: {System.Environment.NewLine}{xml}");
				Debug.LogException(exception);
				return null;
			}
		}

		public void ApplyPreset(PaintColorData[] paintColorData)
		{
			Colors[0].CopyTo(paintColorData[0]);
			Colors[1].CopyTo(paintColorData[1]);
			Colors[2].CopyTo(paintColorData[2]);
			Colors[3].CopyTo(paintColorData[3]);
		}

		public PaintTexturePreset Clone()
		{
			return new PaintTexturePreset
			{
				Id = Id,
				DisplayName = DisplayName,
				Colors = PaintColorData.Clone(Colors),
				Offset = Offset,
				Rotation = Rotation,
				Scale = Scale
			};
		}

		public override string ToString()
		{
			return "Preset '" + DisplayName + "', Id: " + Id + ", Colors: " + string.Join(", ", (IEnumerable<PaintColorData>)Colors) + $"Offset: {Offset}, " + $"Rotation: {Rotation}, " + $"Scale: {Scale}";
		}

		public void UpdatePreset(PaintColorData[] paintColorData)
		{
			paintColorData[0].CopyTo(Colors[0]);
			paintColorData[1].CopyTo(Colors[1]);
			paintColorData[2].CopyTo(Colors[2]);
			paintColorData[3].CopyTo(Colors[3]);
		}
	}
}
