using System;

namespace Loxodon.Framework.Binding.Proxy.Sources.Text
{
	public class LiteralSourceProxy : SourceProxyBase, ISourceProxy, IBindingProxy, IDisposable, IObtainable
	{
		public override Type Type
		{
			get
			{
				if (source == null)
				{
					return typeof(object);
				}
				return source.GetType();
			}
		}

		public LiteralSourceProxy(object source)
			: base(source)
		{
		}

		public virtual object GetValue()
		{
			return source;
		}

		public virtual TValue GetValue<TValue>()
		{
			return (TValue)Convert.ChangeType(source, typeof(TValue));
		}
	}
}
