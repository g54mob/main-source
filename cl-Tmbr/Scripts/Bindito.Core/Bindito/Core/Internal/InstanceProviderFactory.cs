using System;

namespace Bindito.Core.Internal
{
	public class InstanceProviderFactory : IInstanceProviderFactory
	{
		private readonly IInstanceProviderFuncFactory _instanceProviderFuncFactory;

		private readonly IScoper _scoper;

		public InstanceProviderFactory(IInstanceProviderFuncFactory instanceProviderFuncFactory, IScoper scoper)
		{
			_instanceProviderFuncFactory = instanceProviderFuncFactory;
			_scoper = scoper;
		}

		public InstanceProvider CreateInstanceProvider(Binding binding)
		{
			Func<object> provider = _instanceProviderFuncFactory.CreateInstanceProviderFunc(binding.ProvisionBinding);
			return new InstanceProvider(_scoper.PlaceInScope(provider, binding.Scope), binding.Exported);
		}
	}
}
