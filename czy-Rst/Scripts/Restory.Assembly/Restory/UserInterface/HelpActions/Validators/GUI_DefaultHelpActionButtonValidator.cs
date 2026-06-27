using System.Linq;
using UnityEngine;

namespace Restory.UserInterface.HelpActions.Validators
{
	public sealed class GUI_DefaultHelpActionButtonValidator : IHelpActionButtonValidator
	{
		public bool ValidateButton(IHelpActionButtonsView buttonsView, GameObject parentActionButton, HelpAction actionButton)
		{
			return !buttonsView.Buttons.Contains(actionButton);
		}
	}
}
