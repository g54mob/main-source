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
	public class AllowedCategory
	{
		private AssetCategoryType nameField;

		[XmlAttribute]
		public AssetCategoryType Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}
	}
}
