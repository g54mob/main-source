using System.Xml.Linq;
using Assets.Scripts.Mods;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerPart
	{
		public XElement AssemblyElement { get; set; }

		public string Category { get; set; }

		public string Description { get; set; }

		public float EngineThrust { get; set; }

		public string Header { get; set; }

		public string Icon { get; set; }

		public bool IsLegacy { get; set; }

		public bool IsSubassembly => Category == "Sub Assemblies";

		public float Mass { get; set; }

		public LoadedMod Mod { get; set; }

		public string Name { get; set; }

		public Vector3 StudioOffset { get; set; }

		public Vector3 StudioRotation { get; set; }

		public float StudioScale { get; set; }

		public string SubassemblyFilePath { get; set; }

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("DesignerPart");
			xElement.SetAttributeValue("name", Name);
			xElement.SetAttributeValue("category", Category);
			xElement.SetAttributeValue("icon", Icon);
			xElement.SetAttributeValue("description", Description);
			xElement.Add(AssemblyElement);
			return xElement;
		}
	}
}
