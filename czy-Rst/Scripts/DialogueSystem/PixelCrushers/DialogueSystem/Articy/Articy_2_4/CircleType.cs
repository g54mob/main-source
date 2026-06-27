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
	public class CircleType
	{
		private float centerXField;

		private float centerYField;

		private float radiusField;

		[XmlAttribute]
		public float CenterX
		{
			get
			{
				return centerXField;
			}
			set
			{
				centerXField = value;
			}
		}

		[XmlAttribute]
		public float CenterY
		{
			get
			{
				return centerYField;
			}
			set
			{
				centerYField = value;
			}
		}

		[XmlAttribute]
		public float Radius
		{
			get
			{
				return radiusField;
			}
			set
			{
				radiusField = value;
			}
		}
	}
}
