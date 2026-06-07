using UnityEngine.Events;

namespace ManagementScripts
{
	public class RevertableAction : IRevertableAction
	{
		private readonly UnityAction doAction;

		private readonly UnityAction revertAction;

		public RevertableAction(UnityAction toDo, UnityAction toRevert)
		{
			doAction = toDo;
			revertAction = toRevert;
		}

		public void Revert()
		{
			revertAction();
		}

		public void ReDo()
		{
			doAction();
		}
	}
}
