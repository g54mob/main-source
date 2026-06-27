using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
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
		[DefaultValue(1)]
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
		[DefaultValue(StrokeStyleType.Solid)]
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
