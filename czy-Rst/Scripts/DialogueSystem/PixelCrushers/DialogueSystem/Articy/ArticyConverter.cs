using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy
{
	public class ArticyConverter
	{
		public delegate void ProgressCallbackDelegate(string info, float progress);

		public const string ArticyIdFieldTitle = "Articy Id";

		public const string ArticyTechnicalNameFieldTitle = "Technical Name";

		protected const string DestinationArticyIdFieldTitle = "destinationArticyId";

		protected const int StartEntryID = 0;

		protected ArticyData articyData;

		protected ConverterPrefs prefs;

		protected DialogueDatabase database;

		protected Template template;

		protected int conversationID;

		protected int actorID;

		protected int itemID;

		protected int locationID;

		protected static List<string> fullVariableNames;

		protected HashSet<string> otherScriptFieldTitles = new HashSet<string>();

		protected List<Conversation> documentConversations = new List<Conversation>();

		protected List<string> flowFragmentNameStack = new List<string>();

		protected List<Conversation> conversationStack = new List<Conversation>();

		protected Dictionary<Conversation, int> conversationLastEntryID = new Dictionary<Conversation, int>();

		protected Dictionary<string, List<DialogueEntry>> entriesByArticyId = new Dictionary<string, List<DialogueEntry>>();

		protected Dictionary<string, DialogueEntry> entriesByPinID = new Dictionary<string, DialogueEntry>();

		protected Dictionary<ArticyData.Jump, DialogueEntry> jumpsToProcess = new Dictionary<ArticyData.Jump, DialogueEntry>();

		protected List<DialogueEntry> unusedOutputEntries = new List<DialogueEntry>();

		protected static List<string> SpecialFieldTitles;

		protected static List<string> SpecialFieldTitleStarters;

		protected const int MaxRecursionDepth = 1000;

		public static event ProgressCallbackDelegate onProgressCallback;

		public static DialogueDatabase ConvertXmlDataToDatabase(string xmlData, ConverterPrefs prefs = null, Template template = null)
		{
			if (prefs == null)
			{
				prefs = new ConverterPrefs();
			}
			if (template == null)
			{
				template = new Template();
			}
			DialogueDatabase result = DatabaseUtility.CreateDialogueDatabaseInstance();
			ArticyData articyData = ArticySchemaTools.LoadArticyDataFromXmlData(xmlData, prefs);
			if (articyData == null)
			{
				if (DialogueDebug.logWarnings)
				{
					Debug.LogWarning("Dialogue System: Can't convert articy:draft project; unable to import articy:draft data.");
				}
				return null;
			}
			ConvertArticyDataToDatabase(articyData, prefs, template, result);
			return result;
		}

		public static void ConvertArticyDataToDatabase(ArticyData articyData, ConverterPrefs prefs, Template template, DialogueDatabase database)
		{
			new ArticyConverter().Convert(articyData, prefs, template, database);
		}

		protected virtual void ResetStacks()
		{
			flowFragmentNameStack.Clear();
			conversationStack.Clear();
			conversationLastEntryID.Clear();
			entriesByPinID.Clear();
			jumpsToProcess.Clear();
			unusedOutputEntries.Clear();
		}

		protected virtual void PushFlowFragment(ArticyData.FlowFragment flowFragment)
		{
			if (flowFragment != null)
			{
				flowFragmentNameStack.Add(flowFragment.displayName.DefaultText);
			}
		}

		protected virtual void PopFlowFragment()
		{
			if (flowFragmentNameStack.Count >= 1)
			{
				flowFragmentNameStack.RemoveAt(flowFragmentNameStack.Count - 1);
			}
		}

		protected virtual void PushConversation(Conversation conversation)
		{
			if (conversation != null)
			{
				conversationStack.Add(conversation);
			}
		}

		protected virtual void PopConversation()
		{
			if (conversationStack.Count >= 1)
			{
				conversationStack.RemoveAt(conversationStack.Count - 1);
			}
		}

		protected virtual Conversation GetConversationStackTop()
		{
			if (conversationStack.Count <= 0)
			{
				return null;
			}
			return conversationStack[conversationStack.Count - 1];
		}

		protected virtual int GetNextConversationEntryID(Conversation conversation)
		{
			if (conversation == null)
			{
				return 0;
			}
			if (!conversationLastEntryID.ContainsKey(conversation))
			{
				conversationLastEntryID.Add(conversation, 0);
				return 0;
			}
			conversationLastEntryID[conversation]++;
			return conversationLastEntryID[conversation];
		}

		protected virtual void ResetArticyIdIndex()
		{
			entriesByArticyId.Clear();
		}

		protected virtual void IndexDialogueEntryByArticyId(DialogueEntry entry, string articyId)
		{
			if (entriesByArticyId.ContainsKey(articyId))
			{
				if (!entriesByArticyId[articyId].Contains(entry))
				{
					entriesByArticyId[articyId].Add(entry);
				}
			}
			else
			{
				entriesByArticyId.Add(articyId, new List<DialogueEntry>());
				entriesByArticyId[articyId].Add(entry);
			}
		}

		public virtual void Convert(ArticyData articyData, ConverterPrefs prefs, Template template, DialogueDatabase database)
		{
			if (articyData != null)
			{
				ArticyConverter.onProgressCallback("Converting non-dialogue elements", 0.01f);
				Setup(articyData, prefs, template, database);
				ConvertProjectAttributes();
				ConvertVariables();
				ConvertEntities();
				ConvertLocations();
				ConvertFlowFragmentsToQuests();
				ConvertDialogues();
				ResetArticyIdIndex();
				ConvertEmVarSet();
				if (!prefs.ImportDocuments)
				{
					DeleteDocumentConversations();
				}
			}
		}

		protected virtual void Setup(ArticyData articyData, ConverterPrefs prefs, Template template, DialogueDatabase database)
		{
			this.articyData = articyData;
			this.prefs = prefs;
			this.database = database;
			database.actors = new List<Actor>();
			database.items = new List<Item>();
			database.locations = new List<Location>();
			database.variables = new List<Variable>();
			database.conversations = new List<Conversation>();
			conversationID = 0;
			actorID = 0;
			itemID = 0;
			locationID = 0;
			fullVariableNames.Clear();
			otherScriptFieldTitles.Clear();
			documentConversations.Clear();
			string[] array = prefs.OtherScriptFields.Split(';');
			foreach (string text in array)
			{
				otherScriptFieldTitles.Add(text.Trim());
			}
			ResetArticyIdIndex();
			this.template = template;
		}

		protected virtual void ConvertProjectAttributes()
		{
			database.version = articyData.ProjectVersion;
			database.author = articyData.ProjectAuthor;
		}

		protected virtual void ConvertEntities()
		{
			foreach (ArticyData.Entity value in articyData.entities.Values)
			{
				ConversionSetting conversionSetting = prefs.ConversionSettings.GetConversionSetting(value.id);
				if (!conversionSetting.Include)
				{
					continue;
				}
				EntityCategory entityCategory = conversionSetting.Category;
				if (HasField(value.features, "IsNPC", mustBeTrue: false))
				{
					entityCategory = EntityCategory.NPC;
				}
				if (HasField(value.features, "IsPlayer", mustBeTrue: true))
				{
					entityCategory = EntityCategory.Player;
				}
				if (HasField(value.features, "IsItem", mustBeTrue: true))
				{
					entityCategory = EntityCategory.Item;
				}
				if (HasField(value.features, "IsQuest", mustBeTrue: true))
				{
					entityCategory = EntityCategory.Quest;
				}
				switch (entityCategory)
				{
				case EntityCategory.NPC:
				case EntityCategory.Player:
				{
					actorID++;
					bool isPlayer = conversionSetting.Category == EntityCategory.Player;
					Actor actor = template.CreateActor(actorID, value.displayName.DefaultText, isPlayer);
					Field.SetValue(actor.fields, "Articy Id", value.id, FieldType.Text);
					Field.SetValue(actor.fields, "Technical Name", value.technicalName, FieldType.Text);
					Field.SetValue(actor.fields, "Description", value.text.DefaultText, FieldType.Text);
					if (!string.IsNullOrEmpty(value.previewImage))
					{
						Field.SetValue(actor.fields, "Pictures", $"[{value.previewImage}]", FieldType.Text);
					}
					SetFeatureFields(actor.fields, value.features);
					ConvertLocalizableText(actor.fields, "Name", value.displayName);
					if (prefs.UseTechnicalNames)
					{
						Field.SetValue(actor.fields, "Name", value.technicalName, FieldType.Text);
					}
					if (prefs.UseTechnicalNames || prefs.SetDisplayName)
					{
						Field.SetValue(actor.fields, "Display Name", value.displayName.DefaultText, FieldType.Text);
					}
					if (prefs.CustomDisplayName)
					{
						UseCustomDisplayName(actor.fields);
					}
					database.actors.Add(actor);
					break;
				}
				case EntityCategory.Item:
				case EntityCategory.Quest:
				{
					itemID++;
					Item item = template.CreateItem(itemID, value.displayName.DefaultText);
					Field.SetValue(item.fields, "Articy Id", value.id, FieldType.Text);
					Field.SetValue(item.fields, "Technical Name", value.technicalName, FieldType.Text);
					Field.SetValue(item.fields, "Description", value.text.DefaultText, FieldType.Text);
					Field.SetValue(item.fields, "Is Item", (entityCategory == EntityCategory.Item) ? "True" : "False", FieldType.Boolean);
					if (prefs.UseTechnicalNames)
					{
						Field.SetValue(item.fields, "Display Name", value.displayName.DefaultText, FieldType.Text);
					}
					SetFeatureFields(item.fields, value.features);
					ConvertLocalizableText(item.fields, "Name", value.displayName);
					if (prefs.UseTechnicalNames)
					{
						Field.SetValue(item.fields, "Name", value.technicalName, FieldType.Text);
					}
					if (prefs.UseTechnicalNames || prefs.SetDisplayName)
					{
						Field.SetValue(item.fields, "Display Name", value.displayName.DefaultText, FieldType.Text);
					}
					if (prefs.CustomDisplayName)
					{
						UseCustomDisplayName(item.fields);
					}
					database.items.Add(item);
					break;
				}
				default:
					Debug.LogError("Dialogue System: Internal error converting entity type '" + conversionSetting.Category.ToString() + "' (Articy ID: " + value.id + ").");
					break;
				}
			}
			foreach (Actor actor2 in database.actors)
			{
				FindPortraitTextureInResources(actor2);
			}
		}

		protected virtual void ConvertLocations()
		{
			foreach (ArticyData.Location value in articyData.locations.Values)
			{
				if (prefs.ConversionSettings.GetConversionSetting(value.id).Include)
				{
					locationID++;
					Location location = template.CreateLocation(locationID, value.displayName.DefaultText);
					Field.SetValue(location.fields, "Articy Id", value.id, FieldType.Text);
					Field.SetValue(location.fields, "Technical Name", value.technicalName, FieldType.Text);
					Field.SetValue(location.fields, "Description", value.text.DefaultText, FieldType.Text);
					if (prefs.UseTechnicalNames)
					{
						Field.SetValue(location.fields, "Display Name", value.displayName.DefaultText, FieldType.Text);
					}
					SetFeatureFields(location.fields, value.features);
					ConvertLocalizableText(location.fields, "Name", value.displayName);
					if (prefs.UseTechnicalNames)
					{
						Field.SetValue(location.fields, "Name", value.technicalName, FieldType.Text);
						Field.SetValue(location.fields, "Display Name", value.displayName.DefaultText, FieldType.Text);
					}
					if (prefs.CustomDisplayName)
					{
						UseCustomDisplayName(location.fields);
					}
					database.locations.Add(location);
				}
			}
		}

		protected virtual void ConvertFlowFragmentsToQuests()
		{
			if (prefs.FlowFragmentMode != ConverterPrefs.FlowFragmentModes.Quests)
			{
				return;
			}
			foreach (ArticyData.FlowFragment value in articyData.flowFragments.Values)
			{
				if (prefs.ConversionSettings.GetConversionSetting(value.id).Include)
				{
					itemID++;
					Item item = template.CreateItem(itemID, value.displayName.DefaultText);
					Field.SetValue(item.fields, "Articy Id", value.id, FieldType.Text);
					Field.SetValue(item.fields, "Technical Name", value.technicalName, FieldType.Text);
					Field.SetValue(item.fields, "Description", value.text.DefaultText, FieldType.Text);
					Field.SetValue(item.fields, "Success Description", string.Empty, FieldType.Text);
					Field.SetValue(item.fields, "Failure Description", string.Empty, FieldType.Text);
					Field.SetValue(item.fields, "State", "unassigned", FieldType.Text);
					Field.SetValue(item.fields, "Is Item", "False", FieldType.Boolean);
					SetFeatureFields(item.fields, value.features);
					ConvertLocalizableText(item.fields, "Name", value.displayName);
					database.items.Add(item);
				}
			}
		}

		protected virtual void SetFeatureFields(List<Field> fields, ArticyData.Features features)
		{
			foreach (ArticyData.Feature feature in features.features)
			{
				foreach (ArticyData.Property property in feature.properties)
				{
					foreach (Field field2 in property.fields)
					{
						if (!string.IsNullOrEmpty(field2.title))
						{
							string text = ConvertSpecialTechnicalNames(field2.title);
							if (prefs.IncludeFeatureNameInFields && !IsSpecialFieldTitle(field2.title))
							{
								text = feature.name + "." + text;
							}
							string value = (IsOtherScriptField(text) ? ConvertExpression(field2.value) : field2.value);
							Field field = Field.Lookup(fields, text);
							if (field != null)
							{
								field.value = value;
							}
							else
							{
								fields.Add(new Field(text, value, field2.type));
							}
						}
					}
				}
			}
		}

		protected virtual void UseCustomDisplayName(List<Field> fields)
		{
			Field field = Field.Lookup(fields, "DisplayName");
			if (field != null)
			{
				fields.RemoveAll((Field field2) => field2.title == "Display Name");
				field.title = "Display Name";
			}
		}

		protected virtual bool IsOtherScriptField(string fieldTitle)
		{
			return otherScriptFieldTitles.Contains(fieldTitle);
		}

		protected virtual bool IsSpecialFieldTitle(string fieldTitle)
		{
			if (SpecialFieldTitles.Find((string x) => x == fieldTitle) != null)
			{
				return true;
			}
			foreach (string specialFieldTitleStarter in SpecialFieldTitleStarters)
			{
				if (fieldTitle.StartsWith(specialFieldTitleStarter))
				{
					return true;
				}
			}
			return false;
		}

		protected virtual string ConvertSpecialTechnicalNames(string technicalName)
		{
			if (string.Equals(technicalName, "Response_Menu_Sequence") || string.Equals(technicalName, "Success_Description") || string.Equals(technicalName, "Failure_Description") || string.Equals(technicalName, "Entry_Count") || Regex.Match(technicalName, "^Entry_[0-9]").Success)
			{
				return technicalName.Replace("_", " ");
			}
			return technicalName;
		}

		public static bool HasField(ArticyData.Features features, string fieldName, bool mustBeTrue)
		{
			foreach (ArticyData.Feature feature in features.features)
			{
				foreach (ArticyData.Property property in feature.properties)
				{
					foreach (Field field in property.fields)
					{
						if (string.Equals(field.title, fieldName))
						{
							return !mustBeTrue || string.Equals(field.value, "True", StringComparison.OrdinalIgnoreCase);
						}
					}
				}
			}
			return false;
		}

		protected virtual void ConvertVariables()
		{
			int num = 0;
			foreach (ArticyData.VariableSet value in articyData.variableSets.Values)
			{
				foreach (ArticyData.Variable variable2 in value.variables)
				{
					string text = ArticyData.FullVariableName(value, variable2);
					fullVariableNames.Add(text);
					if (!prefs.ConversionSettings.GetConversionSetting(text).Include)
					{
						continue;
					}
					num++;
					Variable variable = template.CreateVariable(num, text, variable2.defaultValue);
					variable.Type = ((variable2.dataType == ArticyData.VariableDataType.Boolean) ? FieldType.Boolean : ((variable2.dataType == ArticyData.VariableDataType.Integer) ? FieldType.Number : FieldType.Text));
					if (!string.IsNullOrEmpty(variable2.description))
					{
						Field field = Field.Lookup(variable.fields, "Description");
						if (field != null)
						{
							field.value = variable2.description;
						}
						else
						{
							variable.fields.Add(new Field("Description", variable2.description, FieldType.Text));
						}
					}
					database.variables.Add(variable);
				}
			}
		}

		protected virtual void DeleteDocumentConversations()
		{
			database.conversations.RemoveAll((Conversation conversation) => documentConversations.Contains(conversation));
		}

		protected virtual void ConvertDialogues()
		{
			ResetStacks();
			ArticyConverter.onProgressCallback("Converting dialogues", 0.2f);
			ConvertDialoguesToConversations();
			ArticyConverter.onProgressCallback("Processing hierarchy", 0.3f);
			ProcessHierarchy();
			InsertDelayEvaluationNodesBeforeInputPins();
			ArticyConverter.onProgressCallback("Sorting links by position", 0.7f);
			SortAllLinksByPosition();
			if (prefs.SplitTextOnPipes)
			{
				SplitPipesIntoEntries();
			}
			ArticyConverter.onProgressCallback("Converting VoiceOver properties", 0.9f);
			ConvertVoiceOverProperties();
		}

		protected virtual bool IncludeDialogue(string dialogueId)
		{
			return ((prefs == null) ? null : prefs.ConversionSettings.GetConversionSetting(dialogueId))?.Include ?? true;
		}

		protected virtual void ConvertDialoguesToConversations()
		{
			foreach (ArticyData.Dialogue value in articyData.dialogues.Values)
			{
				if (IncludeDialogue(value.id))
				{
					CreateNewConversation(value);
				}
			}
		}

		protected virtual Conversation CreateNewConversation(ArticyData.Dialogue articyDialogue)
		{
			if (articyDialogue == null)
			{
				return null;
			}
			conversationID++;
			string empty = string.Empty;
			empty += articyDialogue.displayName.DefaultText;
			if (articyDialogue.isDocument && !string.IsNullOrEmpty(prefs.DocumentsSubmenu))
			{
				empty = prefs.DocumentsSubmenu + "/" + empty;
			}
			Conversation conversation = template.CreateConversation(conversationID, empty);
			Field.SetValue(conversation.fields, "Articy Id", articyDialogue.id, FieldType.Text);
			Field.SetValue(conversation.fields, "Description", articyDialogue.text.DefaultText, FieldType.Text);
			SetConversationOverrideProperties(conversation, articyDialogue.features);
			SetFeatureFields(conversation.fields, articyDialogue.features);
			conversation.ActorID = FindActorIdFromArticyDialogue(articyDialogue, 0, 1);
			conversation.ConversantID = FindActorIdFromArticyDialogue(articyDialogue, 1, 2);
			database.conversations.Add(conversation);
			if (articyDialogue.isDocument)
			{
				documentConversations.Add(conversation);
			}
			DialogueEntry dialogueEntry = template.CreateDialogueEntry(GetNextConversationEntryID(conversation), conversationID, "START");
			dialogueEntry.canvasRect = new Rect(articyDialogue.position.x, articyDialogue.position.y, 160f, 30f);
			SetDialogueEntryParticipants(dialogueEntry, conversation.ActorID, conversation.ConversantID);
			Field.SetValue(dialogueEntry.fields, "Articy Id", articyDialogue.id, FieldType.Text);
			IndexDialogueEntryByArticyId(dialogueEntry, articyDialogue.id);
			dialogueEntry.outgoingLinks = new List<Link>();
			Field field = Field.Lookup(conversation.fields, "Sequence");
			if (field != null && !string.IsNullOrEmpty(field.value))
			{
				conversation.fields.Remove(field);
				Field.SetValue(dialogueEntry.fields, "Sequence", field.value, FieldType.Text);
			}
			else
			{
				Field.SetValue(dialogueEntry.fields, "Sequence", "Continue()", FieldType.Text);
			}
			conversation.dialogueEntries.Add(dialogueEntry);
			for (int i = 0; i < articyDialogue.pins.Count; i++)
			{
				ArticyData.Pin pin = articyDialogue.pins[i];
				bool flag = pin.semantic == ArticyData.SemanticType.Input;
				if (pin.semantic != ArticyData.SemanticType.Output || prefs.RecursionMode != ConverterPrefs.RecursionModes.Off)
				{
					int nextConversationEntryID = GetNextConversationEntryID(conversation);
					string title = (flag ? "input" : "output");
					DialogueEntry dialogueEntry2 = template.CreateDialogueEntry(nextConversationEntryID, conversationID, title);
					dialogueEntry2.canvasRect = new Rect(articyDialogue.position.x, articyDialogue.position.y, 160f, 30f);
					SetDialogueEntryParticipants(dialogueEntry2, conversation.ConversantID, conversation.ActorID);
					ConvertPinExpressionsToConditionsAndScripts(dialogueEntry2, articyDialogue.pins, flag, !flag);
					dialogueEntry2.isGroup = true;
					Field.SetValue(dialogueEntry2.fields, "Articy Id", pin.id, FieldType.Text);
					if (flag)
					{
						Link link = new Link();
						link.originConversationID = conversationID;
						link.originDialogueID = dialogueEntry.id;
						link.destinationConversationID = conversationID;
						link.destinationDialogueID = dialogueEntry2.id;
						dialogueEntry.outgoingLinks.Add(link);
					}
					else
					{
						unusedOutputEntries.Add(dialogueEntry2);
					}
					IndexDialogueEntryByArticyId(dialogueEntry2, pin.id);
					dialogueEntry2.outgoingLinks = new List<Link>();
					conversation.dialogueEntries.Add(dialogueEntry2);
					RecordPin(pin, dialogueEntry2);
				}
			}
			return conversation;
		}

		protected virtual void SetConversationOverrideProperties(Conversation conversation, ArticyData.Features features)
		{
			foreach (ArticyData.Feature feature in features.features)
			{
				foreach (ArticyData.Property property in feature.properties)
				{
					for (int num = property.fields.Count - 1; num >= 0; num--)
					{
						Field field = property.fields[num];
						bool flag = true;
						switch (field.title)
						{
						case "ShowNPCSubtitlesDuringLine":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideSubtitleSettings = true;
							conversation.overrideSettings.showNPCSubtitlesDuringLine = Tools.StringToBool(field.value);
							break;
						case "ShowNPCSubtitlesWithResponses":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideSubtitleSettings = true;
							conversation.overrideSettings.showNPCSubtitlesWithResponses = Tools.StringToBool(field.value);
							break;
						case "ShowPCSubtitlesDuringLine":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideSubtitleSettings = true;
							conversation.overrideSettings.showPCSubtitlesDuringLine = Tools.StringToBool(field.value);
							break;
						case "SkipPCSubtitleAfterResponseMenu":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideSubtitleSettings = true;
							conversation.overrideSettings.skipPCSubtitleAfterResponseMenu = Tools.StringToBool(field.value);
							break;
						case "SubtitleCharsPerSecond":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideSubtitleSettings = true;
							conversation.overrideSettings.subtitleCharsPerSecond = Tools.StringToFloat(field.value);
							break;
						case "MinSubtitleSeconds":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideSubtitleSettings = true;
							conversation.overrideSettings.minSubtitleSeconds = Tools.StringToFloat(field.value);
							break;
						case "ContinueButton":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideSubtitleSettings = true;
							conversation.overrideSettings.continueButton = StringToContinueButtonMode(field.value);
							break;
						case "DefaultSequence":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideSequenceSettings = true;
							conversation.overrideSettings.defaultSequence = field.value;
							break;
						case "DefaultPlayerSequence":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideSequenceSettings = true;
							conversation.overrideSettings.defaultPlayerSequence = field.value;
							break;
						case "DefaultResponseMenuSequence":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideSequenceSettings = true;
							conversation.overrideSettings.defaultResponseMenuSequence = field.value;
							break;
						case "AlwaysForceResponseMenu":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideInputSettings = true;
							conversation.overrideSettings.alwaysForceResponseMenu = Tools.StringToBool(field.value);
							break;
						case "IncludeInvalidEntries":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideInputSettings = true;
							conversation.overrideSettings.includeInvalidEntries = Tools.StringToBool(field.value);
							break;
						case "ResponseTimeout":
							conversation.overrideSettings.useOverrides = true;
							conversation.overrideSettings.overrideInputSettings = true;
							conversation.overrideSettings.responseTimeout = Tools.StringToFloat(field.value);
							break;
						default:
							flag = false;
							break;
						}
						if (flag)
						{
							property.fields.RemoveAt(num);
						}
					}
				}
			}
		}

		protected virtual DisplaySettings.SubtitleSettings.ContinueButtonMode StringToContinueButtonMode(string value)
		{
			Array values = Enum.GetValues(typeof(DisplaySettings.SubtitleSettings.ContinueButtonMode));
			for (int i = 0; i < values.Length; i++)
			{
				DisplaySettings.SubtitleSettings.ContinueButtonMode result = (DisplaySettings.SubtitleSettings.ContinueButtonMode)i;
				if (string.Equals(value, result.ToString(), StringComparison.OrdinalIgnoreCase))
				{
					return result;
				}
			}
			return DisplaySettings.SubtitleSettings.ContinueButtonMode.Never;
		}

		protected virtual void SetDialogueEntryParticipants(DialogueEntry startEntry, int actorID, int conversantID)
		{
			startEntry.ActorID = actorID;
			startEntry.ConversantID = conversantID;
		}

		protected virtual int GetDefaultActorID(Conversation conversation)
		{
			if (conversation == null)
			{
				if (!prefs.UseDefaultActorsIfNoneAssignedToDialogue)
				{
					return -1;
				}
				return 1;
			}
			return conversation.ActorID;
		}

		protected virtual int GetDefaultConversantID(Conversation conversation)
		{
			if (conversation == null)
			{
				if (!prefs.UseDefaultActorsIfNoneAssignedToDialogue)
				{
					return -1;
				}
				return 2;
			}
			return conversation.ConversantID;
		}

		protected virtual Conversation FindOrCreateFlowFragmentConversation(ArticyData.FlowFragment articyFlowFragment, bool isTopLevel)
		{
			if (articyFlowFragment == null)
			{
				return null;
			}
			conversationID++;
			string title = articyFlowFragment.displayName.DefaultText + " Conversation";
			Conversation conversation = template.CreateConversation(conversationID, title);
			Field.SetValue(conversation.fields, "Articy Id", articyFlowFragment.id, FieldType.Text);
			Field.SetValue(conversation.fields, "Description", articyFlowFragment.text.DefaultText, FieldType.Text);
			SetFeatureFields(conversation.fields, articyFlowFragment.features);
			Conversation conversationStackTop = GetConversationStackTop();
			conversation.ActorID = GetDefaultActorID(conversationStackTop);
			conversation.ConversantID = GetDefaultConversantID(conversationStackTop);
			database.conversations.Add(conversation);
			DialogueEntry dialogueEntry = template.CreateDialogueEntry(GetNextConversationEntryID(conversation), conversationID, "START");
			SetDialogueEntryParticipants(dialogueEntry, conversation.ActorID, conversation.ConversantID);
			Field.SetValue(dialogueEntry.fields, "Articy Id", articyFlowFragment.id, FieldType.Text);
			IndexDialogueEntryByArticyId(dialogueEntry, articyFlowFragment.id);
			ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, articyFlowFragment.pins, convertInput: true, convertOutput: false);
			dialogueEntry.outgoingLinks = new List<Link>();
			Field field = Field.Lookup(conversation.fields, "Sequence");
			if (field != null && !string.IsNullOrEmpty(field.value))
			{
				conversation.fields.Remove(field);
				Field.SetValue(dialogueEntry.fields, "Sequence", field.value, FieldType.Text);
			}
			else
			{
				Field.SetValue(dialogueEntry.fields, "Sequence", "Continue()", FieldType.Text);
			}
			conversation.dialogueEntries.Add(dialogueEntry);
			for (int i = 0; i < articyFlowFragment.pins.Count; i++)
			{
				ArticyData.Pin pin = articyFlowFragment.pins[i];
				_ = pin.semantic;
				if (pin.semantic != ArticyData.SemanticType.Output || prefs.RecursionMode != ConverterPrefs.RecursionModes.Off)
				{
					int nextConversationEntryID = GetNextConversationEntryID(conversation);
					string title2 = ((pin.semantic == ArticyData.SemanticType.Input) ? "input" : "output");
					DialogueEntry dialogueEntry2 = template.CreateDialogueEntry(nextConversationEntryID, conversationID, title2);
					SetDialogueEntryParticipants(dialogueEntry2, conversation.ConversantID, conversation.ActorID);
					dialogueEntry2.isGroup = true;
					Field.SetValue(dialogueEntry2.fields, "Articy Id", pin.id, FieldType.Text);
					if (pin.semantic == ArticyData.SemanticType.Input)
					{
						Link link = new Link();
						link.originConversationID = conversationID;
						link.originDialogueID = dialogueEntry.id;
						link.destinationConversationID = conversationID;
						link.destinationDialogueID = dialogueEntry2.id;
						dialogueEntry.outgoingLinks.Add(link);
					}
					else if (!isTopLevel || pin.semantic != ArticyData.SemanticType.Output)
					{
						unusedOutputEntries.Add(dialogueEntry2);
					}
					IndexDialogueEntryByArticyId(dialogueEntry2, pin.id);
					ConvertPinExpressionsToConditionsAndScripts(dialogueEntry2, articyFlowFragment.pins);
					dialogueEntry2.outgoingLinks = new List<Link>();
					conversation.dialogueEntries.Add(dialogueEntry2);
					RecordPin(pin, dialogueEntry2);
				}
			}
			if (isTopLevel)
			{
				DialogueEntry dialogueEntry3 = conversation.dialogueEntries.Find((DialogueEntry x) => x.Title == "input");
				if (dialogueEntry3 != null)
				{
					foreach (DialogueEntry dialogueEntry4 in conversation.dialogueEntries)
					{
						if (dialogueEntry4.Title == "output")
						{
							Link link2 = new Link();
							link2.originConversationID = conversationID;
							link2.originDialogueID = dialogueEntry3.id;
							link2.destinationConversationID = conversationID;
							link2.destinationDialogueID = dialogueEntry4.id;
							dialogueEntry3.outgoingLinks.Add(link2);
						}
					}
				}
			}
			return conversation;
		}

		protected virtual void ProcessHierarchy()
		{
			ArticyConverter.onProgressCallback("Processing dialogue nodes", 0.4f);
			BuildDialogueEntriesFromNode(articyData.hierarchy.node, 0);
			ArticyConverter.onProgressCallback("Connecting dialogue nodes", 0.5f);
			ProcessConnections();
			ArticyConverter.onProgressCallback("Checking if jumps are group nodes", 0.6f);
			CheckJumpsForGroupNodes();
		}

		protected virtual void InsertDelayEvaluationNodesBeforeInputPins()
		{
			foreach (Conversation conversation in database.conversations)
			{
				int count = conversation.dialogueEntries.Count;
				for (int i = 1; i < count; i++)
				{
					DialogueEntry dialogueEntry = conversation.dialogueEntries[i];
					if (string.IsNullOrEmpty(dialogueEntry.userScript))
					{
						continue;
					}
					foreach (Link outgoingLink in dialogueEntry.outgoingLinks)
					{
						DialogueEntry dialogueEntry2 = database.GetDialogueEntry(outgoingLink);
						if (string.IsNullOrEmpty(dialogueEntry2.conditionsString) || !prefs.DelayEvaluation)
						{
							continue;
						}
						string text = Field.LookupValue(dialogueEntry2.fields, "Articy Id");
						DialogueEntry dialogueEntry3 = null;
						foreach (Link outgoingLink2 in dialogueEntry.outgoingLinks)
						{
							DialogueEntry dialogueEntry4 = database.GetDialogueEntry(outgoingLink2);
							if (dialogueEntry4 != null && dialogueEntry4.Title == "Delay Evaluation")
							{
								dialogueEntry3 = dialogueEntry4;
								break;
							}
						}
						if (dialogueEntry3 == null)
						{
							dialogueEntry3 = CreateNewDialogueEntry(conversation, "Delay Evaluation", text + "-1");
							conversation.dialogueEntries.Add(dialogueEntry3);
							dialogueEntry3.isGroup = prefs.ConvertInstructionsAs == ConverterPrefs.CodeNodeMode.GroupEntry;
							dialogueEntry3.ActorID = GetNPCID(conversation);
							dialogueEntry3.Sequence = "Continue()";
							dialogueEntry3.outgoingLinks = new List<Link>
							{
								new Link(outgoingLink)
							};
						}
						else
						{
							dialogueEntry3.outgoingLinks.Add(new Link(outgoingLink));
						}
						outgoingLink.destinationDialogueID = dialogueEntry3.id;
					}
				}
			}
		}

		private int GetNPCID(Conversation conversation)
		{
			Actor actor = database.GetActor(conversation.ConversantID);
			if (actor != null && !actor.IsPlayer)
			{
				return conversation.id;
			}
			Actor actor2 = database.GetActor(conversation.ActorID);
			if (actor2 != null && !actor2.IsPlayer)
			{
				return actor2.id;
			}
			return database.actors.Find((Actor x) => !x.IsPlayer)?.id ?? conversation.ConversantID;
		}

		protected virtual void BuildDialogueEntriesFromNode(ArticyData.Node node, int recursionDepth)
		{
			if (recursionDepth > 1000)
			{
				Debug.LogError("Dialogue System: Internal error - Exceeded max recursion depth " + 1000 + " in ArticyConverter.BuildDialogueEntriesFromNode.");
				return;
			}
			bool flag = false;
			if (node.type == ArticyData.NodeType.Dialogue && !IncludeDialogue(node.id))
			{
				return;
			}
			switch (node.type)
			{
			case ArticyData.NodeType.FlowFragment:
			{
				ArticyData.FlowFragment flowFragment = LookupArticyFlowFragment(node.id);
				PushFlowFragment(flowFragment);
				if (GetConversationStackTop() != null)
				{
					if (prefs.FlowFragmentMode == ConverterPrefs.FlowFragmentModes.NestedConversationGroups && articyData.flowFragments.ContainsKey(node.id))
					{
						Conversation conversation2 = FindOrCreateFlowFragmentConversation(articyData.flowFragments[node.id], isTopLevel: false);
						if (conversation2 != null)
						{
							PushConversation(conversation2);
							PrependFlowStackToConversationTitle(conversation2);
						}
					}
					else
					{
						AddFlowFragmentAsDialogueEntry(GetConversationStackTop(), flowFragment);
					}
				}
				else if (prefs.CreateConversationsForLooseFlow)
				{
					Conversation conversation3 = FindOrCreateFlowFragmentConversation(articyData.flowFragments[node.id], isTopLevel: true);
					if (conversation3 != null)
					{
						PushConversation(conversation3);
						PrependFlowStackToConversationTitle(conversation3);
						flag = true;
					}
				}
				break;
			}
			case ArticyData.NodeType.Dialogue:
			{
				Conversation conversation = database.conversations.Find((Conversation x) => string.Equals(x.LookupValue("Articy Id"), node.id));
				PushConversation(conversation);
				PrependFlowStackToConversationTitle(conversation);
				break;
			}
			case ArticyData.NodeType.DialogueFragment:
				BuildDialogueEntryFromDialogueFragment(GetConversationStackTop(), LookupArticyDialogueFragment(node.id));
				break;
			case ArticyData.NodeType.Hub:
				BuildDialogueEntryFromHub(GetConversationStackTop(), LookupArticyHub(node.id));
				break;
			case ArticyData.NodeType.Jump:
				BuildDialogueEntryFromJump(GetConversationStackTop(), LookupArticyJump(node.id));
				break;
			case ArticyData.NodeType.Condition:
				BuildDialogueEntriesFromCondition(GetConversationStackTop(), LookupArticyCondition(node.id));
				break;
			case ArticyData.NodeType.Instruction:
				BuildDialogueEntryFromInstruction(GetConversationStackTop(), LookupArticyInstruction(node.id));
				break;
			}
			foreach (ArticyData.Node node2 in node.nodes)
			{
				BuildDialogueEntriesFromNode(node2, recursionDepth + 1);
			}
			switch (node.type)
			{
			case ArticyData.NodeType.FlowFragment:
				if (!flag)
				{
					PopFlowFragment();
					if (prefs.FlowFragmentMode == ConverterPrefs.FlowFragmentModes.NestedConversationGroups && database.conversations.Find((Conversation x) => string.Equals(x.LookupValue("Articy Id"), node.id)) != null)
					{
						PopConversation();
					}
				}
				break;
			case ArticyData.NodeType.Dialogue:
				PopConversation();
				break;
			}
		}

		protected virtual void PrependFlowStackToConversationTitle(Conversation conversation)
		{
			bool flag = prefs.FlowFragmentMode == ConverterPrefs.FlowFragmentModes.ConversationGroups || prefs.FlowFragmentMode == ConverterPrefs.FlowFragmentModes.NestedConversationGroups;
			if (conversation == null || !flag || flowFragmentNameStack.Count <= 0)
			{
				return;
			}
			string text = string.Empty;
			foreach (string item in flowFragmentNameStack)
			{
				text = text + item + "/";
			}
			conversation.Title = text + conversation.Title;
		}

		protected virtual void RecordPins(List<ArticyData.Pin> pins, DialogueEntry entry)
		{
			if (pins != null)
			{
				for (int i = 0; i < pins.Count; i++)
				{
					RecordPin(pins[i], entry);
				}
			}
		}

		protected virtual void RecordPin(ArticyData.Pin pin, DialogueEntry entry)
		{
			if (pin != null && entry != null && !entriesByPinID.ContainsKey(pin.id))
			{
				entriesByPinID.Add(pin.id, entry);
				Field.SetValue(entry.fields, (pin.semantic == ArticyData.SemanticType.Input) ? "InputId" : "OutputId", pin.id);
			}
		}

		protected virtual void ProcessConnections()
		{
			foreach (KeyValuePair<string, ArticyData.Connection> connection in articyData.connections)
			{
				ProcessConnectionNew(connection.Value);
			}
			foreach (KeyValuePair<ArticyData.Jump, DialogueEntry> item in jumpsToProcess)
			{
				ProcessJumpConnection(item.Key, item.Value);
			}
			RemoveUnusedOutputEntries();
		}

		protected virtual void ProcessConnectionNew(ArticyData.Connection connection)
		{
			if (connection != null)
			{
				DialogueEntry value2;
				if (!entriesByPinID.TryGetValue(connection.source.pinRef, out var value))
				{
					Debug.LogError("Can't find output pin " + connection.source.pinRef + " for connection [" + connection.source.idRef + "/" + connection.source.pinRef + "]-->[" + connection.target.idRef + "/" + connection.target.pinRef + "]");
				}
				else if (!entriesByPinID.TryGetValue(connection.target.pinRef, out value2))
				{
					Debug.LogError("Can't find input pin " + connection.target.pinRef + " for connection [" + connection.source.idRef + "/" + connection.source.pinRef + "]-->[" + connection.target.idRef + "/" + connection.target.pinRef + "]");
				}
				else
				{
					CreateLinkToTarget(value, value2, connection);
				}
			}
		}

		protected ArticyData.Connection FindConnectionWithSourcePin(string pinRef)
		{
			foreach (ArticyData.Connection value in articyData.connections.Values)
			{
				if (value.source.pinRef == pinRef)
				{
					return value;
				}
			}
			return null;
		}

		protected virtual void CreateLinkToTarget(DialogueEntry sourceEntry, DialogueEntry targetEntry, ArticyData.Connection connection)
		{
			if (sourceEntry.conversationID != targetEntry.conversationID || sourceEntry.id != targetEntry.id)
			{
				Link link = new Link();
				link.originConversationID = sourceEntry.conversationID;
				link.originDialogueID = sourceEntry.id;
				link.destinationConversationID = targetEntry.conversationID;
				link.destinationDialogueID = targetEntry.id;
				link.isConnector = false;
				link.priority = ArticyData.ColorToPriority(connection.color);
				sourceEntry.outgoingLinks.Add(link);
			}
			MarkTargetUsed(targetEntry);
		}

		protected virtual void ProcessDialogueConnection(ArticyData.Connection connection)
		{
			if (connection == null || LookupArticyDialogue(connection.source.idRef) == null || LookupArticyDialogue(connection.target.idRef) == null)
			{
				return;
			}
			Conversation conversation = database.conversations.Find((Conversation x) => string.Equals(x.LookupValue("Articy Id"), connection.source.idRef));
			if (conversation == null)
			{
				return;
			}
			Conversation conversation2 = database.conversations.Find((Conversation x) => string.Equals(x.LookupValue("Articy Id"), connection.target.idRef));
			if (conversation2 == null)
			{
				return;
			}
			DialogueEntry firstDialogueEntry = conversation2.GetFirstDialogueEntry();
			if (firstDialogueEntry == null)
			{
				return;
			}
			foreach (ArticyData.Connection innerConnection in articyData.connections.Values)
			{
				if (innerConnection.target.idRef != connection.source.idRef)
				{
					continue;
				}
				DialogueEntry dialogueEntry = conversation.dialogueEntries.Find((DialogueEntry x) => Field.LookupValue(x.fields, "Articy Id") == innerConnection.source.idRef);
				if (dialogueEntry != null)
				{
					if (dialogueEntry.outgoingLinks == null)
					{
						dialogueEntry.outgoingLinks = new List<Link>();
					}
					dialogueEntry.outgoingLinks.Add(new Link(conversation.id, dialogueEntry.id, conversation2.id, firstDialogueEntry.id));
				}
			}
		}

		protected virtual void ProcessJumpConnection(ArticyData.Jump jump, DialogueEntry jumpEntry)
		{
			if (jump == null || jumpEntry == null)
			{
				return;
			}
			if (entriesByPinID.ContainsKey(jump.target.pinRef))
			{
				DialogueEntry dialogueEntry = entriesByPinID[jump.target.pinRef];
				Link link = new Link();
				link.originConversationID = jumpEntry.conversationID;
				link.originDialogueID = jumpEntry.id;
				link.destinationConversationID = dialogueEntry.conversationID;
				link.destinationDialogueID = dialogueEntry.id;
				link.isConnector = false;
				jumpEntry.outgoingLinks.Add(link);
				MarkTargetUsed(dialogueEntry);
				return;
			}
			Conversation conversation = database.conversations.Find((Conversation x) => string.Equals(x.LookupValue("Articy Id"), jump.target.idRef));
			if (conversation != null)
			{
				DialogueEntry firstDialogueEntry = conversation.GetFirstDialogueEntry();
				Link link2 = new Link();
				link2.originConversationID = jumpEntry.conversationID;
				link2.originDialogueID = jumpEntry.id;
				link2.destinationConversationID = firstDialogueEntry.conversationID;
				link2.destinationDialogueID = firstDialogueEntry.id;
				link2.isConnector = false;
				jumpEntry.outgoingLinks.Add(link2);
				MarkTargetUsed(firstDialogueEntry);
			}
		}

		protected virtual void MarkTargetUsed(DialogueEntry targetEntry)
		{
			unusedOutputEntries.Remove(targetEntry);
		}

		protected virtual void RemoveUnusedOutputEntries()
		{
			for (int i = 0; i < unusedOutputEntries.Count; i++)
			{
				DialogueEntry dialogueEntry = unusedOutputEntries[i];
				database.GetConversation(dialogueEntry.conversationID)?.dialogueEntries.Remove(dialogueEntry);
			}
		}

		protected virtual ArticyData.Dialogue LookupArticyDialogue(string id)
		{
			if (!articyData.dialogues.ContainsKey(id))
			{
				return null;
			}
			return articyData.dialogues[id];
		}

		protected virtual ArticyData.DialogueFragment LookupArticyDialogueFragment(string id)
		{
			if (!articyData.dialogueFragments.ContainsKey(id))
			{
				return null;
			}
			return articyData.dialogueFragments[id];
		}

		protected virtual ArticyData.Hub LookupArticyHub(string id)
		{
			if (!articyData.hubs.ContainsKey(id))
			{
				return null;
			}
			return articyData.hubs[id];
		}

		protected virtual ArticyData.Jump LookupArticyJump(string id)
		{
			if (!articyData.jumps.ContainsKey(id))
			{
				return null;
			}
			return articyData.jumps[id];
		}

		protected virtual ArticyData.Condition LookupArticyCondition(string id)
		{
			if (!articyData.conditions.ContainsKey(id))
			{
				return null;
			}
			return articyData.conditions[id];
		}

		protected virtual ArticyData.Instruction LookupArticyInstruction(string id)
		{
			if (!articyData.instructions.ContainsKey(id))
			{
				return null;
			}
			return articyData.instructions[id];
		}

		protected virtual ArticyData.Connection LookupArticyConnection(string id)
		{
			if (!articyData.connections.ContainsKey(id))
			{
				return null;
			}
			return articyData.connections[id];
		}

		protected virtual ArticyData.FlowFragment LookupArticyFlowFragment(string id)
		{
			if (!articyData.flowFragments.ContainsKey(id))
			{
				return null;
			}
			return articyData.flowFragments[id];
		}

		protected virtual void BuildDialogueEntryFromDialogueFragment(Conversation conversation, ArticyData.DialogueFragment fragment)
		{
			if (fragment == null || conversation == null)
			{
				return;
			}
			DialogueEntry dialogueEntry = CreateNewDialogueEntry(conversation, fragment.displayName.DefaultText, fragment.id);
			dialogueEntry.canvasRect = new Rect(fragment.position.x, fragment.position.y, 160f, 30f);
			ConvertLocalizableText(dialogueEntry, "Dialogue Text", fragment.text, replaceNewlines: true);
			ConvertLocalizableText(dialogueEntry, "Menu Text", fragment.menuText, replaceNewlines: true);
			ConvertLocalizableText(dialogueEntry, "Title", fragment.displayName);
			SetFeatureFields(dialogueEntry.fields, fragment.features);
			switch (prefs.StageDirectionsMode)
			{
			case ConverterPrefs.StageDirModes.Sequences:
			{
				string defaultText2 = fragment.stageDirections.DefaultText;
				if (!string.IsNullOrEmpty(defaultText2) && (defaultText2.Contains("(") || defaultText2.Contains("{{")))
				{
					ConvertLocalizableText(dialogueEntry, "Sequence", fragment.stageDirections);
				}
				break;
			}
			case ConverterPrefs.StageDirModes.Description:
			{
				string defaultText = fragment.stageDirections.DefaultText;
				Field.SetValue(dialogueEntry.fields, "Description", defaultText);
				break;
			}
			}
			Field field = Field.Lookup(dialogueEntry.fields, "Conditions");
			if (field != null)
			{
				dialogueEntry.conditionsString = AddToUserScript(dialogueEntry.conditionsString, field.value);
				dialogueEntry.fields.Remove(field);
			}
			Field field2 = Field.Lookup(dialogueEntry.fields, "Script");
			if (field2 != null)
			{
				dialogueEntry.userScript = AddToUserScript(dialogueEntry.userScript, field2.value);
				dialogueEntry.fields.Remove(field2);
			}
			dialogueEntry.ActorID = FindActorByArticyId(fragment.speakerIdRef)?.id ?? (prefs.UseDefaultActorsIfNoneAssignedToDialogue ? conversation.ActorID : 0);
			Field field3 = Field.Lookup(dialogueEntry.fields, "ConversantEntity");
			Actor actor = ((field3 == null) ? null : ((prefs.ConvertSlotsAs == ConverterPrefs.ConvertSlotsModes.ID) ? FindActorByArticyId(field3.value) : ((prefs.ConvertSlotsAs == ConverterPrefs.ConvertSlotsModes.TechnicalName) ? FindActorByTechnicalName(field3.value) : FindActorByDisplayName(field3.value))));
			if (actor != null)
			{
				dialogueEntry.ConversantID = actor.id;
			}
			else
			{
				dialogueEntry.ConversantID = (prefs.UseDefaultActorsIfNoneAssignedToDialogue ? ((dialogueEntry.ActorID == conversation.ActorID) ? conversation.ConversantID : conversation.ActorID) : 0);
			}
			ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, fragment.pins);
			RecordPins(fragment.pins, dialogueEntry);
		}

		protected virtual bool DoesLinkExist(List<Link> outgoingLinks, DialogueEntry destination)
		{
			if (outgoingLinks == null || destination == null)
			{
				return false;
			}
			for (int i = 0; i < outgoingLinks.Count; i++)
			{
				if (outgoingLinks[i] != null && outgoingLinks[i].destinationConversationID == destination.conversationID && outgoingLinks[i].destinationDialogueID == destination.id)
				{
					return true;
				}
			}
			return false;
		}

		protected virtual void AddFlowFragmentAsDialogueEntry(Conversation conversation, ArticyData.FlowFragment flowFragment)
		{
			if (flowFragment != null && conversation != null)
			{
				DialogueEntry dialogueEntry = CreateNewDialogueEntry(conversation, flowFragment.displayName.DefaultText, flowFragment.id);
				dialogueEntry.canvasRect = new Rect(flowFragment.position.x, flowFragment.position.y, 160f, 30f);
				ConvertLocalizableText(dialogueEntry, "Title", flowFragment.displayName);
				dialogueEntry.Title = "Flow: " + dialogueEntry.Title;
				SetFeatureFields(dialogueEntry.fields, flowFragment.features);
				Field field = Field.Lookup(dialogueEntry.fields, "Script");
				if (field != null)
				{
					dialogueEntry.userScript = AddToUserScript(dialogueEntry.userScript, field.value);
					dialogueEntry.fields.Remove(field);
				}
				dialogueEntry.ActorID = conversation.ActorID;
				dialogueEntry.ConversantID = ((dialogueEntry.ActorID == conversation.ActorID) ? conversation.ConversantID : conversation.ActorID);
				if (!string.IsNullOrEmpty(prefs.FlowFragmentScript))
				{
					dialogueEntry.userScript = prefs.FlowFragmentScript + "(\"" + flowFragment.displayName.DefaultText.Replace("\"", "'") + "\")";
				}
				dialogueEntry.isGroup = true;
				ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, flowFragment.pins);
				if (dialogueEntry.isGroup)
				{
					dialogueEntry.ActorID = GetNPCID(conversation);
				}
				RecordPins(flowFragment.pins, dialogueEntry);
			}
		}

		protected virtual void BuildDialogueEntryFromHub(Conversation conversation, ArticyData.Hub hub)
		{
			if (hub != null && conversation != null)
			{
				DialogueEntry dialogueEntry = CreateNewDialogueEntry(conversation, hub.displayName.DefaultText, hub.id);
				dialogueEntry.canvasRect = new Rect(hub.position.x, hub.position.y, 160f, 30f);
				SetFeatureFields(dialogueEntry.fields, hub.features);
				ConvertLocalizableText(dialogueEntry, "Title", hub.displayName);
				dialogueEntry.isGroup = true;
				ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, hub.pins);
				if (dialogueEntry.isGroup)
				{
					dialogueEntry.ActorID = GetNPCID(conversation);
				}
				RecordPins(hub.pins, dialogueEntry);
			}
		}

		protected virtual void BuildDialogueEntryFromJump(Conversation conversation, ArticyData.Jump jump)
		{
			if (jump == null || conversation == null)
			{
				return;
			}
			DialogueEntry dialogueEntry = CreateNewDialogueEntry(conversation, jump.displayName.DefaultText, jump.id);
			dialogueEntry.canvasRect = new Rect(jump.position.x, jump.position.y, 160f, 30f);
			SetFeatureFields(dialogueEntry.fields, jump.features);
			ConvertLocalizableText(dialogueEntry, "Title", jump.displayName);
			dialogueEntry.isGroup = true;
			ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, jump.pins);
			if (dialogueEntry.isGroup)
			{
				dialogueEntry.ActorID = GetNPCID(conversation);
			}
			RecordPins(jump.pins, dialogueEntry);
			jumpsToProcess.Add(jump, dialogueEntry);
			ArticyData.FlowFragment flowFragment = FindFlowFragment(jump.target.idRef);
			if (flowFragment != null)
			{
				DialogueEntry dialogueEntry2 = CreateNewDialogueEntry(conversation, "Flow: " + flowFragment.displayName.DefaultText, flowFragment.id);
				dialogueEntry2.canvasRect = new Rect(jump.position.x, jump.position.y + 32f, 160f, 30f);
				SetFeatureFields(dialogueEntry2.fields, flowFragment.features);
				dialogueEntry2.isGroup = true;
				ConvertPinExpressionsToConditionsAndScripts(dialogueEntry2, flowFragment.pins);
				if (dialogueEntry2.isGroup)
				{
					dialogueEntry2.ActorID = GetNPCID(conversation);
				}
				RecordPins(flowFragment.pins, dialogueEntry2);
			}
		}

		protected virtual void CheckJumpsForGroupNodes()
		{
			foreach (DialogueEntry item in new HashSet<DialogueEntry>(jumpsToProcess.Values))
			{
				if (item != null)
				{
					item.isGroup = string.IsNullOrEmpty(item.userScript);
					if (!item.isGroup && string.IsNullOrEmpty(item.Sequence))
					{
						item.Sequence = "Continue()";
					}
				}
			}
		}

		protected virtual void BuildDialogueEntriesFromCondition(Conversation conversation, ArticyData.Condition condition)
		{
			if (condition == null || conversation == null)
			{
				return;
			}
			DialogueEntry dialogueEntry = CreateNewDialogueEntry(conversation, condition.expression, condition.id);
			dialogueEntry.canvasRect = new Rect(condition.position.x, condition.position.y, 160f, 30f);
			dialogueEntry.ActorID = conversation.ConversantID;
			dialogueEntry.ConversantID = conversation.ActorID;
			dialogueEntry.currentDialogueText = string.Empty;
			dialogueEntry.currentMenuText = string.Empty;
			dialogueEntry.isGroup = true;
			if (dialogueEntry.isGroup)
			{
				dialogueEntry.ActorID = GetNPCID(conversation);
			}
			string text = ConvertExpression(condition.expression, isCondition: true);
			string text2 = (string.IsNullOrEmpty(text) ? "false" : $"({RemoveTrailingSemicolon(text)}) == false");
			float num = condition.position.y;
			foreach (ArticyData.Pin pin in condition.pins)
			{
				if (pin.semantic == ArticyData.SemanticType.Input)
				{
					RecordPin(pin, dialogueEntry);
					dialogueEntry.conditionsString = AddToConditions(dialogueEntry.conditionsString, ConvertExpression(pin.expression, isCondition: true));
				}
				else if (pin.semantic == ArticyData.SemanticType.Output)
				{
					bool num2 = pin.index == 0;
					string title = (num2 ? condition.expression : $"!({condition.expression})");
					DialogueEntry dialogueEntry2 = CreateNewDialogueEntry(conversation, title, condition.id);
					dialogueEntry2.canvasRect = new Rect(condition.position.x, num, 160f, 30f);
					num += 2f;
					dialogueEntry2.ActorID = GetNPCID(conversation);
					dialogueEntry2.ConversantID = conversation.ActorID;
					dialogueEntry2.currentDialogueText = string.Empty;
					dialogueEntry2.currentMenuText = string.Empty;
					dialogueEntry2.isGroup = true;
					string moreConditions = (num2 ? text : text2);
					dialogueEntry2.conditionsString = AddToConditions(dialogueEntry2.conditionsString, moreConditions);
					dialogueEntry2.userScript = AddToUserScript(dialogueEntry2.userScript, ConvertExpression(pin.expression));
					Link link = new Link();
					link.originConversationID = dialogueEntry.conversationID;
					link.originDialogueID = dialogueEntry.id;
					link.destinationConversationID = dialogueEntry2.conversationID;
					link.destinationDialogueID = dialogueEntry2.id;
					link.isConnector = false;
					dialogueEntry.outgoingLinks.Add(link);
					RecordPin(pin, dialogueEntry2);
				}
			}
		}

		protected string RemoveTrailingSemicolon(string s)
		{
			if (!string.IsNullOrEmpty(s) && s[s.Length - 1] == ';')
			{
				return s.Substring(0, s.Length - 1);
			}
			return s;
		}

		protected virtual void BuildDialogueEntryFromInstruction(Conversation conversation, ArticyData.Instruction instruction)
		{
			if (instruction != null && conversation != null)
			{
				DialogueEntry dialogueEntry = CreateNewDialogueEntry(conversation, instruction.expression, instruction.id);
				dialogueEntry.canvasRect = new Rect(instruction.position.x, instruction.position.y, 160f, 30f);
				dialogueEntry.ActorID = GetNPCID(conversation);
				dialogueEntry.ConversantID = conversation.ActorID;
				dialogueEntry.currentDialogueText = string.Empty;
				dialogueEntry.currentMenuText = string.Empty;
				dialogueEntry.currentSequence = "Continue()";
				dialogueEntry.isGroup = prefs.ConvertInstructionsAs == ConverterPrefs.CodeNodeMode.GroupEntry;
				dialogueEntry.conditionsString = string.Empty;
				dialogueEntry.userScript = AddToUserScript(dialogueEntry.userScript, ConvertExpression(instruction.expression));
				ConvertPinExpressionsToConditionsAndScripts(dialogueEntry, instruction.pins);
				if (dialogueEntry.isGroup)
				{
					dialogueEntry.ActorID = GetNPCID(conversation);
				}
				RecordPins(instruction.pins, dialogueEntry);
			}
		}

		protected virtual string AddToConditions(string conditions, string moreConditions)
		{
			if (string.IsNullOrEmpty(conditions) && string.IsNullOrEmpty(moreConditions))
			{
				return string.Empty;
			}
			if (string.IsNullOrEmpty(conditions))
			{
				return moreConditions;
			}
			if (string.IsNullOrEmpty(moreConditions))
			{
				return conditions;
			}
			return $"({conditions}) and ({moreConditions})";
		}

		protected virtual string AddToUserScript(string script, string moreScript)
		{
			if (string.IsNullOrEmpty(script) && string.IsNullOrEmpty(moreScript))
			{
				return string.Empty;
			}
			if (string.IsNullOrEmpty(script))
			{
				return moreScript;
			}
			if (string.IsNullOrEmpty(moreScript))
			{
				return script;
			}
			return $"{script}; {moreScript}";
		}

		protected DialogueEntry CreateNewDialogueEntry(Conversation conversation, string title, string articyId)
		{
			if (conversation == null)
			{
				Debug.Log("Conversation is null! " + articyId + " / " + title);
				return null;
			}
			DialogueEntry dialogueEntry = template.CreateDialogueEntry(GetNextConversationEntryID(conversation), conversation.id, title);
			SetDialogueEntryParticipants(dialogueEntry, conversation.ConversantID, conversation.ActorID);
			Field.SetValue(dialogueEntry.fields, "Articy Id", articyId, FieldType.Text);
			IndexDialogueEntryByArticyId(dialogueEntry, articyId);
			conversation.dialogueEntries.Add(dialogueEntry);
			return dialogueEntry;
		}

		protected virtual void ConvertPinExpressionsToConditionsAndScripts(DialogueEntry entry, List<ArticyData.Pin> pins, bool convertInput = true, bool convertOutput = true)
		{
			foreach (ArticyData.Pin pin in pins)
			{
				switch (pin.semantic)
				{
				case ArticyData.SemanticType.Input:
					if (convertInput && entry.Title != "output")
					{
						entry.conditionsString = AddToConditions(entry.conditionsString, ConvertExpression(pin.expression, isCondition: true));
					}
					break;
				case ArticyData.SemanticType.Output:
					if (!convertOutput || !(entry.Title != "input"))
					{
						break;
					}
					entry.userScript = AddToUserScript(entry.userScript, ConvertExpression(pin.expression));
					if (!string.IsNullOrEmpty(entry.userScript) && prefs.ConvertInstructionsAs != ConverterPrefs.CodeNodeMode.GroupEntry)
					{
						entry.isGroup = false;
						if (string.IsNullOrEmpty(entry.Sequence) && string.IsNullOrEmpty(entry.DialogueText) && string.IsNullOrEmpty(entry.MenuText))
						{
							entry.Sequence = "Continue()";
						}
					}
					break;
				default:
					Debug.LogWarning("Dialogue System: Unexpected semantic type " + pin.semantic.ToString() + " for pin " + pin.id + ".");
					break;
				}
			}
		}

		public static string ConvertExpression(string expression, bool isCondition = false)
		{
			if (string.IsNullOrEmpty(expression))
			{
				return expression;
			}
			if (isCondition && expression.Trim().StartsWith("//") && !expression.Contains("\n"))
			{
				return string.Empty;
			}
			if (expression.Contains("Variable["))
			{
				return expression;
			}
			if (!expression.Contains(";"))
			{
				return ConvertSingleExpression(expression);
			}
			string text = string.Empty;
			string[] array = expression.Split(';');
			foreach (string text2 in array)
			{
				if ((!isCondition || !text2.Trim().StartsWith("//")) && !string.IsNullOrEmpty(text2))
				{
					if (text.Length > 0)
					{
						text += ";\n";
					}
					text += ConvertSingleExpression(text2);
				}
			}
			return text;
		}

		public static string ConvertSingleExpression(string expression)
		{
			if (string.IsNullOrEmpty(expression))
			{
				return expression;
			}
			if (expression.Contains("Variable["))
			{
				return expression;
			}
			if (!expression.Contains("\""))
			{
				return ConvertExpressionFragment(expression);
			}
			string[] array = Regex.Split(expression, "(?<=[^\\\\])[\\\"]", RegexOptions.None);
			string text = string.Empty;
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				text += (flag ? array[i] : ConvertExpressionFragment(array[i]));
				if (i + 1 < array.Length)
				{
					text += "\"";
				}
				flag = !flag;
			}
			return text;
		}

		protected static string ConvertExpressionFragment(string expression)
		{
			if (string.IsNullOrEmpty(expression))
			{
				return expression;
			}
			string input = expression.Trim().Replace("///", "").Replace("//", "--");
			if (expression.Contains("Variable["))
			{
				return expression;
			}
			input = Regex.Replace(input, "(?<!math\\.)random\\(", "math.random(");
			input = input.Replace("&&", " and ");
			input = input.Replace("||", " or ");
			input = input.Replace("!=", "~=");
			MatchEvaluator evaluator = IncDecMatchEvaluator;
			foreach (string fullVariableName in fullVariableNames)
			{
				if (input.Contains(fullVariableName))
				{
					string pattern = "\\b" + fullVariableName + "\\b\\s*(\\+\\+|\\-\\-)";
					input = Regex.Replace(input, pattern, evaluator);
					pattern = "\\b" + fullVariableName + "\\b";
					string replacement = $"Variable[\"{fullVariableName}\"]";
					input = Regex.Replace(input, pattern, replacement);
				}
			}
			input = input.Replace("!Variable", "not Variable");
			input = input.Replace("!(", "not (");
			input = Regex.Replace(input, "!\\b(_\\w+|[\\w-[0-9_]]\\w*)\\b", (Match match) => "not " + match.Value.Substring(1));
			if (ContainsArithmeticAssignment(input))
			{
				string[] array = input.Split((char[])null);
				for (int num = 1; num < array.Length; num++)
				{
					string text = array[num];
					if (ContainsArithmeticAssignment(text))
					{
						char c = text[0];
						array[num] = $"= {array[num - 1]} {c}";
					}
				}
				input = string.Join(" ", array);
			}
			return input;
		}

		public static string IncDecMatchEvaluator(Match match)
		{
			string text = match.Value.Substring(0, match.Value.Length - 2).Trim();
			string text2 = match.Value.Substring(match.Value.Length - 1);
			return text + " = " + text + " " + text2 + " 1";
		}

		protected static bool ContainsArithmeticAssignment(string s)
		{
			if (s != null)
			{
				if (!s.Contains("+="))
				{
					return s.Contains("-=");
				}
				return true;
			}
			return false;
		}

		protected virtual void ConvertLocalizableText(DialogueEntry entry, string baseFieldTitle, ArticyData.LocalizableText localizableText, bool replaceNewlines = false)
		{
			if (entry == null)
			{
				return;
			}
			string defaultText = localizableText.DefaultText;
			if (!string.IsNullOrEmpty(defaultText))
			{
				Field.SetValue(entry.fields, baseFieldTitle, defaultText);
			}
			foreach (KeyValuePair<string, string> item in localizableText.localizedString)
			{
				if (string.IsNullOrEmpty(item.Key))
				{
					Field.SetValue(entry.fields, baseFieldTitle, RemoveFormattingTags(item.Value, replaceNewlines), FieldType.Text);
					continue;
				}
				string title = (string.Equals("Dialogue Text", baseFieldTitle) ? item.Key : $"{baseFieldTitle} {item.Key}");
				Field.SetValue(entry.fields, title, RemoveFormattingTags(item.Value, replaceNewlines), FieldType.Localization);
			}
		}

		protected virtual void ConvertLocalizableText(List<Field> fields, string baseFieldTitle, ArticyData.LocalizableText localizableText)
		{
			foreach (KeyValuePair<string, string> item in localizableText.localizedString)
			{
				if (string.IsNullOrEmpty(item.Key))
				{
					Field.SetValue(fields, baseFieldTitle, RemoveFormattingTags(item.Value), FieldType.Text);
					continue;
				}
				string title = (string.Equals("Dialogue Text", baseFieldTitle) ? item.Key : $"{baseFieldTitle} {item.Key}");
				Field.SetValue(fields, title, RemoveFormattingTags(item.Value), FieldType.Localization);
			}
		}

		protected virtual string RemoveFormattingTags(string s, bool replaceNewlines = false)
		{
			if (string.IsNullOrEmpty(s))
			{
				return s;
			}
			if (replaceNewlines && s.Contains("\\n"))
			{
				s = s.Replace("\\n", "\n");
			}
			if (s.Contains("font-size"))
			{
				return new Regex("{font-size:[0-9]+pt;}").Replace(s, string.Empty);
			}
			return s;
		}

		protected static void SetConversationStartCutsceneToNone(Conversation conversation)
		{
			DialogueEntry firstDialogueEntry = conversation.GetFirstDialogueEntry();
			if (firstDialogueEntry == null)
			{
				Debug.LogWarning("Dialogue System: Conversation '" + conversation.Title + "' doesn't have a START dialogue entry.");
			}
			else if (string.IsNullOrEmpty(firstDialogueEntry.currentSequence))
			{
				firstDialogueEntry.currentSequence = "Continue()";
			}
		}

		protected virtual Conversation FindConversationByArticyId(string articyId)
		{
			foreach (Conversation conversation in database.conversations)
			{
				if (string.Equals(Field.LookupValue(conversation.fields, "Articy Id"), articyId))
				{
					return conversation;
				}
			}
			return null;
		}

		protected virtual DialogueEntry FindDialogueEntryByArticyId(Conversation conversation, string articyId)
		{
			if (conversation == null)
			{
				return null;
			}
			if (entriesByArticyId.ContainsKey(articyId))
			{
				List<DialogueEntry> list = entriesByArticyId[articyId];
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].conversationID == conversation.id)
					{
						return list[i];
					}
				}
			}
			foreach (DialogueEntry dialogueEntry in conversation.dialogueEntries)
			{
				if (string.Equals(Field.LookupValue(dialogueEntry.fields, "Articy Id"), articyId))
				{
					return dialogueEntry;
				}
			}
			return null;
		}

		protected virtual DialogueEntry FindDialogueEntryByArticyId(string articyId)
		{
			if (entriesByArticyId.ContainsKey(articyId))
			{
				List<DialogueEntry> list = entriesByArticyId[articyId];
				if (list.Count > 0)
				{
					return list[0];
				}
			}
			return null;
		}

		protected virtual List<DialogueEntry> FindAllDialogueEntriesByArticyId(string articyId)
		{
			if (entriesByArticyId.ContainsKey(articyId))
			{
				return entriesByArticyId[articyId];
			}
			return new List<DialogueEntry>();
		}

		protected virtual ArticyData.FlowFragment FindFlowFragment(string articyId)
		{
			foreach (ArticyData.FlowFragment value in articyData.flowFragments.Values)
			{
				if (prefs.ConversionSettings.GetConversionSetting(value.id).Include && string.Equals(value.id, articyId))
				{
					return value;
				}
			}
			return null;
		}

		protected virtual Actor FindActorByArticyId(string articyId)
		{
			foreach (Actor actor in database.actors)
			{
				if (string.Equals(actor.LookupValue("Articy Id"), articyId))
				{
					return actor;
				}
			}
			return null;
		}

		protected virtual Actor FindActorByTechnicalName(string technicalName)
		{
			foreach (Actor actor in database.actors)
			{
				if (string.Equals(actor.LookupValue("Technical Name"), technicalName))
				{
					return actor;
				}
			}
			return null;
		}

		protected virtual Actor FindActorByDisplayName(string displayName)
		{
			foreach (Actor actor in database.actors)
			{
				if (string.Equals(actor.Name, displayName))
				{
					return actor;
				}
			}
			return null;
		}

		protected virtual int FindActorIdFromArticyDialogue(ArticyData.Dialogue articyDialogue, int index, int defaultActorID)
		{
			Actor actor = null;
			if (0 <= index && index < articyDialogue.references.Count)
			{
				actor = FindActorByArticyId(articyDialogue.references[index]);
			}
			if (actor == null)
			{
				if (!prefs.UseDefaultActorsIfNoneAssignedToDialogue)
				{
					return -1;
				}
				return defaultActorID;
			}
			return actor.id;
		}

		protected virtual void SplitPipesIntoEntries()
		{
			foreach (Conversation conversation in database.conversations)
			{
				conversation.SplitPipesIntoEntries(putEndSequenceOnLastSplit: true, prefs.TrimWhitespace, "Articy Id");
			}
		}

		protected virtual void SortAllLinksByPosition()
		{
			foreach (Conversation conversation in database.conversations)
			{
				SortLinksByPosition(conversation);
			}
		}

		protected virtual void SortLinksByPosition(Conversation conversation)
		{
			foreach (DialogueEntry entry in conversation.dialogueEntries)
			{
				entry.outgoingLinks.Sort(delegate(Link A, Link B)
				{
					if (A.destinationConversationID != B.destinationConversationID)
					{
						DialogueEntry dialogueEntry = database.GetDialogueEntry(A);
						DialogueEntry dialogueEntry2 = database.GetDialogueEntry(B);
						if (dialogueEntry == null || dialogueEntry2 == null)
						{
							Debug.LogWarning("Dialogue System: Unexpected error sorting links by position. destA=" + ((dialogueEntry == null) ? "null" : dialogueEntry.ToString()) + " (" + A.destinationConversationID + ":" + A.destinationDialogueID + "), destB=" + ((dialogueEntry2 == null) ? "null" : dialogueEntry2.ToString()) + " (" + B.destinationConversationID + ":" + B.destinationDialogueID + ") in conversation '" + conversation.Title + "' entry " + entry.id + ".");
						}
						if (dialogueEntry != null && dialogueEntry2 != null)
						{
							return dialogueEntry.canvasRect.y.CompareTo(dialogueEntry2.canvasRect.y);
						}
						return A.destinationDialogueID.CompareTo(B.destinationDialogueID);
					}
					DialogueEntry dialogueEntry3 = conversation.GetDialogueEntry(A.destinationDialogueID);
					DialogueEntry dialogueEntry4 = conversation.GetDialogueEntry(B.destinationDialogueID);
					if (dialogueEntry3 == null || dialogueEntry4 == null)
					{
						Debug.LogWarning("Dialogue System: Unexpected error sorting links by position. destA=" + ((dialogueEntry3 == null) ? "null" : dialogueEntry3.ToString()) + " (" + A.destinationConversationID + ":" + A.destinationDialogueID + "), destB=" + ((dialogueEntry4 == null) ? "null" : dialogueEntry4.ToString()) + " (" + B.destinationConversationID + ":" + B.destinationDialogueID + ") in conversation '" + conversation.Title + "' entry " + entry.id + ".");
					}
					return (dialogueEntry3 != null && dialogueEntry4 != null) ? dialogueEntry3.canvasRect.y.CompareTo(dialogueEntry4.canvasRect.y) : A.destinationDialogueID.CompareTo(B.destinationDialogueID);
				});
			}
			foreach (DialogueEntry dialogueEntry5 in conversation.dialogueEntries)
			{
				dialogueEntry5.canvasRect = new Rect(0f, 0f, 160f, 30f);
			}
		}

		protected virtual void RedirectLinkbacksToStartToLinkOutFromStart()
		{
			foreach (Conversation conversation in database.conversations)
			{
				DialogueEntry firstDialogueEntry = conversation.GetFirstDialogueEntry();
				if (firstDialogueEntry == null)
				{
					continue;
				}
				Link link = firstDialogueEntry.outgoingLinks.Find((Link x) => x.destinationConversationID != conversation.id);
				if (link != null)
				{
					firstDialogueEntry.outgoingLinks.Remove(link);
				}
				foreach (DialogueEntry dialogueEntry in conversation.dialogueEntries)
				{
					if (dialogueEntry == firstDialogueEntry)
					{
						continue;
					}
					for (int num = dialogueEntry.outgoingLinks.Count - 1; num >= 0; num--)
					{
						Link link2 = dialogueEntry.outgoingLinks[num];
						if (link2.destinationConversationID == conversation.id && link2.destinationDialogueID == firstDialogueEntry.id)
						{
							if (link == null)
							{
								dialogueEntry.outgoingLinks.RemoveAt(num);
							}
							else
							{
								link2.destinationConversationID = link.destinationConversationID;
								link2.destinationDialogueID = link.destinationDialogueID;
							}
						}
					}
				}
			}
		}

		protected virtual bool DoesEntryLinkOutsideConversation(DialogueEntry entry)
		{
			if (entry == null)
			{
				return false;
			}
			foreach (Link outgoingLink in entry.outgoingLinks)
			{
				if (outgoingLink.destinationConversationID != entry.conversationID)
				{
					return true;
				}
			}
			return false;
		}

		protected virtual void ConvertVoiceOverProperties()
		{
			foreach (Conversation conversation in database.conversations)
			{
				foreach (DialogueEntry dialogueEntry in conversation.dialogueEntries)
				{
					ConvertVoiceOverProperty(dialogueEntry);
				}
			}
		}

		protected virtual void ConvertVoiceOverProperty(DialogueEntry entry)
		{
			if (entry == null)
			{
				return;
			}
			Field field = Field.Lookup(entry.fields, prefs.VoiceOverProperty);
			if (field != null)
			{
				string value = field.value;
				ArticyData.Asset asset = (articyData.assets.ContainsKey(value) ? articyData.assets[value] : null);
				if (asset == null)
				{
					Debug.LogWarning("Dialogue System: Can't find voice-over asset with ID " + value + " for dialogue entry [" + entry.conversationID + ":" + entry.id + "]: '" + entry.currentDialogueText + "'.");
				}
				else
				{
					entry.fields.Remove(field);
					entry.fields.Add(new Field("VoiceOverFile", Path.GetFileNameWithoutExtension(asset.assetFilename), FieldType.Text));
				}
			}
		}

		protected virtual void FindPortraitTextureInResources(Actor actor)
		{
			if (actor == null || actor.portrait != null)
			{
				return;
			}
			string textureName = actor.textureName;
			if (!string.IsNullOrEmpty(textureName))
			{
				actor.portrait = LoadTexture(textureName);
			}
			string text = actor.LookupValue("SUBTABLE__AlternatePortraits");
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			string[] array = text.Split(';');
			foreach (string key in array)
			{
				if (articyData.assets.ContainsKey(key))
				{
					Texture2D texture2D = LoadTexture(articyData.assets[key].displayName.DefaultText);
					if (texture2D != null)
					{
						actor.alternatePortraits.Add(texture2D);
					}
				}
			}
		}

		protected virtual Texture2D LoadTexture(string originalPath)
		{
			string text = Path.GetFileNameWithoutExtension(originalPath).Replace('\\', '/');
			if (Application.isPlaying)
			{
				return DialogueManager.LoadAsset(text, typeof(Texture2D)) as Texture2D;
			}
			return Resources.Load(text, typeof(Texture2D)) as Texture2D;
		}

		protected virtual void ConvertEmVarSet()
		{
			for (int i = 0; i < 4; i++)
			{
				ConvertEmVars(prefs.emVarSet.emVars[i], database.emphasisSettings[i]);
			}
		}

		protected virtual void ConvertEmVars(ArticyEmVars emVars, EmphasisSetting emSetting)
		{
			if (emVars != null && emSetting != null)
			{
				Variable emVar = GetEmVar(emVars.color);
				Variable emVar2 = GetEmVar(emVars.bold);
				Variable emVar3 = GetEmVar(emVars.italic);
				Variable emVar4 = GetEmVar(emVars.underline);
				emSetting.color = ((emVar != null) ? Tools.WebColor(emVar.InitialValue) : Color.white);
				emSetting.bold = emVar2?.InitialBoolValue ?? false;
				emSetting.italic = emVar3?.InitialBoolValue ?? false;
				emSetting.underline = emVar4?.InitialBoolValue ?? false;
			}
		}

		protected virtual Variable GetEmVar(string variableName)
		{
			if (!string.IsNullOrEmpty(variableName))
			{
				return database.GetVariable(variableName);
			}
			return null;
		}

		static ArticyConverter()
		{
			ArticyConverter.onProgressCallback = delegate
			{
			};
			fullVariableNames = new List<string>();
			SpecialFieldTitles = new List<string>(new string[19]
			{
				"Name", "Display Name", "IsPlayer", "Current Portrait", "Is Item", "Group", "Description", "Success Description", "Failure Description", "Entry Count",
				"Title", "Actor", "Conversant", "Priority", "Sequence", "Response Menu Sequence", "VoiceOverFile", "Dialogue Text", "Menu Text"
			});
			SpecialFieldTitleStarters = new List<string>(new string[1] { "Entry " });
		}
	}
}
