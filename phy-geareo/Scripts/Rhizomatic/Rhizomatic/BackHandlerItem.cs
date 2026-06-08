using System;

namespace Rhizomatic
{
	public class BackHandlerItem
	{
		public Func<bool> func;

		public BackHandlerItem(Func<bool> func)
		{
		}

		public bool Pop()
		{
			return false;
		}

		public void Remove()
		{
		}
	}
}
