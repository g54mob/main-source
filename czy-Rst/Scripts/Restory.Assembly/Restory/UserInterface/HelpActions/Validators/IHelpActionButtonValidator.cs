using UnityEngine;

namespace Restory.UserInterface.HelpActions.Validators
{
	public interface IHelpActionButtonValidator
	{
		bool ValidateButton(IHelpActionButtonsView buttonsView, GameObject parentActionButton, HelpAction actionButton);
	}
}
