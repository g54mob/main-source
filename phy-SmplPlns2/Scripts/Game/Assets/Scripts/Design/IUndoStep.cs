namespace Assets.Scripts.Design
{
	public interface IUndoStep
	{
		bool IsHead { get; set; }

		bool DeepEquals(IUndoStep undoStep);
	}
}
