namespace Gh.Tk
{
	public interface ICustomSaveState
	{
		void SaveState(IDataStore data);

		void RestoreState(IDataStore data);
	}
}
