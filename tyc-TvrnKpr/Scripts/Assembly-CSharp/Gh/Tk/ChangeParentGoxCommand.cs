namespace Gh.Tk
{
	public class ChangeParentGoxCommand : UndoRedoCommandWithState
	{
		private readonly GameObjectX _targetGox;

		private readonly EntityObject[] _eos;

		private readonly GameObjectX[] _sourceGoxs;

		public ChangeParentGoxCommand(GameObjectX targetGox, EntityObject[] eos)
		{
		}

		protected override void ExecuteInternal()
		{
		}

		protected override void UndoInternal()
		{
		}

		protected override void CleanUpWhenExecuted()
		{
		}

		protected override void CleanUpWhenUndone()
		{
		}
	}
}
