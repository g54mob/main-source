using System;

namespace Castle.Components.DictionaryAdapter
{
	public abstract class DictionaryBehaviorAttribute : Attribute, IDictionaryBehavior
	{
		public const int FirstExecutionOrder = 0;

		public const int DefaultExecutionOrder = 1073741823;

		public const int LastExecutionOrder = int.MaxValue;

		public int ExecutionOrder { get; set; }

		public DictionaryBehaviorAttribute()
		{
			ExecutionOrder = 1073741823;
		}

		public virtual IDictionaryBehavior Copy()
		{
			return this;
		}
	}
}
