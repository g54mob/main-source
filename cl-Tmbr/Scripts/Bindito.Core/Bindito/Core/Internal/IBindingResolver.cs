using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public interface IBindingResolver
	{
		bool ResolveBindings(Type type, out IEnumerable<Binding> ownBindings);
	}
}
