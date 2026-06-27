using System.Collections.Generic;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_GroupNavigationFinder : INavigationFinder
	{
		[SerializeField]
		private List<GUI_BaseNavigation> navigations;

		public List<GUI_BaseNavigation> Navigations => navigations;

		public GUI_GroupNavigationFinder()
		{
		}

		public GUI_GroupNavigationFinder(IEnumerable<GUI_BaseNavigation> navigations)
		{
			this.navigations = new List<GUI_BaseNavigation>(navigations);
		}

		public GUI_GroupNavigationFinder(params GUI_BaseNavigation[] navigations)
		{
			this.navigations = new List<GUI_BaseNavigation>(navigations);
		}

		public GUI_BaseNavigation FindSelectable(GUI_BaseNavigation center, Vector3 dir, bool wrapAround)
		{
			return GUI_NavigationFinderHelper.FindSelectableFirstOrLast(center, navigations, dir, wrapAround);
		}
	}
}
