using System;

namespace ParadoxNotion.Design
{
	public class ExecutionPriorityAttribute : Attribute
	{
		public readonly int priority;

		public ExecutionPriorityAttribute(int priority)
		{
		}
	}
}
