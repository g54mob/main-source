namespace Restory.Data.SaveLoad
{
	public interface ISaveableComponentReader
	{
		void RestoreState(object state);
	}
}
