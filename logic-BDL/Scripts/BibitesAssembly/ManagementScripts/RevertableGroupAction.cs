using System.Collections.Generic;

namespace ManagementScripts
{
	public class RevertableGroupAction : IRevertableAction
	{
		private List<IRevertableAction> actions;

		public RevertableGroupAction(List<IRevertableAction> groupActions = null)
		{
			actions = groupActions ?? new List<IRevertableAction>();
		}

		public void Add(IRevertableAction action)
		{
			actions.Add(action);
		}

		public void Revert()
		{
			foreach (IRevertableAction action in actions)
			{
				action.Revert();
			}
		}

		public void ReDo()
		{
			foreach (IRevertableAction action in actions)
			{
				action.ReDo();
			}
		}
	}
}
