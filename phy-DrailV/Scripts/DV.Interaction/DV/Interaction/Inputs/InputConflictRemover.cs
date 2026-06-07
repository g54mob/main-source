using System.Collections.Generic;

namespace DV.Interaction.Inputs
{
	public class InputConflictRemover
	{
		private readonly int actionID;

		private List<int> blockedIDs = new List<int>();

		private bool blocked;

		public InputConflictRemover(int actionID)
		{
			this.actionID = actionID;
			InputManager.KeybindingsChanged += Refresh;
			Refresh();
		}

		public void SetBlocked(bool blocked)
		{
			this.blocked = blocked;
			foreach (int blockedID in blockedIDs)
			{
				InputManager.Actions.SetActionDisabled(blockedID, blocked);
			}
		}

		private void Refresh()
		{
			foreach (int blockedID in blockedIDs)
			{
				InputManager.Actions.SetActionDisabled(blockedID, state: false);
			}
			blockedIDs.Clear();
			blockedIDs.AddRange(InputManager.FindActionsThatConflictWith(actionID));
			if (!blocked)
			{
				return;
			}
			foreach (int blockedID2 in blockedIDs)
			{
				InputManager.Actions.SetActionDisabled(blockedID2, state: true);
			}
		}
	}
}
