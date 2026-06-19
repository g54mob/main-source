using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SharpConfig
{
	public sealed class Section : ConfigurationElement, IEnumerable<Setting>, IEnumerable
	{
		private readonly List<Setting> mSettings;

		public int SettingCount => mSettings.Count;

		public Setting this[int index]
		{
			get
			{
				if (index < 0 || index >= mSettings.Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return mSettings[index];
			}
		}

		public Setting this[string name]
		{
			get
			{
				Setting setting = FindSetting(name);
				if (setting == null)
				{
					setting = new Setting(name);
					mSettings.Add(setting);
				}
				return setting;
			}
		}

		public Section(string name)
			: base(name)
		{
			mSettings = new List<Setting>();
		}

		public static Section FromObject(string name, object obj)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("The section name must not be null or empty.", "name");
			}
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			Section section = new Section(name);
			Type type = obj.GetType();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.CanRead && !ShouldIgnoreMappingFor(propertyInfo))
				{
					Setting item = new Setting(propertyInfo.Name, propertyInfo.GetValue(obj, null));
					section.mSettings.Add(item);
				}
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!ShouldIgnoreMappingFor(fieldInfo))
				{
					Setting item2 = new Setting(fieldInfo.Name, fieldInfo.GetValue(obj));
					section.mSettings.Add(item2);
				}
			}
			return section;
		}

		public T ToObject<T>() where T : new()
		{
			T val = new T();
			SetValuesTo(val);
			return val;
		}

		public object ToObject(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(type.Name);
			}
			object obj = Activator.CreateInstance(type);
			SetValuesTo(obj);
			return obj;
		}

		public void GetValuesFrom(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			Type type = obj.GetType();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.CanRead && !ShouldIgnoreMappingFor(propertyInfo))
				{
					Setting setting = FindSetting(propertyInfo.Name);
					if (setting != null)
					{
						object value = propertyInfo.GetValue(obj, null);
						setting.SetValue(value);
					}
				}
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!ShouldIgnoreMappingFor(fieldInfo))
				{
					Setting setting2 = FindSetting(fieldInfo.Name);
					if (setting2 != null)
					{
						object value2 = fieldInfo.GetValue(obj);
						setting2.SetValue(value2);
					}
				}
			}
		}

		public void SetValuesTo(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			Type type = obj.GetType();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!propertyInfo.CanWrite || ShouldIgnoreMappingFor(propertyInfo))
				{
					continue;
				}
				Setting setting = FindSetting(propertyInfo.Name);
				if (setting == null)
				{
					continue;
				}
				object value = setting.GetValue(propertyInfo.PropertyType);
				if (value is Array)
				{
					Array array = value as Array;
					Array array2 = propertyInfo.GetValue(obj, null) as Array;
					if (array2 == null || array2.Length != array.Length)
					{
						array2 = Array.CreateInstance(propertyInfo.PropertyType.GetElementType(), array.Length);
					}
					for (int j = 0; j < array.Length; j++)
					{
						array2.SetValue(array.GetValue(j), j);
					}
					propertyInfo.SetValue(obj, array2, null);
				}
				else
				{
					propertyInfo.SetValue(obj, value, null);
				}
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.IsInitOnly || ShouldIgnoreMappingFor(fieldInfo))
				{
					continue;
				}
				Setting setting2 = FindSetting(fieldInfo.Name);
				if (setting2 == null)
				{
					continue;
				}
				object value2 = setting2.GetValue(fieldInfo.FieldType);
				if (value2 is Array)
				{
					Array array3 = value2 as Array;
					Array array4 = fieldInfo.GetValue(obj) as Array;
					if (array4 == null || array4.Length != array3.Length)
					{
						array4 = Array.CreateInstance(fieldInfo.FieldType.GetElementType(), array3.Length);
					}
					for (int k = 0; k < array3.Length; k++)
					{
						array4.SetValue(array3.GetValue(k), k);
					}
					fieldInfo.SetValue(obj, array4);
				}
				else
				{
					fieldInfo.SetValue(obj, value2);
				}
			}
		}

		private static bool ShouldIgnoreMappingFor(MemberInfo member)
		{
			if (member.GetCustomAttributes(typeof(IgnoreAttribute), inherit: false).Length != 0)
			{
				return true;
			}
			PropertyInfo propertyInfo = member as PropertyInfo;
			if (propertyInfo != null)
			{
				return propertyInfo.PropertyType.GetCustomAttributes(typeof(IgnoreAttribute), inherit: false).Length != 0;
			}
			FieldInfo fieldInfo = member as FieldInfo;
			if (fieldInfo != null)
			{
				return fieldInfo.FieldType.GetCustomAttributes(typeof(IgnoreAttribute), inherit: false).Length != 0;
			}
			return false;
		}

		public IEnumerator<Setting> GetEnumerator()
		{
			return mSettings.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(Setting setting)
		{
			if (setting == null)
			{
				throw new ArgumentNullException("setting");
			}
			if (Contains(setting))
			{
				throw new ArgumentException("The specified setting already exists in the section.");
			}
			mSettings.Add(setting);
		}

		public bool Remove(string settingName)
		{
			if (string.IsNullOrEmpty(settingName))
			{
				throw new ArgumentNullException("settingName");
			}
			return Remove(FindSetting(settingName));
		}

		public bool Remove(Setting setting)
		{
			return mSettings.Remove(setting);
		}

		public void RemoveAllNamed(string settingName)
		{
			if (string.IsNullOrEmpty(settingName))
			{
				throw new ArgumentNullException("settingName");
			}
			while (Remove(settingName))
			{
			}
		}

		public void Clear()
		{
			mSettings.Clear();
		}

		public bool Contains(Setting setting)
		{
			return mSettings.Contains(setting);
		}

		public bool Contains(string settingName)
		{
			if (string.IsNullOrEmpty(settingName))
			{
				throw new ArgumentNullException("settingName");
			}
			return FindSetting(settingName) != null;
		}

		public IEnumerable<Setting> GetSettingsNamed(string name)
		{
			List<Setting> list = new List<Setting>();
			foreach (Setting mSetting in mSettings)
			{
				if (string.Equals(mSetting.Name, name, StringComparison.OrdinalIgnoreCase))
				{
					list.Add(mSetting);
				}
			}
			return list;
		}

		private Setting FindSetting(string name)
		{
			foreach (Setting mSetting in mSettings)
			{
				if (string.Equals(mSetting.Name, name, StringComparison.OrdinalIgnoreCase))
				{
					return mSetting;
				}
			}
			return null;
		}

		protected override string GetStringExpression()
		{
			return $"[{base.Name}]";
		}
	}
}
