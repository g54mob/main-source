namespace Gh.Tk
{
	public class RenameDecorationCommand : UndoRedoCommandWithState
	{
		private readonly EntityObject _eo;

		private readonly string _newName;

		private readonly string _oldName;

		public RenameDecorationCommand(EntityObject eo, string newName)
		{
		}

		protected override void ExecuteInternal()
		{
		}

		protected override void UndoInternal()
		{
		}
	}
}
