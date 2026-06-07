namespace GPUInstancerPro.PrefabModule
{
	public static class GPUIPrefabConstants
	{
		private static string _packagesPath;

		public static readonly string Kw_GPUI_MATERIAL_VARIATION = "GPUI_MATERIAL_VARIATION";

		public static string GetPackagesPath()
		{
			if (string.IsNullOrEmpty(_packagesPath))
			{
				_packagesPath = "Packages/com.gurbu.gpui-pro.prefab/";
			}
			return _packagesPath;
		}
	}
}
