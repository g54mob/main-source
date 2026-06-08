using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public interface IInstanceProviderBank
	{
		bool TryGetInstanceProvider(Type type, out InstanceProvider instanceProvider);

		bool TryGetExportedInstanceProvider(Type type, out InstanceProvider instanceProvider);

		IEnumerable<InstanceProvider> GetInstanceProviders(Type type);

		IEnumerable<InstanceProvider> GetExportedInstanceProviders(Type type);
	}
}
