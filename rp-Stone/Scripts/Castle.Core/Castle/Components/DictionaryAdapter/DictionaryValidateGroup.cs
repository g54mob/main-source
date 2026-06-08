using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Castle.Components.DictionaryAdapter
{
	public class DictionaryValidateGroup : IDictionaryValidate, IDataErrorInfo, INotifyPropertyChanged, IDisposable
	{
		private readonly object[] groups;

		private readonly IDictionaryAdapter adapter;

		private readonly string[] propertyNames;

		private readonly PropertyChangedEventHandler propertyChanged;

		public bool CanValidate
		{
			get
			{
				return adapter.CanValidate;
			}
			set
			{
				adapter.CanValidate = value;
			}
		}

		public bool IsValid => string.IsNullOrEmpty(Error);

		public string Error => string.Join(Environment.NewLine, (from propertyName in propertyNames
			select adapter[propertyName] into errors
			where !string.IsNullOrEmpty(errors)
			select errors).ToArray());

		public string this[string columnName]
		{
			get
			{
				if (Array.IndexOf(propertyNames, columnName) >= 0)
				{
					return adapter[columnName];
				}
				return string.Empty;
			}
		}

		public IEnumerable<IDictionaryValidator> Validators => adapter.Validators;

		public event PropertyChangedEventHandler PropertyChanged;

		public DictionaryValidateGroup(object[] groups, IDictionaryAdapter adapter)
		{
			this.groups = groups;
			this.adapter = adapter;
			propertyNames = (from property in this.adapter.This.Properties.Values
				from groupings in property.Annotations.OfType<GroupAttribute>()
				where this.groups.Intersect(groupings.Group).Any()
				select property.PropertyName).Distinct().ToArray();
			if (propertyNames.Length == 0 || !adapter.CanNotify)
			{
				return;
			}
			propertyChanged = (PropertyChangedEventHandler)Delegate.Combine(propertyChanged, (PropertyChangedEventHandler)delegate(object sender, PropertyChangedEventArgs args)
			{
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, args);
				}
			});
			this.adapter.PropertyChanged += propertyChanged;
		}

		public DictionaryValidateGroup ValidateGroups(params object[] groups)
		{
			groups = this.groups.Union(groups).ToArray();
			return new DictionaryValidateGroup(groups, adapter);
		}

		public void AddValidator(IDictionaryValidator validator)
		{
			throw new NotSupportedException();
		}

		public void Dispose()
		{
			adapter.PropertyChanged -= propertyChanged;
		}
	}
}
