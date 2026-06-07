namespace Gh.Tk
{
	public interface IUndoRedoCommand
	{
		void Execute();

		void Undo();
	}
}
