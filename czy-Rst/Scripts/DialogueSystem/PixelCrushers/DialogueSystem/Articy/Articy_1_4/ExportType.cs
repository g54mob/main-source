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
	[XmlRoot("Export", Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd", IsNullable = false)]
	public class ExportType
	{
		private ContentType contentField;

		private HierarchyType hierarchyField;

		private string[] exportErrorsField;

		private string versionField;

		private string creatorToolField;

		private string creatorVersionField;

		private DateTime createdOnField;

		public ContentType Content
		{
			get
			{
				return contentField;
			}
			set
			{
				contentField = value;
			}
		}

		public HierarchyType Hierarchy
		{
			get
			{
				return hierarchyField;
			}
			set
			{
				hierarchyField = value;
			}
		}

		[XmlArrayItem("Error", IsNullable = false)]
		public string[] ExportErrors
		{
			get
			{
				return exportErrorsField;
			}
			set
			{
				exportErrorsField = value;
			}
		}

		[XmlAttribute]
		public string Version
		{
			get
			{
				return versionField;
			}
			set
			{
				versionField = value;
			}
		}

		[XmlAttribute]
		public string CreatorTool
		{
			get
			{
				return creatorToolField;
			}
			set
			{
				creatorToolField = value;
			}
		}

		[XmlAttribute]
		public string CreatorVersion
		{
			get
			{
				return creatorVersionField;
			}
			set
			{
				creatorVersionField = value;
			}
		}

		[XmlAttribute]
		public DateTime CreatedOn
		{
			get
			{
				return createdOnField;
			}
			set
			{
				createdOnField = value;
			}
		}

		public ExportType()
		{
			versionField = "1.4";
		}
	}
}
