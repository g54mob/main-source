using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using DV.Common;
using DV.Scenarios.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Scenarios
{
	public abstract class Thing : IScenariosThing, IThing, INotifyPropertyChanged
	{
		public static string DATA_VERSION_KEY = "DataVersion";

		internal string _name;

		internal SyncState _syncState;

		internal bool pendingFileRename;

		private bool _isReadOnly;

		protected string snapshot;

		protected SyncState snapshotSyncState;

		protected bool snapshotPendingRename;

		protected readonly Dictionary<string, object> originals = new Dictionary<string, object>();

		private bool reverting;

		protected virtual bool StrictNameMatch => false;

		[JsonProperty]
		public int DataVersion { get; private set; } = 1;

		[JsonProperty]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				SetField(ref _name, value, "Name");
			}
		}

		[JsonIgnore]
		public abstract string FileExtension { get; }

		[JsonIgnore]
		public virtual SyncState SyncState
		{
			get
			{
				if (!IsReadOnly)
				{
					return _syncState;
				}
				return SyncState.Synced;
			}
			set
			{
				if (_syncState != SyncState.Deleted)
				{
					if (_isReadOnly)
					{
						_syncState = SyncState.Synced;
					}
					_syncState = value;
				}
			}
		}

		[JsonIgnore]
		public string FileName { get; internal set; }

		[JsonIgnore]
		public bool IsReadOnly
		{
			get
			{
				return _isReadOnly;
			}
			internal set
			{
				if (IsReadOnly && !value)
				{
					Debug.LogError("Note that changing from read-only to not read-only is untested");
				}
				_isReadOnly = value;
				if (value)
				{
					FileName = null;
					pendingFileRename = false;
					SyncState = SyncState.Synced;
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public static T FromJson<T>(string jsonStr, JsonSerializer serializer = null) where T : Thing
		{
			return FromJson<T>(JObject.Parse(jsonStr));
		}

		public static T FromJson<T>(JObject json, JsonSerializer serializer = null) where T : Thing
		{
			T obj = ((serializer == null) ? json.ToObject<T>() : json.ToObject<T>(serializer));
			obj.SetSyncStateRecursive(SyncState.Synced);
			obj.FixNullLists();
			obj.SubscribeToListThingsChanges();
			obj.SaveSnapshot(recursive: true);
			return obj;
		}

		public static int GetMatchScore(Thing a, Thing b)
		{
			if (a == null || b == null)
			{
				return 0;
			}
			if (a == b)
			{
				return 2;
			}
			if (a.GetType() != b.GetType())
			{
				return 0;
			}
			int num = 2;
			foreach (MemberInfo fieldsAndProperty in GetFieldsAndProperties(a.GetType()))
			{
				if (IsThing(fieldsAndProperty))
				{
					int matchScore = GetMatchScore((Thing)GetValue(fieldsAndProperty, a), (Thing)GetValue(fieldsAndProperty, b));
					if (matchScore == 0)
					{
						return 0;
					}
					num = Mathf.Min(num, matchScore);
				}
				else if (IsArray(fieldsAndProperty))
				{
					IScenariosThing[] array = (IScenariosThing[])GetValue(fieldsAndProperty, a);
					IScenariosThing[] array2 = (IScenariosThing[])GetValue(fieldsAndProperty, b);
					if (BothAreNull(array, array2))
					{
						continue;
					}
					object[] array3 = array;
					object[] a2 = array3;
					array3 = array2;
					if (OneIsNullAndOtherIsEmpty(a2, array3))
					{
						continue;
					}
					if (OnlyOneIsNull(array, array2) || array.Length != array2.Length)
					{
						return 0;
					}
					for (int i = 0; i < array.Length; i++)
					{
						int matchScore2 = GetMatchScore((Thing)array[i], (Thing)array2[i]);
						if (matchScore2 == 0)
						{
							return 0;
						}
						num = Mathf.Min(num, matchScore2);
					}
				}
				else if (IsIEnumerable(fieldsAndProperty))
				{
					IList list = (IList)GetValue(fieldsAndProperty, a);
					IList list2 = (IList)GetValue(fieldsAndProperty, b);
					if (BothAreNull(list, list2) || OneIsNullAndOtherIsEmpty(list, list2))
					{
						continue;
					}
					if (OnlyOneIsNull(list, list2) || list.Count != list2.Count)
					{
						return 0;
					}
					for (int j = 0; j < list.Count; j++)
					{
						int matchScore3 = GetMatchScore((Thing)list[j], (Thing)list2[j]);
						if (matchScore3 == 0)
						{
							return 0;
						}
						num = Mathf.Min(num, matchScore3);
					}
				}
				else
				{
					if (!IsWritablePublicFieldOrProperty(fieldsAndProperty) || fieldsAndProperty.Name == "Name" || fieldsAndProperty.Name == "SyncState" || fieldsAndProperty.Name == "FileName" || fieldsAndProperty.GetCustomAttribute(typeof(JsonIgnoreAttribute)) != null)
					{
						continue;
					}
					object value = GetValue(fieldsAndProperty, a);
					object value2 = GetValue(fieldsAndProperty, b);
					if (value == null && value2 == null)
					{
						continue;
					}
					if (value == null || value2 == null)
					{
						return 0;
					}
					if (GimmeType(fieldsAndProperty).IsValueType)
					{
						if (value.Equals(value2))
						{
							continue;
						}
						return 0;
					}
					string text = JsonConvert.SerializeObject(value, Util.JsonSerializerSettings);
					string text2 = JsonConvert.SerializeObject(value2, Util.JsonSerializerSettings);
					if (text != text2)
					{
						return 0;
					}
				}
			}
			bool flag = string.Equals(a.Name, b.Name);
			if (a.StrictNameMatch || b.StrictNameMatch)
			{
				if (!flag)
				{
					return 0;
				}
				return num;
			}
			return Mathf.Min(num, (!flag) ? 1 : 2);
		}

		private static List<MemberInfo> GetFieldsAndProperties(Type type)
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			List<MemberInfo> list = new List<MemberInfo>(fields.Length + properties.Length);
			list.AddRange(fields);
			list.AddRange(properties);
			return list;
		}

		private static Type GimmeType(MemberInfo mi)
		{
			if (mi is PropertyInfo propertyInfo)
			{
				return propertyInfo.PropertyType;
			}
			if (mi is FieldInfo fieldInfo)
			{
				return fieldInfo.FieldType;
			}
			throw new Exception("Unexpected member type");
		}

		private static bool IsThing(Type t)
		{
			return typeof(IScenariosThing).IsAssignableFrom(t);
		}

		private static bool IsThing(MemberInfo mi)
		{
			return typeof(IScenariosThing).IsAssignableFrom(GimmeType(mi));
		}

		private static bool IsArray(MemberInfo mi)
		{
			Type type = GimmeType(mi);
			if (type.IsArray)
			{
				return typeof(IScenariosThing).IsAssignableFrom(type.GetElementType());
			}
			return false;
		}

		private static bool IsIEnumerable(MemberInfo mi)
		{
			return typeof(IEnumerable<IScenariosThing>).IsAssignableFrom(GimmeType(mi));
		}

		private static bool IsINotifyCollectionChanged(MemberInfo mi)
		{
			return typeof(INotifyCollectionChanged).IsAssignableFrom(GimmeType(mi));
		}

		private static bool IsIList(MemberInfo mi)
		{
			return typeof(IList).IsAssignableFrom(GimmeType(mi));
		}

		private static bool IsWritablePublicFieldOrProperty(MemberInfo mi)
		{
			if (mi is PropertyInfo propertyInfo)
			{
				if (!propertyInfo.CanWrite)
				{
					if (propertyInfo.SetMethod != null)
					{
						return propertyInfo.SetMethod.IsPublic;
					}
					return false;
				}
				return true;
			}
			if (mi is FieldInfo fieldInfo)
			{
				return fieldInfo.IsPublic;
			}
			throw new Exception("Unexpected member type");
		}

		private static object GetValue(MemberInfo mi, Thing obj)
		{
			if (mi is PropertyInfo propertyInfo)
			{
				return propertyInfo.GetValue(obj);
			}
			if (mi is FieldInfo fieldInfo)
			{
				return fieldInfo.GetValue(obj);
			}
			throw new Exception("Unexpected member type");
		}

		private static object SetValue(MemberInfo mi, Thing obj, object value)
		{
			if (mi is PropertyInfo propertyInfo)
			{
				propertyInfo.SetValue(obj, value);
				return value;
			}
			if (mi is FieldInfo fieldInfo)
			{
				fieldInfo.SetValue(obj, value);
				return value;
			}
			throw new Exception("Unexpected member type");
		}

		private static bool BothAreNull(object a, object b)
		{
			if (a == null)
			{
				return b == null;
			}
			return false;
		}

		private static bool OnlyOneIsNull(object a, object b)
		{
			if (a != null || b == null)
			{
				if (a != null)
				{
					return b == null;
				}
				return false;
			}
			return true;
		}

		private static bool OneIsNullAndOtherIsEmpty(object[] a, object[] b)
		{
			if (a == null && b != null)
			{
				return b.Length == 0;
			}
			if (a != null && b == null)
			{
				return a.Length == 0;
			}
			return false;
		}

		private static bool OneIsNullAndOtherIsEmpty(IList a, IList b)
		{
			if (a == null && b != null)
			{
				return b.Count == 0;
			}
			if (a != null && b == null)
			{
				return a.Count == 0;
			}
			return false;
		}

		protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (IsThing(typeof(T)))
			{
				if ((object)field == (object)value)
				{
					return false;
				}
			}
			else if (EqualityComparer<T>.Default.Equals(field, value))
			{
				return false;
			}
			if (IsReadOnly)
			{
				Debug.LogError("Modifying '" + propertyName + "' on read-only " + GetType().Name + " '" + Name + "'");
				return false;
			}
			if (field is Thing thing)
			{
				thing.PropertyChanged -= OnChildPropertyChanged;
			}
			if (value is Thing thing2)
			{
				thing2.PropertyChanged += OnChildPropertyChanged;
			}
			field = value;
			_syncState = SyncState.Modified;
			if (propertyName == "Name" && FileName != null)
			{
				pendingFileRename = true;
			}
			FirePropertyChanged(propertyName);
			return true;
		}

		private void OnChildPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			SyncState = SyncState.Modified;
			FirePropertyChanged("SyncState");
		}

		protected void FirePropertyChanged(string propertyName)
		{
			if (!reverting)
			{
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.OldItems != null)
			{
				foreach (object oldItem in e.OldItems)
				{
					if (oldItem is INotifyPropertyChanged notifyPropertyChanged)
					{
						notifyPropertyChanged.PropertyChanged -= OnCollectionItemChanged;
					}
				}
			}
			if (e.NewItems != null)
			{
				foreach (object newItem in e.NewItems)
				{
					if (newItem is INotifyPropertyChanged notifyPropertyChanged2)
					{
						notifyPropertyChanged2.PropertyChanged += OnCollectionItemChanged;
					}
				}
			}
			if (e.Action == NotifyCollectionChangedAction.Reset)
			{
				foreach (object item in (IEnumerable)sender)
				{
					if (item is INotifyPropertyChanged notifyPropertyChanged3)
					{
						notifyPropertyChanged3.PropertyChanged += OnCollectionItemChanged;
					}
				}
			}
			OnCollectionItemChanged(null, null);
			List<object> list = ((IEnumerable)sender).Cast<object>().ToList();
			int count = list.Count;
			int num = list.Distinct(new ReferenceEqualsComparer()).Count();
			if (count != num)
			{
				Debug.LogError($"Collection in {GetType().Name} contains {count - num} duplicate items");
			}
		}

		private void OnCollectionItemChanged(object _, PropertyChangedEventArgs __)
		{
			SyncState = SyncState.Modified;
			FirePropertyChanged("(collection item changed)");
		}

		private void SubscribeToChildThingsChanges()
		{
			foreach (MemberInfo fieldsAndProperty in GetFieldsAndProperties(GetType()))
			{
				if (IsThing(fieldsAndProperty))
				{
					Thing thing = (Thing)GetValue(fieldsAndProperty, this);
					if (thing != null)
					{
						thing.PropertyChanged += OnChildPropertyChanged;
					}
				}
			}
		}

		private void FixNullLists()
		{
			foreach (MemberInfo fieldsAndProperty in GetFieldsAndProperties(GetType()))
			{
				if (GetValue(fieldsAndProperty, this) == null)
				{
					if (GimmeType(fieldsAndProperty).IsArray)
					{
						Debug.LogWarning("Encountered a null array but fixing arrays is not implemented");
					}
					else if (IsINotifyCollectionChanged(fieldsAndProperty) || IsIList(fieldsAndProperty))
					{
						object value = Activator.CreateInstance(GimmeType(fieldsAndProperty));
						SetValue(fieldsAndProperty, this, value);
					}
				}
			}
		}

		private void SubscribeToListThingsChanges()
		{
			foreach (MemberInfo fieldsAndProperty in GetFieldsAndProperties(GetType()))
			{
				if (IsINotifyCollectionChanged(fieldsAndProperty))
				{
					INotifyCollectionChanged notifyCollectionChanged = (INotifyCollectionChanged)GetValue(fieldsAndProperty, this);
					if (notifyCollectionChanged == null)
					{
						continue;
					}
					foreach (object item in (IEnumerable)notifyCollectionChanged)
					{
						if (item is Thing thing)
						{
							thing.PropertyChanged -= OnCollectionItemChanged;
							thing.PropertyChanged += OnCollectionItemChanged;
						}
					}
					notifyCollectionChanged.CollectionChanged -= OnCollectionChanged;
					notifyCollectionChanged.CollectionChanged += OnCollectionChanged;
				}
				else
				{
					if (!IsIList(fieldsAndProperty))
					{
						continue;
					}
					IList list = (IList)GetValue(fieldsAndProperty, this);
					if (list == null)
					{
						continue;
					}
					foreach (object item2 in list)
					{
						if (item2 is Thing thing2)
						{
							thing2.PropertyChanged -= OnCollectionItemChanged;
							thing2.PropertyChanged += OnCollectionItemChanged;
						}
					}
				}
			}
		}

		public virtual void RevertChanges()
		{
			if (string.IsNullOrWhiteSpace(snapshot))
			{
				Debug.LogError("RevertChanges called on " + GetType().Name + " '" + Name + "' but it has no snapshot, doing nothing");
				return;
			}
			reverting = true;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (MemberInfo fieldsAndProperty in GetFieldsAndProperties(GetType()))
			{
				if (IsThing(fieldsAndProperty))
				{
					SetValue(fieldsAndProperty, this, null);
				}
				else if (IsINotifyCollectionChanged(fieldsAndProperty) || IsIList(fieldsAndProperty))
				{
					object value = GetValue(fieldsAndProperty, this);
					if (value != null)
					{
						dictionary[fieldsAndProperty.Name] = value;
					}
					SetValue(fieldsAndProperty, this, null);
				}
			}
			ApplyValuesFrom(snapshot, snapshotSyncState, snapshotPendingRename);
			foreach (MemberInfo fieldsAndProperty2 in GetFieldsAndProperties(GetType()))
			{
				if (dictionary.TryGetValue(fieldsAndProperty2.Name, out var value2))
				{
					SetValue(fieldsAndProperty2, this, value2);
				}
			}
			if (originals.Count == 0)
			{
				Debug.LogWarning("RevertChanges called on " + GetType().Name + " '" + Name + "' but it has no original values saved");
			}
			else
			{
				foreach (MemberInfo fieldsAndProperty3 in GetFieldsAndProperties(GetType()))
				{
					if (!IsThing(fieldsAndProperty3) && !IsINotifyCollectionChanged(fieldsAndProperty3) && !IsIList(fieldsAndProperty3))
					{
						continue;
					}
					if (!originals.TryGetValue(fieldsAndProperty3.Name, out var value3))
					{
						Debug.LogError("RevertChanges called on " + GetType().Name + " '" + Name + "' but it has no child instance for property '" + fieldsAndProperty3.Name + "', doing nothing");
					}
					else if (IsThing(fieldsAndProperty3))
					{
						SetValue(fieldsAndProperty3, this, value3);
					}
					else
					{
						if (!IsINotifyCollectionChanged(fieldsAndProperty3) && !IsIList(fieldsAndProperty3))
						{
							continue;
						}
						if (GetValue(fieldsAndProperty3, this) is INotifyCollectionChanged notifyCollectionChanged && notifyCollectionChanged is IList list)
						{
							notifyCollectionChanged.CollectionChanged -= OnCollectionChanged;
							list.Clear();
							foreach (object item in (IEnumerable)value3)
							{
								list.Add(item);
								if (item is Thing thing)
								{
									thing.PropertyChanged -= OnChildPropertyChanged;
									thing.PropertyChanged += OnChildPropertyChanged;
								}
							}
							notifyCollectionChanged.CollectionChanged += OnCollectionChanged;
							continue;
						}
						if (!(GetValue(fieldsAndProperty3, this) is IList list2))
						{
							throw new NotImplementedException("Unhandled case for RevertChanges on " + GetType().Name + " '" + Name + "' for property '" + fieldsAndProperty3.Name + "'");
						}
						list2.Clear();
						foreach (object item2 in (IEnumerable)value3)
						{
							list2.Add(item2);
						}
					}
				}
			}
			reverting = false;
			_syncState = snapshotSyncState;
			FirePropertyChanged("(reverted)");
		}

		public virtual void ApplyValuesFrom(string jsonContent, SyncState? forceSyncState = null, bool? forcePendingFileRename = null)
		{
			JsonConvert.PopulateObject(jsonContent, this, Util.JsonSerializerSettings);
			if (forceSyncState.HasValue)
			{
				_syncState = forceSyncState.Value;
			}
			if (forcePendingFileRename.HasValue)
			{
				pendingFileRename = forcePendingFileRename.Value;
			}
		}

		internal virtual IScenariosThing Copy()
		{
			Thing obj = (Thing)MemberwiseClone();
			obj.SetupAfterCopy();
			return obj;
		}

		internal virtual void SetupAfterCopy()
		{
			this.PropertyChanged = null;
			SubscribeToChildThingsChanges();
			foreach (MemberInfo fieldsAndProperty in GetFieldsAndProperties(GetType()))
			{
				if (IsINotifyCollectionChanged(fieldsAndProperty))
				{
					INotifyCollectionChanged notifyCollectionChanged = (INotifyCollectionChanged)GetValue(fieldsAndProperty, this);
					if (notifyCollectionChanged == null)
					{
						continue;
					}
					INotifyCollectionChanged notifyCollectionChanged2 = (INotifyCollectionChanged)Activator.CreateInstance(notifyCollectionChanged.GetType());
					foreach (object item in (IEnumerable)notifyCollectionChanged)
					{
						if (item is Thing thing)
						{
							if (item.GetType().GetCustomAttributes(typeof(ShouldCreateCopyInstanceInParentsListAttribute), inherit: true).Length != 0)
							{
								thing = (Thing)thing.Copy();
							}
							((IList)notifyCollectionChanged2).Add(thing);
							thing.PropertyChanged += OnCollectionItemChanged;
						}
						else
						{
							((IList)notifyCollectionChanged2).Add(item);
						}
					}
					SetValue(fieldsAndProperty, this, notifyCollectionChanged2);
					notifyCollectionChanged2.CollectionChanged += OnCollectionChanged;
				}
				else
				{
					if (!IsIList(fieldsAndProperty))
					{
						continue;
					}
					IList list = (IList)GetValue(fieldsAndProperty, this);
					if (list == null)
					{
						continue;
					}
					IList list2 = (IList)Activator.CreateInstance(list.GetType());
					foreach (object item2 in list)
					{
						if (item2 is Thing thing2)
						{
							if (item2.GetType().GetCustomAttributes(typeof(ShouldCreateCopyInstanceInParentsListAttribute), inherit: true).Length != 0)
							{
								thing2 = (Thing)thing2.Copy();
							}
							thing2.PropertyChanged += OnChildPropertyChanged;
						}
						else
						{
							list2.Add(item2);
						}
					}
					SetValue(fieldsAndProperty, this, list2);
				}
			}
			FileName = null;
			pendingFileRename = false;
			_syncState = SyncState.Fresh;
			_isReadOnly = false;
		}

		public void SaveSnapshot()
		{
			SaveSnapshot(recursive: false);
		}

		internal void SaveSnapshot(bool recursive)
		{
			foreach (MemberInfo fieldsAndProperty in GetFieldsAndProperties(GetType()))
			{
				if (IsThing(fieldsAndProperty))
				{
					Thing thing = (Thing)GetValue(fieldsAndProperty, this);
					if (thing != null)
					{
						originals[fieldsAndProperty.Name] = thing;
						if (recursive)
						{
							thing.SaveSnapshot(recursive: true);
						}
					}
				}
				else
				{
					if (!IsIList(fieldsAndProperty) && !IsINotifyCollectionChanged(fieldsAndProperty))
					{
						continue;
					}
					IEnumerable enumerable = (IEnumerable)GetValue(fieldsAndProperty, this);
					if (enumerable == null)
					{
						continue;
					}
					List<object> list = enumerable.Cast<object>().ToList();
					originals[fieldsAndProperty.Name] = list;
					for (int i = 0; i < list.Count; i++)
					{
						object obj = list[i];
						if (obj is Thing thing2 && obj.GetType().GetCustomAttributes(typeof(ShouldCreateCopyInstanceInParentsListAttribute), inherit: true).Length != 0)
						{
							list[i] = (Thing)thing2.Copy();
						}
					}
				}
			}
			snapshot = JObject.FromObject(this, Util.JsonSerializer).ToString();
			snapshotSyncState = _syncState;
			snapshotPendingRename = pendingFileRename;
		}

		internal void SetSyncStateRecursive(SyncState syncState)
		{
			_syncState = syncState;
			foreach (MemberInfo fieldsAndProperty in GetFieldsAndProperties(GetType()))
			{
				if (IsThing(fieldsAndProperty))
				{
					((Thing)GetValue(fieldsAndProperty, this))?.SetSyncStateRecursive(syncState);
				}
				else if (IsArray(fieldsAndProperty))
				{
					IScenariosThing[] array = (IScenariosThing[])GetValue(fieldsAndProperty, this);
					if (array == null)
					{
						continue;
					}
					IScenariosThing[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						if (array2[i] is Thing thing)
						{
							thing.SetSyncStateRecursive(syncState);
						}
					}
				}
				else
				{
					if (!IsIEnumerable(fieldsAndProperty))
					{
						continue;
					}
					IEnumerable<IScenariosThing> enumerable = (IEnumerable<IScenariosThing>)GetValue(fieldsAndProperty, this);
					if (enumerable == null)
					{
						continue;
					}
					foreach (IScenariosThing item in enumerable)
					{
						if (item is Thing thing2)
						{
							thing2.SetSyncStateRecursive(syncState);
						}
					}
				}
			}
		}

		public Thing()
		{
			FixNullLists();
			SubscribeToListThingsChanges();
			SaveSnapshot(recursive: true);
		}

		public override string ToString()
		{
			return Name + " [" + GetType().Name + "]";
		}
	}
}
