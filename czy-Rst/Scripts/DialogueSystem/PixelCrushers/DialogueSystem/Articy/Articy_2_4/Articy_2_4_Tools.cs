using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	public static class Articy_2_4_Tools
	{
		private static ConverterPrefs.ConvertDropdownsModes _convertDropdownAs;

		private static ConverterPrefs.ConvertSlotsModes _convertSlotsAs;

		private static ExportType _currentExport;

		private static ConverterPrefs _prefs;

		private static int documentDepth;

		public static bool IsSchema(string xmlFilename)
		{
			return ArticyTools.DataContainsSchemaId(xmlFilename, "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd");
		}

		public static ArticyData LoadArticyDataFromXmlData(string xmlData, Encoding encoding, ConverterPrefs.ConvertDropdownsModes convertDropdownAs = ConverterPrefs.ConvertDropdownsModes.Int, ConverterPrefs prefs = null)
		{
			return ConvertExportToArticyData(LoadFromXmlData(xmlData, encoding), convertDropdownAs, prefs);
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

		public static ArticyData ConvertExportToArticyData(ExportType export, ConverterPrefs.ConvertDropdownsModes convertDropdownAs = ConverterPrefs.ConvertDropdownsModes.Int, ConverterPrefs prefs = null)
		{
			if (!IsExportValid(export))
			{
				return null;
			}
			_convertDropdownAs = convertDropdownAs;
			_convertSlotsAs = prefs?.ConvertSlotsAs ?? ConverterPrefs.ConvertSlotsModes.DisplayName;
			_currentExport = export;
			_prefs = prefs;
			documentDepth = 0;
			ArticyData articyData = new ArticyData();
			articyData.project.createdOn = export.CreatedOn.ToString();
			articyData.project.creatorTool = export.CreatorTool;
			articyData.project.creatorVersion = export.CreatorVersion;
			object[] items = export.Content.Items;
			foreach (object obj in items)
			{
				ConvertProject(articyData, obj as ProjectType);
				ConvertAsset(articyData, obj as AssetType);
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

		private static void ConvertAsset(ArticyData articyData, AssetType asset)
		{
			if (asset != null)
			{
				articyData.assets.Add(asset.Id, new ArticyData.Asset(asset.Id, asset.TechnicalName, ConvertLocalizableText(asset.DisplayName), ConvertLocalizableText(asset.Text), ConvertFeatures(asset.Features), Vector2.zero, asset.AssetFilename));
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

		private static void ConvertDocument(ArticyData articyData, DocumentType document)
		{
			if (document != null)
			{
				articyData.dialogues.Add(document.Id, new ArticyData.Dialogue(document.Id, document.TechnicalName, ConvertLocalizableText(document.DisplayName), ConvertLocalizableText(document.Text), new ArticyData.Features(new List<ArticyData.Feature>()), Vector2.zero, new List<ArticyData.Pin>(), new List<string>(), isDocument: true));
			}
		}

		private static void ConvertDialogue(ArticyData articyData, DialogueType dialogue)
		{
			if (dialogue != null)
			{
				articyData.dialogues.Add(dialogue.Id, new ArticyData.Dialogue(dialogue.Id, dialogue.TechnicalName, ConvertLocalizableText(dialogue.DisplayName), ConvertLocalizableText(dialogue.Text), ConvertFeatures(dialogue.Features), new Vector2(dialogue.Position.X, dialogue.Position.Y), ConvertPins(dialogue.Pins), ConvertReferences(dialogue.References)));
			}
		}

		private static void ConvertDialogueFragment(ArticyData articyData, DialogueFragmentType dialogueFragment)
		{
			if (dialogueFragment != null)
			{
				articyData.dialogueFragments.Add(dialogueFragment.Id, new ArticyData.DialogueFragment(dialogueFragment.Id, dialogueFragment.TechnicalName, ConvertLocalizableText(dialogueFragment.DisplayName), ConvertLocalizableText(dialogueFragment.Text), ConvertFeatures(dialogueFragment.Features), new Vector2(dialogueFragment.Position.X, dialogueFragment.Position.Y), ConvertLocalizableText(dialogueFragment.MenuText), ConvertLocalizableText(dialogueFragment.StageDirections), ConvertIdRef(dialogueFragment.Speaker), ConvertPins(dialogueFragment.Pins)));
			}
		}

		private static void ConvertHub(ArticyData articyData, HubType hub)
		{
			if (hub != null)
			{
				articyData.hubs.Add(hub.Id, new ArticyData.Hub(hub.Id, hub.TechnicalName, ConvertLocalizableText(hub.DisplayName), ConvertLocalizableText(hub.Text), ConvertFeatures(hub.Features), new Vector2(hub.Position.X, hub.Position.Y), ConvertPins(hub.Pins)));
			}
		}

		private static void ConvertJump(ArticyData articyData, JumpType jump)
		{
			if (jump != null)
			{
				articyData.jumps.Add(jump.Id, new ArticyData.Jump(jump.Id, jump.TechnicalName, ConvertLocalizableText(jump.DisplayName), ConvertLocalizableText(jump.Text), ConvertFeatures(jump.Features), new Vector2(jump.Position.X, jump.Position.Y), ConvertConnectionRef(jump.Target), ConvertPins(jump.Pins)));
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
				articyData.conditions.Add(condition.Id, new ArticyData.Condition(condition.Id, condition.Expression, ConvertPins(condition.Pins), new Vector2(condition.Position.X, condition.Position.Y)));
			}
		}

		private static void ConvertInstruction(ArticyData articyData, InstructionType instruction)
		{
			if (instruction != null)
			{
				articyData.instructions.Add(instruction.Id, new ArticyData.Instruction(instruction.Id, instruction.Expression, ConvertPins(instruction.Pins), new Vector2(instruction.Position.X, instruction.Position.Y)));
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
					list.Add(new ArticyData.Variable(variableType.TechnicalName, variableType.DefaultValue, ConvertDataType(variableType.DataType), GetDefaultLocalizedString(variableType.Description)));
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
			case VariableDataTypeType.String:
				return ArticyData.VariableDataType.String;
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
				foreach (FeatureType featureType in feature)
				{
					ArticyData.Feature feature2 = new ArticyData.Feature();
					feature2.name = featureType.Name;
					PropertiesType[] properties = featureType.Properties;
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
					fields.Add(new Field(enumPropertyType.Name, ArticyTools.EnumValueToQuestState(Tools.StringToInt(enumPropertyType.Value), GetEnumStringValue(enumPropertyType.Name, Tools.StringToInt(enumPropertyType.Value), getTechnicalName: true)), FieldType.Text));
					return;
				}
				ConverterPrefs.ConvertDropdownsModes convertDropdownsModes = _convertDropdownAs;
				if (_prefs != null)
				{
					switch (_prefs.ConversionSettings.GetDropdownOverrideSetting(enumPropertyType.Name).mode)
					{
					case ConversionSettings.DropdownOverrideMode.Int:
						convertDropdownsModes = ConverterPrefs.ConvertDropdownsModes.Int;
						break;
					case ConversionSettings.DropdownOverrideMode.TechnicalName:
						convertDropdownsModes = ConverterPrefs.ConvertDropdownsModes.TechnicalName;
						break;
					case ConversionSettings.DropdownOverrideMode.DisplayName:
						convertDropdownsModes = ConverterPrefs.ConvertDropdownsModes.DisplayName;
						break;
					}
				}
				switch (convertDropdownsModes)
				{
				case ConverterPrefs.ConvertDropdownsModes.Int:
					fields.Add(new Field(enumPropertyType.Name, enumPropertyType.Value, FieldType.Number));
					break;
				case ConverterPrefs.ConvertDropdownsModes.TechnicalName:
					fields.Add(new Field(enumPropertyType.Name, GetEnumStringValue(enumPropertyType.Name, Tools.StringToInt(enumPropertyType.Value), getTechnicalName: true), FieldType.Text));
					break;
				case ConverterPrefs.ConvertDropdownsModes.DisplayName:
					fields.Add(new Field(enumPropertyType.Name, GetEnumStringValue(enumPropertyType.Name, Tools.StringToInt(enumPropertyType.Value), getTechnicalName: false), FieldType.Text));
					break;
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
				switch (_convertSlotsAs)
				{
				case ConverterPrefs.ConvertSlotsModes.ID:
					fields.Add(new Field(referenceSlotPropertyType.Name, referenceSlotPropertyType.IdRef, FieldType.Text));
					break;
				case ConverterPrefs.ConvertSlotsModes.TechnicalName:
					fields.Add(new Field(referenceSlotPropertyType.Name, GetTechnicalName(referenceSlotPropertyType.IdRef), FieldType.Text));
					break;
				default:
					fields.Add(new Field(referenceSlotPropertyType.Name, GetDisplayName(referenceSlotPropertyType.IdRef), FieldType.Text));
					break;
				}
			}
			else if (type == typeof(NumberPropertyType))
			{
				NumberPropertyType numberPropertyType = (NumberPropertyType)item;
				fields.Add(new Field(numberPropertyType.Name, numberPropertyType.Value, FieldType.Number));
			}
			else if (type == typeof(ReferenceStripPropertyType))
			{
				ReferenceStripPropertyType referenceStripPropertyType = (ReferenceStripPropertyType)item;
				fields.Add(new Field("SUBTABLE__" + referenceStripPropertyType.Name, GetStripStringValue(referenceStripPropertyType), FieldType.Text));
			}
			else if (type == typeof(StringPropertyType))
			{
				StringPropertyType stringPropertyType = (StringPropertyType)item;
				fields.Add(new Field(stringPropertyType.Name, stringPropertyType.Value, FieldType.Text));
			}
		}

		private static string GetStripStringValue(ReferenceStripPropertyType stripPropertyType)
		{
			string text = string.Empty;
			if (stripPropertyType != null && stripPropertyType.Reference != null)
			{
				ReferenceType[] reference = stripPropertyType.Reference;
				foreach (ReferenceType referenceType in reference)
				{
					if (!string.IsNullOrEmpty(text))
					{
						text += ";";
					}
					text += referenceType.IdRef;
				}
			}
			return text;
		}

		private static string GetEnumStringValue(string enumName, int enumIndex, bool getTechnicalName)
		{
			int num = enumIndex;
			object[] items = _currentExport.Content.Items;
			foreach (object obj in items)
			{
				if (!(obj is EnumerationPropertyDefinitionType))
				{
					continue;
				}
				EnumerationPropertyDefinitionType enumerationPropertyDefinitionType = obj as EnumerationPropertyDefinitionType;
				if (!string.Equals(enumerationPropertyDefinitionType.TechnicalName, enumName) || enumerationPropertyDefinitionType.Values == null || enumerationPropertyDefinitionType.Values.EnumValue == null)
				{
					continue;
				}
				EnumValueType[] enumValue = enumerationPropertyDefinitionType.Values.EnumValue;
				foreach (EnumValueType enumValueType in enumValue)
				{
					if (enumValueType.Value == num)
					{
						if (!getTechnicalName)
						{
							return GetDefaultLocalizedString(enumValueType.DisplayName);
						}
						return enumValueType.TechnicalName;
					}
				}
			}
			return enumIndex.ToString();
		}

		private static string GetTechnicalName(string idRef)
		{
			object[] items = _currentExport.Content.Items;
			foreach (object obj in items)
			{
				if (obj is EntityType && string.Equals((obj as EntityType).Id, idRef))
				{
					return (obj as EntityType).TechnicalName;
				}
				if (obj is FlowFragmentType && string.Equals((obj as FlowFragmentType).Id, idRef))
				{
					return (obj as FlowFragmentType).TechnicalName;
				}
				if (obj is DialogueFragmentType && string.Equals((obj as DialogueFragmentType).Id, idRef))
				{
					return (obj as DialogueFragmentType).TechnicalName;
				}
				if (obj is HubType && string.Equals((obj as HubType).Id, idRef))
				{
					return (obj as HubType).TechnicalName;
				}
				if (obj is JumpType && string.Equals((obj as JumpType).Id, idRef))
				{
					return (obj as JumpType).DisplayName;
				}
				if (obj is ZoneType && string.Equals((obj as ZoneType).Id, idRef))
				{
					return (obj as ZoneType).TechnicalName;
				}
				if (obj is LocationType && string.Equals((obj as LocationType).Id, idRef))
				{
					return (obj as LocationType).TechnicalName;
				}
				if (obj is SpotType && string.Equals((obj as SpotType).Id, idRef))
				{
					return (obj as SpotType).TechnicalName;
				}
				if (obj is JourneyType && string.Equals((obj as JourneyType).Id, idRef))
				{
					return (obj as JourneyType).TechnicalName;
				}
				if (obj is AssetType && string.Equals((obj as AssetType).Id, idRef))
				{
					return (obj as AssetType).TechnicalName;
				}
				if (obj is DialogueType && string.Equals((obj as DialogueType).Id, idRef))
				{
					return (obj as DialogueType).TechnicalName;
				}
			}
			if (!string.Equals("0x0000000000000000", idRef))
			{
				return idRef;
			}
			return string.Empty;
		}

		private static string GetDisplayName(string idRef)
		{
			object[] items = _currentExport.Content.Items;
			foreach (object obj in items)
			{
				if (obj is EntityType && string.Equals((obj as EntityType).Id, idRef))
				{
					return GetDefaultLocalizedString((obj as EntityType).DisplayName);
				}
				if (obj is FlowFragmentType && string.Equals((obj as FlowFragmentType).Id, idRef))
				{
					return GetDefaultLocalizedString((obj as FlowFragmentType).DisplayName);
				}
				if (obj is DialogueFragmentType && string.Equals((obj as DialogueFragmentType).Id, idRef))
				{
					return (obj as DialogueFragmentType).DisplayName;
				}
				if (obj is HubType && string.Equals((obj as HubType).Id, idRef))
				{
					return GetDefaultLocalizedString((obj as HubType).DisplayName);
				}
				if (obj is JumpType && string.Equals((obj as JumpType).Id, idRef))
				{
					return (obj as JumpType).DisplayName;
				}
				if (obj is ZoneType && string.Equals((obj as ZoneType).Id, idRef))
				{
					return GetDefaultLocalizedString((obj as ZoneType).DisplayName);
				}
				if (obj is LocationType && string.Equals((obj as LocationType).Id, idRef))
				{
					return GetDefaultLocalizedString((obj as LocationType).DisplayName);
				}
				if (obj is SpotType && string.Equals((obj as SpotType).Id, idRef))
				{
					return GetDefaultLocalizedString((obj as SpotType).DisplayName);
				}
				if (obj is JourneyType && string.Equals((obj as JourneyType).Id, idRef))
				{
					return GetDefaultLocalizedString((obj as JourneyType).DisplayName);
				}
				if (obj is AssetType && string.Equals((obj as AssetType).Id, idRef))
				{
					return GetDefaultLocalizedString((obj as AssetType).DisplayName);
				}
				if (obj is DialogueType && string.Equals((obj as DialogueType).Id, idRef))
				{
					return GetNameWithHierarchyPath(obj as DialogueType);
				}
			}
			if (!string.Equals("0x0000000000000000", idRef))
			{
				return idRef;
			}
			return string.Empty;
		}

		private static string GetNameWithHierarchyPath(DialogueType item)
		{
			string nameWithHierarchyPathRecursion = GetNameWithHierarchyPathRecursion(item, _currentExport.Hierarchy.Node, 0);
			if (string.IsNullOrEmpty(nameWithHierarchyPathRecursion))
			{
				return GetDefaultLocalizedString(item.DisplayName);
			}
			return nameWithHierarchyPathRecursion;
		}

		private static string GetNameWithHierarchyPathRecursion(DialogueType item, NodeType node, int safeguard)
		{
			if (safeguard > 999 || node == null)
			{
				return null;
			}
			if (node.IdRef == item.Id)
			{
				return GetDefaultLocalizedString(item.DisplayName);
			}
			if (node.Node != null)
			{
				NodeType[] node2 = node.Node;
				foreach (NodeType node3 in node2)
				{
					string nameWithHierarchyPathRecursion = GetNameWithHierarchyPathRecursion(item, node3, safeguard + 1);
					if (!string.IsNullOrEmpty(nameWithHierarchyPathRecursion))
					{
						string displayName = GetDisplayName(node.IdRef);
						if (!displayName.StartsWith("0x"))
						{
							return displayName + "/" + nameWithHierarchyPathRecursion;
						}
						return nameWithHierarchyPathRecursion;
					}
				}
			}
			return null;
		}

		private static string GetDefaultLocalizedString(LocalizableTextType localizableText)
		{
			if (localizableText == null || localizableText.LocalizedString == null || localizableText.LocalizedString.Length < 1)
			{
				return string.Empty;
			}
			return localizableText.LocalizedString[0].Value;
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
			articyData.hierarchy.node = ConvertNode(articyData, hierarchy.Node);
		}

		private static ArticyData.Node ConvertNode(ArticyData articyData, NodeType node)
		{
			ArticyData.Node node2 = new ArticyData.Node();
			if (node != null)
			{
				node2.id = node.IdRef;
				node2.type = ConvertNodeType(node.Type);
				if (node2.type == ArticyData.NodeType.Dialogue && documentDepth > 0)
				{
					ArticyData.Dialogue dialogue = (articyData.dialogues.ContainsKey(node.IdRef) ? articyData.dialogues[node.IdRef] : null);
					if (dialogue != null)
					{
						dialogue.isDocument = true;
					}
				}
				if (node.Node != null)
				{
					if (node.Type == "Document")
					{
						documentDepth++;
					}
					NodeType[] node3 = node.Node;
					foreach (NodeType node4 in node3)
					{
						node2.nodes.Add(ConvertNode(articyData, node4));
					}
					if (node.Type == "Document")
					{
						documentDepth--;
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
			if (string.Equals(nodeType, "Dialogue") || string.Equals(nodeType, "Document"))
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
