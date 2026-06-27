using System.Collections.Generic;
using UnityEngine;

namespace Restory.UserInterface.HelpActions.Sorters
{
	public abstract class GUI_BaseHelpActionButtonSorterMonoBehaviour : MonoBehaviour, IHelpActionButtonSorter
	{
		public abstract void Sort(IHelpActionButtonsView buttonsView, List<HelpAction> buttons);
	}
}
