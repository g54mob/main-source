using System;
using System.Collections.Generic;
using Amazon.Runtime.Identity;

namespace Amazon.Runtime.Credentials.Internal
{
	public class DefaultIdentityResolverConfiguration : IIdentityResolverConfiguration
	{
		public static readonly IIdentityResolverConfiguration Instance = new DefaultIdentityResolverConfiguration();

		private static readonly Dictionary<Type, IIdentityResolver> identityResolvers = new Dictionary<Type, IIdentityResolver>
		{
			{
				typeof(AnonymousAWSCredentials),
				new AnonymousIdentityResolver()
			},
			{
				typeof(AWSCredentials),
				new DefaultAWSCredentialsIdentityResolver()
			},
			{
				typeof(AWSToken),
				new DefaultAWSTokenIdentityResolver()
			}
		};

		public IIdentityResolver GetIdentityResolver<T>() where T : BaseIdentity
		{
			if (identityResolvers.TryGetValue(typeof(T), out var value))
			{
				return value;
			}
			throw new NotImplementedException(typeof(T).Name + " is not supported");
		}

		public static T ResolveDefaultIdentity<T>() where T : BaseIdentity
		{
			return Instance.GetIdentityResolver<T>().ResolveIdentity(null) as T;
		}
	}
}
