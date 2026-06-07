using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Jundroo.Common.Events;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings.Events;
using UnityEngine;

namespace Jundroo.Common.Settings
{
	public abstract class SettingsCategory
	{
		private GetDefaultSettingsCategoryPreset _defaultPresetProvider;

		private bool _initialized;

		private SettingsCategoryPreset _originalPreset;

		public IReadOnlyList<SettingsCategoryPreset> AvailablePresets { get; private set; }

		public string CategoryName { get; private set; }

		public string CategoryXmlName { get; protected set; }

		public bool Expanded { get; set; }

		public bool HasUnsavedChanges { get; set; }

		public virtual int Order => 0;

		public bool PendingChanges
		{
			get
			{
				foreach (Setting setting in Settings)
				{
					if (setting.PendingChange)
					{
						return true;
					}
				}
				return Preset != _originalPreset;
			}
		}

		public SettingsCategoryPreset Preset { get; private set; }

		public IReadOnlyList<Setting> Settings { get; private set; }

		public SettingState State { get; protected set; }

		public SettingVisibility SubSettingsVisibility { get; private set; }

		protected Func<SettingsCategoryPreset, SettingVisibility> SubSettingVisibilityCheck { get; private set; }

		protected SettingsCategory(string categoryName)
			: this(categoryName, SettingState.Enabled)
		{
		}

		protected SettingsCategory(string categoryName, SettingState state)
		{
			CategoryName = categoryName;
			State = state;
			CategoryXmlName = XmlConvert.EncodeLocalName(new string((from x in categoryName.Replace(" ", string.Empty)
				where char.IsLetterOrDigit(x) || x == '.' || x == '-' || x == '_'
				select x).ToArray()));
			Preset = SettingsCategoryPreset.None;
			AvailablePresets = new List<SettingsCategoryPreset> { SettingsCategoryPreset.None };
			SubSettingsVisibility = SettingVisibility.Default;
			SubSettingVisibilityCheck = (SettingsCategoryPreset preset) => (preset != SettingsCategoryPreset.Custom && preset != SettingsCategoryPreset.None) ? SettingVisibility.ReadOnly : SettingVisibility.Default;
		}

		public static List<SettingsCategory> InitializeCategoryProperties<T>(T obj, XElement xml, GetDefaultSettingsCategoryPreset defaultPresetProvider = null, GetRegisteredSettingsCategoryPresets registeredPresetsProvider = null)
		{
			List<SettingsCategory> list = new List<SettingsCategory>();
			PropertyInfo[] properties = typeof(T).GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (typeof(SettingsCategory).IsAssignableFrom(propertyInfo.PropertyType))
				{
					object obj2 = propertyInfo.GetValue(obj);
					if (obj2 == null)
					{
						obj2 = Activator.CreateInstance(propertyInfo.PropertyType);
						propertyInfo.SetValue(obj, obj2);
					}
					list.Add((SettingsCategory)obj2);
				}
			}
			if (defaultPresetProvider != null)
			{
				foreach (SettingsCategory item in list)
				{
					item._defaultPresetProvider = defaultPresetProvider;
				}
			}
			if (registeredPresetsProvider != null)
			{
				foreach (SettingsCategory item2 in list)
				{
					foreach (var item3 in registeredPresetsProvider(item2))
					{
						item2.RegisterPresetList(item3.DeviceFlags, item3.Presets.ToArray());
					}
				}
			}
			list.Sort((SettingsCategory x, SettingsCategory y) => x.Order.CompareTo(y.Order));
			InitializeCategoryProperties(list, xml);
			return list;
		}

		public static void InitializeCategoryProperties(List<SettingsCategory> categories, XElement xml)
		{
			categories = categories.Where((SettingsCategory x) => !x._initialized).ToList();
			foreach (SettingsCategory category in categories)
			{
				category.Initialize();
			}
			foreach (SettingsCategory category2 in categories)
			{
				category2.RestoreFromXml(xml);
			}
			foreach (SettingsCategory category3 in categories)
			{
				category3.CommitChanges();
				category3.HasUnsavedChanges = false;
			}
			foreach (SettingsCategory category4 in categories)
			{
				category4.OnInitializationComplete();
			}
		}

