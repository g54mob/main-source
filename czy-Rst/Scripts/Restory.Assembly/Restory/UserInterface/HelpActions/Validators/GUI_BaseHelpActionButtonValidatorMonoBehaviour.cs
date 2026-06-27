using UnityEngine;

namespace Restory.UserInterface.HelpActions.Validators
{
	public abstract class GUI_BaseHelpActionButtonValidatorMonoBehaviour : MonoBehaviour, IHelpActionButtonValidator
	{
		public abstract bool ValidateButton(IHelpActionButtonsView buttonsView, GameObject parentActionButton, HelpAction actionButton);
	}
}
