using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_4_0
{
	[Serializable]
	[GeneratedCode("xsd", "4.8.3928.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.articy.com/schemas/articydraft/4.0/XmlContentExport_FullProject.xsd")]
	public class JourneyMethodReturnValuesType
	{
		private string scriptTextField;

		private JourneyMethodReturnValueType[] methodValueField;

		private int countField;

		public string ScriptText
		{
			get
			{
				return scriptTextField;
			}
			set
			{
				scriptTextField = value;
			}
		}

		[XmlElement("MethodValue")]
		public JourneyMethodReturnValueType[] MethodValue
		{
			get
			{
				return methodValueField;
			}
			set
			{
				methodValueField = value;
			}
		}

		[XmlAttribute]
		public int Count
		{
			get
			{
				return countField;
			}
			set
			{
				countField = value;
			}
		}
	}
}
