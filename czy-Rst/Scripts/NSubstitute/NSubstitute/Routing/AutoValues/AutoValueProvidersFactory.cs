using System;
using System.Collections.Generic;
using System.Threading;
using NSubstitute.Core;
using NSubstitute.Exceptions;

namespace NSubstitute.Routing.AutoValues
{
	public class AutoValueProvidersFactory : IAutoValueProvidersFactory
	{
		public IReadOnlyCollection<IAutoValueProvider> CreateProviders(ISubstituteFactory substituteFactory)
		{
			IAutoValueProvider[] result = null;
			Lazy<IReadOnlyCollection<IAutoValueProvider>> autoValueProviders = new Lazy<IReadOnlyCollection<IAutoValueProvider>>(() => result ?? throw new SubstituteInternalException("Value was not constructed yet."), LazyThreadSafetyMode.PublicationOnly);
			result = new IAutoValueProvider[6]
			{
				new AutoObservableProvider(autoValueProviders),
				new AutoQueryableProvider(),
				new AutoSubstituteProvider(substituteFactory),
				new AutoStringProvider(),
				new AutoArrayProvider(),
				new AutoTaskProvider(autoValueProviders)
			};
			return result;
		}
	}
}
