using System;

namespace Bindito.Core.Internal
{
	public class ProvisionBinding
	{
		public Type Type { get; }

		public Type ProviderType { get; }

		public IProvider<object> ProviderInstance { get; }

		public Func<object> ProvidingMethod { get; }

		public object Instance { get; }

		public Type ExistingType { get; }

		private ProvisionBinding(Type type, Type providerType, IProvider<object> providerInstance, Func<object> providingMethod, object instance, Type existingType)
		{
			Type = type;
			ProviderType = providerType;
			ProviderInstance = providerInstance;
			ProvidingMethod = providingMethod;
			Instance = instance;
			ExistingType = existingType;
		}

		public static ProvisionBinding CreateToType(Type type)
		{
			return new ProvisionBinding(type, null, null, null, null, null);
		}

		public static ProvisionBinding CreateToProviderType(Type providerType)
		{
			return new ProvisionBinding(null, providerType, null, null, null, null);
		}

		public static ProvisionBinding CreateToProviderInstance(IProvider<object> provider)
		{
			return new ProvisionBinding(null, null, provider, null, null, null);
		}

		public static ProvisionBinding CreateToProvidingMethod(Func<object> providingMethod)
		{
			return new ProvisionBinding(null, null, null, providingMethod, null, null);
		}

		public static ProvisionBinding CreateToInstance(object instance)
		{
			return new ProvisionBinding(null, null, null, null, instance, null);
		}

		public static ProvisionBinding CreateToExisting(Type type)
		{
			return new ProvisionBinding(null, null, null, null, null, type);
		}

		public override string ToString()
		{
			if (Type != null)
			{
				return "Type(" + TypeFormatting.Format(Type) + ")";
			}
			if (ProviderType != null)
			{
				return "ProviderType(" + TypeFormatting.Format(ProviderType) + ")";
			}
			if (ProviderInstance != null)
			{
				return string.Format("{0}({1})", "ProviderInstance", ProviderInstance);
			}
			if (ProvidingMethod != null)
			{
				return string.Format("{0}({1})", "ProvidingMethod", ProvidingMethod);
			}
			if (Instance != null)
			{
				return string.Format("{0}({1})", "Instance", Instance);
			}
			if (ExistingType != null)
			{
				return "ExistingType(" + TypeFormatting.Format(ExistingType) + ")";
			}
			throw new InvalidOperationException("This is an internal Bindito error!");
		}

		public bool TryGetBindingType(out Type bindingType)
		{
			if (ProvidingMethod != null)
			{
				bindingType = null;
				return false;
			}
			bindingType = GetBindingType();
			return true;
		}

		private Type GetBindingType()
		{
			if (Type != null)
			{
				return Type;
			}
			if (ProviderType != null)
			{
				return ProviderType;
			}
			if (ProviderInstance != null)
			{
				return ProviderInstance.GetType();
			}
			if (Instance != null)
			{
				return Instance.GetType();
			}
			if (ExistingType != null)
			{
				return ExistingType;
			}
			throw new InvalidOperationException("Binding type not found for " + ToString());
		}
	}
}