		public void CommitChanges()
		{
			bool flag = false;
			foreach (Setting setting in Settings)
			{
				flag |= setting.PendingChange;
				setting.CommitChanges(suppressCategoryChangedEvent: true);
			}
			_originalPreset = Preset;
			if (flag)
			{
				RaiseSettingsChangedEvent();
			}
		}

		public virtual SettingsCategoryPreset GetDefaultPreset()
		{
			GetDefaultSettingsCategoryPreset defaultPresetProvider = _defaultPresetProvider;
			if (defaultPresetProvider == null)
			{
				IReadOnlyList<SettingsCategoryPreset> availablePresets = AvailablePresets;
				if (availablePresets == null || availablePresets.Count <= 0)
				{
					return SettingsCategoryPreset.None;
				}
				return AvailablePresets[0];
			}
			return defaultPresetProvider(this);
		}

		public void Initialize()
		{
			if (_initialized)
			{
				return;
			}
			_initialized = true;
			InitializeSettings();
			List<Setting> list = new List<Setting>();
			PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (typeof(Setting).IsAssignableFrom(propertyInfo.PropertyType))
				{
					Setting setting = (Setting)propertyInfo.GetValue(this);
					if (setting != null)
					{
						list.Add(setting);
						continue;
					}
					Debug.LogWarning("Could not get initial value for setting: \"" + CategoryName + "." + propertyInfo.Name + "\".  Was it properly initialized in InitializeSettings()?");
				}
			}
			Settings = list.OrderBy((Setting x) => x.DisplayOrder).ToList();
			_originalPreset = GetDefaultPreset();
		}

		public abstract void RaiseSettingsChangedEvent();

		public virtual void RestoreFromXml(XElement settingsXml)
		{
			if (State == SettingState.Disabled)
			{
				return;
			}
			XElement xElement = settingsXml?.Element(CategoryXmlName);
			if (xElement == null)
			{
				SetPreset(GetDefaultPreset());
				return;
			}
			Expanded = xElement.GetBoolAttribute("expanded", defaultValue: true);
			if (!Enum.TryParse<SettingsCategoryPreset>((string)xElement.Attribute("preset"), out var result))
			{
				result = GetDefaultPreset();
			}
			if (!AvailablePresets.Contains(result))
			{
				result = GetDefaultPreset();
			}
			if (result == SettingsCategoryPreset.Custom)
			{
				SetPreset(GetDefaultPreset());
			}
			SetPreset(result);
			if (result != SettingsCategoryPreset.None && result != SettingsCategoryPreset.Custom)
			{
				return;
			}
			foreach (Setting setting in Settings)
			{
				try
				{
					setting.RestoreFromXml(xElement);
				}
				catch (Exception exception)
				{
					Debug.LogError("Error restoring setting '" + setting.XmlName + "' in category '" + setting.Category.CategoryXmlName + "' from XML '" + ((xElement == null) ? string.Empty : xElement.ToString()) + "'.");
					Debug.LogException(exception);
				}
			}
		}

		public void RevertChanges()
		{
			Preset = _originalPreset;
			foreach (Setting setting in Settings)
			{
				setting.RevertChanges();
			}
		}

		public virtual void SaveToXml(XElement settingsXml, bool preserveUnsavedChangesFlag = false)
		{
			if (State == SettingState.Disabled || State == SettingState.HiddenReadOnly)
			{
				return;
			}
			XElement xElement = new XElement(CategoryXmlName);
			xElement.SetAttributeValue("expanded", Expanded);
			if (Preset != SettingsCategoryPreset.None)
			{
				xElement.SetAttributeValue("preset", Preset);
			}
			if (Preset == SettingsCategoryPreset.None || Preset == SettingsCategoryPreset.Custom)
			{
				foreach (Setting setting in Settings)
				{
					setting.SaveToXml(xElement);
				}
			}
			XElement xElement2 = settingsXml.Element(xElement.Name.LocalName);
			if (xElement2 == null)
			{
				settingsXml.Add(xElement);
			}
			else
			{
				xElement2.ReplaceWith(xElement);
			}
			if (!preserveUnsavedChangesFlag)
			{
				HasUnsavedChanges = false;
			}
		}

		public void SetPreset(SettingsCategoryPreset preset)
		{
			if (!AvailablePresets.Contains(preset))
			{
				preset = ((AvailablePresets.Count > 0) ? AvailablePresets[0] : SettingsCategoryPreset.None);
				Debug.LogError($"Preset '{preset}' is not available for settings category '{CategoryName}'. Defaulting to  '{Preset}'.");
			}
			Preset = preset;
			SubSettingsVisibility = SubSettingVisibilityCheck(Preset);
			ApplyPreset(Preset, Device.Flags);
		}

		protected internal virtual void OnSettingChanged(Setting setting)
		{
		}

		protected internal virtual void OnSettingCommitted(Setting setting, bool suppressCategoryChangedEvent)
		{
			if ((State == SettingState.Enabled || State == SettingState.Hidden) && (setting.State == SettingState.Enabled || setting.State == SettingState.Hidden))
			{
				HasUnsavedChanges = true;
			}
			if (!suppressCategoryChangedEvent)
			{
				RaiseSettingsChangedEvent();
			}
		}

		protected virtual void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
		}

		protected BoolSetting.BoolSettingBuilder CreateBool(string displayName, string xmlName = null)
		{
			return BoolSetting.Create(displayName, this, xmlName);
		}

		protected EnumSetting<T>.EnumSettingBuilder CreateEnum<T>(string displayName, string xmlName = null) where T : struct
		{
			return EnumSetting<T>.Create(displayName, this, xmlName);
		}

		protected NumericSetting<T>.NumericSettingBuilder CreateNumeric<T>(string displayName, T min, T max, T step, string xmlName = null) where T : struct, IComparable, IComparable<T>, IEquatable<T>
		{
			return NumericSetting<T>.Create(displayName, this, min, max, step, xmlName);
		}

		protected StringSetting.StringSettingBuilder CreateString(string displayName, string xmlName = null)
		{
			return StringSetting.Create(displayName, this, xmlName);
		}

		protected abstract void InitializeSettings();

		protected virtual void OnInitializationComplete()
		{
		}

		protected void RegisterPresetList(params SettingsCategoryPreset[] presets)
		{
			RegisterPresetList(DeviceFlags.All, presets);
		}

		protected void RegisterPresetList(DeviceFlags devices, params SettingsCategoryPreset[] presets)
		{
			if (Device.HasAnyFlag(devices))
			{
				if (presets == null || presets.Length == 0)
				{
					Debug.LogError("No presets were specified.");
					presets = new SettingsCategoryPreset[1];
				}
				AvailablePresets = new List<SettingsCategoryPreset>(presets);
			}
		}

		protected void RegisterSubSettingsVisibilityCheck(Func<SettingsCategoryPreset, SettingVisibility> visibilityCheck)
		{
			RegisterSubSettingsVisibilityCheck(DeviceFlags.All, visibilityCheck);
		}

		protected void RegisterSubSettingsVisibilityCheck(DeviceFlags devices, Func<SettingsCategoryPreset, SettingVisibility> visibilityCheck)
		{
			if (Device.HasAnyFlag(devices))
			{
				SubSettingVisibilityCheck = visibilityCheck;
			}
		}
	}
	public abstract class SettingsCategory<T> : SettingsCategory where T : SettingsCategory<T>
	{
		private SettingsChangedEventArgs<T> _changedEventArgs;

		public event EventHandler<SettingsChangedEventArgs<T>> Changed
		{
			add
			{
				_changed += WeakEventHandler.Create(value, delegate(EventHandler<SettingsChangedEventArgs<T>> x)
				{
					_changed -= x;
				});
			}
			remove
			{
				_changed -= WeakEventHandler.FindUnregisterHandler(this._changed, value);
			}
		}

		private event EventHandler<SettingsChangedEventArgs<T>> _changed;

		protected SettingsCategory(string categoryName)
			: this(categoryName, SettingState.Enabled)
		{
		}

		protected SettingsCategory(string categoryName, SettingState state)
			: base(categoryName, state)
		{
			_changedEventArgs = new SettingsChangedEventArgs<T>((T)this);
		}

		public override void RaiseSettingsChangedEvent()
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
	}
}
