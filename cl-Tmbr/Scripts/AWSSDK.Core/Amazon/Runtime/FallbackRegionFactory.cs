using System;
using System.Collections.Generic;
using Amazon.Runtime.CredentialManagement;

namespace Amazon.Runtime
{
	public static class FallbackRegionFactory
	{
		private delegate AWSRegion RegionGenerator();

		private static CredentialProfileStoreChain credentialProfileChain;

		private static object _lock;

		private static AWSRegion cachedRegion;

		private static List<RegionGenerator> AllGenerators { get; set; }

		private static List<RegionGenerator> NonMetadataGenerators { get; set; }

		static FallbackRegionFactory()
		{
			credentialProfileChain = new CredentialProfileStoreChain();
			_lock = new object();
			Reset();
		}

		public static void Reset()
		{
			cachedRegion = null;
			AllGenerators = new List<RegionGenerator>
			{
				() => new AppConfigAWSRegion(),
				() => new EnvironmentVariableAWSRegion(),
				() => new ProfileAWSRegion(credentialProfileChain),
				() => new InstanceProfileAWSRegion()
			};
			NonMetadataGenerators = new List<RegionGenerator>
			{
				() => new AppConfigAWSRegion(),
				() => new EnvironmentVariableAWSRegion(),
				() => new ProfileAWSRegion(credentialProfileChain)
			};
		}

		public static RegionEndpoint GetRegionEndpoint()
		{
			return GetRegionEndpoint(includeInstanceMetadata: true);
		}

		public static RegionEndpoint GetRegionEndpoint(bool includeInstanceMetadata)
		{
			lock (_lock)
			{
				if (cachedRegion != null)
				{
					return cachedRegion.Region;
				}
				List<Exception> list = new List<Exception>();
				foreach (RegionGenerator item2 in (IEnumerable<RegionGenerator>)(includeInstanceMetadata ? AllGenerators : NonMetadataGenerators))
				{
					try
					{
						cachedRegion = item2();
					}
					catch (Exception item)
					{
						cachedRegion = null;
						list.Add(item);
					}
					if (cachedRegion != null)
					{
						break;
					}
				}
				return (cachedRegion != null) ? cachedRegion.Region : null;
			}
		}
	}
}
