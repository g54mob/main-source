using System;
using NSubstitute.Core.DependencyInjection;

namespace NSubstitute.Core
{
	public static class CallSpecificationFactoryFactoryYesThatsRight
	{
		[Obsolete("This factory is deprecated and will be removed in future versions of the product. Please use 'SubstitutionContext.Current.CallSpecificationFactory' instead. Use NSubstituteDefaultFactory services if you need to activate a new instance.")]
		public static ICallSpecificationFactory CreateCallSpecFactory()
		{
			return NSubstituteDefaultFactory.DefaultContainer.Resolve<ICallSpecificationFactory>();
		}
	}
}
