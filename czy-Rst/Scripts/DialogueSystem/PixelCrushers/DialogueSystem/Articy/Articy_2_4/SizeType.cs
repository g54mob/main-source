using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
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
