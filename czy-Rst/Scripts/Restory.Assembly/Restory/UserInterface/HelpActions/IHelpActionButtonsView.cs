using System.Collections.Generic;
using Restory.UserInterface.HelpActions.Sorters;
using Restory.UserInterface.HelpActions.Validators;
using UnityEngine;

namespace Restory.UserInterface.HelpActions
{
	public interface IHelpActionButtonsView
	{
		IReadOnlyList<HelpAction> Buttons { get; }

		IHelpActionButtonValidator Validator { get; set; }

		IHelpActionButtonSorter Sorter { get; set; }

		bool ContainsButton(HelpAction actionButton);

		void AddButtons(GameObject parent, IReadOnlyList<HelpAction> actionButtons);

		bool AddButton(GameObject parent, HelpAction actionButton);

		void RemoveButtons(IReadOnlyList<HelpAction> actionButtons);

		bool RemoveButton(HelpAction actionButton);

		void ClearButtons();
	}
}
