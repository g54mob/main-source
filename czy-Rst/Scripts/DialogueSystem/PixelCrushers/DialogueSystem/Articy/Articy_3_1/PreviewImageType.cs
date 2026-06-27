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
	public class PreviewImageType
	{
		private RectangleType viewBoxField;

		private string idRefField;

		private ViewBoxModeType modeField;

		public RectangleType ViewBox
		{
			get
			{
				return viewBoxField;
			}
			set
			{
				viewBoxField = value;
			}
		}

		[XmlAttribute]
		public string IdRef
		{
			get
			{
				return idRefField;
			}
			set
			{
				idRefField = value;
			}
		}

		[XmlAttribute]
		public ViewBoxModeType Mode
		{
			get
			{
				return modeField;
			}
			set
			{
				modeField = value;
			}
		}
	}
}
