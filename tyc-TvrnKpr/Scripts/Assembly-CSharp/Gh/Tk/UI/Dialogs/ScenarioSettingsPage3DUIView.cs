using System;
using System.Collections.Generic;
using Gh.Tk.Story.Structure;

namespace Gh.Tk.UI.Dialogs
{
	public class ScenarioSettingsPage3DUIView : TavernSetupPage3DUIView
	{
		protected override void RenderPageInternal()
		{
		}

		private IEnumerable<ScenarioTrait> GetScenarioTraits()
		{
			return null;
		}

		private void AddGameModifierCheckbox(GameSettingsGameModifierAttribute attr, Action<int> setMethod, Func<int> getMethod, AccordionButton3DUIView header, bool isSubgroup)
		{
		}

		private void AddGameModifierSlider(GameSettingsGameModifierAttribute attr, Action<int> setMethod, Func<int> getMethod, AccordionButton3DUIView header, bool isSubgroup)
		{
		}

		private void AddCheatButton(AccordionButton3DUIView setupMainHeader)
		{
		}

		private void AddTavernStartingMoneySlider(AccordionButton3DUIView setupMainHeader)
		{
		}
	}
}
