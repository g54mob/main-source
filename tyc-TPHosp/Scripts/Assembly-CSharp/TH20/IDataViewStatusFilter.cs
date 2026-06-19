namespace TH20
{
	public interface IDataViewStatusFilter
	{
		bool CanShowStatus(ICursorSelectable selectable);
	}
}
