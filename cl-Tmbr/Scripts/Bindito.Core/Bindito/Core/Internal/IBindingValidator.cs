using System;

namespace Bindito.Core.Internal
{
	public interface IBindingValidator
	{
		void Validate(Type type, ProvisionBinding provisionBinding);
	}
}
