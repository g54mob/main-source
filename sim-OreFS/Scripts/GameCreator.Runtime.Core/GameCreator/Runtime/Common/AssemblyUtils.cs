using System;

namespace GameCreator.Runtime.Common
{
	public static class AssemblyUtils
	{
		[field: NonSerialized]
		public static bool IsReloading { get; private set; }

		static AssemblyUtils()
		{
		}

		private static void OnBeforeAssemblyReload()
		{
			IsReloading = true;
		}

		private static void OnAfterAssemblyReload()
		{
			IsReloading = false;
		}
	}
}
