using System;

namespace Bindito.Core.Internal
{
	public interface IScoper
	{
		Func<object> PlaceInScope(Func<object> provider, Scope scope);
	}
}
