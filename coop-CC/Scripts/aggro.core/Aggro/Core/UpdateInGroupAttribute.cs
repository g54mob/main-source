using System;

namespace Aggro.Core
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class UpdateInGroupAttribute : Attribute
	{
		internal readonly Type groupType;

		internal readonly int priority;

		public UpdateInGroupAttribute(Type groupType, UpdatePriority priority = UpdatePriority.Normal)
			: this(groupType, (int)priority)
		{
		}

		public UpdateInGroupAttribute(Type groupType, int priority)
		{
			this.groupType = groupType;
			this.priority = priority;
		}

		public UpdateInGroupAttribute(UpdatePriority priority)
			: this(null, priority)
		{
		}

		public UpdateInGroupAttribute(int priority)
			: this(null, priority)
		{
		}
	}
}
