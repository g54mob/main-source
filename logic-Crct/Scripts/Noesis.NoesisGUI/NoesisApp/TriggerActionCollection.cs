namespace NoesisApp
{
	public class TriggerActionCollection : AttachableCollection<TriggerAction>
	{
		public new TriggerActionCollection Clone()
		{
			return null;
		}

		public new TriggerActionCollection CloneCurrentValue()
		{
			return null;
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetaching()
		{
		}

		protected override void ItemAdded(TriggerAction item)
		{
		}

		protected override void ItemRemoved(TriggerAction item)
		{
		}
	}
}
