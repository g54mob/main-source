using System;
using System.Diagnostics;

namespace Animancer
{
	[AttributeUsage(AttributeTargets.Field)]
	[Conditional("UNITY_EDITOR")]
	public class DefaultValueAttribute : Attribute
	{
		public virtual object Primary { get; protected set; }

		public virtual object Secondary { get; protected set; }

		public DefaultValueAttribute(object primary, object secondary = null)
		{
			Primary = primary;
			Secondary = secondary;
		}

		protected DefaultValueAttribute()
		{
		}
	}
}
