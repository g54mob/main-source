using System;

namespace Bindito.Core.Internal
{
	public interface IInstanceProviderFuncFactory
	{
		Func<object> CreateInstanceProviderFunc(ProvisionBinding provisionBinding);
	}
}
