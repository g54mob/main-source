using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.UserInterface.HelpActions
{
	public class HelpActionButtonsHolder : MonoBehaviour
	{
		[SerializeField]
		private List<HelpAction> actionButtons = new List<HelpAction>();

		public IReadOnlyCollection<HelpAction> ActionButtons => actionButtons;

		public event Action<HelpAction> ActionButtonAdded;

		public event Action<HelpAction> ActionButtonRemoved;

		public bool Contains(HelpAction helpActionButton)
		{
			return actionButtons.Contains(helpActionButton);
		}

		public void AddRange(IReadOnlyCollection<HelpAction> helpActionButtons)
		{
			foreach (HelpAction helpActionButton in helpActionButtons)
			{
				Add(helpActionButton);
			}
		}

		public void Add(HelpAction helpActionButton)
		{
			if (!actionButtons.Contains(helpActionButton))
			{
				actionButtons.Add(helpActionButton);
				this.ActionButtonAdded?.Invoke(helpActionButton);
			}
		}

		public void RemoveRange(IReadOnlyCollection<HelpAction> helpActionButtons)
		{
			foreach (HelpAction helpActionButton in helpActionButtons)
			{
				Remove(helpActionButton);
			}
		}

		public void Remove(HelpAction helpActionButton)
		{
			if (actionButtons.Remove(helpActionButton))
			{
				this.ActionButtonRemoved?.Invoke(helpActionButton);
			}
		}

		public HelpAction Get(HelpActionObject helpActionButtonObject)
		{
			return actionButtons.Find((HelpAction x) => x.Button == helpActionButtonObject);
		}

		public bool TryGet(HelpActionObject helpActionButtonObject, out HelpAction helpAction)
		{
			int num = actionButtons.FindIndex((HelpAction x) => x.Button == helpActionButtonObject);
			if (num == -1)
			{
				helpAction = null;
				return false;
			}
			helpAction = actionButtons[num];
			return true;
		}

		public void Clear()
		{
			foreach (HelpAction actionButton in actionButtons)
			{
				this.ActionButtonRemoved?.Invoke(actionButton);
			}
			actionButtons.Clear();
		}
	}
}
