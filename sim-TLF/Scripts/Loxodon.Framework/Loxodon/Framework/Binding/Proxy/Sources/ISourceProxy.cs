using System;

namespace Loxodon.Framework.Binding.Proxy.Sources
{
	public interface ISourceProxy : IBindingProxy, IDisposable
	{
		Type Type { get; }

		TypeCode TypeCode { get; }

		object Source { get; }
	}
}
