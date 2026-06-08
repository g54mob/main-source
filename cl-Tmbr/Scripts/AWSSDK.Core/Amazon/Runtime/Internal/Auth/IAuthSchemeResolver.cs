using System.Collections.Generic;

namespace Amazon.Runtime.Internal.Auth
{
	public interface IAuthSchemeResolver<T> where T : IAuthSchemeParameters
	{
		List<IAuthSchemeOption> ResolveAuthScheme(T authParameters);
	}
}
