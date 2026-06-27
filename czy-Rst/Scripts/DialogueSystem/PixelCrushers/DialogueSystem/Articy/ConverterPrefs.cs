using System.Text;

namespace PixelCrushers.DialogueSystem.Articy
{
	public class ConverterPrefs
	{
		public enum FlowFragmentModes
		{
			NestedConversationGroups = 0,
			ConversationGroups = 1,
			Quests = 2,
			Ignore = 3
		}

		public enum StageDirModes
		{
			Sequences = 0,
			Nothing = 1,
			Description = 2
		}

		public enum ConvertDropdownsModes
		{
			Int = 0,
			TechnicalName = 1,
			DisplayName = 2
		}

		public enum ConvertSlotsModes
		{
			DisplayName = 0,
			ID = 1,
			TechnicalName = 2
		}

		public enum RecursionModes
		{
			Off = 0,
			On = 1
		}

		public enum CodeNodeMode
		{
			RegularEntry = 0,
			GroupEntry = 1
		}

		public ArticyEmVarSet emVarSet = new ArticyEmVarSet();

		public const string DefaultFlowFragmentScript = "OnFlowFragment";

		public const string DefaultVoiceOverProperty = "VoiceOverFile";

		public string ProjectFilename { get; set; }

		public string PortraitFolder { get; set; }

		public bool UseDefaultActorsIfNoneAssignedToDialogue { get; set; }

		public StageDirModes StageDirectionsMode { get; set; }

		public FlowFragmentModes FlowFragmentMode { get; set; }

		public bool CreateConversationsForLooseFlow { get; set; }

		public string OtherScriptFields { get; set; }

		public string DocumentsSubmenu { get; set; }

		public bool ImportDocuments { get; set; }

		public string TextTableDocument { get; set; }

		public string OutputFolder { get; set; }

		public bool Overwrite { get; set; }

		public ConversionSettings ConversionSettings { get; set; }

		public EncodingType EncodingType { get; set; }

		public RecursionModes RecursionMode { get; set; }

		public CodeNodeMode ConvertInstructionsAs { get; set; }

		public ConvertDropdownsModes ConvertDropdownsAs { get; set; }

		public ConvertSlotsModes ConvertSlotsAs { get; set; }

		public bool UseTechnicalNames { get; set; }

		public bool IncludeFeatureNameInFields { get; set; }

		public bool SetDisplayName { get; set; }

		public bool CustomDisplayName { get; set; }

		public bool DirectConversationLinksToEntry1 { get; set; }

		public bool ConvertMarkupToRichText { get; set; }

		public bool SplitTextOnPipes { get; set; }

		public bool TrimWhitespace { get; set; } = true;

		public bool ReorderIDs { get; set; }

		public bool DelayEvaluation { get; set; }

		public string FlowFragmentScript { get; set; }

		public string VoiceOverProperty { get; set; }

		public string LocalizationXlsx { get; set; }

		public Encoding Encoding => EncodingTypeTools.GetEncoding(EncodingType);

		public ConverterPrefs()
		{
			ProjectFilename = string.Empty;
			PortraitFolder = string.Empty;
			UseDefaultActorsIfNoneAssignedToDialogue = true;
			StageDirectionsMode = StageDirModes.Sequences;
			FlowFragmentMode = FlowFragmentModes.ConversationGroups;
			CreateConversationsForLooseFlow = false;
			OtherScriptFields = string.Empty;
			DocumentsSubmenu = string.Empty;
			ImportDocuments = true;
			TextTableDocument = string.Empty;
			OutputFolder = "Assets";
			Overwrite = false;
			ConversionSettings = new ConversionSettings();
			EncodingType = EncodingType.Default;
			RecursionMode = RecursionModes.On;
			ConvertInstructionsAs = CodeNodeMode.RegularEntry;
			ConvertDropdownsAs = ConvertDropdownsModes.Int;
			ConvertSlotsAs = ConvertSlotsModes.DisplayName;
			UseTechnicalNames = false;
			IncludeFeatureNameInFields = false;
			SetDisplayName = false;
			CustomDisplayName = false;
			DirectConversationLinksToEntry1 = false;
			ConvertMarkupToRichText = true;
			SplitTextOnPipes = true;
			TrimWhitespace = true;
			ReorderIDs = false;
			DelayEvaluation = false;
			FlowFragmentScript = "OnFlowFragment";
			VoiceOverProperty = "VoiceOverFile";
			LocalizationXlsx = string.Empty;
		}

		public void ReviewSpecialProperties(ArticyData articyData)
		{
			foreach (ArticyData.Entity value in articyData.entities.Values)
			{
				ConversionSetting conversionSetting = ConversionSettings.GetConversionSetting(value.id);
				if (conversionSetting.Include)
				{
					if (ArticyConverter.HasField(value.features, "IsNPC", mustBeTrue: false))
					{
						conversionSetting.Category = EntityCategory.NPC;
					}
					if (ArticyConverter.HasField(value.features, "IsPlayer", mustBeTrue: true))
					{
						conversionSetting.Category = EntityCategory.Player;
					}
					if (ArticyConverter.HasField(value.features, "IsItem", mustBeTrue: true))
					{
						conversionSetting.Category = EntityCategory.Item;
					}
					if (ArticyConverter.HasField(value.features, "IsQuest", mustBeTrue: true))
					{
						conversionSetting.Category = EntityCategory.Quest;
					}
				}
			}
		}
	}
}
