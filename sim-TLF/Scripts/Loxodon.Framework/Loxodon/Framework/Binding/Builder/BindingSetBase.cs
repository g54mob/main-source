using System;
using System.Collections.Generic;
using Loxodon.Framework.Binding.Contexts;
using Loxodon.Log;

namespace Loxodon.Framework.Binding.Builder
{
	public abstract class BindingSetBase : IBindingBuilder
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BindingSetBase));

		protected IBindingContext context;

		protected readonly List<IBindingBuilder> builders = new List<IBindingBuilder>();

		public BindingSetBase(IBindingContext context)
		{
			this.context = context;
		}

		public virtual void Build()
		{
			foreach (IBindingBuilder builder in builders)
			{
				try
				{
					builder.Build();
				}
				catch (Exception ex)
				{
					if (log.IsErrorEnabled)
					{
						log.ErrorFormat("{0}", ex);
					}
				}
			}
			builders.Clear();
		}
	}
}
