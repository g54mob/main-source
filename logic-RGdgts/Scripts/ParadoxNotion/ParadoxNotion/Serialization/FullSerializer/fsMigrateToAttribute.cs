using System;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public class fsMigrateToAttribute : Attribute
	{
		public readonly Type targetType;

		public fsMigrateToAttribute(Type targetType)
		{
		}
	}
}
