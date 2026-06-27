using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public abstract class GUI_BaseNavigationValidatorSO : ScriptableObject, INavigationValidator
	{
		public abstract GUI_BaseNavigation ValidateNavigation(GUI_BaseNavigation navigation);
	}
}
