using AirFishLab.ScrollingList.ContentManagement;

namespace AirFishLab.ScrollingList
{
	public interface IListBank
	{
		IListContent GetListContent(int index);

		int GetContentCount();
	}
}
