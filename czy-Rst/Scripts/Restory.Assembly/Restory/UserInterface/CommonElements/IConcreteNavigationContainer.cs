using System.Collections.Generic;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public interface IConcreteNavigationContainer
	{
		ConcreteNavigation OutsideNavigation { get; set; }

		GUI_ConcreteNavigation GetFirstChildNavigation();

		GUI_ConcreteNavigation GetLastChildNavigation();

		IEnumerable<GUI_ConcreteNavigation> GetChildNavigations();

		GUI_ConcreteNavigation GetLeftChildNavigation()
		{
			return null;
		}

		GUI_ConcreteNavigation GetRightChildNavigation()
		{
			return null;
		}

		GUI_ConcreteNavigation GetTopChildNavigation()
		{
			return null;
		}

		GUI_ConcreteNavigation GetBotChildNavigation()
		{
			return null;
		}

		GUI_ConcreteNavigation FindNavigation(GUI_ConcreteNavigation center, Vector3 direction)
		{
			return null;
		}
	}
}
