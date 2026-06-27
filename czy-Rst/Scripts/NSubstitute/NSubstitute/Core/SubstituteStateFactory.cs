using System.Collections.Generic;
using NSubstitute.Routing.AutoValues;

namespace NSubstitute.Core
{
	public class SubstituteStateFactory : ISubstituteStateFactory
	{
		public SubstituteStateFactory(ICallSpecificationFactory callSpecificationFactory, ICallInfoFactory callInfoFactory, IAutoValueProvidersFactory autoValueProvidersFactory)
		{
			_003CcallSpecificationFactory_003EP = callSpecificationFactory;
			_003CcallInfoFactory_003EP = callInfoFactory;
			_003CautoValueProvidersFactory_003EP = autoValueProvidersFactory;
			base._002Ector();
		}

		public ISubstituteState Create(ISubstituteFactory substituteFactory)
		{
			IReadOnlyCollection<IAutoValueProvider> autoValueProviders = _003CautoValueProvidersFactory_003EP.CreateProviders(substituteFactory);
			return new SubstituteState(_003CcallSpecificationFactory_003EP, _003CcallInfoFactory_003EP, autoValueProviders);
		}
	}
}
