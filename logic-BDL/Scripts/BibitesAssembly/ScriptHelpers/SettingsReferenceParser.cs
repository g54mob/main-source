using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using SettingScripts;

namespace ScriptHelpers
{
	public class SettingsReferenceParser
	{
		private static Regex zoneRegex = new Regex("^Zone\\(([^\"]+)\\)\\.(.+)$");

		public static ChangingSetting GetSetting(string key)
		{
			Match isZone = zoneRegex.Match(key);
			FieldInfo field;
			if (isZone.Success)
			{
				ZoneSettings zoneSettings = ScenarioSettings.Instance.zones.FirstOrDefault((ZoneSettings z) => z.zoneName.val == isZone.Groups[1].Value);
				if (zoneSettings == null)
				{
					return null;
				}
				field = typeof(ZoneSettings).GetField(isZone.Groups[2].Value, BindingFlags.Instance | BindingFlags.Public);
				if (field != null && field.GetValue(zoneSettings) is ChangingSetting result)
				{
					return result;
				}
			}
			field = typeof(ScenarioSettings).GetField(key, BindingFlags.Instance | BindingFlags.Public);
			if (field != null && field.GetValue(ScenarioSettings.Instance) is ChangingSetting result2)
			{
				return result2;
			}
			field = typeof(ScenarioIndependentSettings).GetField(key, BindingFlags.Instance | BindingFlags.Public);
			if (field != null && field.GetValue(ScenarioIndependentSettings.Instance) is ChangingSetting result3)
			{
				return result3;
			}
			return null;
		}

		public static string GetKeyOfSetting(ChangingSetting setting)
		{
			FieldInfo fieldInfo = typeof(ScenarioSettings).GetFields(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((FieldInfo f) => f.GetValue(ScenarioSettings.Instance) == setting);
			if (fieldInfo != null)
			{
				return fieldInfo.Name;
			}
			fieldInfo = typeof(ScenarioIndependentSettings).GetFields(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((FieldInfo f) => f.GetValue(ScenarioIndependentSettings.Instance) == setting);
			if (fieldInfo != null)
			{
				return fieldInfo.Name;
			}
			FieldInfo[] fields = typeof(ZoneSettings).GetFields(BindingFlags.Instance | BindingFlags.Public);
			foreach (ZoneSettings zone in ScenarioSettings.Instance.zones)
			{
				fieldInfo = fields.FirstOrDefault((FieldInfo f) => f.GetValue(zone) == setting);
				if (fieldInfo != null)
				{
					return "Zone(" + zone.zoneName.val + ")." + fieldInfo.Name;
				}
			}
			return null;
		}
	}
}
