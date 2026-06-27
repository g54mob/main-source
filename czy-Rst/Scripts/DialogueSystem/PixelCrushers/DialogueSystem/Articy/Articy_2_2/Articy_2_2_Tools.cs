using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	public static class Articy_2_2_Tools
	{
		public static bool IsSchema(string xmlFilename)
		{
			return ArticyTools.DataContainsSchemaId(xmlFilename, "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd");
		}

		public static ArticyData LoadArticyDataFromXmlData(string xmlData, Encoding encoding)
		{
			return ConvertExportToArticyData(LoadFromXmlData(xmlData, encoding));
		}

		public static ExportType LoadFromXmlData(string xmlData, Encoding encoding)
		{
			return new XmlSerializer(typeof(ExportType)).Deserialize(new StringReader(xmlData)) as ExportType;
		}

		public static bool IsExportValid(ExportType export)
		{
			if (export != null && export.Content != null)
			{
				return export.Content.Items != null;
			}
			return false;
		}

		public static ArticyData ConvertExportToArticyData(ExportType export)
		{
			if (!IsExportValid(export))
			{
				return null;
			}
			ArticyData articyData = new ArticyData();
			articyData.project.createdOn = export.CreatedOn.ToString();
			articyData.project.creatorTool = export.CreatorTool;
			articyData.project.creatorVersion = export.CreatorVersion;
			object[] items = export.Content.Items;
			foreach (object obj in items)
			{
				ConvertProject(articyData, obj as ProjectType);
				ConvertEntity(articyData, obj as EntityType, export);
				ConvertLocation(articyData, obj as LocationType);
				ConvertFlowFragment(articyData, obj as FlowFragmentType);
				ConvertDialogue(articyData, obj as DialogueType);
				ConvertDialogueFragment(articyData, obj as DialogueFragmentType);
				ConvertHub(articyData, obj as HubType);
				ConvertJump(articyData, obj as JumpType);
				ConvertConnection(articyData, obj as ConnectionType);
				ConvertCondition(articyData, obj as ConditionType);
				ConvertInstruction(articyData, obj as InstructionType);
				ConvertVariableSet(articyData, obj as VariableSetType);
			}
			ConvertHierarchy(articyData, export.Hierarchy);
			return articyData;
		}

		private static void ConvertProject(ArticyData articyData, ProjectType project)
		{
			if (project != null)
			{
				articyData.project.displayName = project.DisplayName;
			}
		}

		private static void ConvertEntity(ArticyData articyData, EntityType entity, ExportType export)
		{
			if (entity != null)
			{
				articyData.entities.Add(entity.Id, new ArticyData.Entity(entity.Id, entity.TechnicalName, ConvertLocalizableText(entity.DisplayName), ConvertLocalizableText(entity.Text), ConvertFeatures(entity.Features), Vector2.zero, GetPictureFilename(export, entity.PreviewImage)));
			}
		}

		private static void ConvertLocation(ArticyData articyData, LocationType location)
		{
			if (location != null)
			{
				articyData.locations.Add(location.Id, new ArticyData.Location(location.Id, location.TechnicalName, ConvertLocalizableText(location.DisplayName), ConvertLocalizableText(location.Text), ConvertFeatures(location.Features), Vector2.zero));
			}
		}

		private static void ConvertFlowFragment(ArticyData articyData, FlowFragmentType flowFragment)
		{
			if (flowFragment != null)
			{
				articyData.flowFragments.Add(flowFragment.Id, new ArticyData.FlowFragment(flowFragment.Id, flowFragment.TechnicalName, ConvertLocalizableText(flowFragment.DisplayName), ConvertLocalizableText(flowFragment.Text), ConvertFeatures(flowFragment.Features), Vector2.zero, ConvertPins(flowFragment.Pins)));
			}
		}

		private static void ConvertDialogue(ArticyData articyData, DialogueType dialogue)
		{
			if (dialogue != null)
			{
				articyData.dialogues.Add(dialogue.Id, new ArticyData.Dialogue(dialogue.Id, dialogue.TechnicalName, ConvertLocalizableText(dialogue.DisplayName), ConvertLocalizableText(dialogue.Text), ConvertFeatures(dialogue.Features), Vector2.zero, ConvertPins(dialogue.Pins), ConvertReferences(dialogue.References)));
			}
		}

		private static void ConvertDialogueFragment(ArticyData articyData, DialogueFragmentType dialogueFragment)
		{
			if (dialogueFragment != null)
			{
				articyData.dialogueFragments.Add(dialogueFragment.Id, new ArticyData.DialogueFragment(dialogueFragment.Id, dialogueFragment.TechnicalName, ConvertLocalizableText(dialogueFragment.DisplayName), ConvertLocalizableText(dialogueFragment.Text), ConvertFeatures(dialogueFragment.Features), Vector2.zero, ConvertLocalizableText(dialogueFragment.MenuText), ConvertLocalizableText(dialogueFragment.StageDirections), ConvertIdRef(dialogueFragment.Speaker), ConvertPins(dialogueFragment.Pins)));
			}
		}

		private static void ConvertHub(ArticyData articyData, HubType hub)
		{
			if (hub != null)
			{
				articyData.hubs.Add(hub.Id, new ArticyData.Hub(hub.Id, hub.TechnicalName, ConvertLocalizableText(hub.DisplayName), ConvertLocalizableText(hub.Text), ConvertFeatures(hub.Features), Vector2.zero, ConvertPins(hub.Pins)));
			}
		}

		private static void ConvertJump(ArticyData articyData, JumpType jump)
		{
			if (jump != null)
			{
				articyData.jumps.Add(jump.Id, new ArticyData.Jump(jump.Id, jump.TechnicalName, ConvertLocalizableText(jump.DisplayName), ConvertLocalizableText(jump.Text), ConvertFeatures(jump.Features), Vector2.zero, ConvertConnectionRef(jump.Target), ConvertPins(jump.Pins)));
			}
		}

		private static void ConvertConnection(ArticyData articyData, ConnectionType connection)
		{
			if (connection != null)
			{
				articyData.connections.Add(connection.Id, new ArticyData.Connection(connection.Id, connection.Color, ConvertConnectionRef(connection.Source), ConvertConnectionRef(connection.Target)));
			}
		}

		private static ArticyData.ConnectionRef ConvertConnectionRef(ConnectionRefType connectionRef)
		{
			if (connectionRef == null)
			{
				return new ArticyData.ConnectionRef();
			}
			return new ArticyData.ConnectionRef(connectionRef.IdRef, connectionRef.PinRef);
		}

		private static void ConvertCondition(ArticyData articyData, ConditionType condition)
		{
			if (condition != null)
			{
				articyData.conditions.Add(condition.Id, new ArticyData.Condition(condition.Id, condition.Expression, ConvertPins(condition.Pins)));
			}
		}

		private static void ConvertInstruction(ArticyData articyData, InstructionType instruction)
		{
			if (instruction != null)
			{
				articyData.instructions.Add(instruction.Id, new ArticyData.Instruction(instruction.Id, instruction.Expression, ConvertPins(instruction.Pins)));
			}
		}

		private static void ConvertVariableSet(ArticyData articyData, VariableSetType variableSet)
		{
			if (variableSet != null)
			{
				articyData.variableSets.Add(variableSet.Id, new ArticyData.VariableSet(variableSet.Id, variableSet.TechnicalName, ConvertVariables(variableSet.Variables)));
			}
		}

		private static List<ArticyData.Variable> ConvertVariables(VariablesType variables)
		{
			List<ArticyData.Variable> list = new List<ArticyData.Variable>();
			if (variables != null && variables.Variable != null)
			{
				VariableType[] variable = variables.Variable;
				foreach (VariableType variableType in variable)
				{
					list.Add(new ArticyData.Variable(variableType.TechnicalName, variableType.DefaultValue, ConvertDataType(variableType.DataType)));
				}
			}
			return list;
		}

		private static ArticyData.VariableDataType ConvertDataType(VariableDataTypeType dataType)
		{
			switch (dataType)
			{
			case VariableDataTypeType.Boolean:
				return ArticyData.VariableDataType.Boolean;
			case VariableDataTypeType.Integer:
				return ArticyData.VariableDataType.Integer;
			default:
				Debug.LogWarning(string.Format("{0}: Unexpected variable data type {1}", "Dialogue System", dataType.ToString()));
				return ArticyData.VariableDataType.Boolean;
			}
		}

		private static ArticyData.LocalizableText ConvertLocalizableText(LocalizableTextType localizableText)
		{
			ArticyData.LocalizableText localizableText2 = new ArticyData.LocalizableText();
			if (localizableText != null && localizableText.LocalizedString != null)
			{
				LocalizedStringType[] localizedString = localizableText.LocalizedString;
				foreach (LocalizedStringType localizedStringType in localizedString)
				{
					localizableText2.localizedString.Add(localizedStringType.Lang, ArticyTools.RemoveHtml(localizedStringType.Value));
				}
			}
			return localizableText2;
		}

		private static ArticyData.LocalizableText ConvertLocalizableText(string s)
		{
			return new ArticyData.LocalizableText
			{
				localizedString = { 
				{
					string.Empty,
					ArticyTools.RemoveHtml(s)
				} }
			};
		}

		private static List<string> ConvertReferences(ReferencesType references)
		{
			List<string> list = new List<string>();
			if (references != null && references.Reference != null)
			{
				ReferenceType[] reference = references.Reference;
				foreach (ReferenceType reference2 in reference)
				{
					list.Add(ConvertIdRef(reference2));
				}
			}
			return list;
		}

		private static string ConvertIdRef(ReferenceType reference)
		{
			if (reference == null)
			{
				return string.Empty;
			}
			return reference.IdRef;
		}

		private static List<ArticyData.Pin> ConvertPins(PinsType pins)
		{
			List<ArticyData.Pin> list = new List<ArticyData.Pin>();
			if (pins != null && pins.Pin != null)
			{
				PinType[] pin = pins.Pin;
				foreach (PinType pinType in pin)
				{
					list.Add(new ArticyData.Pin(pinType.Id, pinType.Index, ConvertSemanticType(pinType.Semantic), pinType.Expression));
				}
			}
			return list;
		}

		private static ArticyData.SemanticType ConvertSemanticType(SemanticType semanticType)
		{
			switch (semanticType)
			{
			case SemanticType.Input:
				return ArticyData.SemanticType.Input;
			case SemanticType.Output:
				return ArticyData.SemanticType.Output;
			default:
				Debug.LogWarning(string.Format("{0}: Unexpected semantic type {1}", "Dialogue System", semanticType.ToString()));
				return ArticyData.SemanticType.Input;
			}
		}

		private static ArticyData.Features ConvertFeatures(FeaturesType features)
		{
			List<ArticyData.Feature> list = new List<ArticyData.Feature>();
			if (features != null && features.Feature != null)
			{
				FeatureType[] feature = features.Feature;
				foreach (FeatureType obj in feature)
				{
					ArticyData.Feature feature2 = new ArticyData.Feature();
					PropertiesType[] properties = obj.Properties;
					foreach (PropertiesType propertiesType in properties)
					{
						if (propertiesType != null && propertiesType.Items != null && propertiesType.Items.Length != 0)
						{
							List<Field> fields = new List<Field>();
							object[] items = propertiesType.Items;
							for (int k = 0; k < items.Length; k++)
							{
								ConvertItem(items[k], fields);
							}
							feature2.properties.Add(new ArticyData.Property(fields));
						}
					}
					list.Add(feature2);
				}
			}
			return new ArticyData.Features(list);
		}

		private static void ConvertItem(object item, List<Field> fields)
		{
			Type type = item.GetType();
			if (type == typeof(BooleanPropertyType))
			{
				BooleanPropertyType booleanPropertyType = (BooleanPropertyType)item;
				fields.Add(new Field(booleanPropertyType.Name, string.Equals(booleanPropertyType.Value, "1").ToString(), FieldType.Boolean));
			}
			else if (type == typeof(EnumPropertyType))
			{
				EnumPropertyType enumPropertyType = (EnumPropertyType)item;
				if (ArticyTools.IsQuestStateArticyPropertyName(enumPropertyType.Name))
				{
					fields.Add(new Field(enumPropertyType.Name, ArticyTools.EnumValueToQuestState(Tools.StringToInt(enumPropertyType.Value), string.Empty), FieldType.Text));
				}
				else
				{
					fields.Add(new Field(enumPropertyType.Name, enumPropertyType.Value, FieldType.Number));
				}
			}
			else if (type == typeof(LocalizableTextPropertyType))
			{
				LocalizableTextPropertyType localizableTextPropertyType = (LocalizableTextPropertyType)item;
				string name = localizableTextPropertyType.Name;
				if (string.IsNullOrEmpty(name) || localizableTextPropertyType.LocalizedString == null)
				{
					return;
				}
				LocalizedStringType[] localizedString = localizableTextPropertyType.LocalizedString;
				foreach (LocalizedStringType localizedStringType in localizedString)
				{
					if (string.IsNullOrEmpty(localizedStringType.Lang))
					{
						fields.Add(new Field(name, localizedStringType.Value, FieldType.Text));
						continue;
					}
					string title = $"{name} {localizedStringType.Lang}";
					fields.Add(new Field(title, localizedStringType.Value, FieldType.Localization));
				}
			}
			else if (type == typeof(ReferenceSlotPropertyType))
			{
				ReferenceSlotPropertyType referenceSlotPropertyType = (ReferenceSlotPropertyType)item;
				fields.Add(new Field(referenceSlotPropertyType.Name, referenceSlotPropertyType.IdRef, FieldType.Text));
			}
			else if (type == typeof(NumberPropertyType))
			{
				NumberPropertyType numberPropertyType = (NumberPropertyType)item;
				fields.Add(new Field(numberPropertyType.Name, numberPropertyType.Value, FieldType.Number));
			}
			else if (type == typeof(ReferenceStripPropertyType))
			{
				Debug.LogWarning("Dialogue System: Skipping import of ReferenceStripPropertyType: " + (item as ReferenceStripPropertyType).Name);
			}
			else if (type == typeof(StringPropertyType))
			{
				StringPropertyType stringPropertyType = (StringPropertyType)item;
				fields.Add(new Field(stringPropertyType.Name, stringPropertyType.Value, FieldType.Text));
			}
		}

		private static string GetPictureFilename(ExportType export, PreviewImageType previewImage)
		{
			if (previewImage != null)
			{
				object[] items = export.Content.Items;
				foreach (object obj in items)
				{
					if (obj is AssetType)
					{
						AssetType assetType = obj as AssetType;
						if (string.Equals(assetType.Id, previewImage.IdRef))
						{
							return assetType.OriginalSource;
						}
					}
				}
			}
			return null;
		}

		private static void ConvertHierarchy(ArticyData articyData, HierarchyType hierarchy)
		{
			articyData.hierarchy.node = ConvertNode(hierarchy.Node);
		}

		private static ArticyData.Node ConvertNode(NodeType node)
		{
			ArticyData.Node node2 = new ArticyData.Node();
			if (node != null)
			{
				node2.id = node.Id;
				node2.type = ConvertNodeType(node.Type);
				if (node.Node != null)
				{
					NodeType[] node3 = node.Node;
					foreach (NodeType node4 in node3)
					{
						node2.nodes.Add(ConvertNode(node4));
					}
				}
			}
			return node2;
		}

		private static ArticyData.NodeType ConvertNodeType(string nodeType)
		{
			if (string.Equals(nodeType, "FlowFragment"))
			{
				return ArticyData.NodeType.FlowFragment;
			}
			if (string.Equals(nodeType, "Dialogue"))
			{
				return ArticyData.NodeType.Dialogue;
			}
			if (string.Equals(nodeType, "DialogueFragment"))
			{
				return ArticyData.NodeType.DialogueFragment;
			}
			if (string.Equals(nodeType, "Hub"))
			{
				return ArticyData.NodeType.Hub;
			}
			if (string.Equals(nodeType, "Jump"))
			{
				return ArticyData.NodeType.Jump;
			}
			if (string.Equals(nodeType, "Connection"))
			{
				return ArticyData.NodeType.Connection;
			}
			if (string.Equals(nodeType, "Condition"))
			{
				return ArticyData.NodeType.Condition;
			}
			if (string.Equals(nodeType, "Instruction"))
			{
				return ArticyData.NodeType.Instruction;
			}
			return ArticyData.NodeType.Other;
		}
	}
}
