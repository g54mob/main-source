using System;

namespace NSubstitute.Core.DependencyInjection
{
	public static class ConfigurableNSubContainerExtensions
	{
		public static IConfigurableNSubContainer RegisterPerScope<TKey, TImpl>(this IConfigurableNSubContainer container) where TKey : notnull where TImpl : TKey
		{
			return container.Register<TKey, TImpl>(NSubLifetime.PerScope);
		}

		public static IConfigurableNSubContainer RegisterPerScope<TKey>(this IConfigurableNSubContainer container, Func<INSubResolver, TKey> factory) where TKey : notnull
		{
			return container.Register(factory, NSubLifetime.PerScope);
		}

		public static IConfigurableNSubContainer RegisterSingleton<TKey, TImpl>(this IConfigurableNSubContainer container) where TKey : notnull where TImpl : TKey
		{
			return container.Register<TKey, TImpl>(NSubLifetime.Singleton);
		}
	}
}
