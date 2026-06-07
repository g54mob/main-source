using System.Collections.Generic;

namespace Gh.Tk
{
	public class DeleteDecorationCommand : UndoRedoCommandWithState
	{
		private readonly EntityObject[] _eos;

		private readonly List<Tuple<GameObjectX, EntityObject>> _parents;

		private readonly GameObjectX _gox;

		private readonly CustomDecoProp _decoProp;

		public DeleteDecorationCommand(EntityObject[] eos)
		{
		}

		protected override void ExecuteInternal()
		{
		}

		private EntityObject GetNextValidParent(IEnumerable<EntityObject> parents)
		{
			return null;
		}

		protected override void UndoInternal()
		{
		}

		protected override void CleanUpWhenExecuted()
		{
		}
	}
}
