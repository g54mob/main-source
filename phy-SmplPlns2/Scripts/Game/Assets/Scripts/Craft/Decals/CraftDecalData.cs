using System;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Decals
{
	[Serializable]
	public class CraftDecalData
	{
		public static CraftDecalData Default { get; } = new CraftDecalData();

		[field: SerializeField]
		public string Category { get; }

		[field: SerializeField]
		public string DisplayName { get; }

		[field: SerializeField]
		public string Id { get; }

		[field: SerializeField]
		public string LocationPath { get; }

		[field: SerializeField]
		public float AspectRatio { get; }

		[field: SerializeField]
		public CraftDecalLocationType LocationType { get; }

		public CraftDecalData(XElement xml, string rootPath, CraftDecalLocationType locationType)
		{
			LocationType = locationType;
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
			if (locationType == CraftDecalLocationType.LocalFileSystem)
			{
				Id = "Custom_" + Id;
			}
			DisplayName = (string)xml.Attribute("displayName");
			Category = (string)xml.Attribute("category");
			LocationPath = Path.Combine(rootPath, (string)xml.Attribute("path"));
			AspectRatio = float.Parse(xml.Attribute("aspectRatio").Value);
		}

		private CraftDecalData()
		{
			Id = "Default";
			DisplayName = "Default";
			LocationPath = "Craft/CraftDecals/Textures/Default";
			LocationType = CraftDecalLocationType.Resource;
			AspectRatio = 1f;
		}

		public override string ToString()
		{
			return "Craft Decal '" + DisplayName + "', Id: " + Id + ", " + $"Location: {LocationType}, " + "Path: " + LocationPath + ", " + $"AspectRatio: {AspectRatio}";
		}
	}
}
