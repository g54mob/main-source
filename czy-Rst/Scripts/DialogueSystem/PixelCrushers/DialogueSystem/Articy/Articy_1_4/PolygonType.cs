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
	public class PolygonType
	{
		private VerticesType verticesField;

		public VerticesType Vertices
		{
			get
			{
				return verticesField;
			}
			set
			{
				verticesField = value;
			}
		}
	}
}
