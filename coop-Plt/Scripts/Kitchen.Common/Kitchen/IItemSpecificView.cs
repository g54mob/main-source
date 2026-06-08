using KitchenData;

namespace Kitchen
{
	public interface IItemSpecificView
	{
		void PerformUpdate(int item_id, ItemList components, bool is_order = false);
	}
}
