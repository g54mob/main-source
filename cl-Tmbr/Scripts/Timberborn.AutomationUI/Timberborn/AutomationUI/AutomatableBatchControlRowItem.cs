using System;
using Timberborn.Automation;
using Timberborn.BatchControl;
using Timberborn.CoreUI;
using UnityEngine.UIElements;

namespace Timberborn.AutomationUI
{
	internal class AutomatableBatchControlRowItem : IBatchControlRowItem, IClearableBatchControlRowItem
	{
		private readonly Automatable _automatable;

		private readonly AutomationStateIcon _automationStateIcon;

		public VisualElement Root { get; }

		private AutomatableBatchControlRowItem(VisualElement root, Automatable automatable, AutomationStateIcon automationStateIcon)
		{
			Root = root;
			_automatable = automatable;
			_automationStateIcon = automationStateIcon;
		}

		public static AutomatableBatchControlRowItem Create(VisualElement root, Automatable automatable, AutomationStateIcon automationStateIcon)
		{
			AutomatableBatchControlRowItem automatableBatchControlRowItem = new AutomatableBatchControlRowItem(root, automatable, automationStateIcon);
			automatable.InputStateChanged += automatableBatchControlRowItem.OnAutomatableInputStateChanged;
			automatableBatchControlRowItem.UpdateItemState();
			return automatableBatchControlRowItem;
		}

		public void ClearRowItem()
		{
			_automatable.InputStateChanged -= OnAutomatableInputStateChanged;
		}

		private void OnAutomatableInputStateChanged(object sender, EventArgs e)
		{
			UpdateItemState();
		}

		private void UpdateItemState()
		{
			if (_automatable.IsAutomated)
			{
				Root.ToggleDisplayStyle(visible: true);
				_automationStateIcon.Update();
			}
			else
			{
				Root.ToggleDisplayStyle(visible: false);
			}
		}
	}
}
