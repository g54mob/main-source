using UnityEngine;

namespace Restory.Data.SaveLoad.Providers
{
	public static class DataProviders
	{
		private static readonly MonoSaveDataProvider monoProvider = new MonoSaveDataProvider();

		private static readonly EmptyDataProvider emptyProvider = new EmptyDataProvider();

		public static IJsonSaveDataProvider GetJsonProvider()
		{
			RuntimePlatform platform = Application.platform;
			if ((uint)platform <= 2u || platform == RuntimePlatform.WindowsEditor)
			{
				return monoProvider;
			}
			return emptyProvider;
		}

		public static IJsonSaveDataProviderAsync GetAsyncJsonProvider()
		{
			RuntimePlatform platform = Application.platform;
			if ((uint)platform <= 2u || platform == RuntimePlatform.WindowsEditor)
			{
				return monoProvider;
			}
			return emptyProvider;
		}

		public static IBinarySaveDataProviderAsync GetAsyncBinaryProvider()
		{
			return monoProvider;
		}
	}
}
