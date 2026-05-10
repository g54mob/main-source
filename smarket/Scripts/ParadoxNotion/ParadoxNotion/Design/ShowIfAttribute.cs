using System;

namespace ParadoxNotion.Design
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ShowIfAttribute : DrawerAttribute
	{
		public readonly string fieldName;

		public readonly int checkValue;

		public override bool isDecorator => false;

		public override int priority => 0;

		public ShowIfAttribute(string fieldName, int checkValue)
		{
		}
	}
}
