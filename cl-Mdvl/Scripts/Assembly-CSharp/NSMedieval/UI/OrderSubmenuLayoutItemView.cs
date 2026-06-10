using NSEipix.View.UI;

namespace NSMedieval.UI
{
	public class OrderSubmenuLayoutItemView : LayoutGroupItemView
	{
		private readonly int toggleIndex = 1;

		private string id;

		public CustomToggle Toggle => base.GroupItems[toggleIndex].GetComponent<CustomToggle>();

		public string ID => id;

		public void SetId(string id)
		{
			this.id = id;
		}

		public void SetData(string itemId, bool selected)
		{
			SetText(itemId);
			SetToggleWithoutNotify(selected);
		}

		public void SetToggleWithoutNotify(bool value)
		{
			Toggle.SetIsOnWithoutNotify(value);
		}
	}
}
