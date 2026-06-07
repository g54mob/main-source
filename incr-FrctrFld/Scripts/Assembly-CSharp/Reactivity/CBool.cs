using System;

namespace Reactivity
{
	public class CBool : Computed<bool>
	{
		public CBool(Func<bool> getter)
			: base((Func<bool>)null)
		{
		}
	}
}
