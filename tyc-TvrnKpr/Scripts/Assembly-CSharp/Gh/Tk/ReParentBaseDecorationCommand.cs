using System.Collections.Generic;

namespace Gh.Tk
{
	public abstract class ReParentBaseDecorationCommand : UndoRedoCommandWithState
	{
		protected readonly EntityObject[] Eos;

		protected readonly Dictionary<EntityObject, EntityObject> OriginalParents;

		protected readonly GameObjectX Gox;

		protected ReParentBaseDecorationCommand(EntityObject[] eos)
		{
		}
	}
}
