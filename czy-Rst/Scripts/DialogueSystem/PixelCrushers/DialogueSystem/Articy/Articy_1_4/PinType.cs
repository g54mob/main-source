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
	public class PinType
	{
		private string expressionField;

		private string guidField;

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
		public string Guid
		{
			get
			{
				return guidField;
			}
			set
			{
				guidField = value;
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
