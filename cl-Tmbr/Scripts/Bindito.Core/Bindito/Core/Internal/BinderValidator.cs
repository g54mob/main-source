using System;
using System.Collections.Generic;

namespace Bindito.Core.Internal
{
	public class BinderValidator
	{
		private readonly IBindingValidator _bindingValidator;

		private readonly IBinder _binder;

		public BinderValidator(IBindingValidator bindingValidator, IBinder binder)
		{
			_bindingValidator = bindingValidator;
			_binder = binder;
		}

		public void Validate()
		{
			ValidateBindings();
			ValidateMultiBindings();
		}

		private void ValidateBindings()
		{
			foreach (KeyValuePair<Type, Binding> binding in _binder.Bindings)
			{
				_bindingValidator.Validate(binding.Key, binding.Value.ProvisionBinding);
			}
		}

		private void ValidateMultiBindings()
		{
			foreach (KeyValuePair<Type, IReadOnlyList<Binding>> multiBinding in _binder.MultiBindings)
			{
				foreach (Binding item in multiBinding.Value)
				{
					_bindingValidator.Validate(multiBinding.Key, item.ProvisionBinding);
				}
			}
		}
	}
}
