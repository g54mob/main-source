using System;

namespace GameCreator.Runtime.Common
{
	public static class ExecutionOrderUtils
	{
		[Obsolete("Use ApplicationManager.EXECUTION_ORDER_FIRST")]
		public const int EARLY = -100;

		[Obsolete("Use ApplicationManager.EXECUTION_ORDER_DEFAULT")]
		public const int DEFAULT = 0;

		[Obsolete("Use ApplicationManager.EXECUTION_ORDER_LAST")]
		public const int LATER = 100;
	}
}
