using System;

namespace Bindito.Core.Internal
{
	public class BindingBuilder<TBound> : IBindingBuilder, ISingleBindingBuilder<TBound>, IBindingBuilder<TBound>, IScopeAssignee, IMultiBindingBuilder<TBound>, IExportAssignee where TBound : class
	{
		private ProvisionBinding _provisionBinding = ProvisionBinding.CreateToType(typeof(TBound));

		private Scope? _scope;

		private bool _exported;

		public IScopeAssignee To<TImplementation>() where TImplementation : class, TBound
		{
			_provisionBinding = ProvisionBinding.CreateToType(typeof(TImplementation));
			return this;
		}

		public IScopeAssignee ToProvider<TProvider>() where TProvider : IProvider<TBound>
		{
			_provisionBinding = ProvisionBinding.CreateToProviderType(typeof(TProvider));
			return this;
		}

		public IScopeAssignee ToProvider(IProvider<TBound> provider)
		{
			_provisionBinding = ProvisionBinding.CreateToProviderInstance(provider);
			return this;
		}

		public IScopeAssignee ToProvider(Func<TBound> provider)
		{
			_provisionBinding = ProvisionBinding.CreateToProvidingMethod(provider);
			return this;
		}

		public IExportAssignee ToInstance(TBound instance)
		{
			_provisionBinding = ProvisionBinding.CreateToInstance(instance);
			_scope = Scope.Singleton;
			return this;
		}

		public IExportAssignee ToExisting<TExisting>() where TExisting : TBound
		{
			_provisionBinding = ProvisionBinding.CreateToExisting(typeof(TExisting));
			_scope = Scope.Singleton;
			return this;
		}

		public IExportAssignee AsSingleton()
		{
			_scope = Scope.Singleton;
			return this;
		}

		public IExportAssignee AsTransient()
		{
			_scope = Scope.Transient;
			return this;
		}

		public void AsExported()
		{
			_exported = true;
		}

		public Binding Build()
		{
			if (!_scope.HasValue)
			{
				throw new BinditoException(TypeFormatting.Format(typeof(TBound)) + " binding has unspecified scope.");
			}
			return new Binding(_provisionBinding, _scope.Value, _exported);
		}
	}
}
