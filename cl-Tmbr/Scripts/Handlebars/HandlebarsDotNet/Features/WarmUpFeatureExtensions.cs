using System;
using System.Collections.Generic;

namespace HandlebarsDotNet.Features
{
	public static class WarmUpFeatureExtensions
	{
		public static HandlebarsConfiguration UseWarmUp(this HandlebarsConfiguration configuration, Action<ICollection<Type>> configure)
		{
			HashSet<Type> hashSet = new HashSet<Type>();
			configure(hashSet);
			configuration.CompileTimeConfiguration.Features.Add(new WarmUpFeatureFactory(hashSet));
			return configuration;
		}
	}
}
