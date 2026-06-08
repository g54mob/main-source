using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
	public class MultiLevelEditAttribute : DictionaryBehaviorAttribute, IDictionaryInitializer, IDictionaryBehavior
	{
		public void Initialize(IDictionaryAdapter dictionaryAdapter, object[] behaviors)
		{
			dictionaryAdapter.SupportsMultiLevelEdit = true;
		}
	}
}
