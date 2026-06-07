namespace Assets.Scripts.Ui
{
	public interface IUndoStep
	{
		bool IsHead { get; set; }

		bool DeepEquals(IUndoStep undoStep);
	}
}
