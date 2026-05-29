using System;

namespace ParadoxNotion.Design
{
	[AttributeUsage(AttributeTargets.Field)]
	public abstract class DrawerAttribute : Attribute
	{
		public virtual int priority => 0;

		public virtual bool isDecorator => false;
	}
}
