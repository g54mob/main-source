using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_DefaultNavigationFinder : INavigationFinder
	{
		public GUI_BaseNavigation FindSelectable(GUI_BaseNavigation center, Vector3 dir, bool wrapAround)
		{
			return GUI_NavigationFinderHelper.FindSelectableFirstOrLast(center, GUI_BaseNavigation.AllNavigations, dir, wrapAround);
		}
	}
}
