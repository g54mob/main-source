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
	public class OutlineType
	{
		private string colorField;

		private int sizeField;

		private StrokeStyleType styleField;

		[XmlAttribute]
		public string Color
		{
			get
			{
				return colorField;
			}
			set
			{
				colorField = value;
			}
		}

		[XmlAttribute]
		public int Size
		{
			get
			{
				return sizeField;
			}
			set
			{
				sizeField = value;
			}
		}

		[XmlAttribute]
		public StrokeStyleType Style
		{
			get
			{
				return styleField;
			}
			set
			{
				styleField = value;
			}
		}

		public OutlineType()
		{
			sizeField = 1;
			styleField = StrokeStyleType.Solid;
		}
	}
}
