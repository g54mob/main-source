using System;

namespace ParadoxNotion.Design
{
	[AttributeUsage(AttributeTargets.Field)]
	public class CallbackAttribute : DrawerAttribute
	{
		public readonly string methodName;

		public override bool isDecorator => false;

		public override int priority => 0;

		public CallbackAttribute(string methodName)
		{
		}
	}
}
