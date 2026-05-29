using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace UI
{
	public record RouteEventDialogParam(eRouteEvent routeNode)
	{
		[CompilerGenerated]
		protected virtual Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public eRouteEvent routeNode { get; set; }

		[CompilerGenerated]
		public override string ToString()
		{
			return null;
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public virtual bool Equals(RouteEventDialogParam? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected RouteEventDialogParam(RouteEventDialogParam original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out eRouteEvent routeNode)
		{
			routeNode = default(eRouteEvent);
		}
	}
}
