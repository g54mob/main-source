namespace Gh.Tk
{
	public class UnGroupDecorationCommand : ReParentBaseDecorationCommand
	{
		private readonly EntityObject _oldGroup;

		private readonly EntityObject _oldGroupParent;

		public UnGroupDecorationCommand(EntityObject eo)
			: base(null)
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
	}
}
