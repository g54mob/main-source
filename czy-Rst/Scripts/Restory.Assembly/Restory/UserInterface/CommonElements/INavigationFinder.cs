using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public interface INavigationFinder
	{
		GUI_BaseNavigation FindSelectable(GUI_BaseNavigation current, Vector3 dir, bool wrapAround);
	}
}
