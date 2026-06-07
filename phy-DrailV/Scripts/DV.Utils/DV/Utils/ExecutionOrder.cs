using System;

namespace DV.Utils
{
	public class ExecutionOrder : Attribute
	{
		public int Order;

		public ExecutionOrder(int order)
		{
			Order = order;
		}
	}
}
