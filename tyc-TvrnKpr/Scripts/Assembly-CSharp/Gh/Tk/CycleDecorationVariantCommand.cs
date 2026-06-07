namespace Gh.Tk
{
	public class CycleDecorationVariantCommand : UndoRedoCommandWithState
	{
		private readonly EntityObject _originalEos;

		private EntityObject _newEos;

		private readonly int _direction;

		private EntityObject _parent;

		private GameObjectX _gox;

		public CycleDecorationVariantCommand(EntityObject originalEos, int direction)
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

		protected override void CleanUpWhenExecuted()
		{
		}
	}
}
