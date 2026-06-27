using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public abstract class GUI_BaseNavigationFinderSO : ScriptableObject, INavigationFinder
	{
		public abstract GUI_BaseNavigation FindSelectable(GUI_BaseNavigation center, Vector3 dir, bool wrapAround);
	}
}
