using DV.Scenarios.Common;

namespace DV.UI.PresetEditors
{
	public class PresetSelectorLogicScenario : PresetSelectorLogic<IScenario>
	{
		internal const string _LOC_SAVE_OR_REVERT_PROMPT = "scenario/save_or_revert_scenario";

		protected override string LOC_NO_ELEMENTS => "scenario/scenario_selector_no_scenarios";

		protected override string LOC_SAVE_OR_REVERT_PROMPT => "scenario/save_or_revert_scenario";

		protected override string ProcessName(IScenario thing)
		{
			return thing.ToLocalizedString();
		}
	}
}
