namespace NoesisApp
{
	public class BehaviorCollection : AttachableCollection<Behavior>
	{
		public new BehaviorCollection Clone()
		{
			return null;
		}

		public new BehaviorCollection CloneCurrentValue()
		{
			return null;
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetaching()
		{
		}

		protected override void ItemAdded(Behavior item)
		{
		}

		protected override void ItemRemoved(Behavior item)
		{
		}
	}
}
