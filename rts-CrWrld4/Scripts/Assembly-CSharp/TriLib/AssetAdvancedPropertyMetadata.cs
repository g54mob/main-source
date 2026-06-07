namespace TriLib
{
	public static class AssetAdvancedPropertyMetadata
	{
		public const int GroupCount = 35;

		public static readonly string[] ConfigKeys;

		public static string GetConfigKey(AssetAdvancedPropertyClassNames className)
		{
			return null;
		}

		public static void GetOptionMetadata(string key, out AssetAdvancedConfigType assetAdvancedConfigType, out string className, out string description, out string group, out object defaultValue, out object minValue, out object maxValue, out bool hasDefaultValue, out bool hasMinValue, out bool hasMaxValue)
		{
			assetAdvancedConfigType = default(AssetAdvancedConfigType);
			className = null;
			description = null;
			group = null;
			defaultValue = null;
			minValue = null;
			maxValue = null;
			hasDefaultValue = default(bool);
			hasMinValue = default(bool);
			hasMaxValue = default(bool);
		}
	}
}
