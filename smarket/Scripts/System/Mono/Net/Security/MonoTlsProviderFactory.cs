using System;
using System.Collections.Generic;

namespace Mono.Net.Security
{
	internal static class MonoTlsProviderFactory
	{
		private static object locker;

		private static bool initialized;

		private static MobileTlsProvider defaultProvider;

		private static Dictionary<string, Tuple<Guid, string>> providerRegistration;

		private static Dictionary<Guid, MobileTlsProvider> providerCache;

		internal static readonly Guid UnityTlsId;

		internal static readonly Guid AppleTlsId;

		internal static readonly Guid BtlsId;

		internal static MobileTlsProvider GetProviderInternal()
		{
			return null;
		}

		internal static void InitializeInternal()
		{
		}

		private static MobileTlsProvider LookupProvider(string name, bool throwOnError)
		{
			return null;
		}

		private static void InitializeProviderRegistration()
		{
		}

		private static void PopulateUnityProviders()
		{
		}

		private static void PopulateProviders()
		{
		}

		internal static bool IsBtlsSupported()
		{
			return false;
		}

		private static MobileTlsProvider CreateDefaultProviderImpl()
		{
			return null;
		}

		internal static MobileTlsProvider GetProvider()
		{
			return null;
		}
	}
}
