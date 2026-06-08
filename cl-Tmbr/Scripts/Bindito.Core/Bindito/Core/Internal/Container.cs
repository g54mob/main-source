using System;
using System.Collections.Generic;
using System.Linq;

namespace Bindito.Core.Internal
{
	public class Container : IContainer
	{
		private readonly IInstanceBank _instanceBank;

		private readonly IValidatingMethodInjector _validatingMethodInjector;

		private readonly IBoundInstanceService _boundInstanceService;

		private readonly IContainerCreator _ownCreator;

		public Container(IInstanceBank instanceBank, IValidatingMethodInjector validatingMethodInjector, IBoundInstanceService boundInstanceService, IContainerCreator ownCreator)
		{
			_instanceBank = instanceBank;
			_validatingMethodInjector = validatingMethodInjector;
			_boundInstanceService = boundInstanceService;
			_ownCreator = ownCreator;
		}

		public T GetInstance<T>()
		{
			return (T)GetInstance(typeof(T));
		}

		public IEnumerable<T> GetInstances<T>()
		{
			return GetInstances(typeof(T)).Cast<T>();
		}

		public object GetInstance(Type type)
		{
			if (_instanceBank.TryGetInstance(type, out var instance))
			{
				return instance;
			}
			throw new BinditoException("No binding exists for type " + TypeFormatting.Format(type) + ".");
		}

		public IEnumerable<object> GetInstances(Type type)
		{
			return _instanceBank.GetInstances(type);
		}

		public IEnumerable<object> GetBoundInstances()
		{
			return _boundInstanceService.GetBoundInstances();
		}

		public void Inject(object instance)
		{
			try
			{
				_validatingMethodInjector.Inject(instance);
			}
			catch (Exception innerException)
			{
				throw new BinditoException("Failed to inject into " + TypeFormatting.Format(instance.GetType()) + ".", innerException);
			}
		}

		public IContainer CreateChildContainer(params IConfigurator[] configurators)
		{
			return CreateChildContainer(configurators.AsEnumerable());
		}

		public IContainer CreateChildContainer(IEnumerable<IConfigurator> configurators)
		{
			return _ownCreator.CreateChildContainer(configurators);
		}
	}
}
