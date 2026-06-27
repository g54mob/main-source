using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	public class PreviewImageType
	{
		private RectangleType viewBoxField;

		private string guidRefField;

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
		public string GuidRef
		{
			get
			{
				return guidRefField;
			}
			set
			{
				guidRefField = value;
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
