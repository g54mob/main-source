using System.Xml.Linq;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Paint
{
	public class PaintColorData : IPaintColorData
	{
		public Color Color { get; set; }

		public float? EmissionDay { get; set; }

		public float? EmissionNight { get; set; }

		public float? Metallic { get; set; }

		public float? Smoothness { get; set; }

		public PaintColorData()
		{
			Color = Color.white;
		}

		public PaintColorData(XElement xml)
		{
			Color = xml.GetColorAttribute("c", Color.black, ColorStringFormat.HexRGBA);
			Smoothness = xml.GetFloatAttributeOrNull("s");
			Metallic = xml.GetFloatAttributeOrNull("m");
			float? floatAttributeOrNull = xml.GetFloatAttributeOrNull("e");
			EmissionDay = xml.GetFloatAttributeOrNull("ed") ?? floatAttributeOrNull;
			EmissionNight = xml.GetFloatAttributeOrNull("en") ?? floatAttributeOrNull;
		}

		public static PaintColorData[] Clone(PaintColorData[] source)
		{
			PaintColorData[] array = new PaintColorData[source.Length];
			for (int i = 0; i < source.Length; i++)
			{
				array[i] = source[i].Clone();
			}
			return array;
		}

		public PaintColorData Clone()
		{
			PaintColorData paintColorData = new PaintColorData();
			CopyTo(paintColorData);
			return paintColorData;
		}

		public void CopyTo(PaintColorData other)
		{
			other.Color = Color;
			other.Smoothness = Smoothness;
			other.Metallic = Metallic;
			other.EmissionDay = EmissionDay;
			other.EmissionNight = EmissionNight;
		}

		public bool IsEqual(IPaintColorData other)
		{
			if (Mathf.Approximately(Color.r, other.Color.r) && Mathf.Approximately(Color.g, other.Color.g) && Mathf.Approximately(Color.b, other.Color.b) && Mathf.Approximately(Color.a, other.Color.a) && Smoothness.HasValue == other.Smoothness.HasValue && Metallic.HasValue == other.Metallic.HasValue && EmissionDay.HasValue == other.EmissionDay.HasValue && EmissionNight.HasValue == other.EmissionNight.HasValue && Mathf.Approximately(Smoothness.GetValueOrDefault(), other.Smoothness.GetValueOrDefault()) && Mathf.Approximately(Metallic.GetValueOrDefault(), other.Metallic.GetValueOrDefault()) && Mathf.Approximately(EmissionDay.GetValueOrDefault(), other.EmissionDay.GetValueOrDefault()))
			{
				return Mathf.Approximately(EmissionNight.GetValueOrDefault(), other.EmissionNight.GetValueOrDefault());
			}
			return false;
		}

		public XElement SaveToXml(XElement xml)
		{
			xml.SetAttribute("c", Color, ColorStringFormat.HexRGBA);
			xml.SetAttributeValue("s", Smoothness);
			xml.SetAttributeValue("m", Metallic);
			xml.SetAttributeValue("ed", EmissionDay);
			xml.SetAttributeValue("en", EmissionNight);
			return xml;
		}

		public override string ToString()
		{
			return $"RGBA({Color.r}, {Color.g}, {Color.b}, {Color.a}), " + "SME(" + (Smoothness?.ToString() ?? "null") + ", " + (Metallic?.ToString() ?? "null") + ", " + (EmissionDay?.ToString() ?? "null") + ", " + (EmissionNight?.ToString() ?? "null") + ")";
		}
	}
}
