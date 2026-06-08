using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Castle.Components.DictionaryAdapter
{
	public abstract class DictionaryAdapterBase : IDictionaryCreate, IDictionaryAdapter, IDictionaryEdit, IEditableObject, IRevertibleChangeTracking, IChangeTracking, IDictionaryNotify, INotifyPropertyChanging, INotifyPropertyChanged, IDictionaryValidate, IDataErrorInfo
	{
		private struct Edit
		{
			public readonly PropertyDescriptor Property;

			public object PropertyValue;

			public Edit(PropertyDescriptor property, object propertyValue)
			{
				Property = property;
				PropertyValue = propertyValue;
			}
		}

		private class SuppressEditingScope : IDisposable
		{
			private readonly DictionaryAdapterBase adapter;

			public SuppressEditingScope(DictionaryAdapterBase adapter)
			{
				this.adapter = adapter;
				this.adapter.SuppressEditing();
			}

			public void Dispose()
			{
				adapter.ResumeEditing();
			}
		}

		private class NotificationSuppressionScope : IDisposable
		{
			private readonly DictionaryAdapterBase adapter;

			public NotificationSuppressionScope(DictionaryAdapterBase adapter)
			{
				this.adapter = adapter;
				this.adapter.SuppressNotifications();
			}

			public void Dispose()
			{
				adapter.ResumeNotifications();
			}
		}

		public class TrackPropertyChangeScope : IDisposable
		{
			private readonly DictionaryAdapterBase adapter;

			private readonly PropertyDescriptor property;

			private readonly object existingValue;

			private Dictionary<PropertyDescriptor, object> readOnlyProperties;

			public TrackPropertyChangeScope(DictionaryAdapterBase adapter)
			{
				this.adapter = adapter;
				readOnlyProperties = adapter.This.Properties.Values.Where((PropertyDescriptor pd) => !pd.Property.CanWrite || pd.IsDynamicProperty).ToDictionary((PropertyDescriptor pd) => pd, (PropertyDescriptor pd) => GetEffectivePropertyValue(pd));
			}

			public TrackPropertyChangeScope(DictionaryAdapterBase adapter, PropertyDescriptor property, object existingValue)
				: this(adapter)
			{
				this.property = property;
				this.existingValue = existingValue;
				existingValue = adapter.GetProperty(property.PropertyName, ifExists: true);
			}

			public void Dispose()
			{
				Notify();
			}

			public bool Notify()
			{
				if (readOnlyTrackingScope == this)
				{
					readOnlyTrackingScope = null;
					return NotifyReadonly();
				}
				object effectivePropertyValue = GetEffectivePropertyValue(property);
				if (!NotifyIfChanged(property, existingValue, effectivePropertyValue))
				{
					return false;
				}
				if (readOnlyTrackingScope == null)
				{
					NotifyReadonly();
				}
				return true;
			}

			private bool NotifyReadonly()
			{
				bool flag = false;
				foreach (KeyValuePair<PropertyDescriptor, object> readOnlyProperty in readOnlyProperties)
				{
					PropertyDescriptor key = readOnlyProperty.Key;
					object effectivePropertyValue = GetEffectivePropertyValue(key);
					flag |= NotifyIfChanged(key, readOnlyProperty.Value, effectivePropertyValue);
				}
				adapter.Invalidate();
				return flag;
			}

			private bool NotifyIfChanged(PropertyDescriptor descriptor, object oldValue, object newValue)
			{
				if (object.Equals(oldValue, newValue))
				{
					return false;
				}
				adapter.NotifyPropertyChanged(descriptor, oldValue, newValue);
				return true;
			}

			private object GetEffectivePropertyValue(PropertyDescriptor property)
			{
				object obj = adapter.GetProperty(property.PropertyName, ifExists: true);
				if (obj == null || !property.IsDynamicProperty)
				{
					return obj;
				}
				if (!(obj is IDynamicValue dynamicValue))
				{
					return obj;
				}
				return dynamicValue.GetValue();
			}
		}

		private int suppressEditingCount;

		private Stack<Dictionary<string, Edit>> updates;

		private HashSet<IEditableObject> editDependencies;

		[ThreadStatic]
		private static TrackPropertyChangeScope readOnlyTrackingScope;

		private int suppressNotificationCount;

		private ICollection<IDictionaryValidator> validators;

		public abstract DictionaryAdapterMeta Meta { get; }

		public DictionaryAdapterInstance This { get; private set; }

		public bool CanEdit
		{
			get
			{
				if (suppressEditingCount == 0)
				{
					return updates != null;
				}
				return false;
			}
			set
			{
				updates = (value ? new Stack<Dictionary<string, Edit>>() : null);
			}
		}

		public bool IsEditing
		{
			get
			{
				if (CanEdit && updates != null)
				{
					return updates.Count > 0;
				}
				return false;
			}
		}

		public bool SupportsMultiLevelEdit { get; set; }

		public bool IsChanged
		{
			get
			{
				if (IsEditing && updates.Any((Dictionary<string, Edit> level) => level.Count > 0))
				{
					return true;
				}
				return (from prop in This.Properties.Values
					where typeof(IChangeTracking).IsAssignableFrom(prop.PropertyType)
					select GetProperty(prop.PropertyName, ifExists: true)).Cast<IChangeTracking>().Any((IChangeTracking track) => track?.IsChanged ?? false);
			}
		}

		public bool CanNotify { get; set; }

		public bool ShouldNotify
		{
			get
			{
				if (CanNotify)
				{
					return suppressNotificationCount == 0;
				}
				return false;
			}
		}

		public bool CanValidate { get; set; }

		public bool IsValid
		{
			get
			{
				if (CanValidate && validators != null)
				{
					return !validators.Any((IDictionaryValidator v) => !v.IsValid(this));
				}
				return !CanValidate;
			}
		}

		public string Error
		{
			get
			{
				if (CanValidate && validators != null)
				{
					return string.Join(Environment.NewLine, (from v in validators
						select v.Validate(this) into e
						where !string.IsNullOrEmpty(e)
						select e).ToArray());
				}
				return string.Empty;
			}
		}

		public string this[string columnName]
		{
			get
			{
				if (CanValidate && validators != null && This.Properties.TryGetValue(columnName, out var property))
				{
					return string.Join(Environment.NewLine, (from v in validators
						select v.Validate(this, property) into e
						where !string.IsNullOrEmpty(e)
						select e).ToArray());
				}
				return string.Empty;
			}
		}

		public IEnumerable<IDictionaryValidator> Validators
		{
			get
			{
				IEnumerable<IDictionaryValidator> enumerable = validators;
				return enumerable ?? Enumerable.Empty<IDictionaryValidator>();
			}
		}

		public event PropertyChangingEventHandler PropertyChanging;

		public event PropertyChangedEventHandler PropertyChanged;

		public T Coerce<T>() where T : class
		{
			return (T)Coerce(typeof(T));
		}

		public object Coerce(Type type)
		{
			if (type.IsAssignableFrom(Meta.Type))
			{
				return this;
			}
			if (This.CoerceStrategy != null)
			{
				object obj = This.CoerceStrategy.Coerce(this, type);
				if (obj != null)
				{
					return obj;
				}
			}
			return This.Factory.GetAdapter(type, This.Dictionary, This.Descriptor);
		}

		public void CopyTo(IDictionaryAdapter other)
		{
			CopyTo(other, null);
		}

		public void CopyTo(IDictionaryAdapter other, Func<PropertyDescriptor, bool> selector)
		{
			if (this == other)
			{
				return;
			}
			if (!other.Meta.Type.IsAssignableFrom(Meta.Type))
			{
				throw new ArgumentException($"Unable to copy to {other.Meta.Type.FullName}.  The type must be assignable from {Meta.Type.FullName}.");
			}
			if (This.CopyStrategies.Aggregate(seed: false, (bool copied, IDictionaryCopyStrategy s) => copied | s.Copy(this, other, ref selector)))
			{
				return;
			}
			selector = selector ?? ((Func<PropertyDescriptor, bool>)((PropertyDescriptor property) => true));
			foreach (PropertyDescriptor item in This.Properties.Values.Where((PropertyDescriptor property) => selector(property)))
			{
				object value = GetProperty(item.PropertyName, ifExists: true);
				other.SetProperty(item.PropertyName, ref value);
			}
		}

		public T Create<T>()
		{
			return Create<T>(new HybridDictionary());
		}

		public object Create(Type type)
		{
			return Create(type, new HybridDictionary());
		}

		public T Create<T>(IDictionary dictionary)
		{
			return (T)Create(typeof(T), dictionary ?? new HybridDictionary());
		}

		public object Create(Type type, IDictionary dictionary)
		{
			if (This.CreateStrategy != null)
			{
				object obj = This.CreateStrategy.Create(this, type, dictionary);
				if (obj != null)
				{
					return obj;
				}
			}
			dictionary = dictionary ?? new HybridDictionary();
			return This.Factory.GetAdapter(type, dictionary, This.Descriptor);
		}

		public T Create<T>(Action<T> init)
		{
			return Create(new HybridDictionary(), init);
		}

		public T Create<T>(IDictionary dictionary, Action<T> init)
		{
			T val = Create<T>(dictionary ?? new HybridDictionary());
			init?.Invoke(val);
			return val;
		}

		public DictionaryAdapterBase(DictionaryAdapterInstance instance)
		{
			This = instance;
			CanEdit = typeof(IEditableObject).IsAssignableFrom(Meta.Type);
			CanNotify = typeof(INotifyPropertyChanged).IsAssignableFrom(Meta.Type);
			CanValidate = typeof(IDataErrorInfo).IsAssignableFrom(Meta.Type);
			Initialize();
		}

		public string GetKey(string propertyName)
		{
			if (This.Properties.TryGetValue(propertyName, out var value))
			{
				return value.GetKey(this, propertyName, This.Descriptor);
			}
			return null;
		}

		public virtual object GetProperty(string propertyName, bool ifExists)
		{
			if (This.Properties.TryGetValue(propertyName, out var value))
			{
				object propertyValue = value.GetPropertyValue(this, propertyName, null, This.Descriptor, ifExists);
				if (propertyValue is IEditableObject)
				{
					AddEditDependency((IEditableObject)propertyValue);
				}
				return propertyValue;
			}
			return null;
		}

		public T GetPropertyOfType<T>(string propertyName)
		{
			object property = GetProperty(propertyName, ifExists: false);
			if (property == null)
			{
				return default(T);
			}
			return (T)property;
		}

		public object ReadProperty(string key)
		{
			object propertyValue = null;
			if (!GetEditedProperty(key, out propertyValue))
			{
				IDictionary dictionary = GetDictionary(This.Dictionary, ref key);
				if (dictionary != null)
				{
					propertyValue = dictionary[key];
				}
			}
			return propertyValue;
		}

		public virtual bool SetProperty(string propertyName, ref object value)
		{
			bool flag = false;
			if (This.Properties.TryGetValue(propertyName, out var value2))
			{
				if (!ShouldNotify)
				{
					flag = value2.SetPropertyValue(this, propertyName, ref value, This.Descriptor);
					Invalidate();
					return flag;
				}
				object property = GetProperty(propertyName, ifExists: true);
				if (!NotifyPropertyChanging(value2, property, value))
				{
					return false;
				}
				TrackPropertyChangeScope trackPropertyChangeScope = TrackPropertyChange(value2, property, value);
				flag = value2.SetPropertyValue(this, propertyName, ref value, This.Descriptor);
				if (flag)
				{
					trackPropertyChangeScope?.Notify();
				}
			}
			return flag;
		}

		public void StoreProperty(PropertyDescriptor property, string key, object value)
		{
			if (property == null || !EditProperty(property, key, value))
			{
				IDictionary dictionary = GetDictionary(This.Dictionary, ref key);
				if (dictionary != null)
				{
					dictionary[key] = value;
				}
			}
		}

		public void ClearProperty(PropertyDescriptor property, string key)
		{
			key = key ?? GetKey(property.PropertyName);
			if (property == null || !ClearEditProperty(property, key))
			{
				GetDictionary(This.Dictionary, ref key)?.Remove(key);
			}
		}

		public bool ShouldClearProperty(PropertyDescriptor property, object value)
		{
			return (from remove in property?.Setters.OfType<RemoveIfAttribute>()
				where remove.ShouldRemove(value)
				select remove).Any() ?? true;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is IDictionaryAdapter dictionaryAdapter))
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (Meta.Type != dictionaryAdapter.Meta.Type)
			{
				return false;
			}
			if (This.EqualityHashCodeStrategy != null)
			{
				return This.EqualityHashCodeStrategy.Equals(this, dictionaryAdapter);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			if (This.OldHashCode.HasValue)
			{
				return This.OldHashCode.Value;
			}
			if (This.EqualityHashCodeStrategy == null || !This.EqualityHashCodeStrategy.GetHashCode(this, out var hashCode))
			{
				hashCode = base.GetHashCode();
			}
			This.OldHashCode = hashCode;
			return hashCode;
		}

		protected void Initialize()
		{
			object[] behaviors = Meta.Behaviors;
			IDictionaryInitializer[] initializers = This.Initializers;
			for (int i = 0; i < initializers.Length; i++)
			{
				initializers[i].Initialize(this, behaviors);
			}
			foreach (PropertyDescriptor value in This.Properties.Values)
			{
				if (value.Fetch)
				{
					GetProperty(value.PropertyName, ifExists: false);
				}
			}
		}

		private static IDictionary GetDictionary(IDictionary dictionary, ref string key)
		{
			if (!key.StartsWith("!"))
			{
				string[] array = key.Split(',');
				for (int i = 0; i < array.Length - 1; i++)
				{
					dictionary = dictionary[array[i]] as IDictionary;
					if (dictionary == null)
					{
						return null;
					}
				}
				key = array[^1];
			}
			return dictionary;
		}

		public void BeginEdit()
		{
			if (CanEdit && (!IsEditing || SupportsMultiLevelEdit))
			{
				updates.Push(new Dictionary<string, Edit>());
			}
		}

		public void CancelEdit()
		{
			if (!IsEditing)
			{
				return;
			}
			if (editDependencies != null)
			{
				IEditableObject[] array = editDependencies.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].CancelEdit();
				}
				editDependencies.Clear();
			}
			using (SuppressEditingBlock())
			{
				using (TrackReadonlyPropertyChanges())
				{
					Dictionary<string, Edit> dictionary = updates.Peek();
					if (dictionary.Count <= 0)
					{
						return;
					}
					foreach (Edit value in dictionary.Values)
					{
						Edit current = value;
						current.PropertyValue = GetProperty(current.Property.PropertyName, ifExists: true);
					}
					updates.Pop();
					Edit[] array2 = dictionary.Values.ToArray();
					for (int i = 0; i < array2.Length; i++)
					{
						Edit edit = array2[i];
						object propertyValue = edit.PropertyValue;
						object property = GetProperty(edit.Property.PropertyName, ifExists: true);
						if (!object.Equals(propertyValue, property))
						{
							NotifyPropertyChanging(edit.Property, propertyValue, property);
							NotifyPropertyChanged(edit.Property, propertyValue, property);
						}
					}
				}
			}
		}

		public void EndEdit()
		{
			if (!IsEditing)
			{
				return;
			}
			using (SuppressEditingBlock())
			{
				Dictionary<string, Edit> dictionary = updates.Pop();
				if (dictionary.Count > 0)
				{
					KeyValuePair<string, Edit>[] array = dictionary.ToArray();
					for (int i = 0; i < array.Length; i++)
					{
						KeyValuePair<string, Edit> keyValuePair = array[i];
						StoreProperty(null, keyValuePair.Key, keyValuePair.Value.PropertyValue);
					}
				}
			}
			if (editDependencies != null)
			{
				IEditableObject[] array2 = editDependencies.ToArray();
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].EndEdit();
				}
				editDependencies.Clear();
			}
		}

		public void RejectChanges()
		{
			CancelEdit();
		}

		public void AcceptChanges()
		{
			EndEdit();
		}

		public IDisposable SuppressEditingBlock()
		{
			return new SuppressEditingScope(this);
		}

		public void SuppressEditing()
		{
			suppressEditingCount++;
		}

		public void ResumeEditing()
		{
			suppressEditingCount--;
		}

		protected bool GetEditedProperty(string propertyName, out object propertyValue)
		{
			if (updates != null)
			{
				Dictionary<string, Edit>[] array = updates.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].TryGetValue(propertyName, out var value))
					{
						propertyValue = value.PropertyValue;
						return true;
					}
				}
			}
			propertyValue = null;
			return false;
		}

		protected bool EditProperty(PropertyDescriptor property, string key, object propertyValue)
		{
			if (IsEditing)
			{
				updates.Peek()[key] = new Edit(property, propertyValue);
				return true;
			}
			return false;
		}

		protected bool ClearEditProperty(PropertyDescriptor property, string key)
		{
			if (IsEditing)
			{
				updates.Peek().Remove(key);
				return true;
			}
			return false;
		}

		protected void AddEditDependency(IEditableObject editDependency)
		{
			if (IsEditing)
			{
				if (editDependencies == null)
				{
					editDependencies = new HashSet<IEditableObject>();
				}
				if (editDependencies.Add(editDependency))
				{
					editDependency.BeginEdit();
				}
			}
		}

		public IDisposable SuppressNotificationsBlock()
		{
			return new NotificationSuppressionScope(this);
		}

		public void SuppressNotifications()
		{
			suppressNotificationCount++;
		}

		public void ResumeNotifications()
		{
			suppressNotificationCount--;
		}

		protected bool NotifyPropertyChanging(PropertyDescriptor property, object oldValue, object newValue)
		{
			if (property.SuppressNotifications || !ShouldNotify)
			{
				return true;
			}
			PropertyChangingEventHandler propertyChangingEventHandler = this.PropertyChanging;
			if (propertyChangingEventHandler == null)
			{
				return true;
			}
			PropertyChangingEventArgsEx propertyChangingEventArgsEx = new PropertyChangingEventArgsEx(property.PropertyName, oldValue, newValue);
			propertyChangingEventHandler(this, propertyChangingEventArgsEx);
			return !propertyChangingEventArgsEx.Cancel;
		}

		protected void NotifyPropertyChanged(PropertyDescriptor property, object oldValue, object newValue)
		{
			if (!property.SuppressNotifications && ShouldNotify)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgsEx(property.PropertyName, oldValue, newValue));
			}
		}

		protected void NotifyPropertyChanged(string propertyName)
		{
			if (ShouldNotify)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected TrackPropertyChangeScope TrackPropertyChange(PropertyDescriptor property, object oldValue, object newValue)
		{
			if (!ShouldNotify || property.SuppressNotifications)
			{
				return null;
			}
			return new TrackPropertyChangeScope(this, property, oldValue);
		}

		protected TrackPropertyChangeScope TrackReadonlyPropertyChanges()
		{
			if (!ShouldNotify || readOnlyTrackingScope != null)
			{
				return null;
			}
			return readOnlyTrackingScope = new TrackPropertyChangeScope(this);
		}

		public DictionaryValidateGroup ValidateGroups(params object[] groups)
		{
			return new DictionaryValidateGroup(groups, this);
		}

		public void AddValidator(IDictionaryValidator validator)
		{
			if (validators == null)
			{
				validators = new HashSet<IDictionaryValidator>();
			}
			validators.Add(validator);
		}

		protected internal void Invalidate()
		{
			if (!CanValidate)
			{
				return;
			}
			if (validators != null)
			{
				foreach (IDictionaryValidator validator in validators)
				{
					validator.Invalidate(this);
				}
			}
			NotifyPropertyChanged("IsValid");
		}
	}
}
