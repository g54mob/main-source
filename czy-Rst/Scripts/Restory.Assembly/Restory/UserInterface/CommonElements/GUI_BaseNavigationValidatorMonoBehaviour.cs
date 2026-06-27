using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public abstract class GUI_BaseNavigationValidatorMonoBehaviour : MonoBehaviour, INavigationValidator
	{
		public abstract GUI_BaseNavigation ValidateNavigation(GUI_BaseNavigation navigation);
	}
}
