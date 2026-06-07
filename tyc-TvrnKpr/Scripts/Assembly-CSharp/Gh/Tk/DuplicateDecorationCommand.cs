using System.Collections.Generic;

namespace Gh.Tk
{
	public class DuplicateDecorationCommand : UndoRedoCommandWithState
	{
		private readonly EntityObject[] _eos;

		private readonly List<Tuple<EntityObject, EntityObject>> _newEosWithParent;

		private GameObjectX _gox;

		public DuplicateDecorationCommand(EntityObject[] eos)
		{
		}

		protected override void ExecuteInternal()
		{
		}

		protected override void UndoInternal()
		{
		}

		private static EntityObject DuplicateEntity(EntityObject entityObject)
		{
			return null;
		}

		protected override void CleanUpWhenUndone()
		{
		}
	}
}
