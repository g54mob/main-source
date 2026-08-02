using System;

namespace GRP
{
	public class UndoStep
	{
		public string name;

		public Action undo;

		public Action redo;
	}
}
