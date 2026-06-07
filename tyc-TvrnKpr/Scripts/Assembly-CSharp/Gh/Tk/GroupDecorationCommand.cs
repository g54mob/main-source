namespace Gh.Tk
{
	public class GroupDecorationCommand : ReParentBaseDecorationCommand
	{
		private readonly EntityObject _mainObject;

		private EntityObject _newEntityObject;

		private EntityObject _oldParent;

		private GameObjectX _gox;

		public GroupDecorationCommand(EntityObject[] eos)
			: base(null)
		{
		}

		protected override void ExecuteInternal()
		{
		}

		protected override void UndoInternal()
		{
		}

		protected override void CleanUpWhenUndone()
		{
		}
	}
}
