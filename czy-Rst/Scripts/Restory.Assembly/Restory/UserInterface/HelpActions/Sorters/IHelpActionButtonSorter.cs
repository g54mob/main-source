using System.Collections.Generic;

namespace Restory.UserInterface.HelpActions.Sorters
{
	public interface IHelpActionButtonSorter
	{
		void Sort(IHelpActionButtonsView buttonsView, List<HelpAction> buttons);
	}
}
