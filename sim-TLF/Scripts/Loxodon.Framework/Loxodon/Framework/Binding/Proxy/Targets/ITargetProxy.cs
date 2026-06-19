using System;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public interface ITargetProxy : IBindingProxy, IDisposable
	{
		Type Type { get; }

		TypeCode TypeCode { get; }

		object Target { get; }

		BindingMode DefaultMode { get; }
	}
}
