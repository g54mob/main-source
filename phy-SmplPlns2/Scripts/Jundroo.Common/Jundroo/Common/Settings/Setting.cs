using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.Common.Events;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings.Events;
using UnityEngine;

namespace Jundroo.Common.Settings
{
	public abstract class Setting
	{
		private static Dictionary<Type, int> _categoryCounts = new Dictionary<Type, int>();

		public SettingApplyType ApplyType { get; protected set; }

		public SettingsCategory Category { get; private set; }

		public virtual string Description { get; protected set; }

		public string DisplayName { get; protected set; }

		public int DisplayOrder { get; protected set; }

		public bool PendingChange { get; protected set; }

		public SettingState State { get; protected set; }

		public Type ValueType { get; private set; }

		public SettingVisibility Visibility
		{
			get
			{
				if (State != SettingState.Enabled)
				{
					return SettingVisibility.Hidden;
				}
				SettingVisibility settingVisibility = VisibilityCheck();
				SettingVisibility subSettingsVisibility = Category.SubSettingsVisibility;
				switch (settingVisibility)
				{
				case SettingVisibility.Default:
					return subSettingsVisibility;
				case SettingVisibility.ReadOnly:
					if (subSettingsVisibility == SettingVisibility.Hidden)
					{
						return subSettingsVisibility;
					}
					break;
				}
				return settingVisibility;
			}
		}

		public string Warning { get; protected set; }

		public string XmlName { get; protected set; }

		protected Func<SettingVisibility> VisibilityCheck { get; set; }

		protected Setting(Type type, string displayName, SettingsCategory category, string xmlName)
		{
			if (!type.IsValueType)
			{
				Debug.LogError($"Settings only support value types. Type '{type}' is not supported.");
			}
			DisplayName = displayName;
			if (string.IsNullOrEmpty(xmlName))
			{
				XmlName = displayName.Replace(" ", string.Empty);
				XmlName = char.ToLower(XmlName[0]) + XmlName.Substring(1);
			}
			else
			{
				XmlName = xmlName;
			}
			Category = category;
			ValueType = type;
			VisibilityCheck = () => SettingVisibility.Default;
			Type type2 = category.GetType();
			if (!_categoryCounts.ContainsKey(type2))
			{
				_categoryCounts[type2] = 0;
			}
			DisplayOrder = (_categoryCounts[type2] += 1);
		}

		public virtual void CommitChanges()
		{
			CommitChanges(suppressCategoryChangedEvent: false);
		}

		public abstract void RestoreFromXml(XElement xml);

		public abstract void RevertChanges();

		public abstract void SaveToXml(XElement xml);

		protected internal abstract void CommitChanges(bool suppressCategoryChangedEvent);
	}
	public abstract class Setting<T> : Setting where T : struct
	{
		public abstract class SettingBuilder<TBuilder, TSetting> where TBuilder : SettingBuilder<TBuilder, TSetting> where TSetting : Setting<T>
		{
			public TSetting Setting { get; private set; }

			public SettingBuilder(TSetting setting)
			{
				Setting = setting;
			}

			public TBuilder AddWarning(Func<T, bool> condition, string warning = "This setting is not intended to run on your device and is not officially supported. Performance of the game could be severely impacted or it may fail to run entirely. Use at your own risk.")
			{
				return AddWarning(DeviceFlags.All, condition, warning);
			}

			public TBuilder AddWarning(DeviceFlags devices, Func<T, bool> condition, string warning = "This setting is not intended to run on your device and is not officially supported. Performance of the game could be severely impacted or it may fail to run entirely. Use at your own risk.")
			{
				if (Device.HasAnyFlag(devices))
				{
					Setting.WarningChecks.Add((T x) => (!condition(x)) ? null : warning);
				}
				return (TBuilder)this;
			}

			public TBuilder OnChanged<TOther>(Setting<TOther> setting, Action<TSetting, TOther> action) where TOther : struct
			{
				setting.ValueUpdated += delegate(Setting<TOther> x)
				{
					action(Setting, x);
				};
				return (TBuilder)this;
			}

			public TBuilder OnChanged<TOther>(DeviceFlags devices, Setting<TOther> setting, Action<TSetting, TOther> action) where TOther : struct
			{
				if (Device.HasAnyFlag(devices))
				{
					setting.ValueUpdated += delegate(Setting<TOther> x)
					{
						action(Setting, x);
					};
				}
				return (TBuilder)this;
			}

			public TBuilder SetApplyType(SettingApplyType applyType)
			{
				Setting.ApplyType = applyType;
				return (TBuilder)this;
			}

			public TBuilder SetApplyType(DeviceFlags devices, SettingApplyType applyType)
			{
				if (Device.HasAnyFlag(devices))
				{
					Setting.ApplyType = applyType;
				}
				return (TBuilder)this;
			}

			public TBuilder SetDefault(T value)
			{
				Setting._value = value;
				return (TBuilder)this;
			}

			public TBuilder SetDefault(DeviceFlags devices, T value)
			{
				if (Device.HasAnyFlag(devices))
				{
					Setting._value = value;
				}
				return (TBuilder)this;
			}

			public TBuilder SetDescription(string description)
			{
				Setting.Description = description;
				return (TBuilder)this;
			}

