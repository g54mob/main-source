namespace EnhancedScrollerDemos.SelectionDemo
{
	public class InventoryData
	{
		public string itemName;

		public int itemCost;

		public int itemDamage;

		public int itemDefense;

		public int itemWeight;

		public string itemDescription;

		public string spritePath;

		public SelectedChangedDelegate selectedChanged;

		private bool _selected;

		public bool Selected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}
	}
}
