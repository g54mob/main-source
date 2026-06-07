using System;

namespace Reactivity
{
	public class CString : Computed<string>
	{
		public CString(Func<string> getter)
			: base((Func<string>)null)
		{
		}
	}
}
