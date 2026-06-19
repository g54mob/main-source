using System;

namespace FullInspector
{
	public static class fiLogicalOperatorSupport
	{
		public static bool GetInitialValue(fiLogicalOperator op)
		{
			return op switch
			{
				fiLogicalOperator.AND => true, 
				fiLogicalOperator.OR => false, 
				_ => throw new NotImplementedException(), 
			};
		}

		public static bool Combine(fiLogicalOperator op, bool a, bool b)
		{
			return op switch
			{
				fiLogicalOperator.AND => a && b, 
				fiLogicalOperator.OR => a || b, 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
