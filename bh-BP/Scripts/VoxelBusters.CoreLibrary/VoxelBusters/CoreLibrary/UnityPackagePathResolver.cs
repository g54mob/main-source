namespace VoxelBusters.CoreLibrary
{
	public static class UnityPackagePathResolver
	{
		public static bool IsInstalledWithinAssets(this UnityPackageDefinition package)
		{
			return false;
		}

		public static string GetInstallPath(this UnityPackageDefinition package)
		{
			return null;
		}

		public static string GetRuntimeScriptsPath(this UnityPackageDefinition package)
		{
			return null;
		}

		public static string GetEditorScriptsPath(this UnityPackageDefinition package)
		{
			return null;
		}

		public static string GetEditorResourcesPath(this UnityPackageDefinition package)
		{
			return null;
		}

		public static string GetMutableResourcesPath(this UnityPackageDefinition package)
		{
			return null;
		}

		public static string GetImmutableResourcesPath(this UnityPackageDefinition package)
		{
			return null;
		}

		public static string GetPackageResourcesPath(this UnityPackageDefinition package)
		{
			return null;
		}

		public static string GetFullPath(this UnityPackageDefinition package, string relativePath)
		{
			return null;
		}

		public static string GetMutableResourceRelativePath(this UnityPackageDefinition package, string name)
		{
			return null;
		}

		public static string GetExtrasPath(this UnityPackageDefinition package)
		{
			return null;
		}

		public static string GetEssentialsPath(this UnityPackageDefinition package)
		{
			return null;
		}

		public static string GetGeneratedPath(this UnityPackageDefinition package)
		{
			return null;
		}

		private static bool IsSupported()
		{
			return false;
		}

		private static string CombinePath(string pathA, string pathB)
		{
			return null;
		}
	}
}