			public TBuilder SetDescription(DeviceFlags devices, string description)
			{
				if (Device.HasAnyFlag(devices))
				{
					Setting.Description = description;
				}
				return (TBuilder)this;
			}

			public TBuilder SetDisplayOrder(int order)
			{
				Setting.DisplayOrder = order;
				return (TBuilder)this;
			}

			public TBuilder SetDisplayOrder(DeviceFlags devices, int order)
			{
				if (Device.HasAnyFlag(devices))
				{
					Setting.DisplayOrder = order;
				}
				return (TBuilder)this;
			}

			public TBuilder SetRaiseChangedEventOnlyWhenCommitted(bool value)
			{
				Setting.RaiseChangedEventOnlyWhenCommitted = value;
				return (TBuilder)this;
			}

			public TBuilder SetState(SettingState state)
			{
				Setting.State = state;
				return (TBuilder)this;
			}

			public TBuilder SetState(DeviceFlags devices, SettingState state)
			{
				if (Device.HasAnyFlag(devices))
				{
					Setting.State = state;
				}
				return (TBuilder)this;
			}

			public TBuilder SetVisibility(Func<SettingVisibility> visibilityCheck)
			{
				Setting.VisibilityCheck = visibilityCheck;
				return (TBuilder)this;
			}

			public TBuilder SetVisibility(DeviceFlags devices, Func<SettingVisibility> visibilityCheck)
			{
				if (Device.HasAnyFlag(devices))
				{
					Setting.VisibilityCheck = visibilityCheck;
				}
				return (TBuilder)this;
			}

			public TBuilder SetXmlName(string xmlName)
			{
				Setting.XmlName = xmlName;
				return (TBuilder)this;
			}
		}

		private SettingChangedEventArgs<T> _changedEventArgs;

		private T? _originalValue;

		private T _value;

		public string DisplayValue => GetDisplayValue(_value);

		public bool RaiseChangedEventOnlyWhenCommitted { get; set; } = true;

		public T Value
		{
			get
			{
				return _value;
			}
			set
			{
				SetValue(value);
			}
		}

		protected T? OriginalValue => _originalValue;

		protected List<Func<T, string>> WarningChecks { get; private set; }

		public event EventHandler<SettingChangedEventArgs<T>> Changed
		{
			add
			{
				_changed += WeakEventHandler.Create(value, delegate(EventHandler<SettingChangedEventArgs<T>> x)
				{
					_changed -= x;
				});
			}
			remove
			{
				_changed -= WeakEventHandler.FindUnregisterHandler(this._changed, value);
			}
		}

		protected event SettingChangedEventHandler<T> ValueUpdated;

		private event EventHandler<SettingChangedEventArgs<T>> _changed;

		public Setting(string displayName, SettingsCategory category, string xmlName)
			: base(typeof(T), displayName, category, xmlName)
		{
			ValueUpdated += category.OnSettingChanged;
			WarningChecks = new List<Func<T, string>>();
			_changedEventArgs = new SettingChangedEventArgs<T>(this);
		}

		public static implicit operator T(Setting<T> setting)
		{
			return setting.Value;
		}

		public virtual string GetDisplayValue(T value)
		{
			return value.ToString();
		}

		public virtual void RaiseSettingChangedEvent()
		{
			try
			{
				this._changed?.Invoke(this, _changedEventArgs);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public override void RevertChanges()
		{
			if (_originalValue.HasValue)
			{
				_value = _originalValue.Value;
				_originalValue = null;
				if (!RaiseChangedEventOnlyWhenCommitted)
				{
					RaiseSettingChangedEvent();
				}
			}
			base.PendingChange = false;
		}

		public override void SaveToXml(XElement xml)
		{
			if (base.State == SettingState.Enabled || base.State == SettingState.Hidden)
			{
				xml.SetAttributeValue(base.XmlName, OriginalValue ?? Value);
			}
		}

		public void UpdateAndCommit(T value)
		{
			Value = value;
			CommitChanges();
		}

		protected internal override void CommitChanges(bool suppressCategoryChangedEvent)
		{
			if (base.PendingChange)
			{
				RaiseSettingChangedEvent();
				base.Category.OnSettingCommitted(this, suppressCategoryChangedEvent);
			}
			_originalValue = null;
			base.PendingChange = false;
		}

		protected virtual void OnValueChanged(T lastCommittedValue, T previousValue, T requestedNewValue, T actualNewValue)
		{
		}

		protected void RefreshWarnings()
		{
			string[] array = (from x in WarningChecks?.Select((Func<T, string> x) => x(_value))
				where !string.IsNullOrWhiteSpace(x)
				select x).ToArray();
			base.Warning = ((array == null || array.Length == 0) ? null : string.Join(Environment.NewLine + Environment.NewLine, array));
		}

		protected virtual void SetValue(T value)
		{
			T val = Validate(value);
			T value2 = _value;
			if (!value2.Equals(val))
			{
				if (!_originalValue.HasValue)
				{
					_originalValue = value2;
				}
				_value = val;
				base.PendingChange = !val.Equals(_originalValue.Value);
				RefreshWarnings();
				this.ValueUpdated?.Invoke(this);
				OnValueChanged(_originalValue.Value, value2, value, val);
				if (!RaiseChangedEventOnlyWhenCommitted)
				{
					RaiseSettingChangedEvent();
				}
			}
		}

		protected virtual T Validate(T value)
		{
			return value;
		}
	}
}
