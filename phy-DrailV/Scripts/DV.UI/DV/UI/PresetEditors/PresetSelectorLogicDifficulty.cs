using DV.Scenarios.Common;

namespace DV.UI.PresetEditors
{
	public class PresetSelectorLogicDifficulty : PresetSelectorLogic<IDifficulty>
	{
		internal const string _LOC_SAVE_OR_REVERT_PROMPT = "scenario/save_or_revert_difficulty";

		protected override string LOC_NO_ELEMENTS => "difficulty/difficulty_selector_no_difficulties";

		protected override string LOC_SAVE_OR_REVERT_PROMPT => "scenario/save_or_revert_difficulty";

		protected override string ProcessName(IDifficulty thing)
		{
			return thing.ToLocalizedString();
		}
	}
}
