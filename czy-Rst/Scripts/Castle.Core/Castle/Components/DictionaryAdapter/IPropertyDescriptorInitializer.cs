namespace Castle.Components.DictionaryAdapter
{
	public interface IPropertyDescriptorInitializer : IDictionaryBehavior
	{
		void Initialize(PropertyDescriptor propertyDescriptor, object[] behaviors);
	}
}
