using System.Reflection;
using SettingScripts;

namespace ScriptHelpers
{
	public static class ObjectExtend
	{
		public static void CopyProperties(this object source, object destination)
		{
			PropertyInfo[] properties = destination.GetType().GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				PropertyInfo property = source.GetType().GetProperty(propertyInfo.Name);
				propertyInfo.SetValue(destination, property.GetValue(source, null), null);
			}
		}

		public static void CopySettings<T>(this T source, T destination, bool forceUpdate = false)
		{
			FieldInfo[] fields = typeof(T).GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!typeof(IForceUpdateSetting).IsAssignableFrom(fieldInfo.FieldType))
				{
					continue;
				}
				object value = fieldInfo.GetValue(source);
				if (value == null)
				{
					continue;
				}
				object value2 = fieldInfo.GetValue(destination);
				PropertyInfo property = fieldInfo.FieldType.GetProperty("val");
				if (!(property == null))
				{
					property.SetValue(value2, property.GetValue(value, null), null);
					if (forceUpdate)
					{
						(value2 as IForceUpdateSetting)?.ForceUpdate();
					}
				}
			}
		}
	}
}
