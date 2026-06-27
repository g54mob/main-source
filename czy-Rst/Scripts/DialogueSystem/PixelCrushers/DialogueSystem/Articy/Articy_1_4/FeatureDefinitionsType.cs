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
	public class FeatureDefinitionsType
	{
		private FeatureDefinitionRefType[] featureDefinitionRefField;

		private int countField;

		private bool countFieldSpecified;

		[XmlElement("FeatureDefinitionRef")]
		public FeatureDefinitionRefType[] FeatureDefinitionRef
		{
			get
			{
				return featureDefinitionRefField;
			}
			set
			{
				featureDefinitionRefField = value;
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

		[XmlIgnore]
		public bool CountSpecified
		{
			get
			{
				return countFieldSpecified;
			}
			set
			{
				countFieldSpecified = value;
			}
		}
	}
}
