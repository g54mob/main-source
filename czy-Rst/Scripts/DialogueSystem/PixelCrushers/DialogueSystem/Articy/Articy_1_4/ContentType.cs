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
	public class ContentType
	{
		private object[] itemsField;

		private ItemsChoiceType[] itemsElementNameField;

		[XmlElement("Asset", typeof(AssetType))]
		[XmlElement("Assets", typeof(SystemFolderType))]
		[XmlElement("AssetsUserFolder", typeof(UserFolderType))]
		[XmlElement("BooleanPropertyDefinition", typeof(BooleanPropertyDefinitionType))]
		[XmlElement("Comment", typeof(CommentType))]
		[XmlElement("Connection", typeof(ConnectionType))]
		[XmlElement("Dialog", typeof(DialogType))]
		[XmlElement("DialogFragment", typeof(DialogFragmentType))]
		[XmlElement("Entities", typeof(SystemFolderType))]
		[XmlElement("EntitiesUserFolder", typeof(UserFolderType))]
		[XmlElement("Entity", typeof(EntityType))]
		[XmlElement("EnumerationPropertyDefinition", typeof(EnumerationPropertyDefinitionType))]
		[XmlElement("FeatureDefinition", typeof(FeatureDefinitionType))]
		[XmlElement("Features", typeof(SystemFolderType))]
		[XmlElement("FeaturesUserFolder", typeof(UserFolderType))]
		[XmlElement("FlowFragment", typeof(FlowFragmentType))]
		[XmlElement("Hub", typeof(HubType))]
		[XmlElement("Journey", typeof(JourneyType))]
		[XmlElement("Journeys", typeof(SystemFolderType))]
		[XmlElement("JourneysUserFolder", typeof(UserFolderType))]
		[XmlElement("Jump", typeof(JumpType))]
		[XmlElement("Link", typeof(LinkType))]
		[XmlElement("Location", typeof(LocationType))]
		[XmlElement("Locations", typeof(SystemFolderType))]
		[XmlElement("LocationsUserFolder", typeof(UserFolderType))]
		[XmlElement("Note", typeof(NoteType))]
		[XmlElement("Notes", typeof(SystemFolderType))]
		[XmlElement("NotesUserFolder", typeof(UserFolderType))]
		[XmlElement("NumberPropertyDefinition", typeof(NumberPropertyDefinitionType))]
		[XmlElement("ObjectCustomization", typeof(SystemFolderType))]
		[XmlElement("ObjectTemplateDefinition", typeof(ObjectTemplateDefinitionType))]
		[XmlElement("ObjectTemplates", typeof(SystemFolderType))]
		[XmlElement("Path", typeof(PathType))]
		[XmlElement("Project", typeof(ProjectType))]
		[XmlElement("PropertyTemplates", typeof(SystemFolderType))]
		[XmlElement("ReferenceSlotPropertyDefinition", typeof(ReferenceSlotPropertyDefinitionType))]
		[XmlElement("ReferenceStripPropertyDefinition", typeof(ReferenceStripPropertyDefinitionType))]
		[XmlElement("Spot", typeof(SpotType))]
		[XmlElement("Stories", typeof(SystemFolderType))]
		[XmlElement("TextPropertyDefinition", typeof(TextPropertyDefinitionType))]
		[XmlElement("TypedObjectTemplates", typeof(SystemFolderType))]
		[XmlElement("TypedObjectTemplatesUserFolder", typeof(UserFolderType))]
		[XmlElement("TypedPropertyTemplates", typeof(SystemFolderType))]
		[XmlElement("TypedPropertyTemplatesUserFolder", typeof(UserFolderType))]
		[XmlElement("Zone", typeof(ZoneType))]
		[XmlChoiceIdentifier("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
			}
		}

		[XmlElement("ItemsElementName")]
		[XmlIgnore]
		public ItemsChoiceType[] ItemsElementName
		{
			get
			{
				return itemsElementNameField;
			}
			set
			{
				itemsElementNameField = value;
			}
		}
	}
}
