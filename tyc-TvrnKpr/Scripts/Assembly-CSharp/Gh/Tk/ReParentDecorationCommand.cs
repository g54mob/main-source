namespace Gh.Tk
{
	public class ReParentDecorationCommand : ReParentBaseDecorationCommand
	{
		private readonly EntityObject _newParent;

		public ReParentDecorationCommand(EntityObject[] eos, EntityObject newParent)
			: base(null)
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
