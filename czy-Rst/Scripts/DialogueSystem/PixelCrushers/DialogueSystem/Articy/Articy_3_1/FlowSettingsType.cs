using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	[Serializable]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	public class FlowSettingsType
	{
		private int builtInScriptSupportField;

		private int gridSizeField;

		private int gridSizeEnforcedField;

		private int spacingHorizontalField;

		private int spacingVerticalField;

		private int spacingEnforcedField;

		public int BuiltInScriptSupport
		{
			get
			{
				return builtInScriptSupportField;
			}
			set
			{
				builtInScriptSupportField = value;
			}
		}

		public int GridSize
		{
			get
			{
				return gridSizeField;
			}
			set
			{
				gridSizeField = value;
			}
		}

		public int GridSizeEnforced
		{
			get
			{
				return gridSizeEnforcedField;
			}
			set
			{
				gridSizeEnforcedField = value;
			}
		}

		public int SpacingHorizontal
		{
			get
			{
				return spacingHorizontalField;
			}
			set
			{
				spacingHorizontalField = value;
			}
		}

		public int SpacingVertical
		{
			get
			{
				return spacingVerticalField;
			}
			set
			{
				spacingVerticalField = value;
			}
		}

		public int SpacingEnforced
		{
			get
			{
				return spacingEnforcedField;
			}
			set
			{
				spacingEnforcedField = value;
			}
		}
	}
}
