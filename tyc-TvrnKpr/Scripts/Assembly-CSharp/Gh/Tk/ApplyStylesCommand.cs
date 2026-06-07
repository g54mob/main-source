using System.Collections.Generic;

namespace Gh.Tk
{
	public class ApplyStylesCommand : IUndoRedoCommand
	{
		private readonly List<string> _styleIds;

		private List<string> _origStyleIds;

		private readonly bool _applyCost;

		private readonly EntityObject[] _eos;

		public ApplyStylesCommand(List<string> styleIds, bool applyCost, EntityObject[] eos)
		{
		}

		public void Execute()
		{
		}

		private void ApplyCost(EntityObject eo, string styleId)
		{
		}

		public void Undo()
		{
		}
	}
}
