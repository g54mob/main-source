namespace TH20
{
	public interface IDataViewMode
	{
		void Enable(DataViewManager.Mode mode);

		void Disable();

		void Update();
	}
}
