using DV.Scenarios.Common;

namespace DV.UI.PresetEditors
{
	public class PresetSelectorLogicTrain : PresetSelectorLogic<ITrain>
	{
		internal const string _LOC_SAVE_OR_REVERT_PROMPT = "scenario/save_or_revert_train";

		protected override string LOC_NO_ELEMENTS => "scenario/train_selector_no_trains";

		protected override string LOC_SAVE_OR_REVERT_PROMPT => "scenario/save_or_revert_train";

		protected override string ProcessName(ITrain thing)
		{
			return thing.ToLocalizedString();
		}
	}
}
