namespace Player.Toolbar.Concrete
{
	public readonly struct ToolbarModelSlotData<TItem> : jt<TItem>
	{
		public TItem Item { get; }

		public int SlotIndex { get; }

		public ToolbarModelSlotData(TItem item, int slotIndex)
		{
			Item = default(TItem);
			SlotIndex = 0;
		}
	}
}
