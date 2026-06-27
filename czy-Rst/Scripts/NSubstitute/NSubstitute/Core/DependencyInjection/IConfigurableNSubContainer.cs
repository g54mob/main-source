using System;

namespace NSubstitute.Core.DependencyInjection
{
	public interface IConfigurableNSubContainer : INSubContainer, INSubResolver
	{
		IConfigurableNSubContainer Register<TKey, TImpl>(NSubLifetime lifetime) where TKey : notnull where TImpl : TKey;

		IConfigurableNSubContainer Register<TKey>(Func<INSubResolver, TKey> factory, NSubLifetime lifetime) where TKey : notnull;

		IConfigurableNSubContainer Decorate<TKey>(Func<TKey, INSubResolver, TKey> factory) where TKey : notnull;
	}
}
