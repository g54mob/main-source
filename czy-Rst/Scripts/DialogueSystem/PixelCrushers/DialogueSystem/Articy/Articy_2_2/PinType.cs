using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	public class PinType
	{
		private string expressionField;

		private string idField;

		private int indexField;

		private SemanticType semanticField;

		public string Expression
		{
			get
			{
				return expressionField;
			}
			set
			{
				expressionField = value;
			}
		}

		[XmlAttribute]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute]
		public int Index
		{
			get
			{
				return indexField;
			}
			set
			{
				indexField = value;
			}
		}

		[XmlAttribute]
		public SemanticType Semantic
		{
			get
			{
				return semanticField;
			}
			set
			{
				semanticField = value;
			}
		}
	}
}
