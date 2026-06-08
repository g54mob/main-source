using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public interface IDependencyRetriever
	{
		IEnumerable<Type> GetDependencies(ProvisionBinding provisionBinding);
	}
}
