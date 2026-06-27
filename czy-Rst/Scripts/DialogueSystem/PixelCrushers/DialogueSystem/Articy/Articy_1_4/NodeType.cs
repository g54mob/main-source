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
	public class NodeType
	{
		private NodeType[] nodeField;

		private string[] textField;

		private string guidField;

		private string typeField;

		[XmlElement("Node")]
		public NodeType[] Node
		{
			get
			{
				return nodeField;
			}
			set
			{
				nodeField = value;
			}
		}

		[XmlText]
		public string[] Text
		{
			get
			{
				return textField;
			}
			set
			{
				textField = value;
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
		public string Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
			}
		}
	}
}
