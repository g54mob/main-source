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
	public class SizeType
	{
		private float widthField;

		private float heightField;

		[XmlAttribute]
		public float Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		[XmlAttribute]
		public float Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}
	}
}
