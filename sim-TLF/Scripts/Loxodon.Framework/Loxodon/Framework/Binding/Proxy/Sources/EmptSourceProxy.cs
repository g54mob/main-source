using System;
using System.Diagnostics;
using Loxodon.Log;

namespace Loxodon.Framework.Binding.Proxy.Sources
{
	public class EmptSourceProxy : SourceProxyBase, IObtainable, IModifiable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(EmptSourceProxy));

		private SourceDescription description;

		public override Type Type => typeof(object);

		public EmptSourceProxy(SourceDescription description)
			: base(null)
		{
			this.description = description;
		}

		public virtual object GetValue()
		{
			return null;
		}

		public virtual TValue GetValue<TValue>()
		{
			return default(TValue);
		}

		public virtual void SetValue(object value)
		{
		}

		public virtual void SetValue<TValue>(TValue value)
		{
		}

		[Conditional("DEBUG")]
		private void DebugWarning()
		{
			if (log.IsWarnEnabled)
			{
				log.WarnFormat("this is an empty source proxy,If you see this, then the DataContext is null.The SourceDescription is \"{0}\"", description.ToString());
			}
		}
	}
}
