using System;

namespace Loxodon.Framework.Binding.Proxy.Sources
{
	public abstract class SourceProxyBase : BindingProxyBase, ISourceProxy, IBindingProxy, IDisposable
	{
		protected TypeCode typeCode;

		protected readonly object source;

		public abstract Type Type { get; }

		public virtual TypeCode TypeCode
		{
			get
			{
				if (typeCode == TypeCode.Empty)
				{
					typeCode = Type.GetTypeCode(Type);
				}
				return typeCode;
			}
		}

		public virtual object Source => source;

		public SourceProxyBase(object source)
		{
			this.source = source;
		}
	}
}
