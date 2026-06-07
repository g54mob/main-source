using System.IO;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.Planet
{
	public class PlanetCubemapData
	{
		public static readonly string CubemapDataFileName = "CubemapData.xml";

		public Vector3 MaxColor { get; set; }

		public float MaxHeight { get; set; }

		public float MinHeight { get; set; }

		public static bool Exists(IPlanetData planet)
		{
			return planet.GeneratedData.FileExists(CubemapDataFileName);
		}

		public static PlanetCubemapData GetDefault()
		{
			return new PlanetCubemapData
			{
				MinHeight = 0f,
				MaxHeight = 0f,
				MaxColor = Vector3.one
			};
		}

		public static PlanetCubemapData Load(IPlanetData planet)
		{
			string filePath = planet.GeneratedData.GetFilePath(CubemapDataFileName);
			if (!File.Exists(filePath))
			{
				return null;
			}
			XElement root = XDocument.Load(filePath).Root;
			return new PlanetCubemapData
			{
				MinHeight = root.GetFloatAttribute("minHeight"),
				MaxHeight = root.GetFloatAttribute("maxHeight"),
				MaxColor = root.GetVector3Attribute("maxColor", Vector3.one)
			};
		}

		public void Save(IPlanetData planet)
		{
			new XDocument(new XElement("CubemapData", new XAttribute("minHeight", MinHeight), new XAttribute("maxHeight", MaxHeight), new XAttribute("maxColor", MaxColor.ToXAttributeValue()))).Save(planet.GeneratedData.GetFilePath(CubemapDataFileName, createDirectory: true));
		}
	}
}
