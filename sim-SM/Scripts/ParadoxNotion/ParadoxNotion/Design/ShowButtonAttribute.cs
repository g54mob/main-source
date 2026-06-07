using System;

namespace ParadoxNotion.Design
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ShowButtonAttribute : DrawerAttribute
	{
		public readonly string buttonTitle;

		public readonly string methodName;

		public override bool isDecorator => false;

		public override int priority => 0;

		public ShowButtonAttribute(string buttonTitle, string methodnameCallback)
		{
		}
	}
}
