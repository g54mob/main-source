using System;
using System.Reflection;

namespace Bindito.Core.Internal
{
	public interface IConstructorRetriever
	{
		ConstructorInfo GetEligibleConstructor(Type type);
	}
}
