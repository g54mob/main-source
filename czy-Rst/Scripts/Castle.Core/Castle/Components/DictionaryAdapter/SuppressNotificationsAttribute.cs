using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class SuppressNotificationsAttribute : DictionaryBehaviorAttribute, IPropertyDescriptorInitializer, IDictionaryBehavior
	{
		public void Initialize(PropertyDescriptor propertyDescriptor, object[] behaviors)
		{
			propertyDescriptor.SuppressNotifications = true;
		}
	}
}
