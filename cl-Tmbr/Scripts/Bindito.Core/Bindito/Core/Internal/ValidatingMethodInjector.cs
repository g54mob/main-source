using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public class ValidatingMethodInjector : IValidatingMethodInjector
	{
		private readonly IMethodInjector _methodInjector;

		private readonly IBindingValidator _bindingValidator;

		private readonly HashSet<Type> _validatedTypesOfInstances = new HashSet<Type>();

		public ValidatingMethodInjector(IMethodInjector methodInjector, IBindingValidator bindingValidator)
		{
			_methodInjector = methodInjector;
			_bindingValidator = bindingValidator;
		}

		public void Inject(object instance)
		{
			Validate(instance);
			_methodInjector.Inject(instance);
		}

		private void Validate(object instance)
		{
			Type type = instance.GetType();
			if (!_validatedTypesOfInstances.Contains(type))
			{
				ProvisionBinding provisionBinding = ProvisionBinding.CreateToInstance(instance);
				_bindingValidator.Validate(type, provisionBinding);
				_validatedTypesOfInstances.Add(type);
			}
		}
	}
}
