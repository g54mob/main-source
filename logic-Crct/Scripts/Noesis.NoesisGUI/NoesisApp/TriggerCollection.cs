namespace NoesisApp
{
	public class TriggerCollection : AttachableCollection<TriggerBase>
	{
		public new TriggerCollection Clone()
		{
			return null;
		}

		public new TriggerCollection CloneCurrentValue()
		{
			return null;
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetaching()
		{
		}

		protected override void ItemAdded(TriggerBase item)
		{
		}

		protected override void ItemRemoved(TriggerBase item)
		{
		}
	}
}
