using System;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryAdapter : IDictionaryEdit, IEditableObject, IRevertibleChangeTracking, IChangeTracking, IDictionaryNotify, INotifyPropertyChanging, INotifyPropertyChanged, IDictionaryValidate, IDataErrorInfo, IDictionaryCreate
	{
		DictionaryAdapterMeta Meta { get; }

		DictionaryAdapterInstance This { get; }

		string GetKey(string propertyName);

		object GetProperty(string propertyName, bool ifExists);

		object ReadProperty(string key);

		T GetPropertyOfType<T>(string propertyName);

		bool SetProperty(string propertyName, ref object value);

		void StoreProperty(PropertyDescriptor property, string key, object value);

		void ClearProperty(PropertyDescriptor property, string key);

		bool ShouldClearProperty(PropertyDescriptor property, object value);

		void CopyTo(IDictionaryAdapter other);

		void CopyTo(IDictionaryAdapter other, Func<PropertyDescriptor, bool> selector);

		T Coerce<T>() where T : class;

		object Coerce(Type type);
	}
}
