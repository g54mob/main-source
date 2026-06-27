using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public abstract class GUI_BaseNavigationFinderMonoBehaviour : MonoBehaviour, INavigationFinder
	{
		public abstract GUI_BaseNavigation FindSelectable(GUI_BaseNavigation center, Vector3 dir, bool wrapAround);
	}
}
