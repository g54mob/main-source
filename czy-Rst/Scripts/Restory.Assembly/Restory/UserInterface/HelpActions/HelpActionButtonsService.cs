using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Restory.UserInterface.HelpActions
{
	public class HelpActionButtonsService : SerializedMonoBehaviour
	{
		private HashSet<HelpAction> actionButtons = new HashSet<HelpAction>();

		private Dictionary<HelpAction, GameObject> parents = new Dictionary<HelpAction, GameObject>();

		private List<IHelpActionButtonsView> helpActionButtonsViews = new List<IHelpActionButtonsView>();

		public void AddButtons(GameObject parent, IReadOnlyCollection<HelpAction> helpActionButtons)
		{
			foreach (HelpAction helpActionButton in helpActionButtons)
			{
				AddButton(parent, helpActionButton);
			}
		}

		public bool AddButton(GameObject parent, HelpAction helpActionButton)
		{
			if (actionButtons.Contains(helpActionButton))
			{
				return false;
			}
			actionButtons.Add(helpActionButton);
			parents.Add(helpActionButton, parent);
			foreach (IHelpActionButtonsView helpActionButtonsView in helpActionButtonsViews)
			{
				helpActionButtonsView.AddButton(parent, helpActionButton);
			}
			return true;
		}

		public void RemoveButtons(IReadOnlyCollection<HelpAction> helpActionButtons)
		{
			foreach (HelpAction helpActionButton in helpActionButtons)
			{
				RemoveButton(helpActionButton);
			}
		}

		public bool RemoveButton(HelpAction helpActionButton)
		{
			if (!actionButtons.Remove(helpActionButton))
			{
				return false;
			}
			parents.Remove(helpActionButton);
			foreach (IHelpActionButtonsView helpActionButtonsView in helpActionButtonsViews)
			{
				helpActionButtonsView.RemoveButton(helpActionButton);
			}
			return true;
		}

		public bool AddButtonsView(IHelpActionButtonsView helpActionButtonsView)
		{
			if (helpActionButtonsViews.Contains(helpActionButtonsView))
			{
				return false;
			}
			helpActionButtonsViews.Add(helpActionButtonsView);
			foreach (HelpAction actionButton in actionButtons)
			{
				helpActionButtonsView.AddButton(parents[actionButton], actionButton);
			}
			return true;
		}

		public bool RemoveButtonsView(IHelpActionButtonsView helpActionButtonsView)
		{
			if (!helpActionButtonsViews.Remove(helpActionButtonsView))
			{
				return false;
			}
			helpActionButtonsView.ClearButtons();
			return true;
		}
	}
}
