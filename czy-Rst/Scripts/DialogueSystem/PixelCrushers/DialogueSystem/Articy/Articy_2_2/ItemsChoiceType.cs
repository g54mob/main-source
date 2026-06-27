using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd", IncludeInSchema = false)]
	public enum ItemsChoiceType
	{
		Asset = 0,
		Assets = 1,
		AssetsUserFolder = 2,
		BooleanPropertyDefinition = 3,
		Comment = 4,
		Condition = 5,
		Connection = 6,
		Dialogue = 7,
		DialogueFragment = 8,
		Document = 9,
		Documents = 10,
		DocumentsUserFolder = 11,
		Entities = 12,
		EntitiesUserFolder = 13,
		Entity = 14,
		EnumerationPropertyDefinition = 15,
		FeatureDefinition = 16,
		Features = 17,
		FeaturesUserFolder = 18,
		Flow = 19,
		FlowFragment = 20,
		GlobalVariables = 21,
		Hub = 22,
		Instruction = 23,
		Journey = 24,
		Journeys = 25,
		JourneysUserFolder = 26,
		Jump = 27,
		Link = 28,
		Location = 29,
		LocationGroup = 30,
		Locations = 31,
		LocationsUserFolder = 32,
		NumberPropertyDefinition = 33,
		ObjectCustomization = 34,
		ObjectTemplateDefinition = 35,
		ObjectTemplates = 36,
		ObjectTemplatesUserFolder = 37,
		Path = 38,
		Project = 39,
		PropertyTemplates = 40,
		QueryReferenceStripPropertyDefinition = 41,
		ReferenceSlotPropertyDefinition = 42,
		ReferenceStripPropertyDefinition = 43,
		ScriptPropertyDefinition = 44,
		Spot = 45,
		TextObject = 46,
		TextPropertyDefinition = 47,
		TypedObjectTemplates = 48,
		TypedPropertyTemplates = 49,
		TypedPropertyTemplatesUserFolder = 50,
		VariableSet = 51,
		Zone = 52
	}
}
