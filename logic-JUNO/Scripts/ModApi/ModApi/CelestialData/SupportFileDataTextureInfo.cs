using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.CelestialData
{
	public class SupportFileDataTextureInfo
	{
		public TextureFormat? Format { get; }

		public int? Height { get; }

		public int? Width { get; }

		public SupportFileDataTextureInfo(Texture2D texture)
		{
			Width = texture.width;
			Height = texture.height;
			Format = texture.format;
		}

		public SupportFileDataTextureInfo(XElement xml)
		{
			Width = xml.GetIntAttributeOrNull("width");
			Height = xml.GetIntAttributeOrNull("height");
			Format = xml.GetEnumAttributeOrNull<TextureFormat>("format");
		}

		public XElement SaveToXml(string elementName)
		{
			return new XElement(elementName, Width.HasValue ? new XAttribute("width", Width.Value) : null, Height.HasValue ? new XAttribute("height", Height.Value) : null, Format.HasValue ? new XAttribute("format", Format.Value) : null);
		}
	}
}
