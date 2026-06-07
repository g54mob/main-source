using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ModApi.Craft
{
	public class DesignerSettingsData
	{
		public class DesignerPartCollisions
		{
			public const bool EnabledDefault = false;

			public const bool FuselageShapeToolDefault = true;

			public const bool FuselageToolDefault = true;

			public const bool MovePartToolDefault = true;

			public const bool SymmetryModeChangeDefault = true;

			public const float ToleranceDefault = 0.05f;

			public const bool WingToolDefault = true;

			public bool Enabled { get; set; }

			public bool FuselageShapeTool { get; set; }

			public bool FuselageTool { get; set; }

			public bool MovePartTool { get; set; }

			public bool SymmetryModeChange { get; set; }

			public float Tolerance { get; set; }

			public bool WingTool { get; set; }

			public DesignerPartCollisions(XElement xml, int xmlVersion)
			{
				if (xml == null)
				{
					xml = new XElement("PartCollisions");
				}
				Enabled = (bool?)xml.Attribute("enabled") == true;
				Tolerance = ((float?)xml.Attribute("tolerance")) ?? 0.05f;
				MovePartTool = ((bool?)xml.Attribute("movePartTool")) ?? true;
				WingTool = ((bool?)xml.Attribute("wingTool")) ?? true;
				FuselageTool = ((bool?)xml.Attribute("fuselageTool")) ?? true;
				FuselageShapeTool = ((bool?)xml.Attribute("fuselageShapeTool")) ?? true;
				SymmetryModeChange = ((bool?)xml.Attribute("symmetryModeChange")) ?? true;
			}

			public XElement GenerateXml()
			{
				XElement xElement = new XElement("PartCollisions", (!Enabled) ? null : new XAttribute("enabled", Enabled), (Tolerance == 0.05f) ? null : new XAttribute("tolerance", Tolerance), MovePartTool ? null : new XAttribute("movePartTool", MovePartTool), WingTool ? null : new XAttribute("wingTool", WingTool), FuselageTool ? null : new XAttribute("fuselageTool", FuselageTool), FuselageShapeTool ? null : new XAttribute("fuselageShapeTool", FuselageShapeTool), SymmetryModeChange ? null : new XAttribute("symmetryModeChange", SymmetryModeChange));
				if (xElement.Attributes().Count() + xElement.Elements().Count() == 0)
				{
					return null;
				}
				return xElement;
			}
		}

		public string CurrentThemeName { get; set; }

		public ThemeData CustomTheme { get; set; }

		public DesignerPartCollisions PartCollisions { get; private set; }

		public List<int> UserStages { get; private set; }

		public DesignerSettingsData(XElement xml, int xmlVersion, CraftThemes themes)
		{
			if (xml == null)
			{
				xml = new XElement("DesignerSettings");
			}
			PartCollisions = new DesignerPartCollisions(xml.Element("PartCollisions"), xmlVersion);
			CurrentThemeName = Utilities.GetStringAttribute(xml, "themeName", "Custom");
			XElement xElement = xml.Element("Theme");
			if (xElement != null)
			{
				CustomTheme = new ThemeData(xElement, xmlVersion);
			}
			else if (themes != null)
			{
				CustomTheme = themes.GetTheme("Custom").Duplicate();
			}
			UserStages = Utilities.GetIntListAttribute(xml, "userStages");
		}

		public XElement GenerateXml(bool optimizeXml)
		{
			XElement xElement = new XElement("DesignerSettings", new XAttribute("themeName", CurrentThemeName), PartCollisions.GenerateXml());
			if (CustomTheme != null)
			{
				xElement.Add(CustomTheme.GenerateXml(optimizeXml));
			}
			if (UserStages.Count > 0)
			{
				xElement.Add(new XAttribute("userStages", string.Join(",", UserStages)));
			}
			if (xElement.Attributes().Count() + xElement.Elements().Count() == 0)
			{
				return null;
			}
			return xElement;
		}
	}
}
